Public Class Ribbon
  Inherits Panel
  Private components As System.ComponentModel.IContainer

  Public Sub New()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SuspendLayout()
    AllowDrop = True
    BackColor = System.Drawing.Color.Transparent
    Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Margin = New System.Windows.Forms.Padding(0)
    MaximumSize = New System.Drawing.size(0, 100)
    MinimumSize = New System.Drawing.size(100, 100)
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
    'MyBase.OnPaint(e)
    Dim path As New Drawing2D.GraphicsPath()
    path.StartFigure()
    path.AddArc(New Rectangle(0, 0, 16, 16), 180, 90)
    path.AddLine(8, 0, Width - 8, 0)
    path.AddArc(New Rectangle(Width - 16, 0, 16, 16), -90, 90)
    path.AddLine(Width, 8, Width, Height - 8)
    path.AddArc(New Rectangle(Width - 16, Height - 16, 16, 16), 0, 90)
    path.AddLine(Width - 8, Height, 8, Height)
    path.AddArc(New Rectangle(0, Height - 16, 16, 16), 90, 90)
    path.AddLine(0, Height - 8, 0, 8)
    path.CloseFigure()
    Region = New Region(path)
    Using brush As SolidBrush = New SolidBrush(SystemColors.ControlLight)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using

    'Dim jPen As Pen = New Pen(SystemColors.ButtonShadow, 2)
    'e.Graphics.DrawArc(jPen, New Rectangle(0, 0, 16, 16), 180, 90)
    'e.Graphics.DrawArc(jPen, New Rectangle(Width - 16, 0, 16, 16), -90, 90)
    'e.Graphics.DrawArc(jPen, New Rectangle(Width - 16, Height - 16, 16, 16), 0, 90)
    'e.Graphics.DrawArc(jPen, New Rectangle(0, Height - 16, 16, 16), 90, 90)
    'e.Graphics.DrawLine(jPen, 8, 0, Width - 8, 0)
    'e.Graphics.DrawLine(jPen, Width, 8, Width, Height - 8)
    'e.Graphics.DrawLine(jPen, Width - 8, Height, 8, Height)
    'e.Graphics.DrawLine(jPen, 0, Height - 8, 0, 8)

  End Sub


End Class
