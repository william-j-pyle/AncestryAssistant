Public Class RIButton
  Inherits RibbonItem

#Region "Fields"

  Private WithEvents btn As FlatIconButton

#End Region

#Region "Properties"

  Public Property Image As Image
    Get
      Return btn.Image
    End Get
    Set(value As Image)
      btn.Image = value
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    btn = New FlatIconButton With {
      .Dock = DockStyle.Fill,
      .BackColor = BackColor,
      .Font = Font,
      .ForeColor = ForeColor
    }
    Controls.Add(btn)
  End Sub

#End Region

End Class