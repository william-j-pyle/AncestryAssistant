<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AncestorsListPanel
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
        Me.JDockPanelHeader2 = New AncestryAssistant.DockHeaderPanel()
        Me.AncestorsList = New System.Windows.Forms.ListView()
        Me.SuspendLayout()
        '
        'JDockPanelHeader2
        '
        Me.JDockPanelHeader2.BackColor = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader2.BackColorDisabled = System.Drawing.Color.LightGray
        Me.JDockPanelHeader2.BackColorEnabled = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader2.Caption = "Ancestors Research List"
        Me.JDockPanelHeader2.Dock = System.Windows.Forms.DockStyle.Top
        Me.JDockPanelHeader2.ForeColor = System.Drawing.Color.Black
        Me.JDockPanelHeader2.ForeColorDisabled = System.Drawing.Color.Black
        Me.JDockPanelHeader2.ForeColorEnabled = System.Drawing.Color.Black
        Me.JDockPanelHeader2.Location = New System.Drawing.Point(0, 0)
    Me.JDockPanelHeader2.MaximumSize = New System.Drawing.Size(0, 24)
    Me.JDockPanelHeader2.MinimumSize = New System.Drawing.Size(0, 24)
    Me.JDockPanelHeader2.Name = "JDockPanelHeader2"
    Me.JDockPanelHeader2.Size = New System.Drawing.Size(364, 24)
    Me.JDockPanelHeader2.TabIndex = 3
    Me.JDockPanelHeader2.Tag = "BOTTOM_LEFT"
    '
    'AncestorsList
    '
    Me.AncestorsList.AutoArrange = False
    Me.AncestorsList.BackColor = System.Drawing.Color.White
    Me.AncestorsList.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.AncestorsList.Dock = System.Windows.Forms.DockStyle.Fill
    Me.AncestorsList.FullRowSelect = True
    Me.AncestorsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
    Me.AncestorsList.HideSelection = False
    Me.AncestorsList.Location = New System.Drawing.Point(0, 24)
    Me.AncestorsList.MultiSelect = False
    Me.AncestorsList.Name = "AncestorsList"
    Me.AncestorsList.Size = New System.Drawing.Size(364, 327)
    Me.AncestorsList.TabIndex = 4
    Me.AncestorsList.UseCompatibleStateImageBehavior = False
    Me.AncestorsList.View = System.Windows.Forms.View.Details
    '
    'AncestorsListPanel
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.BackColor = System.Drawing.SystemColors.ControlLightLight
    Me.Controls.Add(Me.AncestorsList)
    Me.Controls.Add(Me.JDockPanelHeader2)
    Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ForeColor = System.Drawing.Color.Black
    Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
    Me.Name = "AncestorsListPanel"
    Me.Size = New System.Drawing.Size(364, 351)
    Me.ResumeLayout(False)

    End Sub

    Friend WithEvents JDockPanelHeader2 As DockHeaderPanel
    Friend WithEvents AncestorsList As ListView
End Class
