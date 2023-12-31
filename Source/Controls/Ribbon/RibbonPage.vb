﻿Public Class RibbonPage

  Private items As Dictionary(Of String, FlatPanel)

  Private selectedKey As String = ""

  Public Property AppBackColor As Color = My.Theme.AppBackColor

  Public Property AppForeColor As Color = My.Theme.AppFontColor

  Public Property AppHighlightColor As Color = My.Theme.AppHighlightColor

  Public ReadOnly Property Id As String = ""

  Public Property RibbonAccentColor As Color = My.Theme.RibbonAccentColor

  Public Property RibbonBackColor As Color = My.Theme.RibbonBackColor

  Public Property RibbonForeColor As Color = My.Theme.RibbonForeColor

  Public Property RibbonShadowColor As Color = My.Theme.RibbonShadowColor

  Public Property SelectedItemKey As String
    Get
      Return selectedKey
    End Get
    Set(value As String)
      If Not selectedKey.Equals(value) Then
        If Not selectedKey.Equals("") Then
          items.Item(selectedKey).BorderColorLeft = My.Theme.AppBackColor
        End If
        selectedKey = value
        items.Item(selectedKey).BorderColorLeft = My.Theme.AppHighlightColor
      End If
    End Set
  End Property

  Public Event FileTabButtonClicked(key As String)

  Public Event FileTabItemSelected(key As String)

  Public Sub New()
    InitializeComponent()
    items = New Dictionary(Of String, FlatPanel)
    BtnFileTabBack.BackColor = My.Theme.AppBackColor
    ClientArea.BackColor = My.Theme.AppBorderColor
    BackColor = My.Theme.AppBackColor
    Font = My.Theme.AppFont
    ForeColor = My.Theme.AppFontColor
    BordersPanel7.BorderColor = My.Theme.AppBorderColor
    BordersPanel8.BorderColor = My.Theme.AppBorderColor
    trackButton("new", {Label1, BordersPanel1})
    trackButton("open", {Label2, BordersPanel2})
    trackButton("print", {Label3, BordersPanel3})
    trackButton("share", {Label4, BordersPanel4})
    trackButton("export", {Label5, BordersPanel5})
    trackButton("close", {Label6, BordersPanel6})
    trackButton("account", {Label7, BordersPanel10})
    trackButton("options", {Label8, BordersPanel9})
    SelectedItemKey = "new"
  End Sub

  Private Sub BtnFileTabBack_ButtonClick(sender As Object, e As EventArgs) Handles BtnFileTabBack.Click
    Visible = False
  End Sub

  Private Sub Button_Click(sender As Object, e As EventArgs)
    SelectedItemKey = CType(sender, Control).Tag.ToString
    If SelectedItemKey = "close" Then FindForm.Close()
  End Sub

  Private Sub Button_MouseEnter(sender As Object, e As EventArgs)
    If SelectedItemKey = CType(sender, Control).Tag.ToString Then Exit Sub
    items.Item(CType(sender, Control).Tag.ToString()).BorderColorLeft = My.Theme.AppBorderColor

  End Sub

  Private Sub Button_MouseLeave(sender As Object, e As EventArgs)
    If SelectedItemKey = CType(sender, Control).Tag.ToString Then Exit Sub
    items.Item(CType(sender, Control).Tag.ToString()).BorderColorLeft = My.Theme.AppBackColor

  End Sub

  Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
    My.Settings.Reset()
  End Sub

  Private Sub trackButton(key As String, ctl() As Control)
    For Each c As Control In ctl
      If TypeOf c Is Label Then
        With CType(c, Label)
          .Tag = key
          .Cursor = Cursors.Hand
          .BackColor = My.Theme.AppBackColor
          .Font = My.Theme.AppFont
          .ForeColor = My.Theme.AppFontColor
          AddHandler .Click, AddressOf Button_Click
          AddHandler .MouseEnter, AddressOf Button_MouseEnter
          AddHandler .MouseLeave, AddressOf Button_MouseLeave
        End With
      End If
      If TypeOf c Is FlatPanel Then
        With CType(c, FlatPanel)
          .Tag = key
          .Cursor = Cursors.Hand
          .BackColor = My.Theme.AppBackColor
          .Font = My.Theme.AppFont
          .ForeColor = My.Theme.AppFontColor
          .BorderColorLeft = My.Theme.AppBackColor
          AddHandler .Click, AddressOf Button_Click
          AddHandler .MouseEnter, AddressOf Button_MouseEnter
          AddHandler .MouseLeave, AddressOf Button_MouseLeave
        End With
        items.Add(key, CType(c, FlatPanel))
      End If
    Next
  End Sub

End Class