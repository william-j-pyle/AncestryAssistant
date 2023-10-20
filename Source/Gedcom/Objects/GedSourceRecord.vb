Public Class GedSourceRecord
    Public Property Key As GedReference
    Public Property Title As String
    Public Property AncestryAPID As String
    Public Property Author As String
    Public Property Note As String
    Public Property Publisher As String
    Public Property PublishDate As GedDate
    Public Property PublishPlace As GedPlace
    Public Property RepoRefKey As GedReference

    Public Sub addObject(data As GedComData)
        Dim processedRoot As Boolean = False
        While data.HasNext
            If data.Key.Contains("SOUR") Then
                Select Case data.Key
                    Case "SOUR"
                        If processedRoot Then
                            Exit Sub
                        End If
                        Key = data.RefKey
                        processedRoot = True
                        data.NextRow()
                    Case "SOUR.AUTH"
                        Author = data.Data
                        data.NextRow()
                    Case "SOUR.PUBL"
                        Publisher = data.MultiLineData()
                        data.NextRow()
                    Case "SOUR.PUBL.DATE"
                        PublishDate = New GedDate(data.Data)
                        data.NextRow()
                    Case "SOUR.PUBL.PLAC"
                        PublishPlace = New GedPlace(data.Data)
                        data.NextRow()
                    Case "SOUR._APID"
                        AncestryAPID = data.Data
                        data.NextRow()
                    Case "SOUR.REPO"
                        RepoRefKey = data.RefKey
                        data.NextRow()
                    Case "SOUR.TITL"
                        Title = data.MultiLineData()
                        data.NextRow()
                    Case "SOUR.NOTE"
                        Note = data.MultiLineData()
                        data.NextRow()
                    Case Else
                        Debug.Print("GedSourceRecord: Unhandled Key [{0}]", data.Key)
                        data.NextRow()
                End Select
            Else
                Exit Sub
            End If
        End While
    End Sub

End Class
