Public Interface IDockPanelItem

  ReadOnly Property ItemCaption As String

  ReadOnly Property ItemSupportsSearch As Boolean
  Sub ApplySearch(criteria As String)
  Sub ClearSearch()

  ReadOnly Property ItemSupportsClose As Boolean
  ReadOnly Property ItemSupportsMove As Boolean

  ReadOnly Property ItemHasRibbonBar As Boolean
  Function GetRibbonBarConfig() As RibbonBarTabConfig
  ReadOnly Property ShowRibbonOnFocus As String

  ReadOnly Property ItemHasToolBar As Boolean
  Function GetDockToolBarConfig() As DockToolBarConfig

  Property ItemDockPanelLocation As DockPanelLocation
  Property ItemHasFocus As Boolean

  Event PanelItemGotFocus(sender As Object, e As EventArgs)
  Event AncestorAssigned()
  Event AncestorUpdated()

  Sub SetAncestor(activeAncestor As AncestorCollection.Ancestor)
  Sub RefreshAncestor()

End Interface
