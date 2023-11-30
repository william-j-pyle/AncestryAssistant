Public Class RILabel
  Inherits RibbonItem

#Region "Fields"

  Private lbl As Label

#End Region

#Region "Public Constructors"

  Public Sub New()
    lbl = New Label With {
      .BackColor = Color.Red, 'BackColor,
    .ForeColor = ForeColor,
      .Font = Font,
      .Dock = DockStyle.Fill,
      .AutoSize = False,
      .TextAlign = ContentAlignment.MiddleLeft,
      .Padding = New Padding(0),
      .Margin = New Padding(0),
      .Text = Text
    }
    Controls.Add(lbl)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub RILabel_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
    lbl.Text = Text
  End Sub

#End Region

End Class