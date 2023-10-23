Imports System.ComponentModel
Imports Microsoft.Web.WebView2.Core
Imports Newtonsoft.Json

Public Class AncestryWebViewer
  ' Web Interface
  Private WithEvents CoreWeb As CoreWebView2
  Private WithEvents CoreWebDownload As CoreWebView2DownloadOperation

  ' Tracking
  Private isReady As Boolean = False

  ' Public Events
  Public Event DataDownload(dataType As DataTypeEnum, data As AncestryDataMessage)
  Public Event AncestorChanged(AncestorID As String)
  Public Event ViewerBusy(busy As Boolean)
  Public Event DownloadEnabled(enabled As Boolean)

  Public Sub New()
    InitializeComponent()
    web.EnsureCoreWebView2Async()
  End Sub

  Public Property BlockWebTracking As Boolean = False

  Public Property BlockedWebDomains As String() = {"facebook", "doubleclick", "tiktok", "pinterest", "adservice"}

  Public Property AncestryBaseURL As String = "https://www.ancestry.com/"

  Public Property AncestryTreeID As String = "65171586"

  Public Property BrowserStatus As String = ""

  Private _ShowDownload As Boolean = False
  Public Property ShowDownload As Boolean
    Get
      Return _ShowDownload
    End Get
    Set(value As Boolean)
      _ShowDownload = value
      btnDownload.Enabled = value
      RaiseEvent DownloadEnabled(value)
    End Set
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

  ' ==========================
  ' = JSAPI Related Functions
  ' ==========================

  Private Function JSAPI_Capture(captureType As AncestryCaptureType)
    Select Case captureType
      Case AncestryCaptureType.ANCESTOR
        If AncestryPage.Equals("Facts") Then
          JSAPI_Execute("window.AncestryAssistant.captureFacts();")
          Return True
        End If
      Case AncestryCaptureType.CENSUS
        If AncestryPage.Equals("Census") Then
          JSAPI_Execute("window.AncestryAssistant.captureCensus();")
          Return True
        End If
      Case AncestryCaptureType.CENSUS_IMAGE
        If AncestryPage.Equals("Census") Then
          JSAPI_Execute("window.AncestryAssistant.downloadImage();")
          Return True
        End If
      Case AncestryCaptureType.GALLERY_IMAGE
      Case AncestryCaptureType.IMAGE
        Dim src As String = web.Source.AbsoluteUri
        If src.EndsWith("jpg") Or src.EndsWith("jpeg") Then
          Dim fromPage As String = ""
          Dim fname As String = My.Computer.FileSystem.GetTempFileName & ".jpg"
          If src.Contains("findagrave") Then
            fromPage = "FindAGrave"
          End If
          My.Computer.Network.DownloadFile(src, fname)
          'TODO RaiseEvent ImageDownload(fromPage, fname)
        End If
    End Select
    Return False
  End Function


  Private Async Sub JSAPI_Execute(script As String)
    Await web.CoreWebView2.ExecuteScriptAsync(script)
  End Sub


  Private Sub JSAPI_Message(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs) Handles web.WebMessageReceived
    Dim msg As JSMessage = JsonConvert.DeserializeObject(Of JSMessage)(e.WebMessageAsJson)
    Select Case msg.MessageType
      Case "FactData"
        Dim data As AncestryFactsParser = New AncestryFactsParser(msg.Payload)
      Case "CensusData"
        Dim data As CensusParser = New CensusParser(msg.Payload, msg.MessageKey)
        If data.CensusArray.Length > 1 Then
          Dim year As String = data.CensusArray(1)(0).ToString
          Dim page As String = data.CensusArray(1)(1).ToString
          AncestryPage = "Census-" & year & "-p" & page

          'TODO RaiseEvent DataChanged(DataTypeEnum.anCENSUSDATA, data.CensusArray)
        End If
      Case Else

    End Select
  End Sub

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
    txtHref.Text = web.Source.AbsoluteUri
  End Sub


  ' ==========================
  ' = CoreWeb Event Handlers
  ' ==========================

  Private Sub CoreWeb_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles CoreWeb.NavigationStarting
    BrowserStatus = ""
  End Sub

  ' If enabled, this routine will cancel every request to various tracking sites
  Private Sub CoreWeb_FrameNavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles CoreWeb.FrameNavigationStarting
    If BlockWebTracking Then
      For Each partialDomain As String In BlockedWebDomains
        If e.Uri.Contains(partialDomain) Then
          e.Cancel = True
          Exit Sub
        End If
      Next
    End If
  End Sub

  Private Sub CoreWeb_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles CoreWeb.NavigationCompleted
    If Visible = False Then Visible = True
    _URL = web.Source
    ShowDownload = txtHref.Text.Contains("mediaui-viewer") Or BrowserStatus.Contains("Census") Or BrowserStatus.Contains("Fact") Or txtHref.Text.EndsWith("jpg") Or txtHref.Text.EndsWith("jpeg")
  End Sub

  ' If the result of the current navigation attempts to open a new window
  ' This routine will fire, mark the navigation event as handled,
  ' then passes the url back to the original browser window
  Private Sub CoreWeb_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs) Handles CoreWeb.NewWindowRequested
    e.Handled = True
    HREF = e.Uri
  End Sub

  Private Sub CoreWeb_DocumentTitleChanged(sender As Object, e As Object) Handles CoreWeb.DocumentTitleChanged
    Dim src = CoreWeb.Source
    Dim title = CoreWeb.DocumentTitle
    Dim p() As String
    p = src.Split("/")
    If p(2).Equals("www.ancestry.com") Then
      If p.Length() >= 6 And title.Contains("View - Ancestry") Then
        If src.Contains("?cfpid=") Then
          p = src.Split("=")
          AncestorID = p(1)
        End If
        AncestryPage = title.Replace("View - Ancestry", "").Trim
        BrowserStatus = title
        Exit Sub
      End If
      If p.Length() > 4 Then
        If p(4).Equals("collections") And title.Contains("Census") Then
          AncestryPage = "Census"
          BrowserStatus = title.Replace("Ancestry.com -", "").Trim()
          Exit Sub
        End If
      End If
      If p.Length > 9 Then
        If p(3).Equals("family-tree") And p(4).Equals("person") _
      And p(5).Equals("tree") And p(6) = AncestryTreeID _
      And p(7).Equals("person") Then
          If (p(9).StartsWith("facts") And title.EndsWith("Facts")) Or src.Contains("facts") Then
            AncestorID = p(8)
            If title.EndsWith("Facts") Then
              'TODO AncestorName = title.Split("-")(0).Trim()
            End If
            AncestryPage = "Facts"
            BrowserStatus = AncestryPage
            Exit Sub
          End If
          If p(9).StartsWith("gallery") And title.EndsWith("Gallery") Then
            AncestorID = p(8)
            'TODO AncestorName = title.Split("-")(0).Trim()
            AncestryPage = "Gallery"
            BrowserStatus = AncestryPage
            Exit Sub
          End If
          If p(9).StartsWith("hints") And title.EndsWith("Hints") Then
            AncestorID = p(8)
            'TODO AncestorName = title.Split("-")(0).Trim()
            AncestryPage = "Hints"
            BrowserStatus = AncestryPage
            Exit Sub
          End If
          If p(9).StartsWith("story") And title.EndsWith("LifeStory") Then
            AncestorID = p(8)
            'TODO AncestorName = title.Split("-")(0).Trim()
            AncestryPage = "LifeStory"
            BrowserStatus = AncestryPage
            Exit Sub
          End If
        End If
      End If
    End If
    BrowserStatus = title & " - " & src
  End Sub

  Private Sub CoreWebDownload_StateChanged(sender As Object, e As Object) Handles CoreWebDownload.StateChanged
    If CoreWebDownload.State = CoreWebView2DownloadState.Completed And CoreWeb.IsDefaultDownloadDialogOpen Then
      CoreWeb.CloseDefaultDownloadDialog()
      JSAPI_Execute("document.body.click();")
      'TODO RaiseEvent ImageDownload(AncestryPage, CoreWebDownload.ResultFilePath())
    End If
  End Sub

  ' When the browser detects a file is being downloaded
  ' this routine will fire, we Capture the DownloadOperation object and monitor its events
  ' for completion of the download, then fire an event about the download
  Private Sub CoreWeb_DownloadStarting(sender As Object, e As CoreWebView2DownloadStartingEventArgs) Handles CoreWeb.DownloadStarting
    CoreWebDownload = e.DownloadOperation
  End Sub


  ' ==========================
  ' = Public Methods
  ' ==========================
  Public Sub NavigateTo(target As URLTypeEnum, Optional customParam As String = "")
    Dim rtn As String = AncestryBaseURL
    Select Case target
      Case URLTypeEnum.CUSTOM
        rtn = customParam
      Case URLTypeEnum.HOME
      Case URLTypeEnum.TREE_HOME
        rtn += "family-tree/tree/{TREEID}/family/pedigree?cfpid=0"
      Case URLTypeEnum.TREE_VERTICAL
        rtn += "family-tree/tree/{TREEID}/family/familyview{CFID}"
      Case URLTypeEnum.TREE_HORIZONTAL
        rtn += "family-tree/tree/{TREEID}/family/pedigree{CFID}"
      Case URLTypeEnum.TREE_FAN
        rtn += "family-tree/tree/{TREEID}/family/fanview{CFID}"
      Case URLTypeEnum.PERSON_FACTS
        rtn += "family-tree/person/tree/{TREEID}/person/{PERSONID}/facts"
      Case URLTypeEnum.PERSON_STORY
        rtn += "family-tree/person/tree/{TREEID}/person/{PERSONID}/story"
      Case URLTypeEnum.PERSON_GALLERY
        rtn += "family-tree/person/tree/{TREEID}/person/{PERSONID}/gallery?galleryPage=1&tab=0"
      Case URLTypeEnum.PERSON_HINTS
        rtn += "family-tree/person/tree/{TREEID}/person/{PERSONID}/hints"
      Case Else
    End Select
    ' Replace Variables with ID's
    rtn = rtn.Replace("{TREEID}", AncestryTreeID)
    rtn = rtn.Replace("{CFID}", "?cfpid={PERSONID}")
    If target <> URLTypeEnum.CUSTOM And customParam.Length > 0 Then
      'TODO activeAncestor.Reset()
      rtn = rtn.Replace("{PERSONID}", customParam)
    Else
      rtn = rtn.Replace("{PERSONID}", AncestorID)
    End If
    ' Perform Navigation
    HREF = rtn
  End Sub

  ' ==========================
  ' = Menubar Event Handlers
  ' ==========================
  Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
    If BrowserStatus.Contains("Fact") Then
      JSAPI_Capture(AncestryCaptureType.ANCESTOR)
    End If
    If BrowserStatus.Contains("Census") Then
      JSAPI_Capture(AncestryCaptureType.CENSUS)
      JSAPI_Capture(AncestryCaptureType.CENSUS_IMAGE)
    End If
    If txtHref.Text.EndsWith("jpg") Or txtHref.Text.EndsWith("jpeg") Then
      JSAPI_Capture(AncestryCaptureType.IMAGE)
    End If
    If txtHref.Text.Contains("mediaui-viewer") Then
      JSAPI_Capture(AncestryCaptureType.GALLERY_IMAGE)
    End If
  End Sub

  Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
    web.GoBack()
  End Sub

  Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
    web.Reload()
  End Sub

  Private Sub btnHome_Click_1(sender As Object, e As EventArgs) Handles btnHome.Click
    NavigateTo(URLTypeEnum.HOME)
  End Sub

  Private Sub tsWeb_Resize(sender As Object, e As EventArgs) Handles tsWeb.Resize
    txtHref.Width = tsWeb.Bounds.Width - btnHome.Bounds.Right - 46
  End Sub

  Private Sub txtHref_Enter(sender As Object, e As EventArgs) Handles txtHref.Enter
    NavigateTo(URLTypeEnum.CUSTOM, txtHref.Text)
  End Sub

  Private Sub web_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles web.NavigationStarting
    RaiseEvent ViewerBusy(True)
  End Sub

  Private Sub web_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles web.NavigationCompleted
    RaiseEvent ViewerBusy(False)
  End Sub

End Class
