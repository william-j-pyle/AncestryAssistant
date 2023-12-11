﻿Imports System.Text

Public Class AncestorPanelItem
  Inherits DockPanelItem

#Region "Fields"

  Private WithEvents AncestorAttributes As TreeView
  Private WithEvents ancestorAttributesCol1 As FlatPanel
  Private WithEvents ancestorAttributesCol2 As FlatPanel
  Private WithEvents AncestorAttributesHeader As Panel
  Private WithEvents AncestorColSplitter As Splitter

  Private WithEvents lblAncestorAttributesCol1 As Label
  Private WithEvents lblAncestorAttributesCol2 As Label
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
  Private Const SUBNODE_DELIMITER As String = vbTab
  Private AttributeState As List(Of String)
  Private blockEvents As Boolean = False
  Private components As System.ComponentModel.IContainer
  Private LastAttributeItem As TreeNode
  Public Const Default_Key As String = "DOCK_ANCESTORATTRIBUTES"

#End Region

#Region "Public Constructors"

  Public Sub New(Optional itemKey As String = "")
    'Apply Item Defaults for this Type
    ItemCaption = Default_ItemCaption
    ItemHasRibbonBar = Default_ItemHasRibbonBar
    ItemHasToolBar = Default_ItemHasToolBar
    ItemSupportsClose = Default_ItemSupportsClose
    ItemSupportsMove = Default_ItemSupportsMove
    ItemSupportsSearch = Default_ItemSupportsSearch
    Key = Default_Key
    LocationCurrent = Default_LocationCurrent
    LocationPrefered = Default_LocationPrefered
    LocationPrevious = Default_LocationPrevious
    RibbonBarKey = Default_RibbonBarKey
    RibbonHideOnItemClose = Default_RibbonHideOnItemClose
    RibbonSelectOnItemFocus = Default_RibbonSelectOnItemFocus
    RibbonShowOnItemOpen = Default_RibbonShowOnItemOpen
    'Key can be overriden during creation, apply if set
    If Len(itemKey) > 0 Then Key = itemKey
    'Continue with creation
    AncestorAttributesHeader = New System.Windows.Forms.Panel()
    AncestorColSplitter = New System.Windows.Forms.Splitter()
    ancestorAttributesCol2 = New AncestryAssistant.FlatPanel()
    lblAncestorAttributesCol2 = New System.Windows.Forms.Label()
    ancestorAttributesCol1 = New AncestryAssistant.FlatPanel()
    lblAncestorAttributesCol1 = New System.Windows.Forms.Label()
    AncestorAttributes = New System.Windows.Forms.TreeView()
    AncestorAttributesHeader.SuspendLayout()
    ancestorAttributesCol2.SuspendLayout()
    ancestorAttributesCol1.SuspendLayout()
    SuspendLayout()
    '
    'AncestorAttributesHeader
    '
    AncestorAttributesHeader.BackColor = My.Theme.PanelBorderColor
    AncestorAttributesHeader.Controls.Add(AncestorColSplitter)
    AncestorAttributesHeader.Controls.Add(ancestorAttributesCol2)
    AncestorAttributesHeader.Controls.Add(ancestorAttributesCol1)
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
    ancestorAttributesCol2.BackColor = My.Theme.PanelBorderColor
    ancestorAttributesCol2.BorderColor = My.Theme.PanelBackColor
    ancestorAttributesCol2.BorderColorBottom = My.Theme.PanelShadowColor
    ancestorAttributesCol2.BorderColorLeft = My.Theme.PanelAccentColor
    ancestorAttributesCol2.BorderColorRight = My.Theme.PanelShadowColor
    ancestorAttributesCol2.BorderColorTop = My.Theme.PanelShadowColor
    ancestorAttributesCol2.BorderWidth = New System.Windows.Forms.Padding(0, 0, 1, 1)
    ancestorAttributesCol2.Controls.Add(lblAncestorAttributesCol2)
    ancestorAttributesCol2.CornerRadius = New System.Windows.Forms.Padding(0)
    ancestorAttributesCol2.Dock = System.Windows.Forms.DockStyle.Fill
    ancestorAttributesCol2.Location = New System.Drawing.Point(150, 0)
    ancestorAttributesCol2.MinimumSize = New System.Drawing.Size(60, 0)
    ancestorAttributesCol2.Name = "ancestorAttributesCol2"
    ancestorAttributesCol2.Padding = New System.Windows.Forms.Padding(1)
    ancestorAttributesCol2.Size = New System.Drawing.Size(137, 18)
    ancestorAttributesCol2.TabIndex = 4
    '
    'lblAncestorAttributesCol2
    '
    lblAncestorAttributesCol2.BackColor = My.Theme.PanelBorderColor
    lblAncestorAttributesCol2.Dock = System.Windows.Forms.DockStyle.Fill
    lblAncestorAttributesCol2.ForeColor = My.Theme.PanelFontColor
    lblAncestorAttributesCol2.Location = New System.Drawing.Point(1, 1)
    lblAncestorAttributesCol2.Name = "lblAncestorAttributesCol2"
    lblAncestorAttributesCol2.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
    lblAncestorAttributesCol2.Size = New System.Drawing.Size(135, 16)
    lblAncestorAttributesCol2.TabIndex = 0
    lblAncestorAttributesCol2.Text = "Value"
    lblAncestorAttributesCol2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ancestorAttributesCol1
    '
    ancestorAttributesCol1.BackColor = My.Theme.PanelBorderColor
    ancestorAttributesCol1.BorderColor = My.Theme.PanelBackColor
    ancestorAttributesCol1.BorderColorBottom = My.Theme.PanelBorderColor
    ancestorAttributesCol1.BorderColorLeft = My.Theme.PanelBorderColor
    ancestorAttributesCol1.BorderColorRight = My.Theme.PanelBorderColor
    ancestorAttributesCol1.BorderColorTop = My.Theme.PanelBorderColor
    ancestorAttributesCol1.BorderWidth = New System.Windows.Forms.Padding(0, 0, 1, 1)
    ancestorAttributesCol1.Controls.Add(lblAncestorAttributesCol1)
    ancestorAttributesCol1.CornerRadius = New System.Windows.Forms.Padding(0)
    ancestorAttributesCol1.Dock = System.Windows.Forms.DockStyle.Left
    ancestorAttributesCol1.Location = New System.Drawing.Point(0, 0)
    ancestorAttributesCol1.Margin = New System.Windows.Forms.Padding(0)
    ancestorAttributesCol1.MinimumSize = New System.Drawing.Size(80, 0)
    ancestorAttributesCol1.Name = "ancestorAttributesCol1"
    ancestorAttributesCol1.Padding = New System.Windows.Forms.Padding(1)
    ancestorAttributesCol1.Size = New System.Drawing.Size(150, 18)
    ancestorAttributesCol1.TabIndex = 3
    '
    'lblAncestorAttributesCol1
    '
    lblAncestorAttributesCol1.BackColor = My.Theme.PanelBackColor
    lblAncestorAttributesCol1.Dock = System.Windows.Forms.DockStyle.Fill
    lblAncestorAttributesCol1.ForeColor = My.Theme.PanelFontColor
    lblAncestorAttributesCol1.Location = New System.Drawing.Point(1, 1)
    lblAncestorAttributesCol1.Name = "lblAncestorAttributesCol1"
    lblAncestorAttributesCol1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
    lblAncestorAttributesCol1.Size = New System.Drawing.Size(148, 16)
    lblAncestorAttributesCol1.TabIndex = 0
    lblAncestorAttributesCol1.Text = "Attribute"
    lblAncestorAttributesCol1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
    ancestorAttributesCol2.ResumeLayout(False)
    ancestorAttributesCol1.ResumeLayout(False)
    ResumeLayout(False)

    AncestorAttributes.DrawMode = TreeViewDrawMode.OwnerDrawText
    AncestorAttributes.ForeColor = My.Theme.PanelFontColor
    AncestorAttributes.LineColor = My.Theme.PanelBorderColor
    CaptureFocus(Me)
  End Sub

