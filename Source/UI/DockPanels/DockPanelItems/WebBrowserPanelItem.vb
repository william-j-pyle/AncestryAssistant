Imports System.ComponentModel
Imports Microsoft.Web
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms
Imports Newtonsoft.Json

#Const SHOW_DEBUG = False
#Const MSG_DUMP = False
#Const MSG_LOG = False

Public Class AncestryWebViewer
  Inherits System.Windows.Forms.UserControl
  Implements IDockPanelItem

  Private Const EN_ITEMCAPTION As String = "Ancestry.com"

  ' Web Interface
  Private WithEvents web As WebView2
  Private WithEvents CoreWeb As CoreWebView2
  Private WithEvents CoreWebDownload As CoreWebView2DownloadOperation
  ' Tool Strip
  Private WithEvents tsWeb As ToolStrip
  Private WithEvents btnHome As ToolStripButton
  Private WithEvents txtHref As ToolStripTextBox
  Private WithEvents btnBack As ToolStripButton
  Private WithEvents btnReload As ToolStripButton

  ' Tracking
  Private isReady As Boolean = False
  Private sameImageAsFilename As String = ""
  Private UriTrackingGroupDecoder As UriTrackingGroup = New UriTrackingGroup()

  ' Public Events
  Public Event UriTrackingGroupChanged(NewGroup As UriTrackingGroupEnum, OldGroup As UriTrackingGroupEnum)
  Public Event DataDownload(data As APIMessage)
  Public Event AncestorChanged(AncestorID As String)
  Public Event ViewerBusy(busy As Boolean)
  Public Event PanelItemGotFocus(sender As Object, e As EventArgs) Implements IDockPanelItem.PanelItemGotFocus
  Public Event AncestorAssigned() Implements IDockPanelItem.AncestorAssigned
  Public Event AncestorUpdated() Implements IDockPanelItem.AncestorUpdated

  Public Sub New()
    web = New Microsoft.Web.WebView2.WinForms.WebView2()
    tsWeb = New System.Windows.Forms.ToolStrip()
    btnBack = New System.Windows.Forms.ToolStripButton()
    btnReload = New System.Windows.Forms.ToolStripButton()
    btnHome = New System.Windows.Forms.ToolStripButton()
    txtHref = New System.Windows.Forms.ToolStripTextBox()
    CType(web, System.ComponentModel.ISupportInitialize).BeginInit()
    tsWeb.SuspendLayout()
    SuspendLayout()
    '
    'web
    '
    web.AllowExternalDrop = True
    web.BackColor = System.Drawing.Color.White
    web.CreationProperties = Nothing
    web.DefaultBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
    web.Dock = System.Windows.Forms.DockStyle.Fill
    web.Location = New System.Drawing.Point(0, 25)
    web.Margin = New System.Windows.Forms.Padding(0)
    web.Name = "web"
    web.Size = New System.Drawing.Size(600, 202)
    web.TabIndex = 0
    web.ZoomFactor = 0.75R
    '
    'tsWeb
    '
    tsWeb.CanOverflow = False
    tsWeb.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    tsWeb.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    tsWeb.Items.AddRange(New System.Windows.Forms.ToolStripItem() {btnBack, btnReload, btnHome, txtHref})
    tsWeb.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
    tsWeb.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
    tsWeb.Name = "tsWeb"
    tsWeb.Padding = New System.Windows.Forms.Padding(4, 0, 16, 0)
    tsWeb.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
    tsWeb.Size = New System.Drawing.Size(600, 25)
    tsWeb.Stretch = True
    tsWeb.TabIndex = 2
    '
    'btnBack
    '
    btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    btnBack.Image = Global.AncestryAssistant.My.Resources.Resources.LEFT_ICO20
    btnBack.ImageTransparentColor = System.Drawing.Color.Magenta
    btnBack.Name = "btnBack"
    btnBack.Size = New System.Drawing.Size(23, 22)
    btnBack.Text = "ToolStripButton2"
    btnBack.ToolTipText = "Previous Page"
    '
    'btnReload
    '
    btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    btnReload.Image = Global.AncestryAssistant.My.Resources.Resources.REFRESH_ICO20
    btnReload.ImageTransparentColor = System.Drawing.Color.Magenta
    btnReload.Name = "btnReload"
    btnReload.Size = New System.Drawing.Size(23, 22)
    btnReload.Text = "ToolStripButton1"
    btnReload.ToolTipText = "Refresh"
    '
    'btnHome
    '
    btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    btnHome.Image = Global.AncestryAssistant.My.Resources.Resources.HOME_ICO20
    btnHome.ImageTransparentColor = System.Drawing.Color.Magenta
    btnHome.Name = "btnHome"
    btnHome.Size = New System.Drawing.Size(23, 22)
    btnHome.Text = "ToolStripButton1"
    btnHome.ToolTipText = "Ancestry Home Page"
    '
    'txtHref
    '
    txtHref.AutoSize = False
    txtHref.BackColor = System.Drawing.SystemColors.Window
    txtHref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    txtHref.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    txtHref.Name = "txtHref"
    txtHref.Size = New System.Drawing.Size(100, 22)
    txtHref.ToolTipText = "Website URL"
    '
    'AncestryWebViewer
    '
    AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Controls.Add(web)
    Controls.Add(tsWeb)
    Dock = DockStyle.Fill
    Name = "AncestryWebViewer"
    Size = New System.Drawing.Size(600, 227)
    CType(web, System.ComponentModel.ISupportInitialize).EndInit()
    tsWeb.ResumeLayout(False)
    tsWeb.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
    web.EnsureCoreWebView2Async()
  End Sub


