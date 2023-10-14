Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms
Imports Newtonsoft.Json


#Const SHOW_DEBUG = False

Public Class WebHandler
  Public Const ANCESTRY_URL = "https://www.ancestry.com/"
  Public Const ANCESTRY_TREE_ID = "65171586"
  Private WithEvents web As WebView2
  Private WithEvents CoreWeb As CoreWebView2
  Private WithEvents CoreWebDownload As CoreWebView2DownloadOperation

  Private activeAncestor As Ancestor = New Ancestor()

  Public Event ImageDownload(fromPage As String, filename As String)
  Public Event StatusChanged(text As String)
  Public Event PageChanged(wasPage As String, toPage As String)
  Public Event DataChanged(dataType As DataTypeEnum, data As Object)
  Public Event AncestorChanged(activeAncestor As Ancestor)
  Public Event SourceChanged(sourceString As String)

  Public Sub New(webCtl As WebView2)
    web = webCtl
    web.EnsureCoreWebView2Async()
    AddHandler web.WebMessageReceived, AddressOf handlerWebMessageReceived
  End Sub

  Public Property AncestorID As String
    Get
      Return activeAncestor.ID
    End Get
    Set(value As String)
      If Not value.Equals(activeAncestor.ID) Then
        activeAncestor.ID = value
        If activeAncestor.IsValid Then
          RaiseEvent AncestorChanged(activeAncestor)
        End If
      End If
    End Set
  End Property

  Public Property AncestorName As String
    Get
      Return activeAncestor.Name
    End Get
    Set(value As String)
      If Not value.Equals(activeAncestor.Name) Then
        activeAncestor.Name = value
        If activeAncestor.IsValid Then
          RaiseEvent AncestorChanged(activeAncestor)
        End If
      End If
    End Set
  End Property

  Public Property AncestorBirthYear As String
    Get
      Return activeAncestor.BirthYear
    End Get
    Set(value As String)
      If Not value.Equals(activeAncestor.BirthYear) Then
        activeAncestor.BirthYear = value
        If activeAncestor.IsValid Then
          RaiseEvent AncestorChanged(activeAncestor)
        End If
      End If
    End Set
  End Property

  Public Property AncestorDeathYear As String
    Get
      Return activeAncestor.DeathYear
    End Get
    Set(value As String)
      If Not value.Equals(activeAncestor.DeathYear) Then
        activeAncestor.DeathYear = value
        If activeAncestor.IsValid Then
          RaiseEvent AncestorChanged(activeAncestor)
        End If
      End If
    End Set
  End Property


  Private _AncestryPage As String = ""
  Public Property AncestryPage As String
    Get
      Return _AncestryPage
    End Get
    Set(value As String)
      Dim wasPage As String = _AncestryPage
      _AncestryPage = value
      If value.Equals("Facts") Then
        executeScript("window.AncestryAssistant.captureFactsInternal();")
      End If
      RaiseEvent PageChanged(wasPage, value)
    End Set
  End Property


  Private _URL As Uri
  Public Property URL As Uri
    Get
      Return _URL
    End Get
    Set(value As Uri)
      _URL = value
      If isReady Then
        SetVirtualConfig()
        SetURL()
      End If
    End Set
  End Property

  Public Property isReady As Boolean = False

  Public Property Visible As Boolean
    Get
      Return web.Visible
    End Get
    Set(value As Boolean)
      web.Visible = value
    End Set
  End Property

  Public Property location As String
    Get
      Return URL.AbsolutePath
    End Get
    Set(value As String)
      URL = New Uri(value)
    End Set
  End Property

  Private Sub handlerWebMessageReceived(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs)
    Dim msg As JSMessage = JsonConvert.DeserializeObject(Of JSMessage)(e.WebMessageAsJson)
#If SHOW_DEBUG Then
    Debug.Print("Text Content: " & msg.MessageType & vblf & msg.Payload)
