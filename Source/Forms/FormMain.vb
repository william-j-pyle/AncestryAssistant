﻿Imports System.ComponentModel
Imports System.IO
Imports AncestryAssistant.AncestorCollection

#Const RESET_SAVED_SETTINGS = False

Public Class AssistantAppForm

  Private WithEvents Ancestors As AncestorCollection

  Private Const ANCESTOR_CENSUS As String = "Download Census Data"

  Private Const ANCESTOR_NEW As String = "Add Ancestor To Assistant"

  Private Const ANCESTOR_UPDATED As String = "Apply Ancestor Changes To Assistant"

  Private Const FINDAGRAVE_IMAGE As String = "Download FindAGrave Image"

  'Public Event ActiveAncestorChanged()

  'Public Event AncestorsUpdated()

  Public Event InitUIExtensions()

  Public Sub New()
#If RESET_SAVED_SETTINGS Then
    My.Settings.Reset()
    My.Settings.Save()
    End
#End If

    InitializeComponent()

  End Sub

  Private Sub AncestryBrowserBusyChanged(busy As Boolean)

  End Sub

  Private Sub AncestryDataMessage(msg As APIMessage)
    Dim Ancestor As AncestorCollection.Ancestor = Ancestors.ActiveAncestor
    Logger.log(Logger.LOG_TYPE.ERR, msg.ToString)
    Select Case msg.MessageType
      Case APIMessage.MT_SAVEAS
        Dim rslt As DialogResult
        Dim dlg As New SaveImageDialog
        dlg.InitDialog(msg)
        dlg.HidePayload()
        rslt = dlg.ShowDialog()
        If rslt = DialogResult.OK Then
          Dim i_type As String = dlg.ImageType.ToUpper
          Dim i_category As String = dlg.ImageCategory.ToUpper
          Dim i_summary As String = dlg.Summary
          If i_type.Equals("") Then i_type = "PHOTO"
          If i_category.Equals("") Then i_category = "OTHER"
          Dim filename As String = i_type & "-" & i_category & "-" & StrConv(i_summary, VbStrConv.ProperCase).Replace(" ", "")
          If filename.Length > 60 Then filename = filename.Substring(0, 60)
          Dim ImgFilename As String = uniqueFilename(Ancestor.FullPath("Gallery\" + filename), {"jpg.txt", "jpg"})
          File.WriteAllText(ImgFilename + ".jpg.txt", dlg.Summary)
          'Ancestry.saveImageAs(imgFilename + ".jpg")
          System.IO.File.Move(msg.GetValue("fileName"), ImgFilename + ".jpg")
        End If
      Case APIMessage.MT_PERSON
        If msg.MessageKey.Length > 3 Then
          If Not Ancestors.ContainsKey(msg.MessageKey) Then
            'With BtnActions
            '  .Tag = msg
            '  .Text = ANCESTOR_NEW
            '  '.Image = My.Resources.ANCESTOR_ADD_WHITE
            '  .Enabled = True
            '  .Visible = True
            'End With
          Else
            'If assistant Ancestor is different, then change Ancestors
            If Not Ancestors.ActiveAncestorID.Equals(msg.MessageKey) Then
              Ancestors.ActiveAncestorID = msg.MessageKey
            End If
            If Not Ancestors.Item(msg.MessageKey).AncestorMatchesMessage(msg) Then
              'With BtnActions
              '  .Tag = msg
              '  .Text = ANCESTOR_UPDATED
              '  '.Image = My.Resources.ANCESTOR_ADD_WHITE
              '  .Enabled = True
              '  .Visible = True
              'End With
            End If
          End If
        End If
      Case APIMessage.MT_PAGE
        If msg.PageKey.Equals("FINDAGRAVE_VIEWER_IMAGE") And (msg.GetValue("PAGEKEY").EndsWith("jpg") Or msg.GetValue("PAGEKEY").EndsWith("jepg")) Then
          'With BtnActions
          '  .Tag = msg
          '  .Text = FINDAGRAVE_IMAGE
          '  '.Image = My.Resources.ANCESTOR_ADD_WHITE
          '  .Enabled = True
          '  .Visible = True
          'End With
        End If
      Case APIMessage.MT_FINDAGRAVE
        If Ancestors.HasActiveAncestor Then
          'If Ancestor.Surname.ToLower.Equals(msg.GetValue("lastName").ToLower) Then
          If Ancestor.GedDeathDate.Year = CInt(msg.GetValue("deathYear")) Then
            If Ancestor.Fact("cemeteryName").Equals("") Then
              Ancestor.Fact("cemeteryName") = msg.GetValue("cemeteryName")
            End If
            If Ancestor.Fact("cemeteryPlace").Equals("") Then
              Ancestor.Fact("cemeteryPlace") = msg.GetValue("locationName")
            End If
            If Ancestor.Fact("FindAGraveID").Equals("") Then
              Ancestor.Fact("FindAGraveID") = msg.GetValue("memorialId")
            End If
          End If
          'End If
        End If
      Case APIMessage.MT_TABLEDATA
        If msg.MessageKey.Length > 3 Then
          If Ancestors.ContainsKey(msg.MessageKey) Then
            Dim title As String = msg.GetValue("Title")
            If title.Contains("Census") Then
              'With BtnActions
              '  .Tag = msg
              '  .Text = ANCESTOR_CENSUS
              '  '.Image = My.Resources.ANCESTOR_ADD_WHITE
              '  .Enabled = True
              '  .Visible = True
              'End With
            Else
              If msg.PageKey = "ANCESTRY_VIEWER_IMAGE" Then
                'With BtnActions
                '  .Tag = msg
                '  .Text = ANCESTOR_IMAGE
                '  '.Image = My.Resources.ANCESTOR_ADD_WHITE
                '  .Enabled = True
                '  .Visible = True
                'End With
              End If
            End If
          End If
        End If
      Case Else
        'btnActions.Visible = False
    End Select
  End Sub

  Private Sub AncestryNavigateRequest(SelectedAncestorID As String)
    DockManager.ItemEventRequest(DPIWebBrowser.Base_Key, DockPanelItemEventType.NavRequested, UriTrackingGroupEnum.ANCESTRY_FACTS_PERSON)
  End Sub

  Private Sub AncestryURITrackingGroupChanged(NewGroup As UriTrackingGroupEnum, OldGroup As UriTrackingGroupEnum)
    ' If BtnActions.Visible Then
    'If NewGroup <> OldGroup Then
    'btnActions.Visible = False
    'End If
    'End If
  End Sub

  Private Sub Application_CloseButton_Click(sender As Object, e As EventArgs)
    Close()
  End Sub

  Private Sub Application_Form_Closing(sender As Object, e As CancelEventArgs)
    If WindowState <> FormWindowState.Normal Then
      WindowState = FormWindowState.Normal
    End If
    SettingsSave()
  End Sub

  Private Sub Application_MaxButton_Click(sender As Object, e As EventArgs)
    If WindowState = FormWindowState.Normal Then
      WindowState = FormWindowState.Maximized
    ElseIf WindowState = FormWindowState.Maximized Then
      WindowState = FormWindowState.Normal
    End If
  End Sub

  Private Sub Application_MinButton_Click(sender As Object, e As EventArgs)
    WindowState = FormWindowState.Minimized
  End Sub

  Private Sub BtnActions_Click(sender As Object, e As EventArgs)
    'btnActions.Visible = False
    'If BtnActions.Tag Is Nothing Then Exit Sub
    'Dim msg As APIMessage = BtnActions.Tag
    'Select Case BtnActions.Text
    '  Case ANCESTOR_NEW
    '    If Not Ancestors.ContainsKey(msg.MessageKey) Then
    '      If msg.MessageType = APIMessage.MT_PERSON Then
    '        Dim Ancestor As AncestorCollection.Ancestor = Ancestors.newAncestor(msg.MessageKey)
    '        For Each fact As String In Ancestor.AncestorFactList()
    '          Ancestor.Fact(fact) = msg.GetValue(fact)
    '        Next
    '        AncestorId = msg.MessageKey
    '        RaiseEvent AncestorsUpdated()
    '      End If
    '    End If
    '  Case ANCESTOR_UPDATED
    '    Dim Ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
    '    For Each fact As String In Ancestor.AncestorFactDifferences(msg)
    '      Ancestor.Fact(fact) = msg.GetValue(fact)
    '    Next
    '    AncestorId = msg.MessageKey
    '    RaiseEvent AncestorsUpdated()
    '  Case ANCESTOR_CENSUS
    '    Dim Ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
    '    Dim ImgFilename As String = Ancestor.Census.addCensusData(msg)
    '    AncestorId = msg.MessageKey
    '    Ancestry.saveImageAs(imgFilename + ".jpg")
    '    RaiseEvent AncestorsUpdated()
    '  Case ANCESTOR_IMAGE
    '    Dim Ancestor As AncestorCollection.Ancestor = Ancestors.Item(msg.MessageKey)
    '    Dim rslt As DialogResult
    '    Dim dlg As New SaveImageDetails
    '    dlg.InitDialog(msg)
    '    rslt = dlg.ShowDialog()
    '    If rslt = DialogResult.OK Then
    '      Dim i_type As String = dlg.ImageType.ToUpper
    '      Dim i_category As String = dlg.ImageCategory.ToUpper
    '      Dim i_summary As String = dlg.Summary
    '      Dim i_details As List(Of List(Of String)) = dlg.TableData
    '      If i_type.Equals("") Then i_type = "PHOTO"
    '      If i_category.Equals("") Then i_category = "OTHER"
    '      Dim filename As String = i_type & "-" & i_category & "-" & StrConv(i_summary, VbStrConv.ProperCase).Replace(" ", "")
    '      If filename.Length > 60 Then filename = filename.Substring(0, 60)
    '      Dim ImgFilename As String = uniqueFilename(ancestor.FullPath("Gallery\" + filename), {"aa", "jpg.txt", "jpg"})
    '      File.WriteAllText(imgFilename + ".jpg.txt", dlg.Summary)
    '      Dim aa As AAFile = New AAFile(imgFilename + ".aa", AAFileTypeEnum.LISTARRAY)
    '      aa.setTableData(i_details)
    '      aa.Save()
    '      Ancestry.saveImageAs(imgFilename + ".jpg")
    '    End If
    '  Case FINDAGRAVE_IMAGE
    '    Dim Ancestor As AncestorCollection.Ancestor = Ancestors.Item(AncestorId)
    '    Dim rslt As DialogResult
    '    Dim dlg As New SaveImageDetails
    '    dlg.InitDialog(msg)
    '    dlg.HidePayload()
    '    rslt = dlg.ShowDialog()
    '    If rslt = DialogResult.OK Then
    '      Dim i_type As String = dlg.ImageType.ToUpper
    '      Dim i_category As String = dlg.ImageCategory.ToUpper
    '      Dim i_summary As String = dlg.Summary
    '      If i_type.Equals("") Then i_type = "PHOTO"
    '      If i_category.Equals("") Then i_category = "OTHER"
    '      Dim filename As String = i_type & "-" & i_category & "-" & StrConv(i_summary, VbStrConv.ProperCase).Replace(" ", "")
    '      If filename.Length > 60 Then filename = filename.Substring(0, 60)
    '      Dim ImgFilename As String = uniqueFilename(ancestor.FullPath("Gallery\" + filename), {"jpg.txt", "jpg"})
    '      File.WriteAllText(imgFilename + ".jpg.txt", dlg.Summary)
    '      Ancestry.saveImageAs(imgFilename + ".jpg")
    '    End If
    '  Case Else

    'End Select

  End Sub

  Private Sub InitUI(sender As Object, e As EventArgs) Handles Me.Load
    ' Init the Ancestors data repository
    Ancestors = New AncestorCollection(My.Settings.AncestorsPath)

    'Add Form Event Handlers
    AddHandler AppMinButton.Click, AddressOf Application_MinButton_Click
    AddHandler AppMaxButton.Click, AddressOf Application_MaxButton_Click
    AddHandler AppTitle.DoubleClick, AddressOf Application_MaxButton_Click
    AddHandler Closing, AddressOf Application_Form_Closing
    AddHandler AppCloseButton.Click, AddressOf Application_CloseButton_Click

    RaiseEvent InitUIExtensions()

    ' Restore Size
    Size = My.Settings.APP_CLIENTSIZE

    ' Theme Data - Move all of this to the base assignments
    AppIcon.BackColor = My.Theme.AppBackColor
    AppControlBox.BackColor = My.Theme.AppBackColor
    AppTitle.BackColor = My.Theme.AppBackColor
    AppTitle.ForeColor = My.Theme.AppFontColor
    AppCloseButton.FlatAppearance.MouseDownBackColor = My.Theme.AppAccentColor
    AppCloseButton.FlatAppearance.MouseOverBackColor = My.Theme.AppAccent2Color
    AppCloseButton.ForeColor = My.Theme.AppFontColor
    AppMaxButton.FlatAppearance.MouseDownBackColor = My.Theme.AppAccentColor
    AppMaxButton.FlatAppearance.MouseOverBackColor = My.Theme.AppAccent2Color
    AppMaxButton.ForeColor = My.Theme.AppFontColor
    AppMinButton.FlatAppearance.MouseDownBackColor = My.Theme.AppAccentColor
    AppMinButton.FlatAppearance.MouseOverBackColor = My.Theme.AppAccent2Color
    AppMinButton.ForeColor = My.Theme.AppFontColor
    AppTitle.BackColor = My.Theme.AppBackColor
    AppTitle.ForeColor = My.Theme.AppFontColor
    AppTitleBar.BackColor = My.Theme.AppBackColor
    BackColor = My.Theme.AppBackColor
    ForeColor = My.Theme.AppFontColor
    FormBar.BackColor = My.Theme.AppBackColor
    AppCloseButton.Font = My.Theme.AppIconsFont
    AppMaxButton.Font = My.Theme.AppIconsFont
    AppMinButton.Font = My.Theme.AppIconsFont
    AppTitle.Font = My.Theme.AppTitleFont
    FormBar.BackColor = My.Theme.AppBackColor
    FormBar.ForeColor = My.Theme.AppFontColor

  End Sub

  Private Sub SettingsSave()
    DockManager.SettingsSave()
    My.Settings.APP_CLIENTSIZE = Size
    My.Settings.Save()
  End Sub

End Class