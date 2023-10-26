Imports System.ComponentModel
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web.WebView2.WinForms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AncestryWebViewer
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.web = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.tsWeb = New System.Windows.Forms.ToolStrip()
        Me.btnBack = New System.Windows.Forms.ToolStripButton()
        Me.btnReload = New System.Windows.Forms.ToolStripButton()
        Me.btnHome = New System.Windows.Forms.ToolStripButton()
        Me.txtHref = New System.Windows.Forms.ToolStripTextBox()
        CType(Me.web, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsWeb.SuspendLayout()
        Me.SuspendLayout()
        '
        'web
        '
        Me.web.AllowExternalDrop = True
        Me.web.BackColor = System.Drawing.Color.White
        Me.web.CreationProperties = Nothing
        Me.web.DefaultBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.web.Dock = System.Windows.Forms.DockStyle.Fill
        Me.web.Location = New System.Drawing.Point(0, 25)
        Me.web.Margin = New System.Windows.Forms.Padding(0)
        Me.web.Name = "web"
        Me.web.Size = New System.Drawing.Size(600, 202)
        Me.web.TabIndex = 0
        Me.web.ZoomFactor = 0.75R
        '
        'tsWeb
        '
        Me.tsWeb.CanOverflow = False
        Me.tsWeb.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.AncestryAssistant.My.MySettings.Default, "TB_WEB_LOC", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tsWeb.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsWeb.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnBack, Me.btnReload, Me.btnHome, Me.txtHref})
        Me.tsWeb.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.tsWeb.Location = Global.AncestryAssistant.My.MySettings.Default.TB_WEB_LOC
        Me.tsWeb.Name = "tsWeb"
        Me.tsWeb.Padding = New System.Windows.Forms.Padding(4, 0, 16, 0)
        Me.tsWeb.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tsWeb.Size = New System.Drawing.Size(600, 25)
        Me.tsWeb.Stretch = True
        Me.tsWeb.TabIndex = 2
        '
        'btnBack
        '
        Me.btnBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBack.Image = Global.AncestryAssistant.My.Resources.Resources.LEFT_ICO20
        Me.btnBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(23, 22)
        Me.btnBack.Text = "ToolStripButton2"
        Me.btnBack.ToolTipText = "Previous Page"
        '
        'btnReload
        '
        Me.btnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnReload.Image = Global.AncestryAssistant.My.Resources.Resources.REFRESH_ICO20
        Me.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(23, 22)
        Me.btnReload.Text = "ToolStripButton1"
        Me.btnReload.ToolTipText = "Refresh"
        '
        'btnHome
        '
        Me.btnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnHome.Image = Global.AncestryAssistant.My.Resources.Resources.HOME_ICO20
        Me.btnHome.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(23, 22)
        Me.btnHome.Text = "ToolStripButton1"
        Me.btnHome.ToolTipText = "Ancestry Home Page"
        '
        'txtHref
        '
        Me.txtHref.AutoSize = False
        Me.txtHref.BackColor = System.Drawing.SystemColors.Window
        Me.txtHref.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHref.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtHref.Name = "txtHref"
        Me.txtHref.Size = New System.Drawing.Size(100, 23)
        Me.txtHref.ToolTipText = "Website URL"
        '
        'AncestryWebViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.web)
        Me.Controls.Add(Me.tsWeb)
        Me.Name = "AncestryWebViewer"
        Me.Size = New System.Drawing.Size(600, 227)
        CType(Me.web, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsWeb.ResumeLayout(False)
        Me.tsWeb.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    ' Web Interface
    Private WithEvents web As WebView2
    ' Tool Strip
    Private WithEvents tsWeb As ToolStrip
    Private WithEvents btnHome As ToolStripButton
    Private WithEvents txtHref As ToolStripTextBox
    Private WithEvents btnBack As ToolStripButton
    Private WithEvents btnReload As ToolStripButton
End Class
