﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AncestorPanel
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
        Me.JDockPanelHeader1 = New AncestryAssistant.DockHeaderPanel()
        Me.AncestorAttributesHeader = New System.Windows.Forms.Panel()
        Me.AncestorColSplitter = New System.Windows.Forms.Splitter()
        Me.ancestorAttributesCol2 = New AncestryAssistant.BordersPanel()
        Me.lblAncestorAttributesCol2 = New System.Windows.Forms.Label()
        Me.ancestorAttributesCol1 = New AncestryAssistant.BordersPanel()
        Me.lblAncestorAttributesCol1 = New System.Windows.Forms.Label()
        Me.AncestorAttributes = New System.Windows.Forms.TreeView()
        Me.AncestorAttributesHeader.SuspendLayout()
        Me.ancestorAttributesCol2.SuspendLayout()
        Me.ancestorAttributesCol1.SuspendLayout()
        Me.SuspendLayout()
        '
        'JDockPanelHeader1
        '
        Me.JDockPanelHeader1.BackColor = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader1.BackColorDisabled = System.Drawing.Color.LightGray
        Me.JDockPanelHeader1.BackColorEnabled = System.Drawing.Color.DarkGray
        Me.JDockPanelHeader1.Caption = "Ancestor"
        Me.JDockPanelHeader1.Dock = System.Windows.Forms.DockStyle.Top
        Me.JDockPanelHeader1.ForeColor = System.Drawing.Color.Black
        Me.JDockPanelHeader1.ForeColorDisabled = System.Drawing.Color.Black
        Me.JDockPanelHeader1.ForeColorEnabled = System.Drawing.Color.Black
        Me.JDockPanelHeader1.Location = New System.Drawing.Point(0, 0)
    Me.JDockPanelHeader1.MaximumSize = New System.Drawing.Size(0, 24)
    Me.JDockPanelHeader1.MinimumSize = New System.Drawing.Size(0, 24)
    Me.JDockPanelHeader1.Name = "JDockPanelHeader1"
    Me.JDockPanelHeader1.Size = New System.Drawing.Size(287, 24)
    Me.JDockPanelHeader1.TabIndex = 2
    Me.JDockPanelHeader1.Tag = "TOP_LEFT"
    '
    'AncestorAttributesHeader
    '
    Me.AncestorAttributesHeader.BackColor = System.Drawing.Color.Silver
    Me.AncestorAttributesHeader.Controls.Add(Me.AncestorColSplitter)
    Me.AncestorAttributesHeader.Controls.Add(Me.ancestorAttributesCol2)
    Me.AncestorAttributesHeader.Controls.Add(Me.ancestorAttributesCol1)
    Me.AncestorAttributesHeader.Dock = System.Windows.Forms.DockStyle.Top
    Me.AncestorAttributesHeader.Location = New System.Drawing.Point(0, 24)
    Me.AncestorAttributesHeader.MaximumSize = New System.Drawing.Size(0, 18)
    Me.AncestorAttributesHeader.MinimumSize = New System.Drawing.Size(0, 18)
    Me.AncestorAttributesHeader.Name = "AncestorAttributesHeader"
    Me.AncestorAttributesHeader.Padding = New System.Windows.Forms.Padding(1)
    Me.AncestorAttributesHeader.Size = New System.Drawing.Size(287, 18)
    Me.AncestorAttributesHeader.TabIndex = 4
    '
    'AncestorColSplitter
    '
    Me.AncestorColSplitter.BackColor = System.Drawing.SystemColors.ButtonHighlight
    Me.AncestorColSplitter.Location = New System.Drawing.Point(151, 1)
    Me.AncestorColSplitter.Margin = New System.Windows.Forms.Padding(0)
    Me.AncestorColSplitter.Name = "AncestorColSplitter"
    Me.AncestorColSplitter.Size = New System.Drawing.Size(1, 16)
    Me.AncestorColSplitter.TabIndex = 1
    Me.AncestorColSplitter.TabStop = False
    '
    'ancestorAttributesCol2
    '
    Me.ancestorAttributesCol2.BackColor = System.Drawing.SystemColors.ButtonFace
    Me.ancestorAttributesCol2.BorderColor = System.Drawing.Color.Transparent
    Me.ancestorAttributesCol2.BorderColorBottom = System.Drawing.SystemColors.ButtonShadow
    Me.ancestorAttributesCol2.BorderColorLeft = System.Drawing.SystemColors.ButtonHighlight
    Me.ancestorAttributesCol2.BorderColorRight = System.Drawing.SystemColors.ButtonShadow
    Me.ancestorAttributesCol2.BorderColorTop = System.Drawing.SystemColors.ButtonShadow
    Me.ancestorAttributesCol2.BorderWidth = New System.Windows.Forms.Padding(0, 0, 1, 1)
    Me.ancestorAttributesCol2.Controls.Add(Me.lblAncestorAttributesCol2)
    Me.ancestorAttributesCol2.CornerRadius = New System.Windows.Forms.Padding(0)
    Me.ancestorAttributesCol2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.ancestorAttributesCol2.Location = New System.Drawing.Point(151, 1)
    Me.ancestorAttributesCol2.MinimumSize = New System.Drawing.Size(60, 0)
    Me.ancestorAttributesCol2.Name = "ancestorAttributesCol2"
    Me.ancestorAttributesCol2.Padding = New System.Windows.Forms.Padding(1)
    Me.ancestorAttributesCol2.Size = New System.Drawing.Size(135, 16)
    Me.ancestorAttributesCol2.TabIndex = 4
    '
    'lblAncestorAttributesCol2
    '
    Me.lblAncestorAttributesCol2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.lblAncestorAttributesCol2.Location = New System.Drawing.Point(1, 1)
    Me.lblAncestorAttributesCol2.Name = "lblAncestorAttributesCol2"
    Me.lblAncestorAttributesCol2.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
    Me.lblAncestorAttributesCol2.Size = New System.Drawing.Size(133, 14)
    Me.lblAncestorAttributesCol2.TabIndex = 0
    Me.lblAncestorAttributesCol2.Text = "Value"
    Me.lblAncestorAttributesCol2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ancestorAttributesCol1
    '
    Me.ancestorAttributesCol1.BackColor = System.Drawing.SystemColors.ButtonFace
    Me.ancestorAttributesCol1.BorderColor = System.Drawing.Color.Transparent
    Me.ancestorAttributesCol1.BorderColorBottom = System.Drawing.SystemColors.ButtonShadow
    Me.ancestorAttributesCol1.BorderColorLeft = System.Drawing.SystemColors.ButtonShadow
    Me.ancestorAttributesCol1.BorderColorRight = System.Drawing.SystemColors.ButtonShadow
    Me.ancestorAttributesCol1.BorderColorTop = System.Drawing.SystemColors.ButtonShadow
    Me.ancestorAttributesCol1.BorderWidth = New System.Windows.Forms.Padding(0, 0, 1, 1)
    Me.ancestorAttributesCol1.Controls.Add(Me.lblAncestorAttributesCol1)
    Me.ancestorAttributesCol1.CornerRadius = New System.Windows.Forms.Padding(0)
    Me.ancestorAttributesCol1.Dock = System.Windows.Forms.DockStyle.Left
    Me.ancestorAttributesCol1.Location = New System.Drawing.Point(1, 1)
    Me.ancestorAttributesCol1.MinimumSize = New System.Drawing.Size(80, 0)
    Me.ancestorAttributesCol1.Name = "ancestorAttributesCol1"
    Me.ancestorAttributesCol1.Padding = New System.Windows.Forms.Padding(1)
    Me.ancestorAttributesCol1.Size = New System.Drawing.Size(150, 16)
    Me.ancestorAttributesCol1.TabIndex = 3
    '
    'lblAncestorAttributesCol1
    '
    Me.lblAncestorAttributesCol1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.lblAncestorAttributesCol1.Location = New System.Drawing.Point(1, 1)
    Me.lblAncestorAttributesCol1.Name = "lblAncestorAttributesCol1"
    Me.lblAncestorAttributesCol1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
    Me.lblAncestorAttributesCol1.Size = New System.Drawing.Size(148, 14)
    Me.lblAncestorAttributesCol1.TabIndex = 0
    Me.lblAncestorAttributesCol1.Text = "Attribute"
    Me.lblAncestorAttributesCol1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'AncestorAttributes
    '
    Me.AncestorAttributes.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.AncestorAttributes.Dock = System.Windows.Forms.DockStyle.Fill
    Me.AncestorAttributes.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText
    Me.AncestorAttributes.FullRowSelect = True
    Me.AncestorAttributes.HotTracking = True
    Me.AncestorAttributes.Location = New System.Drawing.Point(0, 42)
    Me.AncestorAttributes.Margin = New System.Windows.Forms.Padding(0)
    Me.AncestorAttributes.Name = "AncestorAttributes"
    Me.AncestorAttributes.ShowLines = False
    Me.AncestorAttributes.Size = New System.Drawing.Size(287, 266)
    Me.AncestorAttributes.TabIndex = 5
    '
    'AncestorPanel
    '
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Me.BackColor = System.Drawing.SystemColors.ControlLightLight
    Me.Controls.Add(Me.AncestorAttributes)
    Me.Controls.Add(Me.AncestorAttributesHeader)
    Me.Controls.Add(Me.JDockPanelHeader1)
    Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ForeColor = System.Drawing.Color.Black
    Me.Margin = New System.Windows.Forms.Padding(0)
    Me.Name = "AncestorPanel"
    Me.Size = New System.Drawing.Size(287, 308)
    Me.AncestorAttributesHeader.ResumeLayout(False)
        Me.ancestorAttributesCol2.ResumeLayout(False)
        Me.ancestorAttributesCol1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents JDockPanelHeader1 As DockHeaderPanel
    Friend WithEvents AncestorAttributesHeader As Panel
    Friend WithEvents AncestorColSplitter As Splitter
    Friend WithEvents ancestorAttributesCol2 As BordersPanel
    Friend WithEvents lblAncestorAttributesCol2 As Label
    Friend WithEvents ancestorAttributesCol1 As BordersPanel
    Friend WithEvents lblAncestorAttributesCol1 As Label
    Friend WithEvents AncestorAttributes As TreeView
End Class
