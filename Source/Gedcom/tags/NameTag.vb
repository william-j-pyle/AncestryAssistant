Public Class NameTag
  Inherits AbstractTag


  Public Sub New(data As Gedcom, ownerID As String)
    MyBase.New(data, "NAME", False, ownerID)
  End Sub


  ' Attributes
  Public Property given As String
  Public Property suffix As String
  Public Property surname As String
  Public Property isPrimary As Boolean

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "NAME"

      Case "NAME.GIVN"
        given = data.getString()

      Case "NAME.NSFX"
        suffix = data.getString()

      Case "NAME.SURN"
        surname = data.getString()

      Case "NAME.SOUR"
        Dim tmp = New SourceRefTag(data, ID)

      Case Else
        Return False
    End Select
    Return True

  End Function

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

End Class
