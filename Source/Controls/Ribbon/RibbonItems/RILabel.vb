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

  Public Overrides Sub SetAttribute(attributeName As String, attributeValue As String)
    Select Case attributeName.ToLower
      Case "ImageFromResource".ToLower
        Dim img As Image = My.Resources.ResourceManager.GetObject(attributeValue)
        Debug.Print("ImageFromResource:  Img.width={0}", img.Width)
        Debug.Print("ImageFromResource:  text.MeasureSpace.width={0}", TextRenderer.MeasureText(" ", ctl.Font).Width)

        textImageOffset = CInt(img.Width / TextRenderer.MeasureText(" ", ctl.Font).Width) * 3
        Debug.Print("ImageFromResource:  TextImageOffset={0}", textImageOffset)

        ctl.ImageAlign = ContentAlignment.MiddleLeft
        ctl.TextAlign = ContentAlignment.MiddleLeft
        ctl.Image = img
        ctl.Text = " ".PadLeft(textImageOffset, " "c) + ctl.Text
        Debug.Print("ImageFromResource:  Img.test=[{0}]", ctl.Text)

      Case "imagealign"
        ctl.ImageAlign = AlignStringToEnum(attributeValue)
      Case "text"
        If textImageOffset > 0 Then
          ctl.Text = " ".PadLeft(textImageOffset, " "c) + attributeValue
        Else
          ctl.Text = attributeValue
        End If

      Case "textalign"
        ctl.TextAlign = AlignStringToEnum(attributeValue)
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", attributeName, attributeValue)
    End Select
  End Sub

#End Region

End Class