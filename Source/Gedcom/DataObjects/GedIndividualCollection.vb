Public Class GedIndividualCollection
  Private IndividualRecords As New Dictionary(Of GedReference, GedIndividualRecord)

  Default Public ReadOnly Property Individual(Ref As GedReference) As GedIndividualRecord
    Get
      Return IndividualRecords(Ref)
    End Get
  End Property

  Default Public ReadOnly Property Individual(idx As Integer) As GedIndividualRecord
    Get
      Return IndividualRecords.ElementAt(idx).Value
    End Get
  End Property

  Public ReadOnly Property Count As Integer
    Get
      Return IndividualRecords.Count
    End Get
  End Property

  Public Sub addObject(data As GedComData)
    'Debug.Print("GedIndividualCollection")
    Dim rec As New GedIndividualRecord
    rec.addObject(data)
    IndividualRecords.Add(rec.Key, rec)
  End Sub

End Class