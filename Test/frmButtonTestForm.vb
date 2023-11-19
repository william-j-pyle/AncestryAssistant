Imports System.Text

Public Class frmButtonTestForm

#Region "Fields"

  Private Const iconSize As Integer = 32

#End Region

#Region "Private Methods"

  Private Sub btnExportStyle_Click(sender As Object, e As EventArgs) Handles btnExportStyle.Click
    Dim sb As New StringBuilder
    sb.Append("BackClickColor:" & preview.BackClickColor.ToArgb)
    sb.Append(",BackColor:" & preview.BackColor.ToArgb)
    sb.Append(",BackHoverColor:" & preview.BackHoverColor.ToArgb)
    sb.Append(",BorderBottomColor:" & preview.BorderBottomColor.ToArgb)
    sb.Append(",BorderLeftColor:" & preview.BorderLeftColor.ToArgb)
    sb.Append(",BorderRightColor:" & preview.BorderRightColor.ToArgb)
    sb.Append(",BorderTopColor:" & preview.BorderTopColor.ToArgb)
    sb.Append(",ButtonSize:" & preview.ButtonSize)
    sb.Append(",Checked:" & preview.Checked)
    sb.Append(",CheckOnClick:" & preview.CheckOnClick)
    sb.Append(",Enabled:" & preview.Enabled)
    sb.Append(",IconAncestry0:" & preview.IconAncestry0)
    sb.Append(",IconAncestry0_Bold:" & preview.IconAncestry0_Bold)
    sb.Append(",IconAncestry0_DisabledForeColor:" & preview.IconAncestry0_DisabledForeColor.ToArgb)
    sb.Append(",IconAncestry0_Forecolor:" & preview.IconAncestry0_Forecolor.ToArgb)
    sb.Append(",IconAncestry0_HoverForeColor:" & preview.IconAncestry0_HoverForeColor.ToArgb)
    sb.Append(",IconAncestry0_Size:" & preview.IconAncestry0_Size)
    sb.Append(",IconAncestry1:" & preview.IconAncestry1)
    sb.Append(",IconAncestry1_Bold:" & preview.IconAncestry1_Bold)
    sb.Append(",IconAncestry1_DisabledForeColor:" & preview.IconAncestry1_DisabledForeColor.ToArgb)
    sb.Append(",IconAncestry1_Forecolor:" & preview.IconAncestry1_Forecolor.ToArgb)
    sb.Append(",IconAncestry1_HoverForeColor:" & preview.IconAncestry1_HoverForeColor.ToArgb)
    sb.Append(",IconAncestry1_Size:" & preview.IconAncestry1_Size)
    sb.Append(",IconSegoe0:" & preview.IconSegoe0)
    sb.Append(",IconSegoe0_Bold:" & preview.IconSegoe0_Bold)
    sb.Append(",IconSegoe0_DisabledForeColor:" & preview.IconSegoe0_DisabledForeColor.ToArgb)
    sb.Append(",IconSegoe0_Forecolor:" & preview.IconSegoe0_Forecolor.ToArgb)
    sb.Append(",IconSegoe0_HoverForeColor:" & preview.IconSegoe0_HoverForeColor.ToArgb)
    sb.Append(",IconSegoe0_Size:" & preview.IconSegoe0_Size)
    sb.Append(",IconSegoe1:" & preview.IconSegoe1)
    sb.Append(",IconSegoe1_Bold:" & preview.IconSegoe1_Bold)
    sb.Append(",IconSegoe1_DisabledForeColor:" & preview.IconSegoe1_DisabledForeColor.ToArgb)
    sb.Append(",IconSegoe1_Forecolor:" & preview.IconSegoe1_Forecolor.ToArgb)
    sb.Append(",IconSegoe1_HoverForeColor:" & preview.IconSegoe1_HoverForeColor.ToArgb)
    sb.Append(",IconSegoe1_Size:" & preview.IconSegoe1_Size)
    sb.Append(",ShowBorder:" & preview.ShowBorder)
    sb.Append(",ShowClick:" & preview.ShowClick)
    sb.Append(",ShowHover:" & preview.ShowHover)
    TextBox1.Text = sb.ToString
  End Sub

  Private Sub btnImportStyle_Click(sender As Object, e As EventArgs) Handles btnImportStyle.Click
    Dim allparams() As String = TextBox1.Text.Split(","c)
    For Each param As String In allparams
      Dim p() As String = param.Split(":"c)
      Dim key As String = p(0)
      Dim val As String = p(1)
      Select Case key
        Case "BackClickColor"
          preview.BackClickColor = Color.FromArgb(CInt(val))
        Case "BackColor"
          preview.BackColor = Color.FromArgb(CInt(val))
        Case "BackHoverColor"
          preview.BackHoverColor = Color.FromArgb(CInt(val))
        Case "BorderBottomColor"
          preview.BorderBottomColor = Color.FromArgb(CInt(val))
        Case "BorderLeftColor"
          preview.BorderLeftColor = Color.FromArgb(CInt(val))
        Case "BorderRightColor"
          preview.BorderRightColor = Color.FromArgb(CInt(val))
        Case "BorderTopColor"
          preview.BorderTopColor = Color.FromArgb(CInt(val))
        Case "ButtonSize"
          preview.ButtonSize = CType(val, IconSizeEnum)
        Case "Checked"
          preview.Checked = Boolean.Parse(val)
        Case "CheckOnClick"
          preview.CheckOnClick = Boolean.Parse(val)
        Case "Enabled"
          preview.Enabled = Boolean.Parse(val)
        Case "IconAncestry0"
          preview.IconAncestry0 = CType(val, FontAncestryIconEnum)
          TA0.Text = [Enum].GetName(GetType(FontAncestryIconEnum), CInt(val))
        Case "IconAncestry0_Bold"
          preview.IconAncestry0_Bold = Boolean.Parse(val)
        Case "IconAncestry0_DisabledForeColor"
          preview.IconAncestry0_DisabledForeColor = Color.FromArgb(CInt(val))
        Case "IconAncestry0_Forecolor"
          preview.IconAncestry0_Forecolor = Color.FromArgb(CInt(val))
        Case "IconAncestry0_HoverForeColor"
          preview.IconAncestry0_HoverForeColor = Color.FromArgb(CInt(val))
        Case "IconAncestry0_Size"
          preview.IconAncestry0_Size = CType(val, IconSizeEnum)
        Case "IconAncestry1"
          preview.IconAncestry1 = CType(val, FontAncestryIconEnum)
          TA1.Text = [Enum].GetName(GetType(FontAncestryIconEnum), CInt(val))
        Case "IconAncestry1_Bold"
          preview.IconAncestry1_Bold = Boolean.Parse(val)
        Case "IconAncestry1_DisabledForeColor"
          preview.IconAncestry1_DisabledForeColor = Color.FromArgb(CInt(val))
        Case "IconAncestry1_Forecolor"
          preview.IconAncestry1_Forecolor = Color.FromArgb(CInt(val))
        Case "IconAncestry1_HoverForeColor"
          preview.IconAncestry1_HoverForeColor = Color.FromArgb(CInt(val))
        Case "IconAncestry1_Size"
          preview.IconAncestry1_Size = CType(val, IconSizeEnum)
        Case "IconSegoe0"
          preview.IconSegoe0 = CType(val, FontSegoeFluentIconsEnum)
          TS0.Text = [Enum].GetName(GetType(FontSegoeFluentIconsEnum), CInt(val))
        Case "IconSegoe0_Bold"
          preview.IconSegoe0_Bold = Boolean.Parse(val)
        Case "IconSegoe0_DisabledForeColor"
          preview.IconSegoe0_DisabledForeColor = Color.FromArgb(CInt(val))
        Case "IconSegoe0_Forecolor"
          preview.IconSegoe0_Forecolor = Color.FromArgb(CInt(val))
        Case "IconSegoe0_HoverForeColor"
          preview.IconSegoe0_HoverForeColor = Color.FromArgb(CInt(val))
        Case "IconSegoe0_Size"
          preview.IconSegoe0_Size = CType(val, IconSizeEnum)
        Case "IconSegoe1"
          preview.IconSegoe1 = CType(val, FontSegoeFluentIconsEnum)
          TS1.Text = [Enum].GetName(GetType(FontSegoeFluentIconsEnum), CInt(val))
        Case "IconSegoe1_Bold"
          preview.IconSegoe1_Bold = Boolean.Parse(val)
        Case "IconSegoe1_DisabledForeColor"
          preview.IconSegoe1_DisabledForeColor = Color.FromArgb(CInt(val))
        Case "IconSegoe1_Forecolor"
          preview.IconSegoe1_Forecolor = Color.FromArgb(CInt(val))
        Case "IconSegoe1_HoverForeColor"
          preview.IconSegoe1_HoverForeColor = Color.FromArgb(CInt(val))
        Case "IconSegoe1_Size"
          preview.IconSegoe1_Size = CType(val, IconSizeEnum)
        Case "ShowBorder"
          preview.ShowBorder = Boolean.Parse(val)
        Case "ShowClick"
          preview.ShowClick = Boolean.Parse(val)
        Case "ShowHover"
          preview.ShowHover = Boolean.Parse(val)

      End Select
    Next
    InitUI()
  End Sub

  Private Sub CA0AdjH_ValueChanged(sender As Object, e As EventArgs) Handles CA0AdjH.ValueChanged
    preview.IconAncestry0_AdjH = CInt(CA0AdjH.Value)
  End Sub

  Private Sub CA0AdjV_ValueChanged(sender As Object, e As EventArgs) Handles CA0AdjV.ValueChanged
    preview.IconAncestry0_AdjV = CInt(CA0AdjV.Value)

  End Sub

  Private Sub CA1AdjH_ValueChanged(sender As Object, e As EventArgs) Handles CA1AdjH.ValueChanged
    preview.IconAncestry1_AdjH = CInt(CA1AdjH.Value)

  End Sub

  Private Sub CA1AdjV_ValueChanged(sender As Object, e As EventArgs) Handles CA1AdjV.ValueChanged
    preview.IconAncestry1_AdjV = CInt(CA1AdjV.Value)

  End Sub

  Private Sub chkChecked_CheckedChanged(sender As Object, e As EventArgs) Handles chkChecked.CheckedChanged
    preview.Checked = chkChecked.Checked

  End Sub

  Private Sub chkCheckOnClick_CheckedChanged(sender As Object, e As EventArgs) Handles chkCheckOnClick.CheckedChanged
    preview.CheckOnClick = chkCheckOnClick.Checked

  End Sub

  Private Sub chkEnabled_CheckedChanged(sender As Object, e As EventArgs) Handles chkEnabled.CheckedChanged
    preview.Enabled = chkEnabled.Checked

  End Sub

  Private Sub chkShowBorders_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowBorders.CheckedChanged
    preview.ShowBorder = chkShowBorders.Checked
  End Sub

  Private Sub chkShowClick_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowClick.CheckedChanged
    preview.ShowClick = chkShowClick.Checked

  End Sub

  Private Sub chkShowHover_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowHover.CheckedChanged
    preview.ShowHover = chkShowHover.Checked

  End Sub

  Private Sub CS0AdjH_ValueChanged(sender As Object, e As EventArgs) Handles CS0AdjH.ValueChanged
    preview.IconSegoe0_AdjH = CInt(CA0AdjH.Value)

  End Sub

  Private Sub CS0AdjV_ValueChanged(sender As Object, e As EventArgs) Handles CS0AdjV.ValueChanged
    preview.IconSegoe0_AdjV = CInt(CA0AdjV.Value)

  End Sub

  Private Sub CS1AdjH_ValueChanged(sender As Object, e As EventArgs) Handles CS1AdjH.ValueChanged
    preview.IconSegoe1_AdjH = CInt(CS1AdjH.Value)

  End Sub

  Private Sub CS1AdjV_ValueChanged(sender As Object, e As EventArgs) Handles CS1AdjV.ValueChanged
    preview.IconSegoe1_AdjV = CInt(CS1AdjV.Value)

  End Sub

  Private Sub dumpControls(ctl As Control)
    For Each mctl As Control In ctl.Controls
      If mctl.Controls.Count > 0 Then dumpControls(mctl)
    Next
  End Sub

  Private Sub frmButtonTestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    InitUI()

    'dumpControls(Me)
  End Sub

  Private Sub IconSelected(sender As Object, e As EventArgs)
    If RS0.Checked Then
      TS0.Text = sender.name
      TS0.Tag = sender.tag
      preview.IconSegoe0 = sender.tag
    End If
    If RS1.Checked Then
      TS1.Text = sender.name
      TS1.Tag = sender.tag
      preview.IconSegoe1 = sender.tag
    End If
    If RA0.Checked Then
      TA0.Text = sender.name
      TA0.Tag = sender.tag
      preview.IconAncestry0 = sender.tag
    End If
    If RA1.Checked Then
      TA1.Text = sender.name
      TA1.Tag = sender.tag
      preview.IconAncestry1 = sender.tag
    End If
  End Sub

  Private Sub InitUI()
    LoadColorList(btnDefault, preview.BackColor)
    LoadColorList(btnHover, preview.BackHoverColor)
    LoadColorList(btnPressed, preview.BackClickColor)
    LoadColorList(CA0Default, preview.IconAncestry0_Forecolor)
    LoadColorList(CA0Hover, preview.IconAncestry0_HoverForeColor)
    LoadColorList(CA0Disabled, preview.IconAncestry0_DisabledForeColor)
    LoadColorList(CA1Default, preview.IconAncestry1_Forecolor)
    LoadColorList(CA1Hover, preview.IconAncestry1_HoverForeColor)
    LoadColorList(CA1Disabled, preview.IconAncestry1_DisabledForeColor)

    LoadColorList(CS0Default, preview.IconSegoe0_Forecolor)
    LoadColorList(CS0Hover, preview.IconSegoe0_HoverForeColor)
    LoadColorList(CS0Disabled, preview.IconSegoe0_DisabledForeColor)
    LoadColorList(CS1Default, preview.IconSegoe1_Forecolor)
    LoadColorList(CS1Hover, preview.IconSegoe1_HoverForeColor)
    LoadColorList(CS1Disabled, preview.IconSegoe1_DisabledForeColor)

    LoadColorList(BLColor, preview.BorderLeftColor)
    LoadColorList(BRColor, preview.BorderRightColor)
    LoadColorList(BTColor, preview.BorderTopColor)
    LoadColorList(BBColor, preview.BorderBottomColor)

    LoadColorList(PreviewBackground, previewPanel.BackColor)

    LoadSizeList(btnSize, preview.ButtonSize)

    LoadSizeList(CA0Size, preview.IconAncestry0_Size)
    LoadSizeList(CA1Size, preview.IconAncestry1_Size)
    LoadSizeList(CS0Size, preview.IconSegoe0_Size)
    LoadSizeList(CS1Size, preview.IconSegoe1_Size)

    LoadBoldList(CA0Bold, preview.IconAncestry0_Bold)
    LoadBoldList(CA1Bold, preview.IconAncestry1_Bold)
    LoadBoldList(CS0Bold, preview.IconSegoe1_Bold)
    LoadBoldList(CS1Bold, preview.IconSegoe1_Bold)

    chkChecked.Checked = preview.Checked
    chkCheckOnClick.Checked = preview.CheckOnClick
    chkEnabled.Checked = preview.Enabled
    chkShowBorders.Checked = preview.ShowBorder
    chkShowClick.Checked = preview.ShowClick
    chkShowHover.Checked = preview.ShowHover
  End Sub

  Private Sub LoadBoldList(cmb As ComboBox, isBold As Boolean)
    AddHandler cmb.SelectedIndexChanged, AddressOf ApplyChanges
    cmb.Items.Clear()
    cmb.Items.Add("Regular")
    cmb.Items.Add("Bold")
    If isBold Then
      cmb.SelectedIndex = 1
    Else
      cmb.SelectedIndex = 0
    End If
  End Sub

  Private Sub LoadColorList(cmb As ComboBox, defColor As Color)
    cmb.DrawMode = DrawMode.OwnerDrawFixed
    AddHandler cmb.DrawItem, AddressOf OnDrawItem
    AddHandler cmb.Paint, AddressOf onPaint
    AddHandler cmb.SelectedIndexChanged, AddressOf ApplyChanges
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

  Private Sub LoadIcons(key As String)
    If iconPanel.Controls.Count = 0 Then iconPanel.Tag = ""
    Select Case key
      Case "RS"
        If iconPanel.Tag.Equals("RS") Then Exit Sub
        iconPanel.Controls.Clear()
        iconPanel.Tag = "RS"
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
      Case "RA"
        If iconPanel.Tag.Equals("RA") Then Exit Sub
        iconPanel.Controls.Clear()
        iconPanel.Tag = "RA"
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
    AddHandler cmb.SelectedIndexChanged, AddressOf ApplyChanges
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

  Private Sub preview_ButtonCheckChanged(sender As Object, e As EventArgs) Handles preview.ButtonCheckChanged
    chkChecked.Checked = preview.Checked
  End Sub

  Private Sub preview_ButtonStateChanged(state As IconButton.IconButtonStateEnum) Handles preview.ButtonStateChanged
    Dim i As Integer = ListBox1.Items.Add(state.ToString)
    ListBox1.SelectedIndex = i
  End Sub

  Private Sub Radio_CheckedChanged(sender As Object, e As EventArgs) Handles RA0.CheckedChanged, RA1.CheckedChanged, RS0.CheckedChanged, RS1.CheckedChanged
    If Not sender.checked Then Exit Sub
    RA0.Checked = sender.Equals(RA0)
    RA1.Checked = sender.Equals(RA1)
    RS0.Checked = sender.Equals(RS0)
    RS1.Checked = sender.Equals(RS1)
    LoadIcons(sender.name.substring(0, 2))
  End Sub

