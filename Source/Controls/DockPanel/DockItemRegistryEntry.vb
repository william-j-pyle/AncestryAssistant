Public Class DockItemRegistryEntry

#Region "Properties"

  Public Property control As IDockPanelItem = Nothing
  Public Property currentLocation As DockPanelLocation = DockPanelLocation.Tray
  Public Property defaultLocation As DockPanelLocation = DockPanelLocation.Tray
  Public Property key As String = ""

#End Region

End Class