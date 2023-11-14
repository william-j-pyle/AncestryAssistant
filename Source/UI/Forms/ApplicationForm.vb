Imports System.ComponentModel
Imports System.IO
Imports AncestryAssistant.AncestorCollection

#Const SHOW_DEBUG = True

Public Class ApplicationForm

  Public Event ActiveAncestorChanged()
  Public Event AncestorsUpdated()

  Private theme As UITheme = UITheme.GetInstance
  Private WithEvents Ancestry As AncestryWebViewer
  Private Ancestors As AncestorCollection
  Private WithEvents AncestorAttributes As AncestorPanel
  Private WithEvents AncestorsList As AncestorsListPanel
  Private WithEvents FormExtensions As ResizeDragHandler


  Private _AncestorId As String = String.Empty

  Property AncestorId As String
    Get
      Return _AncestorId
    End Get
    Set(value As String)
      If Ancestors.ContainsKey(value) Then
        _AncestorId = value
        RaiseEvent ActiveAncestorChanged()
      End If
    End Set
  End Property

#Region "App Form - Event Handlers"

  ' ==========================
  ' = App Form - Event Handlers
  ' ==========================

  Public Sub New()
    InitializeComponent()
    RibbonBar.SelectedIndex = 1
    Ancestors = New AncestorCollection(My.Settings.AncestorsPath)
  End Sub


  Private Sub ApplicationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    '' Register All Panels
    'PanelManager.RegisterPanel(DockPanelLocation.ContainerLeftPanels, pnlLeft)
    'PanelManager.RegisterPanel(DockPanelLocation.LeftTop, pnlLeftTop, DockPanelType.Panel)
    'PanelManager.RegisterPanel(DockPanelLocation.LeftBottom, pnlLeftBottom, DockPanelType.Panel)

    'PanelManager.RegisterPanel(DockPanelLocation.ContainerRightPanels, pnlRight)
    'PanelManager.RegisterPanel(DockPanelLocation.RightTop, pnlRightTop, DockPanelType.Panel)
    'PanelManager.RegisterPanel(DockPanelLocation.RightBottom, pnlRightBottom, DockPanelType.Panel)

    'PanelManager.RegisterPanel(DockPanelLocation.MiddleTopLeft, pnlMiddleLeft, DockPanelType.Tab)
    'PanelManager.RegisterPanel(DockPanelLocation.MiddleTopRight, pnlMiddleRight, DockPanelType.Tab)
    'PanelManager.RegisterPanel(DockPanelLocation.MiddleBottom, pnlMiddleBottom, DockPanelType.Panel)

    '' Register All Splitters
    'PanelManager.RegisterSplitter(DockPanelSplitterPlacement.SplitLeftAndMiddle, splitLeft)
    'PanelManager.RegisterSplitter(DockPanelSplitterPlacement.SplitLeftTopAndBottom, splitLeftTopBottom)
    'PanelManager.RegisterSplitter(DockPanelSplitterPlacement.SplitRightAndMiddle, splitRight)
    'PanelManager.RegisterSplitter(DockPanelSplitterPlacement.SplitRightTopAndBottom, splitRightTopBottom)
    'PanelManager.RegisterSplitter(DockPanelSplitterPlacement.SplitMiddleTopLeftAndTopRight, splitMiddleLeftRight)
    'PanelManager.RegisterSplitter(DockPanelSplitterPlacement.SplitMiddleTopAndBottom, splitMiddleBottom)

    ' Load Saved Visibility and Sizes
    'PanelManager.SetPanelVisibility(DockPanelLocation.MiddleTopLeft, My.Settings.UI_ML_VIS)
    'PanelManager.SetPanelVisibility(DockPanelLocation.MiddleTopRight, My.Settings.UI_MR_VIS)
    'PanelManager.SetPanelVisibility(DockPanelLocation.MiddleBottom, My.Settings.UI_MB_VIS)
    'pnlMiddleRight.Width = My.Settings.UI_MR_WIDTH
    'pnlMiddleBottom.Height = My.Settings.UI_MB_HEIGHT

    'PanelManager.SetPanelVisibility(DockPanelLocation.LeftTop, My.Settings.UI_LT_VIS)
    'PanelManager.SetPanelVisibility(DockPanelLocation.LeftBottom, My.Settings.UI_LB_VIS)
    'pnlLeft.Width = My.Settings.UI_L_WIDTH
    'pnlLeftTop.Height = My.Settings.UI_LT_HEIGHT

    'PanelManager.SetPanelVisibility(DockPanelLocation.RightTop, False) ' My.Settings.UI_RT_VIS)
    'PanelManager.SetPanelVisibility(DockPanelLocation.RightBottom, False) 'My.Settings.UI_RB_VIS)
    'pnlRight.Width = My.Settings.UI_R_WIDTH
    'pnlRightTop.Height = My.Settings.UI_RT_HEIGHT

    AncestorsList = New AncestorsListPanel()
    AncestorsList.setAncestors(Ancestors)
    DockManager.AddItem(DockPanelLocation.LeftTop, AncestorsList)
    'PanelManager.SetPanelVisibility(DockPanelLocation.LeftBottom, False)

    Ancestry = New AncestryWebViewer()
    Ancestry.AncestryTreeID = My.Settings.ANCESTRY_TREE_ID
    AddHandler Ancestry.ViewerBusy, AddressOf AncestryBrowserBusyChanged
    AddHandler Ancestry.UriTrackingGroupChanged, AddressOf AncestryURITrackingGroupChanged
    AddHandler Ancestry.DataDownload, AddressOf AncestryDataMessage
    DockManager.AddItem(DockPanelLocation.MiddleTopLeft, Ancestry)

    AncestorAttributes = New AncestorPanel()
    DockManager.AddItem(DockPanelLocation.LeftTop, AncestorAttributes)
    DockManager.AddItem(DockPanelLocation.MiddleTopLeft, New ImageGalleryPanelItem())
    DockManager.AddItem(DockPanelLocation.MiddleBottom, New CensusViewer())

    DockManager.LoadSettings()

    FormExtensions = New ResizeDragHandler(Me)
    FormExtensions.SetDragControl(AppTitle)

    ApplyTheme()
  End Sub

  Private Sub ApplyTheme()
    AppIcon.BackColor = theme.AppBackColor
    AppControlBox.BackColor = theme.AppBackColor
    AppTitle.BackColor = theme.AppBackColor
    AppTitle.ForeColor = theme.AppFontColor
    AppCloseButton.FlatAppearance.MouseDownBackColor = theme.AppAccentColor
    AppCloseButton.FlatAppearance.MouseOverBackColor = theme.AppAccent2Color
    AppCloseButton.ForeColor = theme.AppFontColor
    AppMaxButton.FlatAppearance.MouseDownBackColor = theme.AppAccentColor
    AppMaxButton.FlatAppearance.MouseOverBackColor = theme.AppAccent2Color
    AppMaxButton.ForeColor = theme.AppFontColor
    AppMinButton.FlatAppearance.MouseDownBackColor = theme.AppAccentColor
    AppMinButton.FlatAppearance.MouseOverBackColor = theme.AppAccent2Color
    AppMinButton.ForeColor = theme.AppFontColor
    AppTitle.BackColor = theme.AppBackColor
    AppTitle.ForeColor = theme.AppFontColor
    AppTitleBar.BackColor = theme.AppBackColor
    BackColor = theme.AppBackColor
    ForeColor = theme.AppFontColor
    FormBar.BackColor = theme.AppBackColor
    RibbonBar.BackColor = theme.AppBackColor
    RibbonBarTabHome.BackColor = theme.RibbonBarBackColor
    RibbonBarTabHome.ForeColor = theme.RibbonBarFontColor
    StatusBar.BackColor = theme.StatusBarBackColor
    StatusBar.ForeColor = theme.StatusBarFontColor
    AppCloseButton.Font = theme.AppIconsFont
    AppMaxButton.Font = theme.AppIconsFont
    AppMinButton.Font = theme.AppIconsFont
    AppTitle.Font = theme.AppTitleFont
    RibbonBar.Font = theme.RibbonBarFont
    FormBar.BackColor = theme.AppBackColor
    FormBar.ForeColor = theme.AppFontColor
    For Each tb As TabPage In RibbonBar.TabPages
      tb.BackColor = theme.AppBackColor
      tb.ForeColor = theme.AppFontColor
    Next
  End Sub

