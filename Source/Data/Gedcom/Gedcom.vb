Imports System.Text

Public Class Gedcom

  Private fileData As List(Of FileLineEntry)
  Private fileIndex As Integer
  Public events As List(Of EventTag)
  Public facts As List(Of FactTag)
  Public family As List(Of FamilyTag)
  Public familyref As List(Of FamilyRefTag)
  Public header As HeaderTag
  Public media As List(Of MediaTag)
  Public mediaRefs As List(Of MediaRefTag)
  Public names As List(Of NameTag)
  Public people As List(Of IndividualTag)
  Public places As List(Of PlaceTag)
  Public repositories As List(Of RepositoryTag)
  Public sourceRefs As List(Of SourceRefTag)
  Public sources As List(Of SourceTag)
  Public tagrefs As List(Of MttagRefTag)
  Public tags As List(Of MttagTag)

  Public ReadOnly Property data() As String
    Get
      Return fileData.Item(fileIndex).line
    End Get
  End Property

  Public ReadOnly Property fileLine As FileLineEntry
    Get
      Return fileData.Item(fileIndex)
    End Get
  End Property

  Public ReadOnly Property Filename As String
  Public ReadOnly Property key As String
    Get
      Return fileData.Item(fileIndex).keyFlat

    End Get
  End Property

  Public ReadOnly Property lineData() As String
    Get
      Return fileData.Item(fileIndex).lineData
    End Get
  End Property

  Public ReadOnly Property lineLevel As Integer
    Get
      Return fileData.Item(fileIndex).lineLvl
    End Get
  End Property

  Public ReadOnly Property refKey() As String
    Get
      Return fileData.Item(fileIndex).lineRef
    End Get
  End Property

  Public ReadOnly Property tag As String
    Get
      Return fileData.Item(fileIndex).lineTag
    End Get
  End Property

  Public Sub New(gedFilename As String)
    header = Nothing
    places = New List(Of PlaceTag)
    media = New List(Of MediaTag)
    sources = New List(Of SourceTag)
    repositories = New List(Of RepositoryTag)
    facts = New List(Of FactTag)
    tags = New List(Of MttagTag)
    names = New List(Of NameTag)
    sourceRefs = New List(Of SourceRefTag)
    people = New List(Of IndividualTag)
    events = New List(Of EventTag)
    mediaRefs = New List(Of MediaRefTag)
    tagrefs = New List(Of MttagRefTag)
    family = New List(Of FamilyTag)
    familyref = New List(Of FamilyRefTag)
    fileData = New List(Of FileLineEntry)
    Filename = gedFilename
    ' LOAD FILE
    Dim keyParts() As String = {"", "", "", "", "", "", "", ""}
    Dim keyFlat As StringBuilder
    Dim lineParts() As String
    Dim lineLvl As Integer
    Dim lineIdx As Double = 0
    Dim lineTag As String
    Dim lineRef As String
    Dim lineData As String
    For Each line As String In System.IO.File.ReadAllLines(Filename)
      lineIdx += 1
      lineParts = line.Split(" ")
      lineLvl = CInt(lineParts(0))
      lineTag = lineParts(1)
      lineRef = ""
      lineData = ""
      If lineTag.StartsWith("@") Then
        lineRef = lineTag
        lineTag = lineParts(2)
      End If
      keyParts(lineLvl) = lineTag
      If lineParts.Length > 2 Then
        If lineParts(2).StartsWith("@") Then
          lineRef = lineParts(2)
        Else
          lineData = line.Substring(lineParts(0).Length() + lineParts(1).Length() + 2)
        End If
      End If
      keyFlat = New StringBuilder(keyParts(0))
      For keyIdx As Integer = 1 To lineLvl
        keyFlat.Append(".").Append(keyParts(keyIdx))
      Next
      fileData.Add(New FileLineEntry(lineIdx, lineLvl, lineTag, lineRef, lineData, keyFlat.ToString(), line))
    Next
    ' PROOCESS FILE
    rewind()
    While HasNext()
      Dim success As Boolean = False
      If tag.Equals(HeaderTag.GEDCOM_TAG) Then success = NewHeaderTag() IsNot Nothing
      If tag.Equals(MediaTag.GEDCOM_TAG) Then success = NewMediaTag() IsNot Nothing
      If tag.Equals(SourceTag.GEDCOM_TAG) Then success = NewSourceTag() IsNot Nothing
      If tag.Equals(RepositoryTag.GEDCOM_TAG) Then success = NewRepositoryTag() IsNot Nothing
      If tag.Equals(MttagTag.GEDCOM_TAG) Then success = NewMttagTag() IsNot Nothing
      If tag.Equals(IndividualTag.GEDCOM_TAG) Then success = NewIndividualTag() IsNot Nothing
      If tag.Equals(FamilyTag.GEDCOM_TAG) Then success = NewFamilyTag() IsNot Nothing
      If Not success And Not key.StartsWith("SUBM") Then
        Debug.Print("MISSING TAG_HANDLER: [tag={}, key={}]", tag, key)
      End If
      nextRow()
    End While
    If header IsNot Nothing Then
      header.mediaCount = media.Count()
      header.personCount = people.Count()
      header.sourceCount = sources.Count()
      header.familyCount = family.Count()
    End If
  End Sub

  Private Function SetIndex(value As Integer) As Boolean
    Dim SetVal As Integer = value
    If value < 0 Then
      fileIndex = 0
      Return False
    End If
    If value >= fileData.Count() Then
      fileIndex = fileData.Count() - 1
      Return False
    End If
    fileIndex = value
    Return True
  End Function

  Public Function addObject(obj As Object) As String

    If (TypeOf obj Is PlaceTag) Then
      Dim item As PlaceTag = obj
      places.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is MediaTag) Then
      Dim item As MediaTag = obj
      media.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is MediaRefTag) Then
      Dim item As MediaRefTag = obj
      mediaRefs.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is SourceTag) Then
      Dim item As SourceTag = obj
      sources.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is HeaderTag) Then
      header = obj
      header.fileName = Filename
      Return header.ID
    End If

    If (TypeOf obj Is RepositoryTag) Then
      Dim item As RepositoryTag = obj
      repositories.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is MttagTag) Then
      Dim item As MttagTag = obj
      tags.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is MttagRefTag) Then
      Dim item As MttagRefTag = obj
      tagrefs.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is FactTag) Then
      Dim item As FactTag = obj
      facts.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is NameTag) Then
      Dim item As NameTag = obj
      names.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is IndividualTag) Then
      Dim item As IndividualTag = obj
      people.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is SourceRefTag) Then
      Dim item As SourceRefTag = obj
      sourceRefs.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is EventTag) Then
      Dim item As EventTag = obj
      events.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is FamilyRefTag) Then
      Dim item As FamilyRefTag = obj
      familyref.Add(item)
      Return item.ID
    End If

    If (TypeOf obj Is FamilyTag) Then
      Dim item As FamilyTag = obj
      family.Add(item)
      Return item.ID
    End If

    Debug.Print("Failed to add unknown class:  {}", obj.getClass().getSimpleName())
    Return "@-@"
  End Function

  Public Function createID(tag As GedTagEnum, refID As String) As String
    Dim id As String = ""
    If Not refID.Equals(String.Empty) Then
      If Not refID.StartsWith("@") Then
        Return refID
      End If
      id = refID.Replace("@", "").Replace("_", "0")
      id = id.Replace("O", "")
      id = id.Replace("I", "")
      id = id.Replace("E", "")
      id = id.Replace("A", "")
      id = id.Replace("F", "")
      id = id.Replace("T", "")
      id = id.Replace("L", "")
      id = id.Replace("R", "")
      id = id.Replace("S", "")
      id = id.Replace("N", "")
    End If
    Select Case tag
      Case GedTagEnum.TYPE_EVENT
        id = "EV" & (events.Count() + 1)
      Case GedTagEnum.TYPE_FACT
        id = "FT" & (facts.Count() + 1)
      Case GedTagEnum.TYPE_FAMILY
        id = "FA" + id
      Case GedTagEnum.TYPE_INDIVIDUAL
        id = "IN" + id
      Case GedTagEnum.TYPE_MEDIA_REF
        id = "ME" + id
      Case GedTagEnum.TYPE_MEDIA
        id = "ME" + id
      Case GedTagEnum.TYPE_MTTAG_REF
        id = "TG" + id
      Case GedTagEnum.TYPE_MTTAG
        id = "TG" + id
      Case GedTagEnum.TYPE_NAME
        id = "NM" & (names.Count() + 1)
      Case GedTagEnum.TYPE_PLACE
        id = "PL" & (places.Count() + 1)
      Case GedTagEnum.TYPE_REPOSITORY
        id = "RP" + id
      Case GedTagEnum.TYPE_SOURCE_REF
        id = "SR" + id
      Case GedTagEnum.TYPE_SOURCE
        id = "SR" + id
    End Select
    Return id
  End Function

  Public Function createID(tag As GedTagEnum) As String
    Return createID(tag, String.Empty)
  End Function

  Public Function GetDate() As GedDate
    Return New GedDate(lineData())
  End Function

  Public Function GetIndex() As Integer
    Return fileIndex
  End Function

  Public Function GetInt() As Integer
    Return CInt(lineData())
  End Function

  Public Function GetOwnerTagType(ownerID As String) As GedTagEnum
    Select Case ownerID.Substring(0, 2)
      Case "EV"
        Return GedTagEnum.TYPE_EVENT
      Case "FT"
        Return GedTagEnum.TYPE_FACT
      Case "FA"
        Return GedTagEnum.TYPE_FAMILY
      Case "IN"
        Return GedTagEnum.TYPE_INDIVIDUAL
      Case "ME"
        Return GedTagEnum.TYPE_MEDIA
      Case "TG"
        Return GedTagEnum.TYPE_MTTAG
      Case "NM"
        Return GedTagEnum.TYPE_NAME
      Case "PL"
        Return GedTagEnum.TYPE_PLACE
      Case "RP"
        Return GedTagEnum.TYPE_REPOSITORY
      Case "SR"
        Return GedTagEnum.TYPE_SOURCE
      Case Else
        Return GedTagEnum.INVALID
    End Select
  End Function

  Public Function GetOwnerType(ownerID As String) As String
    Return GetTagTypeName(GetOwnerTagType(ownerID))
  End Function

  Public Function GetString() As String
    Return multiLineData()
  End Function

  Public Function GetTagTypeName(tag As GedTagEnum) As String
    Select Case tag
      Case GedTagEnum.TYPE_EVENT
        Return "eventID"
      Case GedTagEnum.TYPE_FACT
        Return "factID"
      Case GedTagEnum.TYPE_FAMILY
        Return "familyID"
      Case GedTagEnum.TYPE_INDIVIDUAL
        Return "personID"
      Case GedTagEnum.TYPE_MEDIA_REF
        Return "mediaID"
      Case GedTagEnum.TYPE_MEDIA
        Return "mediaID"
      Case GedTagEnum.TYPE_MTTAG_REF
        Return "tagID"
      Case GedTagEnum.TYPE_MTTAG
        Return "tagID"
      Case GedTagEnum.TYPE_NAME
        Return "nameID"
      Case GedTagEnum.TYPE_PLACE
        Return "placeID"
      Case GedTagEnum.TYPE_REPOSITORY
        Return "repositoryID"
      Case GedTagEnum.TYPE_SOURCE_REF
        Return "sourceID"
      Case GedTagEnum.TYPE_SOURCE
        Return "sourceID"
      Case Else
        Return "unknownID"
    End Select
  End Function

  Public Function HasNext() As Boolean
    Return (fileIndex + 1) < fileData.Count()
  End Function

  Public Function multiLineData() As String
    Dim rtnData As New StringBuilder(fileData.Item(fileIndex).lineData)
    Dim myKey As String = fileData.Item(fileIndex).keyFlat
    While fileData.Item(fileIndex + 1).keyFlat.Equals(myKey + ".CONT") Or fileData.Item(fileIndex + 1).keyFlat.Equals(myKey + ".CONC")
      nextRow()
      If fileData.Item(fileIndex).keyFlat.EndsWith("CONC") Then
        rtnData.Append(fileData.Item(fileIndex).lineData)
      Else
        rtnData.AppendLine().Append(fileData.Item(fileIndex).lineData)
      End If
    End While
    Return rtnData.ToString()
  End Function

  Public Function NewEventTag(OwnerID As String, EventSubType As String) As EventTag
    Return New EventTag(Me, OwnerID, EventSubType)
  End Function

  Public Function NewFactTag(OwnerID As String, Optional FactType As String = "") As FactTag
    If FactType.Equals("") Then
      Return New FactTag(Me, OwnerID)
    Else
      Return New FactTag(Me, OwnerID, FactType)
    End If
  End Function

  Public Function NewFamilyRefTag(OwnerID As String, RefType As String) As FamilyRefTag
    Return New FamilyRefTag(Me, OwnerID)
  End Function

  Public Function NewFamilyTag() As FamilyTag
    Return New FamilyTag(Me)
  End Function

  Public Function NewHeaderTag() As HeaderTag
    Return New HeaderTag(Me)
  End Function

  Public Function NewIndividualTag() As IndividualTag
    Return New IndividualTag(Me)
  End Function

  Public Function NewMediaRefTag(OwnerID As String) As MediaRefTag
    Return New MediaRefTag(Me, OwnerID)
  End Function

  Public Function NewMediaTag() As MediaTag
    Return New MediaTag(Me)
  End Function

  Public Function NewMttagRefTag(OwnerID As String) As MttagRefTag
    Return New MttagRefTag(Me, OwnerID)
  End Function

  Public Function NewMttagTag() As MttagTag
    Return New MttagTag(Me)
  End Function

  Public Function NewNameTag(OwnerID As String) As NameTag
    Return New NameTag(Me, OwnerID)
  End Function

  Public Function NewPlaceTag(OwnerID As String) As PlaceTag
    Dim sPlace As String = multiLineData()
    If sPlace.Equals(String.Empty) Then
      Return Nothing
    End If
    Dim oPlace As PlaceTag = Nothing
    For Each tag As PlaceTag In places
      If tag.place.Equals(sPlace) Then
        Return tag
      End If
    Next
    If oPlace Is Nothing Then
      oPlace = New PlaceTag(sPlace, createID(GedTagEnum.TYPE_PLACE))
      places.Add(oPlace)
    End If
    Return oPlace
  End Function

  Public Function NewRepositoryTag() As RepositoryTag
    Return New RepositoryTag(Me)
  End Function

  Public Function NewSourceRefTag(OwnerID As String) As SourceRefTag
    Return New SourceRefTag(Me, OwnerID)
  End Function

  Public Function NewSourceTag() As SourceTag
    Return New SourceTag(Me)
  End Function

  Public Function nextRow() As Boolean
    Return SetIndex(fileIndex + 1)
  End Function

  Public Function prevRow() As Boolean
    Return SetIndex(fileIndex - 1)
  End Function

  Public Function rewind() As Boolean
    Return SetIndex(0)
  End Function

End Class