
'€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€
' Guanzon Software Engineering Group
' Guanzon Group of Companies
' Perez Blvd., Dagupan City
'
'     MC AR Master Object
'
' Copyright 2012 and Beyond
' All Rights Reserved
' ºººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººº
' €  All  rights reserved. No part of this  software  €€  This Software is Owned by        €
' €  may be reproduced or transmitted in any form or  €€                                   €
' €  by   any   means,  electronic   or  mechanical,  €€    GUANZON MERCHANDISING CORP.    €
' €  including recording, or by information  storage  €€     Guanzon Bldg. Perez Blvd.     €
' €  and  retrieval  systems, without  prior written  €€           Dagupan City            €
' €  from the author.                                 €€  Tel No. 522-1085 ; 522-9275      €
' ºººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººº
'
' ==========================================================================================
'  Kalyptus [ 06/04/2016 11:25 am ]
'      Started creating this object.
'€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€
Imports MySql.Data.MySqlClient
Imports ADODB
Imports ggcAppDriver

Public Class TLMSalesMC
    Private p_oApp As GRider
    Private p_oDTMstr As DataTable
    Private p_nEditMode As xeEditMode
    Private p_oOthersx As New Others
    Private p_oCallInfosx As New OGCallInfo
    Private p_nTranStat As Int32  'Transaction Status of the transaction to retrieve
    Private p_sBranchCD As String

    Private Const p_sMasTable As String = "TLM_Sales"
    Private Const p_sMsgHeadr As String = "TLM Sales"

    Public Event MasterRetrieved(ByVal Index As Integer, _
                                  ByVal Value As Object)

    Public ReadOnly Property AppDriver() As ggcAppDriver.GRider
        Get
            Return p_oApp
        End Get
    End Property

    Public Property Branch As String
        Get
            Return p_sBranchCD
        End Get
        Set(ByVal value As String)
            'If Product ID is LR then do allow changing of Branch
            If p_oApp.ProductID = "TeleMktg" Then
                p_sBranchCD = value
            End If
        End Set
    End Property

    Public Property Master(ByVal Index As Integer) As Object
        Get
            If p_nEditMode <> xeEditMode.MODE_UNKNOWN Then
                Select Case Index

                    Case 2 ' sClientNm
                        If Trim(IFNull(p_oDTMstr(0).Item(2))) <> "" And Trim(p_oCallInfosx.xClientNmeCallInfo) = "" Then
                            getClients(2, 2, p_oDTMstr(0).Item(2), True, False)
                        End If
                        Return p_oCallInfosx.xClientNmeCallInfo
                    Case 3 ' sMobileNo
                        Return p_oDTMstr(0).Item(2)
                    Case 4 ' dCallStrt
                        Return p_oCallInfosx.dCallStrt
                    Case 5 ' sSourceCd
                        Return p_oCallInfosx.sRemarks
                    Case 6 ' status
                        Return p_oCallInfosx.cTranStat
                    Case 8 ' dEntryDte
                        Return p_oDTMstr(0).Item(Index)
                    Case 80 ' sBranchNm
                        If Trim(p_oOthersx.sBranchNm) = "" Then
                            getBranch(7, 7, p_oDTMstr(0).Item(7), True, False)
                        End If
                        Return p_oOthersx.sBranchNm
                    Case 81 ' sClientNmSI
                        If Trim(Trim(p_oOthersx.sBranchNm)) = "" Then
                            getSalesInformation(8, 8, p_oDTMstr(0).Item(8), True, False)
                        End If
                        Return p_oOthersx.sClientNm
                    Case 82 ' sAddressx
                        Return p_oOthersx.sAddressx
                    Case 83 ' sAddressx
                        Return p_oOthersx.sMobileNo
                    Case 84 ' sAddressx
                        Return p_oOthersx.sDRNoxxxx
                    Case 85 ' sAddressx
                        Return p_oOthersx.sModelNme
                    Case 86 ' sAddressx
                        Return p_oOthersx.sEngineNo
                    Case 87 ' sAddressx
                        Return p_oOthersx.sFrameNox
                    Case Else
                        Return p_oDTMstr(0).Item(Index)
                End Select
            Else
                Return vbEmpty
            End If
        End Get

        Set(ByVal value As Object)
            If p_nEditMode <> xeEditMode.MODE_UNKNOWN Then
                Select Case Index
                    Case 8
                        If IsDate(value) Then
                            p_oDTMstr(0).Item(Index) = Format(CDate(value), "yyyy-MM-dd")

                        End If

                        RaiseEvent MasterRetrieved(Index, p_oDTMstr(0).Item(Index))

                        p_oDTMstr(0).Item(Index) = value
                End Select
            End If
        End Set
    End Property

    'Property Master(String)
    Public Property Master(ByVal Index As String) As Object
        Get
            If p_nEditMode <> xeEditMode.MODE_UNKNOWN Then
                Select Case LCase(Index)
                    Case "sclientid" ' 2 
                        If Trim(IFNull(p_oDTMstr(0).Item(2))) <> "" And Trim(p_oCallInfosx.xClientNmeCallInfo) = "" Then
                            getClients(2, 2, p_oDTMstr(0).Item(2), True, False)
                        End If
                        Return p_oCallInfosx.xClientNmeCallInfo

                        Return p_oDTMstr(0).Item(Index)
                    Case "sbranchnm" ' 86
                        If Trim(p_oOthersx.sBranchNm) = "" Then
                            getBranch(7, 7, p_oDTMstr(0).Item(7), True, False)
                        End If
                        Return p_oOthersx.sBranchNm
                    Case "sagentnme"
                        Return p_oCallInfosx.sAgentNme
                    Case Else
                        Return p_oDTMstr(0).Item(Index)
                End Select
            Else
                Return vbEmpty
            End If
        End Get
        Set(ByVal value As Object)
            If p_nEditMode <> xeEditMode.MODE_UNKNOWN Then
                Select Case LCase(Index)
                    Case "dentrydte" '8
                        If IsDate(value) Then
                            value = CDate(value)
                            p_oDTMstr(0).Item(Index) = value
                        End If

                        RaiseEvent MasterRetrieved(Index, p_oDTMstr(0).Item(Index))
                End Select
            End If
        End Set
    End Property

    'Property EditMode()
    Public ReadOnly Property EditMode() As xeEditMode
        Get
            Return p_nEditMode
        End Get
    End Property

    'Public Function NewTransaction()
    Public Function NewTransaction() As Boolean
        Dim lsSQL As String

        lsSQL = AddCondition(getSQ_Master, "0=1")
        p_oDTMstr = p_oApp.ExecuteQuery(lsSQL)
        p_oDTMstr.Rows.Add(p_oDTMstr.NewRow())
        Call initMaster()
        Call InitOthers()
        Call InitOGCallInfo()

        p_nEditMode = xeEditMode.MODE_ADDNEW

        Return True
    End Function

    'Public Function OpenTransaction(String)
    Public Function OpenTransaction(ByVal fsTransNox As String) As Boolean
        Dim lsSQL As String

        lsSQL = AddCondition(getSQ_Master, "a.sTransNox = " & strParm(fsTransNox))

        p_oDTMstr = p_oApp.ExecuteQuery(lsSQL)
        Debug.Print(lsSQL)
        If p_oDTMstr.Rows.Count <= 0 Then
            p_nEditMode = xeEditMode.MODE_UNKNOWN
            Return False
        End If

        OpenOGCallInfo(p_oDTMstr(0).Item("sSourceNo"))
        OpenSalesInformation(p_oDTMstr(0).Item("sReferNox"))
        p_nEditMode = xeEditMode.MODE_READY
        Return True
    End Function

    'Public Function OpenOGCallInfo(String)
    Private Function OpenOGCallInfo(ByVal fsTransNox As String) As Boolean
        Dim lsSQL As String


        If p_oDTMstr(0).Item("sTransNox") = "" Then GoTo endWithWarning

        lsSQL = "SELECT" &
                    "  b.sTransNox" &
                    ", b.dTransact" &
                    ", a.sClientID" &
                    ", b.sMobileNo" &
                    ", a.sCompnyNm" &
                    ", b.sAgentIDx" &
                    ", IFNULL(b.dCallStrt, '')  dCallStrt " &
                    ", IFNULL(b.dCallEndx, '')  dCallEndx " &
                    ", b.sRemarksx" &
                    ", b.sSourceCd" &
                    ", b.cTranStat" &
                    ", a.sLastName" &
                    ", a.sFrstName" &
                    ", a.sMiddName" &
                    ", a.sSuffixNm" &
                    ", IFNULL(d.sCompnyNm, '') sAgentNme" &
                " FROM Call_Outgoing b" &
                    " LEFT JOIN Client_Master a ON a.sClientID = b.sClientID" &
                    " LEFT JOIN xxxSysUser c ON b.sAgentIDx = c.sUserIDxx" &
                    " LEFT JOIN Client_Master d ON d.sClientID = c.sEmployNo"

        Dim loData As DataTable
        lsSQL = AddCondition(lsSQL, "b.sTransNox = " & strParm(fsTransNox))
        loData = (p_oApp.ExecuteQuery(lsSQL))

        Debug.Print(lsSQL)

        If IsNothing(loData) Then
            p_nEditMode = xeEditMode.MODE_UNKNOWN
            GoTo endWithWarning
            Return False
        Else


            p_oCallInfosx.xClientNmeCallInfo = loData(0).Item("sLastName") & ", " & _
                                   loData(0).Item("sFrstName") & _
                                           IIf(loData(0).Item("sSuffixNm") = "", "", " " & loData(0).Item("sSuffixNm")) & " " & _
                                           loData(0).Item("sMiddName")
            p_oDTMstr(0).Item("sEntryByx") = IFNull((loData(0).Item("sAgentIDx")), "")
            p_oDTMstr(0).Item("sSourceNo") = IFNull(loData(0).Item("sTransNox"), "")
            p_oDTMstr(0).Item("sMobileNo") = IFNull(loData(0).Item("sMobileNo"), "")
            p_oCallInfosx.dCallStrt = loData(0).Item("dCallStrt")
            p_oCallInfosx.sRemarks = IFNull(loData(0).Item("sRemarksx"), "")
            p_oCallInfosx.cTranStat = IFNull(loData(0).Item("cTranStat"), "")
            p_oCallInfosx.sAgentNme = loData(0).Item("sAgentNme")
        End If

        RaiseEvent MasterRetrieved(2, p_oCallInfosx.xClientNmeCallInfo)
        RaiseEvent MasterRetrieved(3, p_oDTMstr(0).Item("sMobileNo"))
        RaiseEvent MasterRetrieved(4, p_oCallInfosx.dCallStrt)
        RaiseEvent MasterRetrieved(5, p_oCallInfosx.sRemarks)
        RaiseEvent MasterRetrieved(6, p_oCallInfosx.cTranStat)
        RaiseEvent MasterRetrieved(7, p_oCallInfosx.sAgentNme)

        p_nEditMode = xeEditMode.MODE_READY

        Return True
