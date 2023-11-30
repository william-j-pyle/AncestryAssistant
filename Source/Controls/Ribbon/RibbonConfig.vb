Public Class RibbonConfig

#Region "Fields"

  Public Const GROUP_COL_SPACING As Integer = 2
  Public Const GROUP_COL_WIDTH As Integer = 24
  Public Const GROUP_LEFT_SPACING As Integer = 4
  Public Const GROUP_ROW_HEIGHT As Integer = 24
  Public Const GROUP_ROW_SPACING As Integer = 0
  Public Const GROUP_TOP_SPACING As Integer = 4
  Public Const RIBBON_BAR_HEIGHT As Integer = 100
  Public Const RIBBON_TAB_HEIGHT As Integer = 20

#End Region

#Region "Properties"

  Public Property bars As List(Of Bar)

  Public Property groups As List(Of Group)

  Public Property items As List(Of Item)

#End Region

#Region "Public Methods"

  Public Function GetGroup(id As Integer) As Group
    For Each grp As Group In groups
      If grp.id = id Then Return grp
    Next
    Return Nothing
  End Function

  Public Function GetGroup(refGroup As Group) As Group
    Return GetGroup(refGroup.id)
  End Function

  Public Function GetItem(id As Integer) As Item
    For Each itm As Item In items
      If itm.id = id Then Return itm
    Next
    Return Nothing
  End Function

  Public Function GetItem(refItem As Item) As Item
    Return GetItem(refItem.id)
  End Function

#End Region

#Region "Classes"

  Public Class AttributeValuePair

#Region "Properties"

    Public Property Attribute As String
    Public Property Value As String

#End Region

  End Class

  Public Class Bar

#Region "Properties"

    Public Property enabled As Boolean = True
    Public Property groups As List(Of Group)
    Public Property id As Integer
    Public Property name As String
    Public Property showpage As Boolean = False
    Public Property text As String = ""
    Public Property visible As Boolean = True

#End Region

  End Class

  Public Class Group

#Region "Properties"

    Public Property enabled As Boolean = True
    Public Property id As Integer
    Public Property items As List(Of Item)
    Public Property name As String
    Public Property showpanel As Boolean = False
    Public Property text As String = ""
    Public Property visible As Boolean = True

#End Region

  End Class

  Public Class Item

#Region "Properties"

    Public Property attributes As List(Of AttributeValuePair)
    Public Property col As Double
    Public Property colspan As Double
    Public Property enabled As Boolean = True
    Public Property id As Integer
    Public Property itemtype As RibbonItemType
    Public Property name As String = ""
    Public Property row As Double
    Public Property rowspan As Double
    Public Property text As String = ""
    Public Property visible As Boolean = True

#End Region

#Region "Public Methods"

    Public Function getAttribute(attributeName As String) As String
      For Each kv As AttributeValuePair In attributes
        If kv.Attribute.Equals(attributeName) Then
          Return kv.Value
        End If
      Next
      Return String.Empty
    End Function

    Public Function getIcon() As Image
      Return My.Resources.ResourceManager.GetObject(getAttribute("icon"))
    End Function

#End Region

  End Class

#End Region

End Class