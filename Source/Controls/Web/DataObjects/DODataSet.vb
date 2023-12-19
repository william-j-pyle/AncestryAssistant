Public Class DMDataSet

  Public ReadOnly Property Data As DOData
  Public Property DataSetName As String
  Public ReadOnly Property Metadata As DOMetaData

  Public Sub New()
    Metadata = New DOMetaData()
    Data = New DOData
  End Sub

  Public Sub addColumn(name As String, columnType As DMColumnType, Optional Visible As Boolean = True)
    Metadata.addColumn(name, columnType, Visible)
  End Sub

  Public Sub addDataRow(RID As String, ParamArray data() As String)
    Me.Data.addRow(RID, data)
    Metadata.Rows = Me.Data.Rows
    For i As Integer = 0 To data.Length - 1
      Metadata.UpdateMinColumnWidth(i, data(i).Length)
    Next
  End Sub

  Public Sub deleteDataRow(RID As String)
    Throw New Exception("Functionality not yet implemented")
  End Sub

  Public Sub setColumnVisibility(name As String, visible As Boolean)
    setColumnVisibility(Metadata.getIndex(name), visible)
  End Sub

  Public Sub setColumnVisibility(idx As Integer, visible As Boolean)
    Metadata.setColumnVisibility(idx, visible)
  End Sub

  Public Sub sortOnColumn(name As String, sortType As DMColumnSortType)
    sortOnColumn(Metadata.getIndex(name), sortType)
  End Sub

  Public Sub sortOnColumn(idx As Integer, sortType As DMColumnSortType)
    Metadata.setSort(idx, sortType)
  End Sub

  Public Sub updateData(rowIdx As Integer, columnIdx As Integer, data As String)
    Throw New Exception("Functionality not yet implemented")
  End Sub

  Public Sub updateDataRow(rowIdx As Integer, ParamArray data() As String)
    Throw New Exception("Functionality not yet implemented")
  End Sub

End Class