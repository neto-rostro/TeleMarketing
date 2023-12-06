Imports ggcAppDriver
Imports ggcMCSales

Public Class frmCallManagerRegDetail

    Private pnLoadx As Integer
    Private pnIndex As Integer
    Private poControl As Control

    Dim psTransNox As String
    Dim psMobileNo As String
    Dim psAgent As String
    Dim psCallStart As String
    Dim psCallEnd As String
    Dim psStatus As String
    Dim psRemarksx As String
    Dim psClientNme As String
    Dim pbOkSave As Boolean

    Public Property DetailHistoryInstance As OGCallManagerHistory

    Public Property TransNox() As String
        Get
            Return psTransNox
        End Get
        Set(ByVal value As String)
            psTransNox = value
        End Set
    End Property
    Public Property MobileNo() As String
        Get
            Return psMobileNo
        End Get
        Set(ByVal value As String)
            psMobileNo = value
        End Set
    End Property
    Public Property Agent() As String
        Get
            Return psAgent
        End Get
        Set(ByVal value As String)
            psAgent = value
        End Set
    End Property
    Public Property CallStart() As String
        Get
            Return psCallStart
        End Get
        Set(ByVal value As String)
            psCallStart = value
        End Set
    End Property
    Public Property CallEnd() As String
        Get
            Return psCallEnd
        End Get
        Set(ByVal value As String)
            psCallEnd = value
        End Set
    End Property
    Public Property Status() As String
        Get
            Return psStatus
        End Get
        Set(ByVal value As String)
            psStatus = value
        End Set
    End Property
    Public Property Remarks() As String
        Get
            Return psRemarksx
        End Get
        Set(ByVal value As String)
            psRemarksx = value
        End Set
    End Property
    Public Property ClientName() As String
        Get
            Return psClientNme
        End Get
        Set(ByVal value As String)
            psClientNme = value
        End Set
    End Property

    Public Property OkSave() As Boolean
        Get
            Return pbOkSave
        End Get
        Set(ByVal value As Boolean)
            pbOkSave = value
        End Set
    End Property

    Private Sub frmCallManagerRegDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If pnLoadx = 0 Then

            pnLoadx = 1
        End If

        chkSchedCall.Checked = False
        loadMaster()
    End Sub

    Private Sub loadMaster()
        txtField00.Text = psClientNme
        txtField01.Text = psMobileNo
        txtField02.Text = psAgent
        txtField03.Text = psCallStart
        txtField04.Text = psCallEnd
        txtField05.Text = psStatus
        txtField06.Text = psRemarksx




    End Sub

    Private Sub cmdButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdButton00.Click, cmdButton01.Click
        Dim loChk As Button
        loChk = CType(sender, System.Windows.Forms.Button)

        Dim lnIndex As Integer
        lnIndex = Val(Mid(loChk.Name, 10))
        With DetailHistoryInstance
            Select Case lnIndex
                Case 1
                    Me.Close()

                Case 0
                    If chkSchedCall.Checked = True Then
                        .isCallAgain = True
                        .CallDate = dtpCall1.Value.ToString("MM-dd-yyyy") & " " & _
                                    dtpCall2.Value.ToString("H:mm:ss")
                        pbOkSave = True
                        Me.Close()
                    Else
                        pbOkSave = False
                        Me.Close()
                    End If

            End Select
        End With
    End Sub
    Private Sub chkSchedCall_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSchedCall.CheckedChanged
        dtpCall1.Value = p_oAppDriver.getSysDate
        dtpCall2.Value = p_oAppDriver.getSysDate

        dtpCall1.Visible = chkSchedCall.Checked
        dtpCall2.Visible = chkSchedCall.Checked
    End Sub
    Private Sub txtSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Strings.Right(loTxt.Name, 2))

        pnIndex = loIndex
    End Sub


End Class