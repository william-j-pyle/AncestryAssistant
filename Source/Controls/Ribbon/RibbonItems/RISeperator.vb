﻿Public Class RISeperator
  Inherits RibbonItem

  Public Sub New()
    SetStyle(ControlStyles.UserPaint Or ControlStyles.ContainerControl Or ControlStyles.FixedHeight Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.ResizeRedraw Or ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
  End Sub

  Private Sub RenderControl(sender As Object, e As PaintEventArgs) Handles Me.Paint
    Dim jPen As New Pen(Color.FromArgb(100, RibbonForeColor), 1)
    e.Graphics.DrawLine(jPen, CInt(Width / 2), 4, CInt(Width / 2), Height - 4)
  End Sub

  Public Overrides Function GetAttribute(ItemAttribute As RibbonItemAttribute) As Object
    Throw New NotImplementedException()
  End Function

  Public Overrides Sub SetAttribute(ItemAttribute As RibbonItemAttribute, attributeValue As Object)
    Select Case ItemAttribute
      Case Else
        Debug.Print("Unhandled Attribute: {0}={1}", ItemAttribute.ToString, attributeValue)
    End Select
  End Sub

End Class