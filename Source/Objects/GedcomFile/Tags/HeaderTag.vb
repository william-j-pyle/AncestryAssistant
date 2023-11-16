Public Class HeaderTag
  Inherits AbstractTag

#Region "Properties"

  Public Property anTreeName As String
  Public Property createDate As GedDate
  Public Property familyCount As Integer
  ' Attributes
  Public Property fileName As String

  Public Property gedcFormat As String
  Public Property gedcVersion As String
  Public Property loadDate As GedDate
  Public Property mediaCount As Integer
  Public Property note As String
  Public Property personCount As Integer
  Public Property rin As String
  Public Property sourceCount As Integer

#End Region

#Region "Public Constructors"

  Public Sub New(data As Gedcom)
    MyBase.New(data, GEDCOM_TAG, True)
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "HEAD"
      Case "HEAD.SUBM"
      Case "HEAD.CHAR"
      Case "HEAD.DATE"
        createDate = data.getDate()
      Case "HEAD.DATE.TIME"
      Case "HEAD.GEDC"
      Case "HEAD.GEDC.FORM"
        gedcFormat = data.getString()
      Case "HEAD.GEDC.VERS"
        gedcVersion = data.getString()
      Case "HEAD.SOUR"
      Case "HEAD.SOUR.NAME"
      Case "HEAD.SOUR.VERS"
      Case "HEAD.SOUR.CORP"
      Case "HEAD.SOUR.CORP.PHON"
      Case "HEAD.SOUR.CORP.WWW"
      Case "HEAD.SOUR.CORP.ADDR"
      Case "HEAD.SOUR.CORP.ADDR.CONT"
      Case "HEAD.SOUR._TREE"
        anTreeName = data.getString()
      Case "HEAD.SOUR._TREE._ENV"
      Case "HEAD.SOUR._TREE.NOTE"
        note = data.getString()
      Case "HEAD.SOUR._TREE.RIN"
        rin = data.getString()
      Case Else
        Return False
    End Select
    Return True
  End Function

#End Region

#Region "Fields"

  Public Const GEDCOM_TAG As String = "HEAD"

#End Region

End Class