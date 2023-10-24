Public Class GedName

  Private source As GedSourceReferenceCollection

  Public ReadOnly Property Sources As GedSourceReferenceCollection
    Get
      Return source
    End Get
  End Property

  Public Property Given As String = ""
  Public Property Suffix As String = ""
  Public Property Surname As String = ""

  Public Property Name As String
    Get
      Return (Suffix + Surname).Trim() + IIf(Given.Trim.Length > 1, ", " + Given.Trim, "")
    End Get
    Set(value As String)
      Dim s As String
      Dim p() As String
      If value.Contains(",") Then
        p = value.Split(",")
        Surname = p(0).Trim()
        Given = p(1).Trim()
      Else
        If value.Length > 2 Then
          p = value.Split(" ")
          If IsArray(p) And p.Length > 0 Then
            s = p(UBound(p))
            If s.Length() < 4 Then
              s = p(UBound(p) - 1) & " " & s
            End If
            Surname = s.Trim()
            Given = value.Replace(s, "").Trim()
          Else
            Surname = value.Trim()
            Given = ""
          End If
        Else
          Surname = ""
          Given = ""
        End If
      End If
    End Set
  End Property

  Public Sub New()
    Initialize()
  End Sub

  Public Sub New(AncestorName As String)
    Initialize()
    Name = AncestorName
  End Sub

  Public Sub New(AncestorSurName As String, AncestorGivenName As String, Optional AncestorSuffix As String = "")
    Initialize()
    Surname = AncestorSurName
    Given = AncestorGivenName
    Suffix = AncestorSuffix
  End Sub

  Private Sub Initialize()
    source = New GedSourceReferenceCollection()
  End Sub

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
            source.addObject(data, data.Key)
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