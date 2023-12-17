Public Class MediaTag
  Inherits AbstractTag

  Public Const GEDCOM_TAG As String = "OBJE"

  ' Attributes
  Public Property atl As String

  Public Property clonDate As GedDate
  Public Property clonOID As String
  Public Property clonPID As String
  Public Property clonTID As String
  Public Property createDate As GedDate
  Public Property description As String
  Public Property fileFormat As String
  Public Property fileHeight As Integer
  Public Property fileMediaType As String
  Public Property fileSize As Integer
  Public Property fileStandardType As String
  Public Property fileTitle As String
  Public Property fileType As String
  Public Property fileWidth As Integer
  Public Property MediaDate As GedDate
  Public Property metadata As String
  Public Property mserLKID As String
  Public Property mserParam As String
  Public Property origin As String
  Public Property originUrl As String
  Public Property placeID As String
  Public Property rin As String

  Public Sub New(data As Gedcom)
    MyBase.New(data, GEDCOM_TAG, True)
  End Sub

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "OBJE"
        ID = data.createID(GedTagEnum.TYPE_MEDIA, data.refKey())
      Case "OBJE._ATL"
        atl = data.GetString()
      Case "OBJE._CLON"
      Case "OBJE._CLON._DATE"
        clonDate = data.GetDate()
      Case "OBJE._CLON._OID"
        clonOID = data.GetString()
      Case "OBJE._CLON._PID"
        clonPID = data.GetString()
      Case "OBJE._CLON._TID"
        clonTID = data.GetString()
      Case "OBJE._CLON._USER"
      Case "OBJE._CLON._USER._ENCR"
      Case "OBJE._CREA"
        createDate = data.GetDate()
      Case "OBJE._DSCR"
        description = data.GetString()
      Case "OBJE._META"
        metadata = data.GetString()
      Case "OBJE._MSER"
      Case "OBJE._MSER._LKID"
        mserLKID = data.GetString()
      Case "OBJE._MSER._PARM"
        mserParam = data.GetString()
      Case "OBJE._ORIG"
        origin = data.GetString()
      Case "OBJE._ORIG._URL"
        originUrl = data.GetString()
      Case "OBJE._USER"
      Case "OBJE._USER._ENCR"
      Case "OBJE.DATE"
        MediaDate = data.GetDate()
      Case "OBJE.FILE"
      Case "OBJE.FILE.FORM"
        fileFormat = data.GetString()
      Case "OBJE.FILE.FORM._HGHT"
        fileHeight = data.GetInt()
      Case "OBJE.FILE.FORM._MTYPE"
        fileMediaType = data.GetString()
      Case "OBJE.FILE.FORM._SIZE"
        fileSize = data.GetInt()
      Case "OBJE.FILE.FORM._STYPE"
        fileStandardType = data.GetString()
      Case "OBJE.FILE.FORM._WDTH"
        fileWidth = data.GetInt()
      Case "OBJE.FILE.FORM.TYPE"
        fileType = data.GetString()
      Case "OBJE.FILE.TITL"
        fileTitle = data.GetString()
      Case "OBJE.PLAC"
        Dim tmp As PlaceTag
        tmp = data.NewPlaceTag(ID)
        If tmp Is Nothing Then
          placeID = ""
        Else
          placeID = tmp.ID
        End If
      Case "OBJE.RIN"
        rin = data.GetString()
      Case Else
        Return False
    End Select
    Return True

  End Function

End Class