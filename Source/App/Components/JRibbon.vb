Public Class JRibbon
  Inherits Panel

  Public Sub New()
    InitializeComponent()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
  End Sub

  'Protected Overrides ReadOnly Property CreateParams As CreateParams
  '  Get
  '    Dim cp As CreateParams = MyBase.CreateParams
  '    cp.Style = cp.Style Or &H2000000 ' WS_CLIPCHILDREN
  '    Return cp
  '  End Get
  'End Property

  Private Sub JRibbon_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    'MyBase.OnPaint(e)
    Dim path As New Drawing2D.GraphicsPath()
    path.StartFigure()
    path.AddArc(New Rectangle(0, 0, 32, 32), 180, 90)
    path.AddLine(16, 0, Width - 16, 0)
    path.AddArc(New Rectangle(Width - 32, 0, 32, 32), -90, 90)
    path.AddLine(Width, 16, Width, Height - 16)
    path.AddArc(New Rectangle(Width - 32, Height - 32, 32, 32), 0, 90)
    path.AddLine(Width - 16, Height, 16, Height)
    path.AddArc(New Rectangle(0, Height - 32, 32, 32), 90, 90)
    path.AddLine(0, Height - 16, 0, 16)
    path.CloseFigure()
    Region = New Region(path)
    Using brush As SolidBrush = New SolidBrush(SystemColors.ControlLight)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using

    Dim jPen As Pen = New Pen(SystemColors.ButtonShadow, 2)
    e.Graphics.DrawArc(jPen, New Rectangle(0, 0, 32, 32), 180, 90)
    e.Graphics.DrawArc(jPen, New Rectangle(Width - 32, 0, 32, 32), -90, 90)
    e.Graphics.DrawArc(jPen, New Rectangle(Width - 32, Height - 32, 32, 32), 0, 90)
    e.Graphics.DrawArc(jPen, New Rectangle(0, Height - 32, 32, 32), 90, 90)
    e.Graphics.DrawLine(jPen, 16, 0, Width - 16, 0)
    e.Graphics.DrawLine(jPen, Width, 16, Width, Height - 16)
    e.Graphics.DrawLine(jPen, Width - 16, Height, 16, Height)
    e.Graphics.DrawLine(jPen, 0, Height - 16, 0, 16)

  End Sub
End Class
