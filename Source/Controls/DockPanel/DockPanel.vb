﻿Public Class DockPanel
  Inherits System.Windows.Forms.UserControl

#Region "Events"

  Public Event PanelCloseRequested(sender As DockPanel)

  Public Event PanelFocusChanged(sender As DockPanel, hasFocus As Boolean)

  Public Event PanelLocationChanged(sender As DockPanel, newPanelLocation As DockPanelLocation)

  Public Event PanelTypeChanged(sender As DockPanel, newPanelType As DockPanelType)

#End Region

#Region "Properties"

  Public ReadOnly Property PanelCaption As String
    Get
      Return lblCaption.Text
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
      Return tabPages.Count
    End Get
  End Property

  Public Property PanelLocation As DockPanelLocation
    Get
      Return _PanelLocation
    End Get
    Set(value As DockPanelLocation)
      If _PanelLocation <> value Then
        _PanelLocation = value
        RaiseEvent PanelLocationChanged(Me, value)
      End If
    End Set
  End Property

  Public ReadOnly Property PanelSelectedIndex As Integer
    Get
      Return pnlClient.SelectedIndex
    End Get
  End Property

  Public ReadOnly Property PanelSelectedItem As IDockPanelItem
    Get
      If pnlClient.TabCount > 0 Then
        If pnlClient.SelectedTab.Controls.Count > 0 Then
          Return CType(pnlClient.SelectedTab.Controls(0), IDockPanelItem)
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
        RaiseEvent PanelTypeChanged(Me, value)
        LayoutPanel()
      End If
    End Set
  End Property

  Public ReadOnly Property tabPages As TabControl.TabPageCollection
    Get
      Return pnlClient.TabPages
    End Get
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    pnlMain = New AncestryAssistant.FlatPanel()
    pnlSearch = New AncestryAssistant.FlatPanel()
    txtSearch = New System.Windows.Forms.TextBox()
    pnlButtonContainerSearch = New System.Windows.Forms.TableLayoutPanel()
    btnSearch = New AncestryAssistant.IconButton()
    pnlHeader = New AncestryAssistant.FlatPanel()
    lblCaption = New System.Windows.Forms.Label()
    pnlButtonContainerHeader = New System.Windows.Forms.TableLayoutPanel()
    btnClose = New AncestryAssistant.IconButton()
    btnPinned = New AncestryAssistant.IconButton()
    btnContextMenu = New AncestryAssistant.IconButton()
    pnlClient = New AncestryAssistant.DockTabControl()
    TabPage1 = New System.Windows.Forms.TabPage()
    pnlMain.SuspendLayout()
    pnlSearch.SuspendLayout()
    pnlButtonContainerSearch.SuspendLayout()
    pnlHeader.SuspendLayout()
    pnlButtonContainerHeader.SuspendLayout()
    pnlClient.SuspendLayout()
    SuspendLayout()
    '
    'pnlMain
    '
    pnlMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly
    pnlMain.BorderColor = My.Theme.PanelBorderColor
    pnlMain.BorderColorBottom = My.Theme.PanelBorderColor
    pnlMain.BorderColorLeft = My.Theme.PanelBorderColor
    pnlMain.BorderColorRight = My.Theme.PanelBorderColor
    pnlMain.BorderColorTop = System.Drawing.Color.Lime
    pnlMain.BorderWidth = New System.Windows.Forms.Padding(1, 3, 1, 1)
    pnlMain.Controls.Add(pnlSearch)
    pnlMain.Controls.Add(pnlHeader)
    pnlMain.CornerRadius = New System.Windows.Forms.Padding(0)
    pnlMain.Dock = System.Windows.Forms.DockStyle.Top
    pnlMain.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    pnlMain.ForeColor = System.Drawing.Color.WhiteSmoke
    pnlMain.Location = New System.Drawing.Point(0, 0)
    pnlMain.Margin = New System.Windows.Forms.Padding(0)
    pnlMain.MaximumSize = New System.Drawing.Size(0, 42)
    pnlMain.MinimumSize = New System.Drawing.Size(170, 42)
    pnlMain.Name = "pnlMain"
    pnlMain.Padding = New System.Windows.Forms.Padding(1, 3, 1, 1)
    pnlMain.Size = New System.Drawing.Size(348, 42)
    pnlMain.TabIndex = 5
    '
    'pnlSearch
    '
    pnlSearch.BackColor = My.Theme.PanelBorderColor
    pnlSearch.BorderColor = System.Drawing.Color.Transparent
    pnlSearch.BorderColorBottom = System.Drawing.Color.Black
    pnlSearch.BorderColorLeft = System.Drawing.Color.Black
    pnlSearch.BorderColorRight = System.Drawing.Color.Black
    pnlSearch.BorderColorTop = System.Drawing.Color.Black
    pnlSearch.BorderWidth = New System.Windows.Forms.Padding(0)
    pnlSearch.Controls.Add(txtSearch)
    pnlSearch.Controls.Add(pnlButtonContainerSearch)
    pnlSearch.CornerRadius = New System.Windows.Forms.Padding(0)
    pnlSearch.Dock = System.Windows.Forms.DockStyle.Top
    pnlSearch.Location = New System.Drawing.Point(1, 23)
    pnlSearch.Margin = New System.Windows.Forms.Padding(0)
    pnlSearch.MaximumSize = New System.Drawing.Size(0, 20)
    pnlSearch.MinimumSize = New System.Drawing.Size(0, 20)
    pnlSearch.Name = "pnlSearch"
    pnlSearch.Padding = New System.Windows.Forms.Padding(4, 3, 1, 1)
    pnlSearch.Size = New System.Drawing.Size(346, 20)
    pnlSearch.TabIndex = 2
    '
    'txtSearch
    '
    txtSearch.BackColor = My.Theme.PanelBorderColor
    txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
    txtSearch.Dock = System.Windows.Forms.DockStyle.Fill
    txtSearch.ForeColor = System.Drawing.Color.White
    txtSearch.Location = New System.Drawing.Point(4, 3)
    txtSearch.Margin = New System.Windows.Forms.Padding(0)
    txtSearch.Name = "txtSearch"
    txtSearch.Size = New System.Drawing.Size(321, 15)
    txtSearch.TabIndex = 3
    txtSearch.Text = "Search"
    '
    'pnlButtonContainerSearch
    '
    pnlButtonContainerSearch.ColumnCount = 1
    pnlButtonContainerSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    pnlButtonContainerSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    pnlButtonContainerSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    pnlButtonContainerSearch.Controls.Add(btnSearch, 0, 0)
    pnlButtonContainerSearch.Dock = System.Windows.Forms.DockStyle.Right
    pnlButtonContainerSearch.Location = New System.Drawing.Point(325, 3)
    pnlButtonContainerSearch.Margin = New System.Windows.Forms.Padding(0)
    pnlButtonContainerSearch.Name = "pnlButtonContainerSearch"
    pnlButtonContainerSearch.RowCount = 1
    pnlButtonContainerSearch.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    pnlButtonContainerSearch.Size = New System.Drawing.Size(20, 16)
    pnlButtonContainerSearch.TabIndex = 2
    '
    'btnSearch
    '
    btnSearch.BackClickColor = System.Drawing.Color.Silver
    btnSearch.BackColor = My.Theme.PanelBackColor
    btnSearch.BackHoverColor = System.Drawing.Color.DarkGray
    btnSearch.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnSearch.BorderBottomSize = 0
    btnSearch.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnSearch.BorderLeftSize = 0
    btnSearch.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnSearch.BorderRightSize = 0
    btnSearch.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnSearch.BorderTopSize = 0
    btnSearch.btnState = AncestryAssistant.IconButton.IconButtonStateEnum.STANDARD
    btnSearch.ButtonSize = AncestryAssistant.IconSizeEnum.Icon16x16
    btnSearch.Checked = False
    btnSearch.CheckOnClick = False
    btnSearch.IconAncestry0 = AncestryAssistant.FontAncestryIconEnum.BLANK
    btnSearch.IconAncestry0_AdjH = 0
    btnSearch.IconAncestry0_AdjV = 0
    btnSearch.IconAncestry0_Bold = False
    btnSearch.IconAncestry0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnSearch.IconAncestry0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnSearch.IconAncestry0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnSearch.IconAncestry0_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnSearch.IconAncestry1 = AncestryAssistant.FontAncestryIconEnum.BLANK
    btnSearch.IconAncestry1_AdjH = 0
    btnSearch.IconAncestry1_AdjV = 0
    btnSearch.IconAncestry1_Bold = False
    btnSearch.IconAncestry1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnSearch.IconAncestry1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnSearch.IconAncestry1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnSearch.IconAncestry1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnSearch.IconSegoe0 = AncestryAssistant.FontSegoeFluentIconsEnum.SearchMedium
    btnSearch.IconSegoe0_AdjH = 0
    btnSearch.IconSegoe0_AdjV = 0
    btnSearch.IconSegoe0_Bold = False
    btnSearch.IconSegoe0_DisabledForeColor = System.Drawing.Color.Gainsboro
    btnSearch.IconSegoe0_Forecolor = System.Drawing.Color.WhiteSmoke
    btnSearch.IconSegoe0_HoverForeColor = System.Drawing.Color.White
    btnSearch.IconSegoe0_Size = AncestryAssistant.IconSizeEnum.Icon12x12
    btnSearch.IconSegoe1 = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
    btnSearch.IconSegoe1_AdjH = 0
    btnSearch.IconSegoe1_AdjV = 0
    btnSearch.IconSegoe1_Bold = False
    btnSearch.IconSegoe1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnSearch.IconSegoe1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnSearch.IconSegoe1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnSearch.IconSegoe1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnSearch.Location = New System.Drawing.Point(4, 0)
    btnSearch.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
    btnSearch.MaximumSize = New System.Drawing.Size(16, 16)
    btnSearch.MinimumSize = New System.Drawing.Size(16, 16)
    btnSearch.Name = "btnSearch"
    btnSearch.ShowBorder = False
    btnSearch.ShowClick = True
    btnSearch.ShowHover = True
    btnSearch.Size = New System.Drawing.Size(16, 16)
    btnSearch.TabIndex = 0
    btnSearch.ThemeComponentId = Nothing
    btnSearch.ThemeStyle = ""
    '
    'pnlHeader
    '
    pnlHeader.BackColor = My.Theme.PanelBackColor
    pnlHeader.BorderColorBottom = My.Theme.PanelBorderColor
    pnlHeader.BorderColorLeft = My.Theme.PanelBorderColor
    pnlHeader.BorderColorRight = My.Theme.PanelBorderColor
    pnlHeader.BorderColorTop = My.Theme.PanelHighlightColor
    pnlHeader.BorderWidth = New System.Windows.Forms.Padding(1, 0, 1, 1)
    pnlHeader.Controls.Add(lblCaption)
    pnlHeader.Controls.Add(pnlButtonContainerHeader)
    pnlHeader.CornerRadius = New System.Windows.Forms.Padding(0)
    pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
    pnlHeader.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    pnlHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
    pnlHeader.Location = New System.Drawing.Point(1, 3)
    pnlHeader.Margin = New System.Windows.Forms.Padding(0)
    pnlHeader.MaximumSize = New System.Drawing.Size(0, 20)
    pnlHeader.MinimumSize = New System.Drawing.Size(0, 20)
    pnlHeader.Name = "pnlHeader"
    pnlHeader.Padding = New System.Windows.Forms.Padding(1, 0, 1, 1)
    pnlHeader.Size = New System.Drawing.Size(346, 20)
    pnlHeader.TabIndex = 0
    '
    'lblCaption
    '
    lblCaption.Dock = System.Windows.Forms.DockStyle.Fill
    lblCaption.Location = New System.Drawing.Point(1, 0)
    lblCaption.Name = "lblCaption"
    lblCaption.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
    lblCaption.Size = New System.Drawing.Size(284, 19)
    lblCaption.TabIndex = 2
    lblCaption.Text = "DockPanelHeader"
    '
    'pnlButtonContainerHeader
    '
    pnlButtonContainerHeader.ColumnCount = 3
    pnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    pnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    pnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    pnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
    pnlButtonContainerHeader.Controls.Add(btnClose, 2, 0)
    pnlButtonContainerHeader.Controls.Add(btnPinned, 1, 0)
    pnlButtonContainerHeader.Controls.Add(btnContextMenu, 0, 0)
    pnlButtonContainerHeader.Dock = System.Windows.Forms.DockStyle.Right
    pnlButtonContainerHeader.Location = New System.Drawing.Point(285, 0)
    pnlButtonContainerHeader.Margin = New System.Windows.Forms.Padding(0)
    pnlButtonContainerHeader.Name = "pnlButtonContainerHeader"
    pnlButtonContainerHeader.RowCount = 1
    pnlButtonContainerHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    pnlButtonContainerHeader.Size = New System.Drawing.Size(60, 19)
    pnlButtonContainerHeader.TabIndex = 1
    '
    'btnClose
    '
    btnClose.BackClickColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
    btnClose.BackColor = My.Theme.PanelBackColor
    btnClose.BackHoverColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
    btnClose.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnClose.BorderBottomSize = 0
    btnClose.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnClose.BorderLeftSize = 0
    btnClose.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnClose.BorderRightSize = 0
    btnClose.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnClose.BorderTopSize = 0
    btnClose.btnState = AncestryAssistant.IconButton.IconButtonStateEnum.STANDARD
    btnClose.ButtonSize = AncestryAssistant.IconSizeEnum.Icon16x16
    btnClose.Checked = False
    btnClose.CheckOnClick = False
    btnClose.IconAncestry0 = AncestryAssistant.FontAncestryIconEnum.BLANK
    btnClose.IconAncestry0_AdjH = 0
    btnClose.IconAncestry0_AdjV = 0
    btnClose.IconAncestry0_Bold = False
    btnClose.IconAncestry0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnClose.IconAncestry0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnClose.IconAncestry0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnClose.IconAncestry0_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnClose.IconAncestry1 = AncestryAssistant.FontAncestryIconEnum.BLANK
    btnClose.IconAncestry1_AdjH = 0
    btnClose.IconAncestry1_AdjV = 0
    btnClose.IconAncestry1_Bold = False
    btnClose.IconAncestry1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnClose.IconAncestry1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnClose.IconAncestry1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnClose.IconAncestry1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnClose.IconSegoe0 = AncestryAssistant.FontSegoeFluentIconsEnum.CalculatorMultiply
    btnClose.IconSegoe0_AdjH = 0
    btnClose.IconSegoe0_AdjV = 0
    btnClose.IconSegoe0_Bold = False
    btnClose.IconSegoe0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnClose.IconSegoe0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
    btnClose.IconSegoe0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnClose.IconSegoe0_Size = AncestryAssistant.IconSizeEnum.Icon12x12
    btnClose.IconSegoe1 = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
    btnClose.IconSegoe1_AdjH = 0
    btnClose.IconSegoe1_AdjV = 0
    btnClose.IconSegoe1_Bold = False
    btnClose.IconSegoe1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnClose.IconSegoe1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnClose.IconSegoe1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnClose.IconSegoe1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnClose.Location = New System.Drawing.Point(40, 1)
    btnClose.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
    btnClose.MaximumSize = New System.Drawing.Size(16, 16)
    btnClose.MinimumSize = New System.Drawing.Size(16, 16)
    btnClose.Name = "btnClose"
    btnClose.ShowBorder = False
    btnClose.ShowClick = True
    btnClose.ShowHover = True
    btnClose.Size = New System.Drawing.Size(16, 16)
    btnClose.TabIndex = 0
    btnClose.ThemeComponentId = Nothing
    btnClose.ThemeStyle = ""
    '
    'btnPinned
    '
    btnPinned.BackClickColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
    btnPinned.BackColor = My.Theme.PanelBackColor
    btnPinned.BackHoverColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
    btnPinned.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnPinned.BorderBottomSize = 0
    btnPinned.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnPinned.BorderLeftSize = 0
    btnPinned.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnPinned.BorderRightSize = 0
    btnPinned.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnPinned.BorderTopSize = 0
    btnPinned.btnState = AncestryAssistant.IconButton.IconButtonStateEnum.STANDARD
    btnPinned.ButtonSize = AncestryAssistant.IconSizeEnum.Icon16x16
    btnPinned.Checked = False
    btnPinned.CheckOnClick = False
    btnPinned.IconAncestry0 = AncestryAssistant.FontAncestryIconEnum.BLANK
    btnPinned.IconAncestry0_AdjH = 0
    btnPinned.IconAncestry0_AdjV = 0
    btnPinned.IconAncestry0_Bold = False
    btnPinned.IconAncestry0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnPinned.IconAncestry0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnPinned.IconAncestry0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnPinned.IconAncestry0_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnPinned.IconAncestry1 = AncestryAssistant.FontAncestryIconEnum.BLANK
    btnPinned.IconAncestry1_AdjH = 0
    btnPinned.IconAncestry1_AdjV = 0
    btnPinned.IconAncestry1_Bold = False
    btnPinned.IconAncestry1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnPinned.IconAncestry1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnPinned.IconAncestry1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnPinned.IconAncestry1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnPinned.IconSegoe0 = AncestryAssistant.FontSegoeFluentIconsEnum.Pinned
    btnPinned.IconSegoe0_AdjH = 0
    btnPinned.IconSegoe0_AdjV = 0
    btnPinned.IconSegoe0_Bold = False
    btnPinned.IconSegoe0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnPinned.IconSegoe0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
    btnPinned.IconSegoe0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnPinned.IconSegoe0_Size = AncestryAssistant.IconSizeEnum.Icon12x12
    btnPinned.IconSegoe1 = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
    btnPinned.IconSegoe1_AdjH = 0
    btnPinned.IconSegoe1_AdjV = 0
    btnPinned.IconSegoe1_Bold = False
    btnPinned.IconSegoe1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnPinned.IconSegoe1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnPinned.IconSegoe1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnPinned.IconSegoe1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnPinned.Location = New System.Drawing.Point(20, 1)
    btnPinned.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
    btnPinned.MaximumSize = New System.Drawing.Size(16, 16)
    btnPinned.MinimumSize = New System.Drawing.Size(16, 16)
    btnPinned.Name = "btnPinned"
    btnPinned.ShowBorder = False
    btnPinned.ShowClick = True
    btnPinned.ShowHover = True
    btnPinned.Size = New System.Drawing.Size(16, 16)
    btnPinned.TabIndex = 1
    btnPinned.ThemeComponentId = Nothing
    btnPinned.ThemeStyle = ""
    '
    'btnContextMenu
    '
    btnContextMenu.BackClickColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
    btnContextMenu.BackColor = My.Theme.PanelBackColor
    btnContextMenu.BackHoverColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
    btnContextMenu.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnContextMenu.BorderBottomSize = 0
    btnContextMenu.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnContextMenu.BorderLeftSize = 0
    btnContextMenu.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnContextMenu.BorderRightSize = 0
    btnContextMenu.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
    btnContextMenu.BorderTopSize = 0
    btnContextMenu.btnState = AncestryAssistant.IconButton.IconButtonStateEnum.STANDARD
    btnContextMenu.ButtonSize = AncestryAssistant.IconSizeEnum.Icon16x16
    btnContextMenu.Checked = False
    btnContextMenu.CheckOnClick = False
    btnContextMenu.IconAncestry0 = AncestryAssistant.FontAncestryIconEnum.BLANK
    btnContextMenu.IconAncestry0_AdjH = 0
    btnContextMenu.IconAncestry0_AdjV = 0
    btnContextMenu.IconAncestry0_Bold = False
    btnContextMenu.IconAncestry0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnContextMenu.IconAncestry0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnContextMenu.IconAncestry0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnContextMenu.IconAncestry0_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnContextMenu.IconAncestry1 = AncestryAssistant.FontAncestryIconEnum.BLANK
    btnContextMenu.IconAncestry1_AdjH = 0
    btnContextMenu.IconAncestry1_AdjV = 0
    btnContextMenu.IconAncestry1_Bold = False
    btnContextMenu.IconAncestry1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnContextMenu.IconAncestry1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnContextMenu.IconAncestry1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnContextMenu.IconAncestry1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnContextMenu.IconSegoe0 = AncestryAssistant.FontSegoeFluentIconsEnum.CaretSolidDown
    btnContextMenu.IconSegoe0_AdjH = 0
    btnContextMenu.IconSegoe0_AdjV = 0
    btnContextMenu.IconSegoe0_Bold = False
    btnContextMenu.IconSegoe0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnContextMenu.IconSegoe0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
    btnContextMenu.IconSegoe0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnContextMenu.IconSegoe0_Size = AncestryAssistant.IconSizeEnum.Icon8x8
    btnContextMenu.IconSegoe1 = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
    btnContextMenu.IconSegoe1_AdjH = 0
    btnContextMenu.IconSegoe1_AdjV = 0
    btnContextMenu.IconSegoe1_Bold = False
    btnContextMenu.IconSegoe1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
    btnContextMenu.IconSegoe1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    btnContextMenu.IconSegoe1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
    btnContextMenu.IconSegoe1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
    btnContextMenu.Location = New System.Drawing.Point(0, 1)
    btnContextMenu.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
    btnContextMenu.MaximumSize = New System.Drawing.Size(16, 16)
    btnContextMenu.MinimumSize = New System.Drawing.Size(16, 16)
    btnContextMenu.Name = "btnContextMenu"
    btnContextMenu.ShowBorder = False
    btnContextMenu.ShowClick = True
    btnContextMenu.ShowHover = True
    btnContextMenu.Size = New System.Drawing.Size(16, 16)
    btnContextMenu.TabIndex = 2
    btnContextMenu.ThemeComponentId = Nothing
    btnContextMenu.ThemeStyle = ""
    '
    'pnlClient
    '
    pnlClient.Alignment = System.Windows.Forms.TabAlignment.Bottom
    pnlClient.Controls.Add(TabPage1)
    pnlClient.Dock = System.Windows.Forms.DockStyle.Fill
    pnlClient.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
    pnlClient.HotTrack = True
    pnlClient.Location = New System.Drawing.Point(0, 42)
    pnlClient.Margin = New System.Windows.Forms.Padding(0)
    pnlClient.Name = "pnlClient"
    pnlClient.SelectedIndex = 0
    pnlClient.ShowHasFocus = False
    pnlClient.ShowToolTips = True
    pnlClient.Size = New System.Drawing.Size(348, 310)
    pnlClient.TabIndex = 6
    pnlClient.TabShowClose = True
    pnlClient.TabType = AncestryAssistant.DockPanelType.Tab
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
    Controls.Add(pnlClient)
    Controls.Add(pnlMain)
    Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    ForeColor = System.Drawing.Color.WhiteSmoke
    Margin = New System.Windows.Forms.Padding(0)
    Name = "DockPanel"
    Size = New System.Drawing.Size(348, 352)
    pnlMain.ResumeLayout(False)
    pnlSearch.ResumeLayout(False)
    pnlSearch.PerformLayout()
    pnlButtonContainerSearch.ResumeLayout(False)
    pnlHeader.ResumeLayout(False)
    pnlButtonContainerHeader.ResumeLayout(False)
    pnlClient.ResumeLayout(False)
    ResumeLayout(False)

    DoubleBuffered = True
    ctxMenu = New ContextMenuStrip With {
      .DropShadowEnabled = True
    }
    SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw, True)
    pnlSearch.BackColor = My.Theme.PanelBorderColor
    txtSearch.BackColor = My.Theme.PanelBorderColor
    btnSearch.BackColor = My.Theme.PanelBorderColor
    txtSearch.ForeColor = My.Theme.PanelShadowColor
    btnSearch.Tag = btnSearch.IconSegoe0
    BackColor = My.Theme.PanelBackColor
    ForeColor = My.Theme.PanelFontColor
    With pnlClient
      .HotTrack = True
      .Margin = New System.Windows.Forms.Padding(0)
      .ShowToolTips = True
      .TabPages(0).Text = ""
      .TabPages(0).BackColor = My.Theme.PanelBackColor
      .TabPages(0).ForeColor = My.Theme.PanelFontColor
    End With
    UpdateStyles()
    lblCaption.Text = ""
    CaptureFocus(Me)
    LayoutPanel()
  End Sub

