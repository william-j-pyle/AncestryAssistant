Public Class RICheckBox
  Inherits RibbonItem

#Region "Fields"

  Private ctl As CheckBox

#End Region

#Region "Public Constructors"

  Public Sub New()
    ctl = New CheckBox With {
      .BackColor = BackColor,
      .ForeColor = ForeColor,
      .Font = Font,
      .Dock = DockStyle.Fill,
      .AutoSize = False,
      .TextAlign = ContentAlignment.MiddleLeft,
      .Padding = New Padding(0),
      .Margin = New Padding(0),
      .FlatStyle = FlatStyle.Flat,
      .AutoCheck = True,
      .AutoEllipsis = True,
      .CheckAlign = ContentAlignment.MiddleLeft,
      .UseVisualStyleBackColor = True
    }
    Controls.Add(ctl)
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub SetAttribute(attributeName As String, attributeValue As String)
    Select Case attributeName.ToLower
      Case "text"
        ctl.Text = attributeValue
      Case "value"
        ctl.Checked = attributeValue.ToLower.Equals("true") Or attributeValue.ToLower.Equals("1") Or attributeValue.ToLower.Equals("checked")
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", attributeName, attributeValue)
    End Select
  End Sub

#End Region

End Class