Public Class DockPanelManager
  Inherits System.Windows.Forms.UserControl

  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  Private components As System.ComponentModel.IContainer
  Private WithEvents pnlMain As Panel
  Private WithEvents pnlMiddle As Panel
  Private WithEvents pnlMiddleTop As Panel
  Private WithEvents pnlMiddleLeft As Panel
  Private WithEvents splitMiddleLeftRight As Splitter
  Private WithEvents pnlMiddleRight As Panel
  Private WithEvents splitMiddleBottom As Splitter
  Private WithEvents pnlMiddleBottom As Panel
  Private WithEvents splitLeft As Splitter
  Private WithEvents pnlLeft As Panel
  Private WithEvents pnlLeftBottom As Panel
  Private WithEvents splitLeftTopBottom As Splitter
  Private WithEvents pnlLeftTop As Panel
  Private WithEvents splitRight As Splitter
  Private WithEvents pnlRight As Panel
  Private WithEvents pnlRightBottom As Panel
  Private WithEvents splitRightTopBottom As Splitter
  Private WithEvents pnlRightTop As Panel
  Private WithEvents DockMiddleLeftTop As DockPanel
  Private WithEvents DockMiddleTopRight As DockPanel
  Private WithEvents DockMiddleBottom As DockPanel
  Private WithEvents DockLeftBottom As DockPanel
  Private WithEvents DockLeftTop As DockPanel
  Private WithEvents DockRightBottom As DockPanel
  Private WithEvents DockRightTop As DockPanel

  Private theme As UITheme = UITheme.GetInstance

  Public Sub New()
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
    '
    'pnlMain
    '
    pnlMain.BackColor = System.Drawing.Color.Black
    pnlMain.Controls.Add(pnlMiddle)
    pnlMain.Controls.Add(splitLeft)
    pnlMain.Controls.Add(pnlLeft)
    pnlMain.Controls.Add(splitRight)
    pnlMain.Controls.Add(pnlRight)
    pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
    pnlMain.ForeColor = System.Drawing.Color.WhiteSmoke
    pnlMain.Location = New System.Drawing.Point(0, 0)
    pnlMain.Margin = New System.Windows.Forms.Padding(0)
    pnlMain.Name = "pnlMain"
    pnlMain.Padding = New System.Windows.Forms.Padding(4)
    pnlMain.Size = New System.Drawing.Size(637, 378)
    pnlMain.TabIndex = 10
    '
    'pnlMiddle
    '
    pnlMiddle.Controls.Add(pnlMiddleTop)
    pnlMiddle.Controls.Add(splitMiddleBottom)
    pnlMiddle.Controls.Add(pnlMiddleBottom)
    pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill
    pnlMiddle.Location = New System.Drawing.Point(214, 4)
    pnlMiddle.Name = "pnlMiddle"
    pnlMiddle.Size = New System.Drawing.Size(215, 370)
    pnlMiddle.TabIndex = 13
    '
    'pnlMiddleTop
    '
    pnlMiddleTop.Controls.Add(pnlMiddleLeft)
    pnlMiddleTop.Controls.Add(splitMiddleLeftRight)
    pnlMiddleTop.Controls.Add(pnlMiddleRight)
    pnlMiddleTop.Dock = System.Windows.Forms.DockStyle.Fill
    pnlMiddleTop.Location = New System.Drawing.Point(0, 0)
    pnlMiddleTop.Name = "pnlMiddleTop"
    pnlMiddleTop.Size = New System.Drawing.Size(215, 295)
    pnlMiddleTop.TabIndex = 0
    '
    'pnlMiddleLeft
    '
    pnlMiddleLeft.BackColor = System.Drawing.Color.Black
    pnlMiddleLeft.Controls.Add(DockMiddleLeftTop)
    pnlMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill
    pnlMiddleLeft.Location = New System.Drawing.Point(0, 0)
    pnlMiddleLeft.Name = "pnlMiddleLeft"
    pnlMiddleLeft.Size = New System.Drawing.Size(96, 295)
    pnlMiddleLeft.TabIndex = 4
    '
    'DockMiddleLeftTop
    '
    DockMiddleLeftTop.Dock = System.Windows.Forms.DockStyle.Fill
    DockMiddleLeftTop.PanelType = DockPanelType.Tab
    DockMiddleLeftTop.Location = New System.Drawing.Point(0, 0)
    DockMiddleLeftTop.Margin = New System.Windows.Forms.Padding(0)
    DockMiddleLeftTop.Name = "DockMiddleLeftTop"

    '
    'splitMiddleLeftRight
    '
    splitMiddleLeftRight.Dock = System.Windows.Forms.DockStyle.Right
    splitMiddleLeftRight.Location = New System.Drawing.Point(96, 0)
    splitMiddleLeftRight.Name = "splitMiddleLeftRight"
    splitMiddleLeftRight.Size = New System.Drawing.Size(4, 295)
    splitMiddleLeftRight.TabIndex = 6
    splitMiddleLeftRight.TabStop = False
    '
    'pnlMiddleRight
    '
    pnlMiddleRight.BackColor = System.Drawing.Color.Black
    pnlMiddleRight.Controls.Add(DockMiddleTopRight)
    pnlMiddleRight.Dock = System.Windows.Forms.DockStyle.Right
    pnlMiddleRight.Location = New System.Drawing.Point(100, 0)
    pnlMiddleRight.Name = "pnlMiddleRight"
    pnlMiddleRight.Size = New System.Drawing.Size(115, 295)
    pnlMiddleRight.TabIndex = 5
    '
    'DockMiddleTopRight
    '
    DockMiddleTopRight.Dock = System.Windows.Forms.DockStyle.Fill
    DockMiddleTopRight.PanelType = DockPanelType.Tab
    DockMiddleTopRight.Location = New System.Drawing.Point(0, 0)
    DockMiddleTopRight.Margin = New System.Windows.Forms.Padding(0)
    DockMiddleTopRight.Name = "DockMiddleTopRight"

    '
    'splitMiddleBottom
    '
    splitMiddleBottom.Dock = System.Windows.Forms.DockStyle.Bottom
    splitMiddleBottom.Location = New System.Drawing.Point(0, 295)
    splitMiddleBottom.Name = "splitMiddleBottom"
    splitMiddleBottom.Size = New System.Drawing.Size(215, 4)
    splitMiddleBottom.TabIndex = 15
    splitMiddleBottom.TabStop = False
    '
    'pnlMiddleBottom
    '
    pnlMiddleBottom.BackColor = System.Drawing.Color.Black
    pnlMiddleBottom.Controls.Add(DockMiddleBottom)
    pnlMiddleBottom.Dock = System.Windows.Forms.DockStyle.Bottom
    pnlMiddleBottom.Location = New System.Drawing.Point(0, 299)
    pnlMiddleBottom.Name = "pnlMiddleBottom"
    pnlMiddleBottom.Size = New System.Drawing.Size(215, 71)
    pnlMiddleBottom.TabIndex = 12
    '
    'DockMiddleBottom
    '
    DockMiddleBottom.Dock = System.Windows.Forms.DockStyle.Fill
    DockMiddleBottom.Location = New System.Drawing.Point(0, 0)
    DockMiddleBottom.Margin = New System.Windows.Forms.Padding(0)
    DockMiddleBottom.Name = "DockMiddleBottom"
    '
    'splitLeft
    '
    splitLeft.Location = New System.Drawing.Point(210, 4)
    splitLeft.Name = "splitLeft"
    splitLeft.Size = New System.Drawing.Size(4, 370)
    splitLeft.TabIndex = 10
    splitLeft.TabStop = False
    '
    'pnlLeft
    '
    pnlLeft.Controls.Add(pnlLeftBottom)
    pnlLeft.Controls.Add(splitLeftTopBottom)
    pnlLeft.Controls.Add(pnlLeftTop)
    pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
    pnlLeft.Location = New System.Drawing.Point(4, 4)
    pnlLeft.Name = "pnlLeft"
    pnlLeft.Size = New System.Drawing.Size(206, 370)
    pnlLeft.TabIndex = 9
    '
    'pnlLeftBottom
    '
    pnlLeftBottom.BackColor = System.Drawing.Color.Black
    pnlLeftBottom.Controls.Add(DockLeftBottom)
    pnlLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill
    pnlLeftBottom.Location = New System.Drawing.Point(0, 153)
    pnlLeftBottom.Name = "pnlLeftBottom"
    pnlLeftBottom.Size = New System.Drawing.Size(206, 217)
    pnlLeftBottom.TabIndex = 2
    '
    'DockLeftBottom
    '
    DockLeftBottom.BackColor = System.Drawing.Color.Black
    DockLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill
    DockLeftBottom.Location = New System.Drawing.Point(0, 0)
    DockLeftBottom.Margin = New System.Windows.Forms.Padding(0)
    DockLeftBottom.Name = "DockLeftBottom"
    '
    'splitLeftTopBottom
    '
    splitLeftTopBottom.Dock = System.Windows.Forms.DockStyle.Top
    splitLeftTopBottom.Location = New System.Drawing.Point(0, 149)
    splitLeftTopBottom.Name = "splitLeftTopBottom"
    splitLeftTopBottom.Size = New System.Drawing.Size(206, 4)
    splitLeftTopBottom.TabIndex = 3
    splitLeftTopBottom.TabStop = False
    '
    'pnlLeftTop
    '
    pnlLeftTop.BackColor = System.Drawing.Color.Black
    pnlLeftTop.Controls.Add(DockLeftTop)
    pnlLeftTop.Dock = System.Windows.Forms.DockStyle.Top
    pnlLeftTop.Location = New System.Drawing.Point(0, 0)
    pnlLeftTop.Name = "pnlLeftTop"
    pnlLeftTop.Size = New System.Drawing.Size(206, 149)
    pnlLeftTop.TabIndex = 1
    '
    'DockLeftTop
    '
    DockLeftTop.Dock = System.Windows.Forms.DockStyle.Fill
    DockLeftTop.Location = New System.Drawing.Point(0, 0)
    DockLeftTop.Margin = New System.Windows.Forms.Padding(0)
    DockLeftTop.Name = "DockLeftTop"
    '
    'splitRight
    '
    splitRight.Dock = System.Windows.Forms.DockStyle.Right
    splitRight.Location = New System.Drawing.Point(429, 4)
    splitRight.Name = "splitRight"
    splitRight.Size = New System.Drawing.Size(4, 370)
    splitRight.TabIndex = 14
    splitRight.TabStop = False
    '
    'pnlRight
    '
    pnlRight.Controls.Add(pnlRightBottom)
    pnlRight.Controls.Add(splitRightTopBottom)
    pnlRight.Controls.Add(pnlRightTop)
    pnlRight.Dock = System.Windows.Forms.DockStyle.Right
    pnlRight.Location = New System.Drawing.Point(433, 4)
    pnlRight.Name = "pnlRight"
    pnlRight.Size = New System.Drawing.Size(200, 370)
    pnlRight.TabIndex = 11
    '
    'pnlRightBottom
    '
    pnlRightBottom.BackColor = System.Drawing.Color.Black
    pnlRightBottom.Controls.Add(DockRightBottom)
    pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill
    pnlRightBottom.Location = New System.Drawing.Point(0, 156)
    pnlRightBottom.Name = "pnlRightBottom"
    pnlRightBottom.Size = New System.Drawing.Size(200, 214)
    pnlRightBottom.TabIndex = 1
    '
    'DockRightBottom
    '
    DockRightBottom.Dock = System.Windows.Forms.DockStyle.Fill
    DockRightBottom.Location = New System.Drawing.Point(0, 0)
    DockRightBottom.Margin = New System.Windows.Forms.Padding(0)
    DockRightBottom.Name = "DockRightBottom"
    '
    'splitRightTopBottom
    '
    splitRightTopBottom.Dock = System.Windows.Forms.DockStyle.Top
    splitRightTopBottom.Location = New System.Drawing.Point(0, 152)
    splitRightTopBottom.Name = "splitRightTopBottom"
    splitRightTopBottom.Size = New System.Drawing.Size(200, 4)
    splitRightTopBottom.TabIndex = 2
    splitRightTopBottom.TabStop = False
    '
    'pnlRightTop
    '
    pnlRightTop.BackColor = System.Drawing.Color.Black
    pnlRightTop.Controls.Add(DockRightTop)
    pnlRightTop.Dock = System.Windows.Forms.DockStyle.Top
    pnlRightTop.Location = New System.Drawing.Point(0, 0)
    pnlRightTop.Name = "pnlRightTop"
    pnlRightTop.Size = New System.Drawing.Size(200, 152)
    pnlRightTop.TabIndex = 0
    '
    'DockRightTop
    '
    DockRightTop.Dock = System.Windows.Forms.DockStyle.Fill
    DockRightTop.Location = New System.Drawing.Point(0, 0)
    DockRightTop.Margin = New System.Windows.Forms.Padding(0)
    DockRightTop.Name = "DockRightTop"
    '
    'DockPanelManager
    '
    AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
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
    LoadSettings()
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

    'Hide blank panels
    If getDockPanel(DockPanelLocation.LeftTop).Visible = False Then
      SetPanelVisibility(DockPanelLocation.LeftTop, False)
    End If
    If getDockPanel(DockPanelLocation.LeftBottom).Visible = False Then
      SetPanelVisibility(DockPanelLocation.LeftBottom, False)
    End If
    If getDockPanel(DockPanelLocation.MiddleTopRight).Visible = False Then
      SetPanelVisibility(DockPanelLocation.MiddleTopRight, False)
    End If
    If getDockPanel(DockPanelLocation.MiddleBottom).Visible = False Then
      SetPanelVisibility(DockPanelLocation.MiddleBottom, False)
    End If
    If getDockPanel(DockPanelLocation.RightBottom).Visible = False Then
      SetPanelVisibility(DockPanelLocation.RightBottom, False)
    End If
    If getDockPanel(DockPanelLocation.RightTop).Visible = False Then
      SetPanelVisibility(DockPanelLocation.RightTop, False)
    End If
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
