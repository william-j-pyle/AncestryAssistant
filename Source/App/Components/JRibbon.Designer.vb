<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JRibbon
  Inherits System.Windows.Forms.Panel

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
        Me.SuspendLayout()
        '
        'JRibbon
        '
        Me.AllowDrop = True
    Me.BackColor = System.Drawing.Color.Transparent
    Me.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Margin = New System.Windows.Forms.Padding(0)
        Me.MaximumSize = New System.Drawing.Size(0, 100)
        Me.MinimumSize = New System.Drawing.Size(100, 100)
        Me.Name = "JRibbon"
        Me.Padding = New System.Windows.Forms.Padding(16, 8, 2, 2)
        Me.Size = New System.Drawing.Size(471, 100)
        Me.ResumeLayout(False)

    End Sub
End Class
