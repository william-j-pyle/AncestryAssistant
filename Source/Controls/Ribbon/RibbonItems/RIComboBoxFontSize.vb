Public Class RIComboBoxFontSize
  Inherits RibbonItem

#Region "Public Methods"

  Public Overrides Sub SetAttribute(attributeName As String, attributeValue As String)
    Select Case attributeName.ToLower
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", attributeName, attributeValue)
    End Select
  End Sub

#End Region

End Class