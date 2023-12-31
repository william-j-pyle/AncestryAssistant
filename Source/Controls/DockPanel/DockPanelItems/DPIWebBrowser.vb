﻿Imports System.ComponentModel
Imports Microsoft.Web
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms
Imports Newtonsoft.Json

Public Class DPIWebBrowser
  Inherits DockPanelItem

  Private WithEvents CoreWeb As CoreWebView2
  Private WithEvents CoreWebDownload As CoreWebView2DownloadOperation
  Private WithEvents Web As WebView2
  Private Const AncestryBaseURL As String = "https://www.ancestry.com/"
  Private _AncestorID As String = ""
  Private _MsgSyncKey As Integer = 0
  Private _UriTrackingGroup As UriTrackingGroupEnum = UriTrackingGroupEnum.ANCESTRY
  Private _URL As New Uri(AncestryBaseURL)
  Private components As System.ComponentModel.IContainer
  ' Tracking
  Private isReady As Boolean = False
  Private sameImageAsFilename As String = ""
  Private UriTrackingGroupDecoder As New UriTracking()
  Public Const Base_Key As String = "DOCK_WEBBROWSER"
  Public Property AncestorID As String
    Get
      Return _AncestorID
    End Get
    Set(value As String)
      If Not value.Equals(_AncestorID) Then
        _AncestorID = value
      End If
    End Set
  End Property
  Public Property AncestryPage As String = ""
  Public Property AncestryTreeID As String = ""
  Public Property BlockedWebDomains As String() = {"adsafe", "syndication", "facebook", "doubleclick", "tiktok", "pinterest", "adservice", "ad-delivery", "adspsp", "adsystem", "adnxs", "securepubads"}
  Public Property BlockWebTracking As Boolean = False

  Public Property HREF As String
    Get
      Return URL.AbsoluteUri
    End Get
    Set(value As String)
      URL = New Uri(value)
    End Set
  End Property

  Public ReadOnly Property MessageSyncKey As Integer
    Get
      _MsgSyncKey += 1
      If _MsgSyncKey > 999 Then _MsgSyncKey = 1
      Return _MsgSyncKey
    End Get
  End Property

  Public Property UriTrackingGroup As UriTrackingGroupEnum
    Get
      Return _UriTrackingGroup
    End Get
    Set(value As UriTrackingGroupEnum)
      If value <> _UriTrackingGroup Then
#If TRACE Then
        Logger.log(Logger.LOG_TYPE.INFO, "UriTrackingGroup Changed {New:" & value.ToString & ", Old:" & _UriTrackingGroup.ToString & "}")