#Region "Viewer - Public Properties"

  Public Property BlockWebTracking As Boolean = False

  Public Property BlockedWebDomains As String() = {"adsafe", "syndication", "facebook", "doubleclick", "tiktok", "pinterest", "adservice", "ad-delivery", "adspsp", "adsystem", "adnxs", "securepubads"}

  Public ReadOnly Property AncestryBaseURL As String = "https://www.ancestry.com/"

  Public Property AncestryTreeID As String = ""

  Private _UriTrackingGroup As UriTrackingGroupEnum = UriTrackingGroupEnum.ANCESTRY
  Public Property UriTrackingGroup As UriTrackingGroupEnum
    Get
      Return _UriTrackingGroup
    End Get
    Set(value As UriTrackingGroupEnum)
      If value <> _UriTrackingGroup Then
        Logger.log(Logger.LOG_TYPE.INFO, "UriTrackingGroup Changed {New:" & value.ToString & ", Old:" & _UriTrackingGroup.ToString & "}")
        Dim oldValue As UriTrackingGroupEnum = _UriTrackingGroup
        _UriTrackingGroup = value
        RaiseEvent UriTrackingGroupChanged(value, oldValue)
      End If
    End Set
  End Property

  Private _MsgSyncKey As Integer = 0
  Public ReadOnly Property MessageSyncKey As Integer
    Get
      _MsgSyncKey += 1
      If _MsgSyncKey > 999 Then _MsgSyncKey = 1
      Return _MsgSyncKey
    End Get
  End Property

  Private _ShowToolbar As Boolean = False
  Public Property ShowToolbar As Boolean
    Get
      Return _ShowToolbar
    End Get
    Set(value As Boolean)
      _ShowToolbar = value
      tsWeb.Visible = value
    End Set
  End Property

  Private _AncestorID As String = ""

  Public Property AncestorID As String
    Get
      Return _AncestorID
    End Get
    Set(value As String)
      If Not value.Equals(_AncestorID) Then
        _AncestorID = value
        RaiseEvent AncestorChanged(value)
      End If
    End Set
  End Property

  Public Property AncestryPage As String = ""

  Private _URL As Uri = New Uri(AncestryBaseURL)
  <Browsable(False)>
  Public Property URL As Uri
    Get
      Return _URL
    End Get
    Set(value As Uri)
      _URL = value
      If isReady And value IsNot Nothing Then
        If value.OriginalString.Length > 0 Then
          web.Source = value
        End If
      End If
    End Set
  End Property

  Public Property HREF As String
    Get
      Return URL.AbsoluteUri
    End Get
    Set(value As String)
      URL = New Uri(value)
    End Set
  End Property

  Public ReadOnly Property ItemCaption As String = EN_ITEMCAPTION Implements IDockPanelItem.ItemCaption
  Public ReadOnly Property ItemSupportsSearch As Boolean = False Implements IDockPanelItem.ItemSupportsSearch
  Public ReadOnly Property ItemSupportsClose As Boolean = True Implements IDockPanelItem.ItemSupportsClose
  Public ReadOnly Property ItemSupportsMove As Boolean = True Implements IDockPanelItem.ItemSupportsMove
  Public ReadOnly Property ItemHasRibbonBar As Boolean = False Implements IDockPanelItem.ItemHasRibbonBar
  Public ReadOnly Property ShowRibbonOnFocus As String = String.Empty Implements IDockPanelItem.ShowRibbonOnFocus
  Public ReadOnly Property ItemHasToolBar As Boolean = False Implements IDockPanelItem.ItemHasToolBar
  Public Property ItemDockPanelLocation As DockPanelLocation Implements IDockPanelItem.ItemDockPanelLocation
  Public Property ItemHasFocus As Boolean = False Implements IDockPanelItem.ItemHasFocus

