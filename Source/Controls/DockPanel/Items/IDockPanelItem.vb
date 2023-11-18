Public Interface IDockPanelItem

#Region "Events"

  Event AncestorAssigned()

  Event AncestorUpdated()

  Event PanelItemGotFocus(sender As Object, e As EventArgs)

#End Region

#Region "Properties"

  ReadOnly Property ItemCaption As String

  Property ItemDockPanelLocation As DockPanelLocation
  Property ItemHasFocus As Boolean
  ReadOnly Property ItemHasRibbonBar As Boolean
  ReadOnly Property ItemHasToolBar As Boolean
  ReadOnly Property ItemSupportsClose As Boolean
  ReadOnly Property ItemSupportsMove As Boolean
  ReadOnly Property ItemSupportsSearch As Boolean
  ReadOnly Property ShowRibbonOnFocus As String

#End Region

#Region "Public Methods"

  Sub ApplySearch(criteria As String)

  Sub ClearSearch()

  Function GetDockToolBarConfig() As DockToolBarConfig

  Function GetRibbonBarConfig() As RibbonBarTabConfig

  Sub RefreshAncestor()

  Sub SetAncestor(activeAncestor As AncestorCollection.Ancestor)

#End Region

End Interface