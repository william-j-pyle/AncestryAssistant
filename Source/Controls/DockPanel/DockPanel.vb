Public Class DockPanel
  Inherits System.Windows.Forms.UserControl

#Region "Fields"

  Private WithEvents BtnClose As FlatIconButton
  Private WithEvents BtnContextMenu As FlatIconButton
  Private WithEvents BtnPinned As FlatIconButton
  Private WithEvents BtnSearch As FlatIconButton
  Private WithEvents CtxMenu As ContextMenuStrip
  Private WithEvents LblCaption As Label
  Private WithEvents PnlButtonContainerHeader As TableLayoutPanel
  Private WithEvents PnlButtonContainerSearch As TableLayoutPanel
  Private WithEvents PnlClient As FlatTabControl
  Private WithEvents PnlContextMenu As FlatContextMenu
  Private WithEvents PnlHeader As FlatPanel

  Private WithEvents PnlMain As FlatPanel

  Private WithEvents PnlSearch As FlatPanel

  Private WithEvents TabPage1 As TabPage

  Private WithEvents TxtSearch As TextBox

  Private _PanelHasFocus As Boolean = True

  Private _PanelIsPinned As Boolean = True

  Private _PanelLocation As DockPanelLocation = DockPanelLocation.Floating

  Private _PanelShowClose As Boolean = True

  Private _PanelShowContextMenu As Boolean = True

  Private _PanelShowPinned As Boolean = True

  Private _PanelShowSearch As Boolean = True

  Private _PanelType As DockPanelType = DockPanelType.Panel

  Private components As System.ComponentModel.IContainer

#End Region

#Region "Events"

  Public Event PanelClose(dockPanelObj As DockPanel)

  Public Event PanelFocusChanged(dockPanelObj As DockPanel, HasFocus As Boolean)

  Public Event PanelItemClose(panelItemObj As DockPanelItem)

  Public Event PanelItemLocationChange(panelItemObj As DockPanelItem, toPanelLocation As DockPanelLocation)

  Public Event PanelItemSelected(panelItemObj As DockPanelItem)

#End Region

