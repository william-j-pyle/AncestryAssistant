Imports System.ComponentModel
Imports System.IO

Public Class ImageGalleryPanelItem
  Inherits UserControl
  Implements IDockPanelItem

#Region "Fields"

  Friend WithEvents btnBack As ToolStripButton

  Friend WithEvents btnFlipH As ToolStripButton

  Friend WithEvents btnFlipV As ToolStripButton

  Friend WithEvents btnSizeH As ToolStripButton

  Friend WithEvents btnSizeHV As ToolStripButton

  Friend WithEvents btnSizeV As ToolStripButton

  Friend WithEvents imgBox As PictureBox

  Friend WithEvents imgContainer As Panel

  Friend WithEvents imgViewer As ListView

  Friend WithEvents imgViewerList As ImageList

  Friend WithEvents lblCaption As ToolStripLabel

  Friend WithEvents lblZoom As ToolStripLabel

  Friend WithEvents slider As TrackBar

  Friend WithEvents sliderHost As ToolStripControlHost

  Friend WithEvents toolStripSeparator As ToolStripSeparator

  Friend WithEvents ts As FlatToolBar

  Private Const EN_ITEMCAPTION As String = "Image Gallery"

  Private components As System.ComponentModel.IContainer

  Private MouseSmoothingFactor As Double = 0.1

  ' Tracking
  Private panningActive As Boolean = False

  Private PanningEnabled As Boolean = True

  Private smoothedMousePosition As Point

  Private zoomActive As Boolean = False

  Friend Ancestor As AncestorCollection.Ancestor

#End Region

#Region "Events"

  Public Event AncestorAssigned() Implements IDockPanelItem.AncestorAssigned

  Public Event AncestorUpdated() Implements IDockPanelItem.AncestorUpdated

  Public Event PanelItemGotFocus(sender As Object, e As EventArgs) Implements IDockPanelItem.PanelItemGotFocus

#End Region

#Region "Properties"

  Public ReadOnly Property ItemCaption As String = EN_ITEMCAPTION Implements IDockPanelItem.ItemCaption
  Public Property ItemDockPanelLocation As DockPanelLocation Implements IDockPanelItem.ItemDockPanelLocation
  Public Property ItemHasFocus As Boolean = False Implements IDockPanelItem.ItemHasFocus
  Public ReadOnly Property ItemHasRibbonBar As Boolean = True Implements IDockPanelItem.ItemHasRibbonBar
  Public ReadOnly Property ItemHasToolBar As Boolean = False Implements IDockPanelItem.ItemHasToolBar
  Public ReadOnly Property ItemSupportsClose As Boolean = True Implements IDockPanelItem.ItemSupportsClose
  Public ReadOnly Property ItemSupportsMove As Boolean = True Implements IDockPanelItem.ItemSupportsMove
  Public ReadOnly Property ItemSupportsSearch As Boolean = False Implements IDockPanelItem.ItemSupportsSearch
  Public ReadOnly Property ShowRibbonOnFocus As String = EN_ITEMCAPTION Implements IDockPanelItem.ShowRibbonOnFocus

#End Region

