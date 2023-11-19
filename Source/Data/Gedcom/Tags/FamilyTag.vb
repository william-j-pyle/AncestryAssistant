Public Class FamilyTag
  Inherits AbstractTag

#Region "Fields"

  Public Const GEDCOM_TAG As String = "FAM"

#End Region

#Region "Properties"

  Public Property childIDs As List(Of String)
  ' Attributes
  Public Property fatherID As String

  Public Property motherID As String
  Public Property parentRelationship As String

#End Region

#Region "Public Constructors"

  Public Sub New(data As Gedcom)
    MyBase.New(data, GEDCOM_TAG, True)
  End Sub

#End Region

#Region "Public Methods"

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
        parentRelationship = data.GetString()
      Case "FAM.DIV"
      Case "FAM.MARR"
        data.NewEventTag(ID, data.tag())
      Case "FAM.SOUR"
        data.NewSourceRefTag(ID)
      Case "FAM.OBJE"
        data.NewMediaRefTag(ID)
      Case "FAM._MTTAG"
        data.NewMttagRefTag(ID)
      Case Else
        Return False
    End Select
    Return True
  End Function

#End Region

End Class