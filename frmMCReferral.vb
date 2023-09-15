Imports ggcAppDriver
Imports ggcMCSales

Public Class frmMCReferral
    Private WithEvents oTrans As ggcMCSales.MCReferral
    Private pnLoadx As Integer
    Private pnIndex As Integer
    Private poControl As Control

    Private Sub frmMCInquiry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If pnLoadx = 0 Then
            oTrans = New ggcMCSales.MCReferral(p_oAppDriver)

            Call grpEventHandler(Me, GetType(TextBox), "txtField", "GotFocus", AddressOf txtField_GotFocus)
            Call grpEventHandler(Me, GetType(TextBox), "txtField", "LostFocus", AddressOf txtField_LostFocus)
            Call grpEventHandler(Me, GetType(Button), "cmdButton", "Click", AddressOf cmdButton_Click)

            initButton()

            pnLoadx = 1
        End If
    End Sub

    Private Sub loadMaster(ByVal loControl As Control)
        Dim loTxt As Control

        For Each loTxt In loControl.Controls
            If loTxt.HasChildren Then
                Call loadMaster(loTxt)
            Else
                If (TypeOf loTxt Is TextBox) Then
                    Dim loIndex As Integer
                    loIndex = Val(Mid(loTxt.Name, 9))
                    If LCase(Mid(loTxt.Name, 1, 8)) = "txtfield" Then
                        Select Case loIndex
                            Case 1, 6
                                loTxt.Text = Format(IFNull(oTrans.Master(loIndex), p_oAppDriver.SysDate), "MMMM dd, yyyy")
                            Case 80
                                loTxt.Text = oTrans.Master(loIndex)
                            Case Else
                                loTxt.Text = oTrans.Master(loIndex)
                        End Select
                    End If 'LCase(Mid(loTxt.Name, 1, 8)) = "txtfield"
                End If '(TypeOf loTxt Is TextBox)
            End If 'If loTxt.HasChildren
        Next 'loTxt In loControl.Controls
    End Sub

    Private Sub clearFields()
        txtField00.Text = ""
        txtField01.Text = ""
        txtField06.Text = ""
        txtField08.Text = ""
        txtField80.Text = ""
        txtField81.Text = ""
        txtField82.Text = ""
        txtField83.Text = ""
        ComboBox10.SelectedIndex = 0
    End Sub

    Private Sub initButton()
        Dim lbShow As Boolean
        lbShow = oTrans.EditMode = xeEditMode.MODE_ADDNEW

        cmdButton01.Visible = lbShow
        cmdButton02.Visible = lbShow
        cmdButton04.Visible = lbShow
        cmdButton00.Visible = Not lbShow
        cmdButton03.Visible = Not lbShow
        GroupBox1.Enabled = lbShow

        If oTrans.EditMode = xeEditMode.MODE_ADDNEW Then
            txtField80.Focus()
        End If

    End Sub

    Private Sub NewTransaction()
        clearFields()

        If oTrans.NewTransaction() Then
            loadMaster(Me)
            initButton()
        End If
    End Sub

    Private Sub cmdButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim loChk As Button
        loChk = CType(sender, System.Windows.Forms.Button)

        Dim lnIndex As Integer
        lnIndex = Val(Mid(loChk.Name, 10))

        Select Case lnIndex
            Case 0 'new
                NewTransaction()
            Case 1 'save
                Call validateControl()
                If oTrans.SaveTransaction Then
                    MsgBox("Transaction Saved Successfuly.", MsgBoxStyle.Information, "Notice")

                    NewTransaction()
                End If
            Case 2 'search
                Select Case pnIndex
                    Case 80
                    Case 82
                    Case 83
                End Select
            Case 3 'close
                Me.Close()
            Case 4 'cancel
                oTrans = Nothing
                oTrans = New ggcMCSales.MCReferral(p_oAppDriver)
                clearFields()
                initButton()
        End Select
    End Sub

    Private Sub txtField_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        If Mid(loTxt.Name, 1, 8) = "txtField" Then
            Select Case loIndex
                Case 1, 6
                    loTxt.Text = Format(IFNull(oTrans.Master(loIndex), p_oAppDriver.SysDate), "yyyy/MM/dd")
            End Select
        End If

        poControl = loTxt

        loTxt.BackColor = Color.Azure
        loTxt.SelectAll()
    End Sub

    Private Sub txtField_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        Select Case loIndex
            Case 1, 6
                If IsDate(loTxt.Text) Then
                    oTrans.Master(loIndex) = loTxt.Text
                    loTxt.Text = Format(oTrans.Master(loIndex), "MMMM dd, yyyy")
                Else
                    MsgBox("Invalid date detected!")
                End If
            Case 8
                oTrans.Master(8) = loTxt.Text
        End Select

        pnIndex = loIndex

        loTxt.BackColor = SystemColors.Window
        poControl = Nothing
    End Sub

    Private Sub oTrans_MasterRetrieved(Index As Integer, Value As Object) Handles oTrans.MasterRetrieved
        Select Case Index
            Case 80
                txtField80.Text = Value
            Case 81
                txtField81.Text = Value
            Case 82
                txtField82.Text = Value
            Case 83
                txtField83.Text = Value
            Case 84
                txtField84.Text = Value
            Case 86
                txtField86.Text = Value
        End Select
    End Sub

    Private Sub txtField_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles _
        txtField80.KeyDown, txtField82.KeyDown, txtField83.KeyDown, txtField84.KeyDown, txtField86.KeyDown
        If e.KeyCode = Keys.F3 Or e.KeyCode = Keys.Return Then
            Dim loTxt As TextBox
            loTxt = CType(sender, System.Windows.Forms.TextBox)

            Dim loIndex As Integer
            loIndex = Val(Mid(loTxt.Name, 9))

            If Mid(loTxt.Name, 1, 8) = "txtField" Then
                Select Case loIndex
                    Case 80
                        If loTxt.Text <> "" Then oTrans.SearchMaster(loIndex, loTxt.Text)
                    Case 82, 83, 84, 86
                        oTrans.SearchMaster(loIndex, loTxt.Text)
                End Select
            End If
        End If
    End Sub

    'call this command to validate values since we are using lostfocus as substitute for validate
    Private Sub validateControl()
        txtField01.Focus()
        txtField80.Focus()
        txtField82.Focus()
        txtField83.Focus()
        txtField84.Focus()
        txtField86.Focus()
        txtField06.Focus()
        txtField08.Focus()
        txtField80.Focus()
    End Sub

    Private Sub ComboBox5_LostFocus(sender As Object, e As System.EventArgs) Handles ComboBox10.LostFocus
        Dim loTxt As ComboBox
        loTxt = CType(sender, System.Windows.Forms.ComboBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        If Mid(loTxt.Name, 1, 8) = "ComboBox" Then
            Select Case loIndex
                Case 10
                    Select Case loTxt.SelectedIndex
                        Case 0
                            oTrans.Master("sSourceCd") = "TB"
                        Case 1
                            oTrans.Master("sSourceCd") = "TM"
                        Case 2
                            oTrans.Master("sSourceCd") = "HL"
                        Case 3
                            oTrans.Master("sSourceCd") = "NA"
                    End Select
            End Select
        End If
    End Sub
End Class