<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CensusViewer
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
        Me.tsCensus = New System.Windows.Forms.ToolStrip()
        Me.sht = New System.Windows.Forms.DataGridView()
        CType(Me.sht, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsCensus
        '
        Me.tsCensus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsCensus.Location = New System.Drawing.Point(0, 0)
        Me.tsCensus.Name = "tsCensus"
        Me.tsCensus.Size = New System.Drawing.Size(439, 25)
        Me.tsCensus.TabIndex = 0
        Me.tsCensus.Text = "ToolStrip1"
        '
        'sht
        '
        Me.sht.AllowUserToAddRows = False
        Me.sht.AllowUserToDeleteRows = False
        Me.sht.AllowUserToOrderColumns = True
        Me.sht.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.sht.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.sht.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sht.Location = New System.Drawing.Point(0, 25)
        Me.sht.Name = "sht"
        Me.sht.ShowEditingIcon = False
        Me.sht.Size = New System.Drawing.Size(439, 125)
        Me.sht.TabIndex = 1
        '
        'CensusViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.sht)
        Me.Controls.Add(Me.tsCensus)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "CensusViewer"
        Me.Size = New System.Drawing.Size(439, 150)
        CType(Me.sht, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsCensus As ToolStrip
    Friend WithEvents sht As DataGridView
End Class
