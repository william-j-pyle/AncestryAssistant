Imports System.IO

Public Class ANotebook

  Public Event SectionChanged(SectionName As String)

  Public Event PageChanged(PageName As String)

  Private Const NOTE_SECTION_CONFIG = "anote_sections.aa"
  Private Const NOTE_PAGES_CONFIG = "anote_pages.aa"

  Private sections As AAFile
  Private pages As AAFile

  Private sActiveSection As String = ""

  Public Property ActiveSection As String
    Get
      Return sActiveSection
    End Get
    Set(value As String)
      sActiveSection = value
      Debug.Print("ANotebook_SectionChanged({0})", sActiveSection)
      pages = New AAFile(ActiveSectionPath + NOTE_PAGES_CONFIG)
      If pages.AAFileType = AAFileTypeEnum.UNDEFINED Then
        pages.AAFileType = AAFileTypeEnum.KEYVALUEPAIRS
        pages.Save()
        AddPage("Untitled")
      End If
      ActivePage = pages.Value("1")
      RaiseEvent SectionChanged(value)
    End Set
  End Property

  Private sActivePage As String = ""

  Public Property ActivePage As String
    Get
      Return sActivePage
    End Get
    Set(value As String)
      sActivePage = value

      RaiseEvent PageChanged(value)
    End Set
  End Property

  Public ReadOnly Property ActiveSectionPath As String
    Get
      Return RecordsBasePath + ActiveSection + "\"
    End Get
  End Property

  Public ReadOnly Property ActivePageFilename As String
    Get
      Return ActiveSectionPath + ActivePage + ".aa"
    End Get
  End Property

  Public ReadOnly Property SectionCount As Integer
    Get
      Return sections.Count
    End Get
  End Property

  Public ReadOnly Property PageCount As Integer
    Get
      Return pages.Count
    End Get
  End Property

  Public ReadOnly Property length As Integer
    Get
      Return sections.Count
    End Get
  End Property

  Public ReadOnly Property RecordsBasePath As String = ""

  Public Sub New(RecordsLocation As String)
    If Not RecordsLocation.EndsWith("\") Then RecordsLocation += "\"
    RecordsBasePath = RecordsLocation
    Initialize()
  End Sub

  Public Sub AddSection(SectionName As String)
    Debug.Print("AddSection({0})", SectionName)
    Directory.CreateDirectory(RecordsBasePath + SectionName)
    sections.Value(sections.Count + 1) = SectionName
    sections.Save()
    ActiveSection = SectionName
  End Sub

  Public Sub RemoveSection(SectionName As String)
    Debug.Print("RemoveSection({0})", SectionName)

  End Sub

  Public Sub RenameSection(OldSectionName As String, NewSectionName As String)
    Debug.Print("RenameSection({0},{1})", OldSectionName, NewSectionName)

  End Sub

  Public Sub ChangeSectionOrder(OldSectionIndex As Integer, NewSectionIndex As Integer)
    Debug.Print("ChangeSectionOrder({0},{1})", OldSectionIndex, NewSectionIndex)

  End Sub

  Public Sub AddPage(PageName As String)
    Debug.Print("AddPage({0})", PageName)
    Dim sectionPath As String = RecordsBasePath + sActiveSection + "\"
    Dim pagePath As String = sectionPath + PageName + ".aa"
    Dim page As AAFile = New AAFile(pagePath, AAFileTypeEnum.SINGLEVALUE)
    page.Save()
    pages.Value(pages.Count + 1) = PageName
    pages.Save()
    ActivePage = PageName
  End Sub

  Public Sub RemovePage(PageName As String)
    Debug.Print("RemovePage({0})", PageName)

  End Sub

  Public Sub RenamePage(OldPageName As String, NewPageName As String)
    Debug.Print("RenamePage({0},{1})", OldPageName, NewPageName)

  End Sub

  Public Sub ChangePageOrder(OldPageIndex As Integer, NewPageIndex As Integer)
    Debug.Print("ChangePageOrder({0},{1})", OldPageIndex, NewPageIndex)

  End Sub

  Private Sub Initialize()
    If Not Directory.Exists(RecordsBasePath) Then
      'Create Base path
      Directory.CreateDirectory(RecordsBasePath)
    End If
    sections = New AAFile(RecordsBasePath + NOTE_SECTION_CONFIG)
    If sections.AAFileType = AAFileTypeEnum.UNDEFINED Then
      sections.AAFileType = AAFileTypeEnum.KEYVALUEPAIRS
      'Create SectionsList
      sections.Save()
      'Create Initial Section
      AddSection("Research")
    Else
      ActiveSection = sections.Value("1")
    End If

  End Sub

End Class