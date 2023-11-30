Public Class OLDFlatButton
  Inherits UserControl

#Region "Fields"

  'Back Color
  Private _BackColor As Color = SystemColors.ControlLight

  'Border Color Bottom
  Private _BorderBottomColor As Color = SystemColors.ActiveBorder

  'Border Size Bottom
  Private _BorderBottomSize As Integer = 0

  'Border Color Left
  Private _BorderLeftColor As Color = SystemColors.ActiveBorder

  'Border Size Left
  Private _BorderLeftSize As Integer = 0

  'Border Color Right
  Private _BorderRightColor As Color = SystemColors.ActiveBorder

  'Border Size Right
  Private _BorderRightSize As Integer = 0

  'Border Color Top
  Private _BorderTopColor As Color = SystemColors.ActiveBorder

  'Border Size Top
  Private _BorderTopSize As Integer = 0

  Private _btnState As IconButtonStateEnum = IconButtonStateEnum.STANDARD

  'Button Size
  Private _ButtonSize As IconSizeEnum = IconSizeEnum.Icon20x20

  'Checked
  Private _Checked As Boolean = False

  'AncestryIcon Layer 0
  Private _IconAncestry0 As FontAncestryIconEnum = FontAncestryIconEnum.BLANK

  'AncestryIcon ForeColor
  Private _IconAncestry0_Forecolor As Color = SystemColors.ControlText

  'AncestryIcon Size
  Private _IconAncestry0_Size As IconSizeEnum = IconSizeEnum.Icon20x20

  'AncestryIcon Layer 0
  Private _IconAncestry1 As FontAncestryIconEnum = FontAncestryIconEnum.BLANK

  'AncestryIcon ForeColor
  Private _IconAncestry1_Forecolor As Color = SystemColors.ControlText

  'AncestryIcon Size
  Private _IconAncestry1_Size As IconSizeEnum = IconSizeEnum.Icon20x20

  'SegoeIcon Layer 0
  Private _IconSegoe0 As FontSegoeFluentIconsEnum = FontSegoeFluentIconsEnum.Blank

  'SegoeIcon ForeColor
  Private _IconSegoe0_Forecolor As Color = SystemColors.ControlText

  'SegoeIcon Size
  Private _IconSegoe0_Size As IconSizeEnum = IconSizeEnum.Icon20x20

  'SegoeIcon Layer 0
  Private _IconSegoe1 As FontSegoeFluentIconsEnum = FontSegoeFluentIconsEnum.Blank

  'SegoeIcon ForeColor
  Private _IconSegoe1_Forecolor As Color = SystemColors.ControlText

  'SegoeIcon Size
  Private _IconSegoe1_Size As IconSizeEnum = IconSizeEnum.Icon20x20

  'Show Borders
  Private _ShowBorder As Boolean = False

  Private components As System.ComponentModel.IContainer

#End Region

#Region "Events"

  'On Checked
  Public Event ButtonCheckChanged(sender As Object, e As EventArgs)

  Public Event ButtonClick(sender As Object, e As EventArgs)

  Public Event ButtonStateChanged(state As IconButtonStateEnum)

#End Region

