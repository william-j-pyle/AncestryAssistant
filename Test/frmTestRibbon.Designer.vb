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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.bar = New AncestryAssistant.Ribbon()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.IndianRed
        Me.Button1.Location = New System.Drawing.Point(116, 259)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'bar
        '
        Me.bar.AllowDrop = True
        Me.bar.AppBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.bar.AppForeColor = System.Drawing.Color.WhiteSmoke
        Me.bar.AppHighlightColor = System.Drawing.Color.Lime
        Me.bar.Dock = System.Windows.Forms.DockStyle.Top
        Me.bar.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.bar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bar.Location = New System.Drawing.Point(0, 0)
        Me.bar.Margin = New System.Windows.Forms.Padding(0)
        Me.bar.MaximumSize = New System.Drawing.Size(0, 137)
        Me.bar.MinimumSize = New System.Drawing.Size(100, 137)
        Me.bar.Name = "bar"
        Me.bar.RibbonAccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.bar.RibbonBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.bar.RibbonForeColor = System.Drawing.Color.WhiteSmoke
        Me.bar.RibbonShadowColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.bar.SelectedIndex = 0
        Me.bar.Size = New System.Drawing.Size(985, 137)
        Me.bar.TabIndex = 0
        '
        'frmTestRibbon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(985, 533)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bar)
        Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTestRibbon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTestRibbon"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bar As Ribbon
    Friend WithEvents Button1 As Button
End Class
