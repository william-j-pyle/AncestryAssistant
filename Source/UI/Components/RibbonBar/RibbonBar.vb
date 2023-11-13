Public Class RibbonBar
  Inherits Panel

  Private theme As UITheme = UITheme.GetInstance
  Private components As System.ComponentModel.IContainer

  Public Sub New()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SuspendLayout()
    AllowDrop = True
    BackColor = theme.RibbonBackColor
    Font = theme.RibbonFont
    ForeColor = theme.RibbonFontColor
    Margin = New System.Windows.Forms.Padding(0)
    MaximumSize = New System.Drawing.Size(0, 100)
    MinimumSize = New System.Drawing.Size(100, 100)
    Name = "JRibbon"
    Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
    Dock = DockStyle.Top
    ResumeLayout(False)
  End Sub

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

  'Protected Overrides ReadOnly Property CreateParams As CreateParams
  '  Get
  '    Dim cp As CreateParams = MyBase.CreateParams
  '    cp.Style = cp.Style Or &H2000000 ' WS_CLIPCHILDREN
  '    Return cp
  '  End Get
  'End Property

  Private Sub JRibbon_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    Dim h As Integer = Height - 1
    Dim w As Integer = Width - 1
    Dim bWidth As Integer = 1
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
    Using brush As SolidBrush = New SolidBrush(theme.RibbonBackColor)
      g.FillRectangle(brush, ClientRectangle)
    End Using

    If bWidth > 0 Then
      Dim jPen As Pen = New Pen(theme.RibbonBorderColor, bWidth)
      g.DrawPath(jPen, path)
    End If
    'e.Graphics.DrawArc(jPen2, New Rectangle(0, 0, 16, 16), 180, 90)
    'e.Graphics.DrawArc(jPen2, New Rectangle(Width - 16, 0, 16, 16), -90, 90)
    'e.Graphics.DrawArc(jPen2, New Rectangle(Width - 16, Height - 16, 16, 16), 0, 90)
    'e.Graphics.DrawArc(jPen2, New Rectangle(0, Height - 16, 16, 16), 90, 90)
    'e.Graphics.DrawLine(jPen, 8, 0, Width - 8, 0)
    'e.Graphics.DrawLine(jPen, Width, 8, Width, Height - 8)
    'e.Graphics.DrawLine(jPen, Width - 8, Height, 8, Height)
    'e.Graphics.DrawLine(jPen, 0, Height - 8, 0, 8)

  End Sub


End Class
