Imports System.ComponentModel

Partial Class AssistantAppForm

#Region "Fields"

  Private WithEvents FormExtensions As ResizeDragHandler

#End Region

#Region "Private Methods"

  Private Sub Application_CloseButton_Click(sender As Object, e As EventArgs)
    Close()
  End Sub

  Private Sub Application_Form_Closing(sender As Object, e As CancelEventArgs)
    If WindowState <> FormWindowState.Normal Then
      WindowState = FormWindowState.Normal
    End If
    SettingsSave()
  End Sub

  Private Sub Application_MaxButton_Click(sender As Object, e As EventArgs)
    If WindowState = FormWindowState.Normal Then
      WindowState = FormWindowState.Maximized
    ElseIf WindowState = FormWindowState.Maximized Then
      WindowState = FormWindowState.Normal
    End If
  End Sub

  Private Sub Application_MinButton_Click(sender As Object, e As EventArgs)
    WindowState = FormWindowState.Minimized
  End Sub

  Private Sub InitResizeDragHandler() Handles Me.InitUIExtensions
    'Add Form Event Handlers
    AddHandler AppMinButton.Click, AddressOf Application_MinButton_Click
    AddHandler AppMaxButton.Click, AddressOf Application_MaxButton_Click
    AddHandler AppTitle.DoubleClick, AddressOf Application_MaxButton_Click
    AddHandler Closing, AddressOf Application_Form_Closing
    AddHandler AppCloseButton.Click, AddressOf Application_CloseButton_Click

    ' Init the FormExtensions to make this a borderless form
    FormExtensions = New ResizeDragHandler(Me)
    FormExtensions.SetDragControl(AppTitle)

  End Sub

#End Region

End Class