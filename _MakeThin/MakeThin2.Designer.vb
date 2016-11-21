<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MakeThinForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MakeThinForm))
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.InstructionsBox1 = New System.Windows.Forms.RichTextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(371, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'InputImageTextbox
        '
        Me.InputImageTextbox.Location = New System.Drawing.Point(17, 44)
        Me.InputImageTextbox.Name = "InputImageTextbox"
        Me.InputImageTextbox.Size = New System.Drawing.Size(339, 20)
        Me.InputImageTextbox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Input Image"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Save To Folder:"
        '
        'HotFolder
        '
        Me.HotFolder.Location = New System.Drawing.Point(36, 68)
        Me.HotFolder.Name = "HotFolder"
        Me.HotFolder.Size = New System.Drawing.Size(339, 20)
        Me.HotFolder.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(387, 65)
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
        Me.Start.Location = New System.Drawing.Point(371, 71)
        Me.Start.Name = "Start"
        Me.Start.Size = New System.Drawing.Size(97, 26)
        Me.Start.TabIndex = 3
        Me.Start.Text = "Start"
        Me.Start.UseVisualStyleBackColor = True
        '
        'ThreePercent
        '
        Me.ThreePercent.AutoSize = True
        Me.ThreePercent.Location = New System.Drawing.Point(20, 70)
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
        Me.FivePercent.Location = New System.Drawing.Point(65, 70)
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
        Me.TenPercent.Location = New System.Drawing.Point(110, 70)
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
        Me.Label5.Location = New System.Drawing.Point(173, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 31)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Make Thin"
        '
        'OpenOutput
        '
        Me.OpenOutput.Location = New System.Drawing.Point(126, 43)
        Me.OpenOutput.Name = "OpenOutput"
        Me.OpenOutput.Size = New System.Drawing.Size(141, 23)
        Me.OpenOutput.TabIndex = 3
        Me.OpenOutput.Text = "Open Save To Folder"
        Me.OpenOutput.UseVisualStyleBackColor = True
        '
        'UseWatchFolderCheckbox
        '
        Me.UseWatchFolderCheckbox.AutoSize = True
        Me.UseWatchFolderCheckbox.Location = New System.Drawing.Point(17, 43)
        Me.UseWatchFolderCheckbox.Name = "UseWatchFolderCheckbox"
        Me.UseWatchFolderCheckbox.Size = New System.Drawing.Size(321, 17)
        Me.UseWatchFolderCheckbox.TabIndex = 15
        Me.UseWatchFolderCheckbox.Text = "Monitor HotFolder? (Automatically Detect and Process Images)"
        Me.UseWatchFolderCheckbox.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TenPercent)
        Me.Panel1.Controls.Add(Me.FivePercent)
        Me.Panel1.Controls.Add(Me.ThreePercent)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Start)
        Me.Panel1.Controls.Add(Me.InputImageTextbox)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(12, 199)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 104)
        Me.Panel1.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(149, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 24)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Manual Mode"
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(387, 309)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(97, 23)
        Me.SaveButton.TabIndex = 17
        Me.SaveButton.Text = "Save Settings"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(448, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Tag = "hello"
        Me.Label3.Text = "info"
        Me.ToolTip1.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.UseWatchFolderCheckbox)
        Me.Panel3.Location = New System.Drawing.Point(12, 97)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(481, 72)
        Me.Panel3.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(149, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 24)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Automatic Mode"
        '
        'InstructionsBox1
        '
        Me.InstructionsBox1.Location = New System.Drawing.Point(8, 354)
        Me.InstructionsBox1.Name = "InstructionsBox1"
        Me.InstructionsBox1.Size = New System.Drawing.Size(485, 286)
        Me.InstructionsBox1.TabIndex = 21
        Me.InstructionsBox1.Text = resources.GetString("InstructionsBox1.Text")
        Me.InstructionsBox1.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(8, 331)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(116, 17)
        Me.CheckBox1.TabIndex = 22
        Me.CheckBox1.Text = "Show Instructions?"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'MakeThinForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 651)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.InstructionsBox1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.HotFolder)
        Me.Controls.Add(Me.OpenOutput)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MakeThinForm"
        Me.Text = "MakeThin V2.0"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolTip2 As System.Windows.Forms.ToolTip
    Friend WithEvents ToolTip3 As System.Windows.Forms.ToolTip
    Friend WithEvents InstructionsBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
