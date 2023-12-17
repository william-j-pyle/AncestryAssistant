Public Class PlaceTag

  Public Property ID As String

  Public Property place As String

  Public Sub New(sPlace As String, sID As String)
    ID = sID
    place = sPlace
  End Sub

End Class