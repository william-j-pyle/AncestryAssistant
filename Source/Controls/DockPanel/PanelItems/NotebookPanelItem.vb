Imports System.ComponentModel

Public Class NotebookPanelItem
  Inherits DockPanelItem

#Region "Fields"

  Friend WithEvents BtnAddPage As ToolStripButton
  Friend WithEvents BtnAddSection As ToolStripButton
  Friend WithEvents BtnH1 As ToolStripMenuItem
  Friend WithEvents BtnH2 As ToolStripMenuItem
  Friend WithEvents BtnH3 As ToolStripMenuItem
  Friend WithEvents BtnH4 As ToolStripMenuItem
  Friend WithEvents imgSection As ImageList
  Friend WithEvents LblStretch As Label
  Friend WithEvents PnlBody As Panel
  Friend WithEvents PnlHeader As Panel
  Friend WithEvents PnlHeaderStretch As FlatPanel
  Friend WithEvents SplitSectionsPage As SplitContainer
  Friend WithEvents ToolStripButton1 As ToolStripButton
  Friend WithEvents ToolStripButton10 As ToolStripButton
  Friend WithEvents ToolStripButton2 As ToolStripButton
  Friend WithEvents ToolStripButton3 As ToolStripButton
  Friend WithEvents ToolStripButton4 As ToolStripButton
  Friend WithEvents ToolStripButton5 As ToolStripButton
  Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
  Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
  Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
  Friend WithEvents TreeSectionPages As TreeView
  Friend WithEvents tsPage As ToolStrip
  Friend WithEvents tsSections As ToolStrip
  Friend WithEvents TxtBody As RichTextBox
  Friend WithEvents TxtHeader As TextBox
  Private Const Default_ItemCaption As String = "Notebook"
  Private Const Default_ItemHasRibbonBar As Boolean = True
  Private Const Default_ItemHasToolBar As Boolean = False
  Private Const Default_ItemSupportsClose As Boolean = True
  Private Const Default_ItemSupportsMove As Boolean = True
  Private Const Default_ItemSupportsSearch As Boolean = False
  Private Const Default_Key As String = "DOCK_NOTEBOOK"
  Private Const Default_LocationCurrent As DockPanelLocation = DockPanelLocation.None
  Private Const Default_LocationPrefered As DockPanelLocation = DockPanelLocation.MiddleTopRight
  Private Const Default_LocationPrevious As DockPanelLocation = DockPanelLocation.MiddleTopRight
  Private Const Default_RibbonBarKey As String = "B300"
  Private Const Default_RibbonHideOnItemClose As Boolean = True
  Private Const Default_RibbonSelectOnItemFocus As Boolean = True
  Private Const Default_RibbonShowOnItemOpen As Boolean = True

  Private components As System.ComponentModel.IContainer

#End Region