#End Region

#Region "Viewer - Public Methods"

  ' ==========================
  ' = Public Methods
  ' ==========================
  Public Sub NavigateTo(target As UriTrackingGroupEnum, Optional customParam As String = "")
    Dim rtn As String = AncestryBaseURL
    Select Case target
      Case UriTrackingGroupEnum.CUSTOM
        rtn = customParam
      Case UriTrackingGroupEnum.ANCESTRY
      Case UriTrackingGroupEnum.ANCESTRY_OVERVIEW_TREE
        rtn += "family-tree/tree/{TREEID}/recent"
      Case UriTrackingGroupEnum.ANCESTRY_TREEVIEW_FAMILY
        rtn += "family-tree/tree/{TREEID}/family/pedigree?cfpid=0"
      Case UriTrackingGroupEnum.ANCESTRY_TREEVIEW_PERSON
        rtn += "family-tree/tree/{TREEID}/family/familyview{CFID}"
      Case UriTrackingGroupEnum.ANCESTRY_PEDIGREEVIEW_PERSON
        rtn += "family-tree/tree/{TREEID}/family/pedigree{CFID}"
      Case UriTrackingGroupEnum.ANCESTRY_FANVIEW_PERSON
        rtn += "family-tree/tree/{TREEID}/family/fanview{CFID}"
      Case UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON
        rtn += "family-tree/person/tree/{TREEID}/person/{PERSONID}/facts"
      Case UriTrackingGroupEnum.ANCESTRY_STORY_PERSON
        rtn += "family-tree/person/tree/{TREEID}/person/{PERSONID}/story"
      Case UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON
        rtn += "family-tree/person/tree/{TREEID}/person/{PERSONID}/gallery?galleryPage=1&tab=0"
      Case UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON
        rtn += "family-tree/person/tree/{TREEID}/person/{PERSONID}/hints"
      Case Else
    End Select
    ' Replace Variables with ID's
    rtn = rtn.Replace("{TREEID}", AncestryTreeID)
    rtn = rtn.Replace("{CFID}", "?cfpid={PERSONID}")
    If target <> UriTrackingGroupEnum.CUSTOM And customParam.Length > 0 Then
      'TODO activeAncestor.Reset()
      rtn = rtn.Replace("{PERSONID}", customParam)
    Else
      rtn = rtn.Replace("{PERSONID}", AncestorID)
    End If
    ' Perform Navigation
    HREF = rtn
  End Sub

