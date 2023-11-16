Public Class ToolBarRenderer
  Inherits ToolStripRenderer

#Region "Public Constructors"

  Public Sub New()
    MyBase.New()
  End Sub

#End Region

#Region "Private Methods"

  Private Sub ToolBarRenderer_RenderItemBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderItemBackground
    Using brush As New SolidBrush(e.Item.BackColor)
      e.Graphics.FillRectangle(brush, e.Item.Bounds)
    End Using
    e.Graphics.DrawRectangle(New Pen(My.Theme.PanelAccentColor, 1), e.Item.Bounds)
  End Sub

  Private Sub ToolStripRenderer_RenderSeparator(sender As Object, e As ToolStripSeparatorRenderEventArgs) Handles Me.RenderSeparator
    Using brush As New SolidBrush(My.Theme.PanelAccentColor)
      e.Graphics.FillRectangle(brush, 0 - 2, 0, e.Item.Width + 2, e.Item.Height)
    End Using
    Using pen As New Pen(My.Theme.PanelShadowColor, 1)
      Dim y As Single = ((e.Item.ContentRectangle.Y + 1) / 2) + 1
      Dim x As Single = 26
      Dim w As Single = e.Item.Width - 30
      e.Graphics.DrawLine(pen, x, y, w, y)
    End Using
  End Sub

#End Region

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
End Class