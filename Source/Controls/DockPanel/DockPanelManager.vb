Public Class DockPanelManager
  Inherits System.Windows.Forms.UserControl

  Private WithEvents DockLeftBottom As DockPanel
  Private WithEvents DockLeftTop As DockPanel
  Private WithEvents DockMiddleBottom As DockPanel
  Private WithEvents DockMiddleLeftTop As DockPanel
  Private WithEvents DockMiddleTopRight As DockPanel
  Private WithEvents DockRightBottom As DockPanel
  Private WithEvents DockRightTop As DockPanel
  Private WithEvents PnlLeft As Panel
  Private WithEvents PnlLeftBottom As Panel
  Private WithEvents PnlLeftTop As Panel
  Private WithEvents PnlMain As Panel
  Private WithEvents PnlMiddle As Panel
  Private WithEvents PnlMiddleBottom As Panel
  Private WithEvents PnlMiddleLeft As Panel
  Private WithEvents PnlMiddleRight As Panel
  Private WithEvents PnlMiddleTop As Panel
  Private WithEvents PnlRight As Panel
  Private WithEvents PnlRightBottom As Panel
  Private WithEvents PnlRightTop As Panel
  Private WithEvents SplitLeft As Splitter
  Private WithEvents SplitLeftTopBottom As Splitter
  Private WithEvents SplitMiddleBottom As Splitter
  Private WithEvents SplitMiddleLeftRight As Splitter
  Private WithEvents SplitRight As Splitter
  Private WithEvents SplitRightTopBottom As Splitter
  Private components As System.ComponentModel.IContainer

  Private RegistryDelegates As Dictionary(Of String, PanelItemCreateDelegate)

  Private RegistryItems As Dictionary(Of String, DockPanelItem)

  Private RegistryPanels As Dictionary(Of DockPanelLocation, DockPanel)

  Public Delegate Function PanelItemCreateDelegate() As DockPanelItem

  Public Event PanelItemEvent(panelItem As DockPanelItem, eventType As DockPanelItemEventType, eventData As Object)

  Public Sub New()
    RegistryDelegates = New Dictionary(Of String, PanelItemCreateDelegate)
    RegistryPanels = New Dictionary(Of DockPanelLocation, DockPanel)
    RegistryItems = New Dictionary(Of String, DockPanelItem)
    PnlMain = New System.Windows.Forms.Panel()
    PnlMiddle = New System.Windows.Forms.Panel()
    PnlMiddleTop = New System.Windows.Forms.Panel()
    PnlMiddleLeft = New System.Windows.Forms.Panel()
    DockMiddleLeftTop = New AncestryAssistant.DockPanel()
    SplitMiddleLeftRight = New System.Windows.Forms.Splitter()
    PnlMiddleRight = New System.Windows.Forms.Panel()
    DockMiddleTopRight = New AncestryAssistant.DockPanel()
    SplitMiddleBottom = New System.Windows.Forms.Splitter()
    PnlMiddleBottom = New System.Windows.Forms.Panel()
    DockMiddleBottom = New AncestryAssistant.DockPanel()
    SplitLeft = New System.Windows.Forms.Splitter()
    PnlLeft = New System.Windows.Forms.Panel()
    PnlLeftBottom = New System.Windows.Forms.Panel()
    DockLeftBottom = New AncestryAssistant.DockPanel()
    SplitLeftTopBottom = New System.Windows.Forms.Splitter()
    PnlLeftTop = New System.Windows.Forms.Panel()
    DockLeftTop = New AncestryAssistant.DockPanel()
    SplitRight = New System.Windows.Forms.Splitter()
    PnlRight = New System.Windows.Forms.Panel()
    PnlRightBottom = New System.Windows.Forms.Panel()
    DockRightBottom = New AncestryAssistant.DockPanel()
    SplitRightTopBottom = New System.Windows.Forms.Splitter()
    PnlRightTop = New System.Windows.Forms.Panel()
    DockRightTop = New AncestryAssistant.DockPanel()
    PnlMain.SuspendLayout()
    PnlMiddle.SuspendLayout()
    PnlMiddleTop.SuspendLayout()
    PnlMiddleLeft.SuspendLayout()
    DockMiddleLeftTop.SuspendLayout()
    PnlMiddleRight.SuspendLayout()
    DockMiddleTopRight.SuspendLayout()
    PnlMiddleBottom.SuspendLayout()
    PnlLeft.SuspendLayout()
    PnlLeftBottom.SuspendLayout()
    PnlLeftTop.SuspendLayout()
    PnlRight.SuspendLayout()
    PnlRightBottom.SuspendLayout()
    PnlRightTop.SuspendLayout()
    SuspendLayout()
    With PnlMain
      .BackColor = My.Theme.PanelBackColor
      .Controls.Add(PnlMiddle)
      .Controls.Add(SplitLeft)
      .Controls.Add(PnlLeft)
      .Controls.Add(SplitRight)
      .Controls.Add(PnlRight)
      .Dock = System.Windows.Forms.DockStyle.Fill
      .ForeColor = My.Theme.PanelFontColor
      .Location = New System.Drawing.Point(0, 0)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "pnlMain"
      .Padding = New System.Windows.Forms.Padding(4)
      .Size = New System.Drawing.Size(637, 378)
    End With
    With PnlMiddle
      .Controls.Add(PnlMiddleTop)
      .Controls.Add(SplitMiddleBottom)
      .Controls.Add(PnlMiddleBottom)
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(214, 4)
      .Name = "pnlMiddle"
      .Size = New System.Drawing.Size(215, 370)
    End With
    With PnlMiddleTop
      .Controls.Add(PnlMiddleLeft)
      .Controls.Add(SplitMiddleLeftRight)
      .Controls.Add(PnlMiddleRight)
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(0, 0)
      .Name = "pnlMiddleTop"
      .Size = New System.Drawing.Size(215, 295)
    End With
    With PnlMiddleLeft
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
    PanelRegister(DockMiddleLeftTop)
    With SplitMiddleLeftRight
      .Dock = System.Windows.Forms.DockStyle.Right
      .Location = New System.Drawing.Point(96, 0)
      .Name = "splitMiddleLeftRight"
      .Size = New System.Drawing.Size(4, 295)
    End With
    With PnlMiddleRight
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
    PanelRegister(DockMiddleTopRight)
    With SplitMiddleBottom
      .Dock = System.Windows.Forms.DockStyle.Bottom
      .Location = New System.Drawing.Point(0, 295)
      .Name = "splitMiddleBottom"
      .Size = New System.Drawing.Size(215, 4)
    End With
    With PnlMiddleBottom
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
    PanelRegister(DockMiddleBottom)
    With SplitLeft
      .Location = New System.Drawing.Point(210, 4)
      .Name = "splitLeft"
      .Size = New System.Drawing.Size(4, 370)
    End With
    With PnlLeft
      .Controls.Add(PnlLeftBottom)
      .Controls.Add(SplitLeftTopBottom)
      .Controls.Add(PnlLeftTop)
      .Dock = System.Windows.Forms.DockStyle.Left
      .Location = New System.Drawing.Point(4, 4)
      .Name = "pnlLeft"
      .Size = New System.Drawing.Size(206, 370)
    End With
    With PnlLeftBottom
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
    PanelRegister(DockLeftBottom)
    With SplitLeftTopBottom
      .Dock = System.Windows.Forms.DockStyle.Top
      .Location = New System.Drawing.Point(0, 149)
      .Name = "splitLeftTopBottom"
      .Size = New System.Drawing.Size(206, 4)
    End With
    With PnlLeftTop
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
    PanelRegister(DockLeftTop)
    With SplitRight
      .Dock = System.Windows.Forms.DockStyle.Right
      .Location = New System.Drawing.Point(429, 4)
      .Name = "splitRight"
      .Size = New System.Drawing.Size(4, 370)
    End With
    With PnlRight
      .Controls.Add(PnlRightBottom)
      .Controls.Add(SplitRightTopBottom)
      .Controls.Add(PnlRightTop)
      .Dock = System.Windows.Forms.DockStyle.Right
      .Location = New System.Drawing.Point(433, 4)
      .Name = "pnlRight"
      .Size = New System.Drawing.Size(200, 370)
    End With
    With PnlRightBottom
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
    PanelRegister(DockRightBottom)
    With SplitRightTopBottom
      .Dock = System.Windows.Forms.DockStyle.Top
      .Location = New System.Drawing.Point(0, 152)
      .Name = "splitRightTopBottom"
      .Size = New System.Drawing.Size(200, 4)
    End With
    With PnlRightTop
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
    PanelRegister(DockRightTop)
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Controls.Add(PnlMain)
    Name = "DockPanelManager"
    Size = New System.Drawing.Size(637, 378)
    PnlMain.ResumeLayout(False)
    PnlMiddle.ResumeLayout(False)
    PnlMiddleTop.ResumeLayout(False)
    PnlMiddleLeft.ResumeLayout(False)
    DockMiddleLeftTop.ResumeLayout(False)
    PnlMiddleRight.ResumeLayout(False)
    DockMiddleTopRight.ResumeLayout(False)
    PnlMiddleBottom.ResumeLayout(False)
    PnlLeft.ResumeLayout(False)
    PnlLeftBottom.ResumeLayout(False)
    PnlLeftTop.ResumeLayout(False)
    PnlRight.ResumeLayout(False)
    PnlRightBottom.ResumeLayout(False)
    PnlRightTop.ResumeLayout(False)
    ResumeLayout(False)
  End Sub

  Private Function IsDockableLocation(dockLocation As DockPanelLocation) As Boolean
    Return Not (dockLocation.Equals(DockPanelLocation.None) Or dockLocation.Equals(DockPanelLocation.TrayBottom) Or dockLocation.Equals(DockPanelLocation.Tray) Or dockLocation.Equals(DockPanelLocation.TrayLeft) Or dockLocation.Equals(DockPanelLocation.TrayRight) Or dockLocation.Equals(DockPanelLocation.Floating))
  End Function

  Private Function ItemCreate(itemKey As String) As DockPanelItem
    If RegistryDelegates.ContainsKey(itemKey) Then
      Dim funcCreate As PanelItemCreateDelegate = RegistryDelegates(itemKey)
      Return funcCreate()
    End If
    Return Nothing
  End Function

  Private Sub ItemDestroy(itemKey As String)
