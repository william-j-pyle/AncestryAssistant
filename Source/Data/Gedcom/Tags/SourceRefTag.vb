Public Class SourceRefTag
  Inherits AbstractTag

  ' Attributes
  Public Property apID As String

  Public Property page As String

  Public Property text As String

  Public Property www As String

  Public Sub New(data As Gedcom, ownerID As String)
    MyBase.New(data, "SOUR", False, ownerID)
  End Sub

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "SOUR"
        ID = data.createID(GedTagEnum.TYPE_SOURCE_REF, data.refKey())
      Case "SOUR._APID"
        apID = data.GetString()
      Case "SOUR.DATA"
      Case "SOUR.DATA.TEXT"
        text = data.GetString()
      Case "SOUR.DATA.WWW"
        www = data.GetString()
      Case "SOUR.PAGE"
        page = data.GetString()
      Case "SOUR.OBJE"
        data.NewMediaRefTag(ID)
      Case Else
        Return False
    End Select
    Return True
  End Function

End Class