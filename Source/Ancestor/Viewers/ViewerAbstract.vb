Public MustInherit Class AbstractViewer
  Inherits UserControl

  Public Const ASSISTANTVIEWER_NOANCESTOR = "No Ancestor Selected"
  Public Const ASSISTANTVIEWER_NODATA = "No Data Available"

  Public Event AncestorAssigned()
  Public Event AncestorUpdated()

  Friend Ancestor As AncestorCollection.Ancestor

  Public Sub SetAncestor(activeAncestor As AncestorCollection.Ancestor)
    Ancestor = activeAncestor
    RaiseEvent AncestorAssigned()
  End Sub

  Public Sub RefreshAncestor()
    RaiseEvent AncestorUpdated()
  End Sub



End Class
