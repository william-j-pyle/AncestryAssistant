Imports System.Globalization

Public Class GedDate

#Region "Fields"

  Private bAbout As Boolean = False
  Private bAfter As Boolean = False
  Private bBefore As Boolean = False
  Private bDay As Boolean = False
  Private bMonth As Boolean = False
  Private bRange As Boolean = False
  Private bValid As Boolean = False
  Private bYear As Boolean = False
  Private dResultDate As Date
  Private sCleanDateString As String = ""
  Private sFormat As String = ""
  Private sSourceDateString As String = ""

#End Region

#Region "Properties"

  Public ReadOnly Property DateFormat As String
    Get
      Return sFormat
    End Get
  End Property

  Public ReadOnly Property Day As Integer
    Get
      If bValid And bDay Then
        Return dResultDate.Day
      Else
        Return 0
      End If
    End Get
  End Property

  Public ReadOnly Property HasDay As Boolean
    Get
      Return bDay
    End Get
  End Property

  Public ReadOnly Property HasMonth As Boolean
    Get
      Return bMonth
    End Get
  End Property

  Public ReadOnly Property HasYear As Boolean
    Get
      Return bYear
    End Get
  End Property

  Public ReadOnly Property IsAbout As Boolean
    Get
      Return bAbout
    End Get
  End Property

  Public ReadOnly Property IsAfter As Boolean
    Get
      Return bAfter
    End Get
  End Property

  Public ReadOnly Property IsBefore As Boolean
    Get
      Return bBefore
    End Get
  End Property

  Public ReadOnly Property IsRange As Boolean
    Get
      Return bRange
    End Get
  End Property

  Public ReadOnly Property IsValid As Boolean
    Get
      Return bValid
    End Get
  End Property

  Public ReadOnly Property Month As Integer
    Get
      If bValid And bMonth Then
        Return dResultDate.Month
      Else
        Return 0
      End If
    End Get
  End Property

  Public Property SourceDateString As String
    Get
      Return sSourceDateString
    End Get
    Set(value As String)
      sSourceDateString = value
      Parse()
    End Set
  End Property

  Public ReadOnly Property Year As Integer
    Get
      If bValid And bYear Then
        Return dResultDate.Year
      Else
        Return 0
      End If
    End Get
  End Property

#End Region

#Region "Public Constructors"

  Public Sub New(dateString As String)
    SourceDateString = dateString
  End Sub

  Public Sub New()
    'Nothing to see here...
  End Sub

#End Region

