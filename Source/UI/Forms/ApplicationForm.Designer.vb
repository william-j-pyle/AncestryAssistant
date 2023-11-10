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
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.MenuBar1 = New AncestryAssistant.MenuBar()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AncestryToolbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBar1 = New AncestryAssistant.ToolBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DockManager = New AncestryAssistant.DockPanelManager()
        Me.mnuPanelDock.SuspendLayout()
        Me.tsAncestry.SuspendLayout()
        CType(Me.AncestryDirectorWatcher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolbar.SuspendLayout()
        Me.MenuBar1.SuspendLayout()
        Me.StatusBar1.SuspendLayout()
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
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(107, 148)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "TabPage1"
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
        'StatusBar1
        '
        Me.StatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusBar1.ForeColor = System.Drawing.Color.White
        Me.StatusBar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusBar1.Location = New System.Drawing.Point(0, 477)
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
        'DockManager
        '
        Me.DockManager.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockManager.Location = New System.Drawing.Point(0, 49)
        Me.DockManager.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.DockManager.Name = "DockManager"
        Me.DockManager.Size = New System.Drawing.Size(899, 428)
        Me.DockManager.TabIndex = 12
        '
        'ApplicationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(899, 502)
        Me.Controls.Add(Me.DockManager)
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
        Me.MenuBar1.ResumeLayout(False)
        Me.MenuBar1.PerformLayout()
        Me.StatusBar1.ResumeLayout(False)
        Me.StatusBar1.PerformLayout()
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
    Friend WithEvents toolbar As Panel
    Friend WithEvents btnActions As ToolStripButton
    Friend WithEvents btnCensus As ToolStripButton
    Friend WithEvents btnNotebook As ToolStripButton
    Friend WithEvents TabPage1 As TabPage
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
    Friend WithEvents DockManager As DockPanelManager
End Class
