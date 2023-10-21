'TODO: Not Finished
Public Class GedSourceReferenceCollection
    Private SourceReferences As New Dictionary(Of GedReference, GedSourceReference)

    Default Public ReadOnly Property Source(Ref As GedReference) As GedSourceReference
        Get
            Return SourceReferences(Ref)
        End Get
    End Property

    Default Public ReadOnly Property Source(idx As Integer) As GedSourceReference
        Get
            Return SourceReferences.ElementAt(idx).Value
        End Get
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return SourceReferences.Count
        End Get
    End Property

    Public Sub addObject(data As GedComData, fileKey As String)
        Dim rec As New GedSourceReference
        rec.addObject(data, fileKey)
        SourceReferences.Add(rec.Key, rec)
    End Sub
End Class
