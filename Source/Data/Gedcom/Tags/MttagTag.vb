Public Class MttagTag
  Inherits AbstractTag

#Region "Properties"

  Public Property rin As String
  ' Attributes
  Public Property tagName As String

#End Region

#Region "Public Constructors"

  Public Sub New(data As Gedcom)
    MyBase.New(data, GEDCOM_TAG, True)
  End Sub

#End Region

#Region "Public Methods"

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

#End Region

#Region "Fields"

  Public Const GEDCOM_TAG As String = "_MTTAG"

#End Region

End Class