<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCallManagerRegDetail
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdButton00 = New System.Windows.Forms.Button()
        Me.cmdButton01 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpCall2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpCall1 = New System.Windows.Forms.DateTimePicker()
        Me.chkSchedCall = New System.Windows.Forms.CheckBox()
        Me.txtField06 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtField05 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtField04 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtField03 = New System.Windows.Forms.TextBox()
        Me.txtField02 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtField01 = New System.Windows.Forms.TextBox()
        Me.txtField00 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdButton00)
        Me.GroupBox2.Controls.Add(Me.cmdButton01)
        Me.GroupBox2.Location = New System.Drawing.Point(485, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(89, 273)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        '
        'cmdButton00
        '
        Me.cmdButton00.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdButton00.Image = Global.TeleMarketing.My.Resources.Resources.post
        Me.cmdButton00.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdButton00.Location = New System.Drawing.Point(6, 12)
        Me.cmdButton00.Name = "cmdButton00"
        Me.cmdButton00.Size = New System.Drawing.Size(77, 35)
        Me.cmdButton00.TabIndex = 4
        Me.cmdButton00.TabStop = False
        Me.cmdButton00.Text = "Ok"
        Me.cmdButton00.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdButton00.UseVisualStyleBackColor = True
        '
        'cmdButton01
        '
        Me.cmdButton01.Image = Global.TeleMarketing.My.Resources.Resources._exit
        Me.cmdButton01.Location = New System.Drawing.Point(6, 50)
        Me.cmdButton01.Name = "cmdButton01"
        Me.cmdButton01.Size = New System.Drawing.Size(77, 35)
        Me.cmdButton01.TabIndex = 6
        Me.cmdButton01.TabStop = False
        Me.cmdButton01.Text = "Close"
        Me.cmdButton01.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdButton01.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpCall2)
        Me.GroupBox1.Controls.Add(Me.dtpCall1)
        Me.GroupBox1.Controls.Add(Me.chkSchedCall)
        Me.GroupBox1.Controls.Add(Me.txtField06)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtField05)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtField04)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtField03)
        Me.GroupBox1.Controls.Add(Me.txtField02)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtField01)
        Me.GroupBox1.Controls.Add(Me.txtField00)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 273)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'dtpCall2
        '
        Me.dtpCall2.Checked = False
        Me.dtpCall2.CustomFormat = ""
        Me.dtpCall2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpCall2.Location = New System.Drawing.Point(333, 244)
        Me.dtpCall2.Name = "dtpCall2"
        Me.dtpCall2.Size = New System.Drawing.Size(125, 20)
        Me.dtpCall2.TabIndex = 80
        Me.dtpCall2.Visible = False
        '
        'dtpCall1
        '
        Me.dtpCall1.Checked = False
        Me.dtpCall1.Location = New System.Drawing.Point(120, 244)
        Me.dtpCall1.Name = "dtpCall1"
        Me.dtpCall1.Size = New System.Drawing.Size(207, 20)
        Me.dtpCall1.TabIndex = 79
        Me.dtpCall1.Visible = False
        '
        'chkSchedCall
        '
        Me.chkSchedCall.AutoSize = True
        Me.chkSchedCall.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSchedCall.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkSchedCall.Location = New System.Drawing.Point(17, 247)
        Me.chkSchedCall.Name = "chkSchedCall"
        Me.chkSchedCall.Size = New System.Drawing.Size(105, 17)
        Me.chkSchedCall.TabIndex = 77
        Me.chkSchedCall.Text = "Create Schedule"
        Me.chkSchedCall.UseVisualStyleBackColor = True
        '
        'txtField06
        '
        Me.txtField06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtField06.Enabled = False
        Me.txtField06.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtField06.Location = New System.Drawing.Point(120, 161)
        Me.txtField06.Multiline = True
        Me.txtField06.Name = "txtField06"
        Me.txtField06.ReadOnly = True
        Me.txtField06.Size = New System.Drawing.Size(338, 80)
        Me.txtField06.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(26, 163)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 16)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Remarks"
        '
        'txtField05
        '
        Me.txtField05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtField05.Enabled = False
        Me.txtField05.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtField05.Location = New System.Drawing.Point(120, 137)
        Me.txtField05.Name = "txtField05"
        Me.txtField05.Size = New System.Drawing.Size(165, 22)
        Me.txtField05.TabIndex = 28
        Me.txtField05.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 16)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Status"
        '
        'txtField04
        '
        Me.txtField04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtField04.Enabled = False
        Me.txtField04.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtField04.Location = New System.Drawing.Point(120, 113)
        Me.txtField04.Name = "txtField04"
        Me.txtField04.Size = New System.Drawing.Size(165, 22)
        Me.txtField04.TabIndex = 26
        Me.txtField04.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 16)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Call End"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Call Start"
        '
        'txtField03
        '
        Me.txtField03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtField03.Enabled = False
        Me.txtField03.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtField03.Location = New System.Drawing.Point(120, 89)
        Me.txtField03.Name = "txtField03"
        Me.txtField03.Size = New System.Drawing.Size(165, 22)
        Me.txtField03.TabIndex = 23
        Me.txtField03.TabStop = False
        '
        'txtField02
        '
        Me.txtField02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtField02.Enabled = False
        Me.txtField02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtField02.Location = New System.Drawing.Point(120, 65)
        Me.txtField02.Name = "txtField02"
        Me.txtField02.Size = New System.Drawing.Size(250, 22)
        Me.txtField02.TabIndex = 22
        Me.txtField02.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Agent"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Mobile No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Customer"
        '
        'txtField01
        '
        Me.txtField01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtField01.Enabled = False
        Me.txtField01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtField01.Location = New System.Drawing.Point(120, 41)
        Me.txtField01.Name = "txtField01"
        Me.txtField01.Size = New System.Drawing.Size(165, 22)
        Me.txtField01.TabIndex = 4
        Me.txtField01.TabStop = False
        '
        'txtField00
        '
        Me.txtField00.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtField00.Enabled = False
        Me.txtField00.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtField00.Location = New System.Drawing.Point(120, 13)
        Me.txtField00.Name = "txtField00"
        Me.txtField00.ReadOnly = True
        Me.txtField00.Size = New System.Drawing.Size(338, 22)
        Me.txtField00.TabIndex = 1
        Me.txtField00.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Panel1.Location = New System.Drawing.Point(126, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(335, 22)
        Me.Panel1.TabIndex = 2
        '
        'frmCallManagerRegDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 290)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmCallManagerRegDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Call Out Going History Detail"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdButton00 As System.Windows.Forms.Button
    Friend WithEvents cmdButton01 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtField01 As System.Windows.Forms.TextBox
    Friend WithEvents txtField00 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtField03 As System.Windows.Forms.TextBox
    Friend WithEvents txtField02 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtField06 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtField05 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtField04 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkSchedCall As System.Windows.Forms.CheckBox
    Friend WithEvents dtpCall1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpCall2 As System.Windows.Forms.DateTimePicker
End Class
