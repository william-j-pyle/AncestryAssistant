Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class jImageViewer
  Inherits Panel
  Private WithEvents imgContainer As Panel
  Private WithEvents imgBox As PictureBox
  Private WithEvents imgToolbar As Panel
  Private WithEvents zoomSlider As TrackBar
  Private WithEvents btnTestImg1 As Button
  Private WithEvents btnTestImg2 As Button
  Private WithEvents zoomText As TextBox
  Private WithEvents btnZoomFitHeightWidth As Button
  Private WithEvents btnZoomFitWidth As Button
  Private WithEvents btnZoomFitHeight As Button

  Private panEnabled As Boolean = True
  Private SmoothingFactor As Double = 0.1
  Private panningActive As Boolean = False
  Private smoothedMousePosition As Point
  Private zoomActive As Boolean = False
  'Private panningEnabled As Boolean = True
  <Description("Enable/Disable Toolbar")>
  Public Property ToolbarEnabled As Boolean
    Get
      Return imgToolbar.Visible
    End Get
    Set(value As Boolean)
      imgToolbar.Visible = value
    End Set
  End Property

  <Description("Enable/Disable Panning")>
  Public Property PanningEnabled As Boolean
    Get
      Return panEnabled
    End Get
    Set(value As Boolean)
      panEnabled = value
    End Set
  End Property

  <Description("Enable/Disable Panning")>
  Public Property MouseSmoothingFactor As Double
    Get
      Return SmoothingFactor
    End Get
    Set(value As Double)
      SmoothingFactor = value
    End Set
  End Property


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

  Private Sub btnTestImg1_Click(sender As Object, e As EventArgs) Handles btnTestImg1.Click
    imgBox.Visible = False
    zoomActive = False
    imgBox.LoadAsync("D:\Geneology\Research\images\61775_01_00433-03417.jpg")
  End Sub

  Private Sub btnTestImg2_Click(sender As Object, e As EventArgs) Handles btnTestImg2.Click
    imgBox.Visible = False
    zoomActive = False
    imgBox.LoadAsync("D:\Geneology\Research\images\Deed of land from Samuel Piles to Ludo V (1).jpg")
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

  Public Sub New()
    InitControls()
  End Sub

  Private Sub InitControls()
    Me.imgContainer = New System.Windows.Forms.Panel()
    Me.imgBox = New System.Windows.Forms.PictureBox()
    Me.imgToolbar = New System.Windows.Forms.Panel()
    Me.btnTestImg1 = New System.Windows.Forms.Button()
    Me.btnTestImg2 = New System.Windows.Forms.Button()
    Me.zoomSlider = New System.Windows.Forms.TrackBar()
    Me.zoomText = New System.Windows.Forms.TextBox()
    Me.btnZoomFitHeight = New System.Windows.Forms.Button()
    Me.btnZoomFitWidth = New System.Windows.Forms.Button()
    Me.btnZoomFitHeightWidth = New System.Windows.Forms.Button()
    Me.imgContainer.SuspendLayout()
    CType(Me.imgBox, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.imgToolbar.SuspendLayout()
    CType(Me.zoomSlider, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()

    Me.Controls.Add(Me.imgContainer)
    Me.Controls.Add(Me.imgToolbar)
    Me.Padding = New System.Windows.Forms.Padding(3)
    '
    'imgContainer
    '
    Me.imgContainer.BackColor = System.Drawing.SystemColors.ControlDarkDark
    Me.imgContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.imgContainer.Controls.Add(Me.imgBox)
    Me.imgContainer.Dock = System.Windows.Forms.DockStyle.Fill
    Me.imgContainer.Location = New System.Drawing.Point(3, 30)
    Me.imgContainer.Margin = New System.Windows.Forms.Padding(0)
    Me.imgContainer.Name = "imgContainer"
    Me.imgContainer.Size = New System.Drawing.Size(576, 412)
    Me.imgContainer.TabIndex = 0
    '
    'imgBox
    '
    Me.imgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.imgBox.Cursor = System.Windows.Forms.Cursors.Hand
    Me.imgBox.ErrorImage = Nothing
    Me.imgBox.ImageLocation = ""
    Me.imgBox.Location = New System.Drawing.Point(15, 15)
    Me.imgBox.Margin = New System.Windows.Forms.Padding(0)
    Me.imgBox.Name = "imgBox"
    Me.imgBox.Size = New System.Drawing.Size(1702, 2800)
    Me.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.imgBox.TabIndex = 0
    Me.imgBox.TabStop = False
    '
    'imgToolbar
    '
    Me.imgToolbar.Controls.Add(Me.btnZoomFitHeightWidth)
    Me.imgToolbar.Controls.Add(Me.btnZoomFitWidth)
    Me.imgToolbar.Controls.Add(Me.btnZoomFitHeight)
    Me.imgToolbar.Controls.Add(Me.btnTestImg1)
    Me.imgToolbar.Controls.Add(Me.btnTestImg2)
    Me.imgToolbar.Controls.Add(Me.zoomSlider)
    Me.imgToolbar.Controls.Add(Me.zoomText)
    Me.imgToolbar.Dock = System.Windows.Forms.DockStyle.Top
    Me.imgToolbar.Location = New System.Drawing.Point(3, 3)
    Me.imgToolbar.Name = "imgToolbar"
    Me.imgToolbar.Size = New System.Drawing.Size(576, 27)
    Me.imgToolbar.TabIndex = 1
    Me.imgToolbar.Visible = True
    '
    'btnTestImg1
    '
    Me.btnTestImg2.Dock = System.Windows.Forms.DockStyle.Left
    Me.btnTestImg1.Location = New System.Drawing.Point(95, 4)
    Me.btnTestImg1.Name = "btnTestImg1"
    'Me.btnTestImg1.Size = New System.Drawing.Size(25, 26)
    Me.btnTestImg1.AutoSize = True
    Me.btnTestImg1.TabIndex = 2
    Me.btnTestImg1.Text = "Test Img 1"
    Me.btnTestImg1.UseVisualStyleBackColor = True
    '
    'btnTestImg2
    '
    Me.btnTestImg2.Dock = System.Windows.Forms.DockStyle.Left
    Me.btnTestImg2.Location = New System.Drawing.Point(64, 3)
    Me.btnTestImg2.Name = "btnTestImg2"
    Me.btnTestImg2.Size = New System.Drawing.Size(25, 26)
    Me.btnTestImg2.TabIndex = 1
    Me.btnTestImg2.Text = "Test Img 2"
    Me.btnTestImg2.UseVisualStyleBackColor = True
    '
    'zoomSlider
    '
    Me.zoomSlider.Dock = System.Windows.Forms.DockStyle.Right
    Me.zoomSlider.LargeChange = 10
    Me.zoomSlider.Location = New System.Drawing.Point(427, 0)
    Me.zoomSlider.Maximum = 150
    Me.zoomSlider.Minimum = 10
    Me.zoomSlider.Name = "zoomSlider"
    Me.zoomSlider.Size = New System.Drawing.Size(119, 27)
    Me.zoomSlider.TabIndex = 0
    Me.zoomSlider.TickFrequency = 10
    Me.zoomSlider.Value = 100
    '
    'zoomText
    '
    Me.zoomText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.zoomText.Dock = System.Windows.Forms.DockStyle.Right
    Me.zoomText.Location = New System.Drawing.Point(546, 0)
    Me.zoomText.MaxLength = 3
    Me.zoomText.Name = "zoomText"
    Me.zoomText.Size = New System.Drawing.Size(30, 20)
    Me.zoomText.TabIndex = 3
    Me.zoomText.Text = "100"
    Me.zoomText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'btnZoomFitHeight
    '
    Me.btnZoomFitHeight.Dock = System.Windows.Forms.DockStyle.Right
    Me.btnZoomFitHeight.Location = New System.Drawing.Point(401, 0)
    Me.btnZoomFitHeight.Name = "btnZoomFitHeight"
    Me.btnZoomFitHeight.Size = New System.Drawing.Size(26, 27)
    Me.btnZoomFitHeight.TabIndex = 4
    Me.btnZoomFitHeight.Text = "H"
    Me.btnZoomFitHeight.UseVisualStyleBackColor = True
    '
    'btnZoomFitWidth
    '
    Me.btnZoomFitWidth.Dock = System.Windows.Forms.DockStyle.Right
    Me.btnZoomFitWidth.Location = New System.Drawing.Point(376, 0)
    Me.btnZoomFitWidth.Name = "btnZoomFitWidth"
    Me.btnZoomFitWidth.Size = New System.Drawing.Size(25, 27)
    Me.btnZoomFitWidth.TabIndex = 5
    Me.btnZoomFitWidth.Text = "W"
    Me.btnZoomFitWidth.UseVisualStyleBackColor = True
    '
    'btnZoomFitHeightWidth
    '
    Me.btnZoomFitHeightWidth.Dock = System.Windows.Forms.DockStyle.Right
    Me.btnZoomFitHeightWidth.Location = New System.Drawing.Point(335, 0)
    Me.btnZoomFitHeightWidth.Name = "btnZoomFitHeightWidth"
    Me.btnZoomFitHeightWidth.Size = New System.Drawing.Size(41, 27)
    Me.btnZoomFitHeightWidth.TabIndex = 6
    Me.btnZoomFitHeightWidth.Text = "H+W"
    Me.btnZoomFitHeightWidth.UseVisualStyleBackColor = True
    '
    'Form1
    '
    Me.BackColor = System.Drawing.SystemColors.AppWorkspace
    Me.ClientSize = Global.AncestryAssistant.My.MySettings.Default.MainForm_ClientSize
    Me.Padding = New System.Windows.Forms.Padding(1)
    Me.Text = "Ancestry Assistant"
    Me.imgContainer.ResumeLayout(False)
    Me.imgContainer.PerformLayout()
    CType(Me.imgBox, System.ComponentModel.ISupportInitialize).EndInit()
    Me.imgToolbar.ResumeLayout(False)
    Me.imgToolbar.PerformLayout()
    CType(Me.zoomSlider, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

    imgBox.Visible = False
    zoomActive = False
    zoomSlider.Value = 100
    imgBox.Location = New Point(15, 15)
  End Sub

  <Browsable(False),
        EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BorderStyle As BorderStyle = BorderStyle.None

  Protected Overrides Sub OnResize(eventargs As EventArgs)
    Me.Refresh()
    MyBase.OnResize(eventargs)
  End Sub



End Class
