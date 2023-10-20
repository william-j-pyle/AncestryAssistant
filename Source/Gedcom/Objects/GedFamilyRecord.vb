'TODO: Not Finished
Public Class GedFamilyRecord
    Public Property Key As GedReference
    'Public Property Type As String
    Public Property Child As New GedReferenceCollection
    Public Property Divorce As New GedEventRecord
    Public Property Marriage As New GedEventRecord
    Public Property Husband As GedReference
    Public Property Wife As GedReference
    Public Property Source As New GedSourceReferenceCollection
    Public Property Media As New GedMediaReferenceCollection
    Public Property Notes As String

    Public Sub addObject(data As GedComData)
        Dim processedRoot As Boolean = False
        While data.HasNext
            If data.Key.Contains("FAM") Then
                Select Case data.Key
                    Case "FAM"
                        If processedRoot Then Exit Sub
                        Key = data.RefKey
                        processedRoot = True
                        data.NextRow()
                    Case "FAM._SREL"
                        data.NextRow()
                    Case "FAM.CHIL"
                        Child.Add(data.RefKey)
                        data.NextRow()
                    Case "FAM.DIV"
                        Divorce.addObject(data, data.Key)
                    Case "FAM.MARR"
                        Marriage.addObject(data, data.Key)
                    Case "FAM.HUSB"
                        Husband = data.RefKey
                        data.NextRow()
                    Case "FAM.WIFE"
                        Wife = data.RefKey
                        data.NextRow()
                    Case "FAM.NOTE"
                        Notes = data.MultiLineData()
                        data.NextRow()
                    Case "FAM.SOUR"
                        Source.addObject(data, data.Key)
                    Case Else
                        Debug.Print("GedFamilyRecord: Unhandled Key [{0}]", data.Key)
                        data.NextRow()
                End Select
            Else
                Exit Sub
            End If
        End While
    End Sub

End Class