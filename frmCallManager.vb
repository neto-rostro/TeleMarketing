Imports ggcAppDriver
Imports ggcMCSales
Imports ATSMS
Imports ATSMS.SMS
Imports ATSMS.Common
Imports System.Globalization
Imports System.Threading

Public Class frmCallManager
    Private Const psModemName As String = "HuaweiModem"
    Private Const pxeMsgHeader As String = "frmCallManager"
    Private Const pxeDefaultDate As String = "1900-01-01 00:00:00"
    Private Const pxeIdleTime As Integer = 300

    Private WithEvents oTrans As ggcMCSales.OGCallManager
    Private WithEvents oSMSxx As ggcMCSales.ISMSManager
    Private WithEvents oModem As ATSMS.GSMModem
    Private oINI As ggcAppDriver.INIFile

    Dim pbLoaded As Boolean
    Dim pbReady As Boolean      'detail is loaded
    Dim pbConnected As Boolean  'we are connected to modem
    Dim pbDialling As Boolean   'call is initiating
    Dim pbTalking As Boolean    'call is ongoing
    Dim pbSMSProc As Boolean    'processing hotline sms
    Dim pbHistory As Boolean    'history visibility
    Dim pbApproval As Boolean   'approval visibility
    Dim pbAppIssued As Boolean  'is approval code issued?

    Dim pdCallStart As Date     'start of conversation
    Dim pdCallEnd As Date       'end of conversation
    Dim pbIdle As Boolean       'check call status
    Dim pbSMSRtrvl As Boolean   'modem is retrieving ssm
    Dim pnIdleInterval As Integer = 0

    Dim poHistory As DataTable
    Dim pnLeadsxx As Integer = 0
    Dim lnDialCtr As Integer = 0
    Dim lnRingCtr As Integer = 0

    Dim p_nSubscrbr As Integer = 0

    Enum xeCallStat
        xeOpen = 0
        xeQueued = 1
        xeCalled = 2
        xeDiscarded = 3
    End Enum

    Private Sub frmCallManager_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not pbLoaded Then
            Application.DoEvents()
            Timer1.Enabled = True
            pbConnected = False

            'initialize modem after form load.
            Call ConnectModem()

            isModemConnected()

            'NewTransaction()
            SelectLeads()

            pbLoaded = True
        End If
    End Sub

    Private Sub frmCallManager_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        pbLoaded = False
    End Sub

    Private Sub frmCallManager_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If pbConnected Then oModem.Disconnect()

        oTrans = Nothing
        oSMSxx = Nothing
        oModem = Nothing
    End Sub

    Private Sub frmCallManager_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        With oTrans
            Select Case e.KeyCode
                Case Keys.F1 'start call
                    StartCall()
                Case Keys.F2 'end call
                    EndCall()
                Case Keys.F3 'save transaction
                    If pbConnected Then
                        If SaveTransaction() Then NewTransaction()
                    Else
                        MsgBox("This feature is disabled on agents without GSM Device.", vbInformation, pxeMsgHeader)
                    End If
                Case Keys.F4 'get next customer
                    NewTransaction()
                Case Keys.F5 'choose leads
                    SelectLeads()
                Case Keys.F6
                    'showHistory()
                    'ProcessHistory()
                Case Keys.F7 'issue approval code
                Case Keys.F8 'process sms
                    showSMS()
                    ProcessSMS()
                Case Keys.F9 'process call
                Case Keys.F10 'product info cars
                    showInquiry()
                Case Keys.F11 'product info motorcycle
                Case Keys.F12 'product info mobile phone
                Case Keys.Escape 'exit form
                    ConfirmExit()
            End Select
        End With
    End Sub

    Private Sub frmCallManager_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        oTrans = New ggcMCSales.OGCallManager(p_oAppDriver)
        oTrans.Subscriber = ""

        oSMSxx = New ggcMCSales.ISMSManager(p_oAppDriver)

        InitForm()

        Label14.Text = p_oAppDriver.getSysDate.ToString("ddd") & ", " & p_oAppDriver.getSysDate.ToString("MMM dd, yyyy")
    End Sub

    Private Sub frmCallManager_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        pbIdle = True
    End Sub

    Private Sub frmCallManager_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        pbIdle = False
        pnIdleInterval = 0
    End Sub

    Private Sub txtField_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtField80.KeyDown
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        Select Case e.KeyCode
            Case Keys.Return
                If loIndex = 80 Then
                    oTrans.Master(loIndex) = loTxt.Text
                End If
        End Select
    End Sub

    Private Sub cmdSMSBut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSMSBut00.Click, _
        cmdSMSBut01.Click, cmdSMSBut02.Click, cmdSMSBut03.Click

        Dim loButt As Button
        loButt = CType(sender, System.Windows.Forms.Button)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        With oSMSxx
            If Mid(loButt.Name, 1, 9) = "cmdSMSBut" Then
                Select Case loIndex
                    Case 0 'save
                        If chkSchedSMS.Checked = True Then
                            .isCallAgain = True
                            .CallDate = dtpSMS1.Value.ToString("MM-dd-yyyy") & " " & dtpSMS2.Value.ToString("H:mm:ss")

                            If .SaveTransaction() Then
                                MsgBox("Record Updated Successfuly.", MsgBoxStyle.Information, pxeMsgHeader)
                            End If
                        ElseIf chkUpdateSMS.Checked = True Then
                            .isSMSUpdate = True
                            .Master("sMessagex") = txtSMSxx03.Text

                            If .SaveTransaction() Then
                                chkUpdateSMS.Checked = False
                                MsgBox("Record Updated Successfuly.", MsgBoxStyle.Information, pxeMsgHeader)
                            End If
                        End If
                    Case 1 'disregard
                        If .Disregard() Then
                            'MsgBox("Record Disregarded.", MsgBoxStyle.Information, pxeMsgHeader)
                        End If
                    Case 2 'approve
                        If .Close() Then
                            'MsgBox("Record Closed Successfuly.", MsgBoxStyle.Information, pxeMsgHeader)
                        End If
                    Case 3 'schedule
                        If .Schedule() Then
                            'MsgBox("Record was Scheduled.", MsgBoxStyle.Information, pxeMsgHeader)
                        End If
                End Select
            End If
        End With

        ProcessSMS()
    End Sub

    Private Sub oTrans_MasterRetrieved(ByVal Index As Integer, ByVal Value As Object) Handles oTrans.MasterRetrieved
        Select Case Index
            Case 80
                txtField80.Text = Value
            Case 81
                txtField81.Text = Value
        End Select
    End Sub

    Private Sub PictureBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick, _
        PictureBox2.MouseClick, PictureBox3.MouseClick, PictureBox4.MouseClick, PictureBox5.MouseClick, PictureBox6.MouseClick, _
        PictureBox7.MouseClick, PictureBox8.MouseClick, PictureBox9.MouseClick, PictureBox10.MouseClick, PictureBox11.MouseClick, _
        PictureBox12.MouseClick, PictureBox13.MouseClick, cmdClose.MouseClick

        Dim loPic As PictureBox
        loPic = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loPic.Name, 11))

        If Mid(loPic.Name, 1, 10) = "PictureBox" Then
            If pnLeadsxx <> 4 Then
                Select Case loIndex
                    Case 1 : StartCall()
                    Case 2 : EndCall()
                    Case 3
                        If pbConnected Then
                            If SaveTransaction() Then NewTransaction()
                        Else
                            MsgBox("This feature is disabled on agents without GSM Device.", vbInformation, pxeMsgHeader)
                        End If
                    Case 4 : NewTransaction()
                    Case 5 : SelectLeads()
                    Case 6
                    Case 7
                    Case 8
                        showSMS()
                        ProcessSMS()
                    Case 9 'process call
                    Case 10 'product info cars
                        showInquiry()
                    Case 11 'product info motorcycle
                    Case 12 'product info mobile phone
                    Case 13 'exit form
                        ConfirmExit()
                End Select
            Else
                Select Case loIndex
                    Case 1 : StartCall()
                    Case 2 : EndCall()
                    Case 3
                    Case 4
                    Case 5 : SelectLeads()
                    Case 6
                    Case 7
                    Case 8
                    Case 9 'process call
                    Case 10 'product info cars
                    Case 11 'product info motorcycle
                    Case 12 'product info mobile phone
                    Case 13 'exit form
                End Select
            End If
        Else
            ConfirmExit()
        End If
    End Sub

    Private Sub PictureBox_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover, _
        PictureBox2.MouseHover, PictureBox3.MouseHover, PictureBox4.MouseHover, PictureBox5.MouseHover, PictureBox6.MouseHover, _
        PictureBox7.MouseHover, PictureBox8.MouseHover, PictureBox9.MouseHover, PictureBox10.MouseHover, PictureBox11.MouseHover, _
        PictureBox12.MouseHover, PictureBox13.MouseHover

        Dim loPic As PictureBox
        loPic = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loPic.Name, 11))

        If Mid(loPic.Name, 1, 10) = "PictureBox" Then
            Select Case loIndex
                Case 1 : loPic.BackgroundImage = My.Resources.F1
                Case 2 : loPic.BackgroundImage = My.Resources.F2
                Case 3 : loPic.BackgroundImage = My.Resources.F3
                Case 4 : loPic.BackgroundImage = My.Resources.F4
                Case 5 : loPic.BackgroundImage = My.Resources.F5
                Case 6 : loPic.BackgroundImage = My.Resources.F6
                Case 7 : loPic.BackgroundImage = My.Resources.F7
                Case 8 : loPic.BackgroundImage = My.Resources.F8
                Case 9 : loPic.BackgroundImage = My.Resources.F9
                Case 10 : loPic.BackgroundImage = My.Resources.F10
                Case 11 : loPic.BackgroundImage = My.Resources.F11
                Case 12 : loPic.BackgroundImage = My.Resources.F12
                Case 13 : loPic.BackgroundImage = My.Resources.ESC
            End Select
        End If
    End Sub

    Private Sub PictureBox_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave, _
        PictureBox2.MouseLeave, PictureBox3.MouseLeave, PictureBox4.MouseLeave, PictureBox5.MouseLeave, PictureBox6.MouseLeave, _
        PictureBox7.MouseLeave, PictureBox8.MouseLeave, PictureBox9.MouseLeave, PictureBox10.MouseLeave, PictureBox11.MouseLeave, _
        PictureBox12.MouseLeave, PictureBox13.MouseLeave

        Dim loPic As PictureBox
        loPic = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loPic.Name, 11))

        If Mid(loPic.Name, 1, 10) = "PictureBox" Then
            Select Case loIndex
                Case 1 : loPic.BackgroundImage = My.Resources._call
                Case 2 : loPic.BackgroundImage = My.Resources._end
                Case 3 : loPic.BackgroundImage = My.Resources.save
                Case 4 : loPic.BackgroundImage = My.Resources._next
                Case 5 : loPic.BackgroundImage = My.Resources.refresh
                Case 6 : loPic.BackgroundImage = My.Resources.history
                Case 7 : loPic.BackgroundImage = My.Resources.code_approval
                Case 8 : loPic.BackgroundImage = My.Resources.sms
                Case 9 : loPic.BackgroundImage = My.Resources.calls
                Case 10 : loPic.BackgroundImage = My.Resources.car
                Case 11 : loPic.BackgroundImage = My.Resources.motor
                Case 12 : loPic.BackgroundImage = My.Resources.cellphone
                Case 13 : loPic.BackgroundImage = My.Resources.close
            End Select
        End If
    End Sub

    Private Sub cmdClose_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdClose.MouseDown
        cmdClose.BackgroundImage = My.Resources.Close_OnMouseDown
    End Sub

    Private Sub cmdClose_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.MouseHover
        cmdClose.BackgroundImage = My.Resources.Close_OnMouseOver
    End Sub

    Private Sub cmdClose_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.MouseLeave
        cmdClose.BackgroundImage = My.Resources.Close_Large
    End Sub

    Private Sub chkSchedule_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSchedSMS.CheckedChanged
        dtpSMS1.Value = p_oAppDriver.getSysDate
        dtpSMS2.Value = p_oAppDriver.getSysDate

        dtpSMS1.Visible = chkSchedSMS.Checked
        dtpSMS2.Visible = chkSchedSMS.Checked
        cmdSMSBut00.Visible = chkSchedSMS.Checked
    End Sub

    Private Sub chkSchedCall_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSchedCall.CheckedChanged
        dtpCall1.Value = p_oAppDriver.getSysDate
        dtpCall2.Value = p_oAppDriver.getSysDate

        dtpCall1.Visible = chkSchedCall.Checked
        dtpCall2.Visible = chkSchedCall.Checked
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim ci As CultureInfo = CultureInfo.InvariantCulture
        Application.DoEvents()
        Label10.Text = p_oAppDriver.getSysDate.ToString("hh:mm:ss.F", ci)

        If pbIdle Then
            If pnIdleInterval >= pxeIdleTime Then
                If isValidMobile(oTrans.Master("sMobileNo")) Then
                    getSignalQuality(oModem.GetRssi.Current())
                    lblCallStat.Text = "Retreiving Messages..."
                    Dim lnCtr As Integer
                    Dim msgStore As MessageStore = oModem.MessageStore
                    oModem.MessageMemory = EnumMessageMemory.SM
                    msgStore.Refresh()

                    For lnCtr = 0 To msgStore.Count - 1
                        oModem.DeleteSMS(lnCtr, EnumSMSDeleteOption.All_Messages)
                    Next
                    getSignalQuality(oModem.GetRssi.Current())
                End If

                getSignalQuality(oModem.GetRssi.Current())
                pnIdleInterval = 0
            End If
        End If
    End Sub

    Private Sub gridHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridHistory.Click
        loadRowHist()
    End Sub

