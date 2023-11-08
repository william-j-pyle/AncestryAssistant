Public Class ToolBarRenderer
  Inherits ToolStripRenderer

  Public Property ToolBarBackColor As Color = Color.DarkGray
  Public Property ToolBarFontColor As Color = Color.WhiteSmoke
  Public Property ToolBarBorderColor As Color = Color.DarkSlateGray
  Public Property ToolBarAccentColor As Color = ColorToAccent(ToolBarBorderColor)
  Public Property ToolBarShadowColor As Color = ColorToShadow(ToolBarBorderColor)
  Public Property ToolBarHighlightColor As Color = Color.LimeGreen

  Public Sub New()
    MyBase.New()
  End Sub

  Private Sub ToolStripRenderer_RenderSeparator(sender As Object, e As ToolStripSeparatorRenderEventArgs) Handles Me.RenderSeparator
    Debug.Print("RenderSeperator: {0}", e.Item.Bounds.ToString)
    Using brush As SolidBrush = New SolidBrush(ToolBarAccentColor)
      e.Graphics.FillRectangle(brush, 0 - 2, 0, e.Item.Width + 2, e.Item.Height)
    End Using
    Using pen As Pen = New Pen(ToolBarShadowColor, 1)
      Dim y As Single = ((e.Item.ContentRectangle.Y + 1) / 2) + 1
      Dim x As Single = 26
      Dim w As Single = e.Item.Width - 30
      e.Graphics.DrawLine(pen, x, y, w, y)
    End Using
  End Sub



  'Private Sub ToolStripRenderer_RenderToolStripBorder(sender As Object, e As ToolStripRenderEventArgs) Handles Me.RenderToolStripBorder

  '  If e.ConnectedArea.IsEmpty Then
  '    'ConnectedArea is all 0 then this is just normal borders
  '    Using pen As Pen = New Pen(ToolBarBackColor, 2)
  '      e.Graphics.DrawRectangle(pen, e.AffectedBounds)
  '    End Using
  '  Else
  '    'we are working with a drop down! Need to be all special
  '    Using brush As SolidBrush = New SolidBrush(ToolBarAccentColor)
  '      e.Graphics.FillRectangle(brush, e.ConnectedArea)
  '    End Using
  '    Using pen As Pen = New Pen(ToolBarShadowColor, 1)
  '      'LEFT OF Connected Area
  '      e.Graphics.DrawLine(pen, 0, 0, 0, e.ConnectedArea.Height - 1)
  '      'RIGHT OF Connected Area
  '      e.Graphics.DrawLine(pen, e.ConnectedArea.Width - 1, 0, e.ConnectedArea.Width - 1, e.ConnectedArea.Height - 1)
  '      'TOP OF Affected (starts at end of connectedarea opening thru end of affectedbounds
  '      e.Graphics.DrawLine(pen, e.ConnectedArea.Width, 0, e.AffectedBounds.Width - 1, 0)
  '      'LEFT of Affected
  '      e.Graphics.DrawLine(pen, 0, 0, 0, e.AffectedBounds.Height - 1)
  '      'Right of Affected
  '      e.Graphics.DrawLine(pen, e.AffectedBounds.Width - 1, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1)
  '      'Bottom of affected
  '      e.Graphics.DrawLine(pen, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1)
  '    End Using
  '  End If
  'End Sub


  Private Sub ToolBarRenderer_RenderItemBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderItemBackground
    Debug.Print("ToolBarRenderer_RenderItemBackground: {0}", e.Item.Bounds.ToString)
    Using brush As SolidBrush = New SolidBrush(e.Item.BackColor)
      e.Graphics.FillRectangle(brush, e.Item.Bounds)
    End Using
    e.Graphics.DrawRectangle(New Pen(ToolBarAccentColor, 1), e.Item.Bounds)
  End Sub

  Private Sub ToolBarRenderer_RenderLabelBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderLabelBackground
    Debug.Print("ToolBarRenderer_RenderLabelBackground: {0}", e.Item.Bounds.ToString)

  End Sub

  Private Sub ToolBarRenderer_RenderMenuItemBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderMenuItemBackground
    Debug.Print("ToolBarRenderer_RenderMenuItemBackground: {0}", e.Item.Bounds.ToString)

  End Sub

  Private Sub ToolBarRenderer_RenderSplitButtonBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderSplitButtonBackground
    Debug.Print("ToolBarRenderer_RenderSplitButtonBackground: {0}", e.Item.Bounds.ToString)

  End Sub

  Private Sub ToolBarRenderer_RenderToolStripBorder(sender As Object, e As ToolStripRenderEventArgs) Handles Me.RenderToolStripBorder
    Debug.Print("ToolBarRenderer_RenderToolStripBorder: {0}", e.AffectedBounds.ToString)

  End Sub



  Private Sub ToolBarRenderer_RenderToolStripStatusLabelBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderToolStripStatusLabelBackground
    Debug.Print("ToolBarRenderer_RenderToolStripBackground: {0}", e.Item.Bounds.ToString)

  End Sub

  Private Sub ToolBarRenderer_RenderToolStripBackground(sender As Object, e As ToolStripRenderEventArgs) Handles Me.RenderToolStripBackground
    Debug.Print("ToolBarRenderer_RenderToolStripBackground: {0}", e.AffectedBounds.ToString)

  End Sub

  Private Sub ToolBarRenderer_RenderStatusStripSizingGrip(sender As Object, e As ToolStripRenderEventArgs) Handles Me.RenderStatusStripSizingGrip
    Debug.Print("ToolBarRenderer_RenderStatusStripSizingGrip: {0}", e.AffectedBounds.ToString)

  End Sub

  Private Sub ToolBarRenderer_RenderItemText(sender As Object, e As ToolStripItemTextRenderEventArgs) Handles Me.RenderItemText
    Debug.Print("ToolBarRenderer_RenderItemText: {0}", e.Item.Bounds.ToString)

  End Sub

  Private Sub ToolBarRenderer_RenderItemImage(sender As Object, e As ToolStripItemImageRenderEventArgs) Handles Me.RenderItemImage
    Debug.Print("ToolBarRenderer_RenderItemImage: {0}", e.Item.Bounds.ToString)

  End Sub

  Private Sub ToolBarRenderer_RenderItemCheck(sender As Object, e As ToolStripItemImageRenderEventArgs) Handles Me.RenderItemCheck
    Debug.Print("ToolBarRenderer_RenderItemCheck: {0}", e.Item.Bounds.ToString)

  End Sub

  Private Sub ToolBarRenderer_RenderGrip(sender As Object, e As ToolStripGripRenderEventArgs) Handles Me.RenderGrip
    Debug.Print("ToolBarRenderer_RenderGrip: {0}", e.AffectedBounds.ToString)

  End Sub

  Private Sub ToolBarRenderer_RenderArrow(sender As Object, e As ToolStripArrowRenderEventArgs) Handles Me.RenderArrow
    Debug.Print("ToolBarRenderer_RenderArrow: {0}", e.Item.Bounds.ToString)

  End Sub
End Class