#If DEBUG Then
    Logger.debugPrint("DockPanelManager.ItemDestroy(key=[{0}])", itemKey)
#End If
    If RegistryItems.ContainsKey(itemKey) Then
      Dim panelItem As DockPanelItem = RegistryItems(itemKey)
      RegistryItems.Remove(itemKey)
      panelItem.Ancestors = Nothing
      panelItem = Nothing
    End If
  End Sub

  Private Sub ManageSplitters_PanelLeft(topVis As Boolean, botVis As Boolean)
    If PnlLeftTop.Dock = DockStyle.Top Then
      PnlLeftTop.Tag = PnlLeftTop.Height
    End If
    If topVis And Not botVis Then
      PnlLeftTop.Dock = DockStyle.Fill
    End If
    If topVis And botVis And PnlLeftTop.Dock = DockStyle.Fill Then
      PnlLeftTop.Dock = DockStyle.Top
      PnlLeftTop.Height = CInt(PnlLeftTop.Tag)
    End If

    PnlLeftTop.Visible = topVis
    PnlLeftBottom.Visible = botVis
    SplitLeft.Visible = topVis Or botVis
    SplitLeftTopBottom.Visible = topVis And botVis
    PnlLeft.Visible = topVis Or botVis
  End Sub

  Private Sub ManageSplitters_PanelMiddle(leftVis As Boolean, rightVis As Boolean, bottomVis As Boolean)
    If PnlMiddleRight.Dock = DockStyle.Right Then
      PnlMiddleRight.Tag = PnlMiddleRight.Width
    End If
    If rightVis And Not leftVis Then
      PnlMiddleRight.Dock = DockStyle.Fill
    End If
    If leftVis And rightVis And PnlMiddleRight.Dock = DockStyle.Fill Then
      PnlMiddleRight.Dock = DockStyle.Right
      PnlMiddleRight.Width = CInt(PnlMiddleRight.Tag)
    End If

    PnlMiddleBottom.Visible = bottomVis
    SplitMiddleBottom.Visible = bottomVis
    PnlMiddleLeft.Visible = leftVis
    PnlMiddleRight.Visible = rightVis
    SplitMiddleLeftRight.Visible = leftVis And rightVis
  End Sub

  Private Sub ManageSplitters_PanelRight(topVis As Boolean, botVis As Boolean)
    If PnlRightTop.Dock = DockStyle.Top Then
      PnlRightTop.Tag = PnlRightTop.Height
    End If
    If topVis And Not botVis Then
      PnlRightTop.Dock = DockStyle.Fill
    End If
    If topVis And botVis And PnlRightTop.Dock = DockStyle.Fill Then
      PnlRightTop.Dock = DockStyle.Top
      PnlRightTop.Height = CInt(PnlRightTop.Tag)
    End If

    PnlRightTop.Visible = topVis
    PnlRightBottom.Visible = botVis
    SplitRight.Visible = topVis Or botVis
    SplitRightTopBottom.Visible = topVis And botVis
    PnlRight.Visible = topVis Or botVis
  End Sub

  Private Sub Panel_Close(panelObj As DockPanel)
