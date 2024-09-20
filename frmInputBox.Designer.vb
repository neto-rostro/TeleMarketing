<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.cmdButton02 = New System.Windows.Forms.Button()
        Me.cmdButton05 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(428, 172)
        Me.TextBox1.TabIndex = 0
        '
        'cmdButton02
        '
        Me.cmdButton02.Image = Global.TeleMarketing.My.Resources.Resources.save__2_
        Me.cmdButton02.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdButton02.Location = New System.Drawing.Point(335, 190)
        Me.cmdButton02.Name = "cmdButton02"
        Me.cmdButton02.Size = New System.Drawing.Size(53, 53)
        Me.cmdButton02.TabIndex = 2
        Me.cmdButton02.Text = "Okay"
        Me.cmdButton02.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdButton02.UseVisualStyleBackColor = True
        '
        'cmdButton05
        '
        Me.cmdButton05.Image = Global.TeleMarketing.My.Resources.Resources.cancel_update
        Me.cmdButton05.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdButton05.Location = New System.Drawing.Point(387, 190)
        Me.cmdButton05.Name = "cmdButton05"
        Me.cmdButton05.Size = New System.Drawing.Size(53, 53)
        Me.cmdButton05.TabIndex = 5
        Me.cmdButton05.Text = "Cancel"
        Me.cmdButton05.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdButton05.UseVisualStyleBackColor = True
        '
        'frmInputBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 249)
        Me.Controls.Add(Me.cmdButton05)
        Me.Controls.Add(Me.cmdButton02)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInputBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Input Notes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents cmdButton02 As Button
    Friend WithEvents cmdButton05 As Button
End Class
