Public Class RibbonBar
  Inherits Panel

#Region "Fields"

  Protected Friend WithEvents RibbonCntl As Ribbon

#End Region

#Region "Properties"

  Public Property AppBackColor As Color = My.Theme.AppBackColor
  Public Property AppForeColor As Color = My.Theme.AppFontColor
  Public Property AppHighlightColor As Color = My.Theme.AppHighlightColor
  Public Property BarId As Integer
  Public Property RibbonAccentColor As Color = My.Theme.RibbonAccentColor
  Public Property RibbonBackColor As Color = My.Theme.RibbonBackColor
  Public Property RibbonForeColor As Color = My.Theme.RibbonForeColor
  Public Property RibbonShadowColor As Color = My.Theme.RibbonShadowColor

#End Region

#Region "Public Constructors"

  Public Sub New()
    Me.New(Nothing, "RibbonBar", 1)
  End Sub

  Public Sub New(oRibbon As Ribbon, sName As String, iBarId As Integer)
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SuspendLayout()
    RibbonCntl = oRibbon
    Name = sName
    BarId = iBarId
    AllowDrop = True
    BackColor = RibbonBackColor
    Font = My.Theme.RibbonBarFont
    ForeColor = RibbonForeColor
    Margin = New System.Windows.Forms.Padding(0)
    MaximumSize = New System.Drawing.Size(0, RibbonConfig.RIBBON_BAR_HEIGHT)
    MinimumSize = New System.Drawing.Size(100, RibbonConfig.RIBBON_BAR_HEIGHT)
    Padding = New System.Windows.Forms.Padding(4 * 2, 4, 4 * 2, 4)
    Dock = DockStyle.Top
    ResumeLayout(False)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub RenderControl(sender As Object, e As PaintEventArgs) Handles Me.Paint
    Dim h As Integer = Height - 1
    Dim w As Integer = Width - 1
    Dim bWidth As Integer = 0
    Dim bArc As Integer = 10

    Dim g As Graphics = e.Graphics
    g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

    Dim path As New Drawing2D.GraphicsPath()
    path.StartFigure()
    path.AddArc(New Rectangle(0, 0, bArc * 2, bArc * 2), 180, 90)
    path.AddLine(bArc, 0, w - bArc, 0)
    path.AddArc(New Rectangle(w - (bArc * 2), 0, bArc * 2, bArc * 2), -90, 90)
    path.AddLine(w, bArc, w, h - bArc)
    path.AddArc(New Rectangle(w - (bArc * 2), h - (bArc * 2), bArc * 2, bArc * 2), 0, 90)
    path.AddLine(w - bArc, h, bArc, h)
    path.AddArc(New Rectangle(0, h - (bArc * 2), bArc * 2, bArc * 2), 90, 90)
    path.AddLine(0, h - bArc, 0, bArc)
    path.CloseFigure()

    Region = New Region(path)
    Using brush As New SolidBrush(RibbonBackColor)
      g.FillRectangle(brush, ClientRectangle)
    End Using

    If bWidth > 0 Then
      Dim jPen As New Pen(RibbonShadowColor, bWidth)
      g.DrawPath(jPen, path)
    End If

  End Sub

  Private Sub RibbonBar_ParentChanged(sender As Object, e As EventArgs) Handles Me.ParentChanged
    If RibbonCntl Is Nothing And TypeOf Parent Is Ribbon Then
      RibbonCntl = TryCast(Parent, Ribbon)
      BarId = Parent.Controls.Count
      If Name = "RibbonBar" Then Name += BarId.ToString
    End If
  End Sub

#End Region

#Region "Public Methods"

  Public Function AddGroup(sName As String, sCaption As String, iBarId As Integer, iGroupId As Integer) As RibbonGroup
    Dim rg As New RibbonGroup(RibbonCntl, sName, sCaption, iBarId, iGroupId) With {
      .AppBackColor = AppBackColor,
    .AppForeColor = AppForeColor,
    .AppHighlightColor = AppHighlightColor,
    .RibbonAccentColor = RibbonAccentColor,
    .RibbonBackColor = RibbonBackColor,
    .RibbonForeColor = RibbonForeColor,
    .RibbonShadowColor = RibbonShadowColor
    }
    Controls.Add(rg)
    rg.BringToFront()
    Return rg
  End Function

#End Region

End Class