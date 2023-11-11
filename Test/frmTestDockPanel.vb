Public Class frmTestDockPanel
  Private cnt As Integer = 0
  Private Function getPanelItem(key As String) As IDockPanelItem
    Dim ctl As IDockPanelItem = Nothing
    Select Case key
      Case "Ancestor"
        ctl = New AncestorPanel
      Case "Ancestors List"
        ctl = New AncestorsListPanel
      Case "Ancestry.com"
        ctl = New AncestryWebViewer
      Case "Notebook"
        ctl = New NotebookViewer
      Case "Gallery"
        ctl = New ImageGallery
      Case "Census"
        ctl = New CensusViewer
    End Select
    Return ctl
  End Function


  Private Sub frmTestDockPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    With cmbPanelList.Items
      .Clear()
      .Add("Ancestor")
      .Add("Ancestors List")
      .Add("Ancestry.com")
      .Add("Notebook")
      .Add("Gallery")
      .Add("Census")
    End With
    cmbType1.SelectedIndex = 0
    cmbType2.SelectedIndex = 1
    DockPanel1.PanelHasFocus = False
    DockPanel2.PanelHasFocus = False
    ApplyLayout()
  End Sub

  Private Sub chkFocus1_CheckedChanged(sender As Object, e As EventArgs) Handles chkFocus1.CheckedChanged
    DockPanel1.PanelHasFocus = chkFocus1.Checked
    DockPanel1.Refresh()
  End Sub

  Private Sub chkFocus2_CheckedChanged(sender As Object, e As EventArgs) Handles chkFocus2.CheckedChanged
    DockPanel2.PanelHasFocus = chkFocus2.Checked
    DockPanel2.Refresh()

  End Sub

  Private Sub cmbType1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType1.SelectedIndexChanged
    If cmbType1.Text = "Tab" Then
      DockPanel1.PanelType = DockPanelType.Tab
    Else
      DockPanel1.PanelType = DockPanelType.Panel
    End If
    chkMenu1.Enabled = cmbType1.Text.Equals("Panel")
    chkSearch1.Enabled = cmbType1.Text.Equals("Panel")
    chkPinned1.Enabled = cmbType1.Text.Equals("Panel")
    DockPanel1.Refresh()
  End Sub

  Private Sub cmbType2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbType2.SelectedIndexChanged
    If cmbType2.Text = "Tab" Then
      DockPanel2.PanelType = DockPanelType.Tab
    Else
      DockPanel2.PanelType = DockPanelType.Panel
    End If
    chkMenu2.Enabled = cmbType2.Text.Equals("Panel")
    chkSearch2.Enabled = cmbType2.Text.Equals("Panel")
    chkPinned2.Enabled = cmbType2.Text.Equals("Panel")
    DockPanel2.Refresh()

  End Sub

  Private Sub chkClose1_CheckedChanged(sender As Object, e As EventArgs) Handles chkClose1.CheckedChanged
    DockPanel1.PanelShowClose = sender.Checked
  End Sub

  Private Sub chkMenu1_CheckedChanged(sender As Object, e As EventArgs) Handles chkMenu1.CheckedChanged
    DockPanel1.PanelShowContextMenu = sender.Checked
  End Sub

  Private Sub chkPinned1_CheckedChanged(sender As Object, e As EventArgs) Handles chkPinned1.CheckedChanged
    DockPanel1.PanelShowPinned = sender.Checked

  End Sub

  Private Sub chkSearch1_CheckedChanged(sender As Object, e As EventArgs) Handles chkSearch1.CheckedChanged
    DockPanel1.PanelShowSearch = sender.Checked

  End Sub

  Private Sub chkClose2_CheckedChanged(sender As Object, e As EventArgs) Handles chkClose2.CheckedChanged
    DockPanel2.PanelShowClose = sender.Checked

  End Sub

  Private Sub chkMenu2_CheckedChanged(sender As Object, e As EventArgs) Handles chkMenu2.CheckedChanged
    DockPanel2.PanelShowContextMenu = sender.Checked

  End Sub

  Private Sub chkPinned2_CheckedChanged(sender As Object, e As EventArgs) Handles chkPinned2.CheckedChanged
    DockPanel2.PanelShowPinned = sender.Checked

  End Sub

  Private Sub chkSearch2_CheckedChanged(sender As Object, e As EventArgs) Handles chkSearch2.CheckedChanged
    DockPanel2.PanelShowSearch = sender.Checked

  End Sub

  Private Sub btnAddR_Click(sender As Object, e As EventArgs) Handles btnAddR.Click
    DockPanel2.AddItem(getPanelItem(cmbPanelList.Text))
    ApplyLayout()
  End Sub

  Private Sub btnAddL_Click(sender As Object, e As EventArgs) Handles btnAddL.Click
    DockPanel1.AddItem(getPanelItem(cmbPanelList.Text))
    ApplyLayout()

  End Sub

  Private Sub btnRemoveR_Click(sender As Object, e As EventArgs) Handles btnRemoveR.Click
    DockPanel2.RemoveItem(DockPanel2.PanelSelectedIndex)
    ApplyLayout()
  End Sub

  Private Sub btnRemoveL_Click(sender As Object, e As EventArgs) Handles btnRemoveL.Click
    DockPanel1.RemoveItem(DockPanel1.PanelSelectedIndex)
    ApplyLayout()

  End Sub

  Private Sub btnMoveFromLToR_Click(sender As Object, e As EventArgs) Handles btnMoveFromLToR.Click
    Dim ctl As Control
    ctl = DockPanel1.RemoveItem(DockPanel1.PanelSelectedIndex)
    DockPanel2.AddItem(ctl)
    ApplyLayout()
  End Sub

  Private Sub btnMoveFromRToL_Click(sender As Object, e As EventArgs) Handles btnMoveFromRToL.Click
    Dim ctl As Control
    ctl = DockPanel2.RemoveItem(DockPanel2.PanelSelectedIndex)
    DockPanel1.AddItem(ctl)
    ApplyLayout()
  End Sub

  Private Sub ApplyLayout()
    Dim hL As Boolean = True
    Dim hR As Boolean = True
    If Not cmbPanelList.Text.Equals("") Then
      hL = DockPanel1.HasItem(cmbPanelList.Text)
      hR = DockPanel2.HasItem(cmbPanelList.Text)
    End If
    btnAddR.Enabled = Not hR
    btnAddL.Enabled = Not hL
    btnMoveFromRToL.Enabled = DockPanel2.Visible
    btnRemoveR.Enabled = DockPanel2.Visible
    btnMoveFromLToR.Enabled = DockPanel1.Visible
    btnRemoveL.Enabled = DockPanel1.Visible
  End Sub

  Private Sub cmbPanelList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPanelList.SelectedIndexChanged
    ApplyLayout()
  End Sub

  Private Sub DockPanel1_PanelFocusChanged(sender As DockPanel, hasFocus As Boolean) Handles DockPanel1.PanelFocusChanged
    chkFocus1.Checked = hasFocus
  End Sub
  Private Sub DockPanel2_PanelFocusChanged(sender As DockPanel, hasFocus As Boolean) Handles DockPanel2.PanelFocusChanged
    chkFocus2.Checked = hasFocus
  End Sub
End Class