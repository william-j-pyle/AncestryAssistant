Imports System.Text

Public Class AncestorPanel
  Implements IDockPanelItem

  Private Const SUBNODE_DELIMITER As String = vbTab

  Public Event PanelCloseClicked(sender As Object)

  Private AttributeState As List(Of String)
  Private LastAttributeItem As TreeNode

  Public ReadOnly Property ItemCaption As String Implements IDockPanelItem.ItemCaption
    Get
      Return "Ancestor"
    End Get
  End Property

  Public Property ItemDockStyle As DockStyle Implements IDockPanelItem.ItemDockStyle
    Get
      Return Dock
    End Get
    Set(value As DockStyle)
      Dock = value
    End Set
  End Property

  Public Sub New()
    InitializeComponent()
    AncestorAttributes.DrawMode = TreeViewDrawMode.OwnerDrawText
    AncestorAttributes.ForeColor = Color.WhiteSmoke
    AncestorAttributes.LineColor = Color.DarkGray
  End Sub

#Region "Attribute Node Support"

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

  Private Sub AddAttributeItem(Key As String, Text As String, Optional ImageKey As String = "", Optional SelectedImageKey As String = "")
    LastAttributeItem = AncestorAttributes.Nodes.Add(Key, Text, ImageKey, SelectedImageKey)
    LastAttributeItem.Tag = Key
  End Sub

  Private Sub AddSubAttributeItem(Key As String, Text As String, Optional ImageKey As String = "", Optional SelectedImageKey As String = "")
    Dim item As TreeNode
    item = LastAttributeItem.Nodes.Add(Key, Text, ImageKey, SelectedImageKey)
    item.Tag = Key
  End Sub

  Private Sub AncestorAttributes_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles AncestorAttributes.DrawNode
    ' Get the current node
    Dim node As TreeNode = e.Node

    ' Define the bounds for the first column
    Dim boundsColumn1 As Rectangle = New Rectangle(e.Bounds.Left, e.Bounds.Top, lblAncestorAttributesCol1.Width, e.Bounds.Height) ' Adjust width as needed
    ' Define the bounds for the second column
    'boundsColumn1.Right
    Dim boundsColumn2 As Rectangle = New Rectangle(lblAncestorAttributesCol1.Width + 2, e.Bounds.Top, AncestorAttributes.Width, e.Bounds.Height) ' Adjust width as needed

    Dim txt As String = node.Text & SUBNODE_DELIMITER & SUBNODE_DELIMITER
    Dim txtA() As String = txt.Split(SUBNODE_DELIMITER)

    ' Draw the first column
    Dim fnt As Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    TextRenderer.DrawText(e.Graphics, txtA(0), fnt, boundsColumn1, Color.WhiteSmoke, TextFormatFlags.Left Or TextFormatFlags.EndEllipsis)

    ' Draw the second column
    TextRenderer.DrawText(e.Graphics, txtA(1), fnt, boundsColumn2, Color.WhiteSmoke, TextFormatFlags.Left)

    ' Prevent default drawing of the node's text
    e.DrawDefault = False
  End Sub

#End Region

  Public Sub SetAncestor(ancestor As AncestorCollection.Ancestor)
    CaptureAttributeState()
    AncestorAttributes.Nodes.Clear()

    AddAttributeItem("NAME", customNode("Name", ancestor.FullName))
    AddSubAttributeItem("SURNAME", customNode("Surname", ancestor.Surname))
    AddSubAttributeItem("GIVENNAME", customNode("Givenname", ancestor.Givenname))

    AddAttributeItem("PROFILEIMG", customNode("HasProfileImage", HaveOrMissing(ancestor.HasProfileImage)))

    AddAttributeItem("BIRTH", customNode("Birth", ancestor.GedBirthDate.toAssistantDate))
    AddSubAttributeItem("BIRTHPLACE", customNode("Place", ancestor.Fact("BirthPlace")))
    AddSubAttributeItem("BIRTHDOCUMENTS", customNode("HasDocuments", HaveOrMissing(False)))

    If Not ancestor.LifeSpan.Contains("Living") Then
      AddAttributeItem("DEATH", customNode("Death", ancestor.GedDeathDate.toAssistantDate))
      AddSubAttributeItem("DEATHPLACE", customNode("Death Location", ancestor.Fact("DeathPlace")))
      If Not ancestor.Fact("cemeteryName").Equals("") Then
        AddSubAttributeItem("Burial", customNode("Burial", ancestor.Fact("cemeteryName")))
        AddSubAttributeItem("BurialPlace", customNode("Burial Location", ancestor.Fact("cemeteryPlace")))
      End If
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
    If Not ancestor.Fact("FindAGraveID").Equals("") Then
      AddSubAttributeItem("FindAGraveID", customNode("FindAGrave.com", ancestor.Fact("FindAGraveID")))
    End If


    RestoreAttributeState()
  End Sub

  Private Sub AncestorColSplitter_SplitterMoving(sender As Object, e As SplitterEventArgs) Handles AncestorColSplitter.SplitterMoving
    AncestorColSplitter.Tag = e.X
  End Sub

  Private Sub AncestorColSplitter_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles AncestorColSplitter.SplitterMoved
    ancestorAttributesCol1.Width = AncestorColSplitter.Tag
    AncestorAttributes.Refresh()
  End Sub

  Private Sub JDockPanelHeader1_HeaderCloseClicked()
    RaiseEvent PanelCloseClicked(Me)
  End Sub

  Private Sub AncestorAttributes_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles AncestorAttributes.AfterSelect

  End Sub
End Class
