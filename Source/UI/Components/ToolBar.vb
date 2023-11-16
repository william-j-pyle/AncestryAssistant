Imports System.ComponentModel

Public Class ToolBar
  Inherits System.Windows.Forms.ToolStrip

#Region "Properties"

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BackColor As Color

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property RenderMode As ToolStripRenderMode

#End Region

#Region "Public Constructors"

  Public Sub New()
    MyBase.New()
    components = New System.ComponentModel.Container()
    Renderer = New ToolbarRenderer2()
    'MyBase.BackColor = My.Theme.PanelBackColor
    'MyBase.ForeColor = My.Theme.PanelFontColor
  End Sub

#End Region

#Region "Protected Methods"

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

#End Region

#Region "Fields"

  Private components As System.ComponentModel.IContainer

#End Region

End Class