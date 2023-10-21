
'TODO: Not Finished - Can this inhiert from GedReferenceCollection?
Public Class GedMediaReferenceCollection
    Private MediaReferences As New Dictionary(Of GedReference, GedMediaReference)

    Default Public ReadOnly Property Individual(Ref As GedReference) As GedMediaReference
        Get
            Return MediaReferences(Ref)
        End Get
    End Property

    Default Public ReadOnly Property Individual(idx As Integer) As GedMediaReference
        Get
            Return MediaReferences.ElementAt(idx).Value
        End Get
    End Property

    Public ReadOnly Property Count As Integer
        Get
            Return MediaReferences.Count
        End Get
    End Property

    Public Sub addObject(data As GedComData, fileKey As String)
        'Debug.Print("GedMediaReferenceCollection")
        Dim rec As New GedMediaReference
        rec.addObject(data, fileKey)
        MediaReferences.Add(rec.Key, rec)
    End Sub

End Class