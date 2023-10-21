Public Class GedSubmitterCollection
    Private SubmitterRecords As New Dictionary(Of GedReference, GedSubmitterRecord)

    Default Public ReadOnly Property Submitter(Ref As GedReference) As GedSubmitterRecord
        Get
            Return SubmitterRecords(Ref)
        End Get
    End Property

    Default Public ReadOnly Property Submitter(idx As Integer) As GedSubmitterRecord
        Get
            Return SubmitterRecords.ElementAt(idx).Value
        End Get
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return SubmitterRecords.Count
        End Get
    End Property

    Public Sub addObject(data As GedComData)
        Dim rec As New GedSubmitterRecord
        rec.addObject(data)
        SubmitterRecords.Add(rec.Key, rec)
    End Sub
End Class
