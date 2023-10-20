Imports System.ComponentModel
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms
Imports Newtonsoft.Json

Public Class AncestryViewer
  Inherits Panel
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
  Private WithEvents btnDownload As ToolStripButton

  ' Tracking
  Private isReady As Boolean = False

  ' Temporary Constants, remove these to settings
  Public Const ANCESTRY_URL = "https://www.ancestry.com/"
  Public Const ANCESTRY_TREE_ID = "65171586"

  ' Public Events
  Public Event AncestryData(dataType As DataTypeEnum, data As AncestryMessageData)
  Public Event AncestorChanged(AncestorID As String)
  Public Event AncestryViewerBusy(busy As Boolean)


  Public Sub New()
    activeAncestor = New Ancestor()
    web = New Microsoft.Web.WebView2.WinForms.WebView2()
    tsWeb = New System.Windows.Forms.ToolStrip()
    btnBack = New System.Windows.Forms.ToolStripButton()
    btnReload = New System.Windows.Forms.ToolStripButton()
    btnHome = New System.Windows.Forms.ToolStripButton()
    txtHref = New System.Windows.Forms.ToolStripTextBox()
    btnDownload = New System.Windows.Forms.ToolStripButton()

    CType(web, System.ComponentModel.ISupportInitialize).BeginInit()
    tsWeb.SuspendLayout()

    Dock = DockStyle.Fill

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
    web.Size = New System.Drawing.Size(348, 288)
    web.Source = New System.Uri("https://www.ancestry.com/family-tree/tree/65171586", System.UriKind.Absolute)
    web.TabIndex = 0
    web.ZoomFactor = 0.75R

    Controls.Add(web)
    Controls.Add(tsWeb)

    '
    'tsWeb
    '
    tsWeb.CanOverflow = False
    tsWeb.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    tsWeb.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    tsWeb.Items.AddRange(New System.Windows.Forms.ToolStripItem() {btnBack, btnReload, btnHome, txtHref, btnDownload})
    tsWeb.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
    tsWeb.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
    tsWeb.Name = "tsWeb"
    tsWeb.Padding = New System.Windows.Forms.Padding(4, 0, 16, 0)
    tsWeb.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
    tsWeb.Size = New System.Drawing.Size(348, 25)
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
    txtHref.Font = New System.Drawing.Font("Segoe UI", 9.0!)
    txtHref.Name = "txtHref"
    txtHref.Size = New System.Drawing.Size(100, 23)
    txtHref.ToolTipText = "Website URL"
    '
    'btnDownload
    '
    btnDownload.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
    btnDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    btnDownload.Image = Global.AncestryAssistant.My.Resources.Resources.DOWNLOAD_ICO20
    btnDownload.ImageTransparentColor = System.Drawing.Color.Magenta
    btnDownload.Name = "btnDownload"
    btnDownload.Size = New System.Drawing.Size(23, 22)
    btnDownload.Text = "Download"
    btnDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
    btnDownload.ToolTipText = "Download Available Information"

    CType(web, System.ComponentModel.ISupportInitialize).EndInit()
    web.EnsureCoreWebView2Async()
    tsWeb.ResumeLayout(False)
    tsWeb.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Private _ShowToolbar As Boolean = True
  Public Property ShowToolbar As Boolean
    Get
      Return _ShowToolbar
    End Get
    Set(value As Boolean)
      _ShowToolbar = value
      tsWeb.Visible = value
    End Set
  End Property

  Public Property BrowserStatus As String = ""

  Public Property activeAncestor As Ancestor


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
        JSAPI_Execute("window.AncestryAssistant.captureFactsInternal();")
      End If
      RaiseEvent PageChanged(wasPage, value)
    End Set
  End Property

  Private _URL As Uri = New Uri(ANCESTRY_URL)
  <Browsable(False)>
  Public Property URL As Uri
    Get
      Return _URL
    End Get
    Set(value As Uri)
      _URL = value
      TryToNavigate()
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

  Private Sub TryToNavigate()
    If isReady Then
      If URL IsNot Nothing Then
        If URL.OriginalString.Length > 0 Then
          web.Source = URL
        End If
      End If
    End If
  End Sub

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
          RaiseEvent ImageDownload(fromPage, fname)
        End If
    End Select
    Return False
  End Function


  Private Async Sub JSAPI_Execute(script As String)
#If SHOW_DEBUG Then
    Debug.Print("Executeing Script: " & script)
