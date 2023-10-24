Imports System.IO

Public Class GedComFile
  Private data As New GedComData

  'HEAD
  Public Property Header As New GedHeader

  'SUBM
  Public Property Submitters As New GedSubmitterCollection

  'INDI
  Public Property Individuals As New GedIndividualCollection

  'FAM
  Public Property Family As New GedFamilyCollection

  'OBJE
  Public Property Media As New GedMediaCollection

  'SOUR
  Public Property Source As New GedSourceCollection

  'REPO
  Public Property Repository As New GedRepositoryCollection

  '_MTTAG
  Public Property Tags As New GedTagCollection

  'Public Event GedComDataLoaded(ByVal sender As Object, ByVal e As GedComEventArgs)

  Public Sub New(gedFilename As String)
    loadFile(gedFilename)
  End Sub

  Public Sub loadFile(gedFilename As String)
    Dim keyParts(10) As String
    Dim keyFlat As String
    Dim keyIdx As Integer
    Dim line As String
    Dim lineParts() As String
    Dim lineLvl As Integer
    Dim lineIdx As Double
    Dim lineTag As String
    Dim lineRef As String
    Dim lineData As String
    lineIdx = 0
    'Debug.Print("Loading: {0}", gedFilename)
    For Each line In File.ReadLines(gedFilename, System.Text.Encoding.UTF8)
      lineIdx += 1
      lineParts = line.Split(" ")
      lineLvl = lineParts(0)
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
          lineData = line.Substring(lineParts(0).Length + lineParts(1).Length + 2)
        End If
      End If
      keyFlat = keyParts(0)
      For keyIdx = 1 To lineLvl
        keyFlat += "." + keyParts(keyIdx)
      Next
      data.Add(New GedComFileLine(lineIdx, lineLvl, lineTag, lineRef, lineData, keyFlat, line))
    Next
    parseData()
    'RaiseEvent GedComDataLoaded(Me, New GedComEventArgs(Me.treeID, Me.gedindi.Count))
  End Sub

  Private Sub parseData()
    Dim maxLoops As Double = 100000
    While data.HasNext And maxLoops > 0
      maxLoops -= 1
      Select Case data.Tag
        Case "HEAD"
          Header.addObject(data)
        Case "SUBM"
          Submitters.addObject(data)
        Case "INDI"
          Individuals.addObject(data)
        Case "FAM"
          Family.addObject(data)
        Case "OBJE"
          Media.addObject(data)
        Case "SOUR"
          Source.addObject(data)
        Case "REPO"
          Repository.addObject(data)
        Case "_MTTAG"
          Tags.addObject(data)
        Case "TRLR"
          data.NextRow()
        Case Else
          Debug.Print("MISSING TAG HANDLER: {0} on line {1} in hierarchy {2}", data.Tag, data.Index, data.Key)
          data.NextRow()
      End Select
    End While
    If maxLoops < 1 Then
      Debug.Print("FAILED PROCESSING GedCOM: MaxLoops Reached")
    End If
  End Sub

  Public Sub Summary()
    Debug.Print("HEADER: Tree={0}", Header.AncestryRIN)
    Debug.Print("SUBMITTERS: Count={0}", Submitters.Count)
    Debug.Print("INDIVIDUALS: Count={0}", Individuals.Count)
    Debug.Print("TAGS: Count={0}", Tags.Count)
    Debug.Print("FAMILY: Count={0}", Family.Count)
    Debug.Print("MEDIA: Count={0}", Media.Count)
    Debug.Print("SOURCES: Count={0}", Source.Count)
    Debug.Print("Repositories: Count={0}", Repository.Count)
    For ind As Integer = 1 To Individuals.Count
      For evnt As Integer = 1 To Individuals(ind - 1).Events.Count
        With Individuals(ind - 1).Events(evnt - 1)
          If .EventDate IsNot Nothing And .RecordType <> "RESI" Then
            Debug.Print("IND.EVNT.{0}.DATE={1}", .RecordType, .EventDate.SourceDateString)
          End If
        End With
      Next
    Next
  End Sub

End Class