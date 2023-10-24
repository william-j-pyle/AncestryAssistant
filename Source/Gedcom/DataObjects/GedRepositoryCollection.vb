Public Class GedRepositoryCollection
  Private RepositoryRecords As New Dictionary(Of GedReference, GedRepositoryRecord)

  Default Public ReadOnly Property Individual(Ref As GedReference) As GedRepositoryRecord
    Get
      Return RepositoryRecords(Ref)
    End Get
  End Property

  Default Public ReadOnly Property Individual(idx As Integer) As GedRepositoryRecord
    Get
      Return RepositoryRecords.ElementAt(idx).Value
    End Get
  End Property

  Public ReadOnly Property Count As Integer
    Get
      Return RepositoryRecords.Count
    End Get
  End Property

  Public Sub addObject(data As GedComData)
    Dim rec As New GedRepositoryRecord
    rec.addObject(data)
    RepositoryRecords.Add(rec.Key, rec)
  End Sub

End Class