Imports System.IO

Public Class frmVBFixer

#Region "Private Methods"

  Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    For Each d As String In Directory.GetDirectories("D:\Geneology\Apps\AncestryAssistant\Source\", "*", SearchOption.AllDirectories)
      Debug.Print(d)
      For Each f As String In Directory.GetFiles(d, "NotebookPanelItem.vb")
        Debug.Print("{0}{1}", vbTab, f)
        Dim l() As String = File.ReadAllLines(f)
        Dim status As Integer = 0
        Dim pStart As Integer = 0
        Dim pCnt As Integer = 0
        Dim pFor As String = "BOGUS"
        For li As Integer = 0 To l.Length - 1
          If l(li).Contains("Public Sub New") And status = 0 Then
            status = 1
            Debug.Print("Sub New: {0}", li)
          End If
          If l(li).Contains("End Sub") And status = 1 Then
            status = 2
            Debug.Print("End Sub: {0}", li)
          End If
          If status = 1 Then
            Dim chk As String = li
            If l(li).Contains(".") Then
              Dim cl() As String = l(li).Split("."c)
              chk = cl(0).Trim
              If chk.Equals("Me") Then chk += "." + cl(1).Trim
              If chk.Contains(" ") Then
                chk = li
              End If
            End If
            If chk.Equals(pFor) Then
              pCnt += 1
            Else
              If pCnt > 0 Then
                Debug.Print("Convert: {0} {1}-{2}", pFor, pStart, li - 1)
                Debug.Print("FROM:")
                For x As Integer = pStart To li - 1
                  Debug.Print(l(x))
                Next
                Debug.Print("TO:")
                Debug.Print("with {0}", pFor)
                For x As Integer = pStart To li - 1
                  Debug.Print("{0}{1}", vbTab, l(x).Replace(pFor, ""))
                Next
                Debug.Print("end with")
              End If
              pCnt = 0
              pStart = li
              pFor = chk
            End If
          End If
        Next
      Next
    Next
  End Sub

#End Region

End Class