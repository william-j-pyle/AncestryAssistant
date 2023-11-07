Public Class MttagRefTag
  Inherits AbstractTag

  Public Sub New(data As Gedcom, ownerID As String)
    MyBase.New(data, "_MTTAG", False, ownerID)
  End Sub

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "_MTTAG"
        ID = data.createID(GedTagEnum.TYPE_MTTAG_REF, data.refKey())
      Case Else
        Return False
    End Select
    Return True
  End Function

End Class
