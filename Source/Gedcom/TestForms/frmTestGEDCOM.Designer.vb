<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTestGEDCOM
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
        Me.btnGedCom = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.btnSummary = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnGedCom
        '
        Me.btnGedCom.Location = New System.Drawing.Point(12, 12)
        Me.btnGedCom.Name = "btnGedCom"
        Me.btnGedCom.Size = New System.Drawing.Size(119, 23)
        Me.btnGedCom.TabIndex = 0
        Me.btnGedCom.Text = "Open GedCom"
        Me.btnGedCom.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutput.Location = New System.Drawing.Point(12, 41)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(448, 192)
        Me.txtOutput.TabIndex = 1
        '
        'btnSummary
        '
        Me.btnSummary.Location = New System.Drawing.Point(137, 12)
        Me.btnSummary.Name = "btnSummary"
        Me.btnSummary.Size = New System.Drawing.Size(113, 23)
        Me.btnSummary.TabIndex = 2
        Me.btnSummary.Text = "Display Summary"
        Me.btnSummary.UseVisualStyleBackColor = True
        '
        'frmTestGEDCOM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 241)
        Me.Controls.Add(Me.btnSummary)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.btnGedCom)
        Me.Name = "frmTestGEDCOM"
        Me.Text = "GedCom Testing"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnGedCom As Button
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents btnSummary As Button
End Class
