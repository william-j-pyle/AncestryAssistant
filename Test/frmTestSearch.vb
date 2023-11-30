Imports Svg

Public Class frmTestSearch

#Region "Private Methods"

  Private Sub Button1_Click(sender As Object, e As EventArgs)
    ' Button2.BackgroundImage = ConvertSvgToBitmap("D:\Images\images\svg\Paste.svg")
  End Sub

  Private Function ConvertSvgToBitmap(svgFilePath As String) As Bitmap
    ' Load SVG file
    Dim svgD As SvgDocument = SvgDocument.Open(svgFilePath)
    svgD.Height = 48
    svgD.Width = 48
    ' Create Bitmap from SVG
    Dim bitmap As New Bitmap(CInt(svgD.Width), CInt(svgD.Height))
    Using g As Graphics = Graphics.FromImage(bitmap)
      svgD.Draw(g)
    End Using

    Return bitmap
  End Function

  Private Sub frmTestSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  End Sub

#End Region

End Class