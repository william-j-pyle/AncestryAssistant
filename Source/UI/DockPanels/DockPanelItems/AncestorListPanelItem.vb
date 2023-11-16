﻿Imports AncestryAssistant.AncestorCollection

Public Class AncestorsListPanel
  Inherits System.Windows.Forms.UserControl
  Implements IDockPanelItem

#Region "Events"

  Public Event AncestorAssigned() Implements IDockPanelItem.AncestorAssigned

  Public Event AncestorIDChanged(AncestorID As String)

  Public Event AncestorUpdated() Implements IDockPanelItem.AncestorUpdated

  Public Event AncestryNavigateRequest(AncestorID As String)

  Public Event PanelCloseClicked(sender As Object)

  Public Event PanelItemGotFocus(sender As Object, e As EventArgs) Implements IDockPanelItem.PanelItemGotFocus

#End Region

#Region "Properties"

  Public ReadOnly Property ItemCaption As String = EN_ITEMCAPTION Implements IDockPanelItem.ItemCaption
  Public Property ItemDockPanelLocation As DockPanelLocation Implements IDockPanelItem.ItemDockPanelLocation
  Public Property ItemHasFocus As Boolean = False Implements IDockPanelItem.ItemHasFocus
  Public ReadOnly Property ItemHasRibbonBar As Boolean = False Implements IDockPanelItem.ItemHasRibbonBar
  Public ReadOnly Property ItemHasToolBar As Boolean = False Implements IDockPanelItem.ItemHasToolBar
  Public ReadOnly Property ItemSupportsClose As Boolean = True Implements IDockPanelItem.ItemSupportsClose
  Public ReadOnly Property ItemSupportsMove As Boolean = True Implements IDockPanelItem.ItemSupportsMove
  Public ReadOnly Property ItemSupportsSearch As Boolean = True Implements IDockPanelItem.ItemSupportsSearch
  Public ReadOnly Property ShowRibbonOnFocus As String = String.Empty Implements IDockPanelItem.ShowRibbonOnFocus

#End Region

#Region "Public Constructors"

  Public Sub New()
    AncestorsList = New System.Windows.Forms.ListView()
    SuspendLayout()
    '
    'AncestorsList
    '
    AncestorsList.AutoArrange = False
    AncestorsList.BackColor = My.Theme.PanelBackColor
    AncestorsList.BorderStyle = System.Windows.Forms.BorderStyle.None
    AncestorsList.Dock = System.Windows.Forms.DockStyle.Fill
    AncestorsList.ForeColor = My.Theme.PanelFontColor
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
    BackColor = My.Theme.PanelBackColor
    Controls.Add(AncestorsList)
    Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    ForeColor = My.Theme.PanelFontColor
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
      .Columns.Add("Name", CInt(.ClientSize.Width / 2))
      .Columns.Add("Lifespan", CInt(.ClientSize.Width / 2))
    End With
    CaptureFocus(Me)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub AncestorsList_DoubleClick(sender As Object, e As EventArgs) Handles AncestorsList.DoubleClick
    SelectedAncestorID = AncestorsList.SelectedItems.Item(0).Tag.ToString
    If Not SelectedAncestorID.Equals("") Then
      RaiseEvent AncestryNavigateRequest(SelectedAncestorID)
    End If
  End Sub

  Private Sub AncestorsList_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles AncestorsList.ItemSelectionChanged
    If e.IsSelected And Not blockEvents Then
      SelectedAncestorID = e.Item.Tag.ToString
      RaiseEvent AncestorIDChanged(SelectedAncestorID)
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

  Private Sub PopulateList(Optional filter As String = "")
    If Ancestors Is Nothing Then Exit Sub
    Dim item As ListViewItem
    blockEvents = True
    filter = filter.ToUpper
    With AncestorsList
      .Tag = ""
      .Items.Clear()
      For Each ancestor As AncestorCollection.Ancestor In Ancestors.Values
        If filter.Equals("") Or ancestor.FullName.ToUpper.Contains(filter) Or ancestor.LifeSpan.Contains(filter) Then
          item = .Items.Add(ancestor.FullName)
          item.SubItems.Add(ancestor.LifeSpan)
          item.Tag = ancestor.ID
          If SelectedAncestorID.Equals(ancestor.ID) Then
            item.Selected = True
          End If
        End If
      Next
    End With
    blockEvents = False
  End Sub

  Private Sub setSelectedAncestor()
    blockEvents = True
    For Each item As ListViewItem In AncestorsList.Items
      item.Selected = item.Tag.Equals(SelectedAncestorID)
    Next
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
    PopulateList(criteria)
  End Sub

  Public Sub ClearSearch() Implements IDockPanelItem.ClearSearch
    PopulateList()
  End Sub

  Public Function GetDockToolBarConfig() As DockToolBarConfig Implements IDockPanelItem.GetDockToolBarConfig
    Return Nothing
  End Function

  Public Function GetRibbonBarConfig() As RibbonBarTabConfig Implements IDockPanelItem.GetRibbonBarConfig
    Return Nothing
  End Function

  Public Sub RefreshAncestor() Implements IDockPanelItem.RefreshAncestor
  End Sub

  Public Sub setActiveAncestor(ActiveAncestorID As String)
    SelectedAncestorID = ActiveAncestorID
    setSelectedAncestor()
  End Sub

  Public Sub SetAncestor(activeAncestor As Ancestor) Implements IDockPanelItem.SetAncestor
  End Sub

  Public Sub setAncestors(AncestorsObj As AncestorCollection, Optional ActiveAncestorID As String = "")
    Ancestors = AncestorsObj
    SelectedAncestorID = ActiveAncestorID
    PopulateList()
    setSelectedAncestor()
  End Sub

#End Region

#Region "Fields"

  Private WithEvents AncestorsList As ListView
  Private Const EN_ITEMCAPTION As String = "Ancestors List"

  Private Ancestors As AncestorCollection
  Private blockEvents As Boolean = False
  Private components As System.ComponentModel.IContainer
  Private SelectedAncestorID As String = String.Empty

#End Region

End Class