#If TRACE Then
    Logger.debugPrint("DockPanelManager.Panel_Close(DockPanel=[{0}, {1}])", panelObj.Name, panelObj.PanelLocation.ToString)
#End If
    PanelVisible(panelObj.PanelLocation, False)
  End Sub

  Private Sub Panel_FocusChanged(panelObj As DockPanel, HasFocus As Boolean)
    If Not HasFocus Then Exit Sub
#If TRACE Then
    Logger.debugPrint("DockPanelManager.Panel_FocusChanged(dockPanel=[{0}, {1}], HasFocus=[{2}])", panelObj.Name, panelObj.PanelLocation.ToString, HasFocus)
#End If
    PanelFocus(panelObj.PanelLocation)
  End Sub

  Private Sub Panel_ItemClosed(panelItem As DockPanelItem)
#If TRACE Then
    Logger.debugPrint("DockPanelManager.Panel_ItemClosed(panelItem=[{0}, {1}])", panelItem.Name, panelItem.LocationCurrent.ToString)
#End If
    panelItem.LocationCurrent = DockPanelLocation.Tray
    RaiseEvent PanelItemEvent(panelItem, DockPanelItemEventType.ItemClosed, Nothing)
    If panelItem.ItemSuspendOnClose Then
      ItemDestroy(panelItem.Key)
      panelItem = Nothing
    End If
  End Sub

  Private Sub Panel_ItemEvent(Item As DockPanelItem, eventType As DockPanelItemEventType, eventData As Object)
    Select Case eventType
      Case DockPanelItemEventType.ItemLocationChanged
        Panel_ItemLocationChange(Item, CType(eventData, DockPanelLocation))
      Case DockPanelItemEventType.ItemClosed
        Panel_ItemClosed(Item)
      Case DockPanelItemEventType.ItemSelected
        Panel_ItemSelected(Item)
      Case DockPanelItemEventType.NavTrackingChanged
        RaiseEvent PanelItemEvent(Item, eventType, eventData)
      Case DockPanelItemEventType.NavRequested
        RaiseEvent PanelItemEvent(Item, eventType, eventData)
      Case DockPanelItemEventType.ItemBusy
        RaiseEvent PanelItemEvent(Item, eventType, eventData)
      Case DockPanelItemEventType.NavData
        RaiseEvent PanelItemEvent(Item, eventType, eventData)
    End Select
  End Sub

  Private Sub Panel_ItemLocationChange(panelItem As DockPanelItem, dockLocation As DockPanelLocation)
