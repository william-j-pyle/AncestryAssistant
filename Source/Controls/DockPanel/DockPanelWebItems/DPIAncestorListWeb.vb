Imports System.Text
Imports Microsoft.Web
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms
Imports Newtonsoft.Json

Public Class DPIAncestorListWeb
  Inherits DockPanelItem

  Private WithEvents CoreWeb As CoreWebView2
  Private WithEvents CoreWebDownload As CoreWebView2DownloadOperation
  Private WithEvents DataMgr As WebData
  Private WithEvents Web As WebView2
  Private Const DatasetName As String = "WebControl"
  Private APIJavaScript As String = ApplyVariables(My.Resources.IncludeJSFocus, My.Resources.IncludeJSScrollbars, My.Resources.JSListBox)
  Private components As System.ComponentModel.IContainer
  Private ControlHtml As String = "WebControl.html"
  Private isReady As Boolean = False
  Private VirtualHostName As String = My.Settings.WEB_HOSTNAME
  Private VirtualPath As String = My.Settings.WEB_VIRTUALPATH
  Public Const Base_Key As String = "DOCK_ANCESTORSLIST"

  Public Sub New(Optional instanceKey As String = "")
    SetStyle(ControlStyles.ContainerControl Or ControlStyles.Selectable Or ControlStyles.StandardClick, True)
    DataMgr = New WebData
    ItemCaption = "Ancestors List"
    ItemDestroyOnClose = False
    ItemHasRibbonBar = True
    ItemHasStatusBar = False
    ItemHasToolBar = True
    ItemSupportsClose = True
    ItemSupportsMove = True
    ItemSupportsSearch = False
    LocationCurrent = DockPanelLocation.None
    LocationPrefered = DockPanelLocation.LeftBottom
    LocationPrevious = DockPanelLocation.None
    RibbonBarKey = ""
    RibbonHideOnItemClose = False
    RibbonSelectOnItemFocus = True
    RibbonShowOnItemOpen = True
    ItemKey = Base_Key
    ItemInstanceKey = instanceKey
    Web = New Microsoft.Web.WebView2.WinForms.WebView2()
    CType(Web, System.ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    Web.AllowExternalDrop = False
    Web.BackColor = My.Theme.PanelBackColor
    Web.CreationProperties = Nothing
    Web.DefaultBackgroundColor = My.Theme.PanelBackColor
    Web.Dock = System.Windows.Forms.DockStyle.Fill
    Web.Margin = New System.Windows.Forms.Padding(0)
    Web.Padding = New System.Windows.Forms.Padding(0)
    Web.ZoomFactor = 1
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Controls.Add(Web)
    Dock = DockStyle.Fill
    BackColor = My.Theme.PanelBackColor
    CType(Web, System.ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
    PerformLayout()
    CaptureFocus(Me)
    Web.EnsureCoreWebView2Async()
  End Sub

  Private Sub AncestorsUpdated() Handles _Ancestors.AncestorsChanged
    Dim ds As New DMDataSet
    With ds
      .DataSetName = "WebControl"
      .addColumn("Name", DMColumnType.ColumnString)
      .addColumn("Lifespan", DMColumnType.ColumnString)
      For Each Ancestor As AncestorCollection.Ancestor In Ancestors.Values
        .addDataRow(Ancestor.ID, Ancestor.FullName, Ancestor.LifeSpan)
      Next
    End With
    DataMgr.RegisterDataSet(ds)
    DataMgr.SelectRow(ds.DataSetName, Ancestors.ActiveAncestorID)
  End Sub

  Private Function ApplyVariables(ParamArray sources() As String) As String
    Dim rtn As String = ""
    Dim sb As New StringBuilder
    For Each src As String In sources
      sb.AppendLine(src)
    Next
    rtn = sb.ToString
    rtn = rtn.Replace("{VIRTUALHOSTNAME}", My.Settings.WEB_HOSTNAME)
    rtn = rtn.Replace("{DATASETNAME}", "WebControl")
    Return rtn
  End Function

  ' When the browser detects a file is being downloaded me routine will fire, we Capture the DownloadOperation object
  ' and monitor its events for completion of the download, then fire an event about the download
  Private Sub CoreWeb_DownloadStarting(sender As Object, e As CoreWebView2DownloadStartingEventArgs) Handles CoreWeb.DownloadStarting
    CoreWebDownload = e.DownloadOperation
  End Sub

  ' If enabled, me routine will cancel every request to various tracking sites
  Private Sub CoreWeb_FrameNavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles CoreWeb.FrameNavigationStarting, CoreWeb.NavigationStarting
    'If BlockWebTracking Then
    '  If ShouldBlockNavigation(e.Uri) Then
    '    e.Cancel = True
    '  End If
    'End If
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
    'Dim saveImageAsFilename As String = "TODO"
    'If CoreWebDownload.State = CoreWebView2DownloadState.Completed And CoreWeb.IsDefaultDownloadDialogOpen Then
    '  CoreWeb.CloseDefaultDownloadDialog()
    '  If saveImageAsFilename.Length = 0 Then
    '    Dim msg As New APIMessage With {
    '      .MessageType = APIMessage.MT_SAVEAS
    '    }
    '    Dim payload As New List(Of List(Of String))
    '    Dim row As New List(Of String) From {
    '      "fileName"
    '    }
    '    payload.Add(row)
    '    row = New List(Of String) From {
    '      CoreWebDownload.ResultFilePath()
    '    }
    '    payload.Add(row)
    '    msg.Payload = payload
    '    RaiseEvent DataDownload(msg)
    '  Else
    '    If System.IO.File.Exists(saveImageAsFilename) Then
    '      System.IO.File.Delete(saveImageAsFilename)
    '    End If
    '    System.IO.File.Move(CoreWebDownload.ResultFilePath(), saveImageAsFilename)
    '    Dim msg As New APIMessage With {
    '      .MessageType = APIMessage.MT_IMGDOWNLOAD
    '    }
    '    Dim payload As New List(Of List(Of String))
    '    Dim row As New List(Of String) From {
    '      "fileName"
    '    }
    '    payload.Add(row)
    '    row = New List(Of String) From {
    '      saveImageAsFilename
    '    }
    '    payload.Add(row)
    '    msg.Payload = payload
    '    RaiseEvent DataDownload(msg)
    '    saveImageAsFilename = ""
    '  End If
    'End If
  End Sub

  Private Sub DataMgr_SelectionChanged(dataSetName As String, RID As String) Handles DataMgr.SelectionChanged
    Ancestors.ActiveAncestorID = RID
    If ContainsFocus And Not Focused Then
      Focus()
    End If
  End Sub

  Private Async Sub JSAPI_Execute(script As String)
    Await Web.CoreWebView2.ExecuteScriptAsync(script)
  End Sub

  Private Sub JSAPI_Message(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs) Handles Web.WebMessageReceived
    Dim msg As APIMessage = JsonConvert.DeserializeObject(Of APIMessage)(e.WebMessageAsJson)

  End Sub

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
      If DataMgr IsNot Nothing Then
        .AddHostObjectToScript("DataMgr", DataMgr)
      End If
      .SetVirtualHostNameToFolderMapping(VirtualHostName, VirtualPath, CoreWebView2HostResourceAccessKind.Allow)
      .AddScriptToExecuteOnDocumentCreatedAsync(APIJavaScript)
    End With
    isReady = True
    Web.Source = New Uri(String.Format("http://{0}/web/{1}", VirtualHostName, ControlHtml))
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

  Protected Overrides Sub UpdateUI(Optional reload As Boolean = True)
    AncestorsUpdated()
  End Sub

  Public Sub ActionRequest(eventType As DockPanelItemEventType, eventData As Object)
    Select Case eventType
      Case DockPanelItemEventType.NavRequested
        ' NavigateTo(CType(eventData, UriTrackingGroupEnum))
    End Select
  End Sub

  Public Sub ActiveAncestorChanged() Handles _Ancestors.ActiveAncestorChanged
    DataMgr.SelectRow(DatasetName, Ancestors.ActiveAncestorID)
  End Sub

  Public Overrides Sub ApplySearch(criteria As String)
    'Throw New NotImplementedException()
  End Sub

  Public Overrides Sub ClearSearch()
    'Throw New NotImplementedException()
  End Sub

  Public Overrides Sub EventRequest(eventType As DockPanelItemEventType, eventData As Object)
    Select Case eventType
      Case DockPanelItemEventType.NavRequested
    End Select
  End Sub

End Class