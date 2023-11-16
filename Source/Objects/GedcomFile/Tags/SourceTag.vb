Public Class SourceTag
  Inherits AbstractTag

#Region "Properties"

  ' Attributes
  Public Property apID As String

  Public Property author As String
  Public Property note As String
  Public Property publishDate As GedDate
  Public Property publisher As String
  Public Property publishPlace As String
  Public Property repositoryID As String
  Public Property title As String

#End Region

#Region "Public Constructors"

  Public Sub New(data As Gedcom)
    MyBase.New(data, GEDCOM_TAG, True)
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "SOUR"
        ID = data.createID(GedTagEnum.TYPE_SOURCE, data.refKey())
      Case "SOUR._APID"
        apID = data.getString()
      Case "SOUR.AUTH"
        author = data.getString()
      Case "SOUR.NOTE"
        note = data.getString()
      Case "SOUR.PUBL"
        publisher = data.getString()
      Case "SOUR.PUBL.DATE"
        publishDate = data.getDate()
      Case "SOUR.PUBL.PLAC"
        Dim tmp As PlaceTag
        tmp = data.NewPlaceTag(ID)
        If tmp Is Nothing Then
          publishPlace = ""
        Else
          publishPlace = tmp.ID
        End If
      Case "SOUR.REPO"
        repositoryID = data.createID(GedTagEnum.TYPE_REPOSITORY, data.refKey())

      Case "SOUR.TITL"
        title = data.getString()

      Case Else
        Return False
    End Select
    Return True
  End Function

#End Region

#Region "Fields"

  Public Const GEDCOM_TAG As String = "SOUR"

#End Region

End Class