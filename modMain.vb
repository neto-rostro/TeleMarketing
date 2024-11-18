Imports ggcAppDriver
Imports System.Reflection

Module modMain
    Public p_oAppDriver As GRider
    Public p_sComptrID As String
    Public pxeSubscribr As String

    Private Declare Sub keybd_event Lib "user32.dll" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, ByVal dwExtraInfo As UInteger)

    Public Sub Main(ByVal args As String())
        'Enable XP visual style/skin
        Application.EnableVisualStyles()

        Dim lsUserIDxx As String
        Dim lsProdctID As String
        Dim lsComptrID As String

        If args.Length = 0 Then
            Dim loIni As New INIFile
            loIni.FileName = Environ("windir") & "\GRider.ini"

            If Not loIni.IsFileExist() Then
                MsgBox("Invalid Config File Detected!" & vbCrLf & _
                       "Verify your argument then try Again!", _
                       MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                Exit Sub
            End If

            lsProdctID = loIni.GetTextValue("Product", "ID")
            lsComptrID = loIni.GetTextValue(lsProdctID, "ComputerID")
        Else
            lsProdctID = args(0)
            lsUserIDxx = args(1)
            lsComptrID = args(2)
        End If

        lsProdctID = "TeleMktg"
        If LCase(lsProdctID) <> "telemktg" Then
            MsgBox("Invalid Config File Detected!" & vbCrLf & _
                       "Verify your product id then try Again!", _
                       MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            Exit Sub
        End If

        Select Case lsComptrID
            Case "S1", "S4"
                pxeSubscribr = "1" 'smart
            Case "S2"
                pxeSubscribr = "0" 'globe
            Case "S3"
                pxeSubscribr = "2" 'sun
            Case "S5" 'globe and smart
                pxeSubscribr = "3"
            Case Else
                MsgBox("Invalid Config File Detected!" & vbCrLf & _
                       "Verify your computer id then try Again!", _
                       MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
                Exit Sub
        End Select

        p_oAppDriver = New GRider(lsProdctID)

        If Not p_oAppDriver.LoadEnv() Then
            MsgBox("Unable to load configuration file!")
            Exit Sub
        End If

        ''lsUserIDxx = "M001220034"
        ''If Not p_oAppDriver.LogUser(lsUserIDxx) Then
        ''    MsgBox("User unable to log!")
        ''    Exit Sub
        ''End If

        If args.Length = 2 Then
            lsUserIDxx = args(1)
            If Not p_oAppDriver.LogUser(lsUserIDxx) Then
                MsgBox("User unable to log!")
                Exit Sub
            End If
        Else
            If Not p_oAppDriver.LogUser() Then
                MsgBox("User unable to log!")
                Exit Sub
            End If
        End If

        Debug.Print(p_oAppDriver.UserID)
        p_oAppDriver.MDI = mdiMain
        mdiMain.ShowDialog()
    End Sub

    'This method can handle all events using EventHandler
    Public Sub grpEventHandler(ByVal foParent As Control, ByVal foType As Type, ByVal fsGroupNme As String, ByVal fsEvent As String, ByVal foAddress As EventHandler)
        Dim loTxt As Control
        For Each loTxt In foParent.Controls
            If loTxt.GetType = foType Then
                'Handle events for this controls only
                If LCase(Mid(loTxt.Name, 1, Len(fsGroupNme))) = LCase(fsGroupNme) Then
                    If foType = GetType(TextBox) Then
                        Dim loObj = DirectCast(loTxt, TextBox)
                        Dim loEvent As EventInfo = foType.GetEvent(fsEvent)
                        loEvent.AddEventHandler(loObj, foAddress)
                    ElseIf foType = GetType(CheckBox) Then
                        Dim loObj = DirectCast(loTxt, CheckBox)
                        Dim loEvent As EventInfo = foType.GetEvent(fsEvent)
                        loEvent.AddEventHandler(loObj, foAddress)
                    ElseIf foType = GetType(Button) Then
                        Dim loObj = DirectCast(loTxt, Button)
                        Dim loEvent As EventInfo = foType.GetEvent(fsEvent)
                        loEvent.AddEventHandler(loObj, foAddress)
                    End If
                End If 'LCase(Mid(loTxt.Name, 1, 8)) = "txtfield"
            Else
                If loTxt.HasChildren Then
                    Call grpEventHandler(loTxt, foType, fsGroupNme, fsEvent, foAddress)
                End If
            End If
        Next 'loTxt In loControl.Controls
    End Sub

    'This method can handle all events using CancelEventHandler
    Public Sub grpCancelHandler(ByVal foParent As Control, ByVal foType As Type, ByVal fsGroupNme As String, ByVal fsEvent As String, ByVal foAddress As System.ComponentModel.CancelEventHandler)
        Dim loTxt As Control
        For Each loTxt In foParent.Controls
            If loTxt.GetType = foType Then
                'Handle events for this controls only
                If LCase(Mid(loTxt.Name, 1, Len(fsGroupNme))) = LCase(fsGroupNme) Then
                    If foType = GetType(TextBox) Then
                        Dim loObj = DirectCast(loTxt, TextBox)
                        Dim loEvent As EventInfo = foType.GetEvent(fsEvent)
                        loEvent.AddEventHandler(loObj, foAddress)
                    ElseIf foType = GetType(CheckBox) Then
                        Dim loObj = DirectCast(loTxt, CheckBox)
                        Dim loEvent As EventInfo = foType.GetEvent(fsEvent)
                        loEvent.AddEventHandler(loObj, foAddress)
                    ElseIf foType = GetType(Button) Then
                        Dim loObj = DirectCast(loTxt, Button)
                        Dim loEvent As EventInfo = foType.GetEvent(fsEvent)
                        loEvent.AddEventHandler(loObj, foAddress)
                    End If
                End If 'LCase(Mid(loTxt.Name, 1, 8)) = "txtfield"
            Else
                If loTxt.HasChildren Then
                    Call grpCancelHandler(loTxt, foType, fsGroupNme, fsEvent, foAddress)
                End If
            End If
        Next 'loTxt In loControl.Controls
    End Sub

    'This method can handle all events using KeyEventHandler
    Public Sub grpKeyHandler(ByVal foParent As Control, ByVal foType As Type, ByVal fsGroupNme As String, ByVal fsEvent As String, ByVal foAddress As KeyEventHandler)
        Dim loTxt As Control
        For Each loTxt In foParent.Controls
            If loTxt.GetType = foType Then
                'Handle events for this controls only
                If LCase(Mid(loTxt.Name, 1, Len(fsGroupNme))) = LCase(fsGroupNme) Then
                    If foType = GetType(TextBox) Then
                        Dim loObj = DirectCast(loTxt, TextBox)
                        Dim loEvent As EventInfo = foType.GetEvent(fsEvent)
                        loEvent.AddEventHandler(loObj, foAddress)
                    ElseIf foType = GetType(CheckBox) Then
                        Dim loObj = DirectCast(loTxt, CheckBox)
                        Dim loEvent As EventInfo = foType.GetEvent(fsEvent)
                        loEvent.AddEventHandler(loObj, foAddress)
                    ElseIf foType = GetType(Button) Then
                        Dim loObj = DirectCast(loTxt, Button)
                        Dim loEvent As EventInfo = foType.GetEvent(fsEvent)
                        loEvent.AddEventHandler(loObj, foAddress)
                    End If
                End If 'LCase(Mid(loTxt.Name, 1, 8)) = "txtfield"
            Else
                If loTxt.HasChildren Then
                    Call grpKeyHandler(loTxt, foType, fsGroupNme, fsEvent, foAddress)
                End If
            End If
        Next 'loTxt In loControl.Controls
    End Sub

    'This method can handle all events using EventHandler
    Public Function FindTextBox(ByVal foParent As Control, ByVal fsName As String) As Control
        Dim loTxt As Control
        Static loRet As Control
        For Each loTxt In foParent.Controls
            If loTxt.GetType = GetType(TextBox) Then
                'Handle events for this controls only
                If LCase(loTxt.Name) = LCase(fsName) Then
                    loRet = loTxt
                End If
            Else
                If loTxt.HasChildren Then
                    Call FindTextBox(loTxt, fsName)
                End If
            End If
        Next 'loTxt In loControl.Controls

        Return loRet
    End Function

    Function TranStatus(ByVal fnStatus As Int32) As String
        If fnStatus = 0 Then
            Return "OPEN"
        ElseIf fnStatus = 1 Then
            Return "CLOSED"
        ElseIf fnStatus = 2 Then
            Return "POSTED"
        ElseIf fnStatus = 3 Then
            Return "CANCELLED"
        ElseIf fnStatus = 4 Then
            Return "VOID"
        Else
            Return "UNKNOWN"
        End If
    End Function

    Function InquiryStatus(ByVal fnStatus As Int32) As String
        If fnStatus = 0 Then
            Return "OPEN"
        ElseIf fnStatus = 1 Then
            Return "SCHEDULED"
        ElseIf fnStatus = 2 Then
            Return "CALLED"
        ElseIf fnStatus = 3 Then
            Return "DECLINED"
        Else
            Return "UNKNOWN"
        End If
    End Function

    Function CallOutStatus(ByVal fnStatus As Int32) As String
        If fnStatus = 0 Then
            Return "OPEN"
        ElseIf fnStatus = 1 Then
            Return "QUEUED"
        ElseIf fnStatus = 2 Then
            Return "CALLED"
        ElseIf fnStatus = 3 Then
            Return "DISCARDED"
        ElseIf fnStatus = 5 Then
            Return "RECYCLED"
        Else
            Return "UNKNOWN"
        End If
    End Function

    Function CallIntatus(ByVal fnStatus As Int32) As String
        If fnStatus = 0 Then
            Return "OPEN"
        ElseIf fnStatus = 1 Then
            Return "SCHEDULED"
        ElseIf fnStatus = 2 Then
            Return "CALLED"
        ElseIf fnStatus = 3 Then
            Return "DISREGARD"
        Else
            Return "UNKNOWN"
        End If
    End Function

    Function MCSalesStatus(ByVal fnStatus As Int32) As String
        If fnStatus = 0 Then
            Return "OPEN"
        ElseIf fnStatus = 1 Then
            Return "CLOSED"
        ElseIf fnStatus = 2 Then
            Return "POSTED"
        ElseIf fnStatus = 3 Then
            Return "CANCELLED"
        Else
            Return "UNKNOWN"
        End If
    End Function

    Function TLMStatus(ByVal fnStatus As String) As String
        Select Case fnStatus
            Case "AM"
                Return "Answering Machine"
            Case "CB"
                Return "Call Back"
            Case "CR"
                Return "Cannot Be Reached"
            Case "NA"
                Return "Customer Not Around"
            Case "NC"
                Return "No Capacity "
            Case "NI"
                Return "Not Interested"
            Case "NN"
                Return "Not Now"
            Case "PS"
                Return "Possible Sales"
            Case "UR"
                Return "Cannot Be Reached"
            Case "WN"
                Return "Wrong Number"

            Case Else
                Return "UNKNOWN"

        End Select
    End Function

    Public Sub SetNextFocus()
        keybd_event(&H9, 0, 0, 0)
        keybd_event(&H9, 0, &H2, 0)
    End Sub

    Public Sub SetPreviousFocus()
        keybd_event(&H10, 0, 0, 0)
        keybd_event(&H9, 0, 0, 0)
        keybd_event(&H10, 0, &H2, 0)
    End Sub
End Module

