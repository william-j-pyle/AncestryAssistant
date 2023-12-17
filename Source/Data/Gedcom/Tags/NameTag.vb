Public Class NameTag
  Inherits AbstractTag

  ' Attributes
  Public Property given As String

  Public Property isPrimary As Boolean

  Public Property suffix As String

  Public Property surname As String

  Public Sub New(data As Gedcom, ownerID As String)
    MyBase.New(data, "NAME", False, ownerID)
  End Sub

  Public Overrides Sub generateID()
    ID = data.createID(GedTagEnum.TYPE_NAME)
    isPrimary = True
    For Each tag As NameTag In data.names
      If tag.TagOwnerID.Equals(TagOwnerID) And Not tag.ID.Equals(ID) Then
        isPrimary = False
        Return
      End If
    Next
  End Sub

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "NAME"
      Case "NAME.GIVN"
        given = data.GetString()
      Case "NAME.NSFX"
        suffix = data.GetString()
      Case "NAME.SURN"
        surname = data.GetString()
      Case "NAME.SOUR"
        data.NewSourceRefTag(ID)
      Case Else
        Return False
    End Select
    Return True

  End Function

End Class