#Region "Public Constructors"

  Public Sub New()
    components = New Container()
    imgViewer = New ListView()
    imgViewerList = New ImageList(components)
    imgContainer = New Panel()
    imgBox = New PictureBox()
    ts = New FlatToolBar()
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
    imgViewer.BackColor = My.Theme.PanelBackColor
    imgViewer.BorderStyle = BorderStyle.None
    imgViewer.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
    imgViewer.ForeColor = My.Theme.PanelFontColor
    imgViewer.HideSelection = False
    imgViewer.LargeImageList = imgViewerList
    imgViewer.Location = New Point(0, 144)
    imgViewer.MultiSelect = False
    imgViewer.Name = "imgViewer"
    imgViewer.Size = New Size(223, 174)
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
    imgContainer.BackColor = My.Theme.PanelBackColor
    imgContainer.Controls.Add(imgBox)
    imgContainer.Location = New Point(257, 144)
    imgContainer.Margin = New Padding(0)
    imgContainer.Name = "imgContainer"
    imgContainer.Size = New Size(200, 174)
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
    imgBox.Size = New Size(100, 100)
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
      .Size = New Size(120, 20)
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
      .Size = New Size(465, 25)
      .Text = ""
    End With

    '
    'btnBack
    '
    With btnBack
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
    btnFlipV.DisplayStyle = ToolStripItemDisplayStyle.Image
    btnFlipV.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    btnFlipV.ImageTransparentColor = Color.Transparent
    btnFlipV.Name = "btnFlipV"
    btnFlipV.Size = New Size(23, 22)
    btnFlipV.Text = "Flip Image Vertically"
    '
    'btnFlipH
    '
    btnFlipH.DisplayStyle = ToolStripItemDisplayStyle.Image
    btnFlipH.Image = My.Theme.ImageButtonFlipH
    btnFlipH.ImageTransparentColor = Color.Transparent
    btnFlipH.Name = "btnFlipH"
    btnFlipH.Size = New Size(23, 22)
    btnFlipH.Text = "Flip Image Horizontally"
    '
    'lblCaption
    '
    lblCaption.ForeColor = My.Theme.PanelFontColor
    lblCaption.Name = "lblCaption"
    lblCaption.Size = New Size(87, 22)
    lblCaption.TextAlign = ContentAlignment.MiddleCenter
    lblCaption.Text = ""
    lblCaption.Dock = DockStyle.Fill
    '
    'btnSizeHV
    '
    btnSizeHV.Alignment = ToolStripItemAlignment.Right
    btnSizeHV.DisplayStyle = ToolStripItemDisplayStyle.Image
    btnSizeHV.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    btnSizeHV.ImageTransparentColor = Color.Transparent
    btnSizeHV.Name = "btnSizeHV"
    btnSizeHV.Size = New Size(23, 22)
    btnSizeHV.Text = "Fit Full Image"
    '
    'btnSizeH
    '
    btnSizeH.Alignment = ToolStripItemAlignment.Right
    btnSizeH.DisplayStyle = ToolStripItemDisplayStyle.Image
    btnSizeH.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    btnSizeH.ImageTransparentColor = Color.Transparent
    btnSizeH.Name = "btnSizeH"
    btnSizeH.Size = New Size(23, 22)
    btnSizeH.Text = "Fit Image Width"
    '
    'btnSizeV
    '
    btnSizeV.Alignment = ToolStripItemAlignment.Right
    btnSizeV.DisplayStyle = ToolStripItemDisplayStyle.Image
    btnSizeV.Image = Global.AncestryAssistant.My.Resources.Resources.ANCESTRY
    btnSizeV.ImageTransparentColor = Color.Transparent
    btnSizeV.Name = "btnSizeV"
    btnSizeV.Size = New Size(23, 22)
    btnSizeV.Text = "Fit Image Height"
    '
    'lblZoom
    '
    lblZoom.Alignment = ToolStripItemAlignment.Right
    lblZoom.ForeColor = My.Theme.PanelFontColor
    lblZoom.Name = "lblZoom"
    lblZoom.Size = New Size(25, 22)
    lblZoom.Text = "100"

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
    CaptureFocus(Me)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub btnFlipH_Click(sender As Object, e As EventArgs) Handles btnFlipH.Click
    imgBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
    imgBox.Invalidate()
  End Sub

  Private Sub btnFlipV_Click(sender As Object, e As EventArgs) Handles btnFlipV.Click
    imgBox.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
    imgBox.Invalidate()
  End Sub

  Private Sub btnGallery_Click(sender As Object, e As EventArgs) Handles btnBack.Click
    ShowGallery()
  End Sub

  Private Sub btnZoomFitHeight_Click(sender As Object, e As EventArgs) Handles btnSizeV.Click
    Dim zoom As Integer = CInt(100 * ((imgContainer.Height - 30) / imgBox.Image.Height))
    If zoom > slider.Maximum Then zoom = slider.Maximum
    If zoom < slider.Minimum Then zoom = slider.Minimum
    slider.Value = zoom
    imgBox.Location = New Point(15, 15)

  End Sub

  Private Sub btnZoomFitHeightWidth_Click(sender As Object, e As EventArgs) Handles btnSizeHV.Click
    Dim zoomW As Integer = CInt(100 * ((imgContainer.Width - 30) / imgBox.Image.Width))
    Dim zoomH As Integer = CInt(100 * ((imgContainer.Height - 30) / imgBox.Image.Height))
    Dim zoom As Integer = Math.Min(zoomW, zoomH)
    If zoom > slider.Maximum Then zoom = slider.Maximum
    If zoom < slider.Minimum Then zoom = slider.Minimum

    slider.Value = zoom
    imgBox.Location = New Point(15, 15)

  End Sub

  Private Sub btnZoomFitWidth_Click(sender As Object, e As EventArgs) Handles btnSizeH.Click
    Dim zoom As Integer = CInt(100 * ((imgContainer.Width - 30) / imgBox.Image.Width))
    If zoom > slider.Maximum Then zoom = slider.Maximum
    If zoom < slider.Minimum Then zoom = slider.Minimum
    slider.Value = zoom
    imgBox.Location = New Point(15, 15)

  End Sub

  Private Sub CaptureFocus(ctl As Control)
    Try
      AddHandler ctl.GotFocus, AddressOf DockPanelItem_GotFocus
      AddHandler ctl.MouseDown, AddressOf DockPanelItem_GotFocus
    Catch ex As Exception
    End Try
    For Each childCtl As Control In ctl.Controls
      CaptureFocus(childCtl)
    Next
  End Sub

  Private Sub DockPanelItem_GotFocus(sender As Object, e As EventArgs)
    RaiseEvent PanelItemGotFocus(sender, e)
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

  Private Sub imgBox_LoadCompleted(sender As Object, e As AsyncCompletedEventArgs) Handles imgBox.LoadCompleted
    slider.Value = 100
    imgBox.Location = New Point(15, 15)
    imgBox.Size = imgBox.Image.Size
    imgBox.SizeMode = PictureBoxSizeMode.Zoom
    imgBox.Visible = True
    zoomActive = True
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

  Private Sub imgContainer_Resize(sender As Object, e As EventArgs) Handles imgContainer.Resize
    imgBox.Location = New Point(15, 15)
  End Sub

  Private Sub imgViewer_DoubleClick(sender As Object, e As EventArgs) Handles imgViewer.DoubleClick
    ShowViewer(imgViewer.SelectedItems.Item(0).Tag)
  End Sub

  Private Sub LoadGalleryImage(caption As String, filename As String)
    BeginInvoke(Sub()
                  Dim maxSize As Integer = imgViewerList.ImageSize.Height
                  Dim img As Image = GetImageThumbnail(Image.FromFile(filename), maxSize)
                  Dim key As String = (imgViewerList.Images.Count + 1).ToString
                  imgViewerList.Images.Add(key, img)
                  Dim newItem As ListViewItem = imgViewer.Items.Add(caption, key)
                  newItem.Tag = filename
                End Sub)
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

  Private Sub ShowGallery()
    imgContainer.Visible = False
    'ts.Visible = False
    imgViewer.Visible = True
    imgViewer.BringToFront()
    For Each item As ToolStripItem In ts.Items
      item.Visible = False
    Next
    Refresh()
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

  Private Sub slider_ValueChanged(sender As Object, e As EventArgs) Handles slider.ValueChanged
    lblZoom.Text = slider.Value
    If zoomActive Then
      Dim width As Integer = CInt(imgBox.Image.Width * (slider.Value / 100))
      Dim height As Integer = CInt(imgBox.Image.Height * (slider.Value / 100))
      imgBox.Size = New Size(width, height)
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

#End Region

#Region "Public Methods"

  Public Sub ApplySearch(criteria As String) Implements IDockPanelItem.ApplySearch
    Throw New NotImplementedException()
  End Sub

  Public Sub ClearSearch() Implements IDockPanelItem.ClearSearch
    Throw New NotImplementedException()
  End Sub

  Public Function GetDockToolBarConfig() As DockToolBarConfig Implements IDockPanelItem.GetDockToolBarConfig
    Throw New NotImplementedException()
  End Function

  Public Function GetRibbonBarConfig() As RibbonBarTabConfig Implements IDockPanelItem.GetRibbonBarConfig
    Throw New NotImplementedException()
  End Function

  Public Sub RefreshAncestor() Implements IDockPanelItem.RefreshAncestor
    Throw New NotImplementedException()
  End Sub

  Public Sub SetAncestor(activeAncestor As AncestorCollection.Ancestor) Implements IDockPanelItem.SetAncestor
    Throw New NotImplementedException()
  End Sub

#End Region

End Class