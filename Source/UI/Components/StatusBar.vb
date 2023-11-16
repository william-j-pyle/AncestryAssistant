Imports System.ComponentModel

Public Class StatusBar

#Region "Properties"

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BackColor As Color

#End Region

#Region "Public Constructors"

  Public Sub New()
    InitializeComponent()
    MyBase.BackColor = My.Theme.PanelBackColor
    MyBase.ForeColor = My.Theme.PanelFontColor
  End Sub

#End Region

End Class