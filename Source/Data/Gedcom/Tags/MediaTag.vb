Public Class MediaTag
  Inherits AbstractTag

#Region "Properties"

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

#End Region

#Region "Public Constructors"

  Public Sub New(data As Gedcom)
    MyBase.New(data, GEDCOM_TAG, True)
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "OBJE"
        ID = data.createID(GedTagEnum.TYPE_MEDIA, data.refKey())
      Case "OBJE._ATL"
        atl = data.getString()
      Case "OBJE._CLON"
      Case "OBJE._CLON._DATE"
        clonDate = data.getDate()
      Case "OBJE._CLON._OID"
        clonOID = data.getString()
      Case "OBJE._CLON._PID"
        clonPID = data.getString()
      Case "OBJE._CLON._TID"
        clonTID = data.getString()
      Case "OBJE._CLON._USER"
      Case "OBJE._CLON._USER._ENCR"
      Case "OBJE._CREA"
        createDate = data.getDate()
      Case "OBJE._DSCR"
        description = data.getString()
      Case "OBJE._META"
        metadata = data.getString()
      Case "OBJE._MSER"
      Case "OBJE._MSER._LKID"
        mserLKID = data.getString()
      Case "OBJE._MSER._PARM"
        mserParam = data.getString()
      Case "OBJE._ORIG"
        origin = data.getString()
      Case "OBJE._ORIG._URL"
        originUrl = data.getString()
      Case "OBJE._USER"
      Case "OBJE._USER._ENCR"
      Case "OBJE.DATE"
        MediaDate = data.getDate()
      Case "OBJE.FILE"
      Case "OBJE.FILE.FORM"
        fileFormat = data.getString()
      Case "OBJE.FILE.FORM._HGHT"
        fileHeight = data.getInt()
      Case "OBJE.FILE.FORM._MTYPE"
        fileMediaType = data.getString()
      Case "OBJE.FILE.FORM._SIZE"
        fileSize = data.getInt()
      Case "OBJE.FILE.FORM._STYPE"
        fileStandardType = data.getString()
      Case "OBJE.FILE.FORM._WDTH"
        fileWidth = data.getInt()
      Case "OBJE.FILE.FORM.TYPE"
        fileType = data.getString()
      Case "OBJE.FILE.TITL"
        fileTitle = data.getString()
      Case "OBJE.PLAC"
        Dim tmp As PlaceTag
        tmp = data.NewPlaceTag(ID)
        If tmp Is Nothing Then
          placeID = ""
        Else
          placeID = tmp.ID
        End If
      Case "OBJE.RIN"
        rin = data.getString()
      Case Else
        Return False
    End Select
    Return True

  End Function

#End Region

#Region "Fields"

  Public Const GEDCOM_TAG As String = "OBJE"

#End Region

End Class