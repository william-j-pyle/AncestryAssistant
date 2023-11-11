Public Class RibbonButton
  Inherits UserControl

  Private theme As UITheme = UITheme.GetInstance
  Private icoFont As Font
  Private components As System.ComponentModel.IContainer
  Friend WithEvents btn As Button

  Public Event SettingsChanged()

  Private Sub setSizing() Handles Me.SettingsChanged
    Dim h As Integer
    Dim w As Integer
    If RibbonButtonSize = RibbonButtonSizeEnum.LargeButton Then
      h = 72
      w = 48
    Else
      h = 24
      w = 24
      If _IconSize > IconSizeEnum.Icon20x20 Then
        _IconSize = IconSizeEnum.Icon20x20
      End If
    End If
    MinimumSize = New Size(w, h)
    MaximumSize = New Size(w, h)
    Size = New Size(w, h)
    icoFont = New System.Drawing.Font("Segoe Fluent Icons", IconSize, IconFontStyle, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
    With btn
      .MinimumSize = New Size(w, h)
      .MaximumSize = New Size(w, h)
      .size = New Size(w, h)
      .Refresh()
    End With
  End Sub


  Private _RibbonButtonSize As RibbonButtonSizeEnum = RibbonButtonSizeEnum.LargeButton
  Public Property RibbonButtonSize As RibbonButtonSizeEnum
    Get
      Return _RibbonButtonSize
    End Get
    Set(value As RibbonButtonSizeEnum)
      _RibbonButtonSize = value
      RaiseEvent SettingsChanged()
    End Set
  End Property


  Private _IconSize As IconSizeEnum = IconSizeEnum.Icon32x32
  Public Property IconSize As IconSizeEnum
    Get
      Return _IconSize
    End Get
    Set(value As IconSizeEnum)
      _IconSize = value
      RaiseEvent SettingsChanged()
    End Set
  End Property

  Private _IconFontStyle As FontStyle = FontStyle.Regular
  Public Property IconFontStyle As FontStyle
    Get
      Return _IconFontStyle
    End Get
    Set(value As FontStyle)
      _IconFontStyle = value
      RaiseEvent SettingsChanged()
    End Set
  End Property

  Private _Layer1Color As Color = Color.Black
  Public Property Layer1Color As Color
    Get
      Return _Layer1Color
    End Get
    Set(value As Color)
      _Layer1Color = value
      RaiseEvent SettingsChanged()
    End Set
  End Property
  Private _Layer1Icon As FontSegoeFluentIconsEnum
  Public Property Layer1Icon As FontSegoeFluentIconsEnum
    Get
      Return _Layer1Icon
    End Get
    Set(value As FontSegoeFluentIconsEnum)
      _Layer1Icon = value
      RaiseEvent SettingsChanged()
    End Set
  End Property

  Private _Layer2Color As Color = Color.Black
  Public Property Layer2Color As Color
    Get
      Return _Layer2Color
    End Get
    Set(value As Color)
      _Layer2Color = value
      RaiseEvent SettingsChanged()
    End Set
  End Property
  Private _Layer2Icon As FontSegoeFluentIconsEnum
  Public Property Layer2Icon As FontSegoeFluentIconsEnum
    Get
      Return _Layer2Icon
    End Get
    Set(value As FontSegoeFluentIconsEnum)
      _Layer2Icon = value
      RaiseEvent SettingsChanged()
    End Set
  End Property

  Private _Layer3Color As Color = Color.Black
  Public Property Layer3Color As Color
    Get
      Return _Layer3Color
    End Get
    Set(value As Color)
      _Layer3Color = value
      RaiseEvent SettingsChanged()
    End Set
  End Property
  Private _Layer3Icon As FontSegoeFluentIconsEnum
  Public Property Layer3Icon As FontSegoeFluentIconsEnum
    Get
      Return _Layer3Icon
    End Get
    Set(value As FontSegoeFluentIconsEnum)
      _Layer3Icon = value
      RaiseEvent SettingsChanged()
    End Set
  End Property

  Private _Caption As String = String.Empty

  Public Property Caption As String
    Get
      Return _Caption
    End Get
    Set(value As String)
      _Caption = value
      RaiseEvent SettingsChanged()
    End Set
  End Property

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
        textBrush = New SolidBrush(theme.ColorToDisabled(ForeColor))
      End If
      textSize = TextRenderer.MeasureText(Caption, Font)
      textAdj = 0
      textLocation = New Point(CInt(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - textSize.Width) / 2)), CInt(e.ClipRectangle.Bottom - textAdj - textSize.Height))
      g.DrawString(Caption, Font, textBrush, textLocation)
    End If

    If Layer1Icon > 0 Then
      If Enabled Then
        iconBrush = New SolidBrush(Layer1Color)
      Else
        iconBrush = New SolidBrush(theme.ColorToDisabled(Layer1Color))
      End If
      iconSize = TextRenderer.MeasureText(ChrW(Layer1Icon), icoFont)
      iconLocation = New Point(CInt(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - iconSize.Width) / 2)), CInt(e.ClipRectangle.Top + ((e.ClipRectangle.Height - iconSize.Height - textSize.Height - textAdj) / 2)))
      g.DrawString(ChrW(Layer1Icon), icoFont, iconBrush, iconLocation)
    End If

    If Layer2Icon > 0 Then
      If Enabled Then
        iconBrush = New SolidBrush(Layer2Color)
      Else
        iconBrush = New SolidBrush(theme.ColorToDisabled(Layer2Color))
      End If
      iconSize = TextRenderer.MeasureText(ChrW(Layer2Icon), icoFont)
      iconLocation = New Point(CInt(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - iconSize.Width) / 2)), CInt(e.ClipRectangle.Top + ((e.ClipRectangle.Height - iconSize.Height - textSize.Height - textAdj) / 2)))
      g.DrawString(ChrW(Layer2Icon), icoFont, iconBrush, iconLocation)
    End If

    If Layer3Icon > 0 Then
      If Enabled Then
        iconBrush = New SolidBrush(Layer3Color)
      Else
        iconBrush = New SolidBrush(theme.ColorToDisabled(Layer3Color))
      End If
      iconSize = TextRenderer.MeasureText(ChrW(Layer3Icon), icoFont)
      iconLocation = New Point(CInt(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - iconSize.Width) / 2)), CInt(e.ClipRectangle.Top + ((e.ClipRectangle.Height - iconSize.Height - textSize.Height - textAdj) / 2)))
      g.DrawString(ChrW(Layer3Icon), icoFont, iconBrush, iconLocation)
    End If


    ' Draw focus rectangle if button has focus
    'If (e.State And DrawItemState.Focus) = DrawItemState.Focus Then
    '  ControlPaint.DrawFocusRectangle(g, e.Bounds)
    'End If
  End Sub

  Public Sub New()
    btn = New System.Windows.Forms.Button()
    SuspendLayout()
    With btn
      .Dock = System.Windows.Forms.DockStyle.Fill
      .FlatAppearance.BorderSize = 0
      .FlatStyle = System.Windows.Forms.FlatStyle.Flat
      .Location = New System.Drawing.Point(0, 0)
      .Margin = New System.Windows.Forms.Padding(0)
      .UseMnemonic = False
      .UseVisualStyleBackColor = False
    End With
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Controls.Add(btn)
    BackColor = SystemColors.ButtonFace
    DoubleBuffered = True
    Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Margin = New System.Windows.Forms.Padding(0)
    Name = "JButton"
    setSizing()
    ResumeLayout(False)
  End Sub

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

End Class
