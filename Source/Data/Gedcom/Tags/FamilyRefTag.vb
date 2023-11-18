Public Class FamilyRefTag
  Inherits AbstractTag

#Region "Properties"

  ' Attributes
  Public Property familyType As String

#End Region

#Region "Public Constructors"

  Public Sub New(data As Gedcom, ownerID As String)
    MyBase.New(data, data.tag(), False, ownerID)
  End Sub

#End Region

#Region "Public Methods"

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

#End Region

End Class