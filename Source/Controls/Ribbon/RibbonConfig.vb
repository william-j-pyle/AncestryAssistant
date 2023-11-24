Public Class RibbonConfig

#Region "Fields"

  Public Const GRID_HEIGHTWIDTH As Integer = 24

  Public Const RIBBON_BARHEIGHT As Integer = 100

  Public Const RIBBON_TABHEIGHT As Integer = 20

#End Region

#Region "Properties"

  Public Property bars As List(Of Bar)

  Public Property groups As List(Of Group)

  Public Property items As List(Of Item)

#End Region

#Region "Public Methods"

  Public Function GetGroup(id As String) As Group
    For Each grp As Group In groups
      If grp.id = id Then Return grp
    Next
    Return Nothing
  End Function

  Public Function GetGroup(refGroup As Group) As Group
    Return GetGroup(refGroup.id)
  End Function

  Public Function GetItem(id As String) As Item
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

  Public Class Bar

#Region "Properties"

    Public Property enabled As Boolean
    Public Property id As String
    Public Property name As String
    Public Property showpage As Boolean
    Public Property usesgroups As List(Of Group)
    Public Property visible As Boolean

#End Region

  End Class

  Public Class Grid

#Region "Properties"

    Public Property location As GridLocation
    Public Property size As GridSize

#End Region

  End Class

  ''' <summary>
  '''     The Row/Column location of the item with the parent group
  ''' </summary>
  Public Class GridLocation

#Region "Properties"

    Public ReadOnly Property Point As Point
      Get
        Return New Point(x, y)
      End Get
    End Property
    ''' <summary>
    '''     Column location within the Ribbon Group. 1-n. Group will add columns to match the request.
    ''' </summary>
    Public Property x As Integer
    ''' <summary>
    '''     Row location within a Group. 1-3. Locations outside the available range will result in the item not being displayed.
    ''' </summary>
    Public Property y As Integer

#End Region

  End Class

  Public Class GridSize

#Region "Properties"

    Public Property height As Integer
    Public ReadOnly Property Size As Size
      Get
        Return New Size(width, height)
      End Get
    End Property
    Public Property width As Integer

#End Region

  End Class

  Public Class Group
    Implements ICloneable

#Region "Properties"

    Public Property enabled As Boolean = Nothing
    Public Property id As String = Nothing
    Public Property name As String = Nothing
    Public Property showpanel As Boolean = Nothing
    Public Property usesitems As List(Of Item) = Nothing
    Public Property visible As Boolean = Nothing

#End Region

#Region "Public Methods"

    Public Function Clone() As Object Implements ICloneable.Clone
      Return New [Group] With {
    .enabled = enabled,
    .id = id,
    .name = name,
    .showpanel = showpanel,
    .usesitems = usesitems,
    .visible = visible
    }
    End Function

    Public Overrides Function ToString() As String
      Return MyBase.ToString()
    End Function

#End Region

  End Class

  Public Class Item

#Region "Properties"

    Public Property enabled As Boolean
    Public Property grid As Grid
    Public Property icon As String
    Public Property id As String
    Public Property itemtype As RibbonItemType
    Public Property name As String
    Public Property visible As Boolean

#End Region

  End Class

#End Region

End Class