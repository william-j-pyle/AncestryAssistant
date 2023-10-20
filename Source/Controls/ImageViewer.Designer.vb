<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageViewer
  Inherits System.Windows.Forms.UserControl

  'UserControl overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImageViewer))
        Me.imgToolbar = New System.Windows.Forms.Panel()
        Me.btnFlipV = New System.Windows.Forms.Button()
        Me.btnFlipH = New System.Windows.Forms.Button()
        Me.btnZoomFitHeightWidth = New System.Windows.Forms.Button()
        Me.btnZoomFitWidth = New System.Windows.Forms.Button()
        Me.btnZoomFitHeight = New System.Windows.Forms.Button()
        Me.zoomSlider = New System.Windows.Forms.TrackBar()
        Me.zoomText = New System.Windows.Forms.TextBox()
        Me.imgContainer = New System.Windows.Forms.Panel()
        Me.imgBox = New System.Windows.Forms.PictureBox()
        Me.btnGallery = New System.Windows.Forms.Button()
        Me.imgToolbar.SuspendLayout()
        CType(Me.zoomSlider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.imgContainer.SuspendLayout()
        CType(Me.imgBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgToolbar
        '
        Me.imgToolbar.Controls.Add(Me.btnFlipV)
        Me.imgToolbar.Controls.Add(Me.btnFlipH)
        Me.imgToolbar.Controls.Add(Me.btnZoomFitHeightWidth)
        Me.imgToolbar.Controls.Add(Me.btnZoomFitWidth)
        Me.imgToolbar.Controls.Add(Me.btnZoomFitHeight)
        Me.imgToolbar.Controls.Add(Me.zoomSlider)
        Me.imgToolbar.Controls.Add(Me.zoomText)
        Me.imgToolbar.Controls.Add(Me.btnGallery)
        Me.imgToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.imgToolbar.Location = New System.Drawing.Point(0, 0)
        Me.imgToolbar.Margin = New System.Windows.Forms.Padding(0)
        Me.imgToolbar.Name = "imgToolbar"
        Me.imgToolbar.Padding = New System.Windows.Forms.Padding(16, 0, 8, 0)
        Me.imgToolbar.Size = New System.Drawing.Size(702, 20)
        Me.imgToolbar.TabIndex = 2
        '
        'btnFlipV
        '
        Me.btnFlipV.AutoSize = True
        Me.btnFlipV.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFlipV.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnFlipV.Image = Global.AncestryAssistant.My.Resources.Resources.FLIP_VERTICAL_ICO20
        Me.btnFlipV.Location = New System.Drawing.Point(130, 0)
        Me.btnFlipV.Name = "btnFlipV"
        Me.btnFlipV.Size = New System.Drawing.Size(22, 20)
        Me.btnFlipV.TabIndex = 9
        Me.btnFlipV.UseVisualStyleBackColor = True
        '
        'btnFlipH
        '
        Me.btnFlipH.AutoSize = True
        Me.btnFlipH.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFlipH.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnFlipH.Image = Global.AncestryAssistant.My.Resources.Resources.FLIP_HORIZONTAL_ICO20
        Me.btnFlipH.Location = New System.Drawing.Point(108, 0)
        Me.btnFlipH.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.btnFlipH.Name = "btnFlipH"
        Me.btnFlipH.Size = New System.Drawing.Size(22, 20)
        Me.btnFlipH.TabIndex = 8
        Me.btnFlipH.UseVisualStyleBackColor = True
        '
        'btnZoomFitHeightWidth
        '
        Me.btnZoomFitHeightWidth.AutoSize = True
        Me.btnZoomFitHeightWidth.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnZoomFitHeightWidth.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnZoomFitHeightWidth.Image = Global.AncestryAssistant.My.Resources.Resources.MAXIMIZE_2_ICO20
        Me.btnZoomFitHeightWidth.Location = New System.Drawing.Point(86, 0)
        Me.btnZoomFitHeightWidth.Name = "btnZoomFitHeightWidth"
        Me.btnZoomFitHeightWidth.Size = New System.Drawing.Size(22, 20)
        Me.btnZoomFitHeightWidth.TabIndex = 6
        Me.btnZoomFitHeightWidth.UseVisualStyleBackColor = True
        '
        'btnZoomFitWidth
        '
        Me.btnZoomFitWidth.AutoSize = True
        Me.btnZoomFitWidth.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnZoomFitWidth.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnZoomFitWidth.Image = CType(resources.GetObject("btnZoomFitWidth.Image"), System.Drawing.Image)
        Me.btnZoomFitWidth.Location = New System.Drawing.Point(60, 0)
        Me.btnZoomFitWidth.Name = "btnZoomFitWidth"
        Me.btnZoomFitWidth.Size = New System.Drawing.Size(26, 20)
        Me.btnZoomFitWidth.TabIndex = 5
        Me.btnZoomFitWidth.UseVisualStyleBackColor = True
        '
        'btnZoomFitHeight
        '
        Me.btnZoomFitHeight.AutoSize = True
        Me.btnZoomFitHeight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnZoomFitHeight.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnZoomFitHeight.Image = Global.AncestryAssistant.My.Resources.Resources.VERTICAL_ICO20
        Me.btnZoomFitHeight.Location = New System.Drawing.Point(38, 0)
        Me.btnZoomFitHeight.Name = "btnZoomFitHeight"
        Me.btnZoomFitHeight.Size = New System.Drawing.Size(22, 20)
        Me.btnZoomFitHeight.TabIndex = 4
        Me.btnZoomFitHeight.UseVisualStyleBackColor = True
        '
        'zoomSlider
        '
        Me.zoomSlider.Dock = System.Windows.Forms.DockStyle.Right
        Me.zoomSlider.LargeChange = 10
        Me.zoomSlider.Location = New System.Drawing.Point(545, 0)
        Me.zoomSlider.Maximum = 150
        Me.zoomSlider.Minimum = 10
        Me.zoomSlider.Name = "zoomSlider"
        Me.zoomSlider.Size = New System.Drawing.Size(119, 20)
        Me.zoomSlider.TabIndex = 0
        Me.zoomSlider.TickFrequency = 10
        Me.zoomSlider.Value = 100
        '
        'zoomText
        '
        Me.zoomText.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.zoomText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.zoomText.Dock = System.Windows.Forms.DockStyle.Right
        Me.zoomText.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.zoomText.Location = New System.Drawing.Point(664, 0)
        Me.zoomText.MaxLength = 3
        Me.zoomText.Name = "zoomText"
        Me.zoomText.ReadOnly = True
        Me.zoomText.Size = New System.Drawing.Size(30, 15)
        Me.zoomText.TabIndex = 3
        Me.zoomText.Text = "100"
        Me.zoomText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'imgContainer
        '
        Me.imgContainer.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.imgContainer.Controls.Add(Me.imgBox)
        Me.imgContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgContainer.Location = New System.Drawing.Point(0, 20)
        Me.imgContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.imgContainer.Name = "imgContainer"
        Me.imgContainer.Size = New System.Drawing.Size(702, 475)
        Me.imgContainer.TabIndex = 3
        '
        'imgBox
        '
        Me.imgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.imgBox.ErrorImage = Nothing
        Me.imgBox.ImageLocation = ""
        Me.imgBox.Location = New System.Drawing.Point(16, 16)
        Me.imgBox.Margin = New System.Windows.Forms.Padding(0)
        Me.imgBox.Name = "imgBox"
        Me.imgBox.Size = New System.Drawing.Size(200, 200)
        Me.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.imgBox.TabIndex = 0
        Me.imgBox.TabStop = False
        '
        'btnGallery
        '
        Me.btnGallery.AutoSize = True
        Me.btnGallery.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGallery.BackColor = System.Drawing.Color.Transparent
        Me.btnGallery.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnGallery.FlatAppearance.BorderSize = 0
        Me.btnGallery.Image = Global.AncestryAssistant.My.Resources.Resources.BIG_LEFT_ICO20
        Me.btnGallery.Location = New System.Drawing.Point(16, 0)
        Me.btnGallery.Name = "btnGallery"
        Me.btnGallery.Size = New System.Drawing.Size(22, 20)
        Me.btnGallery.TabIndex = 10
        Me.btnGallery.UseVisualStyleBackColor = False
        '
        'ImageViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.Controls.Add(Me.imgContainer)
        Me.Controls.Add(Me.imgToolbar)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ImageViewer"
        Me.Size = New System.Drawing.Size(702, 495)
        Me.imgToolbar.ResumeLayout(False)
        Me.imgToolbar.PerformLayout()
        CType(Me.zoomSlider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.imgContainer.ResumeLayout(False)
        Me.imgContainer.PerformLayout()
        CType(Me.imgBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents imgToolbar As Panel
    Friend WithEvents btnFlipV As Button
    Friend WithEvents btnFlipH As Button
    Friend WithEvents btnZoomFitHeightWidth As Button
    Friend WithEvents btnZoomFitWidth As Button
    Friend WithEvents btnZoomFitHeight As Button
    Friend WithEvents zoomSlider As TrackBar
    Friend WithEvents zoomText As TextBox
    Friend WithEvents imgContainer As Panel
    Friend WithEvents imgBox As PictureBox
    Friend WithEvents btnGallery As Button
End Class
