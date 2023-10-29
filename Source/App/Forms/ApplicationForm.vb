Imports System.IO
Imports System.Text


#Const SHOW_DEBUG = True

Public Class ApplicationForm

  Public Event ActiveAncestorChanged()
  Public Event AncestorsUpdated()

  Private Ancestors As AncestorCollection

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
    InitializeAncestorList()
    LoadAncestorList()
    SetUIState()
    AncestryDirectorWatcher.EnableRaisingEvents = True
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

  Private Sub btnDownload_Click(sender As Object, e As EventArgs)

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

  Private Const SUBNODE_DELIMITER = vbTab
  Private Function customNode(ParamArray subNodes() As String) As String
    Dim sb As StringBuilder = New StringBuilder
    For Each node As String In subNodes
      If sb.Length > 0 Then sb.Append(SUBNODE_DELIMITER)
      sb.Append(node)
    Next
    Return sb.ToString
  End Function

  Private Function HaveOrMissing(haveIt As Boolean) As String
    If haveIt Then
      Return "Have"
    Else
      Return "Missing"
    End If
  End Function


  Private AttributeState As List(Of String)
  Private Sub CaptureAttributeState()
    ' Save the current expanded state
    AttributeState = New List(Of String)
    For Each i As TreeNode In AncestorAttributes.Nodes
      If i.IsExpanded Then
        AttributeState.Add(i.Tag)
        For Each j As TreeNode In i.Nodes
          If j.IsExpanded Then
            AttributeState.Add(j.Tag)
          End If
        Next
      End If
    Next
  End Sub
  Private Sub RestoreAttributeState()
    For Each i As TreeNode In AncestorAttributes.Nodes
      If AttributeState.Contains(i.Tag) Then
        i.Expand()
      End If
      For Each j As TreeNode In i.Nodes
        If AttributeState.Contains(j.Tag) Then
          j.Expand()
        End If
      Next
    Next
  End Sub

  Private LastAttributeItem As TreeNode

  Private Sub AddAttributeItem(Key As String, Text As String, Optional ImageKey As String = "", Optional SelectedImageKey As String = "")
    LastAttributeItem = AncestorAttributes.Nodes.Add(Key, Text, ImageKey, SelectedImageKey)
    LastAttributeItem.Tag = Key
  End Sub

  Private Sub AddSubAttributeItem(Key As String, Text As String, Optional ImageKey As String = "", Optional SelectedImageKey As String = "")
    Dim item As TreeNode
    item = LastAttributeItem.Nodes.Add(Key, Text, ImageKey, SelectedImageKey)
    item.Tag = Key
  End Sub


  Private Sub LoadAncestorAttributes(ancestor As AncestorCollection.Ancestor)
    CaptureAttributeState()
    AncestorAttributes.DrawMode = TreeViewDrawMode.OwnerDrawText
    AncestorAttributes.Nodes.Clear()
    AncestorAttributes.ForeColor = Color.Black

    AddAttributeItem("NAME", customNode("Name", ancestor.FullName))
    AddSubAttributeItem("SURNAME", customNode("Surname", ancestor.Surname))
    AddSubAttributeItem("GIVENNAME", customNode("Givenname", ancestor.Givenname))

    AddAttributeItem("PROFILEIMG", customNode("HasProfileImage", HaveOrMissing(ancestor.HasProfileImage)))

    AddAttributeItem("BIRTH", customNode("Birth", ancestor.GedBirthDate.toAssistantDate))
    AddSubAttributeItem("BIRTHPLACE", customNode("Place", ancestor.Fact("BirthPlace")))
    AddSubAttributeItem("BIRTHDOCUMENTS", customNode("HasDocuments", HaveOrMissing(False)))

    If Not ancestor.LifeSpan.Contains("Living") Then
      AddAttributeItem("DEATH", customNode("Death", ancestor.GedDeathDate.toAssistantDate))
      AddSubAttributeItem("DEATHPLACE", customNode("Place", ancestor.Fact("DeathPlace")))
      'item.Nodes.Add("DEATHDOCUMENTS", "HasDocuments" & vbTab & workingAncestor.hasDeathCertificate)
      'item.Nodes.Add("DEATHHEADSTONE", "HasHeadstone" & vbTab & workingAncestor.hasHeadstoneImage)
    End If

    Dim expectedCensus As List(Of Integer) = ancestor.Census.ExpectedYears
    Dim availableCensus As List(Of Integer) = ancestor.Census.AvailableYears
    If expectedCensus.Count > 0 Then
      AddAttributeItem("CENSUS", "Census Records")
      For Each censusYear As Integer In expectedCensus
        AddSubAttributeItem(censusYear & " Census", customNode(censusYear & " Census", HaveOrMissing(availableCensus.Contains(censusYear))))
      Next
    End If

    AddAttributeItem("ID", "Links")
    AddSubAttributeItem("ANCESTRYID", customNode("Ancestry.com", ancestor.ID))

    RestoreAttributeState()
  End Sub

  Private Sub AncestorAttributes_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles AncestorAttributes.DrawNode
    ' Get the current node
    Dim node As TreeNode = e.Node

    ' Define the bounds for the first column
    Dim boundsColumn1 As Rectangle = New Rectangle(e.Bounds.Left, e.Bounds.Top, lblAncestorAttributesCol1.Width, e.Bounds.Height) ' Adjust width as needed
    ' Define the bounds for the second column
    'boundsColumn1.Right
    Dim boundsColumn2 As Rectangle = New Rectangle(lblAncestorAttributesCol1.Width + 2, e.Bounds.Top, lblAncestorAttributesCol2.Width, e.Bounds.Height) ' Adjust width as needed

    Dim txt As String = node.Text & SUBNODE_DELIMITER & SUBNODE_DELIMITER
    Dim txtA() As String = txt.Split(SUBNODE_DELIMITER)

    ' Draw the first column
    Dim fnt As Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    TextRenderer.DrawText(e.Graphics, txtA(0), fnt, boundsColumn1, Color.Black, TextFormatFlags.Left Or TextFormatFlags.EndEllipsis)

    ' Draw the second column
    TextRenderer.DrawText(e.Graphics, txtA(1), fnt, boundsColumn2, Color.Black, TextFormatFlags.Left)

    ' Prevent default drawing of the node's text
    e.DrawDefault = False
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
      .Columns.Add("Lifespan", CInt(.Width / 2))
      .Groups.Clear()
    End With
  End Sub

  Private Sub LoadAncestorList()
    If Ancestors Is Nothing Then Exit Sub
    Dim item As ListViewItem
    With AncestorsList
      .Tag = ""
      .Items.Clear()
      For Each ancestor As AncestorCollection.Ancestor In Ancestors.Values
        item = .Items.Add(ancestor.FullName)
        item.SubItems.Add(ancestor.LifeSpan)
        item.Tag = ancestor.ID
        If AncestorId.Equals(ancestor.ID) Then
          item.Selected = True
        End If
      Next
    End With
  End Sub

  Private Sub AncestryDirectorWatcher_Changed(sender As Object, e As FileSystemEventArgs) Handles AncestryDirectorWatcher.Changed
    Debug.Print("FILEWATCHER(Changed')=" & e.FullPath)
  End Sub

  Private Sub AncestryDirectorWatcher_Created(sender As Object, e As FileSystemEventArgs) Handles AncestryDirectorWatcher.Created
    Debug.Print("FILEWATCHER(Created')=" & e.FullPath)
    LoadAncestorList()
  End Sub

  Private Sub AncestryDirectorWatcher_Deleted(sender As Object, e As FileSystemEventArgs) Handles AncestryDirectorWatcher.Deleted
    Debug.Print("FILEWATCHER(Deleted')=" & e.FullPath)
    LoadAncestorList()
  End Sub

  Private Sub AncestorsList_DoubleClick(sender As Object, e As EventArgs) Handles AncestorsList.DoubleClick
    Dim id As String = AncestorsList.SelectedItems.Item(0).Tag
    If Not id.Equals("") Then
      Ancestry.NavigateTo(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON, id)
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

  'Private Sub Ancestry_AncestorChanged(AncestorID As String) Handles Ancestry.AncestorChanged
  '  If AncestorID.Equals("0") Then
  '    btnDownload.Text = ""
  '    btnDownload.ToolTipText = "No Downloadable Content"
  '  Else
  '    btnDownload.Text = AncestorID
  '    btnDownload.ToolTipText = "Download and import Ancestor Information"
  '  End If
  'End Sub

