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

  Public Shared Sub RegisterPanel(panelType As PanelManagerPanelType, panelControl As Panel)
    Dim self As PanelManager = GetInstance()
    Debug.Print("PanelManager:  RegisterPanel({0})", panelControl.Name)

    Select Case panelType
      Case PanelManagerPanelType.ContainerLeftPanels
        self.L = panelControl
      Case PanelManagerPanelType.LeftTop
        self.LT = panelControl
      Case PanelManagerPanelType.LeftBottom
        self.LB = panelControl
      Case PanelManagerPanelType.MiddleTopLeft
        self.ML = panelControl
      Case PanelManagerPanelType.MiddleTopRight
        self.MR = panelControl
      Case PanelManagerPanelType.MiddleBottom
        self.MB = panelControl
      Case PanelManagerPanelType.ContainerRightPanels
        self.R = panelControl
      Case PanelManagerPanelType.RightTop
        self.RT = panelControl
      Case PanelManagerPanelType.RightBottom
        self.RB = panelControl
      Case Else
        Exit Sub
    End Select
    self.setPanelDefaults(panelControl)
  End Sub

  Private Sub setPanelDefaults(panelControl As Panel)
    Debug.Print("PanelManager:  setPanelDefaults")

    With panelControl
      .Margin = New Padding(0)
      .Padding = New Padding(0)
      .BackColor = Color.Black
      .ForeColor = Color.WhiteSmoke
    End With
  End Sub

  Public Shared Sub RegisterSplitter(splitterType As PanelManagerSplitterType, splitControl As Splitter)
    Dim self As PanelManager = GetInstance()
    Debug.Print("PanelManager:  RegisterSplitter({0})", splitControl.Name)
    Select Case splitterType
      Case PanelManagerSplitterType.SplitLeftAndMiddle
        self.SL = splitControl
      Case PanelManagerSplitterType.SplitLeftTopAndBottom
        self.SLTLB = splitControl
      Case PanelManagerSplitterType.SplitRightAndMiddle
        self.SR = splitControl
      Case PanelManagerSplitterType.SplitRightTopAndBottom
        self.SRTRB = splitControl
      Case PanelManagerSplitterType.SplitMiddleTopLeftAndTopRight
        self.SMLMR = splitControl
      Case PanelManagerSplitterType.SplitMiddleTopAndBottom
        self.SMLRMB = splitControl
    End Select
  End Sub

  Public Shared Sub ShowPanel(panelType As PanelManagerPanelType)
    SetPanelVisibility(panelType, True)
  End Sub

  Public Shared Sub HidePanel(panelType As PanelManagerPanelType)
    SetPanelVisibility(panelType, False)
  End Sub

  Public Shared Sub SetPanelVisibility(panelType As PanelManagerPanelType, pnlVisible As Boolean)
    If instance Is Nothing Then
      Throw New Exception("Attempted use of PanelManager before Initialized")
      Exit Sub
    End If
    instance.instanceSetPanelVisibility(panelType, pnlVisible)
  End Sub


  Private Sub instanceSetPanelVisibility(panelType As PanelManagerPanelType, pnlVisible As Boolean)
    Select Case panelType
      Case PanelManagerPanelType.LeftTop
        panelLeft(pnlVisible, LB.Visible)
      Case PanelManagerPanelType.LeftBottom
        panelLeft(LT.Visible, pnlVisible)
      Case PanelManagerPanelType.MiddleTopLeft
        panelMiddle(pnlVisible, MR.Visible, MB.Visible)
      Case PanelManagerPanelType.MiddleTopRight
        panelMiddle(ML.Visible, pnlVisible, MB.Visible)
      Case PanelManagerPanelType.MiddleBottom
        panelMiddle(ML.Visible, MR.Visible, pnlVisible)
      Case PanelManagerPanelType.RightTop
        panelRight(pnlVisible, RB.Visible)
      Case PanelManagerPanelType.RightBottom
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
