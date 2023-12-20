Imports System.IO
Imports System.Text
Imports Microsoft.Web
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms

Public Class DPIImageViewerWeb
  Inherits DockPanelItem

  Private WithEvents CoreWeb As CoreWebView2
  Private WithEvents CoreWebDownload As CoreWebView2DownloadOperation
  Private WithEvents DataMgr As WebData
  Private WithEvents Web As WebView2
  Private Const ControlHtml As String = "WebControl.html"
  Private Const DatasetName As String = "WebControl"
  Private ActiveAncestorId As String = ""
  Private APIJavaScript As String = ApplyVariables(My.Resources.IncludeJSFocus, My.Resources.IncludeJSScrollbars, My.Resources.JSImageList)
  Private components As System.ComponentModel.IContainer
  Private isReady As Boolean = False
  Private VirtualHostName As String = My.Settings.WEB_HOSTNAME
  Private VirtualPath As String = My.Settings.WEB_VIRTUALPATH
  Public Const Base_Key As String = "DOCK_IMAGEVIEWER"

  Public Sub New(Optional instanceKey As String = "")
    SetStyle(ControlStyles.ContainerControl Or ControlStyles.Selectable Or ControlStyles.StandardClick, True)
    DataMgr = New WebData
    ItemCaption = "Image Viewer"
    ItemDestroyOnClose = False
    ItemHasRibbonBar = True
    ItemHasStatusBar = False
    ItemHasToolBar = True
    ItemSupportsClose = True
    ItemSupportsMove = True
    ItemSupportsSearch = False
    LocationCurrent = DockPanelLocation.None
    LocationPrefered = DockPanelLocation.MiddleTopLeft
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
    rtn = rtn.Replace("{DATASETNAME}", DatasetName)
    Return rtn
  End Function

  Private Sub CoreWeb_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs) Handles CoreWeb.NewWindowRequested
    e.Handled = True
    Web.Source = New Uri(e.Uri)
  End Sub

  Private Sub DataMgr_SelectionChanged(dataSetName As String, RID As String) Handles DataMgr.SelectionChanged
    If ContainsFocus And Not Focused Then
      Focus()
    End If
  End Sub

  Private Async Sub JSAPI_Execute(script As String)
    Await Web.CoreWebView2.ExecuteScriptAsync(script)
  End Sub

  Private Sub JSAPI_Message(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs) Handles Web.WebMessageReceived
    'Dim msg As APIMessage = JsonConvert.DeserializeObject(Of APIMessage)(e.WebMessageAsJson)
    If ContainsFocus And Not Focused Then
      Focus()
    End If
  End Sub

  Private Sub UpdateData()
    Debug.Print("IN UPDATE DATE")
    If ActiveAncestorId.Length > 0 Then
      If ActiveAncestorId.Equals(Ancestors.ActiveAncestorID) Then Exit Sub
    End If
    Debug.Print("STEP1")
    Dim ds As New DMDataSet With {
        .DataSetName = DatasetName
      }
    ds.addColumn("Filename", DMColumnType.ColumnString)
    ds.addColumn("Caption", DMColumnType.ColumnString)
    If Ancestors IsNot Nothing Then
      Debug.Print("STEP2")
      If Ancestors.ActiveAncestor IsNot Nothing Then
        Debug.Print("STEP3")
        ActiveAncestorId = Ancestors.ActiveAncestorID
        Dim galleryPath As String = Ancestors.ActiveAncestor.AncestorPath
        For Each filename As String In Directory.GetFiles(galleryPath, "*.jpg", SearchOption.AllDirectories)
          Dim caption As String = ""
          If System.IO.File.Exists(filename + ".txt") Then
            caption = System.IO.File.ReadAllText(filename + ".txt")
          Else
            caption = filename.Replace(galleryPath, "").Replace(".jpg", "")
          End If
          Dim relativeFilename As String = filename.Replace(My.Settings.WEB_VIRTUALPATH, "/")
          Debug.Print("ADDING FILENAME: {0}", relativeFilename)
          ds.addDataRow(filename, relativeFilename, caption)
        Next
      End If
    End If
    Debug.Print("STEP4")
    DataMgr.RegisterDataSet(ds)
    DataMgr.SelectRow(DatasetName, "")
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

  Protected Overrides Sub UpdateUI(Optional reload As Boolean = True)
    AncestorsUpdated()
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
    Throw New NotImplementedException()
  End Sub

End Class