<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowMsgOk
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdButton00 = New System.Windows.Forms.PictureBox()
        Me.cmdButton02 = New System.Windows.Forms.PictureBox()
        CType(Me.cmdButton00, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdButton02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(408, 75)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "The quick brown fox jumps over the lazy dog."
        '
        'cmdButton00
        '
        Me.cmdButton00.BackColor = System.Drawing.Color.Transparent
        Me.cmdButton00.BackgroundImage = Global.TeleMarketing.My.Resources.Resources.OK
        Me.cmdButton00.Location = New System.Drawing.Point(339, 134)
        Me.cmdButton00.Name = "cmdButton00"
        Me.cmdButton00.Size = New System.Drawing.Size(81, 27)
        Me.cmdButton00.TabIndex = 89
        Me.cmdButton00.TabStop = False
        '
        'cmdButton02
        '
        Me.cmdButton02.BackColor = System.Drawing.Color.Transparent
        Me.cmdButton02.BackgroundImage = Global.TeleMarketing.My.Resources.Resources.Close_Small
        Me.cmdButton02.Location = New System.Drawing.Point(409, 7)
        Me.cmdButton02.Name = "cmdButton02"
        Me.cmdButton02.Size = New System.Drawing.Size(16, 17)
        Me.cmdButton02.TabIndex = 88
        Me.cmdButton02.TabStop = False
        '
        'frmShowMsgOk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.TeleMarketing.My.Resources.Resources.Msgbox
        Me.ClientSize = New System.Drawing.Size(432, 173)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdButton00)
        Me.Controls.Add(Me.cmdButton02)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmShowMsgOk"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.cmdButton00, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdButton02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdButton00 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdButton02 As System.Windows.Forms.PictureBox
End Class
