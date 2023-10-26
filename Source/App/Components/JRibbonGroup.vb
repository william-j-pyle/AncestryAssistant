Public Class JRibbonGroup
  Inherits TableLayoutPanel

  Public Sub New()
    InitializeComponent()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
  End Sub

  Private Sub JRibbonGroup_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    Using brush As SolidBrush = New SolidBrush(SystemColors.ControlLight)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using

    Dim jPen As Pen = New Pen(SystemColors.ButtonShadow, 2)
    e.Graphics.DrawLine(jPen, Width, 16, Width, Height - 16)

  End Sub


End Class
