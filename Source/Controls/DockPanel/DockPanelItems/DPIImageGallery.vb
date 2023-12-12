Imports System.ComponentModel
Imports System.IO

Public Class DPIImageGallery
  Inherits DockPanelItem

#Region "Fields"

  Friend WithEvents BtnBack As ToolStripButton

  Friend WithEvents BtnFlipH As ToolStripButton

  Friend WithEvents BtnFlipV As ToolStripButton

  Friend WithEvents BtnSizeH As ToolStripButton

  Friend WithEvents BtnSizeHV As ToolStripButton

  Friend WithEvents BtnSizeV As ToolStripButton

  Friend WithEvents ImgBox As PictureBox

  Friend WithEvents ImgContainer As Panel

  Friend WithEvents ImgViewer As ListView

  Friend WithEvents ImgViewerList As ImageList

  Friend WithEvents LblCaption As ToolStripLabel

  Friend WithEvents LblZoom As ToolStripLabel

  Friend WithEvents slider As TrackBar

  Friend WithEvents sliderHost As ToolStripControlHost

  Friend WithEvents toolStripSeparator As ToolStripSeparator

  Friend WithEvents Ts As FlatToolBar

  Private Const Default_ItemCaption As String = "Image Gallery"
  Private Const Default_ItemHasRibbonBar As Boolean = True
  Private Const Default_ItemHasToolBar As Boolean = False
  Private Const Default_ItemSupportsClose As Boolean = True
  Private Const Default_ItemSupportsMove As Boolean = True
  Private Const Default_ItemSupportsSearch As Boolean = False
  Private Const Default_LocationCurrent As DockPanelLocation = DockPanelLocation.None
  Private Const Default_LocationPrefered As DockPanelLocation = DockPanelLocation.MiddleTopLeft
  Private Const Default_LocationPrevious As DockPanelLocation = DockPanelLocation.MiddleTopLeft
  Private Const Default_RibbonBarKey As String = "B500"
  Private Const Default_RibbonHideOnItemClose As Boolean = True
  Private Const Default_RibbonSelectOnItemFocus As Boolean = True
  Private Const Default_RibbonShowOnItemOpen As Boolean = True
  Private components As System.ComponentModel.IContainer
  Private MouseSmoothingFactor As Double = 0.1
  ' Tracking
  Private panningActive As Boolean = False
  Private PanningEnabled As Boolean = True
  Private smoothedMousePosition As Point
  Private zoomActive As Boolean = False
  Public Const Default_Key As String = "DOCK_GALLERY"

#End Region