#If TRACE Then
    Logger.debugPrint("DockPanelManager.Panel_ItemLocationChange(panelItem=[{0}, {1}], newPanelLocation[{2}])", panelItem.Name, panelItem.LocationCurrent.ToString, dockLocation.ToString)
#End If
    Dim frmDock As DockPanel = RegistryPanels.Item(panelItem.LocationCurrent)
    Dim toDock As DockPanel = RegistryPanels.Item(dockLocation)
    frmDock.ItemRemove(panelItem.Key)
    toDock.ItemAdd(panelItem)
    panelItem.LocationCurrent = dockLocation
    PanelShow(dockLocation)
    toDock.Focus()
  End Sub

  Private Sub Panel_ItemSelected(panelItem As DockPanelItem)
    If panelItem Is Nothing Then Exit Sub
#If TRACE Then
    Logger.debugPrint("DockPanelManager.Panel_ItemSelected(panelItem=[{0}, {1}])", panelItem.Name, panelItem.LocationCurrent.ToString)
#End If
    RaiseEvent PanelItemEvent(panelItem, DockPanelItemEventType.ItemSelected, Nothing)
  End Sub

  Private Sub PanelRegister(panelObj As DockPanel)
#If DEBUG Then
    Logger.debugPrint("DockPanelManager.PanelRegister(pnl=[{0}, {1}])", panelObj.Name, panelObj.PanelLocation.ToString)
