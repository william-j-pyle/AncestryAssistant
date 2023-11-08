Imports AncestryAssistant.AncestorCollection

Public Class AncestorsListPanel
  Implements IDockPanelItem

  Public Event AncestryNavigateRequest(AncestorID As String)
  Public Event AncestorIDChanged(AncestorID As String)
  Public Event PanelCloseClicked(sender As Object)

  Private blockEvents As Boolean = False

  Public ReadOnly Property ItemCaption As String Implements IDockPanelItem.ItemCaption
    Get
      Return "Ancestors List"
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
    Dim AncestorID As String = AncestorsList.SelectedItems.Item(0).Tag
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


  Private Sub JDockPanelHeader_HeaderCloseClicked()
    RaiseEvent PanelCloseClicked(Me)
  End Sub

  Private Sub AncestorsList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AncestorsList.SelectedIndexChanged

  End Sub
End Class
