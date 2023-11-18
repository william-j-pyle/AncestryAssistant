<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestCensus
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
        Me.CensusViewer1 = New AncestryAssistant.CensusViewer()
        Me.SuspendLayout()
        '
        'CensusViewer1
        '
        Me.CensusViewer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.CensusViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CensusViewer1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CensusViewer1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.CensusViewer1.ItemDockPanelLocation = AncestryAssistant.DockPanelLocation.LeftTop
        Me.CensusViewer1.ItemHasFocus = False
        Me.CensusViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CensusViewer1.Name = "CensusViewer1"
        Me.CensusViewer1.Size = New System.Drawing.Size(898, 582)
        Me.CensusViewer1.TabIndex = 0
        '
        'frmTestCensus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 582)
        Me.Controls.Add(Me.CensusViewer1)
        Me.Name = "frmTestCensus"
        Me.Text = "frmTestCensus"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CensusViewer1 As CensusViewer
End Class
