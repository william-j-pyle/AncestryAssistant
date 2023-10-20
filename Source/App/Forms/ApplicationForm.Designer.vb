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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApplicationForm))
        Me.imgViewerList = New System.Windows.Forms.ImageList(Me.components)
        Me.imgList20 = New System.Windows.Forms.ImageList(Me.components)
        Me.imgList32 = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitLeft_Middle = New System.Windows.Forms.SplitContainer()
        Me.SplitLeft = New System.Windows.Forms.SplitContainer()
        Me.AncestorDetails = New System.Windows.Forms.ListView()
        Me.JDockPanelHeader1 = New AncestryAssistant.DockHeaderPanel()
        Me.mnuPanelDock = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDockTopLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockTopRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockBottomLeft = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockBottomMiddle = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDockBottomRight = New System.Windows.Forms.ToolStripMenuItem()
        Me.AncestorsList = New System.Windows.Forms.ListView()
        Me.JDockPanelHeader2 = New AncestryAssistant.DockHeaderPanel()
        Me.SplitMiddle = New System.Windows.Forms.SplitContainer()
        Me.tabs = New System.Windows.Forms.TabControl()
        Me.tabAncestry = New System.Windows.Forms.TabPage()
        Me.Ancestry = New AncestryAssistant.AncestryWebViewer()
        Me.tabCensus = New System.Windows.Forms.TabPage()
        Me.CensusViewer1 = New AncestryAssistant.CensusViewer()
        Me.tabGallery = New System.Windows.Forms.TabPage()
        Me.imgViewer = New AncestryAssistant.ImageViewer()
        Me.imgGallery = New AncestryAssistant.ImageGallery()
        Me.tabNotebooks = New System.Windows.Forms.TabPage()
        Me.NotebookViewer1 = New AncestryAssistant.NotebookViewer()
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
        Me.AncestryToolbarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitLeftMiddle_Right = New System.Windows.Forms.SplitContainer()
        Me.SplitRight = New System.Windows.Forms.SplitContainer()
        Me.AncestorAttributes = New System.Windows.Forms.TreeView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.JPanel2 = New AncestryAssistant.BordersPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.JPanel1 = New AncestryAssistant.BordersPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.JDockPanelHeader3 = New AncestryAssistant.DockHeaderPanel()
        Me.JDockPanelHeader4 = New AncestryAssistant.DockHeaderPanel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblBirthYear = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblPersonName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.AncestryDirectorWatcher = New System.IO.FileSystemWatcher()
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
        Me.tabCensus.SuspendLayout()
        Me.tabGallery.SuspendLayout()
        Me.tabNotebooks.SuspendLayout()
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
        Me.Panel1.SuspendLayout()
        Me.JPanel2.SuspendLayout()
        Me.JPanel1.SuspendLayout()
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
        Me.SplitLeft_Middle.Size = New System.Drawing.Size(659, 468)
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
        Me.SplitMiddle.Size = New System.Drawing.Size(358, 468)
        Me.SplitMiddle.SplitterDistance = 343
        Me.SplitMiddle.TabIndex = 0
        '
        'tabs
        '
        Me.tabs.Controls.Add(Me.tabAncestry)
        Me.tabs.Controls.Add(Me.tabCensus)
        Me.tabs.Controls.Add(Me.tabGallery)
        Me.tabs.Controls.Add(Me.tabNotebooks)
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.ImageList = Me.imgList20
        Me.tabs.Location = New System.Drawing.Point(1, 1)
        Me.tabs.Margin = New System.Windows.Forms.Padding(0)
        Me.tabs.Name = "tabs"
        Me.tabs.Padding = New System.Drawing.Point(0, 0)
        Me.tabs.SelectedIndex = 0
        Me.tabs.Size = New System.Drawing.Size(356, 341)
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
        Me.tabAncestry.Size = New System.Drawing.Size(348, 313)
        Me.tabAncestry.TabIndex = 0
        Me.tabAncestry.Text = "Ancestry"
        '
        'Ancestry
        '
        Me.Ancestry.AncestorID = ""
        Me.Ancestry.AncestryBaseURL = "https://www.ancestry.com/"
        Me.Ancestry.AncestryPage = ""
        Me.Ancestry.AncestryTreeID = "65171586"
        Me.Ancestry.BlockedWebDomains = New String() {"facebook", "doubleclick", "tiktok", "pinterest", "adservice"}
        Me.Ancestry.BlockWebTracking = False
        Me.Ancestry.BrowserStatus = ""
        Me.Ancestry.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Ancestry.HREF = "https://www.ancestry.com/"
        Me.Ancestry.Location = New System.Drawing.Point(0, 0)
        Me.Ancestry.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Ancestry.Name = "Ancestry"
        Me.Ancestry.ShowDownload = False
        Me.Ancestry.ShowToolbar = True
        Me.Ancestry.Size = New System.Drawing.Size(348, 313)
        Me.Ancestry.TabIndex = 0
        Me.Ancestry.URL = New System.Uri("https://www.ancestry.com/", System.UriKind.Absolute)
        '
        'tabCensus
        '
        Me.tabCensus.Controls.Add(Me.CensusViewer1)
        Me.tabCensus.Location = New System.Drawing.Point(4, 23)
        Me.tabCensus.Margin = New System.Windows.Forms.Padding(0)
        Me.tabCensus.Name = "tabCensus"
        Me.tabCensus.Size = New System.Drawing.Size(348, 314)
        Me.tabCensus.TabIndex = 1
        Me.tabCensus.Text = "Census"
        '
        'CensusViewer1
        '
        Me.CensusViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CensusViewer1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CensusViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CensusViewer1.Name = "CensusViewer1"
        Me.CensusViewer1.Size = New System.Drawing.Size(348, 314)
        Me.CensusViewer1.TabIndex = 0
        '
        'tabGallery
        '
        Me.tabGallery.Controls.Add(Me.imgViewer)
        Me.tabGallery.Controls.Add(Me.imgGallery)
        Me.tabGallery.Location = New System.Drawing.Point(4, 23)
        Me.tabGallery.Margin = New System.Windows.Forms.Padding(0)
        Me.tabGallery.Name = "tabGallery"
        Me.tabGallery.Size = New System.Drawing.Size(348, 314)
        Me.tabGallery.TabIndex = 3
        Me.tabGallery.Text = "Gallery"
        '
        'imgViewer
        '
        Me.imgViewer.BackColor = System.Drawing.Color.White
        Me.imgViewer.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.imgViewer.ForeColor = System.Drawing.Color.White
        Me.imgViewer.ImageFile = ""
        Me.imgViewer.Location = New System.Drawing.Point(0, 165)
        Me.imgViewer.Margin = New System.Windows.Forms.Padding(0)
        Me.imgViewer.MouseSmoothingFactor = 0.1R
        Me.imgViewer.Name = "imgViewer"
        Me.imgViewer.PanningEnabled = True
        Me.imgViewer.Size = New System.Drawing.Size(300, 100)
        Me.imgViewer.TabIndex = 1
        Me.imgViewer.ToolbarEnabled = False
        Me.imgViewer.ZoomEnabled = True
        Me.imgViewer.ZoomFactor = 100
        '
        'imgGallery
        '
        Me.imgGallery.ForeColor = System.Drawing.Color.White
        Me.imgGallery.GalleryPath = "D:\Geneology\Ancestors\Pyles, William Charlie - 1918\"
        Me.imgGallery.Location = New System.Drawing.Point(0, 0)
        Me.imgGallery.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.imgGallery.Name = "imgGallery"
        Me.imgGallery.Size = New System.Drawing.Size(332, 141)
        Me.imgGallery.TabIndex = 0
        '
        'tabNotebooks
        '
        Me.tabNotebooks.Controls.Add(Me.NotebookViewer1)
        Me.tabNotebooks.Location = New System.Drawing.Point(4, 23)
        Me.tabNotebooks.Margin = New System.Windows.Forms.Padding(0)
        Me.tabNotebooks.Name = "tabNotebooks"
        Me.tabNotebooks.Size = New System.Drawing.Size(348, 314)
        Me.tabNotebooks.TabIndex = 2
        Me.tabNotebooks.Text = "Notebooks"
        '
        'NotebookViewer1
        '
        Me.NotebookViewer1.AllowDrop = True
        Me.NotebookViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotebookViewer1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NotebookViewer1.Location = New System.Drawing.Point(0, 0)
        Me.NotebookViewer1.Name = "NotebookViewer1"
        Me.NotebookViewer1.Size = New System.Drawing.Size(348, 314)
        Me.NotebookViewer1.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(1, 1)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(356, 119)
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
        Me.btnAncestor.CheckOnClick = True
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
        Me.btnAncestors.CheckOnClick = True
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.CheckOnClick = True
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.CheckOnClick = True
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.CheckOnClick = True
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.AncestryAssistant.My.Resources.Resources.ALERT_TRIANGLE_ICO20
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.AncestryAssistant.My.Resources.Resources.USER_PLUS_ICO20
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
        Me.AncestryToolbarToolStripMenuItem.Checked = True
        Me.AncestryToolbarToolStripMenuItem.CheckOnClick = True
        Me.AncestryToolbarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
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
        Me.SplitLeftMiddle_Right.SplitterDistance = 661
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
        Me.SplitRight.Panel1.Controls.Add(Me.AncestorAttributes)
        Me.SplitRight.Panel1.Controls.Add(Me.Panel1)
        Me.SplitRight.Panel1.Controls.Add(Me.JDockPanelHeader3)
        Me.SplitRight.Panel1.Padding = New System.Windows.Forms.Padding(1)
        '
        'SplitRight.Panel2
        '
        Me.SplitRight.Panel2.BackColor = System.Drawing.Color.Silver
        Me.SplitRight.Panel2.Controls.Add(Me.JDockPanelHeader4)
        Me.SplitRight.Panel2.Padding = New System.Windows.Forms.Padding(1)
        Me.SplitRight.Size = New System.Drawing.Size(225, 468)
        Me.SplitRight.SplitterDistance = 229
        Me.SplitRight.TabIndex = 9
        '
        'AncestorAttributes
        '
        Me.AncestorAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AncestorAttributes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AncestorAttributes.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText
        Me.AncestorAttributes.FullRowSelect = True
        Me.AncestorAttributes.HotTracking = True
        Me.AncestorAttributes.Location = New System.Drawing.Point(1, 43)
        Me.AncestorAttributes.Margin = New System.Windows.Forms.Padding(0)
        Me.AncestorAttributes.Name = "AncestorAttributes"
        Me.AncestorAttributes.ShowLines = False
        Me.AncestorAttributes.Size = New System.Drawing.Size(223, 185)
        Me.AncestorAttributes.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.JPanel2)
        Me.Panel1.Controls.Add(Me.JPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 25)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.MaximumSize = New System.Drawing.Size(0, 18)
        Me.Panel1.MinimumSize = New System.Drawing.Size(0, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(223, 18)
        Me.Panel1.TabIndex = 2
        '
        'JPanel2
        '
        Me.JPanel2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.JPanel2.BorderColor = System.Drawing.Color.Transparent
        Me.JPanel2.BorderColorBottom = System.Drawing.SystemColors.ButtonShadow
        Me.JPanel2.BorderColorLeft = System.Drawing.SystemColors.ButtonHighlight
        Me.JPanel2.BorderColorRight = System.Drawing.SystemColors.ButtonShadow
        Me.JPanel2.BorderColorTop = System.Drawing.SystemColors.ButtonShadow
        Me.JPanel2.BorderWidth = New System.Windows.Forms.Padding(1, 0, 1, 1)
        Me.JPanel2.Controls.Add(Me.Label1)
        Me.JPanel2.CornerRadius = New System.Windows.Forms.Padding(0)
        Me.JPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.JPanel2.Location = New System.Drawing.Point(150, 0)
        Me.JPanel2.Name = "JPanel2"
        Me.JPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.JPanel2.Size = New System.Drawing.Size(73, 18)
        Me.JPanel2.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Value"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'JPanel1
        '
        Me.JPanel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.JPanel1.BorderColor = System.Drawing.Color.Transparent
        Me.JPanel1.BorderColorBottom = System.Drawing.SystemColors.ButtonShadow
        Me.JPanel1.BorderColorLeft = System.Drawing.SystemColors.ButtonShadow
        Me.JPanel1.BorderColorRight = System.Drawing.SystemColors.ButtonShadow
        Me.JPanel1.BorderColorTop = System.Drawing.SystemColors.ButtonShadow
        Me.JPanel1.BorderWidth = New System.Windows.Forms.Padding(0, 0, 1, 1)
        Me.JPanel1.Controls.Add(Me.Label2)
        Me.JPanel1.CornerRadius = New System.Windows.Forms.Padding(0)
        Me.JPanel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.JPanel1.Location = New System.Drawing.Point(0, 0)
        Me.JPanel1.MaximumSize = New System.Drawing.Size(150, 0)
        Me.JPanel1.MinimumSize = New System.Drawing.Size(150, 0)
        Me.JPanel1.Name = "JPanel1"
        Me.JPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.JPanel1.Size = New System.Drawing.Size(150, 18)
        Me.JPanel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(1, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(148, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Attribute"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.JDockPanelHeader3.Size = New System.Drawing.Size(223, 24)
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
        Me.JDockPanelHeader4.Size = New System.Drawing.Size(223, 24)
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
        Me.lblBirthYear.Image = Global.AncestryAssistant.My.Resources.Resources.CALENDAR_ICO20
        Me.lblBirthYear.Name = "lblBirthYear"
        Me.lblBirthYear.Size = New System.Drawing.Size(55, 20)
        Me.lblBirthYear.Text = "YYYY"
        '
        'lblPersonName
        '
        Me.lblPersonName.BackColor = System.Drawing.SystemColors.MenuBar
        Me.lblPersonName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblPersonName.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblPersonName.Image = Global.AncestryAssistant.My.Resources.Resources.USER_ICO20
        Me.lblPersonName.Name = "lblPersonName"
        Me.lblPersonName.Size = New System.Drawing.Size(95, 20)
        Me.lblPersonName.Text = "Active Name"
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.SystemColors.MenuBar
        Me.lblID.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.lblID.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.lblID.Image = CType(resources.GetObject("lblID.Image"), System.Drawing.Image)
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
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.AncestryAssistant.My.MySettings.Default, "APP_FONT", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.AncestryAssistant.My.MySettings.Default, "FORM_A_FG", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.DoubleBuffered = True
        Me.Font = Global.AncestryAssistant.My.MySettings.Default.APP_FONT
        Me.ForeColor = Global.AncestryAssistant.My.MySettings.Default.FORM_A_FG
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ApplicationForm"
        Me.Text = "Ancestry Assistant"
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
        Me.tabCensus.ResumeLayout(False)
        Me.tabGallery.ResumeLayout(False)
        Me.tabNotebooks.ResumeLayout(False)
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
        Me.Panel1.ResumeLayout(False)
        Me.JPanel2.ResumeLayout(False)
        Me.JPanel1.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.AncestryDirectorWatcher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgList20 As ImageList
    Friend WithEvents imgList32 As ImageList
  Friend WithEvents imgViewerList As ImageList
  Friend WithEvents SplitLeft_Middle As SplitContainer
  Friend WithEvents JDockPanelHeader1 As DockHeaderPanel
  Friend WithEvents AncestorDetails As ListView
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
    Friend WithEvents SplitLeft As SplitContainer
    Friend WithEvents AncestorsList As ListView
  Friend WithEvents JDockPanelHeader2 As DockHeaderPanel
  Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents SplitLeftMiddle_Right As SplitContainer
    Friend WithEvents SplitMiddle As SplitContainer
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents SplitRight As SplitContainer
  Friend WithEvents JDockPanelHeader3 As DockHeaderPanel
  Friend WithEvents JDockPanelHeader4 As DockHeaderPanel
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
    Friend WithEvents AncestorAttributes As TreeView
    Friend WithEvents Panel1 As Panel
  Friend WithEvents JPanel2 As BordersPanel
  Friend WithEvents JPanel1 As BordersPanel
  Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tabCensus As TabPage
    Friend WithEvents tabNotebooks As TabPage
    Friend WithEvents tabGallery As TabPage
  Friend WithEvents AncestryToolbarToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents NotebookViewer1 As NotebookViewer
    Friend WithEvents imgGallery As ImageGallery
    Friend WithEvents imgViewer As ImageViewer
    Friend WithEvents CensusViewer1 As CensusViewer
    Friend WithEvents Ancestry As AncestryWebViewer
End Class