#End Region

#Region "JavaScript API"

  ' ==========================
  ' = JSAPI Related Functions
  ' ==========================

  'Private Function JSAPI_Capture(captureType As AncestryCaptureType)
  '  Select Case captureType
  '    Case AncestryCaptureType.ANCESTOR
  '      If AncestryPage.Equals("Facts") Then
  '        JSAPI_Execute("window.AncestryAssistant.captureFacts();")
  '        Return True
  '      End If
  '    Case AncestryCaptureType.CENSUS
  '      If AncestryPage.Equals("Census") Then
  '        JSAPI_Execute("window.AncestryAssistant.captureCensus();")
  '        Return True
  '      End If
  '    Case AncestryCaptureType.CENSUS_IMAGE
  '      If AncestryPage.Equals("Census") Then
  '        JSAPI_Execute("window.AncestryAssistant.downloadImage();")
  '        Return True
  '      End If
  '    Case AncestryCaptureType.GALLERY_IMAGE
  '    Case AncestryCaptureType.IMAGE
  '      Dim src As String = web.Source.AbsoluteUri
  '      If src.EndsWith("jpg") Or src.EndsWith("jpeg") Then
  '        Dim fromPage As String = ""
  '        Dim fname As String = My.Computer.FileSystem.GetTempFileName & ".jpg"
  '        If src.Contains("findagrave") Then
  '          fromPage = "FindAGrave"
  '        End If
  '        My.Computer.Network.DownloadFile(src, fname)
  '        'TODO RaiseEvent ImageDownload(fromPage, fname)
  '      End If
  '  End Select
  '  Return False
  'End Function

  Private Async Sub JSAPI_Execute(script As String)
    Await web.CoreWebView2.ExecuteScriptAsync(script)
  End Sub

  Private Sub JSAPI_Message(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs) Handles web.WebMessageReceived
    Dim msg As APIMessage = JsonConvert.DeserializeObject(Of APIMessage)(e.WebMessageAsJson)

#If MSG_LOG Then
    Logger.log(Logger.LOG_TYPE.DEBUG, msg.ToString)
#End If

    If msg.MessageType.Equals("person") And msg.MessageKey.Length > 4 Then
      AncestorID = msg.MessageKey
    End If

    If msg.MessageType.Equals("page") Then
      sameImageAsFilename = ""
      Dim tracks As String = msg.GetValue("PAGEKEY")
      Dim utg As UriTrackingGroupEnum = UriTrackingGroupDecoder.getEnum(tracks.Split(":"))
      Logger.log(Logger.LOG_TYPE.INFO, "-----------------------------")
      Logger.log(Logger.LOG_TYPE.INFO, "-- URITrackingGroup        --")
      Logger.log(Logger.LOG_TYPE.INFO, "-----------------------------")
      Logger.log(Logger.LOG_TYPE.INFO, "-- tracks        = " & tracks)
      Logger.log(Logger.LOG_TYPE.INFO, "-- TrackingGroup = " & utg.ToString)
      UriTrackingGroup = utg
      ' Ancestry Image and Media Viewer Data Capture
      If utg = UriTrackingGroupEnum.ANCESTRY_VIEWER_IMAGE Or utg = UriTrackingGroupEnum.ANCESTRY_VIEWER_MEDIA Then
        JSAPI_Execute("ancestryAssistant.getTableData(" + AncestorID + ");")
        Exit Sub
      End If
      ' Ancestry Person information data capture
      If utg = UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON Or utg = UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON Or utg = UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON Or utg = UriTrackingGroupEnum.ANCESTRY_STORY_PERSON Then
        JSAPI_Execute("ancestryAssistant.getPerson();")
        Exit Sub
      End If
      If utg = UriTrackingGroupEnum.FINDAGRAVE_MEMORIAL Then
        JSAPI_Execute("ancestryAssistant.getFindAGrave();")
        Exit Sub
      End If

    End If
    msg.PageKey = UriTrackingGroup.ToString
    RaiseEvent DataDownload(msg)
  End Sub

  Public Sub saveImageAs(filename As String)
    Dim src As String = web.Source.AbsoluteUri
    If src.EndsWith("jpg") Or src.EndsWith("jpeg") Then
      My.Computer.Network.DownloadFile(src, filename)
    Else
      sameImageAsFilename = filename
      JSAPI_Execute("ancestryAssistant.getImage();")
    End If
  End Sub

