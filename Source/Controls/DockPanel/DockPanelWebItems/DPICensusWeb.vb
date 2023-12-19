Imports System.Text
Imports Microsoft.Web
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms
Imports Newtonsoft.Json

Public Class DPICensusWeb
  Inherits DockPanelItem

  Private WithEvents CoreWeb As CoreWebView2
  Private WithEvents CoreWebDownload As CoreWebView2DownloadOperation
  Private WithEvents DataMgr As WebData
  Private WithEvents Web As WebView2
  Private Const DatasetName As String = "WebControl"
  Private APIJavaScript As String = ApplyVariables(My.Resources.IncludeJSFocus, My.Resources.IncludeJSScrollbars, My.Resources.JSTable)
  Private components As System.ComponentModel.IContainer
  Private ControlHtml As String = "WebControl.html"
  Private isReady As Boolean = False
  Private VirtualHostName As String = My.Settings.WEB_HOSTNAME
  Private VirtualPath As String = My.Settings.WEB_VIRTUALPATH
  Public Const Base_Key As String = "DOCK_CENSUSWEB"
  Public ReadOnly Property ControlInitialized As Boolean = False

  Public Sub New(Optional instanceKey As String = "")
    SetStyle(ControlStyles.ContainerControl Or ControlStyles.Selectable Or ControlStyles.StandardClick, True)
    DataMgr = New WebData
    ItemCaption = "Census"
    ItemDestroyOnClose = False
    ItemHasRibbonBar = True
    ItemHasStatusBar = False
    ItemHasToolBar = False
    ItemSupportsClose = True
    ItemSupportsMove = True
    ItemSupportsSearch = False
    LocationCurrent = DockPanelLocation.None
    LocationPrefered = DockPanelLocation.MiddleBottom
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

  Private Sub CoreWeb_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs) Handles CoreWeb.NewWindowRequested
    e.Handled = True
    Web.Source = New Uri(e.Uri)
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

  Protected Overrides Sub UpdateUI(Optional reload As Boolean = True) Handles _Ancestors.ActiveAncestorChanged, _Ancestors.AncestorsChanged
    If ControlInitialized Then Exit Sub
    If Ancestors Is Nothing Then Exit Sub
    If Not Ancestors.HasActiveAncestor Then Exit Sub
    Dim ds As New DMDataSet With {
      .DataSetName = "WebControl"
    }
    If ItemInstanceKey.Equals("Unified") Then
    Else
      Dim Data As AAFile = Ancestors.ActiveAncestor.Census.GetAADatasource(CInt(ItemInstanceKey))
      For Each columnName As String In Data.GetHeaders
        ds.addColumn(columnName, DMColumnType.ColumnString)
      Next
      Dim RID As Integer = 0
      For Each row() As String In Data.GetValues
        RID += 1
        ds.addDataRow(RID.ToString, row)
      Next
    End If
    DataMgr.RegisterDataSet(ds)
    DataMgr.SelectRow(ds.DataSetName, "1")
    _ControlInitialized = True
  End Sub

  Public Sub ActionRequest(eventType As DockPanelItemEventType, eventData As Object)
    Throw New NotImplementedException()
  End Sub

  Public Overrides Sub ApplySearch(criteria As String)
    Throw New NotImplementedException()
  End Sub

  Public Overrides Sub ClearSearch()
    Throw New NotImplementedException()
  End Sub

  Public Overrides Sub EventRequest(eventType As DockPanelItemEventType, eventData As Object)

  End Sub

End Class