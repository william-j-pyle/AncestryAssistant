Public Class RibbonBar
  Inherits Panel

#Region "Properties"

  Public Property AppBackColor As Color = My.Theme.AppBackColor
  Public Property AppForeColor As Color = My.Theme.AppFontColor
  Public Property AppHighlightColor As Color = My.Theme.AppHighlightColor
  Public ReadOnly Property Id As String = ""
  Public Property RibbonAccentColor As Color = My.Theme.RibbonAccentColor
  Public Property RibbonBackColor As Color = My.Theme.RibbonBackColor
  Public Property RibbonForeColor As Color = My.Theme.RibbonForeColor
  Public Property RibbonShadowColor As Color = My.Theme.RibbonShadowColor

#End Region

#Region "Public Constructors"

  Public Sub New(Id As String)
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SuspendLayout()
    Name = "BAR__" + Id
    _Id = Id
    AllowDrop = True
    BackColor = RibbonBackColor
    Font = My.Theme.RibbonBarFont
    ForeColor = RibbonForeColor
    Margin = New System.Windows.Forms.Padding(0)
    MaximumSize = New System.Drawing.Size(0, RibbonConfig.RIBBON_BARHEIGHT)
    MinimumSize = New System.Drawing.Size(100, RibbonConfig.RIBBON_BARHEIGHT)
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

#End Region

#Region "Public Methods"

  Public Function AddGroup(GroupId As String, Text As String) As RibbonGroup
    Dim rg As New RibbonGroup(GroupId, Text) With {
      .AppBackColor = AppBackColor,
    .AppForeColor = AppForeColor,
    .AppHighlightColor = AppHighlightColor,
    .RibbonAccentColor = RibbonAccentColor,
    .RibbonBackColor = RibbonBackColor,
    .RibbonForeColor = RibbonForeColor,
    .RibbonShadowColor = RibbonShadowColor
    }
    Controls.Add(rg)
    Return rg
  End Function

#End Region

End Class