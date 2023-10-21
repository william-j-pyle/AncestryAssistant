Public Class GedRepositoryRecord
  Public Property Key As GedReference
  Public Property Name As String

  Public Sub addObject(data As GedComData)
    Dim processedRoot As Boolean = False
    While data.HasNext
      If data.Key.Contains("REPO") Then
        Select Case data.Key
          Case "REPO"
            If processedRoot Then
              Exit Sub
            End If
            Key = data.RefKey
            processedRoot = True
            data.NextRow()
          Case "REPO.NAME"
            Name = data.Data
            data.NextRow()
          Case "REPO.ADDR"
            data.NextRow()
          Case Else
            Debug.Print("GedRepositoryRecord: Unhandled Key [{0}]", data.Key)
            data.NextRow()
        End Select
      Else
        Exit Sub
      End If
    End While
  End Sub

End Class