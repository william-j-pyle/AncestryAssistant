Public Class ToolbarRenderer2
  Inherits ToolStripSystemRenderer

#Region "Private Methods"

  ' Get the color for the specified button state
  Private Function GetButtonColor(state As ButtonState) As Color
    Select Case state
      Case ButtonState.Normal
        Return My.Theme.AppToolbarButtonColor
      Case ButtonState.Hover
        Return My.Theme.AppToolbarButtonHoverColor
      Case ButtonState.Pressed
        Return My.Theme.AppToolbarButtonPressedColor
      Case ButtonState.Disabled
        Return My.Theme.AppToolbarButtonColor
      Case Else
        Return My.Theme.AppToolbarBackColor
    End Select
  End Function

  ' Get the current state of the button
  Private Function GetButtonState(button As ToolStripButton) As ButtonState
    If button.Pressed Then
      Return ButtonState.Pressed
    ElseIf button.Selected Then
      Return ButtonState.Hover
    ElseIf Not button.Enabled Then
      Return ButtonState.Disabled
    Else
      Return ButtonState.Normal
    End If
  End Function

  ' Get the text for the specified button and state
  Private Function GetButtonText(button As ToolStripButton, state As ButtonState) As String
    If buttonText.ContainsKey(button) AndAlso buttonText(button).ContainsKey(state) Then
      Return buttonText(button)(state)
    Else
      Return button.Text
    End If
  End Function

  Private Sub ToolbarRenderer2_RenderArrow(sender As Object, e As ToolStripArrowRenderEventArgs) Handles Me.RenderArrow
    'Debug.Print("ToolbarRenderer2_RenderArrow")
  End Sub

  Private Sub ToolbarRenderer2_RenderButtonBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderButtonBackground
    'Debug.Print("ToolbarRenderer2_RenderButtonBackground")

  End Sub

  Private Sub ToolbarRenderer2_RenderDropDownButtonBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderDropDownButtonBackground
    'Debug.Print("ToolbarRenderer2_RenderDropDownButtonBackground")

  End Sub

  Private Sub ToolbarRenderer2_RenderGrip(sender As Object, e As ToolStripGripRenderEventArgs) Handles Me.RenderGrip
    'Debug.Print("ToolbarRenderer2_RenderGrip")

  End Sub

  Private Sub ToolbarRenderer2_RenderImageMargin(sender As Object, e As ToolStripRenderEventArgs) Handles Me.RenderImageMargin
    'Debug.Print("ToolbarRenderer2_RenderImageMargin")

  End Sub

  Private Sub ToolbarRenderer2_RenderItemBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderItemBackground
    'Debug.Print("ToolbarRenderer2_RenderItemBackground")

  End Sub

  Private Sub ToolbarRenderer2_RenderItemCheck(sender As Object, e As ToolStripItemImageRenderEventArgs) Handles Me.RenderItemCheck
    'Debug.Print("ToolbarRenderer2_RenderItemCheck")

  End Sub

  Private Sub ToolbarRenderer2_RenderItemImage(sender As Object, e As ToolStripItemImageRenderEventArgs) Handles Me.RenderItemImage
    'Debug.Print("ToolbarRenderer2_RenderItemImage")
    Dim button As ToolStripButton = TryCast(e.Item, ToolStripButton)
    If button IsNot Nothing Then
      Dim image As Image = My.Theme.ColorIcon(button.Image, My.Theme.AppToolbarIconColor)
      If image IsNot Nothing Then
        Dim imageRect As New Rectangle(4, 4, button.Width - 8, button.Height - 8)
        e.Graphics.DrawImage(image, imageRect)
      End If
    End If
  End Sub

  Private Sub ToolbarRenderer2_RenderItemText(sender As Object, e As ToolStripItemTextRenderEventArgs) Handles Me.RenderItemText
    'Debug.Print("ToolbarRenderer2_RenderItemText")

  End Sub

  Private Sub ToolbarRenderer2_RenderLabelBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderLabelBackground
    'Debug.Print("ToolbarRenderer2_RenderLabelBackground")

  End Sub

  Private Sub ToolbarRenderer2_RenderMenuItemBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderMenuItemBackground
    'Debug.Print("ToolbarRenderer2_RenderMenuItemBackground")

  End Sub

  Private Sub ToolbarRenderer2_RenderOverflowButtonBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderOverflowButtonBackground
    'Debug.Print("ToolbarRenderer2_RenderOverflowButtonBackground")

  End Sub

  Private Sub ToolbarRenderer2_RenderSeparator(sender As Object, e As ToolStripSeparatorRenderEventArgs) Handles Me.RenderSeparator
    'Debug.Print("ToolbarRenderer2_RenderSeparator")

  End Sub

  Private Sub ToolbarRenderer2_RenderSplitButtonBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderSplitButtonBackground
    'Debug.Print("ToolbarRenderer2_RenderSplitButtonBackground")

  End Sub

  Private Sub ToolbarRenderer2_RenderStatusStripSizingGrip(sender As Object, e As ToolStripRenderEventArgs) Handles Me.RenderStatusStripSizingGrip
    'Debug.Print("ToolbarRenderer2_RenderStatusStripSizingGrip")

  End Sub

  ' Render the background of the toolbar
  Private Sub ToolbarRenderer2_RenderToolStripBackground(sender As Object, e As ToolStripRenderEventArgs) Handles Me.RenderToolStripBackground
    Using brush As New SolidBrush(My.Theme.AppToolbarBackColor)
      e.Graphics.FillRectangle(brush, 0, 0, e.AffectedBounds.Width, e.AffectedBounds.Height)
    End Using

  End Sub

  Private Sub ToolbarRenderer2_RenderToolStripBorder(sender As Object, e As ToolStripRenderEventArgs) Handles Me.RenderToolStripBorder
    'Debug.Print("ToolbarRenderer2_RenderToolStripBorder")

  End Sub

  Private Sub ToolbarRenderer2_RenderToolStripContentPanelBackground(sender As Object, e As ToolStripContentPanelRenderEventArgs) Handles Me.RenderToolStripContentPanelBackground
    'Debug.Print("ToolbarRenderer2_RenderToolStripContentPanelBackground")

  End Sub

  Private Sub ToolbarRenderer2_RenderToolStripPanelBackground(sender As Object, e As ToolStripPanelRenderEventArgs) Handles Me.RenderToolStripPanelBackground
    'Debug.Print("ToolbarRenderer2_RenderToolStripPanelBackground")

  End Sub

  Private Sub ToolbarRenderer2_RenderToolStripStatusLabelBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderToolStripStatusLabelBackground
    'Debug.Print("ToolbarRenderer2_RenderToolStripStatusLabelBackground")

  End Sub