#Region "Public Constructors"

  Public Sub New(Optional itemKey As String = "")
    'Apply Item Defaults for this Type
    ItemCaption = Default_ItemCaption
    ItemHasRibbonBar = Default_ItemHasRibbonBar
    ItemHasToolBar = Default_ItemHasToolBar
    ItemSupportsClose = Default_ItemSupportsClose
    ItemSupportsMove = Default_ItemSupportsMove
    ItemSupportsSearch = Default_ItemSupportsSearch
    Key = Default_Key
    LocationCurrent = Default_LocationCurrent
    LocationPrefered = Default_LocationPrefered
    LocationPrevious = Default_LocationPrevious
    RibbonBarKey = Default_RibbonBarKey
    RibbonHideOnItemClose = Default_RibbonHideOnItemClose
    RibbonSelectOnItemFocus = Default_RibbonSelectOnItemFocus
    RibbonShowOnItemOpen = Default_RibbonShowOnItemOpen
    'Key can be overriden during creation, apply if set
    If Len(itemKey) > 0 Then Key = itemKey
    'Continue with creation
    components = New Container()
    Dim TreeNode1 As New TreeNode("My First Page")
    Dim TreeNode2 As New TreeNode("Welcome Section", New TreeNode() {TreeNode1})
    Dim TreeNode3 As New TreeNode("Last, First - YYYY", New TreeNode() {TreeNode2})
    SplitSectionsPage = New SplitContainer()
    TreeSectionPages = New TreeView()
    imgSection = New ImageList(components)
    tsSections = New ToolStrip()
    BtnAddSection = New ToolStripButton()
    BtnAddPage = New ToolStripButton()
    PnlBody = New Panel()
    TxtBody = New RichTextBox()
    PnlHeader = New Panel()
    PnlHeaderStretch = New AncestryAssistant.FlatPanel()
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
    tsSections.GripStyle = ToolStripGripStyle.Hidden
    tsSections.Items.AddRange(New ToolStripItem() {BtnAddSection, BtnAddPage})
    tsSections.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow
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
    BtnAddSection.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    BtnAddSection.Name = "BtnAddSection"
    BtnAddSection.Size = New Size(23, 22)
    BtnAddSection.ToolTipText = "Add New Section to Notebook"
    '
    'BtnAddPage
    '
    BtnAddPage.AutoToolTip = False
    BtnAddPage.DisplayStyle = ToolStripItemDisplayStyle.Image
    BtnAddPage.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
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
    tsPage.GripStyle = ToolStripGripStyle.Hidden
    tsPage.Items.AddRange(New ToolStripItem() {ToolStripButton10, ToolStripButton1, ToolStripButton2, ToolStripSeparator1, ToolStripButton3, ToolStripButton4, ToolStripButton5, ToolStripSeparator2, ToolStripSplitButton1})
    tsPage.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow
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
    ToolStripButton10.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    ToolStripButton10.ImageTransparentColor = Color.Magenta
    ToolStripButton10.Name = "ToolStripButton10"
    ToolStripButton10.Size = New Size(23, 22)
    ToolStripButton10.Text = "ToolStripButton1"
    ToolStripButton10.ToolTipText = "Refresh"
    '
    'ToolStripButton1
    '
    ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
    ToolStripButton1.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    ToolStripButton1.ImageTransparentColor = Color.Magenta
    ToolStripButton1.Name = "ToolStripButton1"
    ToolStripButton1.Size = New Size(23, 22)
    ToolStripButton1.Text = "ToolStripButton1"
    '
    'ToolStripButton2
    '
    ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
    ToolStripButton2.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
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
    ToolStripButton3.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    ToolStripButton3.ImageTransparentColor = Color.Magenta
    ToolStripButton3.Name = "ToolStripButton3"
    ToolStripButton3.Size = New Size(23, 22)
    ToolStripButton3.Text = "ToolStripButton3"
    '
    'ToolStripButton4
    '
    ToolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image
    ToolStripButton4.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    ToolStripButton4.ImageTransparentColor = Color.Magenta
    ToolStripButton4.Name = "ToolStripButton4"
    ToolStripButton4.Size = New Size(23, 22)
    ToolStripButton4.Text = "ToolStripButton4"
    '
    'ToolStripButton5
    '
    ToolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image
    ToolStripButton5.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
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
    ToolStripSplitButton1.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    ToolStripSplitButton1.ImageTransparentColor = Color.Magenta
    ToolStripSplitButton1.Name = "ToolStripSplitButton1"
    ToolStripSplitButton1.Size = New Size(32, 22)
    ToolStripSplitButton1.Text = "ToolStripSplitButton1"
    '
    'BtnH1
    '
    BtnH1.Font = New Font("Segoe UI", 18.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
    BtnH1.ForeColor = Color.SeaGreen
    BtnH1.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    BtnH1.Name = "BtnH1"
    BtnH1.Size = New Size(259, 36)
    BtnH1.Text = "Heading Style 1"
    '
    'BtnH2
    '
    BtnH2.Font = New Font("Segoe UI", 15.75!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
    BtnH2.ForeColor = Color.LimeGreen
    BtnH2.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    BtnH2.Name = "BtnH2"
    BtnH2.Size = New Size(259, 36)
    BtnH2.Text = "Heading Style 2"
    '
    'BtnH3
    '
    BtnH3.Font = New Font("Segoe UI Semibold", 12.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
    BtnH3.ForeColor = Color.OliveDrab
    BtnH3.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    BtnH3.Name = "BtnH3"
    BtnH3.Size = New Size(259, 36)
    BtnH3.Text = "Heading Style 3"
    '
    'BtnH4
    '
    BtnH4.Font = New Font("Segoe UI Semibold", 12.0!, CType(FontStyle.Bold Or FontStyle.Italic, FontStyle), GraphicsUnit.Point, CType(0, Byte))
    BtnH4.ForeColor = Color.Black
    BtnH4.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
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

    CaptureFocus(Me)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub txtNotebookPageTitle_TextChanged(sender As Object, e As EventArgs) Handles TxtHeader.TextChanged
    LblStretch.Text = TxtHeader.Text
  End Sub

#End Region

#Region "Protected Methods"

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

  Protected Overrides Sub UpdateUI(Optional reload As Boolean = True)
    'Throw New NotImplementedException()
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub ApplySearch(criteria As String)
    Throw New NotImplementedException()
  End Sub

  Public Overrides Sub ClearSearch()
    Throw New NotImplementedException()
  End Sub

#End Region

End Class