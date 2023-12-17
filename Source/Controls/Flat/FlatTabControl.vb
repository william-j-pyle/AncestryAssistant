Public Class FlatTabControl
  Inherits TabControl

#Region "Fields"

  Private closeTarget As Rectangle

#End Region

#Region "Events"

  Public Event BtnClose_Click(sender As Object, e As EventArgs)

#End Region

#Region "Properties"

  Public Property ShowHasFocus As Boolean = False
  Public Property TabCloseIcon As Image = My.Resources.panel_header_close
  Public Property TabPinnedIcon As Image = My.Resources.panel_header_pin
  Public Property TabShowClose As Boolean = True
  Public Property TabType As DockPanelType = DockPanelType.Tab
  Public Property TabUnPinnedIcon As Image = My.Resources.panel_header_unpinned

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
        RaiseEvent BtnClose_Click(sender, New EventArgs)
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

      'Add the Tabs
      For i As Integer = 0 To TabCount - 1
        Dim TabPage As TabPage = TabPages(i)
        Dim TabBounds As Rectangle = GetTabRect(i)
        Dim textColor As Color

        ' Fill the background
        Using brush As New SolidBrush(My.Theme.TabBackColor)
          g.FillRectangle(brush, TabBounds)
        End Using

        ' Set the text and background colors based on selected and unselected states
        If SelectedIndex = i Then
          textColor = My.Theme.TabActiveFontColor
        Else
          textColor = My.Theme.TabFontColor
        End If

        ' Draw the Tab text
        Using brush As New SolidBrush(textColor)
          Dim sf As New StringFormat With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Center
          }
          g.DrawString(TabPage.Text, Font, brush, TabBounds, sf)
        End Using

        ' Draw the individual Tabs
        Const ADJ As Integer = 2
        If SelectedIndex = i Then
          e.Graphics.DrawLine(borderPen, TabBounds.Left - ADJ, TabBounds.Top, TabBounds.Left - ADJ, TabBounds.Bottom)
          e.Graphics.DrawLine(borderPen, TabBounds.Right - ADJ, TabBounds.Top, TabBounds.Right - ADJ, TabBounds.Bottom)
          e.Graphics.DrawLine(borderPen, TabBounds.Left - ADJ, TabBounds.Bottom, TabBounds.Right - ADJ, TabBounds.Bottom)
        Else
          e.Graphics.DrawLine(borderPen, TabBounds.Left - ADJ, TabBounds.Top, TabBounds.Right - ADJ, TabBounds.Top)
        End If
        If i = TabCount - 1 Then
          e.Graphics.DrawLine(borderPen, TabBounds.Right - ADJ, TabBounds.Top, r, TabBounds.Top)
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

    Using brush As New SolidBrush(My.Theme.TabBorderColor)
      e.Graphics.FillRectangle(brush, New Rectangle(Left, t, Right - 1, Height - t - 1))
    End Using

    Dim r As Integer = Right - 1
    Dim b As Integer = Height - t - 1
    Dim closeBtn As Rectangle
    Dim TabOrigBounds As Rectangle
    Dim TabBounds As Rectangle
    Dim textColor As Color
    Dim TabColor As Color
    Dim stringFormat As New StringFormat()
    If TabShowClose Then
      stringFormat.Alignment = StringAlignment.Near
    Else
      stringFormat.Alignment = StringAlignment.Center
    End If
    stringFormat.LineAlignment = StringAlignment.Center

    Dim PenBorder As New Pen(My.Theme.TabBorderColor, 1)

    e.Graphics.DrawRectangle(PenBorder, l, t, r, b)

    'Add the Tabs
    For i As Integer = 0 To TabPages.Count - 1
      TabOrigBounds = GetTabRect(i)

      'Erase current Tab
      Using brush As New SolidBrush(My.Theme.TabBackColor)
        g.FillRectangle(brush, TabOrigBounds)
      End Using

      ' Set the text and background colors based on selected and unselected states
      If SelectedIndex = i Then
        textColor = My.Theme.TabFontColor
        TabColor = My.Theme.TabBorderColor
        TabBounds = New Rectangle(TabOrigBounds.X, TabOrigBounds.Y + 1, TabOrigBounds.Width, TabOrigBounds.Height - 3)
      Else
        TabColor = My.Theme.TabShadowColor
        TabBounds = New Rectangle(TabOrigBounds.X + 1, TabOrigBounds.Y + 2, TabOrigBounds.Width - 1, TabOrigBounds.Height - 4)
        If TabOrigBounds.Contains(PointToClient(MousePosition)) Then
          textColor = My.Theme.TabFontColor
        Else
          textColor = My.Theme.ColorToShadow(My.Theme.TabFontColor)
        End If
      End If

      ' Fill the new Tab
      Using brush As New SolidBrush(TabColor)
        g.FillRectangle(brush, TabBounds)
      End Using

      ' Draw the Tab text
      Using brush As New SolidBrush(textColor)
        g.DrawString(TabPages(i).Text, Font, brush, TabBounds, stringFormat)
      End Using

      If TabShowClose Then
        closeBtn = New Rectangle(TabOrigBounds.X + TabOrigBounds.Width - 21, TabOrigBounds.Y, 20, 20)
        If closeBtn.Contains(PointToClient(MousePosition)) Then
          closeTarget = closeBtn
        End If
        If SelectedIndex = i Then
          'Over Close
          Using brush As New SolidBrush(textColor)
            g.DrawString(ChrW(FontSegoeFluentIconsEnum.CalculatorMultiply), My.Theme.AppIconsFont, brush, closeBtn, stringFormat)
          End Using
        Else
          If TabOrigBounds.Contains(PointToClient(MousePosition)) Then
            Using brush As New SolidBrush(textColor)
              g.DrawString(ChrW(FontSegoeFluentIconsEnum.CalculatorMultiply), My.Theme.AppIconsFont, brush, closeBtn, stringFormat)
            End Using
          End If
        End If
      End If
    Next

    'Draw Divider lines
    TabBounds = GetTabRect(SelectedIndex)
    Dim TabBarColor As Color
    Dim ctlBarColor As Color
    If ShowHasFocus Then
      TabBarColor = My.Theme.TabHighlightColor
      ctlBarColor = My.Theme.TabHighlightColor
    Else
      TabBarColor = My.Theme.TabAccentColor
      ctlBarColor = My.Theme.TabShadowColor
    End If
    e.Graphics.DrawLine(New Pen(TabBarColor, 2), TabBounds.X, TabBounds.Y, TabBounds.Right, TabBounds.Y)
    e.Graphics.DrawLine(New Pen(ctlBarColor, 2), l, TabBounds.Bottom - 1, r, TabBounds.Bottom - 1)

  End Sub

#End Region

End Class