#Region "Interface Process"
    Private Sub InitForm()
        ClearSMS()
        ClearFields()
        InitFields()

        InitGridHistory()
    End Sub

    Private Sub InitGridHistory()
        With gridHistory.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(gridHistory.Font, FontStyle.Bold)
        End With

        With gridHistory
            .ColumnCount = 6
            .RowCount = 1

            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False

            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .GridColor = SystemColors.ActiveBorder
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False

            .Columns(0).Width = 30
            .Columns(1).Width = 130
            .Columns(2).Width = 105
            .Columns(3).Width = 105
            .Columns(4).Width = 105
            .Columns(5).Width = 0

            .Columns(0).Name = "No"
            .Columns(1).Name = "Table Name"
            .Columns(2).Name = "Reference"
            .Columns(3).Name = "Date"
            .Columns(4).Name = "Status"
            .Columns(5).Name = ""

            .Rows(0).Selected = True
        End With

        ClearHistory()
    End Sub

    Private Sub InitFields()
        Dim lbShow As Boolean = oTrans.EditMode = xeEditMode.MODE_READY

        txtField4.Visible = lbShow
        txtField80.Visible = lbShow
        txtField81.Visible = lbShow

        pnlHistory.Visible = False
        pnlCall.Visible = False
        pnlSMS.Visible = False
        pnlAppCode.Visible = False

        cmdSMSBut00.Visible = False
        dtpSMS1.Visible = False
        dtpSMS2.Visible = False
        dtpCall1.Visible = False
        dtpCall2.Visible = False

        chkSchedCall.Checked = False
        chkSchedSMS.Checked = False

        pbIdle = False
        pbReady = False
        pbSMSProc = False
        pbTalking = False
        pbDialling = False
        pbSMSRtrvl = False
        pbHistory = False
        pbApproval = False
        pbAppIssued = False
    End Sub

    Private Sub ClearHistory()
        txtHistx00.Text = ""
        txtHistx01.Text = ""
        txtHistx02.Text = ""
        txtHistx03.Text = ""
        txtHistx04.Text = ""
        txtHistx05.Text = ""
    End Sub

    Private Sub ClearFields()
        lblField3.Text = ""
        lblStart.Text = "00:00:00"
        lblEnd.Text = "00:00:00"
        lblLeads.Text = "0"

        txtField4.Text = ""
        txtField80.Text = ""
        txtField81.Text = ""

        lblCallStat.Text = "Idle"
    End Sub

    Private Sub ClearSMS()
        txtSMSxx01.Text = ""
        txtSMSxx03.Text = ""
        txtSMSxx04.Text = ""

        chkSchedSMS.Checked = False
        cmdSMSBut00.Visible = False
    End Sub

    Private Sub showSMS()
        If pbDialling = True Or pbTalking = True Then Exit Sub

        pbSMSProc = Not pbSMSProc

        pnlSMS.Visible = pbSMSProc
    End Sub

    Private Sub showHistory()
        If Not pbReady Then Exit Sub

        pbHistory = Not pbHistory

        pnlHistory.Visible = pbHistory
    End Sub

    Private Sub showApproval()
        If Not pbReady Then Exit Sub

        pbApproval = Not pbApproval

        pnlAppCode.Visible = pbApproval
    End Sub

    Private Sub ConfirmExit()
        If showMsg("Call Module will close." & vbCrLf & vbCrLf & "Do you want to continue?", _
                                MsgBoxStyle.YesNo) Then Me.Close()
    End Sub

    Private Sub SelectLeads()
        'Dim loForm As frmLeadsOptions

        'loForm = New frmLeadsOptions

        'loForm.Current = pnLeadsxx
        'loForm.ShowDialog()
        'pnLeadsxx = loForm.Leads

        ''mac 2020-05-19
        ''custom call
        'initButtons(pnLeadsxx)
        'If pnLeadsxx = 4 Then Exit Sub

        'oTrans.LeadSource = pnLeadsxx

        'loForm = Nothing

        With oTrans
            .Subscriber = pxeSubscribr
            .NewTransaction()

            If .GetLeadsTotal <= 0 Then
                If pnLeadsxx = 0 Then
                    showMsg("No leads detected for the current source!!!" & vbCrLf & _
                        "Please inform MIS Dept!!!")
                Else
                    showMsg("No leads detected for the selected source!!!" & vbCrLf & _
                        "Please inform MIS Dept., for the meantime i'll redirect you to default source.")
                End If

                pnLeadsxx = 0
                oTrans.LeadSource = pnLeadsxx
                .NewTransaction()
            End If

            If .OpenTransaction(.Get2Call) Then
                LoadTransaction()
                lblLeads.Text = .GetLeadsTotal

                showHistory()
                ProcessHistory()
            End If

            pdCallStart = pxeDefaultDate
            pdCallEnd = pxeDefaultDate
            pbAppIssued = False
            pbIdle = True
        End With
    End Sub

    Private Sub initButtons(ByVal fnValue As Integer)
        Dim lbShow As Boolean = fnValue <> 4

        PictureBox3.Visible = lbShow
        PictureBox4.Visible = lbShow
        PictureBox5.Visible = lbShow
        PictureBox6.Visible = lbShow
        PictureBox7.Visible = lbShow
        PictureBox8.Visible = lbShow
        PictureBox9.Visible = lbShow
        PictureBox10.Visible = lbShow
        PictureBox11.Visible = lbShow
        PictureBox12.Visible = lbShow
        PictureBox13.Visible = lbShow

        pnlHistory.Visible = lbShow
        pnlSMS.Visible = lbShow
        pnlAppCode.Visible = lbShow
        pnlHistory.Visible = lbShow
        pnlCall.Visible = lbShow
    End Sub

    Private Sub showInquiry()
        Dim loForm As frmProductInquiry

        loForm = New frmProductInquiry
        loForm.ShowDialog()
    End Sub

    Private Function showMsg(ByVal Prompt As Object, _
                                Optional ByVal Buttons As MsgBoxStyle = MsgBoxStyle.OkOnly) As Boolean

        Select Case Buttons
            Case MsgBoxStyle.OkOnly
                Dim loForm As frmShowMsgOk

                loForm = New frmShowMsgOk

                loForm.Msg = Prompt
                loForm.ShowDialog()

                Return Not loForm.Cancelled
            Case MsgBoxStyle.OkCancel, MsgBoxStyle.YesNo
                Dim loForm As frmShowMsg

                loForm = New frmShowMsg

                loForm.Msg = Prompt
                loForm.MsgStyle = Buttons
                loForm.ShowDialog()

                Return Not loForm.Cancelled
            Case Else 'only 3 styles are supported by showMsg
                Return False
        End Select
    End Function
