Public Class DOData
  Public ReadOnly Property Data As New ArrayList

  Public ReadOnly Property Rows As Integer
    Get
      Return Data.Count
    End Get
  End Property
  Default Public ReadOnly Property Row(rowIndex As Integer) As DORow
    Get
      Try
        Return CType(Data(rowIndex), DORow)
      Catch ex As Exception
        Return Nothing
      End Try
    End Get
  End Property

  Public Sub addRow(RID As String, ParamArray data() As String)
    Me.Data.Add(New DORow(RID, data))
  End Sub

  Public Sub addRow(dataRow As DORow)
    Data.Add(dataRow)
  End Sub

End Class