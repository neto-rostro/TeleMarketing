Imports ggcAppDriver
Imports ggcMCSales

Public Class frmOGCallCustInfoCPReg
    Private WithEvents oTrans As TLMSalesCP
    Private pnLoadx As Integer
    Private pnIndex As Integer
    Private poControl As Control

    Private Sub frmOGCallCustInfoCPReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If pnLoadx = 0 Then
            oTrans = New TLMSalesCP(p_oAppDriver, 1230)
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
                            Case 1
                                loTxt.Text = Format(IFNull(CDate(oTrans.Master(8)), ""), "MMMM dd, yyyy")

                            Case 0
                                loTxt.Text = oTrans.Master(loIndex)
                                txtSearch00.Text = loTxt.Text
                            Case 2
                                loTxt.Text = oTrans.Master(loIndex)
                                txtSearch01.Text = loTxt.Text
                            Case 4
                                If oTrans.Master(loIndex) <> "" Then
                                    txtField04.Text = Format(CDate(oTrans.Master(loIndex)), "MMMM dd, yyyy")
                                Else
                                    txtField04.Text = ""
                                End If
                            Case 6
                                loTxt.Text = InquiryStatus(oTrans.Master(loIndex))

                            Case 87
                                If oTrans.Master(loIndex) = "0" Then
                                    txtField87.Text = "CASH"
                                Else
                                    txtField87.Text = "INSTALLMENT"
                                End If

                            Case Else
                                loTxt.Text = oTrans.Master(loIndex)
                        End Select
                    End If 'LCase(Mid(loTxt.Name, 1, 8)) = "txtfield"
                End If '(TypeOf loTxt Is TextBox)
            End If 'If loTxt.HasChildren
        Next 'loTxt In loControl.Controls

        lblStatus.Text = TranStatus(oTrans.Master("cTranStat"))
    End Sub

    Private Sub cmdButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdButton03.Click, cmdButton04.Click, cmdButton05.Click
        Dim loChk As Button
        loChk = CType(sender, System.Windows.Forms.Button)

        Dim lnIndex As Integer
        lnIndex = Val(Mid(loChk.Name, 10))

        Select Case lnIndex
            Case 3
                Me.Close()
            Case 4
                'If oTrans.CancelTransaction Then
                '    loadMaster(Me)
                '    txtSearch00.Text = ""
                '    txtSearch01.Text = ""
                '    txtSearch00.Focus()

                '    MsgBox("Transaction cancelled succesfuly.", MsgBoxStyle.Information, "Success")
                'Else
                '    MsgBox("Unable to cancel succesfuly.", MsgBoxStyle.Critical, "Warning")
                'End If
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

    Private Sub txtSearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch00.GotFocus, txtSearch01.GotFocus
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Strings.Right(loTxt.Name, 2))

        pnIndex = loIndex
    End Sub

    Private Sub clearFields()
        txtField00.Text = ""
        txtField01.Text = ""
        txtField02.Text = ""
        txtField03.Text = ""
        txtField04.Text = ""
        txtField05.Text = ""
        txtField06.Text = ""

        txtField80.Text = ""
        txtField81.Text = ""
        txtField82.Text = ""
        txtField83.Text = ""
        txtField84.Text = ""
        txtField85.Text = ""
        txtField86.Text = ""
        txtField87.Text = ""
        lblStatus.Text = "UNKNOWN"

    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch00.KeyDown, txtSearch01.KeyDown
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
End Class