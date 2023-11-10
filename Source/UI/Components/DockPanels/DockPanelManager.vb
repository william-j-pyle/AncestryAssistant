Public Class DockPanelManager


  Public Sub New()
    InitializeComponent()
    If DesignMode Then
      pnlMiddleLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
      pnlMiddleRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
      pnlMiddleBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
      pnlLeftBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
      pnlLeftTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
      pnlRightBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
      pnlRightTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
    End If

  End Sub

  Private Function getDockPanel(dockLocation As DockPanelLocation) As DockPanel
    Dim dockPnl As DockPanel = Nothing
    Select Case dockLocation
      Case DockPanelLocation.LeftTop
        dockPnl = DockLeftTop
      Case DockPanelLocation.LeftBottom
        dockPnl = DockLeftBottom
      Case DockPanelLocation.MiddleTopLeft
        dockPnl = DockMiddleLeftTop
      Case DockPanelLocation.MiddleTopRight
        dockPnl = DockMiddleTopRight
      Case DockPanelLocation.MiddleBottom
        dockPnl = DockMiddleBottom
      Case DockPanelLocation.RightTop
        dockPnl = DockRightTop
      Case DockPanelLocation.RightBottom
        dockPnl = DockRightBottom
    End Select
    Return dockPnl
  End Function

  Public Function AddItem(dockLocation As DockPanelLocation, panelItem As IDockPanelItem) As IDockPanelItem
    Dim dockPnl As DockPanel = getDockPanel(dockLocation)
    If dockPnl IsNot Nothing Then
      With panelItem
        .ItemDockStyle = DockStyle.Fill
        '.PanelShowClose = True
        '.PanelShowSearch = False
        '.PanelShowPinned = True
        '.PanelShowContextMenu = False
        '.PanelHasFocus = False
        '.PanelIsPinned = True
        '.PanelBackColor = Color.Black
        '.PanelBorderColor = Color.DimGray
        '.PanelFontColor = Color.WhiteSmoke
        '.PanelHighlightColor = Color.LimeGreen
        '.PanelShadowColor = ColorToShadow(Color.DimGray)
        '.PanelAccentColor = ColorToAccent(Color.DimGray)
      End With
      dockPnl.AddItem(panelItem)
      Return panelItem
    End If
    Return Nothing
  End Function

  Public Sub LoadSettings()
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
  End Sub

  Public Sub SaveSettings()
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

  Public Sub HidePanel(panelType As DockPanelLocation)
    SetPanelVisibility(panelType, False)
  End Sub


  Public Sub SetPanelVisibility(panelType As DockPanelLocation, pnlVisible As Boolean)
    Select Case panelType
      Case DockPanelLocation.LeftTop
        panelLeft(pnlVisible, pnlLeftBottom.Visible)
      Case DockPanelLocation.LeftBottom
        panelLeft(pnlLeftTop.Visible, pnlVisible)
      Case DockPanelLocation.MiddleTopLeft
        panelMiddle(pnlVisible, pnlMiddleRight.Visible, pnlMiddleBottom.Visible)
      Case DockPanelLocation.MiddleTopRight
        panelMiddle(pnlMiddleLeft.Visible, pnlVisible, pnlMiddleBottom.Visible)
      Case DockPanelLocation.MiddleBottom
        panelMiddle(pnlMiddleLeft.Visible, pnlMiddleRight.Visible, pnlVisible)
      Case DockPanelLocation.RightTop
        panelRight(pnlVisible, pnlRightBottom.Visible)
      Case DockPanelLocation.RightBottom
        panelRight(pnlRightTop.Visible, pnlVisible)
    End Select
  End Sub

  Private Sub panelRight(topVis As Boolean, botVis As Boolean)
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

  Private Sub panelLeft(topVis As Boolean, botVis As Boolean)
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



  Private Sub panelMiddle(leftVis As Boolean, rightVis As Boolean, bottomVis As Boolean)
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

  Private Sub DockLeftBottom_PanelCloseRequested(sender As DockPanel) Handles DockLeftBottom.PanelCloseRequested
    SetPanelVisibility(DockPanelLocation.LeftBottom, False)

  End Sub

  Private Sub DockLeftTop_PanelCloseRequested(sender As DockPanel) Handles DockLeftTop.PanelCloseRequested
    SetPanelVisibility(DockPanelLocation.LeftTop, False)

  End Sub

  Private Sub DockMiddleBottom_PanelCloseRequested(sender As DockPanel) Handles DockMiddleBottom.PanelCloseRequested
    SetPanelVisibility(DockPanelLocation.MiddleBottom, False)

  End Sub

  Private Sub DockMiddleTopRight_PanelCloseRequested(sender As DockPanel) Handles DockMiddleTopRight.PanelCloseRequested
    SetPanelVisibility(DockPanelLocation.MiddleTopRight, False)

  End Sub

  Private Sub DockMiddleLeftTop_PanelCloseRequested(sender As DockPanel) Handles DockMiddleLeftTop.PanelCloseRequested
    SetPanelVisibility(DockPanelLocation.MiddleTopLeft, False)

  End Sub

  Private Sub DockRightBottom_PanelCloseRequested(sender As DockPanel) Handles DockRightBottom.PanelCloseRequested
    SetPanelVisibility(DockPanelLocation.RightBottom, False)

  End Sub

  Private Sub DockRightTop_PanelCloseRequested(sender As DockPanel) Handles DockRightTop.PanelCloseRequested
    SetPanelVisibility(DockPanelLocation.RightTop, False)
  End Sub

  Public Sub SetPanelFocus(panelLocation As DockPanelLocation, hasFocus As Boolean)
    Dim chk As DockPanelLocation
    If hasFocus Then
      For loc As Integer = 0 To 6
        chk = CType(loc, DockPanelLocation)
        If chk <> panelLocation Then
          ApplyFocus(chk, False)
        End If
      Next
    End If
  End Sub

  Private Sub ApplyFocus(panelLocation As DockPanelLocation, hasFocus As Boolean)
    Select Case panelLocation
      Case DockPanelLocation.LeftTop
        DockLeftTop.PanelHasFocus = hasFocus
      Case DockPanelLocation.LeftBottom
        DockLeftBottom.PanelHasFocus = hasFocus
      Case DockPanelLocation.MiddleTopLeft
        DockMiddleLeftTop.PanelHasFocus = hasFocus
      Case DockPanelLocation.MiddleTopRight
        DockMiddleTopRight.PanelHasFocus = hasFocus
      Case DockPanelLocation.MiddleBottom
        DockMiddleBottom.PanelHasFocus = hasFocus
      Case DockPanelLocation.RightTop
        DockRightTop.PanelHasFocus = hasFocus
      Case DockPanelLocation.RightBottom
        DockRightBottom.PanelHasFocus = hasFocus
    End Select
  End Sub

  Private Sub DockLeftBottom_PanelFocusChanged(sender As DockPanel, hasFocus As Boolean) Handles DockLeftBottom.PanelFocusChanged
    SetPanelFocus(DockPanelLocation.LeftBottom, hasFocus)

  End Sub

  Private Sub DockLeftTop_PanelFocusChanged(sender As DockPanel, hasFocus As Boolean) Handles DockLeftTop.PanelFocusChanged
    SetPanelFocus(DockPanelLocation.LeftTop, hasFocus)

  End Sub

  Private Sub DockMiddleBottom_PanelFocusChanged(sender As DockPanel, hasFocus As Boolean) Handles DockMiddleBottom.PanelFocusChanged
    SetPanelFocus(DockPanelLocation.MiddleBottom, hasFocus)

  End Sub

  Private Sub DockMiddleLeftTop_PanelFocusChanged(sender As DockPanel, hasFocus As Boolean) Handles DockMiddleLeftTop.PanelFocusChanged
    SetPanelFocus(DockPanelLocation.MiddleTopLeft, hasFocus)

  End Sub

  Private Sub DockMiddleTopRight_PanelFocusChanged(sender As DockPanel, hasFocus As Boolean) Handles DockMiddleTopRight.PanelFocusChanged
    SetPanelFocus(DockPanelLocation.MiddleTopRight, hasFocus)

  End Sub

  Private Sub DockRightBottom_PanelFocusChanged(sender As DockPanel, hasFocus As Boolean) Handles DockRightBottom.PanelFocusChanged
    SetPanelFocus(DockPanelLocation.RightBottom, hasFocus)

  End Sub

  Private Sub DockRightTop_PanelFocusChanged(sender As DockPanel, hasFocus As Boolean) Handles DockRightTop.PanelFocusChanged
    SetPanelFocus(DockPanelLocation.RightTop, hasFocus)

  End Sub
End Class
