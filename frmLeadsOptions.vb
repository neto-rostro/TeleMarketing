Public Class frmLeadsOptions
    Dim p_nValue As Integer

    ReadOnly Property Leads()
        Get
            Return p_nValue
        End Get
    End Property

    WriteOnly Property Current
        Set(value)
            p_nValue = value
        End Set
    End Property

    Private Sub cmdButton00_Click(sender As System.Object, e As System.EventArgs) Handles cmdButton00.Click
        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 'ok
                    If RadioButton1.Checked Then
                        p_nValue = 0 'default
                    ElseIf RadioButton2.Checked Then
                        p_nValue = 1 'pre approved
                    ElseIf RadioButton3.Checked Then
                        p_nValue = 2 'mc customers for mp offer
                    ElseIf RadioButton4.Checked Then
                        p_nValue = 3 'credit application
                    Else
                        p_nValue = 4 'custom call
                    End If

                    Me.Close()
            End Select
        End If
    End Sub

    Private Sub cmdButton00_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles cmdButton00.MouseDown
        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 : cmdButton00.BackgroundImage = My.Resources.OK_OnMouseDown
            End Select
        End If
    End Sub

    Private Sub cmdButton00_MouseHover(sender As Object, e As System.EventArgs) Handles cmdButton00.MouseHover
        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 : cmdButton00.BackgroundImage = My.Resources.OK_OnMouseOver
            End Select
        End If
    End Sub

    Private Sub cmdButton00_MouseLeave(sender As Object, e As System.EventArgs) Handles cmdButton00.MouseLeave
        Dim loButt As PictureBox
        loButt = CType(sender, System.Windows.Forms.PictureBox)

        Dim loIndex As Integer
        loIndex = Val(Mid(loButt.Name, 10))

        If Mid(loButt.Name, 1, 9) = "cmdButton" Then
            Select Case loIndex
                Case 0 : cmdButton00.BackgroundImage = My.Resources.OK
            End Select
        End If
    End Sub

    Private Sub frmLeadsOptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If p_nValue = 0 Then
            RadioButton1.Checked = True
        ElseIf p_nValue = 1 Then
            RadioButton2.Checked = True
        ElseIf p_nValue = 2 Then
            RadioButton3.Checked = True
        ElseIf p_nValue = 3 Then
            RadioButton4.Checked = True
        Else
            RadioButton5.Checked = True
        End If
    End Sub
End Class