<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTestSearch
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Ribbon1 = New AncestryAssistant.Ribbon()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.RibbonBar1 = New AncestryAssistant.RibbonBar()
        Me.RibbonGroup1 = New AncestryAssistant.RibbonGroup()
        Me.RibbonItem1 = New AncestryAssistant.RibbonItem()
        Me.RibbonItem2 = New AncestryAssistant.RibbonItem()
        Me.Panel1.SuspendLayout()
        Me.Ribbon1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.RibbonBar1.SuspendLayout()
        Me.RibbonGroup1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.Ribbon1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(532, 138)
        Me.Panel1.TabIndex = 5
        '
        'Ribbon1
        '
        Me.Ribbon1.AppBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.Ribbon1.AppForeColor = System.Drawing.Color.WhiteSmoke
        Me.Ribbon1.AppHighlightColor = System.Drawing.Color.Lime
        Me.Ribbon1.Controls.Add(Me.TabPage1)
        Me.Ribbon1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Ribbon1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.Ribbon1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ribbon1.Location = New System.Drawing.Point(0, 0)
        Me.Ribbon1.Margin = New System.Windows.Forms.Padding(0)
        Me.Ribbon1.MaximumSize = New System.Drawing.Size(0, 137)
        Me.Ribbon1.MinimumSize = New System.Drawing.Size(100, 137)
        Me.Ribbon1.Name = "Ribbon1"
        Me.Ribbon1.RibbonAccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Ribbon1.RibbonBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.Ribbon1.RibbonForeColor = System.Drawing.Color.WhiteSmoke
        Me.Ribbon1.RibbonShadowColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Ribbon1.SelectedIndex = 0
        Me.Ribbon1.Size = New System.Drawing.Size(532, 137)
        Me.Ribbon1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Black
        Me.TabPage1.Controls.Add(Me.RibbonBar1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(524, 108)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'RibbonBar1
        '
        Me.RibbonBar1.AllowDrop = True
        Me.RibbonBar1.AppBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.RibbonBar1.AppForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonBar1.AppHighlightColor = System.Drawing.Color.Lime
        Me.RibbonBar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.RibbonBar1.BarId = 1
        Me.RibbonBar1.Controls.Add(Me.RibbonGroup1)
        Me.RibbonBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RibbonBar1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonBar1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonBar1.Location = New System.Drawing.Point(3, 3)
        Me.RibbonBar1.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonBar1.MaximumSize = New System.Drawing.Size(0, 100)
        Me.RibbonBar1.MinimumSize = New System.Drawing.Size(100, 100)
        Me.RibbonBar1.Name = "RibbonBar1"
        Me.RibbonBar1.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.RibbonBar1.RibbonAccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RibbonBar1.RibbonBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.RibbonBar1.RibbonForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonBar1.RibbonShadowColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.RibbonBar1.Size = New System.Drawing.Size(518, 100)
        Me.RibbonBar1.TabIndex = 0
        '
        'RibbonGroup1
        '
        Me.RibbonGroup1.AppBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.RibbonGroup1.AppForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonGroup1.AppHighlightColor = System.Drawing.Color.Lime
        Me.RibbonGroup1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.RibbonGroup1.BarId = 1
        Me.RibbonGroup1.ColCount = 4
        Me.RibbonGroup1.Controls.Add(Me.RibbonItem2)
        Me.RibbonGroup1.Controls.Add(Me.RibbonItem1)
        Me.RibbonGroup1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonGroup1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonGroup1.GroupId = 1
        Me.RibbonGroup1.Location = New System.Drawing.Point(8, 4)
        Me.RibbonGroup1.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonGroup1.MinimumSize = New System.Drawing.Size(121, 0)
        Me.RibbonGroup1.Name = "RibbonGroup1"
        Me.RibbonGroup1.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
        Me.RibbonGroup1.RibbonAccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RibbonGroup1.RibbonBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.RibbonGroup1.RibbonForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonGroup1.RibbonShadowColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.RibbonGroup1.RowCount = 1
        Me.RibbonGroup1.ShowPane = True
        Me.RibbonGroup1.Size = New System.Drawing.Size(121, 92)
        Me.RibbonGroup1.TabIndex = 0
        Me.RibbonGroup1.Text = "RibbonGroup1"
        '
        'RibbonItem1
        '
        Me.RibbonItem1.AppBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.RibbonItem1.AppForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonItem1.AppHighlightColor = System.Drawing.Color.Lime
        Me.RibbonItem1.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.RibbonItem1.BackColor = System.Drawing.Color.Blue
        Me.RibbonItem1.BarId = 1
        Me.RibbonItem1.Col = 1
        Me.RibbonItem1.ColSpan = 1
        Me.RibbonItem1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.RibbonItem1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonItem1.GroupId = 1
        Me.RibbonItem1.ItemId = 1
        Me.RibbonItem1.Location = New System.Drawing.Point(8, 8)
        Me.RibbonItem1.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonItem1.MinimumSize = New System.Drawing.Size(24, 24)
        Me.RibbonItem1.Name = "RibbonItem1"
        Me.RibbonItem1.RibbonAccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RibbonItem1.RibbonBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.RibbonItem1.RibbonForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonItem1.RibbonShadowColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.RibbonItem1.Row = 1
        Me.RibbonItem1.RowSpan = 1
        Me.RibbonItem1.Size = New System.Drawing.Size(24, 24)
        Me.RibbonItem1.TabIndex = 0
        Me.RibbonItem1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RibbonItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'RibbonItem2
        '
        Me.RibbonItem2.AppBackColor = System.Drawing.Color.Red
        Me.RibbonItem2.AppForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonItem2.AppHighlightColor = System.Drawing.Color.Lime
        Me.RibbonItem2.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.RibbonItem2.BackColor = System.Drawing.Color.Red
        Me.RibbonItem2.BarId = 1
        Me.RibbonItem2.Col = 2
        Me.RibbonItem2.ColSpan = 1
        Me.RibbonItem2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        Me.RibbonItem2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonItem2.GroupId = 1
        Me.RibbonItem2.ItemId = 2
        Me.RibbonItem2.Location = New System.Drawing.Point(32, 32)
        Me.RibbonItem2.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonItem2.MinimumSize = New System.Drawing.Size(24, 24)
        Me.RibbonItem2.Name = "RibbonItem2"
        Me.RibbonItem2.RibbonAccentColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RibbonItem2.RibbonBackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.RibbonItem2.RibbonForeColor = System.Drawing.Color.WhiteSmoke
        Me.RibbonItem2.RibbonShadowColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.RibbonItem2.Row = 2
        Me.RibbonItem2.RowSpan = 1
        Me.RibbonItem2.Size = New System.Drawing.Size(24, 24)
        Me.RibbonItem2.TabIndex = 1
        Me.RibbonItem2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RibbonItem2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'frmTestSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmTestSearch"
        Me.Text = "frmTestSearch"
        Me.Panel1.ResumeLayout(False)
        Me.Ribbon1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.RibbonBar1.ResumeLayout(False)
        Me.RibbonGroup1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Ribbon1 As Ribbon
  Friend WithEvents TabPage1 As TabPage
  Friend WithEvents RibbonBar1 As RibbonBar
    Friend WithEvents RibbonGroup1 As RibbonGroup
    Friend WithEvents RibbonItem2 As RibbonItem
    Friend WithEvents RibbonItem1 As RibbonItem
End Class
