Imports System.ComponentModel
Imports System.IO

<DefaultPropertyAttribute("ID")>
Public MustInherit Class AncestorAbstract

  Private gName As GedName
  Private gBirthDate As GedDate
  Private gDeathDate As GedDate
  Private gBirthPlace As GedPlace
  Private gDeathPlace As GedPlace

  Private bIsValid As Boolean = False
  Public ReadOnly Property IsValid As Boolean
    Get
      Return bIsValid
    End Get
  End Property

  <CategoryAttribute("Tracking"),
    Browsable(True),
    DefaultValueAttribute(""),
    DescriptionAttribute("Ancestry.com ID")>
  Public Property ID As String = ""


  <CategoryAttribute("Name"),
    Browsable(True),
    DefaultValueAttribute(""),
    DescriptionAttribute("Sur or Family Name")>
  Public Property Surname As String
    Get
      Return gName.Surname
    End Get
    Set(value As String)
      gName.Surname = value
    End Set
  End Property

  <CategoryAttribute("Name"),
    Browsable(True),
    DefaultValueAttribute(""),
    DescriptionAttribute("Given Name")>
  Public Property Givenname As String
    Get
      Return gName.Given
    End Get
    Set(value As String)
      gName.Given = value
    End Set
  End Property

  <CategoryAttribute("Name"),
    Browsable(True),
    DefaultValueAttribute(""),
    DescriptionAttribute("Display Name, GivenName Surname")>
  Public Property FullName As String
    Get
      Return gName.Name
    End Get
    Set(value As String)
      gName.Name = value
    End Set
  End Property

  Private sAncestorPath As String = ""
  Public ReadOnly Property AncestorPath As String
    Get
      Return sAncestorPath
    End Get
  End Property

  Private bHasProfileImage As Boolean = False
  Public ReadOnly Property HasProfileImage As Boolean
    Get
      Return bHasProfileImage
    End Get
  End Property
  Private bHasImages As Boolean = False
  Public ReadOnly Property HasImages As Boolean
    Get
      Return bHasImages
    End Get
  End Property
  Private bHasNotes As Boolean = False
  Public ReadOnly Property HasNotes As Boolean
    Get
      Return bHasNotes
    End Get
  End Property
  Private bHasFamily As Boolean = False
  Public ReadOnly Property HasFamily As Boolean
    Get
      Return bHasFamily
    End Get
  End Property
  Private bHasSources As Boolean = False
  Public ReadOnly Property HasSources As Boolean
    Get
      Return bHasSources
    End Get
  End Property
  Private bHasCensus As Boolean = False
  Public ReadOnly Property HasCensus As Boolean
    Get
      Return bHasCensus
    End Get
  End Property
  Private bHasTimeline As Boolean = False
  Public ReadOnly Property HasTimeline As Boolean
    Get
      Return bHasTimeline
    End Get
  End Property

  Public Sub Refresh()
    LoadAncestor()
  End Sub

  Friend Sub LoadAncestor(AncestorPath As String)
    sAncestorPath = AncestorPath
    LoadAncestor()
  End Sub

  Private Sub LoadAncestor()
    Dim valid As Boolean
    Initialize()

    If Directory.Exists(sAncestorPath) Then
      'Load ID Files
      valid = LoadIDFiles()
      'Load Profile
      valid = valid And LoadProfile()
      ' If we get this far, IsValid=True
      bIsValid = valid
      'Link Profile Image
      bHasProfileImage = LinkProfileImage()
      'Load Gallery
      bHasImages = LoadGalleryInfo()
      'Load Notes
      bHasNotes = LoadNotesInfo()
      'Load Family
      bHasFamily = LoadFamilyInfo()
      'Load Sources
      bHasSources = LoadSourceInfo()
      'Load Census 
      bHasCensus = LoadCensusInfo()
      'Load Timeline
      bHasTimeline = LoadTimelineInfo()
    End If
  End Sub

  'Load ID Files
  Private Function LoadIDFiles() As Boolean
    Dim rtn As Boolean = False
    Return rtn
  End Function

  'Load Profile
  Private Function LoadProfile() As Boolean
    Dim rtn As Boolean = False
    Return rtn
  End Function

  'Link Profile Image
  Private Function LinkProfileImage() As Boolean
    Dim rtn As Boolean = False
    Return rtn
  End Function

  'Load Gallery
  Private Function LoadGalleryInfo() As Boolean
    Dim rtn As Boolean = False
    Return rtn
  End Function

  'Load Notes
  Private Function LoadNotesInfo() As Boolean
    Dim rtn As Boolean = False
    Return rtn
  End Function

  'Load Family
  Private Function LoadFamilyInfo() As Boolean
    Dim rtn As Boolean = False
    Return rtn
  End Function

  'Load Sources
  Private Function LoadSourceInfo() As Boolean
    Dim rtn As Boolean = False
    Return rtn
  End Function

  'Load Census 
  Private Function LoadCensusInfo() As Boolean
    Dim rtn As Boolean = False
    Return rtn
  End Function

  'Load Timeline
  Private Function LoadTimelineInfo() As Boolean
    Dim rtn As Boolean = False
    Return rtn
  End Function

  Private Sub Initialize()
    bIsValid = False
    gName = New GedName()
    gBirthDate = New GedDate()
    gDeathDate = New GedDate()
    gBirthPlace = New GedPlace()
    gDeathPlace = New GedPlace()
  End Sub

End Class
