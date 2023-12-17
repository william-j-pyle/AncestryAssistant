Imports System.ComponentModel

''' <summary>
'''     Provides basic searchbox functionality.
''' </summary>
Public Class FlatSearchBox
  Inherits System.Windows.Forms.UserControl

  Private WithEvents BtnDropdown As Button

  Private WithEvents BtnSearch As Button

  Private WithEvents TxtSearch As TextBox

  Private _BlockLostFocus As Boolean = False

  Private _ShowDropDown As Boolean = False

  Private _State As SearchState

  Private components As System.ComponentModel.IContainer

  Private PnlContainer As Panel

  Public Property BackColorActive As Color = My.Theme.PanelBackColor

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Property BlockLostFocus As Boolean
    Get
      Return _BlockLostFocus
    End Get
    Set(value As Boolean)
      _BlockLostFocus = value And TxtSearch.Focused
    End Set
  End Property

  Public Property ForeColorActive As Color = My.Theme.PanelFontColor

  Public Property ImageCancelSearch As Image = My.Theme.ColorIcon(My.Resources.panel_header_close, My.Theme.PanelFontColor)

  Public Property ImageDropDown As Image = My.Theme.ColorIcon(My.Resources.panel_header_menu, My.Theme.PanelFontColor)

  Public Property ImageSearch As Image = My.Theme.ColorIcon(My.Resources.panel_search, My.Theme.PanelFontColor)

  Public Property SearchPromptText As String = "Search"

  Public Property ShowDropdown As Boolean
    Get
      Return _ShowDropDown
    End Get
    Set(value As Boolean)
      _ShowDropDown = value
      BtnDropdown.Visible = _ShowDropDown
    End Set
  End Property

  Public Property State As SearchState
    Get
      Return _State
    End Get
    Set(value As SearchState)
      _State = value
      Select Case _State
        Case SearchState.NoFocusNoSearch
          TxtSearch.ForeColor = ForeColor
          TxtSearch.BackColor = BackColor
          PnlContainer.BackColor = BackColor
          BtnDropdown.BackColor = BackColor
          BtnSearch.BackColor = BackColor
          TxtSearch.Text = SearchPromptText
          BtnSearch.Image = ImageSearch
        Case SearchState.NoFocusSearch
          TxtSearch.ForeColor = ForeColor
          TxtSearch.BackColor = BackColor
          PnlContainer.BackColor = BackColor
          BtnDropdown.BackColor = BackColor
          BtnSearch.BackColor = BackColor
          BtnSearch.Image = ImageCancelSearch
        Case SearchState.FocusNoSearch
          TxtSearch.ForeColor = ForeColor
          TxtSearch.BackColor = BackColorActive
          PnlContainer.BackColor = BackColorActive
          BtnDropdown.BackColor = BackColorActive
          BtnSearch.BackColor = BackColorActive
          If TxtSearch.Text.Equals(SearchPromptText) Then TxtSearch.Text = ""
          BtnSearch.Image = ImageSearch
        Case SearchState.FocusSearch
          TxtSearch.ForeColor = ForeColor
          PnlContainer.BackColor = BackColorActive
          TxtSearch.BackColor = BackColorActive
          BtnDropdown.BackColor = BackColorActive
          BtnSearch.BackColor = BackColorActive
          BtnSearch.Image = ImageCancelSearch
      End Select
    End Set
  End Property

  Public Event SearchEvent As FlatSearchEventHandler

  Public Sub New()
    SuspendLayout()

    BtnDropdown = New System.Windows.Forms.Button()
    With BtnDropdown
      .Dock = System.Windows.Forms.DockStyle.Right
      .FlatAppearance.BorderSize = 0
      .FlatStyle = System.Windows.Forms.FlatStyle.Flat
      .Location = New System.Drawing.Point(32, 1)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "btnDropdown"
      .Size = New System.Drawing.Size(17, 18)
      .UseMnemonic = False
      .UseVisualStyleBackColor = False
    End With

    BtnSearch = New System.Windows.Forms.Button()
    With BtnSearch
      .Dock = System.Windows.Forms.DockStyle.Right
      .FlatAppearance.BorderSize = 0
      .FlatStyle = System.Windows.Forms.FlatStyle.Flat
      .Location = New System.Drawing.Point(17, 1)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "BtnSearch"
      .Size = New System.Drawing.Size(15, 18)
      .UseMnemonic = False
      .UseVisualStyleBackColor = False
    End With

    TxtSearch = New System.Windows.Forms.TextBox()
    With TxtSearch
      .BorderStyle = System.Windows.Forms.BorderStyle.None
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      .Location = New System.Drawing.Point(1, 1)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "txtSearch"
      .ShortcutsEnabled = False
      .Size = New System.Drawing.Size(14, 16)
    End With

    PnlContainer = New Panel()
    With PnlContainer
      .Controls.Add(TxtSearch)
      .BorderStyle = BorderStyle.None
      .Location = New Point(0, 0)
      .Margin = New Padding(0)
      .Name = "pnlContainer"
      .Dock = DockStyle.Fill
      .Padding = New Padding(3, 2, 0, 0)
    End With

    Controls.Add(PnlContainer)
    Controls.Add(BtnSearch)
    Controls.Add(BtnDropdown)
    BorderStyle = BorderStyle.None
    AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
    Margin = New System.Windows.Forms.Padding(0)
    MaximumSize = New System.Drawing.Size(0, 20)
    MinimumSize = New System.Drawing.Size(50, 20)
    Dock = DockStyle.Top
    Name = "FlatSearchBox"
    Padding = New System.Windows.Forms.Padding(1, 1, 1, 1)
    BackColor = My.Theme.PanelBorderColor
    ForeColor = My.Theme.PanelFontColor
    State = SearchState.NoFocusNoSearch
    ResumeLayout(False)
    PerformLayout()
  End Sub

  Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
    If State = SearchState.FocusNoSearch And TxtSearch.Text.Length > 0 Then
      RaiseEvent SearchEvent(Me, New FlatSearchEventArgs(TxtSearch.Text))
      State = SearchState.FocusSearch
      Exit Sub
    End If
    If State = SearchState.FocusSearch Then
      RaiseEvent SearchEvent(Me, New FlatSearchEventArgs(True))
      TxtSearch.Text = ""
      State = SearchState.NoFocusNoSearch
    End If

  End Sub

  Private Sub BtnSearch_GotFocus(sender As Object, e As EventArgs) Handles BtnSearch.GotFocus
    If BlockLostFocus And Not State = SearchState.FocusSearch Then
      TxtSearch.Focus()
    End If
  End Sub

  Private Sub BtnSearch_LostFocus(sender As Object, e As EventArgs) Handles BtnSearch.LostFocus
    'Debug.Print("BtnSearch_LostFocus")
  End Sub

  Private Sub BtnSearch_MouseDown(sender As Object, e As MouseEventArgs) Handles BtnSearch.MouseDown
    'Debug.Print("BtnSearch_MouseDown")
  End Sub

  Private Sub BtnSearch_MouseEnter(sender As Object, e As EventArgs) Handles BtnSearch.MouseEnter
    'Debug.Print("Block Lost Focus")
    BlockLostFocus = True
  End Sub

  Private Sub BtnSearch_MouseLeave(sender As Object, e As EventArgs) Handles BtnSearch.MouseLeave
    'Debug.Print("Allow Lost Focus")
    BlockLostFocus = False
  End Sub

  Private Sub TxtSearch_GotFocus(sender As Object, e As EventArgs) Handles TxtSearch.GotFocus
    If BlockLostFocus Then Exit Sub
    'Debug.Print("txtSearch_GotFocus")
    Select Case State
      Case SearchState.NoFocusNoSearch
        State = SearchState.FocusNoSearch
      Case SearchState.NoFocusSearch
        State = SearchState.FocusSearch
    End Select
  End Sub

  Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyDown
    'Debug.Print("txtSearch_KeyDown")
    If e.KeyCode = Keys.Enter And TxtSearch.Text.Length > 0 Then
      RaiseEvent SearchEvent(Me, New FlatSearchEventArgs(TxtSearch.Text))
      State = SearchState.FocusSearch
    ElseIf e.KeyCode = Keys.Escape Then
      If State = SearchState.NoFocusSearch Or State = SearchState.FocusSearch Then
        RaiseEvent SearchEvent(Me, New FlatSearchEventArgs(True))
        State = SearchState.FocusNoSearch
      End If
      TxtSearch.Text = ""
    End If
  End Sub

  Private Sub TxtSearch_LostFocus(sender As Object, e As EventArgs) Handles TxtSearch.LostFocus
    If BlockLostFocus Then Exit Sub
    'Debug.Print("txtSearch_LostFocus")
    Select Case State
      Case SearchState.NoFocusNoSearch
        State = SearchState.NoFocusNoSearch
      Case SearchState.FocusNoSearch
        State = SearchState.NoFocusNoSearch
      Case SearchState.FocusSearch
        State = SearchState.NoFocusSearch
    End Select

  End Sub

  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  Public Enum SearchState
    NoFocusNoSearch = 0
    NoFocusSearch
    FocusNoSearch
    FocusSearch
  End Enum

End Class