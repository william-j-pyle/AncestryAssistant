Public Class MttagTag
  Inherits AbstractTag
  Public Const GEDCOM_TAG = "_MTTAG"


  Public Sub New(data As Gedcom)
    MyBase.New(data, GEDCOM_TAG, True)
  End Sub

  ' Attributes
  Public Property tagName As String
  Public Property rin As String

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "_MTTAG"
        ID = data.createID(GedTagEnum.TYPE_MTTAG, data.refKey())

      Case "_MTTAG.NAME"
        tagName = data.getString()

      Case "_MTTAG.RIN"
        rin = data.getString()

      Case Else
        Return False
    End Select
    Return True
  End Function

End class
