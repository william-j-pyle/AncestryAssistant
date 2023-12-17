Public Class RIButton
  Inherits RibbonItem

  Private WithEvents ctl As FlatIconButton

  Public Property Image As Image
    Get
      Return ctl.Image
    End Get
    Set(value As Image)
      ctl.Image = value
    End Set
  End Property

  Public Sub New()
    ctl = New FlatIconButton With {
      .Dock = DockStyle.Fill,
      .BackColor = BackColor,
      .Font = My.Theme.RibbonButtonFont,
      .ForeColor = ForeColor
    }
    Controls.Add(ctl)
  End Sub

  Private Sub ctl_Click(sender As Object, e As EventArgs) Handles ctl.Click
    OnRibbonItemAction(RibbonEventType.ButtonClick, ItemValue)
  End Sub

  Public Overrides Function GetAttribute(ItemAttribute As RibbonItemAttribute) As Object
    Select Case ItemAttribute
      Case RibbonItemAttribute.image
        Return Image
      Case RibbonItemAttribute.text
        Return ctl.Text
      Case RibbonItemAttribute.caption
        Return ctl.Text
      Case RibbonItemAttribute.textalign
        Return ctl.TextAlign
      Case RibbonItemAttribute.enabled
        Return ctl.Enabled
      Case RibbonItemAttribute.visible
        Return Visible
      Case RibbonItemAttribute.value
        Return ItemValue
      Case Else
        Debug.Print("Unhandled Attribute Requested: {0}", ItemAttribute.ToString)
    End Select
    Return Nothing
  End Function

  Public Overrides Sub SetAttribute(ItemAttribute As RibbonItemAttribute, attributeValue As Object)
    Select Case ItemAttribute
      Case RibbonItemAttribute.imagefromfile
        ctl.Image = ImageFromFile(CType(attributeValue, String))
      Case RibbonItemAttribute.imagefromresource
        ctl.Image = ImageFromResource(CType(attributeValue, String))
      Case RibbonItemAttribute.image
        ctl.Image = CType(attributeValue, Image)
      Case RibbonItemAttribute.text
        ctl.Text = CType(attributeValue, String)
      Case RibbonItemAttribute.caption
        ctl.Text = CType(attributeValue, String)
      Case RibbonItemAttribute.textalign
        ctl.TextAlign = CType(attributeValue, ContentAlignment)
      Case RibbonItemAttribute.enabled
        ctl.Enabled = CType(attributeValue, Boolean)
      Case RibbonItemAttribute.visible
        Visible = CBool(attributeValue)
      Case RibbonItemAttribute.value
        ItemValue = attributeValue
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", ItemAttribute.ToString, attributeValue)
    End Select
  End Sub

End Class