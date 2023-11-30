Imports System.ComponentModel
Imports Newtonsoft.Json

Public Class Ribbon
  Inherits TabControl

#Region "Properties"

  <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
  Private Shadows ReadOnly Property TabPages As TabPageCollection
    Get
      Return MyBase.TabPages
    End Get
  End Property

  Public Property AppBackColor As Color = My.Theme.AppBackColor
  Public Property AppForeColor As Color = My.Theme.AppFontColor
  Public Property AppHighlightColor As Color = My.Theme.AppHighlightColor
  Public Property RibbonAccentColor As Color = My.Theme.RibbonAccentColor
  Public Property RibbonBackColor As Color = My.Theme.RibbonBackColor
  Public Property RibbonForeColor As Color = My.Theme.RibbonForeColor
  Public Property RibbonShadowColor As Color = My.Theme.RibbonShadowColor

#End Region

#Region "Public Constructors"

  Public Sub New()
    MyBase.New
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    UpdateStyles()
    SuspendLayout()
    AllowDrop = False
    DrawMode = TabDrawMode.OwnerDrawFixed
    BackColor = AppBackColor
    Font = My.Theme.AppFont
    Margin = New System.Windows.Forms.Padding(0)
    MaximumSize = New System.Drawing.Size(0, 1 + RibbonConfig.RIBBON_BAR_HEIGHT + RibbonConfig.RIBBON_TAB_HEIGHT + (2 * 8))
    MinimumSize = New System.Drawing.Size(100, 1 + RibbonConfig.RIBBON_BAR_HEIGHT + RibbonConfig.RIBBON_TAB_HEIGHT + (2 * 8))
    Name = "Ribbon"
    'Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
    Dock = DockStyle.Top
    TabPages.Clear()
    ResumeLayout(False)
    PerformLayout()
  End Sub

#End Region

#Region "Private Methods"

  Private Sub RenderControl(sender As Object, e As PaintEventArgs) Handles Me.Paint
    Dim g As Graphics = e.Graphics

    'Pain the background
    Using brush As New SolidBrush(AppBackColor)
      e.Graphics.FillRectangle(brush, ClientRectangle)
    End Using
    If TabCount = 0 Then Exit Sub

    Dim w As Integer = 1
    Dim l As Integer = Left
    Dim t As Integer = GetTabRect(0).Height + 2

    Dim r As Integer = Right - 1
    Dim b As Integer = Height - t - 1
    Dim tabOrigBounds As Rectangle
    Dim tabBounds As Rectangle
    Dim textColor As Color
    Dim tabColor As Color
    Dim stringFormat As New StringFormat With {
      .Alignment = StringAlignment.Center,
      .LineAlignment = StringAlignment.Center
    }

    'Add the tabs
    For i As Integer = 0 To TabPages.Count - 1
      tabOrigBounds = GetTabRect(i)

      'Erase current tab
      Using brush As New SolidBrush(AppBackColor)
        g.FillRectangle(brush, tabOrigBounds)
      End Using

      textColor = AppForeColor
      tabColor = AppBackColor
      tabBounds = New Rectangle(tabOrigBounds.X, tabOrigBounds.Y + 1, tabOrigBounds.Width, tabOrigBounds.Height - 3)
      ' Fill the new tab
      Using brush As New SolidBrush(tabColor)
        g.FillRectangle(brush, tabBounds)
      End Using

      ' Draw the tab text
      Using brush As New SolidBrush(textColor)
        g.DrawString(TabPages(i).Text, Font, brush, tabBounds, stringFormat)
      End Using

      If SelectedIndex = i Then
        g.DrawLine(New Pen(AppHighlightColor, 2), tabBounds.Left + 1, tabBounds.Bottom - 1, tabBounds.Right - 1, tabBounds.Bottom - 1)
      End If

    Next

  End Sub

#End Region

