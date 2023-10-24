Imports System.IO

Public Class ImageGallery

  Public Event ImageViewRequested(imageFilename As String)

  Public Event ImageSelectionChanged(imageFilename As String)

  Public Event ViewRefreshed()

  Public ReadOnly Property GalleryItemCount As Integer
    Get
      Return imgViewer.Items.Count
    End Get
  End Property

  Private _GalleryPath As String = ""

  Public Property GalleryPath As String
    Get
      Return _GalleryPath
    End Get
    Set(value As String)
      If Not value.Equals(_GalleryPath) Then
        If value.EndsWith("\") Then
          _GalleryPath = value
        Else
          _GalleryPath = value + "\"
        End If
        RefreshView()
      End If
    End Set
  End Property

  Public ReadOnly Property ImageSelected As String
    Get
      If imgViewer.SelectedItems.Count > 0 Then
        Return imgViewer.SelectedItems.Item(1).Tag
      End If
      Return String.Empty
    End Get
  End Property

  Public Sub RefreshView()
    Debug.Print("RefreshView")
    Clear()
    If Directory.Exists(GalleryPath) Then
      For Each fileName As String In Directory.GetFiles(GalleryPath)
        If fileName.EndsWith(".jpg") Or fileName.EndsWith(".jepg") Or fileName.EndsWith(".png") Then
          Dim caption As String = fileName.Replace(GalleryPath, "")
          If File.Exists(fileName + ".txt") Then
            caption = File.ReadAllText(fileName + ".txt")
          End If
          AddImage(caption, fileName)
        End If
      Next
      RaiseEvent ViewRefreshed()
    End If
  End Sub

  Public Sub Clear()
    Debug.Print("Clear")
    imgViewer.Items.Clear()
    imgViewerList.Images.Clear()
  End Sub

  Private Function GetImageThumbnail(ByVal originalImage As Image, ByVal targetSize As Integer) As Image
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
    Return paddedImage
  End Function

  Private Sub AddImage(caption As String, filename As String)
    Dim maxSize As Integer = imgViewerList.ImageSize.Height
    Dim img As Image = GetImageThumbnail(Image.FromFile(filename), maxSize)
    Dim key As String
    Debug.Print("AddImage: " & filename)
    key = imgViewerList.Images.Count + 1
    imgViewerList.Images.Add(key, img)
    imgViewer.Items.Add(caption, key).Tag = filename
  End Sub

  Private Sub imgViewer_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles imgViewer.ItemSelectionChanged
    RaiseEvent ImageSelectionChanged(e.Item.Tag)
  End Sub

  Private Sub imgViewer_DoubleClick(sender As Object, e As EventArgs) Handles imgViewer.DoubleClick
    If imgViewer.SelectedItems.Count > 0 Then
      RaiseEvent ImageViewRequested(imgViewer.SelectedItems.Item(0).Tag)
    End If
  End Sub

End Class