#End If
    Select Case msg.MessageType
      Case "InternalFactData"
        Dim data As AncestryFactsParser = New AncestryFactsParser(msg.Payload)
        If data.deathYear.Length = 4 Then
          AncestorDeathYear = data.deathYear
        End If
        If data.birthYear.Length = 4 Then
          AncestorBirthYear = data.birthYear
        End If
      Case "FactData"
        Dim data As AncestryFactsParser = New AncestryFactsParser(msg.Payload)
        If data.deathYear.Length = 4 Then
          AncestorDeathYear = data.deathYear
        End If
        If data.birthYear.Length = 4 Then
          AncestorBirthYear = data.birthYear
        End If
        If data.FamilyArray.Length > 1 Then
          RaiseEvent DataChanged(DataTypeEnum.anFAMILYDATA, data.FamilyArray)
        End If
        If data.SourcesArray.Length > 1 Then
          RaiseEvent DataChanged(DataTypeEnum.anSOURCEDATA, data.SourcesArray)
        End If
        If data.TimelineArray.Length > 1 Then
          RaiseEvent DataChanged(DataTypeEnum.anFACTDATA, data.TimelineArray)
          RaiseEvent DataChanged(DataTypeEnum.anPROFILEDATA, data.ProfileData)
        End If
      Case "CensusData"
        Dim data As AncestryCensusParser = New AncestryCensusParser(msg.Payload, msg.MessageKey)
        If data.CensusArray.Length > 1 Then
          Dim year As String = data.CensusArray(1)(0).ToString
          Dim page As String = data.CensusArray(1)(1).ToString
          _AncestryPage = "Census-" & year & "-p" & page
          RaiseEvent DataChanged(DataTypeEnum.anCENSUSDATA, data.CensusArray)
        End If
      Case Else

    End Select
  End Sub

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
    SetVirtualConfig()
    SetURL()
  End Sub

  Private Sub SetURL()
#If SHOW_DEBUG Then
    Debug.Print("SetURL")
#End If
    If isReady Then
      If URL IsNot Nothing Then
        If URL.OriginalString.Length > 0 Then
          web.Source = URL
        End If
      End If
    End If
  End Sub

  Private Sub SetVirtualConfig()
#If SHOW_DEBUG Then
    Debug.Print("SetVirtualConfig")
#End If
    If isReady Then
      'If HostName.Length > 0 And FSBasePath.Length > 0 And CoreWeb IsNot Nothing Then
      'CoreWebView2.SetVirtualHostNameToFolderMapping(HostName, FSBasePath, CoreWebView2HostResourceAccessKind.Allow)
      'End If
    End If
  End Sub

  Private Sub CoreWeb_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles CoreWeb.NavigationCompleted
    If Visible = False Then Visible = True
    _URL = web.Source
    'RaiseEvent StatusBarChanged("")
    'UpdateStatus()
  End Sub


  Public Function capture(captureType As AncestryCaptureType)
    Select Case captureType
      Case AncestryCaptureType.ANCESTOR
        If AncestryPage.Equals("Facts") Then
          executeScript("window.AncestryAssistant.captureFacts();")
          Return True
        End If
      Case AncestryCaptureType.CENSUS
        If AncestryPage.Equals("Census") Then
          executeScript("window.AncestryAssistant.captureCensus();")
          Return True
        End If
      Case AncestryCaptureType.CENSUS_IMAGE
        If AncestryPage.Equals("Census") Then
          executeScript("window.AncestryAssistant.downloadImage();")
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
          RaiseEvent ImageDownload(fromPage, fname)
        End If
    End Select
    Return False
  End Function


  Public Async Sub executeScript(script As String)
#If SHOW_DEBUG Then
    Debug.Print("Executeing Script: " & script)
#End If
    Await web.CoreWebView2.ExecuteScriptAsync(script)
  End Sub

  Private Sub CoreWeb_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles CoreWeb.NavigationStarting
    RaiseEvent StatusChanged("")
  End Sub


  Private Sub CoreWeb_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs) Handles CoreWeb.NewWindowRequested
#If SHOW_DEBUG Then
    Debug.Print("CoreWeb_NewWindowRequested")