#End If
    RegistryPanels.Add(panelObj.PanelLocation, panelObj)
    AddHandler panelObj.PanelClose, AddressOf Panel_Close
    AddHandler panelObj.PanelFocusChanged, AddressOf Panel_FocusChanged
    AddHandler panelObj.PanelItemEvent, AddressOf Panel_ItemEvent
    'AddHandler panelObj.PanelItemLocationChange, AddressOf Panel_ItemLocationChange
    'AddHandler panelObj.PanelItemClose, AddressOf Panel_ItemClosed
    'AddHandler panelObj.PanelItemSelected, AddressOf Panel_ItemSelected
  End Sub

  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  Public Function ItemAdd(dockLocation As DockPanelLocation, itemKey As String) As DockPanelItem
    'Logger.debugPrint("AddItem: {0}({1})", panelItemKey, dockLocation.ToString)
    If IsDockableLocation(dockLocation) Then
#If TRACE Then
      Logger.debugPrint("DockPanelManager.ItemAdd(dockLocation=[{0}], panelItemKey=[{1}])", dockLocation.ToString, itemKey)
#End If
      Dim dockPnl As DockPanel = RegistryPanels(dockLocation)
      Dim item As DockPanelItem = ItemGet(itemKey)
      dockPnl.ItemAdd(item)
      item.LocationCurrent = dockLocation
      Return item
    End If
    Return Nothing
  End Function

  Public Sub ItemEventRequest(itemKey As String, eventType As DockPanelItemEventType, eventData As Object)
    Dim itm As DockPanelItem = RegistryItems(itemKey)
    itm.EventRequest(eventType, eventData)
  End Sub

  Public Function ItemGet(itemKey As String) As DockPanelItem
    If RegistryItems.ContainsKey(itemKey) Then
#If DEBUG Then
      Logger.debugPrint("DockPanelManager.ItemGet(key=[{0}], FromRegistry)", itemKey)
#End If
      Return RegistryItems(itemKey)
    Else
#If DEBUG Then
      Logger.debugPrint("DockPanelManager.ItemGet(key=[{0}], FromDelegate)", itemKey)
#End If
      Dim panelItem As DockPanelItem = ItemCreate(itemKey)
      If panelItem IsNot Nothing Then
        RegistryItems.Add(itemKey, panelItem)
        Return panelItem
      End If
    End If
    Return Nothing
  End Function

  Public Sub ItemMove(itemKey As String, dockLocation As DockPanelLocation)
#If DEBUG Then
    Logger.debugPrint("DockPanelManager.ItemMove(key=[{0}], dockLocation=[{1}])", itemKey, dockLocation.ToString)
#End If
    Dim item As DockPanelItem = ItemGet(itemKey)
    If item Is Nothing Then Exit Sub
    Dim dockPnl As DockPanel = RegistryPanels(dockLocation)
    If dockPnl IsNot Nothing Then
      dockPnl.ItemAdd(item)
      item.LocationCurrent = dockLocation
    End If
  End Sub

  Public Sub ItemRegister(itemKey As String, funcCreate As PanelItemCreateDelegate)
