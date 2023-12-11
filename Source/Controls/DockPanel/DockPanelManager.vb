Public Class DockPanelManager
  Inherits System.Windows.Forms.UserControl

#Region "Fields"

  Private WithEvents DockLeftBottom As DockPanel
  Private WithEvents DockLeftTop As DockPanel
  Private WithEvents DockMiddleBottom As DockPanel
  Private WithEvents DockMiddleLeftTop As DockPanel
  Private WithEvents DockMiddleTopRight As DockPanel
  Private WithEvents DockRightBottom As DockPanel
  Private WithEvents DockRightTop As DockPanel
  Private WithEvents pnlLeft As Panel
  Private WithEvents pnlLeftBottom As Panel
  Private WithEvents pnlLeftTop As Panel
  Private WithEvents pnlMain As Panel
  Private WithEvents pnlMiddle As Panel
  Private WithEvents pnlMiddleBottom As Panel
  Private WithEvents pnlMiddleLeft As Panel
  Private WithEvents pnlMiddleRight As Panel
  Private WithEvents pnlMiddleTop As Panel
  Private WithEvents pnlRight As Panel
  Private WithEvents pnlRightBottom As Panel
  Private WithEvents pnlRightTop As Panel
  Private WithEvents splitLeft As Splitter
  Private WithEvents splitLeftTopBottom As Splitter
  Private WithEvents splitMiddleBottom As Splitter
  Private WithEvents splitMiddleLeftRight As Splitter
  Private WithEvents splitRight As Splitter
  Private WithEvents splitRightTopBottom As Splitter
  Private components As System.ComponentModel.IContainer
  Private RegistryItems As Dictionary(Of String, DockPanelItem)
  Private RegistryPanels As Dictionary(Of DockPanelLocation, DockPanel)

#End Region

#Region "Events"

  Public Event PanelItemEvent(panelItem As DockPanelItem, eventType As DockPanelItemEventType)

#End Region

