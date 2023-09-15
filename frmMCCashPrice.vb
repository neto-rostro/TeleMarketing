Imports ggcAppDriver
Imports ggcMCSales
Imports System.Threading

Public Class frmMCCashPrice
    Private Const pxeMsgHeader As String = "frmMCCashPrice"

    Private WithEvents oTrans As ggcMCSales.MCPricelist
    Private pnTick As Integer

    Private Sub frmMCCashPrice_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        oTrans = New ggcMCSales.MCPricelist(p_oAppDriver)

        Call InitGrid()
        Call LoadPriceList()

        pnTick = 0
        Timer1.Start()
    End Sub

    Private Sub LoadPriceList()
        Dim lnRow As Integer
        Dim lnCol As Integer
        Dim lnCtr As Integer
        Dim ldLatest As Date
        Dim lsCategory As String
        Dim lsModelNme As String
        Dim lasFormat(4) As String

        lasFormat(0) = ""
        lasFormat(1) = ""
        lasFormat(2) = "#,##0.00"
        lasFormat(3) = "#,##0.00"
        lasFormat(4) = "#,##0.00"

        With oTrans
            .LoadCashPrice()

            gridPricelist.RowCount = .CashPriceCount + 1

            lsCategory = ""
            lsModelNme = ""
            lnCtr = 0
            lnRow = 1

            ldLatest = .CashLatestDate

            Try
                Do While lnCtr < .CashPriceCount
                    If lsCategory <> .CashPrice(lnCtr, "sMCCatNme") Then
                        If lnRow + 1 > gridPricelist.RowCount Then gridPricelist.RowCount = gridPricelist.RowCount + 1

                        gridPricelist.Rows(lnRow - 1).Cells(0).Value = .CashPrice(lnCtr, "sMCCatNme")

                        'gridPricelist.Rows(lnRow - 1).Selected = True
                        For lnCol = 1 To gridPricelist.ColumnCount
                            gridPricelist.Rows(lnRow - 1).Cells(lnCol - 1).Style.ForeColor = Color.Black
                            gridPricelist.Rows(lnRow - 1).Cells(lnCol - 1).Style.BackColor = Color.Yellow
                            gridPricelist.Rows(lnRow - 1).Cells(lnCol - 1).Style.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                        Next

                        lsCategory = .CashPrice(lnCtr, "sMCCatNme")
                        lnRow = lnRow + 1
                    End If

                    If lnRow + 1 > gridPricelist.RowCount Then gridPricelist.RowCount = gridPricelist.RowCount + 1
                    'gridPricelist.Rows(lnRow - 1).Selected = True

                    For lnCol = 1 To gridPricelist.ColumnCount
                        gridPricelist.Rows(lnRow - 1).Cells(lnCol - 1).Value = Format(IFNull(.CashPrice(lnCtr, lnCol), 0), lasFormat(lnCol - 1))

                        If ldLatest = IFNull(.CashPrice(lnCtr, 6), "2001-01-01") Then
                            gridPricelist.Rows(lnRow - 1).Cells(lnCol - 1).Style.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Bold)
                        End If
                    Next
                    lnRow = lnRow + 1
                    lnCtr = lnCtr + 1
                Loop
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            With gridPricelist
                If .Rows(.RowCount - 1).Cells(0).Value = "" Then .RowCount = .RowCount - 1

                If .RowCount > 22 Then
                    .Columns(1).Width = 205
                Else
                    .Columns(1).Width = 185
                End If

                '.Rows(1).Selected = True
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
            .ColumnCount = 5
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

            .Columns(0).Width = 200
            .Columns(1).Width = 200
            .Columns(2).Width = 100
            .Columns(3).Width = 100
            .Columns(4).Width = 100

            .Columns(0).Name = "Model Name"
            .Columns(1).Name = "Brand"
            .Columns(2).Name = "SRP"
            .Columns(3).Name = "Last Price"
            .Columns(4).Name = "Dealer Price"

            Dim lnCtr As Integer
            For lnCtr = 0 To 4
                .Columns(lnCtr).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            .Rows(0).Selected = True
        End With
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If pnTick >= 60 Then
            LoadPriceList()
            pnTick = 0
        Else
            pnTick += 1
        End If
    End Sub
End Class