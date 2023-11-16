Public Class frmColorPallet

#Region "Private Methods"

  Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    SetupLabel(Label1, SystemColors.ActiveBorder)
    SetupLabel(Label2, SystemColors.ActiveCaption)
    SetupLabel(Label3, SystemColors.ActiveCaptionText)
    SetupLabel(Label4, SystemColors.AppWorkspace)
    SetupLabel(Label5, SystemColors.ButtonFace)
    SetupLabel(Label6, SystemColors.ButtonHighlight)
    SetupLabel(Label7, SystemColors.ButtonShadow)
    SetupLabel(Label8, SystemColors.Control)
    SetupLabel(Label9, SystemColors.ControlDark)
    SetupLabel(Label10, SystemColors.ControlDarkDark)
    SetupLabel(Label11, SystemColors.ControlLight)
    SetupLabel(Label12, SystemColors.ControlLightLight)
    SetupLabel(Label13, SystemColors.ControlText)
    SetupLabel(Label14, SystemColors.Desktop)
    SetupLabel(Label15, SystemColors.GradientActiveCaption)
    SetupLabel(Label16, SystemColors.GradientInactiveCaption)
    SetupLabel(Label17, SystemColors.GrayText)
    SetupLabel(Label18, SystemColors.Highlight)
    SetupLabel(Label19, SystemColors.HighlightText)
    SetupLabel(Label20, SystemColors.HotTrack)
    SetupLabel(Label21, SystemColors.InactiveBorder)
    SetupLabel(Label22, SystemColors.InactiveCaption)
    SetupLabel(Label23, SystemColors.InactiveCaptionText)
    SetupLabel(Label24, SystemColors.Info)
    SetupLabel(Label25, SystemColors.InfoText)
    SetupLabel(Label26, SystemColors.Menu)
    SetupLabel(Label27, SystemColors.MenuBar)
    SetupLabel(Label28, SystemColors.MenuHighlight)
    SetupLabel(Label29, SystemColors.MenuText)
    SetupLabel(Label30, SystemColors.ScrollBar)
    SetupLabel(Label31, SystemColors.Window)
    SetupLabel(Label32, SystemColors.WindowFrame)
    SetupLabel(Label33, SystemColors.WindowText)
  End Sub

  Private Sub SetupLabel(ctl As Label, sysColor As Color)
    Dim c As String
    c = "(" & Hex(sysColor.R) & "," & Hex(sysColor.G) & "," & Hex(sysColor.B) & ")   " & sysColor.GetBrightness()
    ctl.Text = sysColor.ToString.Replace("Color [", "").Replace("]", "") & (vbCrLf + c)
    ctl.BackColor = sysColor
    If sysColor.GetBrightness < 0.34 Then
      ctl.ForeColor = Color.White
    End If
  End Sub

#End Region

End Class