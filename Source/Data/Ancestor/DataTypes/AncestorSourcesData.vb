Imports System.IO

Public Class AncestorSourcesData

  Private dataEntries() As String

  Public ReadOnly Property length As Integer
    Get
      Return dataEntries.Length
    End Get
  End Property

  Public ReadOnly Property RecordsBasePath As String = ""

  Public Sub New(RecordsLocation As String)
    If Not RecordsLocation.EndsWith("\") Then RecordsLocation += "\"
    RecordsBasePath = RecordsLocation
    Initialize()
  End Sub

  Private Sub Initialize()
    If Not Directory.Exists(RecordsBasePath) Then
      Directory.CreateDirectory(RecordsBasePath)
    End If
    dataEntries = Directory.GetFiles(RecordsBasePath, "*.aa")
  End Sub

End Class