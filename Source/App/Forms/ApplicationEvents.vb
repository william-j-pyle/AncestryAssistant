Imports Microsoft.VisualBasic.ApplicationServices

Namespace My

  ' The following events are available for MyApplication:
  ' Startup: Raised when the application starts, before the startup form is created.
  ' Shutdown: Raised after all application forms are closed.  me event is not raised if the application terminates abnormally.
  ' UnhandledException: Raised if the application encounters an unhandled exception.
  ' StartupNextInstance: Raised when launching a single-instance application and the application is already active.
  ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
  Partial Friend Class MyApplication
    Public COLOR_BG As Color = Color.FromArgb(255, 77, 77, 77) 'rgb(27, 27, 24)
    Public COLOR_FG As Color = Color.WhiteSmoke
    Public COLOR_FG_DISABLED As Color = Color.LightGray

    Public COLOR_PANEL_HEADER_BG As Color = Color.FromArgb(255, 97, 97, 97)
    Public COLOR_PANEL_HEADER_FG As Color = Color.WhiteSmoke

    Public COLOR_HOVER_BG As Color = Color.DarkGray
    Public COLOR_HOVER_FG As Color = Color.White
    Public COLOR_HOVER_BORDER As Color = Color.LightGray

    Public COLOR_SELECTED_BG As Color = Color.Gray
    Public COLOR_SELECTED_FG As Color = Color.White
    Public COLOR_SELECTED_BORDER As Color = Color.LightGray

    Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
      'Config = JsonConvert.DeserializeObject(Of jConfig)(New StreamReader("D:\Geneology\Apps\MyAncestry\Config\MyAncestry.json").ReadToEnd)
      'Config.loadProperties("D:\Geneology\Apps\MyAncestry\Config\MyAncestry.props")

      'DataMgr = New DBData()
      'DataMgr.LoadGedCom("D:\Geneology\Data\gedcom\Ancestry-20230711.ged")
      Logger.log(Logger.LOG_TYPE.DEBUG, "Starting Up")
    End Sub

    Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
      Logger.log(Logger.LOG_TYPE.ERR, e.Exception.Message)
      Logger.log(Logger.LOG_TYPE.ERR, e.Exception.StackTrace)
    End Sub

    Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
      Logger.log(Logger.LOG_TYPE.DEBUG, "Shutting Down")
    End Sub
  End Class

End Namespace