<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTestFlatControls
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTestFlatControls))
        Me.tabs = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.FlatTextBox1 = New AncestryAssistant.FlatTextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.FlatSearchBox1 = New AncestryAssistant.FlatSearchBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.FlatLabel1 = New AncestryAssistant.FlatLabel()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.NotebookViewer1 = New AncestryAssistant.NotebookViewer()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.CensusViewer1 = New AncestryAssistant.CensusViewer()
        Me.btnClearEvents = New System.Windows.Forms.Button()
        Me.pnlEvents = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAttach = New System.Windows.Forms.Button()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.listEvents = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.prop = New System.Windows.Forms.PropertyGrid()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tabs.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.pnlEvents.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabs
        '
        Me.tabs.Controls.Add(Me.TabPage1)
        Me.tabs.Controls.Add(Me.TabPage2)
        Me.tabs.Controls.Add(Me.TabPage3)
        Me.tabs.Controls.Add(Me.TabPage4)
        Me.tabs.Controls.Add(Me.TabPage5)
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabs.HotTrack = True
        Me.tabs.Location = New System.Drawing.Point(0, 0)
        Me.tabs.Margin = New System.Windows.Forms.Padding(0)
        Me.tabs.Multiline = True
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedIndex = 0
        Me.tabs.Size = New System.Drawing.Size(606, 506)
        Me.tabs.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.FlatTextBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(598, 478)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "FlatTextBox"
        '
        'FlatTextBox1
        '
        Me.FlatTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.FlatTextBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FlatTextBox1.Location = New System.Drawing.Point(6, 5)
        Me.FlatTextBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlatTextBox1.Name = "FlatTextBox1"
        Me.FlatTextBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.FlatTextBox1.Size = New System.Drawing.Size(396, 39)
        Me.FlatTextBox1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.FlatSearchBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(598, 478)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "FlatSearchBox"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.FlatSearchBox1.Location = New System.Drawing.Point(3, 3)
        Me.FlatSearchBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlatSearchBox1.MaximumSize = New System.Drawing.Size(0, 20)
        Me.FlatSearchBox1.MinimumSize = New System.Drawing.Size(50, 20)
        Me.FlatSearchBox1.Name = "FlatSearchBox1"
        Me.FlatSearchBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.FlatSearchBox1.SearchPromptText = "Search"
        Me.FlatSearchBox1.ShowDropdown = True
        Me.FlatSearchBox1.Size = New System.Drawing.Size(592, 20)
        Me.FlatSearchBox1.State = AncestryAssistant.FlatSearchBox.SearchState.NoFocusNoSearch
        Me.FlatSearchBox1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.FlatLabel1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(598, 478)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'FlatLabel1
        '
        Me.FlatLabel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.FlatLabel1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FlatLabel1.Location = New System.Drawing.Point(41, 29)
        Me.FlatLabel1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlatLabel1.Name = "FlatLabel1"
        Me.FlatLabel1.Padding = New System.Windows.Forms.Padding(0)
        Me.FlatLabel1.Size = New System.Drawing.Size(199, 31)
        Me.FlatLabel1.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.NotebookViewer1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(598, 478)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'NotebookViewer1
        '
        Me.NotebookViewer1.AllowDrop = True
        Me.NotebookViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NotebookViewer1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NotebookViewer1.ItemDockPanelLocation = AncestryAssistant.DockPanelLocation.LeftTop
        Me.NotebookViewer1.ItemHasFocus = False
        Me.NotebookViewer1.Location = New System.Drawing.Point(0, 0)
        Me.NotebookViewer1.Name = "NotebookViewer1"
        Me.NotebookViewer1.Size = New System.Drawing.Size(598, 478)
        Me.NotebookViewer1.TabIndex = 0
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.CensusViewer1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 24)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(598, 478)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "TabPage5"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'CensusViewer1
        '
        Me.CensusViewer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.CensusViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CensusViewer1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CensusViewer1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CensusViewer1.ItemDockPanelLocation = AncestryAssistant.DockPanelLocation.LeftTop
        Me.CensusViewer1.ItemHasFocus = False
        Me.CensusViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CensusViewer1.Name = "CensusViewer1"
        Me.CensusViewer1.Size = New System.Drawing.Size(598, 478)
        Me.CensusViewer1.TabIndex = 0
        '
        'btnClearEvents
        '
        Me.btnClearEvents.BackColor = System.Drawing.Color.Gainsboro
        Me.btnClearEvents.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClearEvents.ForeColor = System.Drawing.Color.Black
        Me.btnClearEvents.Location = New System.Drawing.Point(228, 0)
        Me.btnClearEvents.Margin = New System.Windows.Forms.Padding(0)
        Me.btnClearEvents.Name = "btnClearEvents"
        Me.btnClearEvents.Size = New System.Drawing.Size(180, 27)
        Me.btnClearEvents.TabIndex = 2
        Me.btnClearEvents.Text = "Clear Events"
        Me.btnClearEvents.UseVisualStyleBackColor = False
        '
        'pnlEvents
        '
        Me.pnlEvents.Controls.Add(Me.Panel2)
        Me.pnlEvents.Controls.Add(Me.SplitContainer2)
        Me.pnlEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlEvents.Location = New System.Drawing.Point(0, 0)
        Me.pnlEvents.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlEvents.Name = "pnlEvents"
        Me.pnlEvents.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.pnlEvents.Size = New System.Drawing.Size(412, 506)
        Me.pnlEvents.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Controls.Add(Me.btnClearEvents)
        Me.Panel2.Controls.Add(Me.btnAttach)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(4, 479)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(408, 27)
        Me.Panel2.TabIndex = 5
        '
        'btnAttach
        '
        Me.btnAttach.BackColor = System.Drawing.Color.Gainsboro
        Me.btnAttach.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAttach.Location = New System.Drawing.Point(0, 0)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.Size = New System.Drawing.Size(215, 27)
        Me.btnAttach.TabIndex = 0
        Me.btnAttach.Text = "Attach Control"
        Me.btnAttach.UseVisualStyleBackColor = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(4, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.listEvents)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.prop)
        Me.SplitContainer2.Size = New System.Drawing.Size(408, 506)
        Me.SplitContainer2.SplitterDistance = 253
        Me.SplitContainer2.TabIndex = 4
        '
        'listEvents
        '
        Me.listEvents.AutoArrange = False
        Me.listEvents.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.listEvents.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.listEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listEvents.FullRowSelect = True
        Me.listEvents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.listEvents.HideSelection = False
        Me.listEvents.Location = New System.Drawing.Point(0, 0)
        Me.listEvents.MultiSelect = False
        Me.listEvents.Name = "listEvents"
        Me.listEvents.ShowGroups = False
        Me.listEvents.Size = New System.Drawing.Size(408, 253)
        Me.listEvents.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.listEvents.TabIndex = 3
        Me.listEvents.UseCompatibleStateImageBehavior = False
        Me.listEvents.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Event"
        Me.ColumnHeader2.Width = 144
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "EventData"
        Me.ColumnHeader3.Width = 186
        '
        'prop
        '
        Me.prop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prop.Location = New System.Drawing.Point(0, 0)
        Me.prop.Name = "prop"
        Me.prop.Size = New System.Drawing.Size(408, 249)
        Me.prop.TabIndex = 7
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(4, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tabs)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlEvents)
        Me.SplitContainer1.Size = New System.Drawing.Size(1022, 506)
        Me.SplitContainer1.SplitterDistance = 606
        Me.SplitContainer1.TabIndex = 5
        '
        'frmTestFlatControls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1030, 514)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmTestFlatControls"
        Me.Padding = New System.Windows.Forms.Padding(4)
        Me.Text = "Flat Control Testing"
        Me.tabs.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.pnlEvents.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabs As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnClearEvents As Button
    Friend WithEvents pnlEvents As Panel
    Friend WithEvents FlatTextBox1 As FlatTextBox
    Friend WithEvents btnAttach As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents FlatSearchBox1 As FlatSearchBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents NotebookViewer1 As NotebookViewer
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents CensusViewer1 As CensusViewer
    Friend WithEvents listEvents As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents prop As PropertyGrid
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents FlatLabel1 As FlatLabel
End Class
