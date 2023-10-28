﻿Imports System.ComponentModel
Imports System.IO

<DefaultPropertyAttribute("ID")>
Public MustInherit Class AncestorBase

  Private facts As AAFile
  Private parents As AAFile
  Private marriages() As String
  Private children As AAFile
  Private siblings As AAFile
  Private sources As ASource
  Private events As ATimeline
  Private oCensus As ACensus
  Private gallery As AGallery
  Private notebook As ANotebook
  Public ReadOnly Property IsValid As Boolean = False

  Private sID As String = ""

  Public ReadOnly Property Census As ACensus
    Get
      Return oCensus
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

  Public Property Surname As String
    Get
      Return facts.Value("SURNAME")
    End Get
    Set(value As String)
      facts.Value("SURNAME") = value
      facts.Save()
    End Set
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

  Public Property FullName As String
    Get
      Return New GedName(facts.Value("SURNAME"), facts.Value("GIVENNAME"), facts.Value("SUFFIX")).Name
    End Get
    Set(value As String)
      Dim gName As GedName = New GedName(value)
      Surname = gName.Surname
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

  Public ReadOnly Property IsDeathDateExpected As Boolean
    Get
      Return (2023 - GedBirthDate.Year) > 90
    End Get
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

  Private sAncestorPath As String = ""

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
      Dim p() As String = value.Split("\")
      ID = p(UBound(p) - 1)
    End Set
  End Property

  Public ReadOnly Property HasProfileImage As Boolean = False

  Public ReadOnly Property HasImages As Boolean
    Get
      Return gallery.length > 0
    End Get
  End Property

  Public ReadOnly Property HasNotes As Boolean = False

  Public ReadOnly Property HasFamily As Boolean = False

  Public ReadOnly Property HasSources As Boolean
    Get
      Return sources.length > 0
    End Get
  End Property

  Public ReadOnly Property HasCensus As Boolean
    Get
      Return oCensus.length > 0
    End Get
  End Property

  Public ReadOnly Property HasTimeline As Boolean
    Get
      Return events.length > 0
    End Get
  End Property

  Public Sub Refresh()
    LoadAncestor()
  End Sub

  Friend Sub LoadAncestor(MyAncestorPath As String)
    AncestorPath = MyAncestorPath
    LoadAncestor()
  End Sub

  Public Function FullPath(FileOrDirName As String) As String
    Return AncestorPath + FileOrDirName
  End Function

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
    sources = New ASource(FullPath("Sources"))
    oCensus = New ACensus(Me)
    events = New ATimeline(FullPath("Events"))
    notebook = New ANotebook(FullPath("Notebook"))
    gallery = New AGallery(FullPath("Gallery"), FullPath("Census"))

  End Sub

End Class