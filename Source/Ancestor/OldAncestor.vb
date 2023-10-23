Imports System.ComponentModel
Imports System.IO

<DefaultPropertyAttribute("ID")>
Public Class OldAncestor
  Public Sub New()
    Reset()
  End Sub

  Public Sub Reset()
    _ID = ""
    Surname = ""
    Givenname = ""
    BirthYear = ""
    DeathYear = ""
    ResetProfile()
  End Sub



  Private _ID As String = ""
  <CategoryAttribute("Tracking"),
           Browsable(True),
           [ReadOnly](False),
           BindableAttribute(False),
           ParenthesizePropertyName(True),
           DefaultValueAttribute(""),
           DesignOnly(False),
           DescriptionAttribute("Ancestry.com ID")>
  Public Property ID As String
    Get
      Return _ID
    End Get
    Set(value As String)
      If _ID.Equals("") Then
        _ID = value
      Else
        If Not _ID.Equals(value.Trim) Then
          Reset()
          _ID = value
        End If
      End If
    End Set
  End Property

  <CategoryAttribute("Name"),
           Browsable(True),
           [ReadOnly](False),
           BindableAttribute(False),
           DefaultValueAttribute(""),
           DesignOnly(False),
           DescriptionAttribute("Sur or Family Name")>
  Public Property Surname As String = ""
  <CategoryAttribute("Name"),
           Browsable(True),
           [ReadOnly](False),
           BindableAttribute(False),
           DefaultValueAttribute(""),
           DesignOnly(False),
           DescriptionAttribute("Given Name")>
  Public Property Givenname As String = ""
  <CategoryAttribute("Name"), Browsable(False),
           DescriptionAttribute("Display Name, GivenName Surname")>
  Public Property Name As String
    Get
      Return $"{Givenname} {Surname}"
    End Get
    Set(value As String)
      Dim s As String
      Dim p() As String
      If value.Contains(",") Then
        p = value.Split(",")
        Surname = p(0).Trim()
        Givenname = p(1).Trim()
      Else
        If value.Length > 2 Then
          p = value.Split(" ")
          If IsArray(p) And p.Length > 0 Then
            s = p(UBound(p))
            If s.Length() < 4 Then
              s = p(UBound(p) - 1) & " " & s
            End If
            Surname = s.Trim()
            Givenname = value.Replace(s, "").Trim()
          Else
            Surname = value.Trim()
            Givenname = ""
          End If
        Else
          Surname = ""
          Givenname = ""
        End If
      End If
    End Set
  End Property

  <CategoryAttribute("Status"),
           Browsable(True),
           [ReadOnly](True),
           BindableAttribute(False),
           DefaultValueAttribute(False),
           DesignOnly(False),
           DescriptionAttribute("Indicates if record is complete")>
  Public ReadOnly Property IsValid As Boolean
    Get
      Return ID.Length > 3 And Name.Length > 3 And BirthYear.Length = 4
    End Get
  End Property

  <CategoryAttribute("Local Tracking"),
           Browsable(True),
           [ReadOnly](True),
           BindableAttribute(False),
           DefaultValueAttribute(False),
           DesignOnly(False),
           DescriptionAttribute("Ancestor is being tracked locally")>
  Public ReadOnly Property IsLocal As Boolean
    Get
      If IsValid Then
        Return Directory.Exists(Path)
      Else
        Return False
      End If
    End Get
  End Property

  <CategoryAttribute("Local Tracking"),
           Browsable(True),
           [ReadOnly](True),
           BindableAttribute(False),
           DefaultValueAttribute(False),
           DesignOnly(False),
           DescriptionAttribute("Path where local tracking is stored")>
  Public ReadOnly Property Path As String
    Get
      If IsValid Then
        Dim dirPath As String = ""
        dirPath = My.Settings.AncestorsPath
        If Not dirPath.EndsWith("\") Then dirPath += "\"
        dirPath += Surname + ", " + Givenname + " - " + BirthYear + "\"
        Return dirPath
      Else
        Return ""
      End If
    End Get
  End Property

  Public Property BirthYear As String
  Public Property DeathYear As String

  Private _ProfileSurName As String = ""
  Public ReadOnly Property ProfileSurName As String
    Get
      If _ProfileSurName.Equals("") Then LoadProfile()
      Return _ProfileSurName
    End Get
  End Property
  Private _ProfileGivenName As String = ""
  Public ReadOnly Property ProfileGivenName As String
    Get
      If _ProfileSurName.Equals("") Then LoadProfile()
      Return _ProfileGivenName
    End Get
  End Property
  Private _ProfileBirthDate As String = ""
  Public ReadOnly Property ProfileBirthDate As String
    Get
      If _ProfileSurName.Equals("") Then LoadProfile()
      Return _ProfileBirthDate
    End Get
  End Property
  Private _ProfileBirthPlace As String = ""
  Public ReadOnly Property ProfileBirthPlace As String
    Get
      If _ProfileSurName.Equals("") Then LoadProfile()
      Return _ProfileBirthPlace
    End Get
  End Property
  Private _ProfileDeathDate As String = ""
  Public ReadOnly Property ProfileDeathDate As String
    Get
      If _ProfileSurName.Equals("") Then LoadProfile()
      Return _ProfileDeathDate
    End Get
  End Property
  Private _ProfileDeathPlace As String = ""
  Public ReadOnly Property ProfileDeathPlace As String
    Get
      If _ProfileSurName.Equals("") Then LoadProfile()
      Return _ProfileDeathPlace
    End Get
  End Property

  Public Sub createPath()
    If IsValid Then
      If Not IsLocal Then
        Directory.CreateDirectory(Path)
      End If
    End If
  End Sub

  Private Sub ResetProfile()
    _ProfileBirthDate = ""
    _ProfileBirthPlace = ""
    _ProfileDeathDate = ""
    _ProfileDeathPlace = ""
    _ProfileSurName = ""
    _ProfileGivenName = ""
  End Sub

  Private Sub LoadProfile()
    ResetProfile()

    If hasProfile() Then
      Dim data() As String = File.ReadAllLines(Path & "Profile.txt")
      _ProfileSurName = data(0)
      _ProfileGivenName = data(1)
      _ProfileBirthDate = data(2)
      _ProfileBirthPlace = data(3)
      _ProfileDeathDate = data(4)
      _ProfileDeathPlace = data(5)
    End If
  End Sub

  Public Function hasProfile() As Boolean
    If IsLocal Then
      Return File.Exists(Path & "Profile.txt")
    End If
    Return False
  End Function

  Public Function IDFromProfile() As String
    Dim data As String = ""
    If IsLocal Then
      If File.Exists(Path & "Ancestry.id") Then
        data = File.ReadAllText(Path & "Ancestry.id")
      End If
    End If
    Return data
  End Function

  Public Function hasBirthCertificate() As Boolean
    Return hasMatchingFile("certificate-birth", "jpg")
  End Function
  Public Function hasDeathCertificate() As Boolean
    Return hasMatchingFile("certificate-death", "jpg")
  End Function

  Public Function hasProfileImage() As Boolean
    Return hasMatchingFile("photo-profile", "jpg")
  End Function

  Public Function hasHeadstoneImage() As Boolean
    Return hasMatchingFile("photo-headstone", "jpg")
  End Function

  Private Function hasMatchingFile(startText As String, endText As String) As Boolean
    If IsLocal Then
      Dim files = Directory.GetFiles(Path)
      For Each file As String In files
        Dim fname As String = file.Replace(Path, "").ToLower()
        If fname.StartsWith(startText) And fname.EndsWith(endText) Then
          Return True
        End If
      Next
    End If
    Return False
  End Function


  Public Function getCensusList() As ArrayList
    Dim list As ArrayList = New ArrayList()
    If IsLocal Then
      Dim files = Directory.GetFiles(Path)
      For Each file As String In files
        Dim fname As String = file.Replace(Path, "").ToLower()
        If fname.StartsWith("census") And fname.EndsWith(".csv") Then
          Dim p() As String = fname.Split("-")
          If IsArray(p) And p.Length > 1 Then
            list.Add(p(1))
          End If
        End If
      Next
    End If
    Return list
  End Function


End Class
