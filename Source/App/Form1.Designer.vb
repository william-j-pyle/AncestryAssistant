<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.lblIcon = New System.Windows.Forms.Label()
        Me.btnDecToHex = New System.Windows.Forms.Button()
        Me.txtHex = New System.Windows.Forms.TextBox()
        Me.btnHexToDec = New System.Windows.Forms.Button()
        Me.txtDec = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDecToImg = New System.Windows.Forms.Button()
        Me.btnHexToImg = New System.Windows.Forms.Button()
        Me.JRibbon1 = New AncestryAssistant.JRibbon()
        Me.JRibbonGroup1 = New AncestryAssistant.JRibbonGroup()
        Me.JButton1 = New AncestryAssistant.JButton()
        Me.JButton3 = New AncestryAssistant.JButton()
        Me.JButton2 = New AncestryAssistant.JButton()
        Me.pnlRibbon = New AncestryAssistant.BordersPanel()
        Me.pnlGroup = New AncestryAssistant.BordersPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlGroupCaption = New System.Windows.Forms.Panel()
        Me.lblGroupCaption = New System.Windows.Forms.Label()
        Me.btnDialog = New System.Windows.Forms.Button()
        Me.JRibbon1.SuspendLayout()
        Me.JRibbonGroup1.SuspendLayout()
        Me.pnlRibbon.SuspendLayout()
        Me.pnlGroup.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.pnlGroupCaption.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblIcon
        '
        Me.lblIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIcon.Font = New System.Drawing.Font("ancestry-icon", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIcon.ForeColor = System.Drawing.Color.White
        Me.lblIcon.Location = New System.Drawing.Point(413, 279)
        Me.lblIcon.Name = "lblIcon"
        Me.lblIcon.Size = New System.Drawing.Size(98, 37)
        Me.lblIcon.TabIndex = 1
        Me.lblIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDecToHex
        '
        Me.btnDecToHex.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDecToHex.Location = New System.Drawing.Point(413, 246)
        Me.btnDecToHex.Name = "btnDecToHex"
        Me.btnDecToHex.Size = New System.Drawing.Size(98, 20)
        Me.btnDecToHex.TabIndex = 2
        Me.btnDecToHex.Text = "<----"
        Me.btnDecToHex.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDecToHex.UseVisualStyleBackColor = False
        '
        'txtHex
        '
        Me.txtHex.BackColor = System.Drawing.Color.Gainsboro
        Me.txtHex.Location = New System.Drawing.Point(344, 232)
        Me.txtHex.Name = "txtHex"
        Me.txtHex.Size = New System.Drawing.Size(63, 20)
        Me.txtHex.TabIndex = 3
        Me.txtHex.Text = "E92A"
        Me.txtHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnHexToDec
        '
        Me.btnHexToDec.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnHexToDec.Location = New System.Drawing.Point(413, 220)
        Me.btnHexToDec.Name = "btnHexToDec"
        Me.btnHexToDec.Size = New System.Drawing.Size(98, 20)
        Me.btnHexToDec.TabIndex = 4
        Me.btnHexToDec.Text = "--->"
        Me.btnHexToDec.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnHexToDec.UseVisualStyleBackColor = False
        '
        'txtDec
        '
        Me.txtDec.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDec.Location = New System.Drawing.Point(517, 232)
        Me.txtDec.Name = "txtDec"
        Me.txtDec.Size = New System.Drawing.Size(63, 20)
        Me.txtDec.TabIndex = 5
        Me.txtDec.Text = "E92A"
        Me.txtDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(361, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Hex"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(532, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Dec"
        '
        'btnDecToImg
        '
        Me.btnDecToImg.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDecToImg.Location = New System.Drawing.Point(517, 252)
        Me.btnDecToImg.Name = "btnDecToImg"
        Me.btnDecToImg.Size = New System.Drawing.Size(63, 58)
        Me.btnDecToImg.TabIndex = 8
        Me.btnDecToImg.Text = "<----"
        Me.btnDecToImg.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDecToImg.UseVisualStyleBackColor = False
        '
        'btnHexToImg
        '
        Me.btnHexToImg.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnHexToImg.Location = New System.Drawing.Point(344, 252)
        Me.btnHexToImg.Name = "btnHexToImg"
        Me.btnHexToImg.Size = New System.Drawing.Size(63, 58)
        Me.btnHexToImg.TabIndex = 9
        Me.btnHexToImg.Text = "--->"
        Me.btnHexToImg.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnHexToImg.UseVisualStyleBackColor = False
        '
        'JRibbon1
        '
        Me.JRibbon1.AllowDrop = True
        Me.JRibbon1.BackColor = System.Drawing.Color.Transparent
        Me.JRibbon1.Controls.Add(Me.JRibbonGroup1)
        Me.JRibbon1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.JRibbon1.Dock = System.Windows.Forms.DockStyle.Top
        Me.JRibbon1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JRibbon1.ForeColor = System.Drawing.Color.Black
        Me.JRibbon1.Location = New System.Drawing.Point(0, 100)
        Me.JRibbon1.Margin = New System.Windows.Forms.Padding(0)
        Me.JRibbon1.MaximumSize = New System.Drawing.Size(0, 100)
        Me.JRibbon1.MinimumSize = New System.Drawing.Size(100, 100)
        Me.JRibbon1.Name = "JRibbon1"
        Me.JRibbon1.Padding = New System.Windows.Forms.Padding(16, 8, 2, 2)
        Me.JRibbon1.Size = New System.Drawing.Size(800, 100)
        Me.JRibbon1.TabIndex = 13
        '
        'JRibbonGroup1
        '
        Me.JRibbonGroup1.ColumnCount = 6
        Me.JRibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.JRibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.JRibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.JRibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.JRibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.JRibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.JRibbonGroup1.Controls.Add(Me.JButton1, 0, 0)
        Me.JRibbonGroup1.Controls.Add(Me.JButton3, 5, 0)
        Me.JRibbonGroup1.Dock = System.Windows.Forms.DockStyle.Left
        Me.JRibbonGroup1.Location = New System.Drawing.Point(16, 8)
        Me.JRibbonGroup1.Margin = New System.Windows.Forms.Padding(0)
        Me.JRibbonGroup1.MaximumSize = New System.Drawing.Size(0, 90)
        Me.JRibbonGroup1.MinimumSize = New System.Drawing.Size(100, 90)
        Me.JRibbonGroup1.Name = "JRibbonGroup1"
        Me.JRibbonGroup1.Padding = New System.Windows.Forms.Padding(0, 8, 2, 16)
        Me.JRibbonGroup1.RowCount = 2
        Me.JRibbonGroup1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.JRibbonGroup1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.JRibbonGroup1.Size = New System.Drawing.Size(100, 90)
        Me.JRibbonGroup1.TabIndex = 14
        '
        'JButton1
        '
        Me.JButton1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.JButton1.Caption = "Caption"
        Me.JRibbonGroup1.SetColumnSpan(Me.JButton1, 4)
        Me.JButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JButton1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.JButton1.IconFontStyle = System.Drawing.FontStyle.Regular
        Me.JButton1.IconSize = AncestryAssistant.JButton.IconSizeEnum.ICON32
        Me.JButton1.Layer1Color = System.Drawing.Color.Yellow
        Me.JButton1.Layer1Icon = AncestryAssistant.FontSegoeFluentIconsEnum.SegoeFluentIcons_SendFill
        Me.JButton1.Layer2Color = System.Drawing.Color.Black
        Me.JButton1.Layer2Icon = AncestryAssistant.FontSegoeFluentIconsEnum.SegoeFluentIcons_Send
        Me.JButton1.Layer3Color = System.Drawing.Color.Black
        Me.JButton1.Layer3Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.JButton1.Location = New System.Drawing.Point(0, 8)
        Me.JButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.JButton1.Name = "JButton1"
        Me.JRibbonGroup1.SetRowSpan(Me.JButton1, 2)
        Me.JButton1.Size = New System.Drawing.Size(64, 64)
        Me.JButton1.TabIndex = 10
        '
        'JButton3
        '
        Me.JButton3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.JButton3.Caption = ""
        Me.JButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JButton3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.JButton3.IconFontStyle = System.Drawing.FontStyle.Regular
        Me.JButton3.IconSize = AncestryAssistant.JButton.IconSizeEnum.ICON16
        Me.JButton3.Layer1Color = System.Drawing.Color.Yellow
        Me.JButton3.Layer1Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.JButton3.Layer2Color = System.Drawing.Color.Black
        Me.JButton3.Layer2Icon = AncestryAssistant.FontSegoeFluentIconsEnum.SegoeFluentIcons_Send
        Me.JButton3.Layer3Color = System.Drawing.Color.Black
        Me.JButton3.Layer3Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.JButton3.Location = New System.Drawing.Point(72, 8)
        Me.JButton3.Margin = New System.Windows.Forms.Padding(0)
        Me.JButton3.Name = "JButton3"
        Me.JButton3.Size = New System.Drawing.Size(20, 20)
        Me.JButton3.TabIndex = 12
        '
        'JButton2
        '
        Me.JButton2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.JButton2.Caption = "Caption"
        Me.JButton2.Enabled = False
        Me.JButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JButton2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.JButton2.IconFontStyle = System.Drawing.FontStyle.Regular
        Me.JButton2.IconSize = AncestryAssistant.JButton.IconSizeEnum.ICON32
        Me.JButton2.Layer1Color = System.Drawing.Color.Yellow
        Me.JButton2.Layer1Icon = AncestryAssistant.FontSegoeFluentIconsEnum.SegoeFluentIcons_SendFill
        Me.JButton2.Layer2Color = System.Drawing.Color.DarkGray
        Me.JButton2.Layer2Icon = AncestryAssistant.FontSegoeFluentIconsEnum.SegoeFluentIcons_Send
        Me.JButton2.Layer3Color = System.Drawing.Color.Black
        Me.JButton2.Layer3Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.JButton2.Location = New System.Drawing.Point(364, 337)
        Me.JButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.JButton2.Name = "JButton2"
        Me.JButton2.Size = New System.Drawing.Size(64, 64)
        Me.JButton2.TabIndex = 11
        '
        'pnlRibbon
        '
        Me.pnlRibbon.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pnlRibbon.BorderColor = System.Drawing.Color.Transparent
        Me.pnlRibbon.BorderColorBottom = System.Drawing.Color.DarkGray
        Me.pnlRibbon.BorderColorLeft = System.Drawing.Color.DarkGray
        Me.pnlRibbon.BorderColorRight = System.Drawing.Color.DarkGray
        Me.pnlRibbon.BorderColorTop = System.Drawing.Color.DarkGray
        Me.pnlRibbon.BorderWidth = New System.Windows.Forms.Padding(1)
        Me.pnlRibbon.Controls.Add(Me.pnlGroup)
        Me.pnlRibbon.CornerRadius = New System.Windows.Forms.Padding(16)
        Me.pnlRibbon.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRibbon.Location = New System.Drawing.Point(0, 0)
        Me.pnlRibbon.MaximumSize = New System.Drawing.Size(0, 100)
        Me.pnlRibbon.Name = "pnlRibbon"
        Me.pnlRibbon.Padding = New System.Windows.Forms.Padding(16, 8, 2, 2)
        Me.pnlRibbon.Size = New System.Drawing.Size(800, 100)
        Me.pnlRibbon.TabIndex = 0
        '
        'pnlGroup
        '
        Me.pnlGroup.BorderColor = System.Drawing.Color.Transparent
        Me.pnlGroup.BorderColorBottom = System.Drawing.Color.Transparent
        Me.pnlGroup.BorderColorLeft = System.Drawing.Color.Transparent
        Me.pnlGroup.BorderColorRight = System.Drawing.Color.DarkGray
        Me.pnlGroup.BorderColorTop = System.Drawing.Color.Transparent
        Me.pnlGroup.BorderWidth = New System.Windows.Forms.Padding(0, 0, 1, 0)
        Me.pnlGroup.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlGroup.Controls.Add(Me.pnlGroupCaption)
        Me.pnlGroup.CornerRadius = New System.Windows.Forms.Padding(0)
        Me.pnlGroup.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlGroup.Location = New System.Drawing.Point(16, 8)
        Me.pnlGroup.Name = "pnlGroup"
        Me.pnlGroup.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.pnlGroup.Size = New System.Drawing.Size(108, 90)
        Me.pnlGroup.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button3, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(106, 70)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.AncestryAssistant.My.Resources.Resources.interaktionen_clipboard_list1
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button1.Name = "Button1"
        Me.TableLayoutPanel1.SetRowSpan(Me.Button1, 2)
        Me.Button1.Size = New System.Drawing.Size(68, 70)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Paste"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.AncestryAssistant.My.Resources.Resources.interaktionen_cut
        Me.Button2.Location = New System.Drawing.Point(71, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(34, 29)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.AncestryAssistant.My.Resources.Resources.interaktionen_copy
        Me.Button3.Location = New System.Drawing.Point(71, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(34, 29)
        Me.Button3.TabIndex = 2
        Me.Button3.UseVisualStyleBackColor = True
        '
        'pnlGroupCaption
        '
        Me.pnlGroupCaption.Controls.Add(Me.lblGroupCaption)
        Me.pnlGroupCaption.Controls.Add(Me.btnDialog)
        Me.pnlGroupCaption.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlGroupCaption.Location = New System.Drawing.Point(0, 70)
        Me.pnlGroupCaption.Margin = New System.Windows.Forms.Padding(0)
        Me.pnlGroupCaption.Name = "pnlGroupCaption"
        Me.pnlGroupCaption.Size = New System.Drawing.Size(106, 20)
        Me.pnlGroupCaption.TabIndex = 0
        '
        'lblGroupCaption
        '
        Me.lblGroupCaption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblGroupCaption.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblGroupCaption.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupCaption.Location = New System.Drawing.Point(0, 0)
        Me.lblGroupCaption.Name = "lblGroupCaption"
        Me.lblGroupCaption.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)
        Me.lblGroupCaption.Size = New System.Drawing.Size(84, 20)
        Me.lblGroupCaption.TabIndex = 1
        Me.lblGroupCaption.Text = "Clipboard"
        Me.lblGroupCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDialog
        '
        Me.btnDialog.AutoSize = True
        Me.btnDialog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnDialog.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDialog.FlatAppearance.BorderSize = 0
        Me.btnDialog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDialog.Image = Global.AncestryAssistant.My.Resources.Resources.DOWN_RIGHT_2_ICO20
        Me.btnDialog.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnDialog.Location = New System.Drawing.Point(84, 0)
        Me.btnDialog.Margin = New System.Windows.Forms.Padding(0)
        Me.btnDialog.Name = "btnDialog"
        Me.btnDialog.Size = New System.Drawing.Size(22, 20)
        Me.btnDialog.TabIndex = 0
        Me.btnDialog.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDialog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDialog.UseMnemonic = False
        Me.btnDialog.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.JRibbon1)
        Me.Controls.Add(Me.JButton2)
        Me.Controls.Add(Me.btnHexToImg)
        Me.Controls.Add(Me.btnDecToImg)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDec)
        Me.Controls.Add(Me.btnHexToDec)
        Me.Controls.Add(Me.txtHex)
        Me.Controls.Add(Me.btnDecToHex)
        Me.Controls.Add(Me.lblIcon)
        Me.Controls.Add(Me.pnlRibbon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.JRibbon1.ResumeLayout(False)
        Me.JRibbonGroup1.ResumeLayout(False)
        Me.pnlRibbon.ResumeLayout(False)
        Me.pnlGroup.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.pnlGroupCaption.ResumeLayout(False)
        Me.pnlGroupCaption.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlRibbon As BordersPanel
    Friend WithEvents pnlGroup As BordersPanel
    Friend WithEvents pnlGroupCaption As Panel
    Friend WithEvents btnDialog As Button
    Friend WithEvents lblGroupCaption As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents lblIcon As Label
    Friend WithEvents btnDecToHex As Button
    Friend WithEvents txtHex As TextBox
    Friend WithEvents btnHexToDec As Button
    Friend WithEvents txtDec As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnDecToImg As Button
    Friend WithEvents btnHexToImg As Button
    Friend WithEvents JButton1 As JButton
    Friend WithEvents JButton2 As JButton
    Friend WithEvents JButton3 As JButton
    Friend WithEvents JRibbon1 As JRibbon
    Friend WithEvents JRibbonGroup1 As JRibbonGroup
End Class
