Public Class MediaRefTag
  Inherits AbstractTag

  ' Attributes
  Public Property cropHeight As Integer

  Public Property cropLeft As Integer

  Public Property cropTop As Integer

  Public Property cropWidth As Integer

  Public Property isPrimary As Boolean

  Public Sub New(data As Gedcom, ownerID As String)
    MyBase.New(data, "OBJE", False, ownerID)
  End Sub

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "OBJE"
        ID = data.createID(GedTagEnum.TYPE_MEDIA_REF, data.refKey())
      Case "OBJE._CROP"
      Case "OBJE._CROP._TYPE"
      Case "OBJE._CROP._HGHT"
        cropHeight = data.GetInt()
      Case "OBJE._CROP._LEFT"
        cropLeft = data.GetInt()
      Case "OBJE._CROP._TOP"
        cropTop = data.GetInt()
      Case "OBJE._CROP._WDTH"
        cropWidth = data.GetInt()
      Case "OBJE._PRIM"
        isPrimary = data.GetString().Equals("Y")
      Case "OBJE.SOUR"
        data.NewSourceRefTag(ID)
      Case "OBJE.OBJE"
        data.NewMediaRefTag(ID)
      Case Else
        Return False
    End Select
    Return True
  End Function

End Class