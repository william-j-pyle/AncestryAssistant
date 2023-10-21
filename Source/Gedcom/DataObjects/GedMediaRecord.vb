'TODO: Not Finished
Public Class GedMediaRecord

  Public Property Key As GedReference
  Public Property CreateDate As GedDate
  Public Property FileName As String
  Public Property FormatType As String
  Public Property Title As String
  Public Property Place As GedPlaceRecord
  Public Property RIN As String
  Public Property Ex_CLonOID As String
  Public Property Ex_CLonPID As String
  Public Property Ex_CLonTID As String
  Public Property Ex_CLonDate As GedDate
  Public Property Ex_CreateDate As GedDate
  Public Property Ex_Description As String
  Public Property Ex_Meta As String
  Public Property Ex_MserLKID As String
  Public Property Ex_URL As String
  Public Property Ex_FormatHeight As String
  Public Property Ex_FormatWidth As String
  Public Property Ex_FormatSize As String
  Public Property Ex_FormatMType As String
  Public Property Ex_FormatSType As String

  Public Sub addObject(data As GedComData)
    Dim processedRoot As Boolean = False
    While data.HasNext
      If data.Key.Contains("OBJE") Then
        Select Case data.Key
          Case "OBJE"
            If processedRoot Then
              Exit Sub
            End If
            Key = data.RefKey
            processedRoot = True
            data.NextRow()
          Case "OBJE._CLON"
            data.NextRow()
          Case "OBJE._CLON._OID"
            Ex_CLonOID = data.Data
            data.NextRow()
          Case "OBJE._CLON._PID"
            Ex_CLonPID = data.Data
            data.NextRow()
          Case "OBJE._CLON._TID"
            Ex_CLonTID = data.Data
            data.NextRow()
          Case "OBJE._CLON._DATE"
            Ex_CLonDate = New GedDate(data.Data)
            data.NextRow()
          Case "OBJE._CREA"
            Ex_CreateDate = New GedDate(data.Data)
            data.NextRow()
          Case "OBJE._DSCR"
            Ex_Description = data.MultiLineData()
            data.NextRow()
          Case "OBJE._META"
            Ex_Meta = data.MultiLineData()
            data.NextRow()
          Case "OBJE._MSER"
            data.NextRow()
          Case "OBJE._MSER._PARM"
            data.NextRow()
          Case "OBJE._MSER._LKID"
            Ex_MserLKID = data.Data
            data.NextRow()
          Case "OBJE._ATL"
            data.NextRow()
          Case "OBJE._USER"
            data.NextRow()
          Case "OBJE._USER._ENCR"
            data.NextRow()
          Case "OBJE._CLON._USER"
            data.NextRow()
          Case "OBJE._CLON._USER._ENCR"
            data.NextRow()
          Case "OBJE._ORIG"
            data.NextRow()
          Case "OBJE._ORIG._URL"
            data.NextRow()
          Case "OBJE.DATE"
            CreateDate = New GedDate(data.Data)
            data.NextRow()
          Case "OBJE.FILE"
            FileName = data.Data
            data.NextRow()
          Case "OBJE.FILE.FORM"
            FormatType = data.Data
            data.NextRow()
          Case "OBJE.FILE.FORM._HGHT"
            Ex_FormatHeight = data.Data
            data.NextRow()
          Case "OBJE.FILE.FORM._MTYPE"
            Ex_FormatMType = data.Data
            data.NextRow()
          Case "OBJE.FILE.FORM._SIZE"
            Ex_FormatSize = data.Data
            data.NextRow()
          Case "OBJE.FILE.FORM._STYPE"
            Ex_FormatSType = data.Data
            data.NextRow()
          Case "OBJE.FILE.FORM._WDTH"
            Ex_FormatWidth = data.Data
            data.NextRow()
          Case "OBJE.FILE.FORM.TYPE"
            FormatType = data.Data
            data.NextRow()
          Case "OBJE.FILE.TITL"
            Title = data.MultiLineData()
            data.NextRow()
          Case "OBJE.PLAC"
            Place = New GedPlaceRecord(data.Data)
            data.NextRow()
          Case "OBJE.RIN"
            RIN = data.Data
            data.NextRow()
          Case Else
            Debug.Print("GedMediaRecord: Unhandled Key [{0}]", data.Key)
            data.NextRow()
        End Select
      Else
        Exit Sub
      End If
    End While
  End Sub
End Class

