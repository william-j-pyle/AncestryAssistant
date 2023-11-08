Public Class IndividualTag
  Inherits AbstractTag
  Public Const GEDCOM_TAG = "INDI"

  Public Sub New(data As Gedcom)
    MyBase.New(data, GEDCOM_TAG, True)
  End Sub

  ' Attributes

  Public Property note As String

  Public Property universalID As String
  Public Property familySearchID As String

  Private _surname As String = String.Empty
  Private _given As String = String.Empty
  Public ReadOnly Property FullName As String
    Get
      If _surname Is Nothing Or _surname = "" Then
        For Each name As NameTag In data.names
          If name.TagOwnerID.Equals(ID) And name.isPrimary Then
            _given = name.given
            _surname = name.surname
            Exit For
          End If
        Next
      End If
      Return (_given + " " + _surname).Trim
    End Get
  End Property
  Public ReadOnly Property GivenName As String
    Get
      If _surname Is Nothing Or _surname = "" Then
        For Each name As NameTag In data.names
          If name.TagOwnerID.Equals(ID) And name.isPrimary Then
            _given = name.given
            _surname = name.surname
            Exit For
          End If
        Next
      End If
      Return _given
    End Get
  End Property
  Public ReadOnly Property SurName As String
    Get
      If _surname Is Nothing Or _surname = "" Then
        For Each name As NameTag In data.names
          If name.TagOwnerID.Equals(ID) And name.isPrimary Then
            _given = name.given
            _surname = name.surname
            Exit For
          End If
        Next
      End If
      Return _surname
    End Get
  End Property

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "INDI"
        ID = data.createID(GedTagEnum.TYPE_INDIVIDUAL, data.refKey())
      Case "INDI.NOTE"
        note = data.getString()
      Case "INDI.SEX"
        data.NewFactTag(ID, "SEX")
      Case "INDI.FAMS"
        data.NewFamilyRefTag(ID, "FAMS")
      Case "INDI.FAMC"
        data.NewFamilyRefTag(ID, "FAMC")
      Case "INDI.FACT"
        data.NewFactTag(ID)
      Case "INDI.NAME"
        data.NewNameTag(ID)
      Case "INDI.UID"
        universalID = data.getString()
      Case "INDI._FSID"
        familySearchID = data.getString()
      Case "INDI._DEG"
        data.NewEventTag(ID, data.tag())
      Case "INDI._MILT"
        data.NewEventTag(ID, data.tag())
      Case "INDI.BAPM"
        data.NewEventTag(ID, data.tag())
      Case "INDI.BIRT"
        data.NewEventTag(ID, data.tag())
      Case "INDI.BURI"
        data.NewEventTag(ID, data.tag())
      Case "INDI.CHR"
        data.NewEventTag(ID, data.tag())
      Case "INDI.DEAT"
        data.NewEventTag(ID, data.tag())
      Case "INDI.EVEN"
        data.NewEventTag(ID, data.tag())
      Case "INDI.MARR"
        data.NewEventTag(ID, data.tag())
      Case "INDI.NATU"
        data.NewEventTag(ID, data.tag())
      Case "INDI.PROB"
        data.NewEventTag(ID, data.tag())
      Case "INDI.PROP"
        data.NewEventTag(ID, data.tag())
      Case "INDI.RESI"
        data.NewEventTag(ID, data.tag())
      Case "INDI.SOUR"
        data.NewSourceRefTag(ID)
      Case "INDI.OBJE"
        data.NewMediaRefTag(ID)
      Case "INDI._MTTAG"
        data.NewMttagRefTag(ID)
      Case Else
        Return False
    End Select
    Return True
  End Function

End Class