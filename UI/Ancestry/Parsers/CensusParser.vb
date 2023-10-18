Public Class CensusParser
  Private fields As Collection
  Private data As Collection
  Private dataRowIndex As Integer

  Private fieldsLocked As Boolean
  Private fieldIndex As Integer

  Private sPage As String = ""
  Private sYear As String = ""
  Private sTarget As String = ""
  Private sState As String = ""
  Private sCounty As String = ""
  Private sCity As String = ""
  Private sDistrict As String = ""


  Public ReadOnly Property target As String
    Get
      Return sTarget
    End Get
  End Property

  Public ReadOnly Property year As String
    Get
      Return sYear
    End Get
  End Property

  Public ReadOnly Property columnCount As Integer
    Get
      Return fields.Count
    End Get
  End Property

  Public ReadOnly Property rowCount As Integer
    Get
      Return data.Count
    End Get
  End Property


  Public Sub New(payloadData As String, pageNumber As String)
    fields = New Collection
    data = New Collection
    sPage = pageNumber
    fieldsLocked = False
    fieldIndex = 0
    dataRowIndex = 0
    ProcessData(payloadData)
  End Sub

  Private Sub ProcessData(rawData As String)
    Dim rawLines() As String
    Dim parseState As Integer
    Dim row As Double
    Dim f As Integer
    Dim fields() As String
    Dim data As String
    Dim fieldCount As Integer

    rawLines = Split(rawData, vbLf)

    parseState = 0
    For row = 1 To UBound(rawLines)
      data = rawLines(row)
      If Not sYear <> "" And data.Contains("United States Federal Census") And row < 20 Then
        sYear = Left(data, 4)
        sTarget = Mid(data, InStr(1, data, " for ") + 6)
        sState = rawLines(row + 1)
        sCounty = rawLines(row + 2)
        sCity = rawLines(row + 3)
        sDistrict = rawLines(row + 4)
        If sCity = "Toggle fullscreen" Or sCity = "Not Stated" Then
          sCity = ""
          sDistrict = ""
        End If
        If sDistrict = "Toggle fullscreen" Then
          sDistrict = ""
        End If
      End If
      If parseState = 0 And sYear <> "" And (data.Contains("Line Number") Or data.Contains("Dwelling Number") Or (sYear = "1830" And data.Contains("Surname")) Or (sYear = "1840" And data.Contains("Name"))) Then
        fields = Split(data, vbTab)
        If UBound(fields) > 2 Then
          parseState = 1
          fieldCount = UBound(fields)
          For f = 0 To fieldCount
            addField(fields(f))
          Next
        End If
      Else
        If parseState = 1 Then
          fields = Split(data, vbTab)
          If UBound(fields) < fieldCount Then
            parseState = 0
          Else
            For f = 0 To fieldCount
              addData(fields(f))
            Next
          End If
        End If
      End If
    Next
  End Sub


  Public Sub addField(name As String)
    fields.Add(name, "" & (fields.Count + 1))
  End Sub

  Public Sub addData(value As String)
    If Not fieldsLocked Then
      fieldsLocked = True
      fieldIndex = 0
      NewDataRow()
    End If
    fieldIndex = fieldIndex + 1
    If fieldIndex > fields.Count Then
      fieldIndex = 1
      NewDataRow()
    End If
    Dim drow() As String
    drow = data.Item("" & dataRowIndex)
    drow(fieldIndex) = value
    data.Remove("" & dataRowIndex)
    data.Add(drow, "" & dataRowIndex)
  End Sub

  Private Sub NewDataRow()
    Dim dataRow(200) As String
    dataRowIndex = dataRowIndex + 1
    data.Add(dataRow, "" & dataRowIndex)
  End Sub

  Public Function CensusArray() As Array
    Dim dataSet As New ArrayList
    Dim dataRow As ArrayList

    ' Header Row
    dataRow = New ArrayList
    dataRow.Add("Census Year")
    dataRow.Add("Page")
    dataRow.Add("State")
    dataRow.Add("County")
    dataRow.Add("City")
    dataRow.Add("District")
    For f As Integer = 1 To columnCount
      dataRow.Add(fields(f))
    Next
    dataSet.Add(dataRow.ToArray())

    ' Data Rows
    For r = 1 To rowCount
      dataRow = New ArrayList
      dataRow.Add(year())
      dataRow.Add(sPage)
      dataRow.Add(sState)
      dataRow.Add(sCounty)
      dataRow.Add(sCity)
      dataRow.Add(sDistrict)
      For f As Integer = 1 To columnCount
        dataRow.Add(data.Item("" & r)(f))
      Next
      dataSet.Add(dataRow.ToArray())
    Next r

    Return dataSet.ToArray()
  End Function

End Class
