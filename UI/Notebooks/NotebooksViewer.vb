Public Class NotebooksViewer
  Inherits Panel

  Friend WithEvents RichTextBox1 As RichTextBox
  Friend WithEvents ToolStrip1 As ToolStrip
  Friend WithEvents ToolStripButton6 As ToolStripButton
  Friend WithEvents pnlNotebookPage As Panel
  Friend WithEvents pnlStretch As JPanel
  Friend WithEvents txtNotebookPageTitle As TextBox
  Friend WithEvents Panel2 As Panel
  Friend WithEvents lblStretch As Label
  Friend WithEvents SplitContainer1 As SplitContainer
  Friend WithEvents TreeView1 As TreeView
  Friend WithEvents ToolStrip2 As ToolStrip
  Friend WithEvents ToolStripButton10 As ToolStripButton

  Public Sub New()
    SetStyle(ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer, True)

    SplitContainer1 = New System.Windows.Forms.SplitContainer()
    TreeView1 = New System.Windows.Forms.TreeView()
    ToolStrip1 = New System.Windows.Forms.ToolStrip()
    ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
    Panel2 = New System.Windows.Forms.Panel()
    RichTextBox1 = New System.Windows.Forms.RichTextBox()
    pnlNotebookPage = New System.Windows.Forms.Panel()
    pnlStretch = New AncestryAssistant.JPanel()
    txtNotebookPageTitle = New System.Windows.Forms.TextBox()
    lblStretch = New System.Windows.Forms.Label()
    ToolStrip2 = New System.Windows.Forms.ToolStrip()
    ToolStripButton10 = New System.Windows.Forms.ToolStripButton()


    SuspendLayout()
    CType(SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
    SplitContainer1.Panel1.SuspendLayout()
    SplitContainer1.Panel2.SuspendLayout()
    SplitContainer1.SuspendLayout()
    ToolStrip1.SuspendLayout()
    Panel2.SuspendLayout()
    pnlNotebookPage.SuspendLayout()
    pnlStretch.SuspendLayout()
    ToolStrip2.SuspendLayout()

    Dock = DockStyle.Fill
    Controls.Add(SplitContainer1)

    '
    'SplitContainer1
    '
    SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    SplitContainer1.Location = New System.Drawing.Point(0, 0)
    SplitContainer1.Name = "SplitContainer1"
    '
    'SplitContainer1.Panel1
    '
    SplitContainer1.Panel1.Controls.Add(TreeView1)
    SplitContainer1.Panel1.Controls.Add(ToolStrip1)
    '
    'SplitContainer1.Panel2
    '
    SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
    SplitContainer1.Panel2.Controls.Add(Panel2)
    SplitContainer1.Panel2.Controls.Add(pnlNotebookPage)
    SplitContainer1.Panel2.Controls.Add(ToolStrip2)
    SplitContainer1.Size = New System.Drawing.Size(348, 313)
    SplitContainer1.SplitterDistance = 102
    SplitContainer1.TabIndex = 4
    '
    'TreeView1
    '
    TreeView1.BackColor = System.Drawing.SystemColors.Control
    TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
    TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
    TreeView1.Location = New System.Drawing.Point(0, 25)
    TreeView1.Name = "TreeView1"
    TreeView1.Size = New System.Drawing.Size(102, 288)
    TreeView1.TabIndex = 0
    '
    'ToolStrip1
    '
    ToolStrip1.CanOverflow = False
    ToolStrip1.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {ToolStripButton6})
    ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
    ToolStrip1.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
    ToolStrip1.Name = "ToolStrip1"
    ToolStrip1.Padding = New System.Windows.Forms.Padding(4, 0, 16, 0)
    ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
    ToolStrip1.Size = New System.Drawing.Size(102, 25)
    ToolStrip1.Stretch = True
    ToolStrip1.TabIndex = 5
    '
    'ToolStripButton6
    '
    ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    ToolStripButton6.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__191
    ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
    ToolStripButton6.Name = "ToolStripButton6"
    ToolStripButton6.Size = New System.Drawing.Size(23, 22)
    ToolStripButton6.Text = "ToolStripButton1"
    ToolStripButton6.ToolTipText = "Refresh"
    '
    'Panel2
    '
    Panel2.Controls.Add(RichTextBox1)
    Panel2.Dock = System.Windows.Forms.DockStyle.Fill
    Panel2.Location = New System.Drawing.Point(0, 75)
    Panel2.Name = "Panel2"
    Panel2.Padding = New System.Windows.Forms.Padding(20, 20, 20, 0)
    Panel2.Size = New System.Drawing.Size(242, 238)
    Panel2.TabIndex = 7
    '
    'RichTextBox1
    '
    RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
    RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
    RichTextBox1.Location = New System.Drawing.Point(20, 20)
    RichTextBox1.Name = "RichTextBox1"
    RichTextBox1.Size = New System.Drawing.Size(202, 218)
    RichTextBox1.TabIndex = 5
    RichTextBox1.Text = ""
    '
    'pnlNotebookPage
    '
    pnlNotebookPage.Controls.Add(pnlStretch)
    pnlNotebookPage.Dock = System.Windows.Forms.DockStyle.Top
    pnlNotebookPage.Location = New System.Drawing.Point(0, 25)
    pnlNotebookPage.MaximumSize = New System.Drawing.Size(0, 50)
    pnlNotebookPage.MinimumSize = New System.Drawing.Size(0, 50)
    pnlNotebookPage.Name = "pnlNotebookPage"
    pnlNotebookPage.Padding = New System.Windows.Forms.Padding(25, 0, 0, 0)
    pnlNotebookPage.Size = New System.Drawing.Size(242, 50)
    pnlNotebookPage.TabIndex = 6
    '
    'pnlStretch
    '
    pnlStretch.AutoSize = True
    pnlStretch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    pnlStretch.BorderColor = System.Drawing.Color.Transparent
    pnlStretch.BorderColorBottom = System.Drawing.Color.Black
    pnlStretch.BorderColorLeft = System.Drawing.Color.Black
    pnlStretch.BorderColorRight = System.Drawing.Color.Black
    pnlStretch.BorderColorTop = System.Drawing.Color.Black
    pnlStretch.BorderWidth = New System.Windows.Forms.Padding(0, 0, 0, 2)
    pnlStretch.Controls.Add(txtNotebookPageTitle)
    pnlStretch.Controls.Add(lblStretch)
    pnlStretch.CornerRadius = New System.Windows.Forms.Padding(0)
    pnlStretch.Dock = System.Windows.Forms.DockStyle.Left
    pnlStretch.Location = New System.Drawing.Point(25, 0)
    pnlStretch.MinimumSize = New System.Drawing.Size(200, 0)
    pnlStretch.Name = "pnlStretch"
    pnlStretch.Padding = New System.Windows.Forms.Padding(10, 15, 0, 3)
    pnlStretch.Size = New System.Drawing.Size(210, 50)
    pnlStretch.TabIndex = 0
    '
    'txtNotebookPageTitle
    '
    txtNotebookPageTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
    txtNotebookPageTitle.Dock = System.Windows.Forms.DockStyle.Fill
    txtNotebookPageTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    txtNotebookPageTitle.Location = New System.Drawing.Point(10, 15)
    txtNotebookPageTitle.MaxLength = 90
    txtNotebookPageTitle.MinimumSize = New System.Drawing.Size(200, 0)
    txtNotebookPageTitle.Name = "txtNotebookPageTitle"
    txtNotebookPageTitle.Size = New System.Drawing.Size(200, 25)
    txtNotebookPageTitle.TabIndex = 0
    txtNotebookPageTitle.Text = "New Page"
    '
    'lblStretch
    '
    lblStretch.AutoSize = True
    lblStretch.Dock = System.Windows.Forms.DockStyle.Fill
    lblStretch.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold)
    lblStretch.ForeColor = System.Drawing.Color.White
    lblStretch.Location = New System.Drawing.Point(10, 15)
    lblStretch.MinimumSize = New System.Drawing.Size(200, 0)
    lblStretch.Name = "lblStretch"
    lblStretch.Size = New System.Drawing.Size(200, 25)
    lblStretch.TabIndex = 1
    lblStretch.Text = "New Page"
    '
    'ToolStrip2
    '
    ToolStrip2.CanOverflow = False
    ToolStrip2.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {ToolStripButton10})
    ToolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
    ToolStrip2.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
    ToolStrip2.Name = "ToolStrip2"
    ToolStrip2.Padding = New System.Windows.Forms.Padding(4, 0, 16, 0)
    ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
    ToolStrip2.Size = New System.Drawing.Size(242, 25)
    ToolStrip2.Stretch = True
    ToolStrip2.TabIndex = 4
    '
    'ToolStripButton10
    '
    ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    ToolStripButton10.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__191
    ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
    ToolStripButton10.Name = "ToolStripButton10"
    ToolStripButton10.Size = New System.Drawing.Size(23, 22)
    ToolStripButton10.Text = "ToolStripButton1"
    ToolStripButton10.ToolTipText = "Refresh"

    SplitContainer1.Panel1.ResumeLayout(False)
    SplitContainer1.Panel1.PerformLayout()
    SplitContainer1.Panel2.ResumeLayout(False)
    SplitContainer1.Panel2.PerformLayout()
    CType(SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
    SplitContainer1.ResumeLayout(False)
    ToolStrip1.ResumeLayout(False)
    ToolStrip1.PerformLayout()
    Panel2.ResumeLayout(False)
    pnlNotebookPage.ResumeLayout(False)
    pnlNotebookPage.PerformLayout()
    pnlStretch.ResumeLayout(False)
    pnlStretch.PerformLayout()
    ToolStrip2.ResumeLayout(False)
    ToolStrip2.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Private Sub txtNotebookPageTitle_TextChanged(sender As Object, e As EventArgs) Handles txtNotebookPageTitle.TextChanged
    lblStretch.Text = txtNotebookPageTitle.Text
  End Sub

End Class
