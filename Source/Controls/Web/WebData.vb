Imports System.Runtime.InteropServices
Imports Newtonsoft.Json

<ComVisible(True), ClassInterface(ClassInterfaceType.AutoDual)>
Public Class WebData
  'Public GedCom As GEDComFile
  Private dataSets As New Dictionary(Of String, DMDataSet)

  Public Event DataChanged(dataSetName As String)

  Public Event SelectionChanged(dataSetName As String, RID As String)

  Public Event SelectionChangedWeb(dataSetName As String, RID As String)

  Public Function getData(dataSetName As String) As DOData
    Return dataSets(dataSetName).Data
  End Function

  Public Function getDataRow(dataSetName As String, rowIdx As Integer) As DORow
    Return dataSets(dataSetName).Data(rowIdx)
  End Function

  <ComVisible(True)>
  Public Function getDataRowWeb(dataSetName As String, rowIdx As Integer) As String
    Return JsonConvert.SerializeObject(getDataRow(dataSetName, rowIdx), Formatting.Indented)
  End Function

  <ComVisible(True)>
  Public Function getDataWeb(dataSetName As String) As String
    Return JsonConvert.SerializeObject(getData(dataSetName), Formatting.Indented)
  End Function

  Public Function getMetaData(dataSetName As String) As DOMetaData
    Return dataSets(dataSetName).Metadata
  End Function

  <ComVisible(True)>
  Public Function getMetaDataWeb(dataSetName As String) As String
    Return JsonConvert.SerializeObject(getMetaData(dataSetName), Formatting.Indented)
  End Function

  Public Sub RegisterDataSet(dataSet As DMDataSet)
    Dim dsUpdated As Boolean = False
    If dataSets.ContainsKey(dataSet.DataSetName) Then
      dataSets.Remove(dataSet.DataSetName)
      dsUpdated = True
    End If
    dataSets.Add(dataSet.DataSetName, dataSet)
    If dsUpdated Then
      RaiseEvent DataChanged(dataSet.DataSetName)
    End If
  End Sub

  <ComVisible(True)>
  Public Function SelectedRID(dataSetName As String) As String
    Return getMetaData(dataSetName).SelectedRID
  End Function

  Public Sub SelectRow(dataSetName As String, RID As String)
    If getMetaData(dataSetName).SelectedRID = RID Then Exit Sub
    getMetaData(dataSetName).SelectedRID = RID
    RaiseEvent SelectionChangedWeb(dataSetName, RID)
  End Sub

  <ComVisible(True)>
  Public Sub SelectRowWeb(dataSetName As String, RID As String)
    If getMetaData(dataSetName).SelectedRID = RID Then Exit Sub
    getMetaData(dataSetName).SelectedRID = RID
    RaiseEvent SelectionChanged(dataSetName, RID)
  End Sub

  Public Sub SetColumnSize(dataSetName As String, Optional colIdx As Integer = 0, Optional colSize As Integer = 0)

  End Sub

End Class