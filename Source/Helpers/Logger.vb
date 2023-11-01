﻿Imports System.Text

Public Class Logger
  Private Const LOG_FILENAME = "D:\Geneology\Logs\APIMessages.txt"

  Public Enum LOG_TYPE
    INFO
    ERR
    DEBUG
  End Enum

  Private Sub New()
    'NOOP
  End Sub

  'Public Shared Sub info(message() As String)
  '  log(LOG_TYPE.INFO, message)
  'End Sub
  'Public Shared Sub info(message As String)
  '  log(LOG_TYPE.INFO, message)
  'End Sub
  'Public Shared Sub err(message() As String)
  '  log(LOG_TYPE.ERR, message)
  'End Sub

  'Public Shared Sub err(message As String)
  '  log(LOG_TYPE.ERR, message)
  'End Sub
  'Public Shared Sub debug(message() As String)
  '  log(LOG_TYPE.DEBUG, message)
  'End Sub

  'Public Shared Sub debug(message As String)
  '  log(LOG_TYPE.DEBUG, message)
  'End Sub

  Public Shared Sub log(typ As LOG_TYPE, message As String)
    message = message.Replace(vbCrLf, vbLf)
    If message.IndexOf(vbLf) > 0 Then
      log(typ, message.Split(vbLf))
    Else
      log(typ, {message})
    End If
  End Sub

  Public Shared Sub log(typ As LOG_TYPE, message() As String)
    Dim sb As StringBuilder = New StringBuilder
    For Each lin As String In message
      sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + typ.ToString.PadRight(6, " ") + lin)
    Next
    System.IO.File.AppendAllText(LOG_FILENAME, sb.ToString)
  End Sub

End Class
