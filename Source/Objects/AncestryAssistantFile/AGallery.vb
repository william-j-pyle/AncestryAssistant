Imports System.IO

Public Class AGallery

#Region "Properties"

  Public ReadOnly Property length As Integer
    Get
      Return dataEntries.Count
    End Get
  End Property

  Public ReadOnly Property RecordsBasePath As String = ""

#End Region

#Region "Public Constructors"

  Public Sub New(ParamArray RecordsLocations() As String)
    recordLocations = RecordsLocations
    RecordsBasePath = RecordsLocations(0)
    If Not RecordsBasePath.EndsWith("\") Then RecordsBasePath += "\"
    Initialize()
  End Sub

#End Region

#Region "Private Methods"

  Private Sub Initialize()
    dataEntries = New List(Of String)
    For Each Loc As String In recordLocations
      If Not Directory.Exists(Loc) Then
        Directory.CreateDirectory(Loc)
      End If
      dataEntries.AddRange(Directory.GetFiles(Loc, "*.jpg"))
    Next
  End Sub

#End Region

#Region "Fields"

  Private dataEntries As List(Of String)
  Private recordLocations() As String

#End Region

End Class