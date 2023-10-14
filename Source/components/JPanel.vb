Imports System.ComponentModel

Public Class JPanel
  Inherits Panel

  Private _BorderRadius As Integer = 0
  Dim _BorderWidth As Integer = 0
  Dim _BorderColor As Color = Color.DimGray

  Public Sub New()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
  End Sub


  <Category("Apperance"), Description("Sets the pixel width of the border")>
  Public Property BorderWidth As Integer
    Get
      Return _BorderWidth
    End Get
    Set(value As Integer)
      If value < 0 Then value = 0
      _BorderWidth = value
      Padding = New Padding(value)
      Refresh()
    End Set
  End Property

  <Category("Apperance"), Description("Sets the border color")>
  Public Property BorderColor As Color
    Get
      Return _BorderColor
    End Get
    Set(value As Color)
      _BorderColor = value
      Refresh()
    End Set
  End Property


  Public Shadows Property Margin As Padding
    Get
      Return MyBase.Margin
    End Get
    Set(value As Padding)
      MyBase.Margin = value
      Refresh()
    End Set
  End Property

  <Category("Apperance"), Description("Sets the number of pixels for the corner radius")>
  Public Property BorderRadius As Integer
    Get
      Return _BorderRadius
    End Get
    Set(value As Integer)
      If value < 0 Then value = 0
      _BorderRadius = value
      Refresh()
    End Set
  End Property

  Protected Overrides Sub OnResize(eventargs As EventArgs)
    Refresh()
    MyBase.OnResize(eventargs)
  End Sub

  Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
    'Dim gfx As Graphics = e.Graphics
    'Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 9)
    Dim radius As Integer = _BorderRadius + 1
    Dim bgWidth As Integer = Width - Margin.Left - Margin.Right
    Dim bgHeight As Integer = Height - Margin.Top - Margin.Bottom


    Dim path As New Drawing2D.GraphicsPath()
    path.StartFigure()
    path.AddArc(New Rectangle(Margin.Left, 0, radius * 2, radius * 2), 180, 90)
    path.AddLine(Margin.Left + radius, 0, bgWidth - radius, 0)
    path.AddArc(New Rectangle(Margin.Left + bgWidth - (radius * 2), 0, radius * 2, radius * 2), -90, 90)
    path.AddLine(Margin.Left + bgWidth, radius, Margin.Left + bgWidth, bgHeight - radius)
    path.AddArc(New Rectangle(Margin.Left + bgWidth - (radius * 2), bgHeight - (radius * 2), radius * 2, radius * 2), 0, 90)
    path.AddLine(Margin.Left + bgWidth - radius, bgHeight, radius, bgHeight)
    path.AddArc(New Rectangle(Margin.Left, bgHeight - (radius * 2), radius * 2, radius * 2), 90, 90)
    path.AddLine(Margin.Left, bgHeight - radius, Margin.Left, radius)
    path.CloseFigure()
    Region = New Region(path)
    Using brush As SolidBrush = New SolidBrush(BackColor)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using
    Dim jPen As Pen

    'LEFT
    If _BorderWidth > 0 Then
      jPen = New Pen(_BorderColor, _BorderWidth * 2)
      e.Graphics.DrawArc(jPen, New Rectangle(Margin.Left, 0, radius * 2, radius * 2), 180, 90)
      e.Graphics.DrawLine(jPen, Margin.Left + radius, 0, bgWidth, 0) ' - radius
      e.Graphics.DrawArc(jPen, New Rectangle(Margin.Left + bgWidth - (radius * 2), 0, radius * 2, radius * 2), -90, 90)
      e.Graphics.DrawLine(jPen, Margin.Left + bgWidth, radius, Margin.Left + bgWidth, bgHeight - radius)
      e.Graphics.DrawArc(jPen, New Rectangle(Margin.Left + bgWidth - (radius * 2), bgHeight - (radius * 2), radius * 2, radius * 2), 0, 90)
      e.Graphics.DrawLine(jPen, Margin.Left + bgWidth - radius, bgHeight, radius, bgHeight)
      e.Graphics.DrawArc(jPen, New Rectangle(Margin.Left, bgHeight - (radius * 2), radius * 2, radius * 2), 90, 90)
      e.Graphics.DrawLine(jPen, Margin.Left, bgHeight - radius, Margin.Left, radius)
    End If

    MyBase.OnPaint(e)
  End Sub
