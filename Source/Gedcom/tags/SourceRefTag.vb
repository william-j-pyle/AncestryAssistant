Public Class SourceRefTag
  Inherits AbstractTag

  Public Sub New(data As Gedcom, ownerID As String)
    MyBase.New(data, "SOUR", False, ownerID)
  End Sub

  ' Attributes
  Public Property apID As String
  Public Property text As String
  Public Property www As String
  Public Property page As String

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "SOUR"
        ID = data.createID(GedTagEnum.TYPE_SOURCE_REF, data.refKey())

      Case "SOUR._APID"
        apID = data.getString()

      Case "SOUR.DATA"

      Case "SOUR.DATA.TEXT"
        text = data.getString()

      Case "SOUR.DATA.WWW"
        www = data.getString()

      Case "SOUR.PAGE"
        page = data.getString()

      Case "SOUR.OBJE"
        Dim tmp = New MediaRefTag(data, ID)

      Case Else
        Return False
    End Select
    Return True
  End Function

End class
