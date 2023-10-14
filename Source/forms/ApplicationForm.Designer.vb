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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApplicationForm))
        Me.imgViewerList = New System.Windows.Forms.ImageList(Me.components)
        Me.imgList20 = New System.Windows.Forms.ImageList(Me.components)
        Me.imgList32 = New System.Windows.Forms.ImageList(Me.components)
        Me.web = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.SplitLeft_Middle = New System.Windows.Forms.SplitContainer()
        Me.SplitLeft = New System.Windows.Forms.SplitContainer()
        Me.AncestorDetails = New System.Windows.Forms.ListView()
        Me.JDockPanelHeader1 = New AncestryAssistant.jDockPanelHeader()
        Me.mnuPanelDock = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDockTopLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockTopRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockBottomLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockBottomMiddle = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockBottomRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.AncestorsList = New System.Windows.Forms.ListView()
        Me.JDockPanelHeader2 = New AncestryAssistant.jDockPanelHeader()
        Me.SplitMiddle = New System.Windows.Forms.SplitContainer()
        Me.tabs = New System.Windows.Forms.TabControl()
        Me.tabAncestry = New System.Windows.Forms.TabPage()
        Me.tsWeb = New System.Windows.Forms.ToolStrip()
        Me.btnBack = New System.Windows.Forms.ToolStripButton()
        Me.btnReload = New System.Windows.Forms.ToolStripButton()
        Me.btnHome = New System.Windows.Forms.ToolStripButton()
        Me.txtHref = New System.Windows.Forms.ToolStripTextBox()
        Me.btnDownload = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
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
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitLeftMiddle_Right = New System.Windows.Forms.SplitContainer()
        Me.SplitRight = New System.Windows.Forms.SplitContainer()
        Me.JDockPanelHeader3 = New AncestryAssistant.jDockPanelHeader()
        Me.JDockPanelHeader4 = New AncestryAssistant.jDockPanelHeader()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblBirthYear = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblPersonName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.AncestryDirectorWatcher = New System.IO.FileSystemWatcher()
        CType(Me.web, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitLeft_Middle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitLeft_Middle.Panel1.SuspendLayout()
        Me.SplitLeft_Middle.Panel2.SuspendLayout()
        Me.SplitLeft_Middle.SuspendLayout()
        CType(Me.SplitLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitLeft.Panel1.SuspendLayout()
        Me.SplitLeft.Panel2.SuspendLayout()
        Me.SplitLeft.SuspendLayout()
        Me.mnuPanelDock.SuspendLayout()
        CType(Me.SplitMiddle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitMiddle.Panel1.SuspendLayout()
        Me.SplitMiddle.Panel2.SuspendLayout()
        Me.SplitMiddle.SuspendLayout()
        Me.tabs.SuspendLayout()
        Me.tabAncestry.SuspendLayout()
        Me.tsWeb.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsAncestry.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitLeftMiddle_Right, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitLeftMiddle_Right.Panel1.SuspendLayout()
        Me.SplitLeftMiddle_Right.Panel2.SuspendLayout()
        Me.SplitLeftMiddle_Right.SuspendLayout()
        CType(Me.SplitRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitRight.Panel1.SuspendLayout()
        Me.SplitRight.Panel2.SuspendLayout()
        Me.SplitRight.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.AncestryDirectorWatcher, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.imgList20.ImageStream = CType(resources.GetObject("imgList20.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList20.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList20.Images.SetKeyName(0, "BIRTH_RED")
        Me.imgList20.Images.SetKeyName(1, "DEATH_RED")
        Me.imgList20.Images.SetKeyName(2, "MARRIED_RED")
        Me.imgList20.Images.SetKeyName(3, "LOCATION_RED")
        Me.imgList20.Images.SetKeyName(4, "ANCESTRY_RED")
        Me.imgList20.Images.SetKeyName(5, "LINK_RED")
        Me.imgList20.Images.SetKeyName(6, "CAL_RED")
        Me.imgList20.Images.SetKeyName(7, "BIRTH_BLACK")
        Me.imgList20.Images.SetKeyName(8, "DEATH_BLACK")
        Me.imgList20.Images.SetKeyName(9, "MARRIED_BLACK")
        Me.imgList20.Images.SetKeyName(10, "LOCATION_BLACK")
        Me.imgList20.Images.SetKeyName(11, "ANCESTRY_BLACK")
        Me.imgList20.Images.SetKeyName(12, "LINK_BLACK")
        Me.imgList20.Images.SetKeyName(13, "CAL_BLACK")
        Me.imgList20.Images.SetKeyName(14, "Ancestry.png")
        '
        'imgList32
        '
        Me.imgList32.ImageStream = CType(resources.GetObject("imgList32.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList32.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList32.Images.SetKeyName(0, "ico_32_Ancestry.png")
        '
        'web
        '
        Me.web.AllowExternalDrop = True
        Me.web.BackColor = System.Drawing.Color.White
        Me.web.CreationProperties = Nothing
        Me.web.DefaultBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.web.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web.Location = New System.Drawing.Point(0, 25)
        Me.web.Margin = New System.Windows.Forms.Padding(0)
        Me.web.Name = "web"
        Me.web.Size = New System.Drawing.Size(351, 288)
        Me.web.Source = New System.Uri("https://www.ancestry.com/family-tree/tree/65171586", System.UriKind.Absolute)
        Me.web.TabIndex = 0
        Me.web.ZoomFactor = 0.75R
        '
        'SplitLeft_Middle
        '
        Me.SplitLeft_Middle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitLeft_Middle.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitLeft_Middle.Location = New System.Drawing.Point(2, 2)
        Me.SplitLeft_Middle.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitLeft_Middle.Name = "SplitLeft_Middle"
        '
        'SplitLeft_Middle.Panel1
        '
        Me.SplitLeft_Middle.Panel1.Controls.Add(Me.SplitLeft)
        '
        'SplitLeft_Middle.Panel2
        '
        Me.SplitLeft_Middle.Panel2.Controls.Add(Me.SplitMiddle)
        Me.SplitLeft_Middle.Size = New System.Drawing.Size(662, 468)
        Me.SplitLeft_Middle.SplitterDistance = 297
        Me.SplitLeft_Middle.TabIndex = 3
        '
        'SplitLeft
        '
        Me.SplitLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitLeft.Location = New System.Drawing.Point(0, 0)
        Me.SplitLeft.Name = "SplitLeft"
        Me.SplitLeft.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitLeft.Panel1
        '
        Me.SplitLeft.Panel1.BackColor = System.Drawing.Color.Silver
        Me.SplitLeft.Panel1.Controls.Add(Me.AncestorDetails)
        Me.SplitLeft.Panel1.Controls.Add(Me.JDockPanelHeader1)
        Me.SplitLeft.Panel1.Padding = New System.Windows.Forms.Padding(1)
        '
        'SplitLeft.Panel2
        '
        Me.SplitLeft.Panel2.BackColor = System.Drawing.Color.Silver
        Me.SplitLeft.Panel2.Controls.Add(Me.AncestorsList)
        Me.SplitLeft.Panel2.Controls.Add(Me.JDockPanelHeader2)
        Me.SplitLeft.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.SplitLeft.Size = New System.Drawing.Size(297, 468)
        Me.SplitLeft.SplitterDistance = 229
        Me.SplitLeft.TabIndex = 3
        '
        'AncestorDetails
        '
        Me.AncestorDetails.AutoArrange = False
        Me.AncestorDetails.BackColor = System.Drawing.Color.White
        Me.AncestorDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AncestorDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AncestorDetails.FullRowSelect = True
        Me.AncestorDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.AncestorDetails.HideSelection = False
        Me.AncestorDetails.Location = New System.Drawing.Point(1, 25)
        Me.AncestorDetails.MultiSelect = False
        Me.AncestorDetails.Name = "AncestorDetails"
        Me.AncestorDetails.Size = New System.Drawing.Size(295, 203)
        Me.AncestorDetails.SmallImageList = Me.imgList20
        Me.AncestorDetails.TabIndex = 2
        Me.AncestorDetails.UseCompatibleStateImageBehavior = False
        Me.AncestorDetails.View = System.Windows.Forms.View.Details
        '
        'JDockPanelHeader1
        '
        Me.JDockPanelHeader1.BackColor = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader1.BackColorDisabled = System.Drawing.Color.LightGray
        Me.JDockPanelHeader1.BackColorEnabled = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader1.Caption = "Ancestor"
        Me.JDockPanelHeader1.ContextMenuStrip = Me.mnuPanelDock
        Me.JDockPanelHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.JDockPanelHeader1.ForeColor = System.Drawing.Color.Black
        Me.JDockPanelHeader1.ForeColorDisabled = System.Drawing.Color.Black
        Me.JDockPanelHeader1.ForeColorEnabled = System.Drawing.Color.Black
        Me.JDockPanelHeader1.Location = New System.Drawing.Point(1, 1)
        Me.JDockPanelHeader1.MaximumSize = New System.Drawing.Size(0, 24)
        Me.JDockPanelHeader1.MinimumSize = New System.Drawing.Size(0, 24)
        Me.JDockPanelHeader1.Name = "JDockPanelHeader1"
        Me.JDockPanelHeader1.Size = New System.Drawing.Size(295, 24)
        Me.JDockPanelHeader1.TabIndex = 1
        Me.JDockPanelHeader1.Tag = "TOP_LEFT"
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
        Me.mnuDockTopLeft.Image = Global.AncestryAssistant.My.Resources.Resources.Panel_Top_Left
        Me.mnuDockTopLeft.Name = "mnuDockTopLeft"
        Me.mnuDockTopLeft.Size = New System.Drawing.Size(184, 22)
        Me.mnuDockTopLeft.Text = "Dock Top-Left"
        '
        'mnuDockTopRight
        '
        Me.mnuDockTopRight.Image = Global.AncestryAssistant.My.Resources.Resources.Panel_Top_Right
        Me.mnuDockTopRight.Name = "mnuDockTopRight"
        Me.mnuDockTopRight.Size = New System.Drawing.Size(184, 22)
        Me.mnuDockTopRight.Text = "Dock Top-Right"
        '
        'mnuDockBottomLeft
        '
        Me.mnuDockBottomLeft.Image = Global.AncestryAssistant.My.Resources.Resources.Panel_Bottom_Left
        Me.mnuDockBottomLeft.Name = "mnuDockBottomLeft"
        Me.mnuDockBottomLeft.Size = New System.Drawing.Size(184, 22)
        Me.mnuDockBottomLeft.Text = "Dock Bottom-Left"
        '
        'mnuDockBottomMiddle
        '
        Me.mnuDockBottomMiddle.Image = Global.AncestryAssistant.My.Resources.Resources.Panel_Bottom_Center
        Me.mnuDockBottomMiddle.Name = "mnuDockBottomMiddle"
        Me.mnuDockBottomMiddle.Size = New System.Drawing.Size(184, 22)
        Me.mnuDockBottomMiddle.Text = "Dock Bottom-Center"
        '
        'mnuDockBottomRight
        '
        Me.mnuDockBottomRight.Image = Global.AncestryAssistant.My.Resources.Resources.Panel_Bottom_Right
        Me.mnuDockBottomRight.Name = "mnuDockBottomRight"
        Me.mnuDockBottomRight.Size = New System.Drawing.Size(184, 22)
        Me.mnuDockBottomRight.Text = "Dock Bottom-Right"
        '
        'AncestorsList
        '
        Me.AncestorsList.AutoArrange = False
        Me.AncestorsList.BackColor = System.Drawing.Color.White
        Me.AncestorsList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AncestorsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AncestorsList.FullRowSelect = True
        Me.AncestorsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.AncestorsList.HideSelection = False
        Me.AncestorsList.Location = New System.Drawing.Point(1, 25)
        Me.AncestorsList.MultiSelect = False
        Me.AncestorsList.Name = "AncestorsList"
        Me.AncestorsList.Size = New System.Drawing.Size(295, 209)
        Me.AncestorsList.SmallImageList = Me.imgList20
        Me.AncestorsList.TabIndex = 3
        Me.AncestorsList.UseCompatibleStateImageBehavior = False
        Me.AncestorsList.View = System.Windows.Forms.View.Details
        '
        'JDockPanelHeader2
        '
        Me.JDockPanelHeader2.BackColor = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader2.BackColorDisabled = System.Drawing.Color.LightGray
        Me.JDockPanelHeader2.BackColorEnabled = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader2.Caption = "Ancestors Research List"
        Me.JDockPanelHeader2.ContextMenuStrip = Me.mnuPanelDock
        Me.JDockPanelHeader2.Dock = System.Windows.Forms.DockStyle.Top
        Me.JDockPanelHeader2.ForeColor = System.Drawing.Color.Black
        Me.JDockPanelHeader2.ForeColorDisabled = System.Drawing.Color.Black
        Me.JDockPanelHeader2.ForeColorEnabled = System.Drawing.Color.Black
        Me.JDockPanelHeader2.Location = New System.Drawing.Point(1, 1)
        Me.JDockPanelHeader2.MaximumSize = New System.Drawing.Size(0, 24)
        Me.JDockPanelHeader2.MinimumSize = New System.Drawing.Size(0, 24)
        Me.JDockPanelHeader2.Name = "JDockPanelHeader2"
        Me.JDockPanelHeader2.Size = New System.Drawing.Size(295, 24)
        Me.JDockPanelHeader2.TabIndex = 2
        Me.JDockPanelHeader2.Tag = "BOTTOM_LEFT"
        '
        'SplitMiddle
        '
        Me.SplitMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitMiddle.Location = New System.Drawing.Point(0, 0)
        Me.SplitMiddle.Name = "SplitMiddle"
        Me.SplitMiddle.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitMiddle.Panel1
        '
        Me.SplitMiddle.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.SplitMiddle.Panel1.Controls.Add(Me.tabs)
        Me.SplitMiddle.Panel1.Padding = New System.Windows.Forms.Padding(1)
        '
        'SplitMiddle.Panel2
        '
        Me.SplitMiddle.Panel2.BackColor = System.Drawing.Color.Silver
        Me.SplitMiddle.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitMiddle.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.SplitMiddle.Size = New System.Drawing.Size(361, 468)
        Me.SplitMiddle.SplitterDistance = 343
        Me.SplitMiddle.TabIndex = 0
        '
        'tabs
        '
        Me.tabs.Controls.Add(Me.tabAncestry)
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.ImageList = Me.imgList20
        Me.tabs.Location = New System.Drawing.Point(1, 1)
        Me.tabs.Margin = New System.Windows.Forms.Padding(0)
        Me.tabs.Name = "tabs"
        Me.tabs.Padding = New System.Drawing.Point(0, 0)
        Me.tabs.SelectedIndex = 0
        Me.tabs.Size = New System.Drawing.Size(359, 341)
        Me.tabs.TabIndex = 3
        '
        'tabAncestry
        '
        Me.tabAncestry.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tabAncestry.Controls.Add(Me.web)
        Me.tabAncestry.Controls.Add(Me.tsWeb)
        Me.tabAncestry.ImageKey = "Ancestry.png"
        Me.tabAncestry.Location = New System.Drawing.Point(4, 24)
        Me.tabAncestry.Margin = New System.Windows.Forms.Padding(0)
        Me.tabAncestry.Name = "tabAncestry"
        Me.tabAncestry.Size = New System.Drawing.Size(351, 313)
        Me.tabAncestry.TabIndex = 0
        Me.tabAncestry.Text = "Ancestry"
        Me.tabAncestry.UseVisualStyleBackColor = True
        '
        'tsWeb
        '
        Me.tsWeb.CanOverflow = False
        Me.tsWeb.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tsWeb.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsWeb.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBack, Me.btnReload, Me.btnHome, Me.txtHref, Me.btnDownload})
        Me.tsWeb.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tsWeb.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
        Me.tsWeb.Name = "tsWeb"
        Me.tsWeb.Padding = New System.Windows.Forms.Padding(4, 0, 16, 0)
        Me.tsWeb.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsWeb.Size = New System.Drawing.Size(351, 25)
        Me.tsWeb.Stretch = True
        Me.tsWeb.TabIndex = 2
        '
        'btnBack
        '
        Me.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBack.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__36
        Me.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(23, 22)
        Me.btnBack.Text = "ToolStripButton2"
        Me.btnBack.ToolTipText = "Previous Page"
        '
        'btnReload
        '
        Me.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnReload.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__191
        Me.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(23, 22)
        Me.btnReload.Text = "ToolStripButton1"
        Me.btnReload.ToolTipText = "Refresh"
        '
        'btnHome
        '
        Me.btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnHome.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_home
        Me.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(23, 22)
        Me.btnHome.Text = "ToolStripButton1"
        Me.btnHome.ToolTipText = "Ancestry Home Page"
        '
        'txtHref
        '
        Me.txtHref.AutoSize = False
        Me.txtHref.BackColor = System.Drawing.SystemColors.Window
        Me.txtHref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHref.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHref.Name = "txtHref"
        Me.txtHref.Size = New System.Drawing.Size(100, 23)
        Me.txtHref.ToolTipText = "Website URL"
        '
        'btnDownload
        '
        Me.btnDownload.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnDownload.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__50
        Me.btnDownload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(23, 22)
        Me.btnDownload.Text = "Download"
        Me.btnDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnDownload.ToolTipText = "Download Available Information"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(1, 1)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(359, 119)
        Me.DataGridView1.TabIndex = 0
        '
        'tsAncestry
        '
        Me.tsAncestry.BackColor = System.Drawing.SystemColors.ControlLight
        Me.tsAncestry.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_ANCESTRY_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tsAncestry.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsAncestry.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnHomeTree, Me.ToolStripSeparator1, Me.btnViewPedigree, Me.btnViewTree, Me.btnViewFan, Me.ToolStripSeparator2, Me.btnPersonFact, Me.btnPersonHints, Me.btnPersonGallery, Me.btnPersonStory, Me.ToolStripSeparator3, Me.btnAncestor, Me.btnAncestors, Me.ToolStripSeparator4, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4})
        Me.tsAncestry.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tsAncestry.Location = Global.AncestryAssistant.My.MySettings.Default.TB_ANCESTRY_LOC
        Me.tsAncestry.Name = "tsAncestry"
        Me.tsAncestry.Padding = New System.Windows.Forms.Padding(4, 0, 1, 0)
        Me.tsAncestry.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsAncestry.Size = New System.Drawing.Size(892, 25)
        Me.tsAncestry.TabIndex = 3
        Me.tsAncestry.Text = "Ancestry"
        '
        'btnHomeTree
        '
        Me.btnHomeTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnHomeTree.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__179
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
        Me.btnViewPedigree.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__117
        Me.btnViewPedigree.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnViewPedigree.Name = "btnViewPedigree"
        Me.btnViewPedigree.Size = New System.Drawing.Size(23, 22)
        Me.btnViewPedigree.Text = "ToolStripButton2"
        Me.btnViewPedigree.ToolTipText = "Active Ancestor - Pedigree View"
        '
        'btnViewTree
        '
        Me.btnViewTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnViewTree.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__118
        Me.btnViewTree.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnViewTree.Name = "btnViewTree"
        Me.btnViewTree.Size = New System.Drawing.Size(23, 22)
        Me.btnViewTree.Text = "ToolStripButton3"
        Me.btnViewTree.ToolTipText = "Active Ancestor - Tree View"
        '
        'btnViewFan
        '
        Me.btnViewFan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnViewFan.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black_fan
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
        Me.btnPersonFact.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__751
        Me.btnPersonFact.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPersonFact.Name = "btnPersonFact"
        Me.btnPersonFact.Size = New System.Drawing.Size(23, 22)
        Me.btnPersonFact.Text = "ToolStripButton5"
        Me.btnPersonFact.ToolTipText = "Active Ancestor - Facts"
        '
        'btnPersonHints
        '
        Me.btnPersonHints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPersonHints.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__05
        Me.btnPersonHints.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPersonHints.Name = "btnPersonHints"
        Me.btnPersonHints.Size = New System.Drawing.Size(23, 22)
        Me.btnPersonHints.Text = "ToolStripButton6"
        Me.btnPersonHints.ToolTipText = "Active Ancestor - Hints"
        '
        'btnPersonGallery
        '
        Me.btnPersonGallery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPersonGallery.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__138
        Me.btnPersonGallery.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPersonGallery.Name = "btnPersonGallery"
        Me.btnPersonGallery.Size = New System.Drawing.Size(23, 22)
        Me.btnPersonGallery.Text = "ToolStripButton7"
        Me.btnPersonGallery.ToolTipText = "Active Ancestor - Gallery"
        '
        'btnPersonStory
        '
        Me.btnPersonStory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPersonStory.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__38
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
        Me.btnAncestor.CheckOnClick = True
        Me.btnAncestor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAncestor.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__181
        Me.btnAncestor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAncestor.Name = "btnAncestor"
        Me.btnAncestor.Size = New System.Drawing.Size(23, 22)
        Me.btnAncestor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnAncestor.ToolTipText = "Ancestor Panel"
        '
        'btnAncestors
        '
        Me.btnAncestors.CheckOnClick = True
        Me.btnAncestors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAncestors.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__84
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.CheckOnClick = True
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.AncestryAssistant.My.Resources.Resources.Ancestry
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.CheckOnClick = True
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.AncestryAssistant.My.Resources.Resources.Ancestry1
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.CheckOnClick = True
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.AncestryAssistant.My.Resources.Resources.AsymmetricKeyError
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.AncestryAssistant.My.Resources.Resources.AddAgent
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "ToolStripButton4"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(892, 24)
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
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.PreferencesToolStripMenuItem.Text = "Preferences"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(177, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'SplitLeftMiddle_Right
        '
        Me.SplitLeftMiddle_Right.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitLeftMiddle_Right.Location = New System.Drawing.Point(0, 49)
        Me.SplitLeftMiddle_Right.Name = "SplitLeftMiddle_Right"
        '
        'SplitLeftMiddle_Right.Panel1
        '
        Me.SplitLeftMiddle_Right.Panel1.Controls.Add(Me.SplitLeft_Middle)
        Me.SplitLeftMiddle_Right.Panel1.Padding = New System.Windows.Forms.Padding(2, 2, 0, 2)
        '
        'SplitLeftMiddle_Right.Panel2
        '
        Me.SplitLeftMiddle_Right.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.SplitLeftMiddle_Right.Panel2.Controls.Add(Me.SplitRight)
        Me.SplitLeftMiddle_Right.Panel2.Padding = New System.Windows.Forms.Padding(0, 2, 2, 2)
        Me.SplitLeftMiddle_Right.Size = New System.Drawing.Size(892, 472)
        Me.SplitLeftMiddle_Right.SplitterDistance = 664
        Me.SplitLeftMiddle_Right.TabIndex = 8
        '
        'SplitRight
        '
        Me.SplitRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitRight.Location = New System.Drawing.Point(0, 2)
        Me.SplitRight.Name = "SplitRight"
        Me.SplitRight.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitRight.Panel1
        '
        Me.SplitRight.Panel1.BackColor = System.Drawing.Color.Silver
        Me.SplitRight.Panel1.Controls.Add(Me.JDockPanelHeader3)
        Me.SplitRight.Panel1.Padding = New System.Windows.Forms.Padding(1)
        '
        'SplitRight.Panel2
        '
        Me.SplitRight.Panel2.BackColor = System.Drawing.Color.Silver
        Me.SplitRight.Panel2.Controls.Add(Me.JDockPanelHeader4)
        Me.SplitRight.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.SplitRight.Size = New System.Drawing.Size(222, 468)
        Me.SplitRight.SplitterDistance = 229
        Me.SplitRight.TabIndex = 9
        '
        'JDockPanelHeader3
        '
        Me.JDockPanelHeader3.BackColor = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader3.BackColorDisabled = System.Drawing.Color.LightGray
        Me.JDockPanelHeader3.BackColorEnabled = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader3.Caption = "jDockPanelHeader"
        Me.JDockPanelHeader3.ContextMenuStrip = Me.mnuPanelDock
        Me.JDockPanelHeader3.Dock = System.Windows.Forms.DockStyle.Top
        Me.JDockPanelHeader3.ForeColor = System.Drawing.Color.Black
        Me.JDockPanelHeader3.ForeColorDisabled = System.Drawing.Color.Black
        Me.JDockPanelHeader3.ForeColorEnabled = System.Drawing.Color.Black
        Me.JDockPanelHeader3.Location = New System.Drawing.Point(1, 1)
        Me.JDockPanelHeader3.MaximumSize = New System.Drawing.Size(0, 24)
        Me.JDockPanelHeader3.MinimumSize = New System.Drawing.Size(0, 24)
        Me.JDockPanelHeader3.Name = "JDockPanelHeader3"
        Me.JDockPanelHeader3.Size = New System.Drawing.Size(220, 24)
        Me.JDockPanelHeader3.TabIndex = 0
        Me.JDockPanelHeader3.Tag = "TOP_RIGHT"
        '
        'JDockPanelHeader4
        '
        Me.JDockPanelHeader4.BackColor = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader4.BackColorDisabled = System.Drawing.Color.LightGray
        Me.JDockPanelHeader4.BackColorEnabled = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader4.Caption = "jDockPanelHeader"
        Me.JDockPanelHeader4.ContextMenuStrip = Me.mnuPanelDock
        Me.JDockPanelHeader4.Dock = System.Windows.Forms.DockStyle.Top
        Me.JDockPanelHeader4.ForeColor = System.Drawing.Color.Black
        Me.JDockPanelHeader4.ForeColorDisabled = System.Drawing.Color.Black
        Me.JDockPanelHeader4.ForeColorEnabled = System.Drawing.Color.Black
        Me.JDockPanelHeader4.Location = New System.Drawing.Point(1, 1)
        Me.JDockPanelHeader4.MaximumSize = New System.Drawing.Size(0, 24)
        Me.JDockPanelHeader4.MinimumSize = New System.Drawing.Size(0, 24)
        Me.JDockPanelHeader4.Name = "JDockPanelHeader4"
        Me.JDockPanelHeader4.Size = New System.Drawing.Size(220, 24)
        Me.JDockPanelHeader4.TabIndex = 0
        Me.JDockPanelHeader4.Tag = "BOTTOM_RIGHT"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.lblBirthYear, Me.lblPersonName, Me.lblID})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 521)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(892, 25)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.MenuBar
        Me.lblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(689, 20)
        Me.lblStatus.Spring = True
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBirthYear
        '
        Me.lblBirthYear.BackColor = System.Drawing.SystemColors.MenuBar
        Me.lblBirthYear.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblBirthYear.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblBirthYear.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__145
        Me.lblBirthYear.Name = "lblBirthYear"
        Me.lblBirthYear.Size = New System.Drawing.Size(55, 20)
        Me.lblBirthYear.Text = "YYYY"
        '
        'lblPersonName
        '
        Me.lblPersonName.BackColor = System.Drawing.SystemColors.MenuBar
        Me.lblPersonName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblPersonName.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblPersonName.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__75
        Me.lblPersonName.Name = "lblPersonName"
        Me.lblPersonName.Size = New System.Drawing.Size(95, 20)
        Me.lblPersonName.Text = "Active Name"
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.SystemColors.MenuBar
        Me.lblID.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblID.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblID.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__131
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(38, 20)
        Me.lblID.Text = "ID"
        '
        'AncestryDirectorWatcher
        '
        Me.AncestryDirectorWatcher.EnableRaisingEvents = True
        Me.AncestryDirectorWatcher.Path = Global.AncestryAssistant.My.MySettings.Default.AncestorsPath
        Me.AncestryDirectorWatcher.SynchronizingObject = Me
        '
        'ApplicationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.ClientSize = Global.AncestryAssistant.My.MySettings.Default.MainForm_ClientSize
        Me.Controls.Add(Me.SplitLeftMiddle_Right)
        Me.Controls.Add(Me.tsAncestry)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("ClientSize", Global.AncestryAssistant.My.MySettings.Default, "MainForm_ClientSize", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ApplicationForm"
        Me.Text = "Ancestry Assistant"
        CType(Me.web, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitLeft_Middle.Panel1.ResumeLayout(False)
        Me.SplitLeft_Middle.Panel2.ResumeLayout(False)
        CType(Me.SplitLeft_Middle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitLeft_Middle.ResumeLayout(False)
        Me.SplitLeft.Panel1.ResumeLayout(False)
        Me.SplitLeft.Panel2.ResumeLayout(False)
        CType(Me.SplitLeft, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitLeft.ResumeLayout(False)
        Me.mnuPanelDock.ResumeLayout(False)
        Me.SplitMiddle.Panel1.ResumeLayout(False)
        Me.SplitMiddle.Panel2.ResumeLayout(False)
        CType(Me.SplitMiddle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitMiddle.ResumeLayout(False)
        Me.tabs.ResumeLayout(False)
        Me.tabAncestry.ResumeLayout(False)
        Me.tabAncestry.PerformLayout()
        Me.tsWeb.ResumeLayout(False)
        Me.tsWeb.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsAncestry.ResumeLayout(False)
        Me.tsAncestry.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitLeftMiddle_Right.Panel1.ResumeLayout(False)
        Me.SplitLeftMiddle_Right.Panel2.ResumeLayout(False)
        CType(Me.SplitLeftMiddle_Right, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitLeftMiddle_Right.ResumeLayout(False)
        Me.SplitRight.Panel1.ResumeLayout(False)
        Me.SplitRight.Panel2.ResumeLayout(False)
        CType(Me.SplitRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitRight.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.AncestryDirectorWatcher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgList20 As ImageList
    Friend WithEvents imgList32 As ImageList
    Friend WithEvents JImageViewer1 As jImageViewer
    Friend WithEvents imgViewerList As ImageList
    Friend WithEvents web As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents SplitLeft_Middle As SplitContainer
    Friend WithEvents JDockPanelHeader1 As jDockPanelHeader
    Friend WithEvents AncestorDetails As ListView
    Friend WithEvents tsWeb As ToolStrip
    Friend WithEvents btnHome As ToolStripButton
    Friend WithEvents txtHref As ToolStripTextBox
    Friend WithEvents btnBack As ToolStripButton
    Friend WithEvents tsAncestry As ToolStrip
    Friend WithEvents btnReload As ToolStripButton
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
    Friend WithEvents btnDownload As ToolStripButton
    Friend WithEvents SplitLeft As SplitContainer
    Friend WithEvents AncestorsList As ListView
    Friend WithEvents JDockPanelHeader2 As jDockPanelHeader
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents SplitLeftMiddle_Right As SplitContainer
    Friend WithEvents SplitMiddle As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SplitRight As SplitContainer
    Friend WithEvents JDockPanelHeader3 As jDockPanelHeader
    Friend WithEvents JDockPanelHeader4 As jDockPanelHeader
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblBirthYear As ToolStripStatusLabel
    Friend WithEvents lblPersonName As ToolStripStatusLabel
    Friend WithEvents lblID As ToolStripStatusLabel
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents btnAncestor As ToolStripButton
    Friend WithEvents btnAncestors As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
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
    Friend WithEvents ToolStripButton4 As ToolStripButton
End Class