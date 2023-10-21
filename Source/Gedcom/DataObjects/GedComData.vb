Public Class GedComData
    Private FileData As ArrayList
    Private FileIndex As Integer

    Public Function MultiLineData() As String
        Dim rtnData = Data
        Dim myKey = Key
        While FileData(FileIndex + 1).key = myKey + ".CONT" Or FileData(FileIndex + 1).key = myKey + ".CONC"
            NextRow()
            If Key.EndsWith("CONC") Then
                rtnData += Data
            Else
                rtnData += vbNewLine + Data
            End If
        End While
        Return rtnData
    End Function

    Public Sub Add(ByVal line As GedComFileLine)
        FileData.Add(line)
    End Sub

    Public ReadOnly Property FileLine As GedComFileLine
        Get
            Return FileData(FileIndex)
        End Get
    End Property

    Public ReadOnly Property Tag As String
        Get
            Return FileLine.Tag
        End Get
    End Property

    Public ReadOnly Property LineLevel As Integer
        Get
            Return FileLine.LineLevel
        End Get
    End Property
    Public ReadOnly Property Key As String
        Get
            Return FileLine.Key
        End Get
    End Property
    Public ReadOnly Property RefKey As GedReference
        Get
            Return FileLine.RefKey
        End Get
    End Property
    Public ReadOnly Property Data As String
        Get
            Return FileLine.Data
        End Get
    End Property
    Public ReadOnly Property LineData As String
        Get
            Return FileLine.LineData
        End Get
    End Property

    Public Property Index As Integer
        Get
            Return FileIndex
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then value = 0
            If value > FileData.Count - 1 Then value = FileData.Count - 1
            FileIndex = value
        End Set
    End Property

    Public ReadOnly Property HasNext() As Boolean
        Get
            Return ((Index + 1) < FileData.Count)
        End Get
    End Property

    Public Function NextRow() As Boolean
        If FileIndex + 1 < FileData.Count Then
            Index = FileIndex + 1
            Return True
        End If
        Return False
    End Function

    Public Function PrevRow() As Boolean
        If FileIndex > 0 Then
            Index = FileIndex - 1
            Return True
        End If
        Return False
    End Function

    Public Sub New()
        FileData = New ArrayList
        FileIndex = 0
    End Sub

End Class
