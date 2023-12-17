Imports System.ComponentModel
Imports System.Windows.Forms.Layout

''' <summary>
'''     Provides basic searchbox functionality.
''' </summary>
Public Class FlatTextBox
  Inherits System.Windows.Forms.UserControl

  Friend WithEvents TxtCenterMe As TextBox

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
  Public Shadows Property Padding As Padding

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
  <Browsable(True), EditorBrowsable(EditorBrowsableState.Always)>
  Public Overrides Property Text As String
    Get
      Return TxtCenterMe.Text
    End Get
    Set(value As String)
      TxtCenterMe.Text = value
    End Set
  End Property

  Public Sub New()
    SuspendLayout()

    TxtCenterMe = New System.Windows.Forms.TextBox()
    With TxtCenterMe
      .BorderStyle = System.Windows.Forms.BorderStyle.None
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(1, 1)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "txtCenterMe"
    End With

    Controls.Add(TxtCenterMe)
    BorderStyle = BorderStyle.None
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Margin = New System.Windows.Forms.Padding(0)
    Name = "FlatTextBox"
    MyBase.Padding = New System.Windows.Forms.Padding(0)
    BackColor = SystemColors.ControlLightLight
    ForeColor = SystemColors.ControlText

    ResumeLayout(False)
    PerformLayout()
  End Sub

  Private Sub FlatTextBox_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
    If Not TxtCenterMe.Focused Then TxtCenterMe.Focus()
  End Sub

  Private Sub SyncSettings(sender As Object, e As EventArgs) Handles Me.ForeColorChanged, Me.FontChanged, Me.BackColorChanged, TxtCenterMe.SizeChanged, TxtCenterMe.Resize, Me.ClientSizeChanged
    With TxtCenterMe
      .Font = Font
      .BackColor = BackColor
      .ForeColor = ForeColor
      'Do this here because a change in font will alter the Txtbox.cientsize.height
      MyBase.Padding = New Padding(2, 0 + Math.Max(0, CInt((ClientSize.Height - .ClientSize.Height) / 2)), 0, 0)
    End With
  End Sub

  Private Sub TxtCenterMe_Click(sender As Object, e As EventArgs) Handles TxtCenterMe.Click
    OnClick(e)
  End Sub

  Private Sub TxtCenterMe_GotFocus(sender As Object, e As EventArgs) Handles TxtCenterMe.GotFocus
    OnGotFocus(e)
  End Sub

  Private Sub TxtCenterMe_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCenterMe.KeyDown
    OnKeyDown(e)
  End Sub

  Private Sub TxtCenterMe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCenterMe.KeyPress
    OnKeyPress(e)
  End Sub

  Private Sub TxtCenterMe_LostFocus(sender As Object, e As EventArgs) Handles TxtCenterMe.LostFocus
    OnLostFocus(e)
  End Sub

  Private Sub TxtCenterMe_MouseClick(sender As Object, e As MouseEventArgs) Handles TxtCenterMe.MouseClick
    OnMouseClick(e)
  End Sub

  Private Sub TxtCenterMe_MouseDown(sender As Object, e As MouseEventArgs) Handles TxtCenterMe.MouseDown
    OnMouseDown(e)
  End Sub

  Private Sub TxtCenterMe_MouseEnter(sender As Object, e As EventArgs) Handles TxtCenterMe.MouseEnter
    OnMouseEnter(e)
  End Sub

  Private Sub TxtCenterMe_MouseLeave(sender As Object, e As EventArgs) Handles TxtCenterMe.MouseLeave
    OnMouseLeave(e)
  End Sub

  Private Sub TxtCenterMe_MouseMove(sender As Object, e As MouseEventArgs) Handles TxtCenterMe.MouseMove
    OnMouseMove(e)
  End Sub

  Private Sub TxtCenterMe_TextChanged(sender As Object, e As EventArgs) Handles TxtCenterMe.TextChanged
    OnTextChanged(e)
  End Sub

End Class