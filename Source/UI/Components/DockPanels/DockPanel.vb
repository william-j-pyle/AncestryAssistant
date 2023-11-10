Public Class DockPanel

  Public Event PanelFocusChanged(sender As DockPanel, hasFocus As Boolean)
  Public Event PanelCloseRequested(sender As DockPanel)

  Public Event PanelTypeChanged(sender As DockPanel, newPanelType As DockPanelType)
  Public Event PanelLocationChanged(sender As DockPanel, newPanelLocation As DockPanelLocation)


#Region "Properties"

  Public ReadOnly Property tabPages As TabControl.TabPageCollection
    Get
      Return pnlClient.TabPages
    End Get
  End Property

  Private _PanelLocation As DockPanelLocation = DockPanelLocation.Floating
  Public Property PanelLocation As DockPanelLocation
    Get
      Return _PanelLocation
    End Get
    Set(value As DockPanelLocation)
      If _PanelLocation <> value Then
        _PanelLocation = value
        RaiseEvent PanelLocationChanged(Me, value)
      End If
    End Set
  End Property

  Private _PanelType As DockPanelType = DockPanelType.Panel
  Public Property PanelType As DockPanelType
    Get
      Return _PanelType
    End Get
    Set(value As DockPanelType)
      If _PanelType <> value Then
        _PanelType = value
        RaiseEvent PanelTypeChanged(Me, value)
      End If
    End Set
  End Property

  Private _PanelShowClose As Boolean = True
  Public Property PanelShowClose As Boolean
    Get
      Return _PanelShowClose
    End Get
    Set(value As Boolean)
      _PanelShowClose = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelShowSearch As Boolean = True
  Public Property PanelShowSearch As Boolean
    Get
      Return _PanelShowClose
    End Get
    Set(value As Boolean)
      _PanelShowClose = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelShowPinned As Boolean = True
  Public Property PanelShowPinned As Boolean
    Get
      Return _PanelShowPinned
    End Get
    Set(value As Boolean)
      _PanelShowPinned = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelShowContextMenu As Boolean = True
  Public Property PanelShowContextMenu As Boolean
    Get
      Return _PanelShowContextMenu
    End Get
    Set(value As Boolean)
      _PanelShowContextMenu = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelHasFocus As Boolean = True
  Public Property PanelHasFocus As Boolean
    Get
      Return _PanelHasFocus
    End Get
    Set(value As Boolean)
      If value <> _PanelHasFocus Then
        _PanelHasFocus = value
        LayoutPanel()
        RaiseEvent PanelFocusChanged(Me, value)
      End If
    End Set
  End Property

  Private _PanelIsPinned As Boolean = True
  Public Property PanelIsPinned As Boolean
    Get
      Return _PanelIsPinned
    End Get
    Set(value As Boolean)
      _PanelIsPinned = value
    End Set
  End Property

  Private _PanelBackColor As Color = Color.Black
  Public Property PanelBackColor As Color
    Get
      Return _PanelBackColor
    End Get
    Set(value As Color)
      _PanelBackColor = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelBorderColor As Color = Color.DarkGray
  Public Property PanelBorderColor As Color
    Get
      Return _PanelBorderColor
    End Get
    Set(value As Color)
      _PanelBorderColor = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelFontColor As Color = Color.WhiteSmoke
  Public Property PanelFontColor As Color
    Get
      Return _PanelFontColor
    End Get
    Set(value As Color)
      _PanelFontColor = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelHighlightColor As Color = Color.Lime
  Public Property PanelHighlightColor As Color
    Get
      Return _PanelHighlightColor
    End Get
    Set(value As Color)
      _PanelHighlightColor = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelShadowColor As Color = ColorToShadow(_PanelBorderColor)
  Public Property PanelShadowColor As Color
    Get
      Return _PanelShadowColor
    End Get
    Set(value As Color)
      _PanelShadowColor = value
      Invalidate(True)
    End Set
  End Property

  Private _PanelAccentColor As Color = ColorToAccent(_PanelBorderColor)
  Public Property PanelAccentColor As Color
    Get
      Return _PanelAccentColor
    End Get
    Set(value As Color)
      _PanelAccentColor = value
      Invalidate(True)
    End Set
  End Property

  Public ReadOnly Property PanelItemCount As Integer
    Get
      Return tabPages.Count
    End Get
  End Property

  Public ReadOnly Property PanelCaption As String
    Get
      Return lblCaption.Text
    End Get
  End Property

  Public ReadOnly Property PanelSelectedItem As IDockPanelItem
    Get
      If pnlClient.TabCount > 0 Then
        If pnlClient.SelectedTab.Controls.Count > 0 Then
          Return CType(pnlClient.SelectedTab.Controls(0), IDockPanelItem)
        End If
      End If
      Return Nothing
    End Get
  End Property

  Public ReadOnly Property PanelSelectedIndex As Integer
    Get
      Return pnlClient.SelectedIndex
    End Get
  End Property

