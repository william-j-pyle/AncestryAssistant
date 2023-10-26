Public Class Form1
  Private Sub btnDecToHex_Click(sender As Object, e As EventArgs) Handles btnDecToHex.Click
    'Label1.Text = ChrW(&HE92A)
    Dim dec As Integer = txtDec.Text
    txtHex.Text = Convert.ToString(dec, 16).ToUpper
  End Sub

  Private Sub btnHexToDec_Click(sender As Object, e As EventArgs) Handles btnHexToDec.Click
    txtDec.Text = Convert.ToInt32(txtHex.Text, 16)
  End Sub

  Private Sub btnHexToImg_Click(sender As Object, e As EventArgs) Handles btnHexToImg.Click
    lblIcon.Text = ChrW(Convert.ToInt32(txtHex.Text, 16))
  End Sub

  Private Sub btnDecToImg_Click(sender As Object, e As EventArgs) Handles btnDecToImg.Click
    Dim dec As Integer = txtDec.Text
    lblIcon.Text = ChrW(dec)

  End Sub

  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub
End Class