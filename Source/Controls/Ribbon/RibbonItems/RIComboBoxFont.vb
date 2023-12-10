Public Class RIComboBoxFont
  Inherits RibbonItem

#Region "Public Methods"

  Public Overrides Function GetAttribute(ItemAttribute As RibbonItemAttribute) As Object
    Throw New NotImplementedException()
  End Function

  Public Overrides Sub SetAttribute(ItemAttribute As RibbonItemAttribute, attributeValue As Object)
    Select Case ItemAttribute
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", ItemAttribute.ToString, attributeValue)
    End Select
  End Sub

#End Region

End Class