endWithWarning:
        MsgBox("No Leads Found for this Transaction!" & _
                 vbCrLf & " Can Not Process Transaction", vbCritical, "Warning")
        GoTo endProc
endProc:
        loData = Nothing
        Exit Function
    End Function

    'Public Function OpenSalesInformationString)
    Private Function OpenSalesInformation(ByVal fsTransNox As String) As Boolean
        Dim lsSQL As String

        If p_oDTMstr(0).Item("sTransNox") = "" Then GoTo endWithWarning

        lsSQL = "SELECT" &
                        " a.sTransNox " &
                        " , a.sClientID " &
                        " , a.sDRNoxxxx " &
                        " , b.sSerialID " &
                        " , e.sModelNme " &
                        " , d.sEngineNo " &
                        " , d.sFrameNox " &
                        " , c.sCompnyNm " &
                        " , c.sLastName " &
                        " , c.sFrstName " &
                        " , c.sMiddName " &
                        " , c.sSuffixNm " &
                        " , c.sAddressx " &
                        " , c.sMobileNo " &
                        " , f.sBrgyName " &
                        " , g.sTownName " &
                        " , h.sProvName " &
                        " , g.sZippCode " &
                        " , i.sBranchNm " &
                        " FROM MC_SO_Master a " &
                        " LEFT JOIN MC_SO_Detail b ON a.sTransNox = b.sTransNox " &
                        " LEFT JOIN Client_Master c ON c.sClientID = a.sClientID " &
                        " LEFT JOIN MC_Serial d ON  b.sSerialID = d.sSerialID " &
                        " LEFT JOIN MC_Model e ON d.sModelIDx = e.sModelIDx " &
                        " LEFT JOIN Barangay f ON c.sBrgyIDxx = f.sBrgyIDxx " &
                        " LEFT JOIN TownCity g ON f.sTownIDxx = g.sTownIDxx " &
                        " LEFT JOIN Province h ON g.sProvIDxx = h.sProvIDxx " &
                        " LEFT JOIN Branch i  ON  d.sBranchCd = i.sBranchCd "


        Dim loData As DataTable
        lsSQL = AddCondition(lsSQL, "a.sTransNox = " & strParm(fsTransNox))
        loData = (p_oApp.ExecuteQuery(lsSQL))
        Debug.Print(lsSQL)

        If IsNothing(loData) Then
            p_nEditMode = xeEditMode.MODE_UNKNOWN
            GoTo endWithWarning
            Return False
        Else

            p_oDTMstr(0).Item("sReferNox") = loData(0).Item("sTransNox")
            p_oOthersx.sClientNm = loData(0).Item("sLastName") & ", " &
                                   loData(0).Item("sFrstName") &
                                           IIf(loData(0).Item("sSuffixNm") = "", "", " " & loData(0).Item("sSuffixNm")) & " " &
                                           loData(0).Item("sMiddName")
            p_oOthersx.sAddressx = (loData(0).Item("sAddressx") & ", " &
                                   loData(0).Item("sBrgyName") &
                                           IFNull(loData(0).Item("sTownName"), "") & " " & loData(0).Item("sProvName")) & " " &
                                           loData(0).Item("sZippCode")
            p_oOthersx.sMobileNo = IFNull(loData(0).Item("sMobileNo"), "")
            p_oOthersx.sDRNoxxxx = IFNull(loData(0).Item("sDRNoxxxx"), "")
            p_oOthersx.sModelNme = IFNull(loData(0).Item("sModelNme"), "")
            p_oOthersx.sEngineNo = IFNull(loData(0).Item("sEngineNo"), "")
            p_oOthersx.sFrameNox = IFNull(loData(0).Item("sFrameNox"), "")
            p_oOthersx.sBranchNm = IFNull(loData(0).Item("sBranchNm"), "")

        End If
        RaiseEvent MasterRetrieved(80, p_oOthersx.sBranchNm)
        RaiseEvent MasterRetrieved(81, p_oOthersx.sClientNm)
        RaiseEvent MasterRetrieved(82, p_oOthersx.sAddressx)
        RaiseEvent MasterRetrieved(83, p_oOthersx.sMobileNo)
        RaiseEvent MasterRetrieved(84, p_oOthersx.sDRNoxxxx)
        RaiseEvent MasterRetrieved(85, p_oOthersx.sModelNme)
        RaiseEvent MasterRetrieved(86, p_oOthersx.sEngineNo)
        RaiseEvent MasterRetrieved(87, p_oOthersx.sFrameNox)
        Exit Function

        p_nEditMode = xeEditMode.MODE_READY
        Return True