#Region "Public Constructors"

  Public Sub New()
    RegistryPanels = New Dictionary(Of DockPanelLocation, DockPanel)
    RegistryItems = New Dictionary(Of String, DockPanelItem)
    pnlMain = New System.Windows.Forms.Panel()
    pnlMiddle = New System.Windows.Forms.Panel()
    pnlMiddleTop = New System.Windows.Forms.Panel()
    pnlMiddleLeft = New System.Windows.Forms.Panel()
    DockMiddleLeftTop = New AncestryAssistant.DockPanel()
    splitMiddleLeftRight = New System.Windows.Forms.Splitter()
    pnlMiddleRight = New System.Windows.Forms.Panel()
    DockMiddleTopRight = New AncestryAssistant.DockPanel()
    splitMiddleBottom = New System.Windows.Forms.Splitter()
    pnlMiddleBottom = New System.Windows.Forms.Panel()
    DockMiddleBottom = New AncestryAssistant.DockPanel()
    splitLeft = New System.Windows.Forms.Splitter()
    pnlLeft = New System.Windows.Forms.Panel()
    pnlLeftBottom = New System.Windows.Forms.Panel()
    DockLeftBottom = New AncestryAssistant.DockPanel()
    splitLeftTopBottom = New System.Windows.Forms.Splitter()
    pnlLeftTop = New System.Windows.Forms.Panel()
    DockLeftTop = New AncestryAssistant.DockPanel()
    splitRight = New System.Windows.Forms.Splitter()
    pnlRight = New System.Windows.Forms.Panel()
    pnlRightBottom = New System.Windows.Forms.Panel()
    DockRightBottom = New AncestryAssistant.DockPanel()
    splitRightTopBottom = New System.Windows.Forms.Splitter()
    pnlRightTop = New System.Windows.Forms.Panel()
    DockRightTop = New AncestryAssistant.DockPanel()
    pnlMain.SuspendLayout()
    pnlMiddle.SuspendLayout()
    pnlMiddleTop.SuspendLayout()
    pnlMiddleLeft.SuspendLayout()
    DockMiddleLeftTop.SuspendLayout()
    pnlMiddleRight.SuspendLayout()
    DockMiddleTopRight.SuspendLayout()
    pnlMiddleBottom.SuspendLayout()
    pnlLeft.SuspendLayout()
    pnlLeftBottom.SuspendLayout()
    pnlLeftTop.SuspendLayout()
    pnlRight.SuspendLayout()
    pnlRightBottom.SuspendLayout()
    pnlRightTop.SuspendLayout()
    SuspendLayout()
    With pnlMain
      .BackColor = My.Theme.PanelBackColor
      .Controls.Add(pnlMiddle)
      .Controls.Add(splitLeft)
      .Controls.Add(pnlLeft)
      .Controls.Add(splitRight)
      .Controls.Add(pnlRight)
      .Dock = System.Windows.Forms.DockStyle.Fill
      .ForeColor = My.Theme.PanelFontColor
      .Location = New System.Drawing.Point(0, 0)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "pnlMain"
      .Padding = New System.Windows.Forms.Padding(4)
      .Size = New System.Drawing.Size(637, 378)
    End With
    With pnlMiddle
      .Controls.Add(pnlMiddleTop)
      .Controls.Add(splitMiddleBottom)
      .Controls.Add(pnlMiddleBottom)
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(214, 4)
      .Name = "pnlMiddle"
      .Size = New System.Drawing.Size(215, 370)
    End With
    With pnlMiddleTop
      .Controls.Add(pnlMiddleLeft)
      .Controls.Add(splitMiddleLeftRight)
      .Controls.Add(pnlMiddleRight)
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(0, 0)
      .Name = "pnlMiddleTop"
      .Size = New System.Drawing.Size(215, 295)
    End With
    With pnlMiddleLeft
      .BackColor = My.Theme.PanelBackColor
      .Controls.Add(DockMiddleLeftTop)
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(0, 0)
      .Name = "pnlMiddleLeft"
      .Size = New System.Drawing.Size(96, 295)
    End With
    With DockMiddleLeftTop
      .Dock = System.Windows.Forms.DockStyle.Fill
      .PanelType = DockPanelType.Tab
      .PanelLocation = DockPanelLocation.MiddleTopLeft
      .Location = New System.Drawing.Point(0, 0)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "DockMiddleLeftTop"
    End With
    RegisterDock(DockMiddleLeftTop)
    With splitMiddleLeftRight
      .Dock = System.Windows.Forms.DockStyle.Right
      .Location = New System.Drawing.Point(96, 0)
      .Name = "splitMiddleLeftRight"
      .Size = New System.Drawing.Size(4, 295)
    End With
    With pnlMiddleRight
      .BackColor = My.Theme.PanelBackColor
      .Controls.Add(DockMiddleTopRight)
      .Dock = System.Windows.Forms.DockStyle.Right
      .Location = New System.Drawing.Point(100, 0)
      .Name = "pnlMiddleRight"
      .Size = New System.Drawing.Size(115, 295)
    End With
    With DockMiddleTopRight
      .Dock = System.Windows.Forms.DockStyle.Fill
      .PanelType = DockPanelType.Tab
      .Location = New System.Drawing.Point(0, 0)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "DockMiddleTopRight"
      .PanelLocation = DockPanelLocation.MiddleTopRight
    End With
    RegisterDock(DockMiddleTopRight)
    With splitMiddleBottom
      .Dock = System.Windows.Forms.DockStyle.Bottom
      .Location = New System.Drawing.Point(0, 295)
      .Name = "splitMiddleBottom"
      .Size = New System.Drawing.Size(215, 4)
    End With
    With pnlMiddleBottom
      .BackColor = My.Theme.PanelBackColor
      .Controls.Add(DockMiddleBottom)
      .Dock = System.Windows.Forms.DockStyle.Bottom
      .Location = New System.Drawing.Point(0, 299)
      .Name = "pnlMiddleBottom"
      .Size = New System.Drawing.Size(215, 71)
    End With
    With DockMiddleBottom
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(0, 0)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "DockMiddleBottom"
      .PanelLocation = DockPanelLocation.MiddleBottom
    End With
    RegisterDock(DockMiddleBottom)
    With splitLeft
      .Location = New System.Drawing.Point(210, 4)
      .Name = "splitLeft"
      .Size = New System.Drawing.Size(4, 370)
    End With
    With pnlLeft
      .Controls.Add(pnlLeftBottom)
      .Controls.Add(splitLeftTopBottom)
      .Controls.Add(pnlLeftTop)
      .Dock = System.Windows.Forms.DockStyle.Left
      .Location = New System.Drawing.Point(4, 4)
      .Name = "pnlLeft"
      .Size = New System.Drawing.Size(206, 370)
    End With
    With pnlLeftBottom
      .BackColor = My.Theme.PanelBackColor
      .Controls.Add(DockLeftBottom)
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(0, 153)
      .Name = "pnlLeftBottom"
      .Size = New System.Drawing.Size(206, 217)
    End With
    With DockLeftBottom
      .BackColor = My.Theme.PanelBackColor
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(0, 0)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "DockLeftBottom"
      .PanelLocation = DockPanelLocation.LeftBottom
    End With
    RegisterDock(DockLeftBottom)
    With splitLeftTopBottom
      .Dock = System.Windows.Forms.DockStyle.Top
      .Location = New System.Drawing.Point(0, 149)
      .Name = "splitLeftTopBottom"
      .Size = New System.Drawing.Size(206, 4)
    End With
    With pnlLeftTop
      .BackColor = My.Theme.PanelBackColor
      .Controls.Add(DockLeftTop)
      .Dock = System.Windows.Forms.DockStyle.Top
      .Location = New System.Drawing.Point(0, 0)
      .Name = "pnlLeftTop"
      .Size = New System.Drawing.Size(206, 149)
    End With
    With DockLeftTop
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(0, 0)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "DockLeftTop"
      .PanelLocation = DockPanelLocation.LeftTop
    End With
    RegisterDock(DockLeftTop)
    With splitRight
      .Dock = System.Windows.Forms.DockStyle.Right
      .Location = New System.Drawing.Point(429, 4)
      .Name = "splitRight"
      .Size = New System.Drawing.Size(4, 370)
    End With
    With pnlRight
      .Controls.Add(pnlRightBottom)
      .Controls.Add(splitRightTopBottom)
      .Controls.Add(pnlRightTop)
      .Dock = System.Windows.Forms.DockStyle.Right
      .Location = New System.Drawing.Point(433, 4)
      .Name = "pnlRight"
      .Size = New System.Drawing.Size(200, 370)
    End With
    With pnlRightBottom
      .BackColor = My.Theme.PanelBackColor
      .Controls.Add(DockRightBottom)
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(0, 156)
      .Name = "pnlRightBottom"
      .Size = New System.Drawing.Size(200, 214)
    End With
    With DockRightBottom
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(0, 0)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "DockRightBottom"
      .PanelLocation = DockPanelLocation.RightBottom
    End With
    RegisterDock(DockRightBottom)
    With splitRightTopBottom
      .Dock = System.Windows.Forms.DockStyle.Top
      .Location = New System.Drawing.Point(0, 152)
      .Name = "splitRightTopBottom"
      .Size = New System.Drawing.Size(200, 4)
    End With
    With pnlRightTop
      .BackColor = My.Theme.PanelBackColor
      .Controls.Add(DockRightTop)
      .Dock = System.Windows.Forms.DockStyle.Top
      .Location = New System.Drawing.Point(0, 0)
      .Name = "pnlRightTop"
      .Size = New System.Drawing.Size(200, 152)
    End With
    With DockRightTop
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(0, 0)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "DockRightTop"
      .PanelLocation = DockPanelLocation.RightTop
    End With
    RegisterDock(DockRightTop)
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Controls.Add(pnlMain)
    Name = "DockPanelManager"
    Size = New System.Drawing.Size(637, 378)
    pnlMain.ResumeLayout(False)
    pnlMiddle.ResumeLayout(False)
    pnlMiddleTop.ResumeLayout(False)
    pnlMiddleLeft.ResumeLayout(False)
    DockMiddleLeftTop.ResumeLayout(False)
    pnlMiddleRight.ResumeLayout(False)
    DockMiddleTopRight.ResumeLayout(False)
    pnlMiddleBottom.ResumeLayout(False)
    pnlLeft.ResumeLayout(False)
    pnlLeftBottom.ResumeLayout(False)
    pnlLeftTop.ResumeLayout(False)
    pnlRight.ResumeLayout(False)
    pnlRightBottom.ResumeLayout(False)
    pnlRightTop.ResumeLayout(False)
    ResumeLayout(False)
  End Sub

