﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
    Me.SplitPanel_Main = New System.Windows.Forms.SplitContainer()
    Me.SplitPanel = New System.Windows.Forms.SplitContainer()
    Me.AncestorAttributes = New AncestryAssistant.AncestorPanel()
    Me.AncestorsList = New AncestryAssistant.AncestorsListPanel()
    Me.tabs = New System.Windows.Forms.TabControl()
    Me.tabAncestry = New System.Windows.Forms.TabPage()
    Me.Ancestry = New AncestryAssistant.AncestryWebViewer()
    Me.tabCensus = New System.Windows.Forms.TabPage()
    Me.CensusViewer1 = New AncestryAssistant.CensusViewer()
    Me.tabGallery = New System.Windows.Forms.TabPage()
    Me.imgGallery = New AncestryAssistant.ImageGallery()
    Me.tabNotebooks = New System.Windows.Forms.TabPage()
    Me.NotebookViewer1 = New AncestryAssistant.NotebookViewer()
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
    Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
    Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
    Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.AncestryToolbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.AncestryDirectorWatcher = New System.IO.FileSystemWatcher()
    Me.toolbar = New System.Windows.Forms.Panel()
        CType(Me.SplitPanel_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel_Main.Panel1.SuspendLayout()
        Me.SplitPanel_Main.Panel2.SuspendLayout()
        Me.SplitPanel_Main.SuspendLayout()
        CType(Me.SplitPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitPanel.Panel1.SuspendLayout()
        Me.SplitPanel.Panel2.SuspendLayout()
        Me.SplitPanel.SuspendLayout()
        Me.tabs.SuspendLayout()
        Me.tabAncestry.SuspendLayout()
        Me.tabCensus.SuspendLayout()
        Me.tabGallery.SuspendLayout()
        Me.tabNotebooks.SuspendLayout()
        Me.mnuPanelDock.SuspendLayout()
        Me.tsAncestry.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.AncestryDirectorWatcher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolbar.SuspendLayout()
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
        'SplitPanel_Main
        '
        Me.SplitPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitPanel_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitPanel_Main.Location = New System.Drawing.Point(0, 49)
        Me.SplitPanel_Main.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitPanel_Main.Name = "SplitPanel_Main"
        '
        'SplitPanel_Main.Panel1
        '
        Me.SplitPanel_Main.Panel1.Controls.Add(Me.SplitPanel)
        '
        'SplitPanel_Main.Panel2
        '
        Me.SplitPanel_Main.Panel2.Controls.Add(Me.tabs)
        Me.SplitPanel_Main.Size = New System.Drawing.Size(899, 291)
        Me.SplitPanel_Main.SplitterDistance = 297
        Me.SplitPanel_Main.TabIndex = 3
        '
        'SplitPanel
        '
        Me.SplitPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitPanel.Location = New System.Drawing.Point(0, 0)
        Me.SplitPanel.Name = "SplitPanel"
        Me.SplitPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitPanel.Panel1
        '
        Me.SplitPanel.Panel1.BackColor = System.Drawing.Color.Silver
        Me.SplitPanel.Panel1.Controls.Add(Me.AncestorAttributes)
        Me.SplitPanel.Panel1.Padding = New System.Windows.Forms.Padding(1)
        '
        'SplitPanel.Panel2
        '
        Me.SplitPanel.Panel2.BackColor = System.Drawing.Color.Silver
        Me.SplitPanel.Panel2.Controls.Add(Me.AncestorsList)
        Me.SplitPanel.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.SplitPanel.Size = New System.Drawing.Size(297, 291)
        Me.SplitPanel.SplitterDistance = 141
        Me.SplitPanel.TabIndex = 3
        '
        'AncestorAttributes
        '
        Me.AncestorAttributes.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.AncestorAttributes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AncestorAttributes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AncestorAttributes.ForeColor = System.Drawing.Color.Black
        Me.AncestorAttributes.Location = New System.Drawing.Point(1, 1)
        Me.AncestorAttributes.Margin = New System.Windows.Forms.Padding(0)
        Me.AncestorAttributes.Name = "AncestorAttributes"
        Me.AncestorAttributes.Size = New System.Drawing.Size(295, 139)
        Me.AncestorAttributes.TabIndex = 0
        '
        'AncestorsList
        '
        Me.AncestorsList.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.AncestorsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AncestorsList.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AncestorsList.ForeColor = System.Drawing.Color.Black
        Me.AncestorsList.Location = New System.Drawing.Point(1, 1)
        Me.AncestorsList.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.AncestorsList.Name = "AncestorsList"
        Me.AncestorsList.Size = New System.Drawing.Size(295, 144)
        Me.AncestorsList.TabIndex = 0
        '
        'tabs
        '
        Me.tabs.Controls.Add(Me.tabAncestry)
        Me.tabs.Controls.Add(Me.tabCensus)
        Me.tabs.Controls.Add(Me.tabGallery)
        Me.tabs.Controls.Add(Me.tabNotebooks)
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.ImageList = Me.imgList20
        Me.tabs.Location = New System.Drawing.Point(0, 0)
        Me.tabs.Margin = New System.Windows.Forms.Padding(0)
        Me.tabs.Name = "tabs"
        Me.tabs.Padding = New System.Drawing.Point(0, 0)
        Me.tabs.SelectedIndex = 0
        Me.tabs.Size = New System.Drawing.Size(598, 291)
        Me.tabs.TabIndex = 3
        '
        'tabAncestry
        '
        Me.tabAncestry.BackColor = System.Drawing.Color.Transparent
        Me.tabAncestry.Controls.Add(Me.Ancestry)
        Me.tabAncestry.ImageKey = "Ancestry.png"
        Me.tabAncestry.Location = New System.Drawing.Point(4, 24)
        Me.tabAncestry.Margin = New System.Windows.Forms.Padding(0)
        Me.tabAncestry.Name = "tabAncestry"
        Me.tabAncestry.Size = New System.Drawing.Size(590, 263)
        Me.tabAncestry.TabIndex = 0
        Me.tabAncestry.Text = "Ancestry"
        '
        'Ancestry
        '
        Me.Ancestry.AncestorID = ""
        Me.Ancestry.AncestryPage = ""
        Me.Ancestry.AncestryTreeID = "65171586"
        Me.Ancestry.BlockedWebDomains = New String() {"facebook", "doubleclick", "tiktok", "pinterest", "adservice", "ad-delivery", "adspsp", "adsystem", "adnxs", "securepubads"}
        Me.Ancestry.BlockWebTracking = True
        Me.Ancestry.DataBindings.Add(New System.Windows.Forms.Binding("ShowToolbar", Global.AncestryAssistant.My.MySettings.Default, "ANCESTRY_SHOW_TOOLBAR", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Ancestry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ancestry.HREF = "https://www.ancestry.com/family-tree/tree/65171586/recent"
        Me.Ancestry.Location = New System.Drawing.Point(0, 0)
        Me.Ancestry.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Ancestry.Name = "Ancestry"
        Me.Ancestry.ShowToolbar = Global.AncestryAssistant.My.MySettings.Default.ANCESTRY_SHOW_TOOLBAR
        Me.Ancestry.Size = New System.Drawing.Size(590, 263)
        Me.Ancestry.TabIndex = 0
        Me.Ancestry.UriTrackingGroup = AncestryAssistant.UriTrackingGroupEnum.ANCESTRY
        Me.Ancestry.URL = New System.Uri("https://www.ancestry.com/family-tree/tree/65171586/recent", System.UriKind.Absolute)
        '
        'tabCensus
        '
        Me.tabCensus.Controls.Add(Me.CensusViewer1)
        Me.tabCensus.Location = New System.Drawing.Point(4, 23)
        Me.tabCensus.Margin = New System.Windows.Forms.Padding(0)
        Me.tabCensus.Name = "tabCensus"
        Me.tabCensus.Size = New System.Drawing.Size(590, 264)
        Me.tabCensus.TabIndex = 1
        Me.tabCensus.Text = "Census"
        '
        'CensusViewer1
        '
        Me.CensusViewer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.CensusViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CensusViewer1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CensusViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CensusViewer1.Name = "CensusViewer1"
        Me.CensusViewer1.Size = New System.Drawing.Size(590, 264)
        Me.CensusViewer1.TabIndex = 0
        '
        'tabGallery
        '
        Me.tabGallery.Controls.Add(Me.imgGallery)
        Me.tabGallery.Location = New System.Drawing.Point(4, 24)
        Me.tabGallery.Margin = New System.Windows.Forms.Padding(0)
        Me.tabGallery.Name = "tabGallery"
        Me.tabGallery.Size = New System.Drawing.Size(590, 263)
        Me.tabGallery.TabIndex = 3
        Me.tabGallery.Text = "Gallery"
        '
        'imgGallery
        '
        Me.imgGallery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgGallery.ForeColor = System.Drawing.Color.White
        Me.imgGallery.Location = New System.Drawing.Point(0, 0)
        Me.imgGallery.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.imgGallery.Name = "imgGallery"
        Me.imgGallery.Size = New System.Drawing.Size(590, 263)
        Me.imgGallery.TabIndex = 0
        '
        'tabNotebooks
        '
        Me.tabNotebooks.Controls.Add(Me.NotebookViewer1)
        Me.tabNotebooks.Location = New System.Drawing.Point(4, 23)
        Me.tabNotebooks.Margin = New System.Windows.Forms.Padding(0)
        Me.tabNotebooks.Name = "tabNotebooks"
        Me.tabNotebooks.Size = New System.Drawing.Size(590, 264)
        Me.tabNotebooks.TabIndex = 2
        Me.tabNotebooks.Text = "Notebook"
        '
        'NotebookViewer1
        '
        Me.NotebookViewer1.AllowDrop = True
        Me.NotebookViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotebookViewer1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NotebookViewer1.Location = New System.Drawing.Point(0, 0)
        Me.NotebookViewer1.Name = "NotebookViewer1"
        Me.NotebookViewer1.Size = New System.Drawing.Size(590, 264)
        Me.NotebookViewer1.TabIndex = 0
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
        Me.tsAncestry.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnHomeTree, Me.ToolStripSeparator1, Me.btnViewPedigree, Me.btnViewTree, Me.btnViewFan, Me.ToolStripSeparator2, Me.btnPersonFact, Me.btnPersonHints, Me.btnPersonGallery, Me.btnPersonStory, Me.ToolStripSeparator3, Me.btnAncestor, Me.btnAncestors, Me.ToolStripSeparator4, Me.btnActions})
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
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(899, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
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
        'ApplicationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(899, 340)
        Me.Controls.Add(Me.SplitPanel_Main)
        Me.Controls.Add(Me.toolbar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("ClientSize", Global.AncestryAssistant.My.MySettings.Default, "MainForm_ClientSize", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.AncestryAssistant.My.MySettings.Default, "APP_FONT", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.AncestryAssistant.My.MySettings.Default, "FORM_A_FG", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DoubleBuffered = True
        Me.Font = Global.AncestryAssistant.My.MySettings.Default.APP_FONT
        Me.ForeColor = Global.AncestryAssistant.My.MySettings.Default.FORM_A_FG
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ApplicationForm"
        Me.Text = "Ancestry Assistant"
        Me.SplitPanel_Main.Panel1.ResumeLayout(False)
        Me.SplitPanel_Main.Panel2.ResumeLayout(False)
        CType(Me.SplitPanel_Main, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel_Main.ResumeLayout(False)
        Me.SplitPanel.Panel1.ResumeLayout(False)
        Me.SplitPanel.Panel2.ResumeLayout(False)
        CType(Me.SplitPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitPanel.ResumeLayout(False)
        Me.tabs.ResumeLayout(False)
        Me.tabAncestry.ResumeLayout(False)
        Me.tabCensus.ResumeLayout(False)
        Me.tabGallery.ResumeLayout(False)
        Me.tabNotebooks.ResumeLayout(False)
        Me.mnuPanelDock.ResumeLayout(False)
        Me.tsAncestry.ResumeLayout(False)
        Me.tsAncestry.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.AncestryDirectorWatcher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolbar.ResumeLayout(False)
        Me.toolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgList20 As ImageList
  Friend WithEvents imgList32 As ImageList
  Friend WithEvents imgViewerList As ImageList
  Friend WithEvents SplitPanel_Main As SplitContainer
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
  Friend WithEvents SplitPanel As SplitContainer
  Friend WithEvents MenuStrip1 As MenuStrip
  Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
  Friend WithEvents btnAncestor As ToolStripButton
  Friend WithEvents btnAncestors As ToolStripButton
  Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
  Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents PreferencesToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
  Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents AncestryDirectorWatcher As IO.FileSystemWatcher
  Friend WithEvents mnuPanelDock As ContextMenuStrip
  Friend WithEvents mnuDockTopLeft As ToolStripMenuItem
  Friend WithEvents mnuDockBottomLeft As ToolStripMenuItem
  Friend WithEvents mnuDockTopRight As ToolStripMenuItem
  Friend WithEvents mnuDockBottomRight As ToolStripMenuItem
  Friend WithEvents mnuDockBottomMiddle As ToolStripMenuItem
  Friend WithEvents tabs As TabControl
  Friend WithEvents tabAncestry As TabPage
  Friend WithEvents tabCensus As TabPage
  Friend WithEvents tabNotebooks As TabPage
  Friend WithEvents tabGallery As TabPage
  Friend WithEvents AncestryToolbarToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents NotebookViewer1 As NotebookViewer
  Friend WithEvents imgGallery As ImageGallery
  Friend WithEvents CensusViewer1 As CensusViewer
  Friend WithEvents Ancestry As AncestryWebViewer
  Friend WithEvents toolbar As Panel
  Friend WithEvents btnActions As ToolStripButton
  Friend WithEvents AncestorAttributes As AncestorPanel
  Friend WithEvents AncestorsList As AncestorsListPanel
End Class
