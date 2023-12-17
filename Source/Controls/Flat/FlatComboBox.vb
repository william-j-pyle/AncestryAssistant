Public Class FlatComboBox
  Inherits ComboBox

  Public Sub New()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SetStyle(ControlStyles.Selectable, False)
    DrawMode = DrawMode.OwnerDrawFixed
    DoubleBuffered = True
    DropDownStyle = ComboBoxStyle.DropDownList
    FlatStyle = FlatStyle.Popup
    Font = My.Theme.RibbonBarFont
    BackColor = My.Theme.RibbonShadowColor
    ForeColor = My.Theme.RibbonForeColor
  End Sub

End Class