#If TRACE Then
    Logger.debugPrint("DockPanelManager.ItemRegister(itemKey={0})", itemKey)
#End If
    RegistryDelegates.Add(itemKey, funcCreate)
  End Sub

  Public Sub ItemSelect(panelItem As DockPanelItem)
#If TRACE Then
    Logger.debugPrint("DockPanelManager.ItemSelect(panelItem=[{0},{1}])", panelItem.Key, panelItem.LocationCurrent.ToString)
#End If
    Dim dockPnl As DockPanel = RegistryPanels(panelItem.LocationCurrent)
    If dockPnl Is Nothing Then Exit Sub
    dockPnl.ItemSelect(panelItem.Key)
    PanelFocus(panelItem.LocationCurrent)
  End Sub

  Public Sub ItemShow(itemKey As String)
#If TRACE Then
    Logger.debugPrint("DockPanelManager.ItemShow(itemKey=[{0}])", itemKey)
#End If
    Dim itm As DockPanelItem = ItemGet(itemKey)
    Dim loc As DockPanelLocation = itm.LocationPrevious
    If itm.LocationCurrent = DockPanelLocation.Tray Or itm.LocationCurrent = DockPanelLocation.None Then
      If itm.LocationPrevious = DockPanelLocation.None Or itm.LocationPrevious = DockPanelLocation.Tray Then
        loc = itm.LocationPrefered
      End If
      ItemAdd(loc, itemKey)
    Else
      loc = itm.LocationCurrent
    End If
    PanelShow(itm.LocationCurrent)
    ItemSelect(itm)
    RaiseEvent PanelItemEvent(itm, DockPanelItemEventType.ItemOpened, Nothing)
  End Sub

  Public Sub PanelFocus(dockLocation As DockPanelLocation)
    For Each panelLocation As DockPanelLocation In [Enum].GetValues(GetType(DockPanelLocation))
      If IsDockableLocation(panelLocation) Then
        RegistryPanels.Item(panelLocation).PanelHasFocus = dockLocation.Equals(panelLocation)
      End If
    Next
  End Sub

  Public Sub PanelHide(dockLocation As DockPanelLocation)
#If TRACE Then
    Logger.debugPrint("DockPanelManager.PanelHide(dockLocation=[{0}])", dockLocation)
#End If
    PanelVisible(dockLocation, False)
  End Sub

  Public Function PanelIsVisible(dockLocation As DockPanelLocation) As Boolean
    Return RegistryPanels(dockLocation).Visible
  End Function

  Public Sub PanelShow(dockLocation As DockPanelLocation)
#If TRACE Then
    Logger.debugPrint("DockPanelManager.PanelShow(dockLocation=[{0}])", dockLocation.ToString)
#End If
    PanelVisible(dockLocation, True)
  End Sub

  Public Sub PanelVisible(dockLocation As DockPanelLocation, isVisible As Boolean)
#If TRACE Then
    Logger.debugPrint("DockPanelManager.PanelVisible(panelLocation=[{0},{1}])", dockLocation.ToString, isVisible)
#End If
    Select Case dockLocation
      Case DockPanelLocation.LeftTop
        ManageSplitters_PanelLeft(isVisible, PnlLeftBottom.Visible)
      Case DockPanelLocation.LeftBottom
        ManageSplitters_PanelLeft(PnlLeftTop.Visible, isVisible)
      Case DockPanelLocation.MiddleTopLeft
        ManageSplitters_PanelMiddle(isVisible, PnlMiddleRight.Visible, PnlMiddleBottom.Visible)
      Case DockPanelLocation.MiddleTopRight
        ManageSplitters_PanelMiddle(PnlMiddleLeft.Visible, isVisible, PnlMiddleBottom.Visible)
      Case DockPanelLocation.MiddleBottom
        ManageSplitters_PanelMiddle(PnlMiddleLeft.Visible, PnlMiddleRight.Visible, isVisible)
      Case DockPanelLocation.RightTop
        ManageSplitters_PanelRight(isVisible, PnlRightBottom.Visible)
      Case DockPanelLocation.RightBottom
        ManageSplitters_PanelRight(PnlRightTop.Visible, isVisible)
    End Select
  End Sub

  Public Sub SettingsLoad()
    For Each key As String In RegistryDelegates.Keys
      Dim prop As String = key + "_LOC"
      Dim loc As DockPanelLocation = DockPanelLocation.Tray
      Try
