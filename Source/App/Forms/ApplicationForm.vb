Imports System.ComponentModel
Imports System.IO
Imports AncestryAssistant.AncestorCollection



#Const SHOW_DEBUG = True

Public Class ApplicationForm

  Public Event ActiveAncestorChanged()
  Public Event AncestorsUpdated()

  Private Ancestors As AncestorCollection
  Private WithEvents AncestorAttributes As AncestorPanel
  Private WithEvents AncestorsList As AncestorsListPanel


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
    AncestryDirectorWatcher.EnableRaisingEvents = False
    Ancestors = New AncestorCollection(My.Settings.AncestorsPath)
    AncestorsList = New AncestorsListPanel()
    AncestorsList.setAncestors(Ancestors)
    UIUpdateState()
    AncestryDirectorWatcher.EnableRaisingEvents = True
  End Sub

  ' ==========================
  ' = Set Visual States
  ' ==========================
  Private Sub UIUpdateState(Optional sender As Object = Nothing, Optional e As EventArgs = Nothing) Handles btnAncestors.CheckedChanged, btnAncestor.CheckedChanged
    panelLeft(btnAncestor.Checked, btnAncestors.Checked)
    'If btnAncestor.Checked Or btnAncestors.Checked Then
    '  SplitPanel.Panel1Collapsed = Not btnAncestor.Checked
    '  SplitPanel.Panel2Collapsed = Not btnAncestors.Checked
    '  SplitPanel_Main.Panel1Collapsed = False
    'Else
    '  SplitPanel_Main.Panel1Collapsed = True
    'End If
  End Sub

#End Region

#Region "App Toolbar - Event Handlers"

  ' ==========================
  ' = App Toolbar - Event Handlers
  ' ==========================

  Private Sub btnHomeTree_Click(sender As Object, e As EventArgs) Handles btnHomeTree.Click
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_OVERVIEW_TREE)
  End Sub

  Private Sub btnViewPedigree_Click(sender As Object, e As EventArgs) Handles btnViewPedigree.Click
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_PEDIGREEVIEW_PERSON)
  End Sub

  Private Sub btnViewTree_Click(sender As Object, e As EventArgs) Handles btnViewTree.Click
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_TREEVIEW_PERSON)
  End Sub

  Private Sub btnViewFan_Click(sender As Object, e As EventArgs) Handles btnViewFan.Click
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FANVIEW_PERSON)
  End Sub

  Private Sub btnPersonFact_Click(sender As Object, e As EventArgs) Handles btnPersonFact.Click
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON)
  End Sub

  Private Sub btnPersonHints_Click(sender As Object, e As EventArgs) Handles btnPersonHints.Click
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON)
  End Sub

  Private Sub btnPersonGallery_Click(sender As Object, e As EventArgs) Handles btnPersonGallery.Click
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON)
  End Sub

  Private Sub btnPersonStory_Click(sender As Object, e As EventArgs) Handles btnPersonStory.Click
    Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_STORY_PERSON)
  End Sub

  Private Sub AncestryToolbarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AncestryToolbarToolStripMenuItem.Click
    Ancestry.ShowToolbar = AncestryToolbarToolStripMenuItem.Checked
  End Sub

#End Region

#Region "App Menu - Event Handlers"

  ' ==========================
  ' = App Menu - Event Handlers
  ' ==========================


  Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
    My.Settings.Save()
    Close()
  End Sub

#End Region

#Region "Viewer - Ancestors List"


  Private Sub AncestryDirectorWatcher_Changed(sender As Object, e As FileSystemEventArgs)
    Debug.Print("FILEWATCHER(Changed')=" & e.FullPath)
  End Sub

  Private Sub AncestryDirectorWatcher_Created(sender As Object, e As FileSystemEventArgs) Handles AncestryDirectorWatcher.Created
    Logger.log(Logger.LOG_TYPE.INFO, "FILEWATCHER(Created')=" & e.FullPath)
    RaiseEvent ActiveAncestorChanged()
    'TODO: LoadAncestorList()
  End Sub

#End Region

