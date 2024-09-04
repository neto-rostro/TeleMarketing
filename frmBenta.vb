Imports ggcAppDriver
Imports ggcMCSales

Public Class frmBenta
    Private WithEvents oTrans As Benta

    Private Sub cmdButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim loBtn As Button
        loBtn = CType(sender, System.Windows.Forms.Button)

        Dim lnIndex As Integer
        lnIndex = Val(Mid(loBtn.Name, 10))

        With oTrans
            Select Case lnIndex
                Case 0 'pick
                    If .PickTransaction("") Then
                        clearFields()
                        loadMaster()
                        initButton()
                    Else
                        clearFields()
                        initButton()
                    End If
                Case 1 'save
                    Dim loForm As frmSaveBenta
                    loForm = New frmSaveBenta

                    loForm.ShowDialog()

                    If (loForm.Cancelled) Then Exit Sub

                    Dim lsStat As String = CStr(loForm.Status)

                    If .SaveTransaction(lsStat) Then
                        MsgBox("Transacton saved successfully.", vbInformation, "Success")
                        oTrans = New Benta(p_oAppDriver)
                        clearFields()
                        initButton()
                    End If
                Case 2 'close
                    Me.Close()
                Case 3 'cancel
                    oTrans = New Benta(p_oAppDriver)
                    clearFields()
                    initButton()
                Case 4 'history
                    If .SearchTransaction("",, p_oAppDriver.UserID) Then
                        clearFields()
                        loadMaster()
                        initButton()
                    Else
                        clearFields()
                        initButton()
                    End If
            End Select
        End With
    End Sub

    Private Sub frmBenta_Load(sender As Object, e As EventArgs) Handles Me.Load
        oTrans = New Benta(p_oAppDriver)

        Call grpEventHandler(Me, GetType(Button), "cmdButton", "Click", AddressOf cmdButton_Click)
        Call grpKeyHandler(Me, GetType(TextBox), "txtField", "KeyDown", AddressOf txtField_KeyDown)
        Call grpEventHandler(Me, GetType(TextBox), "txtField", "GotFocus", AddressOf txtField_GotFocus)
        Call grpEventHandler(Me, GetType(TextBox), "txtField", "LostFocus", AddressOf txtField_LostFocus)
        Call grpCancelHandler(Me, GetType(TextBox), "txtField", "Validating", AddressOf txtField_Validating)
        Call grpEventHandler(Me, GetType(TextBox), "txtFincr", "GotFocus", AddressOf txtFincr_GotFocus)
        Call grpEventHandler(Me, GetType(TextBox), "txtFincr", "LostFocus", AddressOf txtFincr_LostFocus)
        Call grpCancelHandler(Me, GetType(TextBox), "txtFincr", "Validating", AddressOf txtFincr_Validating)
        Call grpEventHandler(Me, GetType(TextBox), "txtPaymn", "GotFocus", AddressOf txtPaymn_GotFocus)
        Call grpEventHandler(Me, GetType(TextBox), "txtPaymn", "LostFocus", AddressOf txtPaymn_LostFocus)
        Call grpCancelHandler(Me, GetType(TextBox), "txtPaymn", "Validating", AddressOf txtPaymn_Validating)
        Call grpKeyHandler(Me, GetType(TextBox), "txtPrdct", "KeyDown", AddressOf txtPrdct_KeyDown)
        Call grpEventHandler(Me, GetType(TextBox), "txtPrdct", "GotFocus", AddressOf txtPrdct_GotFocus)
        Call grpEventHandler(Me, GetType(TextBox), "txtPrdct", "LostFocus", AddressOf txtPrdct_LostFocus)

        initButton()
        clearFields()
    End Sub

    Private Sub loadMaster()
        With oTrans
            txtField00.Text = .Master("sClientID")
            txtField01.Text = .Personal_Info("sLastName")
            txtField02.Text = .Personal_Info("sFrstName")
            txtField03.Text = .Personal_Info("sMiddName")
            txtField04.Text = .Personal_Info("sSuffixNm")
            txtField05.Text = .Personal_Info("sMaidenNm")
            ComboBox2.SelectedIndex = CInt(.Personal_Info("cGenderCd"))

            If (Not IsDate(.Personal_Info("dBirthDte"))) Then
                txtField07.Text = ""
            Else
                txtField07.Text = Format(CDate(.Personal_Info("dBirthDte")), "MMM dd, yyyy")
            End If

            txtField08.Text = .Personal_Info("sBirthPlc")
            txtField09.Text = .Personal_Info("sHouseNox")
            txtField10.Text = .Personal_Info("sAddressx")
            txtField11.Text = .Personal_Info("sTownIDxx")
            txtField12.Text = .Personal_Info("sMobileNo")
            txtField13.Text = .Personal_Info("sEmailAdd")

            If .Master("cGanadoTp") <> "0" Then
                txtPrdct00.Text = .Product_Info("sBrandIDx")
                txtPrdct01.Text = .Product_Info("sModelIDx")
                txtPrdct02.Text = .Product_Info("sColorIDx")
                txtPrdct07.Text = .Product_Info("nSelPrice")
            Else
                txtPrdct00.Text = ""
                txtPrdct01.Text = ""
                txtPrdct02.Text = ""
                txtPrdct03.Text = ""
                txtPrdct04.Text = ""
                txtPrdct05.Text = ""
                txtPrdct06.Text = ""
                txtPrdct07.Text = ""
            End If

            txtFincr01.Text = .Financer_Info("sLastName")
            txtFincr02.Text = .Financer_Info("sFrstName")
            txtFincr03.Text = .Financer_Info("sMiddName")
            txtFincr04.Text = .Financer_Info("sSuffixNm")
            txtFincr05.Text = .Financer_Info("sAddressx")
            txtFincr06.Text = .Financer_Info("sCntryCde")
            txtFincr07.Text = .Financer_Info("sMobileNo")
            txtFincr08.Text = .Financer_Info("sWhatsApp")
            txtFincr09.Text = .Financer_Info("sWChatApp")
            txtFincr10.Text = .Financer_Info("sFbAccntx")
            txtFincr11.Text = .Financer_Info("sEmailAdd")
            txtFincr12.Text = .Financer_Info("sFIncomex")
            txtFincr13.Text = .Financer_Info("sReltionx")

            txtPaymn00.Text = Format(CDate(.Master("dTargetxx")), "MMM dd, yyyy")

            If .Master("cPaymForm") = "1" Then
                Select Case CInt(.Payment_Info("sTermIDxx"))
                    Case 12
                        ComboBox3.SelectedIndex = 0
                    Case 24
                        ComboBox3.SelectedIndex = 1
                    Case 36
                        ComboBox3.SelectedIndex = 2
                End Select
                ComboBox1.SelectedIndex = 1
                txtPaymn03.Text = .Payment_Info("nDownPaym")

                Label18.Visible = True
                Label19.Visible = True
                ComboBox3.Visible = True
                txtPaymn03.Visible = True
            Else
                ComboBox1.SelectedIndex = 0

                Label18.Visible = False
                Label19.Visible = False
                ComboBox3.Visible = False
                txtPaymn03.Visible = False
            End If

            txtRefer00.Text = IFNull(.Master("xReferNme"), "")
            txtRefer01.Text = Format(.Master("dCreatedx"), "MMM dd, yyyy HH:mm:ss")
            txtRefer02.Text = .Master("sRelatnID")
            txtRefer03.Text = IFNull(.Master("sRemarksx"), "")
            txtRefer04.Text = IFNull(.Master("nLatitude"), "-")
            txtRefer05.Text = IFNull(.Master("nLongitud"), "-")
            txtRefer06.Text = IFNull(.Master("sMobileNo"), "-")
            txtRefer07.Text = IFNull(.Master("sEmailAdd"), "-")

            lblSource.Text = .Master("cSourcexx")
            lblStatus.Text = .Master("cTranStat")
            lblType.Text = .Master("cGanadoTp")

            'additional product information displaying for automobile inquiry
            Label15.Visible = .Master("cGanadoTp") = "0"
            Label44.Visible = .Master("cGanadoTp") = "0"
            Label45.Visible = .Master("cGanadoTp") = "0"
            txtPrdct04.Visible = .Master("cGanadoTp") = "0"
            txtPrdct05.Visible = .Master("cGanadoTp") = "0"
            txtPrdct06.Visible = .Master("cGanadoTp") = "0"

            txtPrdct03.ReadOnly = .Master("cGanadoTp") <> "0"

            If .Master("cSourcexx") = "2" Then
                lblCall.Text = "Please contact " + .Financer_Info("sFrstName") + " " + .Financer_Info("sLastName") + " on his given contact info to verify the transaction."
            Else
                lblCall.Text = "Please contact " + .Personal_Info("sFrstName") + " " + .Personal_Info("sLastName") + " on his given contact info to verify the transaction."
            End If
        End With
    End Sub

    Private Sub clearFields()
        lblSource.Text = "-"
        lblStatus.Text = "-"
        lblType.Text = "-"
        lblCall.Text = ""

        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1

        txtField00.Text = ""
        txtField01.Text = ""
        txtField02.Text = ""
        txtField03.Text = ""
        txtField04.Text = ""
        txtField05.Text = ""
        txtField07.Text = ""
        txtField08.Text = ""
        txtField09.Text = ""
        txtField10.Text = ""
        txtField11.Text = ""
        txtField12.Text = ""
        txtField13.Text = ""

        txtRefer01.Text = ""
        txtRefer02.Text = ""
        txtRefer03.Text = ""
        txtRefer04.Text = ""
        txtRefer05.Text = ""
        txtRefer06.Text = ""
        txtRefer07.Text = ""

        txtPrdct00.Text = ""
        txtPrdct01.Text = ""
        txtPrdct02.Text = ""
        txtPrdct03.Text = ""
        txtPrdct04.Text = ""
        txtPrdct05.Text = ""
        txtPrdct06.Text = ""

        txtPaymn00.Text = ""
        txtPaymn03.Text = ""

        txtFincr01.Text = ""
        txtFincr02.Text = ""
        txtFincr03.Text = ""
        txtFincr04.Text = ""
        txtFincr05.Text = ""
        txtFincr06.Text = ""
        txtFincr07.Text = ""
        txtFincr08.Text = ""
        txtFincr09.Text = ""
        txtFincr10.Text = ""
        txtFincr11.Text = ""
        txtFincr12.Text = ""
        txtFincr13.Text = ""

        'additional product information displaying for automobile inquiry
        Label15.Visible = True
        Label44.Visible = True
        Label45.Visible = True
        txtPrdct04.Visible = True
        txtPrdct05.Visible = True
        txtPrdct06.Visible = True

        txtPrdct03.ReadOnly = False
    End Sub

    Private Sub initButton()
        Dim lbShow = oTrans.EditMode = xeEditMode.MODE_UPDATE

        cmdButton00.Visible = Not lbShow
        cmdButton01.Visible = lbShow
        cmdButton02.Visible = Not lbShow
        cmdButton03.Visible = lbShow
        cmdButton04.Visible = Not lbShow

        GroupBox3.Enabled = lbShow
        GroupBox4.Enabled = lbShow
        GroupBox5.Enabled = lbShow
        GroupBox6.Enabled = lbShow
        GroupBox7.Enabled = lbShow
    End Sub

    Private Sub txtField_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        loTxt.Text = Trim(loTxt.Text)

        With oTrans
            Select Case loIndex
                Case 1
                    .Personal_Info("sLastName") = loTxt.Text
                Case 2
                    .Personal_Info("sFrstName") = loTxt.Text
                Case 3
                    .Personal_Info("sMiddName") = loTxt.Text
                Case 4
                    .Personal_Info("sSuffixNm") = loTxt.Text
                Case 5
                    .Personal_Info("sMaidenNm") = loTxt.Text
                Case 7
                    If Not (IsDate(loTxt.Text)) Then
                        MsgBox("Please input a valid date.", vbInformation, "Notice")
                        .Personal_Info("dBirthDte") = .Personal_Info("dBirthDte")
                        Exit Sub
                    End If

                    .Personal_Info("dBirthDte") = CDate(loTxt.Text)
                Case 8
                    '.Personal_Info("sBirthPlc") = loTxt.Text
                Case 9
                    .Personal_Info("sHouseNox") = loTxt.Text
                Case 10
                    .Personal_Info("sAddressx") = loTxt.Text
                Case 11
                    '.Personal_Info("sTownIDxx") = loTxt.Text
                Case 12
                    If Not IsNumeric(loTxt.Text) Then
                        MsgBox("Please input a valid mobile no.", vbInformation, "Notice")
                        .Personal_Info("sMobileNo") = .Personal_Info("sMobileNo")
                        Exit Sub
                    End If

                    .Personal_Info("sMobileNo") = loTxt.Text
                Case 13
                    .Personal_Info("sEmailAdd") = loTxt.Text
            End Select
        End With
    End Sub

    Private Sub txtField_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F3 Or e.KeyCode = Keys.Enter Then
            Dim loTxt As TextBox
            loTxt = CType(sender, System.Windows.Forms.TextBox)

            Dim loIndex As Integer
            loIndex = Val(Mid(loTxt.Name, 9))

            Dim lasValue() As String

            If loIndex = 8 Then
                lasValue = Split(loTxt.Text, ",")
                oTrans.Personal_Info("sBirthPlc") = lasValue(0)
            ElseIf loIndex = 11 Then
                lasValue = Split(loTxt.Text, ",")
                oTrans.Personal_Info("sTownIDxx") = lasValue(0)
            End If
        End If
    End Sub

    Private Sub txtField_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        If (loIndex = 7) Then
            loTxt.Text = Format(CDate(oTrans.Personal_Info("dBirthDte")), "MM/dd/yyyy")
        End If

        loTxt.BackColor = Color.Azure
        loTxt.SelectAll()
    End Sub

    Private Sub txtField_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)
        loTxt.BackColor = SystemColors.Window
    End Sub

    Private Sub txtFincr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        With oTrans
            Select Case loIndex
                Case 1
                    .Financer_Info("sLastName") = loTxt.Text
                Case 2
                    .Financer_Info("sFrstName") = loTxt.Text
                Case 3
                    .Financer_Info("sMiddName") = loTxt.Text
                Case 4
                    .Financer_Info("sSuffixNm") = loTxt.Text
                Case 5
                    .Financer_Info("sAddressx") = loTxt.Text
                Case 6
                    .Financer_Info("sCntryCde") = loTxt.Text
                Case 7
                    If Not IsNumeric(loTxt.Text) Then
                        MsgBox("Please input a valid mobile no.", vbInformation, "Notice")
                        .Financer_Info("sMobileNo") = .Financer_Info("sMobileNo")
                        Exit Sub
                    End If

                    .Financer_Info("sMobileNo") = loTxt.Text
                Case 8
                    .Financer_Info("sWhatsApp") = loTxt.Text
                Case 9
                    .Financer_Info("sWChatApp") = loTxt.Text
                Case 10
                    .Financer_Info("sFbAccntx") = loTxt.Text
                Case 11
                    .Financer_Info("sEmailAdd") = loTxt.Text
                Case 12
                    If Not IsNumeric(loTxt.Text) Then
                        MsgBox("Please input numeric income value.", vbInformation, "Notice")
                        .Financer_Info("sFIncomex") = .Financer_Info("sFIncomex")
                        Exit Sub
                    End If

                    .Financer_Info("sFIncomex") = loTxt.Text
                Case 13
                    .Financer_Info("sReltionx") = loTxt.Text
            End Select
        End With
    End Sub

    Private Sub txtFincr_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        loTxt.BackColor = Color.Azure
        loTxt.SelectAll()
    End Sub

    Private Sub txtFincr_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)
        loTxt.BackColor = SystemColors.Window
    End Sub


    Private Sub txtPaymn_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        With oTrans
            Select Case loIndex
                Case 3
                    If Not IsNumeric(loTxt.Text) Then
                        MsgBox("Please input numeric value.", vbInformation, "Notice")
                        .Payment_Info("nDownPaym") = .Payment_Info("nDownPaym")
                        Exit Sub
                    End If

                    .Payment_Info("nDownPaym") = loTxt.Text
            End Select
        End With
    End Sub

    Private Sub txtPaymn_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        loTxt.BackColor = Color.Azure
        loTxt.SelectAll()
    End Sub

    Private Sub txtPaymn_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)
        loTxt.BackColor = SystemColors.Window
    End Sub

    Private Sub txtPrdct_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F3 Or e.KeyCode = Keys.Enter Then
            Dim loTxt As TextBox
            loTxt = CType(sender, System.Windows.Forms.TextBox)

            Dim loIndex As Integer
            loIndex = Val(Mid(loTxt.Name, 9))

            If loIndex = 0 Then
                oTrans.Product_Info("sBrandIDx") = loTxt.Text
            ElseIf loIndex = 1 Then
                oTrans.Product_Info("sModelIDx") = loTxt.Text
            ElseIf loIndex = 2 Then
                oTrans.Product_Info("sColorIDx") = loTxt.Text
            End If
        End If
    End Sub

    Private Sub txtPrdct_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loTxt.Name, 9))

        loTxt.BackColor = Color.Azure
        loTxt.SelectAll()
    End Sub

    Private Sub txtPrdct_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim loTxt As TextBox
        loTxt = CType(sender, System.Windows.Forms.TextBox)
        loTxt.BackColor = SystemColors.Window
    End Sub

    Private Sub oTrans_PersonalRetreived(Index As Integer, Value As Object) Handles oTrans.PersonalRetreived
        Select Case Index
            Case 0
                txtField00.Text = Value
            Case 1
                txtField01.Text = Value
            Case 2
                txtField02.Text = Value
            Case 3
                txtField03.Text = Value
            Case 4
                txtField04.Text = Value
            Case 5
                txtField05.Text = Value
            Case 6
                ComboBox2.SelectedIndex = CInt(Value)
            Case 7
                If (Not IsDate(Value)) Then
                    txtField07.Text = ""
                Else
                    txtField07.Text = Format(CDate(Value), "MMM dd, yyyy")
                End If
            Case 8
                txtField08.Text = Value
            Case 9
                txtField09.Text = Value
            Case 10
                txtField10.Text = Value
            Case 11
                txtField11.Text = Value
            Case 12
                txtField12.Text = Value
            Case 13
                txtField13.Text = Value
        End Select
    End Sub

    Private Sub oTrans_ProductRetreived(Index As Integer, Value As Object) Handles oTrans.ProductRetreived
        Select Case Index
            Case 0
                txtPrdct00.Text = Value
            Case 1
                txtPrdct01.Text = Value
            Case 2
                txtPrdct02.Text = Value
            Case 3
                txtPrdct03.Text = Value
            Case 7
                txtPrdct07.Text = Value
        End Select
    End Sub

    Private Sub oTrans_FinancerRetreived(Index As Integer, Value As Object) Handles oTrans.FinancerRetreived
        Select Case Index
            Case 1
                txtFincr01.Text = Value
            Case 2
                txtFincr02.Text = Value
            Case 3
                txtFincr03.Text = Value
            Case 4
                txtFincr04.Text = Value
            Case 5
                txtFincr05.Text = Value
            Case 6
                txtFincr06.Text = Value
            Case 7
                txtFincr07.Text = Value
            Case 8
                txtFincr08.Text = Value
            Case 9
                txtFincr09.Text = Value
            Case 10
                txtFincr10.Text = Value
            Case 11
                txtFincr11.Text = Value
            Case 12
                txtFincr12.Text = Value
            Case 13
                txtFincr13.Text = Value
        End Select
    End Sub

    Private Sub oTrans_PaymentRetreived(Index As Integer, Value As Object) Handles oTrans.PaymentRetreived
        Select Case Index
            Case 1
                ComboBox1.SelectedIndex = CInt(Value)
                Label18.Visible = Value = "1"
                Label19.Visible = Value = "1"
                ComboBox3.Visible = Value = "1"
                txtPaymn03.Visible = Value = "1"
            Case 2
                Select Case CInt(Value)
                    Case 12
                        ComboBox3.SelectedIndex = 0
                    Case 24
                        ComboBox3.SelectedIndex = 1
                    Case 36
                        ComboBox3.SelectedIndex = 2
                End Select
            Case 3
                txtPaymn03.Text = Value
        End Select
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        oTrans.Master("cPaymForm") = ComboBox1.SelectedIndex
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        With ComboBox3
            Select Case .SelectedIndex
                Case 0 '12
                    oTrans.Payment_Info("sTermIDxx") = "12"
                Case 1 '24
                    oTrans.Payment_Info("sTermIDxx") = "24"
                Case 2 '36
                    oTrans.Payment_Info("sTermIDxx") = "36"
            End Select
        End With
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        oTrans.Personal_Info("cGenderCd") = ComboBox2.SelectedIndex
    End Sub

    Private Sub frmBenta_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Enter
                Select Case e.KeyCode
                    Case Keys.Down, Keys.Right, Keys.Enter
                        SetNextFocus()
                    Case Keys.Up, Keys.Left
                        SetPreviousFocus()
                End Select
        End Select
    End Sub
End Class