Public Class RIImage
  Inherits RibbonItem

#Region "Fields"

  Private WithEvents img As Panel

#End Region

#Region "Properties"

  Public Property Image As Image
    Get
      Return img.BackgroundImage
    End Get
    Set(value As Image)
      If value.Height > (RowSpan * RibbonConfig.GROUP_ROW_HEIGHT) Or value.Width > (ColSpan * RibbonConfig.GROUP_COL_WIDTH) Then
        img.BackgroundImageLayout = ImageLayout.Zoom
      Else
        img.BackgroundImageLayout = ImageLayout.None
      End If
      img.BackgroundImage = value
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    img = New Panel With {
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

  Public Overrides Function GetAttribute(attributeName As String) As Object
    Throw New NotImplementedException()
  End Function

  Public Overrides Sub SetAttribute(attributeName As String, attributeValue As Object)
    Select Case attributeName.ToLower
      Case "ImageFromFile".ToLower
        Image = ImageFromFile(CType(attributeValue, String))
      Case "ImageFromResource".ToLower
        Image = ImageFromResource(CType(attributeValue, String))
      Case "Image".ToLower
        Image = CType(attributeValue, Image)
      Case "enabled"
        img.Enabled = CType(attributeValue, Boolean)
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", attributeName, attributeValue)
    End Select
  End Sub

#End Region

End Class