#End Region

#Region "Private Methods"

  Private Function IsDockableLocation(dockLocation As DockPanelLocation) As Boolean
    Return Not (dockLocation.Equals(DockPanelLocation.None) Or dockLocation.Equals(DockPanelLocation.TrayBottom) Or dockLocation.Equals(DockPanelLocation.Tray) Or dockLocation.Equals(DockPanelLocation.TrayLeft) Or dockLocation.Equals(DockPanelLocation.TrayRight) Or dockLocation.Equals(DockPanelLocation.Floating))
  End Function

  Private Sub ManageSplitters_PanelLeft(topVis As Boolean, botVis As Boolean)
    If pnlLeftTop.Dock = DockStyle.Top Then
      pnlLeftTop.Tag = pnlLeftTop.Height
    End If
    If topVis And Not botVis Then
      pnlLeftTop.Dock = DockStyle.Fill
    End If
    If topVis And botVis And pnlLeftTop.Dock = DockStyle.Fill Then
      pnlLeftTop.Dock = DockStyle.Top
      pnlLeftTop.Height = CInt(pnlLeftTop.Tag)
    End If

    pnlLeftTop.Visible = topVis
    pnlLeftBottom.Visible = botVis
    splitLeft.Visible = topVis Or botVis
    splitLeftTopBottom.Visible = topVis And botVis
    pnlLeft.Visible = topVis Or botVis
  End Sub

  Private Sub ManageSplitters_PanelMiddle(leftVis As Boolean, rightVis As Boolean, bottomVis As Boolean)
    If pnlMiddleRight.Dock = DockStyle.Right Then
      pnlMiddleRight.Tag = pnlMiddleRight.Width
    End If
    If rightVis And Not leftVis Then
      pnlMiddleRight.Dock = DockStyle.Fill
    End If
    If leftVis And rightVis And pnlMiddleRight.Dock = DockStyle.Fill Then
      pnlMiddleRight.Dock = DockStyle.Right
      pnlMiddleRight.Width = CInt(pnlMiddleRight.Tag)
    End If

    pnlMiddleBottom.Visible = bottomVis
    splitMiddleBottom.Visible = bottomVis
    pnlMiddleLeft.Visible = leftVis
    pnlMiddleRight.Visible = rightVis
    splitMiddleLeftRight.Visible = leftVis And rightVis
  End Sub

  Private Sub ManageSplitters_PanelRight(topVis As Boolean, botVis As Boolean)
    If pnlRightTop.Dock = DockStyle.Top Then
      pnlRightTop.Tag = pnlRightTop.Height
    End If
    If topVis And Not botVis Then
      pnlRightTop.Dock = DockStyle.Fill
    End If
    If topVis And botVis And pnlRightTop.Dock = DockStyle.Fill Then
      pnlRightTop.Dock = DockStyle.Top
      pnlRightTop.Height = CInt(pnlRightTop.Tag)
    End If

    pnlRightTop.Visible = topVis
    pnlRightBottom.Visible = botVis
    splitRight.Visible = topVis Or botVis
    splitRightTopBottom.Visible = topVis And botVis
    pnlRight.Visible = topVis Or botVis
  End Sub

  Private Sub PanelClose(sender As DockPanel)
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("DockPanelManager.PanelClose(DockPanel=[{0}, {1}])", sender.Name, sender.PanelLocation.ToString)
#End If
    PanelVisible(sender.PanelLocation, False)
  End Sub

  Private Sub PanelFocusChanged(sender As DockPanel, hasFocus As Boolean)
    If Not hasFocus Then Exit Sub
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("DockPanelManager.PanelFocusChanged(dockPanel=[{0}, {1}], hasFocus=[{2}])", sender.Name, sender.PanelLocation.ToString, hasFocus)
#End If
    PanelFocus(sender.PanelLocation)
  End Sub

  Private Sub PanelItemClosed(sender As DockPanelItem)
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("DockPanelManager.PanelItemClosed(panelItem=[{0}, {1}])", sender.Name, sender.LocationCurrent.ToString)
#End If
    sender.LocationCurrent = DockPanelLocation.Tray
    RaiseEvent PanelItemEvent(sender, DockPanelItemEventType.ItemClosed)
  End Sub

  Private Sub PanelItemLocationChange(panelItem As DockPanelItem, newPanelLocation As DockPanelLocation)
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("DockPanelManager.PanelItemLocationChange(panelItem=[{0}, {1}], newPanelLocation[{2}])", panelItem.Name, panelItem.LocationCurrent.ToString, newPanelLocation.ToString)
#End If
    Dim frmDock As DockPanel = RegistryPanels.Item(panelItem.LocationCurrent)
    Dim toDock As DockPanel = RegistryPanels.Item(newPanelLocation)
    frmDock.RemoveItem(panelItem.Key)
    toDock.AddItem(panelItem)
    panelItem.LocationCurrent = newPanelLocation
    ShowPanel(newPanelLocation)
    toDock.Focus()
  End Sub

  Private Sub PanelItemSelected(panelItem As DockPanelItem)
    If panelItem Is Nothing Then Exit Sub
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("DockPanelManager.PanelItemSelected(panelItem=[{0}, {1}])", panelItem.Name, panelItem.LocationCurrent.ToString)
#End If
    RaiseEvent PanelItemEvent(panelItem, DockPanelItemEventType.ItemSelected)
  End Sub

  Private Sub RegisterDock(pnl As DockPanel)
