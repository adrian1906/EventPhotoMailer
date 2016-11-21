<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.InputImageTextbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.HotFolder = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Start = New System.Windows.Forms.Button()
        Me.ThreePercent = New System.Windows.Forms.RadioButton()
        Me.FivePercent = New System.Windows.Forms.RadioButton()
        Me.TenPercent = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OpenOutput = New System.Windows.Forms.Button()
        Me.UseWatchFolderCheckbox = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(371, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'InputImageTextbox
        '
        Me.InputImageTextbox.Location = New System.Drawing.Point(17, 20)
        Me.InputImageTextbox.Name = "InputImageTextbox"
        Me.InputImageTextbox.Size = New System.Drawing.Size(339, 20)
        Me.InputImageTextbox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Input Image"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "HotFolder"
        '
        'HotFolder
        '
        Me.HotFolder.Location = New System.Drawing.Point(43, 72)
        Me.HotFolder.Name = "HotFolder"
        Me.HotFolder.Size = New System.Drawing.Size(339, 20)
        Me.HotFolder.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(397, 70)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(97, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Browse"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Start
        '
        Me.Start.Location = New System.Drawing.Point(371, 47)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(97, 26)
        Me.Start.TabIndex = 3
        Me.Start.Text = "Start"
        Me.Start.UseVisualStyleBackColor = True
        '
        'ThreePercent
        '
        Me.ThreePercent.AutoSize = True
        Me.ThreePercent.Location = New System.Drawing.Point(20, 46)
        Me.ThreePercent.Name = "ThreePercent"
        Me.ThreePercent.Size = New System.Drawing.Size(39, 17)
        Me.ThreePercent.TabIndex = 9
        Me.ThreePercent.TabStop = True
        Me.ThreePercent.Text = "3%"
        Me.ThreePercent.UseVisualStyleBackColor = True
        '
        'FivePercent
        '
        Me.FivePercent.AutoSize = True
        Me.FivePercent.Location = New System.Drawing.Point(65, 46)
        Me.FivePercent.Name = "FivePercent"
        Me.FivePercent.Size = New System.Drawing.Size(39, 17)
        Me.FivePercent.TabIndex = 9
        Me.FivePercent.TabStop = True
        Me.FivePercent.Text = "5%"
        Me.FivePercent.UseVisualStyleBackColor = True
        '
        'TenPercent
        '
        Me.TenPercent.AutoSize = True
        Me.TenPercent.Location = New System.Drawing.Point(110, 46)
        Me.TenPercent.Name = "TenPercent"
        Me.TenPercent.Size = New System.Drawing.Size(165, 17)
        Me.TenPercent.TabIndex = 9
        Me.TenPercent.TabStop = True
        Me.TenPercent.Text = "10% You know that ain't right!"
        Me.TenPercent.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(116, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(289, 31)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Quick Image Modifier"
        '
        'OpenOutput
        '
        Me.OpenOutput.Location = New System.Drawing.Point(397, 41)
        Me.OpenOutput.Name = "OpenOutput"
        Me.OpenOutput.Size = New System.Drawing.Size(97, 23)
        Me.OpenOutput.TabIndex = 3
        Me.OpenOutput.Text = "Open Hot Folder"
        Me.OpenOutput.UseVisualStyleBackColor = True
        '
        'UseWatchFolderCheckbox
        '
        Me.UseWatchFolderCheckbox.AutoSize = True
        Me.UseWatchFolderCheckbox.Location = New System.Drawing.Point(122, 49)
        Me.UseWatchFolderCheckbox.Name = "UseWatchFolderCheckbox"
        Me.UseWatchFolderCheckbox.Size = New System.Drawing.Size(116, 17)
        Me.UseWatchFolderCheckbox.TabIndex = 15
        Me.UseWatchFolderCheckbox.Text = "Monitor HotFolder?"
        Me.UseWatchFolderCheckbox.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TenPercent)
        Me.Panel1.Controls.Add(Me.FivePercent)
        Me.Panel1.Controls.Add(Me.ThreePercent)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Start)
        Me.Panel1.Controls.Add(Me.InputImageTextbox)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(26, 113)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 92)
        Me.Panel1.TabIndex = 16
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(285, 44)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(97, 23)
        Me.SaveButton.TabIndex = 17
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 221)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.UseWatchFolderCheckbox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.HotFolder)
        Me.Controls.Add(Me.OpenOutput)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "QIM v 1.0"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents InputImageTextbox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents HotFolder As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Start As System.Windows.Forms.Button
    Friend WithEvents ThreePercent As System.Windows.Forms.RadioButton
    Friend WithEvents FivePercent As System.Windows.Forms.RadioButton
    Friend WithEvents TenPercent As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OpenOutput As System.Windows.Forms.Button
    Friend WithEvents UseWatchFolderCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SaveButton As System.Windows.Forms.Button

End Class