#If SHOW_DEBUG Then
  Private Sub dumpMessage(msg As APIMessage)
    Debug.Print("----------------MSG-------------------------------")
    Debug.Print("MessageType=" & msg.MessageType)
    Debug.Print("MessageKey =" & msg.MessageKey)
    Debug.Print("RowsOfData =" & msg.Payload.Count)
    Dim sb As StringBuilder = New System.Text.StringBuilder
    Dim sep As String = ""
    For r As Integer = 0 To msg.Payload.Count - 1
      sb = New StringBuilder
      sb.Append("ROW[" & r & "] = ")
      sep = ""
      For c As Integer = 0 To msg.Payload.Item(r).Count - 1
        Dim s As String = msg.Payload.Item(r).Item(c)
        sb.Append(sep & s)
        sep = ","
      Next
      Debug.Print(sb.ToString)
    Next
  End Sub
#End If

  Private Const ANCESTOR_NEW = "Add Ancestor To Assistant"
  Private Const ANCESTOR_UPDATED = "Apply Ancestor Changes To Assistant"
  Private Const ANCESTOR_CENSUS = "Download Census Data"

  Private Sub Ancestry_AncestryData(msg As APIMessage) Handles Ancestry.DataDownload
#If SHOW_DEBUG Then
    dumpMessage(msg)
