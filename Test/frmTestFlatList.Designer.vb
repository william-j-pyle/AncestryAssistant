<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTestFlatList
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.FlatPanel1 = New AncestryAssistant.FlatPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    Me.FlatPanel1.SuspendLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'NotifyIcon1
    '
    Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'FlatPanel1
        '
        Me.FlatPanel1.BorderColor = System.Drawing.Color.Transparent
        Me.FlatPanel1.BorderColorBottom = System.Drawing.Color.DarkGray
        Me.FlatPanel1.BorderColorLeft = System.Drawing.Color.DarkGray
        Me.FlatPanel1.BorderColorRight = System.Drawing.Color.DarkGray
        Me.FlatPanel1.BorderColorTop = System.Drawing.Color.DarkGray
        Me.FlatPanel1.BorderWidth = New System.Windows.Forms.Padding(1)
        Me.FlatPanel1.Controls.Add(Me.PictureBox1)
        Me.FlatPanel1.CornerRadius = New System.Windows.Forms.Padding(5)
        Me.FlatPanel1.Location = New System.Drawing.Point(370, 200)
        Me.FlatPanel1.Name = "FlatPanel1"
        Me.FlatPanel1.Size = New System.Drawing.Size(273, 19)
        Me.FlatPanel1.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AncestryAssistant.My.Resources.Resources.panel_header_menu
        Me.PictureBox1.Location = New System.Drawing.Point(254, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 18)
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False

    '
    'frmTestFlatList
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1016, 534)
        Me.Controls.Add(Me.FlatPanel1)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "frmTestFlatList"
        Me.Text = "frmTestFlatList"
        Me.FlatPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents FlatPanel1 As FlatPanel
    Friend WithEvents PictureBox1 As PictureBox

End Class
