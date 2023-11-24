Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Devices

Namespace My

  ''' <summary>
  '''     My.Application Events
  ''' </summary>
  Partial Friend Class MyApplication

#Region "Private Methods"

    ''' <summary>
    '''     NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    ''' </summary>
    ''' <param name="sender">
    ''' </param>
    ''' <param name="e">
    ''' </param>
    Private Sub MyApplication_NetworkAvailabilityChanged(sender As Object, e As NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
      Logger.log(Logger.LOG_TYPE.DEBUG, "NetworkAvailabilityChanged")
    End Sub

    ''' <summary>
    '''     Shutdown: Raised after all application forms are closed. me event is not raised if the application
    '''     terminates abnormally.
    ''' </summary>
    ''' <param name="sender">
    ''' </param>
    ''' <param name="e">
    ''' </param>
    Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
      Logger.log(Logger.LOG_TYPE.DEBUG, "Shutting Down")
    End Sub

    ''' <summary>
    '''     Startup: Raised when the application starts, before the startup form is created.
    ''' </summary>
    ''' <param name="sender">
    ''' </param>
    ''' <param name="e">
    ''' </param>
    Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
      Logger.log(Logger.LOG_TYPE.DEBUG, "Starting Up")
    End Sub

    ''' <summary>
    '''     StartupNextInstance: Raised when launching a single-instance application and the application is already active.
    ''' </summary>
    ''' <param name="sender">
    ''' </param>
    ''' <param name="e">
    ''' </param>
    Private Sub MyApplication_StartupNextInstance(sender As Object, e As StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
      Logger.log(Logger.LOG_TYPE.DEBUG, "StartupNextInstance")
    End Sub

    ''' <summary>
    '''     UnhandledException: Raised if the application encounters an unhandled exception.
    ''' </summary>
    ''' <param name="sender">
    ''' </param>
    ''' <param name="e">
    ''' </param>
    Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
      Logger.log(Logger.LOG_TYPE.ERR, e.Exception.Message)
      Logger.log(Logger.LOG_TYPE.ERR, e.Exception.StackTrace)
    End Sub

#End Region

  End Class

End Namespace