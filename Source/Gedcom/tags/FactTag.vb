Public Class FactTag
  Inherits AbstractTag

  Public Sub New(data As Gedcom, ownerID As String, realTag As String)
    MyBase.New(data, "FACT", False, ownerID, realTag)
  End Sub

  Public Sub New(data As Gedcom, ownerID As String)
    MyBase.New(data, "FACT", False, ownerID)
  End Sub

  ' Attributes
  Public Property factType As String
  Public Property text As String

  Public Overrides Sub generateID()
    ID = data.createID(GedTagEnum.TYPE_FACT)
    If Not realTag.Equals(String.Empty) Then
      factType = realTag
    End If
  End Sub

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "FACT.TYPE"
        factType = data.getString()

      Case "FACT.NOTE"
      Case "FACT"
        text = data.getString()

      Case "FACT.SOUR"
        Dim tmp = New SourceRefTag(data, ID)

      Case Else
        Return False
    End Select
    Return True
  End Function

End class
