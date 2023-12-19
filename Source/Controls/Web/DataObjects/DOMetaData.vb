Public Class DOMetaData
  Public Columns As New ArrayList()
  Public ReadOnly Property Cols As Integer
    Get
      Return Columns.Count
    End Get
  End Property
  Public Property Rows As Integer
  Public Property SelectedRID As String = String.Empty

  Public Sub addColumn(column As DMColumn)
    column.Index = Columns.Count + 1
    Columns.Add(column)
  End Sub

  Public Sub addColumn(Name As String, Optional Type As DMColumnType = DMColumnType.ColumnString, Optional Visible As Boolean = True)
    addColumn(New DMColumn(Name, Type, Visible))
  End Sub

  Public Function getIndex(Name As String) As Integer
    For i As Integer = 0 To Columns.Count - 1
      If CType(Columns(i), DMColumn).Name = Name Then Return i
    Next
    Return -1
  End Function

  Public Sub setColumnVisibility(columnIndex As Integer, visible As Boolean)
    CType(Columns(columnIndex), DMColumn).Visible = visible
  End Sub

  Public Sub setSort(columnIndex As Integer, sortType As DMColumnSortType)
    For i As Integer = 0 To Cols - 1
      If columnIndex = i Then
        CType(Columns(columnIndex), DMColumn).SortType = sortType
      Else
        CType(Columns(columnIndex), DMColumn).SortType = DMColumnSortType.SortNone
      End If
    Next
  End Sub

  Public Sub UpdateMinColumnWidth(columnIndex As Integer, charCount As Integer)
    CType(Columns(columnIndex), DMColumn).MinWidth = charCount
  End Sub

End Class