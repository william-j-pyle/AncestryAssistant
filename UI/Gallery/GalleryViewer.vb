Public Class GalleryViewer
  Inherits Panel

  Friend WithEvents pnlImageViewer As Panel
  Friend WithEvents tsImageViewer As ToolStrip
  Friend WithEvents ToolStripButton5 As ToolStripButton
  Friend WithEvents pnlGallery As Panel
  Friend WithEvents tsGallery As ToolStrip
  Friend WithEvents lstGallery As ListView

  Public Sub New()
    SetStyle(ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer, True)

    pnlImageViewer = New System.Windows.Forms.Panel()
    tsImageViewer = New System.Windows.Forms.ToolStrip()
    ToolStripButton5 = New System.Windows.Forms.ToolStripButton()

    pnlGallery = New System.Windows.Forms.Panel()
    lstGallery = New System.Windows.Forms.ListView()
    tsGallery = New System.Windows.Forms.ToolStrip()

    pnlImageViewer.SuspendLayout()
    tsImageViewer.SuspendLayout()
    pnlGallery.SuspendLayout()
    SuspendLayout()


    Dock = DockStyle.Fill
    Controls.Add(pnlImageViewer)
    Controls.Add(pnlGallery)

    '
    'pnlImageViewer
    '
    pnlImageViewer.Controls.Add(tsImageViewer)
    pnlImageViewer.Dock = DockStyle.Fill
    '
    'tsImageViewer
    '
    tsImageViewer.CanOverflow = False
    tsImageViewer.Dock = DockStyle.Top
    'tsImageViewer.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    'tsImageViewer.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
    tsImageViewer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    tsImageViewer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {ToolStripButton5})
    tsImageViewer.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
    tsImageViewer.Padding = New System.Windows.Forms.Padding(4, 0, 16, 0)
    tsImageViewer.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
    tsImageViewer.Stretch = True
    '
    'ToolStripButton5
    '
    ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    'ToolStripButton5.Image = Global.AncestryAssistant.My.Resources.Resources.ico_20_black__36
    ToolStripButton5.Size = New System.Drawing.Size(23, 22)
    ToolStripButton5.ToolTipText = "Previous Page"


    '
    'pnlGallery
    '
    pnlGallery.Controls.Add(lstGallery)
    pnlGallery.Controls.Add(tsGallery)
    pnlGallery.Dock = DockStyle.Fill
    pnlGallery.BringToFront()
    '
    'lstGallery
    '
    lstGallery.BackColor = System.Drawing.SystemColors.AppWorkspace
    lstGallery.BorderStyle = System.Windows.Forms.BorderStyle.None
    lstGallery.HideSelection = False
    lstGallery.UseCompatibleStateImageBehavior = False
    lstGallery.Dock = System.Windows.Forms.DockStyle.Fill
    '
    'tsGallery
    '
    tsGallery.CanOverflow = False
    tsGallery.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    tsGallery.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
    tsGallery.Padding = New System.Windows.Forms.Padding(4, 0, 16, 0)
    tsGallery.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
    tsGallery.Stretch = True
    tsGallery.Dock = DockStyle.Top

    pnlImageViewer.ResumeLayout(False)
    pnlImageViewer.PerformLayout()
    tsImageViewer.ResumeLayout(False)
    tsImageViewer.PerformLayout()
    pnlGallery.ResumeLayout(False)
    pnlGallery.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
  End Sub

End Class
