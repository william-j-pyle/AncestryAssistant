Public Class frmTestRibbon

#Region "Private Methods"

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    With bar
      .AddRibbonTab("Notebook")
      .AddGroup("Notebook", "Clipboard")
      .AddGroup("Notebook", "Page")
    End With
  End Sub

  Private Sub frmTestRibbon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    My.Application.Log.WriteEntry("HELLO")
    BackColor = My.Theme.AppBackColor
    Debug.Print(My.Theme.AppIconsFont.ToString)
  End Sub

#End Region

End Class