Public Class RILabel
  Inherits RibbonItem

#Region "Fields"

  Private ctl As Label

  Private textImageOffset As Integer = 0

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
    ctl = New Label With {
      .BackColor = BackColor,
      .ForeColor = ForeColor,
      .Font = Font,
      .Dock = DockStyle.Fill,
      .AutoSize = False,
      .TextAlign = ContentAlignment.MiddleLeft,
      .Padding = New Padding(0),
      .Margin = New Padding(0)
    }
    Controls.Add(ctl)
  End Sub

#End Region

#Region "Public Methods"

  Public Overrides Function GetAttribute(ItemAttribute As RibbonItemAttribute) As Object
    Throw New NotImplementedException()
  End Function

  Public Overrides Sub SetAttribute(ItemAttribute As RibbonItemAttribute, attributeValue As Object)
    Select Case ItemAttribute
      Case RibbonItemAttribute.ImageFromResource
        Dim Img As Image = My.Resources.ResourceManager.GetObject(attributeValue)
        Debug.Print("ImageFromResource:  Img.width={0}", Img.Width)
        Debug.Print("ImageFromResource:  text.MeasureSpace.width={0}", TextRenderer.MeasureText(" ", ctl.Font).Width)

        textImageOffset = CInt(img.Width / TextRenderer.MeasureText(" ", ctl.Font).Width) * 3
        Debug.Print("ImageFromResource:  TextImageOffset={0}", textImageOffset)

        ctl.ImageAlign = ContentAlignment.MiddleLeft
        ctl.TextAlign = ContentAlignment.MiddleLeft
        ctl.Image = Img
        ctl.Text = " ".PadLeft(textImageOffset, " "c) + ctl.Text
        Debug.Print("ImageFromResource:  Img.test=[{0}]", ctl.Text)

      Case RibbonItemAttribute.ImageAlign
        ctl.ImageAlign = CType(attributeValue, ContentAlignment)
      Case RibbonItemAttribute.Text
        If textImageOffset > 0 Then
          ctl.Text = " ".PadLeft(textImageOffset, " "c) + attributeValue
        Else
          ctl.Text = attributeValue
        End If
      Case RibbonItemAttribute.Enabled
        ctl.Enabled = CType(attributeValue, Boolean)
      Case RibbonItemAttribute.TextAlign
        ctl.TextAlign = CType(attributeValue, ContentAlignment)
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", ItemAttribute.ToString, attributeValue)
    End Select
  End Sub

#End Region

End Class