Public Class FlatTabControl
  Inherits TabControl

#Region "Fields"

  Private closeTarget As Rectangle

#End Region

#Region "Events"

  Public Event btnClose_Click(sender As Object, e As EventArgs)

#End Region

#Region "Properties"

  Public Property ShowHasFocus As Boolean = False
  Public Property TabShowClose As Boolean = True
  Public Property TabType As DockPanelType = DockPanelType.Tab

#End Region

#Region "Public Constructors"

  Public Sub New()
    SetStyle(ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    DrawMode = TabDrawMode.OwnerDrawFixed
    Dock = System.Windows.Forms.DockStyle.Fill
    Margin = New System.Windows.Forms.Padding(0)
    closeTarget = New Rectangle
    ShowToolTips = True
  End Sub

#End Region

#Region "Private Methods"

  Private Sub DockTabControl_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
    If closeTarget.IsEmpty Then Exit Sub
    If e.Button = MouseButtons.Left Then
      If closeTarget.Contains(PointToClient(MousePosition)) Then
        RaiseEvent btnClose_Click(sender, New EventArgs)
      End If
    End If
  End Sub

  Private Sub RenderTabClient(sender As Object, e As PaintEventArgs) Handles Me.Paint
    Select Case TabType
      Case DockPanelType.Tab
        closeTarget = New Rectangle
        RenderTypeTabTop(sender, e)
      Case DockPanelType.Panel
        RenderTypeTabBottom(sender, e)
    End Select
  End Sub

  Private Sub RenderTypeTabBottom(sender As Object, e As PaintEventArgs)
    Dim g As Graphics = e.Graphics

    Using brush As New SolidBrush(My.Theme.TabBackColor)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using
    If TabCount = 0 Then Exit Sub

    Dim l As Integer = Left
    Dim t As Integer = 0
    Dim r As Integer = Right - 1
    Dim b As Integer = GetTabRect(0).Top

    Dim borderPen As New Pen(My.Theme.TabBorderColor, 1)

    e.Graphics.DrawLine(borderPen, l, t, r, t)
    e.Graphics.DrawLine(borderPen, r, t, r, b)
    e.Graphics.DrawLine(borderPen, l, b, r, b)
    e.Graphics.DrawLine(borderPen, l, t, l, b)

    If TabCount > 1 Then

      'Add the tabs
      For i As Integer = 0 To TabCount - 1
        Dim tabPage As TabPage = TabPages(i)
        Dim tabBounds As Rectangle = GetTabRect(i)
        Dim textColor As Color

        ' Fill the background
        Using brush As New SolidBrush(My.Theme.TabBackColor)
          g.FillRectangle(brush, tabBounds)
        End Using

        ' Set the text and background colors based on selected and unselected states
        If SelectedIndex = i Then
          textColor = My.Theme.TabActiveFontColor
        Else
          textColor = My.Theme.TabFontColor
        End If

        ' Draw the tab text
        Using brush As New SolidBrush(textColor)
          Dim sf As New StringFormat With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Center
          }
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
    Using brush As New SolidBrush(My.Theme.TabBackColor)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using
    If TabCount = 0 Then Exit Sub

    Dim w As Integer = 1
    Dim l As Integer = Left
    Dim t As Integer = GetTabRect(0).Height + 2

    Dim r As Integer = Right - 1
    Dim b As Integer = Height - t - 1
    Dim closeBtn As Rectangle
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

    Dim PenBorder As New Pen(My.Theme.TabBorderColor, 1)

    e.Graphics.DrawRectangle(PenBorder, l, t, r, b)

    'Add the tabs
    For i As Integer = 0 To TabPages.Count - 1
      tabOrigBounds = GetTabRect(i)

      'Erase current tab
      Using brush As New SolidBrush(My.Theme.TabBackColor)
        g.FillRectangle(brush, tabOrigBounds)
      End Using

      ' Set the text and background colors based on selected and unselected states
      If SelectedIndex = i Then
        textColor = My.Theme.TabFontColor
        tabColor = My.Theme.TabBorderColor
        tabBounds = New Rectangle(tabOrigBounds.X, tabOrigBounds.Y + 1, tabOrigBounds.Width, tabOrigBounds.Height - 3)
      Else
        tabColor = My.Theme.TabShadowColor
        tabBounds = New Rectangle(tabOrigBounds.X + 1, tabOrigBounds.Y + 2, tabOrigBounds.Width - 1, tabOrigBounds.Height - 4)
        If tabOrigBounds.Contains(PointToClient(MousePosition)) Then
          textColor = My.Theme.TabFontColor
        Else
          textColor = My.Theme.ColorToShadow(My.Theme.TabFontColor)
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

      If TabShowClose Then
        closeBtn = New Rectangle(tabOrigBounds.X + tabOrigBounds.Width - 21, tabOrigBounds.Y, 20, 20)
        If closeBtn.Contains(PointToClient(MousePosition)) Then
          closeTarget = closeBtn
        End If
        If SelectedIndex = i Then
          'Over Close
          Using brush As New SolidBrush(textColor)
            g.DrawString(ChrW(FontSegoeFluentIconsEnum.CalculatorMultiply), My.Theme.AppIconsFont, brush, closeBtn, stringFormat)
          End Using
        Else
          If tabOrigBounds.Contains(PointToClient(MousePosition)) Then
            Using brush As New SolidBrush(textColor)
              g.DrawString(ChrW(FontSegoeFluentIconsEnum.CalculatorMultiply), My.Theme.AppIconsFont, brush, closeBtn, stringFormat)
            End Using
          End If
        End If
      End If
    Next

    'Draw Divider lines
    tabBounds = GetTabRect(SelectedIndex)
    Dim tabBarColor As Color
    Dim ctlBarColor As Color
    If ShowHasFocus Then
      tabBarColor = My.Theme.TabHighlightColor
      ctlBarColor = My.Theme.TabHighlightColor
    Else
      tabBarColor = My.Theme.TabAccentColor
      ctlBarColor = My.Theme.TabShadowColor
    End If
    e.Graphics.DrawLine(New Pen(tabBarColor, 2), tabBounds.X, tabBounds.Y, tabBounds.Right, tabBounds.Y)
    e.Graphics.DrawLine(New Pen(ctlBarColor, 2), l, tabBounds.Bottom - 1, r, tabBounds.Bottom - 1)

  End Sub

#End Region

End Class