#End If
        Dim oldValue As UriTrackingGroupEnum = _UriTrackingGroup
        _UriTrackingGroup = value
        InvokePanelItemEvent(DockPanelItemEventType.NavTrackingChanged, value)
        'RaiseEvent UriTrackingGroupChanged(value, oldValue)
      End If
    End Set
  End Property

  <Browsable(False)>
  Public Property URL As Uri
    Get
      Return _URL
    End Get
    Set(value As Uri)
      _URL = value
      If isReady And value IsNot Nothing Then
        If value.OriginalString.Length > 0 Then
          Web.Source = value
        End If
      End If
    End Set
  End Property

  'Public Event DataDownload(data As APIMessage)

  'Public Event UriTrackingGroupChanged(NewGroup As UriTrackingGroupEnum, OldGroup As UriTrackingGroupEnum)

  'Public Event ViewerBusy(busy As Boolean)

  Public Sub New(Optional instanceKey As String = "")
    ItemCaption = "Ancestry.com"
    ItemDestroyOnClose = False
    ItemHasRibbonBar = True
    ItemHasStatusBar = False
    ItemHasToolBar = True
    ItemSupportsClose = True
    ItemSupportsMove = True
    ItemSupportsSearch = False
    LocationCurrent = DockPanelLocation.None
    LocationPrefered = DockPanelLocation.MiddleTopLeft
    LocationPrevious = DockPanelLocation.MiddleTopLeft
    RibbonBarKey = "B200"
    RibbonHideOnItemClose = False
    RibbonSelectOnItemFocus = True
    RibbonShowOnItemOpen = True
    ItemKey = Base_Key
    ItemInstanceKey = instanceKey
    Web = New Microsoft.Web.WebView2.WinForms.WebView2()
    CType(Web, System.ComponentModel.ISupportInitialize).BeginInit()
    SuspendLayout()
    Web.AllowExternalDrop = True
    Web.BackColor = My.Theme.PanelBackColor
    Web.CreationProperties = Nothing
    Web.DefaultBackgroundColor = My.Theme.PanelBackColor
    Web.Dock = System.Windows.Forms.DockStyle.Fill
    Web.Location = New System.Drawing.Point(0, 25)
    Web.Margin = New System.Windows.Forms.Padding(0)
    Web.Name = "web"
    Web.Size = New System.Drawing.Size(600, 202)
    Web.TabIndex = 0
    Web.ZoomFactor = 0.75R
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Controls.Add(Web)
    Dock = DockStyle.Fill
    Name = "AncestryWebViewer"
    Size = New System.Drawing.Size(600, 227)
    CType(Web, System.ComponentModel.ISupportInitialize).EndInit()
    ResumeLayout(False)
    PerformLayout()
    Web.EnsureCoreWebView2Async()
    CaptureFocus(Me)
  End Sub

  ' When the browser detects a file is being downloaded me routine will fire, we Capture the DownloadOperation object
  ' and monitor its events for completion of the download, then fire an event about the download
  Private Sub CoreWeb_DownloadStarting(sender As Object, e As CoreWebView2DownloadStartingEventArgs) Handles CoreWeb.DownloadStarting
    CoreWebDownload = e.DownloadOperation
  End Sub

  ' If enabled, me routine will cancel every request to various tracking sites
  Private Sub CoreWeb_FrameNavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles CoreWeb.FrameNavigationStarting
    If BlockWebTracking Then
      If ShouldBlockNavigation(e.Uri) Then
        e.Cancel = True
      End If
    End If
  End Sub

  Private Sub CoreWeb_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles CoreWeb.NavigationCompleted
    _URL = Web.Source
  End Sub

  Private Sub CoreWeb_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles CoreWeb.NavigationStarting
    If BlockWebTracking Then
      If ShouldBlockNavigation(e.Uri) Then
        e.Cancel = True
      End If
    End If
  End Sub

  ' If the result of the current navigation attempts to open a new window me routine will fire, mark the navigation
  ' event as handled, then passes the url back to the original browser window
  Private Sub CoreWeb_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs) Handles CoreWeb.NewWindowRequested
    e.Handled = True
    HREF = e.Uri
  End Sub

  Private Sub CoreWebDownload_StateChanged(sender As Object, e As Object) Handles CoreWebDownload.StateChanged
    If CoreWebDownload.State = CoreWebView2DownloadState.Completed And CoreWeb.IsDefaultDownloadDialogOpen Then
      CoreWeb.CloseDefaultDownloadDialog()
      JSAPI_Execute("document.body.click();")
      If sameImageAsFilename.Length = 0 Then
        Dim msg As New APIMessage With {
          .MessageType = APIMessage.MT_SAVEAS,
          .MessageKey = AncestorID
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
        InvokePanelItemEvent(DockPanelItemEventType.NavData, msg)
      Else
        If System.IO.File.Exists(sameImageAsFilename) Then
          System.IO.File.Delete(sameImageAsFilename)
        End If
        System.IO.File.Move(CoreWebDownload.ResultFilePath(), sameImageAsFilename)
        Dim msg As New APIMessage With {
          .MessageType = APIMessage.MT_IMGDOWNLOAD,
          .MessageKey = AncestorID
        }
        Dim payload As New List(Of List(Of String))
        Dim row As New List(Of String) From {
          "fileName"
        }
        payload.Add(row)
        row = New List(Of String) From {
          sameImageAsFilename
        }
        payload.Add(row)
        msg.Payload = payload
        InvokePanelItemEvent(DockPanelItemEventType.NavData, msg)
        'RaiseEvent DataDownload(msg)
        sameImageAsFilename = ""
      End If
    End If
  End Sub

  Private Async Sub JSAPI_Execute(script As String)
#If TRACE Then
    Logger.debugPrint("WebBrowserPanelItem.JSAPI_Execute(script=[{0}])", script)
#End If

    Await Web.CoreWebView2.ExecuteScriptAsync(script)
  End Sub

  Private Sub JSAPI_Message(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs) Handles Web.WebMessageReceived
    Dim msg As APIMessage = JsonConvert.DeserializeObject(Of APIMessage)(e.WebMessageAsJson)

#If TRACE Then
    Logger.log(Logger.LOG_TYPE.DEBUG, msg.ToString)
#End If

    If msg.MessageType.Equals("person") And msg.MessageKey.Length > 4 Then
      AncestorID = msg.MessageKey
    End If

    If msg.MessageType.Equals("page") Then
      sameImageAsFilename = ""
      Dim tracks As String = msg.GetValue("PAGEKEY")
      Dim utg As UriTrackingGroupEnum = UriTrackingGroupDecoder.GetEnum(tracks.Split(":"c))
#If TRACE Then
      Logger.log(Logger.LOG_TYPE.INFO, "-----------------------------")
      Logger.log(Logger.LOG_TYPE.INFO, "-- URITrackingGroup        --")
      Logger.log(Logger.LOG_TYPE.INFO, "-----------------------------")
      Logger.log(Logger.LOG_TYPE.INFO, "-- tracks        = " & tracks)
      Logger.log(Logger.LOG_TYPE.INFO, "-- TrackingGroup = " & utg.ToString)
#End If
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
    InvokePanelItemEvent(DockPanelItemEventType.NavData, msg)
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
#If TRACE Then
    Logger.debugPrint("WebBrowserPanelItem.web_CoreWebView2InitializationCompleted()")
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
#If TRACE Then
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
      .AddScriptToExecuteOnDocumentCreatedAsync(My.Resources.WEBAPI)
    End With
    isReady = True
    If URL IsNot Nothing Then
      If URL.OriginalString.Length > 0 Then
        Web.Source = URL
      End If
    End If
  End Sub

  Private Sub Web_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles Web.NavigationCompleted
#If TRACE Then
    Logger.debugPrint("WebBrowserPanelItem.web_NavigationCompleted()")
#End If
    InvokePanelItemEvent(DockPanelItemEventType.ItemBusy, False)
  End Sub

  Private Sub Web_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles Web.NavigationStarting
#If TRACE Then
    Logger.debugPrint("WebBrowserPanelItem.web_NavigationStarting()")
#End If
    InvokePanelItemEvent(DockPanelItemEventType.ItemBusy, True)
  End Sub

  Private Sub Web_SourceChanged(sender As Object, e As CoreWebView2SourceChangedEventArgs) Handles Web.SourceChanged
#If TRACE Then
    Logger.debugPrint("WebBrowserPanelItem.web_SourceChanged(uri=[{0}])", Web.Source.AbsoluteUri)
#End If
    JSAPI_Execute("ancestryAssistant.getPage();")
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

  Protected Overrides Sub UpdateUI(Optional reload As Boolean = True)
    'Throw New NotImplementedException()
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
        NavigateTo(CType(eventData, UriTrackingGroupEnum))
    End Select
  End Sub

  Public Sub NavigateTo(target As UriTrackingGroupEnum, Optional customParam As String = "")
#If TRACE Then
    Logger.debugPrint("WebBrowserPanelItem.NavigateTo(target=[{0}], customParam=[{1}])", target.ToString, customParam)
#End If
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
      rtn = rtn.Replace("{PERSONID}", Ancestors.ActiveAncestorID)
    End If
    ' Perform Navigation
    HREF = rtn
  End Sub

  Public Sub saveImageAs(filename As String)
#If TRACE Then
    Logger.debugPrint("WebBrowserPanelItem.saveImageAs(filename=[{0}])", filename)
#End If
    Dim src As String = Web.Source.AbsoluteUri
    If src.EndsWith("jpg") Or src.EndsWith("jpeg") Then
      My.Computer.Network.DownloadFile(src, filename)
    Else
      sameImageAsFilename = filename
      JSAPI_Execute("ancestryAssistant.getImage();")
    End If
  End Sub

  Public Class UriTracking

    Private UriTrackerConfig As List(Of UriTracks)

    Public Sub New()
      UriTrackerConfig = New List(Of UriTracks) From {
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON, {"ancestryus", "facts"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON, {"ancestryus", "gallery"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON, {"ancestryus", "hints"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_STORY_PERSON, {"ancestryus", "lifestory"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_GROUPVIEW_FAMILY, {"ancestryus", "tree", "familygroup"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_TREEVIEW_PERSON, {"ancestryus", "tree", "familyview"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_FANVIEW_PERSON, {"ancestryus", "tree", "fanview"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_PEDIGREEVIEW_PERSON, {"ancestryus", "tree", "pedigree"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_TREEVIEW_FAMILY, {"ancestryus", "tree", "family"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_GALLERY_TREE, {"ancestryus", "tree", "media"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_OVERVIEW_TREE, {"ancestryus", "tree", "recent"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_SETTINGS_TREE, {"ancestryus", "tree", "settings"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_HOME, {"ancestryus", "homepage", "loggedin"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_HOME_LOGGEDOUT, {"ancestryus", "homepage", "loggedout"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_HINTS_TREE, {"ancestryus", "allhints"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_MESSAGES, {"ancestryus", "messagecenter"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_DNA, {"ancestryus", "dna"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_VIEWER_IMAGE, {"ancestryus", "imageviewer-ui"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_VIEWER_MEDIA, {"ancestryus", "mediaui-viewer"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_SEARCH, {"ancestryus", "search"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY_LOGIN, {"ancestryus", "login"}),
        New UriTracks(UriTrackingGroupEnum.ANCESTRY, {"ancestryus"}),
        New UriTracks(UriTrackingGroupEnum.NEWSPAPERS, {" newspapers", "com"}),
        New UriTracks(UriTrackingGroupEnum.FINDAGRAVE_MEMORIAL, {"findagrave", "com", "memorial"}),
        New UriTracks(UriTrackingGroupEnum.FINDAGRAVE_VIEWER_IMAGE, {"images", "findagrave", "com", "photos"}),
        New UriTracks(UriTrackingGroupEnum.FINDAGRAVE, {"findagrave", "com"})
      }
    End Sub

    Public Function GetEnum(pageData() As String) As UriTrackingGroupEnum
      For Each track As UriTracks In UriTrackerConfig
        If track.Matches(pageData) Then
          Return track.UriTrackingGroup
        End If
      Next
      Return UriTrackingGroupEnum.CUSTOM
    End Function

    Public Class UriTracks

      Public ReadOnly Property PageDataElements As String()

      Public ReadOnly Property UriTrackingGroup As UriTrackingGroupEnum

      Public Sub New(trackingGroup As UriTrackingGroupEnum, pageData() As String)
        UriTrackingGroup = trackingGroup

        PageDataElements = pageData
      End Sub

      Public Function Matches(pPageData() As String) As Boolean
        Dim uPageData() As String = PageDataElements
        If pPageData.Length < uPageData.Length Then Return False
        Dim pIdx As Integer = 0
        For uIdx As Integer = 0 To uPageData.Length - 1
          While Not uPageData(uIdx).ToLower.Equals(pPageData(pIdx).ToLower)
            pIdx += 1
            If pIdx > pPageData.Length - 1 Then Return False
          End While
        Next
        Return True
      End Function

    End Class

  End Class

End Class