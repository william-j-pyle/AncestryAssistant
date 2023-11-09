Imports System.ComponentModel

Public Class DockTopTabs
  Inherits TabControl
  Implements IDockPanel

  Public Event PanelFocusChanged(sender As IDockPanel, hasFocus As Boolean) Implements IDockPanel.PanelFocusChanged
  Public Event PanelCloseRequested(sender As IDockPanel) Implements IDockPanel.PanelCloseRequested

  Private _PanelShowClose As Boolean = False
  Public Property PanelShowClose As Boolean Implements IDockPanel.PanelShowClose
    Get
      Return _PanelShowClose
    End Get
    Set(value As Boolean)
      _PanelShowClose = value
      Invalidate(True)
    End Set
  End Property

  Public Property PanelShowSearch As Boolean = False Implements IDockPanel.PanelShowSearch

  Private _PanelShowPinned As Boolean = False
  Public Property PanelShowPinned As Boolean Implements IDockPanel.PanelShowPinned
    Get
      Return _PanelShowPinned
    End Get
    Set(value As Boolean)
      _PanelShowPinned = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelShowContextMenu As Boolean = False
  Public Property PanelShowContextMenu As Boolean Implements IDockPanel.PanelShowContextMenu
    Get
      Return _PanelShowContextMenu
    End Get
    Set(value As Boolean)
      _PanelShowContextMenu = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelHasFocus As Boolean = False
  Public Property PanelHasFocus As Boolean Implements IDockPanel.PanelHasFocus
    Get
      Return _PanelHasFocus
    End Get
    Set(value As Boolean)
      _PanelHasFocus = value
      RaiseEvent PanelFocusChanged(Me, value)
      Invalidate(True)
    End Set
  End Property

  Public Property PanelIsPinned As Boolean = True Implements IDockPanel.PanelIsPinned

  Private _PanelBackColor As Color = Color.Black
  Public Property PanelBackColor As Color Implements IDockPanel.PanelBackColor
    Get
      Return _PanelBackColor
    End Get
    Set(value As Color)
      _PanelBackColor = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelBorderColor As Color = Color.DarkGray
  Public Property PanelBorderColor As Color Implements IDockPanel.PanelBorderColor
    Get
      Return _PanelBorderColor
    End Get
    Set(value As Color)
      _PanelBorderColor = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelFontColor As Color = Color.WhiteSmoke
  Public Property PanelFontColor As Color Implements IDockPanel.PanelFontColor
    Get
      Return _PanelFontColor
    End Get
    Set(value As Color)
      _PanelFontColor = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelHighlightColor As Color = Color.GreenYellow
  Public Property PanelHighlightColor As Color Implements IDockPanel.PanelHighlightColor
    Get
      Return _PanelHighlightColor
    End Get
    Set(value As Color)
      _PanelHighlightColor = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelShadowColor As Color = ColorToShadow(_PanelBorderColor)
  Public Property PanelShadowColor As Color Implements IDockPanel.PanelShadowColor
    Get
      Return _PanelShadowColor
    End Get
    Set(value As Color)
      _PanelShadowColor = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelAccentColor As Color = ColorToAccent(_PanelBorderColor)
  Public Property PanelAccentColor As Color Implements IDockPanel.PanelAccentColor
    Get
      Return _PanelAccentColor
    End Get
    Set(value As Color)
      _PanelAccentColor = value
      Invalidate(True)
    End Set
  End Property

  Public ReadOnly Property PanelItemCount As Integer Implements IDockPanel.PanelItemCount
    Get
      Return TabPages.Count
    End Get
  End Property

  Public ReadOnly Property PanelCaption As String Implements IDockPanel.PanelCaption
    Get
      Return SelectedTab.Text
    End Get
  End Property

  Public ReadOnly Property PanelSelectedItem As IDockPanelItem Implements IDockPanel.PanelSelectedItem
    Get
      If TabCount > 0 Then
        If SelectedTab.Controls.Count > 0 Then
          Return CType(SelectedTab.Controls(0), IDockPanelItem)
        End If
      End If
      Return Nothing
    End Get
  End Property

  Public ReadOnly Property PanelSelectedIndex As Integer Implements IDockPanel.PanelSelectedIndex
    Get
      Return SelectedIndex
    End Get
  End Property

  Public Sub SelectItemByIndex(index As Integer) Implements IDockPanel.SelectItemByIndex
    TabPages.Item(index).Select()
  End Sub

  Public Sub SelectItemByKey(key As String) Implements IDockPanel.SelectItemByKey
    TabPages.Item(key).Select()
  End Sub

  Public Function AddItem(item As IDockPanelItem) As Integer Implements IDockPanel.AddItem
    item.ItemDockStyle = DockStyle.Fill
    TabPages.Add(item.ItemCaption, item.ItemCaption)
    If TabCount = 2 And TabPages(0).Text = "" Then
      TabPages.RemoveAt(0)
    End If
    With TabPages(item.ItemCaption)
      .Controls.Add(CType(item, Control))
      .Select()
    End With
    HideIfEmpty()
  End Function

  Public Function GetItem(key As String) As IDockPanelItem Implements IDockPanel.GetItem
    If TabPages(key) Is Nothing Then Return Nothing
    Dim ctl As Control = TabPages(key).Controls(0)
    Return CType(ctl, IDockPanelItem)
  End Function

  Public Function GetItem(index As Integer) As IDockPanelItem Implements IDockPanel.GetItem
    If TabPages(index) Is Nothing Then Return Nothing
    Dim ctl As Control = TabPages(index).Controls(0)
    Return CType(ctl, IDockPanelItem)
  End Function

  Public Function RemoveItem(key As String) As IDockPanelItem Implements IDockPanel.RemoveItem
    If TabPages(key) Is Nothing Then Return Nothing
    Dim ctl As Control = TabPages(key).Controls(0)
    If TabCount = 1 Then
      TabPages.Add("BLANK", "")
      SelectItemByKey("BLANK")
    End If
    TabPages.RemoveByKey(key)
    HideIfEmpty()
    Return CType(ctl, IDockPanelItem)
  End Function

  Public Function RemoveItem(index As Integer) As IDockPanelItem Implements IDockPanel.RemoveItem
    If TabPages(index) Is Nothing Then Return Nothing
    Dim ctl As Control = TabPages(index).Controls(0)
    If TabCount = 1 Then
      TabPages.Add("BLANK", "")
    End If
    TabPages.RemoveAt(index)
    HideIfEmpty()
    Return CType(ctl, IDockPanelItem)
  End Function


  Public Sub New()
    SetStyle(ControlStyles.DoubleBuffer, True)
    SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    SetStyle(ControlStyles.ResizeRedraw, True)
    SetStyle(ControlStyles.UserPaint, True)
    UpdateStyles()
    DrawMode = TabDrawMode.OwnerDrawFixed
    'ItemSize = New Size(ItemSize.Width + 100, ItemSize.Height)
    Alignment = System.Windows.Forms.TabAlignment.Top
    HotTrack = True
    Dock = System.Windows.Forms.DockStyle.Fill
    Margin = New System.Windows.Forms.Padding(0)
    Padding = New System.Drawing.Point(20, 2)
    ShowToolTips = True
    HideIfEmpty()
  End Sub

  Private Sub HideIfEmpty()
    If TabCount = 0 Then
      Visible = False
    Else
      If TabCount = 1 And TabPages.Item(0).Text.Equals("") Then
        Visible = False
      Else
        Visible = True
      End If
    End If
  End Sub

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BorderStyle As BorderStyle = BorderStyle.None

  Private Sub JTabs_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    If TabCount = 0 Then Exit Sub
    Dim g As Graphics = e.Graphics

    'Pain the background
    Using brush As SolidBrush = New SolidBrush(PanelBackColor)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using

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
    stringFormat.Alignment = StringAlignment.Near
    stringFormat.LineAlignment = StringAlignment.Center

    Dim PenBorder As Pen = New Pen(PanelBorderColor, 1)

    e.Graphics.DrawRectangle(PenBorder, l, t, r, b)

    'Add the tabs
    For i As Integer = 0 To TabPages.Count - 1
      tabOrigBounds = GetTabRect(i)

      'Erase current tab
      Using brush As New SolidBrush(PanelBackColor)
        g.FillRectangle(brush, tabOrigBounds)
      End Using

      ' Set the text and background colors based on selected and unselected states
      If SelectedIndex = i Then
        textColor = PanelFontColor
        tabColor = PanelBorderColor
        tabBounds = New Rectangle(tabOrigBounds.X, tabOrigBounds.Y + 1, tabOrigBounds.Width, tabOrigBounds.Height - 3)
      Else
        tabColor = PanelShadowColor
        tabBounds = New Rectangle(tabOrigBounds.X + 1, tabOrigBounds.Y + 2, tabOrigBounds.Width - 1, tabOrigBounds.Height - 4)
        If tabOrigBounds.Contains(PointToClient(MousePosition)) Then
          textColor = PanelFontColor
        Else
          textColor = ColorToShadow(PanelFontColor)
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
    If PanelHasFocus Then
      tabBarColor = PanelHighlightColor
      ctlBarColor = PanelHighlightColor
    Else
      tabBarColor = PanelAccentColor
      ctlBarColor = PanelShadowColor
    End If
    e.Graphics.DrawLine(New Pen(tabBarColor, 2), tabBounds.X, tabBounds.Y, tabBounds.Right, tabBounds.Y)
    e.Graphics.DrawLine(New Pen(ctlBarColor, 2), l, tabBounds.Bottom - 1, r, tabBounds.Bottom - 1)

  End Sub

  Private Sub DockTopTabs_Selected(sender As Object, e As TabControlEventArgs) Handles Me.Selected
    PanelHasFocus = True
  End Sub

  Private Sub DockTopTabs_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
    PanelHasFocus = False
  End Sub

  Private Sub TabsGotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
    PanelHasFocus = True
  End Sub

  Private Sub DockTopTabs_Deselected(sender As Object, e As TabControlEventArgs) Handles Me.Deselected
    PanelHasFocus = False
  End Sub

  Private Sub TabsControlAdded(sender As Object, e As ControlEventArgs) Handles Me.ControlAdded
    AddHandler e.Control.ControlAdded, AddressOf TabsControlAdded
    AddHandler e.Control.GotFocus, AddressOf TabsGotFocus
  End Sub

End Class
