Public Class RISeperator
  Inherits RibbonItem

#Region "Public Constructors"

  Public Sub New()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub RenderControl(sender As Object, e As PaintEventArgs) Handles Me.Paint
    Dim jPen As New Pen(Color.FromArgb(100, RibbonForeColor), 1)
    e.Graphics.DrawLine(jPen, CInt(Width / 2), 4, CInt(Width / 2), Height - 4)
  End Sub

#End Region

End Class