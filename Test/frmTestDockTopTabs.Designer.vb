<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTestDockTopTabs
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DockBottomTabs1 = New AncestryAssistant.DockBottomTabs()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.DockTopTabs1 = New AncestryAssistant.DockTopTabs()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.DockBottomTabs1.SuspendLayout()
        Me.DockTopTabs1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DockTopTabs1)
        Me.Panel1.Location = New System.Drawing.Point(30, 25)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(407, 198)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DockBottomTabs1)
        Me.Panel2.Location = New System.Drawing.Point(421, 244)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(293, 100)
        Me.Panel2.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(30, 262)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DockBottomTabs1
        '
        Me.DockBottomTabs1.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.DockBottomTabs1.BorderColor = System.Drawing.Color.DimGray
        Me.DockBottomTabs1.BorderColorBottom = System.Drawing.Color.DimGray
        Me.DockBottomTabs1.BorderColorLeft = System.Drawing.Color.DimGray
        Me.DockBottomTabs1.BorderColorRight = System.Drawing.Color.DimGray
        Me.DockBottomTabs1.BorderColorTop = System.Drawing.Color.DimGray
        Me.DockBottomTabs1.BorderWidth = New System.Windows.Forms.Padding(1)
        Me.DockBottomTabs1.Controls.Add(Me.TabPage3)
        Me.DockBottomTabs1.Controls.Add(Me.TabPage4)
        Me.DockBottomTabs1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockBottomTabs1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
        Me.DockBottomTabs1.HighlightColor = System.Drawing.Color.Lime
        Me.DockBottomTabs1.Location = New System.Drawing.Point(0, 0)
        Me.DockBottomTabs1.Margin = New System.Windows.Forms.Padding(0)
        Me.DockBottomTabs1.Name = "DockBottomTabs1"
        Me.DockBottomTabs1.Padding = New System.Drawing.Point(2, 2)
        Me.DockBottomTabs1.PanelBackColor = System.Drawing.Color.Black
        Me.DockBottomTabs1.SelectedIndex = 0
        Me.DockBottomTabs1.ShowToolTips = True
        Me.DockBottomTabs1.Size = New System.Drawing.Size(293, 100)
        Me.DockBottomTabs1.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Black
        Me.TabPage3.Location = New System.Drawing.Point(4, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(285, 73)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "TabPage3"
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Black
        Me.TabPage4.Location = New System.Drawing.Point(4, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(285, 73)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "TabPage4"
    '
    'DockTopTabs1
    '
    Me.DockTopTabs1.Controls.Add(Me.TabPage1)
    Me.DockTopTabs1.Controls.Add(Me.TabPage2)
        Me.DockTopTabs1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockTopTabs1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed
    Me.DockTopTabs1.HotTrack = True
    Me.DockTopTabs1.Location = New System.Drawing.Point(0, 0)
        Me.DockTopTabs1.Margin = New System.Windows.Forms.Padding(0)
        Me.DockTopTabs1.Name = "DockTopTabs1"
        Me.DockTopTabs1.Padding = New System.Drawing.Point(20, 2)
        Me.DockTopTabs1.PanelBackColor = System.Drawing.Color.Black
        Me.DockTopTabs1.SelectedIndex = 0
        Me.DockTopTabs1.ShowToolTips = True
        Me.DockTopTabs1.Size = New System.Drawing.Size(407, 198)
        Me.DockTopTabs1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(399, 171)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(399, 171)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'frmTestDockTopTabs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Name = "frmTestDockTopTabs"
        Me.Text = "frmTestDockTopTabs"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.DockBottomTabs1.ResumeLayout(False)
        Me.DockTopTabs1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DockBottomTabs1 As DockBottomTabs
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents DockTopTabs1 As DockTopTabs
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
End Class
