Public Class NotebookViewer


  Private Sub txtNotebookPageTitle_TextChanged(sender As Object, e As EventArgs) Handles TxtHeader.TextChanged
    LblStretch.Text = TxtHeader.Text
  End Sub

End Class
