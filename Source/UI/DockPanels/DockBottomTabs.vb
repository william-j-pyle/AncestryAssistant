Imports System.ComponentModel

Public Class DockBottomTabs
  Inherits TabControl

  Private COLOR_APP_BG As Color = Color.FromArgb(31, 31, 31)
  Private COLOR_APP_FG As Color = Color.FromArgb(31, 31, 31)

  Private COLOR_APP_ACCENT_A As Color = Color.FromArgb(113, 96, 232)
  Private COLOR_APP_ACCENT_I As Color = Color.FromArgb(61, 61, 61)

  Private COLOR_PNL_HDR_BG_A As Color = Color.FromArgb(26, 26, 26)
  Private COLOR_PNL_HDR_BG_I As Color = Color.FromArgb(26, 26, 26)

  Private COLOR_PNL_HDR_FG_A As Color = Color.FromArgb(250, 250, 250)
  Private COLOR_PNL_HDR_FG_I As Color = Color.FromArgb(200, 200, 200)

  Private COLOR_PNL_BORDER As Color = Color.FromArgb(61, 61, 61)

  Public Sub New()
    SetStyle(ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    DrawMode = TabDrawMode.OwnerDrawFixed
    Alignment = System.Windows.Forms.TabAlignment.Bottom
    BorderWidth = New System.Windows.Forms.Padding(1)
    BorderColor = COLOR_PNL_BORDER
    HighlightColor = COLOR_APP_ACCENT_A
    PanelBackColor = COLOR_APP_BG
    Dock = System.Windows.Forms.DockStyle.Fill
    Margin = New System.Windows.Forms.Padding(0)
    Padding = New System.Drawing.Point(2, 2)
    ShowToolTips = True
  End Sub


  <Browsable(True), Category("JControl"), Description("Width in pixels of the border around the control")>
  Dim _BorderWidth As Padding = New Padding(0)
  Public Property BorderWidth As Padding
    Get
      Return _BorderWidth
    End Get
    Set(value As Padding)
      If value.All = -1 Then
        value.Left = Math.Max(value.Left, 0)
        value.Top = Math.Max(value.Top, 0)
        value.Right = Math.Max(value.Right, 0)
        value.Bottom = Math.Max(value.Bottom, 0)
      Else
        value.All = Math.Max(value.All, 0)
      End If
      _BorderWidth = value
      If DesignMode Then
        Invalidate()
      End If
    End Set
  End Property

  <Browsable(True), Category("JControl"), Description("Color of the border around the control")>
  Dim _BorderColor As Color = Color.Transparent
  Public Property BorderColor As Color
    Get
      Return _BorderColor
    End Get
    Set(value As Color)
      _BorderColor = value
      _BorderColorTop = value
      _BorderColorLeft = value
      _BorderColorRight = value
      _BorderColorBottom = value
      If DesignMode Then
        Invalidate()
      End If
    End Set
  End Property

  Dim _BorderColorTop As Color = Color.Transparent
  Public Property BorderColorTop As Color
    Get
      Return _BorderColorTop
    End Get
    Set(value As Color)
      _BorderColorTop = value
      If DesignMode Then
        Invalidate()
      End If
    End Set
  End Property
  Dim _BorderColorLeft As Color = Color.Transparent
  Public Property BorderColorLeft As Color
    Get
      Return _BorderColorLeft
    End Get
    Set(value As Color)
      _BorderColorLeft = value
      If DesignMode Then
        Invalidate()
      End If
    End Set
  End Property
  Dim _BorderColorRight As Color = Color.Transparent
  Public Property BorderColorRight As Color
    Get
      Return _BorderColorRight
    End Get
    Set(value As Color)
      _BorderColorRight = value
      If DesignMode Then
        Invalidate()
      End If
    End Set
  End Property
  Dim _BorderColorBottom As Color = Color.Transparent
  Public Property BorderColorBottom As Color
    Get
      Return _BorderColorBottom
    End Get
    Set(value As Color)
      _BorderColorBottom = value
      If DesignMode Then
        Invalidate()
      End If
    End Set
  End Property

  <Browsable(True), Category("JControl"), Description("Color used to highlight active panel")>
  Dim _HighlightColor As Color = Color.FromArgb(113, 96, 232)
  Public Property HighlightColor As Color
    Get
      Return _HighlightColor
    End Get
    Set(value As Color)
      _HighlightColor = value
      If DesignMode Then
        Invalidate()
      End If
    End Set
  End Property

  <Browsable(True), Category("JControl"), Description("Panel Back Color")>
  Dim _PanelBackColor As Color = Color.FromArgb(26, 26, 26)
  Public Property PanelBackColor As Color
    Get
      Return _PanelBackColor
    End Get
    Set(value As Color)
      _PanelBackColor = value
      If DesignMode Then
        Invalidate()
      End If
    End Set
  End Property

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BorderStyle As BorderStyle = BorderStyle.None

  Private Sub JTabs_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    Dim g As Graphics = e.Graphics

    'Pain the background
    Using brush As SolidBrush = New SolidBrush(PanelBackColor)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using

    Dim w As Integer = 1
    Dim l As Integer = Left
    Dim t As Integer = 0
    Dim r As Integer = Right - 1
    Dim b As Integer = Height
    If TabCount > 0 Then
      b = GetTabRect(0).Top
    End If

    'Add the border
    If BorderWidth.All <> 0 Then
      If BorderWidth.Top > 0 Then
        'TOP BORDER
        e.Graphics.DrawLine(New Pen(BorderColorTop, BorderWidth.Top * w), l, t, r, t)
      End If
      If BorderWidth.Right > 0 Then
        'RIGHT BORDER
        e.Graphics.DrawLine(New Pen(BorderColorRight, BorderWidth.Right * w), r, t, r, b)
      End If
      If BorderWidth.Bottom > 0 And TabPages.Count < 2 Then
        'BOTTOM BORDER
        e.Graphics.DrawLine(New Pen(BorderColorBottom, BorderWidth.Bottom * w), l, b, r, b)
      End If
      If BorderWidth.Left > 0 Then
        'LEFT BORDER
        e.Graphics.DrawLine(New Pen(BorderColorLeft, BorderWidth.Left * w), l, t, l, b)
      End If
    End If

    If TabPages.Count > 1 Then

      Dim PenBorderBottom As Pen = New Pen(BorderColorBottom, BorderWidth.Bottom)

      'Add the tabs
      For i As Integer = 0 To TabPages.Count - 1
        Dim tabPage As TabPage = TabPages(i)
        Dim tabBounds As Rectangle = GetTabRect(i)
        Dim textColor As Color

        ' Fill the background
        Using brush As New SolidBrush(PanelBackColor)
          g.FillRectangle(brush, tabBounds)
        End Using

        ' Set the text and background colors based on selected and unselected states
        If SelectedIndex = i Then
          textColor = Color.White
        Else
          textColor = Color.LightGray
        End If

        ' Draw the tab text
        Using brush As New SolidBrush(textColor)
          Dim stringFormat As New StringFormat()
          stringFormat.Alignment = StringAlignment.Center
          stringFormat.LineAlignment = StringAlignment.Center
          g.DrawString(tabPage.Text, Font, brush, tabBounds, stringFormat)
        End Using

        Const ADJ = 2
        If BorderWidth.Bottom > 0 Then
          If SelectedIndex = i Then
            e.Graphics.DrawLine(PenBorderBottom, tabBounds.Left - ADJ, tabBounds.Top, tabBounds.Left - ADJ, tabBounds.Bottom)
            e.Graphics.DrawLine(PenBorderBottom, tabBounds.Right - ADJ, tabBounds.Top, tabBounds.Right - ADJ, tabBounds.Bottom)
            e.Graphics.DrawLine(PenBorderBottom, tabBounds.Left - ADJ, tabBounds.Bottom, tabBounds.Right - ADJ, tabBounds.Bottom)
          Else
            e.Graphics.DrawLine(PenBorderBottom, tabBounds.Left - ADJ, tabBounds.Top, tabBounds.Right - ADJ, tabBounds.Top)
          End If
          If i = TabPages.Count - 1 Then
            e.Graphics.DrawLine(PenBorderBottom, tabBounds.Right - ADJ, tabBounds.Top, r, tabBounds.Top)
          End If
        End If
      Next
    End If

  End Sub


End Class