#Region "Properties"

  Public ReadOnly Property PanelCaption As String
    Get
      Return LblCaption.Text
    End Get
  End Property

  Public Property PanelHasFocus As Boolean
    Get
      Return _PanelHasFocus
    End Get
    Set(value As Boolean)
      If value <> _PanelHasFocus Then
        _PanelHasFocus = value
        LayoutPanel()
        RaiseEvent PanelFocusChanged(Me, value)
        If value Then
          RaiseEvent PanelItemSelected(PanelSelectedItem)
        End If
      End If
    End Set
  End Property

  Public Property PanelIsPinned As Boolean
    Get
      Return _PanelIsPinned
    End Get
    Set(value As Boolean)
      _PanelIsPinned = value
      Invalidate(True)
    End Set
  End Property

  Public ReadOnly Property PanelItemCount As Integer
    Get
      Return TabPages.Count
    End Get
  End Property

  Public Property PanelLocation As DockPanelLocation
    Get
      Return _PanelLocation
    End Get
    Set(value As DockPanelLocation)
      If _PanelLocation <> value Then
        _PanelLocation = value
      End If
    End Set
  End Property

  Public ReadOnly Property PanelSelectedIndex As Integer
    Get
      Return PnlClient.SelectedIndex
    End Get
  End Property

  Public ReadOnly Property PanelSelectedItem As DockPanelItem
    Get
      If PnlClient.TabCount > 0 Then
        If PnlClient.SelectedTab IsNot Nothing Then
          If PnlClient.SelectedTab.Controls.Count > 0 Then
            Return CType(PnlClient.SelectedTab.Controls(0), DockPanelItem)
          End If
        End If
      End If
      Return Nothing
    End Get
  End Property

  Public Property PanelShowClose As Boolean
    Get
      Return _PanelShowClose
    End Get
    Set(value As Boolean)
      _PanelShowClose = value
      LayoutPanel()
    End Set
  End Property

  Public Property PanelShowContextMenu As Boolean
    Get
      Return _PanelShowContextMenu
    End Get
    Set(value As Boolean)
      _PanelShowContextMenu = value
      LayoutPanel()
    End Set
  End Property

  Public Property PanelShowPinned As Boolean
    Get
      Return _PanelShowPinned
    End Get
    Set(value As Boolean)
      _PanelShowPinned = value
      LayoutPanel()
    End Set
  End Property

  Public Property PanelShowSearch As Boolean
    Get
      Return _PanelShowSearch
    End Get
    Set(value As Boolean)
      _PanelShowSearch = value
      LayoutPanel()
    End Set
  End Property

  Public Property PanelType As DockPanelType
    Get
      Return _PanelType
    End Get
    Set(value As DockPanelType)
      If _PanelType <> value Then
        _PanelType = value
        LayoutPanel()
      End If
    End Set
  End Property

  Public ReadOnly Property TabPages As TabControl.TabPageCollection
    Get
      Return PnlClient.TabPages
    End Get
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    PnlMain = New AncestryAssistant.FlatPanel()
    PnlSearch = New AncestryAssistant.FlatPanel()
    TxtSearch = New System.Windows.Forms.TextBox()
    PnlButtonContainerSearch = New System.Windows.Forms.TableLayoutPanel()
    BtnSearch = New AncestryAssistant.FlatIconButton()
    PnlHeader = New AncestryAssistant.FlatPanel()
    LblCaption = New System.Windows.Forms.Label()
    PnlButtonContainerHeader = New System.Windows.Forms.TableLayoutPanel()
    BtnClose = New AncestryAssistant.FlatIconButton()
    BtnPinned = New AncestryAssistant.FlatIconButton()
    BtnContextMenu = New AncestryAssistant.FlatIconButton()
    PnlClient = New AncestryAssistant.FlatTabControl()
    TabPage1 = New System.Windows.Forms.TabPage()
    PnlMain.SuspendLayout()
    PnlSearch.SuspendLayout()
    PnlButtonContainerSearch.SuspendLayout()
    PnlHeader.SuspendLayout()
    PnlButtonContainerHeader.SuspendLayout()
    PnlClient.SuspendLayout()
    SuspendLayout()
    '
    'pnlMain
    '
    PnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
    PnlMain.BorderColor = My.Theme.PanelBorderColor
    PnlMain.BorderColorBottom = My.Theme.PanelBorderColor
    PnlMain.BorderColorLeft = My.Theme.PanelBorderColor
    PnlMain.BorderColorRight = My.Theme.PanelBorderColor
    PnlMain.BorderColorTop = System.Drawing.Color.Lime
    PnlMain.BorderWidth = New System.Windows.Forms.Padding(1, 3, 1, 1)
    PnlMain.Controls.Add(PnlSearch)
    PnlMain.Controls.Add(PnlHeader)
    PnlMain.CornerRadius = New System.Windows.Forms.Padding(0)
    PnlMain.Dock = System.Windows.Forms.DockStyle.Top
    PnlMain.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    PnlMain.ForeColor = System.Drawing.Color.WhiteSmoke
    PnlMain.Location = New System.Drawing.Point(0, 0)
    PnlMain.Margin = New System.Windows.Forms.Padding(0)
    PnlMain.MaximumSize = New System.Drawing.Size(0, 42)
    PnlMain.MinimumSize = New System.Drawing.Size(170, 42)
    PnlMain.Name = "pnlMain"
    PnlMain.Padding = New System.Windows.Forms.Padding(1, 3, 1, 1)
    PnlMain.Size = New System.Drawing.Size(348, 42)
    PnlMain.TabIndex = 5
    '
    'pnlSearch
    '
    PnlSearch.BackColor = My.Theme.PanelBorderColor
    PnlSearch.BorderColor = System.Drawing.Color.Transparent
    PnlSearch.BorderColorBottom = System.Drawing.Color.Black
    PnlSearch.BorderColorLeft = System.Drawing.Color.Black
    PnlSearch.BorderColorRight = System.Drawing.Color.Black
    PnlSearch.BorderColorTop = System.Drawing.Color.Black
    PnlSearch.BorderWidth = New System.Windows.Forms.Padding(0)
    PnlSearch.Controls.Add(TxtSearch)
    PnlSearch.Controls.Add(PnlButtonContainerSearch)
    PnlSearch.CornerRadius = New System.Windows.Forms.Padding(0)
    PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
    PnlSearch.Location = New System.Drawing.Point(1, 23)
    PnlSearch.Margin = New System.Windows.Forms.Padding(0)
    PnlSearch.MaximumSize = New System.Drawing.Size(0, 20)
    PnlSearch.MinimumSize = New System.Drawing.Size(0, 20)
    PnlSearch.Name = "pnlSearch"
    PnlSearch.Padding = New System.Windows.Forms.Padding(4, 3, 1, 1)
    PnlSearch.Size = New System.Drawing.Size(346, 20)
    PnlSearch.TabIndex = 2
    '
    'txtSearch
    '
    TxtSearch.BackColor = My.Theme.PanelBorderColor
    TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
    TxtSearch.Dock = System.Windows.Forms.DockStyle.Fill
    TxtSearch.ForeColor = System.Drawing.Color.White
    TxtSearch.Location = New System.Drawing.Point(4, 3)
    TxtSearch.Margin = New System.Windows.Forms.Padding(0)
    TxtSearch.Name = "txtSearch"
    TxtSearch.Size = New System.Drawing.Size(321, 15)
    TxtSearch.TabIndex = 3
    TxtSearch.Text = "Search"
    '
    'pnlButtonContainerSearch
    '
    PnlButtonContainerSearch.ColumnCount = 1
    PnlButtonContainerSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    PnlButtonContainerSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    PnlButtonContainerSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    PnlButtonContainerSearch.Controls.Add(BtnSearch, 0, 0)
    PnlButtonContainerSearch.Dock = System.Windows.Forms.DockStyle.Right
    PnlButtonContainerSearch.Location = New System.Drawing.Point(325, 3)
    PnlButtonContainerSearch.Margin = New System.Windows.Forms.Padding(0)
    PnlButtonContainerSearch.Name = "pnlButtonContainerSearch"
    PnlButtonContainerSearch.RowCount = 1
    PnlButtonContainerSearch.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    PnlButtonContainerSearch.Size = New System.Drawing.Size(20, 16)
    PnlButtonContainerSearch.TabIndex = 2
    '
    'BtnSearch
    '
    BtnSearch.BackColor = My.Theme.PanelBackColor
    BtnSearch.Icon = My.Resources.panel_search
    BtnSearch.Location = New System.Drawing.Point(4, 0)
    BtnSearch.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
    BtnSearch.MaximumSize = New System.Drawing.Size(16, 16)
    BtnSearch.MinimumSize = New System.Drawing.Size(16, 16)
    BtnSearch.Name = "BtnSearch"
    BtnSearch.Size = New System.Drawing.Size(16, 16)
    BtnSearch.TabIndex = 0
    '
    'pnlHeader
    '
    PnlHeader.BackColor = My.Theme.PanelBackColor
    PnlHeader.BorderColorBottom = My.Theme.PanelBorderColor
    PnlHeader.BorderColorLeft = My.Theme.PanelBorderColor
    PnlHeader.BorderColorRight = My.Theme.PanelBorderColor
    PnlHeader.BorderColorTop = My.Theme.PanelHighlightColor
    PnlHeader.BorderWidth = New System.Windows.Forms.Padding(1, 0, 1, 1)
    PnlHeader.Controls.Add(LblCaption)
    PnlHeader.Controls.Add(PnlButtonContainerHeader)
    PnlHeader.CornerRadius = New System.Windows.Forms.Padding(0)
    PnlHeader.BackgroundImage = My.Resources.panel_header_bgpattern
    PnlHeader.BackgroundImageLayout = ImageLayout.None
    PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
    PnlHeader.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    PnlHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    PnlHeader.Location = New System.Drawing.Point(1, 3)
    PnlHeader.Margin = New System.Windows.Forms.Padding(0)
    PnlHeader.MaximumSize = New System.Drawing.Size(0, 20)
    PnlHeader.MinimumSize = New System.Drawing.Size(0, 20)
    PnlHeader.Name = "pnlHeader"
    PnlHeader.Padding = New System.Windows.Forms.Padding(1, 0, 1, 1)
    PnlHeader.Size = New System.Drawing.Size(346, 20)
    PnlHeader.TabIndex = 0
    '
    'LblCaption
    '
    LblCaption.Dock = System.Windows.Forms.DockStyle.Left
    LblCaption.AutoSize = True
    LblCaption.Location = New System.Drawing.Point(1, 0)
    LblCaption.Name = "LblCaption"
    LblCaption.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
    LblCaption.Size = New System.Drawing.Size(284, 19)
    LblCaption.TabIndex = 2
    LblCaption.Text = "DockPanelHeader"
    '
    'pnlButtonContainerHeader
    '
    PnlButtonContainerHeader.ColumnCount = 3
    PnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    PnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    PnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    PnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    PnlButtonContainerHeader.Controls.Add(BtnClose, 2, 0)
    PnlButtonContainerHeader.Controls.Add(BtnPinned, 1, 0)
    PnlButtonContainerHeader.Controls.Add(BtnContextMenu, 0, 0)
    PnlButtonContainerHeader.BackColor = PnlHeader.BackColor
    PnlButtonContainerHeader.Dock = System.Windows.Forms.DockStyle.Right
    PnlButtonContainerHeader.Location = New System.Drawing.Point(285, 0)
    PnlButtonContainerHeader.Margin = New System.Windows.Forms.Padding(0)
    PnlButtonContainerHeader.Name = "pnlButtonContainerHeader"
    PnlButtonContainerHeader.RowCount = 1
    PnlButtonContainerHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    PnlButtonContainerHeader.Size = New System.Drawing.Size(60, 19)
    PnlButtonContainerHeader.TabIndex = 1
    '
    'BtnClose
    '
    BtnClose.Icon = My.Resources.panel_header_close
    BtnClose.Location = New System.Drawing.Point(40, 1)
    BtnClose.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
    BtnClose.MaximumSize = New System.Drawing.Size(16, 16)
    BtnClose.MinimumSize = New System.Drawing.Size(16, 16)
    BtnClose.Name = "BtnClose"
    BtnClose.Size = New System.Drawing.Size(16, 16)
    '
    'BtnPinned
    '
    BtnPinned.Icon = My.Resources.panel_header_pin
    BtnPinned.Location = New System.Drawing.Point(20, 1)
    BtnPinned.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
    BtnPinned.MaximumSize = New System.Drawing.Size(16, 16)
    BtnPinned.MinimumSize = New System.Drawing.Size(16, 16)
    BtnPinned.Name = "BtnPinned"
    BtnPinned.Size = New System.Drawing.Size(16, 16)
    '
    'BtnContextMenu
    '
    BtnContextMenu.Icon = My.Resources.panel_header_menu
    BtnContextMenu.Location = New System.Drawing.Point(0, 1)
    BtnContextMenu.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
    BtnContextMenu.MaximumSize = New System.Drawing.Size(16, 16)
    BtnContextMenu.MinimumSize = New System.Drawing.Size(16, 16)
    BtnContextMenu.Name = "BtnContextMenu"
    BtnContextMenu.Size = New System.Drawing.Size(16, 16)
    '
    'pnlClient
    '
    PnlClient.Alignment = System.Windows.Forms.TabAlignment.Bottom
    PnlClient.Controls.Add(TabPage1)
    PnlClient.Dock = System.Windows.Forms.DockStyle.Fill
    PnlClient.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
    PnlClient.HotTrack = True
    PnlClient.Location = New System.Drawing.Point(0, 42)
    PnlClient.Margin = New System.Windows.Forms.Padding(0)
    PnlClient.Name = "pnlClient"
    PnlClient.SelectedIndex = 0
    PnlClient.ShowHasFocus = False
    PnlClient.ShowToolTips = True
    PnlClient.Size = New System.Drawing.Size(348, 310)
    PnlClient.TabIndex = 6
    PnlClient.TabShowClose = True
    PnlClient.TabType = AncestryAssistant.DockPanelType.Tab
    '
    'TabPage1
    '
    TabPage1.Location = New System.Drawing.Point(4, 4)
    TabPage1.Name = "TabPage1"
    TabPage1.Padding = New System.Windows.Forms.Padding(3)
    TabPage1.Size = New System.Drawing.Size(340, 281)
    TabPage1.TabIndex = 0
    TabPage1.UseVisualStyleBackColor = True
    '
    'DockPanel
    '
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    BackColor = System.Drawing.Color.Black
    Controls.Add(PnlClient)
    Controls.Add(PnlMain)
    Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    ForeColor = System.Drawing.Color.WhiteSmoke
    Margin = New System.Windows.Forms.Padding(0)
    Name = "DockPanel"
    Size = New System.Drawing.Size(348, 352)
    PnlMain.ResumeLayout(False)
    PnlSearch.ResumeLayout(False)
    PnlSearch.PerformLayout()
    PnlButtonContainerSearch.ResumeLayout(False)
    PnlHeader.ResumeLayout(False)
    PnlButtonContainerHeader.ResumeLayout(False)
    PnlClient.ResumeLayout(False)
    ResumeLayout(False)

    DoubleBuffered = True
    CtxMenu = New ContextMenuStrip With {
      .DropShadowEnabled = True
    }
    SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw, True)
    PnlSearch.BackColor = My.Theme.PanelBorderColor
    TxtSearch.BackColor = My.Theme.PanelBorderColor
    BtnSearch.BackColor = My.Theme.PanelBorderColor
    TxtSearch.ForeColor = My.Theme.PanelShadowColor
    BackColor = My.Theme.PanelBackColor
    ForeColor = My.Theme.PanelFontColor
    With PnlClient
      .HotTrack = True
      .Margin = New System.Windows.Forms.Padding(0)
      .ShowToolTips = True
      .TabPages(0).Text = ""
      .TabPages(0).BackColor = My.Theme.PanelBackColor
      .TabPages(0).ForeColor = My.Theme.PanelFontColor
    End With
    CreatePanelContextMenu()
    UpdateStyles()
    LblCaption.Text = ""
    CaptureFocus(Me)
    LayoutPanel()
  End Sub

