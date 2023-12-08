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

  Public Overrides Function GetAttribute(attributeName As String) As Object
    Select Case attributeName.ToLower
      Case "Image".ToLower
        Return Image
      Case "text"
        Return ctl.Text
      Case "caption"
        Return ctl.Text
      Case "textalign"
        Return ctl.TextAlign
      Case "enabled"
        Return ctl.Enabled
      Case Else
        Debug.Print("Unhandled Attribute Requested: {0}", attributeName)
    End Select
    Return Nothing
  End Function

  Public Overrides Sub SetAttribute(attributeName As String, attributeValue As Object)
    Select Case attributeName.ToLower
      Case "ImageFromFile".ToLower
        Image = ImageFromFile(CType(attributeValue, String))
      Case "ImageFromResource".ToLower
        Image = ImageFromResource(CType(attributeValue, String))
      Case "Image".ToLower
        Image = CType(attributeValue, Image)
      Case "text"
        ctl.Text = CType(attributeValue, String)
      Case "caption"
        ctl.Text = CType(attributeValue, String)
      Case "textalign"
        ctl.TextAlign = CType(attributeValue, ContentAlignment)
      Case "enabled"
        ctl.Enabled = CType(attributeValue, Boolean)
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", attributeName, attributeValue)
    End Select
  End Sub

#End Region

End Class