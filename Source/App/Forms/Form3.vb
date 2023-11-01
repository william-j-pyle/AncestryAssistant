Public Class Form3
  Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim ged As Gedcom = New Gedcom("D:\Geneology\Data\gedcom\Ancestry-20230903-Jason and Dorinda Pyle Family.ged")
    'Debug.Print("Header.Date:  {0}", ged.header.loadDate.toAssistantDate)
    Debug.Print("Header.familyCount:  {0}", ged.header.familyCount)
    Debug.Print("Header.fileName:  {0}", ged.header.fileName)
    Debug.Print("Header.mediaCount:  {0}", ged.header.mediaCount)
    Debug.Print("Header.personCount:  {0}", ged.header.personCount)
    Debug.Print("Header.sourceCount:  {0}", ged.header.sourceCount)
    For Each person As IndividualTag In ged.people
      Debug.Print("ID={0}, Surname={1},  Given={2}", person.ID, person.SurName, person.GivenName)
    Next
  End Sub
End Class