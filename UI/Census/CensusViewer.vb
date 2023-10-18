Public Class CensusViewer
  Inherits Panel

  Friend WithEvents dataCensus As DataGridView
  Friend WithEvents ToolStrip3 As ToolStrip
  Friend WithEvents ToolStripLabel2 As ToolStripLabel
  Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
  Friend WithEvents CommonToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
  Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
  Friend WithEvents ToolStripLabel1 As ToolStripLabel
  Friend WithEvents ToolStripButton13 As ToolStripButton
  Friend WithEvents ToolStripButton14 As ToolStripButton
  Friend WithEvents ToolStripButton15 As ToolStripButton

  Public Sub New()
    SetStyle(ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer, True)

    dataCensus = New System.Windows.Forms.DataGridView()
    ToolStrip3 = New System.Windows.Forms.ToolStrip()
    ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
    ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
    CommonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
    ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
    ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
    ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
    ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
    ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
    ToolStripButton15 = New System.Windows.Forms.ToolStripButton()

    CType(dataCensus, System.ComponentModel.ISupportInitialize).BeginInit()
    ToolStrip3.SuspendLayout()
    SuspendLayout()

    Dock = DockStyle.Fill
    Controls.Add(dataCensus)
    Controls.Add(ToolStrip3)
    '
    'dataCensus
    '
    dataCensus.AllowUserToAddRows = False
    dataCensus.AllowUserToDeleteRows = False
    dataCensus.AllowUserToOrderColumns = True
    dataCensus.AllowUserToResizeRows = False
    dataCensus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
    dataCensus.BackgroundColor = System.Drawing.Color.White
    dataCensus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    dataCensus.Dock = System.Windows.Forms.DockStyle.Fill
    dataCensus.Location = New System.Drawing.Point(0, 25)
    dataCensus.Name = "dataCensus"
    dataCensus.ReadOnly = True
    dataCensus.Size = New System.Drawing.Size(348, 288)
    dataCensus.TabIndex = 5
    '
    'ToolStrip3
    '
    ToolStrip3.CanOverflow = False
    ToolStrip3.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
    ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
    ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {ToolStripLabel2, ToolStripDropDownButton1, ToolStripSeparator5, ToolStripLabel1, ToolStripButton13, ToolStripButton14, ToolStripButton15})
    ToolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
    ToolStrip3.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
    ToolStrip3.Name = "ToolStrip3"
    ToolStrip3.Padding = New System.Windows.Forms.Padding(4, 0, 16, 0)
    ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
    ToolStrip3.Size = New System.Drawing.Size(348, 25)
    ToolStrip3.Stretch = True
    ToolStrip3.TabIndex = 4
    '
    'ToolStripLabel2
    '
    ToolStripLabel2.Name = "ToolStripLabel2"
    ToolStripLabel2.Size = New System.Drawing.Size(45, 22)
    ToolStripLabel2.Text = "Census"
    '
    'ToolStripDropDownButton1
    '
    ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {CommonToolStripMenuItem, ToolStripMenuItem3, ToolStripMenuItem4})
    'ToolStripDropDownButton1.Image = CType(Resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
    ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
    ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
    ToolStripDropDownButton1.Size = New System.Drawing.Size(71, 22)
    ToolStripDropDownButton1.Text = "Common"
    '
    'CommonToolStripMenuItem
    '
    CommonToolStripMenuItem.Name = "CommonToolStripMenuItem"
    CommonToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
    CommonToolStripMenuItem.Text = "Common"
    '
    'ToolStripMenuItem3
    '
    ToolStripMenuItem3.Name = "ToolStripMenuItem3"
    ToolStripMenuItem3.Size = New System.Drawing.Size(125, 22)
    ToolStripMenuItem3.Text = "1940"
    '
    'ToolStripMenuItem4
    '
    ToolStripMenuItem4.Name = "ToolStripMenuItem4"
    ToolStripMenuItem4.Size = New System.Drawing.Size(125, 22)
    ToolStripMenuItem4.Text = "1950"
    '
    'ToolStripSeparator5
    '
    ToolStripSeparator5.Name = "ToolStripSeparator5"
    ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
    '
    'ToolStripLabel1
    '
    ToolStripLabel1.Name = "ToolStripLabel1"
    ToolStripLabel1.Size = New System.Drawing.Size(38, 22)
    ToolStripLabel1.Text = "Filters"
    '
    'ToolStripButton13
    '
    ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    'ToolStripButton13.Image = CType(Resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
    ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
    ToolStripButton13.Name = "ToolStripButton13"
    ToolStripButton13.Size = New System.Drawing.Size(23, 22)
    ToolStripButton13.Text = "ToolStripButton13"
    '
    'ToolStripButton14
    '
    ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    'ToolStripButton14.Image = CType(Resources.GetObject("ToolStripButton14.Image"), System.Drawing.Image)
    ToolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta
    ToolStripButton14.Name = "ToolStripButton14"
    ToolStripButton14.Size = New System.Drawing.Size(23, 22)
    ToolStripButton14.Text = "ToolStripButton14"
    '
    'ToolStripButton15
    '
    ToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
    'ToolStripButton15.Image = CType(Resources.GetObject("ToolStripButton15.Image"), System.Drawing.Image)
    ToolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta
    ToolStripButton15.Name = "ToolStripButton15"
    ToolStripButton15.Size = New System.Drawing.Size(23, 22)
    ToolStripButton15.Text = "ToolStripButton15"

    CType(dataCensus, System.ComponentModel.ISupportInitialize).EndInit()
    ToolStrip3.ResumeLayout(False)
    ToolStrip3.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
  End Sub

End Class
