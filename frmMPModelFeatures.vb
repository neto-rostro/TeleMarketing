Imports MySql.Data.MySqlClient
Imports ggcAppDriver

Public Class frmMPModelFeatures
    Private Const pxeMasTablex As String = "CP_Model"
    Private Const pxeTableName As String = "CP_Model_Features"

    Private pnLoadx As Integer
    Private poControl As Control

    Private psModelIDx As String
    Private p_nEditMode As Integer

    Dim poRow As DataRow
    Dim poDT As DataTable
    Dim poDTTemp As DataTable

    Private Sub frmMPModelFeaturess_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If pnLoadx = 1 Then
            pnLoadx = 2
        End If
    End Sub

    Private Sub frmMPModelFeatures_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim loTxt As Control

            loTxt = Nothing
            If TypeOf poControl Is TextBox Then
                loTxt = CType(poControl, System.Windows.Forms.TextBox)
            ElseIf TypeOf poControl Is CheckBox Then
                loTxt = CType(poControl, System.Windows.Forms.CheckBox)
            ElseIf TypeOf poControl Is ComboBox Then
                loTxt = CType(poControl, System.Windows.Forms.ComboBox)
            End If

            If TypeOf poControl Is TextBox Or
               TypeOf poControl Is CheckBox Or
               TypeOf poControl Is ComboBox Then
                SelectNextControl(loTxt, True, True, True, True)
            End If
        End If
    End Sub

    Private Sub frmMPModelFeatures_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If pnLoadx = 0 Then
            'Set event Handler for txtField
            Call grpEventHandler(Me, GetType(TextBox), "txtField", "GotFocus", AddressOf txtField_GotFocus)
            Call grpEventHandler(Me, GetType(TextBox), "txtField", "LostFocus", AddressOf txtField_LostFocus)
            Call grpCancelHandler(Me, GetType(TextBox), "txtField", "Validating", AddressOf txtField_Validating)
            Call grpKeyHandler(Me, GetType(TextBox), "txtField", "KeyDown", AddressOf txtField_KeyDown)

            Call grpEventHandler(Me, GetType(TextBox), "txtOther", "GotFocus", AddressOf txtField_GotFocus)
            Call grpEventHandler(Me, GetType(TextBox), "txtOther", "LostFocus", AddressOf txtField_LostFocus)
            Call grpCancelHandler(Me, GetType(TextBox), "txtOther", "Validating", AddressOf txtOther_Validating)
            Call grpKeyHandler(Me, GetType(TextBox), "txtOther", "KeyDown", AddressOf txtOther_KeyDown)

            Call grpEventHandler(Me, GetType(Button), "cmdButton", "Click", AddressOf cmdButton_Click)
            Call grpEventHandler(Me, GetType(Button), "cmdOthers", "Click", AddressOf cmdOthers_Click)

            p_nEditMode = xeEditMode.MODE_UNKNOWN
            initButton()

            pnLoadx = 1
        End If
    End Sub

    Private Sub txtField_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        If Mid(loTxt.Name, 1, 8) = "txtField" Then
            Select Case loIndex
                Case 1
            End Select
        End If

        poControl = loTxt

        loTxt.BackColor = Color.Azure
        loTxt.SelectAll()
    End Sub

    Private Sub txtOther_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        If Mid(loTxt.Name, 1, 8) = "txtOther" Then
            Select Case loIndex
                Case 1
            End Select
        End If

        poControl = loTxt

        loTxt.BackColor = Color.Azure
        loTxt.SelectAll()
    End Sub

    Private Sub txtField_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    End Sub

    Private Sub txtOther_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    End Sub

    Private Sub txtField_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        If Mid(loTxt.Name, 1, 8) = "txtField" Then
            Select Case loIndex
                Case 1
            End Select
        End If

        loTxt.BackColor = SystemColors.Window
        poControl = Nothing
    End Sub

    Private Sub txtOther_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        If Mid(loTxt.Name, 1, 8) = "txtOther" Then
            Select Case loIndex
                Case 1
            End Select
        End If

        loTxt.BackColor = SystemColors.Window
        poControl = Nothing
    End Sub

    Private Sub txtField_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub txtOther_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        With DataGridView1
            Dim lnRow As Integer
            lnRow = .CurrentRow.Index

            If Mid(loTxt.Name, 1, 8) = "txtOther" Then
                Select Case loIndex
                    Case 1
                        poDT(lnRow)("sDescript") = txtOther01.Text
                End Select
            End If
        End With
    End Sub

    Private Sub cmdOthers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim loChk As Button
        loChk = CType(sender, System.Windows.Forms.Button)

        Dim lnIndex As Integer
        lnIndex = Val(Mid(loChk.Name, 10))

        Select Case lnIndex
            Case 0 'add
                AddDetail()
                InitGrid()
                LoadDetail(True)
            Case 1 'del
                DeleteDetail(DataGridView1.CurrentRow.Index)
                InitGrid()
                LoadDetail(True)
        End Select
    End Sub

    Private Sub cmdButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim loChk As Button
        loChk = CType(sender, System.Windows.Forms.Button)

        Dim lnIndex As Integer
        lnIndex = Val(Mid(loChk.Name, 10))

        Select Case lnIndex
            Case 1 'new
                'NewRecord()
            Case 2 'save
                If SaveRecord() Then LoadDetail()
            Case 3 'search
                'SearchRecord()
            Case 4 'browse
                BrowseRecord()
            Case 5 'cancel
                CancelTransaction()
            Case 6 'update
                UpdateRecord()
            Case 7 'del
                'DeleteRecord()
            Case 8 'close
                Me.Close()
        End Select
    End Sub

    Private Sub InitGrid()
        With DataGridView1
            'Set No of Columns
            .ColumnCount = 2

            'Set Column Headers
            .Columns(0).HeaderText = "No"
            .Columns(1).HeaderText = "Features"

            'Set Column Sizes
            .Columns(0).Width = 40
            .Columns(1).Width = 387
        End With
    End Sub

    Private Sub initButton()
        'UNKNOWN = -1
        'READY = 0
        'ADDNEW = 1
        'UPDATE = 2
        'DELETE = 3

        Dim lbShow As Integer
        lbShow = (p_nEditMode = 1 Or p_nEditMode = 2)

        cmdButton02.Visible = lbShow
        cmdButton03.Visible = lbShow
        cmdButton05.Visible = lbShow
        GroupBox3.Enabled = lbShow

        cmdButton01.Visible = Not lbShow
        cmdButton06.Visible = Not lbShow
        cmdButton07.Visible = Not lbShow
        cmdButton08.Visible = Not lbShow
    End Sub

    Private Function SaveRecord() As Boolean
        If Not isEntryOK() Then Return False
        If Not saveModified() Then Return False

        MsgBox("Record Saved Successfuly.", MsgBoxStyle.Information, "Success")

        p_nEditMode = xeEditMode.MODE_READY
        initButton()

        Return True
