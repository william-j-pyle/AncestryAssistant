Imports Newtonsoft.Json

Partial Class AssistantAppForm

  Private WithEvents RibbonFileTab As RibbonPage

  Private Sub InitRibbonExtension() Handles Me.InitUIExtensions
#If TRACE Then
    Logger.debugPrint("FormMain.InitRibbonExtension()")
#End If

    'Init the Ribbon Bar
    AddHandler RibbonBar.Selecting, AddressOf RibbonBar_Selecting
    AddHandler RibbonBar.RibbonAction, AddressOf RibbonBar_Action
    AddHandler Ancestors.ActiveAncestorChanged, AddressOf RibbonBar_ActiveAncestorChanged
    RibbonFileTab = New RibbonPage With {
      .Visible = False
    }
    Controls.Add(RibbonFileTab)
    RibbonFileTab.BringToFront()
    Dim cfg As RibbonConfig = JsonConvert.DeserializeObject(Of RibbonConfig)(My.Resources.Ribbon)
    cfg.AppendConfig(JsonConvert.DeserializeObject(Of RibbonConfig)(My.Resources.Ribbon_AncestryBar))
    cfg.AppendConfig(JsonConvert.DeserializeObject(Of RibbonConfig)(My.Resources.Ribbon_ResearchBar))
    RibbonBar.LoadConfig(cfg)
    RibbonBar.SelectedIndex = 1

  End Sub

  Private Sub RibbonBar_Action(action As RibbonEventType, value As Object, barId As Integer, groupId As Integer, itemId As Integer)
#If DEBUG Then
    Logger.debugPrint("RibbonAction: {0}={1}    [{2}]", action.ToString, value, Ribbon.RibbonKey(barId, groupId, itemId))
