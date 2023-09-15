Imports ggcAppDriver
Imports ggcMCSales

Public Class frmMCInsPrice
    Private Const pxeMsgHeader As String = "frmMCInsPrice"

    Private oTrans As ggcMCSales.MCPricelist

    Private Sub frmMCInsPrice_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        oTrans = New ggcMCSales.MCPricelist(p_oAppDriver)

        Call InitGrid()
        Call LoadPriceList()
    End Sub

    Private Sub LoadPriceList()
        Dim lnRow As Integer
        Dim lnCol As Integer
        Dim lnCtr As Integer
        Dim ldLatest As Date
        Dim lsCategory As String
        Dim lsModelNme As String
        Dim lanTerm(4) As Integer

        lanTerm(0) = 6
        lanTerm(1) = 12
        lanTerm(2) = 18
        lanTerm(3) = 24
        lanTerm(4) = 36

        With oTrans
            .LoadInstallmentPrice()

            gridPricelist.RowCount = 1

            lsCategory = ""
            lsModelNme = ""
            lnCtr = 0
            lnRow = 1

            ldLatest = .InstallmentLatestDate

            Application.DoEvents()
            Try
                Do While lnCtr < .InstallmentPriceCount
                    If lsCategory <> .InstallmentPrice(lnCtr, "sMCCatNme") Then
                        If lnRow + 1 > gridPricelist.RowCount Then gridPricelist.RowCount = gridPricelist.RowCount + 1

                        gridPricelist.Rows(lnRow - 1).Cells(0).Value = .InstallmentPrice(lnCtr, "sMCCatNme")

                        gridPricelist.Rows(lnRow - 1).Selected = True
                        For lnCol = 1 To gridPricelist.ColumnCount
                            gridPricelist.Rows(lnRow - 1).Cells(lnCol - 1).Style.ForeColor = Color.Black
                            gridPricelist.Rows(lnRow - 1).Cells(lnCol - 1).Style.BackColor = Color.Yellow
                            gridPricelist.Rows(lnRow - 1).Cells(lnCol - 1).Style.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                        Next

                        lsCategory = .InstallmentPrice(lnCtr, "sMCCatNme")
                        lnRow = lnRow + 1
                    End If

                    If lsModelNme <> .InstallmentPrice(lnCtr, "sModelNme") Then
                        If lnRow + 1 > gridPricelist.RowCount Then gridPricelist.RowCount = gridPricelist.RowCount + 1

                        gridPricelist.Rows(lnRow - 1).Cells(0).Value = .InstallmentPrice(lnCtr, "sModelNme")
                        gridPricelist.Rows(lnRow - 1).Cells(1).Value = Format(.InstallmentPrice(lnCtr, "nSelPrice"), "#,##0")
                        gridPricelist.Rows(lnRow - 1).Cells(2).Value = Format(.InstallmentPrice(lnCtr, "nMinDownx"), "#,##0")
                        gridPricelist.Rows(lnRow - 1).Cells(3).Value = 0
                        gridPricelist.Rows(lnRow - 1).Cells(4).Value = 0
                        gridPricelist.Rows(lnRow - 1).Cells(5).Value = 0
                        gridPricelist.Rows(lnRow - 1).Cells(6).Value = 0
                        gridPricelist.Rows(lnRow - 1).Cells(7).Value = 0

                        If ldLatest = .InstallmentPrice(lnCtr, "dInsPrice") Then
                            If ldLatest = IFNull(.InstallmentPrice(lnCtr, "dInsPrice"), "2001-01-01") Then
                                For lnCol = 1 To gridPricelist.ColumnCount
                                    gridPricelist.Rows(lnRow - 1).Cells(lnCol - 1).Style.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                                Next
                            End If
                        End If

                        lsModelNme = .InstallmentPrice(lnCtr, "sModelNme")
                        lnRow = lnRow + 1
                    Else
                        .MCModel = lsModelNme

                        Do While lsModelNme = .InstallmentPrice(lnCtr, "sModelNme")
                            For lnCol = 0 To UBound(lanTerm)
                                If CInt(oTrans.InstallmentPrice(lnCtr, "nAcctThru")) = lanTerm(lnCol) Then
                                    gridPricelist.Rows(lnRow - 2).Cells(lnCol + 3).Value = Format(.getMonthly(IFNull(.InstallmentPrice(lnCtr, "nMinDownx"), 0), lanTerm(lnCol)), "#,##0")
                                    Exit For
                                End If
                            Next
                            lnCtr = lnCtr + 1
                        Loop
                    End If
                Loop
            Catch ex As Exception
                ' MsgBox(ex.Message)
            End Try

            With gridPricelist
                If .Rows(.RowCount - 1).Cells(0).Value = "" Then .RowCount = .RowCount - 1

                If .RowCount > 22 Then
                    .Columns(1).Width = 150
                Else
                    .Columns(1).Width = 165
                End If

                .Rows(0).Selected = True
            End With
        End With
    End Sub

    Private Sub InitGrid()
        With gridPricelist.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(gridPricelist.Font, FontStyle.Bold)
        End With

        With gridPricelist
            .ColumnCount = 8
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

            .Columns(0).Width = 165
            .Columns(1).Width = 80
            .Columns(2).Width = 80
            .Columns(3).Width = 80
            .Columns(4).Width = 80
            .Columns(5).Width = 80
            .Columns(6).Width = 80
            .Columns(7).Width = 80

            .Columns(0).Name = "Model Name"
            .Columns(1).Name = "SRP"
            .Columns(2).Name = "D/P"
            .Columns(3).Name = "6 Mon"
            .Columns(4).Name = "12 Mon"
            .Columns(5).Name = "18 Mon"
            .Columns(6).Name = "24 Mon"
            .Columns(7).Name = "36 Mon"

            Dim lnCtr As Integer
            For lnCtr = 0 To 7
                .Columns(lnCtr).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            .Rows(0).Selected = True
        End With
    End Sub
End Class