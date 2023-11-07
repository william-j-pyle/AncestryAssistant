Public Class JTheme


  Public Function BorderColor() As Color
    Return BorderColor(ThemeCategoryEnum.APP)
  End Function

  Public Function BorderColor(themeCategory As ThemeCategoryEnum, Optional active As Boolean = True) As Color
    Return Color.FromArgb(61, 61, 61)
  End Function

  Public Function AccentColor(Optional active As Boolean = True) As Color
    Return AccentColor(ThemeCategoryEnum.APP, active)
  End Function

  Public Function AccentColor(themeCategory As ThemeCategoryEnum, Optional active As Boolean = True) As Color
    If active Then
      Return Color.FromArgb(113, 96, 232)
    Else
      Return Color.FromArgb(61, 61, 61)
    End If
  End Function

  Public Function BackColor(themeCategory As ThemeCategoryEnum, Optional active As Boolean = True) As Color
    Select Case themeCategory
      Case ThemeCategoryEnum.APP
        Return Color.FromArgb(31, 31, 31)
      Case ThemeCategoryEnum.PANEL
        Return Color.FromArgb(31, 31, 31)
      Case ThemeCategoryEnum.PANEL_HEADER
        Return Color.FromArgb(26, 26, 26)
      Case ThemeCategoryEnum.PANEL_SEARCH
        Return Color.FromArgb(61, 61, 61)
      Case ThemeCategoryEnum.PANEL_TABS
        Return Color.FromArgb(31, 31, 31)
    End Select
    Return Color.Red
  End Function

  Public Function ForeColor(themeCategory As ThemeCategoryEnum, Optional active As Boolean = True) As Color
    Select Case themeCategory
      Case ThemeCategoryEnum.APP
        If active Then
          Return Color.FromArgb(250, 250, 250)
        Else
          Return Color.FromArgb(150, 150, 150)
        End If
      Case ThemeCategoryEnum.PANEL
        If active Then
          Return Color.FromArgb(250, 250, 250)
        Else
          Return Color.FromArgb(150, 150, 150)
        End If
      Case ThemeCategoryEnum.PANEL_HEADER
        If active Then
          Return Color.FromArgb(250, 250, 250)
        Else
          Return Color.FromArgb(150, 150, 150)
        End If
      Case ThemeCategoryEnum.PANEL_SEARCH
        If active Then
          Return Color.FromArgb(250, 250, 250)
        Else
          Return Color.FromArgb(150, 150, 150)
        End If
      Case ThemeCategoryEnum.PANEL_TABS
        If active Then
          Return Color.FromArgb(250, 250, 250)
        Else
          Return Color.FromArgb(150, 150, 150)
        End If
    End Select
    ' Default Color which should never be returned
    Return Color.Red
  End Function

  Public Function Font() As Font
    Return Font(ThemeCategoryEnum.APP)
  End Function

  Public Function Font(themeCategory As ThemeCategoryEnum) As Font
    Return New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
  End Function

  Public Function Icon(themeIcon As ThemeIconsEnum) As Image
    Return Icon(themeIcon, Color.FromArgb(250, 250, 250))
  End Function

  Public Function Icon(themeIcon As ThemeIconsEnum, reColor As Color) As Image
    Select Case themeIcon
      Case ThemeIconsEnum.APP
        'Return My.Resources.Close_White
      Case ThemeIconsEnum.SEARCH
        'Return My.Resources.Close_White
      Case ThemeIconsEnum.PANEL_BG
        'Return My.Resources.Close_White
      Case ThemeIconsEnum.SEARCH_SM
        'Return My.Resources.Close_White
      Case ThemeIconsEnum.CLOSE
        'Return My.Resources.Close_White
      Case ThemeIconsEnum.CLOSE_SM
        'Return My.Resources.Close_White
      Case ThemeIconsEnum.PINNED
        'Return My.Resources.Close_White
      Case ThemeIconsEnum.UNPINNED
        'Return My.Resources.Close_White
      Case ThemeIconsEnum.DD
        'Return My.Resources.Close_White
      Case ThemeIconsEnum.DD_SM
        'Return My.Resources.Close_White
    End Select
    Return Nothing
  End Function

  Private Function Resize(img As Image, size As Size) As Image
    Return New Bitmap(img, size)
  End Function

  Private Function Resize(img As Image, width As Integer, height As Integer) As Image
    Return Resize(img, New Size(width, height))
  End Function

  Private Function FlipHorizontal(img As Image) As Image
    Dim newImage As Image = img.Clone
    newImage.RotateFlip(RotateFlipType.RotateNoneFlipX)
    Return newImage
  End Function

  Private Function FlipVertical(img As Image) As Image
    Dim newImage As Image = img.Clone
    newImage.RotateFlip(RotateFlipType.RotateNoneFlipY)
    Return newImage
  End Function

  Private Function Recolor(img As Image, toColor As Color) As Image
    Return ReColor(img, Color.Black, toColor)
  End Function

  Private Function ReColor(img As Image, fromColor As Color, toColor As Color) As Image
    Dim originalColor As Color
    Dim newImage As Bitmap = img.Clone
    Try
      For i As Integer = 0 To newImage.Width - 1
        For j As Integer = 0 To newImage.Height - 1
          originalColor = newImage.GetPixel(i, j)
          If originalColor.R = fromColor.R And originalColor.G = fromColor.G And originalColor.B = fromColor.B Then
            newImage.SetPixel(i, j, Color.FromArgb(originalColor.A, toColor))
          End If
        Next
      Next
    Catch e As Exception
      newImage = img
    End Try
    Return newImage
  End Function


End Class
