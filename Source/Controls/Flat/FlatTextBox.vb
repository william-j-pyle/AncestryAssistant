Imports System.ComponentModel

''' <summary>
'''     Provides basic searchbox functionality.
''' </summary>
Public Class FlatTextBox
  Inherits System.Windows.Forms.UserControl

#Region "Fields"

  Friend WithEvents txtCenterMe As TextBox

#End Region

#Region "Properties"

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Shadows Property Padding As Padding

  <Browsable(True), EditorBrowsable(EditorBrowsableState.Always)>
  Public Overrides Property Text As String
    Get
      Return txtCenterMe.Text
    End Get
    Set(value As String)
      txtCenterMe.Text = value
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    SuspendLayout()

    txtCenterMe = New System.Windows.Forms.TextBox()
    With txtCenterMe
      .BorderStyle = System.Windows.Forms.BorderStyle.None
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Location = New System.Drawing.Point(1, 1)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "txtCenterMe"
    End With

    Controls.Add(txtCenterMe)
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

#End Region

#Region "Private Methods"

  Private Sub FlatTextBox_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
    If Not txtCenterMe.Focused Then txtCenterMe.Focus()
  End Sub

  Private Sub SyncSettings(sender As Object, e As EventArgs) Handles Me.ForeColorChanged, Me.FontChanged, Me.BackColorChanged, txtCenterMe.SizeChanged, txtCenterMe.Resize, Me.ClientSizeChanged
    With txtCenterMe
      .Font = Font
      .BackColor = BackColor
      .ForeColor = ForeColor
      'Do this here because a change in font will alter the txtbox.cientsize.height
      MyBase.Padding = New Padding(2, 0 + Math.Max(0, CInt((ClientSize.Height - .ClientSize.Height) / 2)), 0, 0)
    End With
  End Sub

  Private Sub txtCenterMe_Click(sender As Object, e As EventArgs) Handles txtCenterMe.Click
    OnClick(e)
  End Sub

  Private Sub txtCenterMe_GotFocus(sender As Object, e As EventArgs) Handles txtCenterMe.GotFocus
    OnGotFocus(e)
  End Sub

  Private Sub txtCenterMe_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCenterMe.KeyDown
    OnKeyDown(e)
  End Sub

  Private Sub txtCenterMe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCenterMe.KeyPress
    OnKeyPress(e)
  End Sub

  Private Sub txtCenterMe_LostFocus(sender As Object, e As EventArgs) Handles txtCenterMe.LostFocus
    OnLostFocus(e)
  End Sub

  Private Sub txtCenterMe_MouseClick(sender As Object, e As MouseEventArgs) Handles txtCenterMe.MouseClick
    OnMouseClick(e)
  End Sub

  Private Sub txtCenterMe_MouseDown(sender As Object, e As MouseEventArgs) Handles txtCenterMe.MouseDown
    OnMouseDown(e)
  End Sub

  Private Sub txtCenterMe_MouseEnter(sender As Object, e As EventArgs) Handles txtCenterMe.MouseEnter
    OnMouseEnter(e)
  End Sub

  Private Sub txtCenterMe_MouseLeave(sender As Object, e As EventArgs) Handles txtCenterMe.MouseLeave
    OnMouseLeave(e)
  End Sub

  Private Sub txtCenterMe_MouseMove(sender As Object, e As MouseEventArgs) Handles txtCenterMe.MouseMove
    OnMouseMove(e)
  End Sub

  Private Sub txtCenterMe_TextChanged(sender As Object, e As EventArgs) Handles txtCenterMe.TextChanged
    OnTextChanged(e)
  End Sub

#End Region

End Class