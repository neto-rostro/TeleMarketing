Imports ggcAppDriver
Imports ggcMCSales

Public Class frmTextMarketingReg
    Private WithEvents oTrans As ggcMCSales.MessageCast
    Private pnLoadx As Integer
    Private pnIndex As Integer
    Private poControl As Control

    Private Sub frmMCInquiry_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If pnLoadx = 0 Then
            oTrans = New ggcMCSales.MessageCast(p_oAppDriver, 1230)
            pnLoadx = 1

        End If
        clearFields()
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
                            Case 0
                                loTxt.Text = oTrans.Master(loIndex)
                                txtSearch00.Text = loTxt.Text
                            Case 1, 5, 6
                                loTxt.Text = Format(IFNull(oTrans.Master(loIndex), p_oAppDriver.SysDate), "MMMM dd, yyyy")
                            Case 80
                                loTxt.Text = oTrans.Master(loIndex)
                                txtSearch01.Text = loTxt.Text
                            Case Else
                                loTxt.Text = oTrans.Master(loIndex)
                        End Select
                    End If 'LCase(Mid(loTxt.Name, 1, 8)) = "txtfield"
                End If '(TypeOf loTxt Is TextBox)
            End If 'If loTxt.HasChildren
        Next 'loTxt In loControl.Controls

        lblStatus.Text = TranStatus(oTrans.Master("cTranStat"))
    End Sub

    Private Sub clearFields()
        txtField00.Text = ""
        txtField01.Text = ""
        txtField03.Text = ""
        txtField04.Text = ""
        txtField05.Text = ""
        txtField06.Text = ""
        txtField07.Text = "0"
        txtField08.Text = "0"
        txtField09.Text = ""
        txtField10.Text = ""
        txtField80.Text = ""

        lblStatus.Text = ""
    End Sub

    Private Sub cmdButton_Click(sender As System.Object, e As System.EventArgs) Handles cmdButton02.Click, cmdButton03.Click, cmdButton04.Click, cmdButton05.Click
        Dim loChk As Button
        loChk = CType(sender, System.Windows.Forms.Button)

        Dim lnIndex As Integer
        lnIndex = Val(Mid(loChk.Name, 10))

        Select Case lnIndex
            Case 2
                If oTrans.CloseTransaction Then
                    loadMaster(Me)
                    txtSearch00.Text = ""
                    txtSearch01.Text = ""
                    txtSearch00.Focus()

                    MsgBox("Transaction posted succesfuly.", MsgBoxStyle.Information, "Success")
                Else
                    MsgBox("Unable to post succesfuly.", MsgBoxStyle.Critical, "Warning")
                End If
            Case 3
                Me.Close()
            Case 4
                If oTrans.CancelTransaction Then
                    loadMaster(Me)
                    txtSearch00.Text = ""
                    txtSearch01.Text = ""
                    txtSearch00.Focus()

                    MsgBox("Transaction cancelled succesfuly.", MsgBoxStyle.Information, "Success")
                Else
                    MsgBox("Unable to cancel succesfuly.", MsgBoxStyle.Critical, "Warning")
                End If
            Case 5
                Select Case pnIndex
                    Case 0
                        If oTrans.SearchTransaction(txtSearch00.Text, True) Then
                            loadMaster(Me)
                        Else
                            clearFields()
                        End If
                    Case 1
                        If oTrans.SearchTransaction(txtSearch01.Text, False) Then
                            loadMaster(Me)
                        Else
                            clearFields()
                        End If
                End Select
        End Select
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearch00.KeyDown, txtSearch01.KeyDown
        If e.KeyCode = Keys.F3 Or e.KeyCode = Keys.Return Then
            Dim loTxt As TextBox
            loTxt = CType(sender, System.Windows.Forms.TextBox)

            If Mid(loTxt.Name, 1, 9) = "txtSearch" Then
                Select Case pnIndex
                    Case 0
                        If oTrans.SearchTransaction(txtSearch00.Text, True) Then
                            loadMaster(Me)
                        Else
                            clearFields()
                        End If
                    Case 1
                        If oTrans.SearchTransaction(txtSearch01.Text, False) Then
                            loadMaster(Me)
                        Else
                            clearFields()
                        End If
                End Select
            End If
        End If
    End Sub

    Private Sub txtSearch_GotFocus(sender As Object, e As System.EventArgs) Handles txtSearch00.GotFocus, txtSearch01.GotFocus
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Strings.Right(loTxt.Name, 2))

        pnIndex = loIndex
    End Sub
End Class