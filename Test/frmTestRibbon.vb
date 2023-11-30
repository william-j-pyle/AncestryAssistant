Public Class frmTestRibbon

#Region "Fields"

  Private WithEvents bar As Ribbon

#End Region

#Region "Private Methods"

  Private Sub btnAddBar_Click(sender As Object, e As EventArgs) Handles btnAddBar.Click
    Dim rb As RibbonBar = bar.AddBar("100", "Bar100")
    With rb.AddGroup("200", "Clipboard")
      .ShowPane = True
      .AddItem("300", New RibbonItemButton("300", "Btn300") With {
        .Image = My.Resources.clipboard_paste,
        .GridLocation = New Point(0, 0),
        .GridSize = New Drawing.Size(2, 3),
        .ImageAlign = ContentAlignment.TopCenter,
        .Text = ""
        })
      .AddItem("301", New RibbonItemButton("301", "Btn301") With {
        .Image = My.Resources.clipboard_cut,
        .GridLocation = New Point(3, 1),
        .GridSize = New Drawing.Size(1, 1),
        .ImageAlign = ContentAlignment.MiddleCenter,
        .Text = ""
        })
      .AddItem("302", New RibbonItemButton("302", "Btn302") With {
        .Image = My.Resources.clipboard_copy,
        .GridLocation = New Point(3, 2),
        .GridSize = New Drawing.Size(1, 1),
        .ImageAlign = ContentAlignment.MiddleCenter,
        .Text = ""
      })
    End With
    With rb.AddGroup("400", "Font")
      .ShowPane = True
      .AddItem("401", New RibbonItemButton("401", "Btn401") With {
        .Image = My.Resources.clipboard_paste,
        .GridLocation = New Point(0, 0),
        .GridSize = New Drawing.Size(2, 3),
        .ImageAlign = ContentAlignment.TopCenter,
        .Text = ""
        })
      .AddItem("301", New RibbonItemButton("301", "Btn301") With {
        .Image = My.Resources.clipboard_cut,
        .GridLocation = New Point(3, 1),
        .GridSize = New Drawing.Size(1, 1),
        .ImageAlign = ContentAlignment.MiddleCenter,
        .Text = ""
        })
      .AddItem("302", New RibbonItemButton("302", "Btn302") With {
        .Image = My.Resources.clipboard_copy,
        .GridLocation = New Point(3, 2),
        .GridSize = New Drawing.Size(1, 1),
        .ImageAlign = ContentAlignment.MiddleCenter,
        .Text = ""
      })
    End With
  End Sub

  Private Sub frmTestRibbon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    bar = New Ribbon()
    With pnlContainer
      .BackColor = My.Theme.AppBackColor
      .ForeColor = My.Theme.AppFontColor
      .Controls.Add(bar)
    End With
  End Sub

#End Region

End Class