#Const SHOW_PROPERTIES = False
#If SHOW_PROPERTIES Then

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BorderStyle As BorderStyle
    Get
      Return MyBase.BorderStyle
    End Get
    Set(value As BorderStyle)
      MyBase.BorderStyle = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property AllowDrop As Boolean
    Get
      Return MyBase.AllowDrop
    End Get
    Set(value As Boolean)
      MyBase.AllowDrop = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property Anchor As AnchorStyles
    Get
      Return MyBase.Anchor
    End Get
    Set(value As AnchorStyles)
      MyBase.Anchor = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property AutoSize As Boolean
    Get
      Return MyBase.AutoSize
    End Get
    Set(value As Boolean)
      MyBase.AutoSize = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BackgroundImage As Image
    Get
      Return MyBase.BackgroundImage
    End Get
    Set(value As Image)
      MyBase.BackgroundImage = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BackgroundImageLayout As ImageLayout
    Get
      Return MyBase.BackgroundImageLayout
    End Get
    Set(value As ImageLayout)
      MyBase.BackgroundImageLayout = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property CausesValidation As Boolean
    Get
      Return MyBase.CausesValidation
    End Get
    Set(value As Boolean)
      MyBase.CausesValidation = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property Cursor As Cursor
    Get
      Return MyBase.Cursor
    End Get
    Set(value As Cursor)
      MyBase.Cursor = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows ReadOnly Property DataBindings As ControlBindingsCollection
    Get
      Return MyBase.DataBindings
    End Get
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property DataContext As Object
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property ImeMode As ImeMode
    Get
      Return MyBase.ImeMode
    End Get
    Set(value As ImeMode)
      MyBase.ImeMode = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property Location As Point
    Get
      Return MyBase.Location
    End Get
    Set(value As Point)
      MyBase.Location = value
    End Set
  End Property

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property MinimumSize As Size
    Get
      Return MyBase.MinimumSize
    End Get
    Set(value As Size)
      MyBase.MinimumSize = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property MaximumSize As Size
    Get
      Return MyBase.MaximumSize
    End Get
    Set(value As Size)
      MyBase.MaximumSize = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property Padding As Padding
    Get
      Return MyBase.Padding
    End Get
    Set(value As Padding)
      MyBase.Padding = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property RightToLeft As RightToLeft
    Get
      Return MyBase.RightToLeft
    End Get
    Set(value As RightToLeft)
      MyBase.RightToLeft = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property Size As Size
    Get
      Return MyBase.Size
    End Get
    Set(value As Size)
      MyBase.Size = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property UseWaitCursor As Boolean
    Get
      Return MyBase.UseWaitCursor
    End Get
    Set(value As Boolean)
      MyBase.UseWaitCursor = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property AutoScrollMargin As Size
    Get
      Return MyBase.AutoScrollMargin
    End Get
    Set(value As Size)
      MyBase.AutoScrollMargin = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property AutoScrollMinSize As Size
    Get
      Return MyBase.AutoScrollMinSize
    End Get
    Set(value As Size)
      MyBase.AutoScrollMinSize = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property AutoScrollPosition As Point
    Get
      Return MyBase.AutoScrollPosition
    End Get
    Set(value As Point)
      MyBase.AutoScrollPosition = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property AutoScroll As Boolean
    Get
      Return MyBase.AutoScroll
    End Get
    Set(value As Boolean)
      MyBase.AutoScroll = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property AutoSizeMode As AutoSizeMode
    Get
      Return MyBase.AutoSizeMode
    End Get
    Set(value As AutoSizeMode)
      MyBase.AutoSizeMode = value
    End Set
  End Property
  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property GenerateMember As Boolean

#End If

End Class
