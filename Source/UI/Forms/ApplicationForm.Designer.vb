<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ApplicationForm
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
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApplicationForm))
        Me.imgViewerList = New System.Windows.Forms.ImageList(Me.components)
        Me.imgList20 = New System.Windows.Forms.ImageList(Me.components)
        Me.imgList32 = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuPanelDock = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDockTopLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockTopRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockBottomLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockBottomMiddle = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockBottomRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsAncestry = New System.Windows.Forms.ToolStrip()
        Me.btnHomeTree = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnViewPedigree = New System.Windows.Forms.ToolStripButton()
        Me.btnViewTree = New System.Windows.Forms.ToolStripButton()
        Me.btnViewFan = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnPersonFact = New System.Windows.Forms.ToolStripButton()
        Me.btnPersonHints = New System.Windows.Forms.ToolStripButton()
        Me.btnPersonGallery = New System.Windows.Forms.ToolStripButton()
        Me.btnPersonStory = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAncestor = New System.Windows.Forms.ToolStripButton()
        Me.btnAncestors = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnActions = New System.Windows.Forms.ToolStripButton()
        Me.btnCensus = New System.Windows.Forms.ToolStripButton()
        Me.btnNotebook = New System.Windows.Forms.ToolStripButton()
        Me.AncestryDirectorWatcher = New System.IO.FileSystemWatcher()
        Me.toolbar = New System.Windows.Forms.Panel()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlMiddle = New System.Windows.Forms.Panel()
        Me.pnlMiddleTop = New System.Windows.Forms.Panel()
        Me.pnlMiddleLeft = New System.Windows.Forms.Panel()
        Me.splitMiddleLeftRight = New System.Windows.Forms.Splitter()
        Me.pnlMiddleRight = New System.Windows.Forms.Panel()
        Me.splitMiddleBottom = New System.Windows.Forms.Splitter()
        Me.pnlMiddleBottom = New System.Windows.Forms.Panel()
        Me.splitLeft = New System.Windows.Forms.Splitter()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.pnlLeftBottom = New System.Windows.Forms.Panel()
        Me.splitLeftTopBottom = New System.Windows.Forms.Splitter()
        Me.pnlLeftTop = New System.Windows.Forms.Panel()
        Me.splitRight = New System.Windows.Forms.Splitter()
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.pnlRightBottom = New System.Windows.Forms.Panel()
        Me.splitRightTopBottom = New System.Windows.Forms.Splitter()
        Me.pnlRightTop = New System.Windows.Forms.Panel()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.StatusBar1 = New AncestryAssistant.ToolBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dockMiddleLeft = New AncestryAssistant.DockTopTabs()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dockMiddleRight = New AncestryAssistant.DockPanel()
        Me.CensusViewer1 = New AncestryAssistant.CensusViewer()
        Me.dockBottomLeft = New AncestryAssistant.DockPanel()
        Me.dockTopLeft = New AncestryAssistant.DockPanel()
        Me.Ancestry = New AncestryAssistant.AncestryWebViewer()
        Me.MenuBar1 = New AncestryAssistant.MenuBar()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AncestryToolbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPanelDock.SuspendLayout()
        Me.tsAncestry.SuspendLayout()
        CType(Me.AncestryDirectorWatcher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolbar.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlMiddle.SuspendLayout()
        Me.pnlMiddleTop.SuspendLayout()
        Me.pnlMiddleLeft.SuspendLayout()
        Me.pnlMiddleRight.SuspendLayout()
        Me.pnlMiddleBottom.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.pnlLeftBottom.SuspendLayout()
        Me.pnlLeftTop.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.pnlRightTop.SuspendLayout()
        Me.StatusBar1.SuspendLayout()
        Me.dockMiddleLeft.SuspendLayout()
        Me.MenuBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgViewerList
        '
        Me.imgViewerList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgViewerList.ImageSize = New System.Drawing.Size(128, 128)
        Me.imgViewerList.TransparentColor = System.Drawing.Color.Transparent
        '
        'imgList20
        '
        Me.imgList20.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgList20.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgList20.TransparentColor = System.Drawing.Color.Transparent
        '
        'imgList32
        '
        Me.imgList32.ImageStream = CType(resources.GetObject("imgList32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList32.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList32.Images.SetKeyName(0, "ico_32_Ancestry.png")
        '
        'mnuPanelDock
        '
        Me.mnuPanelDock.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDockTopLeft, Me.mnuDockTopRight, Me.mnuDockBottomLeft, Me.mnuDockBottomMiddle, Me.mnuDockBottomRight})
        Me.mnuPanelDock.Name = "mnuPanelMove"
        Me.mnuPanelDock.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.mnuPanelDock.Size = New System.Drawing.Size(185, 114)
        '
        'mnuDockTopLeft
        '
        Me.mnuDockTopLeft.Name = "mnuDockTopLeft"
        Me.mnuDockTopLeft.Size = New System.Drawing.Size(184, 22)
        Me.mnuDockTopLeft.Text = "Dock Top-Left"
        '
        'mnuDockTopRight
        '
        Me.mnuDockTopRight.Name = "mnuDockTopRight"
        Me.mnuDockTopRight.Size = New System.Drawing.Size(184, 22)
        Me.mnuDockTopRight.Text = "Dock Top-Right"
        '
        'mnuDockBottomLeft
        '
        Me.mnuDockBottomLeft.Name = "mnuDockBottomLeft"
        Me.mnuDockBottomLeft.Size = New System.Drawing.Size(184, 22)
        Me.mnuDockBottomLeft.Text = "Dock Bottom-Left"
        '
        'mnuDockBottomMiddle
        '
        Me.mnuDockBottomMiddle.Name = "mnuDockBottomMiddle"
        Me.mnuDockBottomMiddle.Size = New System.Drawing.Size(184, 22)
        Me.mnuDockBottomMiddle.Text = "Dock Bottom-Center"
        '
        'mnuDockBottomRight
        '
        Me.mnuDockBottomRight.Name = "mnuDockBottomRight"
        Me.mnuDockBottomRight.Size = New System.Drawing.Size(184, 22)
        Me.mnuDockBottomRight.Text = "Dock Bottom-Right"
        '
        'tsAncestry
        '
        Me.tsAncestry.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tsAncestry.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_ANCESTRY_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tsAncestry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tsAncestry.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsAncestry.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnHomeTree, Me.ToolStripSeparator1, Me.btnViewPedigree, Me.btnViewTree, Me.btnViewFan, Me.ToolStripSeparator2, Me.btnPersonFact, Me.btnPersonHints, Me.btnPersonGallery, Me.btnPersonStory, Me.ToolStripSeparator3, Me.btnAncestor, Me.btnAncestors, Me.ToolStripSeparator4, Me.btnActions, Me.btnCensus, Me.btnNotebook})
        Me.tsAncestry.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tsAncestry.Location = Global.AncestryAssistant.My.MySettings.Default.TB_ANCESTRY_LOC
        Me.tsAncestry.Name = "tsAncestry"
        Me.tsAncestry.Padding = New System.Windows.Forms.Padding(4, 0, 1, 0)
        Me.tsAncestry.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsAncestry.Size = New System.Drawing.Size(891, 25)
        Me.tsAncestry.TabIndex = 3
        Me.tsAncestry.Text = "Ancestry"
        '
        'btnHomeTree
        '
        Me.btnHomeTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnHomeTree.Image = Global.AncestryAssistant.My.Resources.Resources.SEEDING_ICO20
        Me.btnHomeTree.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHomeTree.Name = "btnHomeTree"
        Me.btnHomeTree.Size = New System.Drawing.Size(23, 22)
        Me.btnHomeTree.ToolTipText = "Root Person - Tree View"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnViewPedigree
        '
        Me.btnViewPedigree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnViewPedigree.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY_PEDIGREE_VIEW
        Me.btnViewPedigree.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnViewPedigree.Name = "btnViewPedigree"
        Me.btnViewPedigree.Size = New System.Drawing.Size(23, 22)
        Me.btnViewPedigree.Text = "ToolStripButton2"
        Me.btnViewPedigree.ToolTipText = "Active Ancestor - Pedigree View"
        '
        'btnViewTree
        '
        Me.btnViewTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnViewTree.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY_FAMILY_VIEW
        Me.btnViewTree.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnViewTree.Name = "btnViewTree"
        Me.btnViewTree.Size = New System.Drawing.Size(23, 22)
        Me.btnViewTree.Text = "ToolStripButton3"
        Me.btnViewTree.ToolTipText = "Active Ancestor - Tree View"
        '
        'btnViewFan
        '
        Me.btnViewFan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnViewFan.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY_FAN_VIEW
        Me.btnViewFan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnViewFan.Name = "btnViewFan"
        Me.btnViewFan.Size = New System.Drawing.Size(23, 22)
        Me.btnViewFan.Text = "ToolStripButton4"
        Me.btnViewFan.ToolTipText = "Active Ancestor - Fan View"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnPersonFact
        '
        Me.btnPersonFact.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPersonFact.Image = Global.AncestryAssistant.My.Resources.Resources.USER_ICO20
        Me.btnPersonFact.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPersonFact.Name = "btnPersonFact"
        Me.btnPersonFact.Size = New System.Drawing.Size(23, 22)
        Me.btnPersonFact.Text = "ToolStripButton5"
        Me.btnPersonFact.ToolTipText = "Active Ancestor - Facts"
        '
        'btnPersonHints
        '
        Me.btnPersonHints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPersonHints.Image = Global.AncestryAssistant.My.Resources.Resources.LEAF_ICO20
        Me.btnPersonHints.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPersonHints.Name = "btnPersonHints"
        Me.btnPersonHints.Size = New System.Drawing.Size(23, 22)
        Me.btnPersonHints.Text = "ToolStripButton6"
        Me.btnPersonHints.ToolTipText = "Active Ancestor - Hints"
        '
        'btnPersonGallery
        '
        Me.btnPersonGallery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPersonGallery.Image = Global.AncestryAssistant.My.Resources.Resources.PHOTO_ICO20
        Me.btnPersonGallery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPersonGallery.Name = "btnPersonGallery"
        Me.btnPersonGallery.Size = New System.Drawing.Size(23, 22)
        Me.btnPersonGallery.Text = "ToolStripButton7"
        Me.btnPersonGallery.ToolTipText = "Active Ancestor - Gallery"
        '
        'btnPersonStory
        '
        Me.btnPersonStory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPersonStory.Image = Global.AncestryAssistant.My.Resources.Resources.BOOK_ICO20
        Me.btnPersonStory.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPersonStory.Name = "btnPersonStory"
        Me.btnPersonStory.Size = New System.Drawing.Size(23, 22)
        Me.btnPersonStory.Text = "ToolStripButton8"
        Me.btnPersonStory.ToolTipText = "Active Ancestor - Stories"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnAncestor
        '
        Me.btnAncestor.Checked = Global.AncestryAssistant.My.MySettings.Default.MNU_ANCESTOR_CHECKED
        Me.btnAncestor.CheckOnClick = True
        Me.btnAncestor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnAncestor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAncestor.Image = CType(resources.GetObject("btnAncestor.Image"), System.Drawing.Image)
        Me.btnAncestor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAncestor.Name = "btnAncestor"
        Me.btnAncestor.Size = New System.Drawing.Size(23, 22)
        Me.btnAncestor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnAncestor.ToolTipText = "Ancestor Panel"
        '
        'btnAncestors
        '
        Me.btnAncestors.Checked = Global.AncestryAssistant.My.MySettings.Default.MNU_ANCESTORLIST_CHECKED
        Me.btnAncestors.CheckOnClick = True
        Me.btnAncestors.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnAncestors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAncestors.Image = Global.AncestryAssistant.My.Resources.Resources.USERS_ICO20
        Me.btnAncestors.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAncestors.Name = "btnAncestors"
        Me.btnAncestors.Size = New System.Drawing.Size(23, 22)
        Me.btnAncestors.Text = "ToolStripButton1"
        Me.btnAncestors.ToolTipText = "Ancestors Panel"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnActions
        '
        Me.btnActions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnActions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnActions.Image = CType(resources.GetObject("btnActions.Image"), System.Drawing.Image)
        Me.btnActions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActions.Name = "btnActions"
        Me.btnActions.Size = New System.Drawing.Size(99, 22)
        Me.btnActions.Text = "ToolStripButton1"
        Me.btnActions.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActions.ToolTipText = "Download"
        Me.btnActions.Visible = False
        '
        'btnCensus
        '
        Me.btnCensus.CheckOnClick = True
        Me.btnCensus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCensus.Image = Global.AncestryAssistant.My.Resources.Resources.ARCHIVE_ICO20
        Me.btnCensus.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCensus.Name = "btnCensus"
        Me.btnCensus.Size = New System.Drawing.Size(23, 22)
        Me.btnCensus.Text = "ToolStripButton1"
        Me.btnCensus.ToolTipText = "Census"
        '
        'btnNotebook
        '
        Me.btnNotebook.CheckOnClick = True
        Me.btnNotebook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNotebook.Image = Global.AncestryAssistant.My.Resources.Resources.EDIT_ICO20
        Me.btnNotebook.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNotebook.Name = "btnNotebook"
        Me.btnNotebook.Size = New System.Drawing.Size(23, 22)
        Me.btnNotebook.Text = "ToolStripButton2"
        Me.btnNotebook.ToolTipText = "Notebook"
        '
        'AncestryDirectorWatcher
        '
        Me.AncestryDirectorWatcher.EnableRaisingEvents = True
        Me.AncestryDirectorWatcher.IncludeSubdirectories = True
        Me.AncestryDirectorWatcher.Path = Global.AncestryAssistant.My.MySettings.Default.AncestorsPath
        Me.AncestryDirectorWatcher.SynchronizingObject = Me
        '
        'toolbar
        '
        Me.toolbar.BackColor = System.Drawing.SystemColors.ControlLight
        Me.toolbar.Controls.Add(Me.tsAncestry)
        Me.toolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.toolbar.Location = New System.Drawing.Point(0, 24)
        Me.toolbar.MaximumSize = New System.Drawing.Size(0, 25)
        Me.toolbar.Name = "toolbar"
        Me.toolbar.Padding = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.toolbar.Size = New System.Drawing.Size(899, 25)
        Me.toolbar.TabIndex = 8
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.Black
        Me.pnlMain.Controls.Add(Me.pnlMiddle)
        Me.pnlMain.Controls.Add(Me.splitLeft)
        Me.pnlMain.Controls.Add(Me.pnlLeft)
        Me.pnlMain.Controls.Add(Me.splitRight)
        Me.pnlMain.Controls.Add(Me.pnlRight)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.pnlMain.Location = New System.Drawing.Point(0, 49)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlMain.Size = New System.Drawing.Size(899, 266)
        Me.pnlMain.TabIndex = 9
        '
        'pnlMiddle
        '
        Me.pnlMiddle.Controls.Add(Me.pnlMiddleTop)
        Me.pnlMiddle.Controls.Add(Me.splitMiddleBottom)
        Me.pnlMiddle.Controls.Add(Me.pnlMiddleBottom)
        Me.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMiddle.Location = New System.Drawing.Point(214, 4)
        Me.pnlMiddle.Name = "pnlMiddle"
        Me.pnlMiddle.Size = New System.Drawing.Size(477, 258)
        Me.pnlMiddle.TabIndex = 13
        '
        'pnlMiddleTop
        '
        Me.pnlMiddleTop.Controls.Add(Me.pnlMiddleLeft)
        Me.pnlMiddleTop.Controls.Add(Me.splitMiddleLeftRight)
        Me.pnlMiddleTop.Controls.Add(Me.pnlMiddleRight)
        Me.pnlMiddleTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMiddleTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlMiddleTop.Name = "pnlMiddleTop"
        Me.pnlMiddleTop.Size = New System.Drawing.Size(477, 183)
        Me.pnlMiddleTop.TabIndex = 0
        '
        'pnlMiddleLeft
        '
        Me.pnlMiddleLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pnlMiddleLeft.Controls.Add(Me.dockMiddleLeft)
        Me.pnlMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMiddleLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlMiddleLeft.Name = "pnlMiddleLeft"
        Me.pnlMiddleLeft.Size = New System.Drawing.Size(358, 183)
        Me.pnlMiddleLeft.TabIndex = 4
        '
        'splitMiddleLeftRight
        '
        Me.splitMiddleLeftRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.splitMiddleLeftRight.Location = New System.Drawing.Point(358, 0)
        Me.splitMiddleLeftRight.Name = "splitMiddleLeftRight"
        Me.splitMiddleLeftRight.Size = New System.Drawing.Size(4, 183)
        Me.splitMiddleLeftRight.TabIndex = 6
        Me.splitMiddleLeftRight.TabStop = False
        '
        'pnlMiddleRight
        '
        Me.pnlMiddleRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pnlMiddleRight.Controls.Add(Me.dockMiddleRight)
        Me.pnlMiddleRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMiddleRight.Location = New System.Drawing.Point(362, 0)
        Me.pnlMiddleRight.Name = "pnlMiddleRight"
        Me.pnlMiddleRight.Size = New System.Drawing.Size(115, 183)
        Me.pnlMiddleRight.TabIndex = 5
        '
        'splitMiddleBottom
        '
        Me.splitMiddleBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.splitMiddleBottom.Location = New System.Drawing.Point(0, 183)
        Me.splitMiddleBottom.Name = "splitMiddleBottom"
        Me.splitMiddleBottom.Size = New System.Drawing.Size(477, 4)
        Me.splitMiddleBottom.TabIndex = 15
        Me.splitMiddleBottom.TabStop = False
        '
        'pnlMiddleBottom
        '
        Me.pnlMiddleBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlMiddleBottom.Controls.Add(Me.CensusViewer1)
        Me.pnlMiddleBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMiddleBottom.Location = New System.Drawing.Point(0, 187)
        Me.pnlMiddleBottom.Name = "pnlMiddleBottom"
        Me.pnlMiddleBottom.Size = New System.Drawing.Size(477, 71)
        Me.pnlMiddleBottom.TabIndex = 12
        '
        'splitLeft
        '
        Me.splitLeft.Location = New System.Drawing.Point(210, 4)
        Me.splitLeft.Name = "splitLeft"
        Me.splitLeft.Size = New System.Drawing.Size(4, 258)
        Me.splitLeft.TabIndex = 10
        Me.splitLeft.TabStop = False
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.pnlLeftBottom)
        Me.pnlLeft.Controls.Add(Me.splitLeftTopBottom)
        Me.pnlLeft.Controls.Add(Me.pnlLeftTop)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(4, 4)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(206, 258)
        Me.pnlLeft.TabIndex = 9
        '
        'pnlLeftBottom
        '
        Me.pnlLeftBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pnlLeftBottom.Controls.Add(Me.dockBottomLeft)
        Me.pnlLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLeftBottom.Location = New System.Drawing.Point(0, 153)
        Me.pnlLeftBottom.Name = "pnlLeftBottom"
        Me.pnlLeftBottom.Size = New System.Drawing.Size(206, 105)
        Me.pnlLeftBottom.TabIndex = 2
        '
        'splitLeftTopBottom
        '
        Me.splitLeftTopBottom.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitLeftTopBottom.Location = New System.Drawing.Point(0, 149)
        Me.splitLeftTopBottom.Name = "splitLeftTopBottom"
        Me.splitLeftTopBottom.Size = New System.Drawing.Size(206, 4)
        Me.splitLeftTopBottom.TabIndex = 3
        Me.splitLeftTopBottom.TabStop = False
        '
        'pnlLeftTop
        '
        Me.pnlLeftTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pnlLeftTop.Controls.Add(Me.dockTopLeft)
        Me.pnlLeftTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLeftTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeftTop.Name = "pnlLeftTop"
        Me.pnlLeftTop.Size = New System.Drawing.Size(206, 149)
        Me.pnlLeftTop.TabIndex = 1
        '
        'splitRight
        '
        Me.splitRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.splitRight.Location = New System.Drawing.Point(691, 4)
        Me.splitRight.Name = "splitRight"
        Me.splitRight.Size = New System.Drawing.Size(4, 258)
        Me.splitRight.TabIndex = 14
        Me.splitRight.TabStop = False
        '
        'pnlRight
        '
        Me.pnlRight.Controls.Add(Me.pnlRightBottom)
        Me.pnlRight.Controls.Add(Me.splitRightTopBottom)
        Me.pnlRight.Controls.Add(Me.pnlRightTop)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRight.Location = New System.Drawing.Point(695, 4)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(200, 258)
        Me.pnlRight.TabIndex = 11
        '
        'pnlRightBottom
        '
        Me.pnlRightBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRightBottom.Location = New System.Drawing.Point(0, 156)
        Me.pnlRightBottom.Name = "pnlRightBottom"
        Me.pnlRightBottom.Size = New System.Drawing.Size(200, 102)
        Me.pnlRightBottom.TabIndex = 1
        '
        'splitRightTopBottom
        '
        Me.splitRightTopBottom.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitRightTopBottom.Location = New System.Drawing.Point(0, 152)
        Me.splitRightTopBottom.Name = "splitRightTopBottom"
        Me.splitRightTopBottom.Size = New System.Drawing.Size(200, 4)
        Me.splitRightTopBottom.TabIndex = 2
        Me.splitRightTopBottom.TabStop = False
        '
        'pnlRightTop
        '
        Me.pnlRightTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlRightTop.Controls.Add(Me.Ancestry)
        Me.pnlRightTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRightTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlRightTop.Name = "pnlRightTop"
        Me.pnlRightTop.Size = New System.Drawing.Size(200, 152)
        Me.pnlRightTop.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(107, 148)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "TabPage1"
        '
        'StatusBar1
        '
        Me.StatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusBar1.ForeColor = System.Drawing.Color.White
        Me.StatusBar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusBar1.Location = New System.Drawing.Point(0, 315)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(899, 25)
        Me.StatusBar1.TabIndex = 10
        Me.StatusBar1.Text = "StatusBar1"
        Me.StatusBar1.ToolBarAccentColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.StatusBar1.ToolBarBackColor = System.Drawing.Color.DimGray
        Me.StatusBar1.ToolBarBorderColor = System.Drawing.Color.DarkSlateGray
        Me.StatusBar1.ToolBarFontColor = System.Drawing.Color.White
        Me.StatusBar1.ToolBarHighlightColor = System.Drawing.Color.LimeGreen
        Me.StatusBar1.ToolBarShadowColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(123, 20)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(123, 20)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(119, 20)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "ToolStripStatusLabel3"
        '
        'dockMiddleLeft
        '
        Me.dockMiddleLeft.Controls.Add(Me.TabPage2)
        Me.dockMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dockMiddleLeft.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.dockMiddleLeft.HotTrack = True
        Me.dockMiddleLeft.Location = New System.Drawing.Point(0, 0)
        Me.dockMiddleLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.dockMiddleLeft.Name = "dockMiddleLeft"
        Me.dockMiddleLeft.Padding = New System.Drawing.Point(20, 2)
        Me.dockMiddleLeft.PanelAccentColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.dockMiddleLeft.PanelBackColor = System.Drawing.Color.Black
        Me.dockMiddleLeft.PanelBorderColor = System.Drawing.Color.DarkGray
        Me.dockMiddleLeft.PanelFontColor = System.Drawing.Color.WhiteSmoke
        Me.dockMiddleLeft.PanelHasFocus = False
        Me.dockMiddleLeft.PanelHighlightColor = System.Drawing.Color.GreenYellow
        Me.dockMiddleLeft.PanelIsPinned = True
        Me.dockMiddleLeft.PanelShadowColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.dockMiddleLeft.PanelShowClose = False
        Me.dockMiddleLeft.PanelShowContextMenu = False
        Me.dockMiddleLeft.PanelShowPinned = False
        Me.dockMiddleLeft.PanelShowSearch = False
        Me.dockMiddleLeft.SelectedIndex = 0
        Me.dockMiddleLeft.ShowToolTips = True
        Me.dockMiddleLeft.Size = New System.Drawing.Size(358, 183)
        Me.dockMiddleLeft.TabIndex = 0
        Me.dockMiddleLeft.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Black
        Me.TabPage2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(350, 156)
        Me.TabPage2.TabIndex = 0
        '
        'dockMiddleRight
        '
        Me.dockMiddleRight.BackColor = System.Drawing.Color.Black
        Me.dockMiddleRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dockMiddleRight.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dockMiddleRight.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.dockMiddleRight.Location = New System.Drawing.Point(0, 0)
        Me.dockMiddleRight.Margin = New System.Windows.Forms.Padding(0)
        Me.dockMiddleRight.Name = "dockMiddleRight"
        Me.dockMiddleRight.PanelAccentColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.dockMiddleRight.PanelBackColor = System.Drawing.Color.Black
        Me.dockMiddleRight.PanelBorderColor = System.Drawing.Color.DarkGray
        Me.dockMiddleRight.PanelFontColor = System.Drawing.Color.WhiteSmoke
        Me.dockMiddleRight.PanelHasFocus = False
        Me.dockMiddleRight.PanelHighlightColor = System.Drawing.Color.GreenYellow
        Me.dockMiddleRight.PanelIsPinned = True
        Me.dockMiddleRight.PanelShadowColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.dockMiddleRight.PanelShowClose = False
        Me.dockMiddleRight.PanelShowContextMenu = False
        Me.dockMiddleRight.PanelShowPinned = False
        Me.dockMiddleRight.PanelShowSearch = False
        Me.dockMiddleRight.Size = New System.Drawing.Size(115, 183)
        Me.dockMiddleRight.TabIndex = 0
        '
        'CensusViewer1
        '
        Me.CensusViewer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.CensusViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CensusViewer1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CensusViewer1.ItemDockStyle = System.Windows.Forms.DockStyle.Fill
        Me.CensusViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CensusViewer1.Name = "CensusViewer1"
        Me.CensusViewer1.Size = New System.Drawing.Size(477, 71)
        Me.CensusViewer1.TabIndex = 0
        '
        'dockBottomLeft
        '
        Me.dockBottomLeft.BackColor = System.Drawing.Color.Black
        Me.dockBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dockBottomLeft.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dockBottomLeft.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.dockBottomLeft.Location = New System.Drawing.Point(0, 0)
        Me.dockBottomLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.dockBottomLeft.Name = "dockBottomLeft"
        Me.dockBottomLeft.PanelAccentColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.dockBottomLeft.PanelBackColor = System.Drawing.Color.Black
        Me.dockBottomLeft.PanelBorderColor = System.Drawing.Color.DarkGray
        Me.dockBottomLeft.PanelFontColor = System.Drawing.Color.WhiteSmoke
        Me.dockBottomLeft.PanelHasFocus = False
        Me.dockBottomLeft.PanelHighlightColor = System.Drawing.Color.GreenYellow
        Me.dockBottomLeft.PanelIsPinned = True
        Me.dockBottomLeft.PanelShadowColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.dockBottomLeft.PanelShowClose = False
        Me.dockBottomLeft.PanelShowContextMenu = False
        Me.dockBottomLeft.PanelShowPinned = False
        Me.dockBottomLeft.PanelShowSearch = False
        Me.dockBottomLeft.Size = New System.Drawing.Size(206, 105)
        Me.dockBottomLeft.TabIndex = 0
        '
        'dockTopLeft
        '
        Me.dockTopLeft.BackColor = System.Drawing.Color.Black
        Me.dockTopLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dockTopLeft.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dockTopLeft.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.dockTopLeft.Location = New System.Drawing.Point(0, 0)
        Me.dockTopLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.dockTopLeft.Name = "dockTopLeft"
        Me.dockTopLeft.PanelAccentColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.dockTopLeft.PanelBackColor = System.Drawing.Color.Black
        Me.dockTopLeft.PanelBorderColor = System.Drawing.Color.DarkGray
        Me.dockTopLeft.PanelFontColor = System.Drawing.Color.WhiteSmoke
        Me.dockTopLeft.PanelHasFocus = False
        Me.dockTopLeft.PanelHighlightColor = System.Drawing.Color.GreenYellow
        Me.dockTopLeft.PanelIsPinned = True
        Me.dockTopLeft.PanelShadowColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.dockTopLeft.PanelShowClose = False
        Me.dockTopLeft.PanelShowContextMenu = False
        Me.dockTopLeft.PanelShowPinned = False
        Me.dockTopLeft.PanelShowSearch = False
        Me.dockTopLeft.Size = New System.Drawing.Size(206, 149)
        Me.dockTopLeft.TabIndex = 1
        '
        'Ancestry
        '
        Me.Ancestry.AncestorID = ""
        Me.Ancestry.AncestryPage = ""
        Me.Ancestry.AncestryTreeID = "65171586"
        Me.Ancestry.BlockedWebDomains = New String() {"facebook", "doubleclick", "tiktok", "pinterest", "adservice", "ad-delivery", "adspsp", "adsystem", "adnxs", "securepubads"}
        Me.Ancestry.BlockWebTracking = True
        Me.Ancestry.DataBindings.Add(New System.Windows.Forms.Binding("ShowToolbar", Global.AncestryAssistant.My.MySettings.Default, "ANCESTRY_SHOW_TOOLBAR", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Ancestry.HREF = "https://www.ancestry.com/family-tree/tree/65171586/recent"
        Me.Ancestry.ItemDockStyle = System.Windows.Forms.DockStyle.None
        Me.Ancestry.Location = New System.Drawing.Point(13, 6)
        Me.Ancestry.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Ancestry.Name = "Ancestry"
        Me.Ancestry.ShowToolbar = Global.AncestryAssistant.My.MySettings.Default.ANCESTRY_SHOW_TOOLBAR
        Me.Ancestry.Size = New System.Drawing.Size(174, 123)
        Me.Ancestry.TabIndex = 0
        Me.Ancestry.UriTrackingGroup = AncestryAssistant.UriTrackingGroupEnum.ANCESTRY
        Me.Ancestry.URL = New System.Uri("https://www.ancestry.com/family-tree/tree/65171586/recent", System.UriKind.Absolute)
        '
        'MenuBar1
        '
        Me.MenuBar1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.MenuBar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuBar1.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar1.MenuBarAccentColor = System.Drawing.Color.FromArgb(CType(CType(111, Byte), Integer), CType(CType(143, Byte), Integer), CType(CType(143, Byte), Integer))
        Me.MenuBar1.MenuBarBackColor = System.Drawing.Color.Black
        Me.MenuBar1.MenuBarBorderColor = System.Drawing.Color.DarkSlateGray
        Me.MenuBar1.MenuBarFontColor = System.Drawing.Color.WhiteSmoke
        Me.MenuBar1.MenuBarHighlightColor = System.Drawing.Color.LimeGreen
        Me.MenuBar1.MenuBarShadowColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.MenuBar1.Name = "MenuBar1"
        Me.MenuBar1.Size = New System.Drawing.Size(899, 24)
        Me.MenuBar1.TabIndex = 11
        Me.MenuBar1.Text = "MenuBar1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreferencesToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PreferencesToolStripMenuItem.Text = "Preferences"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(132, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AncestryToolbarToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'AncestryToolbarToolStripMenuItem
        '
        Me.AncestryToolbarToolStripMenuItem.Checked = Global.AncestryAssistant.My.MySettings.Default.ANCESTRY_SHOW_TOOLBAR
        Me.AncestryToolbarToolStripMenuItem.CheckOnClick = True
        Me.AncestryToolbarToolStripMenuItem.Name = "AncestryToolbarToolStripMenuItem"
        Me.AncestryToolbarToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.AncestryToolbarToolStripMenuItem.Text = "Ancestry Toolbar"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'ApplicationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(899, 340)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.toolbar)
        Me.Controls.Add(Me.MenuBar1)
        Me.Controls.Add(Me.StatusBar1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("ClientSize", Global.AncestryAssistant.My.MySettings.Default, "MainForm_ClientSize", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.AncestryAssistant.My.MySettings.Default, "APP_FONT", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.AncestryAssistant.My.MySettings.Default, "FORM_A_FG", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DoubleBuffered = True
        Me.Font = Global.AncestryAssistant.My.MySettings.Default.APP_FONT
        Me.ForeColor = Global.AncestryAssistant.My.MySettings.Default.FORM_A_FG
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ApplicationForm"
        Me.Text = "Ancestry Assistant"
        Me.mnuPanelDock.ResumeLayout(False)
        Me.tsAncestry.ResumeLayout(False)
        Me.tsAncestry.PerformLayout()
        CType(Me.AncestryDirectorWatcher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolbar.ResumeLayout(False)
        Me.toolbar.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMiddle.ResumeLayout(False)
        Me.pnlMiddleTop.ResumeLayout(False)
        Me.pnlMiddleLeft.ResumeLayout(False)
        Me.pnlMiddleRight.ResumeLayout(False)
        Me.pnlMiddleBottom.ResumeLayout(False)
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlLeftBottom.ResumeLayout(False)
        Me.pnlLeftTop.ResumeLayout(False)
        Me.pnlRight.ResumeLayout(False)
        Me.pnlRightTop.ResumeLayout(False)
        Me.StatusBar1.ResumeLayout(False)
        Me.StatusBar1.PerformLayout()
        Me.dockMiddleLeft.ResumeLayout(False)
        Me.MenuBar1.ResumeLayout(False)
        Me.MenuBar1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgList20 As ImageList
    Friend WithEvents imgList32 As ImageList
    Friend WithEvents imgViewerList As ImageList
    Friend WithEvents tsAncestry As ToolStrip
    Friend WithEvents btnHomeTree As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents btnViewPedigree As ToolStripButton
    Friend WithEvents btnViewTree As ToolStripButton
    Friend WithEvents btnViewFan As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnPersonFact As ToolStripButton
    Friend WithEvents btnPersonHints As ToolStripButton
    Friend WithEvents btnPersonGallery As ToolStripButton
    Friend WithEvents btnPersonStory As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnAncestor As ToolStripButton
    Friend WithEvents btnAncestors As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents AncestryDirectorWatcher As IO.FileSystemWatcher
    Friend WithEvents mnuPanelDock As ContextMenuStrip
    Friend WithEvents mnuDockTopLeft As ToolStripMenuItem
    Friend WithEvents mnuDockBottomLeft As ToolStripMenuItem
    Friend WithEvents mnuDockTopRight As ToolStripMenuItem
    Friend WithEvents mnuDockBottomRight As ToolStripMenuItem
    Friend WithEvents mnuDockBottomMiddle As ToolStripMenuItem
    Friend WithEvents CensusViewer1 As CensusViewer
    Friend WithEvents Ancestry As AncestryWebViewer
    Friend WithEvents toolbar As Panel
    Friend WithEvents btnActions As ToolStripButton
    Friend WithEvents pnlMain As Panel
    Friend WithEvents pnlMiddle As Panel
    Friend WithEvents pnlMiddleTop As Panel
    Friend WithEvents pnlMiddleLeft As Panel
    Friend WithEvents splitMiddleLeftRight As Splitter
    Friend WithEvents pnlMiddleRight As Panel
    Friend WithEvents splitMiddleBottom As Splitter
    Friend WithEvents pnlMiddleBottom As Panel
    Friend WithEvents splitLeft As Splitter
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents pnlLeftBottom As Panel
    Friend WithEvents splitLeftTopBottom As Splitter
    Friend WithEvents pnlLeftTop As Panel
    Friend WithEvents splitRight As Splitter
    Friend WithEvents pnlRight As Panel
    Friend WithEvents pnlRightBottom As Panel
    Friend WithEvents splitRightTopBottom As Splitter
    Friend WithEvents pnlRightTop As Panel
    Friend WithEvents btnCensus As ToolStripButton
    Friend WithEvents btnNotebook As ToolStripButton
    Friend WithEvents dockMiddleRight As DockPanel
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dockTopLeft As DockPanel
    Friend WithEvents dockBottomLeft As DockPanel
    Friend WithEvents dockMiddleLeft As DockTopTabs
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents StatusBar1 As ToolBar
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents MenuBar1 As MenuBar
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PreferencesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AncestryToolbarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
End Class
