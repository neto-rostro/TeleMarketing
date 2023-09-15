Option Explicit On

Public Class frmCallResult
    Dim p_sCallResult As String = "NI" 'set degault to not interested
    Dim p_sRecipientx As String = ""
    Dim p_sBranchCdxx As String = ""
    Dim p_bCancelled As Boolean
    Dim p_dDateTrans As Date
    Dim p_dTimeTrans As Date
    Dim p_bLoaded As Boolean

    Public ReadOnly Property Cancelled() As Boolean
        Get
            Return p_bCancelled
        End Get
    End Property

    Public ReadOnly Property Result() As String
        Get
            Return p_sCallResult
        End Get
    End Property

    Private Sub cmdButton_MouseClick(sender As System.Object, e As System.EventArgs) Handles cmdButton02.Click, _
        cmdButton01.Click, cmdButton00.Click

        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 'ok
                    p_bCancelled = False
                Case 1, 2 'cancel, close
                    p_bCancelled = True
            End Select
        End If

        Me.Close()
    End Sub

    Private Sub cmdButton_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles cmdButton02.MouseDown, _
        cmdButton01.MouseDown, cmdButton00.MouseDown

        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 : cmdButton00.BackgroundImage = My.Resources.OK_OnMouseDown
                Case 1 : cmdButton01.BackgroundImage = My.Resources.Cancel_OnMouseDown
                Case 2 : cmdButton02.BackgroundImage = My.Resources.Close_Small_OnMouseDown
            End Select
        End If
    End Sub

    Private Sub cmdButton_MouseOver(sender As Object, e As System.EventArgs) Handles cmdButton02.MouseHover, _
        cmdButton01.MouseHover, cmdButton00.MouseHover

        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 : cmdButton00.BackgroundImage = My.Resources.OK_OnMouseOver
                Case 1 : cmdButton01.BackgroundImage = My.Resources.Cancel_OnMouseOver
                Case 2 : cmdButton02.BackgroundImage = My.Resources.Close_Small_OnMouseOver
            End Select
        End If
    End Sub

    Private Sub cmdButton_MouseLeave(sender As Object, e As System.EventArgs) Handles cmdButton02.MouseLeave, _
        cmdButton01.MouseLeave, cmdButton00.MouseLeave

        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 : cmdButton00.BackgroundImage = My.Resources.OK
                Case 1 : cmdButton01.BackgroundImage = My.Resources.Cancel
                Case 2 : cmdButton02.BackgroundImage = My.Resources.Close_Small
            End Select
        End If
    End Sub

    Private Sub frmCallResult_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        p_bLoaded = True

        optResult03.Checked = True
    End Sub

    Private Sub frmCallResult_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        p_bLoaded = False
    End Sub

    Private Sub optResult_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optResult01.CheckedChanged, _
        optResult02.CheckedChanged, optResult03.CheckedChanged, optResult04.CheckedChanged, optResult05.CheckedChanged, _
        optResult06.CheckedChanged, optResult07.CheckedChanged, optResult08.CheckedChanged, optResult00.CheckedChanged

        Dim loButt As RadioButton
        loButt = CType(sender, System.Windows.Forms.RadioButton)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "optResult" Then
            Select Case loIndex
                Case 0 : p_sCallResult = "WN"
                Case 1 : p_sCallResult = "NA"
                Case 2 : p_sCallResult = "UR"
                Case 3 : p_sCallResult = "NI"
                Case 4 : p_sCallResult = "NN"
                Case 5 : p_sCallResult = "PS"
                Case 6 : p_sCallResult = "NC"
                Case 7 : p_sCallResult = "CB"
                Case 8 : p_sCallResult = "AM"
            End Select
        End If
    End Sub
End Class