Public Class DORow
  Public Property data As String()
  Public Property RID As String

  Public Sub New(pRID As String, pData() As String)
    Me.RID = pRID
    Me.data = pData
  End Sub

End Class