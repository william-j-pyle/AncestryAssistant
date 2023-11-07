<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AncestorsListPanel
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
        Me.AncestorsList = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'AncestorsList
        '
        Me.AncestorsList.AutoArrange = False
        Me.AncestorsList.BackColor = System.Drawing.Color.Black
        Me.AncestorsList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AncestorsList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AncestorsList.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.AncestorsList.FullRowSelect = True
        Me.AncestorsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.AncestorsList.HideSelection = False
        Me.AncestorsList.Location = New System.Drawing.Point(0, 0)
        Me.AncestorsList.MultiSelect = False
        Me.AncestorsList.Name = "AncestorsList"
        Me.AncestorsList.Size = New System.Drawing.Size(364, 351)
        Me.AncestorsList.TabIndex = 4
        Me.AncestorsList.UseCompatibleStateImageBehavior = False
        Me.AncestorsList.View = System.Windows.Forms.View.Details
        '
        'AncestorsListPanel
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.AncestorsList)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "AncestorsListPanel"
        Me.Size = New System.Drawing.Size(364, 351)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AncestorsList As ListView
End Class
