Imports System.IO

Public Class AncestorCensusData

  Private Ancestor As AncestorCollection.Ancestor
  Private censusYears() As Integer = {1950, 1940, 1930, 1920, 1910, 1900, 1890, 1880, 1870, 1860, 1850, 1840, 1830, 1820, 1810, 1800, 1790}
  Private dataEntries() As String

  Public ReadOnly Property AvailableYears As List(Of Integer)
    Get
      Return CreateAvailableYears()
    End Get
  End Property

  Public ReadOnly Property CensusEntries As List(Of CensusEntry)
    Get
      Dim entries As New List(Of CensusEntry)
      Dim entry As CensusEntry
      For Each censusYear As Integer In ExpectedYears
        entry = New CensusEntry()
        With entry
          .Year = censusYear
          .hasData = AvailableYears.Contains(censusYear)
          .aaFilename = String.Empty
          If .hasData Then
            .aaFilename = GetAAFilename(censusYear)
          End If
        End With
        entries.Add(entry)
      Next
      Return entries
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

  Public Sub New(ancestorObj As AncestorCollection.Ancestor)
    Ancestor = ancestorObj
    Dim recordslocation As String = Ancestor.FullPath("Census")
    If Not recordslocation.EndsWith("\") Then recordslocation += "\"
    RecordsBasePath = recordslocation
    Initialize()
  End Sub

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

  Public Function GetAAFilename(censusYear As Integer) As String
    For Each entry As String In dataEntries
      If censusYear = CInt(entry.Split("-"c)(1)) Then
        Return entry
      End If
    Next
    Return String.Empty
  End Function

  Public Function hasYear(censusYear As Integer) As Boolean
    For Each entry As String In dataEntries
      If censusYear = CInt(entry.Split("-"c)(1)) Then
        Return True
      End If
    Next
    Return False
  End Function

  Public Sub Refresh()
    Initialize()
  End Sub

  Public Class CensusEntry

    Public Property aaFilename As String
    Public Property hasData As Boolean
    Public Property Year As Integer

  End Class

End Class