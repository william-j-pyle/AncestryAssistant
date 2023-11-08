Public Interface IDockPanel
  Event PanelFocusChanged(sender As IDockPanel, hasFocus As Boolean)
  Event PanelCloseRequested(sender As IDockPanel)

  Property PanelShowClose As Boolean
  Property PanelShowSearch As Boolean
  Property PanelShowPinned As Boolean
  Property PanelShowContextMenu As Boolean
  Property PanelHasFocus As Boolean
  Property PanelIsPinned As Boolean

  Property PanelBackColor As Color
  Property PanelBorderColor As Color
  Property PanelFontColor As Color
  Property PanelHighlightColor As Color
  Property PanelShadowColor As Color
  Property PanelAccentColor As Color

  ReadOnly Property PanelItemCount As Integer
  ReadOnly Property PanelCaption As String
  ReadOnly Property PanelSelectedItem As IDockPanelItem
  ReadOnly Property PanelSelectedIndex As Integer

  Sub SelectItemByIndex(index As Integer)
  Sub SelectItemByKey(key As String)

  Function AddItem(item As IDockPanelItem) As Integer
  Function GetItem(key As String) As IDockPanelItem
  Function GetItem(index As Integer) As IDockPanelItem
  Function RemoveItem(key As String) As IDockPanelItem
  Function RemoveItem(index As Integer) As IDockPanelItem

End Interface