#If DEBUG_LEVEL = DEBUG_LEVEL_ALL Then
    Logger.debugPrint("DockPanelManager.RegisterDock(pnl=[{0}, {1}])", pnl.Name, pnl.PanelLocation.ToString)
#End If
    RegistryPanels.Add(pnl.PanelLocation, pnl)
    AddHandler pnl.PanelClose, AddressOf PanelClose
    AddHandler pnl.PanelFocusChanged, AddressOf PanelFocusChanged
    AddHandler pnl.PanelItemLocationChange, AddressOf PanelItemLocationChange
    AddHandler pnl.PanelItemClose, AddressOf PanelItemClosed
    AddHandler pnl.PanelItemSelected, AddressOf PanelItemSelected
  End Sub

#End Region

#Region "Protected Methods"

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

  Public Function AddItem(dockLocation As DockPanelLocation, panelItemKey As String) As DockPanelItem
    'Logger.debugPrint("AddItem: {0}({1})", panelItemKey, dockLocation.ToString)
    If IsDockableLocation(dockLocation) Then
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
      Logger.debugPrint("DockPanelManager.AddItem(dockLocation=[{0}], panelItemKey=[{1}])", dockLocation.ToString, panelItemKey)
#End If
      Dim dockPnl As DockPanel = RegistryPanels(dockLocation)
      Dim item As DockPanelItem = RegistryItems(panelItemKey)
      dockPnl.AddItem(item)
      item.LocationCurrent = dockLocation
      Return item
    End If
    Return Nothing
  End Function

  Public Sub HidePanel(dockLocation As DockPanelLocation)
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("DockPanelManager.HidePanel(dockLocation=[{0}])", dockLocation)
#End If
    PanelVisible(dockLocation, False)
  End Sub

  Public Function IsPanelVisible(dockLocation As DockPanelLocation) As Boolean
    Return RegistryPanels(dockLocation).Visible
  End Function

  Public Sub MoveItem(key As String, dockLocation As DockPanelLocation)
