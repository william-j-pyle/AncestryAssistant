Imports System.ComponentModel
Imports System.IO
Imports AncestryAssistant.AncestorCollection

#Const SHOW_DEBUG = True

Public Class AssistantAppForm

#Region "Fields"

  Private WithEvents AncestorAttributes As AncestorPanel

  Private WithEvents AncestorsList As AncestorsListPanel

  Private WithEvents Ancestry As AncestryWebViewer

  Private WithEvents FormExtensions As ResizeDragHandler

  Private WithEvents RibbonFileTab As RibbonPage

  Private Const ANCESTOR_CENSUS As String = "Download Census Data"

  Private Const ANCESTOR_NEW As String = "Add Ancestor To Assistant"

  Private Const ANCESTOR_UPDATED As String = "Apply Ancestor Changes To Assistant"

  Private Const FINDAGRAVE_IMAGE As String = "Download FindAGrave Image"

  Private _AncestorId As String = String.Empty

  Private Ancestors As AncestorCollection

#End Region

#Region "Events"

  Public Event ActiveAncestorChanged()

  Public Event AncestorsUpdated()

#End Region

#Region "Properties"

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

#End Region

#Region "Public Constructors"

  Public Sub New()
    InitializeComponent()
    RibbonFileTab = New RibbonPage With {
      .Visible = False
    }
    Controls.Add(RibbonFileTab)
    RibbonFileTab.BringToFront()
    RibbonBar.LoadConfig(My.Resources.Ribbon)
    RibbonBar.SelectedIndex = 1
    Ancestors = New AncestorCollection(My.Settings.AncestorsPath)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub AncestorAttributes_PanelCloseClicked(sender As Object)
    'btnAncestor.Checked = False
  End Sub

  Private Sub AncestorsList_AncestorIDChanged(SelectedAncestorID As String) Handles AncestorsList.AncestorIDChanged
    Logger.log(Logger.LOG_TYPE.INFO, "AncestorsList_AncestorIDChanged")
    AncestorId = SelectedAncestorID
  End Sub

  Private Sub AncestorsList_AncestryNavigateRequest(SelectedAncestorID As String) Handles AncestorsList.AncestryNavigateRequest
    AncestorId = SelectedAncestorID
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON, SelectedAncestorID)
  End Sub

  Private Sub AncestorsList_PanelCloseClicked(sender As Object)
    'btnAncestors.Checked = False
  End Sub

  Private Sub Ancestry_AncestryData(data As APIMessage)

  End Sub

  Private Sub Ancestry_UriTrackingGroupChanged(NewGroup As UriTrackingGroupEnum, OldGroup As UriTrackingGroupEnum)

  End Sub

  Private Sub Ancestry_ViewerBusy(busy As Boolean)

  End Sub

  Private Sub AncestryBrowserBusyChanged(busy As Boolean)
    If busy Then
      Cursor = Cursors.WaitCursor
    Else
      Cursor = Cursors.Default
    End If
  End Sub

  Private Sub AncestryDataMessage(msg As APIMessage)
    Logger.log(Logger.LOG_TYPE.ERR, msg.ToString)
    Select Case msg.MessageType
      Case APIMessage.MT_SAVEAS
        Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(AncestorId)
        Dim rslt As DialogResult
        Dim dlg As New SaveImageDialog
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

  Private Sub AncestryToolbarToolStripMenuItem_Click(sender As Object, e As EventArgs)
    'Ancestry.ShowToolbar = AncestryToolbarToolStripMenuItem.Checked
  End Sub

  Private Sub AncestryURITrackingGroupChanged(NewGroup As UriTrackingGroupEnum, OldGroup As UriTrackingGroupEnum)
    ' If btnActions.Visible Then
    'If NewGroup <> OldGroup Then
    'btnActions.Visible = False
    'End If
    'End If
  End Sub

  Private Sub AppCloseButton_Click(sender As Object, e As EventArgs) Handles AppCloseButton.Click
    Close()
  End Sub

  Private Sub ApplicationForm_ActiveAncestorChanged() Handles Me.ActiveAncestorChanged
    Logger.log(Logger.LOG_TYPE.INFO, "ApplicationForm_ActiveAncestorChanged")
    Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(AncestorId)
    AncestorsList.SetActiveAncestor(AncestorId)
    AncestorAttributes.SetAncestor(ancestor)
    'imgGallery.SetAncestor(ancestor)
    'CensusViewer1.SetAncestor(ancestor)
    'NotebookViewer1.SetAncestor(ancestor)
  End Sub

  Private Sub ApplicationForm_AncestorsUpdated() Handles Me.AncestorsUpdated
    Logger.log(Logger.LOG_TYPE.INFO, "ApplicationForm_AncestorsUpdated")
    AncestorsList.SetAncestors(Ancestors, AncestorId)
  End Sub

  ' ==========================
  ' = App Form - Event Handlers ==========================
  Private Sub ApplicationForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    SaveSettings()
  End Sub

  Private Sub ApplicationForm_Load(sender As Object, e As EventArgs) Handles Me.Load
    AncestorsList = New AncestorsListPanel()
    AncestorsList.SetAncestors(Ancestors)
    DockManager.AddItem(DockPanelLocation.LeftTop, AncestorsList)
    'PanelManager.SetPanelVisibility(DockPanelLocation.LeftBottom, False)

    Ancestry = New AncestryWebViewer With {
      .AncestryTreeID = My.Settings.ANCESTRY_TREE_ID
    }
    AddHandler Ancestry.ViewerBusy, AddressOf AncestryBrowserBusyChanged
    AddHandler Ancestry.UriTrackingGroupChanged, AddressOf AncestryURITrackingGroupChanged
    AddHandler Ancestry.DataDownload, AddressOf AncestryDataMessage
    DockManager.AddItem(DockPanelLocation.MiddleTopLeft, Ancestry)

    AncestorAttributes = New AncestorPanel()
    DockManager.AddItem(DockPanelLocation.LeftTop, AncestorAttributes)
    DockManager.AddItem(DockPanelLocation.MiddleTopLeft, New ImageGalleryPanelItem())
    DockManager.AddItem(DockPanelLocation.MiddleBottom, New CensusViewer())

    DockManager.SelectItemTab(DockPanelLocation.LeftTop, 0)
    DockManager.SelectItemTab(DockPanelLocation.MiddleTopLeft, 0)
    DockManager.SetPanelFocus(DockPanelLocation.MiddleTopLeft, True)
    FormExtensions = New ResizeDragHandler(Me)
    FormExtensions.SetDragControl(AppTitle)
    LoadSettings()
  End Sub

  Private Sub ApplyTheme()
    AppIcon.BackColor = My.Theme.AppBackColor
    AppControlBox.BackColor = My.Theme.AppBackColor
    AppTitle.BackColor = My.Theme.AppBackColor
    AppTitle.ForeColor = My.Theme.AppFontColor
    AppCloseButton.FlatAppearance.MouseDownBackColor = My.Theme.AppAccentColor
    AppCloseButton.FlatAppearance.MouseOverBackColor = My.Theme.AppAccent2Color
    AppCloseButton.ForeColor = My.Theme.AppFontColor
    AppMaxButton.FlatAppearance.MouseDownBackColor = My.Theme.AppAccentColor
    AppMaxButton.FlatAppearance.MouseOverBackColor = My.Theme.AppAccent2Color
    AppMaxButton.ForeColor = My.Theme.AppFontColor
    AppMinButton.FlatAppearance.MouseDownBackColor = My.Theme.AppAccentColor
    AppMinButton.FlatAppearance.MouseOverBackColor = My.Theme.AppAccent2Color
    AppMinButton.ForeColor = My.Theme.AppFontColor
    AppTitle.BackColor = My.Theme.AppBackColor
    AppTitle.ForeColor = My.Theme.AppFontColor
    AppTitleBar.BackColor = My.Theme.AppBackColor
    BackColor = My.Theme.AppBackColor
    ForeColor = My.Theme.AppFontColor
    FormBar.BackColor = My.Theme.AppBackColor
    StatusBar.BackColor = My.Theme.StatusBarBackColor
    StatusBar.ForeColor = My.Theme.StatusBarFontColor
    AppCloseButton.Font = My.Theme.AppIconsFont
    AppMaxButton.Font = My.Theme.AppIconsFont
    AppMinButton.Font = My.Theme.AppIconsFont
    AppTitle.Font = My.Theme.AppTitleFont
    FormBar.BackColor = My.Theme.AppBackColor
    FormBar.ForeColor = My.Theme.AppFontColor
  End Sub

  Private Sub AppMaxButton_Click(sender As Object, e As EventArgs) Handles AppMaxButton.Click, AppTitle.DoubleClick
    If WindowState = FormWindowState.Normal Then
      WindowState = FormWindowState.Maximized
    ElseIf WindowState = FormWindowState.Maximized Then
      WindowState = FormWindowState.Normal
    End If
  End Sub

  Private Sub AppMinButton_Click(sender As Object, e As EventArgs) Handles AppMinButton.Click
    WindowState = FormWindowState.Minimized
  End Sub

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

  Private Sub btnCensus_Click(sender As Object, e As EventArgs)
    'PanelManager.SetPanelVisibility(DockPanelLocation.MiddleBottom, btnCensus.Checked)
  End Sub

  ' Private Sub btnFileTabBack_MouseDown(sender As Object, e As MouseEventArgs)
  '   FilePanel.Visible = False
  'End Sub

  ' ==========================
  ' = App Toolbar - Event Handlers ==========================
  Private Sub btnHomeTree_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_OVERVIEW_TREE)
  End Sub

  Private Sub btnNotebook_Click(sender As Object, e As EventArgs)
    'PanelManager.SetPanelVisibility(DockPanelLocation.MiddleTopRight, btnNotebook.Checked)
  End Sub

  Private Sub btnPersonFact_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON)
  End Sub

  Private Sub btnPersonGallery_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON)
  End Sub

  Private Sub btnPersonHints_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON)
  End Sub

  Private Sub btnPersonStory_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_STORY_PERSON)
  End Sub

  Private Sub btnViewFan_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FANVIEW_PERSON)
  End Sub

  Private Sub btnViewPedigree_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_PEDIGREEVIEW_PERSON)
  End Sub

  Private Sub btnViewTree_Click(sender As Object, e As EventArgs)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_TREEVIEW_PERSON)
  End Sub

  Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
    My.Settings.Save()
    Close()
  End Sub

  Private Sub LoadSettings()
    ApplyTheme()
    DockManager.LoadSettings()
    Size = My.Settings.APP_CLIENTSIZE
  End Sub

  Private Sub RibbonBar_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles RibbonBar.Selecting
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

  Private Sub SaveSettings()
    DockManager.SaveSettings()
    My.Settings.APP_CLIENTSIZE = Size
  End Sub

#End Region

End Class