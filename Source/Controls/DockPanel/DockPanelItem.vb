Public MustInherit Class DockPanelItem
  Inherits UserControl

#Region "Fields"

  Protected Friend WithEvents _Ancestors As AncestorCollection
  Private _ItemIsSuspended As Boolean = False
  Private _LocationCurrent As DockPanelLocation = DockPanelLocation.None

#End Region

  'Public Event PanelItemClosed(panelItem As DockPanelItem, e As EventArgs)

  'Public Event PanelItemGotFocus(panelItem As DockPanelItem, e As EventArgs)

  'Public Event PanelItemMoved(panelItem As DockPanelItem, e As EventArgs)

  'Public Event PanelItemOpened(panelItem As DockPanelItem, e As EventArgs)

#Region "Events"

  Public Event PanelItemEvent(panelItem As DockPanelItem, eventType As DockPanelItemEventType, eventData As Object)

#End Region

#Region "Properties"

  Public Property Ancestors As AncestorCollection
    Get
      Return _Ancestors
    End Get
    Set(value As AncestorCollection)
      _Ancestors = value
      UpdateUI()
    End Set
  End Property
  Public Property ItemCaption As String
  Public Property ItemHasFocus As Boolean
  Public Property ItemHasRibbonBar As Boolean
  Public Property ItemHasStatusBar As Boolean
  Public Property ItemHasToolBar As Boolean
  Public Property ItemInstanceKey As String
  Public Property ItemIsSuspended As Boolean
    Get
      Return _ItemIsSuspended
    End Get
    Set(value As Boolean)
      If Not value.Equals(_ItemIsSuspended) Then
        _ItemIsSuspended = value
        If Not _ItemIsSuspended Then UpdateUI()
      End If
    End Set
  End Property
  Public Property ItemKey As String
  Public Property ItemPreRegister As Boolean = True
  Public Property ItemSupportsClose As Boolean
  Public Property ItemSupportsMove As Boolean
  Public Property ItemSupportsSearch As Boolean
  Public Property ItemSuspendOnClose As Boolean = False
  Public ReadOnly Property Key As String
    Get
      If Len(ItemInstanceKey) > 0 Then
        Return ItemKey + "_" + ItemInstanceKey
      Else
        Return ItemKey
      End If
    End Get
  End Property
  Public Property LocationCurrent As DockPanelLocation
    Get
      Return _LocationCurrent
    End Get
    Set(value As DockPanelLocation)
      If Not value.Equals(_LocationCurrent) Then
        _LocationPrevious = _LocationCurrent
        _LocationCurrent = value
        If value.Equals(DockPanelLocation.Tray) Or value.Equals(DockPanelLocation.None) Then
          RaiseEvent PanelItemEvent(Me, DockPanelItemEventType.ItemClosed, Nothing)
        ElseIf LocationPrevious.Equals(DockPanelLocation.Tray) Or LocationPrevious.Equals(DockPanelLocation.None) Then
          RaiseEvent PanelItemEvent(Me, DockPanelItemEventType.ItemClosed, Nothing)
        Else
          RaiseEvent PanelItemEvent(Me, DockPanelItemEventType.ItemLocationChanged, value)
        End If
      End If
    End Set
  End Property
  Public Property LocationPrefered As DockPanelLocation = DockPanelLocation.Tray
  Public Property LocationPrevious As DockPanelLocation
  Public Property RibbonBarKey As String = String.Empty
  Public Property RibbonHideOnItemClose As Boolean = True
  Public Property RibbonSelectOnItemFocus As Boolean = False
  Public Property RibbonShowOnItemOpen As Boolean = False

#End Region

#Region "Private Methods"

  Private Sub DockPanelItem_GotFocus(sender As Object, e As EventArgs)
    OnGotFocus(e)
  End Sub

#End Region

#Region "Protected Methods"

  Protected Sub CaptureFocus(ctl As Control)
    Try
      AddHandler ctl.GotFocus, AddressOf DockPanelItem_GotFocus
      AddHandler ctl.MouseDown, AddressOf DockPanelItem_GotFocus
    Catch ex As Exception
    End Try
    For Each childCtl As Control In ctl.Controls
      CaptureFocus(childCtl)
    Next
  End Sub

  Protected Sub InvokePanelItemEvent(EventType As DockPanelItemEventType, eventData As Object)
    RaiseEvent PanelItemEvent(Me, EventType, eventData)
  End Sub

  Protected Overrides Sub OnGotFocus(e As EventArgs)
#If TRACE Then
    Logger.debugPrint("DockPanelItem.OnGotFocus(panelItem=[{0},c={1}])", ItemCaption, _LocationCurrent.ToString)
#End If
    RaiseEvent PanelItemEvent(Me, DockPanelItemEventType.ItemFocusChanged, True)
  End Sub

  Protected MustOverride Sub UpdateUI(Optional reload As Boolean = True)

#End Region

#Region "Public Methods"

  Public MustOverride Sub ApplySearch(criteria As String)

  Public MustOverride Sub ClearSearch()

  Public MustOverride Sub EventRequest(eventType As DockPanelItemEventType, eventData As Object)

#End Region

End Class