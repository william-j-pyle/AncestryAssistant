Imports System.Text

Public Class DPIAncestorDetails
  Inherits DockPanelItem

  Private WithEvents AncestorAttributes As TreeView
  Private WithEvents AncestorAttributesCol1 As FlatPanel
  Private WithEvents AncestorAttributesCol2 As FlatPanel
  Private WithEvents AncestorAttributesHeader As Panel
  Private WithEvents AncestorColSplitter As Splitter

  Private WithEvents LblAncestorAttributesCol1 As Label
  Private WithEvents LblAncestorAttributesCol2 As Label
  Private Const Default_ItemCaption As String = "Ancestor"
  Private Const Default_ItemHasRibbonBar As Boolean = False
  Private Const Default_ItemHasToolBar As Boolean = False
  Private Const Default_ItemSupportsClose As Boolean = True
  Private Const Default_ItemSupportsMove As Boolean = True
  Private Const Default_ItemSupportsSearch As Boolean = False
  Private Const Default_LocationCurrent As DockPanelLocation = DockPanelLocation.None
  Private Const Default_LocationPrefered As DockPanelLocation = DockPanelLocation.LeftBottom
  Private Const Default_LocationPrevious As DockPanelLocation = DockPanelLocation.LeftBottom
  Private Const Default_RibbonBarKey As String = ""
  Private Const Default_RibbonHideOnItemClose As Boolean = False
  Private Const Default_RibbonSelectOnItemFocus As Boolean = False
  Private Const Default_RibbonShowOnItemOpen As Boolean = False
  Private Const SUBNODE_DELIMITER As Char = CChar(vbTab)
  Private AttributeState As List(Of String)
  Private blockEvents As Boolean = False
  Private components As System.ComponentModel.IContainer
  Private LastAttributeItem As TreeNode
  Public Const Base_Key As String = "DOCK_ANCESTORATTRIBUTES"

  Public Sub New(Optional instanceKey As String = "")
    'Apply Item Defaults for this Type
    ItemCaption = Default_ItemCaption
    ItemHasRibbonBar = Default_ItemHasRibbonBar
    ItemHasToolBar = Default_ItemHasToolBar
    ItemSupportsClose = Default_ItemSupportsClose
    ItemSupportsMove = Default_ItemSupportsMove
    ItemSupportsSearch = Default_ItemSupportsSearch
    ItemKey = Base_Key
    ItemInstanceKey = instanceKey
    LocationCurrent = Default_LocationCurrent
    LocationPrefered = Default_LocationPrefered
    LocationPrevious = Default_LocationPrevious
    RibbonBarKey = Default_RibbonBarKey
    RibbonHideOnItemClose = Default_RibbonHideOnItemClose
    RibbonSelectOnItemFocus = Default_RibbonSelectOnItemFocus
    RibbonShowOnItemOpen = Default_RibbonShowOnItemOpen
    'Continue with creation
    AncestorAttributesHeader = New System.Windows.Forms.Panel()
    AncestorColSplitter = New System.Windows.Forms.Splitter()
    AncestorAttributesCol2 = New AncestryAssistant.FlatPanel()
    LblAncestorAttributesCol2 = New System.Windows.Forms.Label()
    AncestorAttributesCol1 = New AncestryAssistant.FlatPanel()
    LblAncestorAttributesCol1 = New System.Windows.Forms.Label()
    AncestorAttributes = New System.Windows.Forms.TreeView()
    AncestorAttributesHeader.SuspendLayout()
    AncestorAttributesCol2.SuspendLayout()
    AncestorAttributesCol1.SuspendLayout()
    SuspendLayout()
    '
    'AncestorAttributesHeader
    '
    AncestorAttributesHeader.BackColor = My.Theme.PanelBorderColor
    AncestorAttributesHeader.Controls.Add(AncestorColSplitter)
    AncestorAttributesHeader.Controls.Add(AncestorAttributesCol2)
    AncestorAttributesHeader.Controls.Add(AncestorAttributesCol1)
    AncestorAttributesHeader.Dock = System.Windows.Forms.DockStyle.Top
    AncestorAttributesHeader.Location = New System.Drawing.Point(0, 0)
    AncestorAttributesHeader.MaximumSize = New System.Drawing.Size(0, 18)
    AncestorAttributesHeader.MinimumSize = New System.Drawing.Size(0, 18)
    AncestorAttributesHeader.Name = "AncestorAttributesHeader"
    AncestorAttributesHeader.Size = New System.Drawing.Size(287, 18)
    AncestorAttributesHeader.TabIndex = 4
    AncestorAttributesHeader.Visible = False
    '
    'AncestorColSplitter
    '
    AncestorColSplitter.BackColor = My.Theme.PanelAccentColor
    AncestorColSplitter.Location = New System.Drawing.Point(150, 0)
    AncestorColSplitter.Margin = New System.Windows.Forms.Padding(0)
    AncestorColSplitter.Name = "AncestorColSplitter"
    AncestorColSplitter.Size = New System.Drawing.Size(1, 18)
    AncestorColSplitter.TabIndex = 1
    AncestorColSplitter.TabStop = False
    '
    'ancestorAttributesCol2
    '
    AncestorAttributesCol2.BackColor = My.Theme.PanelBorderColor
    AncestorAttributesCol2.BorderColor = My.Theme.PanelBackColor
    AncestorAttributesCol2.BorderColorBottom = My.Theme.PanelShadowColor
    AncestorAttributesCol2.BorderColorLeft = My.Theme.PanelAccentColor
    AncestorAttributesCol2.BorderColorRight = My.Theme.PanelShadowColor
    AncestorAttributesCol2.BorderColorTop = My.Theme.PanelShadowColor
    AncestorAttributesCol2.BorderWidth = New System.Windows.Forms.Padding(0, 0, 1, 1)
    AncestorAttributesCol2.Controls.Add(LblAncestorAttributesCol2)
    AncestorAttributesCol2.CornerRadius = New System.Windows.Forms.Padding(0)
    AncestorAttributesCol2.Dock = System.Windows.Forms.DockStyle.Fill
    AncestorAttributesCol2.Location = New System.Drawing.Point(150, 0)
    AncestorAttributesCol2.MinimumSize = New System.Drawing.Size(60, 0)
    AncestorAttributesCol2.Name = "ancestorAttributesCol2"
    AncestorAttributesCol2.Padding = New System.Windows.Forms.Padding(1)
    AncestorAttributesCol2.Size = New System.Drawing.Size(137, 18)
    AncestorAttributesCol2.TabIndex = 4
    '
    'lblAncestorAttributesCol2
    '
    LblAncestorAttributesCol2.BackColor = My.Theme.PanelBorderColor
    LblAncestorAttributesCol2.Dock = System.Windows.Forms.DockStyle.Fill
    LblAncestorAttributesCol2.ForeColor = My.Theme.PanelFontColor
    LblAncestorAttributesCol2.Location = New System.Drawing.Point(1, 1)
    LblAncestorAttributesCol2.Name = "lblAncestorAttributesCol2"
    LblAncestorAttributesCol2.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
    LblAncestorAttributesCol2.Size = New System.Drawing.Size(135, 16)
    LblAncestorAttributesCol2.TabIndex = 0
    LblAncestorAttributesCol2.Text = "Value"
    LblAncestorAttributesCol2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ancestorAttributesCol1
    '
    AncestorAttributesCol1.BackColor = My.Theme.PanelBorderColor
    AncestorAttributesCol1.BorderColor = My.Theme.PanelBackColor
    AncestorAttributesCol1.BorderColorBottom = My.Theme.PanelBorderColor
    AncestorAttributesCol1.BorderColorLeft = My.Theme.PanelBorderColor
    AncestorAttributesCol1.BorderColorRight = My.Theme.PanelBorderColor
    AncestorAttributesCol1.BorderColorTop = My.Theme.PanelBorderColor
    AncestorAttributesCol1.BorderWidth = New System.Windows.Forms.Padding(0, 0, 1, 1)
    AncestorAttributesCol1.Controls.Add(LblAncestorAttributesCol1)
    AncestorAttributesCol1.CornerRadius = New System.Windows.Forms.Padding(0)
    AncestorAttributesCol1.Dock = System.Windows.Forms.DockStyle.Left
    AncestorAttributesCol1.Location = New System.Drawing.Point(0, 0)
    AncestorAttributesCol1.Margin = New System.Windows.Forms.Padding(0)
    AncestorAttributesCol1.MinimumSize = New System.Drawing.Size(80, 0)
    AncestorAttributesCol1.Name = "ancestorAttributesCol1"
    AncestorAttributesCol1.Padding = New System.Windows.Forms.Padding(1)
    AncestorAttributesCol1.Size = New System.Drawing.Size(150, 18)
    AncestorAttributesCol1.TabIndex = 3
    '
    'lblAncestorAttributesCol1
    '
    LblAncestorAttributesCol1.BackColor = My.Theme.PanelBackColor
    LblAncestorAttributesCol1.Dock = System.Windows.Forms.DockStyle.Fill
    LblAncestorAttributesCol1.ForeColor = My.Theme.PanelFontColor
    LblAncestorAttributesCol1.Location = New System.Drawing.Point(1, 1)
    LblAncestorAttributesCol1.Name = "lblAncestorAttributesCol1"
    LblAncestorAttributesCol1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
    LblAncestorAttributesCol1.Size = New System.Drawing.Size(148, 16)
    LblAncestorAttributesCol1.TabIndex = 0
    LblAncestorAttributesCol1.Text = "Attribute"
    LblAncestorAttributesCol1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'AncestorAttributes
    '
    AncestorAttributes.BackColor = My.Theme.PanelBackColor
    AncestorAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None
    AncestorAttributes.Dock = System.Windows.Forms.DockStyle.Fill
    AncestorAttributes.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText
    AncestorAttributes.ForeColor = My.Theme.PanelFontColor
    AncestorAttributes.FullRowSelect = True
    AncestorAttributes.HotTracking = True
    AncestorAttributes.LineColor = My.Theme.PanelBorderColor
    AncestorAttributes.Location = New System.Drawing.Point(0, 18)
    AncestorAttributes.Margin = New System.Windows.Forms.Padding(0)
    AncestorAttributes.Name = "AncestorAttributes"
    AncestorAttributes.ShowLines = False
    AncestorAttributes.Size = New System.Drawing.Size(287, 290)
    AncestorAttributes.TabIndex = 5
    '
    'AncestorPanel
    '
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    BackColor = My.Theme.PanelBackColor
    Controls.Add(AncestorAttributes)
    Controls.Add(AncestorAttributesHeader)
    Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    ForeColor = My.Theme.PanelBackColor
    Margin = New System.Windows.Forms.Padding(0)
    Name = Key
    Size = New System.Drawing.Size(287, 308)
    Dock = DockStyle.Fill
    AncestorAttributesHeader.ResumeLayout(False)
    AncestorAttributesCol2.ResumeLayout(False)
    AncestorAttributesCol1.ResumeLayout(False)
    ResumeLayout(False)

    AncestorAttributes.DrawMode = TreeViewDrawMode.OwnerDrawText
    AncestorAttributes.ForeColor = My.Theme.PanelFontColor
    AncestorAttributes.LineColor = My.Theme.PanelBorderColor
    CaptureFocus(Me)
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

  Private Sub AncestorAttributes_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles AncestorAttributes.AfterSelect

  End Sub

  Private Sub AncestorAttributes_DrawNode(sender As Object, e As DrawTreeNodeEventArgs) Handles AncestorAttributes.DrawNode
    ' Get the current node
    Dim node As TreeNode = e.Node

    ' Define the bounds for the first column
    Dim boundsColumn1 As New Rectangle(e.Bounds.Left, e.Bounds.Top, LblAncestorAttributesCol1.Width, e.Bounds.Height) ' Adjust width as needed
    ' Define the bounds for the second column
    'boundsColumn1.Right
    Dim boundsColumn2 As New Rectangle(LblAncestorAttributesCol1.Width + 2, e.Bounds.Top, AncestorAttributes.Width, e.Bounds.Height) ' Adjust width as needed

    Dim Txt As String = node.Text & SUBNODE_DELIMITER & SUBNODE_DELIMITER
    Dim TxtA() As String = Txt.Split(SUBNODE_DELIMITER)

    ' Draw the first column
    Dim fnt As New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    TextRenderer.DrawText(e.Graphics, TxtA(0), fnt, boundsColumn1, My.Theme.PanelFontColor, TextFormatFlags.Left Or TextFormatFlags.EndEllipsis)

    ' Draw the second column
    TextRenderer.DrawText(e.Graphics, TxtA(1), fnt, boundsColumn2, My.Theme.PanelFontColor, TextFormatFlags.Left)

    ' Prevent default drawing of the node's text
    e.DrawDefault = False
  End Sub

  Private Sub AncestorColSplitter_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles AncestorColSplitter.SplitterMoved
    AncestorAttributesCol1.Width = CInt(AncestorColSplitter.Tag)
    AncestorAttributes.Refresh()
  End Sub

  Private Sub AncestorColSplitter_SplitterMoving(sender As Object, e As SplitterEventArgs) Handles AncestorColSplitter.SplitterMoving
    AncestorColSplitter.Tag = e.X
  End Sub

  Private Sub CaptureAttributeState()
    ' Save the current expanded state
    AttributeState = New List(Of String)
    For Each i As TreeNode In AncestorAttributes.Nodes
      If i.IsExpanded Then
        AttributeState.Add(CStr(i.Tag))
        For Each j As TreeNode In i.Nodes
          If j.IsExpanded Then
            AttributeState.Add(CStr(j.Tag))
          End If
        Next
      End If
    Next
  End Sub

  Private Function customNode(ParamArray subNodes() As String) As String
    Dim sb As New StringBuilder
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

  Private Sub RestoreAttributeState()
    For Each i As TreeNode In AncestorAttributes.Nodes
      If AttributeState.Contains(CStr(i.Tag)) Then
        i.Expand()
      End If
      For Each j As TreeNode In i.Nodes
        If AttributeState.Contains(CStr(j.Tag)) Then
          j.Expand()
        End If
      Next
    Next
  End Sub

  'UserControl overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  Protected Overrides Sub UpdateUI(Optional reload As Boolean = True) Handles _Ancestors.ActiveAncestorChanged, _Ancestors.AncestorsChanged
    If Ancestors Is Nothing Then Exit Sub
    If Not Ancestors.HasActiveAncestor Then Exit Sub
    Dim Ancestor As AncestorCollection.Ancestor = Ancestors.ActiveAncestor
    CaptureAttributeState()
    AncestorAttributes.Nodes.Clear()

    AddAttributeItem("NAME", customNode("Name", Ancestor.FullName))
    AddSubAttributeItem("SURNAME", customNode("Surname", Ancestor.Surname))
    AddSubAttributeItem("GIVENNAME", customNode("Givenname", Ancestor.Givenname))

    AddAttributeItem("PROFILEIMG", customNode("HasProfileImage", HaveOrMissing(Ancestor.HasProfileImage)))

    AddAttributeItem("BIRTH", customNode("Birth", Ancestor.GedBirthDate.toAssistantDate))
    AddSubAttributeItem("BIRTHPLACE", customNode("Place", Ancestor.Fact("BirthPlace")))
    AddSubAttributeItem("BIRTHDOCUMENTS", customNode("HasDocuments", HaveOrMissing(False)))

    If Not Ancestor.LifeSpan.Contains("Living") Then
      AddAttributeItem("DEATH", customNode("Death", Ancestor.GedDeathDate.toAssistantDate))
      AddSubAttributeItem("DEATHPLACE", customNode("Death Location", Ancestor.Fact("DeathPlace")))
      If Not Ancestor.Fact("cemeteryName").Equals("") Then
        AddSubAttributeItem("Burial", customNode("Burial", Ancestor.Fact("cemeteryName")))
        AddSubAttributeItem("BurialPlace", customNode("Burial Location", Ancestor.Fact("cemeteryPlace")))
      End If
      'item.Nodes.Add("DEATHDOCUMENTS", "HasDocuments" & vbTab & workingAncestor.hasDeathCertificate)
      'item.Nodes.Add("DEATHHEADSTONE", "HasHeadstone" & vbTab & workingAncestor.hasHeadstoneImage)
    End If

    Dim expectedCensus As List(Of Integer) = Ancestor.Census.ExpectedYears
    Dim availableCensus As List(Of Integer) = Ancestor.Census.AvailableYears
    If expectedCensus.Count > 0 Then
      AddAttributeItem("CENSUS", "Census Records")
      For Each censusYear As Integer In expectedCensus
        AddSubAttributeItem(censusYear & " Census", customNode(censusYear & " Census", HaveOrMissing(availableCensus.Contains(censusYear))))
      Next
    End If

    AddAttributeItem("ID", "Links")
    AddSubAttributeItem("ANCESTRYID", customNode("Ancestry.com", Ancestor.ID))
    If Not Ancestor.Fact("FindAGraveID").Equals("") Then
      AddSubAttributeItem("FindAGraveID", customNode("FindAGrave.com", Ancestor.Fact("FindAGraveID")))
    End If

    RestoreAttributeState()
  End Sub

  Public Overrides Sub ApplySearch(criteria As String)
  End Sub

  Public Overrides Sub ClearSearch()
  End Sub

  Public Overrides Sub EventRequest(eventType As DockPanelItemEventType, eventData As Object)
  End Sub

End Class