#End Region

#Region "Private Methods"

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
    Dim boundsColumn1 As New Rectangle(e.Bounds.Left, e.Bounds.Top, lblAncestorAttributesCol1.Width, e.Bounds.Height) ' Adjust width as needed
    ' Define the bounds for the second column
    'boundsColumn1.Right
    Dim boundsColumn2 As New Rectangle(lblAncestorAttributesCol1.Width + 2, e.Bounds.Top, AncestorAttributes.Width, e.Bounds.Height) ' Adjust width as needed

    Dim txt As String = node.Text & SUBNODE_DELIMITER & SUBNODE_DELIMITER
    Dim txtA() As String = txt.Split(SUBNODE_DELIMITER)

    ' Draw the first column
    Dim fnt As New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    TextRenderer.DrawText(e.Graphics, txtA(0), fnt, boundsColumn1, My.Theme.PanelFontColor, TextFormatFlags.Left Or TextFormatFlags.EndEllipsis)

    ' Draw the second column
    TextRenderer.DrawText(e.Graphics, txtA(1), fnt, boundsColumn2, My.Theme.PanelFontColor, TextFormatFlags.Left)

    ' Prevent default drawing of the node's text
    e.DrawDefault = False
  End Sub

  Private Sub AncestorColSplitter_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles AncestorColSplitter.SplitterMoved
    ancestorAttributesCol1.Width = AncestorColSplitter.Tag
    AncestorAttributes.Refresh()
  End Sub

  Private Sub AncestorColSplitter_SplitterMoving(sender As Object, e As SplitterEventArgs) Handles AncestorColSplitter.SplitterMoving
    AncestorColSplitter.Tag = e.X
  End Sub

  Private Sub Ancestors_ActiveAncestorChanged(ancestorId As String) Handles ancestors.ActiveAncestorChanged
    UpdateUI()
  End Sub

  Private Sub Ancestors_AncestorsChanged() Handles ancestors.AncestorsChanged
    UpdateUI()
  End Sub

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

#End Region

#Region "Protected Methods"

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

  Protected Overrides Sub UpdateUI(Optional reload As Boolean = True)
    If ancestors Is Nothing Then Exit Sub
    If Not ancestors.HasActiveAncestor Then Exit Sub
    Dim ancestor As AncestorCollection.Ancestor = ancestors.ActiveAncestor
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

#End Region

#Region "Public Methods"

  Public Overrides Sub ApplySearch(criteria As String)
    Throw New NotImplementedException()
  End Sub

  Public Overrides Sub ClearSearch()
    Throw New NotImplementedException()
  End Sub

#End Region

End Class