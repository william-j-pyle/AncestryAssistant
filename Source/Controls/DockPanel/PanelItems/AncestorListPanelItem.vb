Imports AncestryAssistant.AncestorCollection

Public Class AncestorsListPanel
  Inherits System.Windows.Forms.UserControl
  Implements IDockPanelItem

#Region "Fields"

  Private WithEvents Ancestors As AncestorCollection
  Private WithEvents AncestorsList As FlatListView

  Private Const EN_ITEMCAPTION As String = "Ancestors List"
  Private ActiveAncestorID As String = String.Empty
  Private blockEvents As Boolean = False

  Private components As System.ComponentModel.IContainer

#End Region

#Region "Events"

  Public Event AncestorAssigned() Implements IDockPanelItem.AncestorAssigned

  Public Event AncestorIDChanged(AncestorID As String)

  Public Event AncestorUpdated() Implements IDockPanelItem.AncestorUpdated

  Public Event AncestryNavigateRequest(AncestorID As String)

  Public Event PanelCloseClicked(sender As Object)

  Public Event PanelItemGotFocus(sender As Object, e As EventArgs) Implements IDockPanelItem.PanelItemGotFocus

#End Region

#Region "Properties"

  Public Property ItemAwake As Boolean = False Implements IDockPanelItem.ItemAwake
  Public ReadOnly Property ItemCaption As String = EN_ITEMCAPTION Implements IDockPanelItem.ItemCaption
  Public Property ItemDockPanelLocation As DockPanelLocation Implements IDockPanelItem.ItemDockPanelLocation
  Public Property ItemHasFocus As Boolean = False Implements IDockPanelItem.ItemHasFocus
  Public ReadOnly Property ItemHasRibbonBar As Boolean = False Implements IDockPanelItem.ItemHasRibbonBar
  Public ReadOnly Property ItemHasToolBar As Boolean = False Implements IDockPanelItem.ItemHasToolBar
  Public ReadOnly Property ItemSupportsClose As Boolean = True Implements IDockPanelItem.ItemSupportsClose
  Public ReadOnly Property ItemSupportsMove As Boolean = True Implements IDockPanelItem.ItemSupportsMove
  Public ReadOnly Property ItemSupportsSearch As Boolean = True Implements IDockPanelItem.ItemSupportsSearch
  Public ReadOnly Property Key As String Implements IDockPanelItem.Key
  Public ReadOnly Property ShowRibbonOnFocus As String = String.Empty Implements IDockPanelItem.ShowRibbonOnFocus

#End Region

#Region "Public Constructors"

  Public Sub New(itemKey As String)
    Key = itemKey
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
    Name = "AncestorsListPanel"
    Size = New System.Drawing.Size(364, 351)
    Dock = DockStyle.Fill
    ResumeLayout(False)

    CaptureFocus(Me)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub Ancestors_ActiveAncestorChanged(ancestorId As String) Handles Ancestors.ActiveAncestorChanged
    UpdateUI(False)
  End Sub

  Private Sub Ancestors_AncestorsChanged() Handles Ancestors.AncestorsChanged
    UpdateUI()
  End Sub

  Private Sub AncestorsList_DoubleClick(sender As Object, e As EventArgs) Handles AncestorsList.DoubleClick
    ActiveAncestorID = AncestorsList.SelectedItems.Item(0).Tag.ToString
    If Not ActiveAncestorID.Equals("") Then
      RaiseEvent AncestryNavigateRequest(ActiveAncestorID)
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

  Private Sub CaptureFocus(ctl As Control)
    Try
      AddHandler ctl.GotFocus, AddressOf DockPanelItem_GotFocus
      AddHandler ctl.MouseDown, AddressOf DockPanelItem_GotFocus
    Catch ex As Exception
    End Try
    For Each childCtl As Control In ctl.Controls
      CaptureFocus(childCtl)
    Next
  End Sub

  Private Sub DockPanelItem_GotFocus(sender As Object, e As EventArgs)
    RaiseEvent PanelItemGotFocus(sender, e)
  End Sub

  Private Sub UpdateUI(Optional reload As Boolean = True)
    If Ancestors Is Nothing Then Exit Sub
    blockEvents = True
    If reload Then
      With AncestorsList
        .Tag = ""
        .Items.Clear()
        For Each ancestor As AncestorCollection.Ancestor In Ancestors.Values
          Dim item As ListViewItem
          item = .Items.Add(ancestor.FullName)
          item.SubItems.Add(ancestor.LifeSpan)
          item.Tag = ancestor.ID
        Next
      End With
    End If
    If Ancestors.HasActiveAncestor Then
      For Each item As ListViewItem In AncestorsList.Items
        If item IsNot Nothing Then
          If item.Tag IsNot Nothing Then
            item.Selected = item.Tag.Equals(Ancestors.ActiveAncestorID)
          End If
        End If
      Next
    End If
    blockEvents = False
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

#End Region

#Region "Public Methods"

  Public Sub ApplySearch(criteria As String) Implements IDockPanelItem.ApplySearch
    AncestorsList.Filter(criteria)
  End Sub

  Public Sub ClearSearch() Implements IDockPanelItem.ClearSearch
    AncestorsList.ClearFilter()
  End Sub

  Public Function GetDockToolBarConfig() As DockToolBarConfig Implements IDockPanelItem.GetDockToolBarConfig
    Return Nothing
  End Function

  Public Function GetRibbonBarConfig() As RibbonBarTabConfig Implements IDockPanelItem.GetRibbonBarConfig
    Return Nothing
  End Function

  Public Sub SetAncestors(AncestorsObj As AncestorCollection) Implements IDockPanelItem.SetAncestors
    Ancestors = AncestorsObj
    UpdateUI()
  End Sub

#End Region

End Class