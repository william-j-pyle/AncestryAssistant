Imports System.Text

Public Class frmTestGEDCOM

  Private Const filename As String = "D:\Geneology\Data\gedcom\Ancestry-20231105-Jason and Dorinda Pyle Family.ged"

  Private ged As Gedcom

  Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub

  Private Sub btnGedCom_Click(sender As Object, e As EventArgs) Handles btnGedCom.Click
    txtOutput.Text = "Loading:  " + filename + vbCrLf
    ged = New Gedcom(filename)
    txtOutput.Text += "Loaded" + vbCrLf
  End Sub

  Private Sub btnSummary_Click(sender As Object, e As EventArgs) Handles btnSummary.Click
    Dim sb As StringBuilder = New StringBuilder()
    sb.AppendFormat("Header.fileName:  {0}", ged.header.fileName).AppendLine()
    sb.AppendFormat("Header.personCount:  {0}", ged.header.personCount).AppendLine()
    sb.AppendFormat("Header.familyCount:  {0}", ged.header.familyCount).AppendLine()
    sb.AppendFormat("Header.mediaCount:  {0}", ged.header.mediaCount).AppendLine()
    sb.AppendFormat("Header.sourceCount:  {0}", ged.header.sourceCount).AppendLine()

    For Each person As IndividualTag In ged.people
      sb.AppendFormat("ID={0}, Surname={1},  Given={2}", person.ID, person.SurName, person.GivenName).AppendLine()
    Next
    txtOutput.Text = sb.ToString
  End Sub
End Class