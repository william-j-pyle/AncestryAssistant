Public Class GedTagCollection
    Private TagRecords As New Dictionary(Of GedReference, GedTagRecord)

    Default Public ReadOnly Property Tag(Ref As GedReference) As GedTagRecord
        Get
            Return TagRecords(Ref)
        End Get
    End Property

    Default Public ReadOnly Property Tag(idx As Integer) As GedTagRecord
        Get
            Return TagRecords.ElementAt(idx).Value
        End Get
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return TagRecords.Count
        End Get
    End Property

    Public Sub addObject(data As GedComData)
        Dim rec As New GedTagRecord
        rec.addObject(data)
        TagRecords.Add(rec.Key, rec)
    End Sub
End Class
