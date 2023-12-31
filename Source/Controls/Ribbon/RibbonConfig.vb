﻿Public Class RibbonConfig

  Public Const GROUP_COL_SPACING As Integer = 2
  Public Const GROUP_COL_WIDTH As Integer = 24
  Public Const GROUP_LEFT_SPACING As Integer = 4
  Public Const GROUP_ROW_HEIGHT As Integer = 24
  Public Const GROUP_ROW_SPACING As Integer = 0
  Public Const GROUP_TOP_SPACING As Integer = 4
  Public Const RIBBON_BAR_HEIGHT As Integer = 100
  Public Const RIBBON_TAB_HEIGHT As Integer = 20

  Public Property bars As List(Of Bar)

  Public Property groups As List(Of Group)

  Public Property items As List(Of Item)

  Public Sub AppendConfig(config As RibbonConfig)
    If config IsNot Nothing Then
      If config.items IsNot Nothing Then
        For Each itm As Item In config.items
          items.Add(itm)
        Next
      End If
      If config.groups IsNot Nothing Then
        For Each grp As Group In config.groups
          groups.Add(grp)
        Next
      End If
      If config.bars IsNot Nothing Then
        For Each br As Bar In config.bars
          bars.Add(br)
        Next
      End If
    End If
  End Sub

  Public Function GetGroup(id As Integer) As Group
    If groups Is Nothing Then Return Nothing
    Try
      For Each grp As Group In groups
        If grp.id = id Then Return grp
      Next
    Catch ex As Exception

    End Try
    Return Nothing
  End Function

  Public Function GetGroup(refGroup As Group) As Group
    If groups Is Nothing Then Return refGroup
    Dim grp As Group = GetGroup(refGroup.id)
    If grp Is Nothing Then Return refGroup
    Return grp
  End Function

  Public Function GetItem(id As Integer) As Item
    If items Is Nothing Then Return Nothing
    Try
      For Each itm As Item In items
        If itm.id = id Then Return itm
      Next
    Catch ex As Exception

    End Try
    Return Nothing
  End Function

  Public Function GetItem(refItem As Item) As Item
    If items Is Nothing Then Return refItem
    Dim itm As Item = GetItem(refItem.id)
    If itm Is Nothing Then Return refItem
    If refItem.col > 0 Then itm.col = refItem.col
    If refItem.colspan > 1 Then itm.colspan = refItem.colspan
    If refItem.row > 0 Then itm.row = refItem.row
    If refItem.rowspan > 1 Then itm.rowspan = refItem.rowspan
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

  Public Class AttributeValuePair

    Public Property Attribute As String
    Public Property Value As String

  End Class

  Public Class Bar

    Public Property attributes As List(Of AttributeValuePair)
    Public Property enabled As Boolean = True
    Public Property groups As List(Of Group)
    Public Property id As Integer
    Public Property name As String
    Public Property showpage As Boolean = False
    Public Property text As String = ""
    Public Property visible As Boolean = True

    Public Function GetAttribute(attributeName As String, Optional defaultValue As Object = Nothing) As Object
      If attributes Is Nothing Then Return defaultValue
      For Each kv As AttributeValuePair In attributes
        If kv.Attribute.Equals(attributeName) Then
          Return kv.Value
        End If
      Next
      Return defaultValue
    End Function

  End Class

  Public Class Group

    Public Property attributes As List(Of AttributeValuePair)
    Public Property enabled As Boolean = True
    Public Property id As Integer
    Public Property items As List(Of Item)
    Public Property name As String
    Public Property showpanel As Boolean = False
    Public Property text As String = ""
    Public Property visible As Boolean = True

    Public Function GetAttribute(attributeName As String, Optional defaultValue As Object = Nothing) As Object
      If attributes Is Nothing Then Return defaultValue
      For Each kv As AttributeValuePair In attributes
        If kv.Attribute.Equals(attributeName) Then
          Return kv.Value
        End If
      Next
      Return defaultValue
    End Function

  End Class

  Public Class Item

    Public Property attributes As List(Of AttributeValuePair)
    Public Property col As Double = 0
    Public Property colspan As Double = 1
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
    Public Property row As Double = 0
    Public Property rowspan As Double = 1
    Public Property visible As Boolean = True

    Public Function GetAttribute(attributeName As String, Optional defaultValue As Object = Nothing) As Object
      If attributes Is Nothing Then Return defaultValue
      For Each kv As AttributeValuePair In attributes
        If kv.Attribute.Equals(attributeName) Then
          Return kv.Value
        End If
      Next
      Return defaultValue
    End Function

    Public Function GetIcon() As Image
      Return TryCast(My.Resources.ResourceManager.GetObject(CStr(GetAttribute("icon"))), Image)
    End Function

  End Class

End Class