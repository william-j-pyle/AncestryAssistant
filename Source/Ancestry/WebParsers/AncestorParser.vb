Public Class AncestryFactsParser
  Private sources As Collection
  Private facts As Collection
  Private family As Collection

  Private hasProfileImage As Boolean
  Private hasHeadstoneImage As Boolean
  Private birthEntry As String
  Private deathEntry As String
  Private relationship As String

  Public Property name As String
  Public Property surname As String
  Public Property givenname As String
  Public Property birthYear As String
  Public Property deathYear As String


  Public Sub New(payloadData As String)
    sources = New Collection
    facts = New Collection
    family = New Collection

    hasProfileImage = False
    hasHeadstoneImage = False
    name = ""
    birthEntry = ""
    deathEntry = ""
    relationship = ""
    ProcessData(payloadData)
  End Sub

  Private Sub ProcessData(rawData As String)
    Dim preLines() As String = rawData.Split(vbLf)
    Dim rawLines() As String
    Dim row As String
    Dim r As Integer
    Dim cont As Boolean
    Dim section As String = "New"
    Dim subSection As String = ""
    Dim tmpSection As String = ""
    Dim rawLineData As String = ""
    For p As Integer = 1 To UBound(preLines)
      If processRow(preLines(p)) Then
        rawLineData += vbLf & preLines(p)
      End If
    Next
    rawLines = rawLineData.Split(vbLf)
    For r = 1 To UBound(rawLines)
      'Try
      row = rawLines(r)
      If row.Contains("Support Center") Then Exit For
      If processRow(row) Then
        cont = True
        If cont And section = "New" Then
          If name = "" And row.Length > 5 Then
            If row.Contains("Select a profile image") Then
              name = Split(row, ".")(1)
              cont = False
            Else
              name = row
              hasProfileImage = True
              r += 1
              cont = False
            End If
          End If
          If cont And row.StartsWith("BIRTH") Then
            birthEntry = correctDatePlace(Replace(row, "BIRTH ", ""))
            cont = False
          End If
          If cont And row.StartsWith("DEATH") Then
            deathEntry = correctDatePlace(Replace(row, "DEATH ", ""))
            cont = False
          End If
          If cont And row.Contains("Add MyTreeTags") Then
            relationship = Left(row, InStr(1, row, "Add") - 1)
            cont = False
          End If
        End If
        If cont And (row = "Facts" Or row = "Sources" Or row = "Family") Then
          Debug.Print("pageParserFacts[{0}]", row)
          section = row
          subSection = ""
          cont = False
        End If
        If cont And section = "Facts" Then
          If row = "Select fact" Then
            r = r + addFact(rawLines(r + 1), rawLines(r + 2), rawLines(r + 3), rawLines(r + 4))
            cont = False
          End If
        End If
        If cont And section = "Sources" Then
          addSource(row)
          cont = False
        End If
        If cont And section = "Family" Then
          If row = "Parents" Or row = "Siblings" Or row = "Half siblings" Or row = "Spouse and children" Or row = "Spouse" Or row = "Unknown" Then
            subSection = row
            cont = False
          End If
          If cont Then
            tmpSection = subSection
            If subSection = "Spouse and children" Then
              tmpSection = "Spouse"
            End If
            If r + 1 < rawLines.Length Then
              r += addFamily(tmpSection, rawLines(r), rawLines(r + 1))
            End If
            If subSection = "Spouse and children" Then
              subSection = "   Children"
            Else
              subSection = ""
            End If
            cont = False
          End If
        End If
      End If
      'Catch ex As Exception
      ' IndexOutOfRangeException
      'End Try
    Next
    birthYear = Trim(Left(Split(birthEntry & vbTab & vbTab, vbTab)(0), 4))
    deathYear = Trim(Left(Split(deathEntry & vbTab & vbTab, vbTab)(0), 4))
    Try
      Dim nm() As String
      nm = Split(name, " ")
      surname = nm(UBound(nm))
      If Len(surname) < 4 Then
        surname = nm(UBound(nm) - 1) & " " & surname
      End If
      givenname = Trim(Left(name, Len(name) - Len(surname) - 1))
    Catch ex As Exception
      surname = ""
      givenname = ""
    End Try

  End Sub

  Private Function processRow(row As String) As Boolean
    Return Not (Trim(row) = "" _
       Or row.Contains("View in tree") _
       Or row.Contains("Tree search") _
       Or row.Contains("ToolsEdit") _
       Or row.Contains("LifeStory") _
       Or row.Contains("Skip to sources") _
       Or row.Contains("FilterAdd") _
       Or row.Contains("HelpExtras") _
       Or row.Contains("DNAHelp") _
       Or row.Contains("TreesSearch") _
       Or row.Contains("HomeTrees") _
       Or row.Contains("Hire an Expert") _
       Or row.Contains("CloseSearchPossible") _
       Or row.Contains("Add fact") _
       Or row = "Add" _
       Or row = "Hints." _
       Or row = "Messages." _
       Or row = "Notifications." _
       Or row = "EN" _
       Or row = "Filter" _
       Or row.Contains("Skip to family") _
       Or row.Contains("Ancestry sources") _
       Or row.Contains("Select source") _
       Or row.Contains("View Source") _
       Or row.Contains("Search on Ancestry") _
       Or row.Contains("VIEW MATCH PROFILE") _
       Or row.Contains("Add source") _
       Or row.Contains("Add web link") _
       Or row.Contains("Skip to facts") _
       Or row.Contains("Add family") _
       Or row.Contains("Other sources") _
       Or row.Contains("Ancestry Family Trees"))
  End Function

  Private Function addSource(row As String) As Integer
    Dim key As String = row.GetHashCode()
    If Not sources.Contains(key) Then
      sources.Add(row, key)
    End If
    Return 1
  End Function



  Private Function correctDatePlace(dp As String) As String
    Dim rtn As String
    Dim p() As String
    If dp.Contains(" • ") Then
      rtn = dp.Replace(" • ", vbTab)
      p = Split(rtn, vbTab)

      rtn = New GedDate(p(0)).toAssistantDate() & vbTab & p(1)
    Else
      If dp.Contains(",") Then
        rtn = vbTab & dp
      Else
        rtn = New GedDate(dp).toAssistantDate() & vbTab
      End If
    End If
    Return rtn
  End Function

  Private Function parseTimeline(txt As String) As String
    If Val(txt) <> 0 Then
      parseTimeline = txt
    Else
      parseTimeline = ""
    End If
  End Function

  Private Function addFamily(section As String, name As String, timeline As String) As Integer
    Dim item As String
    Dim rtn As Integer
    rtn = 1
    item = section & vbTab & name & vbTab & parseTimeline(timeline)
    Dim key As String = item.GetHashCode()
    family.Add(item, key)
    Return rtn
  End Function


  Private Function addFact(l1 As String, l2 As String, l3 As String, l4 As String) As Integer
    Dim item As String = ""
    Dim cont As Boolean = True
    Dim r As Integer = 4
    'Clear out the sources and trailing entries
    If l3.Contains("source") Or l3.Contains("Sources") Then
      l3 = ""
      l4 = ""
    End If
    If l4.Contains("source") Or l3.Contains("Sources") Then
      l4 = ""
    End If
    'Collapse entries
    If l1.Trim() = "" Then
      r -= 1
      l1 = l2
      l2 = l3
      l3 = l4
      l4 = ""
    End If
    If l2.Trim() = "" Then
      r -= 1
      l2 = l3
      l3 = l4
      l4 = ""
    End If
    If l3.Trim() = "" Then
      r -= 1
      l3 = l4
      l4 = ""
    End If
    If l4.StartsWith("(") Then
      l3 = l3 & " " & l4
      l4 = ""
    End If

    'Ignore family facts
    If l1.Contains("Birth of") Or l1.Contains("Death of") Then
      Return 0
    End If

    If cont And l2 = "Death" Then
      hasHeadstoneImage = True
      item = l2 & vbTab & correctDatePlace(l3) & vbTab & l4
      cont = False
    End If
    If cont And l2 = "Burial" Then
      item = l2 & vbTab & correctDatePlace(l3) & vbTab & l4
      cont = False
    End If
    'If the factType contains a space, its not one I care about here
    If cont And l1.Contains(" ") Then
      Return 0
    End If
    'If we are here and still have not parsed an entry, then take it all
    If cont Then
      item = l1 & vbTab & correctDatePlace(l2) & vbTab & l3 '& vbTab & l4
      cont = False
    End If
    Dim key As String = item.GetHashCode()
    If Not facts.Contains(key) Then
      facts.Add(item, key)
    End If
    Return r
  End Function

  Public Function ProfileData() As String
    Dim dataSet As String = ""
    dataSet += surname + vbCrLf
    dataSet += givenname + vbCrLf
    dataSet += Split(birthEntry & vbTab & vbTab, vbTab)(0) + vbCrLf
    dataSet += Split(birthEntry & vbTab & vbTab, vbTab)(1) + vbCrLf
    dataSet += Split(deathEntry & vbTab & vbTab, vbTab)(0) + vbCrLf
    dataSet += Split(deathEntry & vbTab & vbTab, vbTab)(1) + vbCrLf
    Return dataSet
  End Function

  Public Function FamilyArray() As Array
    Dim dataSet As New ArrayList
    Dim dataRow() As String

    ' Header Row
    dataRow = {"Family", "Name", "Lifespan"}
    dataSet.Add(dataRow)

    ' Data Rows
    For r As Integer = 1 To family.Count
      dataRow = Split(family.Item(r).replace(Chr(150), "-") & vbTab & vbTab & vbTab, vbTab)
      dataSet.Add(dataRow)
    Next r

    Return dataSet.ToArray
  End Function

  Public Function SourcesArray() As Array
    Dim dataSet As New ArrayList
    Dim dataRow() As String

    ' Header Row
    dataRow = {"Type", "Name", "Comments"}
    dataSet.Add(dataRow)

    ' Data Rows
    Dim typ As String
    For r As Integer = 1 To sources.Count
      typ = ""
      If typ = "" And sources.Item(r).Contains("Census") Then typ = "Census"
      If typ = "" And sources.Item(r).Contains("Newspaper") Then typ = "NewsPaper"
      If typ = "" And sources.Item(r).Contains("Birth") Then typ = "Birth"
      If typ = "" And sources.Item(r).Contains("Death") Then typ = "Death"
      If typ = "" And sources.Item(r).Contains("War") Then typ = "War"
      If typ = "" And sources.Item(r).Contains("WW") Then typ = "War"
      If typ = "" And sources.Item(r).Contains("Marriage") Then typ = "Marriage"
      If typ = "" And sources.Item(r).Contains("Find A Grave") Then typ = "FineAGrave"
      dataRow = {typ, sources.Item(r).replace(Chr(150), "-"), ""}
      dataSet.Add(dataRow)
    Next r

    Return dataSet.ToArray
  End Function

  Public Function TimelineArray() As Array
    Dim dataSet As New ArrayList
    Dim dataRow() As String

    ' Header Row
    dataRow = {"Event", "Date", "Place", "Description"}
    dataSet.Add(dataRow)

    ' Data Rows
    For r As Integer = 1 To facts.Count
      Dim dta() As String
      dta = Split(facts.Item(r).replace(Chr(150), "-") & vbTab & vbTab & vbTab & vbTab, vbTab)
      dataRow = {dta(0), dta(1), dta(2), dta(3)}
      dataSet.Add(dataRow)
    Next r

    Return dataSet.ToArray
  End Function


End Class
