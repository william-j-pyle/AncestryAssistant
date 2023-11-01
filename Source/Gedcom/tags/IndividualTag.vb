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
      If _surname.Equals(String.Empty) Then
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
      If _surname.Equals(String.Empty) Then
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
      If _surname.Equals(String.Empty) Then
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
        Dim tmp = New FactTag(data, ID, "SEX")

      Case "INDI.FAMS"
        Dim tmp = New FamilyRefTag(data, ID)
      Case "INDI.FAMC"
        Dim tmp = New FamilyRefTag(data, ID)

      Case "INDI.FACT"
        Dim tmp = New FactTag(data, ID)

      Case "INDI.NAME"
        Dim tmp = New NameTag(data, ID)

      Case "INDI.UID"
        universalID = data.getString()

      Case "INDI._FSID"
        familySearchID = data.getString()

            'EVENTS
      Case "INDI._DEG"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI._MILT"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI.BAPM"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI.BIRT"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI.BURI"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI.CHR"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI.DEAT"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI.EVEN"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI.MARR"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI.NATU"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI.PROB"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI.PROP"
        Dim tmp = New EventTag(data, ID, data.tag())
      Case "INDI.RESI"
        Dim tmp = New EventTag(data, ID, data.tag())

      Case "INDI.SOUR"
        Dim tmp = New SourceRefTag(data, ID)

      Case "INDI.OBJE"
        Dim tmp = New MediaRefTag(data, ID)

      Case "INDI._MTTAG"
        Dim tmp = New MttagRefTag(data, ID)

      Case Else
        Return False
    End Select
    Return True
  End Function

End Class