#End If
    Select Case msg.MessageType
      Case APIMessage.MT_PERSON
        If msg.MessageKey.Length > 3 Then
          Debug.Print("New Ancestor")
          If Not Ancestors.ContainsKey(msg.MessageKey) Then
            With btnActions
              .Tag = msg
              .Text = ANCESTOR_NEW
              '.Image = My.Resources.ANCESTOR_ADD_WHITE
              .Enabled = True
              .Visible = True
            End With
          Else
            Debug.Print("Check For Ancestor Changes")
            If Not AncestorMatchesMessage(msg) Then
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
            For Each fact As String In AncestorFactList()
              ancestor.Fact(fact) = msg.GetValue(fact)
            Next
            AncestorId = msg.MessageKey
            RaiseEvent AncestorsUpdated()
          End If
        End If
      Case ANCESTOR_UPDATED
        Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
        For Each fact As String In AncestorFactDifferences(msg)
          ancestor.Fact(fact) = msg.GetValue(fact)
        Next
        AncestorId = msg.MessageKey
        RaiseEvent AncestorsUpdated()
      Case ANCESTOR_CENSUS
        Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
        Dim imgFilename = ancestor.Census.addCensusData(msg)
        AncestorId = msg.MessageKey
        Ancestry.saveImageAs(imgFilename + ".jpg")
        RaiseEvent AncestorsUpdated()
      Case Else

    End Select

  End Sub

  Private Function AncestorFactList() As List(Of String)
    Dim rtn As List(Of String) = New List(Of String)
    rtn.AddRange({"givenname", "surname", "suffix", "birthPlace", "birthDate", "deathPlace", "deathDate", "gender", "photo"})
    Return rtn
  End Function

  Private Function AncestorFactDifferences(msg As APIMessage) As List(Of String)
    Dim rtn As List(Of String) = New List(Of String)
    Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
    For Each fact As String In AncestorFactList()
      If Not ancestor.Fact(fact).Equals(msg.GetValue(fact)) Then
        Debug.Print("Fact Difference: " + fact)
        rtn.Add(fact)
      End If
    Next
    Return rtn
  End Function


  Private Function AncestorMatchesMessage(msg As APIMessage) As Boolean
    Return AncestorFactDifferences(msg).Count = 0
  End Function

  Private Sub ApplicationForm_AncestorsUpdated() Handles Me.AncestorsUpdated
    LoadAncestorList()
  End Sub

  Private Sub ApplicationForm_ActiveAncestorChanged() Handles Me.ActiveAncestorChanged
    Dim ancestor As AncestorCollection.Ancestor = Ancestors.Item(AncestorId)
    LoadAncestorAttributes(ancestor)
    imgGallery.SetAncestor(ancestor)
    CensusViewer1.SetAncestor(ancestor)
    NotebookViewer1.SetAncestor(ancestor)

  End Sub

  Private Sub AncestorsList_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles AncestorsList.ItemSelectionChanged
    If e.IsSelected Then
      AncestorId = e.Item.Tag
    End If
  End Sub

  Private Sub AncestorColSplitter_SplitterMoving(sender As Object, e As SplitterEventArgs) Handles AncestorColSplitter.SplitterMoving
    AncestorColSplitter.Tag = e.X
  End Sub

  Private Sub AncestorColSplitter_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles AncestorColSplitter.SplitterMoved
    ancestorAttributesCol1.Width = AncestorColSplitter.Tag
    AncestorAttributes.Refresh()
  End Sub

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