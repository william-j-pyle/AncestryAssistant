Imports System.ComponentModel


Public Class JDockHeader
  Inherits BordersPanel

  Private COLOR_APP_BG As Color = Color.White
  Private COLOR_APP_FG As Color = Color.Black

  Private COLOR_APP_ACCENT_A As Color = Color.LimeGreen
  Private COLOR_APP_ACCENT_I As Color = Color.LightYellow

  Private COLOR_PNL_HDR_BG_A As Color = Color.White
  Private COLOR_PNL_HDR_BG_I As Color = Color.Gray

  Private COLOR_PNL_HDR_FG_A As Color = Color.Black
  Private COLOR_PNL_HDR_FG_I As Color = Color.DarkGray

  Private COLOR_PNL_BORDER As Color = Color.Black


  Private Const BAR_HEIGHT = 24

  Private WithEvents lblHeader As Label

  Public Event BorderColorChanged(newColor As Color)
  Public Event ActiveStateChanged(active As Boolean)

  Public Sub New()

    SetStyle(ControlStyles.DoubleBuffer, True)
    lblHeader = New System.Windows.Forms.Label()
    SuspendLayout()
    '
    'Control
    '
    Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Padding = New Padding(1, 3, 1, 1)
    Margin = New Padding(0)
    CornerRadius = New Padding(0)
    BorderWidth = New Padding(1)
    MaximumSize = New Size(0, BAR_HEIGHT)
    MinimumSize = MaximumSize
    Size = New Size(300, BAR_HEIGHT)
    Location = New System.Drawing.Point(0, 0)
    BackColor = COLOR_APP_BG
    BorderColor = COLOR_PNL_BORDER
    IsPanelActive = True
    Dock = System.Windows.Forms.DockStyle.Top
    ForeColor = COLOR_PNL_HDR_FG_A
    Controls.Add(lblHeader)
    With lblHeader
      .Dock = System.Windows.Forms.DockStyle.Left
      .Padding = New Padding(4, 4, 0, 0)
      .AutoSize = True
      .ForeColor = COLOR_PNL_HDR_FG_A
      .BackColor = COLOR_PNL_HDR_BG_A
      .Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      .Size = New Size(0, BAR_HEIGHT)
      .Text = "JDockHeader"
    End With
    ApplyTheme()
    ResumeLayout(False)

  End Sub

  Public Event ThemeChanged()

  Private Sub ApplyTheme() Handles Me.ThemeChanged
    If theme IsNot Nothing Then
      BorderColor = theme.BorderColor(ThemeCategoryEnum.PANEL_HEADER)
      ForeColor = theme.ForeColor(ThemeCategoryEnum.PANEL_HEADER)
      BackColor = theme.BackColor(ThemeCategoryEnum.PANEL_HEADER)
      With lblHeader
        .ForeColor = theme.ForeColor(ThemeCategoryEnum.PANEL_HEADER)
        .BackColor = theme.BackColor(ThemeCategoryEnum.PANEL_HEADER)
        .Font = theme.Font()
      End With
      Invalidate()
    End If
  End Sub

  Private WithEvents theme As JTheme = Nothing
  <Browsable(True), Category("JControl"), Description("Application Theme")>
  Public Property JApplicationTheme As JTheme
    Get
      Return theme
    End Get
    Set(value As JTheme)
      theme = value
      RaiseEvent ThemeChanged()
    End Set
  End Property

  Private Sub JDockHeader_BorderColorChanged(newColor As Color) Handles Me.BorderColorChanged
    BorderColorBottom = newColor
    BorderColorLeft = newColor
    BorderColorRight = newColor
    If IsPanelActive Then
      BorderColorTop = HighlightColor
    Else
      BorderColorTop = newColor
    End If
    If DesignMode Then
      Invalidate()
    End If
  End Sub

  Private Sub JDockHeader_ActiveStateChanged(active As Boolean) Handles Me.ActiveStateChanged
    If active Then
      BorderColorTop = HighlightColor
      BorderWidth = New Padding(1, 3, 1, 1)
    Else
      BorderColorTop = BorderColor
      BorderWidth = New Padding(1, 1, 1, 1)
    End If
    If DesignMode Then
      Invalidate()
    End If
  End Sub

  Private Sub JDockHeader_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged
    lblHeader.ForeColor = ForeColor
    If DesignMode Then
      Invalidate()
    End If
  End Sub

  Private Sub JDockHeader_BackColorChanged(sender As Object, e As EventArgs) Handles Me.BackColorChanged
    lblHeader.BackColor = BackColor
    If DesignMode Then
      Invalidate()
    End If
  End Sub


  Private Sub Control_Click(sender As Object, e As EventArgs) Handles lblHeader.Click, Me.Click
    If Not IsPanelActive Then
      RaiseEvent ActiveStateChanged(True)
    End If
  End Sub

  Private Sub tabProvider_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabProvider.SelectedIndexChanged
    Caption = tabProvider.SelectedTab.Text
  End Sub

  <Browsable(True), Category("JControl"), Description("Docked Search Provider")>
  Private WithEvents searchProvider As JDockSearch = Nothing
  Public Property JDocSearchProvider As JDockSearch
    Get
      Return searchProvider
    End Get
    Set(value As JDockSearch)
      searchProvider = value
      If theme IsNot Nothing And searchProvider IsNot Nothing Then
        If searchProvider.JApplicationTheme Is Nothing Then
          searchProvider.JApplicationTheme = theme
        End If
      End If
    End Set
  End Property

  <Browsable(True), Category("JControl"), Description("Docked Tabbed Container Provider")>
  Private WithEvents tabProvider As JDockTabs = Nothing
  Public Property JDocTabsProvider As JDockTabs
    Get
      Return tabProvider
    End Get
    Set(value As JDockTabs)
      tabProvider = value
      If tabProvider IsNot Nothing Then
        If tabProvider.TabCount > 0 Then
          Caption = tabProvider.SelectedTab.Text
        End If
      End If
    End Set
  End Property

  <Browsable(True), Category("JControl"), Description("Header Caption")>
  Dim _Caption As String = "JDockHeader"
  Public Property Caption As String
    Get
      Return _Caption
    End Get
    Set(value As String)
      _Caption = value
      lblHeader.Text = value
    End Set
  End Property


  <Browsable(True), Category("JControl"), Description("Panel Active")>
  Dim _IsPanelActive As Boolean = True
  Public Property IsPanelActive As Boolean
    Get
      Return _IsPanelActive
    End Get
    Set(value As Boolean)
      _IsPanelActive = value
      RaiseEvent ActiveStateChanged(value)
    End Set
  End Property

  <Browsable(True), Category("JControl"), Description("Is Pannel Pinned")>
  Dim _IsPanelPinned As Boolean = True
  Public Property IsPanelPinned As Boolean
    Get
      Return _IsPanelPinned
    End Get
    Set(value As Boolean)
      _IsPanelPinned = value
      If DesignMode Then
        Invalidate()
      End If

    End Set
  End Property

  <Browsable(True), Category("JControl"), Description("Color of the border around the control")>
  Dim _BorderColor As Color = COLOR_PNL_BORDER
  Public Property BorderColor As Color
    Get
      Return _BorderColor
    End Get
    Set(value As Color)
      _BorderColor = value
      RaiseEvent BorderColorChanged(value)
    End Set
  End Property

  <Browsable(True), Category("JControl"), Description("Color used to highlight active panel")>
  Dim _HighlightColor As Color = COLOR_APP_ACCENT_A
  Public Property HighlightColor As Color
    Get
      Return _HighlightColor
    End Get
    Set(value As Color)
      _HighlightColor = value
    End Set
  End Property

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BorderStyle As BorderStyle = BorderStyle.None

End Class
