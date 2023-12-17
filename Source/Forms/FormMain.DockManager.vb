Partial Class AssistantAppForm

  Private Sub DockManager_PanelItemEvent(panelItem As DockPanelItem, eventType As DockPanelItemEventType, eventData As Object) Handles DockManager.PanelItemEvent
#If TRACE Then
    Logger.debugPrint("FormMain.PanelItemEvent(panelItem=[{0}], eventType=[{1}])", panelItem.Name, eventType.ToString)
#End If
    Select Case eventType
      Case DockPanelItemEventType.ItemClosed
        If panelItem.ItemHasRibbonBar And panelItem.RibbonHideOnItemClose Then
          RibbonBar.HideBar(panelItem.RibbonBarKey)
        End If
      Case DockPanelItemEventType.ItemOpened
        If panelItem.ItemHasRibbonBar And panelItem.RibbonShowOnItemOpen Then
          panelItem.ItemIsSuspended = False
          RibbonBar.ShowBar(panelItem.RibbonBarKey)
        End If
      Case DockPanelItemEventType.ItemSelected
        If panelItem.ItemHasRibbonBar And panelItem.RibbonShowOnItemOpen Then
          RibbonBar.ShowBar(panelItem.RibbonBarKey)
        End If
      Case DockPanelItemEventType.NavRequested
        DockManager.ItemEventRequest(DPIWebBrowser.Base_Key, eventType, eventData)
    End Select
  End Sub

  Private Function DockManagerItem_AncestorDetails() As DockPanelItem
    Return New DPIAncestorDetails() With {
      .Ancestors = Ancestors
    }
  End Function

  Private Function DockManagerItem_AncestorsList() As DockPanelItem
    Return New DPIAncestorsList() With {
      .Ancestors = Ancestors
    }
  End Function

  Private Function DockManagerItem_Census() As DockPanelItem
    Return New DPICensus() With {
      .Ancestors = Ancestors
    }
  End Function

  Private Function DockManagerItem_ImageGallery() As DockPanelItem
    Return New DPIImageGallery With {
            .ItemSuspendOnClose = True,
            .Ancestors = Ancestors
          }
  End Function

  Private Function DockManagerItem_Notebook() As DockPanelItem
    Return New DPINotebook() With {
      .Ancestors = Ancestors
    }
  End Function

  Private Function DockManagerItem_WebBrowser() As DockPanelItem
    Return New DPIWebBrowser With {
      .AncestryTreeID = My.Settings.ANCESTRY_TREE_ID,
      .Ancestors = Ancestors
    }
  End Function

  Private Sub InitDockManagerExtension() Handles Me.InitUIExtensions
#If TRACE Then
    Logger.debugPrint("FormMain.InitDockManagerExtension()")
#End If

    DockManager.ItemRegister(DPIWebBrowser.Base_Key, AddressOf DockManagerItem_WebBrowser)

    DockManager.ItemRegister(DPINotebook.Base_Key, AddressOf DockManagerItem_Notebook)

    DockManager.ItemRegister(DPICensus.Base_Key, AddressOf DockManagerItem_Census)

    DockManager.ItemRegister(DPIAncestorDetails.Base_Key, AddressOf DockManagerItem_AncestorDetails)

    DockManager.ItemRegister(DPIAncestorsList.Base_Key, AddressOf DockManagerItem_AncestorsList)

    DockManager.ItemRegister(DPIImageGallery.Base_Key, AddressOf DockManagerItem_ImageGallery)

    DockManager.SettingsLoad()

  End Sub

End Class