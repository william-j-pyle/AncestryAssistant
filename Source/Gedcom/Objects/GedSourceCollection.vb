Public Class GedSourceCollection
    Private SourceRecords As New Dictionary(Of GedReference, GedSourceRecord)

    Default Public ReadOnly Property Source(Ref As GedReference) As GedSourceRecord
        Get
            Return SourceRecords(Ref)
        End Get
    End Property

    Default Public ReadOnly Property Source(idx As Integer) As GedSourceRecord
        Get
            Return SourceRecords.ElementAt(idx).Value
        End Get
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return SourceRecords.Count
        End Get
    End Property

    Public Sub addObject(data As GedComData)
        If data.Tag.Equals("SOUR") And data.LineLevel = 0 Then
            Dim rec As New GedSourceRecord
            rec.addObject(data)
            SourceRecords.Add(rec.Key, rec)
        End If
    End Sub
End Class
