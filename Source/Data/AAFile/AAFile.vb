Imports System.IO
Imports System.Text

Public Class AAFile

#Region "Properties"

  Public Property AAFileName As String
    Get
      Return sAAFileName
    End Get
    Set(value As String)
      sAAFileName = value
      Load()
    End Set
  End Property

  Public Property AAFileType As AAFileTypeEnum
    Get
      Return iAAFileType
    End Get
    Set(value As AAFileTypeEnum)
      If value >= 0 Then
        iAAFileType = value
      End If
    End Set
  End Property

  Public Property CanSave As Boolean = True
  Public ReadOnly Property ColumnNames As String()
    Get
      Return aValueHeaders
    End Get
  End Property

  Public ReadOnly Property Count As Integer
    Get
      Select Case AAFileType
        Case AAFileTypeEnum.KEYVALUEPAIRS
          Return dKeyValuePair.Count
        Case AAFileTypeEnum.SINGLEVALUE
          If sSingleValue.Length > 0 Then
            Return 1
          Else
            Return 0
          End If
        Case AAFileTypeEnum.LISTARRAY
          Return aValues.Count
      End Select
      Return 0
    End Get
  End Property

  Public ReadOnly Property IsDirty As Boolean
    Get
      Return _IsDirty
    End Get
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New()
    Initialize()
  End Sub

  Public Sub New(FileName As String, Optional FileType As AAFileTypeEnum = AAFileTypeEnum.UNDEFINED)
    AAFileType = FileType
    AAFileName = FileName
  End Sub

#End Region

#Region "Private Methods"

  Private Sub Initialize()
    aValueHeaders = {}
    aValues = New ArrayList()
    sSingleValue = ""
    dKeyValuePair = New Dictionary(Of String, String)
    _IsDirty = False
  End Sub

  Private Sub Load()
    Initialize()
    If File.Exists(AAFileName) Then
      Dim lines() As String = File.ReadAllLines(AAFileName)
      If lines.Length > 0 Then
        AAFileType = CInt(lines(0).Substring(0, 1))
        Select Case AAFileType
          Case AAFileTypeEnum.KEYVALUEPAIRS ' Key/Value Pairs
            Dim pair As String()
            For l As Integer = 1 To lines.Length - 1
              pair = lines(l).Split(Chr(FIELD_SEPERATOR_CODE))
              If pair.Length >= 2 Then
                Value(pair(0)) = pair(1).Trim()
              End If
            Next
            _IsDirty = False
          Case AAFileTypeEnum.SINGLEVALUE ' Single Value
            Dim sb As New StringBuilder()
            If lines.Length > 1 Then
              sb.Append(lines(1))
              For l As Integer = 2 To lines.Length - 1
                sb.Append(vbCrLf)
                sb.Append(lines(l))
              Next
            End If
            Value = sb.ToString
            _IsDirty = False
          Case AAFileTypeEnum.LISTARRAY ' Array
            If lines.Length > 1 Then
              aValueHeaders = lines(1).Split(Chr(FIELD_SEPERATOR_CODE))
              For l As Integer = 2 To lines.Length - 1
                aValues.Add(lines(l).Split(Chr(FIELD_SEPERATOR_CODE)))
              Next
            End If
            _IsDirty = False
        End Select
      End If
    End If
  End Sub

#End Region

#Region "Public Methods"

  Public Function GetHeaders() As String()
    Return aValueHeaders
  End Function

  Public Function GetTableData() As ArrayList
    Dim data As New ArrayList From {
      aValueHeaders
    }
    data.AddRange(aValues)
    Return data
  End Function

  Public Function GetValues() As ArrayList
    Return aValues
  End Function

  Public Sub Save()
    If Not CanSave Then Exit Sub
    If AAFileName.Length = 0 Or AAFileType < 0 Then
      Throw New FormatException("Both Filename and FileType must be set to perform a save")
      Exit Sub
    End If
    Dim sb As New StringBuilder
    sb.Append(AAFileType)
    Select Case AAFileType
      Case AAFileTypeEnum.KEYVALUEPAIRS
        For Each key As String In dKeyValuePair.Keys
          sb.AppendLine()
          sb.Append(key)
          sb.Append(Chr(FIELD_SEPERATOR_CODE))
          sb.Append(dKeyValuePair.Item(key))
        Next
      Case AAFileTypeEnum.SINGLEVALUE
        sb.AppendLine()
        sb.Append(sSingleValue)
      Case AAFileTypeEnum.LISTARRAY
        Dim sep As String = ""
        sb.AppendLine()
        For Each hdr As String In aValueHeaders
          sb.Append(sep)
          sb.Append(hdr)
          sep = Chr(FIELD_SEPERATOR_CODE)
        Next
        For Each line() As String In aValues
          sb.AppendLine()
          sep = ""
          For Each fld As String In line
            sb.Append(sep)
            sb.Append(fld)
            sep = Chr(FIELD_SEPERATOR_CODE)
          Next
        Next
    End Select
    File.WriteAllText(AAFileName, sb.ToString)
    _IsDirty = False
  End Sub

  Public Sub SetHeaders(headers() As String)
    aValueHeaders = headers
    _IsDirty = True
  End Sub

  Public Sub SetTableData(table As List(Of List(Of String)))
    If table.Count > 0 Then
      aValueHeaders = table.Item(0).ToArray()
      aValues.Clear()
      For i As Integer = 1 To table.Count - 1
        aValues.Add(table.Item(i).ToArray())
      Next
      _IsDirty = True
    End If
  End Sub

  Public Sub SetTableData(table As ArrayList)
    aValueHeaders = table.Item(0)
    aValues.Clear()
    For i As Integer = 1 To table.Count - 1
      aValues.Add(table.Item(i))
    Next
    _IsDirty = True
  End Sub

  Public Sub SetValues(values As ArrayList)
    aValues = values
    _IsDirty = True
  End Sub

#End Region

#Region "Indexers"

  Public Property Value(Optional key As String = "") As String
    Get
      Select Case AAFileType
        Case AAFileTypeEnum.KEYVALUEPAIRS ' Key/Value Pairs
          If dKeyValuePair.ContainsKey(key) Then
            Return dKeyValuePair.Item(key)
          Else
            Return String.Empty
          End If
        Case AAFileTypeEnum.SINGLEVALUE ' Single Value
          Return sSingleValue
      End Select
      Return String.Empty
    End Get
    Set(value As String)
      Select Case AAFileType
        Case AAFileTypeEnum.KEYVALUEPAIRS ' Key/Value Pairs
          If dKeyValuePair.ContainsKey(key) Then
            dKeyValuePair.Item(key) = value
          Else
            dKeyValuePair.Add(key, value)
          End If
        Case AAFileTypeEnum.SINGLEVALUE ' Single Value
          sSingleValue = value
      End Select
      _IsDirty = True
    End Set
  End Property

#End Region

#Region "Fields"

  Const FIELD_SEPERATOR_CODE As Integer = 175

  Private _IsDirty As Boolean = False

  Private aValueHeaders() As String = {}

  Private aValues As New ArrayList()

  Private dKeyValuePair As New Dictionary(Of String, String)

  Private iAAFileType As AAFileTypeEnum = AAFileTypeEnum.UNDEFINED

  Private sAAFileName As String = ""

  Private sSingleValue As String = ""

#End Region

End Class