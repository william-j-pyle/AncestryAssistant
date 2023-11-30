Public Class RIImage
  Inherits RibbonItem

#Region "Public Methods"

  Public Sub LoadImage(sFilename As String)
    BackgroundImage = Image.FromFile(sFilename)
  End Sub

#End Region

End Class