#End Region

#Region "Call/SMS Procedures"
    Private Sub EndCall()
        If pbDialling = False And pbTalking = False Then
            MsgBox("It seems that you did not start a call." & vbCrLf & vbCrLf & _
                "Please start every call by pressing F1 button or key from the keyboard.", vbInformation, pxeMsgHeader)
            Exit Sub
        End If


        Dim ci As CultureInfo = CultureInfo.InvariantCulture

        If Not pbConnected Then
            'not custom call
            If pnLeadsxx <> 4 Then
                pdCallEnd = p_oAppDriver.getSysDate
                lblEnd.Text = pdCallEnd.ToString("hh:mm:ss.F", ci)
                lblCallStat.Text = "Call Ended"

                SaveTransaction() 'save the transaction upon end
                NewTransaction() 'automatically get new customer on end of conversation
            Else
                InitFields()
                pbIdle = True
                lblCallStat.Text = "Call Ended"
            End If
        Else
            If Not isModemConnected() Then Exit Sub

            oModem.CHUPHangUp()

            'not custom call
            If pnLeadsxx <> 4 Then
                pdCallEnd = p_oAppDriver.getSysDate
                lblEnd.Text = pdCallEnd.ToString("hh:mm:ss.F", ci)
                lblCallStat.Text = "Call Ended"

                SaveTransaction() 'save the transaction upon end
                NewTransaction() 'automatically get new customer on end of conversation
            Else
                InitFields()
                pbIdle = True
                lblCallStat.Text = "Call Ended"
            End If
        End If
    End Sub

    Private Sub StartCall()
        If pnLeadsxx <> 4 Then
            'not custom call
            If pbReady = False Then Exit Sub

            'no modem
            If Not pbConnected Then
                pdCallStart = p_oAppDriver.getSysDate
                pbDialling = True
                pbTalking = True

                Dim ci As CultureInfo = CultureInfo.InvariantCulture
                lblStart.Text = pdCallStart.ToString("hh:mm:ss.F", ci)
            Else
                If Not isModemConnected() Then Exit Sub

                If pbDialling = True Or pbTalking = True Then
                    MsgBox("System is in dial/talking mode.", MsgBoxStyle.Information, pxeMsgHeader)
                    Exit Sub
                End If

                If pbSMSProc = True Then showSMS()

                If oTrans.Master("sMobileNo") <> "" Then
                    getSignalQuality(oModem.GetRssi.Current())
                    oModem.Dial(oTrans.Master("sMobileNo"))
                End If
            End If
        Else
            'custom call
            If Not isModemConnected() Then Exit Sub

            If pbDialling = True Or pbTalking = True Then
                MsgBox("System is in dial/talking mode.", MsgBoxStyle.Information, pxeMsgHeader)
                Exit Sub
            End If

            Dim lsValue As String = InputBox("Please enter the mobile number you'd like to call. e.g 0917XXXXXXX" & vbCrLf & vbCrLf & _
                                                "(Please verify the customer mobile network before call. You may be charged if the network is different from your sim's network.)")

            If Not IsNumeric(lsValue) Or _
                Len(lsValue) <> 11 Or _
                Not (Strings.Left(lsValue, 2) <> "09" Or Strings.Left(lsValue, 2) <> "08") Then

                MsgBox("Invalid mobile number detected", MsgBoxStyle.Critical, "Warning")
                Exit Sub
            End If

            getSignalQuality(oModem.GetRssi.Current())
            oModem.Dial(lsValue)
        End If
    End Sub

    Private Function SaveTransaction(Optional ByVal lnSave As xeCallStat = 2) As Boolean
        Dim loForm As frmCallResult
        Dim pbSuccess As Boolean
        Dim lsAppCode As String = ""

        pbSuccess = False

        loForm = frmCallResult

        If pbReady Then
            With oTrans
                .Master("sRemarksx") = txtField4.Text

                Select Case lnSave
                    Case xeCallStat.xeOpen
                    Case xeCallStat.xeQueued
                        .Master("cTranStat") = "1"
                        pbSuccess = .SaveTransaction()

                        GoTo endProc
                    Case xeCallStat.xeCalled
                        loForm.ShowDialog()
                        If loForm.Cancelled Then GoTo endProc

                        .Master("cTranStat") = "2"
                        .Master("cTLMStatx") = loForm.Result

                        .Master("dCallStrt") = pdCallStart
                        .Master("dCallEndx") = pdCallEnd

                        'iMac 2016.09.24
                        'changed approach for approval code issuance;
                        'only possible sales are entitled for discount.
                        If .Master("cTLMStatx") = "PS" Then
                            lsAppCode = oTrans.IssueCodeApproval()
                        End If

                    Case xeCallStat.xeDiscarded : .Master("cTranStat") = "3"
                End Select

                If chkSchedCall.Checked = True Then
                    .isCallAgain = True
                    .CallDate = dtpCall1.Value.ToString("MM-dd-yyyy") & " " & _
                                dtpCall2.Value.ToString("H:mm:ss")
                End If

                pbSuccess = .SaveTransaction
                If pbSuccess Then
                    If lsAppCode <> "" Then
                        showMsg("Approval code for this client is " & oTrans.IssueCodeApproval() & _
                                    ", will be sent via text message shortly.")
                    End If

                    pbReady = False
                    InitForm()
                End If
            End With
        End If