#End If
    Await web.CoreWebView2.ExecuteScriptAsync(script)
  End Sub


  Private Sub JSAPI_Message(sender As Object, e As CoreWebView2WebMessageReceivedEventArgs) Handles web.WebMessageReceived
    Dim msg As JSMessage = JsonConvert.DeserializeObject(Of JSMessage)(e.WebMessageAsJson)
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
        Dim data As CensusParser = New CensusParser(msg.Payload, msg.MessageKey)
        If data.CensusArray.Length > 1 Then
          Dim year As String = data.CensusArray(1)(0).ToString
          Dim page As String = data.CensusArray(1)(1).ToString
          _AncestryPage = "Census-" & year & "-p" & page
          RaiseEvent DataChanged(DataTypeEnum.anCENSUSDATA, data.CensusArray)
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
    TryToNavigate()
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
#If SHOW_DEBUG Then
      Debug.Print("CoreWeb_FrameNavigationStarting: " & e.NavigationId & "-" & e.Uri)
#End If
    'If e.Uri.Contains("facebook") Or e.Uri.Contains("doubleclick") Or e.Uri.Contains("tiktok") Or e.Uri.Contains("pinterest") Or e.Uri.Contains("adservice") Then
    'e.Cancel = True
    'End If
  End Sub

  Private Sub CoreWeb_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles CoreWeb.NavigationCompleted
    If Visible = False Then Visible = True
    _URL = web.Source
    Dim b As Boolean = txtHref.Text.Contains("mediaui-viewer") Or BrowserStatus.Contains("Census") Or BrowserStatus.Contains("Fact") Or txtHref.Text.EndsWith("jpg") Or txtHref.Text.EndsWith("jpeg")
    btnDownload.Enabled = b And activeAncestor.IsValid
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
      And p(5).Equals("tree") And p(6) = ANCESTRY_TREE_ID _
      And p(7).Equals("person") Then
          If (p(9).StartsWith("facts") And title.EndsWith("Facts")) Or src.Contains("facts") Then
            AncestorID = p(8)
            If title.EndsWith("Facts") Then
              AncestorName = title.Split("-")(0).Trim()
            End If
            AncestryPage = "Facts"
            BrowserStatus = AncestryPage
            Exit Sub
          End If
          If p(9).StartsWith("gallery") And title.EndsWith("Gallery") Then
            AncestorID = p(8)
            AncestorName = title.Split("-")(0).Trim()
            AncestryPage = "Gallery"
            BrowserStatus = AncestryPage
            Exit Sub
          End If
          If p(9).StartsWith("hints") And title.EndsWith("Hints") Then
            AncestorID = p(8)
            AncestorName = title.Split("-")(0).Trim()
            AncestryPage = "Hints"
            BrowserStatus = AncestryPage
            Exit Sub
          End If
          If p(9).StartsWith("story") And title.EndsWith("LifeStory") Then
            AncestorID = p(8)
            AncestorName = title.Split("-")(0).Trim()
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
#If SHOW_DEBUG Then
    Debug.Print("CoreWebDownload_StateChanged: " & CoreWebDownload.State.ToString())
#End If
    If CoreWebDownload.State = CoreWebView2DownloadState.Completed And CoreWeb.IsDefaultDownloadDialogOpen Then
      CoreWeb.CloseDefaultDownloadDialog()
      JSAPI_Execute("document.body.click();")
      RaiseEvent ImageDownload(AncestryPage, CoreWebDownload.ResultFilePath())
    End If
  End Sub

  ' When the browser detects a file is being downloaded
  ' this routine will fire, we Capture the DownloadOperation object and monitor its events
  ' for completion of the download, then fire an event about the download
  Private Sub CoreWeb_DownloadStarting(sender As Object, e As CoreWebView2DownloadStartingEventArgs) Handles CoreWeb.DownloadStarting
#If SHOW_DEBUG Then
    Debug.Print("CoreWeb_DownloadStarting:  " & e.ResultFilePath)
#End If
    CoreWebDownload = e.DownloadOperation
  End Sub


  ' ==========================
  ' = Public Methods
  ' ==========================
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
    'tsWeb.Refresh()
  End Sub

  Private Sub txtHref_Enter(sender As Object, e As EventArgs) Handles txtHref.Enter
    NavigateTo(URLTypeEnum.CUSTOM, txtHref.Text)
  End Sub

  Private Sub web_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles web.NavigationStarting
    RaiseEvent AncestryViewerBusy(True)
  End Sub

  Private Sub web_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles web.NavigationCompleted
    RaiseEvent AncestryViewerBusy(False)
  End Sub
End Class
