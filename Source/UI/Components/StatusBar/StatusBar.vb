Imports System.ComponentModel
Public Class StatusBar
  Private theme As UITheme = UITheme.GetInstance

  Public Sub New()
    InitializeComponent()
    MyBase.BackColor = theme.PanelBackColor
    MyBase.ForeColor = theme.PanelFontColor
  End Sub

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property BackColor As Color

End Class
