Public Class GedFamilyCollection
    Private FamilyRecords As New Dictionary(Of GedReference, GedFamilyRecord)

    Default Public ReadOnly Property Individual(Ref As GedReference) As GedFamilyRecord
        Get
            Return FamilyRecords(Ref)
        End Get
    End Property

    Default Public ReadOnly Property Individual(idx As Integer) As GedFamilyRecord
        Get
            Return FamilyRecords.ElementAt(idx).Value
        End Get
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return FamilyRecords.Count
        End Get
    End Property

    Public Sub addObject(data As GedComData)
        Dim rec As New GedFamilyRecord
        rec.addObject(data)
        FamilyRecords.Add(rec.Key, rec)
    End Sub
End Class
