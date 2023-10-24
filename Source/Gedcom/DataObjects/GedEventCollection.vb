'TODO: Not Finished
Public Class GedEventCollection
  Private EventRecords As New Dictionary(Of GedReference, GedEventRecord)

  Default Public ReadOnly Property Individual(Ref As GedReference) As GedEventRecord
    Get
      Return EventRecords(Ref)
    End Get
  End Property

  Default Public ReadOnly Property Individual(idx As Integer) As GedEventRecord
    Get
      Return EventRecords.ElementAt(idx).Value
    End Get
  End Property

  Public ReadOnly Property Count As Integer
    Get
      Return EventRecords.Count
    End Get
  End Property

  Public Sub addObject(data As GedComData, fileKey As String)
    Dim rec As New GedEventRecord
    rec.addObject(data, fileKey)
    EventRecords.Add(rec.Key, rec)
  End Sub

End Class