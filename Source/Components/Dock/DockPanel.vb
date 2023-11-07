
Public Class DockPanel

  Public Event DockClose(sender As DockPanel)
  Public Event DockFocusChanged(sender As DockPanel, hasFocus As Boolean)
  Public Event DockPinnedClicked(sender As DockPanel, isPinned As Boolean)


  Public ReadOnly Property tabPages As TabControl.TabPageCollection
    Get
      Return pnlClient.TabPages
    End Get
  End Property


  Private Sub AdjustClientSize()
    If pnlClient.TabPages.Count = 1 Then
      Dim h As Integer = Height - pnlMain.Height + pnlClient.ItemSize.Height
      pnlClient.MinimumSize = New Size(0, h)
      pnlClient.Size = New Size(pnlClient.Width, h)
      pnlClient.Dock = DockStyle.Fill
      pnlClient.Refresh()
    Else
      pnlClient.MinimumSize = New Size(0, 0)
      pnlClient.Dock = DockStyle.Fill
    End If

  End Sub

  Public Property IsPinned As Boolean = True

  Public Sub New()
    InitializeComponent()
    pnlClient.TabPages(0).Text = ""
    AdjustClientSize()
    lblCaption.Text = ""

  End Sub

  Private Sub DockPanel_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
    AdjustClientSize()
  End Sub

  Private Sub lblCaption_Click(sender As Object, e As EventArgs)

  End Sub

  Public Function GetClient(key As String) As Control
    If pnlClient.TabPages(key) Is Nothing Then Return Nothing
    Return pnlClient.TabPages(key).Controls(0)
  End Function

  Public Function RemoveClient(key As String) As Control
    If pnlClient.TabPages(key) Is Nothing Then Return Nothing
    Dim ctl As Control = pnlClient.TabPages(key).Controls(0)
    If pnlClient.TabCount = 1 Then
      pnlClient.TabPages.Add("BLANK", "")
    End If
    pnlClient.TabPages.RemoveByKey(key)
    If pnlClient.SelectedTab.Text.Equals("") Then
      RaiseEvent DockClose(Me)
    End If
    lblCaption.Text = pnlClient.SelectedTab.Text
    Return ctl
  End Function

  Public Sub AddClient(Caption As String, ctl As Control)
    ctl.Dock = DockStyle.Fill
    pnlClient.TabPages.Add(Caption, Caption)
    If pnlClient.TabCount = 2 And pnlClient.TabPages(0).Text = "" Then
      pnlClient.TabPages.RemoveAt(0)
    End If
    pnlClient.TabPages(Caption).Controls.Add(ctl)
    lblCaption.Text = pnlClient.SelectedTab.Text
  End Sub

  Private Sub pnlClient_ControlAdded(sender As Object, e As ControlEventArgs) Handles pnlClient.ControlAdded
    AdjustClientSize()
  End Sub

  Private Sub pnlClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pnlClient.SelectedIndexChanged
    lblCaption.Text = pnlClient.SelectedTab.Text
  End Sub

  Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
    RaiseEvent DockClose(Me)
  End Sub

  Private Sub btnPinned_Click(sender As Object, e As EventArgs) Handles btnPinned.Click
    IsPinned = Not IsPinned
    RaiseEvent DockPinnedClicked(Me, IsPinned)
  End Sub
End Class
