Imports System.IO
Imports System.Text

Public Class Ancestors

  Public Class Ancestor
    Inherits AncestorAbstract
    Friend Sub New(AncestorsPath As String)
      LoadAncestor(AncestorsPath)
    End Sub
  End Class

  Private AncestorEntries As Dictionary(Of String, Ancestor)
  Public ReadOnly Property RepositoryPath As String

  Public ReadOnly Property Count As Integer
    Get
      Return AncestorEntries.Count
    End Get
  End Property


  Public Sub New(AncestorsPath As String)
    If Not AncestorsPath.EndsWith("\") Then AncestorsPath += "\"
    ' Verify the path
    If Not Directory.Exists(AncestorsPath) Then
      Throw New DirectoryNotFoundException("Ancestors Repository Path not found: " + AncestorsPath)
    End If
    ' Save the path
    RepositoryPath = AncestorsPath
    ' Setup Path Monitoring
    BeginPathMonitoring()
    ' Load Ancestors
    LoadAncestors()
  End Sub

  Private Sub BeginPathMonitoring()

  End Sub

  Private Sub EndPathMonitoring()

  End Sub

  Public Function getAncestor(AncestryID As String) As Ancestor
    If hasAncestor(AncestryID) Then
      Return AncestorEntries.Item(AncestryID)
    End If
    Return Nothing
  End Function

  Public Function createAncestor(AncestryID As String, Name As String, BirthDate As String) As Ancestor
    If hasAncestor(AncestryID) Then
      Return getAncestor(AncestryID)
    End If
    Dim gName As GedName = New GedName(Name)
    Dim gDate As GedDate = New GedDate(BirthDate)
    Dim AncestorPath = RepositoryPath + gName.Name + " - " + gDate.Year + "\"
    ' Create the Directory
    Directory.CreateDirectory(AncestorPath)
    ' Create the ID file
    StringToFile(AncestryID, AncestorPath, "Ancestry.id")
    ' Create the Census Directory
    Directory.CreateDirectory(AncestorPath + "Census")
    ' Create the Gallery Directory
    Directory.CreateDirectory(AncestorPath + "Gallery")
    ' Create the Notebook Directory
    Directory.CreateDirectory(AncestorPath + "Notebook")
    Directory.CreateDirectory(AncestorPath + "Notebook\Research")
    StringToFile("My First Note!", AncestorPath + "Notebook\Research", "0000-Initial Page.rtf")
    ' Create the Profile Entry
    Dim profile As ArrayList = New ArrayList()
    profile.Add({"SURNAME", gName.Surname})
    profile.Add({"GIVENNAME", gName.Given})
    profile.Add({"BIRTHDATE", gDate.toAssistantDate})
    profile.Add({"BIRTHPLACE", ""})
    profile.Add({"DEATHDATE", ""})
    profile.Add({"DEATHPLACE", ""})
    ArrayToDelimitedFile(profile, AncestorPath, "Profile.txt", "=")
  End Function


  Private Sub ArrayToDelimitedFile(ArrayData As ArrayList, FilePath As String, fileName As String, Optional fieldDelimiter As String = ",")
    Dim sb As StringBuilder = New StringBuilder()
    Dim r As Integer = 0
    Dim c As Integer = 0
    For Each row As String() In ArrayData
      If r > 0 Then sb.Append(vbCrLf)
      c = 0
      For Each col As String In row
        If c > 0 Then sb.Append(fieldDelimiter)
        sb.Append(col)
        c += 1
      Next
      r += 1
    Next
    StringToFile(sb.ToString, FilePath, fileName)
  End Sub

  Private Sub StringToFile(StringData As String, FilePath As String, FileName As String)
    If Not FilePath.EndsWith("\") Then FilePath += "\"
    Using writer As New StreamWriter(FilePath & FileName)
      writer.Write(StringData)
    End Using
  End Sub


  Public Function hasAncestor(AncestryID As String) As Boolean
    Return AncestorEntries.ContainsKey(AncestryID)
  End Function

  Public Sub RefreshAncestor(AncestryID As String)
    If hasAncestor(AncestryID) Then
      getAncestor(AncestryID).Refresh()
    End If
  End Sub

  Private Sub LoadAncestors()
    Dim myAncestor As Ancestor
    AncestorEntries = New Dictionary(Of String, Ancestor)
    For Each dir As String In Directory.GetDirectories(RepositoryPath)
      myAncestor = New Ancestor(dir)
      If myAncestor.IsValid Then
        AncestorEntries.Add(myAncestor.ID, myAncestor)
      End If
    Next
  End Sub

  Protected Overrides Sub Finalize()
    EndPathMonitoring()
    MyBase.Finalize()
  End Sub
End Class
