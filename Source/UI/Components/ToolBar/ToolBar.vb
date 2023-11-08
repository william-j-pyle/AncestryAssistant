Imports System.ComponentModel
Public Class ToolBar

  Public Sub New()
    MyBase.New()
    InitializeComponent()
  End Sub

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BackColor As Color

  Public Property ToolBarBackColor As Color
    Get
      Return CType(Renderer, ToolBarRenderer).ToolBarBackColor
    End Get
    Set(value As Color)
      CType(Renderer, ToolBarRenderer).ToolBarBackColor = value
      MyBase.BackColor = value
    End Set
  End Property
  Public Property ToolBarFontColor As Color
    Get
      Return CType(Renderer, ToolBarRenderer).ToolBarFontColor
    End Get
    Set(value As Color)
      CType(Renderer, ToolBarRenderer).ToolBarFontColor = value
      ForeColor = value
    End Set
  End Property
  Public Property ToolBarBorderColor As Color
    Get
      Return CType(Renderer, ToolBarRenderer).ToolBarBorderColor
    End Get
    Set(value As Color)
      CType(Renderer, ToolBarRenderer).ToolBarBorderColor = value
    End Set
  End Property
  Public Property ToolBarAccentColor As Color
    Get
      Return CType(Renderer, ToolBarRenderer).ToolBarAccentColor
    End Get
    Set(value As Color)
      CType(Renderer, ToolBarRenderer).ToolBarAccentColor = value
    End Set
  End Property
  Public Property ToolBarShadowColor As Color
    Get
      Return CType(Renderer, ToolBarRenderer).ToolBarShadowColor
    End Get
    Set(value As Color)
      CType(Renderer, ToolBarRenderer).ToolBarShadowColor = value
    End Set
  End Property
  Public Property ToolBarHighlightColor As Color
    Get
      Return CType(Renderer, ToolBarRenderer).ToolBarHighlightColor
    End Get
    Set(value As Color)
      CType(Renderer, ToolBarRenderer).ToolBarHighlightColor = value
    End Set
  End Property


End Class
