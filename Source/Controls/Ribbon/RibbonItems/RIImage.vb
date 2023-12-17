Public Class RIImage
  Inherits RibbonItem

  Private WithEvents Img As Panel

  Public Property Image As Image
    Get
      Return Img.BackgroundImage
    End Get
    Set(value As Image)
      If value.Height > (RowSpan * RibbonConfig.GROUP_ROW_HEIGHT) Or value.Width > (ColSpan * RibbonConfig.GROUP_COL_WIDTH) Then
        Img.BackgroundImageLayout = ImageLayout.Zoom
      Else
        Img.BackgroundImageLayout = ImageLayout.None
      End If
      Img.BackgroundImage = value
    End Set
  End Property

  Public Sub New()
    Img = New Panel With {
      .Dock = DockStyle.Fill,
      .BackColor = BackColor,
      .Font = Font,
      .ForeColor = ForeColor,
      .BackgroundImageLayout = ImageLayout.None
    }
    Controls.Add(Img)
  End Sub

  Public Overrides Function GetAttribute(ItemAttribute As RibbonItemAttribute) As Object
    Throw New NotImplementedException()
  End Function

  Public Overrides Sub SetAttribute(ItemAttribute As RibbonItemAttribute, attributeValue As Object)
    Select Case ItemAttribute
      Case RibbonItemAttribute.imagefromfile
        Image = ImageFromFile(CType(attributeValue, String))
      Case RibbonItemAttribute.imagefromresource
        Image = ImageFromResource(CType(attributeValue, String))
      Case RibbonItemAttribute.image
        Image = CType(attributeValue, Image)
      Case RibbonItemAttribute.enabled
        Img.Enabled = CType(attributeValue, Boolean)
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", ItemAttribute.ToString, attributeValue)
    End Select
  End Sub

End Class