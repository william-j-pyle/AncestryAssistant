Public Class MenuStripRenderer
    Inherits ToolStripProfessionalRenderer

  Private COLOR_BG As Color = My.Application.COLOR_BG
  Private COLOR_FG As Color = My.Application.COLOR_FG
  Private COLOR_FG_DISABLED As Color = My.Application.COLOR_FG_DISABLED

  Private COLOR_HOVER_BG As Color = My.Application.COLOR_HOVER_BG
  Private COLOR_HOVER_FG As Color = My.Application.COLOR_HOVER_FG
  Private COLOR_HOVER_BORDER As Color = My.Application.COLOR_HOVER_BORDER

  Private COLOR_SELECTED_BG As Color = My.Application.COLOR_SELECTED_BG
  Private COLOR_SELECTED_FG As Color = My.Application.COLOR_SELECTED_FG
  Private COLOR_SELECTED_BORDER As Color = My.Application.COLOR_SELECTED_BORDER

  Public Sub New()
        MyBase.New()
    End Sub

    Private Sub ToolStripRenderer_RenderMenuItemBackground(sender As Object, e As ToolStripItemRenderEventArgs) Handles Me.RenderMenuItemBackground
        'dumpBar()
        'DumpInfo(e.Item.Text, "0/0/W/H", 0, 0, e.Item.Width, e.Item.Height)
        'DumpInfo(e.Item.Text, "Bounds", e.Item.Bounds)
        'DumpInfo(e.Item.Text, "ContentRectangle", e.Item.ContentRectangle)
        'DumpSetting(e.Item.Text, "Selected", e.Item.Selected)
        'DumpSetting(e.Item.Text, "IsOnDropDown", e.Item.IsOnDropDown)
        'DumpSetting(e.Item.Text, "Pressed", e.Item.Pressed)

        With e.Item
            If Not .IsOnDropDown Then
                'This is a top level item
                If Not .Selected And Not .Pressed Then
                    'Paint the default background and we are done
                    Using brush As SolidBrush = New SolidBrush(COLOR_BG)
                        e.Graphics.FillRectangle(brush, 0, 0, .Width, .Height)
                    End Using
                    Exit Sub
                End If
                If .Selected And Not .Pressed Then
                    'We are hovering over this item, needs BG and Border
                    'Paint BG
                    Using brush As SolidBrush = New SolidBrush(COLOR_HOVER_BG)
                        e.Graphics.FillRectangle(brush, 0, 0, .Width, .Height)
                    End Using
                    'Draw border
                    Using pen As Pen = New Pen(COLOR_HOVER_BORDER, 1)
                        e.Graphics.DrawRectangle(pen, 0, 0, e.Item.Width - 1, e.Item.Height - 1)
                    End Using
                    Exit Sub
                End If
                If .Pressed Then
                    'Paint the dropdown style, but only draw borders on left/top/right
                    Using brush As SolidBrush = New SolidBrush(COLOR_SELECTED_BG)
                        e.Graphics.FillRectangle(brush, 0, 0, .Width, .Height)
                    End Using
                    Using pen As Pen = New Pen(COLOR_SELECTED_BORDER, 1)
                        'top
                        e.Graphics.DrawLine(pen, 0, 0, e.Item.Width - 1, 0)
                        'left
                        e.Graphics.DrawLine(pen, 0, 0, 0, e.Item.Height - 1)
                        'right
                        e.Graphics.DrawLine(pen, e.Item.Width - 1, 0, e.Item.Width - 1, e.Item.Height - 1)
                    End Using
                    Exit Sub
                End If
            Else
                'This is a child panel item
                If .Selected Then
                    Const offset As Single = 4
                    Using brush As SolidBrush = New SolidBrush(COLOR_HOVER_BG)
                        e.Graphics.FillRectangle(brush, 0, 0, .Width - 1, .Height + 1)
                    End Using
                    Using pen As Pen = New Pen(COLOR_HOVER_BORDER, 1)
                        e.Graphics.DrawRectangle(pen, offset, 0, .Width - 1 - (2 * offset), .Height - 1)
                    End Using
                Else
                    Using brush As SolidBrush = New SolidBrush(COLOR_SELECTED_BG)
                        e.Graphics.FillRectangle(brush, 0, 0, .Width, .Height)
                    End Using
                End If

            End If
        End With
    End Sub

    Private Sub ToolStripRenderer_RenderSeparator(sender As Object, e As ToolStripSeparatorRenderEventArgs) Handles Me.RenderSeparator
        If e.Item.IsOnDropDown Then
            Using brush As SolidBrush = New SolidBrush(COLOR_SELECTED_BG)
                e.Graphics.FillRectangle(brush, 0 - 2, 0, e.Item.Width + 2, e.Item.Height)
            End Using
            Using pen As Pen = New Pen(COLOR_SELECTED_BORDER, 1)
                Dim y As Single = ((e.Item.ContentRectangle.Y + 1) / 2) + 1
                Dim x As Single = 26
                Dim w As Single = e.Item.Width - 30
                e.Graphics.DrawLine(pen, x, y, w, y)
            End Using
        End If
    End Sub



    Private Sub ToolStripRenderer_RenderToolStripBorder(sender As Object, e As ToolStripRenderEventArgs) Handles Me.RenderToolStripBorder
        'dumpBar()
        'DumpInfo("RenderToolStripBorder", "ConnectedArea", e.ConnectedArea)
        'DumpInfo("RenderToolStripBorder", "AffectedBounds", e.AffectedBounds)

        If e.ConnectedArea.IsEmpty Then
            'ConnectedArea is all 0 then this is just normal borders
            Using pen As Pen = New Pen(COLOR_BG, 2)
                e.Graphics.DrawRectangle(pen, e.AffectedBounds)
            End Using
        Else
            'we are working with a drop down! Need to be all special
            Using brush As SolidBrush = New SolidBrush(COLOR_SELECTED_BG)
                e.Graphics.FillRectangle(brush, e.ConnectedArea)
            End Using
            Using pen As Pen = New Pen(COLOR_SELECTED_BORDER, 1)
                'LEFT OF Connected Area
                e.Graphics.DrawLine(pen, 0, 0, 0, e.ConnectedArea.Height - 1)
                'RIGHT OF Connected Area
                e.Graphics.DrawLine(pen, e.ConnectedArea.Width - 1, 0, e.ConnectedArea.Width - 1, e.ConnectedArea.Height - 1)
                'TOP OF Affected (starts at end of connectedarea opening thru end of affectedbounds
                e.Graphics.DrawLine(pen, e.ConnectedArea.Width, 0, e.AffectedBounds.Width - 1, 0)
                'LEFT of Affected
                e.Graphics.DrawLine(pen, 0, 0, 0, e.AffectedBounds.Height - 1)
                'Right of Affected
                e.Graphics.DrawLine(pen, e.AffectedBounds.Width - 1, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1)
                'Bottom of affected
                e.Graphics.DrawLine(pen, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1)
            End Using
        End If
    End Sub

    Private Sub ToolStripRenderer_RenderImageMargin(sender As Object, e As ToolStripRenderEventArgs) Handles Me.RenderImageMargin
        Using brush As SolidBrush = New SolidBrush(COLOR_SELECTED_BG)
            e.Graphics.FillRectangle(brush, e.AffectedBounds)
        End Using
    End Sub

    'Private Sub DumpSetting(subname As String, src As String, value As Boolean)
    '    Debug.Print(subname & "(" & src & ")=" & value)
    'End Sub

    'Private Sub DumpInfo(subname As String, src As String, rt As Rectangle)
    '    DumpInfo(subname, src, rt.Left, rt.Top, rt.Right, rt.Bottom)
    'End Sub

    'Public Sub DumpInfo(subname As String, src As String, pLeft As Integer, pTop As Integer, pRight As Integer, pBottom As Integer)
    '    Debug.Print(subname & "(" & src & ")=[left:" & pLeft & ",top:" & pTop & ",right:" & pRight & ",bottom:" & pBottom & "]")
    'End Sub

    'Public Sub dumpBar()
    '    Debug.Print("----------------------------------------------------------------")
    'End Sub

End Class