Partial Class AssistantAppForm

  Private ReadOnly ResizeHandleSize As Integer = 4

  Private capturedControls As ArrayList

  Private DragControl As Control

  Private FormInitialHeight As Integer

  Private FormInitialWidth As Integer

  Private FormInitialX As Integer

  Private FormInitialY As Integer

  Private FormResizeHeightFlag As Integer

  Private FormResizeWidthFlag As Integer

  Private IsFormDragging As Boolean

  Private IsFormResizing As Boolean

  Private MouseX As Integer

  Private MouseY As Integer

  Private Sub captureEvents(ctl As Control)
    If ctl IsNot Nothing Then
      If Not capturedControls.Contains(ctl) Then
        AddHandler ctl.MouseDown, AddressOf FormResizing_MouseDown
        AddHandler ctl.MouseEnter, AddressOf FormResizing_MouseEnter
        AddHandler ctl.MouseLeave, AddressOf FormResizing_MouseLeave
        AddHandler ctl.MouseMove, AddressOf FormResizing_MouseMove
        AddHandler ctl.MouseUp, AddressOf FormResizing_MouseUp
        capturedControls.Add(ctl)
      End If
    End If
  End Sub

  Private Sub FormDragging(sender As Object, eventType As ResizeEventType)
    Select Case eventType
      Case ResizeEventType.OnMouseDown
        MouseY = sender.MousePosition.Y
        MouseX = sender.MousePosition.X
        FormInitialX = Left
        FormInitialY = Top
        sender.cursor = Cursors.SizeAll
        IsFormDragging = True
      Case ResizeEventType.OnMouseUp
        sender.cursor = Cursors.Default
        IsFormDragging = False
      Case ResizeEventType.OnMouseMove
        Location = New Point(sender.MousePosition.X - MouseX + FormInitialX, sender.MousePosition.Y - MouseY + FormInitialY)
      Case Else
    End Select
  End Sub

  Private Sub FormDragging_MouseDown(sender As Object, e As MouseEventArgs)
    If IsFormResizing Then Exit Sub
    FormDragging(sender, ResizeEventType.OnMouseDown)
  End Sub

  Private Sub FormDragging_MouseMove(sender As Object, e As MouseEventArgs)
    If IsFormResizing Then Exit Sub
    If IsFormDragging Then
      FormDragging(sender, ResizeEventType.OnMouseMove)
    End If
  End Sub

  Private Sub FormDragging_MouseUp(sender As Object, e As MouseEventArgs)
    If IsFormDragging Then
      FormDragging(sender, ResizeEventType.OnMouseUp)
    End If
  End Sub

  Private Sub FormResizing_Initialize(sender As Object)
    Dim pt As Point = PointToClient(New Point(sender.MousePosition.X, sender.MousePosition.Y))
    'Upper Left
    If pt.X < 10 And pt.Y < 10 Then
      FormResizeWidthFlag = -1
      FormResizeHeightFlag = -1
      sender.Cursor = Cursors.SizeNWSE
      Exit Sub
    End If
    'Lower Right
    If pt.X > Width - 10 And pt.Y > Height - 10 Then
      FormResizeWidthFlag = 1
      FormResizeHeightFlag = 1
      sender.Cursor = Cursors.SizeNWSE
      Exit Sub
    End If
    'Upper Right
    If pt.X > Width - 10 And pt.Y < 10 Then
      FormResizeWidthFlag = 1
      FormResizeHeightFlag = -1
      sender.Cursor = Cursors.SizeNESW
      Exit Sub
    End If
    'Lower Left
    If pt.X < 10 And pt.Y > Height - 10 Then
      FormResizeWidthFlag = -1
      FormResizeHeightFlag = 1
      sender.Cursor = Cursors.SizeNESW
      Exit Sub
    End If
    'Top Bar
    If pt.Y < 5 Then
      FormResizeWidthFlag = 0
      FormResizeHeightFlag = -1
      sender.Cursor = Cursors.SizeNS
      Exit Sub
    End If
    'Lower Bar
    If pt.Y > Height - 5 Then
      FormResizeWidthFlag = 0
      FormResizeHeightFlag = 1
      sender.Cursor = Cursors.SizeNS
      Exit Sub
    End If
    'Left Bar
    If pt.X < 10 Then
      FormResizeWidthFlag = -1
      FormResizeHeightFlag = 0
      sender.Cursor = Cursors.SizeWE
      Exit Sub
    End If
    'Right Bar
    If pt.X > Width - 10 Then
      FormResizeWidthFlag = 1
      FormResizeHeightFlag = 0
      sender.Cursor = Cursors.SizeWE
      Exit Sub
    End If
  End Sub

  Private Sub FormResizing_MouseDown(sender As Object, e As MouseEventArgs)
    If Not IsFormResizing Then
      FormResizingHandler(sender, ResizeEventType.OnMouseDown)
    End If
  End Sub

  Private Sub FormResizing_MouseEnter(sender As Object, e As EventArgs)
    If IsFormResizing Then Exit Sub
    FormResizing_Initialize(sender)
  End Sub

  Private Sub FormResizing_MouseLeave(sender As Object, e As EventArgs)
    If IsFormResizing Then Exit Sub
    sender.Cursor = Cursors.Default
  End Sub

  Private Sub FormResizing_MouseMove(sender As Object, e As MouseEventArgs)
    If IsFormResizing Then
      FormResizingHandler(sender, ResizeEventType.OnMouseMove)
    End If
  End Sub

  Private Sub FormResizing_MouseUp(sender As Object, e As MouseEventArgs)
    If IsFormResizing Then
      FormResizingHandler(sender, ResizeEventType.OnMouseUp)
    End If
  End Sub

  Private Sub FormResizingHandler(sender As Object, eventType As ResizeEventType)
    Select Case eventType
      Case ResizeEventType.OnMouseDown
        FormResizing_Initialize(sender)
        IsFormResizing = True
        MouseY = sender.MousePosition.Y
        MouseX = sender.MousePosition.X
        FormInitialX = Left
        FormInitialY = Top
        FormInitialWidth = Width
        FormInitialHeight = Height
      Case ResizeEventType.OnMouseUp
        IsFormResizing = False
      Case ResizeEventType.OnMouseMove
        Dim adjWidth As Integer = sender.MousePosition.X - MouseX
        Dim adjHeight As Integer = sender.MousePosition.Y - MouseY
        If Math.Abs(adjWidth) > 10 Then
          Select Case FormResizeWidthFlag
            Case 1
              Width = adjWidth + FormInitialWidth
            Case -1
              SuspendLayout()
              Width = FormInitialWidth + (adjWidth * -1)
              Left = FormInitialX + adjWidth
              ResumeLayout(False)
              PerformLayout()
          End Select
        End If
        If Math.Abs(adjHeight) > 10 Then
          Select Case FormResizeHeightFlag
            Case 1
              Height = adjHeight + FormInitialHeight
            Case -1
              SuspendLayout()
              Height = FormInitialHeight + (adjHeight * -1)
              Top = FormInitialY + adjHeight
              ResumeLayout(False)
              PerformLayout()
          End Select
        End If
    End Select
    Application.DoEvents()
  End Sub

  Private Sub InitResizeDragHandler() Handles Me.InitUIExtensions
    Dim x As Integer, y As Integer, x1 As Integer, x2 As Integer

    ' Init the FormExtensions to make this a borderless form
    DragControl = AppTitle
    AddHandler DragControl.MouseDown, AddressOf FormDragging_MouseDown
    AddHandler DragControl.MouseUp, AddressOf FormDragging_MouseUp
    AddHandler DragControl.MouseMove, AddressOf FormDragging_MouseMove

    capturedControls = New ArrayList
    'TOP
    y = CInt(ResizeHandleSize / 2)
    For x = 0 To Width - 1 Step ResizeHandleSize
      captureEvents(GetChildAtPoint(New Point(x, y)))
    Next
    'LEFT and RIGHT
    x1 = CInt(ResizeHandleSize / 2)
    x2 = Width - CInt(ResizeHandleSize / 2)
    For y = 0 To Height - 1 Step ResizeHandleSize
      captureEvents(GetChildAtPoint(New Point(x1, y)))
      captureEvents(GetChildAtPoint(New Point(x2, y)))
    Next
    'BOTTOM
    y = Height - CInt(ResizeHandleSize / 2)
    For x = 0 To Width - 1 Step ResizeHandleSize
      captureEvents(GetChildAtPoint(New Point(x, y)))
    Next

  End Sub

End Class