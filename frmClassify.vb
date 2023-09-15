Imports ggcAppDriver
Imports System.Text
Imports System.IO

Imports ggcMCSales

Public Class frmClassify
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim loDtMaster As DataTable
        Dim loDtDetail As DataTable
        Dim lsSQL As String
        Dim lbContacted As Boolean

        lsSQL = "SELECT a.sClientID" & _
                " FROM TLM_Client a, Client_Master b" & _
                " WHERE a.cSourceCd = 'MP'" & _
                    " AND a.cTranStat IS NULL" & _
                    " AND a.sClientID = b.sClientID" & _
                    "  AND LEFT(sMobileNo, 4) IN ('0907'" & _
                                        ",'0908'" & _
                                        ",'0909'" & _
                                        ",'0910'" & _
                                        ",'0911'" & _
                                        ",'0912'" & _
                                        ",'0913'" & _
                                        ",'0914'" & _
                                        ",'0918'" & _
                                        ",'0919'" & _
                                        ",'0920'" & _
                                        ",'0921'" & _
                                        ",'0928'" & _
                                        ",'0929'" & _
                                        ",'0930'" & _
                                        ",'0938'" & _
                                        ",'0939'" & _
                                        ",'0946'" & _
                                        ",'0947'" & _
                                        ",'0948'" & _
                                        ",'0949'" & _
                                        ",'0950'" & _
                                        ",'0989'" & _
                                        ",'0998'" & _
                                        ",'0999')" & _
        " LIMIT 5000"


        '                                   " AND LEFT(sMobileNo, 4) IN ('0907'" & _
        '                                ",'0908'" & _
        '                                ",'0909'" & _
        '                                ",'0910'" & _
        '                                ",'0911'" & _
        '                                ",'0912'" & _
        '                                ",'0913'" & _
        '                                ",'0914'" & _
        '                                ",'0918'" & _
        '                                ",'0919'" & _
        '                                ",'0920'" & _
        '                                ",'0921'" & _
        '                                ",'0928'" & _
        '                                ",'0929'" & _
        '                                ",'0930'" & _
        '                                ",'0938'" & _
        '                                ",'0939'" & _
        '                                ",'0946'" & _
        '                                ",'0947'" & _
        '                                ",'0948'" & _
        '                                ",'0949'" & _
        '                                ",'0950'" & _
        '                                ",'0989'" & _
        '                                ",'0998'" & _
        '                                ",'0999')" & _
        '" LIMIT 5000"

        '            " AND LEFT(sMobileNo, 4) IN ('0907'" & _
        '                                ",'0908'" & _
        '                                ",'0909'" & _
        '                                ",'0910'" & _
        '                                ",'0911'" & _
        '                                ",'0912'" & _
        '                                ",'0913'" & _
        '                                ",'0914'" & _
        '                                ",'0918'" & _
        '                                ",'0919'" & _
        '                                ",'0920'" & _
        '                                ",'0921'" & _
        '                                ",'0928'" & _
        '                                ",'0929'" & _
        '                                ",'0930'" & _
        '                                ",'0938'" & _
        '                                ",'0939'" & _
        '                                ",'0946'" & _
        '                                ",'0947'" & _
        '                                ",'0948'" & _
        '                                ",'0949'" & _
        '                                ",'0950'" & _
        '                                ",'0989'" & _
        '                                ",'0998'" & _
        '                                ",'0999')" & _
        '" LIMIT 5000"

        lsSQL = "SELECT a.sClientID" & _
                " FROM TLM_Client a, Client_Master b" & _
                " WHERE a.cSourceCd = 'MP'" & _
                    " AND a.cTranStat IS NULL" & _
                    " AND a.sClientID = b.sClientID" & _
                    " AND LEFT(sMobileNo, 4) IN ('0905'" & _
                                                    ",'0906'" & _
                                                    ",'0915'" & _
                                                    ",'0916'" & _
                                                    ",'0917'" & _
                                                    ",'0926'" & _
                                                    ",'0927'" & _
                                                    ",'0935'" & _
                                                    ",'0936'" & _
                                                    ",'0945'" & _
                                                    ",'0975'" & _
                                                    ",'0976'" & _
                                                    ",'0977'" & _
                                                    ",'0994'" & _
                                                    ",'0995'" & _
                                                    ",'0996'" & _
                                                    ",'0997')" & _
                " LIMIT 5000"

        'sun prefix 
        'lsSQL = "SELECT a.sClientID" & _
        '        " FROM TLM_Client a, Client_Master b" & _
        '        " WHERE a.cSourceCd = 'MP'" & _
        '            " AND a.cTranStat IS NULL" & _
        '            " AND a.sClientID = b.sClientID" & _
        '" AND LEFT(sMobileNo, 4) IN ('0922'" & _
        '                            ",'0923'" & _
        '                            ",'0924'" & _
        '                            ",'0925'" & _
        '                            ",'0931'" & _
        '                            ",'0932'" & _
        '                            ",'0933'" & _
        '                            ",'0934'" & _
        '                            ",'0942'" & _
        '                            ",'0943')" & _
        '" LIMIT 5000"

        loDtMaster = New DataTable
        loDtMaster = p_oAppDriver.ExecuteQuery(lsSQL)

        For Each mRow As DataRow In loDtMaster.Rows
            lsSQL = "SELECT *" & _
                    " FROM TLM_Call_Master" & _
                    " WHERE sClientID = " & strParm(mRow("sClientID"))

            loDtDetail = New DataTable
            loDtDetail = p_oAppDriver.ExecuteQuery(lsSQL)

            If loDtDetail.Rows.Count = 0 Then
                p_oAppDriver.Execute("UPDATE TLM_Client SET" & _
                                        " cTranStat = '0'" & _
                                    " WHERE sClientID = " & strParm(mRow("sClientID")), "TLM_Client")
            Else
                lbContacted = False
                For Each dRow As DataRow In loDtDetail.Rows
                    If Not IsDBNull(dRow("dCallStrt")) Then
                        lbContacted = True
                        Exit For
                    End If
                Next dRow

                If lbContacted Then
                    p_oAppDriver.Execute("UPDATE TLM_Client SET" & _
                                        " cTranStat = '2'" & _
                                    " WHERE sClientID = " & strParm(mRow("sClientID")), "TLM_Client")
                Else
                    p_oAppDriver.Execute("UPDATE TLM_Client SET" & _
                                        " cTranStat = '0'" & _
                                    " WHERE sClientID = " & strParm(mRow("sClientID")), "TLM_Client")
                End If
            End If
            Debug.Print(mRow("sClientID"))
        Next mRow

        MsgBox("Tapos na po")
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim loClassify As TLMCustClassify

        loClassify = New TLMCustClassify
        loClassify.AppDriver = p_oAppDriver

        'If loClassify.ClassifyMCCustomer(True) Then
        '    MsgBox("Classification for MC Customers done!!!")
        'End If

        If loClassify.ClassifyMPCustomer Then
            MsgBox("Classification for MP Customers done!!!")
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim MyFile As String
        Dim MyPath As String

        MyPath = "\\192.168.10.220\ssg\Finance\BankReconciliation" & "\DOWNLOAD"
        MyFile = Dir(MyPath & "\MB\")

        Do While MyFile <> ""
            If MyFile Like "*.csv" Then
                If MB_Bank_Statement(MyPath & "\MB\" & MyFile) Then
                    File.Move(MyPath & "\MB\" & MyFile, "\\192.168.10.220\ssg\Finance\BankReconciliation\PROCESS\MB\" & MyFile)
                Else
                    Exit Do
                End If
            End If
            MyFile = Dir()
        Loop

        MsgBox("ola")
        MyFile = Dir(MyPath & "\BDO\")
        Do While MyFile <> ""
            If MyFile Like "*.csv" Then
                If BDO_Bank_Statement(MyPath & "\BDO\" & MyFile) Then
                    File.Move(MyPath & "\BDO\" & MyFile, "\\192.168.10.220\ssg\Finance\BankReconciliation\PROCESS\BDO\" & MyFile)
                Else
                    Exit Do
                End If
            End If
            MyFile = Dir()
        Loop
    End Sub

    Private Function MB_Bank_Statement(ByVal sFileName As String) As Boolean
        Dim lors As DataTable
        Dim lnRow As Int32 = 0
        Dim lsSelected() As String
        Dim lsFiltered() As String
        Dim lsAcctIDxx As String
        Dim lsSQL As String

        lors = FileReader(sFileName)

        p_oAppDriver.BeginTransaction()
        For Each drRow As DataRow In lors.Rows
            Select Case lnRow
                Case 0
                    lsSelected = Split(drRow(0), ",")
                    lsFiltered = Split(Replace(lsSelected(1), """", ""), " ")
                    lsAcctIDxx = getBankAccountID(Replace(lsFiltered(0), "-", ""))

                    If lsAcctIDxx = "" Then
                        p_oAppDriver.RollBackTransaction()
                        Return False
                    End If
                Case Is > 3
                    lsSelected = Split(drRow(0), ",")
                    lsSQL = "INSERT INTO Bank_Account_Ledger_Statement SET" & _
                                "  sBnkActID = " & strParm(lsAcctIDxx) & _
                                ", dTransact = " & dateParm(lsSelected(0)) & _
                                ", sBranchCd = " & strParm("") & _
                                ", sDescript = " & strParm(lsSelected(6)) & _
                                ", nDebitAmt = " & CInt(IIf(lsSelected(3) = "", 0, lsSelected(3))) & _
                                ", nCredtAmt = " & CInt(IIf(lsSelected(4) = "", 0, lsSelected(4))) & _
                                ", nABalance = " & CInt(IIf(lsSelected(5) = "", 0, lsSelected(5))) & _
                                ", sCheckNox = " & strParm(Replace(lsSelected(1), """", "")) & _
                                ", sSourceCd = " & strParm("") & _
                                ", sSourceNo = " & strParm("") & _
                                ", sNotedxxx = " & strParm("") & _
                                ", cPostedxx = " & strParm("") & _
                                ", sPostedxx = " & strParm("")

                    Try
                        If p_oAppDriver.Execute(lsSQL, "Bank_Account_Ledger_Statement") <= 0 Then
                            p_oAppDriver.RollBackTransaction()
                            Return False
                            Exit For
                        End If
                    Catch ex As Exception
                        p_oAppDriver.RollBackTransaction()
                        Return False
                        Exit For
                    End Try
            End Select

            lnRow = lnRow + 1
        Next drRow
        p_oAppDriver.CommitTransaction()

        Return True
    End Function

    Private Function BDO_Bank_Statement(ByVal sFileName As String) As Boolean
        Dim lors As DataTable
        Dim lnRow As Int32 = 0
        Dim lsSelected() As String
        Dim lsFiltered() As String
        Dim lsAcctIDxx As String
        Dim lsSQL As String

        lors = FileReader(sFileName)

        p_oAppDriver.BeginTransaction()
        For Each drRow As DataRow In lors.Rows
            Select Case lnRow
                Case 1
                    lsSelected = Split(drRow(0), ",")
                    lsFiltered = Split(lsSelected(0), " ")

                    lsAcctIDxx = getBankAccountID(Replace(lsFiltered(2), "-", ""))
                    If lsAcctIDxx = "" Then
                        p_oAppDriver.RollBackTransaction()
                        Return False
                    End If
                Case lors.Rows.Count - 1
                    'do not include report date
                Case Is > 3
                    lsSelected = Split(drRow(0), ",")
                    lsSQL = "INSERT INTO Bank_Account_Ledger_Statement SET" & _
                                "  sBnkActID = " & strParm(lsAcctIDxx) & _
                                ", dTransact = " & dateParm(lsSelected(0)) & _
                                ", sBranchCd = " & strParm(UCase(lsSelected(2).Substring(lsSelected(2).Length - 4, 4))) & _
                                ", sDescript = " & strParm(lsSelected(1)) & _
                                ", nDebitAmt = " & CInt(IIf(lsSelected(3) = "", 0, lsSelected(3))) & _
                                ", nCredtAmt = " & CInt(IIf(lsSelected(4) = "", 0, lsSelected(4))) & _
                                ", nABalance = " & CInt(IIf(lsSelected(5) = "", 0, lsSelected(5))) & _
                                ", sCheckNox = " & strParm(lsSelected(6)) & _
                                ", sSourceCd = " & strParm("") & _
                                ", sSourceNo = " & strParm("") & _
                                ", sNotedxxx = " & strParm("") & _
                                ", cPostedxx = " & strParm("") & _
                                ", sPostedxx = " & strParm("")

                    Try
                        If p_oAppDriver.Execute(lsSQL, "Bank_Account_Ledger_Statement") <= 0 Then
                            p_oAppDriver.RollBackTransaction()
                            Return False
                            Exit For
                        End If
                    Catch ex As Exception
                        p_oAppDriver.RollBackTransaction()
                        Return False
                        Exit For
                    End Try
            End Select

            lnRow = lnRow + 1
        Next drRow
        p_oAppDriver.CommitTransaction()

        Return True
    End Function

    Private Function FileReader(ByVal sFileName As String) As DataTable
        Dim TextFileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(sFileName)

        TextFileReader.TextFieldType = FileIO.FieldType.Delimited
        TextFileReader.SetDelimiters(";")

        Dim TextFileTable As DataTable = Nothing

        Dim Column As DataColumn
        Dim Row As DataRow
        Dim UpperBound As Int32
        Dim ColumnCount As Int32
        Dim CurrentRow As String()

        While Not TextFileReader.EndOfData
            Try
                CurrentRow = TextFileReader.ReadFields()
                If Not CurrentRow Is Nothing Then
                    'Check if DataTable has been created
                    If TextFileTable Is Nothing Then
                        TextFileTable = New DataTable("TextFileTable")
                        'Get number of columns
                        UpperBound = CurrentRow.GetUpperBound(0)
                        'Create new DataTable
                        For ColumnCount = 0 To UpperBound
                            Column = New DataColumn()
                            Column.DataType = System.Type.GetType("System.String")
                            Column.ColumnName = "Column" & ColumnCount
                            Column.Caption = "Column" & ColumnCount
                            Column.ReadOnly = True
                            Column.Unique = False
                            TextFileTable.Columns.Add(Column)
                        Next
                    End If
                    Row = TextFileTable.NewRow
                    For ColumnCount = 0 To UpperBound
                        Row("Column" & ColumnCount) = CurrentRow(ColumnCount).ToString
                    Next
                    TextFileTable.Rows.Add(Row)
                End If
            Catch ex As  _
                Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & ex.Message & _
                "is not valid and will be skipped.")
            End Try
        End While
        TextFileReader.Dispose()

        Return TextFileTable
    End Function

    Private Function getBankAccountID(ByVal sActNumbr As String) As String
        Dim lors As DataTable
        Dim lsSQL As String

        lsSQL = "SELECT sBnkActID FROM Bank_Account WHERE sActNumbr = " & strParm(sActNumbr)

        lors = New DataTable
        lors = p_oAppDriver.ExecuteQuery(lsSQL)

        If lors.Rows.Count = 0 Then Return String.Empty
        Return lors.Rows(0).Item("sBnkActID")
    End Function
End Class