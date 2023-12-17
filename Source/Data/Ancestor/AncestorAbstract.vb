Imports System.ComponentModel
Imports System.IO

<DefaultPropertyAttribute("ID")>
Public MustInherit Class AncestorAbstract

  Private _ProfileImage As Image = Nothing
  Private children As AAFile
  Private events As AncestorTimelineData
  Private facts As AAFile
  Private gallery As AncestorGalleryData
  Private marriages() As String
  Private notebook As ANotebook
  Private oCensus As AncestorCensusData
  Private parents As AAFile
  Private sAncestorPath As String = ""
  Private siblings As AAFile
  Private sID As String = ""
  Private sources As AncestorSourcesData

  Public Property AncestorPath As String
    Get
      Return sAncestorPath
    End Get
    Set(value As String)
      If Not value.EndsWith("\") Then value += "\"
      If Not Directory.Exists(value) Then
        Throw New DirectoryNotFoundException("Ancestor Path not found")
      End If
      sAncestorPath = value
      Dim p() As String = value.Split("\"c)
      ID = p(UBound(p) - 1)
    End Set
  End Property

  Public ReadOnly Property Census As AncestorCensusData
    Get
      Return oCensus
    End Get
  End Property
  Public Property FullName As String
    Get
      Return New GedName(facts.Value("SURNAME"), facts.Value("GIVENNAME"), facts.Value("SUFFIX")).Name
    End Get
    Set(value As String)
      Dim gName As New GedName(value)
      Surname = gName.SurName
      Givenname = gName.Given
      facts.Value("SUFFIX") = gName.Suffix
      facts.Save()
    End Set
  End Property
  Public ReadOnly Property GedBirthDate As GedDate
    Get
      Return New GedDate(Fact("birthDate"))
    End Get
  End Property
  Public ReadOnly Property GedDeathDate As GedDate
    Get
      Return New GedDate(Fact("deathDate"))
    End Get
  End Property
  Public Property Givenname As String
    Get
      Return facts.Value("GIVENNAME")
    End Get
    Set(value As String)
      facts.Value("GIVENNAME") = value
      facts.Save()
    End Set
  End Property
  Public ReadOnly Property HasCensus As Boolean
    Get
      Return oCensus.length > 0
    End Get
  End Property
  Public ReadOnly Property HasFamily As Boolean = False
  Public ReadOnly Property HasImages As Boolean
    Get
      Return gallery.length > 0
    End Get
  End Property
  Public ReadOnly Property HasNotes As Boolean = False
  Public ReadOnly Property HasProfileImage As Boolean
    Get
      Return ProfileImage IsNot Nothing
    End Get
  End Property
  Public ReadOnly Property HasSources As Boolean
    Get
      Return sources.length > 0
    End Get
  End Property
  Public ReadOnly Property HasTimeline As Boolean
    Get
      Return events.length > 0
    End Get
  End Property
  Public Property ID As String
    Get
      Return sID
    End Get
    Set(value As String)
      sID = ""
      If IsNumeric(value) Then
        sID = value.Trim
      End If
      If sID = "" Then
        Throw New InvalidDataException("ID is invalid")
      End If
    End Set
  End Property
  Public ReadOnly Property IsDeathDateExpected As Boolean
    Get
      Return (2023 - GedBirthDate.Year) > 90
    End Get
  End Property
  Public ReadOnly Property IsValid As Boolean = False
  Public ReadOnly Property LifeSpan As String
    Get
      Dim birth As Integer = GedBirthDate.Year
      Dim death As Integer = GedDeathDate.Year
      If birth = 0 And death = 0 Then Return ""
      If birth = 0 And death > 0 Then Return "Unknown - " & death
      If birth > 0 And death = 0 Then
        If IsDeathDateExpected Then
          Return birth & " - Missing"
        Else
          Return birth & " - Living"
        End If
      End If
      Return birth & " - " & death
    End Get
  End Property
  Public ReadOnly Property ProfileImage As Image
    Get
      If _ProfileImage Is Nothing Then
        If gallery.length > 0 Then
          _ProfileImage = gallery.ProfileImage
        End If
      End If
      Return _ProfileImage
    End Get
  End Property
  Public Property Surname As String
    Get
      Return facts.Value("SURNAME")
    End Get
    Set(value As String)
      facts.Value("SURNAME") = value
      facts.Save()
    End Set
  End Property

  Public Property Fact(factKey As String) As String
    Get
      Select Case factKey.ToUpper
        Case "FULLNAME"
          Return FullName
        Case "GIVENNAME"
          Return Givenname
        Case "SURNAME"
          Return Surname
        Case Else
          Return facts.Value(factKey.ToUpper)
      End Select
    End Get
    Set(value As String)
      Select Case factKey.ToUpper
        Case "FULLNAME"
          FullName = value
        Case "GIVENNAME"
          Givenname = value
        Case "SURNAME"
          Surname = value
        Case Else
          facts.Value(factKey.ToUpper) = value
          facts.Save()
      End Select
    End Set
  End Property

  Private Sub LoadAncestor()
    facts = New AAFile(FullPath("facts.aa"))
    If facts.AAFileType = AAFileTypeEnum.UNDEFINED Then
      facts.AAFileType = AAFileTypeEnum.KEYVALUEPAIRS
      facts.Value("SURNAME") = ""
      facts.Value("GIVENNAME") = ""
      facts.Save()
    End If
    parents = New AAFile(FullPath("parents.aa"))
    If parents.AAFileType = AAFileTypeEnum.UNDEFINED Then
      parents.AAFileType = AAFileTypeEnum.LISTARRAY
      parents.Save()
    End If
    children = New AAFile(FullPath("children.aa"))
    If children.AAFileType = AAFileTypeEnum.UNDEFINED Then
      children.AAFileType = AAFileTypeEnum.LISTARRAY
      children.Save()
    End If
    siblings = New AAFile(FullPath("siblings.aa"))
    If siblings.AAFileType = AAFileTypeEnum.UNDEFINED Then
      siblings.AAFileType = AAFileTypeEnum.LISTARRAY
      siblings.Save()
    End If
    sources = New AncestorSourcesData(FullPath("Sources"))
    oCensus = New AncestorCensusData(Me)
    events = New AncestorTimelineData(FullPath("Events"))
    notebook = New ANotebook(FullPath("Notebook"))
    gallery = New AncestorGalleryData(FullPath("Gallery"), FullPath("Census"))

  End Sub

  Friend Sub LoadAncestor(MyAncestorPath As String)
    AncestorPath = MyAncestorPath
    LoadAncestor()
  End Sub

  Public Function AncestorFactDifferences(msg As APIMessage) As List(Of String)
    Dim rtn As New List(Of String)
    For Each factkey As String In AncestorFactList()
      If Not Fact(factkey).Equals(msg.GetValue(factkey)) Then
        rtn.Add(factkey)
      End If
    Next
    Return rtn
  End Function

  Public Function AncestorFactList() As List(Of String)
    Dim rtn As New List(Of String)
    rtn.AddRange({"givenname", "surname", "suffix", "birthPlace", "birthDate", "deathPlace", "deathDate", "gender", "photo"})
    Return rtn
  End Function

  Public Function AncestorMatchesMessage(msg As APIMessage) As Boolean
    Return AncestorFactDifferences(msg).Count = 0
  End Function

  Public Function FullPath(FileOrDirName As String) As String
    Return AncestorPath + FileOrDirName
  End Function

  Public Sub Refresh()
    LoadAncestor()
  End Sub

End Class