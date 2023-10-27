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
    Me.RibbonButton1 = New AncestryAssistant.RibbonButton()
    Me.Ribbon1 = New AncestryAssistant.Ribbon()
    Me.RibbonGroup1 = New AncestryAssistant.RibbonGroup()
        Me.RibbonGroup2 = New AncestryAssistant.RibbonGroup()
        Me.RibbonButton2 = New AncestryAssistant.RibbonButton()
        Me.RibbonButton3 = New AncestryAssistant.RibbonButton()
        Me.RibbonButton4 = New AncestryAssistant.RibbonButton()
        Me.RibbonButton5 = New AncestryAssistant.RibbonButton()
        Me.RibbonButton6 = New AncestryAssistant.RibbonButton()
        Me.Ribbon1.SuspendLayout()
        Me.RibbonGroup1.SuspendLayout()
        Me.RibbonGroup2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonButton1
        '
        Me.RibbonButton1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RibbonButton1.Caption = "Caption"
        Me.RibbonGroup1.SetColumnSpan(Me.RibbonButton1, 2)
        Me.RibbonButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonButton1.IconFontStyle = System.Drawing.FontStyle.Regular
        Me.RibbonButton1.IconSize = AncestryAssistant.RibbonButton.IconSizeEnum.Icon32x32
        Me.RibbonButton1.Layer1Color = System.Drawing.Color.Black
        Me.RibbonButton1.Layer1Icon = AncestryAssistant.FontSegoeFluentIconsEnum.SegoeFluentIcons_InternetSharing
        Me.RibbonButton1.Layer2Color = System.Drawing.Color.Black
        Me.RibbonButton1.Layer2Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton1.Layer3Color = System.Drawing.Color.Black
        Me.RibbonButton1.Layer3Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonButton1.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonButton1.MaximumSize = New System.Drawing.Size(48, 72)
        Me.RibbonButton1.MinimumSize = New System.Drawing.Size(48, 72)
        Me.RibbonButton1.Name = "RibbonButton1"
        Me.RibbonButton1.RibbonButtonSize = AncestryAssistant.RibbonButton.RibbonButtonSizeEnum.LargeButton
        Me.RibbonGroup1.SetRowSpan(Me.RibbonButton1, 3)
        Me.RibbonButton1.Size = New System.Drawing.Size(48, 72)
        Me.RibbonButton1.TabIndex = 1
        '
        'Ribbon1
        '
        Me.Ribbon1.AllowDrop = True
        Me.Ribbon1.BackColor = System.Drawing.Color.Transparent
        Me.Ribbon1.Controls.Add(Me.RibbonGroup2)
        Me.Ribbon1.Controls.Add(Me.RibbonGroup1)
        Me.Ribbon1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Ribbon1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ribbon1.Location = New System.Drawing.Point(2, 2)
        Me.Ribbon1.Margin = New System.Windows.Forms.Padding(0)
        Me.Ribbon1.MaximumSize = New System.Drawing.Size(0, 100)
        Me.Ribbon1.MinimumSize = New System.Drawing.Size(100, 100)
        Me.Ribbon1.Name = "Ribbon1"
        Me.Ribbon1.Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
        Me.Ribbon1.Size = New System.Drawing.Size(796, 100)
        Me.Ribbon1.TabIndex = 2
        '
        'RibbonGroup1
        '
        Me.RibbonGroup1.Caption = "Clipboard"
        Me.RibbonGroup1.ColumnCount = 6
        Me.RibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.RibbonGroup1.Controls.Add(Me.RibbonButton6, 3, 1)
        Me.RibbonGroup1.Controls.Add(Me.RibbonButton2, 2, 0)
        Me.RibbonGroup1.Controls.Add(Me.RibbonButton5, 2, 1)
        Me.RibbonGroup1.Controls.Add(Me.RibbonButton1, 0, 0)
        Me.RibbonGroup1.Controls.Add(Me.RibbonButton4, 3, 0)
        Me.RibbonGroup1.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonGroup1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.RibbonGroup1.Location = New System.Drawing.Point(16, 8)
        Me.RibbonGroup1.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonGroup1.MinimumSize = New System.Drawing.Size(100, 0)
        Me.RibbonGroup1.Name = "RibbonGroup1"
        Me.RibbonGroup1.RowCount = 4
        Me.RibbonGroup1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.RibbonGroup1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.RibbonGroup1.Size = New System.Drawing.Size(100, 84)
        Me.RibbonGroup1.TabIndex = 0
        '
        'RibbonGroup2
        '
        Me.RibbonGroup2.Caption = "RibbonGroup"
        Me.RibbonGroup2.ColumnCount = 6
        Me.RibbonGroup2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.RibbonGroup2.Controls.Add(Me.RibbonButton3, 0, 0)
        Me.RibbonGroup2.Dock = System.Windows.Forms.DockStyle.Left
        Me.RibbonGroup2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.RibbonGroup2.Location = New System.Drawing.Point(116, 8)
        Me.RibbonGroup2.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonGroup2.MinimumSize = New System.Drawing.Size(100, 0)
        Me.RibbonGroup2.Name = "RibbonGroup2"
        Me.RibbonGroup2.RowCount = 4
        Me.RibbonGroup2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.RibbonGroup2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.RibbonGroup2.Size = New System.Drawing.Size(100, 84)
        Me.RibbonGroup2.TabIndex = 1
        '
        'RibbonButton2
        '
        Me.RibbonButton2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RibbonButton2.Caption = ""
        Me.RibbonButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonButton2.IconFontStyle = System.Drawing.FontStyle.Regular
        Me.RibbonButton2.IconSize = AncestryAssistant.RibbonButton.IconSizeEnum.Icon20x20
        Me.RibbonButton2.Layer1Color = System.Drawing.Color.Black
        Me.RibbonButton2.Layer1Icon = AncestryAssistant.FontSegoeFluentIconsEnum.SegoeFluentIcons_VPN
        Me.RibbonButton2.Layer2Color = System.Drawing.Color.Black
        Me.RibbonButton2.Layer2Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton2.Layer3Color = System.Drawing.Color.Black
        Me.RibbonButton2.Layer3Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton2.Location = New System.Drawing.Point(48, 0)
        Me.RibbonButton2.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonButton2.MaximumSize = New System.Drawing.Size(24, 24)
        Me.RibbonButton2.MinimumSize = New System.Drawing.Size(24, 24)
        Me.RibbonButton2.Name = "RibbonButton2"
        Me.RibbonButton2.RibbonButtonSize = AncestryAssistant.RibbonButton.RibbonButtonSizeEnum.SmallButton
        Me.RibbonButton2.Size = New System.Drawing.Size(24, 24)
        Me.RibbonButton2.TabIndex = 0
        '
        'RibbonButton3
        '
        Me.RibbonButton3.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RibbonButton3.Caption = "XBox"
        Me.RibbonGroup2.SetColumnSpan(Me.RibbonButton3, 2)
        Me.RibbonButton3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonButton3.IconFontStyle = System.Drawing.FontStyle.Regular
        Me.RibbonButton3.IconSize = AncestryAssistant.RibbonButton.IconSizeEnum.Icon32x32
        Me.RibbonButton3.Layer1Color = System.Drawing.Color.Black
        Me.RibbonButton3.Layer1Icon = AncestryAssistant.FontSegoeFluentIconsEnum.SegoeFluentIcons_GameConsole
        Me.RibbonButton3.Layer2Color = System.Drawing.Color.Black
        Me.RibbonButton3.Layer2Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton3.Layer3Color = System.Drawing.Color.Black
        Me.RibbonButton3.Layer3Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton3.Location = New System.Drawing.Point(0, 0)
        Me.RibbonButton3.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonButton3.MaximumSize = New System.Drawing.Size(48, 72)
        Me.RibbonButton3.MinimumSize = New System.Drawing.Size(48, 72)
        Me.RibbonButton3.Name = "RibbonButton3"
        Me.RibbonButton3.RibbonButtonSize = AncestryAssistant.RibbonButton.RibbonButtonSizeEnum.LargeButton
        Me.RibbonGroup2.SetRowSpan(Me.RibbonButton3, 3)
        Me.RibbonButton3.Size = New System.Drawing.Size(48, 72)
        Me.RibbonButton3.TabIndex = 3
        '
        'RibbonButton4
        '
        Me.RibbonButton4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RibbonButton4.Caption = ""
        Me.RibbonButton4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonButton4.IconFontStyle = System.Drawing.FontStyle.Regular
        Me.RibbonButton4.IconSize = AncestryAssistant.RibbonButton.IconSizeEnum.Icon20x20
        Me.RibbonButton4.Layer1Color = System.Drawing.Color.Black
        Me.RibbonButton4.Layer1Icon = AncestryAssistant.FontSegoeFluentIconsEnum.SegoeFluentIcons_Bluetooth
        Me.RibbonButton4.Layer2Color = System.Drawing.Color.Black
        Me.RibbonButton4.Layer2Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton4.Layer3Color = System.Drawing.Color.Black
        Me.RibbonButton4.Layer3Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton4.Location = New System.Drawing.Point(72, 0)
        Me.RibbonButton4.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonButton4.MaximumSize = New System.Drawing.Size(24, 24)
        Me.RibbonButton4.MinimumSize = New System.Drawing.Size(24, 24)
        Me.RibbonButton4.Name = "RibbonButton4"
        Me.RibbonButton4.RibbonButtonSize = AncestryAssistant.RibbonButton.RibbonButtonSizeEnum.SmallButton
        Me.RibbonButton4.Size = New System.Drawing.Size(24, 24)
        Me.RibbonButton4.TabIndex = 3
        '
        'RibbonButton5
        '
        Me.RibbonButton5.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RibbonButton5.Caption = ""
        Me.RibbonButton5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonButton5.IconFontStyle = System.Drawing.FontStyle.Regular
        Me.RibbonButton5.IconSize = AncestryAssistant.RibbonButton.IconSizeEnum.Icon20x20
        Me.RibbonButton5.Layer1Color = System.Drawing.Color.Black
        Me.RibbonButton5.Layer1Icon = AncestryAssistant.FontSegoeFluentIconsEnum.SegoeFluentIcons_Connect
        Me.RibbonButton5.Layer2Color = System.Drawing.Color.Black
        Me.RibbonButton5.Layer2Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton5.Layer3Color = System.Drawing.Color.Black
        Me.RibbonButton5.Layer3Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton5.Location = New System.Drawing.Point(48, 24)
        Me.RibbonButton5.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonButton5.MaximumSize = New System.Drawing.Size(24, 24)
        Me.RibbonButton5.MinimumSize = New System.Drawing.Size(24, 24)
        Me.RibbonButton5.Name = "RibbonButton5"
        Me.RibbonButton5.RibbonButtonSize = AncestryAssistant.RibbonButton.RibbonButtonSizeEnum.SmallButton
        Me.RibbonButton5.Size = New System.Drawing.Size(24, 24)
        Me.RibbonButton5.TabIndex = 4
        '
        'RibbonButton6
        '
        Me.RibbonButton6.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.RibbonButton6.Caption = ""
        Me.RibbonButton6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonButton6.IconFontStyle = System.Drawing.FontStyle.Regular
        Me.RibbonButton6.IconSize = AncestryAssistant.RibbonButton.IconSizeEnum.Icon20x20
        Me.RibbonButton6.Layer1Color = System.Drawing.Color.Black
        Me.RibbonButton6.Layer1Icon = AncestryAssistant.FontSegoeFluentIconsEnum.SegoeFluentIcons_QuietHours
        Me.RibbonButton6.Layer2Color = System.Drawing.Color.Black
        Me.RibbonButton6.Layer2Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton6.Layer3Color = System.Drawing.Color.Black
        Me.RibbonButton6.Layer3Icon = AncestryAssistant.FontSegoeFluentIconsEnum.Blank
        Me.RibbonButton6.Location = New System.Drawing.Point(72, 24)
        Me.RibbonButton6.Margin = New System.Windows.Forms.Padding(0)
        Me.RibbonButton6.MaximumSize = New System.Drawing.Size(24, 24)
        Me.RibbonButton6.MinimumSize = New System.Drawing.Size(24, 24)
        Me.RibbonButton6.Name = "RibbonButton6"
        Me.RibbonButton6.RibbonButtonSize = AncestryAssistant.RibbonButton.RibbonButtonSizeEnum.SmallButton
        Me.RibbonButton6.Size = New System.Drawing.Size(24, 24)
        Me.RibbonButton6.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Ribbon1)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Text = "Form1"
        Me.Ribbon1.ResumeLayout(False)
        Me.RibbonGroup1.ResumeLayout(False)
        Me.RibbonGroup2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents JButton1 As RibbonButton
  Friend WithEvents JButton2 As RibbonButton
  Friend WithEvents JButton3 As RibbonButton
  Friend WithEvents JRibbon1 As Ribbon
  Friend WithEvents RibbonButton1 As RibbonButton
  Friend WithEvents Ribbon1 As Ribbon
  Friend WithEvents RibbonGroup1 As RibbonGroup
    Friend WithEvents RibbonGroup2 As RibbonGroup
    Friend WithEvents RibbonButton2 As RibbonButton
    Friend WithEvents RibbonButton3 As RibbonButton
    Friend WithEvents RibbonButton4 As RibbonButton
    Friend WithEvents RibbonButton5 As RibbonButton
    Friend WithEvents RibbonButton6 As RibbonButton
End Class
