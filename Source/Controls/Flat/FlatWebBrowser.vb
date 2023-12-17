Imports Microsoft.Web
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms
Imports Newtonsoft.Json

Public Class FlatWebBrowser
  Inherits UserControl

  Private WithEvents CoreWeb As CoreWebView2
  Private WithEvents CoreWebDownload As CoreWebView2DownloadOperation
  Private WithEvents Web As WebView2

  Private components As System.ComponentModel.IContainer
  ' Tracking
  Private isReady As Boolean = False

  Public Property BlockedWebDomains As String() = {"adsafe", "syndication", "facebook", "doubleclick", "tiktok", "pinterest", "adservice", "ad-delivery", "adspsp", "adsystem", "adnxs", "securepubads"}

  Public Property BlockWebTracking As Boolean = False

  Public Property ZoomFactor As Double
    Get
      Return Web.ZoomFactor
    End Get
    Set(value As Double)
      Web.ZoomFactor = value
    End Set
  End Property

  Public Event DataDownload(data As APIMessage)

  Public Event ViewerBusy(busy As Boolean)

  'Public Property HREF As String
  '  Get
  '    Return URL.AbsoluteUri
  '  End Get
  '  Set(value As String)
  '    URL = New Uri(value)
  '  End Set
  'End Property

  Public Sub New()
    Web = New Microsoft.Web.WebView2.WinForms.WebView2()
    CType(Web, System.ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    Web.AllowExternalDrop = True
    Web.BackColor = My.Theme.PanelBackColor
    Web.CreationProperties = Nothing
    Web.DefaultBackgroundColor = My.Theme.PanelBackColor
    Web.Dock = System.Windows.Forms.DockStyle.Fill
    Web.Margin = New System.Windows.Forms.Padding(0)
    Web.Padding = New System.Windows.Forms.Padding(0)
    Web.ZoomFactor = 0.75R

    AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Controls.Add(Web)
    Dock = DockStyle.Fill
    CType(Web, System.ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
    PerformLayout()
    Web.EnsureCoreWebView2Async()
  End Sub

  ' When the browser detects a file is being downloaded me routine will fire, we Capture the DownloadOperation object
  ' and monitor its events for completion of the download, then fire an event about the download
  Private Sub CoreWeb_DownloadStarting(sender As Object, e As CoreWebView2DownloadStartingEventArgs) Handles CoreWeb.DownloadStarting
    CoreWebDownload = e.DownloadOperation
  End Sub

  ' If enabled, me routine will cancel every request to various tracking sites
  Private Sub CoreWeb_FrameNavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles CoreWeb.FrameNavigationStarting, CoreWeb.NavigationStarting
    If BlockWebTracking Then
      If ShouldBlockNavigation(e.Uri) Then
        e.Cancel = True
      End If
    End If
  End Sub

  Private Sub CoreWeb_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles CoreWeb.NavigationCompleted
    '_URL = Web.Source
  End Sub

  ' If the result of the current navigation attempts to open a new window me routine will fire, mark the navigation
  ' event as handled, then passes the url back to the original browser window
  Private Sub CoreWeb_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs) Handles CoreWeb.NewWindowRequested
    e.Handled = True
    'HREF = e.Uri
  End Sub

  Private Sub CoreWebDownload_StateChanged(sender As Object, e As Object) Handles CoreWebDownload.StateChanged
    Dim saveImageAsFilename As String = "TODO"
    If CoreWebDownload.State = CoreWebView2DownloadState.Completed And CoreWeb.IsDefaultDownloadDialogOpen Then
      CoreWeb.CloseDefaultDownloadDialog()
      If saveImageAsFilename.Length = 0 Then
        Dim msg As New APIMessage With {
          .MessageType = APIMessage.MT_SAVEAS
        }
        Dim payload As New List(Of List(Of String))
        Dim row As New List(Of String) From {
          "fileName"
        }
        payload.Add(row)
        row = New List(Of String) From {
          CoreWebDownload.ResultFilePath()
        }
        payload.Add(row)
        msg.Payload = payload
        RaiseEvent DataDownload(msg)
      Else
        If System.IO.File.Exists(saveImageAsFilename) Then
          System.IO.File.Delete(saveImageAsFilename)
        End If
        System.IO.File.Move(CoreWebDownload.ResultFilePath(), saveImageAsFilename)
        Dim msg As New APIMessage With {
          .MessageType = APIMessage.MT_IMGDOWNLOAD
        }
        Dim payload As New List(Of List(Of String))
        Dim row As New List(Of String) From {
          "fileName"
        }
        payload.Add(row)
        row = New List(Of String) From {
          saveImageAsFilename
        }
        payload.Add(row)
        msg.Payload = payload
        RaiseEvent DataDownload(msg)
        saveImageAsFilename = ""
      End If
    End If
  End Sub

  Private Async Sub JSAPI_Execute(script As String)
    Await Web.CoreWebView2.ExecuteScriptAsync(script)
  End Sub

  Private Sub JSAPI_Message(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs) Handles Web.WebMessageReceived
    Dim msg As APIMessage = JsonConvert.DeserializeObject(Of APIMessage)(e.WebMessageAsJson)

    'If msg.MessageType.Equals("person") And msg.MessageKey.Length > 4 Then
    '  AncestorID = msg.MessageKey
    'End If

    'If msg.MessageType.Equals("page") Then
    '  Dim tracks As String = msg.GetValue("PAGEKEY")
    '  ' Ancestry Image and Media Viewer Data Capture
    '  If utg = UriTrackingGroupEnum.ANCESTRY_VIEWER_IMAGE Or utg = UriTrackingGroupEnum.ANCESTRY_VIEWER_MEDIA Then
    '    JSAPI_Execute("ancestryAssistant.getTableData(" + AncestorID + ");")
    '    Exit Sub
    '  End If
    '  ' Ancestry Person information data capture
    '  If utg = UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON Or utg = UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON Or utg = UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON Or utg = UriTrackingGroupEnum.ANCESTRY_STORY_PERSON Then
    '    JSAPI_Execute("ancestryAssistant.getPerson();")
    '    Exit Sub
    '  End If
    '  If utg = UriTrackingGroupEnum.FINDAGRAVE_MEMORIAL Then
    '    JSAPI_Execute("ancestryAssistant.getFindAGrave();")
    '    Exit Sub
    '  End If

    'End If
    'msg.PageKey = UriTrackingGroup.ToString
    'RaiseEvent DataDownload(msg)
  End Sub

  Private Function ShouldBlockNavigation(uri As String) As Boolean
    For Each partialDomain As String In BlockedWebDomains
      If uri.ToLower.Contains(partialDomain.ToLower) Then
        Return True
      End If
    Next
    Return False
  End Function

  Private Sub Web_CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) Handles Web.CoreWebView2InitializationCompleted
    CoreWeb = Web.CoreWebView2
    With CoreWeb
      With .Settings
        .AreHostObjectsAllowed = True
        .IsPasswordAutosaveEnabled = True
        .IsWebMessageEnabled = True
        .IsGeneralAutofillEnabled = True
        .IsScriptEnabled = True
        .IsZoomControlEnabled = False
        .AreBrowserAcceleratorKeysEnabled = False