#End Region

#Region "Viewer - Browser Event Handlers"

  ' ==========================
  ' = Web Event Handlers
  ' ==========================

  Private Sub web_CoreWebView2InitializationCompleted(sender As Object, e As CoreWebView2InitializationCompletedEventArgs) Handles web.CoreWebView2InitializationCompleted
    CoreWeb = web.CoreWebView2
#If SHOW_DEBUG Then
    Debug.Print("JWebView2_CoreWebView2InitializationCompleted")
#End If
    With CoreWeb
      With .Settings
        .AreHostObjectsAllowed = True
        .IsPasswordAutosaveEnabled = True
        .IsWebMessageEnabled = True
        .IsGeneralAutofillEnabled = True
        .IsScriptEnabled = True
        .IsZoomControlEnabled = False
        .AreBrowserAcceleratorKeysEnabled = False
#If SHOW_DEBUG Then
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
    If URL IsNot Nothing Then
      If URL.OriginalString.Length > 0 Then
        web.Source = URL
      End If
    End If
  End Sub

  Private Sub web_SourceChanged(sender As Object, e As CoreWebView2SourceChangedEventArgs) Handles web.SourceChanged
    Debug.Print("web_SourceChanged")
    JSAPI_Execute("ancestryAssistant.getPage();")
    txtHref.Text = web.Source.AbsoluteUri
  End Sub

  Private Sub web_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles web.NavigationStarting
    RaiseEvent ViewerBusy(True)
  End Sub

  Private Sub web_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles web.NavigationCompleted
    Debug.Print("web_NavigationCompleted")
    RaiseEvent ViewerBusy(False)
  End Sub

  ' ==========================
  ' = CoreWeb Event Handlers
  ' ==========================

  Private Sub CoreWeb_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles CoreWeb.NavigationStarting
    If BlockWebTracking Then
      For Each partialDomain As String In BlockedWebDomains
        If e.Uri.ToLower.Contains(partialDomain.ToLower) Then
          e.Cancel = True
          Exit Sub
        End If
      Next
    End If
  End Sub

  ' If enabled, me routine will cancel every request to various tracking sites
  Private Sub CoreWeb_FrameNavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles CoreWeb.FrameNavigationStarting
    If BlockWebTracking Then
      For Each partialDomain As String In BlockedWebDomains
        If e.Uri.ToLower.Contains(partialDomain.ToLower) Then
          'Debug.Print("BLOCKED:  " + e.Uri)
          e.Cancel = True
          Exit Sub
        End If
      Next
    End If
  End Sub

  Private Sub CoreWeb_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles CoreWeb.NavigationCompleted
    _URL = web.Source
  End Sub

  ' If the result of the current navigation attempts to open a new window
  ' me routine will fire, mark the navigation event as handled,
  ' then passes the url back to the original browser window
  Private Sub CoreWeb_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs) Handles CoreWeb.NewWindowRequested
    e.Handled = True
    HREF = e.Uri
  End Sub


  Private Sub CoreWebDownload_StateChanged(sender As Object, e As Object) Handles CoreWebDownload.StateChanged
    If CoreWebDownload.State = CoreWebView2DownloadState.Completed And CoreWeb.IsDefaultDownloadDialogOpen Then
      CoreWeb.CloseDefaultDownloadDialog()
      JSAPI_Execute("document.body.click();")
      If sameImageAsFilename.Length = 0 Then
        Dim msg As APIMessage = New APIMessage()
        msg.MessageType = APIMessage.MT_SAVEAS
        msg.MessageKey = AncestorID
        Dim payload As New List(Of List(Of String))
        Dim row As New List(Of String)
        row.Add("fileName")
        payload.Add(row)
        row = New List(Of String)
        row.Add(CoreWebDownload.ResultFilePath())
        payload.Add(row)
        msg.Payload = payload
        RaiseEvent DataDownload(msg)
      Else
        If System.IO.File.Exists(sameImageAsFilename) Then
          System.IO.File.Delete(sameImageAsFilename)
        End If
        System.IO.File.Move(CoreWebDownload.ResultFilePath(), sameImageAsFilename)
        Dim msg As APIMessage = New APIMessage()
        msg.MessageType = APIMessage.MT_IMGDOWNLOAD
        msg.MessageKey = AncestorID
        Dim payload As New List(Of List(Of String))
        Dim row As New List(Of String)
        row.Add("fileName")
        payload.Add(row)
        row = New List(Of String)
        row.Add(sameImageAsFilename)
        payload.Add(row)
        msg.Payload = payload
        RaiseEvent DataDownload(msg)
        sameImageAsFilename = ""
      End If
    End If
  End Sub

  ' When the browser detects a file is being downloaded
  ' me routine will fire, we Capture the DownloadOperation object and monitor its events
  ' for completion of the download, then fire an event about the download
  Private Sub CoreWeb_DownloadStarting(sender As Object, e As CoreWebView2DownloadStartingEventArgs) Handles CoreWeb.DownloadStarting
    CoreWebDownload = e.DownloadOperation
  End Sub

