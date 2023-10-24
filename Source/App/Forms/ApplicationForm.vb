Imports System.IO

#Const SHOW_DEBUG = False

Public Class ApplicationForm

  Public Event ValidActiveAncestor()

  Private _activeAncestor As AncestorCollection.Ancestor = Nothing

  Property activeAncestor As AncestorCollection.Ancestor
    Get
      Return _activeAncestor
    End Get
    Set(value As AncestorCollection.Ancestor)
      _activeAncestor = value
      If _activeAncestor.IsValid Then
        RaiseEvent ValidActiveAncestor()
      End If
    End Set
  End Property

#Region "App Form - Event Handlers"

  ' ==========================
  ' = App Form - Event Handlers
  ' ==========================

  Public Sub New()
    InitializeComponent()
    InitializeAncestorDetail()
    InitializeAncestorList()
    InitializeImageGallery()
    SetUIState()
    ' Setup Ancestor Object
    ' Open Home Tree
    'ancestry.NavigateTo(URLTypeEnum.TREE_HOME)
  End Sub

  Private Sub ApplicationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    LoadAncestorList()
  End Sub

  ' ==========================
  ' = Set Visual States
  ' ==========================
  Private Sub SetSplitterState()
    If btnAncestor.Checked Or btnAncestors.Checked Then
      SplitPanel.Panel1Collapsed = Not btnAncestor.Checked
      SplitPanel.Panel2Collapsed = Not btnAncestors.Checked
      SplitPanel_Main.Panel1Collapsed = False
    Else
      SplitPanel_Main.Panel1Collapsed = True
    End If
  End Sub

  Private Sub SetUIState()
    SetSplitterState()
    SetToolbarState()
    SetGalleryState()
  End Sub

#End Region

#Region "App Toolbar - Event Handlers"

  ' ==========================
  ' = App Toolbar - Event Handlers
  ' ==========================

  Private Sub SetToolbarState()
    'Dim isIDValid As Boolean = activeAncestor.ID.Length > 3
    'btnPersonFact.Enabled = isIDValid
    'btnPersonGallery.Enabled = isIDValid
    'btnPersonHints.Enabled = isIDValid
    'btnPersonStory.Enabled = isIDValid
  End Sub

  Private Sub btnHomeTree_Click(sender As Object, e As EventArgs) Handles btnHomeTree.Click
    Ancestry.NavigateTo(URLTypeEnum.TREE_HOME)
  End Sub

  Private Sub btnViewPedigree_Click(sender As Object, e As EventArgs) Handles btnViewPedigree.Click
    Ancestry.NavigateTo(URLTypeEnum.TREE_HORIZONTAL)
  End Sub

  Private Sub btnViewTree_Click(sender As Object, e As EventArgs) Handles btnViewTree.Click
    Ancestry.NavigateTo(URLTypeEnum.TREE_VERTICAL)
  End Sub

  Private Sub btnViewFan_Click(sender As Object, e As EventArgs) Handles btnViewFan.Click
    Ancestry.NavigateTo(URLTypeEnum.TREE_FAN)
  End Sub

  Private Sub btnPersonFact_Click(sender As Object, e As EventArgs) Handles btnPersonFact.Click
    Ancestry.NavigateTo(URLTypeEnum.PERSON_FACTS)
  End Sub

  Private Sub btnPersonHints_Click(sender As Object, e As EventArgs) Handles btnPersonHints.Click
    Ancestry.NavigateTo(URLTypeEnum.PERSON_HINTS)
  End Sub

  Private Sub btnPersonGallery_Click(sender As Object, e As EventArgs) Handles btnPersonGallery.Click
    Ancestry.NavigateTo(URLTypeEnum.PERSON_GALLERY)
  End Sub

  Private Sub btnPersonStory_Click(sender As Object, e As EventArgs) Handles btnPersonStory.Click
    Ancestry.NavigateTo(URLTypeEnum.PERSON_STORY)
  End Sub

  Private Sub AncestryToolbarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AncestryToolbarToolStripMenuItem.Click
    Ancestry.ShowToolbar = AncestryToolbarToolStripMenuItem.Checked
  End Sub

  Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click

  End Sub

#End Region

#Region "App Menu - Event Handlers"

  ' ==========================
  ' = App Menu - Event Handlers
  ' ==========================

  Private Sub menuStateHandler(sender As Object, e As EventArgs) Handles btnAncestor.Click, btnAncestors.Click
    SetUIState()
  End Sub

  Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
    My.Settings.Save()
    Close()
  End Sub