#End If

    Select Case Ribbon.RibbonKey(barId, groupId, itemId)
      Case "B400.G400.I401" 'Test 1
        'DockManager.ItemShow(DPICensusWeb.Base_Key)
      Case "B400.G400.I402" 'Test 2
        'DockManager.ItemShow(DPIImageGalleryWeb.Base_Key)
      Case "B400.G400.I403" 'Test 3
      Case "B400.G400.I404" 'Test 4

      Case RibbonBar.Key("ANCESTOR_CENSUS_UNIFIED") 'Census
        DockManager.ItemShow(DPICensusWeb.Base_Key, "Unified")
      Case RibbonBar.Key("ANCESTOR_CENSUS_YR1")
        DockManager.ItemShow(DPICensusWeb.Base_Key, CStr(value), Ancestors.ActiveAncestorID)
      Case RibbonBar.Key("ANCESTOR_CENSUS_YR2")
        DockManager.ItemShow(DPICensusWeb.Base_Key, CStr(value))
      Case RibbonBar.Key("ANCESTOR_CENSUS_YR3")
        DockManager.ItemShow(DPICensusWeb.Base_Key, CStr(value))
      Case RibbonBar.Key("ANCESTOR_CENSUS_YR4")
        DockManager.ItemShow(DPICensusWeb.Base_Key, CStr(value))
      Case RibbonBar.Key("ANCESTOR_CENSUS_YR5")
        DockManager.ItemShow(DPICensusWeb.Base_Key, CStr(value))
      Case RibbonBar.Key("ANCESTOR_CENSUS_YR6")
        DockManager.ItemShow(DPICensusWeb.Base_Key, CStr(value))
      Case RibbonBar.Key("ANCESTOR_CENSUS_YR7")
        DockManager.ItemShow(DPICensusWeb.Base_Key, CStr(value))
      Case RibbonBar.Key("ANCESTOR_CENSUS_YR8")
        DockManager.ItemShow(DPICensusWeb.Base_Key, CStr(value))
      Case RibbonBar.Key("ANCESTOR_CENSUS_YR9")
        DockManager.ItemShow(DPICensusWeb.Base_Key, CStr(value))
      Case RibbonBar.Key("ANCESTOR_TOOLS_GALLERY") 'Gallery
        'Dim item As DockPanelItem = DockManager.ItemGet(DPIImageGallery.Base_Key)
        'If item Is Nothing Then
        '  item = New DPIImageGallery With {
        '    .ItemSuspendOnClose = True,
        '    .Ancestors = Ancestors
        '  }
        '  ' Register PanelItem
        '  DockManager.ItemRegister(item)
        'End If
        DockManager.ItemShow(DPIImageGalleryWeb.Base_Key)
      Case RibbonBar.Key("ANCESTOR_TOOLS_NOTEBOOK") 'Notebook
        DockManager.ItemShow(DPINotebook.Base_Key)
      Case RibbonBar.Key("ANCESTOR_ANCESTRY_FACT") 'Facts
        DockManager.ItemEventRequest(DPIWebBrowser.Base_Key, DockPanelItemEventType.NavRequested, UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Base_Key)
      Case RibbonBar.Key("ANCESTOR_PROFILE")
        If action.Equals(RibbonEventType.GroupPanelClick) Then
          DockManager.ItemShow(DPIAncestorListWeb.Base_Key)
        End If
      Case RibbonBar.Key("ANCESTOR_ANCESTRY_GALLERY") 'Ancestry Person Gallery
        DockManager.ItemEventRequest(DPIWebBrowser.Base_Key, DockPanelItemEventType.NavRequested, UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Base_Key)
      Case RibbonBar.Key("ANCESTOR_ANCESTRY_HINT") 'Ancestry Person Hints
        DockManager.ItemEventRequest(DPIWebBrowser.Base_Key, DockPanelItemEventType.NavRequested, UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Base_Key)
      Case RibbonBar.Key("ANCESTOR_ANCESTRY_STORY") 'Ancestry Person Story
        DockManager.ItemEventRequest(DPIWebBrowser.Base_Key, DockPanelItemEventType.NavRequested, UriTrackingGroupEnum.ANCESTRY_STORY_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Base_Key)
      Case RibbonBar.Key("ANCESTOR_ANCESTRY_FAN") 'Ancestry Person Fan
        DockManager.ItemEventRequest(DPIWebBrowser.Base_Key, DockPanelItemEventType.NavRequested, UriTrackingGroupEnum.ANCESTRY_FANVIEW_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Base_Key)
      Case RibbonBar.Key("ANCESTOR_ANCESTRY_PEDIGREE") 'Ancestry Person Pedigree
        DockManager.ItemEventRequest(DPIWebBrowser.Base_Key, DockPanelItemEventType.NavRequested, UriTrackingGroupEnum.ANCESTRY_PEDIGREEVIEW_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Base_Key)
      Case RibbonBar.Key("ANCESTOR_ANCESTRY_TREE") 'Ancestry Person Tree
        DockManager.ItemEventRequest(DPIWebBrowser.Base_Key, DockPanelItemEventType.NavRequested, UriTrackingGroupEnum.ANCESTRY_TREEVIEW_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Base_Key)
    End Select
  End Sub

  Private Sub RibbonBar_ActiveAncestorChanged()
    Dim Ancestor As AncestorCollection.Ancestor = Ancestors.ActiveAncestor

    Dim profileImage As Image
    If Ancestor.HasProfileImage Then
      profileImage = GetImageThumbnail(Ancestor.ProfileImage, 72)
    Else
      Select Case Ancestor.Fact("GENDER")
        Case "Female"
          profileImage = My.Resources.missing_profile_female
        Case "Male"
          profileImage = My.Resources.missing_profile_male
        Case Else
          profileImage = My.Resources.missing_profile
      End Select
    End If

    RibbonBar.SetItemAttribute(Ribbon.RibbonKey(200, 2, 4), RibbonItemAttribute.image, profileImage)
    RibbonBar.SetGroupAttribute(Ribbon.RibbonKey(200, 2), RibbonItemAttribute.text, Ancestor.FullName)
    RibbonBar.SetItemAttribute(Ribbon.RibbonKey(200, 2, 7), RibbonItemAttribute.text, Ancestor.GedBirthDate.toAssistantDate)
    RibbonBar.SetItemAttribute(Ribbon.RibbonKey(200, 2, 8), RibbonItemAttribute.text, Ancestor.GedDeathDate.toAssistantDate)
    RibbonBar.EnableBar(Ribbon.RibbonKey(200))
    'RibbonBar.EnableGroup(Ribbon.RibbonKey(200, 5))
    Dim x As Integer
    For x = 209 To 201 Step -1
      RibbonBar.SetItemAttribute(Ribbon.RibbonKey(200, 6, x), RibbonItemAttribute.visible, False)
    Next
    Dim hasCensus As Boolean = False
    x = 201
    For Each censusEntry As AncestorCensusData.CensusEntry In Ancestor.Census.CensusEntries
      Dim key As String = Ribbon.RibbonKey(200, 6, x)
      With censusEntry
        If .hasData Then hasCensus = True
        RibbonBar.SetItemAttribute(key, RibbonItemAttribute.value, .Year)
        RibbonBar.SetItemAttribute(key, RibbonItemAttribute.text, .Year)
        RibbonBar.SetItemAttribute(key, RibbonItemAttribute.enabled, .hasData)
        RibbonBar.SetItemAttribute(key, RibbonItemAttribute.visible, True)
      End With
      x += 1
    Next
    RibbonBar.SetItemAttribute(Ribbon.RibbonKey(200, 6, 17), RibbonItemAttribute.enabled, hasCensus)
  End Sub

  Private Sub RibbonBar_Selecting(sender As Object, e As TabControlCancelEventArgs)
    If e.TabPageIndex = 0 Then
      e.Cancel = True
      With RibbonFileTab
        .Location = New Point(4, AppTitleBar.Height)
        .Width = Width - 8
        .Height = Height - AppTitleBar.Height - 2
        .Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
        .Visible = True
      End With
    End If
  End Sub

End Class