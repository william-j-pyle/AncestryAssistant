Public Class RibbonBar
  Inherits TabControl

#Region "Public Constructors"

  Public Sub New()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SuspendLayout()
    AllowDrop = True
    BackColor = My.Theme.AppBackColor
    Font = My.Theme.AppFont
    Margin = New System.Windows.Forms.Padding(0)
    MaximumSize = New System.Drawing.Size(0, RIBBONHEIGHT + RIBBONTOP + (2 * RIBBONBORDER))
    MinimumSize = New System.Drawing.Size(100, RIBBONHEIGHT + RIBBONTOP + (2 * RIBBONBORDER))
    Name = "JRibbon"
    'Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
    Dock = DockStyle.Top
    ResumeLayout(False)
    TabPages.Clear()
  End Sub

#End Region

#Region "Private Methods"

  Private Sub AddFileTab()
    Dim tab As TabPage
    tab = New TabPage("File") With {
      .Name = "File",
      .BackColor = My.Theme.AppBackColor,
      .ForeColor = My.Theme.AppFontColor,
      .Font = My.Theme.AppFont
    }
    'tab.Controls.Add(rb)
    TabPages.Add(tab)
  End Sub

  Private Sub AddRibbonTab(text As String)
    Dim tab As TabPage
    tab = New TabPage(text) With {
      .Name = text.Replace(" ", ""),
      .BackColor = My.Theme.AppBackColor,
      .ForeColor = My.Theme.AppFontColor,
      .Font = My.Theme.AppFont
    }
    Dim rb As New RibbonBarTab()
    With rb
      .Dock = DockStyle.Fill
      .BackColor = My.Theme.AppBackColor
      .ForeColor = My.Theme.AppFontColor
    End With
    tab.Controls.Add(rb)
    TabPages.Add(tab)
  End Sub

  Private Sub RenderTypeTabTop(sender As Object, e As PaintEventArgs) Handles Me.Paint
    Dim g As Graphics = e.Graphics

    'Pain the background
    Using brush As New SolidBrush(My.Theme.AppBackColor)
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
    Dim stringFormat As New StringFormat With {
      .Alignment = StringAlignment.Center,
      .LineAlignment = StringAlignment.Center
    }

    'Dim PenBorder As Pen = New Pen(My.Theme.TabBorderColor, 1)

    'e.Graphics.DrawRectangle(PenBorder, l, t, r, b)

    'Add the tabs
    For i As Integer = 0 To TabPages.Count - 1
      tabOrigBounds = GetTabRect(i)

      'Erase current tab
      Using brush As New SolidBrush(My.Theme.AppBackColor)
        g.FillRectangle(brush, tabOrigBounds)
      End Using

      ' Set the text and background colors based on selected and unselected states
      'If SelectedIndex = i Then
      textColor = My.Theme.AppFontColor
      tabColor = My.Theme.AppBackColor
      tabBounds = New Rectangle(tabOrigBounds.X, tabOrigBounds.Y + 1, tabOrigBounds.Width, tabOrigBounds.Height - 3)
      'Else
      'tabColor = My.Theme.TabShadowColor
      'tabBounds = New Rectangle(tabOrigBounds.X + 1, tabOrigBounds.Y + 2, tabOrigBounds.Width - 1, tabOrigBounds.Height - 4)
      'If tabOrigBounds.Contains(PointToClient(MousePosition)) Then
      'textColor = My.Theme.TabFontColor
      'Else
      'textColor = My.Theme.ColorToShadow(My.Theme.TabFontColor)
      'End If
      'End If

      ' Fill the new tab
      Using brush As New SolidBrush(My.Theme.AppBackColor)
        g.FillRectangle(brush, tabBounds)
      End Using

      ' Draw the tab text
      Using brush As New SolidBrush(textColor)
        g.DrawString(TabPages(i).Text, Font, brush, tabBounds, stringFormat)
      End Using

      If SelectedIndex = i Then
        g.DrawLine(New Pen(My.Theme.AppHighlightColor, 2), tabBounds.Left + 1, tabBounds.Bottom - 1, tabBounds.Right - 1, tabBounds.Bottom - 1)
      End If

    Next

    'Draw Divider lines
    'tabBounds = GetTabRect(SelectedIndex)
    'Dim tabBarColor As Color
    'Dim ctlBarColor As Color
    'tabBarColor = My.Theme.TabAccentColor
    'ctlBarColor = My.Theme.TabShadowColor
    'e.Graphics.DrawLine(New Pen(tabBarColor, 2), tabBounds.X, tabBounds.Y, tabBounds.Right, tabBounds.Y)
    'e.Graphics.DrawLine(New Pen(ctlBarColor, 2), l, tabBounds.Bottom - 1, r, tabBounds.Bottom - 1)

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

#Region "Fields"

  Private Const RIBBONBORDER As Integer = 8
  Private Const RIBBONHEIGHT As Integer = 100
  Private Const RIBBONTOP As Integer = TABHEIGHT + 1
  Private Const TABHEIGHT As Integer = 20
  Private components As System.ComponentModel.IContainer

#End Region

  'Protected Overrides ReadOnly Property CreateParams As CreateParams
  '  Get
  '    Dim cp As CreateParams = MyBase.CreateParams
  '    cp.Style = cp.Style Or &H2000000 ' WS_CLIPCHILDREN
  '    Return cp
  '  End Get
  'End Property
End Class