#If DEBUG Then
        .AreDefaultScriptDialogsEnabled = True
        .AreDevToolsEnabled = True
        .AreDefaultContextMenusEnabled = True
        .IsStatusBarEnabled = True
        .IsBuiltInErrorPageEnabled = True
#Else
        .AreDefaultScriptDialogsEnabled = False
        .AreDevToolsEnabled = False
        .AreDefaultContextMenusEnabled = False
        .IsStatusBarEnabled = False
        .IsBuiltInErrorPageEnabled = False
#End If
      End With
      .AddScriptToExecuteOnDocumentCreatedAsync(My.Resources.AssistantAPI)
    End With
    isReady = True
    'If URL IsNot Nothing Then
    '  If URL.OriginalString.Length > 0 Then
    '    Web.Source = URL
    '  End If
    'End If
  End Sub

  Private Sub Web_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles Web.NavigationCompleted
    RaiseEvent ViewerBusy(False)
  End Sub

  Private Sub Web_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles Web.NavigationStarting
    RaiseEvent ViewerBusy(True)
  End Sub

  Private Sub Web_SourceChanged(sender As Object, e As CoreWebView2SourceChangedEventArgs) Handles Web.SourceChanged
    'JSAPI_Execute("ancestryAssistant.getPage();")
    'TxtHref.Text = Web.Source.AbsoluteUri
  End Sub

  'UserControl overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  Public Sub ActionRequest(eventType As DockPanelItemEventType, eventData As Object)
    Select Case eventType
      Case DockPanelItemEventType.NavRequested
        ' NavigateTo(CType(eventData, UriTrackingGroupEnum))
    End Select
  End Sub

  'Public Sub saveImageAs(filename As String)
  '  Dim src As String = Web.Source.AbsoluteUri
  '  If src.EndsWith("jpg") Or src.EndsWith("jpeg") Then
  '    My.Computer.Network.DownloadFile(src, filename)
  '  Else
  '    sameImageAsFilename = filename
  '    JSAPI_Execute("ancestryAssistant.getImage();")
  '  End If
  'End Sub

End Class