#Region "Properties"

  'Back Color Click
  Public Property BackClickColor As Color = SystemColors.ControlDark

  Public Shadows Property BackColor As Color
    Get
      Return _BackColor
    End Get
    Set(value As Color)
      _BackColor = value
      MyBase.BackColor = _BackColor
      Refresh()
    End Set
  End Property

  'Back Color Hover
  Public Property BackHoverColor As Color = SystemColors.ControlDarkDark

  Public Property BorderBottomColor As Color
    Get
      Return _BorderBottomColor
    End Get
    Set(value As Color)
      _BorderBottomColor = value
      Refresh()
    End Set
  End Property

  Public Property BorderBottomSize As Integer
    Get
      Return _BorderBottomSize
    End Get
    Set(value As Integer)
      _BorderBottomSize = value
      Refresh()
    End Set
  End Property

  Public Property BorderLeftColor As Color
    Get
      Return _BorderLeftColor
    End Get
    Set(value As Color)
      _BorderLeftColor = value
      Refresh()
    End Set
  End Property

  Public Property BorderLeftSize As Integer
    Get
      Return _BorderLeftSize
    End Get
    Set(value As Integer)
      _BorderLeftSize = value
      Refresh()
    End Set
  End Property

  Public Property BorderRightColor As Color
    Get
      Return _BorderRightColor
    End Get
    Set(value As Color)
      _BorderRightColor = value
      Refresh()
    End Set
  End Property

  Public Property BorderRightSize As Integer
    Get
      Return _BorderRightSize
    End Get
    Set(value As Integer)
      _BorderRightSize = value
      Refresh()
    End Set
  End Property

  Public Property BorderTopColor As Color
    Get
      Return _BorderTopColor
    End Get
    Set(value As Color)
      _BorderTopColor = value
      Refresh()
    End Set
  End Property

  Public Property BorderTopSize As Integer
    Get
      Return _BorderTopSize
    End Get
    Set(value As Integer)
      _BorderTopSize = value
      Refresh()
    End Set
  End Property

  Public Property btnState As IconButtonStateEnum
    Get
      Return _btnState
    End Get
    Set(value As IconButtonStateEnum)
      _btnState = value
      RaiseEvent ButtonStateChanged(value)
    End Set
  End Property

  Public Property ButtonSize As IconSizeEnum
    Get
      Return _ButtonSize
    End Get
    Set(value As IconSizeEnum)
      _ButtonSize = value
      If _ButtonSize <> IconSizeEnum.Custom Then
        Size = New Size(value, value)
        MaximumSize = New Size(value, value)
        MinimumSize = New Size(value, value)
      End If
    End Set
  End Property

  Public Property Checked As Boolean
    Get
      Return _Checked
    End Get
    Set(value As Boolean)
      _Checked = value
      RaiseEvent ButtonCheckChanged(Me, New EventArgs())
      Refresh()
    End Set
  End Property

  'Check On Click
  Public Property CheckOnClick As Boolean = False

  Public Property IconAncestry0 As FontAncestryIconEnum
    Get
      Return _IconAncestry0
    End Get
    Set(value As FontAncestryIconEnum)
      _IconAncestry0 = value
      Refresh()
    End Set
  End Property

  Public Property IconAncestry0_AdjH As Integer = 0
  Public Property IconAncestry0_AdjV As Integer = 0
  Public Property IconAncestry0_Bold As Boolean = False
  Public Property IconAncestry0_DisabledForeColor As Color = SystemColors.ControlDarkDark
  Public Property IconAncestry0_Forecolor As Color
    Get
      Return _IconAncestry0_Forecolor
    End Get
    Set(value As Color)
      _IconAncestry0_Forecolor = value
      Refresh()
    End Set
  End Property

  Public Property IconAncestry0_HoverForeColor As Color = SystemColors.ControlLight
  Public Property IconAncestry0_Size As IconSizeEnum
    Get
      Return _IconAncestry0_Size
    End Get
    Set(value As IconSizeEnum)
      _IconAncestry0_Size = value
      Refresh()
    End Set
  End Property

  Public Property IconAncestry1 As FontAncestryIconEnum
    Get
      Return _IconAncestry1
    End Get
    Set(value As FontAncestryIconEnum)
      _IconAncestry1 = value
      Refresh()
    End Set
  End Property

  Public Property IconAncestry1_AdjH As Integer = 0
  Public Property IconAncestry1_AdjV As Integer = 0
  Public Property IconAncestry1_Bold As Boolean = False
  Public Property IconAncestry1_DisabledForeColor As Color = SystemColors.ControlDarkDark
  Public Property IconAncestry1_Forecolor As Color
    Get
      Return _IconAncestry1_Forecolor
    End Get
    Set(value As Color)
      _IconAncestry1_Forecolor = value
      Refresh()
    End Set
  End Property

  Public Property IconAncestry1_HoverForeColor As Color = SystemColors.ControlLight
  Public Property IconAncestry1_Size As IconSizeEnum
    Get
      Return _IconAncestry1_Size
    End Get
    Set(value As IconSizeEnum)
      _IconAncestry1_Size = value
      Refresh()
    End Set
  End Property

  Public Property IconSegoe0 As FontSegoeFluentIconsEnum
    Get
      Return _IconSegoe0
    End Get
    Set(value As FontSegoeFluentIconsEnum)
      _IconSegoe0 = value
      Refresh()
    End Set
  End Property

  Public Property IconSegoe0_AdjH As Integer = 0
  Public Property IconSegoe0_AdjV As Integer = 0
  Public Property IconSegoe0_Bold As Boolean = False
  Public Property IconSegoe0_DisabledForeColor As Color = SystemColors.ControlDarkDark
  Public Property IconSegoe0_Forecolor As Color
    Get
      Return _IconSegoe0_Forecolor
    End Get
    Set(value As Color)
      _IconSegoe0_Forecolor = value
      Refresh()
    End Set
  End Property

  Public Property IconSegoe0_HoverForeColor As Color = SystemColors.ControlLight
  Public Property IconSegoe0_Size As IconSizeEnum
    Get
      Return _IconSegoe0_Size
    End Get
    Set(value As IconSizeEnum)
      _IconSegoe0_Size = value
      Refresh()
    End Set
  End Property

  Public Property IconSegoe1 As FontSegoeFluentIconsEnum
    Get
      Return _IconSegoe1
    End Get
    Set(value As FontSegoeFluentIconsEnum)
      _IconSegoe1 = value
      Refresh()
    End Set
  End Property

  Public Property IconSegoe1_AdjH As Integer = 0
  Public Property IconSegoe1_AdjV As Integer = 0
  Public Property IconSegoe1_Bold As Boolean = False
  Public Property IconSegoe1_DisabledForeColor As Color = SystemColors.ControlDarkDark
  Public Property IconSegoe1_Forecolor As Color
    Get
      Return _IconSegoe1_Forecolor
    End Get
    Set(value As Color)
      _IconSegoe1_Forecolor = value
      Refresh()
    End Set
  End Property

  Public Property IconSegoe1_HoverForeColor As Color = SystemColors.ControlLight
  Public Property IconSegoe1_Size As IconSizeEnum
    Get
      Return _IconSegoe1_Size
    End Get
    Set(value As IconSizeEnum)
      _IconSegoe1_Size = value
      Refresh()
    End Set
  End Property

  Public Property ShowBorder As Boolean
    Get
      Return _ShowBorder
    End Get
    Set(value As Boolean)
      _ShowBorder = value
      Refresh()
    End Set
  End Property

  'Show Click
  Public Property ShowClick As Boolean = False

  'Show Hover
  Public Property ShowHover As Boolean = False

  'ThemeComponentId
  Public Property ThemeComponentId As String

  'ThemeStyle
  Public Property ThemeStyle As String
    Get
      Return ""
    End Get
    Set(value As String)
      If value IsNot Nothing Then
        If value.Length > 0 Then
          Dim allparams() As String = value.Split(","c)
          For Each param As String In allparams
            Dim p() As String = param.Split(":"c)
            Dim key As String = p(0)
            Dim val As String = p(1)
            Select Case key
              Case "BackClickColor"
                BackClickColor = Color.FromArgb(CInt(val))
              Case "BackColor"
                BackColor = Color.FromArgb(CInt(val))
              Case "BackHoverColor"
                BackHoverColor = Color.FromArgb(CInt(val))
              Case "BorderBottomColor"
                BorderBottomColor = Color.FromArgb(CInt(val))
              Case "BorderLeftColor"
                BorderLeftColor = Color.FromArgb(CInt(val))
              Case "BorderRightColor"
                BorderRightColor = Color.FromArgb(CInt(val))
              Case "BorderTopColor"
                BorderTopColor = Color.FromArgb(CInt(val))
              Case "ButtonSize"
                ButtonSize = CType(val, IconSizeEnum)
              Case "Checked"
                Checked = Boolean.Parse(val)
              Case "CheckOnClick"
                CheckOnClick = Boolean.Parse(val)
              Case "Enabled"
                Enabled = Boolean.Parse(val)
              Case "IconAncestry0"
                IconAncestry0 = CType(val, FontAncestryIconEnum)
              Case "IconAncestry0_Bold"
                IconAncestry0_Bold = Boolean.Parse(val)
              Case "IconAncestry0_DisabledForeColor"
                IconAncestry0_DisabledForeColor = Color.FromArgb(CInt(val))
              Case "IconAncestry0_Forecolor"
                IconAncestry0_Forecolor = Color.FromArgb(CInt(val))
              Case "IconAncestry0_HoverForeColor"
                IconAncestry0_HoverForeColor = Color.FromArgb(CInt(val))
              Case "IconAncestry0_Size"
                IconAncestry0_Size = CType(val, IconSizeEnum)
              Case "IconAncestry1"
                IconAncestry1 = CType(val, FontAncestryIconEnum)
              Case "IconAncestry1_Bold"
                IconAncestry1_Bold = Boolean.Parse(val)
              Case "IconAncestry1_DisabledForeColor"
                IconAncestry1_DisabledForeColor = Color.FromArgb(CInt(val))
              Case "IconAncestry1_Forecolor"
                IconAncestry1_Forecolor = Color.FromArgb(CInt(val))
              Case "IconAncestry1_HoverForeColor"
                IconAncestry1_HoverForeColor = Color.FromArgb(CInt(val))
              Case "IconAncestry1_Size"
                IconAncestry1_Size = CType(val, IconSizeEnum)
              Case "IconSegoe0"
                IconSegoe0 = CType(val, FontSegoeFluentIconsEnum)
              Case "IconSegoe0_Bold"
                IconSegoe0_Bold = Boolean.Parse(val)
              Case "IconSegoe0_DisabledForeColor"
                IconSegoe0_DisabledForeColor = Color.FromArgb(CInt(val))
              Case "IconSegoe0_Forecolor"
                IconSegoe0_Forecolor = Color.FromArgb(CInt(val))
              Case "IconSegoe0_HoverForeColor"
                IconSegoe0_HoverForeColor = Color.FromArgb(CInt(val))
              Case "IconSegoe0_Size"
                IconSegoe0_Size = CType(val, IconSizeEnum)
              Case "IconSegoe1"
                IconSegoe1 = CType(val, FontSegoeFluentIconsEnum)
              Case "IconSegoe1_Bold"
                IconSegoe1_Bold = Boolean.Parse(val)
              Case "IconSegoe1_DisabledForeColor"
                IconSegoe1_DisabledForeColor = Color.FromArgb(CInt(val))
              Case "IconSegoe1_Forecolor"
                IconSegoe1_Forecolor = Color.FromArgb(CInt(val))
              Case "IconSegoe1_HoverForeColor"
                IconSegoe1_HoverForeColor = Color.FromArgb(CInt(val))
              Case "IconSegoe1_Size"
                IconSegoe1_Size = CType(val, IconSizeEnum)
              Case "ShowBorder"
                ShowBorder = Boolean.Parse(val)
              Case "ShowClick"
                ShowClick = Boolean.Parse(val)
              Case "ShowHover"
                ShowHover = Boolean.Parse(val)
            End Select
          Next
        End If
      End If
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    ButtonSize = _ButtonSize
  End Sub

