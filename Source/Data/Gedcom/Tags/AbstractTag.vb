Public MustInherit Class AbstractTag

#Region "Fields"

  Public isRootTag As Boolean
  Public keyTagBase As String
  Public lvlTagBase As Integer
  Public realTag As String
  Public rootTag As String
  Public tagStarted As Boolean

#End Region

#Region "Properties"

  Public Property data As Gedcom
  Public Property ID As String
  Public Property TagOwnerID As String

#End Region

#Region "Public Constructors"

  Public Sub New(gdata As Gedcom, grootTag As String, gisRootTag As Boolean, gownerID As String, grealTag As String)
    initObject(gdata, grootTag, gisRootTag, gownerID, grealTag)
  End Sub

  Public Sub New(gdata As Gedcom, grootTag As String, gisRootTag As Boolean, gownerID As String)
    initObject(gdata, grootTag, gisRootTag, gownerID, String.Empty)
  End Sub

  Public Sub New(gdata As Gedcom, grootTag As String, gisRootTag As Boolean)
    initObject(gdata, grootTag, gisRootTag, String.Empty, String.Empty)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub initObject(gdata As Gedcom, grootTag As String, gisRootTag As Boolean, gownerID As String, grealTag As String)
    data = gdata
    rootTag = grootTag
    realTag = grealTag
    isRootTag = gisRootTag
    TagOwnerID = gownerID
    If setTagDefaults() Then
      generateID()
      tagLoop()
    End If
  End Sub

  Private Function setTagDefaults() As Boolean
    Dim useTag As String = rootTag
    If Not realTag.Equals(String.Empty) Then
      useTag = realTag
    End If
    keyTagBase = ""
    ' Is me a baseTag? Base tags have Level=0 Base tags should match G_BASETAG
    If isRootTag And data.lineLevel() = 0 And data.tag().Equals(rootTag) Then
      keyTagBase = rootTag
      lvlTagBase = 0
    Else
      ' Non BaseTags should have Level>0 Non BaseTags should have BASETAG at the end of the keyPath
      If Not isRootTag And data.lineLevel > 0 And data.key().EndsWith(useTag) Then
        keyTagBase = data.key()
        lvlTagBase = data.lineLevel()
      End If
    End If
    ' Set the other case elses here

    Return Not keyTagBase.Equals(String.Empty)
  End Function

  Private Sub tagLoop()
    ' Begin processing loop
    While data.hasNext()
      ' Have we completed the current tag
      If tagStarted And data.lineLevel() <= lvlTagBase Then
        data.prevRow()
        Return
      End If
      Dim activeKey As String = data.key().Replace(keyTagBase, rootTag)
      If activeKey.Equals(rootTag) Then
        data.addObject(Me)
        tagStarted = True
      End If
      If Not processTag(activeKey) Then
        Debug.Print("MISSED_TAG: [key={0}, data.key={1}]", activeKey, data.key())
      End If
      data.nextRow()
    End While

  End Sub

#End Region

#Region "Public Methods"

  Public Overridable Sub generateID()
    'NOOP
  End Sub

  Public MustOverride Function processTag(key As String) As Boolean

  Public Function wasTagProcessed() As Boolean
    Return tagStarted
  End Function

#End Region

End Class