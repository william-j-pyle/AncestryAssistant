Public Class FlatIconButton
  Inherits Button

  Public Property Icon As Image
    Get
      Return Image
    End Get
    Set(value As Image)
      Image = value
    End Set
  End Property

  Public Sub New()
    SetStyle(ControlStyles.Selectable, False)
    With FlatAppearance
      .CheckedBackColor = My.Theme.PanelShadowColor
      .BorderSize = 0
      .BorderColor = My.Theme.PanelBorderColor
      .MouseDownBackColor = My.Theme.PanelBorderColor
      .MouseOverBackColor = My.Theme.PanelAccentColor
    End With
    BackColor = My.Theme.PanelBackColor
    ForeColor = My.Theme.PanelFontColor
    FlatStyle = FlatStyle.Flat
    ImageAlign = ContentAlignment.MiddleCenter
    TextAlign = ContentAlignment.BottomCenter
    Font = My.Theme.RibbonButtonFont
    Text = ""
  End Sub

End Class