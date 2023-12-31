﻿Public Class RIComboBox
  Inherits RibbonItem

  Private ctl As ComboBox

  Public Sub New()
    ctl = New ComboBox With {
      .BackColor = BackColor,
      .ForeColor = BackColor,
      .Font = Font,
      .Dock = DockStyle.Fill,
      .AutoSize = False,
      .Padding = New Padding(0),
      .Margin = New Padding(0),
      .DropDownStyle = ComboBoxStyle.DropDownList,
      .FlatStyle = FlatStyle.Popup
    }
    Controls.Add(ctl)
  End Sub

  Private Sub RIComboBox_RegionChanged(sender As Object, e As EventArgs) Handles Me.RegionChanged
    Debug.Print("RegionChanged")
  End Sub

  Protected Overrides Sub OnPaint(e As PaintEventArgs)
    Debug.Print("OnPaint: {0}", e.ClipRectangle.ToString)
    MyBase.OnPaint(e)
  End Sub

  Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
    Debug.Print("OnPaintBackground: {0}", e.ClipRectangle.ToString)
    MyBase.OnPaintBackground(e)
  End Sub

  Public Overrides Function GetAttribute(ItemAttribute As RibbonItemAttribute) As Object
    Throw New NotImplementedException()
  End Function

  Public Overrides Sub SetAttribute(ItemAttribute As RibbonItemAttribute, attributeValue As Object)
    Select Case ItemAttribute
      Case RibbonItemAttribute.csvitems
        ctl.Items.AddRange(CStr(attributeValue).Split(","c))
      Case RibbonItemAttribute.text
        ctl.Text = CStr(attributeValue)
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", ItemAttribute.ToString, attributeValue)
    End Select
  End Sub

End Class