endwithRoll:
        p_oAppDriver.RollBackTransaction()
        MsgBox("Unable to Save Record. Please verify your entry.", MsgBoxStyle.Critical, "Warning")
        Return False
    End Function

    Private Function BrowseRecord() As Boolean
        Dim lsSQL As String
        Dim lsFilter As String = ""

        lsSQL = "SELECT" & _
                    "  a.sModelIDx" & _
                    ", a.sModelCde" & _
                    ", a.sModelNme" & _
                    ", b.sBrandNme" & _
                " FROM " & pxeMasTablex & " a" & _
                    " , Brand b" & _
                " WHERE a.sBrandIDx = b.sBrandIDx" & _
                    " AND a.cRecdStat = " & strParm(xeRecordStat.RECORD_NEW) & _
                " ORDER BY b.sBrandNme, a.sModelNme"

        With p_oAppDriver
            poRow = KwikSearch(p_oAppDriver _
                                            , lsSQL _
                                            , False _
                                            , lsFilter _
                                            , "sModelIDx»sModelCde»sModelNme»sBrandNme" _
                                            , "Model ID»Code»Description»Brand" _
                                            , "" _
                                            , "a.sModelIDx»a.sModelCde»a.sModelNme»b.sBrandNme")

            If Not IsNothing(poRow) Then
                txtField00.Text = poRow(0)
                txtField01.Text = IFNull(poRow(1), "")
                txtField02.Text = IFNull(poRow(2), "")

                LoadDetail()

                p_nEditMode = xeEditMode.MODE_READY
                initButton()
            Else
                Return False
            End If
        End With

        Return True
    End Function

    Private Sub LoadDetail(Optional ByVal showonly As Boolean = False)
        If showonly Then GoTo loadrecord

        Dim lsSQL As String

        lsSQL = "SELECT nEntryNox, sDescript, sFeatrIDx" & _
                " FROM " & pxeTableName & _
                " WHERE sModelIDx = " & strParm(poRow(0)) & _
                " ORDER BY nEntryNox"

        poDT = Nothing
        poDTTemp = Nothing
        poDT = p_oAppDriver.ExecuteQuery(lsSQL)
        poDTTemp = p_oAppDriver.ExecuteQuery(lsSQL)

        If poDT.Rows.Count = 0 Then
            MsgBox("Model features not set.", MsgBoxStyle.Information, "Notice")
            Call AddDetail()
        End If

