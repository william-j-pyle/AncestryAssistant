Imports AncestryAssistant.AncestorCollection

Public Class DPIAncestorsList
  Inherits DockPanelItem

  Private WithEvents AncestorsList As FlatListView
  Private components As System.ComponentModel.IContainer
  Public Const Base_Key As String = "DOCK_ANCESTORSLIST"

  Public Sub New(Optional instanceKey As String = "")
    ItemCaption = "Ancestors List"
    ItemDestroyOnClose = False
    ItemHasRibbonBar = False
    ItemHasStatusBar = False
    ItemHasToolBar = True
    ItemSupportsClose = True
    ItemSupportsMove = True
    ItemSupportsSearch = True
    LocationCurrent = DockPanelLocation.None
    LocationPrefered = DockPanelLocation.LeftTop
    LocationPrevious = DockPanelLocation.LeftTop
    RibbonBarKey = ""
    RibbonHideOnItemClose = False
    RibbonSelectOnItemFocus = False
    RibbonShowOnItemOpen = False
    ItemKey = Base_Key
    ItemInstanceKey = instanceKey
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
      .Size = New System.Drawing.Size(364, 351)
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

  Private Sub AncestorsList_DoubleClick(sender As Object, e As EventArgs) Handles AncestorsList.DoubleClick
    Dim ActiveAncestorID As String = AncestorsList.SelectedItems.Item(0).Tag.ToString
    If Not ActiveAncestorID.Equals("") Then
      InvokePanelItemEvent(DockPanelItemEventType.NavRequested, UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON)
    End If
  End Sub

  Private Sub AncestorsList_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles AncestorsList.ItemSelectionChanged
    If e.IsSelected And Not blockEvents Then
      Ancestors.ActiveAncestorID = e.Item.Tag.ToString
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

  Protected Overrides Sub UpdateUI(Optional reload As Boolean = True) Handles _Ancestors.AncestorsChanged
    If Ancestors Is Nothing Then Exit Sub
    blockEvents = True
    AncestorsList.SuspendLayout()
    If reload Then
      With AncestorsList
        .Tag = ""
        .Items.Clear()
        For Each Ancestor As AncestorCollection.Ancestor In Ancestors.Values
          Dim item As ListViewItem
          item = .Items.Add(Ancestor.FullName)
          item.SubItems.Add(Ancestor.LifeSpan)
          item.Tag = Ancestor.ID
        Next
      End With
    End If
    If Ancestors.HasActiveAncestor Then
      For Each item As ListViewItem In AncestorsList.Items
        If item IsNot Nothing Then
          If item.Tag IsNot Nothing Then
            item.Selected = item.Tag.Equals(Ancestors.ActiveAncestorID)
            If item.Selected Then
              item.Focused = True
            End If
          End If
        End If
      Next
    End If
    AncestorsList.ResumeLayout(True)
    blockEvents = False
  End Sub

  Protected Sub UpdateUISelection() Handles _Ancestors.ActiveAncestorChanged
    UpdateUI(False)
  End Sub

  Public Overrides Sub ApplySearch(criteria As String)
    AncestorsList.Filter(criteria)
  End Sub

  Public Overrides Sub ClearSearch()
    AncestorsList.ClearFilter()
  End Sub

  Public Overrides Sub EventRequest(eventType As DockPanelItemEventType, eventData As Object)
  End Sub

End Class