#If DEBUG_LEVEL = DEBUG_LEVEL_ALL Then
    Logger.debugPrint("DockPanelManager.MoveItem(key=[{0}], dockLocation=[{1}])", key, dockLocation.ToString)
#End If
    Dim item As DockPanelItem = RegistryItems(key)
    If item Is Nothing Then Exit Sub
    Dim dockPnl As DockPanel = RegistryPanels(dockLocation)
    If dockPnl IsNot Nothing Then
      dockPnl.AddItem(item)
      item.LocationCurrent = dockLocation
    End If
  End Sub

  Public Sub PanelFocus(focusedLocation As DockPanelLocation)
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("DockPanelManager.PanelUnFocus(skipPanelLocation=[{0}])", focusedLocation.ToString)
#End If
    For Each panelLocation As DockPanelLocation In [Enum].GetValues(GetType(DockPanelLocation))
      If IsDockableLocation(panelLocation) Then
        RegistryPanels.Item(panelLocation).PanelHasFocus = focusedLocation.Equals(panelLocation)
      End If
    Next
  End Sub

  Public Sub PanelVisible(panelLocation As DockPanelLocation, isVisible As Boolean)
    Select Case panelLocation
      Case DockPanelLocation.LeftTop
        ManageSplitters_PanelLeft(isVisible, pnlLeftBottom.Visible)
      Case DockPanelLocation.LeftBottom
        ManageSplitters_PanelLeft(pnlLeftTop.Visible, isVisible)
      Case DockPanelLocation.MiddleTopLeft
        ManageSplitters_PanelMiddle(isVisible, pnlMiddleRight.Visible, pnlMiddleBottom.Visible)
      Case DockPanelLocation.MiddleTopRight
        ManageSplitters_PanelMiddle(pnlMiddleLeft.Visible, isVisible, pnlMiddleBottom.Visible)
      Case DockPanelLocation.MiddleBottom
        ManageSplitters_PanelMiddle(pnlMiddleLeft.Visible, pnlMiddleRight.Visible, isVisible)
      Case DockPanelLocation.RightTop
        ManageSplitters_PanelRight(isVisible, pnlRightBottom.Visible)
      Case DockPanelLocation.RightBottom
        ManageSplitters_PanelRight(pnlRightTop.Visible, isVisible)
    End Select
  End Sub

  Public Sub RegisterDockItem(item As DockPanelItem)
    RegistryItems.Add(item.Key, item)
  End Sub

  Public Sub SelectItem(panelItem As DockPanelItem)
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("DockPanelManager.SelectItemTab(panelItem=[{0},{1}])", panelItem.Key, panelItem.LocationCurrent.ToString)
#End If
    Dim dockPnl As DockPanel = RegistryPanels(panelItem.LocationCurrent)
    If dockPnl Is Nothing Then Exit Sub
    dockPnl.SelectItem(panelItem.Key)
    PanelFocus(panelItem.LocationCurrent)
  End Sub

  Public Sub SettingsLoad()
    For Each key As String In RegistryItems.Keys
      Dim prop As String = key + "_LOC"
      Dim loc As DockPanelLocation = DockPanelLocation.Tray
      Try
