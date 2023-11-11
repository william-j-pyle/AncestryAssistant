<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTestDockPanel
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
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

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAddR = New System.Windows.Forms.Button()
        Me.btnAddL = New System.Windows.Forms.Button()
        Me.chkFocus1 = New System.Windows.Forms.CheckBox()
        Me.chkFocus2 = New System.Windows.Forms.CheckBox()
        Me.cmbType1 = New System.Windows.Forms.ComboBox()
        Me.cmbType2 = New System.Windows.Forms.ComboBox()
        Me.chkClose1 = New System.Windows.Forms.CheckBox()
        Me.chkMenu1 = New System.Windows.Forms.CheckBox()
        Me.chkSearch1 = New System.Windows.Forms.CheckBox()
        Me.chkPinned1 = New System.Windows.Forms.CheckBox()
        Me.chkMenu2 = New System.Windows.Forms.CheckBox()
        Me.chkClose2 = New System.Windows.Forms.CheckBox()
        Me.chkSearch2 = New System.Windows.Forms.CheckBox()
        Me.chkPinned2 = New System.Windows.Forms.CheckBox()
        Me.mnu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CloseTagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MoveOverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRemoveR = New System.Windows.Forms.Button()
        Me.btnRemoveL = New System.Windows.Forms.Button()
        Me.btnMoveFromLToR = New System.Windows.Forms.Button()
        Me.btnMoveFromRToL = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPanelList = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DockPanel2 = New AncestryAssistant.DockPanel()
        Me.DockPanel1 = New AncestryAssistant.DockPanel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.mnu.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.DockPanel1)
        Me.Panel1.Location = New System.Drawing.Point(13, 16)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(419, 426)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Controls.Add(Me.DockPanel2)
        Me.Panel2.Location = New System.Drawing.Point(453, 16)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(419, 426)
        Me.Panel2.TabIndex = 1
        '
        'btnAddR
        '
        Me.btnAddR.AutoSize = True
        Me.btnAddR.BackColor = System.Drawing.Color.Silver
        Me.btnAddR.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddR.ForeColor = System.Drawing.Color.Black
        Me.btnAddR.Location = New System.Drawing.Point(193, 85)
        Me.btnAddR.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddR.Name = "btnAddR"
        Me.btnAddR.Size = New System.Drawing.Size(50, 42)
        Me.btnAddR.TabIndex = 2
        Me.btnAddR.Text = "+"
        Me.btnAddR.UseVisualStyleBackColor = False
        '
        'btnAddL
        '
        Me.btnAddL.AutoSize = True
        Me.btnAddL.BackColor = System.Drawing.Color.Silver
        Me.btnAddL.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddL.ForeColor = System.Drawing.Color.Black
        Me.btnAddL.Location = New System.Drawing.Point(9, 85)
        Me.btnAddL.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddL.Name = "btnAddL"
        Me.btnAddL.Size = New System.Drawing.Size(50, 42)
        Me.btnAddL.TabIndex = 3
        Me.btnAddL.Text = "+"
        Me.btnAddL.UseVisualStyleBackColor = False
        '
        'chkFocus1
        '
        Me.chkFocus1.AutoSize = True
        Me.chkFocus1.ForeColor = System.Drawing.Color.White
        Me.chkFocus1.Location = New System.Drawing.Point(12, 55)
        Me.chkFocus1.Name = "chkFocus1"
        Me.chkFocus1.Size = New System.Drawing.Size(62, 21)
        Me.chkFocus1.TabIndex = 5
        Me.chkFocus1.Text = "Focus"
        Me.chkFocus1.UseVisualStyleBackColor = True
        '
        'chkFocus2
        '
        Me.chkFocus2.AutoSize = True
        Me.chkFocus2.ForeColor = System.Drawing.Color.White
        Me.chkFocus2.Location = New System.Drawing.Point(196, 55)
        Me.chkFocus2.Name = "chkFocus2"
        Me.chkFocus2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkFocus2.Size = New System.Drawing.Size(62, 21)
        Me.chkFocus2.TabIndex = 6
        Me.chkFocus2.Text = "Focus"
        Me.chkFocus2.UseVisualStyleBackColor = True
        '
        'cmbType1
        '
        Me.cmbType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType1.FormattingEnabled = True
        Me.cmbType1.Items.AddRange(New Object() {"Tab", "Panel"})
        Me.cmbType1.Location = New System.Drawing.Point(69, 24)
        Me.cmbType1.Name = "cmbType1"
        Me.cmbType1.Size = New System.Drawing.Size(191, 25)
        Me.cmbType1.TabIndex = 7
        '
        'cmbType2
        '
        Me.cmbType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType2.FormattingEnabled = True
        Me.cmbType2.Items.AddRange(New Object() {"Tab", "Panel"})
        Me.cmbType2.Location = New System.Drawing.Point(20, 24)
        Me.cmbType2.Name = "cmbType2"
        Me.cmbType2.Size = New System.Drawing.Size(197, 25)
        Me.cmbType2.TabIndex = 8
        '
        'chkClose1
        '
        Me.chkClose1.AutoSize = True
        Me.chkClose1.Checked = True
        Me.chkClose1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClose1.ForeColor = System.Drawing.Color.White
        Me.chkClose1.Location = New System.Drawing.Point(12, 79)
        Me.chkClose1.Name = "chkClose1"
        Me.chkClose1.Size = New System.Drawing.Size(97, 21)
        Me.chkClose1.TabIndex = 9
        Me.chkClose1.Text = "Show Close"
        Me.chkClose1.UseVisualStyleBackColor = True
        '
        'chkMenu1
        '
        Me.chkMenu1.AutoSize = True
        Me.chkMenu1.Checked = True
        Me.chkMenu1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMenu1.ForeColor = System.Drawing.Color.White
        Me.chkMenu1.Location = New System.Drawing.Point(12, 106)
        Me.chkMenu1.Name = "chkMenu1"
        Me.chkMenu1.Size = New System.Drawing.Size(99, 21)
        Me.chkMenu1.TabIndex = 10
        Me.chkMenu1.Text = "Show Menu"
        Me.chkMenu1.UseVisualStyleBackColor = True
        '
        'chkSearch1
        '
        Me.chkSearch1.AutoSize = True
        Me.chkSearch1.Checked = True
        Me.chkSearch1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearch1.ForeColor = System.Drawing.Color.White
        Me.chkSearch1.Location = New System.Drawing.Point(113, 106)
        Me.chkSearch1.Name = "chkSearch1"
        Me.chkSearch1.Size = New System.Drawing.Size(104, 21)
        Me.chkSearch1.TabIndex = 12
        Me.chkSearch1.Text = "Show Search"
        Me.chkSearch1.UseVisualStyleBackColor = True
        '
        'chkPinned1
        '
        Me.chkPinned1.AutoSize = True
        Me.chkPinned1.Checked = True
        Me.chkPinned1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPinned1.ForeColor = System.Drawing.Color.White
        Me.chkPinned1.Location = New System.Drawing.Point(113, 79)
        Me.chkPinned1.Name = "chkPinned1"
        Me.chkPinned1.Size = New System.Drawing.Size(107, 21)
        Me.chkPinned1.TabIndex = 11
        Me.chkPinned1.Text = "Show Pinned"
        Me.chkPinned1.UseVisualStyleBackColor = True
        '
        'chkMenu2
        '
        Me.chkMenu2.AutoSize = True
        Me.chkMenu2.Checked = True
        Me.chkMenu2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMenu2.ForeColor = System.Drawing.Color.White
        Me.chkMenu2.Location = New System.Drawing.Point(159, 106)
        Me.chkMenu2.Name = "chkMenu2"
        Me.chkMenu2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkMenu2.Size = New System.Drawing.Size(99, 21)
        Me.chkMenu2.TabIndex = 14
        Me.chkMenu2.Text = "Show Menu"
        Me.chkMenu2.UseVisualStyleBackColor = True
        '
        'chkClose2
        '
        Me.chkClose2.AutoSize = True
        Me.chkClose2.Checked = True
        Me.chkClose2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClose2.ForeColor = System.Drawing.Color.White
        Me.chkClose2.Location = New System.Drawing.Point(161, 79)
        Me.chkClose2.Name = "chkClose2"
        Me.chkClose2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkClose2.Size = New System.Drawing.Size(97, 21)
        Me.chkClose2.TabIndex = 13
        Me.chkClose2.Text = "Show Close"
        Me.chkClose2.UseVisualStyleBackColor = True
        '
        'chkSearch2
        '
        Me.chkSearch2.AutoSize = True
        Me.chkSearch2.Checked = True
        Me.chkSearch2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSearch2.ForeColor = System.Drawing.Color.White
        Me.chkSearch2.Location = New System.Drawing.Point(42, 106)
        Me.chkSearch2.Name = "chkSearch2"
        Me.chkSearch2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkSearch2.Size = New System.Drawing.Size(104, 21)
        Me.chkSearch2.TabIndex = 16
        Me.chkSearch2.Text = "Show Search"
        Me.chkSearch2.UseVisualStyleBackColor = True
        '
        'chkPinned2
        '
        Me.chkPinned2.AutoSize = True
        Me.chkPinned2.Checked = True
        Me.chkPinned2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPinned2.ForeColor = System.Drawing.Color.White
        Me.chkPinned2.Location = New System.Drawing.Point(39, 79)
        Me.chkPinned2.Name = "chkPinned2"
        Me.chkPinned2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkPinned2.Size = New System.Drawing.Size(107, 21)
        Me.chkPinned2.TabIndex = 15
        Me.chkPinned2.Text = "Show Pinned"
        Me.chkPinned2.UseVisualStyleBackColor = True
        '
        'mnu
        '
        Me.mnu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseTagToolStripMenuItem, Me.ToolStripMenuItem1, Me.MoveOverToolStripMenuItem})
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(133, 54)
        '
        'CloseTagToolStripMenuItem
        '
        Me.CloseTagToolStripMenuItem.Name = "CloseTagToolStripMenuItem"
        Me.CloseTagToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.CloseTagToolStripMenuItem.Text = "Close Tag"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(129, 6)
        '
        'MoveOverToolStripMenuItem
        '
        Me.MoveOverToolStripMenuItem.Name = "MoveOverToolStripMenuItem"
        Me.MoveOverToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.MoveOverToolStripMenuItem.Text = "Move Over"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAddR)
        Me.GroupBox1.Controls.Add(Me.btnAddL)
        Me.GroupBox1.Controls.Add(Me.btnRemoveR)
        Me.GroupBox1.Controls.Add(Me.btnRemoveL)
        Me.GroupBox1.Controls.Add(Me.btnMoveFromLToR)
        Me.GroupBox1.Controls.Add(Me.btnMoveFromRToL)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbPanelList)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(315, 449)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 133)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        '
        'btnRemoveR
        '
        Me.btnRemoveR.AutoSize = True
        Me.btnRemoveR.BackColor = System.Drawing.Color.Silver
        Me.btnRemoveR.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveR.ForeColor = System.Drawing.Color.Black
        Me.btnRemoveR.Location = New System.Drawing.Point(192, 52)
        Me.btnRemoveR.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemoveR.Name = "btnRemoveR"
        Me.btnRemoveR.Size = New System.Drawing.Size(50, 25)
        Me.btnRemoveR.TabIndex = 14
        Me.btnRemoveR.Text = "-"
        Me.btnRemoveR.UseVisualStyleBackColor = False
        '
        'btnRemoveL
        '
        Me.btnRemoveL.AutoSize = True
        Me.btnRemoveL.BackColor = System.Drawing.Color.Silver
        Me.btnRemoveL.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveL.ForeColor = System.Drawing.Color.Black
        Me.btnRemoveL.Location = New System.Drawing.Point(8, 52)
        Me.btnRemoveL.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRemoveL.Name = "btnRemoveL"
        Me.btnRemoveL.Size = New System.Drawing.Size(50, 25)
        Me.btnRemoveL.TabIndex = 15
        Me.btnRemoveL.Text = "-"
        Me.btnRemoveL.UseVisualStyleBackColor = False
        '
        'btnMoveFromLToR
        '
        Me.btnMoveFromLToR.AutoSize = True
        Me.btnMoveFromLToR.BackColor = System.Drawing.Color.Silver
        Me.btnMoveFromLToR.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveFromLToR.ForeColor = System.Drawing.Color.Black
        Me.btnMoveFromLToR.Location = New System.Drawing.Point(192, 20)
        Me.btnMoveFromLToR.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMoveFromLToR.Name = "btnMoveFromLToR"
        Me.btnMoveFromLToR.Size = New System.Drawing.Size(50, 25)
        Me.btnMoveFromLToR.TabIndex = 12
        Me.btnMoveFromLToR.Text = ">"
        Me.btnMoveFromLToR.UseVisualStyleBackColor = False
        '
        'btnMoveFromRToL
        '
        Me.btnMoveFromRToL.AutoSize = True
        Me.btnMoveFromRToL.BackColor = System.Drawing.Color.Silver
        Me.btnMoveFromRToL.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMoveFromRToL.ForeColor = System.Drawing.Color.Black
        Me.btnMoveFromRToL.Location = New System.Drawing.Point(8, 20)
        Me.btnMoveFromRToL.Margin = New System.Windows.Forms.Padding(4)
        Me.btnMoveFromRToL.Name = "btnMoveFromRToL"
        Me.btnMoveFromRToL.Size = New System.Drawing.Size(50, 25)
        Me.btnMoveFromRToL.TabIndex = 13
        Me.btnMoveFromRToL.Text = "<"
        Me.btnMoveFromRToL.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(105, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Move"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(98, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Remove"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(234, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Add New"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPanelList
        '
        Me.cmbPanelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPanelList.FormattingEnabled = True
        Me.cmbPanelList.Items.AddRange(New Object() {"Tab", "Panel"})
        Me.cmbPanelList.Location = New System.Drawing.Point(61, 102)
        Me.cmbPanelList.Name = "cmbPanelList"
        Me.cmbPanelList.Size = New System.Drawing.Size(131, 25)
        Me.cmbPanelList.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cmbType1)
        Me.GroupBox2.Controls.Add(Me.chkFocus1)
        Me.GroupBox2.Controls.Add(Me.chkClose1)
        Me.GroupBox2.Controls.Add(Me.chkMenu1)
        Me.GroupBox2.Controls.Add(Me.chkPinned1)
        Me.GroupBox2.Controls.Add(Me.chkSearch1)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox2.Location = New System.Drawing.Point(13, 449)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 133)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Left Control"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Style"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.cmbType2)
        Me.GroupBox3.Controls.Add(Me.chkFocus2)
        Me.GroupBox3.Controls.Add(Me.chkClose2)
        Me.GroupBox3.Controls.Add(Me.chkMenu2)
        Me.GroupBox3.Controls.Add(Me.chkSearch2)
        Me.GroupBox3.Controls.Add(Me.chkPinned2)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(594, 449)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(278, 133)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Right Control"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(223, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Style"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DockPanel2
        '
        Me.DockPanel2.BackColor = System.Drawing.Color.Black
        Me.DockPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockPanel2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DockPanel2.ForeColor = System.Drawing.Color.WhiteSmoke
    Me.DockPanel2.Location = New System.Drawing.Point(0, 0)
    Me.DockPanel2.Margin = New System.Windows.Forms.Padding(0)
    Me.DockPanel2.Name = "DockPanel2"
    Me.DockPanel2.PanelHasFocus = True
    Me.DockPanel2.PanelIsPinned = True
    Me.DockPanel2.PanelLocation = AncestryAssistant.DockPanelLocation.Floating
    Me.DockPanel2.PanelShowClose = True
    Me.DockPanel2.PanelShowContextMenu = True
    Me.DockPanel2.PanelShowPinned = True
    Me.DockPanel2.PanelShowSearch = True
    Me.DockPanel2.PanelType = AncestryAssistant.DockPanelType.Panel
    Me.DockPanel2.Size = New System.Drawing.Size(399, 422)
    Me.DockPanel2.TabIndex = 0
    Me.DockPanel2.Visible = False
    '
    'DockPanel1
    '
    Me.DockPanel1.BackColor = System.Drawing.Color.Black
    Me.DockPanel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.DockPanel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DockPanel1.ForeColor = System.Drawing.Color.WhiteSmoke
    Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.DockPanel1.Name = "DockPanel1"
    Me.DockPanel1.PanelHasFocus = True
    Me.DockPanel1.PanelIsPinned = True
    Me.DockPanel1.PanelLocation = AncestryAssistant.DockPanelLocation.Floating
    Me.DockPanel1.PanelShowClose = True
    Me.DockPanel1.PanelShowContextMenu = True
        Me.DockPanel1.PanelShowPinned = True
        Me.DockPanel1.PanelShowSearch = True
        Me.DockPanel1.PanelType = AncestryAssistant.DockPanelType.Tab
        Me.DockPanel1.Size = New System.Drawing.Size(399, 422)
        Me.DockPanel1.TabIndex = 0
        Me.DockPanel1.Visible = False
        '
        'frmTestDockPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(885, 588)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmTestDockPanel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Test - DockPanel Control"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.mnu.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
  Friend WithEvents DockPanel1 As DockPanel
  Friend WithEvents Panel2 As Panel
  Friend WithEvents DockPanel2 As DockPanel
  Friend WithEvents btnAddR As Button
  Friend WithEvents btnAddL As Button
  Friend WithEvents chkFocus1 As CheckBox
  Friend WithEvents chkFocus2 As CheckBox
  Friend WithEvents cmbType1 As ComboBox
  Friend WithEvents cmbType2 As ComboBox
  Friend WithEvents chkClose1 As CheckBox
  Friend WithEvents chkMenu1 As CheckBox
  Friend WithEvents chkSearch1 As CheckBox
  Friend WithEvents chkPinned1 As CheckBox
  Friend WithEvents chkMenu2 As CheckBox
  Friend WithEvents chkClose2 As CheckBox
  Friend WithEvents chkSearch2 As CheckBox
  Friend WithEvents chkPinned2 As CheckBox
  Friend WithEvents mnu As ContextMenuStrip
  Friend WithEvents CloseTagToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
  Friend WithEvents MoveOverToolStripMenuItem As ToolStripMenuItem
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents cmbPanelList As ComboBox
  Friend WithEvents GroupBox2 As GroupBox
  Friend WithEvents Label1 As Label
  Friend WithEvents GroupBox3 As GroupBox
  Friend WithEvents Label2 As Label
  Friend WithEvents Label3 As Label
  Friend WithEvents Label5 As Label
  Friend WithEvents Label4 As Label
  Friend WithEvents btnRemoveR As Button
  Friend WithEvents btnRemoveL As Button
  Friend WithEvents btnMoveFromLToR As Button
  Friend WithEvents btnMoveFromRToL As Button
End Class