#End Region

#Region "Viewer - Ancestor"

  ' ==========================
  ' = Viewer - Ancestor
  ' ==========================
  Private Sub JDockPanelHeader1_HeaderCloseClicked() Handles JDockPanelHeader1.HeaderCloseClicked
    btnAncestor.Checked = False
    SetUIState()
  End Sub

  Private Sub InitializeAncestorDetail()
    'With AncestorDetails
    '  .Tag = ""
    '  .Items.Clear()
    '  .Columns.Clear()
    '  .Columns.Add("Property", CInt(.Width / 2))
    '  .Columns.Add("Value", CInt(.Width / 2))
    '  .Groups.Clear()
    '  .Groups.Add(New ListViewGroup("ANCESTOR", "Ancestor"))
    '  .Groups.Add(New ListViewGroup("BIRTH", "Birth"))
    '  .Groups.Add(New ListViewGroup("DEATH", "Death"))
    '  .Groups.Add(New ListViewGroup("PARENTS", "Parents"))
    '  .Groups.Add(New ListViewGroup("SIBLINGS", "Siblings"))
    '  .Groups.Add(New ListViewGroup("MARRIAGE", "Marriages"))
    '  .Groups.Add(New ListViewGroup("CHILDREN", "Children"))
    '  .Groups.Add(New ListViewGroup("CENSUS", "Census"))
    '  .Groups.Add(New ListViewGroup("IMAGES", "Images"))
    'End With
  End Sub

  Private Function getAncestorDetails(Optional workingAncestor As AncestorCollection.Ancestor = Nothing) As ArrayList
    Dim details As ArrayList = New ArrayList
    'If workingAncestor Is Nothing Then workingAncestor = activeAncestor
    'If workingAncestor.IsValid Then
    '  LoadAncestorAttributes(workingAncestor)
    '  details.Add({"AncestryID", workingAncestor.IDFromProfile, "ANCESTOR", "N", ""})
    '  details.Add({"Surname", workingAncestor.Surname, "ANCESTOR", "N", ""})
    '  details.Add({"Given", workingAncestor.Givenname, "ANCESTOR", "N", ""})
    '  details.Add({"HasProfileImage", workingAncestor.HasProfileImage, "ANCESTOR", "Y", ""})

    '  details.Add({"Date", workingAncestor.ProfileBirthDate, "BIRTH", "N", "CAL_BLACK"})
    '  details.Add({"Place", workingAncestor.ProfileBirthPlace, "BIRTH", "N", "LOCATION_BLACK"})
    '  details.Add({"HasCertificateImage", workingAncestor.hasBirthCertificate, "BIRTH", "Y", ""})

    '  details.Add({"Date", workingAncestor.ProfileDeathDate, "DEATH", "N", "CAL_BLACK"})
    '  details.Add({"Place", workingAncestor.ProfileDeathPlace, "DEATH", "N", "LOCATION_BLACK"})
    '  details.Add({"HasCertificateImage", workingAncestor.hasDeathCertificate, "DEATH", "Y", ""})
    '  details.Add({"HasHeadstoneImage", workingAncestor.hasHeadstoneImage, "DEATH", "Y", ""})
    '  'Census
    '  Dim aCensus As ArrayList = workingAncestor.getCensusList()
    '  Dim byear As Integer = Val(workingAncestor.BirthYear)
    '  Dim dyear As Integer = Val(workingAncestor.DeathYear)
    '  If byear > 0 Then
    '    If dyear = 0 Then dyear = byear + 90
    '    Dim census() As Integer = {1950, 1940, 1930, 1920, 1910, 1900, 1890, 1880, 1870, 1860, 1850, 1840, 1830, 1820, 1810, 1800, 1790}
    '    For Each dt As Integer In census
    '      If byear <= dt And dyear >= dt Then
    '        details.Add({dt & " Census", aCensus.Contains(dt.ToString), "CENSUS", "Y", ""})
    '      End If
    '    Next
    '  End If

    'End If
    Return details
  End Function

  Private Sub LoadAncestorAttributes(workingAncestor As AncestorCollection.Ancestor)
    AncestorAttributes.DrawMode = TreeViewDrawMode.OwnerDrawText
    AncestorAttributes.Nodes.Clear()
    'Dim item As TreeNode
    'item = AncestorAttributes.Nodes.Add("NAME", "Name" & vbTab & workingAncestor.Name, "", "")
    'item.Nodes.Add("SURNAME", "Surname" & vbTab & workingAncestor.Surname)
    'item.Nodes.Add("GIVENNAME", "Givenname" & vbTab & workingAncestor.Givenname)

    'item = AncestorAttributes.Nodes.Add("ID", "Research", "", "")
    'item.Nodes.Add("ANCESTRYID", "Ancestry.com" & vbTab & workingAncestor.IDFromProfile)

    'item = AncestorAttributes.Nodes.Add("PROFILEIMG", "HasProfileImage" & vbTab & workingAncestor.HasProfileImage, "", "")

    'item = AncestorAttributes.Nodes.Add("BIRTH", "Birth" & vbTab & workingAncestor.ProfileBirthDate, "", "")
    'item.Nodes.Add("BIRTHPLACE", "Place" & vbTab & workingAncestor.ProfileBirthPlace)
    'item.Nodes.Add("BIRTHDOCUMENTS", "HasDocuments" & vbTab & workingAncestor.hasBirthCertificate)

    'item = AncestorAttributes.Nodes.Add("DEATH", "Death" & vbTab & workingAncestor.ProfileDeathDate, "", "")
    'item.Nodes.Add("DEATHPLACE", "Place" & vbTab & workingAncestor.ProfileDeathPlace)
    'item.Nodes.Add("DEATHDOCUMENTS", "HasDocuments" & vbTab & workingAncestor.hasDeathCertificate)
    'item.Nodes.Add("DEATHHEADSTONE", "HasHeadstone" & vbTab & workingAncestor.hasHeadstoneImage)

    'item = AncestorAttributes.Nodes.Add("CENSUS", "Census Records", "", "")

    ''Census
    'Dim aCensus As ArrayList = workingAncestor.getCensusList()
    'Dim byear As Integer = Val(workingAncestor.BirthYear)
    'Dim dyear As Integer = Val(workingAncestor.DeathYear)
    'If byear > 0 Then
    '  If dyear = 0 Then dyear = byear + 90
    '  Dim census() As Integer = {1950, 1940, 1930, 1920, 1910, 1900, 1890, 1880, 1870, 1860, 1850, 1840, 1830, 1820, 1810, 1800, 1790}
    '  For Each dt As Integer In census
    '    If byear <= dt And dyear >= dt Then
    '      item.Nodes.Add(dt & " Census", dt & " Census" & vbTab & aCensus.Contains(dt.ToString), "", "")
    '    End If
    '  Next
    'End If
  End Sub

  Private Sub AncestorAttributes_DrawNode(sender As Object, e As DrawTreeNodeEventArgs)
    ' Get the current node
    Dim node As TreeNode = e.Node

    ' Define the bounds for the first column
    Dim boundsColumn1 As Rectangle = New Rectangle(e.Bounds.Left, e.Bounds.Top, 100, e.Bounds.Height) ' Adjust width as needed
    ' Define the bounds for the second column
    'boundsColumn1.Right
    Dim boundsColumn2 As Rectangle = New Rectangle(150, e.Bounds.Top, 100, e.Bounds.Height) ' Adjust width as needed

    Dim txt As String = node.Text & vbTab & vbTab
    Dim txtA() As String = txt.Split(vbTab)

    ' Draw the first column
    Dim fnt As Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    TextRenderer.DrawText(e.Graphics, txtA(0), fnt, boundsColumn1, Color.Black, TextFormatFlags.Left Or TextFormatFlags.EndEllipsis)

    ' Draw the second column
    TextRenderer.DrawText(e.Graphics, txtA(1), AncestorAttributes.Font, boundsColumn2, Color.DarkGray, TextFormatFlags.Left)

    ' Prevent default drawing of the node's text
    e.DrawDefault = False
  End Sub

  Private Sub LoadAncestorTree()
    'Debug.Print("LoadAncestorTree: TAG=" & AncestorDetails.Tag)
    'If activeAncestor.IsValid Then
    '  Debug.Print("LoadAncestorTree: VALID")
    '  If AncestorDetails.Tag Is Nothing Then AncestorDetails.Tag = 0
    '  Dim details As ArrayList = getAncestorDetails()
    '  Dim newTag As Double = 0
    '  For Each detail() As Object In details
    '    newTag += detail(2).ToString().GetHashCode And detail(1).ToString().GetHashCode And detail(0).ToString().GetHashCode
    '  Next
    '  Debug.Print("LoadAncestorTree: NEWTAG=" & newTag)
    '  If newTag = AncestorDetails.Tag Then
    '    Debug.Print("LoadAncestorTree: NOCHANGE")
    '    Exit Sub
    '  End If
    '  Debug.Print("LoadAncestorTree: RELOADING")
    '  AncestorDetails.Tag = newTag
    '  Dim hasProfile As Boolean = activeAncestor.IsLocal
    '  With AncestorDetails
    '    If hasProfile Then
    '      .ForeColor = Color.Black
    '    Else
    '      .ForeColor = Color.Red
    '    End If
    '    .Items.Clear()
    '    For Each detail() As Object In details
    '      '   0         1                               2       3          4
    '      '{"Date", workingAncestor.ProfileBirthDate, "BIRTH", "N", "CAL_BLACK"}
    '      Dim item As ListViewItem = New ListViewItem(detail(0).ToString)
    '      If Not detail(2).ToString.Equals("") Then
    '        item.Group = .Groups.Item(detail(2).ToString)
    '      End If
    '      If detail(3).ToString.Equals("Y") Then
    '        If detail(1) Then
    '          item.SubItems.Add("Have")
    '        Else
    '          item.ForeColor = Color.Red
    '          item.SubItems.Add("Missing")
    '        End If
    '      Else
    '        If detail(1).ToString.Length > 0 Then
    '          item.SubItems.Add(detail(1).ToString)
    '        Else
    '          item.ForeColor = Color.Red
    '          item.SubItems.Add("Missing")
    '        End If
    '      End If
    '      If Not detail(4).ToString.Equals("") Then
    '        item.ImageKey = details(4).ToString
    '      End If
    '      .Items.Add(item)
    '    Next
    '  End With
    'Else
    '  Debug.Print("LoadAncestorTree: INVALID")
    '  'AncestorTree.Items.Clear()
    '  AncestorDetails.Tag = 0
    'End If
  End Sub

