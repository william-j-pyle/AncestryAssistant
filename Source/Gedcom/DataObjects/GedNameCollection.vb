'TODO: Not Finished
Public Class GedNameCollection
    Private NameRecords As New ArrayList


    Default Public ReadOnly Property Name(idx As Integer) As GedName
        Get
            Return NameRecords(idx)
        End Get
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return NameRecords.Count
        End Get
    End Property

    Public Sub addObject(data As GedComData)
        Dim rec As New GedName
        rec.addObject(data)
        NameRecords.Add(rec)
    End Sub
End Class