#Region "Public Constructors"

  Public Sub New(Optional instanceKey As String = "")
    'Apply Item Defaults for this Type
    ItemCaption = Default_ItemCaption
    ItemHasRibbonBar = Default_ItemHasRibbonBar
    ItemHasToolBar = Default_ItemHasToolBar
    ItemSupportsClose = Default_ItemSupportsClose
    ItemSupportsMove = Default_ItemSupportsMove
    ItemSupportsSearch = Default_ItemSupportsSearch
    ItemKey = Default_Key
    ItemInstanceKey = instanceKey
    LocationCurrent = Default_LocationCurrent
    LocationPrefered = Default_LocationPrefered
    LocationPrevious = Default_LocationPrevious
    RibbonBarKey = Default_RibbonBarKey
    RibbonHideOnItemClose = Default_RibbonHideOnItemClose
    RibbonSelectOnItemFocus = Default_RibbonSelectOnItemFocus
    RibbonShowOnItemOpen = Default_RibbonShowOnItemOpen
    'Continue with creation
    components = New Container()
    ImgViewer = New ListView()
    ImgViewerList = New ImageList(components)
    ImgContainer = New Panel()
    ImgBox = New PictureBox()
    Ts = New FlatToolBar()
    slider = New TrackBar()
    BtnBack = New ToolStripButton()
    BtnFlipV = New ToolStripButton()
    BtnFlipH = New ToolStripButton()
    LblCaption = New ToolStripLabel()
    BtnSizeHV = New ToolStripButton()
    BtnSizeH = New ToolStripButton()
    BtnSizeV = New ToolStripButton()
    LblZoom = New ToolStripLabel()
    toolStripSeparator = New ToolStripSeparator()
    ImgContainer.SuspendLayout()
    CType(ImgBox, System.ComponentModel.ISupportInitialize).BeginInit()
    Ts.SuspendLayout()
    SuspendLayout()
    '
    'imgViewer
    '
    ImgViewer.BackColor = My.Theme.PanelBackColor
    ImgViewer.BorderStyle = BorderStyle.None
    ImgViewer.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
    ImgViewer.ForeColor = My.Theme.PanelFontColor
    ImgViewer.HideSelection = False
    ImgViewer.LargeImageList = ImgViewerList
    ImgViewer.Location = New Point(0, 144)
    ImgViewer.MultiSelect = False
    ImgViewer.Name = "imgViewer"
    ImgViewer.Size = New Size(223, 174)
    ImgViewer.TabIndex = 0
    ImgViewer.TileSize = New Size(256, 256)
    ImgViewer.UseCompatibleStateImageBehavior = False
    ImgViewer.View = View.Tile
    '
    'imgViewerList
    '
    ImgViewerList.ColorDepth = ColorDepth.Depth32Bit
    ImgViewerList.ImageSize = New Size(256, 256)
    ImgViewerList.TransparentColor = Color.Transparent
    '
    'imgContainer
    '
    ImgContainer.BackColor = My.Theme.PanelBackColor
    ImgContainer.Controls.Add(ImgBox)
    ImgContainer.Location = New Point(257, 144)
    ImgContainer.Margin = New Padding(0)
    ImgContainer.Name = "imgContainer"
    ImgContainer.Size = New Size(200, 174)
    ImgContainer.TabIndex = 4
    '
    'imgBox
    '
    ImgBox.BorderStyle = BorderStyle.FixedSingle
    ImgBox.Cursor = Cursors.Hand
    ImgBox.ErrorImage = Nothing
    ImgBox.ImageLocation = ""
    ImgBox.Location = New Point(29, 48)
    ImgBox.Margin = New Padding(0)
    ImgBox.Name = "imgBox"
    ImgBox.Size = New Size(100, 100)
    ImgBox.SizeMode = PictureBoxSizeMode.AutoSize
    ImgBox.TabIndex = 0
    ImgBox.TabStop = False

    With slider
      .Minimum = 10
      .Maximum = 150
      .Value = 100
      .SmallChange = 1
      .LargeChange = 10
      .TickFrequency = 10
      .MaximumSize = New Size(120, 20)
      .MinimumSize = New Size(120, 20)
      .Size = New Size(120, 20)
    End With

    sliderHost = New ToolStripControlHost(slider)

    '
    'ts
    '
    With Ts
      Ts.GripStyle = ToolStripGripStyle.Hidden
      .Items.AddRange(New ToolStripItem() {BtnBack, BtnFlipV, BtnFlipH, LblCaption, LblZoom, sliderHost, toolStripSeparator, BtnSizeH, BtnSizeV, BtnSizeHV})
      .Location = New Point(0, 0)
      .Name = "ts"
      .RenderMode = ToolStripRenderMode.System
      .Size = New Size(465, 25)
      .Text = ""
    End With

    '
    'btnBack
    '
    With BtnBack
      .DisplayStyle = ToolStripItemDisplayStyle.Image
      .Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
      .ImageTransparentColor = Color.Transparent
      .Name = ""
      .Size = New Size(23, 22)
      .Text = "Back to Gallery"
    End With
    '
    'btnFlipV
    '
    BtnFlipV.DisplayStyle = ToolStripItemDisplayStyle.Image
    BtnFlipV.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    BtnFlipV.ImageTransparentColor = Color.Transparent
    BtnFlipV.Name = "btnFlipV"
    BtnFlipV.Size = New Size(23, 22)
    BtnFlipV.Text = "Flip Image Vertically"
    '
    'btnFlipH
    '
    BtnFlipH.DisplayStyle = ToolStripItemDisplayStyle.Image
    BtnFlipH.Image = My.Theme.ImageButtonFlipH
    BtnFlipH.ImageTransparentColor = Color.Transparent
    BtnFlipH.Name = "btnFlipH"
    BtnFlipH.Size = New Size(23, 22)
    BtnFlipH.Text = "Flip Image Horizontally"
    '
    'LblCaption
    '
    LblCaption.ForeColor = My.Theme.PanelFontColor
    LblCaption.Name = "LblCaption"
    LblCaption.Size = New Size(87, 22)
    LblCaption.TextAlign = ContentAlignment.MiddleCenter
    LblCaption.Text = ""
    LblCaption.Dock = DockStyle.Fill
    '
    'btnSizeHV
    '
    BtnSizeHV.Alignment = ToolStripItemAlignment.Right
    BtnSizeHV.DisplayStyle = ToolStripItemDisplayStyle.Image
    BtnSizeHV.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    BtnSizeHV.ImageTransparentColor = Color.Transparent
    BtnSizeHV.Name = "btnSizeHV"
    BtnSizeHV.Size = New Size(23, 22)
    BtnSizeHV.Text = "Fit Full Image"
    '
    'btnSizeH
    '
    BtnSizeH.Alignment = ToolStripItemAlignment.Right
    BtnSizeH.DisplayStyle = ToolStripItemDisplayStyle.Image
    BtnSizeH.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    BtnSizeH.ImageTransparentColor = Color.Transparent
    BtnSizeH.Name = "btnSizeH"
    BtnSizeH.Size = New Size(23, 22)
    BtnSizeH.Text = "Fit Image Width"
    '
    'btnSizeV
    '
    BtnSizeV.Alignment = ToolStripItemAlignment.Right
    BtnSizeV.DisplayStyle = ToolStripItemDisplayStyle.Image
    BtnSizeV.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    BtnSizeV.ImageTransparentColor = Color.Transparent
    BtnSizeV.Name = "btnSizeV"
    BtnSizeV.Size = New Size(23, 22)
    BtnSizeV.Text = "Fit Image Height"
    '
    'lblZoom
    '
    LblZoom.Alignment = ToolStripItemAlignment.Right
    LblZoom.ForeColor = My.Theme.PanelFontColor
    LblZoom.Name = "lblZoom"
    LblZoom.Size = New Size(25, 22)
    LblZoom.Text = "100"

    '
    'toolStripSeparator
    '
    toolStripSeparator.Alignment = ToolStripItemAlignment.Right
    toolStripSeparator.Name = "toolStripSeparator"
    toolStripSeparator.Size = New Size(6, 25)

    With sliderHost
      .Alignment = ToolStripItemAlignment.Right
      .Size = New Size(120, 20)
    End With

    AutoScaleDimensions = New SizeF(6.0!, 13.0!)
    AutoScaleMode = AutoScaleMode.Font
    Controls.Add(Ts)
    Controls.Add(ImgContainer)
    Controls.Add(ImgViewer)
    Name = "ImageGallery"
    Size = New Size(465, 330)
    ImgContainer.ResumeLayout(False)
    ImgContainer.PerformLayout()
    CType(ImgBox, System.ComponentModel.ISupportInitialize).EndInit()
    Ts.ResumeLayout(False)
    Ts.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
    Dock = DockStyle.Fill
    ImgViewer.Dock = DockStyle.Fill
    ImgContainer.Dock = DockStyle.Fill
    ShowGallery()
    CaptureFocus(Me)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub Ancestors_ActiveAncestorChanged(ancestorId As String) Handles Ancestors.ActiveAncestorChanged
    UpdateUI()
  End Sub

  Private Sub Ancestors_AncestorsChanged() Handles Ancestors.AncestorsChanged
    UpdateUI()
  End Sub

  Private Sub BtnFlipH_Click(sender As Object, e As EventArgs) Handles BtnFlipH.Click
    ImgBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
    ImgBox.Invalidate()
  End Sub

  Private Sub BtnFlipV_Click(sender As Object, e As EventArgs) Handles BtnFlipV.Click
    ImgBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
    ImgBox.Invalidate()
  End Sub

  Private Sub BtnGallery_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
    ShowGallery()
  End Sub

  Private Sub BtnZoomFitHeight_Click(sender As Object, e As EventArgs) Handles BtnSizeV.Click
    Dim zoom As Integer = CInt(100 * ((ImgContainer.Height - 30) / ImgBox.Image.Height))
    If zoom > slider.Maximum Then zoom = slider.Maximum
    If zoom < slider.Minimum Then zoom = slider.Minimum
    slider.Value = zoom
    ImgBox.Location = New Point(15, 15)

  End Sub

  Private Sub BtnZoomFitHeightWidth_Click(sender As Object, e As EventArgs) Handles BtnSizeHV.Click
    Dim zoomW As Integer = CInt(100 * ((ImgContainer.Width - 30) / ImgBox.Image.Width))
    Dim zoomH As Integer = CInt(100 * ((ImgContainer.Height - 30) / ImgBox.Image.Height))
    Dim zoom As Integer = Math.Min(zoomW, zoomH)
    If zoom > slider.Maximum Then zoom = slider.Maximum
    If zoom < slider.Minimum Then zoom = slider.Minimum

    slider.Value = zoom
    ImgBox.Location = New Point(15, 15)

  End Sub

  Private Sub BtnZoomFitWidth_Click(sender As Object, e As EventArgs) Handles BtnSizeH.Click
    Dim zoom As Integer = CInt(100 * ((ImgContainer.Width - 30) / ImgBox.Image.Width))
    If zoom > slider.Maximum Then zoom = slider.Maximum
    If zoom < slider.Minimum Then zoom = slider.Minimum
    slider.Value = zoom
    ImgBox.Location = New Point(15, 15)

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

  Private Sub ImgBox_LoadCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles ImgBox.LoadCompleted
    slider.Value = 100
    ImgBox.Location = New Point(15, 15)
    ImgBox.Size = ImgBox.Image.Size
    ImgBox.SizeMode = PictureBoxSizeMode.Zoom
    ImgBox.Visible = True
    zoomActive = True
  End Sub

  Private Sub ImgBox_MouseDown(sender As Object, e As MouseEventArgs) Handles ImgBox.MouseDown
    If PanningEnabled And e.Button = MouseButtons.Left And (ImgBox.Height > ImgContainer.Height Or ImgBox.Width > ImgContainer.Width) Then
      panningActive = True
      smoothedMousePosition = e.Location
    End If
  End Sub

  Private Sub ImgBox_MouseMove(sender As Object, e As MouseEventArgs) Handles ImgBox.MouseMove
    If panningActive Then
      Dim deltaX As Integer = CInt((e.X - smoothedMousePosition.X) * MouseSmoothingFactor)
      Dim deltaY As Integer = CInt((e.Y - smoothedMousePosition.Y) * MouseSmoothingFactor)
      smoothedMousePosition = New Point(smoothedMousePosition.X + deltaX, smoothedMousePosition.Y + deltaY)

      Dim newX As Integer = Math.Min(15, ImgBox.Left + deltaX)
      Dim newY As Integer = Math.Min(15, ImgBox.Top + deltaY)

      If newX < (ImgContainer.Width - ImgBox.Width - 15) Then newX = ImgContainer.Width - ImgBox.Width - 15
      If newY < (ImgContainer.Height - ImgBox.Height - 15) Then newY = ImgContainer.Height - ImgBox.Height - 15

      ImgBox.Location = New Point(newX, newY)
    End If
  End Sub

  Private Sub ImgBox_MouseUp(sender As Object, e As MouseEventArgs) Handles ImgBox.MouseUp
    If e.Button = MouseButtons.Left Then
      panningActive = False
    End If
  End Sub

  Private Sub ImgContainer_Resize(sender As Object, e As EventArgs) Handles ImgContainer.Resize
    ImgBox.Location = New Point(15, 15)
  End Sub

  Private Sub ImgViewer_DoubleClick(sender As Object, e As EventArgs) Handles ImgViewer.DoubleClick
    ShowViewer(ImgViewer.SelectedItems.Item(0).Tag.ToString)
  End Sub

  Private Sub LoadGalleryImage(caption As String, filename As String)
    Dim maxSize As Integer = ImgViewerList.ImageSize.Height
    Dim Img As Image = GetImageThumbnail(Image.FromFile(filename), maxSize)
    Dim key As String = (ImgViewerList.Images.Count + 1).ToString
    ImgViewerList.Images.Add(key, Img)
    Dim newItem As ListViewItem = ImgViewer.Items.Add(caption, key)
    newItem.Tag = filename
  End Sub

  Private Sub ProcessFileAsync(fileName As String)
    Dim galleryPath As String = Ancestors.ActiveAncestor.AncestorPath
    Dim caption As String = fileName.Replace(galleryPath, "")
    If File.Exists(fileName + ".txt") Then
      caption = File.ReadAllText(fileName + ".txt")
    End If
    If InvokeRequired Then
      BeginInvoke(Sub()
                    LoadGalleryImage(caption, fileName)
                  End Sub)
    Else
      LoadGalleryImage(caption, fileName)
    End If
  End Sub

  Private Sub ReloadGalleryAsync()
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("ImageGalleryPanelItem.ReloadGalleryAsync()")
#End If

    Dim fileNames As List(Of String) = Directory.GetFiles(Ancestors.ActiveAncestor.AncestorPath, "*.jpg", SearchOption.AllDirectories).ToList()
    Parallel.ForEach(fileNames, Async Sub(fileName)
                                  ProcessFileAsync(fileName)
                                End Sub)
  End Sub

  Private Sub ShowGallery()
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("ImageGalleryPanelItem.ShowGallery()")
#End If
    ImgContainer.Visible = False
    'ts.Visible = False
    ImgViewer.Visible = True
    ImgViewer.BringToFront()
    For Each item As ToolStripItem In Ts.Items
      item.Visible = False
    Next
    Refresh()
  End Sub

  Private Sub ShowViewer(filename As String)
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("ImageGalleryPanelItem.ShowViewer(filename=[{0}])", filename)
#End If

    Dim f() As String = filename.Split("\"c)
    LblCaption.Text = f(UBound(f))
    For Each item As ToolStripItem In Ts.Items
      item.Visible = True
    Next
    'ts.Visible = True
    ImgContainer.Visible = True
    ImgContainer.BringToFront()
    ImgViewer.Visible = False
    Refresh()
    ImgBox.LoadAsync(filename)
  End Sub

  Private Sub slider_ValueChanged(sender As Object, e As EventArgs) Handles slider.ValueChanged
    LblZoom.Text = CStr(slider.Value)
    If zoomActive Then
      Dim width As Integer = CInt(ImgBox.Image.Width * (slider.Value / 100))
      Dim height As Integer = CInt(ImgBox.Image.Height * (slider.Value / 100))
      ImgBox.Size = New Size(width, height)
    End If
  End Sub

#End Region

#Region "Protected Methods"

  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  Protected Overrides Sub UpdateUI(Optional reload As Boolean = True)
#If DEBUG_LEVEL >= DEBUG_LEVEL_EVENT Then
    Logger.debugPrint("ImageGalleryPanelItem.UpdateUI()")
#End If

    If Ancestors Is Nothing Then Exit Sub
    ImgViewer.Items.Clear()
    ImgViewerList.Images.Clear()
    If Not Ancestors.HasActiveAncestor Then Exit Sub
    ShowGallery()
    ReloadGalleryAsync()
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub ApplySearch(criteria As String)
    Throw New NotImplementedException()
  End Sub

  Public Overrides Sub ClearSearch()
    Throw New NotImplementedException()
  End Sub

#End Region

End Class