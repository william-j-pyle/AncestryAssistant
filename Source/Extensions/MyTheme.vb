﻿Namespace My.Theme

  <HideModuleName()>
  Module MyTheme

    Public ReadOnly Property AppAccent2Color As Color = ColorBrightness(AppBorderColor, 25)

    Public ReadOnly Property AppAccentColor As Color = Color.FromArgb(255, 102, 102, 102)

    Public ReadOnly Property AppActiveFontColor As Color = Color.White

    Public ReadOnly Property AppBackColor As Color = Color.FromArgb(255, 10, 10, 10)

    Public ReadOnly Property AppBorderColor As Color = Color.FromArgb(255, 41, 41, 41)

    Public ReadOnly Property AppControlBoxBackColor As Color = AppBackColor

    Public ReadOnly Property AppControlBoxFont As Font = New System.Drawing.Font("Segoe Fluent Icons", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    Public ReadOnly Property AppControlBoxFontColor As Color = AppFontColor

    Public ReadOnly Property AppFont As Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    Public ReadOnly Property AppFontColor As Color = Color.WhiteSmoke

    Public ReadOnly Property AppFontDarkColor As Color = Color.Black

    Public ReadOnly Property AppHighlightColor As Color = Color.Lime

    Public ReadOnly Property AppIconsFont As Font = New System.Drawing.Font("Segoe Fluent Icons", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    Public ReadOnly Property AppShadow2Color As Color = ColorBrightness(AppBorderColor, -25)

    Public ReadOnly Property AppShadowColor As Color = ColorBrightness(AppBorderColor, -15)

    Public ReadOnly Property AppTitleFont As Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

    Public ReadOnly Property AppTitleFontColor As Color = AppFontColor

    Public ReadOnly Property AppToolbarBackColor As Color = AppBackColor

    Public ReadOnly Property AppToolbarButtonColor As Color = AppBackColor

    Public ReadOnly Property AppToolbarButtonHoverColor As Color = AppShadowColor

    Public ReadOnly Property AppToolbarButtonPressedColor As Color = AppShadow2Color

    Public ReadOnly Property AppToolbarFontColor As Color = AppFontColor

    Public ReadOnly Property AppToolbarIconColor As Color = Color.White

    Public ReadOnly Property PanelAccentColor As Color = AppAccentColor

    Public ReadOnly Property PanelAccentColor2 As Color = AppAccent2Color

    Public ReadOnly Property PanelActiveFontColor As Color = AppActiveFontColor

    Public ReadOnly Property PanelBackColor As Color = AppBackColor

    Public ReadOnly Property PanelBorderColor As Color = AppBorderColor

    Public ReadOnly Property PanelFontColor As Color = AppFontColor

    Public ReadOnly Property PanelHighlightColor As Color = AppHighlightColor

    Public ReadOnly Property PanelShadowColor As Color = AppShadowColor

    Public ReadOnly Property PanelShadowColor2 As Color = AppShadow2Color

    Public ReadOnly Property RibbonAccentColor As Color = AppAccent2Color
    Public ReadOnly Property RibbonBackColor As Color = AppBorderColor
    Public ReadOnly Property RibbonBarFont As Font = AppFont
    Public ReadOnly Property RibbonButtonFont As Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Public ReadOnly Property RibbonForeColor As Color = AppFontColor
    Public ReadOnly Property RibbonShadowColor As Color = AppAccentColor
    Public ReadOnly Property StatusBarBackColor As Color = Color.FromArgb(255, 20, 20, 20)

    Public ReadOnly Property StatusBarFontColor As Color = AppFontDarkColor

    Public ReadOnly Property TabAccentColor As Color = AppAccentColor

    Public ReadOnly Property TabAccentColor2 As Color = AppAccent2Color

    Public ReadOnly Property TabActiveFontColor As Color = AppActiveFontColor

    Public ReadOnly Property TabBackColor As Color = AppBackColor

    Public ReadOnly Property TabBorderColor As Color = AppBorderColor

    Public ReadOnly Property TabFontColor As Color = AppFontColor

    Public ReadOnly Property TabHighlightColor As Color = AppHighlightColor

    Public ReadOnly Property TabShadowColor As Color = AppShadowColor

    Public ReadOnly Property TabShadowColor2 As Color = AppShadow2Color

    Public ReadOnly Property XLSBackColor As Color = Color.White

    Public ReadOnly Property XLSFontColor As Color = Color.Black

    Public ReadOnly Property XLSHighlightColor As Color = Color.Green

    Public ReadOnly Property XLSHighlightColor2 As Color = Color.Yellow

    Public Function ColorBrightness(color As Color, brightness As Double) As Color
      Dim brightnessChange As Integer = CInt(255 * brightness / 100)
      Dim newRed As Integer = Math.Max(Math.Min(255, color.R + brightnessChange), 0)
      Dim newGreen As Integer = Math.Max(Math.Min(255, color.G + brightnessChange), 0)
      Dim newBlue As Integer = Math.Max(Math.Min(255, color.B + brightnessChange), 0)
      Return Color.FromArgb(color.A, newRed, newGreen, newBlue)
    End Function

    Public Function ColorIcon(icon As Bitmap, newColor As Color) As Bitmap
      Dim originalColor As Color
      Dim newBitmap As Bitmap
      Try
        newBitmap = New Bitmap(icon.Width, icon.Height)
        For i As Integer = 0 To icon.Width - 1
          For j As Integer = 0 To icon.Height - 1
            originalColor = icon.GetPixel(i, j)
            newBitmap.SetPixel(i, j, Color.FromArgb(originalColor.A, newColor))  '
          Next
        Next
      Catch e As Exception
        newBitmap = icon
      End Try
      Return newBitmap
    End Function

    Public Function ColorToAccent(color As Color) As Color
      Return ColorBrightness(color, 15)
    End Function

    Public Function ColorToAccent2(color As Color) As Color
      Return ColorBrightness(color, 25)
    End Function

    Public Function ColorToDisabled(color As Color) As Color
      Dim grayValue As Integer = CInt((0.299 * color.R) + (0.587 * color.G) + (0.114 * color.B))
      Return Color.FromArgb(150, grayValue, grayValue, grayValue)
    End Function

    Public Function ColorToGray(color As Color) As Color
      Dim grayValue As Integer = CInt((0.299 * color.R) + (0.587 * color.G) + (0.114 * color.B))
      Return Color.FromArgb(grayValue, grayValue, grayValue)
    End Function

    Public Function ColorToShadow(color As Color) As Color
      Return ColorBrightness(color, -15)
    End Function

    Public Function ColorToShadow2(color As Color) As Color
      Return ColorBrightness(color, -25)
    End Function

  End Module
End Namespace