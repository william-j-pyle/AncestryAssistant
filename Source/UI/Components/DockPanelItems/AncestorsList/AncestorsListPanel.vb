Imports AncestryAssistant.AncestorCollection

Public Class AncestorsListPanel
  Inherits System.Windows.Forms.UserControl
  Implements IDockPanelItem

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

  Private theme As UITheme = UITheme.GetInstance
  Private components As System.ComponentModel.IContainer
  Private WithEvents AncestorsList As ListView

  Public Event AncestryNavigateRequest(AncestorID As String)
  Public Event AncestorIDChanged(AncestorID As String)
  Public Event PanelCloseClicked(sender As Object)

  Private blockEvents As Boolean = False

  Public ReadOnly Property ItemCaption As String Implements IDockPanelItem.ItemCaption
    Get
      Return "Ancestors List"
    End Get
  End Property

  Public Property ItemDockStyle As DockStyle Implements IDockPanelItem.ItemDockStyle
    Get
      Return Dock
    End Get
    Set(value As DockStyle)
      Dock = value
    End Set
  End Property

  Public Sub New()
    AncestorsList = New System.Windows.Forms.ListView()
    SuspendLayout()
    '
    'AncestorsList
    '
    AncestorsList.AutoArrange = False
    AncestorsList.BackColor = theme.PanelBackColor
    AncestorsList.BorderStyle = System.Windows.Forms.BorderStyle.None
    AncestorsList.Dock = System.Windows.Forms.DockStyle.Fill
    AncestorsList.ForeColor = theme.PanelFontColor
    AncestorsList.FullRowSelect = True
    AncestorsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
    AncestorsList.HideSelection = False
    AncestorsList.Location = New System.Drawing.Point(0, 0)
    AncestorsList.MultiSelect = False
    AncestorsList.Name = "AncestorsList"
    AncestorsList.Size = New System.Drawing.Size(364, 351)
    AncestorsList.TabIndex = 4
    AncestorsList.UseCompatibleStateImageBehavior = False
    AncestorsList.View = System.Windows.Forms.View.Details
    '
    'AncestorsListPanel
    '
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    BackColor = theme.PanelBackColor
    Controls.Add(AncestorsList)
    Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    ForeColor = theme.PanelFontColor
    Margin = New System.Windows.Forms.Padding(0)
    Name = "AncestorsListPanel"
    Size = New System.Drawing.Size(364, 351)
    ResumeLayout(False)

    With AncestorsList
      .Tag = ""
      .Items.Clear()
      .Groups.Clear()
      .Columns.Clear()
      .Columns.Add("Name", CInt(.Width / 2))
      .Columns.Add("Lifespan", CInt(.Width / 2))
    End With
  End Sub

  Private Sub AncestorsList_DoubleClick(sender As Object, e As EventArgs) Handles AncestorsList.DoubleClick
    Dim AncestorID As String = AncestorsList.SelectedItems.Item(0).Tag
    If Not AncestorID.Equals("") Then
      RaiseEvent AncestryNavigateRequest(AncestorID)
    End If
  End Sub

  Private Sub AncestorsList_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles AncestorsList.ItemSelectionChanged
    If e.IsSelected And Not blockEvents Then
      RaiseEvent AncestorIDChanged(e.Item.Tag)
    End If
  End Sub

  Public Sub setAncestors(Ancestors As AncestorCollection, Optional SelectedAncestorID As String = "")
    Dim item As ListViewItem
    blockEvents = True
    With AncestorsList
      .Tag = ""
      .Items.Clear()
      For Each ancestor As AncestorCollection.Ancestor In Ancestors.Values
        item = .Items.Add(ancestor.FullName)
        item.SubItems.Add(ancestor.LifeSpan)
        item.Tag = ancestor.ID
        If SelectedAncestorID.Equals(ancestor.ID) Then
          item.Selected = True
        End If
      Next
    End With
    blockEvents = False
  End Sub

  Public Sub setActiveAncestor(AncestorID As String)
    blockEvents = True
    For Each item As ListViewItem In AncestorsList.Items
      item.Selected = item.Tag.Equals(AncestorID)
    Next
    blockEvents = False
  End Sub

End Class
