Imports System.IO

Public Class CensusViewer
  Inherits UserControl
  Implements IDockPanelItem

#Region "Fields"

  Private WithEvents ts As FlatToolBar

  Private WithEvents xlsActiveSheet As DataGridView

  Private Const EN_ITEMCAPTION As String = "Census"

  Const UNIFIED_TEXT As String = "Unified"

  Private Ancestor As AncestorCollection.Ancestor

  Private AvailableYears() As Integer = {1950, 1940, 1930, 1920, 1910, 1900, 1890, 1880, 1870, 1860, 1850, 1840, 1830, 1820, 1810, 1800, 1790}

  Private CensusData As Collection

  Private CensusFileList As Collection

  Private components As System.ComponentModel.IContainer

  Private xlsWorkbook As Dictionary(Of Integer, DataGridView)

#End Region

#Region "Events"

  Public Event AncestorAssigned() Implements IDockPanelItem.AncestorAssigned

  Public Event AncestorUpdated() Implements IDockPanelItem.AncestorUpdated

  Public Event PanelItemGotFocus(sender As Object, e As EventArgs) Implements IDockPanelItem.PanelItemGotFocus

#End Region

#Region "Properties"

  Public ReadOnly Property ItemCaption As String = EN_ITEMCAPTION Implements IDockPanelItem.ItemCaption
  Public Property ItemDockPanelLocation As DockPanelLocation Implements IDockPanelItem.ItemDockPanelLocation
  Public Property ItemHasFocus As Boolean = False Implements IDockPanelItem.ItemHasFocus
  Public ReadOnly Property ItemHasRibbonBar As Boolean = True Implements IDockPanelItem.ItemHasRibbonBar
  Public ReadOnly Property ItemHasToolBar As Boolean = True Implements IDockPanelItem.ItemHasToolBar
  Public ReadOnly Property ItemSupportsClose As Boolean = True Implements IDockPanelItem.ItemSupportsClose
  Public ReadOnly Property ItemSupportsMove As Boolean = True Implements IDockPanelItem.ItemSupportsMove
  Public ReadOnly Property ItemSupportsSearch As Boolean = True Implements IDockPanelItem.ItemSupportsSearch
  Public ReadOnly Property ShowRibbonOnFocus As String = UNIFIED_TEXT Implements IDockPanelItem.ShowRibbonOnFocus

#End Region

