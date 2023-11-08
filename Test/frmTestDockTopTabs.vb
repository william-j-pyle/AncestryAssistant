Public Class frmTestDockTopTabs
  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    DockTopTabs1.PanelHasFocus = Not DockTopTabs1.PanelHasFocus
    'DockTopTabs1.Invalidate(DockBottomTabs1.Bounds)
  End Sub
End Class