#If DEBUG_LEVEL >= DEBUG_LEVEL_CRITICAL Then
        Logger.debugPrint("DockPanelManager.SettingsLoad: {0}=[{1}]", prop, My.Settings.Item(prop))
#End If
        loc = My.Settings.Item(prop)
      Catch ex As Exception
#If DEBUG_LEVEL >= DEBUG_LEVEL_CRITICAL Then
        Logger.debugPrint("DockPanelManager.SettingsLoad: {0}=[{1}]", prop, "FAILED")
#End If
        loc = DockPanelLocation.Tray
      End Try
      If loc <> DockPanelLocation.Tray Then
        AddItem(loc, key)
      End If
    Next
    PanelVisible(DockPanelLocation.MiddleTopLeft, My.Settings.UI_ML_VIS)
    PanelVisible(DockPanelLocation.MiddleTopRight, My.Settings.UI_MR_VIS)
    PanelVisible(DockPanelLocation.MiddleBottom, My.Settings.UI_MB_VIS)
    pnlMiddleRight.Width = My.Settings.UI_MR_WIDTH
    pnlMiddleBottom.Height = My.Settings.UI_MB_HEIGHT

    PanelVisible(DockPanelLocation.LeftTop, My.Settings.UI_LT_VIS)
    PanelVisible(DockPanelLocation.LeftBottom, My.Settings.UI_LB_VIS)
    pnlLeft.Width = My.Settings.UI_L_WIDTH
    pnlLeftTop.Height = My.Settings.UI_LT_HEIGHT

    PanelVisible(DockPanelLocation.RightTop, My.Settings.UI_RT_VIS)
    PanelVisible(DockPanelLocation.RightBottom, My.Settings.UI_RB_VIS)
    pnlRight.Width = My.Settings.UI_R_WIDTH
    pnlRightTop.Height = My.Settings.UI_RT_HEIGHT

    'Hide blank panels
    If RegistryPanels(DockPanelLocation.LeftTop).Visible = False Then
      PanelVisible(DockPanelLocation.LeftTop, False)
    End If
    If RegistryPanels(DockPanelLocation.LeftBottom).Visible = False Then
      PanelVisible(DockPanelLocation.LeftBottom, False)
    End If
    If RegistryPanels(DockPanelLocation.MiddleTopRight).Visible = False Then
      PanelVisible(DockPanelLocation.MiddleTopRight, False)
    End If
    If RegistryPanels(DockPanelLocation.MiddleBottom).Visible = False Then
      PanelVisible(DockPanelLocation.MiddleBottom, False)
    End If
    If RegistryPanels(DockPanelLocation.RightBottom).Visible = False Then
      PanelVisible(DockPanelLocation.RightBottom, False)
    End If
    If RegistryPanels(DockPanelLocation.RightTop).Visible = False Then
      PanelVisible(DockPanelLocation.RightTop, False)
    End If
    'Clean up any assigned items to hidden tabs
    For Each key As String In RegistryItems.Keys
      Dim itm As DockPanelItem = RegistryItems(key)
      If IsDockableLocation(itm.LocationCurrent) Then
        Dim pnl As DockPanel = RegistryPanels(itm.LocationCurrent)
        If Not pnl.Visible Then
          pnl.RemoveItem(key)
        End If
      End If
    Next
    PanelFocus(DockPanelLocation.MiddleTopLeft)
  End Sub

  Public Sub SettingsSave()
    For Each key As String In RegistryItems.Keys
      Try
