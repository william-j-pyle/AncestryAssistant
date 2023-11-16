Public Class frmTestSplitters

#Region "Private Methods"

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    panelLeft(Not pnlLeftTop.Visible, pnlLeftBottom.Visible)

  End Sub

  Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
    If pnlRightTop.Controls.Count > 0 Then
      pnlLeftTop.Controls.Add(pnlRightTop.Controls(0))
    End If
  End Sub

  Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    panelLeft(pnlLeftTop.Visible, Not pnlLeftBottom.Visible)

  End Sub

  Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    panelMiddle(Not pnlMiddleLeft.Visible, pnlMiddleRight.Visible)
  End Sub

  Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    panelMiddle(pnlMiddleLeft.Visible, Not pnlMiddleRight.Visible)
  End Sub

  Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    panelRight(pnlRightTop.Visible, Not pnlRightBottom.Visible)
  End Sub

  Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    panelRight(Not pnlRightTop.Visible, pnlRightBottom.Visible)
  End Sub

  Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
    If pnlLeftBottom.Controls.Count > 0 Then
      pnlRightBottom.Controls.Add(pnlLeftBottom.Controls(0))
    End If
  End Sub

  Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
    If pnlLeftTop.Controls.Count > 0 Then
      pnlRightTop.Controls.Add(pnlLeftTop.Controls(0))
    End If
  End Sub

  Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
    If pnlRightBottom.Controls.Count > 0 Then
      pnlLeftBottom.Controls.Add(pnlRightBottom.Controls(0))
    End If
  End Sub

  Private Sub panelLeft(topVis As Boolean, botVis As Boolean)
    If pnlLeftTop.Dock = DockStyle.Top Then
      pnlLeftTop.Tag = pnlLeftTop.Height
    End If
    If topVis And Not botVis Then
      pnlLeftTop.Dock = DockStyle.Fill
    End If
    If topVis And botVis And pnlLeftTop.Dock = DockStyle.Fill Then
      pnlLeftTop.Dock = DockStyle.Top
      pnlLeftTop.Height = CInt(pnlLeftTop.Tag)
    End If

    pnlLeftTop.Visible = topVis
    pnlLeftBottom.Visible = botVis
    splitLeft.Visible = topVis Or botVis
    splitLeftTopBottom.Visible = topVis And botVis
    pnlLeft.Visible = topVis Or botVis
  End Sub

  Private Sub panelMiddle(leftVis As Boolean, rightVis As Boolean)
    If pnlMiddleRight.Dock = DockStyle.Right Then
      pnlMiddleRight.Tag = pnlMiddleRight.Width
    End If
    If rightVis And Not leftVis Then
      pnlMiddleRight.Dock = DockStyle.Fill
    End If
    If leftVis And rightVis And pnlMiddleRight.Dock = DockStyle.Fill Then
      pnlMiddleRight.Dock = DockStyle.Right
      pnlMiddleRight.Width = CInt(pnlMiddleRight.Tag)
    End If

    pnlMiddleLeft.Visible = leftVis
    pnlMiddleRight.Visible = rightVis
    splitMiddleLeftRight.Visible = leftVis And rightVis
  End Sub

  Private Sub panelRight(topVis As Boolean, botVis As Boolean)
    If pnlRightTop.Dock = DockStyle.Top Then
      pnlRightTop.Tag = pnlRightTop.Height
    End If
    If topVis And Not botVis Then
      pnlRightTop.Dock = DockStyle.Fill
    End If
    If topVis And botVis And pnlRightTop.Dock = DockStyle.Fill Then
      pnlRightTop.Dock = DockStyle.Top
      pnlRightTop.Height = CInt(pnlRightTop.Tag)
    End If

    pnlRightTop.Visible = topVis
    pnlRightBottom.Visible = botVis
    splitRight.Visible = topVis Or botVis
    splitRightTopBottom.Visible = topVis And botVis
    pnlRight.Visible = topVis Or botVis
  End Sub

#End Region

End Class