#Region "Private Methods"

  Private Sub Initialize()
    sSourceDateString = ""
    sCleanDateString = ""
    sFormat = ""
    bRange = False
    bAbout = False
    bBefore = False
    bAfter = False
    bYear = False
    bMonth = False
    bDay = False
    bValid = False
  End Sub

  Private Function Parse() As Boolean
    Dim workingDate As String = sSourceDateString.Replace(".", "").Replace(",", "").ToUpper()
    If workingDate.Length < 3 Then
      bValid = False
      Return False
    End If
    ' ABOUT PROCESSING
    If workingDate.StartsWith("ABOUT") Or workingDate.StartsWith("ABT") Then
      bAbout = True
      workingDate = workingDate.Replace("ABOUT", "").Replace("ABT", "").Trim()
    End If
    ' AFTER PROCESSING
    If workingDate.StartsWith("AFTER") Or workingDate.StartsWith("AFT") Then
      bAbout = True
      workingDate = workingDate.Replace("AFTER", "").Replace("AFT", "").Trim()
    End If
    ' BEFORE PROCESSING
    If workingDate.StartsWith("BEFORE") Or workingDate.StartsWith("BEF") Then
      bAbout = True
      workingDate = workingDate.Replace("BEFORE", "").Replace("BEF", "").Trim()
    End If
    ' YYYY
    If workingDate.Length() = 4 And IsNumeric(workingDate) And Val(workingDate) > 0 Then
      sFormat = "yyyy"
      sCleanDateString = workingDate
      dResultDate = New Date(CInt(workingDate.Substring(0, 4)), 1, 1)
      bYear = True
      bValid = True
      Return True
    End If
    ' YYYY-YYYY
    If workingDate.Length() = 9 Then
      If IsNumeric(workingDate.Substring(0, 4)) And workingDate.Substring(4, 1).Equals("-") And Val(Right(workingDate, 4)) > 0 Then
        sFormat = "yyyy-yyyy"
        sCleanDateString = workingDate
        dResultDate = New Date(CInt(workingDate.Substring(0, 4)), 1, 1)
        bRange = True
        bYear = True
        bValid = True
        Return True
      End If
    End If
    Dim parsedDate As Date
    Dim format As String = "d MMM yyyy"
    If Date.TryParseExact(workingDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True
    End If
    format = "d MMMM yyyy"
    If Date.TryParseExact(workingDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True
    End If
    format = "MMM yyyy"
    If Date.TryParseExact(DateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = False
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True
    End If
    format = "MMMM yyyy"
    If Date.TryParseExact(DateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = False
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True
    End If
    format = "M-d-yyyy"
    If Date.TryParseExact(DateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True

    End If
    format = "yyyy-M-d"
    If Date.TryParseExact(DateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True

    End If
    format = "M/d/yyyy"
    If Date.TryParseExact(DateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True

    End If
    format = "MM/d/yyyy"
    If Date.TryParseExact(DateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True

    End If
    format = "M/dd/yyyy"
    If Date.TryParseExact(DateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True

    End If
    format = "MM/dd/yyyy"
    If Date.TryParseExact(DateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True

    End If
    format = "MMM d yyyy"
    If Date.TryParseExact(DateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True
    End If
    format = "MMMM d yyyy"
    If Date.TryParseExact(DateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      dResultDate = parsedDate
      bValid = True
      Return True
    End If
    bValid = False
    Return False
  End Function

#End Region

#Region "Public Methods"

  Public Function toAssistantDate() As String
    Dim rtnString As String = ""
    If IsValid Then
      If bYear And Not bDay And Not bMonth Then
        rtnString = sCleanDateString
      Else
        rtnString += dResultDate.Year.ToString()
        If bMonth Then
          rtnString += "-" + dResultDate.Month.ToString.PadLeft(2, "0"c)
        Else
          rtnString += "-00"
        End If
        If bDay Then
          rtnString += "-" + dResultDate.Day.ToString.PadLeft(2, "0"c)
        Else
          rtnString += "-00"
        End If
      End If
    End If
    Return rtnString
  End Function

  Public Function toDate() As Date
    Return dResultDate
  End Function

  Public Function toRootsMagicDate() As String
    Dim rtnString As String = ""
    If IsValid Then
      rtnString = "D"
      If IsAbout Or IsAfter Then
        rtnString += "A"
      Else
        If IsBefore Then
          rtnString += "B"
        Else
          If IsRange Then
            rtnString += "-"
          Else
            rtnString += "."
          End If
        End If
      End If
      rtnString += "+"
      If bYear And Not bDay And Not bMonth Then
        rtnString += sCleanDateString + "0000"
      Else
        rtnString += dResultDate.Year.ToString()
        If bMonth Then
          rtnString += dResultDate.Month.ToString.PadLeft(2, "0"c)
        Else
          rtnString += "00"
        End If
        If bDay Then
          rtnString += dResultDate.Day.ToString.PadLeft(2, "0"c)
        Else
          rtnString += "00"
        End If
      End If
      rtnString += "..+00000000.."
    Else
      If SourceDateString.Trim.Length > 0 Then
        rtnString = "T" + SourceDateString
      Else
        rtnString = "."
      End If
    End If
    Return rtnString
  End Function

#End Region

End Class