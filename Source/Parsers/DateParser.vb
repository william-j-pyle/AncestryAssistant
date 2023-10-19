Imports System.Globalization

Public Class DateParser
  Private lastDateString As String = ""
  Private lastDate As Date
  Private lastStandardString As String = ""
  Private sFormat As String = ""
  Public ReadOnly Property Year As String
    Get
      If bValid And bYear Then
        Return lastDate.Year
      Else
        Return ""
      End If
    End Get
  End Property
  Public ReadOnly Property Month As String
    Get
      If bValid And bMonth Then
        Return lastDate.Month
      Else
        Return ""
      End If
    End Get
  End Property
  Public ReadOnly Property Day As String
    Get
      If bValid And bDay Then
        Return lastDate.Day
      Else
        Return ""
      End If
    End Get
  End Property
  Public ReadOnly Property DateFormat As String
    Get
      Return sFormat
    End Get
  End Property
  Private bRange As Boolean = False
  Public ReadOnly Property IsRange As Boolean
    Get
      Return bRange
    End Get
  End Property
  Private bAbout As Boolean = False
  Public ReadOnly Property IsAbout As Boolean
    Get
      Return bAbout
    End Get
  End Property
  Private bBefore As Boolean = False
  Public ReadOnly Property IsBefore As Boolean
    Get
      Return bBefore
    End Get
  End Property
  Private bAfter As Boolean = False
  Public ReadOnly Property IsAfter As Boolean
    Get
      Return bAfter
    End Get
  End Property
  Private bYear As Boolean = False
  Public ReadOnly Property HasYear As Boolean
    Get
      Return bYear
    End Get
  End Property
  Private bMonth As Boolean = False
  Public ReadOnly Property HasMonth As Boolean
    Get
      Return bMonth
    End Get
  End Property
  Private bDay As Boolean = False
  Public ReadOnly Property HasDay As Boolean
    Get
      Return bDay
    End Get
  End Property
  Private bValid As Boolean = False
  Public ReadOnly Property IsValid As Boolean
    Get
      Return bValid
    End Get
  End Property



  Private Sub Reset()
    lastDateString = ""
    lastStandardString = ""
    sFormat = ""
    bRange = False
    bAbout = False
    bBefore = False
    bAfter = False
    bYear = False
    bMonth = False
    bDay = False
  End Sub


  Public Function Parse(dateString As String) As Boolean
    'Debug.Print("DateHelper.Parse(dateString={0})", dateString)
    ' Reset track globals
    Reset()
    lastDateString = dateString
    Dim workingDate As String = dateString.Replace(".", "").Replace(",", "").ToUpper()
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
      lastStandardString = workingDate
      lastDate = New Date(workingDate.Substring(0, 4), 1, 1)
      bYear = True
      bValid = True
      Return True
    End If
    ' YYYY-YYYY
    If workingDate.Length() = 9 Then
      If IsNumeric(workingDate.Substring(0, 4)) And workingDate.Substring(4, 1).Equals("-") And Val(Right(workingDate, 4)) > 0 Then
        sFormat = "yyyy-yyyy"
        lastStandardString = workingDate
        lastDate = New Date(workingDate.Substring(0, 4), 1, 1)
        bRange = True
        bYear = True
        bValid = True
        Return True
      End If
    End If
    Dim parsedDate As Date
    Dim format As String = "d MMM yyyy"
    If DateTime.TryParseExact(workingDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True
    End If
    format = "d MMMM yyyy"
    If DateTime.TryParseExact(workingDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True
    End If
    format = "MMM yyyy"
    If DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = False
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True
    End If
    format = "MMMM yyyy"
    If DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = False
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True
    End If
    format = "M-d-yyyy"
    If DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True

    End If
    format = "yyyy-M-d"
    If DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True

    End If
    format = "M/d/yyyy"
    If DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True

    End If
    format = "MM/d/yyyy"
    If DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True

    End If
    format = "M/dd/yyyy"
    If DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True

    End If
    format = "MM/dd/yyyy"
    If DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True

    End If
    format = "MMM d yyyy"
    If DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True
    End If
    format = "MMMM d yyyy"
    If DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, parsedDate) Then
      bDay = True
      bMonth = True
      bYear = True
      sFormat = format
      lastDate = parsedDate
      bValid = True
      Return True
    End If
    bValid = False
    Return False
  End Function

  Public Function toStandardDateFormat(dateString As String) As String
    Dim rtnString As String = ""
    If Parse(dateString) Then
      If bYear And Not bDay And Not bMonth Then
        rtnString = lastStandardString
      Else
        rtnString += lastDate.Year.ToString()
        If bMonth Then
          rtnString += "-" + lastDate.Month.ToString.PadLeft(2, "0")
        Else
          rtnString += "-00"
        End If
        If bDay Then
          rtnString += "-" + lastDate.Day.ToString.PadLeft(2, "0")
        Else
          rtnString += "-00"
        End If
      End If
    End If
    'Debug.Print("toStandardDateFormat({0})=[{1}, {2}]", dateString, sFormat, rtnString)
    Return rtnString
  End Function

End Class
