Public Class frmTestDockPanel
  Private cnt As Integer = 0
  Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
    Dim ctl As IDockPanelItem
    Dim ctl2 As IDockPanelItem
    cnt += 1
    Select Case cnt
      Case 1
        ctl = New AncestorPanel
        ctl2 = New AncestorPanel
      Case 2
        ctl = New AncestorsListPanel
        ctl2 = New AncestorsListPanel
      Case 3
        ctl = New ImageGallery
        ctl2 = New ImageGallery
      Case 4
        ctl = New CensusViewer
        ctl2 = New CensusViewer
      Case Else
        cnt -= 1
        Exit Sub
    End Select
    DockPanel1.AddItem(ctl)
    DockPanel2.AddItem(ctl2)
  End Sub

  Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
    If cnt = 0 Then Exit Sub
    cnt -= 1

    DockPanel1.RemoveItem(cnt)
    DockPanel2.RemoveItem(cnt)
  End Sub
End Class