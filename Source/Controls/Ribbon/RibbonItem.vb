Imports System.ComponentModel

Public MustInherit Class RibbonItem

#Region "Fields"

  Private WithEvents RibbonCntl As Ribbon
  Private _Col As Double = 1
  Private _ColSpan As Double = 0
  Private _Row As Double = 1
  Private _RowSpan As Double = 0
  <Browsable(True), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
  Private _Text As String = ""
  Private CaptionFont As New System.Drawing.Font("Segoe UI", 12, FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))

#End Region

#Region "Events"

  Public Event RibbonItemAction(sender As RibbonItem, eventType As RibbonEventType, value As Object)

  Public Event RibbonItemLocationChanged(sender As Object, e As EventArgs)

  Public Event RibbonItemSizeChanged(sender As Object, e As EventArgs)

#End Region

#Region "Properties"

  Public Property AppBackColor As Color = My.Theme.AppBackColor

  Public Property AppForeColor As Color = My.Theme.AppFontColor

  Public Property AppHighlightColor As Color = My.Theme.AppHighlightColor

  Public Property BarId As Integer

  Public Property Col As Double
    Get
      Return _Col
    End Get
    Set(value As Double)
      If value < 1 Then value = 1
      If value <> _Col Then
        _Col = value
        ApplyConstraints()
        RaiseEvent RibbonItemLocationChanged(Me, New EventArgs())
      End If
    End Set
  End Property

  Public Property ColSpan As Double
    Get
      Return _ColSpan
    End Get
    Set(value As Double)
      If value < 1 Then value = 1
      If value > 12 Then value = 12
      If value <> _ColSpan Then
        _ColSpan = value
        ApplyConstraints()
        RaiseEvent RibbonItemSizeChanged(Me, New EventArgs())
      End If
    End Set
  End Property

  Public Property GroupId As Integer

  Public Property ItemId As Integer

  Public Property Ribbon As Ribbon
    Get
      Return RibbonCntl
    End Get
    Set(value As Ribbon)
      RibbonCntl = value
    End Set
  End Property

  Public Property RibbonAccentColor As Color = My.Theme.RibbonAccentColor

  Public Property RibbonBackColor As Color = My.Theme.RibbonBackColor

  Public Property RibbonForeColor As Color = My.Theme.RibbonForeColor

  Public Property RibbonShadowColor As Color = My.Theme.RibbonShadowColor

  Public Property Row As Double
    Get
      Return _Row
    End Get
    Set(value As Double)
      If value <> _Row Then
        _Row = value
        ApplyConstraints()
        RaiseEvent RibbonItemLocationChanged(Me, New EventArgs())
      End If
    End Set
  End Property

  Public Property RowSpan As Double
    Get
      Return _RowSpan
    End Get
    Set(value As Double)
      If value <> _RowSpan Then
        _RowSpan = value
        ApplyConstraints()
        RaiseEvent RibbonItemSizeChanged(Me, New EventArgs())
      End If
    End Set
  End Property

  Public Overrides Property Text As String
    Get
      Return _Text
    End Get
    Set(value As String)
      _Text = value
      OnTextChanged(New EventArgs)
    End Set
  End Property

  Public Property TextAlign As ContentAlignment = ContentAlignment.BottomCenter

  Public Property TextImageRelation As TextImageRelation = TextImageRelation.ImageAboveText

#End Region

