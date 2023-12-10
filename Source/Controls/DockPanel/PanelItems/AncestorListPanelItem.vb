Imports AncestryAssistant.AncestorCollection

Public Class AncestorsListPanelItem
  Inherits DockPanelItem

#Region "Fields"

  Private WithEvents AncestorsList As FlatListView
  Private Const Default_ItemCaption As String = "Ancestors List"
  Private Const Default_ItemHasRibbonBar As Boolean = False
  Private Const Default_ItemHasToolBar As Boolean = True
  Private Const Default_ItemSupportsClose As Boolean = True
  Private Const Default_ItemSupportsMove As Boolean = True
  Private Const Default_ItemSupportsSearch As Boolean = True
  Private Const Default_Key As String = "DOCK_ANCESTORSLIST"
  Private Const Default_LocationCurrent As DockPanelLocation = DockPanelLocation.None
  Private Const Default_LocationPrefered As DockPanelLocation = DockPanelLocation.LeftTop
  Private Const Default_LocationPrevious As DockPanelLocation = DockPanelLocation.LeftTop
  Private Const Default_RibbonBarKey As String = ""
  Private Const Default_RibbonHideOnItemClose As Boolean = False
  Private Const Default_RibbonSelectOnItemFocus As Boolean = False
  Private Const Default_RibbonShowOnItemOpen As Boolean = False
  Private blockEvents As Boolean = False
  Private components As System.ComponentModel.IContainer

#End Region

#Region "Events"

  Public Event AncestryNavigateRequest(AncestorID As String)

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
    AncestorsList = New FlatListView()
    SuspendLayout()
    With AncestorsList
      .AutoArrange = False
      .BackColor = My.Theme.PanelBackColor
      .BorderStyle = System.Windows.Forms.BorderStyle.None
      .Dock = System.Windows.Forms.DockStyle.Fill
      .ForeColor = My.Theme.PanelFontColor
      .FullRowSelect = True
      .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Clickable
      .HideSelection = False
      .Location = New System.Drawing.Point(0, 0)
      .MultiSelect = False
      .Name = "AncestorsList"
      .Size = New System.Drawing.Size(364, 351)
      .TabIndex = 4
      .UseCompatibleStateImageBehavior = False
      .OwnerDraw = True
      .View = System.Windows.Forms.View.Details
      .Tag = ""
      .Items.Clear()
      .Groups.Clear()
      .Columns.Clear()

      .Columns.Add("Name", CInt(.ClientSize.Width / 2))
      .Columns.Add("Lifespan", CInt(.ClientSize.Width / 2))
      .Columns.Add("", CInt(.ClientSize.Width / 2))
    End With
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    BackColor = My.Theme.PanelBackColor
    Controls.Add(AncestorsList)
    Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    ForeColor = My.Theme.PanelFontColor
    Margin = New System.Windows.Forms.Padding(0)
    Name = Key
    Size = New System.Drawing.Size(364, 351)
    Dock = DockStyle.Fill
    ResumeLayout(False)
    CaptureFocus(Me)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub Ancestors_ActiveAncestorChanged(ancestorId As String) Handles ancestors.ActiveAncestorChanged
    UpdateUI(False)
  End Sub

  Private Sub Ancestors_AncestorsChanged() Handles ancestors.AncestorsChanged
    UpdateUI()
  End Sub

  Private Sub AncestorsList_DoubleClick(sender As Object, e As EventArgs) Handles AncestorsList.DoubleClick
    Dim ActiveAncestorID As String = AncestorsList.SelectedItems.Item(0).Tag.ToString
    If Not ActiveAncestorID.Equals("") Then
      RaiseEvent AncestryNavigateRequest(ActiveAncestorID)
    End If
  End Sub

  Private Sub AncestorsList_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles AncestorsList.ItemSelectionChanged
    If e.IsSelected And Not blockEvents Then
      ancestors.ActiveAncestorID = e.Item.Tag.ToString
    End If
  End Sub

  Private Sub AncestorsList_Resize(sender As Object, e As EventArgs) Handles AncestorsList.Resize
    With AncestorsList.Columns
      If .Count > 0 Then
        .Item(0).Width = CInt((Width - 4) / 2)
        .Item(1).Width = CInt((Width - 4) / 2)
      End If
    End With
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
    blockEvents = True
    If reload Then
      With AncestorsList
        .Tag = ""
        .Items.Clear()
        For Each ancestor As AncestorCollection.Ancestor In ancestors.Values
          Dim item As ListViewItem
          item = .Items.Add(ancestor.FullName)
          item.SubItems.Add(ancestor.LifeSpan)
          item.Tag = ancestor.ID
        Next
      End With
    End If
    If ancestors.HasActiveAncestor Then
      For Each item As ListViewItem In AncestorsList.Items
        If item IsNot Nothing Then
          If item.Tag IsNot Nothing Then
            item.Selected = item.Tag.Equals(ancestors.ActiveAncestorID)
          End If
        End If
      Next
    End If
    blockEvents = False
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub ApplySearch(criteria As String)
    AncestorsList.Filter(criteria)
  End Sub

  Public Overrides Sub ClearSearch()
    AncestorsList.ClearFilter()
  End Sub

#End Region

End Class