#End Region

#Region "App Toolbar - Event Handlers"

  ' ==========================
  ' = App Toolbar - Event Handlers
  ' ==========================

  Private Sub btnHomeTree_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_OVERVIEW_TREE)
  End Sub

  Private Sub btnViewPedigree_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_PEDIGREEVIEW_PERSON)
  End Sub

  Private Sub btnViewTree_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_TREEVIEW_PERSON)
  End Sub

  Private Sub btnViewFan_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FANVIEW_PERSON)
  End Sub

  Private Sub btnPersonFact_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON)
  End Sub

  Private Sub btnPersonHints_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON)
  End Sub

  Private Sub btnPersonGallery_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON)
  End Sub

  Private Sub btnPersonStory_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_STORY_PERSON)
  End Sub

  Private Sub AncestryToolbarToolStripMenuItem_Click(sender As Object, e As EventArgs)
    'Ancestry.ShowToolbar = AncestryToolbarToolStripMenuItem.Checked
  End Sub

#End Region

#Region "App Menu - Event Handlers"

  ' ==========================
  ' = App Menu - Event Handlers
  ' ==========================


  Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
    My.Settings.Save()
    Close()
  End Sub

#End Region


#Region "Viewer - Ancestry Web"

  ' ==========================
  ' = Viewer - Ancestry Web
  ' ==========================

  Private Sub AncestryBrowserBusyChanged(busy As Boolean)
    If busy Then
      Cursor = Cursors.WaitCursor
    Else
      Cursor = Cursors.Default
    End If
  End Sub

  Private Sub AncestryURITrackingGroupChanged(NewGroup As UriTrackingGroupEnum, OldGroup As UriTrackingGroupEnum)
    ' If btnActions.Visible Then
    'If NewGroup <> OldGroup Then
    'btnActions.Visible = False
    'End If
    'End If
  End Sub

  Private Const ANCESTOR_NEW As String = "Add Ancestor To Assistant"
  Private Const ANCESTOR_UPDATED As String = "Apply Ancestor Changes To Assistant"
  Private Const ANCESTOR_CENSUS As String = "Download Census Data"
  Private Const ANCESTOR_IMAGE As String = "Download Image"
  Private Const FINDAGRAVE_IMAGE As String = "Download FindAGrave Image"

  Private Sub AncestryDataMessage(msg As APIMessage)
    Logger.log(Logger.LOG_TYPE.ERR, msg.ToString)
    Select Case msg.MessageType
      Case APIMessage.MT_SAVEAS
        Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(AncestorId)
        Dim rslt As DialogResult
        Dim dlg As New SaveImageDetails
        dlg.InitDialog(msg)
        dlg.HidePayload()
        rslt = dlg.ShowDialog()
        If rslt = DialogResult.OK Then
          Dim i_type As String = dlg.ImageType.ToUpper
          Dim i_category As String = dlg.ImageCategory.ToUpper
          Dim i_summary As String = dlg.Summary
          If i_type.Equals("") Then i_type = "PHOTO"
          If i_category.Equals("") Then i_category = "OTHER"
          Dim filename As String = i_type & "-" & i_category & "-" & StrConv(i_summary, VbStrConv.ProperCase).Replace(" ", "")
          If filename.Length > 60 Then filename = filename.Substring(0, 60)
          Dim imgFilename As String = uniqueFilename(ancestor.FullPath("Gallery\" + filename), {"jpg.txt", "jpg"})
          File.WriteAllText(imgFilename + ".jpg.txt", dlg.Summary)
          'Ancestry.saveImageAs(imgFilename + ".jpg")
          System.IO.File.Move(msg.GetValue("fileName"), imgFilename + ".jpg")
        End If
      Case APIMessage.MT_PERSON
        If msg.MessageKey.Length > 3 Then
          If Not Ancestors.ContainsKey(msg.MessageKey) Then
            'With btnActions
            '  .Tag = msg
            '  .Text = ANCESTOR_NEW
            '  '.Image = My.Resources.ANCESTOR_ADD_WHITE
            '  .Enabled = True
            '  .Visible = True
            'End With
          Else
            'If assistant ancestor is different, then change ancestors
            If Not AncestorId.Equals(msg.MessageKey) Then
              AncestorId = msg.MessageKey
            End If
            If Not Ancestors.Item(msg.MessageKey).AncestorMatchesMessage(msg) Then
              'With btnActions
              '  .Tag = msg
              '  .Text = ANCESTOR_UPDATED
              '  '.Image = My.Resources.ANCESTOR_ADD_WHITE
              '  .Enabled = True
              '  .Visible = True
              'End With
            End If
          End If
        End If
      Case APIMessage.MT_PAGE
        If msg.PageKey.Equals("FINDAGRAVE_VIEWER_IMAGE") And (msg.GetValue("PAGEKEY").EndsWith("jpg") Or msg.GetValue("PAGEKEY").EndsWith("jepg")) Then
          'With btnActions
          '  .Tag = msg
          '  .Text = FINDAGRAVE_IMAGE
          '  '.Image = My.Resources.ANCESTOR_ADD_WHITE
          '  .Enabled = True
          '  .Visible = True
          'End With
        End If
      Case APIMessage.MT_FINDAGRAVE
        Debug.Print("FindAGrave Handler")
        If Ancestors.ContainsKey(AncestorId) Then
          Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(AncestorId)
          'If ancestor.Surname.ToLower.Equals(msg.GetValue("lastName").ToLower) Then
          If ancestor.GedDeathDate.Year = CInt(msg.GetValue("deathYear")) Then
            If ancestor.Fact("cemeteryName").Equals("") Then
              ancestor.Fact("cemeteryName") = msg.GetValue("cemeteryName")
            End If
            If ancestor.Fact("cemeteryPlace").Equals("") Then
              ancestor.Fact("cemeteryPlace") = msg.GetValue("locationName")
            End If
            If ancestor.Fact("FindAGraveID").Equals("") Then
              ancestor.Fact("FindAGraveID") = msg.GetValue("memorialId")
            End If
            RaiseEvent ActiveAncestorChanged()
          End If
          'End If
        End If
      Case APIMessage.MT_TABLEDATA
        If msg.MessageKey.Length > 3 Then
          If Ancestors.ContainsKey(msg.MessageKey) Then
            Dim title As String = msg.GetValue("Title")
            If title.Contains("Census") Then
              'With btnActions
              '  .Tag = msg
              '  .Text = ANCESTOR_CENSUS
              '  '.Image = My.Resources.ANCESTOR_ADD_WHITE
              '  .Enabled = True
              '  .Visible = True
              'End With
            Else
              If msg.PageKey = "ANCESTRY_VIEWER_IMAGE" Then
                'With btnActions
                '  .Tag = msg
                '  .Text = ANCESTOR_IMAGE
                '  '.Image = My.Resources.ANCESTOR_ADD_WHITE
                '  .Enabled = True
                '  .Visible = True
                'End With
              End If
            End If
          End If
        End If
      Case Else
        'btnActions.Visible = False
    End Select
  End Sub

#End Region


  Private Sub btnActions_Click(sender As Object, e As EventArgs)
    'btnActions.Visible = False
    'If btnActions.Tag Is Nothing Then Exit Sub
    'Dim msg As APIMessage = btnActions.Tag
    'Select Case btnActions.Text
    '  Case ANCESTOR_NEW
    '    If Not Ancestors.ContainsKey(msg.MessageKey) Then
    '      If msg.MessageType = APIMessage.MT_PERSON Then
    '        Dim ancestor As AncestorCollection.Ancestor = Ancestors.newAncestor(msg.MessageKey)
    '        For Each fact As String In ancestor.AncestorFactList()
    '          ancestor.Fact(fact) = msg.GetValue(fact)
    '        Next
    '        AncestorId = msg.MessageKey
    '        RaiseEvent AncestorsUpdated()
    '      End If
    '    End If
    '  Case ANCESTOR_UPDATED
    '    Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
    '    For Each fact As String In ancestor.AncestorFactDifferences(msg)
    '      ancestor.Fact(fact) = msg.GetValue(fact)
    '    Next
    '    AncestorId = msg.MessageKey
    '    RaiseEvent AncestorsUpdated()
    '  Case ANCESTOR_CENSUS
    '    Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
    '    Dim imgFilename As String = ancestor.Census.addCensusData(msg)
    '    AncestorId = msg.MessageKey
    '    Ancestry.saveImageAs(imgFilename + ".jpg")
    '    RaiseEvent AncestorsUpdated()
    '  Case ANCESTOR_IMAGE
    '    Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
    '    Dim rslt As DialogResult
    '    Dim dlg As New SaveImageDetails
    '    dlg.InitDialog(msg)
    '    rslt = dlg.ShowDialog()
    '    If rslt = DialogResult.OK Then
    '      Dim i_type As String = dlg.ImageType.ToUpper
    '      Dim i_category As String = dlg.ImageCategory.ToUpper
    '      Dim i_summary As String = dlg.Summary
    '      Dim i_details As List(Of List(Of String)) = dlg.TableData
    '      If i_type.Equals("") Then i_type = "PHOTO"
    '      If i_category.Equals("") Then i_category = "OTHER"
    '      Dim filename As String = i_type & "-" & i_category & "-" & StrConv(i_summary, VbStrConv.ProperCase).Replace(" ", "")
    '      If filename.Length > 60 Then filename = filename.Substring(0, 60)
    '      Dim imgFilename As String = uniqueFilename(ancestor.FullPath("Gallery\" + filename), {"aa", "jpg.txt", "jpg"})
    '      File.WriteAllText(imgFilename + ".jpg.txt", dlg.Summary)
    '      Dim aa As AAFile = New AAFile(imgFilename + ".aa", AAFileTypeEnum.LISTARRAY)
    '      aa.setTableData(i_details)
    '      aa.Save()
    '      Ancestry.saveImageAs(imgFilename + ".jpg")
    '    End If
    '  Case FINDAGRAVE_IMAGE
    '    Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(AncestorId)
    '    Dim rslt As DialogResult
    '    Dim dlg As New SaveImageDetails
    '    dlg.InitDialog(msg)
    '    dlg.HidePayload()
    '    rslt = dlg.ShowDialog()
    '    If rslt = DialogResult.OK Then
    '      Dim i_type As String = dlg.ImageType.ToUpper
    '      Dim i_category As String = dlg.ImageCategory.ToUpper
    '      Dim i_summary As String = dlg.Summary
    '      If i_type.Equals("") Then i_type = "PHOTO"
    '      If i_category.Equals("") Then i_category = "OTHER"
    '      Dim filename As String = i_type & "-" & i_category & "-" & StrConv(i_summary, VbStrConv.ProperCase).Replace(" ", "")
    '      If filename.Length > 60 Then filename = filename.Substring(0, 60)
    '      Dim imgFilename As String = uniqueFilename(ancestor.FullPath("Gallery\" + filename), {"jpg.txt", "jpg"})
    '      File.WriteAllText(imgFilename + ".jpg.txt", dlg.Summary)
    '      Ancestry.saveImageAs(imgFilename + ".jpg")
    '    End If
    '  Case Else

    'End Select

  End Sub

  Private Sub ApplicationForm_AncestorsUpdated() Handles Me.AncestorsUpdated
    Logger.log(Logger.LOG_TYPE.INFO, "ApplicationForm_AncestorsUpdated")
    AncestorsList.setAncestors(Ancestors, AncestorId)
  End Sub

  Private Sub ApplicationForm_ActiveAncestorChanged() Handles Me.ActiveAncestorChanged
    Logger.log(Logger.LOG_TYPE.INFO, "ApplicationForm_ActiveAncestorChanged")
    Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(AncestorId)
    AncestorsList.setActiveAncestor(AncestorId)
    AncestorAttributes.SetAncestor(ancestor)
    'imgGallery.SetAncestor(ancestor)
    'CensusViewer1.SetAncestor(ancestor)
    'NotebookViewer1.SetAncestor(ancestor)
  End Sub

  Private Sub AncestorsList_AncestorIDChanged(SelectedAncestorID As String) Handles AncestorsList.AncestorIDChanged
    Logger.log(Logger.LOG_TYPE.INFO, "AncestorsList_AncestorIDChanged")
    AncestorId = SelectedAncestorID
  End Sub

  Private Sub AncestorsList_AncestryNavigateRequest(SelectedAncestorID As String) Handles AncestorsList.AncestryNavigateRequest
    AncestorId = SelectedAncestorID
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON, SelectedAncestorID)
  End Sub


  Private Sub AncestorAttributes_PanelCloseClicked(sender As Object)
    'btnAncestor.Checked = False
  End Sub

  Private Sub AncestorsList_PanelCloseClicked(sender As Object)
    'btnAncestors.Checked = False
  End Sub




  Private Sub SaveUIState()
    'My.Settings.UI_MR_WIDTH = pnlMiddleRight.Width
    'My.Settings.UI_MB_HEIGHT = pnlMiddleBottom.Height
    'My.Settings.UI_ML_VIS = pnlMiddleLeft.Visible
    'My.Settings.UI_MR_VIS = pnlMiddleRight.Visible
    'My.Settings.UI_MB_VIS = pnlMiddleBottom.Visible

    'My.Settings.UI_L_WIDTH = pnlLeft.Width
    'My.Settings.UI_LT_HEIGHT = pnlLeftTop.Height
    'My.Settings.UI_LT_VIS = pnlLeftTop.Visible
    'My.Settings.UI_LB_VIS = pnlLeftBottom.Visible

    'My.Settings.UI_R_WIDTH = pnlRight.Width
    'My.Settings.UI_RT_HEIGHT = pnlRightTop.Height
    'My.Settings.UI_RT_VIS = pnlRightTop.Visible
    'My.Settings.UI_RB_VIS = pnlRightBottom.Visible
  End Sub

  Private Sub ApplicationForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    SaveUIState()
  End Sub

  Private Sub btnCensus_Click(sender As Object, e As EventArgs)
    'PanelManager.SetPanelVisibility(DockPanelLocation.MiddleBottom, btnCensus.Checked)
  End Sub

  Private Sub btnNotebook_Click(sender As Object, e As EventArgs)
    'PanelManager.SetPanelVisibility(DockPanelLocation.MiddleTopRight, btnNotebook.Checked)
  End Sub

  Private Sub Ancestry_UriTrackingGroupChanged(NewGroup As UriTrackingGroupEnum, OldGroup As UriTrackingGroupEnum)

  End Sub

  Private Sub Ancestry_AncestryData(data As APIMessage)

  End Sub

  Private Sub Ancestry_ViewerBusy(busy As Boolean)

  End Sub

  Private Sub AppCloseButton_Click(sender As Object, e As EventArgs) Handles AppCloseButton.Click
    Close()
  End Sub

  Private Sub AppMinButton_Click(sender As Object, e As EventArgs) Handles AppMinButton.Click
    WindowState = FormWindowState.Minimized
  End Sub

  Private Sub AppMaxButton_Click(sender As Object, e As EventArgs) Handles AppMaxButton.Click, AppTitle.DoubleClick
    If WindowState = FormWindowState.Normal Then
      WindowState = FormWindowState.Maximized
    ElseIf WindowState = FormWindowState.Maximized Then
      WindowState = FormWindowState.Normal
    End If
  End Sub



End Class