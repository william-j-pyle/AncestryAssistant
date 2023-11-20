Imports System.ComponentModel

Public Class RibbonBar
  Inherits TabControl

#Region "Fields"

  Private Const RIBBONBORDER As Integer = 8
  Private Const RIBBONHEIGHT As Integer = 100
  Private Const RIBBONTOP As Integer = TABHEIGHT + 1
  Private Const TABHEIGHT As Integer = 20

  Private ByKey As New Dictionary(Of String, RibbonBarTab)
  Private components As System.ComponentModel.IContainer

#End Region

#Region "Properties"

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Private Shadows ReadOnly Property TabPages As TabPageCollection
    Get
      Return MyBase.TabPages
    End Get
  End Property
  Public Property HighlightColor As Color = My.Theme.AppHighlightColor
  Public Property RibbonAccentColor As Color = My.Theme.RibbonBarBorderColor
  Public Property RibbonBackColor As Color = My.Theme.RibbonBarBackColor
  Public Property RibbonForeColor As Color = My.Theme.RibbonBarFontColor
  Public Property RibbonShadowColor As Color = My.Theme.RibbonBarBorderColor

#End Region

#Region "Public Constructors"

  Public Sub New()
    MyBase.New
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    UpdateStyles()
    SuspendLayout()
    AllowDrop = False
    DrawMode = TabDrawMode.OwnerDrawFixed
    BackColor = My.Theme.AppBackColor
    Font = My.Theme.AppFont
    Margin = New System.Windows.Forms.Padding(0)
    MaximumSize = New System.Drawing.Size(0, RIBBONHEIGHT + RIBBONTOP + (2 * RIBBONBORDER))
    MinimumSize = New System.Drawing.Size(100, RIBBONHEIGHT + RIBBONTOP + (2 * RIBBONBORDER))
    Name = "JRibbon"
    'Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
    Dock = DockStyle.Top
    TabPages.Clear()
    AddFileTab()
    ResumeLayout(False)
    PerformLayout()
  End Sub

#End Region

#Region "Private Methods"

  Private Sub AddFileTab()
    Dim tab As TabPage
    tab = New TabPage("File") With {
      .Name = "file",
      .BackColor = My.Theme.AppBackColor,
      .ForeColor = My.Theme.AppFontColor,
      .Font = My.Theme.AppFont
    }
    'tab.Controls.Add(rb)
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

  Private Function ToKey(text As String) As String
    Return text.ToLower.Trim.Replace(" ", "")
  End Function

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

  Public Function AddGroup(RibbonKey As String, GroupText As String, Optional Key As String = "") As RibbonGroup
    Dim rb As RibbonBarTab = Nothing
    If Not ByKey.TryGetValue(ToKey(RibbonKey), rb) Then Return Nothing
    Dim rg As New RibbonGroup(GroupText) With {
      .BackColor = rb.BackColor,
      .ForeColor = rb.ForeColor
    }
    rb.Controls.Add(rg)
    Return rg
  End Function

  Public Function AddRibbonTab(TabText As String, Optional Key As String = "") As TabPage
    If Key.Equals("") Then Key = ToKey(TabText)
    Dim Tab As New TabPage(TabText) With {
      .Name = Key,
      .BackColor = My.Theme.AppBackColor,
      .ForeColor = My.Theme.AppFontColor,
      .Font = My.Theme.AppFont
    }
    Dim rb As New RibbonBarTab() With {
      .Dock = DockStyle.Fill,
      .BackColor = My.Theme.AppBackColor,
      .ForeColor = My.Theme.AppFontColor
    }
    Tab.Controls.Add(rb)
    Controls.Add(Tab)
    ByKey.Add(Key, rb)
    Return Tab
  End Function

#End Region

  'Protected Overrides ReadOnly Property CreateParams As CreateParams
  '  Get
  '    Dim cp As CreateParams = MyBase.CreateParams
  '    cp.Style = cp.Style Or &H2000000 ' WS_CLIPCHILDREN
  '    Return cp
  '  End Get
  'End Property
End Class