<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMPModelFeatures
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtField02 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtField01 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtField00 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtOther00 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdOthers01 = New System.Windows.Forms.Button()
        Me.cmdOthers00 = New System.Windows.Forms.Button()
        Me.txtOther01 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.nEntryNox = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sDescript = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdButton05 = New System.Windows.Forms.Button()
        Me.cmdButton04 = New System.Windows.Forms.Button()
        Me.cmdButton03 = New System.Windows.Forms.Button()
        Me.cmdButton02 = New System.Windows.Forms.Button()
        Me.cmdButton01 = New System.Windows.Forms.Button()
        Me.cmdButton06 = New System.Windows.Forms.Button()
        Me.cmdButton07 = New System.Windows.Forms.Button()
        Me.cmdButton08 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtField02)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtField01)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtField00)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(445, 101)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'txtField02
        '
        Me.txtField02.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtField02.Location = New System.Drawing.Point(98, 72)
        Me.txtField02.Name = "txtField02"
        Me.txtField02.ReadOnly = True
        Me.txtField02.Size = New System.Drawing.Size(340, 22)
        Me.txtField02.TabIndex = 6
        Me.txtField02.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Description"
        '
        'txtField01
        '
        Me.txtField01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtField01.Location = New System.Drawing.Point(98, 48)
        Me.txtField01.Name = "txtField01"
        Me.txtField01.ReadOnly = True
        Me.txtField01.Size = New System.Drawing.Size(182, 22)
        Me.txtField01.TabIndex = 4
        Me.txtField01.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Model Code"
        '
        'txtField00
        '
        Me.txtField00.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtField00.Location = New System.Drawing.Point(98, 13)
        Me.txtField00.Name = "txtField00"
        Me.txtField00.ReadOnly = True
        Me.txtField00.Size = New System.Drawing.Size(131, 22)
        Me.txtField00.TabIndex = 1
        Me.txtField00.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Model ID"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Panel1.Location = New System.Drawing.Point(104, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(131, 22)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtOther00)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cmdOthers01)
        Me.GroupBox3.Controls.Add(Me.cmdOthers00)
        Me.GroupBox3.Controls.Add(Me.txtOther01)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 99)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(445, 200)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        '
        'txtOther00
        '
        Me.txtOther00.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOther00.Location = New System.Drawing.Point(98, 11)
        Me.txtOther00.Name = "txtOther00"
        Me.txtOther00.ReadOnly = True
        Me.txtOther00.Size = New System.Drawing.Size(42, 22)
        Me.txtOther00.TabIndex = 10
        Me.txtOther00.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Priority"
        '
        'cmdOthers01
        '
        Me.cmdOthers01.Location = New System.Drawing.Point(363, 11)
        Me.cmdOthers01.Name = "cmdOthers01"
        Me.cmdOthers01.Size = New System.Drawing.Size(75, 23)
        Me.cmdOthers01.TabIndex = 8
        Me.cmdOthers01.TabStop = False
        Me.cmdOthers01.Text = "Remove"
        Me.cmdOthers01.UseVisualStyleBackColor = True
        '
        'cmdOthers00
        '
        Me.cmdOthers00.Location = New System.Drawing.Point(281, 11)
        Me.cmdOthers00.Name = "cmdOthers00"
        Me.cmdOthers00.Size = New System.Drawing.Size(75, 23)
        Me.cmdOthers00.TabIndex = 7
        Me.cmdOthers00.TabStop = False
        Me.cmdOthers00.Text = "Add"
        Me.cmdOthers00.UseVisualStyleBackColor = True
        '
        'txtOther01
        '
        Me.txtOther01.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOther01.Location = New System.Drawing.Point(98, 35)
        Me.txtOther01.MaxLength = 11
        Me.txtOther01.Name = "txtOther01"
        Me.txtOther01.Size = New System.Drawing.Size(340, 22)
        Me.txtOther01.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Description"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nEntryNox, Me.sDescript})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 63)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(432, 130)
        Me.DataGridView1.TabIndex = 0
        '
        'nEntryNox
        '
        Me.nEntryNox.HeaderText = "No."
        Me.nEntryNox.Name = "nEntryNox"
        Me.nEntryNox.ReadOnly = True
        Me.nEntryNox.Width = 40
        '
        'sDescript
        '
        Me.sDescript.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.sDescript.HeaderText = "Features"
        Me.sDescript.Name = "sDescript"
        Me.sDescript.ReadOnly = True
        Me.sDescript.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.sDescript.Width = 387
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdButton05)
        Me.GroupBox2.Controls.Add(Me.cmdButton04)
        Me.GroupBox2.Controls.Add(Me.cmdButton03)
        Me.GroupBox2.Controls.Add(Me.cmdButton02)
        Me.GroupBox2.Controls.Add(Me.cmdButton01)
        Me.GroupBox2.Controls.Add(Me.cmdButton06)
        Me.GroupBox2.Controls.Add(Me.cmdButton07)
        Me.GroupBox2.Controls.Add(Me.cmdButton08)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 294)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(445, 69)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'cmdButton05
        '
        Me.cmdButton05.Image = Global.TeleMarketing.My.Resources.Resources.cancel_update
        Me.cmdButton05.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdButton05.Location = New System.Drawing.Point(386, 10)
        Me.cmdButton05.Name = "cmdButton05"
        Me.cmdButton05.Size = New System.Drawing.Size(53, 53)
        Me.cmdButton05.TabIndex = 4
        Me.cmdButton05.Text = "Cancel"
        Me.cmdButton05.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdButton05.UseVisualStyleBackColor = True
        '
        'cmdButton04
        '
        Me.cmdButton04.Image = Global.TeleMarketing.My.Resources.Resources.browse
        Me.cmdButton04.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdButton04.Location = New System.Drawing.Point(333, 10)
        Me.cmdButton04.Name = "cmdButton04"
        Me.cmdButton04.Size = New System.Drawing.Size(53, 53)
        Me.cmdButton04.TabIndex = 3
        Me.cmdButton04.Text = "Browse"
        Me.cmdButton04.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdButton04.UseVisualStyleBackColor = True
        '
        'cmdButton03
        '
        Me.cmdButton03.Image = Global.TeleMarketing.My.Resources.Resources.search
        Me.cmdButton03.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdButton03.Location = New System.Drawing.Point(280, 10)
        Me.cmdButton03.Name = "cmdButton03"
        Me.cmdButton03.Size = New System.Drawing.Size(53, 53)
        Me.cmdButton03.TabIndex = 2
        Me.cmdButton03.Text = "Search"
        Me.cmdButton03.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdButton03.UseVisualStyleBackColor = True
        '
        'cmdButton02
        '
        Me.cmdButton02.Image = Global.TeleMarketing.My.Resources.Resources.save__2_
        Me.cmdButton02.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdButton02.Location = New System.Drawing.Point(227, 10)
        Me.cmdButton02.Name = "cmdButton02"
        Me.cmdButton02.Size = New System.Drawing.Size(53, 53)
        Me.cmdButton02.TabIndex = 1
        Me.cmdButton02.Text = "Save"
        Me.cmdButton02.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdButton02.UseVisualStyleBackColor = True
        '
        'cmdButton01
        '
        Me.cmdButton01.Image = Global.TeleMarketing.My.Resources.Resources._new
        Me.cmdButton01.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdButton01.Location = New System.Drawing.Point(174, 10)
        Me.cmdButton01.Name = "cmdButton01"
        Me.cmdButton01.Size = New System.Drawing.Size(53, 53)
        Me.cmdButton01.TabIndex = 0
        Me.cmdButton01.Text = "New"
        Me.cmdButton01.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdButton01.UseVisualStyleBackColor = True
        '
        'cmdButton06
        '
        Me.cmdButton06.Image = Global.TeleMarketing.My.Resources.Resources.update
        Me.cmdButton06.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdButton06.Location = New System.Drawing.Point(227, 11)
        Me.cmdButton06.Name = "cmdButton06"
        Me.cmdButton06.Size = New System.Drawing.Size(53, 53)
        Me.cmdButton06.TabIndex = 5
        Me.cmdButton06.Text = "Update"
        Me.cmdButton06.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdButton06.UseVisualStyleBackColor = True
        '
        'cmdButton07
        '
        Me.cmdButton07.Image = Global.TeleMarketing.My.Resources.Resources.omit_item
        Me.cmdButton07.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdButton07.Location = New System.Drawing.Point(280, 11)
        Me.cmdButton07.Name = "cmdButton07"
        Me.cmdButton07.Size = New System.Drawing.Size(53, 53)
        Me.cmdButton07.TabIndex = 6
        Me.cmdButton07.Text = "Delete"
        Me.cmdButton07.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdButton07.UseVisualStyleBackColor = True
        '
        'cmdButton08
        '
        Me.cmdButton08.Image = Global.TeleMarketing.My.Resources.Resources._exit
        Me.cmdButton08.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdButton08.Location = New System.Drawing.Point(386, 11)
        Me.cmdButton08.Name = "cmdButton08"
        Me.cmdButton08.Size = New System.Drawing.Size(53, 53)
        Me.cmdButton08.TabIndex = 7
        Me.cmdButton08.Text = "Close"
        Me.cmdButton08.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdButton08.UseVisualStyleBackColor = True
        '
        'frmMPModelFeatures
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 367)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMPModelFeatures"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MP Model Features"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtField02 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtField01 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtField00 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtOther00 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdOthers01 As System.Windows.Forms.Button
    Friend WithEvents cmdOthers00 As System.Windows.Forms.Button
    Friend WithEvents txtOther01 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdButton05 As System.Windows.Forms.Button
    Friend WithEvents cmdButton04 As System.Windows.Forms.Button
    Friend WithEvents cmdButton03 As System.Windows.Forms.Button
    Friend WithEvents cmdButton02 As System.Windows.Forms.Button
    Friend WithEvents cmdButton01 As System.Windows.Forms.Button
    Friend WithEvents cmdButton06 As System.Windows.Forms.Button
    Friend WithEvents cmdButton07 As System.Windows.Forms.Button
    Friend WithEvents cmdButton08 As System.Windows.Forms.Button
    Friend WithEvents nEntryNox As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sDescript As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