#End Region

#Region "Private Methods"

  Private Sub AddPlaceholderTab()
    If PnlClient.TabCount = 1 Then
      If Not PnlClient.SelectedTab.Text.Equals("") Then
        PnlClient.TabPages.Add("BLANK", "")
      End If
    End If
  End Sub

  Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click, PnlClient.BtnClose_Click
    RemoveItem(PanelSelectedItem)
  End Sub

  Private Sub BtnContextMenu_MouseDown(sender As Object, e As MouseEventArgs) Handles BtnContextMenu.MouseDown
    PnlContextMenu.Show(BtnContextMenu, New Point(0, BtnContextMenu.Height))
  End Sub

  Private Sub BtnPinned_Click(sender As Object, e As EventArgs) Handles BtnPinned.Click
    PanelIsPinned = Not PanelIsPinned
  End Sub

  Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
    If TxtSearch.Text.Equals("Search") Then Exit Sub
    If BtnSearch.Icon.Equals(BtnClose.Icon) Then
      PanelSelectedItem.ClearSearch()
      BtnSearch.Icon = My.Resources.panel_search
      TxtSearch.Text = "Search"
      TxtSearch.ForeColor = My.Theme.PanelShadowColor
    Else
      PanelSelectedItem.ApplySearch(TxtSearch.Text)
      BtnSearch.Icon = BtnClose.Icon
    End If
  End Sub

  Private Sub CaptureFocus(ctl As Control)
    Try
      If Not ctl.Name.ToUpper.Contains("CLOSE") Then
        AddHandler ctl.GotFocus, AddressOf DockPanel_GotFocus
        AddHandler ctl.MouseDown, AddressOf DockPanel_GotFocus
      End If
    Catch ex As Exception
    End Try
    For Each childCtl As Control In ctl.Controls
      CaptureFocus(childCtl)
    Next
  End Sub

  Private Sub CreatePanelContextMenu()
    Dim item As System.Windows.Forms.ToolStripMenuItem

    PnlContextMenu = New AncestryAssistant.FlatContextMenu() With {
    .Name = "pnlContextMenu"
    }

    PnlContextMenu.AddMenuItem("MnuDockFloat", "Float", enabled:=False)

    item = PnlContextMenu.AddMenuItem("MnuDock", "Dock")
    PnlContextMenu.AddMenuItem(item, "MnuDockLeftTop", "Top Left")
    PnlContextMenu.AddMenuItem(item, "MnuDockLeftBottom", "Bottom Left")
    PnlContextMenu.AddMenuItem(item, "MnuDockRightTop", "Top Right")
    PnlContextMenu.AddMenuItem(item, "MnuDockRightBottom", "Bottom Right")
    PnlContextMenu.AddMenuItem(item, "MnuDockMiddleBottom", "Middle Bottom")
    PnlContextMenu.AddSeperator(item)
    PnlContextMenu.AddMenuItem(item, "MnuDockTabbed", "As Tabbed Document")

    PnlContextMenu.AddSeperator()

    PnlContextMenu.AddMenuItem("MnuDockClose", "Close")

  End Sub

  Private Sub DockPanel_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
    PanelHasFocus = True
  End Sub

  Private Function HasTabs() As Boolean
    If PnlClient.TabCount > 1 Then Return True
    If PnlClient.TabCount = 0 Then Return False
    If PnlClient.TabPages(0).Text.Equals("") Then Return False
    Return True
  End Function

  Private Sub LayoutPanel()
    'Prevent display of control when its empty
    If Not HasTabs() Then
      Visible = False
      Exit Sub
    End If
    'We have data so generate the interface
    Visible = True
    With CtxMenu
      .BackColor = My.Theme.PanelBorderColor
      .ForeColor = My.Theme.PanelFontColor
    End With
    With PnlClient
      .TabShowClose = PanelShowClose
      .TabType = PanelType
      .ShowHasFocus = PanelHasFocus
    End With
    Select Case PanelType
      Case DockPanelType.None
        Visible = False
      Case DockPanelType.Panel
        Visible = True
        'Adjust visibility of all controls within Main Panel
        BtnClose.Visible = PanelShowClose
        BtnContextMenu.Visible = PanelShowContextMenu
        BtnPinned.Visible = PanelShowPinned
        PnlSearch.Visible = PanelShowSearch
        'Apply Main Panel Formatting and refresh
        With PnlMain
          If PanelShowSearch Then
            .MinimumSize = New Size(0, 42)
            .MaximumSize = New Size(0, 42)
            .Height = 42
          Else
            .MinimumSize = New Size(0, 22)
            .MaximumSize = New Size(0, 22)
            .Height = 22
          End If
          .Visible = True
          If PanelHasFocus Then
            PnlHeader.BackgroundImageLayout = ImageLayout.Tile
            .BorderColorTop = My.Theme.PanelHighlightColor
            .BorderWidth = New Padding(1, 3, 1, 1)
          Else
            PnlHeader.BackgroundImageLayout = ImageLayout.None
            .BorderColorTop = My.Theme.PanelBorderColor
            .BorderWidth = New Padding(1, 1, 1, 1)
          End If
          .Invalidate(True)
        End With
        'Apply Client Panel layout and sizing
        With PnlClient
          .Alignment = System.Windows.Forms.TabAlignment.Bottom
          .Padding = New System.Drawing.Point(2, 2)
          If .TabPages.Count < 2 Then
            Dim h As Integer = Height - PnlMain.Height + .ItemSize.Height
            .MinimumSize = New Size(100, h)
            .Size = New Size(.Width, h)
          Else
            .MinimumSize = New Size(0, 0)
          End If
          .Dock = DockStyle.Fill
          '.Invalidate(True)
        End With
        'For entire control to refresh and repaint
        'Update()
      Case DockPanelType.Tab
        Visible = True
        'Hide the main panel
        PnlMain.Visible = False
        'Apply Client Panel layout and sizing
        With PnlClient
          .Alignment = System.Windows.Forms.TabAlignment.Top
          If PanelShowClose Then
            .Padding = New System.Drawing.Point(20, 2)
          Else
            .Padding = New System.Drawing.Point(2, 2)
          End If
          .Size = New Size(0, 0)
          .Dock = DockStyle.Fill
          .Invalidate()
        End With
        'Update()
    End Select
  End Sub

  Private Sub PnlClient_Selected(sender As Object, e As TabControlEventArgs) Handles PnlClient.Selected
    SetPanelState()
  End Sub

  Private Sub PnlClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PnlClient.SelectedIndexChanged
    If PanelSelectedItem Is Nothing Then Exit Sub
    LblCaption.Text = PnlClient.SelectedTab.Text
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("DockPanel.SelectedItemChanged(panelItem=[{0},{1},{2}])", PanelSelectedItem.Key, PanelSelectedItem.LocationCurrent.ToString, PanelSelectedIndex)
#End If
    RaiseEvent PanelItemSelected(PanelSelectedItem)
  End Sub

  Private Sub PnlContextMenu_ContextItemClicked(item As ToolStripMenuItem) Handles PnlContextMenu.ContextItemClicked
    Dim panelItem As DockPanelItem = PanelSelectedItem
    Select Case item.Name
      Case "MnuDockClose"
        RemoveItem(panelItem)
      Case "MnuDockLeftTop"
        RaiseEvent PanelItemLocationChange(panelItem, DockPanelLocation.LeftTop)
      Case "MnuDockLeftBottom"
        RaiseEvent PanelItemLocationChange(panelItem, DockPanelLocation.LeftBottom)
      Case "MnuDockRightTop"
        RaiseEvent PanelItemLocationChange(panelItem, DockPanelLocation.RightTop)
      Case "MnuDockRightBottom"
        RaiseEvent PanelItemLocationChange(panelItem, DockPanelLocation.RightBottom)
      Case "MnuDockMiddleBottom"
        RaiseEvent PanelItemLocationChange(panelItem, DockPanelLocation.MiddleBottom)
      Case "MnuDockTabbed"
        RaiseEvent PanelItemLocationChange(panelItem, DockPanelLocation.MiddleTopLeft)
    End Select
  End Sub

  Private Sub ReLayoutRequired(sender As Object, e As EventArgs) Handles Me.SizeChanged, Me.Load
    LayoutPanel()
  End Sub

  Private Sub RemoveBlankTabs()
    Dim cnt As Integer = PnlClient.TabCount - 1
    For idx As Integer = cnt To 0 Step -1
      If PnlClient.TabPages(idx).Text = "" Then
        PnlClient.TabPages.RemoveAt(idx)
      End If
    Next
  End Sub

  Private Sub SetPanelState()
    If PnlClient.SelectedTab Is Nothing Then Exit Sub
    Dim tp As TabPage = PnlClient.SelectedTab
    If tp.Controls.Count = 0 Then Exit Sub
    Dim item As DockPanelItem = TryCast(tp.Controls(0), DockPanelItem)
    If PanelShowClose = item.ItemSupportsClose And PanelShowContextMenu = item.ItemSupportsMove And PanelShowSearch = item.ItemSupportsSearch Then Exit Sub
    SuspendLayout()
    PanelShowClose = item.ItemSupportsClose
    PanelShowContextMenu = item.ItemSupportsMove
    PanelShowSearch = item.ItemSupportsSearch
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Private Sub TxtSearch_GotFocus(sender As Object, e As EventArgs) Handles TxtSearch.GotFocus
    If TxtSearch.Text.Equals("Search") Then
      TxtSearch.Text = ""
    End If
    TxtSearch.ForeColor = My.Theme.PanelFontColor
    TxtSearch.BackColor = My.Theme.PanelBackColor
  End Sub

  Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyDown
    If e.KeyCode = Keys.Enter Then
      e.Handled = True
      PanelSelectedItem.ApplySearch(TxtSearch.Text)
      BtnSearch.Icon = BtnClose.Icon
    ElseIf e.KeyCode = Keys.Escape Then
      PanelSelectedItem.ClearSearch()
      BtnSearch.Icon = My.Resources.panel_search
      TxtSearch.Text = "Search"
      TxtSearch.ForeColor = My.Theme.PanelShadowColor
      PnlClient.Focus()
    End If
  End Sub

  Private Sub TxtSearch_LostFocus(sender As Object, e As EventArgs) Handles TxtSearch.LostFocus
    If TxtSearch.Text.Equals("") Then
      TxtSearch.Text = "Search"
    End If
    TxtSearch.BackColor = My.Theme.PanelBorderColor
  End Sub

