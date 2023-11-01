Public Class EventTag
  Inherits AbstractTag

  Public Sub New(data As Gedcom, ownerID As String, eventType As String)
    MyBase.New(data, "EVNT", False, ownerID, eventType)
  End Sub

  Public Sub New(data As Gedcom, ownerID As String)
    MyBase.New(data, "EVNT", False, ownerID)
  End Sub

  ' Attributes
  Public Property eventType As String
  Public Property eventDate As GedDate
  Public Property placeID As String
  Public Property note As String
  Public Property text As String

  Public Overrides Sub generateID()
    ID = data.createID(GedTagEnum.TYPE_EVENT)
    If Not realTag.Equals(String.Empty) Then
      eventType = realTag
    End If
  End Sub

  Public Overrides Function processTag(key As String) As Boolean
    Select Case key
      Case "EVNT"

      Case "EVNT.TYPE"
        eventType = data.getString()

      Case "EVNT.DATE"
        eventDate = data.getDate()

      Case "EVNT.PLAC"
        placeID = data.getPlaceID()

      Case "EVNT.NOTE"
        note = data.getString()

      Case "EVNT.DATA"
        text = data.getString()

      Case "EVNT.SOUR"
        Dim tmp As New SourceRefTag(data, ID)

      Case "EVNT.OBJE"
        Dim tmp As New MediaRefTag(data, ID)

      Case Else
        Return False
    End Select
    Return True
  End Function


End class
