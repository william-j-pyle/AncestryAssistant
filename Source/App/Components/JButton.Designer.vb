<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JButton
  Inherits System.Windows.Forms.UserControl

  'UserControl overrides dispose to clean up the component list.
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
        Me.btn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn
        '
        Me.btn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btn.FlatAppearance.BorderSize = 0
        Me.btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn.Location = New System.Drawing.Point(0, 0)
        Me.btn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(132, 146)
        Me.btn.TabIndex = 0
        Me.btn.UseMnemonic = False
        Me.btn.UseVisualStyleBackColor = False
        '
        'JButton
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.Controls.Add(Me.btn)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "JButton"
        Me.Size = New System.Drawing.Size(132, 146)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn As Button
End Class
