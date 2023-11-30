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
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.btnAddBar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'pnlContainer
        '
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlContainer.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlContainer.MaximumSize = New System.Drawing.Size(0, 130)
        Me.pnlContainer.MinimumSize = New System.Drawing.Size(0, 130)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlContainer.Size = New System.Drawing.Size(658, 130)
        Me.pnlContainer.TabIndex = 2
        '
        'btnAddBar
        '
        Me.btnAddBar.BackColor = System.Drawing.Color.White
        Me.btnAddBar.ForeColor = System.Drawing.Color.Black
        Me.btnAddBar.Location = New System.Drawing.Point(20, 142)
        Me.btnAddBar.Name = "btnAddBar"
        Me.btnAddBar.Size = New System.Drawing.Size(199, 23)
        Me.btnAddBar.TabIndex = 9
        Me.btnAddBar.Text = "Add Bar"
        Me.btnAddBar.UseVisualStyleBackColor = False
        '
        'frmTestRibbon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(658, 180)
        Me.Controls.Add(Me.btnAddBar)
        Me.Controls.Add(Me.pnlContainer)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmTestRibbon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTestRibbon"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContainer As Panel
    Friend WithEvents btnAddBar As Button
End Class
