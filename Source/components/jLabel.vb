Imports System.ComponentModel

Public Class jLabel
  Inherits Label


  Private _BorderWidthTop As Integer = 0
    Private _BorderWidthBottom As Integer = 0
    Private _BorderWidthLeft As Integer = 0
    Private _BorderWidthRight As Integer = 0

    <Browsable(False),
        EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property BorderStyle As BorderStyle = BorderStyle.None

    <Category("Borders"), Description("Specifies the width of the top border.")>
    Public Property BorderWidthTop As Integer
        Get
            Return _BorderWidthTop
        End Get
        Set
            _BorderWidthTop = Value
      Padding = New Padding(_BorderWidthLeft, _BorderWidthTop, _BorderWidthRight, _BorderWidthBottom)
    End Set
    End Property

    <Category("Borders"), Description("Specifies the color of the top border.")>
    Public Property BorderColorTop As Color = BackColor

  <Category("Borders"), Description("Specifies the width of the bottom border.")>
  Public Property BorderWidthBottom As Integer
    Get
      Return _BorderWidthBottom
    End Get
    Set
      _BorderWidthBottom = Value
      Padding = New Padding(_BorderWidthLeft, _BorderWidthTop, _BorderWidthRight, _BorderWidthBottom)
    End Set
  End Property

  <Category("Borders"), Description("Specifies the color of the bottom border.")>
    Public Property BorderColorBottom As Color = BackColor

  <Category("Borders"), Description("Specifies the width of the left border.")>
  Public Property BorderWidthLeft As Integer
    Get
      Return _BorderWidthLeft
    End Get
    Set
      _BorderWidthLeft = Value
      Padding = New Padding(_BorderWidthLeft, _BorderWidthTop, _BorderWidthRight, _BorderWidthBottom)
    End Set
  End Property

  <Category("Borders"), Description("Specifies the color of the left border.")>
  Public Property BorderColorLeft As Color = BackColor

  <Category("Borders"), Description("Specifies the width of the right border.")>
  Public Property BorderWidthRight As Integer
    Get
      Return _BorderWidthRight
    End Get
    Set
      _BorderWidthRight = Value
      Padding = New Padding(_BorderWidthLeft, _BorderWidthTop, _BorderWidthRight, _BorderWidthBottom)
    End Set
  End Property

  <Category("Borders"), Description("Specifies the color of the right border.")>
  Public Property BorderColorRight As Color = BackColor


  Public Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Using brush As SolidBrush = New SolidBrush(BackColor)
            e.Graphics.FillRectangle(brush, ClientRectangle)
        End Using
        Dim jPen As Pen
        'LEFT
        If BorderWidthLeft > 0 Then
            jPen = New Pen(BorderColorLeft, BorderWidthLeft * 2)
            e.Graphics.DrawLine(jPen, 0, 0, 0, ClientSize.Height - 1)
        End If
        'RIGHT
        If BorderWidthRight > 0 Then
            jPen = New Pen(BorderColorRight, BorderWidthRight * 2)
            e.Graphics.DrawLine(jPen, ClientSize.Width - 1, 0, ClientSize.Width - 1, ClientSize.Height - 1)
        End If
        'TOP
        If BorderWidthTop > 0 Then
            jPen = New Pen(BorderColorTop, BorderWidthTop * 2)
            e.Graphics.DrawLine(jPen, 0, 0, ClientSize.Width - 1, 0)
        End If
        'BOTTOM
        If BorderWidthBottom > 0 Then
            jPen = New Pen(BorderColorBottom, BorderWidthBottom * 2)
            e.Graphics.DrawLine(jPen, 0, ClientSize.Height - 1, ClientSize.Width - 1, ClientSize.Height - 1)
        End If
        'e.Graphics.DrawRectangle(mypen, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1)
    End Sub
End Class