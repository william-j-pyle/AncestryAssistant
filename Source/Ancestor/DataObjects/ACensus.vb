Imports System.IO

Public Class ACensus
  Private censusYears() As Integer = {1950, 1940, 1930, 1920, 1910, 1900, 1890, 1880, 1870, 1860, 1850, 1840, 1830, 1820, 1810, 1800, 1790}
  Private dataEntries() As String

  Private ancestor As AncestorCollection.Ancestor

  Public ReadOnly Property length As Integer
    Get
      Return dataEntries.Length
    End Get
  End Property


  Public ReadOnly Property ExpectedYears As List(Of Integer)
    Get
      Dim birth As Integer = ancestor.GedBirthDate.Year
      Dim death As Integer = ancestor.GedDeathDate.Year
      Return CreateExpectedYears(birth, death)
    End Get
  End Property

  Public ReadOnly Property AvailableYears As List(Of Integer)
    Get
      Return CreateAvailableYears()
    End Get
  End Property

  Public ReadOnly Property RecordsBasePath As String = ""

  Public Sub New(ancestorObj As AncestorCollection.Ancestor)
    ancestor = ancestorObj
    Dim recordslocation As String = ancestor.FullPath("Census")
    If Not RecordsLocation.EndsWith("\") Then RecordsLocation += "\"
    RecordsBasePath = RecordsLocation
    Initialize()
  End Sub

  Public Function addCensusData(msg As APIMessage) As String
    Dim year As String = msg.GetValue("Title").Split(" ")(0)
    Dim page As String = msg.GetValue("PageNbr")
    Dim filename As String = RecordsBasePath + "census-" + year + "-" + page
    Dim afile As AAFile = New AAFile(filename + ".aa", AAFileTypeEnum.LISTARRAY)
    afile.setTableData(msg.Payload)
    afile.Save()
    Refresh()
    Return filename
  End Function

  Public Sub Refresh()
    Initialize()
  End Sub

  Private Sub Initialize()
    If Not Directory.Exists(RecordsBasePath) Then
      Directory.CreateDirectory(RecordsBasePath)
    End If
    dataEntries = Directory.GetFiles(RecordsBasePath, "census*.aa")

  End Sub

  Private Function CreateExpectedYears(birthYear As Integer, deathYear As Integer) As List(Of Integer)
    Dim expected As List(Of Integer) = New List(Of Integer)
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

  Private Function CreateAvailableYears() As List(Of Integer)
    Dim available As List(Of Integer) = New List(Of Integer)
    For Each entry As String In dataEntries
      Dim y As Integer = CInt(entry.Split("-")(1))
      available.Add(y)
    Next
    Return available
  End Function

End Class