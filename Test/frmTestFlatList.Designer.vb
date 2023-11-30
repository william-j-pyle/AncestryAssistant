<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestFlatList
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
    Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Row 1", "Column2"}, -1)
    Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Row 2", "Column 2"}, -1)
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.FlatListView1 = New AncestryAssistant.FlatListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.FlatListView1)
        Me.Panel1.Location = New System.Drawing.Point(111, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(278, 324)
        Me.Panel1.TabIndex = 0
        '
        'FlatListView1
        '
        Me.FlatListView1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.FlatListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.FlatListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.FlatListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.FlatListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlatListView1.FlatAccentColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.FlatListView1.FlatBackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.FlatListView1.FlatBorderColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.FlatListView1.FlatForeColor = System.Drawing.Color.WhiteSmoke
        Me.FlatListView1.FlatHighlightColor = System.Drawing.Color.Lime
        Me.FlatListView1.FlatShadowColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(3, Byte), Integer))
        Me.FlatListView1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FlatListView1.FullRowSelect = True
        Me.FlatListView1.HideSelection = False
        Me.FlatListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
        Me.FlatListView1.Location = New System.Drawing.Point(0, 0)
        Me.FlatListView1.Margin = New System.Windows.Forms.Padding(0)
        Me.FlatListView1.Name = "FlatListView1"
        Me.FlatListView1.OwnerDraw = True
        Me.FlatListView1.ShowItemToolTips = True
        Me.FlatListView1.Size = New System.Drawing.Size(278, 324)
        Me.FlatListView1.TabIndex = 0
        Me.FlatListView1.UseCompatibleStateImageBehavior = False
        Me.FlatListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 121
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 157
        '
        'frmTestFlatList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 534)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmTestFlatList"
        Me.Text = "frmTestFlatList"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents FlatListView1 As FlatListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
End Class
