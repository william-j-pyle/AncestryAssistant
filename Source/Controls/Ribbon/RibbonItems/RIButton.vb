Public Class RIButton
  Inherits RibbonItem

#Region "Fields"

  Private WithEvents ctl As FlatIconButton

#End Region

#Region "Properties"

  Public Property Image As Image
    Get
      Return ctl.Image
    End Get
    Set(value As Image)
      ctl.Image = value
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    ctl = New FlatIconButton With {
      .Dock = DockStyle.Fill,
      .BackColor = BackColor,
      .Font = My.Theme.RibbonButtonFont,
      .ForeColor = ForeColor
    }
    Controls.Add(ctl)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub ctl_Click(sender As Object, e As EventArgs) Handles ctl.Click
    OnRibbonItemAction(RibbonEventType.ButtonClick, True)
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Function GetAttribute(ItemAttribute As RibbonItemAttribute) As Object
    Select Case ItemAttribute
      Case RibbonItemAttribute.Image
        Return Image
      Case RibbonItemAttribute.Text
        Return ctl.Text
      Case RibbonItemAttribute.Caption
        Return ctl.Text
      Case RibbonItemAttribute.TextAlign
        Return ctl.TextAlign
      Case RibbonItemAttribute.Enabled
        Return ctl.Enabled
      Case Else
        Debug.Print("Unhandled Attribute Requested: {0}", ItemAttribute.ToString)
    End Select
    Return Nothing
  End Function

  Public Overrides Sub SetAttribute(ItemAttribute As RibbonItemAttribute, attributeValue As Object)
    Select Case ItemAttribute
      Case RibbonItemAttribute.ImageFromFile
        Image = ImageFromFile(CType(attributeValue, String))
      Case RibbonItemAttribute.ImageFromResource
        Image = ImageFromResource(CType(attributeValue, String))
      Case RibbonItemAttribute.Image
        Image = CType(attributeValue, Image)
      Case RibbonItemAttribute.Text
        ctl.Text = CType(attributeValue, String)
      Case RibbonItemAttribute.Caption
        ctl.Text = CType(attributeValue, String)
      Case RibbonItemAttribute.TextAlign
        ctl.TextAlign = CType(attributeValue, ContentAlignment)
      Case RibbonItemAttribute.Enabled
        ctl.Enabled = CType(attributeValue, Boolean)
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", ItemAttribute.ToString, attributeValue)
    End Select
  End Sub

#End Region

End Class