#End Region

#Region "Private Methods"

  Private Sub IconButton_CheckChanged(sender As Object, e As EventArgs) Handles Me.ButtonCheckChanged
    If Enabled And (btnState = IconButtonStateEnum.STANDARD Or btnState = IconButtonStateEnum.CHECKED) Then
      SetButtonState(False, False)
    End If
  End Sub

  Private Sub IconButton_Click(sender As Object, e As EventArgs) Handles Me.Click
    If Enabled And CheckOnClick Then
      Checked = Not Checked
    End If
    SetButtonState(True, False)
    ' Need to raise click or check events to public
    RaiseEvent ButtonClick(Me, e)
  End Sub

  Private Sub IconButton_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
    SetButtonState(True, True)
  End Sub

  Private Sub IconButton_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
    SetButtonState(True, False)
  End Sub

  Private Sub IconButton_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
    SetButtonState(False, False)
  End Sub

  Private Sub IconButton_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    'MyBase.OnPaint(e)
    Dim g As Graphics = e.Graphics

    Dim iconFont As Font
    Dim iconFontStyle As FontStyle
    Dim iconBrush As Brush
    Dim iconSize As Size
    Dim iconLocation As Point

    If IconSegoe0 > 0 Then
      If Enabled Then
        If btnState = IconButtonStateEnum.HOVERING Then
          iconBrush = New SolidBrush(IconSegoe0_HoverForeColor)
        Else
          iconBrush = New SolidBrush(IconSegoe0_Forecolor)
        End If
      Else
        iconBrush = New SolidBrush(IconSegoe0_DisabledForeColor)
      End If
      If IconSegoe0_Bold Then
        iconFontStyle = FontStyle.Bold
      Else
        iconFontStyle = FontStyle.Regular
      End If
      iconFont = New System.Drawing.Font("Segoe Fluent Icons", IconSegoe0_Size, iconFontStyle, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
      iconSize = TextRenderer.MeasureText(ChrW(IconSegoe0), iconFont)
      iconLocation = New Point(IconSegoe0_AdjH + CInt(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - iconSize.Width) / 2)), IconSegoe0_AdjV + CInt(e.ClipRectangle.Top + ((e.ClipRectangle.Height - iconSize.Height) / 2)))
      g.DrawString(ChrW(IconSegoe0), iconFont, iconBrush, iconLocation)
    End If

    If IconSegoe1 > 0 Then
      If Enabled Then
        If btnState = IconButtonStateEnum.HOVERING Then
          iconBrush = New SolidBrush(IconSegoe1_HoverForeColor)
        Else
          iconBrush = New SolidBrush(IconSegoe1_Forecolor)
        End If
      Else
        iconBrush = New SolidBrush(IconSegoe1_DisabledForeColor)
      End If
      If IconSegoe1_Bold Then
        iconFontStyle = FontStyle.Bold
      Else
        iconFontStyle = FontStyle.Regular
      End If
      iconFont = New System.Drawing.Font("Segoe Fluent Icons", IconSegoe1_Size, iconFontStyle, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
      iconSize = TextRenderer.MeasureText(ChrW(IconSegoe1), iconFont)
      iconLocation = New Point(IconSegoe1_AdjH + CInt(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - iconSize.Width) / 2)), IconSegoe0_AdjV + CInt(e.ClipRectangle.Top + ((e.ClipRectangle.Height - iconSize.Height) / 2)))
      g.DrawString(ChrW(IconSegoe1), iconFont, iconBrush, iconLocation)
    End If

    If IconAncestry0 > 0 Then
      If Enabled Then
        If btnState = IconButtonStateEnum.HOVERING Then
          iconBrush = New SolidBrush(IconAncestry0_HoverForeColor)
        Else
          iconBrush = New SolidBrush(IconAncestry0_Forecolor)
        End If
      Else
        iconBrush = New SolidBrush(IconAncestry0_DisabledForeColor)
      End If
      If IconAncestry0_Bold Then
        iconFontStyle = FontStyle.Bold
      Else
        iconFontStyle = FontStyle.Regular
      End If
      iconFont = New System.Drawing.Font("ancestry-icon", IconAncestry0_Size, iconFontStyle, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
      iconSize = TextRenderer.MeasureText(ChrW(IconAncestry0), iconFont)
      iconLocation = New Point(IconAncestry0_AdjH + CInt(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - iconSize.Width) / 2)), IconAncestry0_AdjV + CInt(e.ClipRectangle.Top + ((e.ClipRectangle.Height - iconSize.Height) / 2)))
      g.DrawString(ChrW(IconAncestry0), iconFont, iconBrush, iconLocation)
    End If

    If IconAncestry1 > 0 Then
      If Enabled Then
        If btnState = IconButtonStateEnum.HOVERING Then
          iconBrush = New SolidBrush(IconAncestry1_HoverForeColor)
        Else
          iconBrush = New SolidBrush(IconAncestry1_Forecolor)
        End If
      Else
        iconBrush = New SolidBrush(IconAncestry1_DisabledForeColor)
      End If
      If IconAncestry1_Bold Then
        iconFontStyle = FontStyle.Bold
      Else
        iconFontStyle = FontStyle.Regular
      End If
      iconFont = New System.Drawing.Font("ancestry-icon", IconAncestry1_Size, iconFontStyle, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
      iconSize = TextRenderer.MeasureText(ChrW(IconAncestry1), iconFont)
      iconLocation = New Point(IconAncestry1_AdjH + CInt(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - iconSize.Width) / 2)), IconAncestry1_AdjV + CInt(e.ClipRectangle.Top + ((e.ClipRectangle.Height - iconSize.Height) / 2)))
      g.DrawString(ChrW(IconAncestry1), iconFont, iconBrush, iconLocation)
    End If

  End Sub

  Private Sub SetButtonState(mouseOver As Boolean, mouseDown As Boolean)
    If Enabled Then
      If mouseOver Then
        If mouseDown And ShowClick And btnState <> IconButtonStateEnum.PRESSED Then
          btnState = IconButtonStateEnum.PRESSED
          MyBase.BackColor = BackClickColor
          Exit Sub
        End If
        If Not mouseDown And ShowHover And btnState <> IconButtonStateEnum.HOVERING Then
          btnState = IconButtonStateEnum.HOVERING
          MyBase.BackColor = BackHoverColor
          Exit Sub
        End If
      Else
        If Checked And btnState <> IconButtonStateEnum.CHECKED Then
          btnState = IconButtonStateEnum.CHECKED
          MyBase.BackColor = BackClickColor
          Exit Sub
        End If
        If Not Checked And btnState <> IconButtonStateEnum.STANDARD Then
          btnState = IconButtonStateEnum.STANDARD
          MyBase.BackColor = BackColor
          Exit Sub
        End If
      End If
    Else
      If btnState <> IconButtonStateEnum.DISABLED Then
        btnState = IconButtonStateEnum.DISABLED
        MyBase.BackColor = BackColor
      End If
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

#Region "Public Methods"

  Function ConvertToGray(color As Color) As Color
    Dim grayValue As Integer = CInt((0.299 * color.R) + (0.587 * color.G) + (0.114 * color.B))
    Return Color.FromArgb(grayValue, grayValue, grayValue)
  End Function

  Function DisableColor(color As Color) As Color
    Dim grayValue As Integer = CInt((0.299 * color.R) + (0.587 * color.G) + (0.114 * color.B))
    Return Color.FromArgb(150, grayValue, grayValue, grayValue)
  End Function

#End Region

#Region "Enums"

  Public Enum IconButtonStateEnum
    DISABLED
    STANDARD
    HOVERING
    CHECKED
    PRESSED
  End Enum

#End Region

End Class