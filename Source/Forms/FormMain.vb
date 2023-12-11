﻿Imports System.ComponentModel
Imports System.IO
Imports AncestryAssistant.AncestorCollection

#Const RESET_SAVED_SETTINGS = False
#Const SHOW_DEBUG = True

Public Class AssistantAppForm

#Region "Fields"

  Private WithEvents Ancestors As AncestorCollection
  Private WithEvents Ancestry As WebBrowserPanelItem

  Private WithEvents FormExtensions As ResizeDragHandler

  Private WithEvents RibbonFileTab As RibbonPage

  Private Const ANCESTOR_CENSUS As String = "Download Census Data"

  Private Const ANCESTOR_NEW As String = "Add Ancestor To Assistant"

  Private Const ANCESTOR_UPDATED As String = "Apply Ancestor Changes To Assistant"

  Private Const FINDAGRAVE_IMAGE As String = "Download FindAGrave Image"

#End Region

#Region "Events"

  Public Event ActiveAncestorChanged()

  Public Event AncestorsUpdated()

#End Region

#Region "Public Constructors"

  Public Sub New()
#If RESET_SAVED_SETTINGS Then
    My.Settings.Reset()
    My.Settings.Save()
    End
#End If

    InitializeComponent()

    'Init the Ribbon Bar
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

    ' Init the Ancestors data repository
    Ancestors = New AncestorCollection(My.Settings.AncestorsPath)

    'Create and register all Panel Items

    Ancestry = New WebBrowserPanelItem With {
      .AncestryTreeID = My.Settings.ANCESTRY_TREE_ID
    }
    Ancestry.SetAncestors(Ancestors)
    ' Add Custom Handlers for Panel Item
    AddHandler Ancestry.ViewerBusy, AddressOf AncestryBrowserBusyChanged
    AddHandler Ancestry.UriTrackingGroupChanged, AddressOf AncestryURITrackingGroupChanged
    AddHandler Ancestry.DataDownload, AddressOf AncestryDataMessage
    ' Register PanelItem
    DockManager.RegisterDockItem(Ancestry)

    Dim item As DockPanelItem

    item = New AncestorsListPanelItem()
    item.SetAncestors(Ancestors)
    ' Add Custom Handlers for Panel Item
    AddHandler CType(item, AncestorsListPanelItem).AncestryNavigateRequest, AddressOf AncestryNavigateRequest
    ' Register PanelItem
    DockManager.RegisterDockItem(item)

    item = New AncestorPanelItem()
    item.SetAncestors(Ancestors)
    ' Register PanelItem
    DockManager.RegisterDockItem(item)

    item = New CensusPanelItem()
    item.SetAncestors(Ancestors)
    ' Register PanelItem
    DockManager.RegisterDockItem(item)

    item = New ImageGalleryPanelItem()
    item.SetAncestors(Ancestors)
    ' Register PanelItem
    DockManager.RegisterDockItem(item)

    item = New NotebookPanelItem()
    item.SetAncestors(Ancestors)
    ' Register PanelItem
    DockManager.RegisterDockItem(item)
    DockManager.SettingsLoad()

    Size = My.Settings.APP_CLIENTSIZE

    'Theme Data - Move all of this to the base assignments
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

#End Region