#End Region

#Region "Public Methods"

  Public Sub ApplyChanges(sender As Object, e As EventArgs)
    If TypeOf sender Is ComboBox Then
      Dim cmb As ComboBox = DirectCast(sender, ComboBox)
      Debug.Print("Applying Change: " & cmb.Name)
      If TypeOf cmb.SelectedItem Is ComboBoxColorItem Then
        Debug.Print("Change Type: Color")
        Select Case cmb.Name
          Case "btnPressed"
            preview.BackClickColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.BackClickColor")
          Case "btnHover"
            preview.BackHoverColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.BackHoverColor")
          Case "btnDefault"
            preview.BackColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.BackColor")
          Case "BRColor"
            preview.BorderRightColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.BorderRightColor")
          Case "BLColor"
            preview.BorderLeftColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.BorderLeftColor")
          Case "BBColor"
            preview.BorderBottomColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.BorderBottomColor")
          Case "BTColor"
            preview.BorderTopColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.BorderTopColor")
          Case "CS1Hover"
            preview.IconSegoe1_HoverForeColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconSegoe1_HoverForeColor")
          Case "CS1Disabled"
            preview.IconSegoe1_DisabledForeColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconSegoe1_DisabledForeColor")
          Case "CS1Default"
            preview.IconSegoe1_Forecolor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconSegoe1_Forecolor")
          Case "CS0Hover"
            preview.IconSegoe0_HoverForeColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconSegoe0_HoverForeColor")
          Case "CS0Disabled"
            preview.IconSegoe0_DisabledForeColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconAncestry0_DisabledForeColor")
          Case "CS0Default"
            preview.IconSegoe0_Forecolor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconAncestry0_Forecolor")
          Case "CA1Hover"
            preview.IconAncestry1_HoverForeColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconAncestry0_HoverForeColor")
          Case "CA1Disabled"
            preview.IconAncestry1_DisabledForeColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconAncestry0_DisabledForeColor")
          Case "CA1Default"
            preview.IconAncestry1_Forecolor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconAncestry1_Forecolor")
          Case "CA0Hover"
            preview.IconAncestry0_HoverForeColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconSegoe0_HoverForeColor")
          Case "CA0Disabled"
            preview.IconAncestry0_DisabledForeColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconSegoe0_DisabledForeColor")
          Case "CA0Default"
            preview.IconAncestry0_Forecolor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("preview.IconSegoe0_Forecolor")
          Case "PreviewBackground"
            previewPanel.BackColor = DirectCast(sender, ComboBox).SelectedItem.color
            Debug.Print("previewPanel.BackColor")
          Case Else
            Debug.Print("FAILED TO CHANGE COLOR")
        End Select
      Else
        If cmb.Tag.Equals("size") Then
          Debug.Print("Change Type: Size")
          Dim txt As String = cmb.Text
          Dim s As Integer
          If txt.Contains("x") Then
            s = CInt(txt.Split("x"c)(1))
          Else
            s = 0
          End If
          Select Case cmb.Name
            Case "btnSize"
              preview.ButtonSize = s
              Debug.Print("preview.ButtonSize")
              'Center the preview box, and update H/W fields in UI
              preview.Left = CInt((previewPanel.Width - s) / 2)
              btnHeight.Text = preview.Size.Height
              btnWidth.Text = preview.Size.Width
            Case "CS1Size"
              preview.IconSegoe1_Size = s
              Debug.Print("preview.IconSegoe1_Size")
            Case "CS0Size"
              preview.IconSegoe0_Size = s
              Debug.Print("preview.IconSegoe0_Size")
            Case "CA1Size"
              preview.IconAncestry1_Size = s
              Debug.Print("preview.IconAncestry1_Size")
            Case "CA0Size"
              preview.IconAncestry0_Size = s
              Debug.Print("preview.IconAncestry0_Size")
            Case Else
              Debug.Print("FAILED TO CHANGE SIZE")
          End Select
        End If
        If cmb.Tag.Equals("bold") Then
          Select Case cmb.Name
            Case "CA0Bold"
              preview.IconAncestry0_Bold = cmb.Text.Equals("Bold")
              Debug.Print("preview.IconAncestry0_Bold")
            Case "CA1Bold"
              preview.IconAncestry1_Bold = cmb.Text.Equals("Bold")
              Debug.Print("preview.IconAncestry1_Bold")
            Case "CS0Bold"
              preview.IconSegoe0_Bold = cmb.Text.Equals("Bold")
              Debug.Print("preview.IconSegoe0_Bold")
            Case "CA1Bold"
              preview.IconSegoe1_Bold = cmb.Text.Equals("Bold")
              Debug.Print("preview.IconSegoe1_Bold")
            Case Else
              Debug.Print("FAILED TO CHANGE FontStyle")
          End Select
        End If
      End If
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