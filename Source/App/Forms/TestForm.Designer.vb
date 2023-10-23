<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestForm
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
        Me.btnAddSection = New System.Windows.Forms.Button()
        Me.txtSection = New System.Windows.Forms.TextBox()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.btnAddPage = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPage = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddSection
        '
        Me.btnAddSection.Location = New System.Drawing.Point(243, 7)
        Me.btnAddSection.Name = "btnAddSection"
        Me.btnAddSection.Size = New System.Drawing.Size(113, 23)
        Me.btnAddSection.TabIndex = 11
        Me.btnAddSection.Text = "Add Section"
        Me.btnAddSection.UseVisualStyleBackColor = True
        '
        'txtSection
        '
        Me.txtSection.Location = New System.Drawing.Point(30, 9)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(211, 20)
        Me.txtSection.TabIndex = 14
        '
        'txtPage
        '
        Me.txtPage.Location = New System.Drawing.Point(30, 35)
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Size = New System.Drawing.Size(211, 20)
        Me.txtPage.TabIndex = 16
        '
        'btnAddPage
        '
        Me.btnAddPage.Location = New System.Drawing.Point(243, 33)
        Me.btnAddPage.Name = "btnAddPage"
        Me.btnAddPage.Size = New System.Drawing.Size(113, 23)
        Me.btnAddPage.TabIndex = 15
        Me.btnAddPage.Text = "Add Page"
        Me.btnAddPage.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(491, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Section"
        '
        'lblSection
        '
        Me.lblSection.AutoEllipsis = True
        Me.lblSection.Location = New System.Drawing.Point(551, 33)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(227, 23)
        Me.lblSection.TabIndex = 18
        Me.lblSection.Text = "unset"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(491, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Page"
        '
        'lblPage
        '
        Me.lblPage.AutoEllipsis = True
        Me.lblPage.Location = New System.Drawing.Point(551, 67)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(227, 23)
        Me.lblPage.TabIndex = 20
        Me.lblPage.Text = "unset"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(53, 162)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblPage)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblSection)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPage)
        Me.Controls.Add(Me.btnAddPage)
        Me.Controls.Add(Me.txtSection)
        Me.Controls.Add(Me.btnAddSection)
        Me.Name = "TestForm"
        Me.Text = "TestForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAddSection As Button
    Friend WithEvents txtSection As TextBox
    Friend WithEvents txtPage As TextBox
    Friend WithEvents btnAddPage As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblSection As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblPage As Label
    Friend WithEvents Button1 As Button
End Class