#Region "Viewer - Ancestry Web"

  ' ==========================
  ' = Viewer - Ancestry Web
  ' ==========================

  Private Sub Ancestry_ViewerBusy(busy As Boolean) Handles Ancestry.ViewerBusy
    If busy Then
      Cursor = Cursors.WaitCursor
      tabs.SelectTab(0)
    Else
      Cursor = Cursors.Default
    End If
  End Sub

  Private Sub Ancestry_UriTrackingGroupChanged(NewGroup As UriTrackingGroupEnum, OldGroup As UriTrackingGroupEnum) Handles Ancestry.UriTrackingGroupChanged
    If btnActions.Visible Then
      If NewGroup <> OldGroup Then
        btnActions.Visible = False
      End If
    End If
  End Sub

  Private Const ANCESTOR_NEW As String = "Add Ancestor To Assistant"
  Private Const ANCESTOR_UPDATED As String = "Apply Ancestor Changes To Assistant"
  Private Const ANCESTOR_CENSUS As String = "Download Census Data"
  Private Const ANCESTOR_IMAGE As String = "Download Image"
  Private Const FINDAGRAVE_IMAGE As String = "Download FindAGrave Image"

  Private Sub Ancestry_AncestryData(msg As APIMessage) Handles Ancestry.DataDownload
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
            With btnActions
              .Tag = msg
              .Text = ANCESTOR_NEW
              '.Image = My.Resources.ANCESTOR_ADD_WHITE
              .Enabled = True
              .Visible = True
            End With
          Else
            'If assistant ancestor is different, then change ancestors
            If Not AncestorId.Equals(msg.MessageKey) Then
              AncestorId = msg.MessageKey
            End If
            If Not Ancestors.Item(msg.MessageKey).AncestorMatchesMessage(msg) Then
              With btnActions
                .Tag = msg
                .Text = ANCESTOR_UPDATED
                '.Image = My.Resources.ANCESTOR_ADD_WHITE
                .Enabled = True
                .Visible = True
              End With
            End If
          End If
        End If
      Case APIMessage.MT_PAGE
        If msg.PageKey.Equals("FINDAGRAVE_VIEWER_IMAGE") And (msg.GetValue("PAGEKEY").EndsWith("jpg") Or msg.GetValue("PAGEKEY").EndsWith("jepg")) Then
          With btnActions
            .Tag = msg
            .Text = FINDAGRAVE_IMAGE
            '.Image = My.Resources.ANCESTOR_ADD_WHITE
            .Enabled = True
            .Visible = True
          End With
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
              With btnActions
                .Tag = msg
                .Text = ANCESTOR_CENSUS
                '.Image = My.Resources.ANCESTOR_ADD_WHITE
                .Enabled = True
                .Visible = True
              End With
            Else
              If msg.PageKey = "ANCESTRY_VIEWER_IMAGE" Then
                With btnActions
                  .Tag = msg
                  .Text = ANCESTOR_IMAGE
                  '.Image = My.Resources.ANCESTOR_ADD_WHITE
                  .Enabled = True
                  .Visible = True
                End With
              End If
            End If
          End If
        End If
      Case Else
        btnActions.Visible = False
    End Select
  End Sub