endWithWarning:
        MsgBox("No Sales Information Found for this Transaction!" &
                 vbCrLf & " Can Not Process Transaction", vbCritical, "Warning")
        GoTo endProc
endProc:
        loData = Nothing
        Exit Function
    End Function


    'Public Function SearchTransaction(String, Boolean, Boolean=False)
    Public Function SearchTransaction(
                        ByVal fsValue As String _
                      , Optional ByVal fbByCode As Boolean = False) As Boolean

        Dim lsSQL As String

        'Check if already loaded base on edit mode
        If p_nEditMode = xeEditMode.MODE_READY Or p_nEditMode = xeEditMode.MODE_UPDATE Then
            If fbByCode Then
                If fsValue = p_oDTMstr(0).Item("sTransNox") Then Return True
            Else
                If fsValue = p_oCallInfosx.xClientNmeCallInfo Then Return True
            End If
        End If

        'Initialize SQL filter
        If p_nTranStat >= 0 Then
            lsSQL = AddCondition(getSQ_Browse, "a.cTranStat IN (" & strDissect(p_nTranStat) & ")")
        Else
            lsSQL = getSQ_Browse()
        End If

        'create Kwiksearch filter
        Dim lsFilter As String
        If fbByCode Then
            lsFilter = "a.sTransNox LIKE " & strParm("%" & fsValue)
        Else
            lsFilter = "b.sCompnyNm like " & strParm(fsValue & "%")
        End If

        Dim loDta As DataRow = KwikSearch(p_oApp _
                                        , lsSQL _
                                        , False _
                                        , lsFilter _
                                        , "sTransNox»sClientNm»dEntryDte" _
                                        , "Transaction No»Client Name»Date",
                                        , "a.sTransNox»b.sCompnyNm»a.dEntryDte" _
                                        , IIf(fbByCode, 0, 1))
        If IsNothing(loDta) Then
            p_nEditMode = xeEditMode.MODE_UNKNOWN
            Return False
        Else
            Return OpenTransaction(loDta.Item("sTransNox"))
        End If
    End Function

    'Public Function SaveTransaction
    'This object does not implement Update
    Public Function SaveTransaction() As Boolean
        If Not (p_nEditMode = xeEditMode.MODE_ADDNEW Or
                p_nEditMode = xeEditMode.MODE_READY Or
                p_nEditMode = xeEditMode.MODE_UPDATE) Then
            MsgBox("Invalid Edit Mode detected!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, p_sMsgHeadr)
            Return False
        End If

        If Not isEntryOk() Then
            Return False
        End If

        Dim lsSQL As String


        If p_nEditMode = xeEditMode.MODE_ADDNEW Then

            p_oDTMstr(0).Item("sTransNox") = GetNextCode(p_sMasTable, "sTransNox", True, p_oApp.Connection, True, p_sBranchCD)
            p_oDTMstr(0).Item("dEntryDte") = Format(p_oApp.SysDate, "yyyy-MM-dd HH:mm:ss")

            lsSQL = ADO2SQL(p_oDTMstr, p_sMasTable, , p_oApp.UserID)
            p_oApp.BeginTransaction()
            If (p_oApp.Execute(lsSQL, p_sMasTable) <= 0) Then
                p_oApp.RollBackTransaction()
                Return False
            End If
            p_oApp.CommitTransaction()
        Else
            lsSQL = ADO2SQL(p_oDTMstr, p_sMasTable, "sTransNox = " & strParm(p_oDTMstr(0).Item("sTransNox")), p_oApp.UserID)

            If lsSQL <> "" Then
                p_oApp.BeginTransaction()
                If (p_oApp.Execute(lsSQL, p_sMasTable) <= 0) Then
                    p_oApp.RollBackTransaction()
                    Return False
                End If
                p_oApp.CommitTransaction()
            End If
        End If

        Return True
    End Function


    Function CloseTransaction() As Boolean
        Dim lsSQL As String
        If Not (p_nEditMode = xeEditMode.MODE_READY Or
               p_nEditMode = xeEditMode.MODE_UPDATE) Then
            MsgBox("Invalid Edit Mode detected!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, p_sMsgHeadr)
            Return False
        End If

        'Test if closing is possible
        If Not (p_nEditMode = xeEditMode.MODE_READY) Then
            MsgBox("Transaction mode does not allow closing of the Record!!!" & vbCrLf & vbCrLf &
                  "Please inform the SEG/SSG of Guanzon Group of Companies!!!", vbCritical, "Warning")
            GoTo endProc
        End If

        If Not p_oDTMstr(0).Item("sTransNox") = "" Then
            If Not OpenTransaction(p_oDTMstr(0).Item("sTransNox")) Then GoTo endProc
        End If

        If p_oDTMstr(0).Item("cTranStat") = strParm("1") _
           Or p_oDTMstr(0).Item("cTranStat") = strParm("2") _
           Or p_oDTMstr(0).Item("cTranStat") = strParm("3") Then
            MsgBox("Modification of closed / cancelled / posted transaction is not allowed!" & vbCrLf & vbCrLf &
                     "Please verify your entry then Try Again!!!", vbCritical, "Warning")
            GoTo endProc
        End If

        If p_oApp.UserLevel < xeUserRights.SUPERVISOR Then
            MsgBox("User account is not ALLOWED to approve this transaction", vbInformation, "Notice")
            GoTo endProc
        End If

        p_oApp.BeginTransaction()

        lsSQL = "UPDATE " & p_sMasTable & " SET" &
                    "  cTranStat = " & strParm("1") &
                    ", sApproved = " & strParm(p_oApp.UserID) &
                    ", dApproved = " & datetimeParm(p_oApp.getSysDate) &
                " WHERE sTransNox = " & strParm(p_oDTMstr(0).Item("sTransNox"))

        If p_oApp.Execute(lsSQL, p_sMasTable, p_sBranchCD) <= 0 Then
            p_oApp.RollBackTransaction()
            MsgBox("Unable to close " & p_oDTMstr(0).Item("sTransNox") & " from " & p_sMasTable & " Table." & vbCrLf &
                     "Please Inform SEG/SSG of Guanzon Group of Companies!!!", vbCritical, "Warning")
            GoTo endProc
        End If

        p_oApp.CommitTransaction()
        RaiseEvent MasterRetrieved(11, "1")

        p_nEditMode = xeEditMode.MODE_READY

        Return True
endProc:
        Exit Function

    End Function

    Function PostTransaction() As Boolean
        Dim lsSQL As String

        If Not (p_nEditMode = xeEditMode.MODE_READY Or
               p_nEditMode = xeEditMode.MODE_UPDATE) Then
            MsgBox("Invalid Edit Mode detected!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, p_sMsgHeadr)
            Return False
        End If

        'Test if closing is possible
        If Not (p_nEditMode = xeEditMode.MODE_READY) Then
            MsgBox("Transaction mode does not allow closing of the Record!!!" & vbCrLf & vbCrLf &
                  "Please inform the SEG/SSG of Guanzon Group of Companies!!!", vbCritical, "Warning")
            GoTo endProc
        End If

        If Not p_oDTMstr(0).Item("sTransNox") = "" Then
            If Not OpenTransaction(p_oDTMstr(0).Item("sTransNox")) Then GoTo endProc
        End If

        If p_oDTMstr(0).Item("cTranStat") = strParm("2") _
           Or p_oDTMstr(0).Item("cTranStat") = strParm("3") Then
            MsgBox("Modification of cancelled / posted transaction is not allowed!" & vbCrLf & vbCrLf &
                     "Please verify your entry then Try Again!!!", vbCritical, "Warning")
            GoTo endProc
        End If

        If p_oApp.UserLevel < xeUserRights.AUDIT Then
            MsgBox("User account is not ALLOWED to approve this transaction", vbInformation, "Notice")
            GoTo endProc
        End If

        p_oApp.BeginTransaction()

        lsSQL = "UPDATE " & p_sMasTable & " SET" &
                    "  cTranStat = " & strParm("2") &
                    ", sPostedxx = " & strParm(p_oApp.UserID) &
                    ", dPostedxx = " & dateParm(p_oApp.getSysDate) &
                " WHERE sTransNox = " & strParm(p_oDTMstr(0).Item("sTransNox"))

        If p_oApp.Execute(lsSQL, p_sMasTable, p_sBranchCD) <= 0 Then
            p_oApp.RollBackTransaction()
            MsgBox("Unable to close " & p_oDTMstr(0).Item("sTransNox") & " from " & p_sMasTable & " Table." & vbCrLf &
                     "Please Inform SEG/SSG of Guanzon Group of Companies!!!", vbCritical, "Warning")
            GoTo endProc
        End If

        p_oApp.CommitTransaction()
        RaiseEvent MasterRetrieved(11, "2")

        p_nEditMode = xeEditMode.MODE_READY

        Return True
endProc:
        Exit Function

    End Function

    Function CancelTransaction() As Boolean
        Dim lsSQL As String
        If Not (p_nEditMode = xeEditMode.MODE_READY Or
               p_nEditMode = xeEditMode.MODE_UPDATE) Then
            MsgBox("Invalid Edit Mode detected!", MsgBoxStyle.OkOnly + MsgBoxStyle.Critical, p_sMsgHeadr)
            Return False
        End If

        'Test if closing is possible
        If Not (p_nEditMode = xeEditMode.MODE_READY) Then
            MsgBox("Transaction mode does not allow closing of the Record!!!" & vbCrLf & vbCrLf &
                  "Please inform the SEG/SSG of Guanzon Group of Companies!!!", vbCritical, "Warning")
            GoTo endProc
        End If

        If Not p_oDTMstr(0).Item("sTransNox") = "" Then
            If Not OpenTransaction(p_oDTMstr(0).Item("sTransNox")) Then GoTo endProc
        End If

        If p_oDTMstr(0).Item("cTranStat") = strParm("2") _
            Or p_oDTMstr(0).Item("cTranStat") = strParm("3") Then
            MsgBox("Modification of closed / cancelled / posted transaction is not allowed!" & vbCrLf & vbCrLf &
                     "Please verify your entry then Try Again!!!", vbCritical, "Warning")
            GoTo endProc
        End If

        p_oApp.BeginTransaction()

        lsSQL = "UPDATE " & p_sMasTable & " SET" &
                    " cTranStat = " & strParm("3") &
                " WHERE sTransNox = " & strParm(p_oDTMstr(0).Item("sTransNox"))


        If p_oApp.Execute(lsSQL, p_sMasTable, p_sBranchCD) <= 0 Then
            p_oApp.RollBackTransaction()
            MsgBox("Unable to close " & p_oDTMstr(0).Item("sTransNox") & " from " & p_sMasTable & " Table." & vbCrLf &
                     "Please Inform SEG/SSG of Guanzon Group of Companies!!!", vbCritical, "Warning")
            GoTo endProc
        End If

        p_oApp.CommitTransaction()
        RaiseEvent MasterRetrieved(11, "3")

        p_nEditMode = xeEditMode.MODE_READY

        Return True
endProc:
        Exit Function

    End Function

    Public Sub SearchMaster(ByVal fnIndex As Integer, ByVal fsValue As String)
        Select Case fnIndex
            Case 2 ' sClientNm
                getClients(2, 2, fsValue, False, True)
            Case 3 ' sMobileNo
                getMobile(3, 2, fsValue, False, True)
            Case 80 ' sBranch
                getBranch(80, 80, fsValue, False, True)
            Case 81 ' clientnme
                getSalesInformation(81, 81, fsValue, False, True)

        End Select
    End Sub

    Private Sub initMaster()
        Dim lnCtr As Integer
        For lnCtr = 0 To p_oDTMstr.Columns.Count - 1
            Select Case LCase(p_oDTMstr.Columns(lnCtr).ColumnName)
                Case "stransnox"
                    p_oDTMstr(0).Item(lnCtr) = GetNextCode(p_sMasTable, "sTransNox", True, p_oApp.Connection, True, p_sBranchCD)
                Case "ssourcecd"
                    p_oDTMstr(0).Item(lnCtr) = "LEAD"
                Case "srefercde"
                    p_oDTMstr(0).Item(lnCtr) = "MCSO"
                Case "sentrybyx"
                    p_oDTMstr(0).Item(lnCtr) = p_oApp.UserID
                Case "ctranstat"
                    p_oDTMstr(0).Item(lnCtr) = 0
                Case "smodified"
                    p_oDTMstr(0).Item(lnCtr) = p_oApp.UserID
                Case "dmodified"
                    p_oDTMstr(0).Item(lnCtr) = p_oApp.SysDate
                Case "dtimestmp"
                    p_oDTMstr(0).Item(lnCtr) = p_oApp.SysDate
                Case "dapproved"
                    p_oDTMstr(0).Item(lnCtr) = DBNull.Value
                Case "sapproved"
                    p_oDTMstr(0).Item(lnCtr) = DBNull.Value
                Case "dentrydte"
                    p_oDTMstr(0).Item(lnCtr) = p_oApp.SysDate
                Case Else
                    p_oDTMstr(0).Item(lnCtr) = ""
            End Select
        Next
    End Sub
    Private Sub InitOthers()
        p_oOthersx.sTransNox = ""
        p_oOthersx.sDRNoxxxx = ""
        p_oOthersx.sSerialID = ""
        p_oOthersx.sModelNme = ""
        p_oOthersx.sEngineNo = ""
        p_oOthersx.sFrameNox = ""
        p_oOthersx.sMobileNo = ""
        p_oOthersx.sClientNm = ""
        p_oOthersx.sAddressx = ""
        p_oOthersx.sBranchCd = ""
        p_oOthersx.sBranchNm = ""
    End Sub
    Private Sub InitOGCallInfo()
        p_oCallInfosx.sClientID = ""
        p_oCallInfosx.sCompnyNm = ""
        p_oCallInfosx.dCallStrt = ""
        p_oCallInfosx.dCallEndx = ""
        p_oCallInfosx.sRemarks = ""
        p_oCallInfosx.sSourceCD = ""
        p_oCallInfosx.cTranStat = ""
        p_oCallInfosx.sAgentNme = ""
        p_oCallInfosx.xClientNmeCallInfo = ""
    End Sub

    Private Function isEntryOk() As Boolean

        'Check validity of transaction date
        If p_oDTMstr(0).Item("dEntryDte") = "" Then
            MsgBox("Transaction date seems to have a problem! Please check your entry....", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, p_sMsgHeadr)
            Return False
        End If

        'Check if application has client
        If p_oDTMstr(0).Item("sClientID") = "" Then
            MsgBox("Client Info seems to have a problem! Please check your entry....", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, p_sMsgHeadr)
            Return False
        End If


        If p_oDTMstr(0).Item("sSourceNo") = "" Then
            MsgBox("Leads Info seems to have a problem! Please check your entry...", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, p_sMsgHeadr)
            Return False
        End If

        If p_oDTMstr(0).Item("sReferNox") = "" Then
            MsgBox("Sales Info seems to have a problem! Please check your entry...", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, p_sMsgHeadr)
            Return False
        End If

        Return True
    End Function

    Private Sub getBranch(ByVal fnColIdx As Integer _
                        , ByVal fnColDsc As Integer _
                        , ByVal fsValue As String _
                        , ByVal fbIsCode As Boolean _
                        , ByVal fbIsSrch As Boolean)

        'Compare the value to be search against the value in our column
        If fbIsCode Then
            If fsValue = p_oDTMstr(0).Item(fnColIdx) And fsValue <> "" And p_oDTMstr(0).Item("sTransNox") <> "" Then Exit Sub
        Else
            If fsValue = p_oDTMstr(0).Item("sTransNox") And fsValue <> "" Then Exit Sub
        End If

        Dim lsSQL As String
        lsSQL = "SELECT" &
                       "  a.sBranchCD" &
                       ", a.sBranchNm" &
               " FROM Branch a" &
                   " LEFT JOIN Branch_Others b " &
                   " ON a.sBranchCD = b.sBranchCD " &
               " WHERE b.cDivision = '1' "

            IIf(fbIsCode = False, " AND a.cRecdStat = '1'", "")

        'Are we using like comparison or equality comparison
        If fbIsSrch Then
            Dim loRow As DataRow = KwikSearch(p_oApp _
                                             , lsSQL _
                                             , True _
                                             , fsValue _
                                             , "sBranchCD»sBranchNm" _
                                             , "Code»Branch", _
                                             , "a.sBranchCD»a.sBranchNm" _
                                             , IIf(fbIsCode, 0, 1))
            If IsNothing(loRow) Then
                p_oOthersx.sBranchNm = ""
            Else
                p_oOthersx.sBranchNm = loRow.Item("sBranchNm")
            End If


            RaiseEvent MasterRetrieved(fnColDsc, p_oOthersx.sBranchNm)
            Exit Sub
        End If

        If fsValue <> "" Then
            If fbIsCode Then
                lsSQL = AddCondition(lsSQL, "a.sBranchCD = " & strParm(fsValue))
            Else
                lsSQL = AddCondition(lsSQL, "a.sBranchNm = " & strParm(fsValue))
            End If
        End If

        Dim loDta As DataTable
        loDta = p_oApp.ExecuteQuery(lsSQL)

        If loDta.Rows.Count = 0 Then
            p_oDTMstr(0).Item(fnColIdx) = ""
            p_oOthersx.sBranchNm = ""
        ElseIf loDta.Rows.Count = 1 Then
            p_oDTMstr(0).Item(fnColIdx) = loDta(0).Item("sBranchCD")
            p_oOthersx.sBranchNm = loDta(0).Item("sBranchNm")
        End If

        RaiseEvent MasterRetrieved(fnColDsc, p_oOthersx.sBranchNm)
    End Sub
    'This method implements a search master where id and desc are not joined.
    Private Sub getClients(ByVal fnColIdx As Integer _
                        , ByVal fnColDsc As Integer _
                        , ByVal fsValue As String _
                        , ByVal fbIsCode As Boolean _
                        , ByVal fbIsSrch As Boolean)

        'Compare the value to be search against the value in our column
        If fbIsCode Then
            If fsValue = p_oDTMstr(0).Item(fnColIdx) And fsValue <> "" And p_oDTMstr(0).Item("sTransNox") <> "" Then Exit Sub
        Else
            If fsValue = p_oDTMstr(0).Item("sTransNox") And fsValue <> "" Then Exit Sub
        End If

        Dim lsSQL As String
        lsSQL = "SELECT" &
                    "  b.sTransNox" &
                    ", b.dTransact" &
                    ", a.sClientID" &
                    ", b.sMobileNo" &
                    ", a.sCompnyNm" &
                    ", b.sAgentIDx" &
                    ", IFNULL(b.dCallStrt, '')  dCallStrt " &
                    ", IFNULL(b.dCallEndx, '')  dCallEndx " &
                    ", b.sRemarksx" &
                    ", b.sSourceCd" &
                    ", b.cTranStat" &
                    ", a.sLastName" &
                    ", a.sFrstName" &
                    ", a.sMiddName" &
                    ", a.sSuffixNm" &
                    ", IFNULL(d.sCompnyNm, '') sAgentNme" &
                " FROM Call_Outgoing b" &
                    " LEFT JOIN Client_Master a ON a.sClientID = b.sClientID" &
                    " LEFT JOIN xxxSysUser c ON b.sAgentIDx = c.sUserIDxx" &
                    " LEFT JOIN Client_Master d ON d.sClientID = c.sEmployNo" &
                " WHERE b.cTranStat <> '3'"


        'Are we using like comparison or equality comparison
        If fbIsSrch Then
            Dim loRow As DataRow = KwikSearch(p_oApp _
                                             , lsSQL _
                                             , True _
                                             , fsValue _
                                             , "dTransact»sCompnyNm»sMobileNo»sAgentNme" _
                                             , "Date Called»Name»Mobile»Agent",
                                             , "b.dTransact»a.sCompnyNm»b.sMobileNo»d.sCompnyNm")

            If IsNothing(loRow) Then
                p_oDTMstr(0).Item("sClientID") = ""
                p_oCallInfosx.xClientNmeCallInfo = ""
            Else
                p_oDTMstr(0).Item("sClientID") = loRow.Item("sClientID")
                p_oCallInfosx.xClientNmeCallInfo = loRow.Item("sLastName") & ", " &
                                                    loRow.Item("sFrstName") &
                                                    IIf(loRow.Item("sSuffixNm") = "", "", " " & loRow.Item("sSuffixNm")) & " " &
                                                    loRow.Item("sMiddName")

                p_oDTMstr(0).Item("sMobileNo") = IFNull(loRow.Item("sMobileNo"), "")
                p_oDTMstr(0).Item("sEntryByx") = IFNull((loRow.Item("sAgentIDx")), "")
                p_oDTMstr(0).Item("sSourceNo") = IFNull(loRow.Item("sTransNox"), "")
                p_oCallInfosx.sSourceCd = IFNull(loRow.Item("sSourceCd"), "")
                p_oCallInfosx.dCallStrt = loRow.Item("dCallStrt")
                p_oCallInfosx.sRemarks = IFNull(loRow.Item("sRemarksx"), "")
                p_oCallInfosx.cTranStat = IFNull(loRow.Item("cTranStat"), "")
                p_oCallInfosx.sAgentNme = loRow.Item("sAgentNme")
            End If

            RaiseEvent MasterRetrieved(fnColDsc, p_oCallInfosx.xClientNmeCallInfo)
            RaiseEvent MasterRetrieved(3, p_oDTMstr(0).Item("sMobileNo"))
            RaiseEvent MasterRetrieved(4, p_oCallInfosx.dCallStrt)
            RaiseEvent MasterRetrieved(5, p_oCallInfosx.sRemarks)
            RaiseEvent MasterRetrieved(6, p_oCallInfosx.cTranStat)
            RaiseEvent MasterRetrieved(7, p_oCallInfosx.sAgentNme)
            Exit Sub
        End If

        If fsValue <> "" Then
            If fbIsCode Then
                lsSQL = AddCondition(lsSQL, "a.sCompnyNm = " & strParm(fsValue))
            Else
                lsSQL = AddCondition(lsSQL, "a.sMobileNo = " & strParm(fsValue))
            End If
        End If

        Dim loDta As DataTable
        loDta = p_oApp.ExecuteQuery(lsSQL)

        If loDta.Rows.Count = 0 Then
            p_oDTMstr(0).Item(fnColIdx) = ""
            p_oCallInfosx.xClientNmeCallInfo = ""
        ElseIf loDta.Rows.Count = 1 Then
            p_oDTMstr(0).Item("sClientID") = loDta(0).Item("sClientID")
            p_oCallInfosx.xClientNmeCallInfo = loDta(0).Item("sLastName") & ", " &
                                                loDta(0).Item("sFrstName") &
                                                   IIf(loDta(0).Item("sSuffixNm") = "", "", " " & loDta(0).Item("sSuffixNm")) & " " &
                                                   loDta(0).Item("sMiddName")

            p_oDTMstr(0).Item("sMobileNo") = IFNull(loDta(0).Item("sMobileNo"), "")
            p_oDTMstr(0).Item("sEntryByx") = IFNull((loDta(0).Item("sAgentIDx")), "")
            p_oDTMstr(0).Item("sSourceNo") = IFNull(loDta(0).Item("sTransNox"), "")
            p_oCallInfosx.sSourceCd = IFNull(loDta(0).Item("sSourceCd"), "")
            p_oCallInfosx.dCallStrt = loDta(0).Item("dCallStrt")
            p_oCallInfosx.sRemarks = IFNull(loDta(0).Item("sRemarksx"), "")
            p_oCallInfosx.cTranStat = IFNull(loDta(0).Item("cTranStat"), "")
            p_oCallInfosx.sAgentNme = loDta(0).Item("sAgentNme")
        End If

        RaiseEvent MasterRetrieved(fnColDsc, p_oCallInfosx.xClientNmeCallInfo)
        RaiseEvent MasterRetrieved(3, p_oDTMstr(0).Item("sMobileNo"))
        RaiseEvent MasterRetrieved(4, p_oCallInfosx.dCallStrt)
        RaiseEvent MasterRetrieved(5, p_oCallInfosx.sRemarks)
        RaiseEvent MasterRetrieved(6, p_oCallInfosx.cTranStat)
        RaiseEvent MasterRetrieved(7, p_oCallInfosx.sAgentNme)
    End Sub
    Private Sub getMobile(ByVal fnColIdx As Integer _
                        , ByVal fnColDsc As Integer _
                        , ByVal fsValue As String _
                        , ByVal fbIsCode As Boolean _
                        , ByVal fbIsSrch As Boolean)

        'Compare the value to be search against the value in our column
        If fbIsCode Then
            If fsValue = p_oDTMstr(0).Item(fnColIdx) And fsValue <> "" And p_oDTMstr(0).Item("sTransNox") <> "" Then Exit Sub
        Else
            If fsValue = p_oDTMstr(0).Item("sTransNox") And fsValue <> "" Then Exit Sub
        End If



        Dim lsSQL As String
        lsSQL = "SELECT" & _
                       " b.sTransNox" &
                       ", b.dTransact" & _
                       ", a.sClientID" & _
                       ", b.sMobileNo" & _
                       ", a.sCompnyNm" & _
                       ", b.sAgentIDx" & _
                       ", IFNULL(b.dCallStrt, '')  dCallStrt " & _
                       ", IFNULL(b.dCallEndx, '')  dCallEndx " & _
                       ", b.sRemarksx" & _
                       ", b.sSourceCd" & _
                       ", b.cTranStat" & _
                       ", a.sLastName" & _
                       ", a.sFrstName" & _
                       ", a.sMiddName" & _
                       ", a.sSuffixNm" & _
                       " FROM Client_Master a" & _
               " LEFT JOIN Call_Outgoing b" & _
               " ON a.sClientID = b.sClientID" & _
               " WHERE b.sMobileNo > ''  "
        IIf(fbIsCode = False, " AND a.cRecdStat = '1'", "")

        'Are we using like comparison or equality comparison
        If fbIsSrch Then
            Dim loRow As DataRow = KwikSearch(p_oApp _
                                             , lsSQL _
                                             , True _
                                             , fsValue _
                                             , "sCompnyNm»sMobileNo»dTransact" _
                                             , "Name»Mobile»Date Called", _
                                             , "a.sCompnyNm»b.sMobileNo»b.dTransact")

            IIf(fbIsCode, 0, 1)
            If IsNothing(loRow) Then
                p_oDTMstr(0).Item("sClientID") = ""
                p_oCallInfosx.xClientNmeCallInfo = ""
            Else
                p_oDTMstr(0).Item("sClientID") = loRow.Item("sClientID")
                p_oCallInfosx.xClientNmeCallInfo = loRow.Item("sLastName") & ", " & _
                                       loRow.Item("sFrstName") & _
                                               IIf(loRow.Item("sSuffixNm") = "", "", " " & loRow.Item("sSuffixNm")) & " " & _
                                               loRow.Item("sMiddName")
                Debug.Print(p_oCallInfosx.xClientNmeCallInfo)
                Debug.Print(loRow.Item("dCallStrt"))
                p_oDTMstr(0).Item("sMobileNo") = IFNull(loRow.Item("sMobileNo"), "")
                p_oDTMstr(0).Item("sEntryByx") = IFNull((loRow.Item("sAgentIDx")), "")
                p_oCallInfosx.dCallStrt = loRow.Item("dCallStrt")
                p_oCallInfosx.sRemarks = IFNull(loRow.Item("sRemarksx"), "")
                p_oCallInfosx.cTranStat = IFNull(loRow.Item("cTranStat"), "")
                p_oDTMstr(0).Item("sSourceNo") = IFNull(loRow.Item("sTransNox"), "")
                p_oCallInfosx.sSourceCd = IFNull(loRow.Item("sSourceCd"), "")
            End If

            RaiseEvent MasterRetrieved(fnColDsc, p_oCallInfosx.xClientNmeCallInfo)
            RaiseEvent MasterRetrieved(3, p_oDTMstr(0).Item("sMobileNo"))
            RaiseEvent MasterRetrieved(4, p_oCallInfosx.dCallStrt)
            RaiseEvent MasterRetrieved(5, p_oCallInfosx.sRemarks)
            RaiseEvent MasterRetrieved(6, p_oCallInfosx.cTranStat)

            Exit Sub

        End If

        If fsValue <> "" Then
            If fbIsCode Then
                lsSQL = AddCondition(lsSQL, "a.sMobileNo = " & strParm(fsValue))
            Else
                lsSQL = AddCondition(lsSQL, "a.sCompnyNm = " & strParm(fsValue))
            End If
        End If

        Dim loDta As DataTable
        loDta = p_oApp.ExecuteQuery(lsSQL)

        If loDta.Rows.Count = 0 Then
            p_oDTMstr(0).Item(fnColIdx) = ""
            p_oCallInfosx.xClientNmeCallInfo = ""
        ElseIf loDta.Rows.Count = 1 Then

            p_oDTMstr(0).Item("sClientID") = loDta(0).Item("sClientID")
            p_oCallInfosx.xClientNmeCallInfo = loDta(0).Item("sLastName") & ", " & _
                                   loDta(0).Item("sFrstName") & _
                                           IIf(loDta(0).Item("sSuffixNm") = "", "", " " & loDta(0).Item("sSuffixNm")) & " " & _
                                           loDta(0).Item("sMiddName")
            Debug.Print(p_oCallInfosx.xClientNmeCallInfo)
            p_oDTMstr(0).Item("sMobileNo") = IFNull(loDta(0).Item("sMobileNo"), "")


        End If

        RaiseEvent MasterRetrieved(fnColDsc, p_oCallInfosx.xClientNmeCallInfo)
    End Sub

    Private Sub getSalesInformation(ByVal fnColIdx As Integer _
                    , ByVal fnColDsc As Integer _
                    , ByVal fsValue As String _
                    , ByVal fbIsCode As Boolean _
                    , ByVal fbIsSrch As Boolean)

        'Compare the value to be search against the value in our column
        If fbIsCode Then
            If fsValue = p_oDTMstr(0).Item(fnColIdx) And fsValue <> "" And p_oDTMstr(0).Item("sTransNox") <> "" Then Exit Sub
        Else
            If fsValue = p_oDTMstr(0).Item("sTransNox") And fsValue <> "" Then Exit Sub
        End If
        If p_oOthersx.sBranchNm = "" Then Exit Sub

        Dim lsSQL As String
        lsSQL = "SELECT" &
                    "  a.sTransNox" &
                    ", a.sClientID" &
                    ", a.sDRNoxxxx" &
                    ", b.sSerialID" &
                    ", e.sModelNme" &
                    ", d.sEngineNo" &
                    ", d.sFrameNox" &
                    ", c.sCompnyNm" &
                    ", c.sLastName" &
                    ", c.sFrstName" &
                    ", c.sMiddName" &
                    ", c.sSuffixNm" &
                    ", c.sAddressx" &
                    ", c.sMobileNo" &
                    ", f.sBrgyName" &
                    ", g.sTownName" &
                    ", h.sProvName" &
                    ", g.sZippCode" &
                    ", a.dTransact" &
                " FROM MC_SO_Master a " &
                    " LEFT JOIN MC_SO_Detail b ON a.sTransNox = b.sTransNox " &
                    " LEFT JOIN Client_Master c ON c.sClientID = a.sClientID " &
                    " LEFT JOIN MC_Serial d ON  b.sSerialID = d.sSerialID " &
                    " LEFT JOIN MC_Model e ON d.sModelIDx = e.sModelIDx " &
                    " LEFT JOIN Barangay f ON c.sBrgyIDxx = f.sBrgyIDxx " &
                    " LEFT JOIN TownCity g ON f.sTownIDxx = g.sTownIDxx " &
                    " LEFT JOIN Province h ON g.sProvIDxx = h.sProvIDxx " &
                    " LEFT JOIN Branch i  ON  d.sBranchCd = i.sBranchCd " &
                " WHERE a.cTranStat != '3' " &
                    " AND i.sBranchNm = " + strParm(p_oOthersx.sBranchNm)
        IIf(fbIsCode = False, " AND a.cRecdStat = '1'", "")

        'Are we using like comparison or equality comparison
        If fbIsSrch Then
            Dim loRow As DataRow = KwikSearch(p_oApp _
                                             , lsSQL _
                                             , True _
                                             , fsValue _
                                             , "sDRNoxxxx»sCompnyNm»sModelNme»dTransact" _
                                             , "DR No.»Name»Model Name»Date",
                                             , "a.sDRNoxxxx»c.sCompnyNm»e.sModelNme»a.dTransact", 1)

            IIf(fbIsCode, 0, 2)
            If IsNothing(loRow) Then
                p_oOthersx.sTransNox = ""
                p_oOthersx.sClientNm = ""
            Else
                p_oDTMstr(0).Item("sReferNox") = loRow.Item("sTransNox")
                p_oOthersx.sClientNm = loRow.Item("sLastName") & ", " & _
                                       loRow.Item("sFrstName") & _
                                               IIf(loRow.Item("sSuffixNm") = "", "", " " & loRow.Item("sSuffixNm")) & " " & _
                                               loRow.Item("sMiddName")
                p_oOthersx.sAddressx = (loRow.Item("sAddressx") & ", " & _
                                       loRow.Item("sBrgyName") & _
                                               IFNull(loRow.Item("sTownName"), "") & " " & loRow.Item("sProvName")) & " " & _
                                               loRow.Item("sZippCode")
                p_oOthersx.sMobileNo = IFNull(loRow.Item("sMobileNo"), "")
                p_oOthersx.sDRNoxxxx = IFNull(loRow.Item("sDRNoxxxx"), "")
                p_oOthersx.sModelNme = IFNull(loRow.Item("sModelNme"), "")
                p_oOthersx.sEngineNo = IFNull(loRow.Item("sEngineNo"), "")
                p_oOthersx.sFrameNox = IFNull(loRow.Item("sFrameNox"), "")
                Debug.Print(p_oOthersx.sClientNm)
                Debug.Print(p_oOthersx.sAddressx)
            End If

            RaiseEvent MasterRetrieved(fnColDsc, p_oOthersx.sClientNm)
            RaiseEvent MasterRetrieved(82, p_oOthersx.sAddressx)
            RaiseEvent MasterRetrieved(83, p_oOthersx.sMobileNo)
            RaiseEvent MasterRetrieved(84, p_oOthersx.sDRNoxxxx)
            RaiseEvent MasterRetrieved(85, p_oOthersx.sModelNme)
            RaiseEvent MasterRetrieved(86, p_oOthersx.sEngineNo)
            RaiseEvent MasterRetrieved(87, p_oOthersx.sFrameNox)
            Exit Sub

        End If

        If fsValue <> "" Then
            If fbIsCode Then
                lsSQL = AddCondition(lsSQL, "a.sCompnyNm = " & strParm(fsValue))
            Else
                lsSQL = AddCondition(lsSQL, "a.sMobileNo = " & strParm(fsValue))
            End If
        End If

        Dim loDta As DataTable
        loDta = p_oApp.ExecuteQuery(lsSQL)

        If loDta.Rows.Count = 0 Then
            p_oDTMstr(0).Item(fnColIdx) = ""
            p_oCallInfosx.xClientNmeCallInfo = ""
        ElseIf loDta.Rows.Count = 1 Then

            p_oDTMstr(0).Item("sClientID") = loDta(0).Item("sClientID")
            p_oCallInfosx.xClientNmeCallInfo = loDta(0).Item("sLastName") & ", " & _
                                   loDta(0).Item("sFrstName") & _
                                           IIf(loDta(0).Item("sSuffixNm") = "", "", " " & loDta(0).Item("sSuffixNm")) & " " & _
                                           loDta(0).Item("sMiddName")
            Debug.Print(p_oCallInfosx.xClientNmeCallInfo)
            p_oDTMstr(0).Item("sMobileNo") = IFNull(loDta(0).Item("sMobileNo"), "")


        End If

        RaiseEvent MasterRetrieved(fnColDsc, p_oCallInfosx.xClientNmeCallInfo)
    End Sub
    Private Function getSQ_Master() As String
        Return "SELECT a.sTransNox" & _
                    ", a.sClientID" & _
                    ", a.sMobileNo" & _
                    ", a.sSourceNo" & _
                    ", a.sSourceCd" & _
                    ", a.sReferNox" & _
                    ", a.sReferCde" & _
                    ", a.sEntryByx" & _
                    ", IFNULL(a.dEntryDte,'') dEntryDte" & _
                    ", a.sApproved" & _
                    ", IFNULL(a.dApproved,'') dApproved" & _
                    ", a.cTranStat" & _
                    ", a.sModified" & _
                    ", a.dModified" & _
                    ", a.dTimestmp" & _
                " FROM " & p_sMasTable & " a"
    End Function

    Private Function getSQ_Browse() As String
        Return "SELECT a.sTransNox" &
                    ", b.sCompnyNm sClientNm" &
                    ", a.sSourceNo" &
                    ", a.sEntryByx" &
                    ", a.dEntryDte" &
              " FROM " & p_sMasTable & " a" &
                    ", Client_Master b" &
              " WHERE a.sClientID = b.sClientID" &
              " AND a.sReferCde = 'MCSO' "
    End Function

    Public Sub New(ByVal foRider As GRider)
        p_oApp = foRider
        p_nEditMode = xeEditMode.MODE_UNKNOWN

        p_sBranchCD = p_oApp.BranchCode
    End Sub

    Public Sub New(ByVal foRider As GRider, ByVal fnStatus As Int32)
        Me.New(foRider)
        p_nTranStat = fnStatus
    End Sub
    Private Class Others
        Public sTransNox As String
        Public sDRNoxxxx As String
        Public sSerialID As String
        Public sModelNme As String
        Public sEngineNo As String
        Public sFrameNox As String
        Public sMobileNo As String
        Public sClientNm As String
        Public sAddressx As String
        Public sBranchCd As String
        Public sBranchNm As String
    End Class

    Private Class OGCallInfo
        Public sTransNox As String
        Public sClientID As String
        Public sCompnyNm As String
        Public dCallStrt As String
        Public dCallEndx As String
        Public sRemarks As String
        Public sSourceCd As String
        Public cTranStat As String
        Public sAgentNme As String
        Public xClientNmeCallInfo As String
    End Class

End Class
