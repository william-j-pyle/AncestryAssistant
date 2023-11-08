Public Class UriTrackingGroup
  Private UriTrackerConfig As List(Of UriTracks)

  Public Sub New()
    UriTrackerConfig = New List(Of UriTracks)
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON, {"ancestryus", "facts"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON, {"ancestryus", "gallery"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON, {"ancestryus", "hints"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_STORY_PERSON, {"ancestryus", "lifestory"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_GROUPVIEW_FAMILY, {"ancestryus", "tree", "familygroup"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_TREEVIEW_PERSON, {"ancestryus", "tree", "familyview"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_FANVIEW_PERSON, {"ancestryus", "tree", "fanview"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_PEDIGREEVIEW_PERSON, {"ancestryus", "tree", "pedigree"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_TREEVIEW_FAMILY, {"ancestryus", "tree", "family"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_GALLERY_TREE, {"ancestryus", "tree", "media"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_OVERVIEW_TREE, {"ancestryus", "tree", "recent"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_SETTINGS_TREE, {"ancestryus", "tree", "settings"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_HOME, {"ancestryus", "homepage", "loggedin"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_HOME_LOGGEDOUT, {"ancestryus", "homepage", "loggedout"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_HINTS_TREE, {"ancestryus", "allhints"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_MESSAGES, {"ancestryus", "messagecenter"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_DNA, {"ancestryus", "dna"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_VIEWER_IMAGE, {"ancestryus", "imageviewer-ui"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_VIEWER_MEDIA, {"ancestryus", "mediaui-viewer"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_SEARCH, {"ancestryus", "search"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY_LOGIN, {"ancestryus", "login"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.ANCESTRY, {"ancestryus"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.NEWSPAPERS, {" newspapers", "com"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.FINDAGRAVE_MEMORIAL, {"findagrave", "com", "memorial"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.FINDAGRAVE_VIEWER_IMAGE, {"images", "findagrave", "com", "photos"}))
    UriTrackerConfig.Add(New UriTracks(UriTrackingGroupEnum.FINDAGRAVE, {"findagrave", "com"}))
  End Sub

  Public Function getEnum(pageData() As String) As UriTrackingGroupEnum
    For Each track As UriTracks In UriTrackerConfig
      If track.Matches(pageData) Then
        Return track.UriTrackingGroup
      End If
    Next
    Return UriTrackingGroupEnum.CUSTOM
  End Function

End Class