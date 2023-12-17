<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTestFlat
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTestFlat))
        Me.FlatPanel1 = New AncestryAssistant.FlatPanel()
        Me.FlatSearchBox1 = New AncestryAssistant.FlatSearchBox()
        Me.FlatToolBar1 = New AncestryAssistant.FlatToolBar()
        Me.FlatStatusBar1 = New AncestryAssistant.FlatStatusBar()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FlatPanel1.SuspendLayout()
        Me.FlatToolBar1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlatPanel1
        '
        Me.FlatPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.FlatPanel1.BorderColor = System.Drawing.Color.Transparent
        Me.FlatPanel1.BorderColorBottom = System.Drawing.Color.Transparent
        Me.FlatPanel1.BorderColorLeft = System.Drawing.Color.Transparent
        Me.FlatPanel1.BorderColorRight = System.Drawing.Color.Transparent
        Me.FlatPanel1.BorderColorTop = System.Drawing.Color.Transparent
        Me.FlatPanel1.BorderWidth = New System.Windows.Forms.Padding(0)
        Me.FlatPanel1.Controls.Add(Me.FlatSearchBox1)
        Me.FlatPanel1.Controls.Add(Me.FlatToolBar1)
        Me.FlatPanel1.Controls.Add(Me.FlatStatusBar1)
        Me.FlatPanel1.CornerRadius = New System.Windows.Forms.Padding(0)
        Me.FlatPanel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.FlatPanel1.Location = New System.Drawing.Point(412, 0)
        Me.FlatPanel1.Name = "FlatPanel1"
        Me.FlatPanel1.Size = New System.Drawing.Size(388, 450)
        Me.FlatPanel1.TabIndex = 0
        '
        'FlatSearchBox1
        '
        Me.FlatSearchBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.FlatSearchBox1.BackColorActive = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.FlatSearchBox1.BlockLostFocus = False
        Me.FlatSearchBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlatSearchBox1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FlatSearchBox1.ForeColorActive = System.Drawing.Color.WhiteSmoke
        Me.FlatSearchBox1.ImageCancelSearch = CType(resources.GetObject("FlatSearchBox1.ImageCancelSearch"), System.Drawing.Image)
        Me.FlatSearchBox1.ImageDropDown = CType(resources.GetObject("FlatSearchBox1.ImageDropDown"), System.Drawing.Image)
        Me.FlatSearchBox1.ImageSearch = CType(resources.GetObject("FlatSearchBox1.ImageSearch"), System.Drawing.Image)
        Me.FlatSearchBox1.Location = New System.Drawing.Point(0, 31)
        Me.FlatSearchBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlatSearchBox1.MaximumSize = New System.Drawing.Size(0, 20)
        Me.FlatSearchBox1.MinimumSize = New System.Drawing.Size(50, 20)
        Me.FlatSearchBox1.Name = "FlatSearchBox1"
        Me.FlatSearchBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.FlatSearchBox1.SearchPromptText = "Search"
        Me.FlatSearchBox1.ShowDropdown = False
        Me.FlatSearchBox1.Size = New System.Drawing.Size(388, 20)
        Me.FlatSearchBox1.State = AncestryAssistant.FlatSearchBox.SearchState.NoFocusNoSearch
        Me.FlatSearchBox1.TabIndex = 2
        '
        'FlatToolBar1
        '
        Me.FlatToolBar1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FlatToolBar1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.FlatToolBar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSplitButton1})
        Me.FlatToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.FlatToolBar1.Name = "FlatToolBar1"
        Me.FlatToolBar1.Padding = New System.Windows.Forms.Padding(0)
        Me.FlatToolBar1.Size = New System.Drawing.Size(388, 31)
        Me.FlatToolBar1.TabIndex = 1
        Me.FlatToolBar1.Text = "FlatToolBar1"
        '
        'FlatStatusBar1
        '
        Me.FlatStatusBar1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FlatStatusBar1.Location = New System.Drawing.Point(0, 428)
        Me.FlatStatusBar1.Name = "FlatStatusBar1"
        Me.FlatStatusBar1.Size = New System.Drawing.Size(388, 22)
        Me.FlatStatusBar1.TabIndex = 0
        Me.FlatStatusBar1.Text = "FlatStatusBar1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.AncestryAssistant.My.Resources.Resources.back
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(28, 31)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.AncestryAssistant.My.Resources.Resources.filepage_home
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(28, 28)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.ToolStripSplitButton1.Image = Global.AncestryAssistant.My.Resources.Resources.ancestry_view_tree
        Me.ToolStripSplitButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(40, 28)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripMenuItem1.Image = Global.AncestryAssistant.My.Resources.Resources.ancestry_view_fan
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ToolStripMenuItem1.Text = "ToolStripMenuItem1"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripMenuItem2.Image = Global.AncestryAssistant.My.Resources.Resources.ancestry_view_pedigree
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(181, 22)
        Me.ToolStripMenuItem2.Text = "ToolStripMenuItem2"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ToolStripMenuItem3.Image = Global.AncestryAssistant.My.Resources.Resources.ancestry_view_tree
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(181, 22)
        Me.ToolStripMenuItem3.Text = "ToolStripMenuItem3"
        '
        'FormTestFlat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.FlatPanel1)
        Me.Name = "FormTestFlat"
        Me.Text = "FormTestFlat"
        Me.FlatPanel1.ResumeLayout(False)
        Me.FlatPanel1.PerformLayout()
        Me.FlatToolBar1.ResumeLayout(False)
        Me.FlatToolBar1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FlatPanel1 As FlatPanel
    Friend WithEvents FlatSearchBox1 As FlatSearchBox
    Friend WithEvents FlatToolBar1 As FlatToolBar
    Friend WithEvents FlatStatusBar1 As FlatStatusBar
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
End Class
