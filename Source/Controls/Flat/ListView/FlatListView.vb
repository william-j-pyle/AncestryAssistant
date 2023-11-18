Public Class FlatListView
  Inherits ListView

#Region "Public Constructors"

  Public Sub New()
    ' Set up the ListView
    View = View.Details
    FullRowSelect = True
    GridLines = False
    OwnerDraw = True
  End Sub

#End Region

#Region "Protected Methods"

  Protected Overrides Sub OnDrawColumnHeader(ByVal e As DrawListViewColumnHeaderEventArgs)
    e.Graphics.FillRectangle(New SolidBrush(My.Theme.AppBackColor), e.Bounds)
    e.Graphics.DrawRectangle(New Pen(Color.Red, 2), e.Bounds)
    ' Draw custom column headers
    'e.DrawDefault = True
    e.DrawText()
  End Sub

  Protected Overrides Sub OnDrawItem(ByVal e As DrawListViewItemEventArgs)
    ' Draw custom items
    e.DrawDefault = True
  End Sub

  Protected Overrides Sub OnDrawSubItem(ByVal e As DrawListViewSubItemEventArgs)
    e.DrawDefault = True
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