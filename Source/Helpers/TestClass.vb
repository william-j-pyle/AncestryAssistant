Imports System.ComponentModel
Imports System.Windows.Forms.Layout

Public Class TestClass
  Inherits UserControl

#Region "Properties"

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property AllowDrop As Boolean
    Get
      Return MyBase.AllowDrop
    End Get
    Set(value As Boolean)
      MyBase.AllowDrop = value
    End Set
  End Property

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property Anchor As AnchorStyles
    Get
      Return MyBase.Anchor
    End Get
    Set(value As AnchorStyles)
      MyBase.Anchor = value
    End Set
  End Property

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property AutoScroll As Boolean
    Get
      Return MyBase.AutoScroll
    End Get
    Set(value As Boolean)
      MyBase.AutoScroll = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property AutoScrollOffset As Point
    Get
      Return MyBase.AutoScrollOffset
    End Get
    Set(value As Point)
      MyBase.AutoScrollOffset = value
    End Set
  End Property

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property AutoSize As Boolean
    Get
      Return MyBase.AutoSize
    End Get
    Set(value As Boolean)
      MyBase.AutoSize = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property AutoValidate As AutoValidate
    Get
      Return MyBase.AutoValidate
    End Get
    Set(value As AutoValidate)
      MyBase.AutoValidate = value
    End Set
  End Property
  Public Overrides Property BackColor As Color
    Get
      Return MyBase.BackColor
    End Get
    Set(value As Color)
      MyBase.BackColor = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property BackgroundImage As Image
    Get
      Return MyBase.BackgroundImage
    End Get
    Set(value As Image)
      MyBase.BackgroundImage = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property BackgroundImageLayout As ImageLayout
    Get
      Return MyBase.BackgroundImageLayout
    End Get
    Set(value As ImageLayout)
      MyBase.BackgroundImageLayout = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property ContextMenu As ContextMenu
    Get
      Return MyBase.ContextMenu
    End Get
    Set(value As ContextMenu)
      MyBase.ContextMenu = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property ContextMenuStrip As ContextMenuStrip
    Get
      Return MyBase.ContextMenuStrip
    End Get
    Set(value As ContextMenuStrip)
      MyBase.ContextMenuStrip = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property Cursor As Cursor
    Get
      Return MyBase.Cursor
    End Get
    Set(value As Cursor)
      MyBase.Cursor = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides ReadOnly Property DisplayRectangle As Rectangle
    Get
      Return MyBase.DisplayRectangle
    End Get
  End Property
  Public Overrides Property Dock As DockStyle
    Get
      Return MyBase.Dock
    End Get
    Set(value As DockStyle)
      MyBase.Dock = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides ReadOnly Property Focused As Boolean
    Get
      Return MyBase.Focused
    End Get
  End Property
  Public Overrides Property Font As Font
    Get
      Return MyBase.Font
    End Get
    Set(value As Font)
      MyBase.Font = value
    End Set
  End Property
  Public Overrides Property ForeColor As Color
    Get
      Return MyBase.ForeColor
    End Get
    Set(value As Color)
      MyBase.ForeColor = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides ReadOnly Property LayoutEngine As LayoutEngine
    Get
      Return MyBase.LayoutEngine
    End Get
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property MaximumSize As Size
    Get
      Return MyBase.MaximumSize
    End Get
    Set(value As Size)
      MyBase.MaximumSize = value
    End Set
  End Property

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property MinimumSize As Size
    Get
      Return MyBase.MinimumSize
    End Get
    Set(value As Size)
      MyBase.MinimumSize = value
    End Set
  End Property

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property RightToLeft As RightToLeft
    Get
      Return MyBase.RightToLeft
    End Get
    Set(value As RightToLeft)
      MyBase.RightToLeft = value
    End Set
  End Property

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Overrides Property Site As ISite
    Get
      Return MyBase.Site
    End Get
    Set(value As ISite)
      MyBase.Site = value
    End Set
  End Property
  Public Overrides Property Text As String
    Get
      Return MyBase.Text
    End Get
    Set(value As String)
      MyBase.Text = value
    End Set
  End Property

#End Region

End Class