#Region "Private Methods"

  Private Sub Ancestors_ActiveAncestorChanged(ancestorId As String) Handles Ancestors.ActiveAncestorChanged
    Dim ancestor As AncestorCollection.Ancestor = Ancestors.ActiveAncestor

    RibbonBar.setItemAttribute(Ribbon.RibbonKey(200, 2, 7), RibbonItemAttribute.text, ancestor.GedBirthDate.toAssistantDate)
    RibbonBar.setItemAttribute(Ribbon.RibbonKey(200, 2, 8), RibbonItemAttribute.text, ancestor.GedDeathDate.toAssistantDate)
    RibbonBar.EnableGroup(Ribbon.RibbonKey(200, 2))
    RibbonBar.EnableGroup(Ribbon.RibbonKey(200, 3))
    RibbonBar.EnableGroup(Ribbon.RibbonKey(200, 4))
    RibbonBar.EnableGroup(Ribbon.RibbonKey(200, 5))

  End Sub

  Private Sub AncestryBrowserBusyChanged(busy As Boolean)
    If busy Then
      Cursor = Cursors.WaitCursor
    Else
      Cursor = Cursors.Default
      DockManager.ShowRegisteredItem(WebBrowserPanelItem.Default_Key)
    End If
  End Sub

  Private Sub AncestryDataMessage(msg As APIMessage)
    Dim ancestor As AncestorCollection.Ancestor = Ancestors.ActiveAncestor
    Logger.log(Logger.LOG_TYPE.ERR, msg.ToString)
    Select Case msg.MessageType
      Case APIMessage.MT_SAVEAS
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
            If Not Ancestors.ActiveAncestorID.Equals(msg.MessageKey) Then
              Ancestors.ActiveAncestorID = msg.MessageKey
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
        If Ancestors.HasActiveAncestor Then
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

  Private Sub AncestryNavigateRequest(SelectedAncestorID As String)
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON, Ancestors.ActiveAncestorID)
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

  Private Sub ApplicationForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    If WindowState <> FormWindowState.Normal Then
      WindowState = FormWindowState.Normal
    End If
    SettingsSave()
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

  Private Sub DockManager_PanelItemEvent(panelItem As DockPanelItem, eventType As DockPanelItemEventType) Handles DockManager.PanelItemEvent
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("FormMain.PanelItemEvent(panelItem=[{0}], eventType=[{1}])", panelItem.Name, eventType.ToString)
#End If
    Select Case eventType
      Case DockPanelItemEventType.ItemClosed
        If panelItem.ItemHasRibbonBar And panelItem.RibbonHideOnItemClose Then
          RibbonBar.HideBar(panelItem.RibbonBarKey)
        End If
      Case DockPanelItemEventType.ItemOpened
        If panelItem.ItemHasRibbonBar And panelItem.RibbonShowOnItemOpen Then
          RibbonBar.ShowBar(panelItem.RibbonBarKey)
        End If
      Case DockPanelItemEventType.ItemSelected
        If panelItem.ItemHasRibbonBar And panelItem.RibbonShowOnItemOpen Then
          RibbonBar.ShowBar(panelItem.RibbonBarKey)
        End If
    End Select
  End Sub

  Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
    SettingsSave()
    Close()
  End Sub

  Private Sub RibbonBar_RibbonAction(action As RibbonEventType, value As Object, barId As Integer, groupId As Integer, itemId As Integer) Handles RibbonBar.RibbonAction
    Logger.debugPrint("RibbonAction: {0}={1}    [{2}]", action.ToString, value, Ribbon.RibbonKey(barId, groupId, itemId))

    Select Case Ribbon.RibbonKey(barId, groupId, itemId)
      Case "B200.G5.I17" 'Census
        DockManager.ShowRegisteredItem(CensusPanelItem.Default_Key)
      Case "B200.G5.I18" 'Gallery
        DockManager.ShowRegisteredItem(ImageGalleryPanelItem.Default_Key)
      Case "B200.G5.I19" 'Notebook
        DockManager.ShowRegisteredItem(NotebookPanelItem.Default_Key)
      Case "B200.G3.I9" 'Facts
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON)
        DockManager.ShowRegisteredItem(WebBrowserPanelItem.Default_Key)
      Case "B200.G2"
        DockManager.ShowRegisteredItem(AncestorsListPanelItem.Default_Key)
      Case "ASSIGN" 'Ancestry Person Gallery
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON)
        DockManager.ShowRegisteredItem(WebBrowserPanelItem.Default_Key)
      Case "ASSIGN" 'Ancestry Person Hints
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON)
        DockManager.ShowRegisteredItem(WebBrowserPanelItem.Default_Key)
      Case "ASSIGN" 'Ancestry Person Story
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_STORY_PERSON)
        DockManager.ShowRegisteredItem(WebBrowserPanelItem.Default_Key)
      Case "B200.G3.I12" 'Ancestry Person Fan
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FANVIEW_PERSON)
        DockManager.ShowRegisteredItem(WebBrowserPanelItem.Default_Key)
      Case "B200.G3.I11" 'Ancestry Person Pedigree
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_PEDIGREEVIEW_PERSON)
        DockManager.ShowRegisteredItem(WebBrowserPanelItem.Default_Key)
      Case "B200.G3.I10" 'Ancestry Person Tree
        Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_TREEVIEW_PERSON)
        DockManager.ShowRegisteredItem(WebBrowserPanelItem.Default_Key)
    End Select
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

  Private Sub SettingsSave()
    DockManager.SettingsSave()
    My.Settings.APP_CLIENTSIZE = Size
    My.Settings.Save()
  End Sub

#End Region

End Class