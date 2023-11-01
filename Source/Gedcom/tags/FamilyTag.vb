Public Class FamilyTag
  Inherits AbstractTag
  Public Const GEDCOM_TAG As String = "FAM"

  Public Sub New(data As Gedcom)
    MyBase.New(data, GEDCOM_TAG, True)
  End Sub

  ' Attributes
  Public Property fatherID As String
  Public Property motherID As String
  Public Property parentRelationship As String
  Public Property childIDs As List(Of String)

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "FAM"
        ID = data.createID(GedTagEnum.TYPE_FAMILY, data.refKey())

      Case "FAM.HUSB"
        fatherID = data.createID(GedTagEnum.TYPE_INDIVIDUAL, data.refKey())

      Case "FAM.WIFE"
        motherID = data.createID(GedTagEnum.TYPE_INDIVIDUAL, data.refKey())

      Case "FAM.CHIL"
        If childIDs Is Nothing Then
          childIDs = New List(Of String)
        End If
        childIDs.Add(data.createID(GedTagEnum.TYPE_INDIVIDUAL, data.refKey()))

      Case "FAM._SREL"
        parentRelationship = data.getString()

      Case "FAM.DIV"
      Case "FAM.MARR"
        Dim tmp As Object = New EventTag(data, ID, data.tag())

      Case "FAM.SOUR"
        Dim tmp As Object = New SourceRefTag(data, ID)

      Case "FAM.OBJE"
        Dim tmp As Object = New MediaRefTag(data, ID)

      Case "FAM._MTTAG"
        Dim tmp As Object = New MttagRefTag(data, ID)

      Case Else
        Return False
    End Select
    Return True
  End Function


End Class
