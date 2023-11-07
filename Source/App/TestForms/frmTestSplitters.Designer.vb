<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTestSplitters
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlMiddle = New System.Windows.Forms.Panel()
        Me.pnlMiddleTop = New System.Windows.Forms.Panel()
        Me.pnlMiddleLeft = New System.Windows.Forms.Panel()
        Me.splitMiddleLeftRight = New System.Windows.Forms.Splitter()
        Me.pnlMiddleRight = New System.Windows.Forms.Panel()
        Me.splitMiddleBottom = New System.Windows.Forms.Splitter()
        Me.pnlMiddleBottom = New System.Windows.Forms.Panel()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.splitLeft = New System.Windows.Forms.Splitter()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.pnlLeftBottom = New System.Windows.Forms.Panel()
        Me.splitLeftTopBottom = New System.Windows.Forms.Splitter()
        Me.pnlLeftTop = New System.Windows.Forms.Panel()
        Me.splitRight = New System.Windows.Forms.Splitter()
        Me.pnlRight = New System.Windows.Forms.Panel()
        Me.pnlRightBottom = New System.Windows.Forms.Panel()
        Me.splitRightTopBottom = New System.Windows.Forms.Splitter()
        Me.pnlRightTop = New System.Windows.Forms.Panel()
        Me.pnlMain.SuspendLayout()
        Me.pnlMiddle.SuspendLayout()
        Me.pnlMiddleTop.SuspendLayout()
        Me.pnlMiddleBottom.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.pnlRight.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.pnlMiddle)
        Me.pnlMain.Controls.Add(Me.splitLeft)
        Me.pnlMain.Controls.Add(Me.pnlLeft)
        Me.pnlMain.Controls.Add(Me.splitRight)
        Me.pnlMain.Controls.Add(Me.pnlRight)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(800, 450)
        Me.pnlMain.TabIndex = 0
        '
        'pnlMiddle
        '
        Me.pnlMiddle.Controls.Add(Me.pnlMiddleTop)
        Me.pnlMiddle.Controls.Add(Me.splitMiddleBottom)
        Me.pnlMiddle.Controls.Add(Me.pnlMiddleBottom)
        Me.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMiddle.Location = New System.Drawing.Point(209, 0)
        Me.pnlMiddle.Name = "pnlMiddle"
        Me.pnlMiddle.Size = New System.Drawing.Size(388, 450)
        Me.pnlMiddle.TabIndex = 13
        '
        'pnlMiddleTop
        '
        Me.pnlMiddleTop.Controls.Add(Me.pnlMiddleLeft)
        Me.pnlMiddleTop.Controls.Add(Me.splitMiddleLeftRight)
        Me.pnlMiddleTop.Controls.Add(Me.pnlMiddleRight)
        Me.pnlMiddleTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMiddleTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlMiddleTop.Name = "pnlMiddleTop"
        Me.pnlMiddleTop.Size = New System.Drawing.Size(388, 376)
        Me.pnlMiddleTop.TabIndex = 0
        '
        'pnlMiddleLeft
        '
        Me.pnlMiddleLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pnlMiddleLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMiddleLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlMiddleLeft.Name = "pnlMiddleLeft"
        Me.pnlMiddleLeft.Size = New System.Drawing.Size(270, 376)
        Me.pnlMiddleLeft.TabIndex = 4
        '
        'splitMiddleLeftRight
        '
        Me.splitMiddleLeftRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.splitMiddleLeftRight.Location = New System.Drawing.Point(270, 0)
        Me.splitMiddleLeftRight.Name = "splitMiddleLeftRight"
        Me.splitMiddleLeftRight.Size = New System.Drawing.Size(3, 376)
        Me.splitMiddleLeftRight.TabIndex = 6
        Me.splitMiddleLeftRight.TabStop = False
        '
        'pnlMiddleRight
        '
        Me.pnlMiddleRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pnlMiddleRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlMiddleRight.Location = New System.Drawing.Point(273, 0)
        Me.pnlMiddleRight.Name = "pnlMiddleRight"
        Me.pnlMiddleRight.Size = New System.Drawing.Size(115, 376)
        Me.pnlMiddleRight.TabIndex = 5
        '
        'splitMiddleBottom
        '
        Me.splitMiddleBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.splitMiddleBottom.Location = New System.Drawing.Point(0, 376)
        Me.splitMiddleBottom.Name = "splitMiddleBottom"
        Me.splitMiddleBottom.Size = New System.Drawing.Size(388, 3)
        Me.splitMiddleBottom.TabIndex = 15
        Me.splitMiddleBottom.TabStop = False
        '
        'pnlMiddleBottom
        '
        Me.pnlMiddleBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlMiddleBottom.Controls.Add(Me.Button9)
        Me.pnlMiddleBottom.Controls.Add(Me.Button10)
        Me.pnlMiddleBottom.Controls.Add(Me.Button7)
        Me.pnlMiddleBottom.Controls.Add(Me.Button8)
        Me.pnlMiddleBottom.Controls.Add(Me.Button5)
        Me.pnlMiddleBottom.Controls.Add(Me.Button6)
        Me.pnlMiddleBottom.Controls.Add(Me.Button4)
        Me.pnlMiddleBottom.Controls.Add(Me.Button3)
        Me.pnlMiddleBottom.Controls.Add(Me.Button2)
        Me.pnlMiddleBottom.Controls.Add(Me.Button1)
        Me.pnlMiddleBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlMiddleBottom.Location = New System.Drawing.Point(0, 379)
        Me.pnlMiddleBottom.Name = "pnlMiddleBottom"
        Me.pnlMiddleBottom.Size = New System.Drawing.Size(388, 71)
        Me.pnlMiddleBottom.TabIndex = 12
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button9.Location = New System.Drawing.Point(303, 36)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(47, 23)
        Me.Button9.TabIndex = 9
        Me.Button9.Text = "<<L"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button10.Location = New System.Drawing.Point(303, 6)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(47, 23)
        Me.Button10.TabIndex = 8
        Me.Button10.Text = "<<L"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button7.Location = New System.Drawing.Point(42, 37)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(47, 23)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = ">>R"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button8.Location = New System.Drawing.Point(42, 7)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(47, 23)
        Me.Button8.TabIndex = 6
        Me.Button8.Text = ">>R"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button5.Location = New System.Drawing.Point(263, 37)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(34, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "B-R"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button6.Location = New System.Drawing.Point(263, 7)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(34, 23)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "T-R"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button4.Location = New System.Drawing.Point(199, 7)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(58, 38)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "M-R"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button3.Location = New System.Drawing.Point(135, 7)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(58, 38)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "L-M"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(95, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(34, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "L-B"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(95, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(34, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "L-T"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'splitLeft
        '
        Me.splitLeft.Location = New System.Drawing.Point(206, 0)
        Me.splitLeft.Name = "splitLeft"
        Me.splitLeft.Size = New System.Drawing.Size(3, 450)
        Me.splitLeft.TabIndex = 10
        Me.splitLeft.TabStop = False
        '
        'pnlLeft
        '
        Me.pnlLeft.Controls.Add(Me.pnlLeftBottom)
        Me.pnlLeft.Controls.Add(Me.splitLeftTopBottom)
        Me.pnlLeft.Controls.Add(Me.pnlLeftTop)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(206, 450)
        Me.pnlLeft.TabIndex = 9
        '
        'pnlLeftBottom
        '
        Me.pnlLeftBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pnlLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLeftBottom.Location = New System.Drawing.Point(0, 152)
        Me.pnlLeftBottom.Name = "pnlLeftBottom"
        Me.pnlLeftBottom.Size = New System.Drawing.Size(206, 298)
        Me.pnlLeftBottom.TabIndex = 2
        '
        'splitLeftTopBottom
        '
        Me.splitLeftTopBottom.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitLeftTopBottom.Location = New System.Drawing.Point(0, 149)
        Me.splitLeftTopBottom.Name = "splitLeftTopBottom"
        Me.splitLeftTopBottom.Size = New System.Drawing.Size(206, 3)
        Me.splitLeftTopBottom.TabIndex = 3
        Me.splitLeftTopBottom.TabStop = False
        '
        'pnlLeftTop
        '
        Me.pnlLeftTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.pnlLeftTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLeftTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeftTop.Name = "pnlLeftTop"
        Me.pnlLeftTop.Size = New System.Drawing.Size(206, 149)
        Me.pnlLeftTop.TabIndex = 1
        '
        'splitRight
        '
        Me.splitRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.splitRight.Location = New System.Drawing.Point(597, 0)
        Me.splitRight.Name = "splitRight"
        Me.splitRight.Size = New System.Drawing.Size(3, 450)
        Me.splitRight.TabIndex = 14
        Me.splitRight.TabStop = False
        '
        'pnlRight
        '
        Me.pnlRight.Controls.Add(Me.pnlRightBottom)
        Me.pnlRight.Controls.Add(Me.splitRightTopBottom)
        Me.pnlRight.Controls.Add(Me.pnlRightTop)
        Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRight.Location = New System.Drawing.Point(600, 0)
        Me.pnlRight.Name = "pnlRight"
        Me.pnlRight.Size = New System.Drawing.Size(200, 450)
        Me.pnlRight.TabIndex = 11
        '
        'pnlRightBottom
        '
        Me.pnlRightBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlRightBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRightBottom.Location = New System.Drawing.Point(0, 155)
        Me.pnlRightBottom.Name = "pnlRightBottom"
        Me.pnlRightBottom.Size = New System.Drawing.Size(200, 295)
        Me.pnlRightBottom.TabIndex = 1
        '
        'splitRightTopBottom
        '
        Me.splitRightTopBottom.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitRightTopBottom.Location = New System.Drawing.Point(0, 152)
        Me.splitRightTopBottom.Name = "splitRightTopBottom"
        Me.splitRightTopBottom.Size = New System.Drawing.Size(200, 3)
        Me.splitRightTopBottom.TabIndex = 2
        Me.splitRightTopBottom.TabStop = False
        '
        'pnlRightTop
        '
        Me.pnlRightTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlRightTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRightTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlRightTop.Name = "pnlRightTop"
        Me.pnlRightTop.Size = New System.Drawing.Size(200, 152)
        Me.pnlRightTop.TabIndex = 0
        '
        'frmTestSplitters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "frmTestSplitters"
        Me.Text = "frmTestSplitters"
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMiddle.ResumeLayout(False)
        Me.pnlMiddleTop.ResumeLayout(False)
        Me.pnlMiddleBottom.ResumeLayout(False)
        Me.pnlLeft.ResumeLayout(False)
        Me.pnlRight.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlMain As Panel
    Friend WithEvents splitLeft As Splitter
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents splitLeftTopBottom As Splitter
    Friend WithEvents pnlLeftBottom As Panel
    Friend WithEvents pnlLeftTop As Panel
    Friend WithEvents pnlMiddle As Panel
    Friend WithEvents pnlMiddleBottom As Panel
    Friend WithEvents splitMiddleBottom As Splitter
    Friend WithEvents pnlMiddleLeft As Panel
    Friend WithEvents splitMiddleLeftRight As Splitter
    Friend WithEvents pnlMiddleRight As Panel
    Friend WithEvents splitRight As Splitter
    Friend WithEvents pnlRight As Panel
    Friend WithEvents splitRightTopBottom As Splitter
    Friend WithEvents pnlRightBottom As Panel
    Friend WithEvents pnlRightTop As Panel
    Friend WithEvents pnlMiddleTop As Panel
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
End Class
