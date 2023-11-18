Public Class PlaceTag

#Region "Properties"

  Public Property ID As String

  Public Property place As String

#End Region

#Region "Public Constructors"

  Public Sub New(sPlace As String, sID As String)
    ID = sID
    place = sPlace
  End Sub

#End Region

End Class