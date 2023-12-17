Public Class GedName

  Public Property AKA As String = String.Empty

  Public Property Given As String = String.Empty

  Public Property Name As String
    Get
      If SurName.Equals(String.Empty) Then Return String.Empty
      Dim rtn As String = (SurName + " " + Suffix).Trim
      If Given.Equals(String.Empty) Then
        Return rtn
      Else
        Return rtn + ", " + Given
      End If
    End Get
    Set(value As String)
      If value.Contains(",") Then
        Dim v() As String = value.Split(","c)
        If v(0).Contains(" ") Then
          Dim p() As String = v(0).Split(" "c)
          SurName = p(0)
          Suffix = p(1)
        Else
          SurName = v(0)
        End If
        Given = v(1)
      Else
        Dim v() As String = value.Split(" "c)
        If v.Length = 2 Then
          SurName = v(1)
          Given = v(0)
        End If
        If v.Length > 2 Then
          SurName = v(UBound(v))
          Given = value.Replace(SurName, "").Trim
        End If
      End If
    End Set
  End Property

  Public Property Suffix As String = String.Empty

  Public Property SurName As String = String.Empty

  Public Sub New(newFullName As String)
    Name = newFullName
  End Sub

  Public Sub New(newSurName As String, newGivenName As String)
    SurName = newSurName
    Given = newGivenName
  End Sub

  Public Sub New(newSurName As String, newGivenName As String, newSuffix As String)
    SurName = newSurName
    Given = newGivenName
    Suffix = newSuffix
  End Sub

End Class