#If DEBUG_LEVEL >= DEBUG_LEVEL_CRITICAL Then
        Logger.debugPrint("DockPanelManager.SettingsSave: {0}=[{1}]", key + "_LOC", CInt(RegistryItems(key).LocationCurrent))
#End If
        My.Settings.Item(key + "_LOC") = CInt(RegistryItems(key).LocationCurrent)
      Catch ex As Exception
#If DEBUG_LEVEL >= DEBUG_LEVEL_CRITICAL Then
        Logger.debugPrint("DockPanelManager.SettingsSave: {0}=[{1}]", key + "_LOC", "FAILED")
#End If
      End Try
    Next
    My.Settings.UI_MR_WIDTH = pnlMiddleRight.Width
    My.Settings.UI_MB_HEIGHT = pnlMiddleBottom.Height
    My.Settings.UI_ML_VIS = pnlMiddleLeft.Visible
    My.Settings.UI_MR_VIS = pnlMiddleRight.Visible
    My.Settings.UI_MB_VIS = pnlMiddleBottom.Visible

    My.Settings.UI_L_WIDTH = pnlLeft.Width
    My.Settings.UI_LT_HEIGHT = pnlLeftTop.Height
    My.Settings.UI_LT_VIS = pnlLeftTop.Visible
    My.Settings.UI_LB_VIS = pnlLeftBottom.Visible

    My.Settings.UI_R_WIDTH = pnlRight.Width
    My.Settings.UI_RT_HEIGHT = pnlRightTop.Height
    My.Settings.UI_RT_VIS = pnlRightTop.Visible
    My.Settings.UI_RB_VIS = pnlRightBottom.Visible

  End Sub

  Public Sub ShowPanel(dockLocation As DockPanelLocation)
#If DEBUG_LEVEL >= DEBUG_LEVEL_CRITICAL Then
    Logger.debugPrint("DockPanelManager.ShowPanel(dockLocation=[{0}])", dockLocation.ToString)
#End If
    PanelVisible(dockLocation, True)
  End Sub

  Public Sub ShowRegisteredItem(itemKey As String)
#If DEBUG_LEVEL >= DEBUG_LEVEL_CRITICAL Then
    Logger.debugPrint("DockPanelManager.ShowRegisteredItem(itemKey=[{0}])", itemKey)
#End If
    Dim itm As DockPanelItem = RegistryItems(itemKey)
    Dim loc As DockPanelLocation = itm.LocationPrevious
    If itm.LocationCurrent = DockPanelLocation.Tray Or itm.LocationCurrent = DockPanelLocation.None Then
      If itm.LocationPrevious = DockPanelLocation.None Or itm.LocationPrevious = DockPanelLocation.Tray Then
        loc = itm.LocationPrefered
      End If
      AddItem(loc, itemKey)
    Else
      loc = itm.LocationCurrent
    End If
    PanelVisible(itm.LocationCurrent, True)
    SelectItem(itm)
    RaiseEvent PanelItemEvent(itm, DockPanelItemEventType.ItemOpened)
  End Sub

#End Region

End Class