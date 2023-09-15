<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCallResult
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
        Me.cmdButton02 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.optResult02 = New System.Windows.Forms.RadioButton()
        Me.optResult01 = New System.Windows.Forms.RadioButton()
        Me.optResult00 = New System.Windows.Forms.RadioButton()
        Me.optResult08 = New System.Windows.Forms.RadioButton()
        Me.optResult07 = New System.Windows.Forms.RadioButton()
        Me.optResult06 = New System.Windows.Forms.RadioButton()
        Me.optResult05 = New System.Windows.Forms.RadioButton()
        Me.optResult04 = New System.Windows.Forms.RadioButton()
        Me.optResult03 = New System.Windows.Forms.RadioButton()
        Me.cmdButton00 = New System.Windows.Forms.PictureBox()
        Me.cmdButton01 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dtpCall2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpCall1 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.cmdButton02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.cmdButton00, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdButton01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdButton02
        '
        Me.cmdButton02.BackColor = System.Drawing.Color.Transparent
        Me.cmdButton02.BackgroundImage = Global.TeleMarketing.My.Resources.Resources.Close_Small
        Me.cmdButton02.Location = New System.Drawing.Point(412, 5)
        Me.cmdButton02.Name = "cmdButton02"
        Me.cmdButton02.Size = New System.Drawing.Size(16, 17)
        Me.cmdButton02.TabIndex = 0
        Me.cmdButton02.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.optResult02)
        Me.Panel1.Controls.Add(Me.optResult01)
        Me.Panel1.Controls.Add(Me.optResult00)
        Me.Panel1.Controls.Add(Me.optResult08)
        Me.Panel1.Controls.Add(Me.optResult07)
        Me.Panel1.Controls.Add(Me.optResult06)
        Me.Panel1.Controls.Add(Me.optResult05)
        Me.Panel1.Controls.Add(Me.optResult04)
        Me.Panel1.Controls.Add(Me.optResult03)
        Me.Panel1.Location = New System.Drawing.Point(130, 171)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(291, 252)
        Me.Panel1.TabIndex = 82
        '
        'optResult02
        '
        Me.optResult02.AutoSize = True
        Me.optResult02.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optResult02.ForeColor = System.Drawing.Color.White
        Me.optResult02.Location = New System.Drawing.Point(12, 220)
        Me.optResult02.Name = "optResult02"
        Me.optResult02.Size = New System.Drawing.Size(191, 23)
        Me.optResult02.TabIndex = 10
        Me.optResult02.TabStop = True
        Me.optResult02.Text = "CANNOT BE REACHED"
        Me.optResult02.UseVisualStyleBackColor = True
        '
        'optResult01
        '
        Me.optResult01.AutoSize = True
        Me.optResult01.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optResult01.ForeColor = System.Drawing.Color.White
        Me.optResult01.Location = New System.Drawing.Point(12, 191)
        Me.optResult01.Name = "optResult01"
        Me.optResult01.Size = New System.Drawing.Size(119, 23)
        Me.optResult01.TabIndex = 9
        Me.optResult01.TabStop = True
        Me.optResult01.Text = "NO ANSWER"
        Me.optResult01.UseVisualStyleBackColor = True
        '
        'optResult00
        '
        Me.optResult00.AutoSize = True
        Me.optResult00.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optResult00.ForeColor = System.Drawing.Color.White
        Me.optResult00.Location = New System.Drawing.Point(12, 164)
        Me.optResult00.Name = "optResult00"
        Me.optResult00.Size = New System.Drawing.Size(125, 21)
        Me.optResult00.TabIndex = 6
        Me.optResult00.TabStop = True
        Me.optResult00.Text = "Wrong Number"
        Me.optResult00.UseVisualStyleBackColor = True
        '
        'optResult08
        '
        Me.optResult08.AutoSize = True
        Me.optResult08.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optResult08.ForeColor = System.Drawing.Color.White
        Me.optResult08.Location = New System.Drawing.Point(12, 137)
        Me.optResult08.Name = "optResult08"
        Me.optResult08.Size = New System.Drawing.Size(151, 21)
        Me.optResult08.TabIndex = 5
        Me.optResult08.TabStop = True
        Me.optResult08.Text = "Answering Machine"
        Me.optResult08.UseVisualStyleBackColor = True
        '
        'optResult07
        '
        Me.optResult07.AutoSize = True
        Me.optResult07.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optResult07.ForeColor = System.Drawing.Color.White
        Me.optResult07.Location = New System.Drawing.Point(12, 110)
        Me.optResult07.Name = "optResult07"
        Me.optResult07.Size = New System.Drawing.Size(87, 21)
        Me.optResult07.TabIndex = 4
        Me.optResult07.TabStop = True
        Me.optResult07.Text = "Call Back"
        Me.optResult07.UseVisualStyleBackColor = True
        '
        'optResult06
        '
        Me.optResult06.AutoSize = True
        Me.optResult06.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optResult06.ForeColor = System.Drawing.Color.White
        Me.optResult06.Location = New System.Drawing.Point(12, 83)
        Me.optResult06.Name = "optResult06"
        Me.optResult06.Size = New System.Drawing.Size(109, 21)
        Me.optResult06.TabIndex = 3
        Me.optResult06.TabStop = True
        Me.optResult06.Text = "No Capacity"
        Me.optResult06.UseVisualStyleBackColor = True
        '
        'optResult05
        '
        Me.optResult05.AutoSize = True
        Me.optResult05.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optResult05.ForeColor = System.Drawing.Color.White
        Me.optResult05.Location = New System.Drawing.Point(12, 56)
        Me.optResult05.Name = "optResult05"
        Me.optResult05.Size = New System.Drawing.Size(111, 21)
        Me.optResult05.TabIndex = 2
        Me.optResult05.TabStop = True
        Me.optResult05.Text = "Possible Sales"
        Me.optResult05.UseVisualStyleBackColor = True
        '
        'optResult04
        '
        Me.optResult04.AutoSize = True
        Me.optResult04.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optResult04.ForeColor = System.Drawing.Color.White
        Me.optResult04.Location = New System.Drawing.Point(12, 29)
        Me.optResult04.Name = "optResult04"
        Me.optResult04.Size = New System.Drawing.Size(85, 21)
        Me.optResult04.TabIndex = 1
        Me.optResult04.TabStop = True
        Me.optResult04.Text = "Not Now"
        Me.optResult04.UseVisualStyleBackColor = True
        '
        'optResult03
        '
        Me.optResult03.AutoSize = True
        Me.optResult03.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optResult03.ForeColor = System.Drawing.Color.White
        Me.optResult03.Location = New System.Drawing.Point(12, 2)
        Me.optResult03.Name = "optResult03"
        Me.optResult03.Size = New System.Drawing.Size(117, 21)
        Me.optResult03.TabIndex = 0
        Me.optResult03.TabStop = True
        Me.optResult03.Text = "Not Interested"
        Me.optResult03.UseVisualStyleBackColor = True
        '
        'cmdButton00
        '
        Me.cmdButton00.BackColor = System.Drawing.Color.Transparent
        Me.cmdButton00.BackgroundImage = Global.TeleMarketing.My.Resources.Resources.OK
        Me.cmdButton00.Location = New System.Drawing.Point(253, 461)
        Me.cmdButton00.Name = "cmdButton00"
        Me.cmdButton00.Size = New System.Drawing.Size(81, 27)
        Me.cmdButton00.TabIndex = 84
        Me.cmdButton00.TabStop = False
        '
        'cmdButton01
        '
        Me.cmdButton01.BackColor = System.Drawing.Color.Transparent
        Me.cmdButton01.BackgroundImage = Global.TeleMarketing.My.Resources.Resources.Cancel
        Me.cmdButton01.Location = New System.Drawing.Point(340, 461)
        Me.cmdButton01.Name = "cmdButton01"
        Me.cmdButton01.Size = New System.Drawing.Size(81, 27)
        Me.cmdButton01.TabIndex = 85
        Me.cmdButton01.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.dtpCall2)
        Me.Panel2.Controls.Add(Me.dtpCall1)
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(10, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(411, 80)
        Me.Panel2.TabIndex = 86
        '
        'dtpCall2
        '
        Me.dtpCall2.Checked = False
        Me.dtpCall2.CustomFormat = ""
        Me.dtpCall2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpCall2.Location = New System.Drawing.Point(317, 52)
        Me.dtpCall2.Name = "dtpCall2"
        Me.dtpCall2.Size = New System.Drawing.Size(93, 20)
        Me.dtpCall2.TabIndex = 88
        '
        'dtpCall1
        '
        Me.dtpCall1.Checked = False
        Me.dtpCall1.Location = New System.Drawing.Point(119, 52)
        Me.dtpCall1.Name = "dtpCall1"
        Me.dtpCall1.Size = New System.Drawing.Size(195, 20)
        Me.dtpCall1.TabIndex = 87
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(119, 28)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(291, 20)
        Me.TextBox2.TabIndex = 86
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(119, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(291, 20)
        Me.TextBox1.TabIndex = 85
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Date Transact"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 17)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Branch Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 17)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "Recipient Name"
        '
        'frmCallResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.TeleMarketing.My.Resources.Resources.Client_Concern
        Me.ClientSize = New System.Drawing.Size(432, 504)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cmdButton01)
        Me.Controls.Add(Me.cmdButton00)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cmdButton02)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCallResult"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCallResult"
        CType(Me.cmdButton02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cmdButton00, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdButton01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdButton02 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents optResult00 As System.Windows.Forms.RadioButton
    Friend WithEvents optResult08 As System.Windows.Forms.RadioButton
    Friend WithEvents optResult07 As System.Windows.Forms.RadioButton
    Friend WithEvents optResult06 As System.Windows.Forms.RadioButton
    Friend WithEvents optResult05 As System.Windows.Forms.RadioButton
    Friend WithEvents optResult04 As System.Windows.Forms.RadioButton
    Friend WithEvents optResult03 As System.Windows.Forms.RadioButton
    Friend WithEvents cmdButton00 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdButton01 As System.Windows.Forms.PictureBox
    Friend WithEvents optResult02 As System.Windows.Forms.RadioButton
    Friend WithEvents optResult01 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dtpCall2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCall1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
