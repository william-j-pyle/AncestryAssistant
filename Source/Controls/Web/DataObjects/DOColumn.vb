Public Class DMColumn
  Private _MinWidth As Integer = 0
  Public Property Index As Integer
  Public Property MinWidth As Integer
    Get
      Return _MinWidth
    End Get
    Set(value As Integer)
      If value > _MinWidth Then
        _MinWidth = value
      End If
    End Set
  End Property
  Public Property Name As String = ""
  Public Property SortType As DMColumnSortType = DMColumnSortType.SortNone
  Public Property Type As DMColumnType = DMColumnType.ColumnString
  Public Property Visible As Boolean = True

  Public Sub New()

  End Sub

  Public Sub New(Name As String)
    Me.Name = Name
    MinWidth = Name.Length
  End Sub

  Public Sub New(Name As String, Optional Type As DMColumnType = DMColumnType.ColumnString, Optional Visible As Boolean = True)
    Me.Name = Name
    Me.Type = Type
    Me.Visible = Visible
    MinWidth = Name.Length
  End Sub

End Class