endProc:
        If lnSave = 2 Then loForm.Close()
        Return pbSuccess
    End Function

    Private Sub NewTransaction()
        With oTrans
            If pbSMSProc = True Then showSMS()
            'If pbHistory = True Then showHistory()

            If pbReady = True And pdCallStart = pxeDefaultDate Then 'client was not transacted
                If showMsg("Client was not called. Discard record?", MsgBoxStyle.YesNo) = True Then
                    .Master("sRemarksx") = txtField4.Text
                    .Master("cTranStat") = "3" 'discarded
                    .SaveTransaction()
                Else : Exit Sub
                End If
            End If

            .Subscriber = pxeSubscribr
            .NewTransaction()
            If .OpenTransaction(.Get2Call) Then
                LoadTransaction()
                lblLeads.Text = .GetLeadsTotal

                showHistory()
                ProcessHistory()
            End If

            pdCallStart = pxeDefaultDate
            pdCallEnd = pxeDefaultDate
            pbAppIssued = False
            pbIdle = True
        End With
    End Sub

    Private Sub LoadTransaction()
        ClearFields()
        InitFields()

        lblField3.Text = oTrans.Master(3)
        txtField4.Text = oTrans.Master(4)
        txtField80.Text = oTrans.Master(80)
        txtField81.Text = oTrans.Master(81)

        If txtField80.Text = "" Then
            txtField80.Focus()
        Else
            txtField4.Focus()
        End If

        lblCallStat.Text = "Ready"

        pbReady = True
        pnlCall.Visible = True
    End Sub

    Private Sub ProcessHistory()
        Dim lnCtr As Integer

        If Not pbReady Then Exit Sub

        poHistory = Nothing
        poHistory = oTrans.getHistory

        If poHistory.Rows.Count <> 0 Then
            With gridHistory
                .RowCount = poHistory.Rows.Count

                If .RowCount > 7 Then
                    .Columns(1).Width = 112
                Else
                    .Columns(1).Width = 130
                End If

                For lnCtr = 0 To poHistory.Rows.Count - 1
                    .Rows(lnCtr).Cells(0).Value = lnCtr + 1
                    .Rows(lnCtr).Cells(1).Value = poHistory(lnCtr)("sTableNme")
                    .Rows(lnCtr).Cells(2).Value = poHistory(lnCtr)("sTransNox")
                    .Rows(lnCtr).Cells(3).Value = Format(poHistory(lnCtr)("dTransact"), "MMM dd, yyyy")

                    Select Case poHistory(lnCtr)("sTableNme")
                        Case "MC_Inquiry", "MC_Referral"
                            .Rows(lnCtr).Cells(4).Value = InquiryStatus(poHistory(lnCtr)("cTranStat"))
                        Case "Call_Incoming", "SMS_Incoming"
                            .Rows(lnCtr).Cells(4).Value = CallIntatus(IFNull(poHistory(lnCtr)("cTranStat"), "0"))
                        Case "Call_Outgoing", "SMS_Outgoing"
                            .Rows(lnCtr).Cells(4).Value = CallOutStatus(poHistory(lnCtr)("cTranStat"))
                        Case "MC_SO_Master"
                            .Rows(lnCtr).Cells(4).Value = MCSalesStatus(poHistory(lnCtr)("cTranStat"))
                        Case "Ganado_Online"
                            .Rows(lnCtr).Cells(4).Value = MCSalesStatus(poHistory(lnCtr)("cTranStat"))
                    End Select
                    .Rows(lnCtr).Cells(5).Value = poHistory(lnCtr)("sSourceNm")
                Next
                .Rows(0).Selected = True

                Call gridHistory_Click(New Object(), New EventArgs())
            End With
        End If
    End Sub

    Private Sub loadRowHist()
        If IsNothing(poHistory) Then Exit Sub
        If poHistory.Rows.Count = 0 Then Exit Sub

        Dim lnRow As Integer = gridHistory.CurrentRow.Index

        txtHistx00.Text = poHistory(lnRow)(0)
        txtHistx01.Text = IFNull(poHistory(lnRow)(1))
        txtHistx03.Text = poHistory(lnRow)(3)
        txtHistx04.Text = poHistory(lnRow)(4)
        txtHistx05.Text = poHistory(lnRow)(5)

        Select Case poHistory(lnRow)("sTableNme")
            Case "MC_Inquiry", "MC_Referral"
                txtHistx02.Text = InquiryStatus(poHistory(lnRow)("cTranStat"))
            Case "Call_Incoming", "SMS_Incoming"
                txtHistx02.Text = CallIntatus(IFNull(poHistory(lnRow)("cTranStat"), "0"))
            Case "Call_Outgoing", "SMS_Outgoing"
                txtHistx02.Text = CallOutStatus(poHistory(lnRow)("cTranStat"))
        End Select
    End Sub

    Private Sub IssueApproval()
        If pbAppIssued Then Exit Sub
        If oTrans.Master("sClientID") = "" Then Exit Sub

        If pbConnected = False Then
            pdCallStart = p_oAppDriver.getSysDate
        End If

        If pdCallStart = pxeDefaultDate Then
            If pbConnected Then
                txtAppCode.Text = ""
                Exit Sub
            End If
        End If

        oTrans.Master("dCallStrt") = pdCallStart

        txtAppCode.Text = oTrans.IssueCodeApproval
        pbAppIssued = True
    End Sub

    Private Sub ProcessSMS()
        With oSMSxx
            .NewTransaction()
            If .OpenTransaction(.Get2Read) Then
                ClearSMS()

                txtSMSxx01.Text = .Master(1)
                txtSMSxx03.Text = .Master(3)
                txtSMSxx04.Text = .Master(4)
            End If
        End With
    End Sub