#End Region

#Region "Item Management"

  Public Sub SelectItem(key As String)
    If Not pnlClient.TabPages.ContainsKey(key) Then
      Exit Sub
    End If
    SelectItem(pnlClient.TabPages.IndexOfKey(key))
  End Sub

  Public Sub SelectItem(index As Integer)
    If index >= 0 Or index < pnlClient.TabCount Then
      pnlClient.TabPages(index).Select()
    End If
  End Sub

  Public Function AddItem(item As IDockPanelItem) As Integer
    With item
      .ItemDockStyle = DockStyle.Fill
    End With
    pnlClient.TabPages.Add(item.ItemCaption, item.ItemCaption)
    With pnlClient.TabPages(item.ItemCaption)
      .BackColor = PanelBackColor
      .BorderStyle = BorderStyle.None
      .UseVisualStyleBackColor = False
      .ForeColor = PanelFontColor
      .Controls.Add(CType(item, Control))
    End With
    RemoveBlankTabs()
    LayoutPanel()
    pnlClient.SelectTab(item.ItemCaption)
  End Function

  Public Function GetItem(key As String) As Control
    If Not pnlClient.TabPages.ContainsKey(key) Then
      Return Nothing
    End If
    Return GetItem(pnlClient.TabPages.IndexOfKey(key))
  End Function

  Public Function GetItem(index As Integer) As Control
    If index < 0 Or index >= pnlClient.TabCount Then
      Return Nothing
    End If
    If pnlClient.TabPages(index).Controls.Count > 0 Then
      Return pnlClient.TabPages(index).Controls(0)
    Else
      Return Nothing
    End If
  End Function

  Public Function RemoveItem(key As String) As Control
    If Not pnlClient.TabPages.ContainsKey(key) Then
      Return Nothing
    End If
    Return RemoveItem(pnlClient.TabPages.IndexOfKey(key))
  End Function

  Public Function RemoveItem(index As Integer) As Control
    Dim ctl As Control = GetItem(index)
    If ctl Is Nothing Then
      Return Nothing
    End If
    AddPlaceholderTab()
    pnlClient.TabPages.RemoveAt(index)
    If hasTabs() Then
      lblCaption.Text = pnlClient.SelectedTab.Text
    Else
      Visible = False
      RaiseEvent PanelCloseRequested(Me)
    End If
    LayoutPanel()
    Return ctl
  End Function

  Private Sub RemoveBlankTabs()
    Dim cnt As Integer = pnlClient.TabCount - 1
    For idx As Integer = cnt To 0 Step -1
      If pnlClient.TabPages(idx).Text = "" Then
        pnlClient.TabPages.RemoveAt(idx)
      End If
    Next
  End Sub

  Private Function hasTabs() As Boolean
    If pnlClient.TabCount > 1 Then Return True
    If pnlClient.TabCount = 0 Then Return False
    If pnlClient.TabPages(0).Text.Equals("") Then Return False
    Return True
  End Function

  Private Sub AddPlaceholderTab()
    If pnlClient.TabCount = 1 Then
      If Not pnlClient.SelectedTab.Text.Equals("") Then
        pnlClient.TabPages.Add("BLANK", "")
      End If
    End If
  End Sub


