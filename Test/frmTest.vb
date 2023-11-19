Public Class frmTest

#Region "Fields"

  Private frm As Form

#End Region

#Region "Private Methods"

  Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
    If frm IsNot Nothing Then
      frm.Close()
      frm = Nothing
    End If
    frm = New frmTestDockPanel
    frm.Show()
  End Sub

  Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
    If frm IsNot Nothing Then
      frm.Close()
      frm = Nothing
    End If
    frm = New frmButtonTestForm
    frm.Show()
  End Sub

  Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
    If frm IsNot Nothing Then
      frm.Close()
      frm = Nothing
    End If
    frm = New frmColorPallet
    frm.Show()
  End Sub

  Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
    If frm IsNot Nothing Then
      frm.Close()
      frm = Nothing
    End If
    frm = New frmTestRibbon
    frm.Show()
  End Sub

  Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
    If frm IsNot Nothing Then
      frm.Close()
      frm = Nothing
    End If
    frm = New frmTestGEDCOM
    frm.Show()
  End Sub

  Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus, TextBox2.GotFocus, TextBox3.GotFocus, TextBox4.GotFocus, TextBox5.GotFocus
    PictureBox1.Select()
  End Sub

#End Region

End Class