#End Region

#Region "Private Methods"

  Private Sub AddPlaceholderTab()
    If pnlClient.TabCount = 1 Then
      If Not pnlClient.SelectedTab.Text.Equals("") Then
        pnlClient.TabPages.Add("BLANK", "")
      End If
    End If
  End Sub

  Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click, pnlClient.btnClose_Click
    RemoveItem(PanelSelectedIndex)
  End Sub

  Private Sub btnPinned_Click(sender As Object, e As EventArgs) Handles btnPinned.Click
    PanelIsPinned = Not PanelIsPinned
  End Sub

  Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
    If txtSearch.Text.Equals("Search") And btnSearch.IconSegoe0 = btnSearch.Tag Then Exit Sub
    If btnSearch.IconSegoe0 = btnClose.IconSegoe0 Then
      PanelSelectedItem.ClearSearch()
      btnSearch.IconSegoe0 = btnSearch.Tag
      txtSearch.Text = "Search"
      txtSearch.ForeColor = My.Theme.PanelShadowColor
    Else
      PanelSelectedItem.ApplySearch(txtSearch.Text)
      btnSearch.IconSegoe0 = btnClose.IconSegoe0
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

  Private Sub DockPanel_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
    PanelHasFocus = True
  End Sub

  Private Function hasTabs() As Boolean
    If pnlClient.TabCount > 1 Then Return True
    If pnlClient.TabCount = 0 Then Return False
    If pnlClient.TabPages(0).Text.Equals("") Then Return False
    Return True
  End Function

  Private Sub LayoutPanel()
    Debug.Print("LayoutPanel: {0}", Name)
    'Prevent display of control when its empty
    If Not hasTabs() Then
      Visible = False
      Exit Sub
    End If
    'We have data so generate the interface
    Visible = True
    With ctxMenu
      .BackColor = My.Theme.PanelBorderColor
      .ForeColor = My.Theme.PanelFontColor
    End With
    With pnlClient
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
        btnClose.Visible = PanelShowClose
        btnContextMenu.Visible = PanelShowContextMenu
        btnPinned.Visible = PanelShowPinned
        pnlSearch.Visible = PanelShowSearch
        'Apply Main Panel Formatting and refresh
        With pnlMain
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
            .BorderColorTop = My.Theme.PanelHighlightColor
            .BorderWidth = New Padding(1, 3, 1, 1)
          Else
            .BorderColorTop = My.Theme.PanelBorderColor
            .BorderWidth = New Padding(1, 1, 1, 1)
          End If
          .Invalidate(True)
        End With
        'Apply Client Panel layout and sizing
        With pnlClient
          .Alignment = System.Windows.Forms.TabAlignment.Bottom
          .Padding = New System.Drawing.Point(2, 2)
          If .TabPages.Count < 2 Then
            Dim h As Integer = Height - pnlMain.Height + .ItemSize.Height
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
        pnlMain.Visible = False
        'Apply Client Panel layout and sizing
        With pnlClient
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

  Private Sub lblCaption_Click(sender As Object, e As EventArgs) Handles lblCaption.Click

  End Sub

  Private Sub pnlClient_Selected(sender As Object, e As TabControlEventArgs) Handles pnlClient.Selected
    SetPanelState()
  End Sub

  Private Sub pnlClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pnlClient.SelectedIndexChanged
    lblCaption.Text = pnlClient.SelectedTab.Text
  End Sub

  Private Sub pnlClient_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles pnlClient.Selecting

  End Sub

  Private Sub ReLayoutRequired(sender As Object, e As EventArgs) Handles Me.SizeChanged, Me.Load
    LayoutPanel()
  End Sub

  Private Sub RemoveBlankTabs()
    Dim cnt As Integer = pnlClient.TabCount - 1
    For idx As Integer = cnt To 0 Step -1
      If pnlClient.TabPages(idx).Text = "" Then
        pnlClient.TabPages.RemoveAt(idx)
      End If
    Next
  End Sub

  Private Sub SetPanelState()
    If pnlClient.SelectedTab Is Nothing Then Exit Sub
    Dim tp As TabPage = pnlClient.SelectedTab
    If tp.Controls.Count = 0 Then Exit Sub
    Dim item As IDockPanelItem = CType(tp.Controls(0), IDockPanelItem)
    SuspendLayout()
    PanelShowClose = item.ItemSupportsClose
    PanelShowContextMenu = item.ItemSupportsMove
    PanelShowSearch = item.ItemSupportsSearch
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
    If txtSearch.Text.Equals("Search") Then
      txtSearch.Text = ""
    End If
    txtSearch.ForeColor = My.Theme.PanelFontColor
    txtSearch.BackColor = My.Theme.PanelBackColor
  End Sub

  Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
    If e.KeyCode = Keys.Enter Then
      e.Handled = True
      PanelSelectedItem.ApplySearch(txtSearch.Text)
      btnSearch.IconSegoe0 = btnClose.IconSegoe0
    ElseIf e.KeyCode = Keys.Escape Then
      PanelSelectedItem.ClearSearch()
      btnSearch.IconSegoe0 = btnSearch.Tag
      txtSearch.Text = "Search"
      txtSearch.ForeColor = My.Theme.PanelShadowColor
      pnlClient.Focus()
    End If
  End Sub

  Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
    If txtSearch.Text.Equals("") Then
      txtSearch.Text = "Search"
    End If
    txtSearch.BackColor = My.Theme.PanelBorderColor
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

  Public Function AddItem(item As IDockPanelItem) As Integer
    pnlClient.TabPages.Add(item.ItemCaption, item.ItemCaption)
    With pnlClient.TabPages(item.ItemCaption)
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
    pnlClient.SelectTab(item.ItemCaption)
    lblCaption.Text = item.ItemCaption
    SetPanelState()
  End Function

  Public Function GetItem(key As String) As Control
    If Not pnlClient.TabPages.ContainsKey(key) Then
      Return Nothing
    End If
    Return GetItem(pnlClient.TabPages.IndexOfKey(key))
  End Function

  Public Function GetItem(index As Integer) As Control
    If index < 0 Or index >= pnlClient.TabCount Then
      Return Nothing
    End If
    If pnlClient.TabPages(index).Controls.Count > 0 Then
      Return pnlClient.TabPages(index).Controls(0)
    Else
      Return Nothing
    End If
  End Function

  Public Function HasItem(key As String) As Boolean
    Return pnlClient.TabPages.ContainsKey(key)
  End Function

  Public Function RemoveItem(key As String) As Control
    If Not pnlClient.TabPages.ContainsKey(key) Then
      Return Nothing
    End If
    Return RemoveItem(pnlClient.TabPages.IndexOfKey(key))
  End Function

  Public Function RemoveItem(index As Integer) As Control
    Dim ctl As Control = GetItem(index)
    If ctl Is Nothing Then
      Return Nothing
    End If
    AddPlaceholderTab()
    pnlClient.TabPages.RemoveAt(index)
    If hasTabs() Then
      lblCaption.Text = pnlClient.SelectedTab.Text
    Else
      Visible = False
      RaiseEvent PanelCloseRequested(Me)
    End If
    LayoutPanel()
    Return ctl
  End Function

  Public Sub SelectItem(key As String)
    If Not pnlClient.TabPages.ContainsKey(key) Then
      Exit Sub
    End If
    SelectItem(pnlClient.TabPages.IndexOfKey(key))
  End Sub

  Public Sub SelectItem(index As Integer)
    If index >= 0 Or index < pnlClient.TabCount Then
      pnlClient.SelectedIndex = index
      SetPanelState()
    End If
  End Sub