#End Region

  Public Sub New()
    InitializeComponent()
    SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw, True)
    BackColor = PanelBackColor
    ForeColor = PanelFontColor
    With pnlClient
      .HotTrack = True
      .Margin = New System.Windows.Forms.Padding(0)
      .ShowToolTips = True
      .TabPages(0).Text = ""
      .TabPages(0).BackColor = PanelBackColor
      .TabPages(0).ForeColor = PanelFontColor
    End With
    UpdateStyles()
    lblCaption.Text = ""
    LayoutPanel()
  End Sub

  Private Sub LayoutPanel()
    'Prevent display of control when its empty
    If Not hasTabs() Then
      Visible = False
      Exit Sub
    End If
    'We have data so generate the interface
    Visible = True
    With pnlClient
      .TabAccentColor = PanelAccentColor
      .TabBackColor = PanelBackColor
      .TabBorderColor = PanelBorderColor
      .TabFontColor = PanelFontColor
      .TabHighlightColor = PanelHighlightColor
      .TabShadowColor = PanelShadowColor
      .TabType = PanelType
    End With
    Select Case PanelType
      Case DockPanelType.None
        Visible = False
      Case DockPanelType.Panel
        Visible = True
        'Adjust visibility of all controls within Main Panel
        btnClose.Visible = PanelShowClose
        btnContextMenu.Visible = PanelShowContextMenu
        btnPinned.Visible = PanelShowPinned
        pnlSearch.Visible = PanelShowSearch
        'Apply Main Panel Formatting and refresh
        With pnlMain
          .Visible = True
          If PanelHasFocus Then
            .BorderColorTop = PanelHighlightColor
            .BorderWidth = New Padding(1, 3, 1, 1)
          Else
            .BorderColorTop = PanelBorderColor
            .BorderWidth = New Padding(1, 1, 1, 1)
          End If
          .Invalidate(True)
        End With
        'Apply Client Panel layout and sizing
        With pnlClient
          .Alignment = System.Windows.Forms.TabAlignment.Bottom
          .Padding = New System.Drawing.Point(2, 2)
          If .TabPages.Count < 2 Then
            Dim h As Integer = Height - pnlMain.Height + .ItemSize.Height
            .MinimumSize = New Size(100, h)
            .Size = New Size(.Width, h)
          Else
            .MinimumSize = New Size(0, 0)
          End If
          .Dock = DockStyle.Fill
          .Invalidate(True)
        End With
        'For entire control to refresh and repaint
        Update()
      Case DockPanelType.Tab
        Visible = True
        'Hide the main panel
        pnlMain.Visible = False
        'Apply Client Panel layout and sizing
        With pnlClient
          .Alignment = System.Windows.Forms.TabAlignment.Top
          .Padding = New System.Drawing.Point(20, 2)
          .Size = New Size(0, 0)
          .Dock = DockStyle.Fill
          .Invalidate(True)
        End With
        Update()
    End Select
  End Sub

  Private Sub pnlClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pnlClient.SelectedIndexChanged
    lblCaption.Text = pnlClient.SelectedTab.Text
  End Sub

#Region "Control Event Handlers"
  Private Sub ReLayoutRequired(sender As Object, e As EventArgs) Handles Me.SizeChanged, Me.Load
    LayoutPanel()
  End Sub

  Private Sub DockPanel_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
    PanelHasFocus = True
    LayoutPanel()
  End Sub
#End Region

#Region "Button Handlers"
  Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
    RaiseEvent PanelCloseRequested(Me)
  End Sub

  Private Sub btnPinned_Click(sender As Object, e As EventArgs) Handles btnPinned.Click
    PanelIsPinned = Not PanelIsPinned
  End Sub

#End Region

End Class
