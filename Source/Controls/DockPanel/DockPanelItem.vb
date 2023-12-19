Public MustInherit Class DockPanelItem
  Inherits UserControl

  Protected Friend WithEvents _Ancestors As AncestorCollection
  Private _ItemCaption As String = ""
  Protected Friend _LocationCurrent As DockPanelLocation
  Protected Friend blockEvents As Boolean = False
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
    Get
      If ItemInstanceKey.Length > 0 Then
        If _ItemCaption.Length > 0 Then
          Return _ItemCaption + " - " + ItemInstanceKey
        Else
          Return ItemInstanceKey
        End If
      Else
        Return _ItemCaption

      End If
    End Get
    Set(value As String)
      _ItemCaption = value
    End Set
  End Property
  Public Property ItemDestroyOnClose As Boolean = False
  Public Property ItemHasFocus As Boolean = False
  Public Property ItemHasRibbonBar As Boolean = False
  Public Property ItemHasStatusBar As Boolean = False
  Public Property ItemHasToolBar As Boolean = False
  Public Property ItemInstanceKey As String = ""
  Public Property ItemKey As String = String.Empty
  Public Property ItemPreRegister As Boolean = False

  Public Property ItemSupportsClose As Boolean = True

  Public Property ItemSupportsMove As Boolean = True

  Public Property ItemSupportsSearch As Boolean = False
  Public ReadOnly Property Key As String
    Get
      Return ItemKey + ItemInstanceKey
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

  Public Property LocationPrefered As DockPanelLocation = DockPanelLocation.MiddleTopLeft

  Public Property LocationPrevious As DockPanelLocation = DockPanelLocation.None

  Public Property RibbonBarKey As String = ""
  Public Property RibbonHideOnItemClose As Boolean = True

  Public Property RibbonSelectOnItemFocus As Boolean = True

  Public Property RibbonShowOnItemOpen As Boolean = True

  Public Event PanelItemEvent(panelItem As DockPanelItem, eventType As DockPanelItemEventType, eventData As Object)

  Private Sub DockPanelItem_GotFocus(sender As Object, e As EventArgs)
    OnGotFocus(e)
  End Sub

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

  Public MustOverride Sub ApplySearch(criteria As String)

  Public MustOverride Sub ClearSearch()

  Public MustOverride Sub EventRequest(eventType As DockPanelItemEventType, eventData As Object)

End Class