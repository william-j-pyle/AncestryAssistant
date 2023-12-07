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
  Private RegistryItems As Dictionary(Of String, DockItemRegistryEntry)
  Private RegistryPanels As Dictionary(Of DockPanelLocation, DockPanel)

#End Region

#Region "Public Constructors"

  Public Sub New()
    RegistryPanels = New Dictionary(Of DockPanelLocation, DockPanel)
    RegistryItems = New Dictionary(Of String, DockItemRegistryEntry)
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

  Private Sub ApplyFocus(panelLocation As DockPanelLocation, hasFocus As Boolean)
    RegistryPanels.Item(panelLocation).PanelHasFocus = hasFocus
  End Sub

  Private Function GetDockPanel(dockLocation As DockPanelLocation) As DockPanel
    Return RegistryPanels.Item(dockLocation)
  End Function

  Private Function GetItemRegistryEntry(key As String) As DockItemRegistryEntry
    Return RegistryItems.Item(key)
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

  Private Sub PanelCloseRequested(sender As DockPanel)
    SetPanelVisibility(sender.PanelLocation, False)
  End Sub

  Private Sub PanelFocusChanged(sender As DockPanel, hasFocus As Boolean)
    SetPanelFocus(sender.PanelLocation, hasFocus)
  End Sub

  Private Sub PanelItemClosed(sender As IDockPanelItem)
    Dim item As DockItemRegistryEntry = GetItemRegistryEntry(sender.Key)
    item.currentLocation = DockPanelLocation.Tray
  End Sub

  Private Sub PanelItemLocationChangeRequested(panelItem As IDockPanelItem, newPanelLocation As DockPanelLocation)
    Debug.Print("PanelItemLocationChange:  {0}(from:{1}, to:{2})", panelItem.Key, panelItem.ItemDockPanelLocation.ToString, newPanelLocation.ToString)
    Dim frmDock As DockPanel = RegistryPanels.Item(panelItem.ItemDockPanelLocation)
    Dim toDock As DockPanel = RegistryPanels.Item(newPanelLocation)
    Dim item As DockItemRegistryEntry = GetItemRegistryEntry(panelItem.Key)
    frmDock.RemoveItem(panelItem.Key)
    toDock.AddItem(panelItem)
    item.currentLocation = newPanelLocation
    ShowPanel(newPanelLocation)
    toDock.Focus()
    'SetPanelFocus(newPanelLocation, True)
  End Sub

  Private Sub RegisterDock(pnl As DockPanel)
    RegistryPanels.Add(pnl.PanelLocation, pnl)
    AddHandler pnl.PanelCloseRequested, AddressOf PanelCloseRequested
    AddHandler pnl.PanelFocusChanged, AddressOf PanelFocusChanged
    AddHandler pnl.PanelItemLocationChangeRequested, AddressOf PanelItemLocationChangeRequested
    AddHandler pnl.PanelItemClosed, AddressOf PanelItemClosed
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

  Public Function AddItem(dockLocation As DockPanelLocation, panelItemKey As String) As IDockPanelItem
    'Debug.Print("AddItem: {0}({1})", panelItemKey, dockLocation.ToString)
    Dim dockPnl As DockPanel = GetDockPanel(dockLocation)
    Dim item As DockItemRegistryEntry = GetItemRegistryEntry(panelItemKey)
    item.currentLocation = dockLocation
    dockPnl.AddItem(item.control)
    Return item.control
  End Function

  Public Function GetItem(key As String) As IDockPanelItem
    Return GetItemRegistryEntry(key).control
  End Function

  Public Sub HidePanel(panelType As DockPanelLocation)
    'Debug.Print("HidePanel: {0}", panelType.ToString)
    SetPanelVisibility(panelType, False)
  End Sub

  Public Function IsPanelVisible(panelLocation As DockPanelLocation) As Boolean
    Return GetDockPanel(panelLocation).Visible
  End Function

  Public Sub MoveItem(key As String, dockLocation As DockPanelLocation)
    Debug.Print("MoveItem: {0}({1})", key, dockLocation.ToString)
    Dim item As DockItemRegistryEntry = GetItemRegistryEntry(key)
    If item.control Is Nothing Then Exit Sub
    Dim dockPnl As DockPanel = GetDockPanel(dockLocation)
    If dockPnl IsNot Nothing Then
      Dim panelItem As IDockPanelItem = item.control
      panelItem.ItemDockPanelLocation = dockLocation
      dockPnl.AddItem(panelItem)
    End If
  End Sub

  Public Sub RegisterDockItem(item As DockItemRegistryEntry)
    RegistryItems.Add(item.key, item)
  End Sub

  Public Sub SelectItemTab(dockLocation As DockPanelLocation, tabIndex As Integer)
    Dim dockPnl As DockPanel = GetDockPanel(dockLocation)
    If dockPnl Is Nothing Then Exit Sub
    dockPnl.SelectItem(tabIndex)
  End Sub

  Public Sub SelectItemTab(dockLocation As DockPanelLocation, key As String)
    Dim dockPnl As DockPanel = GetDockPanel(dockLocation)
    If dockPnl Is Nothing Then Exit Sub
    dockPnl.SelectItem(key)
  End Sub

  Public Sub SetPanelFocus(panelLocation As DockPanelLocation, hasFocus As Boolean)
    Dim chk As DockPanelLocation
    Debug.Print("{0}:  hasFocus={1}", panelLocation.ToString, hasFocus)
    If hasFocus Then
      For loc As Integer = 0 To 6
        chk = CType(loc, DockPanelLocation)
        If chk <> panelLocation Then
          Debug.Print("RemoveFocus: {0}", chk.ToString)
          ApplyFocus(chk, False)
        End If
      Next
    End If
  End Sub

  Public Sub SetPanelVisibility(panelType As DockPanelLocation, pnlVisible As Boolean)
    Select Case panelType
      Case DockPanelLocation.LeftTop
        ManageSplitters_PanelLeft(pnlVisible, pnlLeftBottom.Visible)
      Case DockPanelLocation.LeftBottom
        ManageSplitters_PanelLeft(pnlLeftTop.Visible, pnlVisible)
      Case DockPanelLocation.MiddleTopLeft
        ManageSplitters_PanelMiddle(pnlVisible, pnlMiddleRight.Visible, pnlMiddleBottom.Visible)
      Case DockPanelLocation.MiddleTopRight
        ManageSplitters_PanelMiddle(pnlMiddleLeft.Visible, pnlVisible, pnlMiddleBottom.Visible)
      Case DockPanelLocation.MiddleBottom
        ManageSplitters_PanelMiddle(pnlMiddleLeft.Visible, pnlMiddleRight.Visible, pnlVisible)
      Case DockPanelLocation.RightTop
        ManageSplitters_PanelRight(pnlVisible, pnlRightBottom.Visible)
      Case DockPanelLocation.RightBottom
        ManageSplitters_PanelRight(pnlRightTop.Visible, pnlVisible)
    End Select
  End Sub

  Public Sub SettingsLoad()
    For Each key As String In RegistryItems.Keys
      Dim prop As String = key + "_LOC"
      Dim loc As DockPanelLocation = DockPanelLocation.Tray
      Try
        Debug.Print("LoadSetting: {0}({1})", prop, My.Settings.Item(prop))
        loc = My.Settings.Item(prop)
      Catch ex As Exception
        Debug.Print("LoadSetting: {0}({1})", prop, "FAILED")
        loc = DockPanelLocation.Tray
      End Try
      If loc <> DockPanelLocation.Tray Then
        AddItem(loc, key)
      End If
    Next
    SetPanelVisibility(DockPanelLocation.MiddleTopLeft, My.Settings.UI_ML_VIS)
    SetPanelVisibility(DockPanelLocation.MiddleTopRight, My.Settings.UI_MR_VIS)
    SetPanelVisibility(DockPanelLocation.MiddleBottom, My.Settings.UI_MB_VIS)
    pnlMiddleRight.Width = My.Settings.UI_MR_WIDTH
    pnlMiddleBottom.Height = My.Settings.UI_MB_HEIGHT

    SetPanelVisibility(DockPanelLocation.LeftTop, My.Settings.UI_LT_VIS)
    SetPanelVisibility(DockPanelLocation.LeftBottom, My.Settings.UI_LB_VIS)
    pnlLeft.Width = My.Settings.UI_L_WIDTH
    pnlLeftTop.Height = My.Settings.UI_LT_HEIGHT

    SetPanelVisibility(DockPanelLocation.RightTop, My.Settings.UI_RT_VIS)
    SetPanelVisibility(DockPanelLocation.RightBottom, My.Settings.UI_RB_VIS)
    pnlRight.Width = My.Settings.UI_R_WIDTH
    pnlRightTop.Height = My.Settings.UI_RT_HEIGHT

    'Hide blank panels
    If GetDockPanel(DockPanelLocation.LeftTop).Visible = False Then
      SetPanelVisibility(DockPanelLocation.LeftTop, False)
    End If
    If GetDockPanel(DockPanelLocation.LeftBottom).Visible = False Then
      SetPanelVisibility(DockPanelLocation.LeftBottom, False)
    End If
    If GetDockPanel(DockPanelLocation.MiddleTopRight).Visible = False Then
      SetPanelVisibility(DockPanelLocation.MiddleTopRight, False)
    End If
    If GetDockPanel(DockPanelLocation.MiddleBottom).Visible = False Then
      SetPanelVisibility(DockPanelLocation.MiddleBottom, False)
    End If
    If GetDockPanel(DockPanelLocation.RightBottom).Visible = False Then
      SetPanelVisibility(DockPanelLocation.RightBottom, False)
    End If
    If GetDockPanel(DockPanelLocation.RightTop).Visible = False Then
      SetPanelVisibility(DockPanelLocation.RightTop, False)
    End If
    'Clean up any assigned items to hidden tabs
    For Each key As String In RegistryItems.Keys
      Dim itm As DockItemRegistryEntry = GetItemRegistryEntry(key)
      If itm.currentLocation <> DockPanelLocation.Tray Then
        Dim pnl As DockPanel = GetDockPanel(itm.currentLocation)
        If Not pnl.Visible Then
          pnl.RemoveItem(itm.control.Key)
        End If
      End If
    Next
    SetPanelFocus(DockPanelLocation.MiddleTopLeft, True)
  End Sub

  Public Sub SettingsSave()
    For Each key As String In RegistryItems.Keys
      Try
        Debug.Print("SaveSetting: {0}({1})", key + "_LOC", CInt(RegistryItems(key).currentLocation))
        My.Settings.Item(key + "_LOC") = CInt(RegistryItems(key).currentLocation)
      Catch ex As Exception
        Debug.Print("SaveSetting: {0}({1})", key + "_LOC", "FAILED")
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

  Public Sub ShowPanel(panelType As DockPanelLocation)
    SetPanelVisibility(panelType, True)
  End Sub

  Public Sub ShowRegisteredItem(itemKey As String)
    Dim itm As DockItemRegistryEntry = GetItemRegistryEntry(itemKey)
    If itm.currentLocation = DockPanelLocation.Tray Then
      AddItem(itm.defaultLocation, itemKey)
    End If
    SetPanelVisibility(itm.currentLocation, True)
    SelectItemTab(itm.currentLocation, itm.key)
    SetPanelFocus(itm.currentLocation, True)
  End Sub

#End Region

End Class