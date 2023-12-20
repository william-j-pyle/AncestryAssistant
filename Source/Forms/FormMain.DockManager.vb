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
          RibbonBar.ShowBar(panelItem.RibbonBarKey)
        End If
      Case DockPanelItemEventType.ItemSelected
        If panelItem.ItemHasRibbonBar And panelItem.RibbonShowOnItemOpen Then
          RibbonBar.ShowBar(panelItem.RibbonBarKey)
        End If
      Case DockPanelItemEventType.NavRequested
        DockManager.ItemEventRequest(DPIWebBrowser.Base_Key, eventType, eventData)
      Case DockPanelItemEventType.ItemBusy
        If CBool(eventData) Then
          UseWaitCursor = True
          Cursor = Cursors.WaitCursor
          DockManager.ItemShow(panelItem.Key)
        Else
          UseWaitCursor = False
          Cursor = Cursors.Default
        End If
    End Select
  End Sub

  Private Function DockManagerItem_AncestorDetails(Optional instanceKey As String = "", Optional ancestorId As String = "") As DockPanelItem
    Return New DPIAncestorDetails(instanceKey) With {
      .Ancestors = Ancestors
    }
  End Function

  Private Function DockManagerItem_AncestorListWeb(Optional instanceKey As String = "", Optional ancestorId As String = "") As DockPanelItem
    Return New DPIAncestorListWeb(instanceKey) With {
      .Ancestors = Ancestors
    }
  End Function

  Private Function DockManagerItem_AncestorsList(Optional instanceKey As String = "", Optional ancestorId As String = "") As DockPanelItem
    Return New DPIAncestorsList(instanceKey) With {
      .Ancestors = Ancestors
    }
  End Function

  Private Function DockManagerItem_CensusWeb(Optional instanceKey As String = "", Optional ancestorId As String = "") As DockPanelItem
    Return New DPICensusWeb(instanceKey, ancestorId) With {
      .Ancestors = Ancestors
    }
  End Function

  Private Function DockManagerItem_ImageGallery(Optional instanceKey As String = "", Optional ancestorId As String = "") As DockPanelItem
    Return New DPIImageGallery(instanceKey) With {
            .Ancestors = Ancestors
          }
  End Function

  Private Function DockManagerItem_ImageGalleryWeb(Optional instanceKey As String = "", Optional ancestorId As String = "") As DockPanelItem
    Return New DPIImageGalleryWeb(instanceKey) With {
      .Ancestors = Ancestors
    }
  End Function

  Private Function DockManagerItem_Notebook(Optional instanceKey As String = "", Optional ancestorId As String = "") As DockPanelItem
    Return New DPINotebook(instanceKey) With {
      .Ancestors = Ancestors
    }
  End Function

  Private Function DockManagerItem_WebBrowser(Optional instanceKey As String = "", Optional ancestorId As String = "") As DockPanelItem
    Return New DPIWebBrowser(instanceKey) With {
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

    DockManager.ItemRegister(DPICensusWeb.Base_Key, AddressOf DockManagerItem_CensusWeb)

    DockManager.ItemRegister(DPIAncestorDetails.Base_Key, AddressOf DockManagerItem_AncestorDetails)

    DockManager.ItemRegister(DPIAncestorListWeb.Base_Key, AddressOf DockManagerItem_AncestorListWeb)

    DockManager.ItemRegister(DPIImageGalleryWeb.Base_Key, AddressOf DockManagerItem_ImageGalleryWeb)

    DockManager.SettingsLoad()

  End Sub

End Class