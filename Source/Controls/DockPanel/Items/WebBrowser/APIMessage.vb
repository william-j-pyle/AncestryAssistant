Imports System.Text

Public Class APIMessage

#Region "Fields"

  Public Const MT_ACCOUNT As String = "account"
  Public Const MT_FINDAGRAVE As String = "findagrave"
  Public Const MT_IMGDOWNLOAD As String = "imageDownload"
  Public Const MT_PAGE As String = "page"
  Public Const MT_PERSON As String = "person"
  Public Const MT_SAVEAS As String = "imageSaveAs"
  Public Const MT_TABLEDATA As String = "tabledata"
  Public Const MT_TREES As String = "trees"

#End Region

#Region "Properties"

  Public Property MessageKey As String
  Public Property MessageType As String
  Public Property PageKey As String
  Public Property Payload As List(Of List(Of String))

#End Region

#Region "Public Methods"

  Public Function ContainsKey(key As String) As Boolean
    Return KeyIndex(key) > 0
  End Function

  Public Function GetValue(key As String, Optional rowIdx As Integer = 1) As String
    Dim keyIdx As Integer = KeyIndex(key)
    If keyIdx > 0 And ValueCount() >= rowIdx Then
      Return Payload.Item(rowIdx).Item(keyIdx - 1)
    End If
    Return String.Empty
  End Function

  Public Function KeyCount() As Integer
    If Payload.Count > 0 Then
      Return Payload.Item(0).Count
    End If
    Return 0
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

  Public Overrides Function ToString() As String
    Dim sb As New StringBuilder
    sb.AppendLine("-------------------------------------------------")
    sb.AppendLine("--                 NEW MESSAGE                 --")
    sb.AppendLine("-------------------------------------------------")
    sb.AppendLine("MessageType    = " & MessageType)
    sb.AppendLine("MessageKey     = " & MessageKey)
    sb.AppendLine("PageKey        = " & PageKey)
    sb.AppendLine("RowsOfData     = " & Payload.Count)
    sb.AppendLine("Payload")
    For r As Integer = 0 To Payload.Count - 1
      sb.Append("     ROW[" & r & "] = ")
      For c As Integer = 0 To Payload.Item(r).Count - 1
        If c > 0 Then sb.Append("|")
        sb.Append(Payload.Item(r).Item(c))
      Next
      sb.AppendLine()
    Next
    Return sb.ToString()
  End Function

  Public Function ValueCount() As Integer
    If Payload.Count > 0 Then
      Return Payload.Count - 1
    End If
    Return 0
  End Function

#End Region

End Class