Imports System.IO

Public Class ImageSaveDialog

  Public Property SrcPage As String
    Get
      Return txtPage.Text
    End Get
    Set(value As String)
      txtPage.Text = value
    End Set
  End Property

  Private _SrcFilename As String = ""
  Public Property SrcFilename As String
    Get
      Return _SrcFilename
    End Get
    Set(value As String)
      _SrcFilename = value
      Dim p() As String = value.Split("\")
      txtDetails.Text = p(p.Length - 1)
      img.Image = GetImageThumbnail(value, img.Width)
    End Set
  End Property

  Private _DstFilename As String = ""

  Private _DstDir As String = ""
  Public Property DstDir As String
    Get
      Return _DstDir
    End Get
    Set(value As String)
      _DstDir = value
    End Set
  End Property

  Private Function GetImageThumbnail(ByVal fileName As String, ByVal targetSize As Integer) As Image
    Dim originalImage As Image = Image.FromFile(fileName)
    Dim paddedImage As New Bitmap(targetSize, targetSize)
    Using g As Graphics = Graphics.FromImage(paddedImage)
      ' Fill the image with transparent color
      g.Clear(Color.Transparent)
      ' Scale the image to fit in targetSize
      Dim tH As Integer = CInt(originalImage.Height * Math.Min(targetSize / originalImage.Height, targetSize / originalImage.Width))
      Dim tW As Integer = CInt(originalImage.Width * Math.Min(targetSize / originalImage.Height, targetSize / originalImage.Width))
      Dim thumbnail As Image = originalImage.GetThumbnailImage(tW, tH, Nothing, Nothing)

      ' Calculate the position to draw the original image in the center
      Dim x As Integer = (targetSize - thumbnail.Width) \ 2
      Dim y As Integer = (targetSize - thumbnail.Height) \ 2

      ' Draw the original image on the padded canvas
      g.DrawImage(thumbnail, x, y, thumbnail.Width, thumbnail.Height)
    End Using
    originalImage.Dispose()
    originalImage = Nothing
    Return paddedImage
  End Function


  Private Sub ImageType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    With cmbCategory.Items
      .Add("Certificate-Birth")
      .Add("Certificate-Death")
      .Add("Certificate-Marriage")
      .Add("Certificate-Other")
      .Add("Document-Land")
      .Add("Document-Other")
      .Add("Document-Will")
      .Add("Newspaper-Obituary")
      .Add("Newspaper-Other")
      .Add("Photo-Headstone")
      .Add("Photo-Other")
      .Add("Photo-Portrait")
      .Add("Photo-Profile")
    End With
  End Sub

  Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
    Dim fname As String = ""
    fname += _DstDir
    If Not fname.EndsWith("\") Then fname += "\"
    fname += cmbCategory.Text.ToLower
    If txtDate.Text.Trim.Length > 0 Then
      Dim dt As DateParser = New DateParser()
      If dt.Parse(txtDate.Text) And dt.HasYear Then
        fname += "-" + dt.Year
      End If
    End If
    If txtSummary.Text.Trim.Length > 0 Then
      fname += "-" + txtSummary.Text.ToLower.Trim.Replace(" ", "_").Substring(0, Math.Min(txtSummary.Text.Length - 1, 40))
    End If
    File.Move(SrcFilename, fname & ".jpg")
    Using writer As New StreamWriter(fname & ".txt")
      writer.WriteLine(SrcFilename)
      writer.WriteLine(SrcPage)
      writer.WriteLine(txtSummary.Text)
      writer.WriteLine(txtDate.Text)
      writer.WriteLine(txtPlace.Text)
      writer.WriteLine(txtDetails.Text)
    End Using
    Close()
  End Sub

  Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
    Close()
  End Sub
End Class