Imports System.IO

Module Utils

  Public Function GetImageThumbnail(ByVal fileName As String, ByVal targetSize As Integer) As Image
    Dim originalImage As Image = Image.FromFile(fileName)
    Dim thumb As Image = GetImageThumbnail(originalImage, targetSize)
    originalImage.Dispose()
    originalImage = Nothing
    Return thumb
  End Function

  Public Function GetImageThumbnail(ByVal originalImage As Image, ByVal targetSize As Integer) As Image
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

  Public Sub saveFile(ByVal data As String, ByVal dirPath As String, ByVal fileName As String, Optional overwrite As Boolean = False)
    If Not dirPath.EndsWith("\") Then dirPath += "\"
    If File.Exists(dirPath & fileName) And Not overwrite Then
      Exit Sub
    End If
    Using writer As New StreamWriter(dirPath & fileName)
      writer.Write(data)
    End Using
  End Sub

  Public Sub saveCSV(ByVal data As Array, ByVal dirPath As String, ByVal fileName As String)
    Dim line As String
    Dim sep As String
    If Not dirPath.EndsWith("\") Then dirPath += "\"
    Using writer As New StreamWriter(dirPath & fileName)
      line = ""
      sep = ""
      For Each column As String In data(0)
        line += sep + """" + column.Replace("""", "'") + """"
        sep = ","
      Next
      writer.WriteLine(line)
      For i As Integer = 1 To data.Length - 1
        line = ""
        sep = ""
        For j As Integer = 0 To data(i).length - 1
          line += sep + """" + data(i)(j).ToString().Replace("""", "'") + """"
          sep = ","
        Next
        writer.WriteLine(line)
      Next
    End Using
  End Sub

  Public Function arrayToStringArray(data()) As String()
    Dim stringArray(data.Count) As String
    For j As Integer = 0 To data.Count - 1
      stringArray(j) = data(j).ToString()
    Next
    Return stringArray
  End Function

  Public Sub populateTable(tbl As DataGridView, data As Array)
    tbl.Columns.Clear()
    tbl.Rows.Clear()
    For Each column As String In data(0)
      tbl.Columns.Add(column, column)
    Next
    For i As Integer = 1 To data.Length - 1
      tbl.Rows.Add(arrayToStringArray(data(i)))
    Next
  End Sub

  Public Function colorBrightness(color As Color, brightness As Double) As Color
    Dim brightnessChange As Integer = CInt(255 * brightness / 100)
    Dim newRed As Integer = Math.Max(Math.Min(255, color.R + brightnessChange), 0)
    Dim newGreen As Integer = Math.Max(Math.Min(255, color.G + brightnessChange), 0)
    Dim newBlue As Integer = Math.Max(Math.Min(255, color.B + brightnessChange), 0)
    Return Color.FromArgb(color.A, newRed, newGreen, newBlue)
  End Function

  Function ColorToGray(color As Color) As Color
    Dim grayValue As Integer = CInt((0.299 * color.R) + (0.587 * color.G) + (0.114 * color.B))
    Return Color.FromArgb(grayValue, grayValue, grayValue)
  End Function

  Function ColorToDisabled(color As Color) As Color
    Dim grayValue As Integer = CInt((0.299 * color.R) + (0.587 * color.G) + (0.114 * color.B))
    Return Color.FromArgb(150, grayValue, grayValue, grayValue)
  End Function

  Function ColorToShadow(color As Color) As Color
    Return colorBrightness(color, -25)
  End Function

  Function ColorToAccent(color As Color) As Color
    Return colorBrightness(color, 25)
  End Function

End Module