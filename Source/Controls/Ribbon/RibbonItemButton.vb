Public Class RibbonItemButton
  Inherits Button
  Implements IRibbonItem

#Region "Fields"

  Private _GridSize As New Size(1, 1)
  Private _MinimumWidth As Integer = 0
  Private _TextSize As New Size(0, 0)
  Private CaptionFont As New System.Drawing.Font("Segoe UI Semibold", 10, FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))
  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer
  Private IconFont As New System.Drawing.Font("Segoe Fluent Icons", 10, FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, CType(0, Byte))

#End Region

#Region "Properties"

  Private ReadOnly Property Id As String Implements IRibbonItem.Id
  Public Property AppBackColor As Color = My.Theme.AppBackColor Implements IRibbonItem.AppBackColor
  Public Property AppForeColor As Color = My.Theme.AppFontColor Implements IRibbonItem.AppForeColor
  Public Property AppHighlightColor As Color = My.Theme.AppHighlightColor Implements IRibbonItem.AppHighlightColor
  Public Property GridLocation As Point = New Point(1, 1) Implements IRibbonItem.GridLocation
  Public Property GridSize As Size Implements IRibbonItem.GridSize
    Get
      Return _GridSize
    End Get
    Set(value As Size)
      _GridSize = value
      Size = New Size(RibbonConfig.GRID_HEIGHTWIDTH * value.Width, RibbonConfig.GRID_HEIGHTWIDTH * value.Height)
    End Set
  End Property

  Public Property RibbonAccentColor As Color = My.Theme.RibbonAccentColor Implements IRibbonItem.RibbonAccentColor
  Public Property RibbonBackColor As Color = My.Theme.RibbonBackColor Implements IRibbonItem.RibbonBackColor
  Public Property RibbonForeColor As Color = My.Theme.RibbonForeColor Implements IRibbonItem.RibbonForeColor
  Public Property RibbonShadowColor As Color = My.Theme.RibbonShadowColor Implements IRibbonItem.RibbonShadowColor

#End Region

#Region "Public Constructors"

  Public Sub New(ItemId As String, ItemText As String)
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    SuspendLayout()
    Name = "ITEM_" + ItemId
    _Id = ItemId
    Text = ItemText
    BackColor = RibbonBackColor
    ForeColor = RibbonForeColor
    FlatStyle = FlatStyle.Flat
    With FlatAppearance
      .BorderColor = RibbonBackColor
      .BorderSize = 0
      .CheckedBackColor = RibbonShadowColor
      .MouseDownBackColor = RibbonAccentColor
      .MouseOverBackColor = RibbonShadowColor
    End With
    Padding = New Padding(0)
    Margin = New Padding(0)
    MaximumSize = New System.Drawing.Size(0, 0)
    MinimumSize = New System.Drawing.Size(RibbonConfig.GRID_HEIGHTWIDTH, RibbonConfig.GRID_HEIGHTWIDTH)
    ResumeLayout(False)
  End Sub

#End Region

#Region "Protected Methods"

  'UserControl overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
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

End Class