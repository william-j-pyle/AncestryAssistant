Public Class ResizeDragHandler
  Private WithEvents frm As Form
  Private capturedControls As ArrayList

  Private ResizeHandleSize As Integer = 4

  Private MouseX As Integer
  Private MouseY As Integer

  Private FormInitialX As Integer
  Private FormInitialY As Integer
  Private FormInitialWidth As Integer
  Private FormInitialHeight As Integer
  Private FormResizeWidthFlag As Integer
  Private FormResizeHeightFlag As Integer
  Private IsFormResizing As Boolean

  Private DragControl As Control
  Private IsFormDragging As Boolean

  Private Enum ResizeEventType
    OnMouseDown
    OnMouseMove
    OnMouseUp
  End Enum

  Public Sub New(targetForm As Form, targetResizeHandleSize As Integer)
    frm = targetForm
    ResizeHandleSize = targetResizeHandleSize
    Initialize()
  End Sub

  Public Sub New(targetForm As Form)
    frm = targetForm
    Initialize()
  End Sub

  Private Sub Initialize()
    capturedControls = New ArrayList
    Dim x As Integer
    Dim y As Integer
    'TOP
    y = CInt(ResizeHandleSize / 2)
    For x = 0 To frm.Width - 1 Step ResizeHandleSize
      captureEvents(frm.GetChildAtPoint(New Point(x, y)))
    Next
    'LEFT and RIGHT
    Dim x1 As Integer = CInt(ResizeHandleSize / 2)
    Dim x2 As Integer = frm.Width - CInt(ResizeHandleSize / 2)
    For y = 0 To frm.Height - 1 Step ResizeHandleSize
      captureEvents(frm.GetChildAtPoint(New Point(x1, y)))
      captureEvents(frm.GetChildAtPoint(New Point(x2, y)))
    Next
    'BOTTOM
    y = frm.Height - CInt(ResizeHandleSize / 2)
    For x = 0 To frm.Width - 1 Step ResizeHandleSize
      captureEvents(frm.GetChildAtPoint(New Point(x, y)))
    Next
  End Sub

  Private Sub captureEvents(ctl As Control)
    If ctl IsNot Nothing Then
      If Not capturedControls.Contains(ctl) Then
        Debug.Print("Capture Events for: {0}", ctl.Name)
        AddHandler ctl.MouseDown, AddressOf FormResizing_MouseDown
        AddHandler ctl.MouseEnter, AddressOf FormResizing_MouseEnter
        AddHandler ctl.MouseLeave, AddressOf FormResizing_MouseLeave
        AddHandler ctl.MouseMove, AddressOf FormResizing_MouseMove
        AddHandler ctl.MouseUp, AddressOf FormResizing_MouseUp
        capturedControls.Add(ctl)
      End If
    End If
  End Sub

  Public Sub SetDragControl(ctl As Control)
    DragControl = ctl
    AddHandler DragControl.MouseDown, AddressOf FormDragging_MouseDown
    AddHandler DragControl.MouseUp, AddressOf FormDragging_MouseUp
    AddHandler DragControl.MouseMove, AddressOf FormDragging_Mousemove
  End Sub
  'Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
  '  'Debug.Print("Timer: Pos({0},{1})  BTN({2})", MousePosition.X, MousePosition.Y, MouseButtons)
  '  If IsFormDragging Then
  '    If MouseButtons = MouseButtons.None Then
  '      jApp_FormDragging("MouseUp")
  '    Else
  '      jApp_FormDragging("MouseMove")
  '    End If
  '  End If
  'End Sub

  Private Sub FormDragging(sender As Object, eventType As ResizeEventType)
    'Debug.Print("jApp_FormDragging: {0}", triggerName)
    Select Case eventType
      Case ResizeEventType.OnMouseDown
        MouseY = sender.MousePosition.Y
        MouseX = sender.MousePosition.X
        FormInitialX = frm.Left
        FormInitialY = frm.Top
        sender.cursor = Cursors.SizeAll
        IsFormDragging = True
        'Timer.Start()
      Case ResizeEventType.OnMouseUp
        'Timer.Stop()
        sender.cursor = Cursors.Default
        IsFormDragging = False
      Case ResizeEventType.OnMouseMove
        frm.Location = New Point(sender.MousePosition.X - MouseX + FormInitialX, sender.MousePosition.Y - MouseY + FormInitialY)
      Case Else
    End Select
  End Sub

  Private Sub FormDragging_MouseDown(sender As Object, e As MouseEventArgs)
    If IsFormResizing Then Exit Sub
    FormDragging(sender, ResizeEventType.OnMouseDown)
  End Sub

  Private Sub FormDragging_MouseUp(sender As Object, e As MouseEventArgs)
    If IsFormDragging Then
      FormDragging(sender, ResizeEventType.OnMouseUp)
    End If
  End Sub

  Private Sub FormDragging_MouseMove(sender As Object, e As MouseEventArgs)
    If IsFormResizing Then Exit Sub
    If IsFormDragging Then
      FormDragging(sender, ResizeEventType.OnMouseMove)
    End If
  End Sub


  Private Sub FormResizingHandler(sender As Object, eventType As ResizeEventType)
    Debug.Print("FormResizingHandler({0}, {7})  Mouse({1},{2})  Form({3},{4},{5},{6})", eventType.ToString, sender.MousePosition.X, sender.MousePosition.Y, frm.Left, frm.Top, frm.Width, frm.Height, sender.name)
    Select Case eventType
      Case ResizeEventType.OnMouseDown
        FormResizing_Initialize(sender)
        IsFormResizing = True
        MouseY = sender.MousePosition.Y
        MouseX = sender.MousePosition.X
        FormInitialX = frm.Left
        FormInitialY = frm.Top
        FormInitialWidth = frm.Width
        FormInitialHeight = frm.Height
      Case ResizeEventType.OnMouseUp
        IsFormResizing = False
      Case ResizeEventType.OnMouseMove
        Dim adjWidth = sender.MousePosition.X - MouseX
        Dim adjHeight = sender.MousePosition.Y - MouseY
        'Only do the adjustment if moved more than 10px
        If Math.Abs(adjWidth) > 10 Then
          Select Case FormResizeWidthFlag
            Case 1
              frm.Width = adjWidth + FormInitialWidth
            Case -1
              With frm
                .SuspendLayout()
                .Width = FormInitialWidth + (adjWidth * -1)
                .Left = FormInitialX + adjWidth
                .ResumeLayout(False)
                .PerformLayout()
              End With
            Case Else
              'NO UPDATE
          End Select
        End If
        'Only do the adjustment if moved more than 10px
        If Math.Abs(adjHeight) > 10 Then
          Select Case FormResizeHeightFlag
            Case 1
              frm.Height = adjHeight + FormInitialHeight
            Case -1
              With frm
                .SuspendLayout()
                .Height = FormInitialHeight + (adjHeight * -1)
                .Top = FormInitialY + adjHeight
                .ResumeLayout(False)
                .PerformLayout()
              End With
            Case Else
              'NO UPDATE
          End Select
        End If
      Case Else

    End Select
    Application.DoEvents()
  End Sub

  Private Sub FormResizing_MouseDown(sender As Object, e As MouseEventArgs)
    If Not IsFormResizing Then
      FormResizingHandler(sender, ResizeEventType.OnMouseDown)
    End If
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

  Private Sub FormResizing_MouseEnter(sender As Object, e As EventArgs)
    If IsFormResizing Then Exit Sub
    FormResizing_Initialize(sender)
  End Sub

  Private Sub FormResizing_MouseLeave(sender As Object, e As EventArgs)
    If IsFormResizing Then Exit Sub
    sender.Cursor = Cursors.Default
  End Sub


  Private Sub FormResizing_Initialize(sender As Object)
    Dim pt As Point = frm.PointToClient(New Point(sender.MousePosition.X, sender.MousePosition.Y))
    'Upper Left
    If pt.X < 10 And pt.Y < 10 Then
      FormResizeWidthFlag = -1
      FormResizeHeightFlag = -1
      sender.Cursor = Cursors.SizeNWSE
      Exit Sub
    End If
    'Lower Right
    If pt.X > frm.Width - 10 And pt.Y > frm.Height - 10 Then
      FormResizeWidthFlag = 1
      FormResizeHeightFlag = 1
      sender.Cursor = Cursors.SizeNWSE
      Exit Sub
    End If
    'Upper Right
    If pt.X > frm.Width - 10 And pt.Y < 10 Then
      FormResizeWidthFlag = 1
      FormResizeHeightFlag = -1
      sender.Cursor = Cursors.SizeNESW
      Exit Sub
    End If
    'Lower Left
    If pt.X < 10 And pt.Y > frm.Height - 10 Then
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
    If pt.Y > frm.Height - 5 Then
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
    If pt.X > frm.Width - 10 Then
      FormResizeWidthFlag = 1
      FormResizeHeightFlag = 0
      sender.Cursor = Cursors.SizeWE
      Exit Sub
    End If
  End Sub


End Class
