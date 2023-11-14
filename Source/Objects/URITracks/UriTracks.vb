Public Class UriTracks
  Public ReadOnly Property UriTrackingGroup As UriTrackingGroupEnum
  Public ReadOnly Property PageDataElements As String()

  Public Sub New(trackingGroup As UriTrackingGroupEnum, pageData() As String)
    UriTrackingGroup = trackingGroup

    PageDataElements = pageData
  End Sub

  Public Function Matches(pPageData() As String) As Boolean
    Dim uPageData() As String = PageDataElements
    If pPageData.Length < uPageData.Length Then Return False
    Dim pIdx As Integer = 0
    For uIdx As Integer = 0 To uPageData.Length - 1
      While Not uPageData(uIdx).ToLower.Equals(pPageData(pIdx).ToLower)
        pIdx += 1
        If pIdx > pPageData.Length - 1 Then Return False
      End While
    Next
    Return True
  End Function
End Class
