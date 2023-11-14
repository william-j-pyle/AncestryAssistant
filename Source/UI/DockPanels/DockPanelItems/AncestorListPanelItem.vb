Imports AncestryAssistant.AncestorCollection

Public Class AncestorsListPanel
  Inherits System.Windows.Forms.UserControl
  Implements IDockPanelItem

  Private Const EN_ITEMCAPTION As String = "Ancestors List"


  Private theme As UITheme = UITheme.GetInstance
  Private WithEvents AncestorsList As ListView

  Public Event AncestryNavigateRequest(AncestorID As String)
  Public Event AncestorIDChanged(AncestorID As String)
  Public Event PanelCloseClicked(sender As Object)
  Public Event PanelItemGotFocus(sender As Object, e As EventArgs) Implements IDockPanelItem.PanelItemGotFocus
  Public Event AncestorAssigned() Implements IDockPanelItem.AncestorAssigned
  Public Event AncestorUpdated() Implements IDockPanelItem.AncestorUpdated
  Private blockEvents As Boolean = False

  Public ReadOnly Property ItemCaption As String = EN_ITEMCAPTION Implements IDockPanelItem.ItemCaption
  Public ReadOnly Property ItemSupportsSearch As Boolean = True Implements IDockPanelItem.ItemSupportsSearch
  Public ReadOnly Property ItemSupportsClose As Boolean = True Implements IDockPanelItem.ItemSupportsClose
  Public ReadOnly Property ItemSupportsMove As Boolean = True Implements IDockPanelItem.ItemSupportsMove
  Public ReadOnly Property ItemHasRibbonBar As Boolean = False Implements IDockPanelItem.ItemHasRibbonBar
  Public ReadOnly Property ShowRibbonOnFocus As String = String.Empty Implements IDockPanelItem.ShowRibbonOnFocus
  Public ReadOnly Property ItemHasToolBar As Boolean = False Implements IDockPanelItem.ItemHasToolBar
  Public Property ItemDockPanelLocation As DockPanelLocation Implements IDockPanelItem.ItemDockPanelLocation
  Public Property ItemHasFocus As Boolean = False Implements IDockPanelItem.ItemHasFocus

  Public Sub New()
    AncestorsList = New System.Windows.Forms.ListView()
    SuspendLayout()
    '
    'AncestorsList
    '
    AncestorsList.AutoArrange = False
    AncestorsList.BackColor = theme.PanelBackColor
    AncestorsList.BorderStyle = System.Windows.Forms.BorderStyle.None
    AncestorsList.Dock = System.Windows.Forms.DockStyle.Fill
    AncestorsList.ForeColor = theme.PanelFontColor
    AncestorsList.FullRowSelect = True
    AncestorsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
    AncestorsList.HideSelection = False
    AncestorsList.Location = New System.Drawing.Point(0, 0)
    AncestorsList.MultiSelect = False
    AncestorsList.Name = "AncestorsList"
    AncestorsList.Size = New System.Drawing.Size(364, 351)
    AncestorsList.TabIndex = 4
    AncestorsList.UseCompatibleStateImageBehavior = False
    AncestorsList.View = System.Windows.Forms.View.Details
    '
    'AncestorsListPanel
    '
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    BackColor = theme.PanelBackColor
    Controls.Add(AncestorsList)
    Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    ForeColor = theme.PanelFontColor
    Margin = New System.Windows.Forms.Padding(0)
    Name = "AncestorsListPanel"
    Size = New System.Drawing.Size(364, 351)
    Dock = DockStyle.Fill
    ResumeLayout(False)

    With AncestorsList
      .Tag = ""
      .Items.Clear()
      .Groups.Clear()
      .Columns.Clear()
      .Columns.Add("Name", CInt(.Width / 2))
      .Columns.Add("Lifespan", CInt(.Width / 2))
    End With
  End Sub

  Private Sub AncestorsList_DoubleClick(sender As Object, e As EventArgs) Handles AncestorsList.DoubleClick
    Dim AncestorID As String = AncestorsList.SelectedItems.Item(0).Tag.ToString
    If Not AncestorID.Equals("") Then
      RaiseEvent AncestryNavigateRequest(AncestorID)
    End If
  End Sub

  Private Sub AncestorsList_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles AncestorsList.ItemSelectionChanged
    If e.IsSelected And Not blockEvents Then
      RaiseEvent AncestorIDChanged(e.Item.Tag)
    End If
  End Sub

  Public Sub setAncestors(Ancestors As AncestorCollection, Optional SelectedAncestorID As String = "")
    Dim item As ListViewItem
    blockEvents = True
    With AncestorsList
      .Tag = ""
      .Items.Clear()
      For Each ancestor As AncestorCollection.Ancestor In Ancestors.Values
        item = .Items.Add(ancestor.FullName)
        item.SubItems.Add(ancestor.LifeSpan)
        item.Tag = ancestor.ID
        If SelectedAncestorID.Equals(ancestor.ID) Then
          item.Selected = True
        End If
      Next
    End With
    blockEvents = False
  End Sub

  Public Sub setActiveAncestor(AncestorID As String)
    blockEvents = True
    For Each item As ListViewItem In AncestorsList.Items
      item.Selected = item.Tag.Equals(AncestorID)
    Next
    blockEvents = False
  End Sub

  Public Function GetRibbonBarConfig() As RibbonBarTabConfig Implements IDockPanelItem.GetRibbonBarConfig
    Throw New NotImplementedException()
  End Function

  Public Function GetDockToolBarConfig() As DockToolBarConfig Implements IDockPanelItem.GetDockToolBarConfig
    Throw New NotImplementedException()
  End Function

  Public Sub SetAncestor(activeAncestor As Ancestor) Implements IDockPanelItem.SetAncestor
    Throw New NotImplementedException()
  End Sub

  Public Sub RefreshAncestor() Implements IDockPanelItem.RefreshAncestor
    Throw New NotImplementedException()
  End Sub

  Public Sub ApplySearch(criteria As String) Implements IDockPanelItem.ApplySearch
    Throw New NotImplementedException()
  End Sub

  Public Sub ClearSearch() Implements IDockPanelItem.ClearSearch
    Throw New NotImplementedException()
  End Sub


#Region "Component Helper"
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
  Private components As System.ComponentModel.IContainer
#End Region

End Class
