Imports System.ComponentModel

Public Class RibbonGroup
  Inherits Panel

#Region "Fields"

  Private Const DEFAULT_NAME As String = "RibbonGroup"
  Private _ColCount As Integer = 1
  Private CaptionFont As New System.Drawing.Font("Segoe UI Semibold", 10, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
  Protected Friend RibbonCntl As Ribbon

#End Region

#Region "Properties"

  Public Property AppBackColor As Color = My.Theme.AppBackColor
  Public Property AppForeColor As Color = My.Theme.AppFontColor
  Public Property AppHighlightColor As Color = My.Theme.AppHighlightColor
  Public Property BarId As Integer
  Public Property ColCount As Integer
    Get
      Return _ColCount
    End Get
    Set(value As Integer)
      If Not _ColCount.Equals(value) Then
        _ColCount = value
        MinimumSize = New System.Drawing.Size(MinimumWidth, 0)
        Size = New Size(MinimumWidth, Height)
        Width = Size.Width
        Invalidate(Region)
      End If
    End Set
  End Property
  Public Property GroupId As Integer
  Public ReadOnly Property MinimumWidth As Integer
    Get
      Return Math.Max(TextSize.Width + 50, _ColCount * (RibbonConfig.GROUP_COL_WIDTH + RibbonConfig.GROUP_COL_SPACING))
    End Get
  End Property
  Public Property RibbonAccentColor As Color = My.Theme.RibbonAccentColor
  Public Property RibbonBackColor As Color = My.Theme.RibbonBackColor
  Public Property RibbonForeColor As Color = My.Theme.RibbonForeColor
  Public Property RibbonShadowColor As Color = My.Theme.RibbonShadowColor
  Public Property RowCount As Integer = 1
  Public Property ShowPane As Boolean = True
  <Browsable(True), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
  Public Overrides Property Text As String
    Get
      Return MyBase.Text
    End Get
    Set(value As String)
      MyBase.Text = value
      Invalidate()
    End Set
  End Property
  Public ReadOnly Property TextSize As Size
    Get
      Return TextRenderer.MeasureText(Text, CaptionFont)
    End Get
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    Me.New(Nothing, DEFAULT_NAME, DEFAULT_NAME, 0, 0)
  End Sub

  Public Sub New(oRibbon As Ribbon, sName As String, sCaption As String, iBarId As Integer, iGroupId As Integer)
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SuspendLayout()
    RibbonCntl = oRibbon
    Name = sName
    GroupId = iGroupId
    BarId = iBarId
    Text = sCaption
    BackColor = RibbonBackColor
    ForeColor = RibbonForeColor
    Padding = New Padding(8, 0, 0, 0)
    Margin = New Padding(0)
    Dock = System.Windows.Forms.DockStyle.Left
    MaximumSize = New System.Drawing.Size(0, 0)
    MinimumSize = New System.Drawing.Size(MinimumWidth, 0)
    Width = MinimumWidth
    ResumeLayout(False)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub AddItemProcessing(ri As RibbonItem, isAddItem As Boolean)
    ri.BarId = BarId
    If ColCount < ri.Col + ri.ColSpan Then
      ColCount = ri.Col + ri.ColSpan
    End If
    If isAddItem Then
      ri.Tag = "AddItem"
      Controls.Add(ri)
    End If
    ri.Location = getItemTargetLocation(ri.Col, ri.ColSpan, ri.Row, ri.RowSpan)
    AddHandler ri.RibbonItemLocationChanged, AddressOf RibbonItemLocationChanged
    AddHandler ri.RibbonItemSizeChanged, AddressOf RibbonItemSizeChanged
  End Sub

  Private Function getItemTargetLocation(Col As Double, ColSpan As Double, Row As Double, RowSpan As Double) As Point
    If ColCount < Col + ColSpan Then
      ColCount = CInt(Col + ColSpan)
    End If
    Return New Point(CInt(((Col - 1) * (RibbonConfig.GROUP_COL_WIDTH + RibbonConfig.GROUP_COL_SPACING)) + RibbonConfig.GROUP_LEFT_SPACING), CInt(((Row - 1) * (RibbonConfig.GROUP_ROW_HEIGHT + RibbonConfig.GROUP_ROW_SPACING)) + RibbonConfig.GROUP_TOP_SPACING))
  End Function

  Private Function getItemTargetSize(Col As Double, ColSpan As Double, Row As Double, RowSpan As Double) As Size
    If ColCount < Col + ColSpan Then
      ColCount = CInt(Col + ColSpan)
    End If
    Return New Size(CInt(ColSpan * RibbonConfig.GROUP_COL_WIDTH), CInt(RowSpan * RibbonConfig.GROUP_ROW_HEIGHT))
  End Function

  Private Sub RenderControl(sender As Object, e As PaintEventArgs) Handles Me.Paint

    'Clear Group Client Area
    Using brush As New SolidBrush(RibbonBackColor)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using

    If Width <> e.ClipRectangle.Width Then Exit Sub

    'Draw the seperator bar at the end of the group
    Dim jPen As New Pen(Color.FromArgb(100, RibbonForeColor), 1)
    e.Graphics.DrawLine(jPen, Width - 1, 0, Width - 1, Height - 5)

    'Draw the group caption
    Dim textBrush As Brush = New SolidBrush(RibbonForeColor)
    Dim textLocation As New Point(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - TextSize.Width) / 2), e.ClipRectangle.Bottom - TextSize.Height - 4)
    e.Graphics.DrawString(Text, CaptionFont, textBrush, textLocation)

    ' Draw the Exapand Icon

    If ShowPane Then

      Dim t As Integer = textLocation.Y + 5
      Dim l As Integer = Width - 12

      jPen = New Pen(RibbonAccentColor, 2)
      e.Graphics.DrawLine(jPen, l + 3, t + 3, l + 7, t + 7)

      jPen = New Pen(RibbonForeColor, 1)
      e.Graphics.DrawLine(jPen, l, t, l, t + 6)
      e.Graphics.DrawLine(jPen, l, t, l + 6, t)
      e.Graphics.DrawLine(jPen, l + 7, t + 3, l + 7, t + 7)
      e.Graphics.DrawLine(jPen, l + 3, t + 7, l + 7, t + 7)
      e.Graphics.DrawLine(jPen, l + 3, t + 3, l + 7, t + 7)

    End If

  End Sub

  Private Sub RibbonGroup_ControlAdded(sender As Object, e As ControlEventArgs) Handles Me.ControlAdded
    If TypeOf e.Control Is RibbonItem Then
      If e.Control.Tag IsNot Nothing Then
        If e.Control.Tag.Equals("AddItem") Then
          Exit Sub
        End If
      End If
      AddItemProcessing(CType(e.Control, RibbonItem), False)
    End If
  End Sub

  ''' <summary>
  '''     When Group is added via addItem, all proper inits are completed When Group is added via designer, then this
  '''     event will apply the required parent values
  ''' </summary>
  ''' <param name="sender">
  ''' </param>
  ''' <param name="e">
  ''' </param>
  Private Sub RibbonGroup_ParentChanged(sender As Object, e As EventArgs) Handles Me.ParentChanged
    If RibbonCntl Is Nothing And TypeOf Parent Is RibbonBar Then
      With CType(Parent, RibbonBar)
        RibbonCntl = .RibbonCntl
        BarId = .BarId
        GroupId = Parent.Controls.Count
        If Name.Equals(DEFAULT_NAME) Then Name += GroupId.ToString
        If Text.Equals(DEFAULT_NAME) Then Text = Name
      End With
    End If
  End Sub

#End Region

#Region "Public Methods"

  Public Sub AddItem(ri As RibbonItem)
    AddItemProcessing(ri, True)
  End Sub

  Public Sub RibbonItemLocationChanged(sender As Object, e As EventArgs)
    With CType(sender, RibbonItem)
      .Location = getItemTargetLocation(.Col, .ColSpan, .Row, .RowSpan)
      .Refresh()
    End With
  End Sub

  Public Sub RibbonItemSizeChanged(sender As Object, e As EventArgs)
    With CType(sender, RibbonItem)
      .Size = getItemTargetSize(.Col, .ColSpan, .Row, .RowSpan)
      .Refresh()
    End With
  End Sub

#End Region

End Class