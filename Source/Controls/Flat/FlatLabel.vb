Imports System.ComponentModel

''' <summary>
'''     Provides basic searchbox functionality.
''' </summary>
Public Class FlatLabel
  Inherits System.Windows.Forms.UserControl

#Region "Fields"

  Friend WithEvents TxtCenterMe As Label

#End Region

#Region "Properties"

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Shadows Property Padding As Padding

  <Browsable(True), EditorBrowsable(EditorBrowsableState.Always)>
  Public Overrides Property Text As String
    Get
      Return TxtCenterMe.Text
    End Get
    Set(value As String)
      TxtCenterMe.Text = value
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    SuspendLayout()

    TxtCenterMe = New System.Windows.Forms.Label()
    With TxtCenterMe
      .BorderStyle = System.Windows.Forms.BorderStyle.None
      .Dock = System.Windows.Forms.DockStyle.None
      .AutoEllipsis = True
      .AutoSize = True
      .Location = New System.Drawing.Point(1, 1)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "txtCenterMe"
    End With

    Controls.Add(TxtCenterMe)
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
    SuspendLayout()
    Name = "FlatLabel"
    Size = New System.Drawing.Size(312, 79)
    ResumeLayout(False)
  End Sub

  Private Sub SyncSettings(sender As Object, e As EventArgs) Handles Me.ForeColorChanged, Me.FontChanged, Me.BackColorChanged, TxtCenterMe.SizeChanged, TxtCenterMe.Resize, Me.ClientSizeChanged
    With TxtCenterMe
      .Font = Font
      .BackColor = BackColor
      .ForeColor = ForeColor
      .Location = New Point(0, 0 + Math.Max(0, CInt((ClientSize.Height - .ClientSize.Height) / 2)))
    End With
  End Sub

  Private Sub TxtCenterMe_Click(sender As Object, e As EventArgs) Handles TxtCenterMe.Click
    OnClick(e)
  End Sub

  Private Sub TxtCenterMe_GotFocus(sender As Object, e As EventArgs) Handles TxtCenterMe.GotFocus
    OnGotFocus(e)
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

#End Region

End Class