#End If
    e.Handled = True
    location = e.Uri
  End Sub

  '  Private Sub CoreWeb_FrameNavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles CoreWeb.FrameNavigationStarting
  '#If SHOW_DEBUG Then
  '    Debug.Print("CoreWeb_FrameNavigationStarting: " & e.NavigationId & "-" & e.Uri)
  '#End If
  '    If e.Uri.Contains("facebook") Or e.Uri.Contains("doubleclick") Or e.Uri.Contains("tiktok") Or e.Uri.Contains("pinterest") Or e.Uri.Contains("adservice") Then
  '      e.Cancel = True
  '    End If
  '  End Sub

  Private Sub UpdateStatus()
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
        RaiseEvent StatusChanged(title)
        Exit Sub
      End If
      If p.Length() > 4 Then
        If p(4).Equals("collections") And title.Contains("Census") Then
          AncestryPage = "Census"
          RaiseEvent StatusChanged(title.Replace("Ancestry.com -", "").Trim())
          Exit Sub
        End If
      End If
      If p.Length > 9 Then
        If p(3).Equals("family-tree") And p(4).Equals("person") _
      And p(5).Equals("tree") And p(6) = ANCESTRY_TREE_ID _
      And p(7).Equals("person") Then
          If (p(9).StartsWith("facts") And title.EndsWith("Facts")) Or src.Contains("facts") Then
            AncestorID = p(8)
            If title.EndsWith("Facts") Then
              AncestorName = title.Split("-")(0).Trim()
            End If
            AncestryPage = "Facts"
            RaiseEvent StatusChanged(AncestryPage)
            Exit Sub
          End If
          If p(9).StartsWith("gallery") And title.EndsWith("Gallery") Then
            AncestorID = p(8)
            AncestorName = title.Split("-")(0).Trim()
            AncestryPage = "Gallery"
            RaiseEvent StatusChanged(AncestryPage)
            Exit Sub
          End If
          If p(9).StartsWith("hints") And title.EndsWith("Hints") Then
            AncestorID = p(8)
            AncestorName = title.Split("-")(0).Trim()
            AncestryPage = "Hints"
            RaiseEvent StatusChanged(AncestryPage)
            Exit Sub
          End If
          If p(9).StartsWith("story") And title.EndsWith("LifeStory") Then
            AncestorID = p(8)
            AncestorName = title.Split("-")(0).Trim()
            AncestryPage = "LifeStory"
            RaiseEvent StatusChanged(AncestryPage)
            Exit Sub
          End If
        End If
      End If
    End If
    RaiseEvent StatusChanged(title & " - " & src)
  End Sub

  Private Sub CoreWeb_DocumentTitleChanged(sender As Object, e As Object) Handles CoreWeb.DocumentTitleChanged
#If SHOW_DEBUG Then
    Debug.Print("CoreWeb_DocumentTitleChanged ")
    Debug.Print(vbTab & CoreWeb.Source)
    Debug.Print(vbTab & CoreWeb.DocumentTitle)
#End If
    UpdateStatus()
  End Sub

  Private Sub CoreWebDownload_StateChanged(sender As Object, e As Object) Handles CoreWebDownload.StateChanged
#If SHOW_DEBUG Then
    Debug.Print("CoreWebDownload_StateChanged: " & CoreWebDownload.State.ToString())
#End If
    If CoreWebDownload.State = CoreWebView2DownloadState.Completed And CoreWeb.IsDefaultDownloadDialogOpen Then
      CoreWeb.CloseDefaultDownloadDialog()
      executeScript("document.body.click();")
      RaiseEvent ImageDownload(AncestryPage, CoreWebDownload.ResultFilePath())
    End If
  End Sub

  Private Sub CoreWeb_DownloadStarting(sender As Object, e As CoreWebView2DownloadStartingEventArgs) Handles CoreWeb.DownloadStarting
#If SHOW_DEBUG Then
    Debug.Print("CoreWeb_DownloadStarting:  " & e.ResultFilePath)
#End If
    CoreWebDownload = e.DownloadOperation
  End Sub

  Public Sub NavigateTo(target As URLTypeEnum, Optional customParam As String = "")
    Dim rtn As String = ANCESTRY_URL
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
    rtn = rtn.Replace("{TREEID}", ANCESTRY_TREE_ID)
    rtn = rtn.Replace("{CFID}", "?cfpid={PERSONID}")
    If target <> URLTypeEnum.CUSTOM And customParam.Length > 0 Then
      activeAncestor.Reset()
      rtn = rtn.Replace("{PERSONID}", customParam)
    Else
      rtn = rtn.Replace("{PERSONID}", AncestorID)
    End If
    ' Perform Navigation
    location = rtn
  End Sub

  Public Sub Refresh()
    web.Reload()
  End Sub

  Private Sub web_SourceChanged(sender As Object, e As CoreWebView2SourceChangedEventArgs) Handles web.SourceChanged
    RaiseEvent SourceChanged(web.Source.AbsoluteUri)
  End Sub
End Class
