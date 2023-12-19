Imports System.IO

Public Class AncestorCollection
  Inherits Dictionary(Of String, Ancestor)

  Private _ActiveAncestorID As String = ""
  'Private AncestorEntries As Dictionary(Of String, Ancestor)
  Private _RepositoryPath As String = ""

  Public ReadOnly Property ActiveAncestor As Ancestor
    Get
      If Len(ActiveAncestorID) > 0 Then
        Return Item(ActiveAncestorID)
      Else
        Return Nothing
      End If
    End Get
  End Property

  Public Property ActiveAncestorID As String
    Get
      Return _ActiveAncestorID
    End Get
    Set(value As String)
      If Not _ActiveAncestorID.Equals(value) Then
        _ActiveAncestorID = value
        RaiseEvent ActiveAncestorChanged()
      End If
    End Set
  End Property

  Public ReadOnly Property HasActiveAncestor As Boolean
    Get
      Return Len(ActiveAncestorID) > 1
    End Get
  End Property

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

  Public Event ActiveAncestorChanged()

  Public Event AncestorsChanged()

  Public Event RepositoryPathChanged(NewPath As String)

  Public Sub New(AncestorsRepositoryPath As String)
    RepositoryPath = AncestorsRepositoryPath
  End Sub

  Protected Overrides Sub Finalize()
    EndPathMonitoring()
    MyBase.Finalize()
  End Sub

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
    For Each AncestorPath As String In Directory.GetDirectories(RepositoryPath)
      If Not AncestorPath.EndsWith("web") Then
        Try
          myAncestor = New Ancestor(AncestorPath)
          Add(myAncestor.ID, myAncestor)
          RaiseEvent AncestorsChanged()
        Catch ex As InvalidDataException
          Debug.Print("Invalid Repository Entry: " + AncestorPath)
        End Try
      End If
    Next
  End Sub

  Public Function HasAncestor(AncestryID As String) As Boolean
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
      RaiseEvent AncestorsChanged()
    End If
  End Sub

  Public Class Ancestor
    Inherits AncestorAbstract

    Friend Sub New(AncestorPath As String)
      LoadAncestor(AncestorPath)
    End Sub

  End Class

End Class