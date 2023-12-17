Public Class Individual

  Private ged As Gedcom

  Public Sub New(gedData As Gedcom, ancestryId As String)
    ged = gedData
  End Sub

  Public Sub New(gedData As Gedcom, yearOfBirth As Integer, surname As String, Optional firstname As String = "")
    ged = gedData
  End Sub

End Class