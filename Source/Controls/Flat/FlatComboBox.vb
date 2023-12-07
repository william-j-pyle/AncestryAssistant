Public Class FlatComboBox
  Inherits ComboBox

#Region "Public Constructors"

  Public Sub New()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SetStyle(ControlStyles.Selectable, False)
    Me.DrawMode = DrawMode.OwnerDrawFixed
    Me.DoubleBuffered = True
    Me.DropDownStyle = ComboBoxStyle.DropDownList
    Me.FlatStyle = FlatStyle.Popup
    Me.Font = My.Theme.RibbonBarFont
    Me.BackColor = My.Theme.RibbonShadowColor
    Me.ForeColor = My.Theme.RibbonForeColor
  End Sub

#End Region

End Class