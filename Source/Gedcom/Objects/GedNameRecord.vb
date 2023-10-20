'TODO: Not Finished
Public Class GedNameRecord
    Public Name As String = ""
    Public Given As String = ""
    Public Suffix As String = ""
    Public Surname As String = ""
    Public Source As New GedSourceReferenceCollection

    Public Sub addObject(data As GedComData)
        Dim processedRoot As Boolean = False
        Dim baseKey As String = data.Key
        While data.HasNext
            If data.Key.StartsWith(baseKey) Then
                Select Case data.Key.Replace(baseKey, "NAME")
                    Case "NAME"
                        If processedRoot Then Exit Sub
                        Name = data.Data
                        processedRoot = True
                        data.NextRow()
                    Case "NAME.GIVN"
                        Given = data.Data
                        data.NextRow()
                    Case "NAME.SURN"
                        Surname = data.Data
                        data.NextRow()
                    Case "NAME.NSFX"
                        Suffix = data.Data
                        data.NextRow()
                    Case "NAME.SOUR"
                        Source.addObject(data, data.Key)
                    Case Else
                        Debug.Print("GedNameRecord: Unhandled Key [{0}]", data.Key)
                        data.NextRow()
                End Select
            Else
                Exit Sub
            End If
        End While
    End Sub

End Class