#Region "Public Methods"

  Public Function AddBar(sName As String, sCaption As String, iBarId As Integer) As AncestryAssistant.RibbonBar
    Dim Tab As New TabPage(sCaption) With {
      .Name = sName,
      .Tag = iBarId,
      .BackColor = AppBackColor,
      .ForeColor = AppForeColor,
    .Font = My.Theme.AppFont
    }
    Dim Bar As New RibbonBar(Me, sName, iBarId) With {
      .Dock = DockStyle.Fill,
  .AppBackColor = AppBackColor,
    .AppForeColor = AppForeColor,
    .AppHighlightColor = AppHighlightColor,
    .RibbonAccentColor = RibbonAccentColor,
    .RibbonBackColor = RibbonBackColor,
    .RibbonForeColor = RibbonForeColor,
    .RibbonShadowColor = RibbonShadowColor
    }
    Tab.Controls.Add(Bar)
    Controls.Add(Tab)
    RegisterBar(Bar)
    Return Bar
  End Function

  Public Sub AddPage(PageId As String, Text As String, PageControl As RibbonPage)
    Dim Tab As New TabPage(Text) With {
      .Name = "PAGE_" + PageId,
      .Tag = PageId,
      .BackColor = AppBackColor,
      .ForeColor = AppForeColor,
      .Font = My.Theme.AppFont
    }
    Controls.Add(Tab)
  End Sub

  Public Sub LoadConfig(jsonConfig As String)
    Dim cfg As RibbonConfig = JsonConvert.DeserializeObject(Of RibbonConfig)(jsonConfig)
    For Each Bar As RibbonConfig.Bar In cfg.bars
      Dim rBar As RibbonBar = AddBar(Bar.name, Bar.text, Bar.id)
      For Each refGrp As RibbonConfig.Group In Bar.groups
        Dim Grp As RibbonConfig.Group = cfg.GetGroup(refGrp)
        Dim rBarGrp As RibbonGroup = rBar.AddGroup(Grp.name, Grp.text, Bar.id, Grp.id)
        For Each refItem As RibbonConfig.Item In Grp.items
          Dim Item As RibbonConfig.Item = cfg.GetItem(refItem)
          Dim rBarGrpItem As RibbonItem = Nothing
          Select Case Item.itemtype
            Case RibbonItemType.RIButton
              '.Image = Item.getIcon
              rBarGrpItem = New RIButton() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan,
                .Image = Item.getIcon()
              }
            Case RibbonItemType.RIButtonDropDown
              rBarGrpItem = New RIButtonDropDown() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
            Case RibbonItemType.RIButtonSplit
              rBarGrpItem = New RIButtonSplit() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
            Case RibbonItemType.RIListBox
              rBarGrpItem = New RIListBox() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
            Case RibbonItemType.RIListView
              rBarGrpItem = New RIListView() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
            Case RibbonItemType.RICheckBox
              rBarGrpItem = New RICheckBox() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
            Case RibbonItemType.RILabel
              rBarGrpItem = New RILabel() With {
              .Name = Item.name,
              .Text = Item.getAttribute("text"),
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
            Case RibbonItemType.RIImageIcon
              rBarGrpItem = New RIImageIcon() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
            Case RibbonItemType.RIImage
              rBarGrpItem = New RIImage() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
              'Dim ri As New RIImage(Item.name, Bar.id, Grp.id, Item.id) With {
              '  .Grid = New RibbonGroup.Grid(Item.grid.location.Point, Item.grid.size.Size)
              '}
              'ri.LoadImage(Item.getAttribute("imageFilename"))
              'rBarGrpItem = ri
            Case RibbonItemType.RISeperator
              rBarGrpItem = New RISeperator() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
            Case RibbonItemType.RIListBoxFont
              rBarGrpItem = New RIListBoxFont() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
            Case RibbonItemType.RIListBoxFontSize
              rBarGrpItem = New RIListBoxFontSize() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
            Case RibbonItemType.RIListBoxFontColor
              rBarGrpItem = New RIListBoxFontColor() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
            Case RibbonItemType.RIListBoxColor
              rBarGrpItem = New RIListBoxColor() With {
              .Name = Item.name,
              .Text = Item.text,
              .BarId = rBar.BarId,
              .GroupId = rBarGrp.GroupId,
              .ItemId = Item.id,
              .Col = Item.col,
                .Row = Item.row,
                .ColSpan = Item.colspan,
                .RowSpan = Item.rowspan
              }
          End Select
          If rBarGrpItem IsNot Nothing Then
            Debug.Print("LoadConfig.AddBar({0}).AddGroup({1}).AddItem({2})", Bar.name, Grp.name, Item.name)
            rBarGrp.AddItem(rBarGrpItem)
          End If
        Next
      Next
    Next
  End Sub

  Public Sub RegisterBar(bar As RibbonBar)

  End Sub

  Public Sub RegisterGroup(group As RibbonGroup)

  End Sub

  Public Sub RegisterItem(item As RibbonItem)

  End Sub

#End Region

End Class