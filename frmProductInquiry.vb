Option Explicit On

Imports MySql.Data.MySqlClient
Imports ggcAppDriver

Public Class frmProductInquiry
    Private poDTModel As DataTable

    Dim p_sModelIDx As String = ""
    Dim p_sModelNme As String = ""

    Private Sub cmdButton_MouseClick(sender As System.Object, e As System.EventArgs) Handles cmdButton02.Click, cmdButton00.Click, cmdButton01.Click
        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 1
                    If SearchModel(txtSearch.Text) Then
                        txtSearch.Text = p_sModelNme
                        LoadFeatures()
                        LoadSpecs()
                    End If
                Case 0, 2
                    Me.Close()
            End Select
        End If
    End Sub

    Private Sub cmdButton_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles cmdButton02.MouseDown, cmdButton00.MouseDown, cmdButton01.MouseDown

        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 : cmdButton00.BackgroundImage = My.Resources.OK_OnMouseDown
                Case 1 : cmdButton01.BackgroundImage = My.Resources.Search_OnMouseDown
                Case 2 : cmdButton02.BackgroundImage = My.Resources.Close_Small_OnMouseDown
            End Select
        End If
    End Sub

    Private Sub cmdButton_MouseOver(sender As Object, e As System.EventArgs) Handles cmdButton02.MouseHover, cmdButton00.MouseHover, cmdButton01.MouseHover

        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 : cmdButton00.BackgroundImage = My.Resources.OK_OnMouseOver
                Case 1 : cmdButton01.BackgroundImage = My.Resources.Search_OnMouseOver
                Case 2 : cmdButton02.BackgroundImage = My.Resources.Close_Small_OnMouseOver
            End Select
        End If
    End Sub

    Private Sub cmdButton_MouseLeave(sender As Object, e As System.EventArgs) Handles cmdButton02.MouseLeave, cmdButton00.MouseLeave, cmdButton01.MouseLeave

        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 : cmdButton00.BackgroundImage = My.Resources.OK
                Case 1 : cmdButton01.BackgroundImage = My.Resources.SearchInq
                Case 2 : cmdButton02.BackgroundImage = My.Resources.Close_Small
            End Select
        End If
    End Sub

#Region "Events"
    Private Function getSQLModel() As String
        Return _
             "SELECT" & _
                "  a.sModelIDx" & _
                ", a.sModelCde" & _
                ", a.sModelNme" & _
                ", a.sModelDsc" & _
                ", CASE a.cEndOfLfe WHEN '1' THEN 'YES' WHEN '0' THEN 'NO' ELSE '' END xEndOfLfe" & _
                ", a.sBrandIDx" & _
                ", b.sBrandNme" & _
            " FROM MC_Model a" & _
                ", Brand b" & _
            " WHERE a.sBrandIDx = b.sBrandIDx" & _
            " ORDER BY b.sBrandNme, a.sModelNme"
    End Function

    Private Function getSQLFeatures() As String
        Return _
            "SELECT sDescript" & _
            " FROM MC_Model_Features" & _
            " ORDER BY nEntryNox"
    End Function

    Private Function getSQLSpecs() As String
        Return _
            "SELECT sDescript" & _
            " FROM MC_Model_Specs" & _
            " ORDER BY nEntryNox"
    End Function

    Private Function SearchModel(ByVal lsValue As String) As Boolean
        Dim loDT As DataTable
        Dim loDataRow As DataRow
        Dim lsSQL As String

        lsSQL = AddCondition(getSQLModel, "a.sModelNme LIKE " & strParm(lsValue & "%"))
        loDT = p_oAppDriver.ExecuteQuery(lsSQL)

        loDataRow = KwikSearch(p_oAppDriver, lsSQL, "", "sBrandNme»sModelNme»sModelCde»xEndOfLfe", _
                                    "Brand»Model»Code»End of Life", , "b.sBrandNme»a.sModelNme»a.sModelCde»a.cEndOfLfe", 1)

        If Not IsNothing(loDataRow) Then
            p_sModelIDx = loDataRow("sModelIDx")
            p_sModelNme = loDataRow("sModelNme")
            Return True
        End If

        Return False
    End Function

    Private Sub LoadFeatures()
        Dim loDT As DataTable
        Dim lsSQL As String

        lsSQL = "SELECT nEntryNox, sDescript, sFeatrIDx" & _
                " FROM MC_Model_Features" & _
                " WHERE sModelIDx = " & strParm(p_sModelIDx) & _
                " ORDER BY nEntryNox"

        loDT = p_oAppDriver.ExecuteQuery(lsSQL)

        If loDT.Rows.Count = 0 Then
            MsgBox("Model features not set.", MsgBoxStyle.Information, "Notice")
            Exit Sub
        End If

loadrecord:
        With gridFeatures
            Dim lnRow As Integer = loDT.Rows.Count()
            Dim lnCtr As Integer

            .RowCount = lnRow
            For lnCtr = 0 To lnRow - 1
                .Rows(lnCtr).Cells(0).Value = loDT(lnCtr)("nEntryNox")
                .Rows(lnCtr).Cells(1).Value = loDT(lnCtr)("sDescript")
            Next

            'goto last row
            .ClearSelection()
            .CurrentCell = .Rows(lnRow - 1).Cells(0)
            .Rows(lnRow - 1).Selected = True
        End With
    End Sub

    Private Sub LoadSpecs()
        Dim loDT As DataTable
        Dim lsSQL As String

        lsSQL = "SELECT nEntryNox, sDescript, sSpecsIDx" & _
                " FROM MC_Model_Specs" & _
                " WHERE sModelIDx = " & strParm(p_sModelIDx) & _
                " ORDER BY nEntryNox"

        loDT = p_oAppDriver.ExecuteQuery(lsSQL)

        If loDT.Rows.Count = 0 Then
            MsgBox("Model specs not set.", MsgBoxStyle.Information, "Notice")
            Exit Sub
        End If

loadrecord:
        With gridSpecs
            Dim lnRow As Integer = loDT.Rows.Count()
            Dim lnCtr As Integer

            .RowCount = lnRow
            For lnCtr = 0 To lnRow - 1
                .Rows(lnCtr).Cells(0).Value = loDT(lnCtr)("nEntryNox")
                .Rows(lnCtr).Cells(1).Value = loDT(lnCtr)("sDescript")
            Next

            'goto last row
            .ClearSelection()
            .CurrentCell = .Rows(lnRow - 1).Cells(0)
            .Rows(lnRow - 1).Selected = True
        End With
    End Sub

    Private Sub InitForm()
        txtSearch.Text = ""
        lblProduct.Text = ""

        With gridFeatures.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(gridFeatures.Font, FontStyle.Bold)
        End With

        With gridFeatures
            .ColumnCount = 2
            .RowCount = 0

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

            .Columns(0).Width = 40
            .Columns(1).Width = 530

            .Columns(0).Name = "No"
            .Columns(1).Name = "Features"
        End With


        With gridSpecs.ColumnHeadersDefaultCellStyle
            .BackColor = Color.Navy
            .ForeColor = Color.White
            .Font = New Font(gridFeatures.Font, FontStyle.Bold)
        End With

        With gridSpecs
            .ColumnCount = 2
            .RowCount = 0

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

            .Columns(0).Width = 40
            .Columns(1).Width = 530

            .Columns(0).Name = "No"
            .Columns(1).Name = "Specs"
        End With
    End Sub
#End Region

    Private Sub frmProductInquiry_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InitForm()
    End Sub
End Class