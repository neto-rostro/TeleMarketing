Imports ggcAppDriver
Imports System.Globalization
Imports System.IO

Public Class mdiMain
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub mdiMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p_oAppDriver.MDI = Me

        tslUser.Text = Decrypt(p_oAppDriver.UserName, p_oAppDriver.Signature)
        tslDate.Text = Format(p_oAppDriver.SysDate, "MMMM dd, yyyy")
    End Sub

    Private Sub MCInquiryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCInquiryToolStripMenuItem.Click
        With frmMCInquiry
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Public Function isFormOpen(ByVal lsForm As String) As Boolean

        For Each frm As Form In Me.MdiChildren
            If frm.Name = lsForm Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub ProductSpecsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductSpecsToolStripMenuItem.Click
        With frmProductSpecs
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub ProductCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductCategoryToolStripMenuItem.Click
        With frmProductCategory
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub ProductFeaturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductFeaturesToolStripMenuItem.Click
        With frmProductFeatures
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub DepartmentMobileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartmentMobileToolStripMenuItem.Click
        With frmDeptMobile
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub DepartmentEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartmentEmailToolStripMenuItem.Click
        With frmDeptEmail
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub BranchMobileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BranchMobileToolStripMenuItem.Click
        With frmBranchMobile
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub BranchEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BranchEmailToolStripMenuItem.Click
        With frmBranchEmail
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub MCInquiryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCInquiryToolStripMenuItem1.Click
        With frmMCInquiryReg
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub MCReferralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCReferralToolStripMenuItem.Click
        With frmMCReferral
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub MCReferralToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCReferralToolStripMenuItem1.Click
        With frmMCReferralReg
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub OutboundCallToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutboundCallToolStripMenuItem.Click
        With frmCallManager
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub MCModelSpecsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCModelSpecsToolStripMenuItem.Click
        With frmMCModelSpecs
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub MCModelFeaturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCModelFeaturesToolStripMenuItem.Click
        With frmMCModelFeatures
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub CashToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashToolStripMenuItem.Click
        With frmMCCashPrice
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub InstallmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallmentToolStripMenuItem.Click
        With frmMCInsPrice
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub InstallmentCalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallmentCalculatorToolStripMenuItem.Click
        With frmMCInsCalc
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub OutboundCallsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutboundCallsToolStripMenuItem.Click
        Dim loRpt As ggcTeleMarketingReports.clsCallReport
        loRpt = New ggcTeleMarketingReports.clsCallReport(p_oAppDriver)

        If loRpt.getParameter() Then
            Call loRpt.ReportTrans()
        End If
    End Sub

    Private Sub ATMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With frmTextMarketing
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub MessageCastToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageCastToolStripMenuItem.Click
        With frmTextMarketingReg
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub MPModelFeaturesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MPModelFeaturesToolStripMenuItem.Click
        'With frmMPModelFeatures
        '    If isFormOpen(.Name) Then Exit Sub

        '    .MdiParent = Me

        '    .Show()
        '    .Refresh()
        'End With
    End Sub

    Private Sub MPModelSpecsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MPModelSpecsToolStripMenuItem.Click
        'With frmMPModelSpecs
        '    If isFormOpen(.Name) Then Exit Sub

        '    .MdiParent = Me

        '    .Show()
        '    .Refresh()
        'End With
    End Sub

    Private Sub GetMobileNetworkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetMobileNetworkToolStripMenuItem.Click
        Dim lsValue As String = Trim(InputBox("Please encode mobile number." & vbCrLf & vbCrLf & _
                                                "Format: 09XXXXXXXXX", "Mobile Prefix Network Inquiry"))

        If lsValue <> "" Then
            lsValue = "https://restgk.guanzongroup.com.ph/telemarketing/getNetwork.php?mobile=" & lsValue

            lsValue = Trim(httpsGET(lsValue))

            Select Case lsValue
                Case "0"
                    lsValue = "Guanzon system classified this mobile number as GLOBE." & vbCrLf & vbCrLf & _
                                "For any concern, please inform MIS Department. Thank you."
                Case "1"
                    lsValue = "Guanzon system classified this mobile number as SMART." & vbCrLf & vbCrLf & _
                                "For any concern, please inform MIS Department. Thank you."
                Case "2"
                    lsValue = "Guanzon system classified this mobile number as SUN." & vbCrLf & vbCrLf & _
                                "For any concern, please inform MIS Department. Thank you."
                Case Else
                    lsValue = "The network if this mobile number is not registered." & vbCrLf & vbCrLf & _
                                "Please inform MIS Department. Thank you."
            End Select

            MsgBox(lsValue, MsgBoxStyle.Information, "Mobile Prefix Network Inquiry")
        End If
    End Sub

    Private Function httpsGET(ByVal fsURL As String) As String
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(New System.Uri(fsURL))

        request.Method = System.Net.WebRequestMethods.Http.Get

        Dim response As System.Net.HttpWebResponse = request.GetResponse()

        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As StreamReader = New StreamReader(dataStream)
        Dim lsValue As String = reader.ReadToEnd()
        reader.Close()
        response.Close()

        Return lsValue
    End Function

    Private Sub WhoIsThisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WhoIsThisToolStripMenuItem.Click
        MsgBox(p_oAppDriver.UserID, , "Who's this!")
    End Sub

    Private Sub ClassifyClientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClassifyClientToolStripMenuItem.Click
        With frmClassify
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub


    Private Sub MCEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCEntryToolStripMenuItem.Click
        With frmOGCallCustInfo
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub MCHistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCHistoryToolStripMenuItem.Click
        With frmOGCallCustInfoReg
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub LeadsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeadsToolStripMenuItem.Click
        Dim loRpt As ggcTeleMarketingReports.clsCallStatusReport
        loRpt = New ggcTeleMarketingReports.clsCallStatusReport(p_oAppDriver)

        If loRpt.getParameter() Then
            Call loRpt.ReportTrans()
        End If
    End Sub

    Private Sub MCSalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MCSalesToolStripMenuItem.Click
        Dim loRpt As ggcTeleMarketingReports.clstlmMCSalesReport
        loRpt = New ggcTeleMarketingReports.clstlmMCSalesReport(p_oAppDriver)

        If loRpt.getParameter() Then
            Call loRpt.ReportTrans()
        End If
    End Sub

    Private Sub OutBoundCallToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutBoundCallToolStripMenuItem1.Click
        With frmCallManagerReg
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub BentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BentaToolStripMenuItem.Click
        With frmBenta
            If isFormOpen(.Name) Then Exit Sub

            .MdiParent = Me

            .Show()
            .Refresh()
        End With
    End Sub

    Private Sub BranchInquiryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BranchInquiryToolStripMenuItem.Click
        Dim loRpt As ggcTeleMarketingReports.clsBranchInquiry
        loRpt = New ggcTeleMarketingReports.clsBranchInquiry(p_oAppDriver)

        If loRpt.getParameter() Then
            Call loRpt.ReportTrans()
        End If
    End Sub
End Class
