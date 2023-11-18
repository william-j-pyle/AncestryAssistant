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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTestSearch))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FlatPanel1 = New AncestryAssistant.FlatPanel()
        Me.FlatSearchBox1 = New AncestryAssistant.FlatSearchBox()
        Me.FlatPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(282, 228)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.Location = New System.Drawing.Point(568, 97)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 63)
        Me.Button2.TabIndex = 2
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FlatPanel1
        '
        Me.FlatPanel1.BorderColor = System.Drawing.Color.IndianRed
        Me.FlatPanel1.BorderColorBottom = System.Drawing.Color.IndianRed
        Me.FlatPanel1.BorderColorLeft = System.Drawing.Color.IndianRed
        Me.FlatPanel1.BorderColorRight = System.Drawing.Color.IndianRed
        Me.FlatPanel1.BorderColorTop = System.Drawing.Color.IndianRed
        Me.FlatPanel1.BorderWidth = New System.Windows.Forms.Padding(1)
        Me.FlatPanel1.Controls.Add(Me.FlatSearchBox1)
        Me.FlatPanel1.CornerRadius = New System.Windows.Forms.Padding(0)
        Me.FlatPanel1.Location = New System.Drawing.Point(44, 36)
        Me.FlatPanel1.Name = "FlatPanel1"
        Me.FlatPanel1.Size = New System.Drawing.Size(200, 264)
        Me.FlatPanel1.TabIndex = 4
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
        Me.FlatSearchBox1.Location = New System.Drawing.Point(0, 0)
        Me.FlatSearchBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlatSearchBox1.MaximumSize = New System.Drawing.Size(0, 20)
        Me.FlatSearchBox1.MinimumSize = New System.Drawing.Size(50, 20)
        Me.FlatSearchBox1.Name = "FlatSearchBox1"
        Me.FlatSearchBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.FlatSearchBox1.SearchPromptText = "Search"
        Me.FlatSearchBox1.ShowDropdown = False
        Me.FlatSearchBox1.Size = New System.Drawing.Size(200, 20)
        Me.FlatSearchBox1.State = AncestryAssistant.FlatSearchBox.SearchState.NoFocusNoSearch
        Me.FlatSearchBox1.TabIndex = 0
        '
        'frmTestSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.FlatPanel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmTestSearch"
        Me.Text = "frmTestSearch"
        Me.FlatPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents FlatPanel1 As FlatPanel
    Friend WithEvents FlatSearchBox1 As FlatSearchBox
End Class
