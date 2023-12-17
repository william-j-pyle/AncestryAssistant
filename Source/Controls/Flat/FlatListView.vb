Imports System.ComponentModel

Public Class FlatListView
  Inherits ListView
  Implements IFlatItem

  Private _FilterCriteria As String = String.Empty
  Private activeItems As List(Of ListViewItem)
  Private allItems As List(Of ListViewItem)
  Private columnSorting As Integer = 0
  Private columnSortingOrder As SortOrder = SortOrder.None
  Private ignoreSizingOfIndex As Integer = -1

  <Browsable(False)>
  Public Shadows Property BackColor As Color
    Get
      Return FlatBackColor
    End Get
    Set(value As Color)
      MyBase.BackColor = FlatBackColor
    End Set
  End Property
  Public Property FilterCriteria As String
    Get
      Return _FilterCriteria
    End Get
    Set(value As String)
      If Not value.Equals(_FilterCriteria) Then
        _FilterCriteria = value
        Filter(value)
      End If
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
  Public ReadOnly Property IsFiltered As Boolean
    Get
      Return _FilterCriteria.Length > 0
    End Get
  End Property
  Public ReadOnly Property IsSorted As Boolean
    Get
      Return Not columnSortingOrder = SortOrder.None
    End Get
  End Property
  Public ReadOnly Property SortColumnIndex As Integer
    Get
      Return columnSorting
    End Get
  End Property

  Public ReadOnly Property SortColumnOrder As SortOrder
    Get
      Return columnSortingOrder
    End Get
  End Property

  Public Sub New()
    SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer, True)
    ' Set up the ListView
    View = View.Details
    HeaderStyle = ColumnHeaderStyle.Nonclickable
    UseCompatibleStateImageBehavior = False
    FullRowSelect = True
    HotTracking = False
    HoverSelection = False
    GridLines = False
    DoubleBuffered = True
    OwnerDraw = True
    MyBase.BackColor = FlatBackColor
    MyBase.ForeColor = FlatForeColor
    Scrollable = True
  End Sub

  Private Sub ApplyItemSortFilter()
    Dim selText As String = String.Empty
    If SelectedItems.Count > 0 Then
      selText = SelectedItems.Item(0).Text
    End If
    InitItems()
    Items.Clear()
    If FilterCriteria.Equals("") Then
      activeItems = allItems
    Else
      activeItems = allItems.Where(Function(item) item.SubItems(0).Text.ToLower.Contains(FilterCriteria.ToLower)).ToList()
    End If
    Select Case columnSortingOrder
      Case SortOrder.Ascending
        Items.AddRange(activeItems.OrderBy(Function(item) item.SubItems(columnSorting).Text).ToList().ToArray())
      Case SortOrder.Descending
        Items.AddRange(activeItems.OrderByDescending(Function(item) item.SubItems(columnSorting).Text).ToList().ToArray())
      Case Else
        Items.AddRange(activeItems.ToArray)
    End Select
    If Not selText.Equals(String.Empty) Then
      For Each item As ListViewItem In Items
        If item.Text.Equals(selText) Then
          item.Selected = True
          item.Focused = True
          item.EnsureVisible()
          Exit For
        End If
      Next
    End If

    Invalidate(True)
  End Sub

  Private Sub FlatListView_ClientSizeChanged(sender As Object, e As EventArgs) Handles Me.ClientSizeChanged

    'Debug.Print("ClientSizeChanged=[width={0}, height={1}", Width, Height)
  End Sub

  Private Sub FlatListView_ColumnWidthChanged(sender As Object, e As ColumnWidthChangedEventArgs) Handles Me.ColumnWidthChanged
    If e.ColumnIndex = ignoreSizingOfIndex Then
      ignoreSizingOfIndex = -1
      Exit Sub
    End If
    UpdateColumnSizes()
  End Sub

  Private Sub HeaderClick(sender As Object, e As ColumnClickEventArgs) Handles Me.ColumnClick
    If e.Column = columnSorting Then
      Select Case columnSortingOrder
        Case SortOrder.None
          columnSortingOrder = SortOrder.Ascending
        Case SortOrder.Ascending
          columnSortingOrder = SortOrder.Descending
        Case SortOrder.Descending
          columnSortingOrder = SortOrder.None
      End Select
    Else
      columnSorting = e.Column
      columnSortingOrder = SortOrder.Ascending
    End If
    Sort(columnSorting, columnSortingOrder)
  End Sub

  Private Sub InitItems()
    If allItems IsNot Nothing And activeItems IsNot Nothing Then
      If allItems.Count > 0 And allItems.Count >= Items.Count Then Exit Sub
    End If
    allItems = New List(Of ListViewItem)
    For Each item As ListViewItem In Items
      allItems.Add(item)
    Next
    activeItems = allItems
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

  Protected Overrides Sub OnDrawColumnHeader(ByVal e As DrawListViewColumnHeaderEventArgs)
    'Debug.Print("DrawColumnHeader({0})=[{1}, {2}]", e.ColumnIndex, columnSorting, columnSortingOrder)

    'e.DrawBackground()
    e.Graphics.FillRectangle(New SolidBrush(FlatBackColor), e.Bounds)
    Dim p As New Pen(FlatBorderColor, 1)
    Dim b As Rectangle = e.Bounds
    'e.Graphics.DrawLine(p, b.X, b.Y, b.X, b.Y + b.Height - 1)
    If e.ColumnIndex < Columns.Count - 1 Then
      e.Graphics.DrawLine(p, b.X + b.Width - 1, b.Y, b.X + b.Width - 1, b.Y + b.Height - 1)
    End If
    e.Graphics.DrawLine(p, b.X, b.Y + b.Height - 1, b.X + b.Width - 1, b.Y + b.Height - 1)
    ' Draw custom column headers
    e.Graphics.DrawString(e.Header.Text, Font, New SolidBrush(FlatForeColor), New PointF(b.X + 2, b.Y))

    Dim x As Integer = b.X + TextRenderer.MeasureText(e.Header.Text, Font).Width + 4
    Dim y As Integer = b.Y
    If e.ColumnIndex = columnSorting And columnSortingOrder > 0 Then
      'Debug.Print("SORT({0})={1}", e.ColumnIndex, columnSortingOrder)
      p = New Pen(FlatForeColor, 1)
      Dim d As Integer = 1
      If columnSortingOrder = 2 Then
        d = -1
        y += 16
      End If
      With e.Graphics
        .DrawLine(p, x + 5, y + (7 * d), x + 8, y + (10 * d))
        .DrawLine(p, x + 9, y + (10 * d), x + 12, y + (7 * d))

        .DrawLine(p, x + 6, y + (7 * d), x + 11, y + (7 * d))
        .DrawLine(p, x + 7, y + (8 * d), x + 11, y + (8 * d))
        .DrawLine(p, x + 8, y + (9 * d), x + 9, y + (9 * d))
      End With
    Else
      'Debug.Print("CLEAR({0})={1}", e.ColumnIndex, columnSortingOrder)
      e.Graphics.FillRectangle(New SolidBrush(FlatBackColor), x, y, 16, 16)
    End If
    e.DrawDefault = False
  End Sub

  Protected Overrides Sub OnDrawItem(ByVal e As DrawListViewItemEventArgs)
    e.DrawDefault = False
  End Sub

  Protected Overrides Sub OnDrawSubItem(ByVal e As DrawListViewSubItemEventArgs)
    'Debug.Print("DrawSubItem({0},{1})={2}    {3}", e.ItemIndex, e.ColumnIndex, e.ItemState.ToString, e.SubItem.Bounds)
    Dim rec As Rectangle
    Dim Txt As String
    If e.ColumnIndex = 0 Then
      Txt = e.Item.Text
      rec = e.Item.GetBounds(ItemBoundsPortion.Label)
    Else
      Txt = e.SubItem.Text
      rec = e.SubItem.Bounds
    End If

    If e.Item.Selected And e.Item.Focused Then
      e.Graphics.FillRectangle(New SolidBrush(FlatHighlightColor), rec)
      e.Graphics.DrawString(Txt, Font, New SolidBrush(FlatBackColor), New PointF(rec.X + 2, rec.Y))
    Else
      e.Graphics.FillRectangle(New SolidBrush(FlatBackColor), rec)
      e.Graphics.DrawString(Txt, Font, New SolidBrush(FlatForeColor), New PointF(rec.X + 2, rec.Y))
    End If
  End Sub

  Public Sub ClearFilter()
    _FilterCriteria = String.Empty
    ApplyItemSortFilter()
  End Sub

  Public Sub Filter(criteria As String)
    _FilterCriteria = criteria
    ApplyItemSortFilter()
  End Sub

  Public Overloads Sub Sort(columnIndex As Integer, order As SortOrder)
    columnSorting = columnIndex
    columnSortingOrder = order
    ApplyItemSortFilter()
  End Sub

End Class