loadrecord:
        With DataGridView1
            Dim lnRow As Integer = poDT.Rows.Count()
            Dim lnCtr As Integer

            psModelIDx = poRow(0)

            .RowCount = lnRow
            For lnCtr = 0 To lnRow - 1
                .Rows(lnCtr).Cells(0).Value = poDT(lnCtr)("nEntryNox")
                .Rows(lnCtr).Cells(1).Value = poDT(lnCtr)("sDescript")
            Next

            'goto last row
            .ClearSelection()
            .CurrentCell = .Rows(lnRow - 1).Cells(0)
            .Rows(lnRow - 1).Selected = True

            'assign grid value to txtothers
            setFieldValue()
        End With
    End Sub

    Private Function SearchRecord() As Boolean
        Return True
    End Function

    Private Function UpdateRecord() As Boolean
        If p_nEditMode <> xeEditMode.MODE_READY Then Return False

        p_nEditMode = xeEditMode.MODE_UPDATE
        initButton()

        txtOther01.Focus()
        Return True
    End Function

    Private Function isEntryOK() As Boolean
        With DataGridView1
            If .Rows.Count < 1 Then Return False
            If .Rows.Count <> poDT.Rows.Count Then Return False
        End With

        Return True
    End Function

    Private Function saveModified() As Boolean
        If p_nEditMode <> xeEditMode.MODE_UPDATE Then Return False
        If IsNothing(poDT) Then Return False

        Dim lnCtr As Integer
        Dim lsSQL As String

        Try
            p_oAppDriver.BeginTransaction()
            If poDTTemp.Rows.Count = 0 Then
                'insert all the detail
                For lnCtr = 0 To poDT.Rows.Count - 1
                    If poDT(lnCtr)("sDescript") <> "" Then
                        lsSQL = "INSERT INTO " & pxeTableName & _
                                " SET nEntryNox = " & lnCtr + 1 & _
                                    ", sFeatrIDx = " & strParm(GetNextCode(pxeTableName, "sFeatrIDx", False, p_oAppDriver.Connection, True, p_oAppDriver.BranchCode)) & _
                                    ", sDescript = " & strParm(poDT(lnCtr)("sDescript")) & _
                                    ", sModelIDx = " & strParm(psModelIDx)

                        If p_oAppDriver.Execute(lsSQL, pxeTableName) = 0 Then Return False
                    End If
                Next
            Else
                If poDT.Rows.Count > 0 Then
                    'remove deleted item
                    Dim loDR() As DataRow
                    For lnCtr = 0 To poDTTemp.Rows.Count - 1
                        loDR = poDT.Select("sFeatrIDx = " & strParm(poDTTemp(lnCtr)("sFeatrIDx")))

                        If loDR.Length = 0 Then
                            lsSQL = "DELETE FROM " & pxeTableName & _
                                    " WHERE sModelIDx = " & strParm(psModelIDx) & _
                                        " AND sFeatrIDx = " & strParm(poDTTemp(lnCtr)("sFeatrIDx"))

                            If p_oAppDriver.Execute(lsSQL, pxeTableName) = 0 Then Return False
                        End If
                    Next

                    'update existing or insert new
                    For lnCtr = 0 To poDT.Rows.Count - 1
                        If poDT(lnCtr)("sDescript") = "" Then GoTo nextrec

                        If poDT(lnCtr)("nEntryNox") = 0 Then
                            lsSQL = "INSERT INTO " & pxeTableName & _
                                    " SET nEntryNox = " & lnCtr + 1 & _
                                        ", sFeatrIDx = " & strParm(GetNextCode(pxeTableName, "sFeatrIDx", False, p_oAppDriver.Connection, True, p_oAppDriver.BranchCode)) & _
                                        ", sDescript = " & strParm(poDT(lnCtr)("sDescript")) & _
                                        ", sModelIDx = " & strParm(psModelIDx)
                        Else
                            lsSQL = "UPDATE " & pxeTableName & _
                                    " SET sFeatrIDx = " & strParm(GetNextCode(pxeTableName, "sFeatrIDx", False, p_oAppDriver.Connection, True, p_oAppDriver.BranchCode)) & _
                                        ", sDescript = " & strParm(poDT(lnCtr)("sDescript")) & _
                                        ", nEntryNox = " & lnCtr + 1 & _
                                    " WHERE sModelIDx = " & strParm(psModelIDx) & _
                                        " AND nEntryNox = " & poDT(lnCtr)("nEntryNox")
                        End If

                        If p_oAppDriver.Execute(lsSQL, pxeTableName) = 0 Then Return False
