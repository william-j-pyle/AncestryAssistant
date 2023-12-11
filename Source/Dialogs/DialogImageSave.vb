Public Class SaveImageDialog

#Region "Properties"

  Public ReadOnly Property ImageCategory As String
    Get
      Return cmbType.Text
    End Get
  End Property

  Public ReadOnly Property ImageType As String
    Get
      Return cmbCategory.Text
    End Get
  End Property

  Public ReadOnly Property Summary As String
    Get
      Return TxtSummary.Text
    End Get
  End Property

  Public ReadOnly Property TableData As List(Of List(Of String))
    Get
      Return GetDetails()
    End Get
  End Property

#End Region

#Region "Private Methods"

  Private Sub Cancel_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    DialogResult = System.Windows.Forms.DialogResult.Cancel
    Close()
  End Sub

  Private Sub cmbCategory_TextChanged(sender As Object, e As EventArgs) Handles cmbCategory.TextChanged
    loadTypes(cmbCategory.Text)
  End Sub

  Private Function GetDetails() As List(Of List(Of String))
    Dim data As New List(Of List(Of String))

    ' Add headers to the list
    Dim headers As New List(Of String)
    For Each column As DataGridViewColumn In tblDetails.Columns
      headers.Add(column.HeaderText)
    Next
    data.Add(headers)
    ' Add rows to the list
    For Each row As DataGridViewRow In tblDetails.Rows
      Dim rowData As New List(Of String)
      For Each cell As DataGridViewCell In row.Cells
        rowData.Add(cell.Value)
      Next
      data.Add(rowData)
    Next
    Return data
  End Function

  Private Sub InitCategories(txt As String)
    Dim categories As String = My.Settings.IMAGE_CATEGORIES
    cmbCategory.Items.Clear()
    For Each str As String In categories.Split(",")
      cmbCategory.Items.Add(str)
    Next
    cmbCategory.Items.Add("Other")
    cmbCategory.Text = Txt
  End Sub

  Private Sub InitDetails(data As List(Of List(Of String)))
    tblDetails.Rows.Clear()
    tblDetails.Columns.Clear()
    Dim i As Integer = 0
    For Each row As List(Of String) In data
      If i = 0 Then
        For Each columnName As String In row
          Dim column As New DataGridViewTextBoxColumn With {
            .DataPropertyName = columnName,
            .HeaderText = columnName
          }
          tblDetails.Columns.Add(column)
        Next
        i += 1
      Else
        tblDetails.Rows.Add(row.ToArray)
      End If
    Next
    tblDetails.ColumnHeadersHeight = 18
    tblDetails.RowHeadersVisible = True
    tblDetails.ScrollBars = ScrollBars.Both
  End Sub

  Private Sub InitSummary(txt As String)
    TxtSummary.Text = Txt
  End Sub

  Private Sub loadTypes(category As String, Optional type As String = "")
    Dim types As String = My.Settings.Properties("IMAGE_TYPE_" & category).DefaultValue
    cmbType.Items.Clear()
    For Each str As String In types.Split(",")
      cmbType.Items.Add(str)
    Next
    cmbType.Items.Add("Other")
    cmbType.Text = type
  End Sub

  Private Sub OK_Button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    SaveSettings()
    DialogResult = System.Windows.Forms.DialogResult.OK
    Close()
  End Sub

  Private Sub SaveSettings()
    Dim category As String = cmbCategory.Text
    Dim type As String = cmbType.Text
    Dim categories As String = My.Settings.IMAGE_CATEGORIES
    Dim types As String = ""
    Try
      types = My.Settings.Properties("IMAGE_TYPE_" & category).DefaultValue
    Catch ex As Exception
      types = ""
    End Try
    If Not categories.Contains(category) And Not category.Equals("") Then
      My.Settings.Properties("IMAGE_CATEGORIES").DefaultValue = categories & "," & category
      My.Settings.Save()
    End If
    If Not types.Contains(type) And Not type.Equals("") Then
      If types.Equals("") Then
        Dim prop As New System.Configuration.SettingsProperty("IMAGE_TYPE_" & category) With {
          .DefaultValue = type
        }
        My.Settings.Properties.Add(prop)
        My.Settings.Save()
      Else
        My.Settings.Properties("IMAGE_TYPE_" & category).DefaultValue = types & "," & type
      End If
    End If
    Logger.log(Logger.LOG_TYPE.INFO, "SaveSettings.End")
  End Sub

#End Region

#Region "Public Methods"

  Public Sub HidePayload()
    ' LblDetails.Visible = False
    'tblDetails.Visible = False
    'Height = 187
  End Sub

  Public Sub InitDialog(msg As APIMessage)
    Dim title As String = msg.GetValue("Title").ToUpper
    Dim category As String = ""
    Dim type As String = ""
    Dim summary As String = msg.GetValue("Title").Replace(",", "").Replace(".", "").Replace("/", "").Replace("\", "").Replace("'", "").Replace("""", "")

    If (title.Contains("CERTIFICATE") Or title.Contains("RECORDS")) And Not title.Contains("NEWSPAPER") Then
      category = "Certificate"
      If title.Contains("BIRTH") And type.Equals("") Then type = "Birth"
      If title.Contains("DEATH") And type.Equals("") Then type = "Death"
      If title.Contains("MARRIAGE") And type.Equals("") Then type = "Marriage"
      If type.Equals("") Then type = "Other"
    End If

    If title.Contains("DOCUMENT") And category.Equals("") Then
      category = "Document"
      If title.Contains("LAND") And type.Equals("") Then type = "Land"
      If title.Contains("WILL") And type.Equals("") Then type = "Will"
      If title.Contains("PROBATE") And type.Equals("") Then type = "Will"
      If type.Equals("") Then type = "Other"
    End If

    If title.Contains("NEWSPAPER") And category.Equals("") Then
      category = "Newspaper"
      If title.Contains("OBITUARY") And type.Equals("") Then type = "Obituary"
      If title.Contains("MARRIAGE") And type.Equals("") Then type = "Marriage"
      If type.Equals("") Then type = "Other"
    End If

    If category.Equals("") Then
      category = "Photo"
      If title.Contains("HEADSTONE") And type.Equals("") Then type = "Headstone"
      If title.Contains("PROFILE") And type.Equals("") Then type = "Profile"
      If title.Contains("PORTRAIT") And type.Equals("") Then type = "Portrait"
      If type.Equals("") Then type = "Other"
    End If

    InitCategories(category)
    loadTypes(category, type)
    InitSummary(summary)
    InitDetails(msg.Payload)

  End Sub

#End Region

End Class