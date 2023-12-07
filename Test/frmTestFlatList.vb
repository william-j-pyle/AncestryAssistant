Public Class frmTestFlatList

#Region "Fields"

  Friend WithEvents PanelContextMenu As FlatContextMenu

#End Region

#Region "Private Methods"

  Private Sub CreatePanelContextMenu()
    Dim item As System.Windows.Forms.ToolStripMenuItem

    PanelContextMenu = New AncestryAssistant.FlatContextMenu() With {
    .Name = "PanelContextMenu"
    }

    PanelContextMenu.AddMenuItem("MnuDockFloat", "Float", enabled:=False)

    item = PanelContextMenu.AddMenuItem("MnuDock", "Dock")
    PanelContextMenu.AddMenuItem(item, "MnuDockLeftTop", "Top Left")
    PanelContextMenu.AddMenuItem(item, "MnuDockLeftBottom", "Bottom Left")
    PanelContextMenu.AddMenuItem(item, "MnuDockRightTop", "Top Right")
    PanelContextMenu.AddMenuItem(item, "MnuDockRightBottom", "Bottom Right")
    PanelContextMenu.AddMenuItem(item, "MnuDockMiddleBottom", "Middle Bottom")
    PanelContextMenu.AddSeperator(item)
    PanelContextMenu.AddMenuItem(item, "MnuDockTabbed", "As Tabbed Document")

    PanelContextMenu.AddSeperator()

    PanelContextMenu.AddMenuItem("MnuDockClose", "Close")

  End Sub

  Private Sub frmTestFlatList_Load(sender As Object, e As EventArgs) Handles Me.Load
    CreatePanelContextMenu()
  End Sub

  Private Sub PanelContextMenu_ContextItemClicked(item As ToolStripMenuItem) Handles PanelContextMenu.ContextItemClicked
    Debug.Print(item.Name)
  End Sub

  Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
    PanelContextMenu.Show(PictureBox1, New Point(0, PictureBox1.Height))
  End Sub

#End Region

End Class