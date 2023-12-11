Imports System.IO

Public Class ACensus

#Region "Fields"

  Private Ancestor As AncestorCollection.Ancestor
  Private censusYears() As Integer = {1950, 1940, 1930, 1920, 1910, 1900, 1890, 1880, 1870, 1860, 1850, 1840, 1830, 1820, 1810, 1800, 1790}
  Private dataEntries() As String

#End Region

#Region "Properties"

  Public ReadOnly Property AvailableYears As List(Of Integer)
    Get
      Return CreateAvailableYears()
    End Get
  End Property

  Public ReadOnly Property ExpectedYears As List(Of Integer)
    Get
      Dim birth As Integer = Ancestor.GedBirthDate.Year
      Dim death As Integer = Ancestor.GedDeathDate.Year
      Return CreateExpectedYears(birth, death)
    End Get
  End Property

  Public ReadOnly Property length As Integer
    Get
      Return dataEntries.Length
    End Get
  End Property

  Public ReadOnly Property RecordsBasePath As String = ""

#End Region

#Region "Public Constructors"

  Public Sub New(ancestorObj As AncestorCollection.Ancestor)
    Ancestor = AncestorObj
    Dim recordslocation As String = Ancestor.FullPath("Census")
    If Not recordslocation.EndsWith("\") Then recordslocation += "\"
    RecordsBasePath = recordslocation
    Initialize()
  End Sub

#End Region

#Region "Private Methods"

  Private Function CreateAvailableYears() As List(Of Integer)
    Dim available As New List(Of Integer)
    For Each entry As String In dataEntries
      Dim y As Integer = CInt(entry.Split("-"c)(1))
      available.Add(y)
    Next
    Return available
  End Function

  Private Function CreateExpectedYears(birthYear As Integer, deathYear As Integer) As List(Of Integer)
    Dim expected As New List(Of Integer)
    If birthYear > 0 Then
      If deathYear = 0 Then deathYear = birthYear + 90
      For Each dt As Integer In censusYears
        If birthYear <= dt And deathYear >= dt Then
          expected.Add(dt)
        End If
      Next
    End If
    Return expected
  End Function

  Private Sub Initialize()
    If Not Directory.Exists(RecordsBasePath) Then
      Directory.CreateDirectory(RecordsBasePath)
    End If
    dataEntries = Directory.GetFiles(RecordsBasePath, "census*.aa")

  End Sub

#End Region

#Region "Public Methods"

  Public Function addCensusData(msg As APIMessage) As String
    Dim year As String = msg.GetValue("Title").Split(" "c)(0)
    Dim page As String = msg.GetValue("PageNbr")
    Dim filename As String = RecordsBasePath + "census-" + year + "-" + page
    Dim afile As New AAFile(filename + ".aa", AAFileTypeEnum.LISTARRAY)
    afile.SetTableData(msg.Payload)
    afile.Save()
    Refresh()
    Return filename
  End Function

  Public Function GetAADatasource(censusYear As Integer) As AAFile
    Dim aaRtn As AAFile = Nothing
    Dim aaTmp As AAFile = Nothing
    For Each entry As String In dataEntries
      If censusYear = CInt(entry.Split("-"c)(1)) Then
        If aaRtn Is Nothing Then
          aaRtn = New AAFile(entry)
        Else
          aaRtn.CanSave = False
          aaTmp = New AAFile(entry)
          Dim rVal As ArrayList = aaRtn.GetValues()
          rVal.AddRange(aaTmp.GetValues)
          aaRtn.SetValues(rVal)
        End If
      End If
    Next
    Return aaRtn
  End Function

  Public Sub Refresh()
    Initialize()
  End Sub

#End Region

End Class