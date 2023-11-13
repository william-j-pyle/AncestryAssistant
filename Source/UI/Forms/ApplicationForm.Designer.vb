<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ApplicationForm
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
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApplicationForm))
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.FormBar = New System.Windows.Forms.Panel()
        Me.AppTitleBar = New System.Windows.Forms.Panel()
        Me.AppTitle = New System.Windows.Forms.Label()
        Me.AppControlBox = New System.Windows.Forms.Panel()
        Me.AppMinButton = New System.Windows.Forms.Button()
        Me.AppMaxButton = New System.Windows.Forms.Button()
        Me.AppCloseButton = New System.Windows.Forms.Button()
        Me.AppIcon = New System.Windows.Forms.Panel()
        Me.StatusBar = New System.Windows.Forms.Panel()
        Me.RibbonBar = New AncestryAssistant.Ribbon()
        Me.tabFile = New System.Windows.Forms.TabPage()
        Me.tabHome = New System.Windows.Forms.TabPage()
        Me.RibbonBar1 = New AncestryAssistant.RibbonBar()
        Me.DockManager = New AncestryAssistant.DockPanelManager()
        Me.FormBar.SuspendLayout()
        Me.AppTitleBar.SuspendLayout()
        Me.AppControlBox.SuspendLayout()
        Me.RibbonBar.SuspendLayout()
        Me.tabHome.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(107, 148)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "TabPage1"
        '
        'FormBar
        '
        Me.FormBar.BackColor = System.Drawing.Color.Black
        Me.FormBar.Controls.Add(Me.DockManager)
        Me.FormBar.Controls.Add(Me.RibbonBar)
        Me.FormBar.Controls.Add(Me.AppTitleBar)
        Me.FormBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormBar.Location = New System.Drawing.Point(0, 0)
        Me.FormBar.Margin = New System.Windows.Forms.Padding(0)
        Me.FormBar.Name = "FormBar"
        Me.FormBar.Padding = New System.Windows.Forms.Padding(3)
        Me.FormBar.Size = New System.Drawing.Size(771, 411)
        Me.FormBar.TabIndex = 13
        '
        'AppTitleBar
        '
        Me.AppTitleBar.BackColor = System.Drawing.Color.Black
        Me.AppTitleBar.Controls.Add(Me.AppTitle)
        Me.AppTitleBar.Controls.Add(Me.AppControlBox)
        Me.AppTitleBar.Controls.Add(Me.AppIcon)
        Me.AppTitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.AppTitleBar.Location = New System.Drawing.Point(3, 3)
        Me.AppTitleBar.Margin = New System.Windows.Forms.Padding(0)
        Me.AppTitleBar.MaximumSize = New System.Drawing.Size(0, 28)
        Me.AppTitleBar.MinimumSize = New System.Drawing.Size(0, 28)
        Me.AppTitleBar.Name = "AppTitleBar"
        Me.AppTitleBar.Size = New System.Drawing.Size(765, 28)
        Me.AppTitleBar.TabIndex = 0
        '
        'AppTitle
        '
        Me.AppTitle.AutoEllipsis = True
        Me.AppTitle.BackColor = System.Drawing.Color.Black
        Me.AppTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AppTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppTitle.ForeColor = System.Drawing.Color.White
        Me.AppTitle.Location = New System.Drawing.Point(27, 0)
        Me.AppTitle.Name = "AppTitle"
        Me.AppTitle.Padding = New System.Windows.Forms.Padding(9, 3, 0, 0)
        Me.AppTitle.Size = New System.Drawing.Size(652, 28)
        Me.AppTitle.TabIndex = 2
        Me.AppTitle.Text = "ControlBarAppCaption"
        '
        'AppControlBox
        '
        Me.AppControlBox.Controls.Add(Me.AppMinButton)
        Me.AppControlBox.Controls.Add(Me.AppMaxButton)
        Me.AppControlBox.Controls.Add(Me.AppCloseButton)
        Me.AppControlBox.Dock = System.Windows.Forms.DockStyle.Right
        Me.AppControlBox.Location = New System.Drawing.Point(679, 0)
        Me.AppControlBox.Margin = New System.Windows.Forms.Padding(0)
        Me.AppControlBox.MaximumSize = New System.Drawing.Size(86, 22)
        Me.AppControlBox.MinimumSize = New System.Drawing.Size(86, 22)
        Me.AppControlBox.Name = "AppControlBox"
        Me.AppControlBox.Size = New System.Drawing.Size(86, 22)
        Me.AppControlBox.TabIndex = 1
        '
        'AppMinButton
        '
        Me.AppMinButton.Dock = System.Windows.Forms.DockStyle.Left
        Me.AppMinButton.FlatAppearance.BorderSize = 0
        Me.AppMinButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AppMinButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.AppMinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AppMinButton.Font = New System.Drawing.Font("Segoe Fluent Icons", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppMinButton.ForeColor = System.Drawing.Color.White
        Me.AppMinButton.Location = New System.Drawing.Point(0, 0)
        Me.AppMinButton.Margin = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.AppMinButton.MaximumSize = New System.Drawing.Size(21, 22)
        Me.AppMinButton.MinimumSize = New System.Drawing.Size(21, 22)
        Me.AppMinButton.Name = "AppMinButton"
        Me.AppMinButton.Size = New System.Drawing.Size(21, 22)
        Me.AppMinButton.TabIndex = 2
        Me.AppMinButton.Text = ""
        Me.AppMinButton.UseVisualStyleBackColor = True
        '
        'AppMaxButton
        '
        Me.AppMaxButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AppMaxButton.FlatAppearance.BorderSize = 0
        Me.AppMaxButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AppMaxButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.AppMaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AppMaxButton.Font = New System.Drawing.Font("Segoe Fluent Icons", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppMaxButton.ForeColor = System.Drawing.Color.White
        Me.AppMaxButton.Location = New System.Drawing.Point(33, 0)
        Me.AppMaxButton.Margin = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.AppMaxButton.MaximumSize = New System.Drawing.Size(21, 22)
        Me.AppMaxButton.MinimumSize = New System.Drawing.Size(21, 22)
        Me.AppMaxButton.Name = "AppMaxButton"
        Me.AppMaxButton.Size = New System.Drawing.Size(21, 22)
        Me.AppMaxButton.TabIndex = 1
        Me.AppMaxButton.Text = ""
        Me.AppMaxButton.UseVisualStyleBackColor = True
        '
        'AppCloseButton
        '
        Me.AppCloseButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.AppCloseButton.FlatAppearance.BorderSize = 0
        Me.AppCloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.AppCloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
        Me.AppCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AppCloseButton.Font = New System.Drawing.Font("Segoe Fluent Icons", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppCloseButton.ForeColor = System.Drawing.Color.White
        Me.AppCloseButton.Location = New System.Drawing.Point(65, 0)
        Me.AppCloseButton.Margin = New System.Windows.Forms.Padding(0)
        Me.AppCloseButton.MaximumSize = New System.Drawing.Size(21, 22)
        Me.AppCloseButton.MinimumSize = New System.Drawing.Size(21, 22)
        Me.AppCloseButton.Name = "AppCloseButton"
        Me.AppCloseButton.Size = New System.Drawing.Size(21, 22)
        Me.AppCloseButton.TabIndex = 0
        Me.AppCloseButton.Text = ""
        Me.AppCloseButton.UseVisualStyleBackColor = True
        '
        'AppIcon
        '
        Me.AppIcon.BackgroundImage = CType(resources.GetObject("AppIcon.BackgroundImage"), System.Drawing.Image)
        Me.AppIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.AppIcon.Dock = System.Windows.Forms.DockStyle.Left
        Me.AppIcon.Location = New System.Drawing.Point(0, 0)
        Me.AppIcon.Margin = New System.Windows.Forms.Padding(0)
        Me.AppIcon.MaximumSize = New System.Drawing.Size(27, 28)
        Me.AppIcon.MinimumSize = New System.Drawing.Size(27, 28)
        Me.AppIcon.Name = "AppIcon"
        Me.AppIcon.Size = New System.Drawing.Size(27, 28)
        Me.AppIcon.TabIndex = 0
        '
        'StatusBar
        '
        Me.StatusBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusBar.Location = New System.Drawing.Point(0, 411)
        Me.StatusBar.MaximumSize = New System.Drawing.Size(0, 24)
        Me.StatusBar.MinimumSize = New System.Drawing.Size(0, 24)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(771, 24)
        Me.StatusBar.TabIndex = 13
        '
        'RibbonBar
        '
        Me.RibbonBar.AllowDrop = True
        Me.RibbonBar.Controls.Add(Me.tabFile)
        Me.RibbonBar.Controls.Add(Me.tabHome)
        Me.RibbonBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonBar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar.Location = New System.Drawing.Point(3, 31)
        Me.RibbonBar.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonBar.MaximumSize = New System.Drawing.Size(0, 137)
        Me.RibbonBar.MinimumSize = New System.Drawing.Size(100, 137)
        Me.RibbonBar.Name = "RibbonBar"
        Me.RibbonBar.Padding = New System.Drawing.Point(0, 0)
        Me.RibbonBar.SelectedIndex = 0
        Me.RibbonBar.Size = New System.Drawing.Size(765, 137)
        Me.RibbonBar.TabIndex = 1
        '
        'tabFile
        '
        Me.tabFile.BackColor = System.Drawing.Color.Black
        Me.tabFile.Location = New System.Drawing.Point(4, 25)
        Me.tabFile.Name = "tabFile"
        Me.tabFile.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFile.Size = New System.Drawing.Size(757, 108)
        Me.tabFile.TabIndex = 0
        Me.tabFile.Text = "File"
        '
        'tabHome
        '
        Me.tabHome.BackColor = System.Drawing.Color.Black
        Me.tabHome.Controls.Add(Me.RibbonBar1)
        Me.tabHome.Location = New System.Drawing.Point(4, 25)
        Me.tabHome.Name = "tabHome"
        Me.tabHome.Padding = New System.Windows.Forms.Padding(3)
        Me.tabHome.Size = New System.Drawing.Size(757, 108)
        Me.tabHome.TabIndex = 1
        Me.tabHome.Text = "Home"
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AllowDrop = True
        Me.RibbonBar1.BackColor = System.Drawing.Color.DimGray
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonBar1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonBar1.Location = New System.Drawing.Point(3, 3)
        Me.RibbonBar1.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonBar1.MaximumSize = New System.Drawing.Size(0, 100)
        Me.RibbonBar1.MinimumSize = New System.Drawing.Size(100, 100)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
        Me.RibbonBar1.Size = New System.Drawing.Size(751, 100)
        Me.RibbonBar1.TabIndex = 0
        '
        'DockManager
        '
        Me.DockManager.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockManager.Location = New System.Drawing.Point(3, 168)
        Me.DockManager.Name = "DockManager"
        Me.DockManager.Size = New System.Drawing.Size(765, 240)
        Me.DockManager.TabIndex = 12
        '
        'ApplicationForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(771, 435)
        Me.Controls.Add(Me.FormBar)
        Me.Controls.Add(Me.StatusBar)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ApplicationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ancestry Assistant"
        Me.FormBar.ResumeLayout(False)
        Me.AppTitleBar.ResumeLayout(False)
        Me.AppControlBox.ResumeLayout(False)
        Me.RibbonBar.ResumeLayout(False)
        Me.tabHome.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents DockManager As DockPanelManager
    Friend WithEvents FormBar As Panel
    Friend WithEvents AppTitleBar As Panel
    Friend WithEvents AppTitle As Label
    Friend WithEvents AppControlBox As Panel
    Friend WithEvents AppIcon As Panel
    Friend WithEvents AppCloseButton As Button
    Friend WithEvents AppMinButton As Button
    Friend WithEvents AppMaxButton As Button
    Friend WithEvents StatusBar As Panel
    Friend WithEvents RibbonBar As Ribbon
    Friend WithEvents tabFile As TabPage
    Friend WithEvents tabHome As TabPage
    Friend WithEvents RibbonBar1 As RibbonBar
End Class