#End Region

#Region "Viewer - Ancestors List"

  ' ==========================
  ' = Viewer - Ancestors List
  ' ==========================

  Private Sub JDockPanelHeader2_HeaderCloseClicked() Handles JDockPanelHeader2.HeaderCloseClicked
    btnAncestors.Checked = False
    SetUIState()
  End Sub

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
    With AncestorsList
      '.Tag = ""
      '.Items.Clear()
      'Dim dirs() As String = Directory.GetDirectories(My.Settings.AncestorsPath)
      'For Each dir As String In dirs
      '  Dim dirname As String = dir.Replace(My.Settings.AncestorsPath, "")
      '  Dim p() As String = dirname.Split("-")
      '  If p.Length() > 0 Then
      '    item = .Items.Add(p(0).Trim())
      '    item.SubItems.Add(p(1).Trim())
      '    If File.Exists(dir + "\Ancestry.id") Then
      '      item.Tag = File.ReadAllLines(dir + "\Ancestry.id")(0).Trim
      '    Else
      '      item.Tag = ""
      '    End If
      '  End If
      'Next
    End With
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

  Private Sub AncestorsList_DoubleClick(sender As Object, e As EventArgs) Handles AncestorsList.DoubleClick
    Dim id As String = AncestorsList.SelectedItems.Item(0).Tag
    If Not id.Equals("") Then
      Ancestry.NavigateTo(URLTypeEnum.PERSON_FACTS, id)
    End If
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

  Private Sub ancestry_AncestorChanged(newAncestor As AncestorCollection.Ancestor)
    activeAncestor = newAncestor
  End Sub

  Private Sub ancestry_ImageDownload(fromPage As String, filename As String)
    'If activeAncestor.IsValid Then
    '  activeAncestor.createPath()
    '  If fromPage.StartsWith("Census") Then
    '    fromPage += ".jpg"
    '    If File.Exists(activeAncestor.Path & fromPage) Then
    '      Dim rslt As MsgBoxResult
    '      rslt = MsgBox("File Already Exists" & vbCrLf & fromPage & vbCrLf & "Replace?", vbCritical Or vbYesNoCancel, "File Exists")
    '      Select Case rslt
    '        Case MsgBoxResult.Yes
    '          File.Delete(activeAncestor.Path & fromPage)
    '        Case Else
    '          File.Delete(filename)
    '          Exit Sub
    '      End Select
    '    End If
    '    File.Move(filename, activeAncestor.Path & fromPage)
    '  Else
    '    Dim frm As ImageSaveDialog = New ImageSaveDialog()
    '    frm.DstDir = activeAncestor.Path
    '    frm.SrcFilename = filename
    '    frm.SrcPage = fromPage
    '    frm.Show()
    '  End If
    'End If
    SetUIState()
  End Sub

  Private Sub ancestry_AncestryData(dataType As DataTypeEnum, ancestryData As Object) 'TODO Handles ancestry.DataChanged
    'If activeAncestor.IsValid Then
    '  activeAncestor.createPath()
    '  saveFile(activeAncestor.ID, activeAncestor.Path, "Ancestry.id", False)
    '  Select Case dataType
    '    Case DataTypeEnum.anFACTDATA
    '      Dim data As Array = ancestryData
    '      saveCSV(data, activeAncestor.Path, "Timeline.csv")
    '    Case DataTypeEnum.anSOURCEDATA
    '      Dim data As Array = ancestryData
    '      saveCSV(data, activeAncestor.Path, "Sources.csv")
    '    Case DataTypeEnum.anFAMILYDATA
    '      Dim data As Array = ancestryData
    '      saveCSV(data, activeAncestor.Path, "Family.csv")
    '    Case DataTypeEnum.anCENSUSDATA
    '      Dim data As Array = ancestryData
    '      Dim year As String = data(1)(0).ToString
    '      Dim page As String = data(1)(1).ToString
    '      saveCSV(data, activeAncestor.Path, "Census-" & year & "-p" & page & ".csv")
    '    Case DataTypeEnum.anPROFILEDATA
    '      Dim data As String = ancestryData
    '      saveFile(data, activeAncestor.Path, "Profile.txt")
    '    Case Else

    '  End Select
    'End If
    'SetUIState()
  End Sub

  Private Sub Ancestry_AncestorChanged(AncestorID As String) Handles Ancestry.AncestorChanged
    If AncestorID.Equals("0") Then
      btnDownload.Text = ""
      btnDownload.ToolTipText = "No Downloadable Content"
    Else
      btnDownload.Text = AncestorID
      btnDownload.ToolTipText = "Download and import Ancestor Information"
    End If
  End Sub

  Private Sub Ancestry_AncestryData(dataType As DataTypeEnum, data As AncestryDataMessage) Handles Ancestry.DataDownload

  End Sub

  Private Sub Ancestry_DownloadEnabled(isEnabled As Boolean) Handles Ancestry.DownloadEnabled
    btnDownload.Enabled = isEnabled
  End Sub

