Public Class Ribbon
  Inherits TabControl
  Private components As System.ComponentModel.IContainer
  Private Const TABHEIGHT As Integer = 20
  Private Const RIBBONTOP As Integer = TABHEIGHT + 1
  Private Const RIBBONBORDER As Integer = 8
  Private Const RIBBONHEIGHT As Integer = 100

  Public Sub New()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SuspendLayout()
    AllowDrop = True
    BackColor = System.Drawing.Color.Transparent
    Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Margin = New System.Windows.Forms.Padding(0)
    MaximumSize = New System.Drawing.Size(0, RIBBONHEIGHT + RIBBONTOP + (2 * RIBBONBORDER))
    MinimumSize = New System.Drawing.Size(100, RIBBONHEIGHT + RIBBONTOP + (2 * RIBBONBORDER))
    Name = "JRibbon"
    'Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
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
    'TOP LEFT CORNER
    path.AddArc(New Rectangle(0, RIBBONTOP, RIBBONBORDER * 2, RIBBONBORDER * 2), 180, 90)
    'TOP LINE
    path.AddLine(RIBBONBORDER, RIBBONTOP, Width - RIBBONBORDER, RIBBONTOP)
    'TOP RIGHT CORNER
    path.AddArc(New Rectangle(Width - (RIBBONBORDER * 2), RIBBONTOP, RIBBONBORDER * 2, RIBBONBORDER * 2), -90, 90)
    'RIGHT LINE
    path.AddLine(Width, RIBBONBORDER + RIBBONTOP, Width, RIBBONTOP + RIBBONHEIGHT - RIBBONBORDER)
    'BOTTOM RIGHT CORNER
    path.AddArc(New Rectangle(Width - (RIBBONBORDER * 2), RIBBONTOP + RIBBONHEIGHT - (RIBBONBORDER * 2), RIBBONBORDER * 2, RIBBONBORDER * 2), 0, 90)
    'BOTTOM LINE
    path.AddLine(Width - RIBBONBORDER, RIBBONTOP + RIBBONHEIGHT, RIBBONBORDER, RIBBONTOP + RIBBONHEIGHT)
    'BOTTOM LEFT CORNER
    path.AddArc(New Rectangle(0, RIBBONTOP + RIBBONHEIGHT - (RIBBONBORDER * 2), RIBBONBORDER * 2, RIBBONBORDER * 2), 90, 90)
    'LEFT LINE
    path.AddLine(0, RIBBONTOP + RIBBONHEIGHT - RIBBONBORDER, 0, RIBBONTOP + RIBBONBORDER)
    path.CloseFigure()
    Region = New Region(path)
    Using brush As SolidBrush = New SolidBrush(SystemColors.ControlLight)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using
    For i As Integer = 0 To TabPages.Count - 1
      Dim tabPage As TabPage = TabPages(i)
      Dim tabBounds As Rectangle = GetTabRect(i)
      Dim textColor As Color

      ' Fill the background
      'Using brush As New SolidBrush(PanelBackColor)
      'g.FillRectangle(brush, tabBounds)
      'End Using

      ' Set the text and background colors based on selected and unselected states
      If SelectedIndex = i Then
        textColor = Color.White
      Else
        textColor = Color.LightGray
      End If

      ' Draw the tab text
      Using brush As New SolidBrush(textColor)
        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center
        e.Graphics.DrawString(tabPage.Text, Font, brush, tabBounds, stringFormat)
      End Using

      'Const ADJ = 2
      'If BorderWidth.Bottom > 0 Then
      'If SelectedIndex = i Then
      'e.Graphics.DrawLine(PenBorderBottom, tabBounds.Left - ADJ, tabBounds.Top, tabBounds.Left - ADJ, tabBounds.Bottom)
      'e.Graphics.DrawLine(PenBorderBottom, tabBounds.Right - ADJ, tabBounds.Top, tabBounds.Right - ADJ, tabBounds.Bottom)
      'e.Graphics.DrawLine(PenBorderBottom, tabBounds.Left - ADJ, tabBounds.Bottom, tabBounds.Right - ADJ, tabBounds.Bottom)
      'Else
      'e.Graphics.DrawLine(PenBorderBottom, tabBounds.Left - ADJ, tabBounds.Top, tabBounds.Right - ADJ, tabBounds.Top)
      'End If
      'If i = TabPages.Count - 1 Then
      'e.Graphics.DrawLine(PenBorderBottom, tabBounds.Right - ADJ, tabBounds.Top, r, tabBounds.Top)
      'End If
      'End If
    Next
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
