Imports System.ComponentModel

''' <summary>
'''     Provides basic searchbox functionality.
''' </summary>
Public Class FlatSearchBox
  Inherits System.Windows.Forms.UserControl

#Region "Fields"

  Private WithEvents btnDropdown As Button

  Private WithEvents btnSearch As Button

  Private WithEvents txtSearch As TextBox

  Private _BlockLostFocus As Boolean = False

  Private _ShowDropDown As Boolean = True

  Private _State As SearchState

  Private components As System.ComponentModel.IContainer

  Private pnlContainer As Panel

#End Region

#Region "Events"

  Public Event SearchEvent As FlatSearchEventHandler

#End Region

#Region "Properties"

  Public Property BackColorActive As Color = My.Theme.PanelBackColor

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Public Property BlockLostFocus As Boolean
    Get
      Return _BlockLostFocus
    End Get
    Set(value As Boolean)
      _BlockLostFocus = value And txtSearch.Focused
    End Set
  End Property

  Public Property ForeColorActive As Color = My.Theme.PanelFontColor

  Public Property ImageCancelSearch As Image = My.Theme.ColorIcon(My.Resources.ANCESTRY, My.Theme.PanelFontColor)

  Public Property ImageDropDown As Image = My.Theme.ColorIcon(My.Resources.ANCESTRY, My.Theme.PanelFontColor)

  Public Property ImageSearch As Image = My.Theme.ColorIcon(My.Resources.ANCESTRY, My.Theme.PanelFontColor)

  Public Property SearchPromptText As String = "Search"

  Public Property ShowDropdown As Boolean
    Get
      Return _ShowDropDown
    End Get
    Set(value As Boolean)
      _ShowDropDown = value
      btnDropdown.Visible = _ShowDropDown
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
          txtSearch.ForeColor = ForeColor
          txtSearch.BackColor = BackColor
          pnlContainer.BackColor = BackColor
          btnDropdown.BackColor = BackColor
          btnSearch.BackColor = BackColor
          txtSearch.Text = SearchPromptText
          btnSearch.Image = ImageSearch
        Case SearchState.NoFocusSearch
          txtSearch.ForeColor = ForeColor
          txtSearch.BackColor = BackColor
          pnlContainer.BackColor = BackColor
          btnDropdown.BackColor = BackColor
          btnSearch.BackColor = BackColor
          btnSearch.Image = ImageCancelSearch
        Case SearchState.FocusNoSearch
          txtSearch.ForeColor = ForeColor
          txtSearch.BackColor = BackColorActive
          pnlContainer.BackColor = BackColorActive
          btnDropdown.BackColor = BackColorActive
          btnSearch.BackColor = BackColorActive
          If txtSearch.Text.Equals(SearchPromptText) Then txtSearch.Text = ""
          btnSearch.Image = ImageSearch
        Case SearchState.FocusSearch
          txtSearch.ForeColor = ForeColor
          pnlContainer.BackColor = BackColorActive
          txtSearch.BackColor = BackColorActive
          btnDropdown.BackColor = BackColorActive
          btnSearch.BackColor = BackColorActive
          btnSearch.Image = ImageCancelSearch
      End Select
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    SuspendLayout()

    btnDropdown = New System.Windows.Forms.Button()
    With btnDropdown
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

    btnSearch = New System.Windows.Forms.Button()
    With btnSearch
      .Dock = System.Windows.Forms.DockStyle.Right
      .FlatAppearance.BorderSize = 0
      .FlatStyle = System.Windows.Forms.FlatStyle.Flat
      .Location = New System.Drawing.Point(17, 1)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "btnSearch"
      .Size = New System.Drawing.Size(15, 18)
      .UseMnemonic = False
      .UseVisualStyleBackColor = False
    End With

    txtSearch = New System.Windows.Forms.TextBox()
    With txtSearch
      .BorderStyle = System.Windows.Forms.BorderStyle.None
      .Dock = System.Windows.Forms.DockStyle.Fill
      .Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      .Location = New System.Drawing.Point(1, 1)
      .Margin = New System.Windows.Forms.Padding(0)
      .Name = "txtSearch"
      .ShortcutsEnabled = False
      .Size = New System.Drawing.Size(14, 16)
    End With

    pnlContainer = New Panel()
    With pnlContainer
      .Controls.Add(txtSearch)
      .BorderStyle = BorderStyle.None
      .Location = New Point(0, 0)
      .Margin = New Padding(0)
      .Name = "pnlContainer"
      .Dock = DockStyle.Fill
      .Padding = New Padding(3, 2, 0, 0)
    End With

    Controls.Add(pnlContainer)
    Controls.Add(btnSearch)
    Controls.Add(btnDropdown)
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

#End Region

#Region "Private Methods"

  Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
    If State = SearchState.FocusNoSearch And txtSearch.Text.Length > 0 Then
      RaiseEvent SearchEvent(Me, New FlatSearchEventArgs(txtSearch.Text))
      State = SearchState.FocusSearch
      Exit Sub
    End If
    If State = SearchState.FocusSearch Then
      RaiseEvent SearchEvent(Me, New FlatSearchEventArgs(True))
      txtSearch.Text = ""
      State = SearchState.NoFocusNoSearch
    End If

  End Sub

  Private Sub btnSearch_GotFocus(sender As Object, e As EventArgs) Handles btnSearch.GotFocus
    If BlockLostFocus And Not State = SearchState.FocusSearch Then
      txtSearch.Focus()
    End If
  End Sub

  Private Sub btnSearch_LostFocus(sender As Object, e As EventArgs) Handles btnSearch.LostFocus
    'Debug.Print("btnSearch_LostFocus")
  End Sub

  Private Sub btnSearch_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSearch.MouseDown
    'Debug.Print("btnSearch_MouseDown")
  End Sub

  Private Sub btnSearch_MouseEnter(sender As Object, e As EventArgs) Handles btnSearch.MouseEnter
    'Debug.Print("Block Lost Focus")
    BlockLostFocus = True
  End Sub

  Private Sub btnSearch_MouseLeave(sender As Object, e As EventArgs) Handles btnSearch.MouseLeave
    'Debug.Print("Allow Lost Focus")
    BlockLostFocus = False
  End Sub

  Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
    If BlockLostFocus Then Exit Sub
    'Debug.Print("txtSearch_GotFocus")
    Select Case State
      Case SearchState.NoFocusNoSearch
        State = SearchState.FocusNoSearch
      Case SearchState.NoFocusSearch
        State = SearchState.FocusSearch
    End Select
  End Sub

  Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
    'Debug.Print("txtSearch_KeyDown")
    If e.KeyCode = Keys.Enter And txtSearch.Text.Length > 0 Then
      RaiseEvent SearchEvent(Me, New FlatSearchEventArgs(txtSearch.Text))
      State = SearchState.FocusSearch
    ElseIf e.KeyCode = Keys.Escape Then
      If State = SearchState.NoFocusSearch Or State = SearchState.FocusSearch Then
        RaiseEvent SearchEvent(Me, New FlatSearchEventArgs(True))
        State = SearchState.FocusNoSearch
      End If
      txtSearch.Text = ""
    End If
  End Sub

  Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
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

#End Region

#Region "Protected Methods"

  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

#End Region

#Region "Enums"

  Public Enum SearchState
    NoFocusNoSearch = 0
    NoFocusSearch
    FocusNoSearch
    FocusSearch
  End Enum

#End Region

End Class