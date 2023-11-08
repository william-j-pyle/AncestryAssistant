Imports System.ComponentModel
Public Class StatusBar

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BackColor As Color

  Public Property StatusBarBackColor As Color
    Get
      Return CType(Renderer, StatusBarRenderer).StatusBarBackColor
    End Get
    Set(value As Color)
      CType(Renderer, StatusBarRenderer).StatusBarBackColor = value
      MyBase.BackColor = value
    End Set
  End Property
  Public Property StatusBarFontColor As Color
    Get
      Return CType(Renderer, StatusBarRenderer).StatusBarFontColor
    End Get
    Set(value As Color)
      CType(Renderer, StatusBarRenderer).StatusBarFontColor = value
      ForeColor = value
    End Set
  End Property
  Public Property StatusBarBorderColor As Color
    Get
      Return CType(Renderer, StatusBarRenderer).StatusBarBorderColor
    End Get
    Set(value As Color)
      CType(Renderer, StatusBarRenderer).StatusBarBorderColor = value
    End Set
  End Property
  Public Property StatusBarAccentColor As Color
    Get
      Return CType(Renderer, StatusBarRenderer).StatusBarAccentColor
    End Get
    Set(value As Color)
      CType(Renderer, StatusBarRenderer).StatusBarAccentColor = value
    End Set
  End Property
  Public Property StatusBarShadowColor As Color
    Get
      Return CType(Renderer, StatusBarRenderer).StatusBarShadowColor
    End Get
    Set(value As Color)
      CType(Renderer, StatusBarRenderer).StatusBarShadowColor = value
    End Set
  End Property
  Public Property StatusBarHighlightColor As Color
    Get
      Return CType(Renderer, StatusBarRenderer).StatusBarHighlightColor
    End Get
    Set(value As Color)
      CType(Renderer, StatusBarRenderer).StatusBarHighlightColor = value
    End Set
  End Property


End Class
