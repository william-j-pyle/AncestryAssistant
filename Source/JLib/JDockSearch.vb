Imports System.ComponentModel


Public Class JDockSearch
  Inherits JPanel

  Private Const BAR_HEIGHT = 20

  Private COLOR_APP_BG As Color = Color.FromArgb(31, 31, 31)
  Private COLOR_APP_FG As Color = Color.FromArgb(250, 250, 250)

  Private COLOR_APP_ACCENT_A As Color = Color.FromArgb(113, 96, 232)
  Private COLOR_APP_ACCENT_I As Color = Color.FromArgb(61, 61, 61)

  Private COLOR_PNL_HDR_BG_A As Color = Color.FromArgb(26, 26, 26)
  Private COLOR_PNL_HDR_BG_I As Color = Color.FromArgb(26, 26, 26)

  Private COLOR_PNL_HDR_FG_A As Color = Color.FromArgb(250, 250, 250)
  Private COLOR_PNL_HDR_FG_I As Color = Color.FromArgb(200, 200, 200)

  Private COLOR_PNL_BORDER As Color = Color.FromArgb(61, 61, 61)

  Private COLOR_PNL_SRCH_BG_A As Color = Color.FromArgb(61, 61, 61)
  Private COLOR_PNL_SRCH_BG_I As Color = Color.FromArgb(61, 61, 61)

  Private COLOR_PNL_SRCH_FG_A As Color = Color.FromArgb(200, 200, 200)
  Private COLOR_PNL_SRCH_FG_I As Color = Color.FromArgb(100, 100, 100)


  Private WithEvents txtSearch As TextBox
  Private WithEvents pnlSearchImage As Panel

  Public Sub New()
    SetStyle(ControlStyles.DoubleBuffer, True)
    txtSearch = New System.Windows.Forms.TextBox()
    pnlSearchImage = New System.Windows.Forms.Panel()
    SuspendLayout()
    '
    'Control
    '
    MaximumSize = New Size(0, BAR_HEIGHT)
    MinimumSize = MaximumSize
    Size = New Size(300, BAR_HEIGHT)
    BackColor = COLOR_PNL_SRCH_BG_A
    ForeColor = COLOR_PNL_SRCH_FG_I
    BorderColor = COLOR_PNL_BORDER
    Font = New System.Drawing.Font("Segoe UI Historic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    CornerRadius = New Padding(0)
    Padding = New Padding(4, 4, 1, 0)
    Margin = New Padding(0)
    BorderWidth = New Padding(1, 0, 1, 0)
    Dock = System.Windows.Forms.DockStyle.Top
    Controls.Add(txtSearch)
    Controls.Add(pnlSearchImage)
    '
    'txtSearch
    '
    txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
    txtSearch.Dock = System.Windows.Forms.DockStyle.Fill
    txtSearch.Font = Font
    txtSearch.ForeColor = ForeColor
    txtSearch.Enabled = Enabled
    txtSearch.Location = New System.Drawing.Point(0, 0)
    txtSearch.Text = "Search..."
    '
    'pnlSearchImage
    '
    pnlSearchImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
    pnlSearchImage.Dock = System.Windows.Forms.DockStyle.Right
    pnlSearchImage.Size = New Size(16, 16)

    ApplyTheme()
    ResumeLayout(False)

  End Sub

  Public Event ThemeChanged()

  Private Sub ApplyTheme() Handles Me.ThemeChanged
    If theme IsNot Nothing Then
      BackColor = theme.BackColor(ThemeCategoryEnum.PANEL_SEARCH)
      ForeColor = theme.ForeColor(ThemeCategoryEnum.PANEL_SEARCH)
      BorderColor = theme.BorderColor()
      With txtSearch
        .Font = theme.Font
        .ForeColor = theme.ForeColor(ThemeCategoryEnum.PANEL_SEARCH)
        .BackColor = theme.BackColor(ThemeCategoryEnum.PANEL_SEARCH)
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

  <Browsable(True), Category("JControl"), Description("Color of the border around the control")>
  Dim _BorderColor As Color = COLOR_PNL_BORDER
  Public Shadows Property BorderColor As Color
    Get
      Return MyBase.BorderColor
    End Get
    Set(value As Color)
      _BorderColor = value
      MyBase.BorderColor = value
    End Set
  End Property

  <Browsable(True)>
  Public Overrides Property Text As String
    Get
      Return txtSearch.Text
    End Get
    Set(value As String)
      txtSearch.Text = value
    End Set
  End Property

  Private Sub JDockSearch_BackColorChanged(sender As Object, e As EventArgs) Handles Me.BackColorChanged
    txtSearch.BackColor = BackColor
  End Sub

  Private Sub JDockSearch_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
    txtSearch.Enabled = Enabled
  End Sub

  Private Sub JDockSearch_FontChanged(sender As Object, e As EventArgs) Handles Me.FontChanged
    txtSearch.Font = Font
  End Sub

  Private Sub JDockSearch_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged
    txtSearch.ForeColor = ForeColor
  End Sub

  Private Sub JDockSearch_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus

  End Sub

  Private Sub JDockSearch_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus

  End Sub

  Private Sub JDockSearch_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
    txtSearch.Text = Text
  End Sub


  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BorderStyle As BorderStyle = BorderStyle.None


End Class
