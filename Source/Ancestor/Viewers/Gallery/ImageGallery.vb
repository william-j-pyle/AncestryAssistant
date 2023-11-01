Imports System.ComponentModel
Imports System.IO

Public Class ImageGallery
  Inherits AbstractViewer

  Friend WithEvents imgViewer As ListView
  Friend WithEvents imgViewerList As ImageList
  Friend WithEvents imgContainer As Panel
  Friend WithEvents imgBox As PictureBox
  Friend WithEvents ts As ToolStrip
  Friend WithEvents btnBack As ToolStripButton
  Friend WithEvents btnFlipV As ToolStripButton
  Friend WithEvents btnFlipH As ToolStripButton
  Friend WithEvents lblCaption As ToolStripLabel
  Friend WithEvents btnSizeHV As ToolStripButton
  Friend WithEvents btnSizeH As ToolStripButton
  Friend WithEvents btnSizeV As ToolStripButton
  Friend WithEvents lblZoom As ToolStripLabel
  Friend WithEvents toolStripSeparator As ToolStripSeparator
  Friend WithEvents sliderHost As ToolStripControlHost
  Friend WithEvents slider As TrackBar

  ' Tracking
  Private panningActive As Boolean = False
  Private smoothedMousePosition As Point
  Private zoomActive As Boolean = False
  Private PanningEnabled As Boolean = True
  Private MouseSmoothingFactor As Double = 0.1
  Private components As System.ComponentModel.IContainer

  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub


  Public Sub New()
    components = New Container()
    imgViewer = New ListView()
    imgViewerList = New ImageList(components)
    imgContainer = New Panel()
    imgBox = New PictureBox()
    ts = New ToolStrip()
    slider = New TrackBar()
    btnBack = New ToolStripButton()
    btnFlipV = New ToolStripButton()
    btnFlipH = New ToolStripButton()
    lblCaption = New ToolStripLabel()
    btnSizeHV = New ToolStripButton()
    btnSizeH = New ToolStripButton()
    btnSizeV = New ToolStripButton()
    lblZoom = New ToolStripLabel()
    toolStripSeparator = New ToolStripSeparator()
    imgContainer.SuspendLayout()
    CType(imgBox, System.ComponentModel.ISupportInitialize).BeginInit()
    ts.SuspendLayout()
    SuspendLayout()
    '
    'imgViewer
    '
    imgViewer.BackColor = Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(31, Byte), Integer))
    imgViewer.BorderStyle = BorderStyle.None
    imgViewer.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
    imgViewer.ForeColor = Color.White
    imgViewer.HideSelection = False
    imgViewer.LargeImageList = imgViewerList
    imgViewer.Location = New Point(0, 144)
    imgViewer.MultiSelect = False
    imgViewer.Name = "imgViewer"
    imgViewer.size = New Size(223, 174)
    imgViewer.TabIndex = 0
    imgViewer.TileSize = New Size(256, 256)
    imgViewer.UseCompatibleStateImageBehavior = False
    imgViewer.View = View.Tile
    '
    'imgViewerList
    '
    imgViewerList.ColorDepth = ColorDepth.Depth32Bit
    imgViewerList.ImageSize = New Size(256, 256)
    imgViewerList.TransparentColor = Color.Transparent
    '
    'imgContainer
    '
    imgContainer.BackColor = SystemColors.ControlDarkDark
    imgContainer.Controls.Add(imgBox)
    imgContainer.Location = New Point(257, 144)
    imgContainer.Margin = New Padding(0)
    imgContainer.Name = "imgContainer"
    imgContainer.size = New Size(200, 174)
    imgContainer.TabIndex = 4
    '
    'imgBox
    '
    imgBox.BorderStyle = BorderStyle.FixedSingle
    imgBox.Cursor = Cursors.Hand
    imgBox.ErrorImage = Nothing
    imgBox.ImageLocation = ""
    imgBox.Location = New Point(29, 48)
    imgBox.Margin = New Padding(0)
    imgBox.Name = "imgBox"
    imgBox.size = New Size(100, 100)
    imgBox.SizeMode = PictureBoxSizeMode.AutoSize
    imgBox.TabIndex = 0
    imgBox.TabStop = False





    With slider
      .Minimum = 10
      .Maximum = 150
      .Value = 100
      .SmallChange = 1
      .LargeChange = 10
      .TickFrequency = 10
      .MaximumSize = New Size(120, 20)
      .MinimumSize = New Size(120, 20)
      .size = New Size(120, 20)
    End With

    sliderHost = New ToolStripControlHost(slider)

    '
    'ts
    '
    With ts
      ts.GripStyle = ToolStripGripStyle.Hidden
      .Items.AddRange(New ToolStripItem() {btnBack, btnFlipV, btnFlipH, lblCaption, lblZoom, sliderHost, toolStripSeparator, btnSizeH, btnSizeV, btnSizeHV})
      .Location = New Point(0, 0)
      .Name = "ts"
      .RenderMode = ToolStripRenderMode.System
      .size = New Size(465, 25)
      .Text = ""
    End With

    '
    'btnBack
    '
    With btnBack
      .DisplayStyle = ToolStripItemDisplayStyle.Image
      .Image = Global.AncestryAssistant.My.Resources.Resources.BIG_LEFT_ICO20
      .ImageTransparentColor = Color.Magenta
      .Name = ""
      .size = New Size(23, 22)
      .Text = "Back to Gallery"
    End With
    '
    'btnFlipV
    '
    btnFlipV.DisplayStyle = ToolStripItemDisplayStyle.Image
    btnFlipV.Image = Global.AncestryAssistant.My.Resources.Resources.FLIP_HORIZONTAL_ICO20
    btnFlipV.ImageTransparentColor = Color.Magenta
    btnFlipV.Name = "btnFlipV"
    btnFlipV.size = New Size(23, 22)
    btnFlipV.Text = "Flip Image Vertically"
    '
    'btnFlipH
    '
    btnFlipH.DisplayStyle = ToolStripItemDisplayStyle.Image
    btnFlipH.Image = Global.AncestryAssistant.My.Resources.Resources.FLIP_VERTICAL_ICO20
    btnFlipH.ImageTransparentColor = Color.Magenta
    btnFlipH.Name = "btnFlipH"
    btnFlipH.size = New Size(23, 22)
    btnFlipH.Text = "Flip Image Horizontally"
    '
    'lblCaption
    '
    lblCaption.ForeColor = Color.Black
    lblCaption.Name = "lblCaption"
    lblCaption.size = New Size(87, 22)
    lblCaption.TextAlign = ContentAlignment.MiddleCenter
    lblCaption.Text = ""
    lblCaption.Dock = DockStyle.Fill
    '
    'btnSizeHV
    '
    btnSizeHV.Alignment = ToolStripItemAlignment.Right
    btnSizeHV.DisplayStyle = ToolStripItemDisplayStyle.Image
    btnSizeHV.Image = Global.AncestryAssistant.My.Resources.Resources.MAXIMIZE_2_ICO20
    btnSizeHV.ImageTransparentColor = Color.Magenta
    btnSizeHV.Name = "btnSizeHV"
    btnSizeHV.size = New Size(23, 22)
    btnSizeHV.Text = "Fit Full Image"
    '
    'btnSizeH
    '
    btnSizeH.Alignment = ToolStripItemAlignment.Right
    btnSizeH.DisplayStyle = ToolStripItemDisplayStyle.Image
    btnSizeH.Image = Global.AncestryAssistant.My.Resources.Resources.pfeile_pfeile_horizontal
    btnSizeH.ImageTransparentColor = Color.Magenta
    btnSizeH.Name = "btnSizeH"
    btnSizeH.size = New Size(23, 22)
    btnSizeH.Text = "Fit Image Width"
    '
    'btnSizeV
    '
    btnSizeV.Alignment = ToolStripItemAlignment.Right
    btnSizeV.DisplayStyle = ToolStripItemDisplayStyle.Image
    btnSizeV.Image = Global.AncestryAssistant.My.Resources.Resources.VERTICAL_ICO20
    btnSizeV.ImageTransparentColor = Color.Magenta
    btnSizeV.Name = "btnSizeV"
    btnSizeV.size = New Size(23, 22)
    btnSizeV.Text = "Fit Image Height"
    '
    'lblZoom
    '
    lblZoom.Alignment = ToolStripItemAlignment.Right
    lblZoom.ForeColor = Color.Black
    lblZoom.Name = "lblZoom"
    lblZoom.size = New Size(25, 22)
    lblZoom.Text = "100"
    '
    'toolStripSeparator
    '
    toolStripSeparator.Alignment = ToolStripItemAlignment.Right
    toolStripSeparator.Name = "toolStripSeparator"
    toolStripSeparator.size = New Size(6, 25)

    With sliderHost
      .Alignment = ToolStripItemAlignment.Right
      .size = New Size(120, 20)
    End With

    '
    'ImageGallery
    '
    AutoScaleDimensions = New SizeF(6.0!, 13.0!)
    AutoScaleMode = AutoScaleMode.Font
    Controls.Add(ts)
    Controls.Add(imgContainer)
    Controls.Add(imgViewer)
    Name = "ImageGallery"
    Size = New Size(465, 330)
    imgContainer.ResumeLayout(False)
    imgContainer.PerformLayout()
    CType(imgBox, System.ComponentModel.ISupportInitialize).EndInit()
    ts.ResumeLayout(False)
    ts.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
    Dock = DockStyle.Fill
    imgViewer.Dock = DockStyle.Fill
    imgContainer.Dock = DockStyle.Fill
    ShowGallery()
  End Sub

  Private Sub ShowViewer(filename As String)
    Dim f() As String = filename.Split("\")
    lblCaption.Text = f(UBound(f))
    For Each item As ToolStripItem In ts.Items
      item.Visible = True
    Next
    'ts.Visible = True
    imgContainer.Visible = True
    imgContainer.BringToFront()
    imgViewer.Visible = False
    Refresh()
    imgBox.LoadAsync(filename)
  End Sub

  Private Sub ShowGallery()
    imgContainer.Visible = False
    'ts.Visible = False
    imgViewer.Visible = True
    imgViewer.BringToFront()
    For Each item As ToolStripItem In ts.Items
      item.Visible = False
    Next
    With lblCaption
      If ancestor Is Nothing Then
        .Text = ASSISTANTVIEWER_NOANCESTOR
      Else
        .Text = "Gallery of " & ancestor.FullName
      End If
      .Visible = True
    End With
    Refresh()
  End Sub

  Private Async Sub ImageGallery_AncestorAssigned() Handles Me.AncestorAssigned
    imgViewer.Items.Clear()
    imgViewerList.Images.Clear()
    Await ReloadGalleryAsync()
    ShowGallery()
  End Sub

  Private Async Sub ImageGallery_AncestorUpdated() Handles Me.AncestorUpdated
    imgViewer.Items.Clear()
    imgViewerList.Images.Clear()
    Await ReloadGalleryAsync()
    ShowGallery()
  End Sub

  Private Async Function ReloadGalleryAsync() As Task
    Await Task.Run(Sub()
                     Dim galleryPath As String = Ancestor.AncestorPath
                     For Each fileName As String In Directory.GetFiles(galleryPath, "*.jpg", SearchOption.AllDirectories)
                       Dim caption As String = fileName.Replace(galleryPath, "")
                       If File.Exists(fileName + ".txt") Then
                         caption = File.ReadAllText(fileName + ".txt")
                       End If
                       LoadGalleryImage(caption, fileName)
                     Next
                   End Sub)
  End Function

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

  Private Sub LoadGalleryImage(caption As String, filename As String)
    BeginInvoke(Sub()
                  Dim maxSize As Integer = imgViewerList.ImageSize.Height
                  Dim img As Image = GetImageThumbnail(Image.FromFile(filename), maxSize)
                  Dim key As String
                  key = imgViewerList.Images.Count + 1
                  imgViewerList.Images.Add(key, img)
                  Dim newItem As ListViewItem = imgViewer.Items.Add(caption, key)
                  newItem.Tag = filename
                End Sub)
  End Sub

  Private Sub btnGallery_Click(sender As Object, e As EventArgs) Handles btnBack.Click
    ShowGallery()
  End Sub

  Private Sub imgViewer_DoubleClick(sender As Object, e As EventArgs) Handles imgViewer.DoubleClick
    ShowViewer(imgViewer.SelectedItems.Item(0).Tag)
  End Sub

  Private Sub imgBox_MouseDown(sender As Object, e As MouseEventArgs) Handles imgBox.MouseDown
    If PanningEnabled And e.Button = MouseButtons.Left And (imgBox.Height > imgContainer.Height Or imgBox.Width > imgContainer.Width) Then
      panningActive = True
      smoothedMousePosition = e.Location
    End If
  End Sub

  Private Sub imgBox_MouseMove(sender As Object, e As MouseEventArgs) Handles imgBox.MouseMove
    If panningActive Then
      Dim deltaX As Integer = CInt((e.X - smoothedMousePosition.X) * MouseSmoothingFactor)
      Dim deltaY As Integer = CInt((e.Y - smoothedMousePosition.Y) * MouseSmoothingFactor)
      smoothedMousePosition = New Point(smoothedMousePosition.X + deltaX, smoothedMousePosition.Y + deltaY)

      Dim newX As Integer = Math.Min(15, imgBox.Left + deltaX)
      Dim newY As Integer = Math.Min(15, imgBox.Top + deltaY)

      If newX < (imgContainer.Width - imgBox.Width - 15) Then newX = imgContainer.Width - imgBox.Width - 15
      If newY < (imgContainer.Height - imgBox.Height - 15) Then newY = imgContainer.Height - imgBox.Height - 15

      imgBox.Location = New Point(newX, newY)
    End If
  End Sub

  Private Sub imgBox_MouseUp(sender As Object, e As MouseEventArgs) Handles imgBox.MouseUp
    If e.Button = MouseButtons.Left Then
      panningActive = False
    End If
  End Sub

  Private Sub slider_ValueChanged(sender As Object, e As EventArgs) Handles slider.ValueChanged
    lblZoom.Text = slider.Value
    If zoomActive Then
      Dim width As Integer = CInt(imgBox.Image.Width * (slider.Value / 100))
      Dim height As Integer = CInt(imgBox.Image.Height * (slider.Value / 100))
      imgBox.size = New Size(width, height)
    End If
  End Sub

  Private Sub imgBox_LoadCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles imgBox.LoadCompleted
    slider.Value = 100
    imgBox.Location = New Point(15, 15)
    imgBox.size = imgBox.Image.Size
    imgBox.SizeMode = PictureBoxSizeMode.Zoom
    imgBox.Visible = True
    zoomActive = True
  End Sub

  Private Sub btnZoomFitHeightWidth_Click(sender As Object, e As EventArgs) Handles btnSizeHV.Click
    Dim zoomW As Integer = CInt(100 * ((imgContainer.Width - 30) / imgBox.Image.Width))
    Dim zoomH As Integer = CInt(100 * ((imgContainer.Height - 30) / imgBox.Image.Height))
    slider.Value = Math.Min(zoomW, zoomH)
    imgBox.Location = New Point(15, 15)

  End Sub

  Private Sub btnZoomFitWidth_Click(sender As Object, e As EventArgs) Handles btnSizeH.Click
    Dim zoomW As Integer = CInt(100 * ((imgContainer.Width - 30) / imgBox.Image.Width))
    slider.Value = zoomW
    imgBox.Location = New Point(15, 15)

  End Sub

  Private Sub btnZoomFitHeight_Click(sender As Object, e As EventArgs) Handles btnSizeV.Click
    Dim zoomH As Integer = CInt(100 * ((imgContainer.Height - 30) / imgBox.Image.Height))
    slider.Value = zoomH
    imgBox.Location = New Point(15, 15)

  End Sub

  Private Sub imgContainer_Resize(sender As Object, e As EventArgs) Handles imgContainer.Resize
    imgBox.Location = New Point(15, 15)
  End Sub

  Private Sub btnFlipV_Click(sender As Object, e As EventArgs) Handles btnFlipV.Click
    imgBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
    imgBox.Invalidate()
  End Sub

  Private Sub btnFlipH_Click(sender As Object, e As EventArgs) Handles btnFlipH.Click
    imgBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
    imgBox.Invalidate()
  End Sub

End Class