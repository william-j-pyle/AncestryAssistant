Public Class APIMessage

  Public Const MT_PERSON = "person"
  Public Const MT_ACCOUNT = "account"
  Public Const MT_TREES = "trees"
  Public Const MT_PAGE = "page"
  Public Const MT_TABLEDATA = "tabledata"

  Public Property MessageType As String
  Public Property MessageKey As String
  Public Property Payload As List(Of List(Of String))


  Public Function ContainsKey(key As String) As Boolean
    Return KeyIndex(key) > 0
  End Function


  Public Function KeyIndex(key As String) As Integer
    If Payload.Count > 0 Then
      Dim upKey As String = key.ToUpper
      For c As Integer = 0 To Payload.Item(0).Count - 1
        If Payload.Item(0).Item(c).ToUpper.Equals(upKey) Then
          Return c + 1
        End If
      Next
    End If
    Return 0
  End Function

  Public Function KeyCount() As Integer
    If Payload.Count > 0 Then
      Return Payload.Item(0).Count
    End If
    Return 0
  End Function

  Public Function ValueCount() As Integer
    If Payload.Count > 0 Then
      Return Payload.Count - 1
    End If
    Return 0
  End Function

  Public Function GetValue(key As String, Optional rowIdx As Integer = 1) As String
    Dim keyIdx As Integer = KeyIndex(key)
    If keyIdx > 0 And ValueCount() >= rowIdx Then
      Return Payload.Item(rowIdx).Item(keyIdx - 1)
    End If
    Return String.Empty
  End Function

End Class