#If TRACE Then
        Logger.debugPrint("DockPanelManager.SettingsLoad: {0}=[{1}]", prop, My.Settings.Item(prop))
#End If
        loc = CType(My.Settings.Item(prop), DockPanelLocation)
      Catch ex As Exception
#If TRACE Then
        Logger.debugPrint("DockPanelManager.SettingsLoad: {0}=[{1}]", prop, "FAILED")
#End If
        loc = DockPanelLocation.Tray
      End Try
      If loc <> DockPanelLocation.Tray Then
        ItemAdd(loc, key)
      End If
    Next
    PanelVisible(DockPanelLocation.MiddleTopLeft, My.Settings.UI_ML_VIS)
    PanelVisible(DockPanelLocation.MiddleTopRight, My.Settings.UI_MR_VIS)
    PanelVisible(DockPanelLocation.MiddleBottom, My.Settings.UI_MB_VIS)
    PnlMiddleRight.Width = My.Settings.UI_MR_WIDTH
    PnlMiddleBottom.Height = My.Settings.UI_MB_HEIGHT

    PanelVisible(DockPanelLocation.LeftTop, My.Settings.UI_LT_VIS)
    PanelVisible(DockPanelLocation.LeftBottom, My.Settings.UI_LB_VIS)
    PnlLeft.Width = My.Settings.UI_L_WIDTH
    PnlLeftTop.Height = My.Settings.UI_LT_HEIGHT

    PanelVisible(DockPanelLocation.RightTop, My.Settings.UI_RT_VIS)
    PanelVisible(DockPanelLocation.RightBottom, My.Settings.UI_RB_VIS)
    PnlRight.Width = My.Settings.UI_R_WIDTH
    PnlRightTop.Height = My.Settings.UI_RT_HEIGHT

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
    'Clean up any assigned items to hidden Tabs
    For Each key As String In RegistryItems.Keys
      Dim itm As DockPanelItem = RegistryItems(key)
      If IsDockableLocation(itm.LocationCurrent) Then
        Dim Pnl As DockPanel = RegistryPanels(itm.LocationCurrent)
        If Not Pnl.Visible Then
          Pnl.ItemRemove(key)
        End If
      End If
    Next
    PanelFocus(DockPanelLocation.MiddleTopLeft)
  End Sub

  Public Sub SettingsSave()
    For Each key As String In RegistryItems.Keys
      Try
        My.Settings.Item(key + "_LOC") = CInt(RegistryItems(key).LocationCurrent)
#If TRACE Then
        Logger.debugPrint("DockPanelManager.SettingsSave: {0}=[{1}]", key + "_LOC", CInt(RegistryItems(key).LocationCurrent))
#End If
      Catch ex As Exception
#If TRACE Then
        Logger.debugPrint("DockPanelManager.SettingsSave: {0}=[{1}]", key + "_LOC", "FAILED")
#End If
      End Try
    Next
    My.Settings.UI_MR_WIDTH = PnlMiddleRight.Width
    My.Settings.UI_MB_HEIGHT = PnlMiddleBottom.Height
    My.Settings.UI_ML_VIS = PnlMiddleLeft.Visible
    My.Settings.UI_MR_VIS = PnlMiddleRight.Visible
    My.Settings.UI_MB_VIS = PnlMiddleBottom.Visible

    My.Settings.UI_L_WIDTH = PnlLeft.Width
    My.Settings.UI_LT_HEIGHT = PnlLeftTop.Height
    My.Settings.UI_LT_VIS = PnlLeftTop.Visible
    My.Settings.UI_LB_VIS = PnlLeftBottom.Visible

    My.Settings.UI_R_WIDTH = PnlRight.Width
    My.Settings.UI_RT_HEIGHT = PnlRightTop.Height
    My.Settings.UI_RT_VIS = PnlRightTop.Visible
    My.Settings.UI_RB_VIS = PnlRightBottom.Visible

  End Sub

End Class