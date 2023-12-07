Imports System.IO

Public Class TimelineData

#Region "Fields"

  Private dataEntries() As String

#End Region

#Region "Properties"

  Public ReadOnly Property length As Integer
    Get
      Return dataEntries.Length
    End Get
  End Property

  Public ReadOnly Property RecordsBasePath As String = ""

#End Region

#Region "Public Constructors"

  Public Sub New(RecordsLocation As String)
    If Not RecordsLocation.EndsWith("\") Then RecordsLocation += "\"
    RecordsBasePath = RecordsLocation
    Initialize()
  End Sub

#End Region

#Region "Private Methods"

  Private Sub Initialize()
    If Not Directory.Exists(RecordsBasePath) Then
      Directory.CreateDirectory(RecordsBasePath)
    End If
    dataEntries = Directory.GetFiles(RecordsBasePath, "*.aa")

  End Sub

#End Region

End Class