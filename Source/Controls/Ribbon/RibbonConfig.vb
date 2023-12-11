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
    Dim itm As Item = GetItem(refItem.id)
    If refItem.col > 0 Then itm.col = refItem.col
    If refItem.colspan > 0 Then itm.colspan = refItem.colspan
    If refItem.row > 0 Then itm.row = refItem.row
    If refItem.rowspan > 0 Then itm.rowspan = refItem.rowspan
    If Len(refItem.name) > 0 Then itm.name = refItem.name
    If refItem.attributes IsNot Nothing Then
      For Each rAvp As AttributeValuePair In refItem.attributes
        Dim add As Boolean = True
        For Each avp As AttributeValuePair In itm.attributes
          If rAvp.Attribute.Equals(avp.Attribute) Then
            add = False
            avp.Value = rAvp.Value
          End If
        Next
        If add Then
          itm.attributes.Add(rAvp)
        End If
      Next
    End If
    Return itm
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
    Public Property itemtype As String
      Get
        Return ribbonitemtype.ToString
      End Get
      Set(value As String)
        If Val(value) > 0 Then
          ribbonitemtype = CType(value, RibbonItemType)
        Else
          ribbonitemtype = DirectCast([Enum].Parse(GetType(RibbonItemType), value), RibbonItemType)
        End If
      End Set
    End Property
    Public Property name As String = ""
    Public Property ribbonitemtype As RibbonItemType
    Public Property row As Double
    Public Property rowspan As Double
    Public Property visible As Boolean = True

#End Region

#Region "Public Methods"

    Public Function GetAttribute(attributeName As String) As String
      For Each kv As AttributeValuePair In attributes
        If kv.Attribute.Equals(attributeName) Then
          Return kv.Value
        End If
      Next
      Return String.Empty
    End Function

    Public Function GetIcon() As Image
      Return My.Resources.ResourceManager.GetObject(GetAttribute("icon"))
    End Function

#End Region

  End Class

#End Region

End Class