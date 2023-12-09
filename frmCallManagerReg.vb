Imports ggcAppDriver
Imports ggcMCSales

Public Class frmCallManagerReg
    Private WithEvents oTrans As OGCallManagerHistory
    Private pnLoadx As Integer
    Private pnIndex As Integer
    Private poControl As Control


    Private Sub frmCallManagerReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If pnLoadx = 0 Then
            oTrans = New OGCallManagerHistory(p_oAppDriver, 1230)
            pnLoadx = 1
        End If
        clearFields()
        InitGrid()
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
                           
                            Case Else
                                loTxt.Text = oTrans.Master(loIndex)
                        End Select
                    End If 'LCase(Mid(loTxt.Name, 1, 8)) = "txtfield"
                End If '(TypeOf loTxt Is TextBox)
            End If 'If loTxt.HasChildren
        Next 'loTxt In loControl.Controls
        LoadDetail()

    End Sub

    Private Sub cmdButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdButton00.Click, cmdButton01.Click
        Dim loChk As Button
        loChk = CType(sender, System.Windows.Forms.Button)

        Dim lnIndex As Integer
        lnIndex = Val(Mid(loChk.Name, 10))

        Select Case lnIndex
            Case 1
                Me.Close()

            Case 0
                Select Case pnIndex
                    Case 0
                        If oTrans.SearchTransaction(txtSearch00.Text, False) Then
                            loadMaster(Me)
                            txtSearch00.Text = txtField00.Text

                        Else
                            clearFields()
                        End If
                    Case 1
                        If oTrans.SearchTransaction(txtSearch01.Text, True) Then
                            loadMaster(Me)
                            txtSearch01.Text = txtField01.Text
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
        txtSearch00.Text = ""
        txtSearch01.Text = ""
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch00.KeyDown, txtSearch01.KeyDown
        If e.KeyCode = Keys.F3 Or e.KeyCode = Keys.Return Then
            Dim loTxt As TextBox
            loTxt = CType(sender, System.Windows.Forms.TextBox)

            If Mid(loTxt.Name, 1, 9) = "txtSearch" Then
                Select Case pnIndex
                    Case 0
                        If oTrans.SearchTransaction(txtSearch00.Text, False) Then
                            loadMaster(Me)
                            txtSearch00.Text = txtField00.Text
                        Else
                            clearFields()
                        End If
                    Case 1
                        If oTrans.SearchTransaction(txtSearch01.Text, True) Then
                            loadMaster(Me)
                            txtSearch01.Text = txtField01.Text
                        Else
                            clearFields()
                        End If
                End Select
            End If
        End If
    End Sub

    Private Sub InitGrid()
        With DataGridView1
            'Set No of Columns
            .ColumnCount = 4

            'Set Column Headers
            .Columns(0).HeaderText = "No"
            .Columns(1).HeaderText = "Call Start"
            .Columns(2).HeaderText = "Call End"
            .Columns(3).HeaderText = "Status"

            'Set Column Sizes
            .Columns(0).Width = 40
            .Columns(1).Width = 140
            .Columns(2).Width = 140
            .Columns(3).Width = 126

            'Set Cell Alignment
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            For Each column As DataGridViewColumn In .Columns
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With
    End Sub
Private Sub LoadDetail()
        With DataGridView1
            ' Assuming oTrans is an instance of your class with GetItemCount and Detail methods
            Dim itemCount As Integer = oTrans.GetItemCount()
            Dim TLMStats As String
            ' Set the row count in the DataGridView
            .RowCount = itemCount

            Debug.Print(itemCount)
            If itemCount > 6 Then
                .Columns(0).Width = 23
            Else
                .Columns(0).Width = 40
            End If
            ' Loop through the items and populate the DataGridView
            For lnCtr As Integer = 0 To itemCount - 1
                TLMStats = oTrans.Detail(lnCtr, "cTLMStatx")
                .Rows(lnCtr).Cells(0).Value = lnCtr + 1
                .Rows(lnCtr).Cells(1).Value = FormatDate(oTrans.Detail(lnCtr, "dCallStrt"))
                .Rows(lnCtr).Cells(2).Value = FormatDate(oTrans.Detail(lnCtr, "dCallEndx"))
                .Rows(lnCtr).Cells(3).Value = TLMStatus(oTrans.Detail(lnCtr, "cTLMStatx"))
            Next

            ' Go to the last row
            If itemCount > 1 Then
                .ClearSelection()
                .CurrentCell = .Rows(itemCount - 1).Cells(0)
                .Rows(itemCount - 1).Selected = True
            End If
        End With
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        With DataGridView1
            Dim lnRow As Integer = .CurrentRow.Index

            If oTrans.Detail(lnRow, "sTransNox") <> "" Then
                Dim loForm = frmCallManagerRegDetail
                loForm = New frmCallManagerRegDetail
                Debug.Print(oTrans.Detail(lnRow, "sTransNox"))
                loForm.TransNox = oTrans.Detail(lnRow, "sTransNox")
                loForm.ClientName = oTrans.Detail(lnRow, "sClientID")
                loForm.MobileNo = oTrans.Detail(lnRow, "sMobileNo")
                loForm.Agent = oTrans.Detail(lnRow, "sAgentIDx")
                loForm.CallStart = FormatDate(oTrans.Detail(lnRow, "dCallStrt"))
                loForm.CallEnd = FormatDate(oTrans.Detail(lnRow, "dCallEndx"))
                loForm.Status = TLMStatus(oTrans.Detail(lnRow, "cTLMStatx"))
                loForm.Remarks = oTrans.Detail(lnRow, "sRemarksx")
                loForm.DetailHistoryInstance = oTrans
                loForm.ShowDialog()

                If loForm.OkSave Then
                    If (oTrans.SaveTransaction(lnRow)) Then
                        MsgBox("Transaction Successfully rescheduled.", MsgBoxStyle.Information, "Notice")
                    End If
                End If
            End If
        End With
    End Sub


    Private Function FormatDate(ByVal dateValue As Object) As String
        If dateValue IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(dateValue.ToString()) Then
            Dim formattedDate As String = ""
            Dim parsedDate As DateTime

            If DateTime.TryParse(dateValue.ToString(), parsedDate) Then
                formattedDate = parsedDate.ToString("MMM dd, yyyy - HH:mm:ss")
            End If

            Return formattedDate
        Else
            Return ""
        End If
    End Function


End Class