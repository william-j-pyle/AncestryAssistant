Public Class GedComFileLine
    Property LineIndex As Double = 0
    Property LineLevel As Integer = 0
    Property Tag As String = ""
    Property RefKey As GedReference = Nothing
    Property Data As String = ""
    Property Key As String = ""
    Property LineData As String = ""

    Public Sub New(lineIdx As Double, lineLvl As Integer, lineTag As String, lineRef As String, Data As String, keyFlat As String, lineData As String)
        LineIndex = lineIdx
        LineLevel = lineLvl
        Tag = lineTag
        RefKey = New GedReference(lineRef)
        Key = keyFlat
        Me.Data = Data
        Me.LineData = lineData
    End Sub
End Class