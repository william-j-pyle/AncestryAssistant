Public Class RibbonBarFileTab

#Region "Events"

  Public Event FileTabButtonClicked(key As String)

  Public Event FileTabItemSelected(key As String)

#End Region

#Region "Properties"

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

#End Region

#Region "Public Constructors"

  Public Sub New()
    InitializeComponent()
    items = New Dictionary(Of String, FlatPanel)
    btnFileTabBack.BackColor = My.Theme.AppBackColor
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

#End Region

#Region "Private Methods"

  Private Sub btnFileTabBack_ButtonClick(sender As Object, e As EventArgs) Handles btnFileTabBack.ButtonClick
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

#End Region

#Region "Fields"

  Private items As Dictionary(Of String, FlatPanel)
  Private selectedKey As String = ""

#End Region

End Class