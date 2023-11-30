Public Class FlatIconButton
  Inherits Button

#Region "Properties"

  Public Property Icon As Image
    Get
      Return Image
    End Get
    Set(value As Image)
      Image = value
    End Set
  End Property

  Public Overrides Property Text As String
    Get
      Return String.Empty
    End Get
    Set(value As String)
      'NOOP
    End Set
  End Property

#End Region

#Region "Public Constructors"

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
  End Sub

#End Region

End Class