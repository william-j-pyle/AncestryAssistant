Public Class RibbonGroup
  Inherits TableLayoutPanel

#Region "Fields"

  Private _MinimumWidth As Integer = 0
  Private _TextSize As New Size(0, 0)
  Private CaptionFont As New System.Drawing.Font("Segoe UI Semibold", 10, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
  Private IconFont As New System.Drawing.Font("Segoe Fluent Icons", 10, FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))

#End Region

#Region "Properties"

  Public Property AppBackColor As Color = My.Theme.AppBackColor
  Public Property AppForeColor As Color = My.Theme.AppFontColor
  Public Property AppHighlightColor As Color = My.Theme.AppHighlightColor
  Public ReadOnly Property Id As String = ""
  Public ReadOnly Property MinimumWidth As Integer
    Get
      If _MinimumWidth = 0 Then
        calcMinimumWidth()
      End If
      Return _MinimumWidth
    End Get
  End Property
  Public Property RibbonAccentColor As Color = My.Theme.RibbonAccentColor
  Public Property RibbonBackColor As Color = My.Theme.RibbonBackColor
  Public Property RibbonForeColor As Color = My.Theme.RibbonForeColor
  Public Property RibbonShadowColor As Color = My.Theme.RibbonShadowColor

  Public ReadOnly Property TextSize As Size
    Get
      If _TextSize.IsEmpty Then
        calcTextSize()
      End If
      Return _TextSize
    End Get
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New(GroupId As String, GroupText As String)
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SuspendLayout()
    Name = "GRP__" + GroupId
    _Id = GroupId
    Text = GroupText
    BackColor = RibbonBackColor
    ForeColor = RibbonForeColor
    Padding = New Padding(8, 0, 0, 0)
    Margin = New Padding(0)
    Dock = System.Windows.Forms.DockStyle.Left
    GrowStyle = TableLayoutPanelGrowStyle.FixedSize
    MaximumSize = New System.Drawing.Size(0, 0)
    MinimumSize = New System.Drawing.Size(MinimumWidth, 0)
    Width = MinimumWidth
    ResumeLayout(False)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub addGridColumns(Optional colCount As Integer = 1)
    For i As Integer = 1 To colCount
      ColumnCount += 1
      ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, RibbonConfig.GRID_HEIGHTWIDTH))
    Next
  End Sub

  Private Sub calcMinimumWidth()
    _MinimumWidth = Math.Max(TextSize.Width + 50, ColumnCount * RibbonConfig.GRID_HEIGHTWIDTH)
  End Sub

  Private Sub calcTextSize()
    _TextSize = TextRenderer.MeasureText(Text, CaptionFont)
  End Sub

  Private Sub forceResize()
    calcMinimumWidth()
    MinimumSize = New System.Drawing.Size(MinimumWidth, 0)
    Size = New Size(MinimumWidth, Height)
  End Sub

  Private Sub initGrid(colCount As Integer)
    ColumnStyles.Clear()
    RowStyles.Clear()
    addGridColumns()
    Me.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
    RowCount = 4
    RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, RibbonConfig.GRID_HEIGHTWIDTH))
    RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, RibbonConfig.GRID_HEIGHTWIDTH))
    RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, RibbonConfig.GRID_HEIGHTWIDTH))
    RowStyles.Add(New System.Windows.Forms.RowStyle())
  End Sub

  Private Sub RenderControl(sender As Object, e As PaintEventArgs) Handles Me.Paint
    'Clear Group Client Area
    Using brush As New SolidBrush(RibbonBackColor)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using

    'Draw the seperator bar at the end of the group
    Dim jPen As New Pen(Color.FromArgb(100, RibbonForeColor), 1)
    e.Graphics.DrawLine(jPen, Width - 1, 0, Width - 1, Height - 5)

    'Draw the group caption
    Dim textBrush As Brush = New SolidBrush(RibbonForeColor)
    Dim textLocation As New Point(e.ClipRectangle.Left + 1 + ((e.ClipRectangle.Width - TextSize.Width) / 2), e.ClipRectangle.Bottom - TextSize.Height - 4)
    e.Graphics.DrawString(Text, CaptionFont, textBrush, textLocation)

    ' Draw the Exapand Icon
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

  End Sub

#End Region

#Region "Public Methods"

  Public Sub AddItem(Id As String, RibbonItem As IRibbonItem)
    Debug.Print("AddItem({0})[Loc.X={1}, Loc.Y={2}, Width={3}, Height={4}]", Id, RibbonItem.GridLocation.X, RibbonItem.GridLocation.Y, RibbonItem.GridSize.Width, RibbonItem.GridSize.Height)
    If Controls.Count = 0 Then
      initGrid(RibbonItem.GridSize.Width)
    End If
    If ColumnCount < RibbonItem.GridLocation.X + RibbonItem.GridSize.Width Then
      addGridColumns(RibbonItem.GridLocation.X + RibbonItem.GridSize.Width - ColumnCount)
    End If
    If RibbonItem.GridSize.Width > 1 Then
      SetColumnSpan(RibbonItem, RibbonItem.GridSize.Width)
    End If
    If RibbonItem.GridSize.Height > 1 Then
      SetRowSpan(RibbonItem, RibbonItem.GridSize.Height)
    End If
    Controls.Add(RibbonItem, RibbonItem.GridLocation.X - 1, RibbonItem.GridLocation.Y - 1)
    forceResize()
  End Sub

#End Region

End Class