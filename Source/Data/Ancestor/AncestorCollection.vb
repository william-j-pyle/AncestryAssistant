Imports System.IO

Public Class AncestorCollection
  Inherits Dictionary(Of String, Ancestor)

#Region "Fields"

  'Private AncestorEntries As Dictionary(Of String, Ancestor)
  Private _RepositoryPath As String = ""

#End Region

#Region "Events"

  Public Event RepositoryPathChanged(NewPath As String)

#End Region

#Region "Properties"

  Public Property RepositoryPath As String
    Get
      Return _RepositoryPath
    End Get
    Set(value As String)
      If value.Equals("") Then
        Throw New InvalidDataException("Repository Path cannot be blank")
      End If
      If Not value.EndsWith("\") Then value += "\"
      If Not Directory.Exists(value) Then
        Throw New DirectoryNotFoundException("Repository Path not found: " + value)
      End If
      _RepositoryPath = value
      RaiseEvent RepositoryPathChanged(_RepositoryPath)
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New(AncestorsRepositoryPath As String)
    RepositoryPath = AncestorsRepositoryPath
  End Sub

#End Region

#Region "Private Methods"

  Private Sub AncestorsRepositoryPathChanged(NewPath As String) Handles Me.RepositoryPathChanged
    ' Setup Path Monitoring
    BeginPathMonitoring()
    ' Load Ancestors
    LoadRepository()
  End Sub

  Private Sub BeginPathMonitoring()

  End Sub

  Private Sub EndPathMonitoring()

  End Sub

  Private Sub LoadRepository()
    Dim myAncestor As Ancestor
    For Each ancestorPath As String In Directory.GetDirectories(RepositoryPath)
      Try
        myAncestor = New Ancestor(ancestorPath)
        Add(myAncestor.ID, myAncestor)
      Catch ex As InvalidDataException
        Debug.Print("Invalid Repository Entry: " + ancestorPath)
      End Try
    Next
  End Sub

#End Region

#Region "Public Methods"

  Public Function hasAncestor(AncestryID As String) As Boolean
    Return ContainsKey(AncestryID)
  End Function

  Public Function newAncestor(AncestryID As String) As Ancestor
    If ContainsKey(AncestryID) Then
      Return Item(AncestryID)
    End If
    Dim AncestorPath As String = RepositoryPath + AncestryID + "\"
    Directory.CreateDirectory(AncestorPath)
    Add(AncestryID, New Ancestor(AncestorPath))
    Return Item(AncestryID)
  End Function

  Public Sub RefreshAncestor(AncestryID As String)
    If ContainsKey(AncestryID) Then
      Item(AncestryID).Refresh()
    End If
  End Sub

#End Region

#Region "Protected Destructors"

  Protected Overrides Sub Finalize()
    EndPathMonitoring()
    MyBase.Finalize()
  End Sub

#End Region

#Region "Classes"

  Public Class Ancestor
    Inherits AncestorAbstract

#Region "Internal Constructors"

    Friend Sub New(AncestorPath As String)
      LoadAncestor(AncestorPath)
    End Sub

#End Region

  End Class

#End Region

End Class