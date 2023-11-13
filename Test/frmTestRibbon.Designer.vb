<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTestRibbon
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
        Me.Ribbon1 = New AncestryAssistant.Ribbon()
        Me.mnuFile = New System.Windows.Forms.TabPage()
        Me.tabHome = New System.Windows.Forms.TabPage()
        Me.RibbonBar1 = New AncestryAssistant.RibbonBar()
        Me.Ribbon1.SuspendLayout()
        Me.tabHome.SuspendLayout()
        Me.SuspendLayout()
        '
        'Ribbon1
        '
        Me.Ribbon1.AllowDrop = True
        Me.Ribbon1.Controls.Add(Me.mnuFile)
        Me.Ribbon1.Controls.Add(Me.tabHome)
        Me.Ribbon1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Ribbon1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ribbon1.Location = New System.Drawing.Point(4, 4)
        Me.Ribbon1.Margin = New System.Windows.Forms.Padding(0)
        Me.Ribbon1.MaximumSize = New System.Drawing.Size(0, 137)
        Me.Ribbon1.MinimumSize = New System.Drawing.Size(100, 137)
        Me.Ribbon1.Multiline = True
        Me.Ribbon1.Name = "Ribbon1"
        Me.Ribbon1.SelectedIndex = 0
        Me.Ribbon1.Size = New System.Drawing.Size(792, 137)
        Me.Ribbon1.TabIndex = 8
        '
        'mnuFile
        '
        Me.mnuFile.Location = New System.Drawing.Point(4, 25)
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Padding = New System.Windows.Forms.Padding(3)
        Me.mnuFile.Size = New System.Drawing.Size(784, 108)
        Me.mnuFile.TabIndex = 0
        Me.mnuFile.Text = "File"
        Me.mnuFile.UseVisualStyleBackColor = True
        '
        'tabHome
        '
        Me.tabHome.BackColor = System.Drawing.Color.Black
        Me.tabHome.Controls.Add(Me.RibbonBar1)
        Me.tabHome.Location = New System.Drawing.Point(4, 25)
        Me.tabHome.Name = "tabHome"
        Me.tabHome.Size = New System.Drawing.Size(784, 108)
        Me.tabHome.TabIndex = 1
        Me.tabHome.Text = "Home"
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AllowDrop = True
        Me.RibbonBar1.BackColor = System.Drawing.Color.Transparent
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonBar1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonBar1.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonBar1.MaximumSize = New System.Drawing.Size(0, 100)
        Me.RibbonBar1.MinimumSize = New System.Drawing.Size(100, 100)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
        Me.RibbonBar1.Size = New System.Drawing.Size(784, 100)
        Me.RibbonBar1.TabIndex = 0
        '
        'frmTestRibbon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Ribbon1)
        Me.ForeColor = System.Drawing.Color.IndianRed
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTestRibbon"
        Me.Padding = New System.Windows.Forms.Padding(4)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ribbon Test Form"
        Me.TopMost = True
        Me.Ribbon1.ResumeLayout(False)
        Me.tabHome.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents JButton1 As RibbonButton
    Friend WithEvents JButton2 As RibbonButton
    Friend WithEvents JButton3 As RibbonButton
    Friend WithEvents JRibbon1 As Ribbon
    Friend WithEvents Ribbon1 As Ribbon
    Friend WithEvents mnuFile As TabPage
    Friend WithEvents tabHome As TabPage
    Friend WithEvents RibbonBar1 As RibbonBar
End Class
