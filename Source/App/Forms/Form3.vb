Public Class Form3

  Private aa As AAFile
  Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    aa = New AAFile("D:\Geneology\Ancestors\42135909469\Census\census-1900-6.aa")
    For Each columnName As String In aa.getHeaders
      Dim column As New DataGridViewTextBoxColumn()
      column.DataPropertyName = columnName
      column.HeaderText = columnName
      sht.Columns.Add(column)
    Next
    For Each row() As String In aa.getValues
      sht.Rows.Add(row)
    Next
  End Sub
End Class