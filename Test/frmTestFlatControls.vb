Imports System.Reflection
Imports System.Text

Public Class frmTestFlatControls

#Region "Fields"

  Private WithEvents ctl As Control

  Private Const CTL_ATTACH As String = "Attach Control"

  Private Const CTL_RELEASE As String = "Release Control"

  Private dynamicEvent As List(Of EventInfo)

  Private dynamicEventHandlers As List(Of Object)

#End Region

#Region "Private Methods"

  Private Sub attachControl(c As Control)
    If c Is Nothing Then Exit Sub
    detachControl()
    listEvents.Items.Clear()
    dynamicEventHandlers = New List(Of Object)
    dynamicEvent = New List(Of EventInfo)
    ctl = c
    Dim controlType As Type = ctl.GetType()
    Dim events As EventInfo() = controlType.GetEvents()
    For Each ev As EventInfo In events
      If Not (ev.Name.Contains("Scroll") Or ev.Name.Contains("Control") Or ev.Name.Contains("Drag")) Then
        Dim eventName As String = ev.Name
        Dim handler As Object = Nothing
        Select Case eventName
          Case "SearchEvent"
            handler = New FlatSearchEventHandler(Sub(s, e) EventHandler_FlatSearch(s, e, eventName))
            'Case "SearchEvent"
           ' handler = New FlatSearchEventHandler(Sub(s, e) EventHandler_FlatSearch(s, e, eventName))
          Case "Scroll"
          Case "ControlAdded"
          Case "ControlRemoved"
          Case "DragDrop"
          Case "DragEnter"
          Case "DragOver"
          Case "GiveFeedback"
          Case "HelpRequested"
          Case "Invalidated"
          Case "Paint"
          Case "QueryContinueDrag"
          Case "QueryAccessibilityHelp"
          Case "KeyDown"
            handler = New KeyEventHandler(Sub(s, e) EventHandler_KeyEventArgs(s, e, eventName))
          Case "KeyPress"
            handler = New KeyPressEventHandler(Sub(s, e) EventHandler_KeyPressEventArgs(s, e, eventName))
          Case "KeyUp"
            handler = New KeyEventHandler(Sub(s, e) EventHandler_KeyEventArgs(s, e, eventName))
          Case "Layout"
          Case "MouseClick"
            handler = New MouseEventHandler(Sub(s, e) EventHandler_MouseEventArgs(s, e, eventName))
          Case "MouseDoubleClick"
            handler = New MouseEventHandler(Sub(s, e) EventHandler_MouseEventArgs(s, e, eventName))
          Case "MouseDown"
            handler = New MouseEventHandler(Sub(s, e) EventHandler_MouseEventArgs(s, e, eventName))
          Case "MouseMove"
            handler = New MouseEventHandler(Sub(s, e) EventHandler_MouseEventArgs(s, e, eventName))
          Case "MouseUp"
            handler = New MouseEventHandler(Sub(s, e) EventHandler_MouseEventArgs(s, e, eventName))
          Case "MouseWheel"
            handler = New MouseEventHandler(Sub(s, e) EventHandler_MouseEventArgs(s, e, eventName))
          Case "PreviewKeyDown"
          Case "ChangeUICues"
            handler = New UICuesEventHandler(Sub(s, e) EventHandler_UICuesEventArgs(s, e, eventName))
          Case "Validating"
          Case Else
            handler = New EventHandler(Sub(s, e) EventHandler_EventArgs(s, e, eventName))
        End Select
        If handler IsNot Nothing Then
          Dim addHandlerMethod As MethodInfo = ev.GetAddMethod()
          Try
            addHandlerMethod.Invoke(ctl, {handler})
            dynamicEvent.Add(ev)
            dynamicEventHandlers.Add(handler)
          Catch ex As Exception
            Debug.Print("Failed to add handler for event: {0}.{1}", ctl.Name, ev.Name)
          End Try
        End If
      End If
    Next
    If ctl IsNot Nothing Then
      btnAttach.Text = CTL_RELEASE
      prop.SelectedObject = ctl
      prop.Enabled = True
    End If
  End Sub

  Private Sub btnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
    If btnAttach.Text.Equals(CTL_ATTACH) Then
      If tabs.SelectedTab.Controls.Count > 0 Then
        attachControl(tabs.SelectedTab.Controls(0))
      End If
    Else
      detachControl()
    End If
  End Sub

  Private Sub btnClearEvents_Click(sender As Object, e As EventArgs) Handles btnClearEvents.Click
    listEvents.Items.Clear()
  End Sub

  Private Sub detachControl()
    If ctl IsNot Nothing Then
      ' Loop through each event and dynamically add a handler
      For i As Integer = 0 To dynamicEvent.Count - 1
        Dim ev As EventInfo = dynamicEvent.Item(i)
        Dim eventName As String = ev.Name
        Dim handler As Object = dynamicEventHandlers.Item(i)
        Dim removeHandlerMethod As MethodInfo = ev.GetRemoveMethod
        Try
          removeHandlerMethod.Invoke(ctl, {handler})
        Catch ex As Exception
          Debug.Print("Failed to remove handler for event: {0}.{1}", ctl.Name, ev.Name)
        End Try
      Next
    End If
    ctl = Nothing
    dynamicEventHandlers = New List(Of Object)
    dynamicEvent = New List(Of EventInfo)
    prop.SelectedObject = Nothing
    prop.Enabled = False
    btnAttach.Text = CTL_ATTACH
  End Sub

  Private Sub EventHandler_EventArgs(sender As Object, e As EventArgs, eventName As String)
    LogEvent(eventName, e.ToString)
  End Sub

  Private Sub EventHandler_FlatSearch(sender As Object, e As FlatSearchEventArgs, eventname As String)
    If e.IsCanceled Then
      LogEvent(eventname, "Canceled[true]")
    Else
      LogEvent(eventname, "Criteria[" & e.Criteria & "]")
    End If
  End Sub

  Private Sub EventHandler_KeyEventArgs(sender As Object, e As KeyEventArgs, eventName As String)
    Dim sb As New StringBuilder
    If e.Control Then sb.Append("Ctl")
    If e.Alt Then
      If sb.Length > 0 Then sb.Append("+")
      sb.Append("Alt")
    End If
    If e.Shift Then
      If sb.Length > 0 Then sb.Append("+")
      sb.Append("Shft")
    End If
    If e.KeyCode <> Keys.Control And e.KeyCode <> Keys.Alt And e.KeyCode <> Keys.Shift Then
      If sb.Length > 0 Then sb.Append("+")
      sb.Append(e.KeyCode.ToString)
    End If
    LogEvent(eventName, sb.ToString)
  End Sub

  Private Sub EventHandler_KeyPressEventArgs(sender As Object, e As KeyPressEventArgs, eventName As String)
    LogEvent(eventName, "Key[" & e.KeyChar & "]")
  End Sub

  Private Sub EventHandler_MouseEventArgs(sender As Object, e As MouseEventArgs, eventName As String)
    LogEvent(eventName, e.Button.ToString & " " & e.Location.ToString)
  End Sub

  Private Sub EventHandler_UICuesEventArgs(sender As Object, e As UICuesEventArgs, eventName As String)
    LogEvent(eventName, "ChangeFocus: " & e.ChangeFocus)
  End Sub

  Private Sub frmTestFlatControls_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
    detachControl()
  End Sub

  Private Sub frmTestFlatControls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    detachControl()
    For Each tab As TabPage In tabs.TabPages
      If tab.Controls.Count > 0 Then
        tab.Text = tab.Controls.Item(0).GetType.Name
      End If
    Next
  End Sub

  Private Sub LogEvent(eventName As String, Optional args As String = "")
    Dim item As New ListViewItem(listEvents.Items.Count.ToString.PadLeft(4, "0"c))
    item.SubItems.Add(eventName)
    item.SubItems.Add(args)
    listEvents.Items().Add(item)
  End Sub

#End Region

End Class