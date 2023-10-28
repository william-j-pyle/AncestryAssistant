Imports System.IO

Public Class AGallery
  Private dataEntries As List(Of String)
  Private recordLocations() As String

  Public ReadOnly Property length As Integer
    Get
      Return dataEntries.Count
    End Get
  End Property

  Public ReadOnly Property RecordsBasePath As String = ""

  Public Sub New(ParamArray RecordsLocations() As String)
    recordLocations = RecordsLocations
    RecordsBasePath = RecordsLocations(0)
    If Not RecordsBasePath.EndsWith("\") Then RecordsBasePath += "\"
    Initialize()
  End Sub

  Private Sub Initialize()
    dataEntries = New List(Of String)
    For Each Loc As String In recordLocations
      If Not Directory.Exists(Loc) Then
        Directory.CreateDirectory(Loc)
      End If
      dataEntries.AddRange(Directory.GetFiles(Loc, "*.jpg"))
    Next
  End Sub

End Class