#End Region

#Region "Protected Methods"

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

#End Region

#Region "Public Methods"

  Public Sub AddItem(item As DockPanelItem)
    item.LocationCurrent = PanelLocation
    PnlClient.TabPages.Add(item.Key, item.ItemCaption)
    With PnlClient.TabPages(item.Key)
      .Name = item.Key
      .Padding = New Padding(0)
      .Margin = New Padding(0)
      .BackColor = My.Theme.PanelBackColor
      .BorderStyle = BorderStyle.None
      .UseVisualStyleBackColor = False
      .ForeColor = My.Theme.PanelFontColor
      .Controls.Add(CType(item, Control))
    End With
    AddHandler item.PanelItemGotFocus, AddressOf DockPanel_GotFocus
    RemoveBlankTabs()
    LayoutPanel()
    PnlClient.SelectTab(item.Key)
    LblCaption.Text = item.ItemCaption
    SetPanelState()
  End Sub

  Public Function GetItem(key As String) As DockPanelItem
    If HasItem(key) Then
      Return TryCast(PnlClient.TabPages(key).Controls(0), DockPanelItem)
    End If
    Return Nothing
  End Function

  Public Function GetItem() As DockPanelItem
    Return PanelSelectedItem
  End Function

  Public Function HasItem(key As String) As Boolean
    Return PnlClient.TabPages.ContainsKey(key)
  End Function

  Public Function RemoveItem(key As String) As DockPanelItem
    If HasItem(key) Then
      Return RemoveItem(GetItem(key))
    End If
    Return Nothing
  End Function

  Public Function RemoveItem(panelItem As DockPanelItem) As DockPanelItem
    If panelItem IsNot Nothing Then
      RaiseEvent PanelItemClose(panelItem)
      AddPlaceholderTab()
      PnlClient.TabPages.RemoveByKey(panelItem.Key)
      PnlClient.SelectedIndex = 0
      If HasTabs() Then
        LblCaption.Text = PnlClient.SelectedTab.Text
      Else
        Visible = False
        RaiseEvent PanelClose(Me)
      End If
      LayoutPanel()
      Return panelItem
    End If
    Return Nothing
  End Function

  Public Sub SelectItem(key As String)
    If HasItem(key) Then
      PnlClient.SelectTab(PnlClient.TabPages.IndexOfKey(key))
      SetPanelState()
    End If
  End Sub

#End Region

End Class