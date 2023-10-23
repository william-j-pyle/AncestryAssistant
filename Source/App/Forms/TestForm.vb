Public Class TestForm
  'Private WithEvents a As AncestorCollection = New AncestorCollection("D:\Geneology\Ancestors\")
  Public WithEvents MyNotes As ANotebook

  'Private Function dumpInfo(aa As AncestorCollection.Ancestor) As String
  '  Dim sb As StringBuilder = New StringBuilder
  '  sb.AppendLine("Ancestor Count: " & a.Count)
  '  sb.AppendLine("ID=" & aa.ID)
  '  sb.AppendLine("Name=" & aa.FullName)
  '  sb.AppendLine("Surname=" & aa.Surname)
  '  sb.AppendLine("GivenName=" & aa.Givenname)
  '  sb.AppendLine("HasCensus=" & aa.HasCensus)
  '  sb.AppendLine("HasImages=" & aa.HasImages)
  '  sb.AppendLine("HasTimeline=" & aa.HasTimeline)
  '  sb.AppendLine("HasFamily=" & aa.HasFamily)
  '  sb.AppendLine("HasNotes=" & aa.HasNotes)
  '  sb.AppendLine("HasProfileImage=" & aa.HasProfileImage)
  '  sb.AppendLine("HasSources=" & aa.HasSources)
  '  Return sb.ToString
  'End Function

  Private Sub TestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
  End Sub

  Private Sub notes_PageChanged(PageName As String) Handles MyNotes.PageChanged
    Debug.Print("notes_PageChanged")
    lblPage.Text = PageName

  End Sub

  Private Sub notes_SectionChanged(SectionName As String) Handles MyNotes.SectionChanged
    Debug.Print("notes_SectionChanged")
    lblSection.Text = SectionName

  End Sub

  Private Sub notes_TestMe(FromWhere As String) Handles MyNotes.TestMe
    Debug.Print("TESTME: " + FromWhere)
  End Sub

  Private Sub btnAddSection_Click(sender As Object, e As EventArgs) Handles btnAddSection.Click
    MyNotes.AddSection(txtSection.Text)
  End Sub

  Private Sub btnAddPage_Click(sender As Object, e As EventArgs) Handles btnAddPage.Click
    MyNotes.AddPage(txtPage.Text)
  End Sub

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    MyNotes = New ANotebook("D:\Geneology\Ancestors\")

  End Sub
End Class