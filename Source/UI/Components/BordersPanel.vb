Imports System.ComponentModel

Public Class BordersPanel
  Inherits Panel

#Region "Properties"

  Public Property BorderColor As Color
    Get
      Return _BorderColor
    End Get
    Set(value As Color)
      _BorderColor = value
      _BorderColorTop = value
      _BorderColorLeft = value
      _BorderColorRight = value
      _BorderColorBottom = value
      Invalidate()
    End Set
  End Property

  Public Property BorderColorBottom As Color
    Get
      Return _BorderColorBottom
    End Get
    Set(value As Color)
      _BorderColorBottom = value
      _BorderColor = Color.Transparent
      Invalidate()
    End Set
  End Property

  Public Property BorderColorLeft As Color
    Get
      Return _BorderColorLeft
    End Get
    Set(value As Color)
      _BorderColorLeft = value
      _BorderColor = Color.Transparent
      Invalidate()
    End Set
  End Property

  Public Property BorderColorRight As Color
    Get
      Return _BorderColorRight
    End Get
    Set(value As Color)
      _BorderColorRight = value
      _BorderColor = Color.Transparent
      Invalidate()
    End Set
  End Property

  Public Property BorderColorTop As Color
    Get
      Return _BorderColorTop
    End Get
    Set(value As Color)
      _BorderColorTop = value
      _BorderColor = Color.Transparent
      Invalidate()
    End Set
  End Property

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BorderStyle As BorderStyle

  Public Property BorderWidth As Padding
    Get
      Return _BorderWidth
    End Get
    Set(value As Padding)
      If value.All = -1 Then
        value.Left = Math.Max(value.Left, 0)
        value.Top = Math.Max(value.Top, 0)
        value.Right = Math.Max(value.Right, 0)
        value.Bottom = Math.Max(value.Bottom, 0)
      Else
        value.All = Math.Max(value.All, 0)
      End If
      _BorderWidth = value
      Invalidate()
    End Set
  End Property

  Public Property CornerRadius As Padding
    Get
      Return _CornerRadius
    End Get
    Set(value As Padding)
      Dim mxVal As Integer = CInt(Math.Min(Width, Height) / 2)
      If value.All = -1 Then
        value.Left = Math.Min(Math.Max(value.Left, 0), mxVal)
        value.Top = Math.Min(Math.Max(value.Top, 0), mxVal)
        value.Right = Math.Min(Math.Max(value.Right, 0), mxVal)
        value.Bottom = Math.Min(Math.Max(value.Bottom, 0), mxVal)
      Else
        value.All = Math.Min(Math.Max(value.All, 0), mxVal)
      End If
      _CornerRadius = value
      Invalidate()
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub BordersPanel_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    'MyBase.OnPaint(e)
    'Until I learn to do a custom param property guy, using Padding
    'So   Padding.Top   =   Top-Left
    '     Padding.Left  =   Bottom-Left
    '     Padding.Right =   Top-Right
    '     Padding.Bottom=   Bottom-Right
    Dim CornerRadiusTopLeft As Integer = CornerRadius.Top
    Dim CornerRadiusBottomLeft As Integer = CornerRadius.Left
    Dim CornerRadiusTopRight As Integer = CornerRadius.Right
    Dim CornerRadiusBottomRight As Integer = CornerRadius.Bottom

    If CornerRadius.All <> 0 Then
      Dim path As New Drawing2D.GraphicsPath()
      path.StartFigure()
      If CornerRadiusTopLeft > 0 Then
        path.AddArc(New Rectangle(0, 0, CornerRadiusTopLeft * 2, CornerRadiusTopLeft * 2), 180, 90)
      End If
      path.AddLine(CornerRadiusTopLeft, 0, Width - CornerRadiusTopRight, 0)
      If CornerRadiusTopRight > 0 Then
        path.AddArc(New Rectangle(Width - (CornerRadiusTopRight * 2), 0, CornerRadiusTopRight * 2, CornerRadiusTopRight * 2), -90, 90)
      End If
      path.AddLine(Width, CornerRadiusTopRight, Width, Height - CornerRadiusBottomRight)
      If CornerRadiusBottomRight > 0 Then
        path.AddArc(New Rectangle(Width - (CornerRadiusBottomRight * 2), Height - (CornerRadiusBottomRight * 2), CornerRadiusBottomRight * 2, CornerRadiusBottomRight * 2), 0, 90)
      End If
      path.AddLine(Width - CornerRadiusBottomRight, Height, CornerRadiusBottomLeft, Height)
      If CornerRadiusBottomLeft > 0 Then
        path.AddArc(New Rectangle(0, Height - (CornerRadiusBottomLeft * 2), CornerRadiusBottomLeft * 2, CornerRadiusBottomLeft * 2), 90, 90)
      End If
      path.AddLine(0, Height - CornerRadiusBottomLeft, 0, CornerRadiusTopLeft)
      path.CloseFigure()
      Region = New Region(path)
      Using brush As New SolidBrush(BackColor)
        e.Graphics.FillRectangle(brush, ClientRectangle)
      End Using
    End If

    If BorderWidth.All <> 0 Then
      Dim jPenLeft As New Pen(BorderColorLeft, BorderWidth.Left * 2)
      Dim jPenTop As New Pen(BorderColorTop, BorderWidth.Top * 2)
      Dim jPenRight As New Pen(BorderColorRight, BorderWidth.Right * 2)
      Dim jPenBottom As New Pen(BorderColorBottom, BorderWidth.Bottom * 2)
      If CornerRadius.All <> 0 Then
        If BorderWidth.Top > 0 And CornerRadiusTopLeft > 0 Then
          e.Graphics.DrawArc(jPenTop, New Rectangle(0, 0, CornerRadiusTopLeft * 2, CornerRadiusTopLeft * 2), 180, 90)
        End If
        If BorderWidth.Top > 0 And CornerRadiusTopRight > 0 Then
          e.Graphics.DrawArc(jPenTop, New Rectangle(Width - (CornerRadiusTopRight * 2), 0, CornerRadiusTopRight * 2, CornerRadiusTopRight * 2), -90, 90)
        End If
        If BorderWidth.Right > 0 And CornerRadiusBottomRight > 0 Then
          e.Graphics.DrawArc(jPenRight, New Rectangle(Width - (CornerRadiusBottomRight * 2), Height - (CornerRadiusBottomRight * 2), CornerRadiusBottomRight * 2, CornerRadiusBottomRight * 2), 0, 90)
        End If
        If BorderWidth.Left > 0 And CornerRadiusBottomLeft > 0 Then
          e.Graphics.DrawArc(jPenLeft, New Rectangle(0, Height - (CornerRadiusBottomLeft * 2), CornerRadiusBottomLeft * 2, CornerRadiusBottomLeft * 2), 90, 90)
        End If
      End If
      If BorderWidth.Top > 0 Then
        e.Graphics.DrawLine(jPenTop, CornerRadiusTopLeft, 0, Width - CornerRadiusTopRight, 0)
      End If
      If BorderWidth.Right > 0 Then
        e.Graphics.DrawLine(jPenRight, Width, CornerRadiusTopRight, Width, Height - CornerRadiusBottomRight)
      End If
      If BorderWidth.Bottom > 0 Then
        e.Graphics.DrawLine(jPenBottom, Width - CornerRadiusBottomRight, Height, CornerRadiusBottomLeft, Height)
      End If
      If BorderWidth.Left > 0 Then
        e.Graphics.DrawLine(jPenLeft, 0, Height - CornerRadiusBottomLeft, 0, CornerRadiusTopLeft)
      End If
    End If

  End Sub

#End Region

#Region "Fields"

  <Browsable(True), Category("JControl"), Description("Color of the border around the control")>
  Dim _BorderColor As Color = Color.Transparent

  Dim _BorderColorBottom As Color = Color.Transparent

  Dim _BorderColorLeft As Color = Color.Transparent

  Dim _BorderColorRight As Color = Color.Transparent

  Dim _BorderColorTop As Color = Color.Transparent

  <Browsable(True), Category("JControl"), Description("Width in pixels of the border around the control")>
  Dim _BorderWidth As New Padding(0)

  <Browsable(True), Category("JControl"), Description("Sets the number of pixels for the Corner radius. Valid 0 to Min(Height,Width)/2")>
  Private _CornerRadius As New Padding(0)

#End Region

End Class