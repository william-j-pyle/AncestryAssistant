Public Class RIButton
  Inherits RibbonItem

#Region "Fields"

  Private WithEvents ctl As FlatIconButton

#End Region

#Region "Properties"

  Public Property Image As Image
    Get
      Return ctl.Image
    End Get
    Set(value As Image)
      ctl.Image = value
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    ctl = New FlatIconButton With {
      .Dock = DockStyle.Fill,
      .BackColor = BackColor,
      .Font = My.Theme.RibbonButtonFont,
      .ForeColor = ForeColor
    }
    Controls.Add(ctl)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub ctl_Click(sender As Object, e As EventArgs) Handles ctl.Click
    OnRibbonItemAction(RibbonEventType.ButtonClick, True)
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Sub SetAttribute(attributeName As String, attributeValue As String)
    Select Case attributeName.ToLower
      Case "ImageFromFile".ToLower
        Image = ImageFromFile(attributeValue)
      Case "ImageFromResource".ToLower
        Image = ImageFromResource(attributeValue)
      Case "text"
        ctl.Text = attributeValue
      Case "caption"
        ctl.Text = attributeValue
      Case "textalign"
        ctl.TextAlign = AlignStringToEnum(attributeValue)
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", attributeName, attributeValue)
    End Select
  End Sub

#End Region

End Class