nextrec:
                    Next
                Else
                    lsSQL = "DELETE FROM " & pxeTableName & _
                            " WHERE sModelIDx = " & strParm(psModelIDx)

                    p_oAppDriver.Execute(lsSQL, pxeTableName)
                End If
            End If
            p_oAppDriver.CommitTransaction()

        Catch ex As MySqlException
            p_oAppDriver.RollBackTransaction()
            MsgBox("MySQL Exception - " & pxeTableName, MsgBoxStyle.Critical, "Warning")
        End Try

        Return True
    End Function

    Private Function CancelTransaction() As Boolean
        clearText()

        p_nEditMode = xeEditMode.MODE_UNKNOWN
        initButton()

        Return True
    End Function

    Private Sub AddDetail()
        Dim lnRow As Integer
        If poDT.Rows.Count = 0 Then
            poDT.Rows.Add()
            GoTo endProc
        End If

        lnRow = poDT.Rows.Count - 1
        If IFNull(poDT(lnRow)("sDescript")) = "" Then Exit Sub

        poDT.Rows.Add()
endProc:
        lnRow = poDT.Rows.Count - 1
        poDT(lnRow)("nEntryNox") = poDT.Rows.Count
        poDT(lnRow)("sDescript") = ""
        poDT(lnRow)("sFeatrIDx") = ""
        txtOther01.Focus()
    End Sub

    Private Sub DeleteDetail(ByVal lnRow As Integer)
        poDT.Rows(lnRow).Delete()
        poDT.AcceptChanges()

        If poDT.Rows.Count = 0 Then AddDetail()
    End Sub

    Private Sub clearText()
        txtField00.Text = ""
        txtField01.Text = ""
        txtField02.Text = ""

        Call InitGrid()
    End Sub

    Private Sub setFieldValue()
        With DataGridView1
            txtOther00.Text = .SelectedRows(0).Cells(0).Value.ToString
            txtOther01.Text = .SelectedRows(0).Cells(1).Value.ToString
            txtOther01.Focus()
        End With
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        With DataGridView1
            If e.RowIndex < 0 Then Exit Sub
            .ClearSelection()
            .CurrentCell = .Rows(e.RowIndex).Cells(e.ColumnIndex)
            .Rows(e.RowIndex).Selected = True

            setFieldValue()
        End With
    End Sub
End Class

'Private Function NewRecord() As Boolean
'    clearText()

'    txtField00.Text = GetNextCode(pxeTableName, "sModelIDx", False, p_oAppDriver.Connection, True, p_oAppDriver.BranchCode)

'    p_nEditMode = xeEditMode.MODE_ADDNEW
'    initButton()

'    txtField01.Focus()
'    Return True
'End Function

'    Private Function DeleteRecord() As Boolean
'        Dim lsSQL As String
'        Dim lnRow As Integer

'        If Not p_nEditMode = xeEditMode.MODE_READY Then Return False

'        If MsgBox("Are you sure to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
'            Return False
'        End If

'        lsSQL = "DELETE FROM " & pxeTableName & _
'                " WHERE sCategIDx = " & strParm(txtField00.Text)

'        With p_oAppDriver
'            .BeginTransaction()
'            lnRow = .Execute(lsSQL, pxeTableName)
'            If lnRow = 0 Then GoTo endWithroll
'            .CommitTransaction()
'        End With

'        MsgBox("Record Deleted Successfuly.", MsgBoxStyle.Information, "Success")

'        p_nEditMode = xeEditMode.MODE_UNKNOWN
'        initButton()
'        clearText()

'        Return True
'endwithRoll:
'        p_oAppDriver.RollBackTransaction()
'        MsgBox("Unable to Delete Record.", MsgBoxStyle.Critical, "Warning")
'        Return False
'    End Function