#End Region

#Region "Fields"

  Private WithEvents btnClose As IconButton
  Private WithEvents btnContextMenu As IconButton
  Private WithEvents btnPinned As IconButton
  Private WithEvents btnSearch As IconButton
  Private WithEvents ctxMenu As ContextMenuStrip
  Private WithEvents lblCaption As Label
  Private WithEvents pnlButtonContainerHeader As TableLayoutPanel
  Private WithEvents pnlButtonContainerSearch As TableLayoutPanel
  Private WithEvents pnlClient As DockTabControl
  Private WithEvents pnlHeader As FlatPanel
  Private WithEvents pnlMain As FlatPanel
  Private WithEvents pnlSearch As FlatPanel
  Private WithEvents TabPage1 As TabPage
  Private WithEvents txtSearch As TextBox

  Private _PanelHasFocus As Boolean = True
  Private _PanelIsPinned As Boolean = True
  Private _PanelLocation As DockPanelLocation = DockPanelLocation.Floating
  Private _PanelShowClose As Boolean = True
  Private _PanelShowContextMenu As Boolean = True
  Private _PanelShowPinned As Boolean = False
  Private _PanelShowSearch As Boolean = True
  Private _PanelType As DockPanelType = DockPanelType.Panel
  Private components As System.ComponentModel.IContainer

#End Region

End Class