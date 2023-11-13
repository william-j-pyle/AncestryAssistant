Public Class DockTabControl
  Inherits TabControl

  Private theme As UITheme = UITheme.GetInstance

  Public Sub New()
    SetStyle(ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    DrawMode = TabDrawMode.OwnerDrawFixed
    Dock = System.Windows.Forms.DockStyle.Fill
    Margin = New System.Windows.Forms.Padding(0)
    ShowToolTips = True
  End Sub


#Region "Properties"

  Public Property TabType As DockPanelType = DockPanelType.Tab
  Public Property TabShowClose As Boolean = True
  Public Property ShowHasFocus As Boolean = False

#End Region


#Region "Tab Client Renders"

  Private Sub RenderTabClient(sender As Object, e As PaintEventArgs) Handles Me.Paint
    Select Case TabType
      Case DockPanelType.Tab
        'Debug.Print("Render Tab")
        RenderTypeTabTop(sender, e)
      Case DockPanelType.Panel
        'Debug.Print("Render Panel")
        RenderTypeTabBottom(sender, e)
    End Select
  End Sub

  Private Sub RenderTypeTabBottom(sender As Object, e As PaintEventArgs)
    Dim g As Graphics = e.Graphics

    Using brush As SolidBrush = New SolidBrush(theme.TabBackColor)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using
    If TabCount = 0 Then Exit Sub

    Dim l As Integer = Left
    Dim t As Integer = 0
    Dim r As Integer = Right - 1
    Dim b As Integer = GetTabRect(0).Top

    'Debug.Print("l={0}, t={1}, r={2}, b={3}, height={4}, tabrec.top={5}, tabrec.height={6}, ca.top={7}, ca.height={8}", l, t, r, b, Height, GetTabRect(0).Top, GetTabRect(0).Height, ClientRectangle.Top, ClientRectangle.Height)

    'If TabCount > 1 Then
    'b = GetTabRect(0).Top
    'End If

    Dim borderPen As Pen = New Pen(theme.TabBorderColor, 1)

    e.Graphics.DrawLine(borderPen, l, t, r, t)
    e.Graphics.DrawLine(borderPen, r, t, r, b)
    'If TabCount < 2 Then
    e.Graphics.DrawLine(borderPen, l, b, r, b)
    'End If
    e.Graphics.DrawLine(borderPen, l, t, l, b)

    If TabCount > 1 Then

      'Add the tabs
      For i As Integer = 0 To TabCount - 1
        Dim tabPage As TabPage = TabPages(i)
        Dim tabBounds As Rectangle = GetTabRect(i)
        Dim textColor As Color

        ' Fill the background
        Using brush As New SolidBrush(theme.TabBackColor)
          g.FillRectangle(brush, tabBounds)
        End Using

        ' Set the text and background colors based on selected and unselected states
        If SelectedIndex = i Then
          textColor = theme.TabActiveFontColor
        Else
          textColor = theme.TabFontColor
        End If

        ' Draw the tab text
        Using brush As New SolidBrush(textColor)
          Dim sf As StringFormat = New StringFormat()
          sf.Alignment = StringAlignment.Center
          sf.LineAlignment = StringAlignment.Center
          g.DrawString(tabPage.Text, Font, brush, tabBounds, sf)
        End Using

        ' Draw the individual tabs
        Const ADJ As Integer = 2
        If SelectedIndex = i Then
          e.Graphics.DrawLine(borderPen, tabBounds.Left - ADJ, tabBounds.Top, tabBounds.Left - ADJ, tabBounds.Bottom)
          e.Graphics.DrawLine(borderPen, tabBounds.Right - ADJ, tabBounds.Top, tabBounds.Right - ADJ, tabBounds.Bottom)
          e.Graphics.DrawLine(borderPen, tabBounds.Left - ADJ, tabBounds.Bottom, tabBounds.Right - ADJ, tabBounds.Bottom)
        Else
          e.Graphics.DrawLine(borderPen, tabBounds.Left - ADJ, tabBounds.Top, tabBounds.Right - ADJ, tabBounds.Top)
        End If
        If i = TabCount - 1 Then
          e.Graphics.DrawLine(borderPen, tabBounds.Right - ADJ, tabBounds.Top, r, tabBounds.Top)
        End If
      Next
    End If

  End Sub

  Private Sub RenderTypeTabTop(sender As Object, e As PaintEventArgs)
    Dim g As Graphics = e.Graphics

    'Pain the background
    Using brush As SolidBrush = New SolidBrush(theme.TabBackColor)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using
    If TabCount = 0 Then Exit Sub

    Dim w As Integer = 1
    Dim l As Integer = Left
    Dim t As Integer = GetTabRect(0).Height + 2

    Dim r As Integer = Right - 1
    Dim b As Integer = Height - t - 1
    Dim tabOrigBounds As Rectangle
    Dim tabBounds As Rectangle
    Dim textColor As Color
    Dim tabColor As Color
    Dim stringFormat As New StringFormat()
    If TabShowClose Then
      stringFormat.Alignment = StringAlignment.Near
    Else
      stringFormat.Alignment = StringAlignment.Center
    End If
    stringFormat.LineAlignment = StringAlignment.Center

    Dim PenBorder As Pen = New Pen(theme.TabBorderColor, 1)

    e.Graphics.DrawRectangle(PenBorder, l, t, r, b)

    'Add the tabs
    For i As Integer = 0 To TabPages.Count - 1
      tabOrigBounds = GetTabRect(i)

      'Erase current tab
      Using brush As New SolidBrush(theme.TabBackColor)
        g.FillRectangle(brush, tabOrigBounds)
      End Using

      ' Set the text and background colors based on selected and unselected states
      If SelectedIndex = i Then
        textColor = theme.TabFontColor
        tabColor = theme.TabBorderColor
        tabBounds = New Rectangle(tabOrigBounds.X, tabOrigBounds.Y + 1, tabOrigBounds.Width, tabOrigBounds.Height - 3)
      Else
        tabColor = theme.TabShadowColor
        tabBounds = New Rectangle(tabOrigBounds.X + 1, tabOrigBounds.Y + 2, tabOrigBounds.Width - 1, tabOrigBounds.Height - 4)
        If tabOrigBounds.Contains(PointToClient(MousePosition)) Then
          textColor = theme.TabFontColor
        Else
          textColor = theme.ColorToShadow(theme.TabFontColor)
        End If
      End If

      ' Fill the new tab
      Using brush As New SolidBrush(tabColor)
        g.FillRectangle(brush, tabBounds)
      End Using

      ' Draw the tab text
      Using brush As New SolidBrush(textColor)
        g.DrawString(TabPages(i).Text, Font, brush, tabBounds, stringFormat)
      End Using

    Next

    'Draw Divider lines
    tabBounds = GetTabRect(SelectedIndex)
    Dim tabBarColor As Color
    Dim ctlBarColor As Color
    If ShowHasFocus Then
      tabBarColor = theme.TabHighlightColor
      ctlBarColor = theme.TabHighlightColor
    Else
      tabBarColor = theme.TabAccentColor
      ctlBarColor = theme.TabShadowColor
    End If
    e.Graphics.DrawLine(New Pen(tabBarColor, 2), tabBounds.X, tabBounds.Y, tabBounds.Right, tabBounds.Y)
    e.Graphics.DrawLine(New Pen(ctlBarColor, 2), l, tabBounds.Bottom - 1, r, tabBounds.Bottom - 1)

  End Sub

#End Region

End Class
