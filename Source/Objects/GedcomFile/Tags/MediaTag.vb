Public Class MediaTag
  Inherits AbstractTag
  Public Const GEDCOM_TAG = "OBJE"

  Public Sub New(data As Gedcom)
    MyBase.New(data, GEDCOM_TAG, True)
  End Sub

  ' Attributes
  Public Property atl As String
  Public Property clonDate As GedDate
  Public Property clonOID As String
  Public Property clonPID As String
  Public Property clonTID As String
  Public Property createDate As GedDate
  Public Property description As String
  Public Property metadata As String
  Public Property mserLKID As String
  Public Property mserParam As String
  Public Property origin As String
  Public Property originUrl As String
  Public Property MediaDate As GedDate
  Public Property fileFormat As String
  Public Property fileHeight As Integer
  Public Property fileMediaType As String
  Public Property fileSize As Integer
  Public Property fileStandardType As String
  Public Property fileWidth As Integer
  Public Property fileType As String
  Public Property fileTitle As String
  Public Property placeID As String
  Public Property rin As String

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "OBJE"
        id = Data.createID(GedTagEnum.TYPE_MEDIA, Data.refKey())
      Case "OBJE._ATL"
        atl = Data.getString()
      Case "OBJE._CLON"
      Case "OBJE._CLON._DATE"
        clonDate = Data.getDate()
      Case "OBJE._CLON._OID"
        clonOID = Data.getString()
      Case "OBJE._CLON._PID"
        clonPID = Data.getString()
      Case "OBJE._CLON._TID"
        clonTID = Data.getString()
      Case "OBJE._CLON._USER"
      Case "OBJE._CLON._USER._ENCR"
      Case "OBJE._CREA"
        createDate = Data.getDate()
      Case "OBJE._DSCR"
        description = Data.getString()
      Case "OBJE._META"
        metadata = Data.getString()
      Case "OBJE._MSER"
      Case "OBJE._MSER._LKID"
        mserLKID = Data.getString()
      Case "OBJE._MSER._PARM"
        mserParam = Data.getString()
      Case "OBJE._ORIG"
        origin = Data.getString()
      Case "OBJE._ORIG._URL"
        originUrl = Data.getString()
      Case "OBJE._USER"
      Case "OBJE._USER._ENCR"
      Case "OBJE.DATE"
        MediaDate = data.getDate()
      Case "OBJE.FILE"
      Case "OBJE.FILE.FORM"
        fileFormat = Data.getString()
      Case "OBJE.FILE.FORM._HGHT"
        fileHeight = Data.getInt()
      Case "OBJE.FILE.FORM._MTYPE"
        fileMediaType = Data.getString()
      Case "OBJE.FILE.FORM._SIZE"
        fileSize = Data.getInt()
      Case "OBJE.FILE.FORM._STYPE"
        fileStandardType = Data.getString()
      Case "OBJE.FILE.FORM._WDTH"
        fileWidth = Data.getInt()
      Case "OBJE.FILE.FORM.TYPE"
        fileType = Data.getString()
      Case "OBJE.FILE.TITL"
        fileTitle = Data.getString()
      Case "OBJE.PLAC"
        Dim tmp As PlaceTag
        tmp = data.NewPlaceTag(ID)
        If tmp Is Nothing Then
          placeID = ""
        Else
          placeID = tmp.ID
        End If
      Case "OBJE.RIN"
        rin = Data.getString()
      Case Else
        Return False
    End Select
    Return True

  End Function

End Class
