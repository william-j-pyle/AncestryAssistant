Public Class RIListView
  Inherits RibbonItem

#Region "Public Methods"

  Public Overrides Function GetAttribute(attributeName As String) As Object
    Throw New NotImplementedException()
  End Function

  Public Overrides Sub SetAttribute(attributeName As String, attributeValue As Object)
    Select Case attributeName.ToLower
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", attributeName, attributeValue)
    End Select
  End Sub

#End Region

End Class