<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestDockPanel
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DockPanel1 = New AncestryAssistant.DockPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DockPanel2 = New AncestryAssistant.DockPanel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DockPanel1)
        Me.Panel1.Location = New System.Drawing.Point(39, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(324, 335)
        Me.Panel1.TabIndex = 0
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
        Me.DockPanel1.PanelAccentColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.DockPanel1.PanelBackColor = System.Drawing.Color.Black
        Me.DockPanel1.PanelBorderColor = System.Drawing.Color.DarkGray
        Me.DockPanel1.PanelFontColor = System.Drawing.Color.WhiteSmoke
        Me.DockPanel1.PanelHasFocus = True
        Me.DockPanel1.PanelHighlightColor = System.Drawing.Color.Lime
        Me.DockPanel1.PanelIsPinned = True
        Me.DockPanel1.PanelLocation = AncestryAssistant.DockPanelLocation.Floating
        Me.DockPanel1.PanelShadowColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.DockPanel1.PanelShowClose = True
        Me.DockPanel1.PanelShowContextMenu = True
        Me.DockPanel1.PanelShowPinned = True
        Me.DockPanel1.PanelShowSearch = True
        Me.DockPanel1.PanelType = AncestryAssistant.DockPanelType.Tab
        Me.DockPanel1.Size = New System.Drawing.Size(324, 335)
        Me.DockPanel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DockPanel2)
        Me.Panel2.Location = New System.Drawing.Point(443, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(341, 334)
        Me.Panel2.TabIndex = 1
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
        Me.DockPanel2.PanelAccentColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.DockPanel2.PanelBackColor = System.Drawing.Color.Black
        Me.DockPanel2.PanelBorderColor = System.Drawing.Color.DarkGray
        Me.DockPanel2.PanelFontColor = System.Drawing.Color.WhiteSmoke
        Me.DockPanel2.PanelHasFocus = True
        Me.DockPanel2.PanelHighlightColor = System.Drawing.Color.Lime
        Me.DockPanel2.PanelIsPinned = True
        Me.DockPanel2.PanelLocation = AncestryAssistant.DockPanelLocation.Floating
        Me.DockPanel2.PanelShadowColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.DockPanel2.PanelShowClose = True
        Me.DockPanel2.PanelShowContextMenu = True
        Me.DockPanel2.PanelShowPinned = True
        Me.DockPanel2.PanelShowSearch = True
        Me.DockPanel2.PanelType = AncestryAssistant.DockPanelType.Panel
        Me.DockPanel2.Size = New System.Drawing.Size(341, 334)
        Me.DockPanel2.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Silver
        Me.btnAdd.Location = New System.Drawing.Point(280, 394)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "+"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.Silver
        Me.btnRemove.Location = New System.Drawing.Point(197, 394)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(75, 23)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "-"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'frmTestDockPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmTestDockPanel"
        Me.Text = "frmTestDockPanel"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents DockPanel1 As DockPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DockPanel2 As DockPanel
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnRemove As Button
End Class
