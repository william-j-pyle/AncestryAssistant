Public Class MediaRefTag
  Inherits AbstractTag

#Region "Properties"

  ' Attributes
  Public Property cropHeight As Integer

  Public Property cropLeft As Integer

  Public Property cropTop As Integer

  Public Property cropWidth As Integer

  Public Property isPrimary As Boolean

#End Region

#Region "Public Constructors"

  Public Sub New(data As Gedcom, ownerID As String)
    MyBase.New(data, "OBJE", False, ownerID)
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "OBJE"
        ID = data.createID(GedTagEnum.TYPE_MEDIA_REF, data.refKey())
      Case "OBJE._CROP"
      Case "OBJE._CROP._TYPE"
      Case "OBJE._CROP._HGHT"
        cropHeight = data.getInt()
      Case "OBJE._CROP._LEFT"
        cropLeft = data.getInt()
      Case "OBJE._CROP._TOP"
        cropTop = data.getInt()
      Case "OBJE._CROP._WDTH"
        cropWidth = data.getInt()
      Case "OBJE._PRIM"
        isPrimary = data.getString().Equals("Y")
      Case "OBJE.SOUR"
        data.NewSourceRefTag(ID)
      Case "OBJE.OBJE"
        data.NewMediaRefTag(ID)
      Case Else
        Return False
    End Select
    Return True
  End Function

#End Region

End Class