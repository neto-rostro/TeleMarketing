Option Explicit On

Public Class frmShowMsg
    Private p_sMsgAlert As String
    Private p_bCancelld As Boolean
    Private p_vMsgStyle As MsgBoxStyle

    WriteOnly Property Msg() As String
        Set(value As String)
            p_sMsgAlert = value
        End Set
    End Property

    WriteOnly Property MsgStyle() As MsgBoxStyle
        Set(value As MsgBoxStyle)
            p_vMsgStyle = value
        End Set
    End Property

    ReadOnly Property Cancelled() As Boolean
        Get
            Return p_bCancelld
        End Get
    End Property

    Private Sub frmShowMsg_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label1.Text = p_sMsgAlert
    End Sub

    Private Sub cmdButton_MouseClick(sender As System.Object, e As System.EventArgs) Handles cmdButton02.Click, _
       cmdButton01.Click, cmdButton00.Click

        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 'ok
                    p_bCancelld = False
                Case 1, 2 'cancel, close
                    p_bCancelld = True
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
End Class