#End Region

#Region "Viewer - Menu "

  ' ==========================
  ' = Menubar Event Handlers
  ' ==========================

  Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
    web.GoBack()
  End Sub

  Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
    web.Reload()
  End Sub

  Private Sub btnHome_Click_1(sender As Object, e As EventArgs) Handles btnHome.Click
    NavigateTo(UriTrackingGroupEnum.ANCESTRY_HOME)
  End Sub

  Private Sub tsWeb_Resize(sender As Object, e As EventArgs) Handles tsWeb.Resize
    txtHref.Width = tsWeb.Bounds.Width - btnHome.Bounds.Right - 46
  End Sub

  Private Sub txtHref_Enter(sender As Object, e As EventArgs) Handles txtHref.Enter
    NavigateTo(UriTrackingGroupEnum.CUSTOM, txtHref.Text)
  End Sub

  Public Function GetRibbonBarConfig() As RibbonBarTabConfig Implements IDockPanelItem.GetRibbonBarConfig
    Throw New NotImplementedException()
  End Function

  Public Function GetDockToolBarConfig() As DockToolBarConfig Implements IDockPanelItem.GetDockToolBarConfig
    Throw New NotImplementedException()
  End Function

  Public Sub SetAncestor(activeAncestor As AncestorCollection.Ancestor) Implements IDockPanelItem.SetAncestor
    Throw New NotImplementedException()
  End Sub

  Public Sub RefreshAncestor() Implements IDockPanelItem.RefreshAncestor
    Throw New NotImplementedException()
  End Sub

  Public Sub ApplySearch(criteria As String) Implements IDockPanelItem.ApplySearch
    Throw New NotImplementedException()
  End Sub

  Public Sub ClearSearch() Implements IDockPanelItem.ClearSearch
    Throw New NotImplementedException()
  End Sub

#End Region

#Region "Component Helper"
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
  Private components As System.ComponentModel.IContainer
#End Region

End Class