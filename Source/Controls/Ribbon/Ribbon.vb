﻿Imports System.ComponentModel

Public Class Ribbon
  Inherits TabControl

  Private RegistryBar As New Dictionary(Of String, RibbonBar)
  Private RegistryGroup As New Dictionary(Of String, RibbonGroup)
  Private RegistryItem As New Dictionary(Of String, RibbonItem)
  Private RegistryKey As New Dictionary(Of String, String)
  Private RegistryTab As New Dictionary(Of String, TabPage)
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
  Public ReadOnly Property Key(keyName As String) As String
    Get
      If RegistryKey.ContainsKey(keyName) Then
        Return RegistryKey(keyName)
      End If
      Return ""
    End Get
  End Property

  Public Event RibbonAction(action As RibbonEventType, value As Object, barId As Integer, groupId As Integer, itemId As Integer)

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
    Dim TabOrigBounds As Rectangle
    Dim TabBounds As Rectangle
    Dim textColor As Color
    Dim TabColor As Color
    Dim stringFormat As New StringFormat With {
      .Alignment = StringAlignment.Center,
      .LineAlignment = StringAlignment.Center
    }

    'Add the Tabs
    For i As Integer = 0 To TabPages.Count - 1
      TabOrigBounds = GetTabRect(i)

      'Erase current Tab
      Using brush As New SolidBrush(AppBackColor)
        g.FillRectangle(brush, TabOrigBounds)
      End Using

      textColor = AppForeColor
      TabColor = AppBackColor
      TabBounds = New Rectangle(TabOrigBounds.X, TabOrigBounds.Y + 1, TabOrigBounds.Width, TabOrigBounds.Height - 3)
      ' Fill the new Tab
      Using brush As New SolidBrush(TabColor)
        g.FillRectangle(brush, TabBounds)
      End Using

      ' Draw the Tab text
      Using brush As New SolidBrush(textColor)
        g.DrawString(TabPages(i).Text, Font, brush, TabBounds, stringFormat)
      End Using

      If SelectedIndex = i Then
        g.DrawLine(New Pen(AppHighlightColor, 2), TabBounds.Left + 1, TabBounds.Bottom - 1, TabBounds.Right - 1, TabBounds.Bottom - 1)
      End If

    Next

  End Sub

  Private Sub RibbonGroupAction(sender As RibbonGroup, action As RibbonEventType, value As Object)
    RaiseEvent RibbonAction(action, value, sender.BarId, sender.GroupId, 0)
  End Sub

  Private Sub RibbonItemAction(sender As RibbonItem, action As RibbonEventType, value As Object)
    RaiseEvent RibbonAction(action, value, sender.BarId, sender.GroupId, sender.ItemId)
  End Sub

  Public Shared Function RibbonKey(barId As Integer, Optional groupId As Integer = 0, Optional itemId As Integer = 0) As String
    If itemId > 0 Then Return "B" & barId & ".G" & groupId & ".I" & itemId
    If groupId > 0 Then Return "B" & barId & ".G" & groupId
    Return "B" & barId
  End Function

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

  Public Sub DisableBar(barKey As String)
    SetGroupItemsAttribute(barKey, RibbonItemAttribute.enabled, False)
  End Sub

  Public Sub DisableGroup(groupKey As String)
    SetGroupItemsAttribute(groupKey, RibbonItemAttribute.enabled, False)
  End Sub

  Public Sub EnableBar(barKey As String)
    SetGroupItemsAttribute(barKey, RibbonItemAttribute.enabled, True)
  End Sub

  Public Sub EnableGroup(groupKey As String)
    SetGroupItemsAttribute(groupKey, RibbonItemAttribute.enabled, True)
  End Sub

  Public Function GetBar(barId As Integer) As RibbonBar
    Return GetBar(RibbonKey(barId))
  End Function

  Public Function GetBar(key As String) As RibbonBar
    Return RegistryBar.Item(key)
  End Function

  Public Function GetGroup(barId As Integer, groupId As Integer) As RibbonGroup
    Return GetGroup(RibbonKey(barId, groupId))
  End Function

  Public Function GetGroup(key As String) As RibbonGroup
    Return RegistryGroup.Item(key)
  End Function

  Public Function GetItem(barId As Integer, groupId As Integer, itemId As Integer) As RibbonItem
    Return GetItem(RibbonKey(barId, groupId, itemId))
  End Function

  Public Function GetItem(key As String) As RibbonItem
    Try
      Return RegistryItem.Item(key)
    Catch ex As Exception
      Return Nothing
    End Try
  End Function

  Public Function GetItemAttribute(key As String, attribute As RibbonItemAttribute) As Object
    Try
      Return GetItem(key).GetAttribute(attribute)
    Catch ex As Exception
      Return Nothing
    End Try
  End Function

  Public Sub HideBar(barKey As String)
    If RegistryTab.ContainsKey(barKey) Then
      If TabPages.Contains(RegistryTab.Item(barKey)) Then
        SelectedIndex = 1
        TabPages.Remove(RegistryTab.Item(barKey))
      End If
    End If
  End Sub

  Public Sub LoadConfig(cfg As RibbonConfig)
    For Each Bar As RibbonConfig.Bar In cfg.bars
      Dim rBar As RibbonBar = AddBar(Bar.name, Bar.text, Bar.id)
      RegisterBar(rBar)
      If Not Bar.visible Then
        HideBar(RibbonKey(Bar.id))
      End If
      For Each refGrp As RibbonConfig.Group In Bar.groups
        Dim Grp As RibbonConfig.Group = cfg.GetGroup(refGrp)
        Dim rBarGrp As RibbonGroup = rBar.AddGroup(Grp.name, Grp.text, Bar.id, Grp.id)
        If Not Bar.enabled Then
          Grp.enabled = False
        End If
        'rBarGrp.Enabled = CBool(Grp.GetAttribute("enabled", Grp.enabled))
        rBarGrp.Visible = CBool(Grp.GetAttribute("visible", Grp.visible))
        rBarGrp.ShowPane = CBool(Grp.GetAttribute("showpane", Grp.showpanel))
        RegisterGroup(rBarGrp)
        AddHandler rBarGrp.RibbonGroupAction, AddressOf RibbonGroupAction
        For Each refItem As RibbonConfig.Item In Grp.items
          Dim Item As RibbonConfig.Item = cfg.GetItem(refItem)
          Dim rBarGrpItem As RibbonItem = Nothing
          Select Case Item.ribbonitemtype
            Case RibbonItemType.RIButton
              rBarGrpItem = New RIButton()
            Case RibbonItemType.RIButtonDropDown
              rBarGrpItem = New RIButtonDropDown()
            Case RibbonItemType.RIButtonSplit
              rBarGrpItem = New RIButtonSplit()
            Case RibbonItemType.RIComboBox
              rBarGrpItem = New RIComboBox()
            Case RibbonItemType.RIListView
              rBarGrpItem = New RIListView()
            Case RibbonItemType.RICheckBox
              rBarGrpItem = New RICheckBox()
            Case RibbonItemType.RILabel
              rBarGrpItem = New RILabel()
            Case RibbonItemType.RIImage
              rBarGrpItem = New RIImage()
            Case RibbonItemType.RISeperator
              rBarGrpItem = New RISeperator()
            Case RibbonItemType.RIComboBoxFont
              rBarGrpItem = New RIComboBoxFont()
            Case RibbonItemType.RIComboBoxFontSize
              rBarGrpItem = New RIComboBoxFontSize()
            Case RibbonItemType.RIComboBoxFontColor
              rBarGrpItem = New RIComboBoxFontColor()
            Case RibbonItemType.RIComboBoxColor
              rBarGrpItem = New RIListBoxColor()
          End Select
          If rBarGrpItem IsNot Nothing Then
            With rBarGrpItem
              .Ribbon = Me
              .Name = Item.name
              .BarId = rBar.BarId
              .GroupId = rBarGrp.GroupId
              .ItemId = Item.id
              .Col = Item.col
              .Row = Item.row
              .ColSpan = Item.colspan
              .RowSpan = Item.rowspan
            End With
            For Each attr As RibbonConfig.AttributeValuePair In Item.attributes
              Dim itemAttribute As RibbonItemAttribute = DirectCast([Enum].Parse(GetType(RibbonItemAttribute), attr.Attribute.ToLower), RibbonItemAttribute)
              rBarGrpItem.SetAttribute(itemAttribute, attr.Value)
            Next
            If Not Grp.enabled Then
              rBarGrpItem.SetAttribute(RibbonItemAttribute.enabled, False)
            End If
            'Debug.Print("LoadConfig.AddBar({0}).AddGroup({1}).AddItem({2})", Bar.name, Grp.name, Item.name)
            rBarGrp.AddItem(rBarGrpItem)
            RegisterItem(rBarGrpItem)
            AddHandler rBarGrpItem.RibbonItemAction, AddressOf RibbonItemAction
          End If
        Next
      Next
    Next
  End Sub

  Public Sub RegisterBar(bar As RibbonBar)
    Dim key As String = RibbonKey(bar.BarId)
    Try
      RegistryBar.Add(key, bar)
      RegistryTab.Add(key, TryCast(bar.Parent, TabPage))
      RegistryKey.Add(bar.Name, key)
    Catch ex As Exception

    End Try
  End Sub

  Public Sub RegisterGroup(group As RibbonGroup)
    Dim key As String = RibbonKey(group.BarId, group.GroupId)
    Try
      RegistryGroup.Add(key, group)
      RegistryKey.Add(group.Name, key)
    Catch ex As Exception

    End Try
  End Sub

  Public Sub RegisterItem(item As RibbonItem)
    Dim key As String = RibbonKey(item.BarId, item.GroupId, item.ItemId)
    Try
      RegistryItem.Add(key, item)
      RegistryKey.Add(item.Name, key)
    Catch ex As Exception

    End Try
  End Sub

  Public Sub SetGroupAttribute(groupKey As String, attribute As RibbonItemAttribute, value As Object)
    If RegistryGroup.ContainsKey(groupKey) Then
      RegistryGroup(groupKey).SetAttribute(attribute, value)
    End If
  End Sub

  Public Sub SetGroupItemsAttribute(groupKey As String, attribute As RibbonItemAttribute, value As Object)
    For Each Itemkey As String In RegistryItem.Keys
      If Itemkey.StartsWith(groupKey + ".") Then
        SetItemAttribute(Itemkey, attribute, value)
      End If
    Next
  End Sub

  Public Sub SetItemAttribute(key As String, attribute As RibbonItemAttribute, value As Object)
    If RegistryItem.ContainsKey(key) Then
      GetItem(key).SetAttribute(attribute, value)
    End If
  End Sub

  Public Sub ShowBar(barKey As String)
    If RegistryTab.ContainsKey(barKey) Then
      If Not TabPages.Contains(RegistryTab.Item(barKey)) Then
        TabPages.Add(RegistryTab.Item(barKey))
      End If
      SelectedTab = RegistryTab.Item(barKey)
    End If
  End Sub

End Class