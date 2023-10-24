Public Class GedMediaCollection
  Private MediaRecords As New Dictionary(Of GedReference, GedMediaRecord)

  Default Public ReadOnly Property Individual(Ref As GedReference) As GedMediaRecord
    Get
      Return MediaRecords(Ref)
    End Get
  End Property

  Default Public ReadOnly Property Individual(idx As Integer) As GedMediaRecord
    Get
      Return MediaRecords.ElementAt(idx).Value
    End Get
  End Property

  Public ReadOnly Property Count As Integer
    Get
      Return MediaRecords.Count
    End Get
  End Property

  Public Sub addObject(data As GedComData)
    Dim rec As New GedMediaRecord
    rec.addObject(data)
    MediaRecords.Add(rec.Key, rec)
  End Sub

End Class