#Region "Public Constructors"

  Public Sub New()
    ts = New FlatToolBar()
    SuspendLayout()
    With ts
      .SuspendLayout()
      .BackColor = My.Theme.PanelBorderColor
      .ForeColor = My.Theme.PanelFontColor
      .GripStyle = ToolStripGripStyle.Hidden
      .Location = New Point(0, 0)
      .Name = "ts"
      .Size = New Size(439, 25)
      .TabIndex = 3
      .Text = "ToolStrip1"
    End With
    AutoScaleDimensions = New SizeF(6.0!, 13.0!)
    AutoScaleMode = AutoScaleMode.None
    BackColor = My.Theme.PanelBackColor
    ForeColor = My.Theme.PanelFontColor
    Controls.Add(xlsActiveSheet)
    Controls.Add(ts)
    DoubleBuffered = True
    Font = New Font("Segoe UI", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    Name = "CensusViewer"
    Size = New Size(439, 150)
    Dock = DockStyle.Fill
    ts.ResumeLayout(False)
    ts.PerformLayout()
    ResumeLayout(False)
    PerformLayout()
    CaptureFocus(Me)
  End Sub

#End Region

#Region "Private Methods"

  Private Sub AddCensusFile(CensusYear As String, Filename As String)
    Debug.Print(CensusYear, Filename)
    'CensusFileList.Add(Filename, CensusYear)
    'For Each btn As ToolStripItem In tsCensus.Items
    'If btn.Text.Equals(CensusYear) Then
    'btn.Visible = True
    'End If
    'Next
  End Sub

  Private Sub addRemapData(CensusYear As Integer, BaseKey As Integer, CensusHeader As String, Optional CustomHandler As String = "")
    Debug.Print(CensusYear, BaseKey, CensusHeader, CustomHandler)
  End Sub

  Private Sub addUnifiedData(CensusOrder As Integer, BaseKey As Integer, CensusHeader As String)
    Debug.Print(CensusOrder, BaseKey, CensusHeader)
  End Sub

  Private Sub CaptureFocus(ctl As Control)
    Try
      AddHandler ctl.GotFocus, AddressOf DockPanelItem_GotFocus
      AddHandler ctl.MouseDown, AddressOf DockPanelItem_GotFocus
    Catch ex As Exception
    End Try
    For Each childCtl As Control In ctl.Controls
      CaptureFocus(childCtl)
    Next
  End Sub

  Private Sub CensusSelect(sender As Object, e As EventArgs)
    If TypeOf sender IsNot ToolStripButton Then Exit Sub
    Dim srcSender As ToolStripButton = DirectCast(sender, ToolStripButton)
    For Each btn As ToolStripButton In ts.Items
      If srcSender.Text.Equals(btn.Text) Then
        btn.Checked = True
        btn.ForeColor = My.Theme.PanelFontColor
      Else
        btn.Checked = False
        btn.ForeColor = My.Theme.PanelFontColor
      End If
    Next
    If srcSender.Text.Equals(UNIFIED_TEXT) Then
      'TODO
    Else
      showWorkSheet(CInt(srcSender.Text))
    End If
  End Sub

  Private Sub CensusViewer_AncestorAssigned() Handles Me.AncestorAssigned
    LoadCensus()
  End Sub

  Private Sub CensusViewer_AncestorUpdated() Handles Me.AncestorUpdated
    LoadCensus()
  End Sub

  Private Function CreateWorkSheet(censusYear As Integer) As DataGridView
    Dim tmpWorkSheet As New DataGridView
    CType(tmpWorkSheet, System.ComponentModel.ISupportInitialize).BeginInit()
    With tmpWorkSheet
      .AllowUserToAddRows = False
      .AllowUserToDeleteRows = False
      .AllowUserToOrderColumns = True
      .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
      .BorderStyle = BorderStyle.None
      .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
      .Dock = DockStyle.Fill
      .Location = New Point(0, 25)
      .Margin = New Padding(0)
      .ShowEditingIcon = False
      .Size = New Size(439, 125)
    End With
    CType(tmpWorkSheet, System.ComponentModel.ISupportInitialize).EndInit()
    'Get the data
    Dim aa As AAFile = Ancestor.Census.GetAADatasource(censusYear)
    Dim i As Integer
    'Add Header to table
    For Each columnName As String In aa.GetHeaders
      Dim column As New DataGridViewTextBoxColumn With {
        .DataPropertyName = columnName,
        .HeaderText = columnName
      }
      tmpWorkSheet.Columns.Add(column)
    Next
    'Add Data to table
    For Each row() As String In aa.GetValues
      i = tmpWorkSheet.Rows.Add(row)
    Next
    'Add Sheet to the workbook
    xlsWorkbook.Add(censusYear, tmpWorkSheet)
    Return tmpWorkSheet
  End Function

  Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles xlsActiveSheet.CellFormatting
    ' Check if the current column is the first column (index 0) and the row is not a header row
    If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
      ' Check the value of the first column
      If xlsActiveSheet.Rows(e.RowIndex).Cells(0).Value IsNot Nothing AndAlso xlsActiveSheet.Rows(e.RowIndex).Cells(0).Value.ToString() = "P" Then
        ' Set the background color to green if col(0)="P"
        xlsActiveSheet.Rows(e.RowIndex).DefaultCellStyle.BackColor = My.Theme.XLSHighlightColor
      ElseIf xlsActiveSheet.Rows(e.RowIndex).Cells(0).Value IsNot Nothing AndAlso xlsActiveSheet.Rows(e.RowIndex).Cells(0).Value.ToString() = "F" Then
        ' Set the background color to yellow if col(0)="F"
        xlsActiveSheet.Rows(e.RowIndex).DefaultCellStyle.BackColor = My.Theme.XLSHighlightColor2
      Else
        ' Reset the background color for other values if needed
        xlsActiveSheet.Rows(e.RowIndex).DefaultCellStyle.BackColor = My.Theme.XLSBackColor
      End If
    End If
  End Sub

  Private Sub DockPanelItem_GotFocus(sender As Object, e As EventArgs)
    RaiseEvent PanelItemGotFocus(sender, e)
  End Sub

  Private Function GetData(csvFilePath As String) As ArrayList
    If CensusData.Contains(csvFilePath) Then
      Return CensusData.Item(csvFilePath)
    End If
    Dim lines As String() = File.ReadAllLines(csvFilePath)
    Dim data As New ArrayList()
    For i As Integer = 0 To lines.Length - 1
      Dim fields As String() = lines(i).Split(","c)
      For j As Integer = 0 To fields.Length - 1
        fields(j) = fields(j).Trim(""""c)
      Next
      data.Add(fields)
    Next
    CensusData.Add(data, csvFilePath)
    Return data
  End Function

  Private Sub GetUnifiedData()
    Dim rtn As New ArrayList()
    Dim data As ArrayList

    'Add Header to rtn

    For Each dt As Integer In AvailableYears
      If CensusFileList.Contains(dt.ToString) Then
        data = GetData(CensusFileList.Item(dt.ToString).ToString)
      End If
    Next
  End Sub

  Private Sub InitializeRemapData()
    addRemapData(1950, 1, "Year")
    addRemapData(1950, 2, "Page")
    addRemapData(1950, 3, "State")
    addRemapData(1950, 4, "County")
    addRemapData(1950, 5, "City")
    addRemapData(1950, 6, "District")
    addRemapData(1950, 7, "Line Number")
    addRemapData(1950, 8, "Dwelling Number")
    addRemapData(1950, 10, "Street Name")
    addRemapData(1950, 11, "House Number")
    addRemapData(1950, 12, "Race")
    addRemapData(1950, 13, "Gender")
    addRemapData(1950, 14, "Relation to Head of House")
    addRemapData(1950, 15, "Surname")
    addRemapData(1950, 16, "Given Name")
    addRemapData(1950, 17, "Age")
    addRemapData(1950, 18, "Birth Date")
    addRemapData(1950, 21, "Birth Place")
    addRemapData(1950, 22, "Father Birth Place")
    addRemapData(1950, 23, "Mother Birth Place")
    addRemapData(1950, 24, "Marital Status")
    addRemapData(1950, 25, "Number of Children")
    addRemapData(1950, 27, "Occupation")
    addRemapData(1950, 28, "Veteran")
    addRemapData(1950, 29, "Years Since Married")
    addRemapData(1950, 31, "Citizenship")
    addRemapData(1950, 32, "Grade Completed")
    addRemapData(1950, 33, "Rent or Own")
    addRemapData(1950, 99, "Ceremonies")
    addRemapData(1950, 99, "Territorial Citizenship")
    addRemapData(1950, 99, "World War I Veteran")
    addRemapData(1950, 99, "World War II Veteran")
    addRemapData(1940, 1, "Year")
    addRemapData(1940, 2, "Page")
    addRemapData(1940, 3, "State")
    addRemapData(1940, 4, "County")
    addRemapData(1940, 5, "City")
    addRemapData(1940, 6, "District")
    addRemapData(1940, 7, "Line Number")
    addRemapData(1940, 10, "Street Name")
    addRemapData(1940, 11, "House Number")
    addRemapData(1940, 12, "Race")
    addRemapData(1940, 13, "Gender")
    addRemapData(1940, 14, "Relation to Head of House")
    addRemapData(1940, 15, "Surname")
    addRemapData(1940, 16, "Given Name")
    addRemapData(1940, 17, "Age")
    addRemapData(1940, 20, "Estimated Birth Year")
    addRemapData(1940, 21, "Birthplace")
    addRemapData(1940, 22, "Father's Birth Place")
    addRemapData(1940, 23, "Mother's Birth Place")
    addRemapData(1940, 24, "Marital Status")
    addRemapData(1940, 25, "Number of Children")
    addRemapData(1940, 27, "Occupation")
    addRemapData(1940, 28, "Veteran")
    addRemapData(1940, 31, "Citizenship")
    addRemapData(1940, 32, "Attended School or College")
    addRemapData(1940, 33, "House Owned or Rented")
    addRemapData(1940, 99, "Military service")
    addRemapData(1940, 99, "Veteran Father Dead")
    addRemapData(1940, 99, "Woman Age at First Marriage")
    addRemapData(1940, 99, "Woman Marriages")
    addRemapData(1930, 1, "Year")
    addRemapData(1930, 2, "Page")
    addRemapData(1930, 3, "State")
    addRemapData(1930, 4, "County")
    addRemapData(1930, 5, "City")
    addRemapData(1930, 6, "District")
    addRemapData(1930, 7, "Line Number")
    addRemapData(1930, 8, "Dwelling Number")
    addRemapData(1930, 9, "Family Number")
    addRemapData(1930, 10, "Street Address")
    addRemapData(1930, 11, "House Number")
    addRemapData(1930, 12, "Race")
    addRemapData(1930, 13, "Gender")
    addRemapData(1930, 14, "Relation to Head")
    addRemapData(1930, 15, "Surname")
    addRemapData(1930, 16, "Given Name")
    addRemapData(1930, 17, "Age")
    addRemapData(1930, 20, "Estimated Birth Year")
    addRemapData(1930, 21, "Birthplace")
    addRemapData(1930, 22, "Father's Birthplace")
    addRemapData(1930, 23, "Mother's Birthplace")
    addRemapData(1930, 24, "Marital Status")
    addRemapData(1930, 27, "Occupation")
    addRemapData(1930, 28, "Veteran")
    addRemapData(1930, 29, "Age at First Marriage")
    addRemapData(1930, 30, "Immigration Year")
    addRemapData(1930, 31, "Naturalization")
    addRemapData(1930, 32, "Attended School")
    addRemapData(1930, 33, "Home Owned or Rented")
    addRemapData(1930, 99, "War")
    addRemapData(1920, 1, "Year")
    addRemapData(1920, 2, "Page")
    addRemapData(1920, 3, "State")
    addRemapData(1920, 4, "County")
    addRemapData(1920, 5, "City")
    addRemapData(1920, 6, "District")
    addRemapData(1920, 7, "Line Number")
    addRemapData(1920, 9, "Family Number")
    addRemapData(1920, 10, "Street")
    addRemapData(1920, 11, "House Number")
    addRemapData(1920, 12, "Race")
    addRemapData(1920, 13, "Sex")
    addRemapData(1920, 14, "Relationship")
    addRemapData(1920, 15, "Surname")
    addRemapData(1920, 16, "Given Name")
    addRemapData(1920, 17, "Age")
    addRemapData(1920, 20, "Estimated Birth Year")
    addRemapData(1920, 21, "Birthplace")
    addRemapData(1920, 22, "Father's Birthplace")
    addRemapData(1920, 23, "Mother's Birthplace")
    addRemapData(1920, 24, "Marital Status")
    addRemapData(1920, 27, "Occupation")
    addRemapData(1920, 30, "Immigration Year")
    addRemapData(1920, 31, "Naturalization Year")
    addRemapData(1920, 32, "Attended School")
    addRemapData(1920, 33, "Home Owned or Rented")
    addRemapData(1920, 99, "Naturalization Status")
    addRemapData(1910, 1, "Year")
    addRemapData(1910, 2, "Page")
    addRemapData(1910, 3, "State")
    addRemapData(1910, 4, "County")
    addRemapData(1910, 5, "City")
    addRemapData(1910, 6, "District")
    addRemapData(1910, 7, "Line Number")
    addRemapData(1910, 8, "Dwelling Number")
    addRemapData(1910, 9, "Family Number")
    addRemapData(1910, 10, "Street Name")
    addRemapData(1910, 12, "Race")
    addRemapData(1910, 13, "Gender")
    addRemapData(1910, 14, "Relationship")
    addRemapData(1910, 15, "Surname")
    addRemapData(1910, 16, "Given Name")
    addRemapData(1910, 17, "Age")
    addRemapData(1910, 19, "Birth Month")
    addRemapData(1910, 20, "Estimated Birth Year")
    addRemapData(1910, 21, "Birthplace")
    addRemapData(1910, 22, "Father's Birthplace")
    addRemapData(1910, 23, "Mother's Birthplace")
    addRemapData(1910, 24, "Marital Status")
    addRemapData(1910, 25, "Number of Children Born")
    addRemapData(1910, 26, "Number of Children Living")
    addRemapData(1910, 27, "Occupation")
    addRemapData(1910, 28, "Survivor of Confederate or Union of Army or Navy")
    addRemapData(1910, 29, "Number of Years of Present Marriage")
    addRemapData(1910, 30, "Immigration Year")
    addRemapData(1910, 31, "Naturalization Status")
    addRemapData(1910, 32, "Attended School")
    addRemapData(1910, 33, "Own or Rent")
    addRemapData(1900, 1, "Year")
    addRemapData(1900, 2, "Page")
    addRemapData(1900, 3, "State")
    addRemapData(1900, 4, "County")
    addRemapData(1900, 5, "City")
    addRemapData(1900, 6, "District")
    addRemapData(1900, 7, "Line Number")
    addRemapData(1900, 8, "Number of Dwelling in Order of Visitation")
    addRemapData(1900, 9, "Family Number")
    addRemapData(1900, 10, "Street")
    addRemapData(1900, 12, "Race")
    addRemapData(1900, 13, "Gender")
    addRemapData(1900, 14, "Relationship")
    addRemapData(1900, 15, "Surname")
    addRemapData(1900, 16, "Given Name")
    addRemapData(1900, 17, "Age")
    addRemapData(1900, 19, "Birth Month")
    addRemapData(1900, 20, "Birth Year")
    addRemapData(1900, 21, "Birthplace")
    addRemapData(1900, 22, "Father's Birthplace")
    addRemapData(1900, 23, "Mother's Birthplace")
    addRemapData(1900, 24, "Marital Status")
    addRemapData(1900, 25, "Number of Children Born")
    addRemapData(1900, 26, "Number of Children Living")
    addRemapData(1900, 27, "Occupation")
    addRemapData(1900, 29, "Years Married")
    addRemapData(1900, 30, "Immigration Year")
    addRemapData(1900, 31, "Naturalization")
    addRemapData(1900, 32, "Attended School")
    addRemapData(1900, 33, "House Owned or Rented")
    addRemapData(1900, 99, "Years in US")
    addRemapData(1880, 1, "Year")
    addRemapData(1880, 2, "Page")
    addRemapData(1880, 3, "State")
    addRemapData(1880, 4, "County")
    addRemapData(1880, 5, "City")
    addRemapData(1880, 6, "District")
    addRemapData(1880, 7, "Line Number")
    addRemapData(1880, 8, "Dwelling Number")
    addRemapData(1880, 10, "Street")
    addRemapData(1880, 12, "Race")
    addRemapData(1880, 13, "Gender")
    addRemapData(1880, 14, "Relation to Head of House")
    addRemapData(1880, 15, "Surname")
    addRemapData(1880, 16, "Given Name")
    addRemapData(1880, 17, "Age")
    addRemapData(1880, 19, "Birth Month")
    addRemapData(1880, 20, "Birth Year")
    addRemapData(1880, 21, "Birthplace")
    addRemapData(1880, 22, "Father's Birthplace")
    addRemapData(1880, 23, "Mother's Birthplace")
    addRemapData(1880, 24, "Marital Status")
    addRemapData(1880, 27, "Occupation")
    addRemapData(1880, 29, "Married During Census Year")
    addRemapData(1880, 32, "Attended School")
    addRemapData(1870, 1, "Year")
    addRemapData(1870, 2, "Page")
    addRemapData(1870, 3, "State")
    addRemapData(1870, 4, "County")
    addRemapData(1870, 5, "City")
    addRemapData(1870, 6, "District")
    addRemapData(1870, 7, "Line Number")
    addRemapData(1870, 8, "Dwelling Number")
    addRemapData(1870, 9, "Family Number")
    addRemapData(1870, 12, "Race")
    addRemapData(1870, 13, "Gender")
    addRemapData(1870, 15, "Surname")
    addRemapData(1870, 16, "Given Name")
    addRemapData(1870, 17, "Age")
    addRemapData(1870, 19, "Birth Month")
    addRemapData(1870, 20, "Birth Year")
    addRemapData(1870, 21, "Birthplace")
    addRemapData(1870, 22, "Father of Foreign Birth")
    addRemapData(1870, 23, "Mother of Foreign Birth")
    addRemapData(1870, 24, "Marriage Month")
    addRemapData(1870, 27, "Occupation")
    addRemapData(1870, 32, "Attended School")
    addRemapData(1870, 33, "Real Estate Value")
    addRemapData(1860, 1, "Year")
    addRemapData(1860, 2, "Page")
    addRemapData(1860, 3, "State")
    addRemapData(1860, 4, "County")
    addRemapData(1860, 5, "City")
    addRemapData(1860, 6, "District")
    addRemapData(1860, 8, "Dwelling Number")
    addRemapData(1860, 9, "Family Number")
    addRemapData(1860, 12, "Race")
    addRemapData(1860, 13, "Gender")
    addRemapData(1860, 15, "Surname")
    addRemapData(1860, 16, "Given Name")
    addRemapData(1860, 17, "Age")
    addRemapData(1860, 20, "Birth Year")
    addRemapData(1860, 21, "Birth Place")
    addRemapData(1860, 24, "Married Within Year")
    addRemapData(1860, 27, "Occupation")
    addRemapData(1860, 32, "Attended School")
    addRemapData(1860, 33, "Real Estate Value")
    addRemapData(1850, 1, "Year")
    addRemapData(1850, 2, "Page")
    addRemapData(1850, 3, "State")
    addRemapData(1850, 4, "County")
    addRemapData(1850, 5, "City")
    addRemapData(1850, 6, "District")
    addRemapData(1850, 7, "Line Number")
    addRemapData(1850, 8, "Dwelling Number")
    addRemapData(1850, 9, "Family Number")
    addRemapData(1850, 12, "Race")
    addRemapData(1850, 13, "Gender")
    addRemapData(1850, 15, "Surname")
    addRemapData(1850, 16, "Given Name")
    addRemapData(1850, 17, "Age")
    addRemapData(1850, 20, "Birth Year")
    addRemapData(1850, 21, "Birth Place")
    addRemapData(1850, 24, "Married within the Year")
    addRemapData(1850, 27, "Occupation")
    addRemapData(1850, 32, "Attended School")
    addRemapData(1850, 33, "Real Estate")
    addRemapData(1840, 1, "Year")
    addRemapData(1840, 2, "Page")
    addRemapData(1840, 3, "State")
    addRemapData(1840, 4, "County")
    addRemapData(1840, 5, "City")
    addRemapData(1840, 6, "District")
    addRemapData(1840, 15, "Name")
    addRemapData(1840, 17, "Age")
    addRemapData(1830, 1, "Year")
    addRemapData(1830, 2, "Page")
    addRemapData(1830, 3, "State")
    addRemapData(1830, 4, "County")
    addRemapData(1830, 5, "City")
    addRemapData(1830, 6, "District")
    addRemapData(1830, 15, "Surname")
    addRemapData(1830, 16, "Given Name")
    addRemapData(1820, 1, "Year")
    addRemapData(1820, 2, "Page")
    addRemapData(1820, 3, "State")
    addRemapData(1820, 4, "County")
    addRemapData(1820, 5, "City")
    addRemapData(1820, 6, "District")
    addRemapData(1820, 15, "Name")
    addRemapData(1810, 1, "Year")
    addRemapData(1810, 2, "Page")
    addRemapData(1810, 3, "State")
    addRemapData(1810, 4, "County")
    addRemapData(1810, 5, "City")
    addRemapData(1810, 6, "District")
    addRemapData(1810, 15, "Name")
    addRemapData(1800, 1, "Year")
    addRemapData(1800, 2, "Page")
    addRemapData(1800, 3, "State")
    addRemapData(1800, 4, "County")
    addRemapData(1800, 5, "City")
    addRemapData(1800, 6, "District")
    addRemapData(1800, 15, "Surname")
    addRemapData(1800, 16, "Given Name")
    addRemapData(1790, 1, "Year")
    addRemapData(1790, 2, "Page")
    addRemapData(1790, 3, "State")
    addRemapData(1790, 4, "County")
    addRemapData(1790, 5, "City")
    addRemapData(1790, 6, "District")
    addRemapData(1790, 15, "Name")
    addUnifiedData(1, 1, "Year")
    addUnifiedData(2, 2, "Page")
    addUnifiedData(3, 7, "LineNumber")
    addUnifiedData(4, 8, "Dwelling Number")
    addUnifiedData(5, 9, "Family Number")
    addUnifiedData(6, 14, "RelationToHead")
    addUnifiedData(7, 15, "Surname")
    addUnifiedData(8, 16, "GivenName")
    addUnifiedData(9, 12, "Race")
    addUnifiedData(10, 13, "Gender")
    addUnifiedData(11, 17, "Age")
    addUnifiedData(12, 18, "BirthDate")
    addUnifiedData(13, 19, "BirthMonth")
    addUnifiedData(14, 20, "BirthYear")
    addUnifiedData(15, 21, "BirthPlace")
    addUnifiedData(16, 22, "BirthPlaceFather")
    addUnifiedData(17, 23, "BirthPlaceMother")
    addUnifiedData(18, 24, "MarriageStatus")
    addUnifiedData(19, 29, "MarriageYears")
    addUnifiedData(20, 25, "ChildrenBorn")
    addUnifiedData(21, 26, "ChildrenLiving")
    addUnifiedData(22, 28, "Veteran")
    addUnifiedData(23, 30, "Immigration")
    addUnifiedData(24, 31, "Naturalization")
    addUnifiedData(25, 32, "Education")
    addUnifiedData(26, 27, "Occupation")
    addUnifiedData(27, 33, "HouseOwnedRented")
    addUnifiedData(28, 10, "StreetName")
    addUnifiedData(29, 11, "HouseNumber")
    addUnifiedData(30, 3, "State")
    addUnifiedData(31, 4, "County")
    addUnifiedData(32, 5, "City")
    addUnifiedData(33, 6, "District")

  End Sub

  Private Sub LoadCensus()
    ResetViewer()
    If Ancestor Is Nothing Then Exit Sub
    Dim item As ToolStripButton
    Dim expectedCensus As List(Of Integer) = Ancestor.Census.ExpectedYears
    Dim availableCensus As List(Of Integer) = Ancestor.Census.AvailableYears
    If expectedCensus.Count > 0 Then
      For Each censusYear As Integer In expectedCensus
        item = New ToolStripButton(censusYear.ToString)
        If availableCensus.Contains(censusYear) Then
          item.CheckOnClick = True
          item.ForeColor = My.Theme.PanelFontColor
          item.ToolTipText = censusYear & " Census"
          item.Tag = Nothing
          AddHandler item.Click, AddressOf CensusSelect
        Else
          item.Enabled = False
          item.ForeColor = My.Theme.PanelFontColor 'Need to modify theme and code to allow for error condition
          item.ToolTipText = censusYear & " Census Unavailable"
        End If
        ts.Items.Add(item)
      Next
      If availableCensus.Count > 0 Then
        item = New ToolStripButton(UNIFIED_TEXT) With {
          .ForeColor = My.Theme.PanelFontColor,
          .ToolTipText = "Unified view of all available Census Years",
          .Tag = Nothing
        }
        AddHandler item.Click, AddressOf CensusSelect
        ts.Items.Add(item)
      End If
    End If
  End Sub

  Private Sub LoadFile(csvFilePath As String)
    Dim lines As ArrayList = GetData(csvFilePath)
    xlsActiveSheet.Columns.Clear()
    xlsActiveSheet.Rows.Clear()
    xlsActiveSheet.SuspendLayout()
    Dim i As Integer = 0
    For Each data() As String In lines
      If i = 0 Then
        For Each column As String In data
          xlsActiveSheet.Columns.Add(column, column)
        Next
      Else
        xlsActiveSheet.Rows.Add(data)
      End If
      i += 1
    Next
    xlsActiveSheet.ResumeLayout(False)
    xlsActiveSheet.PerformLayout()
  End Sub

  Private Sub ResetViewer()
    Dim idx As Integer = 0
    While idx < Controls.Count
      If TypeOf Controls.Item(idx) Is DataGridView Then
        Controls.RemoveAt(idx)
      Else
        idx += 1
      End If
    End While
    ts.Items.Clear()
    xlsActiveSheet = Nothing
    xlsWorkbook = New Dictionary(Of Integer, DataGridView)
  End Sub

  Private Sub ShowCensus(CensusYear As String)
    If CensusFileList.Contains(CensusYear) Then
      LoadFile(CensusFileList.Item(CensusYear))
    End If
  End Sub

  Private Sub ShowUnified()
    Debug.Print("Show Unified")
  End Sub

  Private Sub showWorkSheet(censusYear As Integer)
    If xlsWorkbook.ContainsKey(censusYear) Then
      xlsActiveSheet = xlsWorkbook.Item(censusYear)
    Else
      xlsActiveSheet = CreateWorkSheet(censusYear)
      Controls.Add(xlsActiveSheet)
    End If
    xlsActiveSheet.BringToFront()
  End Sub

#End Region

#Region "Protected Methods"

  'UserControl overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

#End Region

#Region "Public Methods"

  Public Sub ApplySearch(criteria As String) Implements IDockPanelItem.ApplySearch
    Throw New NotImplementedException()
  End Sub

  Public Sub ClearSearch() Implements IDockPanelItem.ClearSearch
    Throw New NotImplementedException()
  End Sub

  Public Function GetDockToolBarConfig() As DockToolBarConfig Implements IDockPanelItem.GetDockToolBarConfig
    Throw New NotImplementedException()
  End Function

  Public Function GetRibbonBarConfig() As RibbonBarTabConfig Implements IDockPanelItem.GetRibbonBarConfig
    Throw New NotImplementedException()
  End Function

  Public Sub RefreshAncestor() Implements IDockPanelItem.RefreshAncestor
    Throw New NotImplementedException()
  End Sub

  Public Sub SetAncestor(activeAncestor As AncestorCollection.Ancestor) Implements IDockPanelItem.SetAncestor
    Throw New NotImplementedException()
  End Sub

#End Region

End Class