Imports ggcAppDriver
Imports ggcMCSales

Public Class frmMCInsCalc
    Private Const pxeMsgHeader As String = "frmMCInsCalc"

    Private oTrans As ggcMCSales.MCPricelist

    Private Sub frmMCInsCalc_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        oTrans = New ggcMCSales.MCPricelist(p_oAppDriver)

        InitForm()
    End Sub

    Private Sub prcMonthlyAmort()
        Dim lnCtr As Integer
        Dim lnDownPaym As Double
        Dim lanTerm(4) As Integer

        lanTerm(0) = 6
        lanTerm(1) = 12
        lanTerm(2) = 18
        lanTerm(3) = 24
        lanTerm(4) = 36

        lnDownPaym = CDbl(TextBox2.Text)
        If lnDownPaym <= 0 Then Exit Sub

        With gridPricelist
            For lnCtr = 0 To UBound(lanTerm)
                .Rows(0).Cells(lnCtr + 1).Value = Format(oTrans.getMonthly(lnDownPaym, lanTerm(lnCtr)), "#,##0.00")
                .Rows(1).Cells(lnCtr + 1).Value = Format(CDbl(.Rows(0).Cells(lnCtr + 1).Value) - CDbl(TextBox3.Text), "#,##0.00")
                .Rows(2).Cells(lnCtr + 1).Value = Format(CDbl(.Rows(0).Cells(lnCtr + 1).Value) * lanTerm(lnCtr), "#,##0.00")
                .Rows(3).Cells(lnCtr + 1).Value = Format(CDbl(.Rows(1).Cells(lnCtr + 1).Value) * lanTerm(lnCtr), "#,##0.00")
            Next
        End With
    End Sub

    Private Sub LoadMaster()
        TextBox1.Text = oTrans.MCModel
        TextBox2.Text = oTrans.MinimumDown
        TextBox3.Text = Format(oTrans.Rebate, "#,##0.00")
        TextBox4.Text = Format(oTrans.MiscCharge, "#,##0.00")
        TextBox5.Text = Format(oTrans.EndMortgage, "#,##0.00")
    End Sub

    Private Sub InitForm()
        InitGrid()

        TextBox1.Text = ""
        TextBox2.Text = 0.0
        TextBox3.Text = 0.0
        TextBox4.Text = 0.0
        TextBox5.Text = 0.0
    End Sub

    Private Sub InitGrid()
        With gridPricelist.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(gridPricelist.Font, FontStyle.Bold)
        End With

        With gridPricelist
            .ColumnCount = 6
            .RowCount = 4

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

            .Columns(0).Width = 150
            .Columns(1).Width = 100
            .Columns(2).Width = 100
            .Columns(3).Width = 100
            .Columns(4).Width = 100
            .Columns(5).Width = 100

            .Columns(0).Name = ""
            .Columns(1).Name = "6 mos"
            .Columns(2).Name = "12 mos"
            .Columns(3).Name = "18 mos"
            .Columns(4).Name = "24 mos"
            .Columns(5).Name = "36 mos"

            .Rows(0).Cells(0).Value = "Gross Monthly"
            .Rows(1).Cells(0).Value = "Net Monthly"
            .Rows(2).Cells(0).Value = "Gross Total"
            .Rows(3).Cells(0).Value = "Net Total"

            Dim lnRow As Integer
            Dim lnCol As Integer

            For lnRow = 0 To 3
                For lnCol = 0 To 5
                    If lnCol = 0 Then
                        gridPricelist.Rows(lnRow).Cells(lnCol).Style.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                    Else
                        .Rows(lnRow).Cells(lnCol).Value = 0
                    End If
                Next
            Next

            .Rows(3).Selected = True
        End With
    End Sub

    Private Sub TextBox_GotFocus(sender As Object, e As System.EventArgs) Handles TextBox1.GotFocus, _
        TextBox2.GotFocus, TextBox3.GotFocus, TextBox4.GotFocus, TextBox5.GotFocus

        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 8))

        If Mid(loTxt.Name, 1, 7) = "TextBox" Then
            Select Case loIndex
                Case 1, 2
                    loTxt.BackColor = Color.Azure
                    loTxt.SelectAll()
            End Select
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Return, Keys.F3
                oTrans.MCModel = TextBox1.Text
                If oTrans.MCModel <> "" Then
                    InitForm()
                    LoadMaster()
                    prcMonthlyAmort()
                    TextBox2.Focus()
                End If
        End Select
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        With TextBox2
            Select Case e.KeyCode
                Case Keys.Return
                    If IsNumeric(.Text) Then
                        If .Text < oTrans.MinimumDown Then
                            .Text = oTrans.MinimumDown
                        End If
                    Else
                        .Text = oTrans.MinimumDown
                    End If

                    Call prcMonthlyAmort()
            End Select
        End With
    End Sub

    Private Sub TextBox_LostFocus(sender As Object, e As System.EventArgs) Handles TextBox1.LostFocus, _
        TextBox2.LostFocus, TextBox3.LostFocus, TextBox4.LostFocus, TextBox5.LostFocus

        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 8))

        If Mid(loTxt.Name, 1, 7) = "TextBox" Then
            Select Case loIndex
                Case 1, 2
                    loTxt.BackColor = SystemColors.Window
            End Select
        End If
    End Sub

End Class
