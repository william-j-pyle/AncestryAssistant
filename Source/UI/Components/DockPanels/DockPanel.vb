Public Class DockPanel
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

  Private _PanelShowSearch As Boolean = False
  Public Property PanelShowSearch As Boolean Implements IDockPanel.PanelShowSearch
    Get
      Return _PanelShowClose
    End Get
    Set(value As Boolean)
      _PanelShowClose = value
      Invalidate(True)
    End Set
  End Property

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
    End Set
  End Property

  Private _PanelIsPinned As Boolean = True
  Public Property PanelIsPinned As Boolean Implements IDockPanel.PanelIsPinned
    Get
      Return _PanelIsPinned
    End Get
    Set(value As Boolean)
      _PanelIsPinned = value
    End Set
  End Property

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
      Invalidate(0)
    End Set
  End Property

  Public ReadOnly Property PanelItemCount As Integer Implements IDockPanel.PanelItemCount
    Get
      Return tabPages.Count
    End Get
  End Property

  Public ReadOnly Property PanelCaption As String Implements IDockPanel.PanelCaption
    Get
      Return lblCaption.Text
    End Get
  End Property

  Public ReadOnly Property PanelSelectedItem As IDockPanelItem Implements IDockPanel.PanelSelectedItem
    Get
      If pnlClient.TabCount > 0 Then
        If pnlClient.SelectedTab.Controls.Count > 0 Then
          Return CType(pnlClient.SelectedTab.Controls(0), IDockPanelItem)
        End If
      End If
      Return Nothing
    End Get
  End Property

  Public ReadOnly Property PanelSelectedIndex As Integer Implements IDockPanel.PanelSelectedIndex
    Get
      Return pnlClient.SelectedIndex
    End Get
  End Property

  Public Sub SelectItemByIndex(index As Integer) Implements IDockPanel.SelectItemByIndex
    Throw New NotImplementedException()
  End Sub

  Public Sub SelectItemByKey(key As String) Implements IDockPanel.SelectItemByKey
    Throw New NotImplementedException()
  End Sub

  Public Function AddItem(item As IDockPanelItem) As Integer Implements IDockPanel.AddItem
    item.ItemDockStyle = DockStyle.Fill
    pnlClient.TabPages.Add(item.ItemCaption, item.ItemCaption)
    If pnlClient.TabCount = 2 And pnlClient.TabPages(0).Text = "" Then
      pnlClient.TabPages.RemoveAt(0)
    End If
    pnlClient.TabPages(item.ItemCaption).Controls.Add(item)
    lblCaption.Text = pnlClient.SelectedTab.Text
    AdjustClientSize()
  End Function

  Public Function GetItem(key As String) As IDockPanelItem Implements IDockPanel.GetItem
    If pnlClient.TabPages(key) Is Nothing Then Return Nothing
    Dim ctl As Control = pnlClient.TabPages(key).Controls(0)
    Return CType(ctl, IDockPanelItem)
  End Function

  Public Function GetItem(index As Integer) As IDockPanelItem Implements IDockPanel.GetItem
    If pnlClient.TabPages(index) Is Nothing Then Return Nothing
    Dim ctl As Control = pnlClient.TabPages(index).Controls(0)
    Return CType(ctl, IDockPanelItem)
  End Function

  Public Function RemoveItem(key As String) As IDockPanelItem Implements IDockPanel.RemoveItem
    If pnlClient.TabPages(key) Is Nothing Then Return Nothing
    Dim ctl As Control = pnlClient.TabPages(key).Controls(0)
    If pnlClient.TabCount = 1 Then
      pnlClient.TabPages.Add("BLANK", "")
    End If
    pnlClient.TabPages.RemoveByKey(key)
    If pnlClient.SelectedTab.Text.Equals("") Then
      RaiseEvent PanelCloseRequested(Me)
    End If
    lblCaption.Text = pnlClient.SelectedTab.Text
    AdjustClientSize()
    Return CType(ctl, IDockPanelItem)
  End Function

  Public Function RemoveItem(index As Integer) As IDockPanelItem Implements IDockPanel.RemoveItem
    If pnlClient.TabPages(index) Is Nothing Then Return Nothing
    Dim ctl As Control = pnlClient.TabPages(index).Controls(0)
    If pnlClient.TabCount = 1 Then
      pnlClient.TabPages.Add("BLANK", "")
    End If
    pnlClient.TabPages.RemoveAt(index)
    If pnlClient.SelectedTab.Text.Equals("") Then
      RaiseEvent PanelCloseRequested(Me)
    End If
    lblCaption.Text = pnlClient.SelectedTab.Text
    AdjustClientSize()
    Return CType(ctl, IDockPanelItem)
  End Function

  ' Internal Setup Items
  Public Sub New()
    InitializeComponent()
    pnlClient.TabPages(0).Text = ""
    lblCaption.Text = ""
  End Sub

  Public ReadOnly Property tabPages As TabControl.TabPageCollection
    Get
      Return pnlClient.TabPages
    End Get
  End Property


  Private Sub AdjustClientSize()
    If pnlClient.TabPages.Count < 2 Then
      Dim h As Integer = Height - pnlMain.Height + pnlClient.ItemSize.Height
      pnlClient.MinimumSize = New Size(100, h)
      pnlClient.Size = New Size(pnlClient.Width, h)
    Else
      pnlClient.MinimumSize = New Size(0, 0)
    End If
    pnlClient.Dock = DockStyle.Fill
    pnlClient.Refresh()
    Refresh()
  End Sub

  Private Sub DockPanel_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
    AdjustClientSize()
  End Sub

  Private Sub pnlClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pnlClient.SelectedIndexChanged
    lblCaption.Text = pnlClient.SelectedTab.Text
  End Sub

  Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
    RaiseEvent PanelCloseRequested(Me)
  End Sub

  Private Sub btnPinned_Click(sender As Object, e As EventArgs) Handles btnPinned.Click
    PanelIsPinned = Not PanelIsPinned
  End Sub

  Private Sub DockPanel_Load(sender As Object, e As EventArgs) Handles Me.Load
    AdjustClientSize()
  End Sub

End Class
