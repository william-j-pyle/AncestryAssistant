Imports System.ComponentModel
Public Class MenuBar

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BackColor As Color

  Public Property MenuBarBackColor As Color
    Get
      Return CType(Renderer, MenuBarRenderer).MenuBarBackColor
    End Get
    Set(value As Color)
      CType(Renderer, MenuBarRenderer).MenuBarBackColor = value
      MyBase.BackColor = value
    End Set
  End Property
  Public Property MenuBarFontColor As Color
    Get
      Return CType(Renderer, MenuBarRenderer).MenuBarFontColor
    End Get
    Set(value As Color)
      CType(Renderer, MenuBarRenderer).MenuBarFontColor = value
      ForeColor = value
    End Set
  End Property
  Public Property MenuBarBorderColor As Color
    Get
      Return CType(Renderer, MenuBarRenderer).MenuBarBorderColor
    End Get
    Set(value As Color)
      CType(Renderer, MenuBarRenderer).MenuBarBorderColor = value
    End Set
  End Property
  Public Property MenuBarAccentColor As Color
    Get
      Return CType(Renderer, MenuBarRenderer).MenuBarAccentColor
    End Get
    Set(value As Color)
      CType(Renderer, MenuBarRenderer).MenuBarAccentColor = value
    End Set
  End Property
  Public Property MenuBarShadowColor As Color
    Get
      Return CType(Renderer, MenuBarRenderer).MenuBarShadowColor
    End Get
    Set(value As Color)
      CType(Renderer, MenuBarRenderer).MenuBarShadowColor = value
    End Set
  End Property
  Public Property MenuBarHighlightColor As Color
    Get
      Return CType(Renderer, MenuBarRenderer).MenuBarHighlightColor
    End Get
    Set(value As Color)
      CType(Renderer, MenuBarRenderer).MenuBarHighlightColor = value
    End Set
  End Property


End Class
