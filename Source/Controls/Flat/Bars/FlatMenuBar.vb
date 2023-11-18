Imports System.ComponentModel

Public Class FlatMenuBar
  Inherits System.Windows.Forms.MenuStrip

#Region "Properties"

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BackColor As Color

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property RenderMode As ToolStripRenderMode

#End Region

#Region "Public Constructors"

  Public Sub New()
    components = New System.ComponentModel.Container()
    Renderer = New MyRenderer()
    MyBase.BackColor = My.Theme.PanelBorderColor
    MyBase.ForeColor = My.Theme.PanelFontColor
  End Sub

#End Region

#Region "Protected Methods"

  'UserControl overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  Protected Overrides Sub OnPaint(e As PaintEventArgs)
    MyBase.OnPaint(e)
  End Sub

  Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
    MyBase.OnPaintBackground(e)
  End Sub

  Protected Overrides Sub OnPaintGrip(e As PaintEventArgs)
    MyBase.OnPaintGrip(e)
  End Sub

#End Region

#Region "Classes"

  Private Class MyRenderer
    Inherits ToolStripRenderer

#Region "Protected Methods"

    Protected Overrides Sub OnRenderArrow(e As ToolStripArrowRenderEventArgs)
      MyBase.OnRenderArrow(e)
    End Sub

    Protected Overrides Sub OnRenderButtonBackground(e As ToolStripItemRenderEventArgs)
      MyBase.OnRenderButtonBackground(e)
    End Sub

    Protected Overrides Sub OnRenderDropDownButtonBackground(e As ToolStripItemRenderEventArgs)
      MyBase.OnRenderDropDownButtonBackground(e)
    End Sub

    Protected Overrides Sub OnRenderGrip(e As ToolStripGripRenderEventArgs)
      MyBase.OnRenderGrip(e)
    End Sub

    Protected Overrides Sub OnRenderImageMargin(e As ToolStripRenderEventArgs)
      MyBase.OnRenderImageMargin(e)
    End Sub

    Protected Overrides Sub OnRenderItemBackground(e As ToolStripItemRenderEventArgs)
      Using brush As New SolidBrush(e.Item.BackColor)
        e.Graphics.FillRectangle(brush, e.Item.Bounds)
      End Using
      e.Graphics.DrawRectangle(New Pen(My.Theme.PanelAccentColor, 1), e.Item.Bounds)
    End Sub

    Protected Overrides Sub OnRenderItemCheck(e As ToolStripItemImageRenderEventArgs)
      MyBase.OnRenderItemCheck(e)
    End Sub

    Protected Overrides Sub OnRenderItemImage(e As ToolStripItemImageRenderEventArgs)
      MyBase.OnRenderItemImage(e)
    End Sub

    Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
      MyBase.OnRenderItemText(e)
    End Sub

    Protected Overrides Sub OnRenderLabelBackground(e As ToolStripItemRenderEventArgs)
      MyBase.OnRenderLabelBackground(e)
    End Sub

    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
      MyBase.OnRenderMenuItemBackground(e)
    End Sub

    Protected Overrides Sub OnRenderOverflowButtonBackground(e As ToolStripItemRenderEventArgs)
      MyBase.OnRenderOverflowButtonBackground(e)
    End Sub

    Protected Overrides Sub OnRenderSeparator(e As ToolStripSeparatorRenderEventArgs)
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

    Protected Overrides Sub OnRenderSplitButtonBackground(e As ToolStripItemRenderEventArgs)
      MyBase.OnRenderSplitButtonBackground(e)
    End Sub

    Protected Overrides Sub OnRenderStatusStripSizingGrip(e As ToolStripRenderEventArgs)
      MyBase.OnRenderStatusStripSizingGrip(e)
    End Sub

    Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
      MyBase.OnRenderToolStripBackground(e)
    End Sub

    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
      If e.ConnectedArea.IsEmpty Then
        'ConnectedArea is all 0 then this is just normal borders
        Using pen As New Pen(My.Theme.StatusBarBackColor, 2)
          e.Graphics.DrawRectangle(pen, e.AffectedBounds)
        End Using
      Else
        'we are working with a drop down! Need to be all special
        Using brush As New SolidBrush(My.Theme.ColorToAccent(My.Theme.StatusBarBackColor))
          e.Graphics.FillRectangle(brush, e.ConnectedArea)
        End Using
        Using pen As New Pen(My.Theme.ColorToShadow(My.Theme.StatusBarBackColor), 1)
          'LEFT OF Connected Area
          e.Graphics.DrawLine(pen, 0, 0, 0, e.ConnectedArea.Height - 1)
          'RIGHT OF Connected Area
          e.Graphics.DrawLine(pen, e.ConnectedArea.Width - 1, 0, e.ConnectedArea.Width - 1, e.ConnectedArea.Height - 1)
          'TOP OF Affected (starts at end of connectedarea opening thru end of affectedbounds
          e.Graphics.DrawLine(pen, e.ConnectedArea.Width, 0, e.AffectedBounds.Width - 1, 0)
          'LEFT of Affected
          e.Graphics.DrawLine(pen, 0, 0, 0, e.AffectedBounds.Height - 1)
          'Right of Affected
          e.Graphics.DrawLine(pen, e.AffectedBounds.Width - 1, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1)
          'Bottom of affected
          e.Graphics.DrawLine(pen, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1)
        End Using
      End If
    End Sub

    Protected Overrides Sub OnRenderToolStripContentPanelBackground(e As ToolStripContentPanelRenderEventArgs)
      MyBase.OnRenderToolStripContentPanelBackground(e)
    End Sub

    Protected Overrides Sub OnRenderToolStripPanelBackground(e As ToolStripPanelRenderEventArgs)
      MyBase.OnRenderToolStripPanelBackground(e)
    End Sub

    Protected Overrides Sub OnRenderToolStripStatusLabelBackground(e As ToolStripItemRenderEventArgs)
      MyBase.OnRenderToolStripStatusLabelBackground(e)
    End Sub

#End Region

  End Class

#End Region

#Region "Fields"

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

#End Region

End Class