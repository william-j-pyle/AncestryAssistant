Public Class RIImage
  Inherits RibbonItem

#Region "Fields"

  Private WithEvents Img As Panel

#End Region

#Region "Properties"

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

#End Region

#Region "Public Constructors"

  Public Sub New()
    Img = New Panel With {
      .Dock = DockStyle.Fill,
      .BackColor = BackColor,
      .Font = Font,
      .ForeColor = ForeColor,
      .BackgroundImageLayout = ImageLayout.None
    }
    Controls.Add(img)
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Function GetAttribute(ItemAttribute As RibbonItemAttribute) As Object
    Throw New NotImplementedException()
  End Function

  Public Overrides Sub SetAttribute(ItemAttribute As RibbonItemAttribute, attributeValue As Object)
    Select Case ItemAttribute
      Case RibbonItemAttribute.ImageFromFile
        Image = ImageFromFile(CType(attributeValue, String))
      Case RibbonItemAttribute.ImageFromResource
        Image = ImageFromResource(CType(attributeValue, String))
      Case RibbonItemAttribute.Image
        Image = CType(attributeValue, Image)
      Case RibbonItemAttribute.Enabled
        Img.Enabled = CType(attributeValue, Boolean)
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", ItemAttribute.ToString, attributeValue)
    End Select
  End Sub

#End Region

End Class