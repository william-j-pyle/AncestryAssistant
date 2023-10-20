<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageGallery
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
        Me.components = New System.ComponentModel.Container()
        Me.imgViewer = New System.Windows.Forms.ListView()
        Me.imgViewerList = New System.Windows.Forms.ImageList(Me.components)
        Me.SuspendLayout()
        '
        'imgViewer
        '
        Me.imgViewer.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.imgViewer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.imgViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgViewer.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.imgViewer.ForeColor = System.Drawing.Color.White
        Me.imgViewer.HideSelection = False
        Me.imgViewer.LargeImageList = Me.imgViewerList
        Me.imgViewer.Location = New System.Drawing.Point(0, 0)
        Me.imgViewer.MultiSelect = False
        Me.imgViewer.Name = "imgViewer"
        Me.imgViewer.Size = New System.Drawing.Size(465, 365)
        Me.imgViewer.TabIndex = 0
        Me.imgViewer.TileSize = New System.Drawing.Size(256, 256)
        Me.imgViewer.UseCompatibleStateImageBehavior = False
        Me.imgViewer.View = System.Windows.Forms.View.Tile
        '
        'imgViewerList
        '
        Me.imgViewerList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imgViewerList.ImageSize = New System.Drawing.Size(256, 256)
        Me.imgViewerList.TransparentColor = System.Drawing.Color.Transparent
        '
        'ImageGallery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.imgViewer)
        Me.Name = "ImageGallery"
        Me.Size = New System.Drawing.Size(465, 365)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents imgViewer As ListView
    Friend WithEvents imgViewerList As ImageList
End Class
