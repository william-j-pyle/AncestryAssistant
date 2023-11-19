Imports System.ComponentModel

''' <summary>
'''     Provides basic searchbox functionality.
''' </summary>
Public Class FlatLabel
  Inherits System.Windows.Forms.UserControl

#Region "Fields"

  Friend WithEvents txtCenterMe As Label

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

    txtCenterMe = New System.Windows.Forms.Label()
    With txtCenterMe
      .BorderStyle = System.Windows.Forms.BorderStyle.None
      .Dock = System.Windows.Forms.DockStyle.None
      .AutoEllipsis = True
      .AutoSize = True
      .Location = New System.Drawing.Point(1, 1)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "txtCenterMe"
    End With

    Controls.Add(txtCenterMe)
    BorderStyle = BorderStyle.None
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Margin = New System.Windows.Forms.Padding(0)
    Name = "FlatLabel"
    MyBase.Padding = New System.Windows.Forms.Padding(0)
    BackColor = SystemColors.ControlLightLight
    ForeColor = SystemColors.ControlText

    ResumeLayout(False)
    PerformLayout()
  End Sub

#End Region

#Region "Private Methods"

  Private Sub InitializeComponent()
    Me.SuspendLayout()
    Me.Name = "FlatLabel"
    Me.Size = New System.Drawing.Size(312, 79)
    Me.ResumeLayout(False)
  End Sub

  Private Sub SyncSettings(sender As Object, e As EventArgs) Handles Me.ForeColorChanged, Me.FontChanged, Me.BackColorChanged, txtCenterMe.SizeChanged, txtCenterMe.Resize, Me.ClientSizeChanged
    With txtCenterMe
      .Font = Font
      .BackColor = BackColor
      .ForeColor = ForeColor
      .Location = New Point(0, 0 + Math.Max(0, CInt((ClientSize.Height - .ClientSize.Height) / 2)))
    End With
  End Sub

  Private Sub txtCenterMe_Click(sender As Object, e As EventArgs) Handles txtCenterMe.Click
    OnClick(e)
  End Sub

  Private Sub txtCenterMe_GotFocus(sender As Object, e As EventArgs) Handles txtCenterMe.GotFocus
    OnGotFocus(e)
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