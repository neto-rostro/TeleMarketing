Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmVotingDetails
    Private p_oReport As New ReportDocument
    Private p_oDTSrce As DataTable

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim lsSQL As String
        lsSQL = "SELECT * FROM Client_Master LIMIT 500"
              
        p_oDTSrce = p_oAppDriver.ExecuteQuery(lsSQL)
        MsgBox(p_oDTSrce.Rows.Count)
        'p_oReport.SetDataSource(p_oDTSrce)

        'p_oReport.Load("C:\sample" & ".rpt")

        'CrystalReportViewer1.ReportSource = p_oReport
        'CrystalReportViewer1.Show()
    End Sub
End Class