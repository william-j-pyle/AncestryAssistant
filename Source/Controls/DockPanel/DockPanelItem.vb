Public MustInherit Class DockPanelItem
  Inherits UserControl

#Region "Fields"

  Protected Friend WithEvents ancestors As AncestorCollection
  Private _LocationCurrent As DockPanelLocation = DockPanelLocation.None

#End Region

#Region "Events"

  Public Event PanelItemClosed(sender As DockPanelItem, e As EventArgs)

  Public Event PanelItemGotFocus(sender As DockPanelItem, e As EventArgs)

  Public Event PanelItemMoved(sender As DockPanelItem, e As EventArgs)

  Public Event PanelItemOpened(sender As DockPanelItem, e As EventArgs)

#End Region

#Region "Properties"

  Public Property ItemCaption As String
  Public Property ItemHasFocus As Boolean
  Public Property ItemHasRibbonBar As Boolean
  Public Property ItemHasToolBar As Boolean
  Public Property ItemIsSuspended As Boolean
  Public Property ItemSupportsClose As Boolean
  Public Property ItemSupportsMove As Boolean
  Public Property ItemSupportsSearch As Boolean
  Public Property Key As String
  Public Property LocationCurrent As DockPanelLocation
    Get
      Return _LocationCurrent
    End Get
    Set(value As DockPanelLocation)
      If Not value.Equals(_LocationCurrent) Then
        _LocationPrevious = _LocationCurrent
        _LocationCurrent = value
        If value.Equals(DockPanelLocation.Tray) Then
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
          Logger.debugPrint("DockPanelItem.PanelItemClosed(panelItem=[{0},c={1},p={2}])", ItemCaption, _LocationCurrent.ToString, _LocationPrevious.ToString)
#End If

          RaiseEvent PanelItemClosed(Me, New EventArgs())
        ElseIf LocationPrevious.Equals(DockPanelLocation.Tray) Then
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
          Logger.debugPrint("DockPanelItem.PanelItemOpened(panelItem=[{0},c={1},p={2}])", ItemCaption, _LocationCurrent.ToString, _LocationPrevious.ToString)
#End If
          RaiseEvent PanelItemOpened(Me, New EventArgs())
        Else
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
          Logger.debugPrint("DockPanelItem.PanelItemMoved(panelItem=[{0},c={1},p={2}])", ItemCaption, _LocationCurrent.ToString, _LocationPrevious.ToString)
#End If
          RaiseEvent PanelItemMoved(Me, New EventArgs())
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

  Protected Overrides Sub OnGotFocus(e As EventArgs)
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("DockPanelItem.OnGotFocus(panelItem=[{0},c={1}])", ItemCaption, _LocationCurrent.ToString)
#End If
    RaiseEvent PanelItemGotFocus(Me, e)
  End Sub

  Protected MustOverride Sub UpdateUI(Optional reload As Boolean = True)

#End Region

#Region "Public Methods"

  Public MustOverride Sub ApplySearch(criteria As String)

  Public MustOverride Sub ClearSearch()

  Public Sub SetAncestors(ancestorsObj As AncestorCollection)
    ancestors = ancestorsObj
    UpdateUI()
  End Sub

#End Region

End Class