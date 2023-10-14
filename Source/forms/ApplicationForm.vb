Imports System.ComponentModel
Imports System.IO
Imports Microsoft.Web.WebView2.Core

#Const SHOW_DEBUG = False

Public Class ApplicationForm
  Private WithEvents ancestry As WebHandler
  Private activeAncestor As Ancestor

  Public Sub New()
    InitializeComponent()
    InitializeAncestorDetail()
    InitializeAncestorList()
    ' Setup Ancestor Object
    activeAncestor = New Ancestor
    ' Setup Ancestry Web Handler
    ancestry = New WebHandler(web)
    ' Open Home Tree
    ancestry.NavigateTo(URLTypeEnum.TREE_HOME)
  End Sub

  ' ==========================
  ' = Form Event Handlers
  ' ==========================
  Private Sub ApplicationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    With lblBirthYear
      .Text = ""
      .Tag = ""
      .Visible = False
    End With
    With lblPersonName
      .Text = ""
      .Tag = ""
      .Visible = False
    End With
    With lblStatus
      .Text = ""
      .Tag = ""
      .Visible = True
    End With
    With lblID
      .Text = ""
      .Tag = ""
      .Visible = False
    End With
    LoadAncestorList()
    SetUIState()
  End Sub

  ' ==========================
  ' = Ancestry Event Handlers
  ' ==========================
  Private Sub ancestry_StatusBarChanged(text As String) Handles ancestry.StatusChanged
    lblStatus.Text = text
    SetUIState()
  End Sub

  Private Sub ancestry_PageChanged(wasPage As String, toPage As String) Handles ancestry.PageChanged
    SetUIState()
  End Sub

  Private Sub ancestry_SourceChanged(sourceString As String) Handles ancestry.SourceChanged
    txtHref.Text = sourceString
    SetUIState()
  End Sub

  Private Sub ancestry_AncestorChanged(newAncestor As Ancestor) Handles ancestry.AncestorChanged
    activeAncestor = newAncestor
    SetUIState()
  End Sub

  Private Sub ancestry_ImageDownload(fromPage As String, filename As String) Handles ancestry.ImageDownload
    If activeAncestor.IsValid Then
      activeAncestor.createPath()
      If fromPage.StartsWith("Census") Then
        fromPage += ".jpg"
        If File.Exists(activeAncestor.Path & fromPage) Then
          Dim rslt As MsgBoxResult
          rslt = MsgBox("File Already Exists" & vbCrLf & fromPage & vbCrLf & "Replace?", vbCritical Or vbYesNoCancel, "File Exists")
          Select Case rslt
            Case MsgBoxResult.Yes
              File.Delete(activeAncestor.Path & fromPage)
            Case Else
              File.Delete(filename)
              Exit Sub
          End Select
        End If
        File.Move(filename, activeAncestor.Path & fromPage)
      Else
        Dim frm As ImageSaveDialog = New ImageSaveDialog()
        frm.DstDir = activeAncestor.Path
        frm.SrcFilename = filename
        frm.SrcPage = fromPage
        frm.Show()
      End If
    End If
    SetUIState()
  End Sub

  Private Sub ancestry_AncestryData(dataType As DataTypeEnum, ancestryData As Object) Handles ancestry.DataChanged
    If activeAncestor.IsValid Then
      activeAncestor.createPath()
      saveFile(activeAncestor.ID, activeAncestor.Path, "Ancestry.id", False)
      Select Case dataType
        Case DataTypeEnum.anFACTDATA
          Dim data As Array = ancestryData
          saveCSV(data, activeAncestor.Path, "Timeline.csv")
        Case DataTypeEnum.anSOURCEDATA
          Dim data As Array = ancestryData
          saveCSV(data, activeAncestor.Path, "Sources.csv")
        Case DataTypeEnum.anFAMILYDATA
          Dim data As Array = ancestryData
          saveCSV(data, activeAncestor.Path, "Family.csv")
        Case DataTypeEnum.anCENSUSDATA
          Dim data As Array = ancestryData
          Dim year As String = data(1)(0).ToString
          Dim page As String = data(1)(1).ToString
          saveCSV(data, activeAncestor.Path, "Census-" & year & "-p" & page & ".csv")
        Case DataTypeEnum.anPROFILEDATA
          Dim data As String = ancestryData
          saveFile(data, activeAncestor.Path, "Profile.txt")
        Case Else

      End Select
    End If
    SetUIState()
  End Sub

  ' ==========================
  ' = Ancestors List
  ' ==========================
  Private Sub InitializeAncestorList()
    With AncestorsList
      .Tag = ""
      .Items.Clear()
      .Columns.Clear()
      .Columns.Add("Name", CInt(.Width / 2))
      .Columns.Add("Birth Year", CInt(.Width / 2))
      .Groups.Clear()
    End With
  End Sub

  Private Sub LoadAncestorList()
    Dim item As ListViewItem
    With AncestorsList
      .Tag = ""
      .Items.Clear()
      Dim dirs() As String = Directory.GetDirectories(My.Settings.AncestorsPath)
      For Each dir As String In dirs
        Dim dirname As String = dir.Replace(My.Settings.AncestorsPath, "")
        Dim p() As String = dirname.Split("-")
        If p.Length() > 0 Then
          item = .Items.Add(p(0).Trim())
          item.SubItems.Add(p(1).Trim())
          If File.Exists(dir + "\Ancestry.id") Then
            item.Tag = File.ReadAllLines(dir + "\Ancestry.id")(0).Trim
          Else
            item.Tag = ""
          End If
        End If
      Next
    End With
  End Sub

  ' ==========================
  ' = Ancestor Details
  ' ==========================
  Private Sub InitializeAncestorDetail()
    With AncestorDetails
      .Tag = ""
      .Items.Clear()
      .Columns.Clear()
      .Columns.Add("Property", CInt(.Width / 2))
      .Columns.Add("Value", CInt(.Width / 2))
      .Groups.Clear()
      .Groups.Add(New ListViewGroup("ANCESTOR", "Ancestor"))
      .Groups.Add(New ListViewGroup("BIRTH", "Birth"))
      .Groups.Add(New ListViewGroup("DEATH", "Death"))
      .Groups.Add(New ListViewGroup("PARENTS", "Parents"))
      .Groups.Add(New ListViewGroup("SIBLINGS", "Siblings"))
      .Groups.Add(New ListViewGroup("MARRIAGE", "Marriages"))
      .Groups.Add(New ListViewGroup("CHILDREN", "Children"))
      .Groups.Add(New ListViewGroup("CENSUS", "Census"))
      .Groups.Add(New ListViewGroup("IMAGES", "Images"))
    End With
  End Sub

  Private Function getAncestorDetails(Optional workingAncestor As Ancestor = Nothing) As ArrayList
    Dim details As ArrayList = New ArrayList
    If workingAncestor Is Nothing Then workingAncestor = activeAncestor
    If workingAncestor.IsValid Then

      details.Add({"AncestryID", workingAncestor.IDFromFile, "ANCESTOR", "N", ""})
      details.Add({"Surname", workingAncestor.Surname, "ANCESTOR", "N", ""})
      details.Add({"Given", workingAncestor.Givenname, "ANCESTOR", "N", ""})
      details.Add({"HasProfileImage", workingAncestor.hasProfileImage, "ANCESTOR", "Y", ""})

      details.Add({"Date", workingAncestor.ProfileBirthDate, "BIRTH", "N", "CAL_BLACK"})
      details.Add({"Place", workingAncestor.ProfileBirthPlace, "BIRTH", "N", "LOCATION_BLACK"})
      details.Add({"HasCertificateImage", workingAncestor.hasBirthCertificate, "BIRTH", "Y", ""})


      details.Add({"Date", workingAncestor.ProfileDeathDate, "DEATH", "N", "CAL_BLACK"})
      details.Add({"Place", workingAncestor.ProfileDeathPlace, "DEATH", "N", "LOCATION_BLACK"})
      details.Add({"HasCertificateImage", workingAncestor.hasDeathCertificate, "DEATH", "Y", ""})
      details.Add({"HasHeadstoneImage", workingAncestor.hasHeadstoneImage, "DEATH", "Y", ""})
      'Census
      Dim aCensus As ArrayList = workingAncestor.getCensusList()
      Dim byear As Integer = Val(workingAncestor.BirthYear)
      Dim dyear As Integer = Val(workingAncestor.DeathYear)
      If byear > 0 Then
        If dyear = 0 Then dyear = byear + 90
        Dim census() As Integer = {1950, 1940, 1930, 1920, 1910, 1900, 1890, 1880, 1870, 1860, 1850, 1840, 1830, 1820, 1810, 1800, 1790}
        For Each dt As Integer In census
          If byear <= dt And dyear >= dt Then
            details.Add({dt & " Census", aCensus.Contains(dt.ToString), "CENSUS", "Y", ""})
          End If
        Next
      End If

    End If
    Return details
  End Function

  Private Sub LoadAncestorTree()
    Debug.Print("LoadAncestorTree: TAG=" & AncestorDetails.Tag)
    If activeAncestor.IsValid Then
      Debug.Print("LoadAncestorTree: VALID")
      If AncestorDetails.Tag Is Nothing Then AncestorDetails.Tag = 0
      Dim details As ArrayList = getAncestorDetails()
      Dim newTag As Double = 0
      For Each detail() As Object In details
        newTag += detail(2).ToString().GetHashCode And detail(1).ToString().GetHashCode And detail(0).ToString().GetHashCode
      Next
      Debug.Print("LoadAncestorTree: NEWTAG=" & newTag)
      If newTag = AncestorDetails.Tag Then
        Debug.Print("LoadAncestorTree: NOCHANGE")
        Exit Sub
      End If
      Debug.Print("LoadAncestorTree: RELOADING")
      AncestorDetails.Tag = newTag
      Dim hasProfile As Boolean = activeAncestor.PathExists
      With AncestorDetails
        If hasProfile Then
          .ForeColor = Color.Black
        Else
          .ForeColor = Color.Red
        End If
        .Items.Clear()
        For Each detail() As Object In details
          '   0         1                               2       3          4
          '{"Date", workingAncestor.ProfileBirthDate, "BIRTH", "N", "CAL_BLACK"}
          Dim item As ListViewItem = New ListViewItem(detail(0).ToString)
          If Not detail(2).ToString.Equals("") Then
            item.Group = .Groups.Item(detail(2).ToString)
          End If
          If detail(3).ToString.Equals("Y") Then
            If detail(1) Then
              item.SubItems.Add("Have")
            Else
              item.ForeColor = Color.Red
              item.SubItems.Add("Missing")
            End If
          Else
            If detail(1).ToString.Length > 0 Then
              item.SubItems.Add(detail(1).ToString)
            Else
              item.ForeColor = Color.Red
              item.SubItems.Add("Missing")
            End If
          End If
          If Not detail(4).ToString.Equals("") Then
            item.ImageKey = details(4).ToString
          End If
          .Items.Add(item)
        Next
      End With
    Else
      Debug.Print("LoadAncestorTree: INVALID")
      'AncestorTree.Items.Clear()
      AncestorDetails.Tag = 0
    End If
  End Sub

  ' ==========================
  ' = Set Visual States
  ' ==========================

  Private Sub SetUIState()
    Dim haveActiveAncestor As Boolean = activeAncestor.IsValid

    ' Manage the Panels
    Dim RP1 As Boolean = False, RP2 As Boolean = False, GP2 As Boolean = False, BP1 As Boolean = False, BP2 As Boolean = False

    LoadAncestorTree()

    RP1 = btnAncestor.Checked
    RP2 = btnAncestors.Checked
    GP2 = ToolStripButton1.Checked
    BP1 = ToolStripButton2.Checked
    BP2 = ToolStripButton3.Checked

    'RED
    If RP1 Or RP2 Then
      SplitLeft.Panel1Collapsed = Not RP1
      SplitLeft.Panel2Collapsed = Not RP2
      SplitLeft_Middle.Panel1Collapsed = False
    Else
      SplitLeft_Middle.Panel1Collapsed = True
    End If
    'GREEN
    SplitMiddle.Panel2Collapsed = Not GP2
    'BLUE
    If BP1 Or BP2 Then
      SplitRight.Panel1Collapsed = Not BP1
      SplitRight.Panel2Collapsed = Not BP2
      SplitLeftMiddle_Right.Panel2Collapsed = False
    Else
      SplitLeftMiddle_Right.Panel2Collapsed = True
    End If


    ' Apply ActiveAncestor data
    lblID.Visible = activeAncestor.ID.Length > 3
    lblPersonName.Visible = activeAncestor.Name.Length > 3
    lblBirthYear.Visible = activeAncestor.BirthYear.Length = 4

    If lblPersonName.Visible Then
      If activeAncestor.PathExists Then
        lblPersonName.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__75
      Else
        lblPersonName.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_red__75
      End If
    End If


    lblID.Text = activeAncestor.ID
    lblPersonName.Text = activeAncestor.Name
    lblBirthYear.Text = activeAncestor.BirthYear

    ' Apply Menubar state
    Dim e As Boolean
    e = txtHref.Text.Contains("mediaui-viewer") Or lblStatus.Text.Contains("Census") Or lblStatus.Text.Contains("Fact") Or txtHref.Text.EndsWith("jpg") Or txtHref.Text.EndsWith("jpeg")
    btnDownload.Enabled = e And lblID.Visible And lblBirthYear.Visible And lblPersonName.Visible
    btnPersonFact.Enabled = lblID.Visible
    btnPersonGallery.Enabled = lblID.Visible
    btnPersonHints.Enabled = lblID.Visible
    btnPersonStory.Enabled = lblID.Visible
  End Sub


  ' ==========================
  ' = Panel Event Handlers
  ' ==========================
  Private Sub JDockPanelHeader1_HeaderCloseClicked() Handles JDockPanelHeader1.HeaderCloseClicked
    btnAncestor.Checked = False
    SetUIState()
  End Sub

  Private Sub JDockPanelHeader2_HeaderCloseClicked() Handles JDockPanelHeader2.HeaderCloseClicked
    btnAncestors.Checked = False
    SetUIState()
  End Sub

  ' ==========================
  ' = Menubar Event Handlers
  ' ==========================
  Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
    If lblStatus.Text.Contains("Fact") Then
      ancestry.capture(AncestryCaptureType.ANCESTOR)
    End If
    If lblStatus.Text.Contains("Census") Then
      ancestry.capture(AncestryCaptureType.CENSUS)
      ancestry.capture(AncestryCaptureType.CENSUS_IMAGE)
    End If
    If txtHref.Text.EndsWith("jpg") Or txtHref.Text.EndsWith("jpeg") Then
      ancestry.capture(AncestryCaptureType.IMAGE)
    End If
    If txtHref.Text.Contains("mediaui-viewer") Then
      ancestry.capture(AncestryCaptureType.GALLERY_IMAGE)
    End If
  End Sub

  Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
    web.GoBack()
  End Sub

  Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
    ancestry.Refresh()
  End Sub

  Private Sub btnHome_Click_1(sender As Object, e As EventArgs) Handles btnHome.Click
    ancestry.NavigateTo(URLTypeEnum.HOME)
  End Sub

  Private Sub btnHomeTree_Click(sender As Object, e As EventArgs) Handles btnHomeTree.Click
    ancestry.NavigateTo(URLTypeEnum.TREE_HOME)
  End Sub

  Private Sub btnViewPedigree_Click(sender As Object, e As EventArgs) Handles btnViewPedigree.Click
    ancestry.NavigateTo(URLTypeEnum.TREE_HORIZONTAL)
  End Sub

  Private Sub btnViewTree_Click(sender As Object, e As EventArgs) Handles btnViewTree.Click
    ancestry.NavigateTo(URLTypeEnum.TREE_VERTICAL)
  End Sub

  Private Sub btnViewFan_Click(sender As Object, e As EventArgs) Handles btnViewFan.Click
    ancestry.NavigateTo(URLTypeEnum.TREE_FAN)
  End Sub

  Private Sub btnPersonFact_Click(sender As Object, e As EventArgs) Handles btnPersonFact.Click
    ancestry.NavigateTo(URLTypeEnum.PERSON_FACTS)
  End Sub

  Private Sub btnPersonHints_Click(sender As Object, e As EventArgs) Handles btnPersonHints.Click
    ancestry.NavigateTo(URLTypeEnum.PERSON_HINTS)
  End Sub

  Private Sub btnPersonGallery_Click(sender As Object, e As EventArgs) Handles btnPersonGallery.Click
    ancestry.NavigateTo(URLTypeEnum.PERSON_GALLERY)
  End Sub

  Private Sub btnPersonStory_Click(sender As Object, e As EventArgs) Handles btnPersonStory.Click
    ancestry.NavigateTo(URLTypeEnum.PERSON_STORY)
  End Sub

  Private Sub txtHref_Enter(sender As Object, e As EventArgs) Handles txtHref.Enter
    ancestry.NavigateTo(URLTypeEnum.CUSTOM, txtHref.Text)
  End Sub

  Private Sub btnAncestor_Click(sender As Object, e As EventArgs) Handles btnAncestor.Click
    SetUIState()
  End Sub

  Private Sub btnAncestors_Click(sender As Object, e As EventArgs) Handles btnAncestors.Click
    SetUIState()

  End Sub

  Private Sub tsWeb_Resize(sender As Object, e As EventArgs) Handles tsWeb.Resize
    txtHref.Width = tsWeb.Bounds.Width - btnHome.Bounds.Right - 46
    'tsWeb.Refresh()
  End Sub

  Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
    SetUIState()

  End Sub

  Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
    SetUIState()

  End Sub

  Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
    SetUIState()

  End Sub

  Private Sub AncestryDirectorWatcher_Created(sender As Object, e As FileSystemEventArgs) Handles AncestryDirectorWatcher.Created
    LoadAncestorList()
  End Sub

  Private Sub AncestryDirectorWatcher_Deleted(sender As Object, e As FileSystemEventArgs) Handles AncestryDirectorWatcher.Deleted
    LoadAncestorList()
  End Sub

  Private Sub AncestryDirectorWatcher_Renamed(sender As Object, e As RenamedEventArgs) Handles AncestryDirectorWatcher.Renamed
    LoadAncestorList()
  End Sub


  Private Sub mnuDockBottomLeft_Click(sender As Object, e As EventArgs) Handles mnuDockBottomLeft.Click
    Debug.Print("mnuDockBottomLeft_Click")
  End Sub

  Private Sub mnuDockTopLeft_Click(sender As Object, e As EventArgs) Handles mnuDockTopLeft.Click
    Debug.Print("mnuDockTopLeft_Click")

  End Sub

  Private Sub mnuDockTopRight_Click(sender As Object, e As EventArgs) Handles mnuDockTopRight.Click
    Debug.Print("mnuDockTopRight_Click")

  End Sub

  Private Sub mnuDockBottomMiddle_Click(sender As Object, e As EventArgs) Handles mnuDockBottomMiddle.Click
    Debug.Print("mnuDockBottomMiddle_Click")

  End Sub

  Private Sub mnuDockBottomRight_Click(sender As Object, e As EventArgs) Handles mnuDockBottomRight.Click
    Debug.Print("mnuDockBottomRight_Click")

  End Sub

  Private Sub JDockPanelHeader1_ContextMenuChanged(sender As Object, e As EventArgs) Handles JDockPanelHeader1.ContextMenuChanged
    Debug.Print("JDockPanelHeader1_ContextMenuChanged")
  End Sub

  Private Sub JDockPanelHeader1_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles JDockPanelHeader1.ContextMenuStripChanged
    Debug.Print("JDockPanelHeader1_ContextMenuStripChanged")

  End Sub

  Private Sub mnuPanelDock_Opening(sender As Object, e As CancelEventArgs) Handles mnuPanelDock.Opening
    Debug.Print("mnuPanelDock_Opening: " & sender.SourceControl.tag)

  End Sub

  Private Sub mnuPanelDock_Opened(sender As Object, e As EventArgs) Handles mnuPanelDock.Opened
    Debug.Print("mnuPanelDock_Opened")

  End Sub

  Private Sub mnuPanelDock_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles mnuPanelDock.ItemClicked
    Debug.Print("mnuPanelDock_ItemClicked")

  End Sub

  Private Sub mnuPanelDock_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles mnuPanelDock.Closed
    Debug.Print("mnuPanelDock_Closed")

  End Sub

  Private Sub mnuPanelDock_Closing(sender As Object, e As ToolStripDropDownClosingEventArgs) Handles mnuPanelDock.Closing
    Debug.Print("mnuPanelDock_Closing")

  End Sub

  Private Sub mnuPanelDock_BindingContextChanged(sender As Object, e As EventArgs) Handles mnuPanelDock.BindingContextChanged
    Debug.Print("mnuPanelDock_BindingContextChanged")

  End Sub

  Private Sub mnuPanelDock_ParentChanged(sender As Object, e As EventArgs) Handles mnuPanelDock.ParentChanged
    Debug.Print("mnuPanelDock_ParentChanged")
  End Sub


  Private Sub AncestorsList_DoubleClick(sender As Object, e As EventArgs) Handles AncestorsList.DoubleClick
    Dim id As String = AncestorsList.SelectedItems.Item(0).Tag
    If Not id.Equals("") Then
      ancestry.NavigateTo(URLTypeEnum.PERSON_FACTS, id)
    End If
  End Sub

  Private Sub web_NavigationStarting(sender As Object, e As CoreWebView2NavigationStartingEventArgs) Handles web.NavigationStarting
    Cursor = Cursors.WaitCursor
  End Sub

  Private Sub web_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles web.NavigationCompleted
    Cursor = Cursors.Default
  End Sub
End Class
