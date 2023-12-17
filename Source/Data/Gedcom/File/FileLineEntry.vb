Public Class FileLineEntry

  Public ReadOnly Property keyFlat As String

  Public ReadOnly Property line As String

  Public ReadOnly Property lineData As String

  Public ReadOnly Property lineIdx As Double

  Public ReadOnly Property lineLvl As Integer

  Public ReadOnly Property lineRef As String

  Public ReadOnly Property lineTag As String

  Public Sub New(dlineIdx As Double, ilineLvl As Integer, slineTag As String, slineRef As String, slineData As String, skeyFlat As String, sline As String)
    lineIdx = dlineIdx
    lineLvl = ilineLvl
    lineTag = slineTag
    lineRef = slineRef
    lineData = slineData
    keyFlat = skeyFlat
    line = sline
  End Sub

End Class