Imports System.ComponentModel

Public Class ImageViewer

  Public Event BackToGallery()

  Private panningActive As Boolean = False
  Private smoothedMousePosition As Point
  Private zoomActive As Boolean = False

  ''' <value>True</value>
  <Description("Enable/Disable Toolbar")>
  Public Property ToolbarEnabled As Boolean
    Get
      Return imgToolbar.Visible
    End Get
    Set(value As Boolean)
      imgToolbar.Visible = value
    End Set
  End Property

  ''' <value>True</value>
  <Description("Enable/Disable Panning")>
  Public Property PanningEnabled As Boolean = True

  ''' <value>0.1</value>
  <Description("Enable/Disable Panning")>
  Public Property MouseSmoothingFactor As Double = 0.1


  ''' <value>100</value>
  <Category("Zoom"), Description("Zoom factor (10 to 150)")>
  Public Property ZoomFactor As Integer
    Get
      Return zoomSlider.Value
    End Get
    Set(value As Integer)
      If value > 0 And value < 150 Then
        zoomSlider.Value = value
      End If
    End Set
  End Property

  ''' <value>True</value>
  <Category("Zoom"), Description("Enable/Disable Zooming")>
  Public Property ZoomEnabled As Boolean
    Get
      Return zoomSlider.Enabled
    End Get
    Set(value As Boolean)
      If Not value Then ZoomFactor = 100
      zoomSlider.Enabled = value
      zoomText.Enabled = value
      btnZoomFitHeight.Enabled = value
      btnZoomFitHeightWidth.Enabled = value
      btnZoomFitWidth.Enabled = value
    End Set
  End Property


  ''' <summary>
  ''' This is the Summary
  ''' </summary>
  ''' <remarks>These are the remarks</remarks>
  <Category("Image"), Description("Image Filename")>
  Public Property ImageFile As String
    Get
      Return imgBox.ImageLocation
    End Get
    Set(value As String)
      If value = "" Then
        imgBox.Image = Nothing
        imgBox.ImageLocation = ""
        'imgBox.Hide()
      Else
        imgBox.LoadAsync(value)
      End If
    End Set
  End Property

  <Category("Image"), Description("Height of loaded image")>
  Public ReadOnly Property ImageHeight As Integer
    Get
      If IsNothing(imgBox.Image) Then
        Return vbNull
      End If
      Return imgBox.Image.Height
    End Get
  End Property

  <Category("Image"), Description("Width of loaded image")>
  Public ReadOnly Property ImageWidth As Integer
    Get
      If IsNothing(imgBox.Image) Then
        Return vbNull
      End If
      Return imgBox.Image.Width
    End Get
  End Property

  <Category("Image"), Description("Zoomed Height of loaded image")>
  Public ReadOnly Property ImageZoomHeight As Integer
    Get
      If IsNothing(imgBox.Image) Then
        Return vbNull
      End If
      Return imgBox.Height
    End Get
  End Property

  <Category("Image"), Description("Zoomed Width of loaded image")>
  Public ReadOnly Property ImageZoomWidth As Integer
    Get
      If IsNothing(imgBox.Image) Then
        Return vbNull
      End If
      Return imgBox.Width
    End Get
  End Property

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

  Private Sub zoomSlider_ValueChanged(sender As Object, e As EventArgs) Handles zoomSlider.ValueChanged
    zoomText.Text = zoomSlider.Value
    If zoomActive Then
      Dim width As Integer = CInt(imgBox.Image.Width * (zoomSlider.Value / 100))
      Dim height As Integer = CInt(imgBox.Image.Height * (zoomSlider.Value / 100))
      imgBox.Size = New Size(width, height)
    End If
  End Sub

  Private Sub imgBox_LoadCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles imgBox.LoadCompleted
    zoomSlider.Value = 100
    imgBox.Location = New Point(15, 15)
    imgBox.Size = imgBox.Image.Size
    imgBox.SizeMode = PictureBoxSizeMode.Zoom
    imgBox.Visible = True
    zoomActive = True
  End Sub

  Private Sub btnZoomFitHeightWidth_Click(sender As Object, e As EventArgs) Handles btnZoomFitHeightWidth.Click
    Dim zoomW As Integer = CInt(100 * ((imgContainer.Width - 30) / imgBox.Image.Width))
    Dim zoomH As Integer = CInt(100 * ((imgContainer.Height - 30) / imgBox.Image.Height))
    zoomSlider.Value = Math.Min(zoomW, zoomH)
    imgBox.Location = New Point(15, 15)

  End Sub

  Private Sub btnZoomFitWidth_Click(sender As Object, e As EventArgs) Handles btnZoomFitWidth.Click
    Dim zoomW As Integer = CInt(100 * ((imgContainer.Width - 30) / imgBox.Image.Width))
    zoomSlider.Value = zoomW
    imgBox.Location = New Point(15, 15)

  End Sub

  Private Sub btnZoomFitHeight_Click(sender As Object, e As EventArgs) Handles btnZoomFitHeight.Click
    Dim zoomH As Integer = CInt(100 * ((imgContainer.Height - 30) / imgBox.Image.Height))
    zoomSlider.Value = zoomH
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

  Private Sub btnGallery_Click(sender As Object, e As EventArgs) Handles btnGallery.Click
    RaiseEvent BackToGallery()
  End Sub
End Class
