Public Class SourceTag
  Inherits AbstractTag

#Region "Fields"

  Public Const GEDCOM_TAG As String = "SOUR"

#End Region

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
        apID = data.GetString()
      Case "SOUR.AUTH"
        author = data.GetString()
      Case "SOUR.NOTE"
        note = data.GetString()
      Case "SOUR.PUBL"
        publisher = data.GetString()
      Case "SOUR.PUBL.DATE"
        publishDate = data.GetDate()
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
        title = data.GetString()

      Case Else
        Return False
    End Select
    Return True
  End Function

#End Region

End Class