Imports Newtonsoft
Imports ggcAppDriver
Imports Newtonsoft.Json

Public Class frmGanadoEntry
    Dim psTransNox As String

    Public Property ReferNox() As String
        Get
            Return psTransNox
        End Get
        Set(value As String)
            psTransNox = value
        End Set
    End Property

    Private Sub frmGanadoEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call initFields()
        Call loadMaster()
    End Sub
    Private Sub initFields()
        txtField01.Text = ""
        txtField02.Text = ""
        txtField03.Text = ""
        txtField04.Text = ""
        txtField05.Text = ""
        txtField06.Text = ""
        txtField07.Text = ""

        txtOthers01.Text = ""
        txtOthers02.Text = ""
        txtOthers03.Text = ""
        txtOthers04.Text = ""
        txtOthers05.Text = ""
        txtOthers06.Text = ""

        cmbOther01.SelectedIndex = 0
        cmbOther02.SelectedIndex = 0
    End Sub
    Private Sub loadMaster()
        Dim lsSQL As String
        Dim loDT As DataTable

        lsSQL = "SELECT" +
                    "  b.sClientID" +
                    ", b.sCompnyNm" +
                    ", CONCAT(b.sHouseNox, ' ', b.sAddressx, ', ', c.sTownName, ' ', c.sZippCode, ' ', d.sProvName) sAddressx" +
                    ", b.sEmailAdd" +
                    ", IFNULL(g.sCompnyNm, '-') xReferByx" +
                    ", IFNULL(h.sBranchNm, 'CUSTOMER') xBranchNm" +
                    ", a.sPrdctInf" +
                    ", a.sPaymInfo" +
                    ", a.cGanadoTp" +
                    ", a.cPaymForm" +
                " FROM Ganado_Online a" +
                        " LEFT JOIN App_User_Master e ON a.sReferdBy = e.sUserIDxx" +
                        " LEFT JOIN Employee_Master001 f ON e.sEmployNo = f.sEmployID" +
                        " LEFT JOIN Client_Master g ON f.sEmployID = g.sClientID" +
                        " LEFT JOIN Branch h ON f.sBranchCd = h.sBranchCd" +
                    ", Client_Master b" +
                        " LEFT JOIN TownCity c ON b.sTownIDxx = c.sTownIDxx" +
                        " LEFT JOIN Province d ON c.sProvIDxx = d.sProvIDxx" +
                " WHERE a.sClientID = b.sClientID" +
                    " AND a.sTransNox = " & strParm(psTransNox)

        loDT = p_oAppDriver.ExecuteQuery(lsSQL)

        If loDT.Rows.Count > 0 Then
            txtField01.Text = psTransNox
            txtField02.Text = loDT(0)("sClientID")
            txtField03.Text = loDT(0)("sCompnyNm")
            txtField04.Text = loDT(0)("sAddressx")
            txtField05.Text = loDT(0)("sEmailAdd")
            txtField06.Text = loDT(0)("xReferByx")
            txtField07.Text = loDT(0)("xBranchNm")

            cmbOther01.SelectedIndex = CInt(loDT(0)("cGanadoTp"))
            cmbOther02.SelectedIndex = CInt(loDT(0)("cPaymForm"))

            Dim product As Product = JsonConvert.DeserializeObject(Of Product)(loDT(0)("sPrdctInf"))
            Dim payment As Payment = JsonConvert.DeserializeObject(Of Payment)(loDT(0)("sPaymInfo"))

            lsSQL = "SELECT sBrandNme FROM Brand WHERE sBrandIDx = " & strParm(product.sBrandIDx)
            loDT = p_oAppDriver.ExecuteQuery(lsSQL)
            txtOthers01.Text = loDT(0)(0)

            lsSQL = "SELECT CONCAT(sModelCde, ' - ', sModelNme) sModelNme FROM MC_Model WHERE sModelIdx = " & strParm(product.sModelIDx)
            loDT = p_oAppDriver.ExecuteQuery(lsSQL)
            txtOthers02.Text = loDT(0)(0)

            lsSQL = "SELECT sColorNme FROM Color WHERE sColorIDx = " & strParm(product.sColorIDx)
            loDT = p_oAppDriver.ExecuteQuery(lsSQL)
            txtOthers03.Text = loDT(0)(0)

            If cmbOther02.SelectedIndex = 0 Then
                'cash
                txtOthers04.Text = payment.nSelPrice
                txtOthers04.Visible = True
                Label15.Visible = True

                txtOthers05.Visible = False
                txtOthers06.Visible = False
                Label13.Visible = False
                Label14.Visible = False
            Else
                'installment
                txtOthers05.Text = payment.sTermIDxx
                txtOthers06.Text = payment.nDownPaym
                txtOthers04.Visible = False
                Label15.Visible = False

                txtOthers05.Visible = True
                txtOthers06.Visible = True
                Label13.Visible = True
                Label14.Visible = True
            End If
        End If
    End Sub
End Class

Public Class Product
    Public Property sBrandIDx As String
    Public Property sModelIDx As String
    Public Property sColorIDx As String
End Class

Public Class Payment
    Public Property sTermIDxx As String
    Public Property nDownPaym As String
    Public Property nSelPrice As String
    Public Property dPricedxx As String
End Class