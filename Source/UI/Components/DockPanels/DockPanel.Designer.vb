<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DockPanel
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
        Me.pnlMain = New AncestryAssistant.BordersPanel()
        Me.pnlSearch = New AncestryAssistant.BordersPanel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.pnlButtonContainerSearch = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSearch = New AncestryAssistant.IconButton()
        Me.pnlHeader = New AncestryAssistant.BordersPanel()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.pnlButtonContainerHeader = New System.Windows.Forms.TableLayoutPanel()
        Me.btnClose = New AncestryAssistant.IconButton()
        Me.btnPinned = New AncestryAssistant.IconButton()
        Me.btnContextMenu = New AncestryAssistant.IconButton()
    Me.pnlClient = New DockTabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pnlMain.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        Me.pnlButtonContainerSearch.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlButtonContainerHeader.SuspendLayout()
        Me.pnlClient.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BorderColor = System.Drawing.Color.Transparent
        Me.pnlMain.BorderColorBottom = System.Drawing.Color.DimGray
        Me.pnlMain.BorderColorLeft = System.Drawing.Color.DimGray
        Me.pnlMain.BorderColorRight = System.Drawing.Color.DimGray
        Me.pnlMain.BorderColorTop = System.Drawing.Color.Lime
        Me.pnlMain.BorderWidth = New System.Windows.Forms.Padding(1, 3, 1, 1)
        Me.pnlMain.Controls.Add(Me.pnlSearch)
        Me.pnlMain.Controls.Add(Me.pnlHeader)
        Me.pnlMain.CornerRadius = New System.Windows.Forms.Padding(0)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMain.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlMain.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMain.MaximumSize = New System.Drawing.Size(0, 42)
        Me.pnlMain.MinimumSize = New System.Drawing.Size(170, 42)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(1, 3, 1, 1)
        Me.pnlMain.Size = New System.Drawing.Size(348, 42)
        Me.pnlMain.TabIndex = 5
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.DimGray
        Me.pnlSearch.BorderColor = System.Drawing.Color.Transparent
        Me.pnlSearch.BorderColorBottom = System.Drawing.Color.Black
        Me.pnlSearch.BorderColorLeft = System.Drawing.Color.Black
        Me.pnlSearch.BorderColorRight = System.Drawing.Color.Black
        Me.pnlSearch.BorderColorTop = System.Drawing.Color.Black
        Me.pnlSearch.BorderWidth = New System.Windows.Forms.Padding(0)
        Me.pnlSearch.Controls.Add(Me.txtSearch)
        Me.pnlSearch.Controls.Add(Me.pnlButtonContainerSearch)
        Me.pnlSearch.CornerRadius = New System.Windows.Forms.Padding(0)
        Me.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearch.Location = New System.Drawing.Point(1, 23)
        Me.pnlSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlSearch.MaximumSize = New System.Drawing.Size(0, 20)
        Me.pnlSearch.MinimumSize = New System.Drawing.Size(0, 20)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Padding = New System.Windows.Forms.Padding(4, 3, 1, 1)
        Me.pnlSearch.Size = New System.Drawing.Size(346, 20)
        Me.pnlSearch.TabIndex = 2
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.DimGray
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSearch.ForeColor = System.Drawing.Color.White
        Me.txtSearch.Location = New System.Drawing.Point(4, 3)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(321, 15)
        Me.txtSearch.TabIndex = 3
        Me.txtSearch.Text = "Search"
        '
        'pnlButtonContainerSearch
        '
        Me.pnlButtonContainerSearch.ColumnCount = 1
        Me.pnlButtonContainerSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlButtonContainerSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlButtonContainerSearch.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlButtonContainerSearch.Controls.Add(Me.btnSearch, 0, 0)
        Me.pnlButtonContainerSearch.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlButtonContainerSearch.Location = New System.Drawing.Point(325, 3)
        Me.pnlButtonContainerSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlButtonContainerSearch.Name = "pnlButtonContainerSearch"
        Me.pnlButtonContainerSearch.RowCount = 1
        Me.pnlButtonContainerSearch.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlButtonContainerSearch.Size = New System.Drawing.Size(20, 16)
        Me.pnlButtonContainerSearch.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.BackClickColor = System.Drawing.Color.Silver
        Me.btnSearch.BackColor = System.Drawing.Color.DimGray
        Me.btnSearch.BackHoverColor = System.Drawing.Color.DarkGray
        Me.btnSearch.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnSearch.BorderBottomSize = 0
        Me.btnSearch.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnSearch.BorderLeftSize = 0
        Me.btnSearch.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnSearch.BorderRightSize = 0
        Me.btnSearch.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnSearch.BorderTopSize = 0
        Me.btnSearch.btnState = AncestryAssistant.IconButton.IconButtonStateEnum.STANDARD
        Me.btnSearch.ButtonSize = AncestryAssistant.IconSizeEnum.Icon16x16
        Me.btnSearch.Checked = False
        Me.btnSearch.CheckOnClick = False
        Me.btnSearch.IconAncestry0 = AncestryAssistant.FontAncestryIconEnum.BLANK
        Me.btnSearch.IconAncestry0_AdjH = 0
        Me.btnSearch.IconAncestry0_AdjV = 0
        Me.btnSearch.IconAncestry0_Bold = False
        Me.btnSearch.IconAncestry0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnSearch.IconAncestry0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSearch.IconAncestry0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnSearch.IconAncestry0_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnSearch.IconAncestry1 = AncestryAssistant.FontAncestryIconEnum.BLANK
        Me.btnSearch.IconAncestry1_AdjH = 0
        Me.btnSearch.IconAncestry1_AdjV = 0
        Me.btnSearch.IconAncestry1_Bold = False
        Me.btnSearch.IconAncestry1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnSearch.IconAncestry1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSearch.IconAncestry1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnSearch.IconAncestry1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnSearch.IconSegoe0 = AncestryAssistant.FontSegoeFluentIconsEnum.SearchMedium
        Me.btnSearch.IconSegoe0_AdjH = 0
        Me.btnSearch.IconSegoe0_AdjV = 0
        Me.btnSearch.IconSegoe0_Bold = False
        Me.btnSearch.IconSegoe0_DisabledForeColor = System.Drawing.Color.Gainsboro
        Me.btnSearch.IconSegoe0_Forecolor = System.Drawing.Color.WhiteSmoke
        Me.btnSearch.IconSegoe0_HoverForeColor = System.Drawing.Color.White
        Me.btnSearch.IconSegoe0_Size = AncestryAssistant.IconSizeEnum.Icon12x12
        Me.btnSearch.IconSegoe1 = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.btnSearch.IconSegoe1_AdjH = 0
        Me.btnSearch.IconSegoe1_AdjV = 0
        Me.btnSearch.IconSegoe1_Bold = False
        Me.btnSearch.IconSegoe1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnSearch.IconSegoe1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSearch.IconSegoe1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnSearch.IconSegoe1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnSearch.Location = New System.Drawing.Point(4, 0)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnSearch.MaximumSize = New System.Drawing.Size(16, 16)
        Me.btnSearch.MinimumSize = New System.Drawing.Size(16, 16)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.ShowBorder = False
        Me.btnSearch.ShowClick = True
        Me.btnSearch.ShowHover = True
        Me.btnSearch.Size = New System.Drawing.Size(16, 16)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.ThemeComponentId = Nothing
        Me.btnSearch.ThemeStyle = ""
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.Black
        Me.pnlHeader.BorderColor = System.Drawing.Color.Transparent
        Me.pnlHeader.BorderColorBottom = System.Drawing.Color.Black
        Me.pnlHeader.BorderColorLeft = System.Drawing.Color.Black
        Me.pnlHeader.BorderColorRight = System.Drawing.Color.Black
        Me.pnlHeader.BorderColorTop = System.Drawing.Color.Lime
        Me.pnlHeader.BorderWidth = New System.Windows.Forms.Padding(1, 0, 1, 1)
        Me.pnlHeader.Controls.Add(Me.lblCaption)
        Me.pnlHeader.Controls.Add(Me.pnlButtonContainerHeader)
        Me.pnlHeader.CornerRadius = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pnlHeader.Location = New System.Drawing.Point(1, 3)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlHeader.MaximumSize = New System.Drawing.Size(0, 20)
        Me.pnlHeader.MinimumSize = New System.Drawing.Size(0, 20)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(1, 0, 1, 1)
        Me.pnlHeader.Size = New System.Drawing.Size(346, 20)
        Me.pnlHeader.TabIndex = 0
        '
        'lblCaption
        '
        Me.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCaption.Location = New System.Drawing.Point(1, 0)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Padding = New System.Windows.Forms.Padding(3, 3, 0, 0)
        Me.lblCaption.Size = New System.Drawing.Size(284, 19)
        Me.lblCaption.TabIndex = 2
        Me.lblCaption.Text = "DockPanelHeader"
        '
        'pnlButtonContainerHeader
        '
        Me.pnlButtonContainerHeader.ColumnCount = 3
        Me.pnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlButtonContainerHeader.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.pnlButtonContainerHeader.Controls.Add(Me.btnClose, 2, 0)
        Me.pnlButtonContainerHeader.Controls.Add(Me.btnPinned, 1, 0)
        Me.pnlButtonContainerHeader.Controls.Add(Me.btnContextMenu, 0, 0)
        Me.pnlButtonContainerHeader.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlButtonContainerHeader.Location = New System.Drawing.Point(285, 0)
        Me.pnlButtonContainerHeader.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlButtonContainerHeader.Name = "pnlButtonContainerHeader"
        Me.pnlButtonContainerHeader.RowCount = 1
        Me.pnlButtonContainerHeader.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.pnlButtonContainerHeader.Size = New System.Drawing.Size(60, 19)
        Me.pnlButtonContainerHeader.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.BackClickColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClose.BackHoverColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnClose.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnClose.BorderBottomSize = 0
        Me.btnClose.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnClose.BorderLeftSize = 0
        Me.btnClose.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnClose.BorderRightSize = 0
        Me.btnClose.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnClose.BorderTopSize = 0
        Me.btnClose.btnState = AncestryAssistant.IconButton.IconButtonStateEnum.STANDARD
        Me.btnClose.ButtonSize = AncestryAssistant.IconSizeEnum.Icon16x16
        Me.btnClose.Checked = False
        Me.btnClose.CheckOnClick = False
        Me.btnClose.IconAncestry0 = AncestryAssistant.FontAncestryIconEnum.BLANK
        Me.btnClose.IconAncestry0_AdjH = 0
        Me.btnClose.IconAncestry0_AdjV = 0
        Me.btnClose.IconAncestry0_Bold = False
        Me.btnClose.IconAncestry0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnClose.IconAncestry0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClose.IconAncestry0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnClose.IconAncestry0_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnClose.IconAncestry1 = AncestryAssistant.FontAncestryIconEnum.BLANK
        Me.btnClose.IconAncestry1_AdjH = 0
        Me.btnClose.IconAncestry1_AdjV = 0
        Me.btnClose.IconAncestry1_Bold = False
        Me.btnClose.IconAncestry1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnClose.IconAncestry1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClose.IconAncestry1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnClose.IconAncestry1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnClose.IconSegoe0 = AncestryAssistant.FontSegoeFluentIconsEnum.CalculatorMultiply
        Me.btnClose.IconSegoe0_AdjH = 0
        Me.btnClose.IconSegoe0_AdjV = 0
        Me.btnClose.IconSegoe0_Bold = False
        Me.btnClose.IconSegoe0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnClose.IconSegoe0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnClose.IconSegoe0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnClose.IconSegoe0_Size = AncestryAssistant.IconSizeEnum.Icon12x12
        Me.btnClose.IconSegoe1 = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.btnClose.IconSegoe1_AdjH = 0
        Me.btnClose.IconSegoe1_AdjV = 0
        Me.btnClose.IconSegoe1_Bold = False
        Me.btnClose.IconSegoe1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnClose.IconSegoe1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnClose.IconSegoe1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnClose.IconSegoe1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnClose.Location = New System.Drawing.Point(40, 1)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.btnClose.MaximumSize = New System.Drawing.Size(16, 16)
        Me.btnClose.MinimumSize = New System.Drawing.Size(16, 16)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.ShowBorder = False
        Me.btnClose.ShowClick = True
        Me.btnClose.ShowHover = True
        Me.btnClose.Size = New System.Drawing.Size(16, 16)
        Me.btnClose.TabIndex = 0
        Me.btnClose.ThemeComponentId = Nothing
        Me.btnClose.ThemeStyle = ""
        '
        'btnPinned
        '
        Me.btnPinned.BackClickColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnPinned.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnPinned.BackHoverColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnPinned.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnPinned.BorderBottomSize = 0
        Me.btnPinned.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnPinned.BorderLeftSize = 0
        Me.btnPinned.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnPinned.BorderRightSize = 0
        Me.btnPinned.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnPinned.BorderTopSize = 0
        Me.btnPinned.btnState = AncestryAssistant.IconButton.IconButtonStateEnum.STANDARD
        Me.btnPinned.ButtonSize = AncestryAssistant.IconSizeEnum.Icon16x16
        Me.btnPinned.Checked = False
        Me.btnPinned.CheckOnClick = False
        Me.btnPinned.IconAncestry0 = AncestryAssistant.FontAncestryIconEnum.BLANK
        Me.btnPinned.IconAncestry0_AdjH = 0
        Me.btnPinned.IconAncestry0_AdjV = 0
        Me.btnPinned.IconAncestry0_Bold = False
        Me.btnPinned.IconAncestry0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnPinned.IconAncestry0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnPinned.IconAncestry0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnPinned.IconAncestry0_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnPinned.IconAncestry1 = AncestryAssistant.FontAncestryIconEnum.BLANK
        Me.btnPinned.IconAncestry1_AdjH = 0
        Me.btnPinned.IconAncestry1_AdjV = 0
        Me.btnPinned.IconAncestry1_Bold = False
        Me.btnPinned.IconAncestry1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnPinned.IconAncestry1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnPinned.IconAncestry1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnPinned.IconAncestry1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnPinned.IconSegoe0 = AncestryAssistant.FontSegoeFluentIconsEnum.Pinned
        Me.btnPinned.IconSegoe0_AdjH = 0
        Me.btnPinned.IconSegoe0_AdjV = 0
        Me.btnPinned.IconSegoe0_Bold = False
        Me.btnPinned.IconSegoe0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnPinned.IconSegoe0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnPinned.IconSegoe0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnPinned.IconSegoe0_Size = AncestryAssistant.IconSizeEnum.Icon12x12
        Me.btnPinned.IconSegoe1 = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.btnPinned.IconSegoe1_AdjH = 0
        Me.btnPinned.IconSegoe1_AdjV = 0
        Me.btnPinned.IconSegoe1_Bold = False
        Me.btnPinned.IconSegoe1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnPinned.IconSegoe1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnPinned.IconSegoe1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnPinned.IconSegoe1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnPinned.Location = New System.Drawing.Point(20, 1)
        Me.btnPinned.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.btnPinned.MaximumSize = New System.Drawing.Size(16, 16)
        Me.btnPinned.MinimumSize = New System.Drawing.Size(16, 16)
        Me.btnPinned.Name = "btnPinned"
        Me.btnPinned.ShowBorder = False
        Me.btnPinned.ShowClick = True
        Me.btnPinned.ShowHover = True
        Me.btnPinned.Size = New System.Drawing.Size(16, 16)
        Me.btnPinned.TabIndex = 1
        Me.btnPinned.ThemeComponentId = Nothing
        Me.btnPinned.ThemeStyle = ""
        '
        'btnContextMenu
        '
        Me.btnContextMenu.BackClickColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnContextMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContextMenu.BackHoverColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.btnContextMenu.BorderBottomColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnContextMenu.BorderBottomSize = 0
        Me.btnContextMenu.BorderLeftColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnContextMenu.BorderLeftSize = 0
        Me.btnContextMenu.BorderRightColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnContextMenu.BorderRightSize = 0
        Me.btnContextMenu.BorderTopColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.btnContextMenu.BorderTopSize = 0
        Me.btnContextMenu.btnState = AncestryAssistant.IconButton.IconButtonStateEnum.STANDARD
        Me.btnContextMenu.ButtonSize = AncestryAssistant.IconSizeEnum.Icon16x16
        Me.btnContextMenu.Checked = False
        Me.btnContextMenu.CheckOnClick = False
        Me.btnContextMenu.IconAncestry0 = AncestryAssistant.FontAncestryIconEnum.BLANK
        Me.btnContextMenu.IconAncestry0_AdjH = 0
        Me.btnContextMenu.IconAncestry0_AdjV = 0
        Me.btnContextMenu.IconAncestry0_Bold = False
        Me.btnContextMenu.IconAncestry0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnContextMenu.IconAncestry0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContextMenu.IconAncestry0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnContextMenu.IconAncestry0_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnContextMenu.IconAncestry1 = AncestryAssistant.FontAncestryIconEnum.BLANK
        Me.btnContextMenu.IconAncestry1_AdjH = 0
        Me.btnContextMenu.IconAncestry1_AdjV = 0
        Me.btnContextMenu.IconAncestry1_Bold = False
        Me.btnContextMenu.IconAncestry1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnContextMenu.IconAncestry1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContextMenu.IconAncestry1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnContextMenu.IconAncestry1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnContextMenu.IconSegoe0 = AncestryAssistant.FontSegoeFluentIconsEnum.CaretSolidDown
        Me.btnContextMenu.IconSegoe0_AdjH = 0
        Me.btnContextMenu.IconSegoe0_AdjV = 0
        Me.btnContextMenu.IconSegoe0_Bold = False
        Me.btnContextMenu.IconSegoe0_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnContextMenu.IconSegoe0_Forecolor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnContextMenu.IconSegoe0_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnContextMenu.IconSegoe0_Size = AncestryAssistant.IconSizeEnum.Icon8x8
        Me.btnContextMenu.IconSegoe1 = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.btnContextMenu.IconSegoe1_AdjH = 0
        Me.btnContextMenu.IconSegoe1_AdjV = 0
        Me.btnContextMenu.IconSegoe1_Bold = False
        Me.btnContextMenu.IconSegoe1_DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnContextMenu.IconSegoe1_Forecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnContextMenu.IconSegoe1_HoverForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btnContextMenu.IconSegoe1_Size = AncestryAssistant.IconSizeEnum.Icon20x20
        Me.btnContextMenu.Location = New System.Drawing.Point(0, 1)
        Me.btnContextMenu.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.btnContextMenu.MaximumSize = New System.Drawing.Size(16, 16)
        Me.btnContextMenu.MinimumSize = New System.Drawing.Size(16, 16)
        Me.btnContextMenu.Name = "btnContextMenu"
        Me.btnContextMenu.ShowBorder = False
        Me.btnContextMenu.ShowClick = True
        Me.btnContextMenu.ShowHover = True
        Me.btnContextMenu.Size = New System.Drawing.Size(16, 16)
        Me.btnContextMenu.TabIndex = 2
        Me.btnContextMenu.ThemeComponentId = Nothing
        Me.btnContextMenu.ThemeStyle = ""
        '
        'pnlClient
        '
        Me.pnlClient.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.pnlClient.Controls.Add(Me.TabPage1)
        Me.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlClient.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.pnlClient.HotTrack = True
        Me.pnlClient.Location = New System.Drawing.Point(0, 42)
        Me.pnlClient.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlClient.Name = "pnlClient"
        Me.pnlClient.SelectedIndex = 0
        Me.pnlClient.Size = New System.Drawing.Size(348, 310)
        Me.pnlClient.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(340, 282)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DockPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.pnlClient)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "DockPanel"
        Me.Size = New System.Drawing.Size(348, 352)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlSearch.ResumeLayout(False)
        Me.pnlSearch.PerformLayout()
        Me.pnlButtonContainerSearch.ResumeLayout(False)
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlButtonContainerHeader.ResumeLayout(False)
        Me.pnlClient.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As BordersPanel
  Friend WithEvents pnlSearch As BordersPanel
  Friend WithEvents txtSearch As TextBox
  Friend WithEvents pnlButtonContainerSearch As TableLayoutPanel
  Friend WithEvents btnSearch As IconButton
  Friend WithEvents pnlHeader As BordersPanel
  Friend WithEvents lblCaption As Label
  Friend WithEvents pnlButtonContainerHeader As TableLayoutPanel
  Friend WithEvents btnClose As IconButton
  Friend WithEvents btnPinned As IconButton
  Friend WithEvents btnContextMenu As IconButton
  Friend WithEvents pnlClient As DockTabControl
  Friend WithEvents TabPage1 As TabPage
End Class
