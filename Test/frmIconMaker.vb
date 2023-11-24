Public Class frmIconMaker

#Region "Fields"

  Private Const iconSize As Integer = 32

  Private _ActiveLayer As Integer = 0

#End Region

#Region "Properties"

  Public Property activeLayer As Integer
    Get
      Return _ActiveLayer
    End Get
    Set(value As Integer)
      If _ActiveLayer <> value Then
        lbl1.BackColor = Color.Gray
        lbl2.BackColor = Color.Gray
        lbl3.BackColor = Color.Gray
        lbl4.BackColor = Color.Gray
        _ActiveLayer = value
        Select Case _ActiveLayer
          Case 1
            lbl1.BackColor = Color.Green
          Case 2
            lbl2.BackColor = Color.Green
          Case 3
            lbl3.BackColor = Color.Green
          Case 4
            lbl4.BackColor = Color.Green
        End Select
      End If
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()

    ' This call is required by the designer.
    InitializeComponent()
    InitUI()
    ' Add any initialization after the InitializeComponent() call.

  End Sub

#End Region

#Region "Private Methods"

  Private Sub cmbOutSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOutSize.SelectedIndexChanged
    UpdateUI(sender, e)
  End Sub

  Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
    UpdateUI(sender, e)
  End Sub

  Private Sub IconSelected(sender As Object, e As EventArgs)
    Select Case activeLayer
      Case 1
        ico1.Text = ChrW(sender.tag)
        ico1.Tag = sender.tag
      Case 2
        ico2.Text = ChrW(sender.tag)
        ico2.Tag = sender.tag
      Case 3
        ico3.Text = ChrW(sender.tag)
        ico3.Tag = sender.tag
      Case 4
        ico4.Text = ChrW(sender.tag)
        ico4.Tag = sender.tag
    End Select
    UpdateUI(sender, e)
  End Sub

  Private Sub InitUI()
    'Global
    LoadColorList(ComboBox1, Color.Black)
    LoadSizeList(cmbOutSize, 32)
    AddHandler ComboBox1.SelectedIndexChanged, AddressOf UpdateUI
    'Layer 1
    ico1.Text = ""
    ico1.Tag = ""
    LoadFontList(cmbFont1)
    LoadSizeList(cmbSize1, 32)
    LoadColorList(cmbColor1, Color.White)
    AddHandler chk1.CheckedChanged, AddressOf UpdateUI
    AddHandler cmbFont1.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler cmbSize1.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler cmbColor1.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler NumericUpDown1.ValueChanged, AddressOf UpdateUI
    AddHandler NumericUpDown5.ValueChanged, AddressOf UpdateUI
    'Layer 2
    ico2.Text = ""
    ico2.Tag = ""
    LoadFontList(cmbFont2)
    LoadSizeList(cmbSize2, 32)
    LoadColorList(cmbColor2, Color.White)
    AddHandler chk2.CheckedChanged, AddressOf UpdateUI
    AddHandler cmbFont2.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler cmbSize2.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler cmbColor2.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler NumericUpDown2.ValueChanged, AddressOf UpdateUI
    AddHandler NumericUpDown6.ValueChanged, AddressOf UpdateUI
    'Layer 3
    ico3.Text = ""
    ico3.Tag = ""
    LoadFontList(cmbFont3)
    LoadSizeList(cmbSize3, 32)
    LoadColorList(cmbColor3, Color.White)
    AddHandler chk3.CheckedChanged, AddressOf UpdateUI
    AddHandler cmbFont3.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler cmbSize3.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler cmbColor3.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler NumericUpDown3.ValueChanged, AddressOf UpdateUI
    AddHandler NumericUpDown7.ValueChanged, AddressOf UpdateUI
    'Layer 4
    ico4.Text = ""
    ico4.Tag = ""
    LoadFontList(cmbFont4)
    LoadSizeList(cmbSize4, 32)
    LoadColorList(cmbColor4, Color.White)
    AddHandler chk4.CheckedChanged, AddressOf UpdateUI
    AddHandler cmbFont4.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler cmbSize4.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler cmbColor4.SelectedIndexChanged, AddressOf UpdateUI
    AddHandler NumericUpDown4.ValueChanged, AddressOf UpdateUI
    AddHandler NumericUpDown8.ValueChanged, AddressOf UpdateUI
  End Sub

  Private Sub Layer1_GotFocus(sender As Object, e As EventArgs) Handles chk1.GotFocus, cmbFont1.GotFocus, cmbSize1.GotFocus, cmbColor1.GotFocus, NumericUpDown1.GotFocus, NumericUpDown5.GotFocus
    activeLayer = 1
  End Sub

  Private Sub Layer2_GotFocus(sender As Object, e As EventArgs) Handles chk2.GotFocus, cmbFont2.GotFocus, cmbSize2.GotFocus, cmbColor2.GotFocus, NumericUpDown2.GotFocus, NumericUpDown6.GotFocus
    activeLayer = 2
  End Sub

  Private Sub Layer3_GotFocus(sender As Object, e As EventArgs) Handles chk3.GotFocus, cmbFont3.GotFocus, cmbSize3.GotFocus, cmbColor3.GotFocus, NumericUpDown3.GotFocus, NumericUpDown7.GotFocus
    activeLayer = 3
  End Sub

  Private Sub Layer4_GotFocus(sender As Object, e As EventArgs) Handles chk4.GotFocus, cmbFont4.GotFocus, cmbSize4.GotFocus, cmbColor4.GotFocus, NumericUpDown4.GotFocus, NumericUpDown8.GotFocus
    activeLayer = 4
  End Sub

  Private Sub LoadColorList(cmb As ComboBox, defColor As Color)
    cmb.DrawMode = DrawMode.OwnerDrawFixed
    AddHandler cmb.DrawItem, AddressOf OnDrawItem
    AddHandler cmb.Paint, AddressOf onPaint
    cmb.Items.Clear()
    Dim colorNames() As String = [Enum].GetNames(GetType(KnownColor))
    Dim elist() As KnownColor = DirectCast([Enum].GetValues(GetType(KnownColor)), KnownColor())
    For Each eitem As KnownColor In elist
      Dim idx As Integer = cmb.Items.Add(New ComboBoxColorItem(Color.FromKnownColor(eitem)))
      If Color.FromKnownColor(eitem).ToArgb = defColor.ToArgb Then
        cmb.SelectedIndex = idx
      End If
    Next
  End Sub

  Private Sub LoadFontList(cmb As ComboBox)
    cmb.Items.Clear()
    cmb.Items.Add("Segoe Fluent Icons")
    cmb.Items.Add("ancestry-icon")

  End Sub

  Private Sub LoadIcons(fontName As String)
    If iconPanel.Controls.Count = 0 Then iconPanel.Tag = ""
    Select Case fontName
      Case "Segoe Fluent Icons"
        If iconPanel.Tag.Equals(fontName) Then Exit Sub
        iconPanel.Controls.Clear()
        iconPanel.Tag = fontName
        Dim elist() As FontSegoeFluentIconsEnum = DirectCast([Enum].GetValues(GetType(FontSegoeFluentIconsEnum)), FontSegoeFluentIconsEnum())
        Dim iconFont As New System.Drawing.Font("Segoe Fluent Icons", iconSize, FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        ' Print out names and values
        For Each eitem As FontSegoeFluentIconsEnum In elist
          Dim name As String = [Enum].GetName(GetType(FontSegoeFluentIconsEnum), eitem)
          Dim value As Integer = CInt(eitem)
          Dim btn As New Button()
          With btn
            .BackColor = Color.LightGray
            .Font = iconFont
            .Size = New Size(48, 48)
            .Text = ChrW(value)
            .Margin = New Padding(8, 8, 8, 8)
            .Padding = New Padding(0)
            .Name = name
            .Tag = value
          End With
          AddHandler btn.Click, AddressOf IconSelected
          iconPanel.Controls.Add(btn)
        Next
      Case "ancestry-icon"
        If iconPanel.Tag.Equals(fontName) Then Exit Sub
        iconPanel.Controls.Clear()
        iconPanel.Tag = fontName
        Dim elist() As FontAncestryIconEnum = DirectCast([Enum].GetValues(GetType(FontAncestryIconEnum)), FontAncestryIconEnum())
        Dim iconFont As New System.Drawing.Font("ancestry-icon", iconSize, FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        ' Print out names and values
        For Each eitem As FontAncestryIconEnum In elist
          Dim name As String = [Enum].GetName(GetType(FontAncestryIconEnum), eitem)
          Dim value As Integer = CInt(eitem)
          Dim btn As New Button()
          With btn
            .BackColor = Color.LightGray
            .Font = iconFont
            .Size = New Size(48, 48)
            .Text = ChrW(value)
            .Padding = New Padding(0)
            .Margin = New Padding(8, 8, 8, 8)
            .Name = name
            .Tag = value
          End With
          AddHandler btn.Click, AddressOf IconSelected
          iconPanel.Controls.Add(btn)
        Next
    End Select
  End Sub

  Private Sub LoadSizeList(cmb As ComboBox, sizeH As Integer)
    cmb.Items.Clear()
    Dim Names() As String = [Enum].GetNames(GetType(IconSizeEnum))
    Dim elist() As IconSizeEnum = DirectCast([Enum].GetValues(GetType(IconSizeEnum)), IconSizeEnum())
    For Each eitem As IconSizeEnum In elist
      Dim idx As Integer = cmb.Items.Add(eitem.ToString().Replace("Icon", ""))
      If eitem = sizeH Then
        cmb.SelectedIndex = idx
      End If
    Next
  End Sub

  Private Sub OnDrawItem(sender As Object, e As DrawItemEventArgs)
    Dim cmb As ComboBox = DirectCast(sender, ComboBox)
    ' Draw the background of the item
    e.DrawBackground()

    If e.Index >= 0 AndAlso e.Index < cmb.Items.Count Then
      ' Get the color from the ComboBox item
      Dim color As Color = DirectCast(cmb.Items(e.Index), ComboBoxColorItem).Color

      ' Draw the color sample and its name
      Using brush As New SolidBrush(color)
        e.Graphics.FillRectangle(brush, e.Bounds.Left + 2, e.Bounds.Top + 2, 20, e.Bounds.Height - 4)
      End Using

      Using textBrush As New SolidBrush(e.ForeColor)
        e.Graphics.DrawString(color.Name, e.Font, textBrush, e.Bounds.Left + 25, e.Bounds.Top + 2)
      End Using
    End If

    ' Draw the focus rectangle if the item has focus
    e.DrawFocusRectangle()
  End Sub

  Private Sub onPaint(sender As Object, e As PaintEventArgs)
    Dim cmb As ComboBox = DirectCast(sender, ComboBox)
    MyBase.OnPaint(e)
    ' Draw the selected color in the ComboBox when it is not dropped down
    If cmb.SelectedIndex >= 0 AndAlso cmb.SelectedIndex < cmb.Items.Count Then
      Dim selectedColor As Color = DirectCast(cmb.Items(cmb.SelectedIndex), ComboBoxColorItem).Color
      Using brush As New SolidBrush(selectedColor)
        e.Graphics.FillRectangle(brush, cmb.ClientRectangle.Right - 25, cmb.ClientRectangle.Top + 2, 20, cmb.ClientRectangle.Height - 4)
      End Using
    End If
  End Sub

  Private Sub picOut_Paint(sender As Object, e As PaintEventArgs) Handles picOut.Paint
    'Render Background
    e.Graphics.FillRectangle(New SolidBrush(CType(ComboBox1.SelectedItem, ComboBoxColorItem).Color), 0, 0, Width, Height)
    'Render Layer 1
    If chk1.Checked And ico1.Text.Length > 0 Then
      Dim font As New System.Drawing.Font(cmbFont1.Text, CInt(cmbSize1.SelectedItem.split("x"c)(0)), FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
      Dim textSize As Size = TextRenderer.MeasureText(ico1.Text, font)
      Dim t As Integer = CInt((picOut.Height - textSize.Height - 1) / 2) + NumericUpDown5.Value
      Dim l As Integer = CInt((picOut.Width - textSize.Width - 1) / 2) + NumericUpDown1.Value
      Debug.Print(textSize.ToString)
      Debug.Print(t)
      Debug.Print(l)
      e.Graphics.DrawString(ico1.Text, font, New SolidBrush(CType(cmbColor1.SelectedItem, ComboBoxColorItem).Color), New Point(l, t))
    End If
    If chk2.Checked And ico2.Text.Length > 0 Then
      Dim font As New System.Drawing.Font(cmbFont2.Text, CInt(cmbSize2.SelectedItem.split("x"c)(0)), FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
      Dim textSize As Size = TextRenderer.MeasureText(ico2.Text, font)
      Dim t As Integer = CInt((picOut.Height - textSize.Height - 1) / 2) + NumericUpDown6.Value
      Dim l As Integer = CInt((picOut.Width - textSize.Width - 1) / 2) + NumericUpDown2.Value
      Debug.Print(textSize.ToString)
      Debug.Print(t)
      Debug.Print(l)
      e.Graphics.DrawString(ico2.Text, font, New SolidBrush(CType(cmbColor2.SelectedItem, ComboBoxColorItem).Color), New Point(l, t))
    End If
    If chk3.Checked And ico3.Text.Length > 0 Then
      Dim font As New System.Drawing.Font(cmbFont3.Text, CInt(cmbSize3.SelectedItem.split("x"c)(0)), FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
      Dim textSize As Size = TextRenderer.MeasureText(ico3.Text, font)
      Dim t As Integer = CInt((picOut.Height - textSize.Height - 1) / 2) + NumericUpDown7.Value
      Dim l As Integer = CInt((picOut.Width - textSize.Width - 1) / 2) + NumericUpDown3.Value
      Debug.Print(textSize.ToString)
      Debug.Print(t)
      Debug.Print(l)
      e.Graphics.DrawString(ico3.Text, font, New SolidBrush(CType(cmbColor3.SelectedItem, ComboBoxColorItem).Color), New Point(l, t))
    End If
    If chk4.Checked And ico4.Text.Length > 0 Then
      Dim font As New System.Drawing.Font(cmbFont4.Text, CInt(cmbSize4.SelectedItem.split("x"c)(0)), FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
      Dim textSize As Size = TextRenderer.MeasureText(ico4.Text, font)
      Dim t As Integer = CInt((picOut.Height - textSize.Height - 1) / 2) + NumericUpDown8.Value
      Dim l As Integer = CInt((picOut.Width - textSize.Width - 1) / 2) + NumericUpDown4.Value
      Debug.Print(textSize.ToString)
      Debug.Print(t)
      Debug.Print(l)
      e.Graphics.DrawString(ico4.Text, font, New SolidBrush(CType(cmbColor4.SelectedItem, ComboBoxColorItem).Color), New Point(l, t))
    End If

  End Sub

  Private Sub UpdateUI(sender As Object, e As EventArgs)
    UpdateUILayer(chk1, cmbFont1, cmbSize1, cmbColor1, ico1, activeLayer = 1)
    UpdateUILayer(chk2, cmbFont2, cmbSize2, cmbColor2, ico2, activeLayer = 2)
    UpdateUILayer(chk3, cmbFont3, cmbSize3, cmbColor3, ico3, activeLayer = 3)
    UpdateUILayer(chk4, cmbFont4, cmbSize4, cmbColor4, ico4, activeLayer = 4)
    If cmbOutSize.SelectedItem Is Nothing Then Exit Sub
    Dim hw As Integer = CInt(cmbOutSize.SelectedItem.split("x"c)(0))
    If picOut.Height <> hw Or picOut.Width <> hw Then
      picOut.Size = New Size(hw, hw)
    End If
    picOut.BackColor = CType(ComboBox1.SelectedItem, ComboBoxColorItem).Color
    picOut.Invalidate()
  End Sub

  Private Sub UpdateUILayer(chk As CheckBox, cmbFont As ComboBox, cmbSize As ComboBox, cmbColor As ComboBox, ico As Label, isActive As Boolean)
    If chk.Checked Then
      If cmbFont.Text.Length > 0 Then
        ico.Font = New System.Drawing.Font(cmbFont.Text, 18, FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
        If isActive Then LoadIcons(cmbFont.Text)
      End If
      ico.Visible = True
      ico.ForeColor = CType(cmbColor.SelectedItem, ComboBoxColorItem).Color
      ico.BackColor = CType(ComboBox1.SelectedItem, ComboBoxColorItem).Color
      If Val(ico.Tag) = 0 Then
        ico.Text = ""
      Else
        ico.Text = ChrW(ico.Tag)
      End If
    Else
      ico.Visible = False
    End If

  End Sub

#End Region

#Region "Classes"

  Class ComboBoxColorItem

#Region "Properties"

    Public Property Color As Color

#End Region

#Region "Public Constructors"

    Public Sub New(color As Color)
      Me.Color = color
    End Sub

#End Region

#Region "Public Methods"

    Public Overrides Function ToString() As String
      Return Color.Name
    End Function

#End Region

  End Class

#End Region

End Class