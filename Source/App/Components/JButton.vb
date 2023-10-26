Public Class JButton

  Public Enum IconSizeEnum
    ICON16 = 16
    ICON20 = 20
    ICON32 = 32
    ICON48 = 48
    ICON64 = 64
  End Enum

  Private icoFont As Font

  Private Sub setFont()
    icoFont = New System.Drawing.Font("Segoe Fluent Icons", IconSize, IconFontStyle, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
  End Sub


  Private _IconSize As IconSizeEnum = IconSizeEnum.ICON20
  Public Property IconSize As IconSizeEnum
    Get
      Return _IconSize
    End Get
    Set(value As IconSizeEnum)
      _IconSize = value
      setFont()
      btn.Refresh()
    End Set
  End Property

  Private _IconFontStyle As FontStyle = FontStyle.Regular
  Public Property IconFontStyle As FontStyle
    Get
      Return _IconFontStyle
    End Get
    Set(value As FontStyle)
      _IconFontStyle = value
      setFont()
      btn.Refresh()
    End Set
  End Property

  Private _Layer1Color As Color = Color.Black
  Public Property Layer1Color As Color
    Get
      Return _Layer1Color
    End Get
    Set(value As Color)
      _Layer1Color = value
      btn.Refresh()
    End Set
  End Property
  Private _Layer1Icon As FontSegoeFluentIconsEnum
  Public Property Layer1Icon As FontSegoeFluentIconsEnum
    Get
      Return _Layer1Icon
    End Get
    Set(value As FontSegoeFluentIconsEnum)
      _Layer1Icon = value
      btn.Refresh()
    End Set
  End Property

  Private _Layer2Color As Color = Color.Black
  Public Property Layer2Color As Color
    Get
      Return _Layer2Color
    End Get
    Set(value As Color)
      _Layer2Color = value
      btn.Refresh()
    End Set
  End Property
  Private _Layer2Icon As FontSegoeFluentIconsEnum
  Public Property Layer2Icon As FontSegoeFluentIconsEnum
    Get
      Return _Layer2Icon
    End Get
    Set(value As FontSegoeFluentIconsEnum)
      _Layer2Icon = value
      btn.Refresh()
    End Set
  End Property

  Private _Layer3Color As Color = Color.Black
  Public Property Layer3Color As Color
    Get
      Return _Layer3Color
    End Get
    Set(value As Color)
      _Layer3Color = value
      btn.Refresh()
    End Set
  End Property
  Private _Layer3Icon As FontSegoeFluentIconsEnum
  Public Property Layer3Icon As FontSegoeFluentIconsEnum
    Get
      Return _Layer3Icon
    End Get
    Set(value As FontSegoeFluentIconsEnum)
      _Layer3Icon = value
      btn.Refresh()
    End Set
  End Property

  Private _Caption As String = String.Empty

  Public Property Caption As String
    Get
      Return _Caption
    End Get
    Set(value As String)
      _Caption = value
      btn.Refresh()
    End Set
  End Property

  Function ConvertToGray(color As Color) As Color
    Dim grayValue As Integer = CInt((0.299 * color.R) + (0.587 * color.G) + (0.114 * color.B))
    Return Color.FromArgb(grayValue, grayValue, grayValue)
  End Function

  Function DisableColor(color As Color) As Color
    Dim grayValue As Integer = CInt((0.299 * color.R) + (0.587 * color.G) + (0.114 * color.B))
    Return Color.FromArgb(150, grayValue, grayValue, grayValue)
  End Function

  Private Sub btn_Paint(sender As Object, e As PaintEventArgs) Handles btn.Paint
    MyBase.OnPaint(e)
    Dim g As Graphics = e.Graphics

    Dim iconBrush As Brush
    Dim iconSize As Size
    Dim iconLocation As Point

    Dim textBrush As Brush
    Dim textSize As Size = New Size(0, 0)
    Dim textAdj As Integer = 0
    Dim textLocation As Point

    If Caption.Length > 0 Then
      If Enabled Then
        textBrush = New SolidBrush(ForeColor)
      Else
        textBrush = New SolidBrush(DisableColor(ForeColor))
      End If
      textSize = TextRenderer.MeasureText(Caption, Font)
      textAdj = 4
      textLocation = New Point(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - textSize.Width) / 2), e.ClipRectangle.Bottom - textAdj - textSize.Height)
      g.DrawString(Caption, Font, textBrush, textLocation)
    End If

    If Layer1Icon > 0 Then
      If Enabled Then
        iconBrush = New SolidBrush(Layer1Color)
      Else
        iconBrush = New SolidBrush(DisableColor(Layer1Color))
      End If
      iconSize = TextRenderer.MeasureText(ChrW(Layer1Icon), icoFont)
      iconLocation = New Point(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - iconSize.Width) / 2), e.ClipRectangle.Top + ((e.ClipRectangle.Height - iconSize.Height - textSize.Height - textAdj) / 2))
      g.DrawString(ChrW(Layer1Icon), icoFont, iconBrush, iconLocation)
    End If

    If Layer2Icon > 0 Then
      If Enabled Then
        iconBrush = New SolidBrush(Layer2Color)
      Else
        iconBrush = New SolidBrush(DisableColor(Layer2Color))
      End If
      iconSize = TextRenderer.MeasureText(ChrW(Layer2Icon), icoFont)
      iconLocation = New Point(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - iconSize.Width) / 2), e.ClipRectangle.Top + ((e.ClipRectangle.Height - iconSize.Height - textSize.Height - textAdj) / 2))
      g.DrawString(ChrW(Layer2Icon), icoFont, iconBrush, iconLocation)
    End If

    If Layer3Icon > 0 Then
      If Enabled Then
        iconBrush = New SolidBrush(Layer3Color)
      Else
        iconBrush = New SolidBrush(DisableColor(Layer3Color))
      End If
      iconSize = TextRenderer.MeasureText(ChrW(Layer3Icon), icoFont)
      iconLocation = New Point(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - iconSize.Width) / 2), e.ClipRectangle.Top + ((e.ClipRectangle.Height - iconSize.Height - textSize.Height - textAdj) / 2))
      g.DrawString(ChrW(Layer3Icon), icoFont, iconBrush, iconLocation)
    End If


    ' Draw focus rectangle if button has focus
    'If (e.State And DrawItemState.Focus) = DrawItemState.Focus Then
    '  ControlPaint.DrawFocusRectangle(g, e.Bounds)
    'End If
  End Sub

  Public Sub New()
    InitializeComponent()
    setFont()
  End Sub

End Class
