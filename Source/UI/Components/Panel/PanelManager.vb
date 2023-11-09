Public Class PanelManager
  Shared instance As PanelManager

  'Panels

  Private WithEvents LT As Panel
  Private WithEvents SLTLB As Splitter
  Private WithEvents LB As Panel
  Private L As Panel
  Private WithEvents SL As Splitter

  Private WithEvents ML As Panel
  Private WithEvents SMLMR As Splitter
  Private WithEvents MR As Panel
  Private WithEvents SMLRMB As Splitter
  Private WithEvents MB As Panel

  Private WithEvents SR As Splitter
  Private R As Panel
  Private WithEvents RT As Panel
  Private WithEvents SRTRB As Splitter
  Private WithEvents RB As Panel


  Private RT_HEIGHT As Integer



  Private Sub New()
    'NOOP
  End Sub

  Public Shared Function GetInstance() As PanelManager

    If instance Is Nothing Then
      instance = New PanelManager()
      Debug.Print("PanelManager:  GetInstance.NEW")
    Else
      Debug.Print("PanelManager:  GetInstance")
    End If
    Return instance
  End Function

  Private Function getPanel(panelLocation As DockPanelLocation) As Panel
    Dim pnl As Panel = Nothing
    Select Case panelLocation
      Case DockPanelLocation.ContainerLeftPanels
        pnl = L
      Case DockPanelLocation.LeftTop
        pnl = LT
      Case DockPanelLocation.LeftBottom
        pnl = LB
      Case DockPanelLocation.MiddleTopLeft
        pnl = ML
      Case DockPanelLocation.MiddleTopRight
        pnl = MR
      Case DockPanelLocation.MiddleBottom
        pnl = MB
      Case DockPanelLocation.ContainerRightPanels
        pnl = R
      Case DockPanelLocation.RightTop
        pnl = RT
      Case DockPanelLocation.RightBottom
        pnl = RB
    End Select
    Return pnl
  End Function

  Private Function IAddItem(panelLocation As DockPanelLocation, panelItem As IDockPanelItem) As IDockPanelItem
    Dim pnl As Panel = getPanel(panelLocation)
    If pnl IsNot Nothing Then
      If pnl.Controls.Count = 1 Then
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
        With CType(pnl.Controls(0), IDockPanel)
          .AddItem(panelItem)
        End With
        Return panelItem
      End If
    End If
    Return Nothing
  End Function

  Public Shared Function AddItem(panelLocation As DockPanelLocation, panelItem As IDockPanelItem) As IDockPanelItem
    Return GetInstance().IAddItem(panelLocation, panelItem)
  End Function

  Public Shared Sub RegisterPanel(panelLocation As DockPanelLocation, panelControl As Panel, Optional panelType As DockPanelType = DockPanelType.None)
    Dim self As PanelManager = GetInstance()
    Debug.Print("PanelManager:  RegisterPanel({0})", panelControl.Name)

    Select Case panelLocation
      Case DockPanelLocation.ContainerLeftPanels
        self.L = panelControl
      Case DockPanelLocation.LeftTop
        self.LT = panelControl
      Case DockPanelLocation.LeftBottom
        self.LB = panelControl
      Case DockPanelLocation.MiddleTopLeft
        self.ML = panelControl
      Case DockPanelLocation.MiddleTopRight
        self.MR = panelControl
      Case DockPanelLocation.MiddleBottom
        self.MB = panelControl
      Case DockPanelLocation.ContainerRightPanels
        self.R = panelControl
      Case DockPanelLocation.RightTop
        self.RT = panelControl
      Case DockPanelLocation.RightBottom
        self.RB = panelControl
      Case Else
        Exit Sub
    End Select

    With panelControl
      .Margin = New Padding(0)
      .Padding = New Padding(0)
      .BackColor = Color.Black
      .ForeColor = Color.WhiteSmoke
    End With

    Dim ctl As IDockPanel
    Select Case panelType
      Case DockPanelType.Panel
        Dim bCtl As DockPanel = New DockPanel()
        bCtl.Dock = DockStyle.Fill
        ctl = bCtl
      Case DockPanelType.Tab
        Dim bCtl As DockTopTabs = New DockTopTabs()
        bCtl.Dock = DockStyle.Fill
        ctl = bCtl
      Case Else
        Exit Sub
    End Select

    With ctl
      .PanelShowClose = True
      .PanelShowSearch = False
      .PanelShowPinned = True
      .PanelShowContextMenu = False
      .PanelHasFocus = False
      .PanelIsPinned = True
      .PanelBackColor = Color.Black
      .PanelBorderColor = Color.DimGray
      .PanelFontColor = Color.WhiteSmoke
      .PanelHighlightColor = Color.LimeGreen
      .PanelShadowColor = ColorToShadow(Color.DimGray)
      .PanelAccentColor = ColorToAccent(Color.DimGray)
    End With

    panelControl.Controls.Add(CType(ctl, Control))

  End Sub


  Public Shared Sub RegisterSplitter(splitterType As DockPanelSplitterPlacement, splitControl As Splitter)
    Dim self As PanelManager = GetInstance()
    Debug.Print("PanelManager:  RegisterSplitter({0})", splitControl.Name)
    Select Case splitterType
      Case DockPanelSplitterPlacement.SplitLeftAndMiddle
        self.SL = splitControl
      Case DockPanelSplitterPlacement.SplitLeftTopAndBottom
        self.SLTLB = splitControl
      Case DockPanelSplitterPlacement.SplitRightAndMiddle
        self.SR = splitControl
      Case DockPanelSplitterPlacement.SplitRightTopAndBottom
        self.SRTRB = splitControl
      Case DockPanelSplitterPlacement.SplitMiddleTopLeftAndTopRight
        self.SMLMR = splitControl
      Case DockPanelSplitterPlacement.SplitMiddleTopAndBottom
        self.SMLRMB = splitControl
    End Select
  End Sub

  Public Shared Sub ShowPanel(panelType As DockPanelLocation)
    SetPanelVisibility(panelType, True)
  End Sub

  Public Shared Sub HidePanel(panelType As DockPanelLocation)
    SetPanelVisibility(panelType, False)
  End Sub

  Public Shared Sub SetPanelVisibility(panelType As DockPanelLocation, pnlVisible As Boolean)
    If instance Is Nothing Then
      Throw New Exception("Attempted use of PanelManager before Initialized")
      Exit Sub
    End If
    instance.instanceSetPanelVisibility(panelType, pnlVisible)
  End Sub


  Private Sub instanceSetPanelVisibility(panelType As DockPanelLocation, pnlVisible As Boolean)
    Select Case panelType
      Case DockPanelLocation.LeftTop
        panelLeft(pnlVisible, LB.Visible)
      Case DockPanelLocation.LeftBottom
        panelLeft(LT.Visible, pnlVisible)
      Case DockPanelLocation.MiddleTopLeft
        panelMiddle(pnlVisible, MR.Visible, MB.Visible)
      Case DockPanelLocation.MiddleTopRight
        panelMiddle(ML.Visible, pnlVisible, MB.Visible)
      Case DockPanelLocation.MiddleBottom
        panelMiddle(ML.Visible, MR.Visible, pnlVisible)
      Case DockPanelLocation.RightTop
        panelRight(pnlVisible, RB.Visible)
      Case DockPanelLocation.RightBottom
        panelRight(RT.Visible, pnlVisible)
    End Select
  End Sub

  Private Sub panelRight(topVis As Boolean, botVis As Boolean)
    If RT.Dock = DockStyle.Top Then
      RT.Tag = RT.Height
    End If
    If topVis And Not botVis Then
      RT.Dock = DockStyle.Fill
    End If
    If topVis And botVis And RT.Dock = DockStyle.Fill Then
      RT.Dock = DockStyle.Top
      RT.Height = CInt(RT.Tag)
    End If

    RT.Visible = topVis
    RB.Visible = botVis
    SR.Visible = topVis Or botVis
    SRTRB.Visible = topVis And botVis
    R.Visible = topVis Or botVis
  End Sub

  Private Sub panelLeft(topVis As Boolean, botVis As Boolean)
    If LT.Dock = DockStyle.Top Then
      LT.Tag = LT.Height
    End If
    If topVis And Not botVis Then
      LT.Dock = DockStyle.Fill
    End If
    If topVis And botVis And LT.Dock = DockStyle.Fill Then
      LT.Dock = DockStyle.Top
      LT.Height = CInt(LT.Tag)
    End If

    LT.Visible = topVis
    LB.Visible = botVis
    SL.Visible = topVis Or botVis
    SLTLB.Visible = topVis And botVis
    L.Visible = topVis Or botVis
  End Sub



  Private Sub panelMiddle(leftVis As Boolean, rightVis As Boolean, bottomVis As Boolean)
    If MR.Dock = DockStyle.Right Then
      MR.Tag = MR.Width
    End If
    If rightVis And Not leftVis Then
      MR.Dock = DockStyle.Fill
    End If
    If leftVis And rightVis And MR.Dock = DockStyle.Fill Then
      MR.Dock = DockStyle.Right
      MR.Width = CInt(MR.Tag)
    End If

    MB.Visible = bottomVis
    SMLRMB.Visible = bottomVis
    ML.Visible = leftVis
    MR.Visible = rightVis
    SMLMR.Visible = leftVis And rightVis
  End Sub

End Class
