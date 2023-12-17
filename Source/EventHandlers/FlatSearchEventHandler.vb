' Define a delegate type for the custom event handler
Public Delegate Sub FlatSearchEventHandler(sender As Object, e As FlatSearchEventArgs)

' Define a custom event arguments class
Public Class FlatSearchEventArgs
  Inherits EventArgs

  Public Property Criteria As String = ""
  Public Property IsCanceled As Boolean = False

  ' Constructor to initialize the custom data
  Public Sub New(searchCriteria As String)
    Criteria = searchCriteria
  End Sub

  Public Sub New(searchCanceled As Boolean)
    IsCanceled = searchCanceled
  End Sub

  Public Sub New(searchCriteria As String, canceled As Boolean)
    Criteria = searchCriteria
    IsCanceled = canceled
  End Sub

End Class