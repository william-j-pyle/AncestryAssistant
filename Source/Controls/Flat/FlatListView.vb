Imports System.ComponentModel

Public Class FlatListView
  Inherits ListView
  Implements IFlatItem

#Region "Fields"

  Private ignoreSizingOfIndex As Integer = -1

#End Region

#Region "Properties"

  <Browsable(False)>
  Public Shadows Property BackColor As Color
    Get
      Return FlatBackColor
    End Get
    Set(value As Color)
      MyBase.BackColor = FlatBackColor
    End Set
  End Property

  <Browsable(True), Category("Flat"), Description("Lighter version of Border color, used to accent the control")>
  Public Property FlatAccentColor As Color = My.Theme.PanelAccentColor Implements IFlatItem.FlatAccentColor

  <Browsable(True), Category("Flat"), Description("Backcolor of the control")>
  Public Property FlatBackColor As Color = My.Theme.PanelBackColor Implements IFlatItem.FlatBackColor

  <Browsable(True), Category("Flat"), Description("Border color, Also commonly used for seperators")>
  Public Property FlatBorderColor As Color = My.Theme.PanelBorderColor Implements IFlatItem.FlatBorderColor

  <Browsable(True), Category("Flat"), Description("Font color")>
  Public Property FlatForeColor As Color = My.Theme.PanelFontColor Implements IFlatItem.FlatForeColor

  <Browsable(True), Category("Flat"), Description("Highlighing color, commonly used when focused")>
  Public Property FlatHighlightColor As Color = My.Theme.PanelHighlightColor Implements IFlatItem.FlatHighlightColor

  <Browsable(True), Category("Flat"), Description("Darker version of Border color, used to show shadowing of the control")>
  Public Property FlatShadowColor As Color = My.Theme.PanelShadowColor Implements IFlatItem.FlatShadowColor

  <Browsable(False)>
  Public Shadows Property ForeColor As Color
    Get
      Return FlatForeColor
    End Get
    Set(value As Color)
      MyBase.ForeColor = FlatForeColor
    End Set
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer, True)
    ' Set up the ListView
    View = View.Details
    HeaderStyle = ColumnHeaderStyle.Clickable
    UseCompatibleStateImageBehavior = False
    FullRowSelect = True
    HotTracking = False
    GridLines = False
    OwnerDraw = True
    MyBase.BackColor = FlatBackColor
    MyBase.ForeColor = FlatForeColor
    Scrollable = True
  End Sub

#End Region

#Region "Private Methods"

  Private Sub FlatListView_ClientSizeChanged(sender As Object, e As EventArgs) Handles Me.ClientSizeChanged
    Debug.Print("ClientSizeChanged=[width={0}, height={1}", Width, Height)
  End Sub

  Private Sub FlatListView_ColumnWidthChanged(sender As Object, e As ColumnWidthChangedEventArgs) Handles Me.ColumnWidthChanged
    If e.ColumnIndex = ignoreSizingOfIndex Then
      ignoreSizingOfIndex = -1
      Exit Sub
    End If
    UpdateColumnSizes()
  End Sub

  Private Sub UpdateColumnSizes()
    If Columns.Count > 0 Then
      Try
        Dim idx As Integer = 0
        Dim lastIdx As Integer = Columns.Count - 1
        Dim x As Integer = 0
        'Debug.Print("Client: w={0}", ClientSize.Width)
        For Each col As ColumnHeader In Columns
          Dim newWidth As Integer = ClientSize.Width - x
          If idx = lastIdx Then
            'Debug.Print("Resize   Col({3})=[x={0}, w={1}, newW={2}", x, col.Width, newWidth, idx)
            If newWidth > 0 And newWidth <> col.Width Then
              ignoreSizingOfIndex = lastIdx
              col.Width = newWidth
            End If
          Else
            'Debug.Print("         Col({3})=[x={0}, w={1}, newW={2}", x, col.Width, col.Width, idx)
          End If
          idx += 1
          x += col.Width
        Next
      Catch ex As Exception

      End Try
    End If

  End Sub

#End Region

#Region "Protected Methods"

  Protected Overrides Sub OnDrawColumnHeader(ByVal e As DrawListViewColumnHeaderEventArgs)
    Debug.Print("DrawColumnHeader")

    'e.DrawBackground()
    e.Graphics.FillRectangle(New SolidBrush(FlatBackColor), e.Bounds)
    Dim p As New Pen(FlatBorderColor, 1)
    Dim b As Rectangle = e.Bounds
    e.Graphics.DrawLine(p, b.X, b.Y, b.X, b.Y + b.Height - 1)
    'e.Graphics.DrawLine(p, b.X + b.Width - 1, b.Y, b.X + b.Width - 1, b.Y + b.Height - 1)
    e.Graphics.DrawLine(p, b.X, b.Y + b.Height - 1, b.X + b.Width - 1, b.Y + b.Height - 1)
    ' Draw custom column headers
    e.Graphics.DrawString(e.Header.Text, Font, New SolidBrush(FlatForeColor), New PointF(b.X + 2, b.Y))

    'e.DrawDefault = True
  End Sub

  Protected Overrides Sub OnDrawItem(ByVal e As DrawListViewItemEventArgs)
    Debug.Print("DrawItem({0})", e.ItemIndex, e.State.ToString)
    ' Draw custom items
    'e.Graphics.DrawRectangle(New Pen(Color.Red, 2), e.Bounds)
    e.Graphics.FillRectangle(New SolidBrush(FlatBackColor), e.Bounds)
    e.Graphics.DrawString(e.Item.Text, Font, New SolidBrush(FlatForeColor), New PointF(e.Bounds.X + 2, e.Bounds.Y))
    If e.State.HasFlag(ListViewItemStates.Selected) Then
      e.Graphics.DrawLine(New Pen(FlatHighlightColor), 0, e.Bounds.Bottom - 1, e.Bounds.Width, e.Bounds.Bottom - 1)
    End If
  End Sub

  Protected Overrides Sub OnDrawSubItem(ByVal e As DrawListViewSubItemEventArgs)
    'Debug.Print("DrawItem({0},{1})={2}", e.ItemIndex, e.ColumnIndex, e.ItemState.ToString)
    'Debug.Print("DrawSubItem")

    e.Graphics.FillRectangle(New SolidBrush(FlatBackColor), e.Bounds)
    e.Graphics.DrawString(e.SubItem.Text, Font, New SolidBrush(FlatForeColor), New PointF(e.Bounds.X + 2, e.Bounds.Y))
    'e.Graphics.DrawRectangle(New Pen(Color.Red, 2), e.Bounds)
    '' Draw custom sub-items
    'If e.ColumnIndex = 0 Then
    '  ' Draw icon in the first column
    '  Dim iconRect As Rectangle = e.Bounds
    '  iconRect.Width = Me.SmallImageList.ImageSize.Width
    '  e.Graphics.DrawImage(Me.SmallImageList.Images(e.Item.ImageIndex), iconRect.Location)
    'Else
    '  ' Draw text in other columns
    '  e.DrawText()
    'End If
  End Sub

#End Region

End Class