#Region "Public Constructors"

  Public Sub New()
    Me.New(Nothing, "RibbonItem", 0, 0, 0)
  End Sub

  Public Sub New(oRibbon As Ribbon, sItemName As String, iBarId As Integer, iGroupId As Integer, iItemId As Integer)
    'SetStyle(ControlStyles.UserPaint Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    InitializeComponent()
    RibbonCntl = oRibbon
    Name = sItemName
    ItemId = iItemId
    BarId = iBarId
    GroupId = iGroupId
    Font = CaptionFont
    BorderStyle = BorderStyle.None
    BackColor = RibbonBackColor
    ForeColor = RibbonForeColor
    Padding = New Padding(0)
    Margin = New Padding(0)
    MaximumSize = New System.Drawing.Size(0, 0)
    MinimumSize = New System.Drawing.Size(RibbonConfig.GROUP_COL_WIDTH, RibbonConfig.GROUP_ROW_HEIGHT)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub ApplyConstraints()
    'MinimumSize = New System.Drawing.Size(CInt(RibbonConfig.GROUP_COL_WIDTH * ColSpan), CInt(RibbonConfig.GROUP_ROW_HEIGHT * RowSpan))
    Size = New Size(CInt(RibbonConfig.GROUP_COL_WIDTH * ColSpan), CInt(RibbonConfig.GROUP_ROW_HEIGHT * RowSpan))
    If RowSpan > 1 Then
      TextImageRelation = TextImageRelation.ImageAboveText
      'TextAlign = ContentAlignment.BottomCenter
    Else
      TextImageRelation = TextImageRelation.ImageBeforeText
      'TextAlign = ContentAlignment.MiddleRight
    End If
    'If ColSpan <= 1 And RowSpan <= 1 Then
    'Text = ""
    'End If
    Invalidate(True)
  End Sub

  Private Sub RibbonItem_ParentChanged(sender As Object, e As EventArgs) Handles Me.ParentChanged
    If RibbonCntl Is Nothing And TypeOf Parent Is RibbonGroup Then
      With CType(Parent, RibbonGroup)
        RibbonCntl = .RibbonCntl
        BarId = .BarId
        GroupId = .GroupId
        ItemId = Parent.Controls.Count
        If Name.Equals("RibbonItem") Then Name += ItemId.ToString
      End With
      If RibbonCntl IsNot Nothing Then
        RibbonCntl.RegisterItem(Me)
      End If
    End If
  End Sub

  Private Sub RibbonItem_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
    ApplyConstraints()
  End Sub

#End Region

  'Public Function AlignStringToEnum(alignString As String) As ContentAlignment
  '  Dim align As ContentAlignment
  '  Select Case alignString.ToLower
  '    Case ContentAlignment.TopCenter.ToString.ToLower
  '      align = ContentAlignment.TopCenter
  '    Case ContentAlignment.TopLeft.ToString.ToLower
  '      align = ContentAlignment.TopLeft
  '    Case ContentAlignment.TopRight.ToString.ToLower
  '      align = ContentAlignment.TopRight

  ' Case ContentAlignment.MiddleCenter.ToString.ToLower align = ContentAlignment.MiddleCenter Case
  ' ContentAlignment.MiddleLeft.ToString.ToLower align = ContentAlignment.MiddleLeft Case
  ' ContentAlignment.MiddleRight.ToString.ToLower align = ContentAlignment.MiddleRight

  '    Case ContentAlignment.BottomCenter.ToString.ToLower
  '      align = ContentAlignment.BottomCenter
  '    Case ContentAlignment.BottomLeft.ToString.ToLower
  '      align = ContentAlignment.BottomLeft
  '    Case ContentAlignment.BottomRight.ToString.ToLower
  '      align = ContentAlignment.BottomRight
  '    Case Else
  '      align = ContentAlignment.MiddleLeft
  '  End Select
  '  Return align
  'End Function

#Region "Public Methods"

  Public MustOverride Function GetAttribute(ItemAttribute As RibbonItemAttribute) As Object

  Public Function ImageFromFile(fileName As String) As Image
    Return Image.FromFile(fileName)
  End Function

  Public Function ImageFromResource(resourceName As String) As Image
    Return TryCast(My.Resources.ResourceManager.GetObject(resourceName), Image)
  End Function

  Public Sub OnRibbonItemAction(eventType As RibbonEventType, value As Object)
    RaiseEvent RibbonItemAction(Me, eventType, value)
  End Sub

  Public MustOverride Sub SetAttribute(ItemAttribute As RibbonItemAttribute, attributeValue As Object)

#End Region

End Class