#End Region

#Region "Protected Methods"

  ' Custom rendering for ToolStripButton
  Protected Overrides Sub OnRenderButtonBackground(e As ToolStripItemRenderEventArgs)
    'Debug.Print("OnRender: {0}", e.Item.GetType.ToString)
    Dim button As ToolStripButton = TryCast(e.Item, ToolStripButton)

    If button IsNot Nothing Then
      Dim state As ButtonState = GetButtonState(button)

      ' Choose color based on button state
      Dim backColor As Color = GetButtonColor(state)

      ' Draw button background
      Using brush As New SolidBrush(backColor)
        e.Graphics.FillRectangle(brush, 0, 0, button.Width, button.Height)
      End Using

      ' Draw button text
      Dim text As String = GetButtonText(button, state)
      Dim textColor As Color = If(state = ButtonState.Disabled, SystemColors.ControlDark, button.ForeColor)

      Using textBrush As New SolidBrush(textColor)
        Dim format As New StringFormat With {
            .Alignment = StringAlignment.Center,
            .LineAlignment = StringAlignment.Center
        }
        e.Graphics.DrawString(text, button.Font, textBrush, e.Item.ContentRectangle, format)
      End Using
    Else
      'MyBase.OnRenderButtonBackground(e)
    End If
  End Sub

#End Region

#Region "Public Methods"

  ' Method to set text for a button in a specific state
  Public Sub SetButtonText(button As ToolStripButton, state As ButtonState, text As String)
    If Not buttonText.ContainsKey(button) Then
      buttonText.Add(button, New Dictionary(Of ButtonState, String)())
    End If

    buttonText(button)(state) = text
  End Sub

#End Region

#Region "Enums"

  ' Define button states
  Enum ButtonState
    Normal
    Hover
    Pressed
    Disabled
  End Enum

#End Region

#Region "Fields"

  ' Dictionary to store button text for each state
  Private buttonText As New Dictionary(Of ToolStripButton, Dictionary(Of ButtonState, String))

#End Region

End Class