#End Region


  Private Sub btnActions_Click(sender As Object, e As EventArgs) Handles btnActions.Click
    btnActions.Visible = False
    If btnActions.Tag Is Nothing Then Exit Sub
    Dim msg As APIMessage = btnActions.Tag
    Select Case btnActions.Text
      Case ANCESTOR_NEW
        If Not Ancestors.ContainsKey(msg.MessageKey) Then
          If msg.MessageType = APIMessage.MT_PERSON Then
            Dim ancestor As AncestorCollection.Ancestor = Ancestors.newAncestor(msg.MessageKey)
            For Each fact As String In ancestor.AncestorFactList()
              ancestor.Fact(fact) = msg.GetValue(fact)
            Next
            AncestorId = msg.MessageKey
            RaiseEvent AncestorsUpdated()
          End If
        End If
      Case ANCESTOR_UPDATED
        Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
        For Each fact As String In ancestor.AncestorFactDifferences(msg)
          ancestor.Fact(fact) = msg.GetValue(fact)
        Next
        AncestorId = msg.MessageKey
        RaiseEvent AncestorsUpdated()
      Case ANCESTOR_CENSUS
        Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
        Dim imgFilename As String = ancestor.Census.addCensusData(msg)
        AncestorId = msg.MessageKey
        Ancestry.saveImageAs(imgFilename + ".jpg")
        RaiseEvent AncestorsUpdated()
      Case ANCESTOR_IMAGE
        Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
        Dim rslt As DialogResult
        Dim dlg As New SaveImageDetails
        dlg.InitDialog(msg)
        rslt = dlg.ShowDialog()
        If rslt = DialogResult.OK Then
          Dim i_type As String = dlg.ImageType.ToUpper
          Dim i_category As String = dlg.ImageCategory.ToUpper
          Dim i_summary As String = dlg.Summary
          Dim i_details As List(Of List(Of String)) = dlg.TableData
          If i_type.Equals("") Then i_type = "PHOTO"
          If i_category.Equals("") Then i_category = "OTHER"
          Dim filename As String = i_type & "-" & i_category & "-" & StrConv(i_summary, VbStrConv.ProperCase).Replace(" ", "")
          If filename.Length > 60 Then filename = filename.Substring(0, 60)
          Dim imgFilename As String = uniqueFilename(ancestor.FullPath("Gallery\" + filename), {"aa", "jpg.txt", "jpg"})
          File.WriteAllText(imgFilename + ".jpg.txt", dlg.Summary)
          Dim aa As AAFile = New AAFile(imgFilename + ".aa", AAFileTypeEnum.LISTARRAY)
          aa.setTableData(i_details)
          aa.Save()
          Ancestry.saveImageAs(imgFilename + ".jpg")
        End If
      Case FINDAGRAVE_IMAGE
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
          Ancestry.saveImageAs(imgFilename + ".jpg")
        End If
      Case Else

    End Select

  End Sub

  Private Function uniqueFilename(baseName As String, extensions() As String) As String
    Dim uni As String = ""
    Dim uniIdx As Integer = 0
    Dim isUnique As Boolean = False
    While Not isUnique
      isUnique = True
      For Each ext As String In extensions
        isUnique = isUnique And Not File.Exists(baseName + uni + "." + ext)
      Next
      If Not isUnique Then
        uniIdx += 1
        uni = "-" & uniIdx.ToString.PadLeft(3, "0")
      End If
    End While
    Return baseName + uni
  End Function

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
    CensusViewer1.SetAncestor(ancestor)
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
    btnAncestor.Checked = False
    UIUpdateState()
  End Sub

  Private Sub AncestorsList_PanelCloseClicked(sender As Object)
    btnAncestors.Checked = False
    UIUpdateState()
  End Sub

  Private Sub AncestryDirectorWatcher_Changed_1(sender As Object, e As FileSystemEventArgs) Handles AncestryDirectorWatcher.Changed
    Logger.log(Logger.LOG_TYPE.INFO, "FILEWATCHER(Changed')=" & e.FullPath)

  End Sub

  Private Sub AncestryDirectorWatcher_Deleted(sender As Object, e As FileSystemEventArgs) Handles AncestryDirectorWatcher.Deleted
    Logger.log(Logger.LOG_TYPE.INFO, "FILEWATCHER(Deleted')=" & e.FullPath)

  End Sub

  Private Sub AncestryDirectorWatcher_Error(sender As Object, e As ErrorEventArgs) Handles AncestryDirectorWatcher.[Error]
    Logger.log(Logger.LOG_TYPE.INFO, "FILEWATCHER([Error]')=" & e.GetException.Message)

  End Sub



  Private Sub panelRight(topVis As Boolean, botVis As Boolean)
    If pnlRightTop.Dock = DockStyle.Top Then
      pnlRightTop.Tag = pnlRightTop.Height
    End If
    If topVis And Not botVis Then
      pnlRightTop.Dock = DockStyle.Fill
    End If
    If topVis And botVis And pnlRightTop.Dock = DockStyle.Fill Then
      pnlRightTop.Dock = DockStyle.Top
      pnlRightTop.Height = CInt(pnlRightTop.Tag)
    End If

    pnlRightTop.Visible = topVis
    pnlRightBottom.Visible = botVis
    splitRight.Visible = topVis Or botVis
    splitRightTopBottom.Visible = topVis And botVis
    pnlRight.Visible = topVis Or botVis
  End Sub

  Private Sub panelLeft(topVis As Boolean, botVis As Boolean)
    If pnlLeftTop.Dock = DockStyle.Top Then
      pnlLeftTop.Tag = pnlLeftTop.Height
    End If
    If topVis And Not botVis Then
      pnlLeftTop.Dock = DockStyle.Fill
    End If
    If topVis And botVis And pnlLeftTop.Dock = DockStyle.Fill Then
      pnlLeftTop.Dock = DockStyle.Top
      pnlLeftTop.Height = CInt(pnlLeftTop.Tag)
    End If

    pnlLeftTop.Visible = topVis
    pnlLeftBottom.Visible = botVis
    splitLeft.Visible = topVis Or botVis
    splitLeftTopBottom.Visible = topVis And botVis
    pnlLeft.Visible = topVis Or botVis
  End Sub



  Private Sub panelMiddle(leftVis As Boolean, rightVis As Boolean, bottomVis As Boolean)
    If pnlMiddleRight.Dock = DockStyle.Right Then
      pnlMiddleRight.Tag = pnlMiddleRight.Width
    End If
    If rightVis And Not leftVis Then
      pnlMiddleRight.Dock = DockStyle.Fill
    End If
    If leftVis And rightVis And pnlMiddleRight.Dock = DockStyle.Fill Then
      pnlMiddleRight.Dock = DockStyle.Right
      pnlMiddleRight.Width = CInt(pnlMiddleRight.Tag)
    End If

    pnlMiddleBottom.Visible = bottomVis
    splitMiddleBottom.Visible = bottomVis
    pnlMiddleLeft.Visible = leftVis
    pnlMiddleRight.Visible = rightVis
    splitMiddleLeftRight.Visible = leftVis And rightVis
    btnCensus.Checked = pnlMiddleBottom.Visible
    btnNotebook.Checked = pnlMiddleRight.Visible
  End Sub

  Private Sub ApplicationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    LoadUIState()
    AncestorAttributes = New AncestorPanel
    Dim ctl As New ImageGallery()
    Dim ctl2 As New CensusViewer()
    dockMiddleRight.AddClient("Image Gallery", ctl)
    dockMiddleRight.AddClient("Census", ctl2)
    dockTopLeft.AddClient("Ancestor Attributes", AncestorAttributes)
    dockBottomLeft.AddClient("Ancestors List", AncestorsList)
  End Sub

  Private Sub LoadUIState()
    Dim lb_ctl As String = My.Settings.UI_LB_CTL
    Dim lt_ctl As String = My.Settings.UI_LT_CTL
    Dim ml_ctl As String = My.Settings.UI_ML_CTL

    pnlMiddleRight.Width = My.Settings.UI_MR_WIDTH
    pnlMiddleBottom.Height = My.Settings.UI_MB_HEIGHT
    panelMiddle(My.Settings.UI_ML_VIS, My.Settings.UI_MR_VIS, My.Settings.UI_MB_VIS)

    pnlLeft.Width = My.Settings.UI_L_WIDTH
    pnlLeftTop.Height = My.Settings.UI_LT_HEIGHT
    panelLeft(My.Settings.UI_LT_VIS, My.Settings.UI_LB_VIS)

    pnlRight.Width = My.Settings.UI_R_WIDTH
    pnlRightTop.Height = My.Settings.UI_RT_HEIGHT
    panelRight(My.Settings.UI_RT_VIS, My.Settings.UI_RB_VIS)
  End Sub

  Private Sub SaveUIState()
    My.Settings.UI_MR_WIDTH = pnlMiddleRight.Width
    My.Settings.UI_MB_HEIGHT = pnlMiddleBottom.Height
    My.Settings.UI_ML_VIS = pnlMiddleLeft.Visible
    My.Settings.UI_MR_VIS = pnlMiddleRight.Visible
    My.Settings.UI_MB_VIS = pnlMiddleBottom.Visible

    My.Settings.UI_L_WIDTH = pnlLeft.Width
    My.Settings.UI_LT_HEIGHT = pnlLeftTop.Height
    My.Settings.UI_LT_VIS = pnlLeftTop.Visible
    My.Settings.UI_LB_VIS = pnlLeftBottom.Visible

    My.Settings.UI_R_WIDTH = pnlRight.Width
    My.Settings.UI_RT_HEIGHT = pnlRightTop.Height
    My.Settings.UI_RT_VIS = pnlRightTop.Visible
    My.Settings.UI_RB_VIS = pnlRightBottom.Visible
  End Sub

  Private Sub ApplicationForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
    SaveUIState()
  End Sub

  Private Sub btnCensus_Click(sender As Object, e As EventArgs) Handles btnCensus.Click
    panelMiddle(pnlMiddleLeft.Visible, pnlMiddleRight.Visible, btnCensus.Checked)
  End Sub

  Private Sub btnNotebook_Click(sender As Object, e As EventArgs) Handles btnNotebook.Click
    panelMiddle(pnlMiddleLeft.Visible, btnNotebook.Checked, pnlMiddleBottom.Visible)
  End Sub
End Class