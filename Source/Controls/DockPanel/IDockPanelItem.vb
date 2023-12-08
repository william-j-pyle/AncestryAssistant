Public Interface IDockPanelItem

#Region "Events"

  Event AncestorAssigned()

  Event AncestorUpdated()

  Event PanelItemGotFocus(sender As Object, e As EventArgs)

#End Region

#Region "Properties"

  Property ItemAwake As Boolean
  ReadOnly Property ItemCaption As String
  Property ItemDockPanelLocation As DockPanelLocation
  Property ItemHasFocus As Boolean
  ReadOnly Property ItemHasRibbonBar As Boolean
  ReadOnly Property ItemHasToolBar As Boolean
  ReadOnly Property ItemSupportsClose As Boolean
  ReadOnly Property ItemSupportsMove As Boolean
  ReadOnly Property ItemSupportsSearch As Boolean
  ReadOnly Property Key As String
  ReadOnly Property ShowRibbonOnFocus As String

#End Region

#Region "Public Methods"

  Sub ApplySearch(criteria As String)

  Sub ClearSearch()

  Function GetDockToolBarConfig() As DockToolBarConfig

  Function GetRibbonBarConfig() As RibbonBarTabConfig

  Sub SetAncestors(ancestors As AncestorCollection)

#End Region

End Interface