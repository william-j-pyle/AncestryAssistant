Public Class RibbonGroup
  Inherits TableLayoutPanel

#Region "Fields"

  Private _Caption As String = "RibbonGroup"
  Private CaptionFont As New System.Drawing.Font("Segoe UI Semibold", 10, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer
  Private IconFont As New System.Drawing.Font("Segoe Fluent Icons", 10, FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))

#End Region

#Region "Properties"

  Public Property Caption As String
    Get
      Return _Caption
    End Get
    Set(value As String)
      _Caption = value
      Refresh()
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SuspendLayout()
    MaximumSize = New System.Drawing.Size(0, 0)
    MinimumSize = New System.Drawing.Size(100, 0)
    Padding = New Padding(0)
    Margin = New Padding(0)
    Name = "JRibbonGroup"
    Dock = System.Windows.Forms.DockStyle.Left
    GrowStyle = TableLayoutPanelGrowStyle.FixedSize
    ResumeLayout(False)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub JRibbonGroup_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    Using brush As New SolidBrush(SystemColors.ControlLight)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using

    Dim jPen As New Pen(SystemColors.ButtonShadow, 2)
    e.Graphics.DrawLine(jPen, Width, 16, Width, Height - 16)

    Dim textBrush As Brush = New SolidBrush(ForeColor)
    Dim textSize As Size = TextRenderer.MeasureText(Caption, Font)
    Dim textLocation As New Point(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - textSize.Width) / 2), e.ClipRectangle.Bottom - textSize.Height)

    e.Graphics.DrawString(Caption, Font, textBrush, textLocation)

    ' Draw the Exapand Icon ------- | | \ | \ | ----
    Dim t As Integer = textLocation.Y + 2
    Dim l As Integer = Width - 12
    Dim w As Integer = 8
    Dim h As Integer = 8

    Dim tColor As Color = Color.FromArgb(180, ForeColor)
    jPen = New Pen(tColor, 2)
    e.Graphics.DrawLine(jPen, l + 3, t + 3, l + 7, t + 7)

    jPen = New Pen(ForeColor, 1)
    e.Graphics.DrawLine(jPen, l, t, l, t + 6)
    e.Graphics.DrawLine(jPen, l, t, l + 6, t)
    e.Graphics.DrawLine(jPen, l + 7, t + 3, l + 7, t + 7)
    e.Graphics.DrawLine(jPen, l + 3, t + 7, l + 7, t + 7)
    e.Graphics.DrawLine(jPen, l + 3, t + 3, l + 7, t + 7)

  End Sub

  Private Sub RibbonGroup_ControlAdded(sender As Object, e As ControlEventArgs) Handles Me.ControlAdded
    If Controls.Count = 1 Then
      With Me
        .ColumnStyles.Clear()
        .RowStyles.Clear()
        .ColumnCount = 6
        .ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        .ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        .ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        .ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        .ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        .ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        .RowCount = 4
        .RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        .RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        .RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        .RowStyles.Add(New System.Windows.Forms.RowStyle())
      End With
    End If

  End Sub

#End Region

#Region "Protected Methods"

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

#End Region

End Class