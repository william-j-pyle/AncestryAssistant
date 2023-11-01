Imports System.ComponentModel

Public Class DockHeaderPanel
  Inherits Panel

  Private Const FIXED_HEIGHT = 24

  Private WithEvents theme As JTheme = New JTheme()

  Private WithEvents HeaderCloseButton As Button
  Private WithEvents HeaderCaption As Label

  Public Event HeaderCloseClicked()

  Private _Caption As String = "jDockPanelHeader"

  Public Property Caption As String
    Get
      Return _Caption
    End Get
    Set(value As String)
      _Caption = value
      HeaderCaption.Text = value
    End Set
  End Property

  Private _BackColorEnabled As Color = Color.Black ' theme.HeadingBackColor

  Public Property BackColorEnabled As Color
    Get
      Return _BackColorEnabled
    End Get
    Set(value As Color)
      _BackColorEnabled = value
      If Enabled Then
        BackColor = _BackColorEnabled
      End If
    End Set
  End Property

  Private _BackColorDisabled As Color = Color.DarkGray ' theme.HeadingBackColorDisabled

  Public Property BackColorDisabled As Color
    Get
      Return _BackColorDisabled
    End Get
    Set(value As Color)
      _BackColorDisabled = value
      If Not Enabled Then
        BackColor = _BackColorDisabled
      End If
    End Set
  End Property

  Private _ForeColorEnabled As Color = Color.White ' theme.HeadingForeColor

  Public Property ForeColorEnabled As Color
    Get
      Return _ForeColorEnabled
    End Get
    Set(value As Color)
      _ForeColorEnabled = value
      If Enabled Then
        _ForeColorDisabled = _ForeColorEnabled
      End If
    End Set
  End Property

  Private _ForeColorDisabled As Color = Color.Black ' theme.HeadingBackColorDisabled

  Public Property ForeColorDisabled As Color
    Get
      Return _ForeColorDisabled
    End Get
    Set(value As Color)
      _ForeColorDisabled = value
      If Not Enabled Then
        ForeColor = _ForeColorDisabled
      End If
    End Set
  End Property

  Public Sub New()

    HeaderCloseButton = New System.Windows.Forms.Button()
    HeaderCaption = New System.Windows.Forms.Label()

    BackColor = _BackColorEnabled
    ForeColor = _ForeColorEnabled
    Controls.Add(HeaderCloseButton)
    Controls.Add(HeaderCaption)
    MaximumSize = New Size(0, FIXED_HEIGHT)
    MinimumSize = New Size(0, FIXED_HEIGHT)
    Margin = New System.Windows.Forms.Padding(0)
    Padding = New System.Windows.Forms.Padding(0)
    Dock = System.Windows.Forms.DockStyle.Top
    Name = "jDockPanelHeader"
    '
    'HeaderCloseButton
    '
    HeaderCloseButton.Dock = System.Windows.Forms.DockStyle.Right
    HeaderCloseButton.FlatAppearance.BorderSize = 0
    HeaderCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    HeaderCloseButton.Image = Global.AncestryAssistant.My.Resources.Resources.X_ICO20
    HeaderCloseButton.Location = New System.Drawing.Point(276, 0)
    HeaderCloseButton.Margin = New System.Windows.Forms.Padding(0)
    HeaderCloseButton.Name = "HeaderCloseButton"
    HeaderCloseButton.Padding = New System.Windows.Forms.Padding(0, 0, 2, 3)
    HeaderCloseButton.size = New System.Drawing.size(FIXED_HEIGHT, FIXED_HEIGHT)
    HeaderCloseButton.TabIndex = 3
    HeaderCloseButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    HeaderCloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
    HeaderCloseButton.UseVisualStyleBackColor = True
    '
    'HeaderCaption
    '
    HeaderCaption.Dock = System.Windows.Forms.DockStyle.Fill
    HeaderCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    HeaderCaption.Location = New System.Drawing.Point(0, 0)
    HeaderCaption.Margin = New System.Windows.Forms.Padding(0)
    HeaderCaption.TextAlign = ContentAlignment.MiddleLeft
    HeaderCaption.Padding = New System.Windows.Forms.Padding(8, 0, 0, 0)
    HeaderCaption.MaximumSize = New Size(0, FIXED_HEIGHT)
    HeaderCaption.MinimumSize = New Size(0, FIXED_HEIGHT)
    HeaderCaption.TabIndex = 0
    HeaderCaption.Text = Name

  End Sub

  'Private Sub jDockPanelHeader_Resize(sender As Object, e As EventArgs) Handles Me.Resize
  '  Height = FIXED_HEIGHT
  'End Sub

  Private Sub jDockPanelHeader_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
    If Enabled Then
      BackColor = _BackColorEnabled
      ForeColor = _ForeColorEnabled
    Else
      BackColor = _BackColorDisabled
      ForeColor = _ForeColorDisabled
    End If
    Refresh()
  End Sub

  Private Sub HeaderCloseButton_Click(sender As Object, e As EventArgs) Handles HeaderCloseButton.Click
    RaiseEvent HeaderCloseClicked()
  End Sub

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
  Public Shadows Property Margin As Padding
    Get
      Return MyBase.Margin
    End Get
    Set(value As Padding)
      MyBase.Margin = value
    End Set
  End Property

End Class