#End Region

#Region "Modem Events"
    Private Sub ConnectModem()
        lblCallStat.Text = "Initializing Modem..."

        Dim comSettings() As String

        CheckForIllegalCrossThreadCalls = False

        oINI = New ggcAppDriver.INIFile
        oINI.FileName = Environment.GetEnvironmentVariable("SystemRoot") + "\\SMSModemXP.ini"
        If Not oINI.IsFileExist Then
            MsgBox("INI file not found for SMSModem settings..." & vbCrLf & _
                   "Please contact GGC SEG/SSG for assistance..." & vbCrLf & _
                   "You may call manually for a while.")
            Return
        End If

        comSettings = oINI.GetTextValue(psModemName, "CommSettings").Split(",")

        oModem = New ATSMS.GSMModem
        With oModem
            .BaudRate = comSettings(0)
            '.Parity = CType([Enum].Parse(GetType(System.IO.Ports.Parity), comSettings(1)), System.IO.Ports.Parity)
            .DataBits = CInt(comSettings(2))
            .StopBits = CType([Enum].Parse(GetType(System.IO.Ports.StopBits), comSettings(3)), System.IO.Ports.StopBits)
            .Port = "COM" & oINI.GetTextValue(psModemName, "TELE")
            .Handsake = CType([Enum].Parse(GetType(System.IO.Ports.Handshake), oINI.GetTextValue(psModemName, "CommHandshake")), System.IO.Ports.Handshake)

            Try
                .Connect()
                .IncomingCallIndication = True
                .NewMessageIndication = False
                .AutoDeleteReadMessage = False

                Try
                    .InitMsgIndication()
                Catch ex As System.Exception
                    showMsg(ex.Message)
                    Return
                End Try
            Catch ex As Exception
                showMsg(ex.Message)
                Return
            End Try

            Application.DoEvents()
            If oModem.IsConnected Then
                Dim lbProcess As Boolean = False
                oModem.CheckATCommands()
            Else
                showMsg("Unable to connect modem!!!" & vbCrLf & _
                        "Please contact GGC SEG/SSG for asssistance!!!" & vbCrLf & _
                        "You may call manually for a while.")
                Me.Close()
            End If

            Try
                getSignalQuality(oModem.GetRssi.Current())
            Catch ex As NullReferenceException
                getSignalQuality(0)
            End Try

            'Call RetreiveMSG()

            lblCallStat.Text = "Connnected"

            pbConnected = True
        End With
    End Sub

    Private Sub oModem_CallStatus(ByVal Status As ATSMS.GSMModem.xeCallStatus) Handles oModem.CallStatus
        Dim lsStatus As String
        Dim ci As CultureInfo = CultureInfo.InvariantCulture

        Select Case Status
            Case 1, 2, 3, 7, 8
                pbDialling = False
                pbTalking = False
            Case 4 'connected
                pbDialling = False
                pbTalking = True
            Case 5, 6 'dialling, ringing
                pbDialling = True
                pbTalking = False
            Case Else
                pbDialling = False
                pbTalking = False
        End Select

        Select Case Status
            Case 1 'BUSY'
                lsStatus = "Network Busy"
                If oModem.IsConnected = False Then oModem.Connect()
                oModem.CHUPHangUp()
            Case 2 'NO CARRIER'
                lsStatus = "No Carrier"
                If oModem.IsConnected = False Then oModem.Connect()
                oModem.CHUPHangUp()
            Case 3 'NO ANSWER'
                lsStatus = "No Answer"
                If oModem.IsConnected = False Then oModem.Connect()
                oModem.CHUPHangUp()
            Case 4 'CONNECTED'
                pdCallStart = p_oAppDriver.getSysDate
                lblStart.Text = pdCallStart.ToString("hh:mm:ss.F", ci)
                lsStatus = "Talking..."
            Case 5 'DIALLING'
                Select Case lnDialCtr
                    Case 0
                        lsStatus = "Dialling"
                    Case 1
                        lsStatus = "Dialling."
                    Case 2
                        lsStatus = "Dialling.."
                    Case 3
                        lsStatus = "Dialling..."
                    Case 4
                        lsStatus = "Dialling...."
                    Case 5
                        lsStatus = "Dialling....."
                    Case 6
                        lsStatus = "Dialling......"
                    Case 7
                        lsStatus = "Dialling......."
                    Case 8
                        lsStatus = "Dialling........"
                    Case 9
                        lsStatus = "Dialling........."
                    Case 10
                        lsStatus = "Dialling.........."
                        lnDialCtr = 0
                End Select
                lnDialCtr = lnDialCtr + 1
            Case 6 'RINGING'
                Select Case lnRingCtr
                    Case 0
                        lsStatus = "Ringing"
                    Case 1
                        lsStatus = "Ringing."
                    Case 2
                        lsStatus = "Ringing.."
                    Case 3
                        lsStatus = "Ringing..."
                    Case 4
                        lsStatus = "Ringing...."
                    Case 5
                        lsStatus = "Ringing....."
                    Case 6
                        lsStatus = "Ringing......"
                    Case 7
                        lsStatus = "Ringing......."
                    Case 8
                        lsStatus = "Ringing........"
                    Case 9
                        lsStatus = "Ringing........."
                    Case 10
                        lsStatus = "Ringing.........."
                        lnRingCtr = 0
                End Select
                lnRingCtr = lnRingCtr + 1
            Case 7 'NO NETWORK'
                lsStatus = "No Network"
                If oModem.IsConnected = False Then oModem.Connect()
                oModem.CHUPHangUp()
            Case 8 'END CALL'
                pdCallEnd = p_oAppDriver.getSysDate
                lblEnd.Text = pdCallEnd.ToString("hh:mm:ss.F", ci)
                lsStatus = "Call Ended"
                If oModem.IsConnected = False Then oModem.Connect()
                oModem.CHUPHangUp()
            Case Else 'ERROR'
                lsStatus = "System Error"
        End Select

        Application.DoEvents()
        Debug.Print("CALL STATUS: " & Status)
        lblCallStat.Text = lsStatus
    End Sub

    Private Function getSignalQuality(ByVal lnCurrent) As Integer
        Dim lnDbm As Integer
        Dim lnSignalQlty As Integer

        On Error Resume Next

        lnDbm = (lnCurrent * 2) - 113

        Select Case lnDbm
            Case Is <= -111 : lnSignalQlty = 0
            Case -110 To -99 : lnSignalQlty = 1
            Case -98 To -86 : lnSignalQlty = 2
            Case -85 To -74 : lnSignalQlty = 3
            Case -73 To -61 : lnSignalQlty = 4
            Case Is >= -60 : lnSignalQlty = 5
            Case Else : lnSignalQlty = -1
        End Select

        Select Case lnSignalQlty
            Case 1 : picSignal.BackgroundImage = My.Resources.B11
            Case 2 : picSignal.BackgroundImage = My.Resources.B21
            Case 3 : picSignal.BackgroundImage = My.Resources.B31
            Case 4 : picSignal.BackgroundImage = My.Resources.B41
            Case 5 : picSignal.BackgroundImage = My.Resources.B51
            Case Else : picSignal.BackgroundImage = My.Resources.B01
        End Select

        Debug.Print("Signal Quality = " & lnSignalQlty)
        getSignalQuality = lnSignalQlty
    End Function

    Private Sub oModem_CheckSignalStrength(ByVal e As ATSMS.SignalStrengthEventArgs) Handles oModem.CheckSignalStrength
        getSignalQuality(e.Current)
    End Sub

    Private Sub oModem_NewIncomingCall(ByVal e As ATSMS.NewIncomingCallEventArgs) Handles oModem.NewIncomingCall
        Dim lsMobileNo As String = e.CallerID

        oModem.CHUPHangUp()

        saveIncomingCall(lsMobileNo)
    End Sub

    Private Sub RetreiveMSG()
        Dim lnCtr As Integer
        Dim msgStore As MessageStore = oModem.MessageStore
        oModem.MessageMemory = EnumMessageMemory.SM
        msgStore.Refresh()

        For lnCtr = 0 To msgStore.Count - 1
            Dim sms As SMSMessage = msgStore.Message(lnCtr)
            Dim lsText As String

            If sms.EMSTotolPiece > 1 Then
                lsText = Mid(sms.Text, 8, sms.Text.Length)
            Else
                lsText = sms.Text
            End If

            Dim item As New ListViewItem(New String() {sms.Index, sms.Timestamp, sms.PhoneNumber, lsText})
            item.Tag = sms

            If saveMessageReceived(sms.PhoneNumber, lsText, sms.Timestamp, sms.Data, sms.EMSCurrentPiece, sms.EMSTotolPiece) Then
                sms.Delete()
            End If
        Next
    End Sub

    Private Sub saveIncomingCall(ByVal recepient As String)
        Dim lsProcName As String
        Dim lsSQL As String
        Dim lors As DataTable

        lsProcName = "saveIncomingCall"

        If Not p_oAppDriver.isConnected Then
            If p_oAppDriver.Reconnect = False Then Exit Sub
        End If
        lsSQL = "SELECT" & _
                    "  sTransNox" & _
                    ", dTransact" & _
                    ", sMobileNo" & _
                    ", nCallCtrx" & _
                    ", sSourceCd" & _
                    ", cTranStat" & _
                " FROM Call_Incoming" & _
                " WHERE sMobileNo = " & strParm(Replace(recepient, "+63", "0")) & _
                    " AND dTransact = " & dateParm(p_oAppDriver.getSysDate) & _
                    " AND sSourceCd = " & strParm("TM")

        Call p_oAppDriver.ExecuteActionQuery(lsSQL)

        Try
            lors = New DataTable
            lors = p_oAppDriver.ExecuteQuery(lsSQL)
        Catch ex As Exception
            Throw ex
        End Try

        lsSQL = ""
        If lors.Rows.Count = 0 Then
            lsSQL = "INSERT INTO Call_Incoming SET" & _
                        "  sTransNox = " & strParm(GetNextCode("Call_Incoming", "sTransNox", True, p_oAppDriver.Connection, True, p_oAppDriver.BranchCode)) & _
                        ", dTransact = " & dateParm(p_oAppDriver.getSysDate) & _
                        ", sSourceCd = " & strParm("HL") & _
                        ", sMobileNo = " & strParm(Replace(recepient, "+63", "0")) & _
                        ", nCallCtrx = " & CDbl(1) & _
                        ", cTranStat = " & strParm(xeTranStat.TRANS_OPEN)
        Else
            If lors.Rows(0).Item("cTranStat") = xeTranStat.TRANS_OPEN Then
                If lors.Rows(0).Item("nCallCtrx") < 3 Then
                    lsSQL = "UPDATE Call_Incoming SET" & _
                                " nCallCtrx = nCallCtrx + '1'" & _
                            " WHERE sTransNox = " & strParm(lors.Rows(0).Item("sTransNox"))
                End If
            Else
                lsSQL = "INSERT INTO Call_Incoming SET" & _
                            "  sTransNox = " & strParm(GetNextCode("Call_Incoming", "sTransNox", True, p_oAppDriver.Connection, True, p_oAppDriver.BranchCode)) & _
                            ", dTransact = " & dateParm(p_oAppDriver.getSysDate) & _
                            ", sSourceCd = " & strParm("HL") & _
                            ", sMobileNo = " & strParm(Replace(recepient, "+63", "0")) & _
                            ", nCallCtrx = " & CDbl(1) & _
                            ", cTranStat = " & strParm(xeTranStat.TRANS_OPEN)
            End If
        End If

        If lsSQL <> "" Then
            Call p_oAppDriver.ExecuteActionQuery(lsSQL)
        End If
    End Sub

    Private Function saveMessageReceived(ByVal recepient As String, _
                            ByVal message As String, _
                            ByVal dateReceived As DateTime, _
                            ByVal smsref As String, _
                            ByVal smspart As Integer, _
                            ByVal smstotalparts As Integer) As Boolean
        Dim lsProcName As String
        Dim lsSQL As String
        Dim lsReferNo As String

        lsProcName = "saveMessageReceived"

        If IsNothing(smsref) Then
            lsReferNo = String.Empty
        Else
            lsReferNo = smsref
        End If

        If Not p_oAppDriver.isConnected Then
            If p_oAppDriver.Reconnect() = False Then
                Return False
            End If
        End If

        lsSQL = "INSERT INTO Text_SMS SET" & _
                    "  sTransNox = " & strParm(GetNextCode("Text_SMS", "sTransNox", True, p_oAppDriver.Connection, True, p_oAppDriver.BranchCode)) & _
                    ", sSourceCd = " & strParm("TM") & _
                    ", dReceived = " & datetimeParm(dateReceived) & _
                    ", sMobileNo = " & strParm(recepient) & _
                    ", sMessagex = " & strParm(message) & _
                    ", sReferNox = " & strParm(lsReferNo) & _
                    ", nTotlPrts = " & CDbl(smstotalparts) & _
                    ", nCurrPrts = " & CDbl(smspart) & _
                    ", cClassify = " & strParm("0") & _
                    ", dModified = " & dateParm(p_oAppDriver.getSysDate)

        Call p_oAppDriver.ExecuteActionQuery(lsSQL)
        Return True
    End Function

    Private Function isValidMobile(ByVal lsMobileNo As String) As Boolean
        Dim lsProcName As String

        lsProcName = "isValidMobile"
        'On Error GoTo errProc
        Debug.Print(lsProcName)

        lsMobileNo = Replace(lsMobileNo, "-", "", 1)
        lsMobileNo = Replace(lsMobileNo, "(", "", 1)
        lsMobileNo = Replace(lsMobileNo, ")", "", 1)
        lsMobileNo = Replace(lsMobileNo, "*", "", 1)
        lsMobileNo = Replace(lsMobileNo, " ", "", 1)

        ' assumes that encoder follow international format
        If Trim(lsMobileNo) = "" Then
            Return False
            Exit Function
        End If

        If lsMobileNo.Substring(0, 2) = "09" Then lsMobileNo = "+639" & Mid(lsMobileNo, 3)
        If Len(lsMobileNo) <> 13 Then
            lsMobileNo = ""
            GoTo endProc
        End If

        Return True
endProc:
        Return False
        Exit Function
errProc:
        MsgBox(Err.Description)
    End Function

    Private Function isModemConnected() As Boolean
        If pbConnected = False Then
            showMsg("Modem is not connected!!!" & vbCrLf & _
                        "Please contact GGC SEG/SSG for asssistance!!!" & vbCrLf & _
                        "You may call manually for a while.")
        End If

        Return pbConnected
    End Function
#End Region

    Private Sub chkUpdateSMS_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUpdateSMS.CheckedChanged
        txtSMSxx03.ReadOnly = Not chkUpdateSMS.Checked

        cmdSMSBut00.Visible = chkUpdateSMS.Checked
    End Sub

    Private Sub gridHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridHistory.CellDoubleClick
        With gridHistory
            Dim lnRow As Integer = .CurrentRow.Index

            If LCase(.Item(1, lnRow).Value) = "ganado_online" Then
                Dim loForm = frmGanadoEntry
                loForm = New frmGanadoEntry

                loForm.ReferNox = .Item(2, lnRow).Value
                loForm.ShowDialog()
            End If
        End With
    End Sub

End Class