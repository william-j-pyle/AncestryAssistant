Public Class GedMediaReference
    Public Property Key As GedReference
    Public Property IsProfile As Boolean
    Public Property CropType As String
    Public Property CropX As Double 'Left
    Public Property CropY As Double 'Top
    Public Property CropW As Double 'Width
    Public Property CropH As Double 'Height
    Public ReadOnly Property Crop As Rectangle    '(Left,Top,Width,Height)
        Get
            Return New Rectangle(CropX, CropY, CropW, CropH)
        End Get
    End Property

    Public Sub addObject(data As GedComData, fileKey As String)
        Dim processedRoot As Boolean = False
        While data.HasNext
            If data.Key.StartsWith(fileKey) Then
                Select Case data.Key.Replace(fileKey, "OBJE")
                    Case "OBJE"
                        If processedRoot Then
                            Exit Sub
                        End If
                        Key = data.RefKey
                        processedRoot = True
                        data.NextRow()
                    Case "OBJE._PRIM"
                        IsProfile = data.Data.Equals("Y")
                        data.NextRow()
                    Case "OBJE._CROP"
                        data.NextRow()
                    Case "OBJE._CROP._LEFT"
                        CropX = data.Data
                        data.NextRow()
                    Case "OBJE._CROP._TOP"
                        CropY = data.Data
                        data.NextRow()
                    Case "OBJE._CROP._WDTH"
                        CropW = data.Data
                        data.NextRow()
                    Case "OBJE._CROP._HGHT"
                        CropH = data.Data
                        data.NextRow()
                    Case "OBJE._CROP._TYPE"
                        CropType = data.Data
                        data.NextRow()
                    Case Else
                        Debug.Print("GedMediaReference: Unhandled Key [{0}]", data.Key)
                        data.NextRow()
                End Select
            Else
                Exit Sub
            End If
        End While
    End Sub

End Class

