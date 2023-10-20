'TODO: Not Finished 
Public Class GedFactCollection
  Private FactRecords As New ArrayList


  Default Public ReadOnly Property Fact(idx As Integer) As GedFactRecord
    Get
      Return FactRecords(idx)
    End Get
  End Property

  Public ReadOnly Property Count As Integer
    Get
      Return FactRecords.Count
    End Get
  End Property

  Public Sub addObject(data As GedComData)
    Dim rec As New GedFactRecord
    rec.addObject(data, data.Key)
    FactRecords.Add(rec)
  End Sub
End Class
