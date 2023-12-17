<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AssistantAppForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AssistantAppForm))
        Me.FormBar = New System.Windows.Forms.Panel()
        Me.DockManager = New AncestryAssistant.DockPanelManager()
        Me.RibbonBar = New AncestryAssistant.Ribbon()
        Me.AppTitleBar = New System.Windows.Forms.Panel()
        Me.AppTitle = New System.Windows.Forms.Label()
        Me.AppControlBox = New System.Windows.Forms.Panel()
        Me.AppMinButton = New System.Windows.Forms.Button()
        Me.AppMaxButton = New System.Windows.Forms.Button()
        Me.AppCloseButton = New System.Windows.Forms.Button()
        Me.AppIcon = New System.Windows.Forms.Panel()
        Me.TabFile = New System.Windows.Forms.TabPage()
        Me.TabHome = New System.Windows.Forms.TabPage()
        Me.BtnAlert = New System.Windows.Forms.Button()
        Me.FormBar.SuspendLayout()
        Me.AppTitleBar.SuspendLayout()
        Me.AppControlBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormBar
        '
        Me.FormBar.Controls.Add(Me.DockManager)
        Me.FormBar.Controls.Add(Me.RibbonBar)
        Me.FormBar.Controls.Add(Me.AppTitleBar)
        Me.FormBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormBar.Location = New System.Drawing.Point(0, 0)
        Me.FormBar.Margin = New System.Windows.Forms.Padding(0)
        Me.FormBar.Name = "FormBar"
        Me.FormBar.Padding = New System.Windows.Forms.Padding(3)
        Me.FormBar.Size = New System.Drawing.Size(774, 444)
        Me.FormBar.TabIndex = 13
        '
        'DockManager
        '
        Me.DockManager.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockManager.Location = New System.Drawing.Point(3, 168)
        Me.DockManager.Name = "DockManager"
        Me.DockManager.Size = New System.Drawing.Size(768, 273)
        Me.DockManager.TabIndex = 12
        '
        'RibbonBar
        '
        Me.RibbonBar.AllowDrop = True
        Me.RibbonBar.AppBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.RibbonBar.AppForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonBar.AppHighlightColor = System.Drawing.Color.Lime
        Me.RibbonBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonBar.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.RibbonBar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar.Location = New System.Drawing.Point(3, 31)
        Me.RibbonBar.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonBar.MaximumSize = New System.Drawing.Size(0, 137)
        Me.RibbonBar.MinimumSize = New System.Drawing.Size(100, 137)
        Me.RibbonBar.Name = "RibbonBar"
        Me.RibbonBar.Padding = New System.Drawing.Point(0, 0)
        Me.RibbonBar.RibbonAccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RibbonBar.RibbonBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.RibbonBar.RibbonForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonBar.RibbonShadowColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.RibbonBar.SelectedIndex = 0
        Me.RibbonBar.Size = New System.Drawing.Size(768, 137)
        Me.RibbonBar.TabIndex = 1
        '
        'AppTitleBar
        '
        Me.AppTitleBar.Controls.Add(Me.AppTitle)
        Me.AppTitleBar.Controls.Add(Me.AppControlBox)
        Me.AppTitleBar.Controls.Add(Me.AppIcon)
        Me.AppTitleBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.AppTitleBar.Location = New System.Drawing.Point(3, 3)
        Me.AppTitleBar.Margin = New System.Windows.Forms.Padding(0)
        Me.AppTitleBar.MaximumSize = New System.Drawing.Size(0, 28)
        Me.AppTitleBar.MinimumSize = New System.Drawing.Size(0, 28)
        Me.AppTitleBar.Name = "AppTitleBar"
        Me.AppTitleBar.Size = New System.Drawing.Size(768, 28)
        Me.AppTitleBar.TabIndex = 0
        '
        'AppTitle
        '
        Me.AppTitle.AutoEllipsis = True
        Me.AppTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AppTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppTitle.Location = New System.Drawing.Point(27, 0)
        Me.AppTitle.Name = "AppTitle"
        Me.AppTitle.Padding = New System.Windows.Forms.Padding(9, 3, 0, 0)
        Me.AppTitle.Size = New System.Drawing.Size(655, 28)
        Me.AppTitle.TabIndex = 2
        Me.AppTitle.Text = "ControlBarAppCaption"
        '
        'AppControlBox
        '
        Me.AppControlBox.Controls.Add(Me.AppMinButton)
        Me.AppControlBox.Controls.Add(Me.AppMaxButton)
        Me.AppControlBox.Controls.Add(Me.AppCloseButton)
        Me.AppControlBox.Dock = System.Windows.Forms.DockStyle.Right
        Me.AppControlBox.Location = New System.Drawing.Point(682, 0)
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
        Me.AppMinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AppMinButton.Image = Global.AncestryAssistant.My.Resources.Resources.form_min
        Me.AppMinButton.Location = New System.Drawing.Point(0, 0)
        Me.AppMinButton.Margin = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.AppMinButton.MaximumSize = New System.Drawing.Size(21, 22)
        Me.AppMinButton.MinimumSize = New System.Drawing.Size(21, 22)
        Me.AppMinButton.Name = "AppMinButton"
        Me.AppMinButton.Size = New System.Drawing.Size(21, 22)
        Me.AppMinButton.TabIndex = 2
        Me.AppMinButton.UseVisualStyleBackColor = True
        '
        'AppMaxButton
        '
        Me.AppMaxButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AppMaxButton.FlatAppearance.BorderSize = 0
        Me.AppMaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AppMaxButton.Image = Global.AncestryAssistant.My.Resources.Resources.form_max
        Me.AppMaxButton.Location = New System.Drawing.Point(33, 0)
        Me.AppMaxButton.Margin = New System.Windows.Forms.Padding(0, 0, 9, 0)
        Me.AppMaxButton.MaximumSize = New System.Drawing.Size(21, 22)
        Me.AppMaxButton.MinimumSize = New System.Drawing.Size(21, 22)
        Me.AppMaxButton.Name = "AppMaxButton"
        Me.AppMaxButton.Size = New System.Drawing.Size(21, 22)
        Me.AppMaxButton.TabIndex = 1
        Me.AppMaxButton.UseVisualStyleBackColor = True
        '
        'AppCloseButton
        '
        Me.AppCloseButton.Dock = System.Windows.Forms.DockStyle.Right
        Me.AppCloseButton.FlatAppearance.BorderSize = 0
        Me.AppCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AppCloseButton.Image = Global.AncestryAssistant.My.Resources.Resources.form_close
        Me.AppCloseButton.Location = New System.Drawing.Point(65, 0)
        Me.AppCloseButton.Margin = New System.Windows.Forms.Padding(0)
        Me.AppCloseButton.MaximumSize = New System.Drawing.Size(21, 22)
        Me.AppCloseButton.MinimumSize = New System.Drawing.Size(21, 22)
        Me.AppCloseButton.Name = "AppCloseButton"
        Me.AppCloseButton.Size = New System.Drawing.Size(21, 22)
        Me.AppCloseButton.TabIndex = 0
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
        'TabFile
        '
        Me.TabFile.Location = New System.Drawing.Point(0, 0)
        Me.TabFile.Name = "TabFile"
        Me.TabFile.Size = New System.Drawing.Size(200, 100)
        Me.TabFile.TabIndex = 0
        '
        'TabHome
        '
        Me.TabHome.Location = New System.Drawing.Point(0, 0)
        Me.TabHome.Name = "TabHome"
        Me.TabHome.Size = New System.Drawing.Size(200, 100)
        Me.TabHome.TabIndex = 0
        '
        'BtnAlert
        '
        Me.BtnAlert.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAlert.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnAlert.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAlert.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAlert.ForeColor = System.Drawing.Color.White
        Me.BtnAlert.Location = New System.Drawing.Point(640, 30)
        Me.BtnAlert.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnAlert.Name = "BtnAlert"
        Me.BtnAlert.Size = New System.Drawing.Size(109, 22)
        Me.BtnAlert.TabIndex = 0
        Me.BtnAlert.Text = "No Alert"
        Me.BtnAlert.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnAlert.UseMnemonic = False
        Me.BtnAlert.UseVisualStyleBackColor = False
        Me.BtnAlert.Visible = False
        '
        'AssistantAppForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.ClientSize = New System.Drawing.Size(774, 444)
        Me.Controls.Add(Me.BtnAlert)
        Me.Controls.Add(Me.FormBar)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "AssistantAppForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Ancestry Assistant"
        Me.FormBar.ResumeLayout(False)
        Me.AppTitleBar.ResumeLayout(False)
        Me.AppControlBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DockManager As DockPanelManager
    Friend WithEvents FormBar As Panel
    Friend WithEvents AppTitleBar As Panel
    Friend WithEvents AppTitle As Label
    Friend WithEvents AppControlBox As Panel
    Friend WithEvents AppIcon As Panel
    Friend WithEvents AppCloseButton As Button
    Friend WithEvents AppMinButton As Button
    Friend WithEvents AppMaxButton As Button
    Friend WithEvents RibbonBar As Ribbon
    Friend WithEvents TabFile As TabPage
    Friend WithEvents TabHome As TabPage
    Friend WithEvents RibbonBarTabHome As RibbonBar
    Friend WithEvents BtnAlert As Button
End Class
