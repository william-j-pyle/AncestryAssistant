Public Class Individual

#Region "Public Constructors"

  Public Sub New(gedData As Gedcom, ancestryId As String)
    ged = gedData
  End Sub

  Public Sub New(gedData As Gedcom, yearOfBirth As Integer, surname As String, Optional firstname As String = "")
    ged = gedData
  End Sub

#End Region

#Region "Fields"

  Private ged As Gedcom

#End Region

End Class