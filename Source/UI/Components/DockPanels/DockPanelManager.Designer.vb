<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DockPanelManager
  Inherits System.Windows.Forms.UserControl

  'UserControl overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.pnlMain = New System.Windows.Forms.Panel()
    Me.pnlMiddle = New System.Windows.Forms.Panel()
    Me.pnlMiddleTop = New System.Windows.Forms.Panel()
    Me.pnlMiddleLeft = New System.Windows.Forms.Panel()
    Me.DockMiddleLeftTop = New AncestryAssistant.DockPanel()
    Me.splitMiddleLeftRight = New System.Windows.Forms.Splitter()
    Me.pnlMiddleRight = New System.Windows.Forms.Panel()
    Me.DockMiddleTopRight = New AncestryAssistant.DockPanel()
    Me.splitMiddleBottom = New System.Windows.Forms.Splitter()
    Me.pnlMiddleBottom = New System.Windows.Forms.Panel()
        Me.DockMiddleBottom = New AncestryAssistant.DockPanel()
        Me.splitLeft = New System.Windows.Forms.Splitter()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.pnlLeftBottom = New System.Windows.Forms.Panel()
        Me.DockLeftBottom = New AncestryAssistant.DockPanel()
        Me.splitLeftTopBottom = New System.Windows.Forms.Splitter()
        Me.pnlLeftTop = New System.Windows.Forms.Panel()
        Me.DockLeftTop = New AncestryAssistant.DockPanel()
        Me.splitRight = New System.Windows.Forms.Splitter()
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.pnlRightBottom = New System.Windows.Forms.Panel()
        Me.DockRightBottom = New AncestryAssistant.DockPanel()
        Me.splitRightTopBottom = New System.Windows.Forms.Splitter()
        Me.pnlRightTop = New System.Windows.Forms.Panel()
        Me.DockRightTop = New AncestryAssistant.DockPanel()
        Me.pnlMain.SuspendLayout()
        Me.pnlMiddle.SuspendLayout()
        Me.pnlMiddleTop.SuspendLayout()
        Me.pnlMiddleLeft.SuspendLayout()
        Me.DockMiddleLeftTop.SuspendLayout()
        Me.pnlMiddleRight.SuspendLayout()
        Me.DockMiddleTopRight.SuspendLayout()
        Me.pnlMiddleBottom.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.pnlLeftBottom.SuspendLayout()
        Me.pnlLeftTop.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.pnlRightBottom.SuspendLayout()
        Me.pnlRightTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.Black
        Me.pnlMain.Controls.Add(Me.pnlMiddle)
        Me.pnlMain.Controls.Add(Me.splitLeft)
        Me.pnlMain.Controls.Add(Me.pnlLeft)
        Me.pnlMain.Controls.Add(Me.splitRight)
        Me.pnlMain.Controls.Add(Me.pnlRight)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlMain.Size = New System.Drawing.Size(637, 378)
        Me.pnlMain.TabIndex = 10
        '
        'pnlMiddle
        '
        Me.pnlMiddle.Controls.Add(Me.pnlMiddleTop)
        Me.pnlMiddle.Controls.Add(Me.splitMiddleBottom)
        Me.pnlMiddle.Controls.Add(Me.pnlMiddleBottom)
        Me.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMiddle.Location = New System.Drawing.Point(214, 4)
        Me.pnlMiddle.Name = "pnlMiddle"
        Me.pnlMiddle.Size = New System.Drawing.Size(215, 370)
        Me.pnlMiddle.TabIndex = 13
        '
        'pnlMiddleTop
        '
        Me.pnlMiddleTop.Controls.Add(Me.pnlMiddleLeft)
        Me.pnlMiddleTop.Controls.Add(Me.splitMiddleLeftRight)
        Me.pnlMiddleTop.Controls.Add(Me.pnlMiddleRight)
        Me.pnlMiddleTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMiddleTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlMiddleTop.Name = "pnlMiddleTop"
        Me.pnlMiddleTop.Size = New System.Drawing.Size(215, 295)
        Me.pnlMiddleTop.TabIndex = 0
        '
        'pnlMiddleLeft
        '
        Me.pnlMiddleLeft.BackColor = System.Drawing.Color.Black
        Me.pnlMiddleLeft.Controls.Add(Me.DockMiddleLeftTop)
        Me.pnlMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMiddleLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlMiddleLeft.Name = "pnlMiddleLeft"
        Me.pnlMiddleLeft.Size = New System.Drawing.Size(96, 295)
        Me.pnlMiddleLeft.TabIndex = 4
    '
    'DockMiddleLeftTop
    '
    Me.DockMiddleLeftTop.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DockMiddleLeftTop.Location = New System.Drawing.Point(0, 0)
    Me.DockMiddleLeftTop.Margin = New System.Windows.Forms.Padding(0)
        Me.DockMiddleLeftTop.Name = "DockMiddleLeftTop"

    '
    'splitMiddleLeftRight
    '
    Me.splitMiddleLeftRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.splitMiddleLeftRight.Location = New System.Drawing.Point(96, 0)
        Me.splitMiddleLeftRight.Name = "splitMiddleLeftRight"
        Me.splitMiddleLeftRight.Size = New System.Drawing.Size(4, 295)
        Me.splitMiddleLeftRight.TabIndex = 6
        Me.splitMiddleLeftRight.TabStop = False
        '
        'pnlMiddleRight
        '
        Me.pnlMiddleRight.BackColor = System.Drawing.Color.Black
        Me.pnlMiddleRight.Controls.Add(Me.DockMiddleTopRight)
        Me.pnlMiddleRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMiddleRight.Location = New System.Drawing.Point(100, 0)
        Me.pnlMiddleRight.Name = "pnlMiddleRight"
        Me.pnlMiddleRight.Size = New System.Drawing.Size(115, 295)
        Me.pnlMiddleRight.TabIndex = 5
    '
    'DockMiddleTopRight
    '
    Me.DockMiddleTopRight.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DockMiddleTopRight.Location = New System.Drawing.Point(0, 0)
    Me.DockMiddleTopRight.Margin = New System.Windows.Forms.Padding(0)
        Me.DockMiddleTopRight.Name = "DockMiddleTopRight"

    '
    'splitMiddleBottom
    '
    Me.splitMiddleBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.splitMiddleBottom.Location = New System.Drawing.Point(0, 295)
        Me.splitMiddleBottom.Name = "splitMiddleBottom"
        Me.splitMiddleBottom.Size = New System.Drawing.Size(215, 4)
        Me.splitMiddleBottom.TabIndex = 15
        Me.splitMiddleBottom.TabStop = False
        '
        'pnlMiddleBottom
        '
        Me.pnlMiddleBottom.BackColor = System.Drawing.Color.Black
        Me.pnlMiddleBottom.Controls.Add(Me.DockMiddleBottom)
        Me.pnlMiddleBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMiddleBottom.Location = New System.Drawing.Point(0, 299)
        Me.pnlMiddleBottom.Name = "pnlMiddleBottom"
        Me.pnlMiddleBottom.Size = New System.Drawing.Size(215, 71)
        Me.pnlMiddleBottom.TabIndex = 12
    '
    'DockMiddleBottom
    '
    Me.DockMiddleBottom.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DockMiddleBottom.Location = New System.Drawing.Point(0, 0)
    Me.DockMiddleBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.DockMiddleBottom.Name = "DockMiddleBottom"
    '
    'splitLeft
    '
    Me.splitLeft.Location = New System.Drawing.Point(210, 4)
        Me.splitLeft.Name = "splitLeft"
        Me.splitLeft.Size = New System.Drawing.Size(4, 370)
        Me.splitLeft.TabIndex = 10
        Me.splitLeft.TabStop = False
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.pnlLeftBottom)
        Me.pnlLeft.Controls.Add(Me.splitLeftTopBottom)
        Me.pnlLeft.Controls.Add(Me.pnlLeftTop)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(4, 4)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(206, 370)
        Me.pnlLeft.TabIndex = 9
        '
        'pnlLeftBottom
        '
        Me.pnlLeftBottom.BackColor = System.Drawing.Color.Black
        Me.pnlLeftBottom.Controls.Add(Me.DockLeftBottom)
        Me.pnlLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLeftBottom.Location = New System.Drawing.Point(0, 153)
        Me.pnlLeftBottom.Name = "pnlLeftBottom"
        Me.pnlLeftBottom.Size = New System.Drawing.Size(206, 217)
        Me.pnlLeftBottom.TabIndex = 2
        '
        'DockLeftBottom
        '
        Me.DockLeftBottom.BackColor = System.Drawing.Color.Black
        Me.DockLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DockLeftBottom.Location = New System.Drawing.Point(0, 0)
    Me.DockLeftBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.DockLeftBottom.Name = "DockLeftBottom"
    '
    'splitLeftTopBottom
    '
    Me.splitLeftTopBottom.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitLeftTopBottom.Location = New System.Drawing.Point(0, 149)
        Me.splitLeftTopBottom.Name = "splitLeftTopBottom"
        Me.splitLeftTopBottom.Size = New System.Drawing.Size(206, 4)
        Me.splitLeftTopBottom.TabIndex = 3
        Me.splitLeftTopBottom.TabStop = False
        '
        'pnlLeftTop
        '
        Me.pnlLeftTop.BackColor = System.Drawing.Color.Black
        Me.pnlLeftTop.Controls.Add(Me.DockLeftTop)
        Me.pnlLeftTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLeftTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeftTop.Name = "pnlLeftTop"
        Me.pnlLeftTop.Size = New System.Drawing.Size(206, 149)
        Me.pnlLeftTop.TabIndex = 1
    '
    'DockLeftTop
    '
    Me.DockLeftTop.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DockLeftTop.Location = New System.Drawing.Point(0, 0)
    Me.DockLeftTop.Margin = New System.Windows.Forms.Padding(0)
        Me.DockLeftTop.Name = "DockLeftTop"
    '
    'splitRight
    '
    Me.splitRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.splitRight.Location = New System.Drawing.Point(429, 4)
        Me.splitRight.Name = "splitRight"
        Me.splitRight.Size = New System.Drawing.Size(4, 370)
        Me.splitRight.TabIndex = 14
        Me.splitRight.TabStop = False
        '
        'pnlRight
        '
        Me.pnlRight.Controls.Add(Me.pnlRightBottom)
        Me.pnlRight.Controls.Add(Me.splitRightTopBottom)
        Me.pnlRight.Controls.Add(Me.pnlRightTop)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRight.Location = New System.Drawing.Point(433, 4)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(200, 370)
        Me.pnlRight.TabIndex = 11
        '
        'pnlRightBottom
        '
        Me.pnlRightBottom.BackColor = System.Drawing.Color.Black
        Me.pnlRightBottom.Controls.Add(Me.DockRightBottom)
        Me.pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRightBottom.Location = New System.Drawing.Point(0, 156)
        Me.pnlRightBottom.Name = "pnlRightBottom"
        Me.pnlRightBottom.Size = New System.Drawing.Size(200, 214)
        Me.pnlRightBottom.TabIndex = 1
    '
    'DockRightBottom
    '
    Me.DockRightBottom.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DockRightBottom.Location = New System.Drawing.Point(0, 0)
    Me.DockRightBottom.Margin = New System.Windows.Forms.Padding(0)
        Me.DockRightBottom.Name = "DockRightBottom"
    '
    'splitRightTopBottom
    '
    Me.splitRightTopBottom.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitRightTopBottom.Location = New System.Drawing.Point(0, 152)
        Me.splitRightTopBottom.Name = "splitRightTopBottom"
        Me.splitRightTopBottom.Size = New System.Drawing.Size(200, 4)
        Me.splitRightTopBottom.TabIndex = 2
        Me.splitRightTopBottom.TabStop = False
        '
        'pnlRightTop
        '
        Me.pnlRightTop.BackColor = System.Drawing.Color.Black
        Me.pnlRightTop.Controls.Add(Me.DockRightTop)
        Me.pnlRightTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRightTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlRightTop.Name = "pnlRightTop"
        Me.pnlRightTop.Size = New System.Drawing.Size(200, 152)
        Me.pnlRightTop.TabIndex = 0
    '
    'DockRightTop
    '
    Me.DockRightTop.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DockRightTop.Location = New System.Drawing.Point(0, 0)
    Me.DockRightTop.Margin = New System.Windows.Forms.Padding(0)
        Me.DockRightTop.Name = "DockRightTop"
    '
    'DockPanelManager
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "DockPanelManager"
        Me.Size = New System.Drawing.Size(637, 378)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMiddle.ResumeLayout(False)
        Me.pnlMiddleTop.ResumeLayout(False)
        Me.pnlMiddleLeft.ResumeLayout(False)
        Me.DockMiddleLeftTop.ResumeLayout(False)
        Me.pnlMiddleRight.ResumeLayout(False)
        Me.DockMiddleTopRight.ResumeLayout(False)
        Me.pnlMiddleBottom.ResumeLayout(False)
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlLeftBottom.ResumeLayout(False)
        Me.pnlLeftTop.ResumeLayout(False)
        Me.pnlRight.ResumeLayout(False)
        Me.pnlRightBottom.ResumeLayout(False)
        Me.pnlRightTop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
  Friend WithEvents pnlMiddle As Panel
  Friend WithEvents pnlMiddleTop As Panel
  Friend WithEvents pnlMiddleLeft As Panel
  Friend WithEvents splitMiddleLeftRight As Splitter
  Friend WithEvents pnlMiddleRight As Panel
  Friend WithEvents splitMiddleBottom As Splitter
  Friend WithEvents pnlMiddleBottom As Panel
  Friend WithEvents splitLeft As Splitter
  Friend WithEvents pnlLeft As Panel
  Friend WithEvents pnlLeftBottom As Panel
  Friend WithEvents splitLeftTopBottom As Splitter
  Friend WithEvents pnlLeftTop As Panel
  Friend WithEvents splitRight As Splitter
  Friend WithEvents pnlRight As Panel
  Friend WithEvents pnlRightBottom As Panel
  Friend WithEvents splitRightTopBottom As Splitter
  Friend WithEvents pnlRightTop As Panel
  Friend WithEvents DockMiddleLeftTop As DockPanel
  Friend WithEvents DockMiddleTopRight As DockPanel
  Friend WithEvents DockMiddleBottom As DockPanel
  Friend WithEvents DockLeftBottom As DockPanel
  Friend WithEvents DockLeftTop As DockPanel
  Friend WithEvents DockRightBottom As DockPanel
  Friend WithEvents DockRightTop As DockPanel
End Class
