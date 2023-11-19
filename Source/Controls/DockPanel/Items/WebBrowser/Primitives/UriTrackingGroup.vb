Public Class UriTrackingGroup

#Region "Fields"

  Private UriTrackerConfig As List(Of UriTracks)

#End Region

#Region "Public Constructors"

  Public Sub New()
    UriTrackerConfig = New List(Of UriTracks) From {
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON, {"ancestryus", "facts"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_GALLERY_PERSON, {"ancestryus", "gallery"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_HINTS_PERSON, {"ancestryus", "hints"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_STORY_PERSON, {"ancestryus", "lifestory"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_GROUPVIEW_FAMILY, {"ancestryus", "tree", "familygroup"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_TREEVIEW_PERSON, {"ancestryus", "tree", "familyview"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_FANVIEW_PERSON, {"ancestryus", "tree", "fanview"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_PEDIGREEVIEW_PERSON, {"ancestryus", "tree", "pedigree"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_TREEVIEW_FAMILY, {"ancestryus", "tree", "family"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_GALLERY_TREE, {"ancestryus", "tree", "media"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_OVERVIEW_TREE, {"ancestryus", "tree", "recent"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_SETTINGS_TREE, {"ancestryus", "tree", "settings"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_HOME, {"ancestryus", "homepage", "loggedin"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_HOME_LOGGEDOUT, {"ancestryus", "homepage", "loggedout"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_HINTS_TREE, {"ancestryus", "allhints"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_MESSAGES, {"ancestryus", "messagecenter"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_DNA, {"ancestryus", "dna"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_VIEWER_IMAGE, {"ancestryus", "imageviewer-ui"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_VIEWER_MEDIA, {"ancestryus", "mediaui-viewer"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_SEARCH, {"ancestryus", "search"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY_LOGIN, {"ancestryus", "login"}),
      New UriTracks(UriTrackingGroupEnum.ANCESTRY, {"ancestryus"}),
      New UriTracks(UriTrackingGroupEnum.NEWSPAPERS, {" newspapers", "com"}),
      New UriTracks(UriTrackingGroupEnum.FINDAGRAVE_MEMORIAL, {"findagrave", "com", "memorial"}),
      New UriTracks(UriTrackingGroupEnum.FINDAGRAVE_VIEWER_IMAGE, {"images", "findagrave", "com", "photos"}),
      New UriTracks(UriTrackingGroupEnum.FINDAGRAVE, {"findagrave", "com"})
    }
  End Sub

#End Region

#Region "Public Methods"

  Public Function GetEnum(pageData() As String) As UriTrackingGroupEnum
    For Each track As UriTracks In UriTrackerConfig
      If track.Matches(pageData) Then
        Return track.UriTrackingGroup
      End If
    Next
    Return UriTrackingGroupEnum.CUSTOM
  End Function

#End Region

End Class