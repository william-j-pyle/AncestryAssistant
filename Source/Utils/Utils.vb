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

  Public Function uniqueFilename(baseName As String, extensions() As String) As String
    Dim uni As String = ""
    Dim uniIdx As Integer = 0
    Dim isUnique As Boolean = False
    While Not isUnique
      isUnique = True
      For Each ext As String In extensions
        isUnique = isUnique And Not File.Exists(baseName + uni + "." + ext)
      Next
      If Not isUnique Then
        uniIdx += 1
        uni = "-" & uniIdx.ToString.PadLeft(3, "0")
      End If
    End While
    Return baseName + uni
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

  Public Sub DumpColorCodes(ctl As Control)
    Try
      Debug.Print("{0}.backcolor={1}", ctl.Name, ctl.BackColor)
    Catch ex As Exception
    End Try
    Try
      Debug.Print("{0}.forecolor={1}", ctl.Name, ctl.ForeColor)
    Catch ex As Exception
    End Try
    For Each subCtl As Control In ctl.Controls
      DumpColorCodes(subCtl)
    Next
  End Sub


End Module