#End Region

#Region "Viewer - Image/Gallery"

  ' ==========================
  ' = Viewer - Image/Gallery
  ' ==========================

  Private Sub SetGalleryState()
    'If activeAncestor.IsLocal Then
    '  If Not imgGallery.GalleryPath.Equals(activeAncestor.Path) Then
    '    Debug.Print("SetGalleryState: " + activeAncestor.Path)
    '    imgGallery.GalleryPath = activeAncestor.Path
    '    imgGallery.BringToFront()
    '  End If
    'End If
  End Sub

  Private Sub InitializeImageGallery()
    imgGallery.Dock = DockStyle.Fill
    imgViewer.Dock = DockStyle.Fill
    imgGallery.Clear()
    imgGallery.SendToBack()
    imgViewer.BringToFront()
    imgViewer.Visible = False
  End Sub

  Private Sub imgGallery_ImageViewRequested(imageFilename As String) Handles imgGallery.ImageViewRequested
    imgViewer.ImageFile = imageFilename
    imgViewer.Visible = True
    imgViewer.BringToFront()
  End Sub

  Private Sub imgViewer_BackToGallery() Handles imgViewer.BackToGallery
    imgViewer.Visible = False
    imgGallery.BringToFront()
  End Sub

#End Region

#Region "Viewer - Notes"

  ' ==========================
  ' = Viewer - Notes
  ' ==========================

#End Region

#Region "Viewer - Census"

  ' ==========================
  ' = Viewer - Census
  ' ==========================

#End Region

End Class