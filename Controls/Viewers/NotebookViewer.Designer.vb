<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NotebookViewer
  Inherits System.Windows.Forms.UserControl

  'UserControl overrides dispose to clean up the component list.
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
    Me.components = New System.ComponentModel.Container()
    Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("My First Page")
    Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Welcome Section", New System.Windows.Forms.TreeNode() {TreeNode4})
    Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Last, First - YYYY", New System.Windows.Forms.TreeNode() {TreeNode5})
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NotebookViewer))
    Me.SplitSectionsPage = New System.Windows.Forms.SplitContainer()
    Me.TreeSectionPages = New System.Windows.Forms.TreeView()
    Me.imgSection = New System.Windows.Forms.ImageList(Me.components)
    Me.tsSections = New System.Windows.Forms.ToolStrip()
    Me.BtnAddSection = New System.Windows.Forms.ToolStripButton()
    Me.BtnAddPage = New System.Windows.Forms.ToolStripButton()
    Me.PnlBody = New System.Windows.Forms.Panel()
    Me.TxtBody = New System.Windows.Forms.RichTextBox()
    Me.PnlHeader = New System.Windows.Forms.Panel()
    Me.PnlHeaderStretch = New AncestryAssistant.JPanel()
    Me.TxtHeader = New System.Windows.Forms.TextBox()
    Me.LblStretch = New System.Windows.Forms.Label()
    Me.tsPage = New System.Windows.Forms.ToolStrip()
    Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
    Me.BtnH1 = New System.Windows.Forms.ToolStripMenuItem()
    Me.BtnH2 = New System.Windows.Forms.ToolStripMenuItem()
    Me.BtnH3 = New System.Windows.Forms.ToolStripMenuItem()
    Me.BtnH4 = New System.Windows.Forms.ToolStripMenuItem()
    CType(Me.SplitSectionsPage, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitSectionsPage.Panel1.SuspendLayout()
    Me.SplitSectionsPage.Panel2.SuspendLayout()
    Me.SplitSectionsPage.SuspendLayout()
    Me.tsSections.SuspendLayout()
    Me.PnlBody.SuspendLayout()
    Me.PnlHeader.SuspendLayout()
    Me.PnlHeaderStretch.SuspendLayout()
    Me.tsPage.SuspendLayout()
    Me.SuspendLayout()
    '
    'SplitSectionsPage
    '
    Me.SplitSectionsPage.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitSectionsPage.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
    Me.SplitSectionsPage.Location = New System.Drawing.Point(0, 0)
    Me.SplitSectionsPage.Name = "SplitSectionsPage"
    '
    'SplitSectionsPage.Panel1
    '
    Me.SplitSectionsPage.Panel1.Controls.Add(Me.TreeSectionPages)
    Me.SplitSectionsPage.Panel1.Controls.Add(Me.tsSections)
    '
    'SplitSectionsPage.Panel2
    '
    Me.SplitSectionsPage.Panel2.BackColor = System.Drawing.Color.White
    Me.SplitSectionsPage.Panel2.Controls.Add(Me.PnlBody)
    Me.SplitSectionsPage.Panel2.Controls.Add(Me.PnlHeader)
    Me.SplitSectionsPage.Panel2.Controls.Add(Me.tsPage)
    Me.SplitSectionsPage.Size = New System.Drawing.Size(654, 435)
    Me.SplitSectionsPage.SplitterDistance = 102
    Me.SplitSectionsPage.TabIndex = 4
    '
    'TreeSectionPages
    '
    Me.TreeSectionPages.BackColor = System.Drawing.SystemColors.Control
    Me.TreeSectionPages.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TreeSectionPages.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TreeSectionPages.ImageIndex = 2
    Me.TreeSectionPages.ImageList = Me.imgSection
    Me.TreeSectionPages.Location = New System.Drawing.Point(0, 25)
    Me.TreeSectionPages.Name = "TreeSectionPages"
    TreeNode4.ImageKey = "PAGE"
    TreeNode4.Name = "Node2"
    TreeNode4.SelectedImageKey = "PAGE"
    TreeNode4.StateImageKey = "(none)"
    TreeNode4.Text = "My First Page"
    TreeNode5.ImageKey = "SECTION"
    TreeNode5.Name = "Node1"
    TreeNode5.SelectedImageKey = "SECTION"
    TreeNode5.StateImageKey = "(none)"
    TreeNode5.Text = "Welcome Section"
    TreeNode6.ImageKey = "SECTIONS"
    TreeNode6.Name = "Node0"
    TreeNode6.SelectedImageKey = "SECTIONS"
    TreeNode6.Text = "Last, First - YYYY"
    Me.TreeSectionPages.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode6})
    Me.TreeSectionPages.SelectedImageIndex = 0
    Me.TreeSectionPages.ShowLines = False
    Me.TreeSectionPages.ShowNodeToolTips = True
    Me.TreeSectionPages.ShowRootLines = False
    Me.TreeSectionPages.Size = New System.Drawing.Size(102, 410)
    Me.TreeSectionPages.StateImageList = Me.imgSection
    Me.TreeSectionPages.TabIndex = 0
    '
    'imgSection
    '
    Me.imgSection.ImageStream = CType(resources.GetObject("imgSection.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.imgSection.TransparentColor = System.Drawing.Color.Transparent
    Me.imgSection.Images.SetKeyName(0, "SECTIONS")
    Me.imgSection.Images.SetKeyName(1, "SECTION")
    Me.imgSection.Images.SetKeyName(2, "PAGE")
    '
    'tsSections
    '
    Me.tsSections.CanOverflow = False
    Me.tsSections.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.tsSections.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.tsSections.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnAddSection, Me.BtnAddPage})
    Me.tsSections.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
    Me.tsSections.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
    Me.tsSections.Name = "tsSections"
    Me.tsSections.Padding = New System.Windows.Forms.Padding(4, 0, 16, 0)
    Me.tsSections.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
    Me.tsSections.Size = New System.Drawing.Size(102, 25)
    Me.tsSections.Stretch = True
    Me.tsSections.TabIndex = 5
    '
    'BtnAddSection
    '
    Me.BtnAddSection.AutoToolTip = False
    Me.BtnAddSection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.BtnAddSection.Image = Global.AncestryAssistant.My.Resources.Resources.FOLDER_PLUS_ICO20
    Me.BtnAddSection.Name = "BtnAddSection"
    Me.BtnAddSection.Size = New System.Drawing.Size(23, 22)
    Me.BtnAddSection.ToolTipText = "Add New Section to Notebook"
    '
    'BtnAddPage
    '
    Me.BtnAddPage.AutoToolTip = False
    Me.BtnAddPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.BtnAddPage.Image = Global.AncestryAssistant.My.Resources.Resources.PAGE_DOWNLOAD_ICO20
    Me.BtnAddPage.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.BtnAddPage.Name = "BtnAddPage"
    Me.BtnAddPage.Size = New System.Drawing.Size(23, 22)
    Me.BtnAddPage.ToolTipText = "Add New Page to Section"
    '
    'PnlBody
    '
    Me.PnlBody.Controls.Add(Me.TxtBody)
    Me.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill
    Me.PnlBody.Location = New System.Drawing.Point(0, 75)
    Me.PnlBody.Name = "PnlBody"
    Me.PnlBody.Padding = New System.Windows.Forms.Padding(20, 20, 20, 0)
    Me.PnlBody.Size = New System.Drawing.Size(548, 360)
    Me.PnlBody.TabIndex = 7
    '
    'TxtBody
    '
    Me.TxtBody.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtBody.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TxtBody.Location = New System.Drawing.Point(20, 20)
    Me.TxtBody.Name = "TxtBody"
    Me.TxtBody.Size = New System.Drawing.Size(508, 340)
    Me.TxtBody.TabIndex = 5
    Me.TxtBody.Text = ""
    '
    'PnlHeader
    '
    Me.PnlHeader.Controls.Add(Me.PnlHeaderStretch)
    Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
    Me.PnlHeader.Location = New System.Drawing.Point(0, 25)
    Me.PnlHeader.MaximumSize = New System.Drawing.Size(0, 50)
    Me.PnlHeader.MinimumSize = New System.Drawing.Size(0, 50)
    Me.PnlHeader.Name = "PnlHeader"
    Me.PnlHeader.Padding = New System.Windows.Forms.Padding(25, 0, 0, 0)
    Me.PnlHeader.Size = New System.Drawing.Size(548, 50)
    Me.PnlHeader.TabIndex = 6
    '
    'PnlHeaderStretch
    '
    Me.PnlHeaderStretch.AutoSize = True
    Me.PnlHeaderStretch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
    Me.PnlHeaderStretch.BorderColor = System.Drawing.Color.Transparent
    Me.PnlHeaderStretch.BorderColorBottom = System.Drawing.Color.Black
    Me.PnlHeaderStretch.BorderColorLeft = System.Drawing.Color.Black
    Me.PnlHeaderStretch.BorderColorRight = System.Drawing.Color.Black
    Me.PnlHeaderStretch.BorderColorTop = System.Drawing.Color.Black
    Me.PnlHeaderStretch.BorderWidth = New System.Windows.Forms.Padding(0, 0, 0, 2)
    Me.PnlHeaderStretch.Controls.Add(Me.TxtHeader)
    Me.PnlHeaderStretch.Controls.Add(Me.LblStretch)
    Me.PnlHeaderStretch.CornerRadius = New System.Windows.Forms.Padding(0)
    Me.PnlHeaderStretch.Dock = System.Windows.Forms.DockStyle.Left
    Me.PnlHeaderStretch.Location = New System.Drawing.Point(25, 0)
    Me.PnlHeaderStretch.MinimumSize = New System.Drawing.Size(200, 0)
    Me.PnlHeaderStretch.Name = "PnlHeaderStretch"
    Me.PnlHeaderStretch.Padding = New System.Windows.Forms.Padding(10, 15, 0, 3)
    Me.PnlHeaderStretch.Size = New System.Drawing.Size(210, 50)
    Me.PnlHeaderStretch.TabIndex = 0
    '
    'TxtHeader
    '
    Me.TxtHeader.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtHeader.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TxtHeader.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtHeader.Location = New System.Drawing.Point(10, 15)
    Me.TxtHeader.MaxLength = 90
    Me.TxtHeader.MinimumSize = New System.Drawing.Size(200, 0)
    Me.TxtHeader.Name = "TxtHeader"
    Me.TxtHeader.Size = New System.Drawing.Size(200, 25)
    Me.TxtHeader.TabIndex = 0
    Me.TxtHeader.Text = "New Page"
    '
    'LblStretch
    '
    Me.LblStretch.AutoSize = True
    Me.LblStretch.Dock = System.Windows.Forms.DockStyle.Fill
    Me.LblStretch.Font = New System.Drawing.Font("Segoe UI Semibold", 14.0!, System.Drawing.FontStyle.Bold)
    Me.LblStretch.ForeColor = System.Drawing.Color.White
    Me.LblStretch.Location = New System.Drawing.Point(10, 15)
    Me.LblStretch.MinimumSize = New System.Drawing.Size(200, 0)
    Me.LblStretch.Name = "LblStretch"
    Me.LblStretch.Size = New System.Drawing.Size(200, 25)
    Me.LblStretch.TabIndex = 1
    Me.LblStretch.Text = "New Page"
    '
    'tsPage
    '
    Me.tsPage.CanOverflow = False
    Me.tsPage.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    Me.tsPage.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    Me.tsPage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton10, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripSeparator2, Me.ToolStripSplitButton1})
    Me.tsPage.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
    Me.tsPage.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
    Me.tsPage.Name = "tsPage"
    Me.tsPage.Padding = New System.Windows.Forms.Padding(4, 0, 16, 0)
    Me.tsPage.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
    Me.tsPage.Size = New System.Drawing.Size(548, 25)
    Me.tsPage.Stretch = True
    Me.tsPage.TabIndex = 4
    '
    'ToolStripButton10
    '
    Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton10.Image = Global.AncestryAssistant.My.Resources.Resources.CUT_ICO20
    Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton10.Name = "ToolStripButton10"
    Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton10.Text = "ToolStripButton1"
    Me.ToolStripButton10.ToolTipText = "Refresh"
    '
    'ToolStripButton1
    '
    Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton1.Image = Global.AncestryAssistant.My.Resources.Resources.COPY_ICO20
    Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton1.Name = "ToolStripButton1"
    Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton1.Text = "ToolStripButton1"
    '
    'ToolStripButton2
    '
    Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton2.Image = Global.AncestryAssistant.My.Resources.Resources.CLIPBOARD_CHECK_ICO20
    Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton2.Name = "ToolStripButton2"
    Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton2.Text = "ToolStripButton2"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripButton3
    '
    Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton3.Image = Global.AncestryAssistant.My.Resources.Resources.tastatur_bold
    Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton3.Name = "ToolStripButton3"
    Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton3.Text = "ToolStripButton3"
    '
    'ToolStripButton4
    '
    Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton4.Image = Global.AncestryAssistant.My.Resources.Resources.ITALIC_ICO20
    Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton4.Name = "ToolStripButton4"
    Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton4.Text = "ToolStripButton4"
    '
    'ToolStripButton5
    '
    Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripButton5.Image = Global.AncestryAssistant.My.Resources.Resources.UNDERLINE_ICO20
    Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripButton5.Name = "ToolStripButton5"
    Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
    Me.ToolStripButton5.Text = "ToolStripButton5"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripSplitButton1
    '
    Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnH1, Me.BtnH2, Me.BtnH3, Me.BtnH4})
    Me.ToolStripSplitButton1.Image = Global.AncestryAssistant.My.Resources.Resources.H_1_ICO20
    Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
    Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 22)
    Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
    '
    'BtnH1
    '
    Me.BtnH1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnH1.ForeColor = System.Drawing.Color.SeaGreen
    Me.BtnH1.Image = Global.AncestryAssistant.My.Resources.Resources.H_1_ICO20
    Me.BtnH1.Name = "BtnH1"
    Me.BtnH1.Size = New System.Drawing.Size(259, 36)
    Me.BtnH1.Text = "Heading Style 1"
    '
    'BtnH2
    '
    Me.BtnH2.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnH2.ForeColor = System.Drawing.Color.LimeGreen
    Me.BtnH2.Image = Global.AncestryAssistant.My.Resources.Resources.H_2_ICO20
    Me.BtnH2.Name = "BtnH2"
    Me.BtnH2.Size = New System.Drawing.Size(259, 36)
    Me.BtnH2.Text = "Heading Style 2"
    '
    'BtnH3
    '
    Me.BtnH3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnH3.ForeColor = System.Drawing.Color.OliveDrab
    Me.BtnH3.Image = Global.AncestryAssistant.My.Resources.Resources.H_3_ICO20
    Me.BtnH3.Name = "BtnH3"
    Me.BtnH3.Size = New System.Drawing.Size(259, 36)
    Me.BtnH3.Text = "Heading Style 3"
    '
    'BtnH4
    '
    Me.BtnH4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnH4.ForeColor = System.Drawing.Color.Black
    Me.BtnH4.Image = Global.AncestryAssistant.My.Resources.Resources.H_4_ICO20
    Me.BtnH4.Name = "BtnH4"
    Me.BtnH4.Size = New System.Drawing.Size(259, 36)
    Me.BtnH4.Text = "Heading Style 4"
    '
    'NotebookViewer
    '
    Me.AllowDrop = True
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.SplitSectionsPage)
    Me.DoubleBuffered = True
    Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Name = "NotebookViewer"
    Me.Size = New System.Drawing.Size(654, 435)
    Me.SplitSectionsPage.Panel1.ResumeLayout(False)
    Me.SplitSectionsPage.Panel1.PerformLayout()
    Me.SplitSectionsPage.Panel2.ResumeLayout(False)
    Me.SplitSectionsPage.Panel2.PerformLayout()
    CType(Me.SplitSectionsPage, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitSectionsPage.ResumeLayout(False)
    Me.tsSections.ResumeLayout(False)
    Me.tsSections.PerformLayout()
    Me.PnlBody.ResumeLayout(False)
    Me.PnlHeader.ResumeLayout(False)
    Me.PnlHeader.PerformLayout()
    Me.PnlHeaderStretch.ResumeLayout(False)
    Me.PnlHeaderStretch.PerformLayout()
    Me.tsPage.ResumeLayout(False)
    Me.tsPage.PerformLayout()
    Me.ResumeLayout(False)

  End Sub

  Friend WithEvents TxtBody As RichTextBox
  Friend WithEvents tsSections As ToolStrip
  Friend WithEvents BtnAddSection As ToolStripButton
  Friend WithEvents PnlHeader As Panel
  Friend WithEvents PnlHeaderStretch As JPanel
  Friend WithEvents TxtHeader As TextBox
  Friend WithEvents PnlBody As Panel
  Friend WithEvents LblStretch As Label
  Friend WithEvents SplitSectionsPage As SplitContainer
  Friend WithEvents TreeSectionPages As TreeView
  Friend WithEvents tsPage As ToolStrip
  Friend WithEvents ToolStripButton10 As ToolStripButton
  Friend WithEvents BtnAddPage As ToolStripButton
  Friend WithEvents imgSection As ImageList
  Friend WithEvents ToolStripButton1 As ToolStripButton
  Friend WithEvents ToolStripButton2 As ToolStripButton
  Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
  Friend WithEvents ToolStripButton3 As ToolStripButton
  Friend WithEvents ToolStripButton4 As ToolStripButton
  Friend WithEvents ToolStripButton5 As ToolStripButton
  Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
  Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
  Friend WithEvents BtnH1 As ToolStripMenuItem
  Friend WithEvents BtnH2 As ToolStripMenuItem
  Friend WithEvents BtnH3 As ToolStripMenuItem
  Friend WithEvents BtnH4 As ToolStripMenuItem
End Class
