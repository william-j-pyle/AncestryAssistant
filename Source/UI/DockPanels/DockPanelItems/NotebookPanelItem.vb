Imports System.ComponentModel

Public Class NotebookViewer
  Inherits UserControl
  Implements IDockPanelItem

  Private Const EN_ITEMCAPTION As String = "Notebook"


  Friend WithEvents TxtBody As RichTextBox
  Friend WithEvents tsSections As ToolStrip
  Friend WithEvents BtnAddSection As ToolStripButton
  Friend WithEvents PnlHeader As Panel
  Friend WithEvents PnlHeaderStretch As BordersPanel
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

  Public Event PanelItemGotFocus(sender As Object, e As EventArgs) Implements IDockPanelItem.PanelItemGotFocus
  Public Event AncestorAssigned() Implements IDockPanelItem.AncestorAssigned
  Public Event AncestorUpdated() Implements IDockPanelItem.AncestorUpdated

  Public ReadOnly Property ItemCaption As String = EN_ITEMCAPTION Implements IDockPanelItem.ItemCaption
  Public ReadOnly Property ItemSupportsSearch As Boolean = True Implements IDockPanelItem.ItemSupportsSearch
  Public ReadOnly Property ItemSupportsClose As Boolean = True Implements IDockPanelItem.ItemSupportsClose
  Public ReadOnly Property ItemSupportsMove As Boolean = True Implements IDockPanelItem.ItemSupportsMove
  Public ReadOnly Property ItemHasRibbonBar As Boolean = True Implements IDockPanelItem.ItemHasRibbonBar
  Public ReadOnly Property ShowRibbonOnFocus As String = EN_ITEMCAPTION Implements IDockPanelItem.ShowRibbonOnFocus
  Public ReadOnly Property ItemHasToolBar As Boolean = False Implements IDockPanelItem.ItemHasToolBar
  Public Property ItemDockPanelLocation As DockPanelLocation Implements IDockPanelItem.ItemDockPanelLocation
  Public Property ItemHasFocus As Boolean = False Implements IDockPanelItem.ItemHasFocus

  Private Sub NotebookViewer_AncestorAssigned() Handles Me.AncestorAssigned

  End Sub

  Private Sub NotebookViewer_AncestorUpdated() Handles Me.AncestorUpdated

  End Sub


  Public Sub New()
    components = New Container()
    Dim TreeNode1 As TreeNode = New TreeNode("My First Page")
    Dim TreeNode2 As TreeNode = New TreeNode("Welcome Section", New TreeNode() {TreeNode1})
    Dim TreeNode3 As TreeNode = New TreeNode("Last, First - YYYY", New TreeNode() {TreeNode2})
    SplitSectionsPage = New SplitContainer()
    TreeSectionPages = New TreeView()
    imgSection = New ImageList(components)
    tsSections = New ToolStrip()
    BtnAddSection = New ToolStripButton()
    BtnAddPage = New ToolStripButton()
    PnlBody = New Panel()
    TxtBody = New RichTextBox()
    PnlHeader = New Panel()
    PnlHeaderStretch = New AncestryAssistant.BordersPanel()
    TxtHeader = New TextBox()
    LblStretch = New Label()
    tsPage = New ToolStrip()
    ToolStripButton10 = New ToolStripButton()
    ToolStripButton1 = New ToolStripButton()
    ToolStripButton2 = New ToolStripButton()
    ToolStripSeparator1 = New ToolStripSeparator()
    ToolStripButton3 = New ToolStripButton()
    ToolStripButton4 = New ToolStripButton()
    ToolStripButton5 = New ToolStripButton()
    ToolStripSeparator2 = New ToolStripSeparator()
    ToolStripSplitButton1 = New ToolStripSplitButton()
    BtnH1 = New ToolStripMenuItem()
    BtnH2 = New ToolStripMenuItem()
    BtnH3 = New ToolStripMenuItem()
    BtnH4 = New ToolStripMenuItem()
    CType(SplitSectionsPage, ISupportInitialize).BeginInit()
    SplitSectionsPage.Panel1.SuspendLayout()
    SplitSectionsPage.Panel2.SuspendLayout()
    SplitSectionsPage.SuspendLayout()
    tsSections.SuspendLayout()
    PnlBody.SuspendLayout()
    PnlHeader.SuspendLayout()
    PnlHeaderStretch.SuspendLayout()
    tsPage.SuspendLayout()
    SuspendLayout()
    '
    'SplitSectionsPage
    '
    SplitSectionsPage.Dock = DockStyle.Fill
    SplitSectionsPage.FixedPanel = FixedPanel.Panel1
    SplitSectionsPage.Location = New Point(0, 0)
    SplitSectionsPage.Name = "SplitSectionsPage"
    '
    'SplitSectionsPage.Panel1
    '
    SplitSectionsPage.Panel1.Controls.Add(TreeSectionPages)
    SplitSectionsPage.Panel1.Controls.Add(tsSections)
    '
    'SplitSectionsPage.Panel2
    '
    SplitSectionsPage.Panel2.BackColor = Color.White
    SplitSectionsPage.Panel2.Controls.Add(PnlBody)
    SplitSectionsPage.Panel2.Controls.Add(PnlHeader)
    SplitSectionsPage.Panel2.Controls.Add(tsPage)
    SplitSectionsPage.Size = New Size(654, 435)
    SplitSectionsPage.SplitterDistance = 102
    SplitSectionsPage.TabIndex = 4
    '
    'TreeSectionPages
    '
    TreeSectionPages.BackColor = SystemColors.Control
    TreeSectionPages.BorderStyle = BorderStyle.None
    TreeSectionPages.Dock = DockStyle.Fill
    TreeSectionPages.ImageIndex = 2
    TreeSectionPages.ImageList = imgSection
    TreeSectionPages.Location = New Point(0, 25)
    TreeSectionPages.Name = "TreeSectionPages"
    TreeNode1.ImageKey = "PAGE"
    TreeNode1.Name = "Node2"
    TreeNode1.SelectedImageKey = "PAGE"
    TreeNode1.StateImageKey = "(none)"
    TreeNode1.Text = "My First Page"
    TreeNode2.ImageKey = "SECTION"
    TreeNode2.Name = "Node1"
    TreeNode2.SelectedImageKey = "SECTION"
    TreeNode2.StateImageKey = "(none)"
    TreeNode2.Text = "Welcome Section"
    TreeNode3.ImageKey = "SECTIONS"
    TreeNode3.Name = "Node0"
    TreeNode3.SelectedImageKey = "SECTIONS"
    TreeNode3.Text = "Last, First - YYYY"
    TreeSectionPages.Nodes.AddRange(New TreeNode() {TreeNode3})
    TreeSectionPages.SelectedImageIndex = 0
    TreeSectionPages.ShowLines = False
    TreeSectionPages.ShowNodeToolTips = True
    TreeSectionPages.ShowRootLines = False
    TreeSectionPages.Size = New Size(102, 410)
    TreeSectionPages.StateImageList = imgSection
    TreeSectionPages.TabIndex = 0
    '
    'imgSection
    '
    '  imgSection.ImageStream = CType(resources.GetObject("imgSection.ImageStream"), ImageListStreamer)
    'imgSection.TransparentColor = Color.Transparent
    'imgSection.Images.SetKeyName(0, "SECTIONS")
    'imgSection.Images.SetKeyName(1, "SECTION")
    'imgSection.Images.SetKeyName(2, "PAGE")
    '
    'tsSections
    '
    tsSections.CanOverflow = False
    tsSections.DataBindings.Add(New Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, DataSourceUpdateMode.OnPropertyChanged))
    tsSections.GripStyle = ToolStripGripStyle.Hidden
    tsSections.Items.AddRange(New ToolStripItem() {BtnAddSection, BtnAddPage})
    tsSections.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow
    tsSections.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
    tsSections.Name = "tsSections"
    tsSections.Padding = New Padding(4, 0, 16, 0)
    tsSections.RenderMode = ToolStripRenderMode.System
    tsSections.Size = New Size(102, 25)
    tsSections.Stretch = True
    tsSections.TabIndex = 5
    '
    'BtnAddSection
    '
    BtnAddSection.AutoToolTip = False
    BtnAddSection.DisplayStyle = ToolStripItemDisplayStyle.Image
    BtnAddSection.Image = Global.AncestryAssistant.My.Resources.Resources.FOLDER_PLUS_ICO20
    BtnAddSection.Name = "BtnAddSection"
    BtnAddSection.Size = New Size(23, 22)
    BtnAddSection.ToolTipText = "Add New Section to Notebook"
    '
    'BtnAddPage
    '
    BtnAddPage.AutoToolTip = False
    BtnAddPage.DisplayStyle = ToolStripItemDisplayStyle.Image
    BtnAddPage.Image = Global.AncestryAssistant.My.Resources.Resources.PAGE_DOWNLOAD_ICO20
    BtnAddPage.ImageTransparentColor = Color.Magenta
    BtnAddPage.Name = "BtnAddPage"
    BtnAddPage.Size = New Size(23, 22)
    BtnAddPage.ToolTipText = "Add New Page to Section"
    '
    'PnlBody
    '
    PnlBody.Controls.Add(TxtBody)
    PnlBody.Dock = DockStyle.Fill
    PnlBody.Location = New Point(0, 75)
    PnlBody.Name = "PnlBody"
    PnlBody.Padding = New Padding(20, 20, 20, 0)
    PnlBody.Size = New Size(548, 360)
    PnlBody.TabIndex = 7
    '
    'TxtBody
    '
    TxtBody.BorderStyle = BorderStyle.None
    TxtBody.Dock = DockStyle.Fill
    TxtBody.Location = New Point(20, 20)
    TxtBody.Name = "TxtBody"
    TxtBody.Size = New Size(508, 340)
    TxtBody.TabIndex = 5
    TxtBody.Text = ""
    '
    'PnlHeader
    '
    PnlHeader.Controls.Add(PnlHeaderStretch)
    PnlHeader.Dock = DockStyle.Top
    PnlHeader.Location = New Point(0, 25)
    PnlHeader.MaximumSize = New Size(0, 50)
    PnlHeader.MinimumSize = New Size(0, 50)
    PnlHeader.Name = "PnlHeader"
    PnlHeader.Padding = New Padding(25, 0, 0, 0)
    PnlHeader.Size = New Size(548, 50)
    PnlHeader.TabIndex = 6
    '
    'PnlHeaderStretch
    '
    PnlHeaderStretch.AutoSize = True
    PnlHeaderStretch.AutoSizeMode = AutoSizeMode.GrowAndShrink
    PnlHeaderStretch.BorderColor = Color.Transparent
    PnlHeaderStretch.BorderColorBottom = Color.Black
    PnlHeaderStretch.BorderColorLeft = Color.Black
    PnlHeaderStretch.BorderColorRight = Color.Black
    PnlHeaderStretch.BorderColorTop = Color.Black
    PnlHeaderStretch.BorderWidth = New Padding(0, 0, 0, 2)
    PnlHeaderStretch.Controls.Add(TxtHeader)
    PnlHeaderStretch.Controls.Add(LblStretch)
    PnlHeaderStretch.CornerRadius = New Padding(0)
    PnlHeaderStretch.Dock = DockStyle.Left
    PnlHeaderStretch.Location = New Point(25, 0)
    PnlHeaderStretch.MinimumSize = New Size(200, 0)
    PnlHeaderStretch.Name = "PnlHeaderStretch"
    PnlHeaderStretch.Padding = New Padding(10, 15, 0, 3)
    PnlHeaderStretch.Size = New Size(210, 50)
    PnlHeaderStretch.TabIndex = 0
    '
    'TxtHeader
    '
    TxtHeader.BorderStyle = BorderStyle.None
    TxtHeader.Dock = DockStyle.Fill
    TxtHeader.Font = New Font("Segoe UI Semibold", 14.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
    TxtHeader.Location = New Point(10, 15)
    TxtHeader.MaxLength = 90
    TxtHeader.MinimumSize = New Size(200, 0)
    TxtHeader.Name = "TxtHeader"
    TxtHeader.Size = New Size(200, 25)
    TxtHeader.TabIndex = 0
    TxtHeader.Text = "New Page"
    '
    'LblStretch
    '
    LblStretch.AutoSize = True
    LblStretch.Dock = DockStyle.Fill
    LblStretch.Font = New Font("Segoe UI Semibold", 14.0!, FontStyle.Bold)
    LblStretch.ForeColor = Color.White
    LblStretch.Location = New Point(10, 15)
    LblStretch.MinimumSize = New Size(200, 0)
    LblStretch.Name = "LblStretch"
    LblStretch.Size = New Size(200, 25)
    LblStretch.TabIndex = 1
    LblStretch.Text = "New Page"
    '
    'tsPage
    '
    tsPage.CanOverflow = False
    tsPage.DataBindings.Add(New Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, DataSourceUpdateMode.OnPropertyChanged))
    tsPage.GripStyle = ToolStripGripStyle.Hidden
    tsPage.Items.AddRange(New ToolStripItem() {ToolStripButton10, ToolStripButton1, ToolStripButton2, ToolStripSeparator1, ToolStripButton3, ToolStripButton4, ToolStripButton5, ToolStripSeparator2, ToolStripSplitButton1})
    tsPage.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow
    tsPage.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
    tsPage.Name = "tsPage"
    tsPage.Padding = New Padding(4, 0, 16, 0)
    tsPage.RenderMode = ToolStripRenderMode.System
    tsPage.Size = New Size(548, 25)
    tsPage.Stretch = True
    tsPage.TabIndex = 4
    '
    'ToolStripButton10
    '
    ToolStripButton10.DisplayStyle = ToolStripItemDisplayStyle.Image
    ToolStripButton10.Image = Global.AncestryAssistant.My.Resources.Resources.CUT_ICO20
    ToolStripButton10.ImageTransparentColor = Color.Magenta
    ToolStripButton10.Name = "ToolStripButton10"
    ToolStripButton10.Size = New Size(23, 22)
    ToolStripButton10.Text = "ToolStripButton1"
    ToolStripButton10.ToolTipText = "Refresh"
    '
    'ToolStripButton1
    '
    ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
    ToolStripButton1.Image = Global.AncestryAssistant.My.Resources.Resources.COPY_ICO20
    ToolStripButton1.ImageTransparentColor = Color.Magenta
    ToolStripButton1.Name = "ToolStripButton1"
    ToolStripButton1.Size = New Size(23, 22)
    ToolStripButton1.Text = "ToolStripButton1"
    '
    'ToolStripButton2
    '
    ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
    ToolStripButton2.Image = Global.AncestryAssistant.My.Resources.Resources.CLIPBOARD_CHECK_ICO20
    ToolStripButton2.ImageTransparentColor = Color.Magenta
    ToolStripButton2.Name = "ToolStripButton2"
    ToolStripButton2.Size = New Size(23, 22)
    ToolStripButton2.Text = "ToolStripButton2"
    '
    'ToolStripSeparator1
    '
    ToolStripSeparator1.Name = "ToolStripSeparator1"
    ToolStripSeparator1.Size = New Size(6, 25)
    '
    'ToolStripButton3
    '
    ToolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image
    ToolStripButton3.Image = Global.AncestryAssistant.My.Resources.Resources.tastatur_bold
    ToolStripButton3.ImageTransparentColor = Color.Magenta
    ToolStripButton3.Name = "ToolStripButton3"
    ToolStripButton3.Size = New Size(23, 22)
    ToolStripButton3.Text = "ToolStripButton3"
    '
    'ToolStripButton4
    '
    ToolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image
    ToolStripButton4.Image = Global.AncestryAssistant.My.Resources.Resources.ITALIC_ICO20
    ToolStripButton4.ImageTransparentColor = Color.Magenta
    ToolStripButton4.Name = "ToolStripButton4"
    ToolStripButton4.Size = New Size(23, 22)
    ToolStripButton4.Text = "ToolStripButton4"
    '
    'ToolStripButton5
    '
    ToolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image
    ToolStripButton5.Image = Global.AncestryAssistant.My.Resources.Resources.UNDERLINE_ICO20
    ToolStripButton5.ImageTransparentColor = Color.Magenta
    ToolStripButton5.Name = "ToolStripButton5"
    ToolStripButton5.Size = New Size(23, 22)
    ToolStripButton5.Text = "ToolStripButton5"
    '
    'ToolStripSeparator2
    '
    ToolStripSeparator2.Name = "ToolStripSeparator2"
    ToolStripSeparator2.Size = New Size(6, 25)
    '
    'ToolStripSplitButton1
    '
    ToolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
    ToolStripSplitButton1.DropDownItems.AddRange(New ToolStripItem() {BtnH1, BtnH2, BtnH3, BtnH4})
    ToolStripSplitButton1.Image = Global.AncestryAssistant.My.Resources.Resources.H_1_ICO20
    ToolStripSplitButton1.ImageTransparentColor = Color.Magenta
    ToolStripSplitButton1.Name = "ToolStripSplitButton1"
    ToolStripSplitButton1.Size = New Size(32, 22)
    ToolStripSplitButton1.Text = "ToolStripSplitButton1"
    '
    'BtnH1
    '
    BtnH1.Font = New Font("Segoe UI", 18.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
    BtnH1.ForeColor = Color.SeaGreen
    BtnH1.Image = Global.AncestryAssistant.My.Resources.Resources.H_1_ICO20
    BtnH1.Name = "BtnH1"
    BtnH1.Size = New Size(259, 36)
    BtnH1.Text = "Heading Style 1"
    '
    'BtnH2
    '
    BtnH2.Font = New Font("Segoe UI", 15.75!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
    BtnH2.ForeColor = Color.LimeGreen
    BtnH2.Image = Global.AncestryAssistant.My.Resources.Resources.H_2_ICO20
    BtnH2.Name = "BtnH2"
    BtnH2.Size = New Size(259, 36)
    BtnH2.Text = "Heading Style 2"
    '
    'BtnH3
    '
    BtnH3.Font = New Font("Segoe UI Semibold", 12.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
    BtnH3.ForeColor = Color.OliveDrab
    BtnH3.Image = Global.AncestryAssistant.My.Resources.Resources.H_3_ICO20
    BtnH3.Name = "BtnH3"
    BtnH3.Size = New Size(259, 36)
    BtnH3.Text = "Heading Style 3"
    '
    'BtnH4
    '
    BtnH4.Font = New Font("Segoe UI Semibold", 12.0!, CType(FontStyle.Bold Or FontStyle.Italic, FontStyle), GraphicsUnit.Point, CType(0, Byte))
    BtnH4.ForeColor = Color.Black
    BtnH4.Image = Global.AncestryAssistant.My.Resources.Resources.H_4_ICO20
    BtnH4.Name = "BtnH4"
    BtnH4.Size = New Size(259, 36)
    BtnH4.Text = "Heading Style 4"
    '
    'NotebookViewer
    '
    AllowDrop = True
    AutoScaleDimensions = New SizeF(6.0!, 13.0!)
    AutoScaleMode = AutoScaleMode.None
    Controls.Add(SplitSectionsPage)
    DoubleBuffered = True
    Dock = DockStyle.Fill
    Font = New Font("Segoe UI", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    Name = "NotebookViewer"
    Size = New Size(654, 435)
    SplitSectionsPage.Panel1.ResumeLayout(False)
    SplitSectionsPage.Panel1.PerformLayout()
    SplitSectionsPage.Panel2.ResumeLayout(False)
    SplitSectionsPage.Panel2.PerformLayout()
    CType(SplitSectionsPage, ISupportInitialize).EndInit()
    SplitSectionsPage.ResumeLayout(False)
    tsSections.ResumeLayout(False)
    tsSections.PerformLayout()
    PnlBody.ResumeLayout(False)
    PnlHeader.ResumeLayout(False)
    PnlHeader.PerformLayout()
    PnlHeaderStretch.ResumeLayout(False)
    PnlHeaderStretch.PerformLayout()
    tsPage.ResumeLayout(False)
    tsPage.PerformLayout()
    ResumeLayout(False)

  End Sub


  Private Sub txtNotebookPageTitle_TextChanged(sender As Object, e As EventArgs) Handles TxtHeader.TextChanged
    LblStretch.Text = TxtHeader.Text
  End Sub

  Public Function GetRibbonBarConfig() As RibbonBarTabConfig Implements IDockPanelItem.GetRibbonBarConfig
    Throw New NotImplementedException()
  End Function

  Public Function GetDockToolBarConfig() As DockToolBarConfig Implements IDockPanelItem.GetDockToolBarConfig
    Throw New NotImplementedException()
  End Function

  Public Sub SetAncestor(activeAncestor As AncestorCollection.Ancestor) Implements IDockPanelItem.SetAncestor
    Throw New NotImplementedException()
  End Sub

  Public Sub RefreshAncestor() Implements IDockPanelItem.RefreshAncestor
    Throw New NotImplementedException()
  End Sub

  Public Sub ApplySearch(criteria As String) Implements IDockPanelItem.ApplySearch
    Throw New NotImplementedException()
  End Sub

  Public Sub ClearSearch() Implements IDockPanelItem.ClearSearch
    Throw New NotImplementedException()
  End Sub


#Region "Component Helper"
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
  Private components As System.ComponentModel.IContainer
#End Region

End Class