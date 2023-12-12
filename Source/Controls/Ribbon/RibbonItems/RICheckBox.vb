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

  Public Overrides Function GetAttribute(ItemAttribute As RibbonItemAttribute) As Object
    Throw New NotImplementedException()
  End Function

  Public Overrides Sub SetAttribute(ItemAttribute As RibbonItemAttribute, attributeValue As Object)
    Select Case ItemAttribute
      Case RibbonItemAttribute.text
        ctl.Text = CStr(attributeValue)
      Case RibbonItemAttribute.checked
        ctl.Checked = CStr(attributeValue).ToLower.Equals("true") Or CStr(attributeValue).ToLower.Equals("1") Or CStr(attributeValue).ToLower.Equals("checked")
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", ItemAttribute.ToString, attributeValue)
    End Select
  End Sub

#End Region

End Class