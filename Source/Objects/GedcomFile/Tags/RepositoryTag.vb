Public Class RepositoryTag
  Inherits AbstractTag

#Region "Properties"

  ' Attributes
  Public Property address As String

  Public Property name As String

#End Region

#Region "Public Constructors"

  Public Sub New(data As Gedcom)
    MyBase.New(data, GEDCOM_TAG, True)
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "REPO"
        ID = data.createID(GedTagEnum.TYPE_REPOSITORY, data.refKey())

      Case "REPO.ADDR"
        address = data.getString()

      Case "REPO.NAME"
        name = data.getString()

      Case Else
        Return False
    End Select
    Return True
  End Function

#End Region

#Region "Fields"

  Public Const GEDCOM_TAG As String = "REPO"

#End Region

End Class