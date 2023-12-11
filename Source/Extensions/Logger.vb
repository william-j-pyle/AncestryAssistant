Imports System.IO
Imports System.Text

Public Class Logger

#Region "Fields"

  Private Const DEBUGLOG_FILENAME As String = "D:\Geneology\Logs\AncestryAssistantDebug.log"
  Private Const LOG_FILENAME As String = "D:\Geneology\Logs\AncestryAssistant.log"

#End Region

#Region "Private Constructors"

  Private Sub New()
    'NOOP
  End Sub

#End Region

#Region "Public Methods"

  Public Shared Sub Clear()
    If File.Exists(DEBUGLOG_FILENAME) Then My.Computer.FileSystem.DeleteFile(DEBUGLOG_FILENAME)
    If File.Exists(LOG_FILENAME) Then My.Computer.FileSystem.DeleteFile(LOG_FILENAME)
  End Sub

  Public Shared Sub debugPrint(format As String, ParamArray args As Object())
    Dim str As String = Date.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ": " + String.Format(format, args)
    Debug.Print(str)
    System.IO.File.AppendAllText(DEBUGLOG_FILENAME, str + vbCrLf)
  End Sub

  Public Shared Sub log(typ As LOG_TYPE, message As String)
    message = message.Replace(vbCrLf, vbLf)
    If message.IndexOf(vbLf) > 0 Then
      log(typ, message.Split(vbLf))
    Else
      log(typ, {message})
    End If
  End Sub

  'Public Shared Sub debug(message As String)
  '  log(LOG_TYPE.DEBUG, message)
  'End Sub
  Public Shared Sub log(typ As LOG_TYPE, message() As String)
    Dim sb As New StringBuilder
    For Each lin As String In message
      sb.AppendLine(Date.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + typ.ToString.PadRight(6, " ") + lin)
    Next
    System.IO.File.AppendAllText(LOG_FILENAME, sb.ToString)
  End Sub

#End Region

#Region "Enums"

  Public Enum LOG_TYPE
    INFO
    ERR
    DEBUG
  End Enum

#End Region

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
End Class