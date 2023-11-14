Imports System.ComponentModel
Public Class ToolBar
  Inherits System.Windows.Forms.ToolStrip

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
  Private components As System.ComponentModel.IContainer

  Private theme As UITheme = UITheme.GetInstance

  Public Sub New()
    MyBase.New()
    components = New System.ComponentModel.Container()
    Renderer = New ToolbarRenderer2()
    'MyBase.BackColor = theme.PanelBackColor
    'MyBase.ForeColor = theme.PanelFontColor
  End Sub

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BackColor As Color

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property RenderMode As ToolStripRenderMode


End Class
