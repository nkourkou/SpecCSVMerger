<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.chkShowPath = New System.Windows.Forms.CheckBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblhowmanyfiles = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.radioxyxy = New System.Windows.Forms.RadioButton()
        Me.radioxyyy = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.radio_filename = New System.Windows.Forms.RadioButton()
        Me.radio_relpath = New System.Windows.Forms.RadioButton()
        Me.radio_wholepath = New System.Windows.Forms.RadioButton()
        Me.StatusStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(0, 59)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(389, 497)
        Me.TreeView1.TabIndex = 0
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(12, 12)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(135, 40)
        Me.btn1.TabIndex = 1
        Me.btn1.Text = "Open folder..."
        Me.btn1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(189, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(200, 40)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Assemble selected files >>"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(395, 485)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(533, 71)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Merge CSV"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Location = New System.Drawing.Point(395, 59)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(533, 264)
        Me.ListBox1.TabIndex = 4
        '
        'chkShowPath
        '
        Me.chkShowPath.AutoSize = True
        Me.chkShowPath.Location = New System.Drawing.Point(398, 22)
        Me.chkShowPath.Name = "chkShowPath"
        Me.chkShowPath.Size = New System.Drawing.Size(131, 24)
        Me.chkShowPath.TabIndex = 5
        Me.chkShowPath.Text = "Only Filenames"
        Me.chkShowPath.UseVisualStyleBackColor = True
        Me.chkShowPath.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 559)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(940, 26)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(86, 20)
        Me.ToolStripStatusLabel1.Text = "NK (c) 2023"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 18)
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(325, 20)
        Me.ToolStripStatusLabel2.Text = "                                                                               "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(456, 452)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(472, 27)
        Me.TextBox1.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(395, 455)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Output:"
        '
        'lblhowmanyfiles
        '
        Me.lblhowmanyfiles.Location = New System.Drawing.Point(731, 32)
        Me.lblhowmanyfiles.Name = "lblhowmanyfiles"
        Me.lblhowmanyfiles.Size = New System.Drawing.Size(197, 24)
        Me.lblhowmanyfiles.TabIndex = 12
        Me.lblhowmanyfiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.radioxyxy)
        Me.GroupBox1.Controls.Add(Me.radioxyyy)
        Me.GroupBox1.Location = New System.Drawing.Point(697, 329)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 108)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Export CSV columns"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 20)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "X: wavenumber, Y: intensity"
        '
        'radioxyxy
        '
        Me.radioxyxy.AutoSize = True
        Me.radioxyxy.Location = New System.Drawing.Point(17, 50)
        Me.radioxyxy.Name = "radioxyxy"
        Me.radioxyxy.Size = New System.Drawing.Size(145, 24)
        Me.radioxyxy.TabIndex = 12
        Me.radioxyxy.TabStop = True
        Me.radioxyxy.Text = "X,Y,X,Y,X,Y format"
        Me.radioxyxy.UseVisualStyleBackColor = True
        '
        'radioxyyy
        '
        Me.radioxyyy.AutoSize = True
        Me.radioxyyy.Location = New System.Drawing.Point(17, 26)
        Me.radioxyyy.Name = "radioxyyy"
        Me.radioxyyy.Size = New System.Drawing.Size(143, 24)
        Me.radioxyyy.TabIndex = 11
        Me.radioxyyy.TabStop = True
        Me.radioxyyy.Text = "X,Y,Y,Y,Y,Y format"
        Me.radioxyyy.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.radio_filename)
        Me.GroupBox2.Controls.Add(Me.radio_relpath)
        Me.GroupBox2.Controls.Add(Me.radio_wholepath)
        Me.GroupBox2.Location = New System.Drawing.Point(398, 329)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(231, 108)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Export CSV header columns"
        '
        'radio_filename
        '
        Me.radio_filename.AutoSize = True
        Me.radio_filename.Location = New System.Drawing.Point(16, 78)
        Me.radio_filename.Name = "radio_filename"
        Me.radio_filename.Size = New System.Drawing.Size(90, 24)
        Me.radio_filename.TabIndex = 6
        Me.radio_filename.Text = "Filename"
        Me.radio_filename.UseVisualStyleBackColor = True
        '
        'radio_relpath
        '
        Me.radio_relpath.AutoSize = True
        Me.radio_relpath.Location = New System.Drawing.Point(16, 50)
        Me.radio_relpath.Name = "radio_relpath"
        Me.radio_relpath.Size = New System.Drawing.Size(187, 24)
        Me.radio_relpath.TabIndex = 5
        Me.radio_relpath.Text = "Filename (relative path)"
        Me.radio_relpath.UseVisualStyleBackColor = True
        '
        'radio_wholepath
        '
        Me.radio_wholepath.AutoSize = True
        Me.radio_wholepath.Location = New System.Drawing.Point(16, 20)
        Me.radio_wholepath.Name = "radio_wholepath"
        Me.radio_wholepath.Size = New System.Drawing.Size(128, 24)
        Me.radio_wholepath.TabIndex = 4
        Me.radio_wholepath.Text = "Path\Filename "
        Me.radio_wholepath.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 585)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblhowmanyfiles)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.chkShowPath)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.TreeView1)
        Me.Name = "Form1"
        Me.Text = "Spectra CSV merger (ENLIGHTEN spectroscopy software files)"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents btn1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents chkShowPath As CheckBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblhowmanyfiles As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents radioxyxy As RadioButton
    Friend WithEvents radioxyyy As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents radio_filename As RadioButton
    Friend WithEvents radio_relpath As RadioButton
    Friend WithEvents radio_wholepath As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
End Class
