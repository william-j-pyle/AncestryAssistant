Imports System.ComponentModel

Partial Class AssistantAppForm

#Region "Fields"

  Private WithEvents FormExtensions As ResizeDragHandler

  Private WithEvents RibbonFileTab As RibbonPage

#End Region

#Region "Private Methods"

  Private Sub Application_CloseButton_Click(sender As Object, e As EventArgs)
    Close()
  End Sub

  Private Sub Application_Form_Closing(sender As Object, e As CancelEventArgs)
    If WindowState <> FormWindowState.Normal Then
      WindowState = FormWindowState.Normal
    End If
    SettingsSave()
  End Sub

  Private Sub Application_MaxButton_Click(sender As Object, e As EventArgs)
    If WindowState = FormWindowState.Normal Then
      WindowState = FormWindowState.Maximized
    ElseIf WindowState = FormWindowState.Maximized Then
      WindowState = FormWindowState.Normal
    End If
  End Sub

  Private Sub Application_MinButton_Click(sender As Object, e As EventArgs)
    WindowState = FormWindowState.Minimized
  End Sub

  Private Sub InitUIExtensions()
    'Add Form Event Handlers
    AddHandler AppMinButton.Click, AddressOf Application_MinButton_Click
    AddHandler AppMaxButton.Click, AddressOf Application_MaxButton_Click
    AddHandler AppTitle.DoubleClick, AddressOf Application_MaxButton_Click
    AddHandler Closing, AddressOf Application_Form_Closing
    AddHandler AppCloseButton.Click, AddressOf Application_CloseButton_Click

    'Init the Ribbon Bar
    AddHandler RibbonBar.Selecting, AddressOf RibbonBar_Selecting
    AddHandler RibbonBar.RibbonAction, AddressOf RibbonBar_Action
    RibbonFileTab = New RibbonPage With {
      .Visible = False
    }
    Controls.Add(RibbonFileTab)
    RibbonFileTab.BringToFront()
    RibbonBar.LoadConfig(My.Resources.Ribbon)
    RibbonBar.SelectedIndex = 1

    'Move this to the config file
    RibbonBar.DisableGroup(Ribbon.RibbonKey(200, 2))
    RibbonBar.DisableGroup(Ribbon.RibbonKey(200, 3))
    RibbonBar.DisableGroup(Ribbon.RibbonKey(200, 4))
    RibbonBar.DisableGroup(Ribbon.RibbonKey(200, 5))

    ' Init the FormExtensions to make this a borderless form
    FormExtensions = New ResizeDragHandler(Me)
    FormExtensions.SetDragControl(AppTitle)

  End Sub

  Private Sub RibbonBar_Action(action As RibbonEventType, value As Object, barId As Integer, groupId As Integer, itemId As Integer)
    Logger.debugPrint("RibbonAction: {0}={1}    [{2}]", action.ToString, value, Ribbon.RibbonKey(barId, groupId, itemId))

    Select Case Ribbon.RibbonKey(barId, groupId, itemId)
      Case "B200.G5.I17" 'Census
        DockManager.ItemShow(DPICensus.Default_Key)
      Case "B200.G5.I18" 'Gallery
        DockManager.ItemShow(DPIImageGallery.Default_Key)
      Case "B200.G5.I19" 'Notebook
        DockManager.ItemShow(DPINotebook.Default_Key)
      Case "B200.G3.I9" 'Facts
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Default_Key)
      Case "B200.G2"
        DockManager.ItemShow(DPIAncestorsList.Default_Key)
      Case "ASSIGN" 'Ancestry Person Gallery
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Default_Key)
      Case "ASSIGN" 'Ancestry Person Hints
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Default_Key)
      Case "ASSIGN" 'Ancestry Person Story
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_STORY_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Default_Key)
      Case "B200.G3.I12" 'Ancestry Person Fan
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FANVIEW_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Default_Key)
      Case "B200.G3.I11" 'Ancestry Person Pedigree
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_PEDIGREEVIEW_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Default_Key)
      Case "B200.G3.I10" 'Ancestry Person Tree
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_TREEVIEW_PERSON)
        DockManager.ItemShow(DPIWebBrowser.Default_Key)
    End Select
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

#End Region

End Class