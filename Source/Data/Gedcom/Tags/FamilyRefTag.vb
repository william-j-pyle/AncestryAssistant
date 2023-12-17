Public Class FamilyRefTag
  Inherits AbstractTag

  ' Attributes
  Public Property familyType As String

  Public Sub New(data As Gedcom, ownerID As String)
    MyBase.New(data, data.tag(), False, ownerID)
  End Sub

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "FAMC"
        ID = data.createID(GedTagEnum.TYPE_FAMILY, data.refKey())
        familyType = "FAMC"

      Case "FAMS"
        ID = data.createID(GedTagEnum.TYPE_FAMILY, data.refKey())
        familyType = "FAMS"

      Case Else
        Return False
    End Select
    Return True
  End Function

End Class