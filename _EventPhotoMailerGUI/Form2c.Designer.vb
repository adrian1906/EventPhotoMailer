<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.textBox_MailServer = New System.Windows.Forms.TextBox()
        Me.label4_outgoing = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textBox_Username = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textBox_Password = New System.Windows.Forms.TextBox()
        Me.Label7_port = New System.Windows.Forms.Label()
        Me.PortBox = New System.Windows.Forms.TextBox()
        Me.CustomerInfoLabel = New System.Windows.Forms.Label()
        Me.Button_SaveAsDefault2 = New System.Windows.Forms.Button()
        Me.Form2closeNoSavebutton = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.EmailMasterListFilename = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.AdLabel = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.IncludeAdCheckBox = New System.Windows.Forms.CheckBox()
        Me.AdLabel2 = New System.Windows.Forms.Label()
        Me.UseMasterListCheckbox = New System.Windows.Forms.CheckBox()
        Me.ConfigButton1 = New System.Windows.Forms.Button()
        Me.ConfigButton2 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SSLcheckBox = New System.Windows.Forms.CheckBox()
        Me.Checkbox_CheckForIntConnectYesNo = New System.Windows.Forms.CheckBox()
        Me.PostEmailPrompt_CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'textBox_MailServer
        '
        Me.textBox_MailServer.Location = New System.Drawing.Point(14, 112)
        Me.textBox_MailServer.Name = "textBox_MailServer"
        Me.textBox_MailServer.Size = New System.Drawing.Size(322, 20)
        Me.textBox_MailServer.TabIndex = 113
        '
        'label4_outgoing
        '
        Me.label4_outgoing.AutoSize = True
        Me.label4_outgoing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4_outgoing.Location = New System.Drawing.Point(14, 58)
        Me.label4_outgoing.Name = "label4_outgoing"
        Me.label4_outgoing.Size = New System.Drawing.Size(163, 16)
        Me.label4_outgoing.TabIndex = 114
        Me.label4_outgoing.Text = "Outgoing Email Server"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Username"
        '
        'textBox_Username
        '
        Me.textBox_Username.Location = New System.Drawing.Point(14, 156)
        Me.textBox_Username.Name = "textBox_Username"
        Me.textBox_Username.Size = New System.Drawing.Size(322, 20)
        Me.textBox_Username.TabIndex = 115
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Password"
        '
        'textBox_Password
        '
        Me.textBox_Password.Location = New System.Drawing.Point(17, 204)
        Me.textBox_Password.Name = "textBox_Password"
        Me.textBox_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textBox_Password.Size = New System.Drawing.Size(322, 20)
        Me.textBox_Password.TabIndex = 117
        '
        'Label7_port
        '
        Me.Label7_port.AutoSize = True
        Me.Label7_port.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7_port.Location = New System.Drawing.Point(350, 93)
        Me.Label7_port.Name = "Label7_port"
        Me.Label7_port.Size = New System.Drawing.Size(36, 16)
        Me.Label7_port.TabIndex = 120
        Me.Label7_port.Text = "Port"
        '
        'PortBox
        '
        Me.PortBox.Location = New System.Drawing.Point(353, 112)
        Me.PortBox.Name = "PortBox"
        Me.PortBox.Size = New System.Drawing.Size(48, 20)
        Me.PortBox.TabIndex = 119
        Me.PortBox.Text = "25"
        '
        'CustomerInfoLabel
        '
        Me.CustomerInfoLabel.AutoSize = True
        Me.CustomerInfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerInfoLabel.Location = New System.Drawing.Point(448, 213)
        Me.CustomerInfoLabel.Name = "CustomerInfoLabel"
        Me.CustomerInfoLabel.Size = New System.Drawing.Size(391, 37)
        Me.CustomerInfoLabel.TabIndex = 121
        Me.CustomerInfoLabel.Text = "Email Configuration Editor"
        '
        'Button_SaveAsDefault2
        '
        Me.Button_SaveAsDefault2.Location = New System.Drawing.Point(297, 328)
        Me.Button_SaveAsDefault2.Name = "Button_SaveAsDefault2"
        Me.Button_SaveAsDefault2.Size = New System.Drawing.Size(99, 23)
        Me.Button_SaveAsDefault2.TabIndex = 122
        Me.Button_SaveAsDefault2.Text = "Save and Close"
        Me.Button_SaveAsDefault2.UseVisualStyleBackColor = True
        '
        'Form2closeNoSavebutton
        '
        Me.Form2closeNoSavebutton.Location = New System.Drawing.Point(433, 328)
        Me.Form2closeNoSavebutton.Name = "Form2closeNoSavebutton"
        Me.Form2closeNoSavebutton.Size = New System.Drawing.Size(121, 23)
        Me.Form2closeNoSavebutton.TabIndex = 123
        Me.Form2closeNoSavebutton.Text = "Close without saving"
        Me.Form2closeNoSavebutton.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(433, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 16)
        Me.Label7.TabIndex = 133
        Me.Label7.Text = "Email Master List"
        '
        'EmailMasterListFilename
        '
        Me.EmailMasterListFilename.Location = New System.Drawing.Point(6, 134)
        Me.EmailMasterListFilename.Name = "EmailMasterListFilename"
        Me.EmailMasterListFilename.ReadOnly = True
        Me.EmailMasterListFilename.Size = New System.Drawing.Size(322, 20)
        Me.EmailMasterListFilename.TabIndex = 132
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(334, 132)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 134
        Me.Button2.Text = "Browse"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "EmailMasterListDialog"
        '
        'AdLabel
        '
        Me.AdLabel.AutoSize = True
        Me.AdLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdLabel.Location = New System.Drawing.Point(433, 78)
        Me.AdLabel.Name = "AdLabel"
        Me.AdLabel.Size = New System.Drawing.Size(137, 16)
        Me.AdLabel.TabIndex = 136
        Me.AdLabel.Text = "Advertisement File"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(334, 86)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 137
        Me.Button3.Text = "Browse"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'IncludeAdCheckBox
        '
        Me.IncludeAdCheckBox.AutoSize = True
        Me.IncludeAdCheckBox.Location = New System.Drawing.Point(155, 66)
        Me.IncludeAdCheckBox.Name = "IncludeAdCheckBox"
        Me.IncludeAdCheckBox.Size = New System.Drawing.Size(156, 17)
        Me.IncludeAdCheckBox.TabIndex = 138
        Me.IncludeAdCheckBox.Text = "Include Advertisement File?"
        Me.IncludeAdCheckBox.UseVisualStyleBackColor = True
        '
        'AdLabel2
        '
        Me.AdLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AdLabel2.Location = New System.Drawing.Point(6, 86)
        Me.AdLabel2.Name = "AdLabel2"
        Me.AdLabel2.Size = New System.Drawing.Size(322, 20)
        Me.AdLabel2.TabIndex = 139
        '
        'UseMasterListCheckbox
        '
        Me.UseMasterListCheckbox.AutoSize = True
        Me.UseMasterListCheckbox.Location = New System.Drawing.Point(155, 115)
        Me.UseMasterListCheckbox.Name = "UseMasterListCheckbox"
        Me.UseMasterListCheckbox.Size = New System.Drawing.Size(105, 17)
        Me.UseMasterListCheckbox.TabIndex = 140
        Me.UseMasterListCheckbox.Text = "Use Master List?"
        Me.UseMasterListCheckbox.UseVisualStyleBackColor = True
        '
        'ConfigButton1
        '
        Me.ConfigButton1.Location = New System.Drawing.Point(93, 25)
        Me.ConfigButton1.Name = "ConfigButton1"
        Me.ConfigButton1.Size = New System.Drawing.Size(109, 23)
        Me.ConfigButton1.TabIndex = 142
        Me.ConfigButton1.Text = "Configuration 1"
        Me.ConfigButton1.UseVisualStyleBackColor = True
        '
        'ConfigButton2
        '
        Me.ConfigButton2.Location = New System.Drawing.Point(217, 25)
        Me.ConfigButton2.Name = "ConfigButton2"
        Me.ConfigButton2.Size = New System.Drawing.Size(109, 23)
        Me.ConfigButton2.TabIndex = 143
        Me.ConfigButton2.Text = "Configuration 2"
        Me.ConfigButton2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"List of ISP providers"})
        Me.ComboBox1.Location = New System.Drawing.Point(14, 77)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(322, 21)
        Me.ComboBox1.TabIndex = 145
        Me.ComboBox1.Text = "List of ISPs"
        '
        'SSLcheckBox
        '
        Me.SSLcheckBox.AutoSize = True
        Me.SSLcheckBox.Location = New System.Drawing.Point(17, 239)
        Me.SSLcheckBox.Name = "SSLcheckBox"
        Me.SSLcheckBox.Size = New System.Drawing.Size(68, 17)
        Me.SSLcheckBox.TabIndex = 146
        Me.SSLcheckBox.Text = "Use SSL"
        Me.SSLcheckBox.UseVisualStyleBackColor = True
        '
        'Checkbox_CheckForIntConnectYesNo
        '
        Me.Checkbox_CheckForIntConnectYesNo.AutoSize = True
        Me.Checkbox_CheckForIntConnectYesNo.Location = New System.Drawing.Point(17, 262)
        Me.Checkbox_CheckForIntConnectYesNo.Name = "Checkbox_CheckForIntConnectYesNo"
        Me.Checkbox_CheckForIntConnectYesNo.Size = New System.Drawing.Size(242, 17)
        Me.Checkbox_CheckForIntConnectYesNo.TabIndex = 147
        Me.Checkbox_CheckForIntConnectYesNo.Text = "Check for internet connection before sending."
        Me.Checkbox_CheckForIntConnectYesNo.UseVisualStyleBackColor = True
        '
        'PostEmailPrompt_CheckBox1
        '
        Me.PostEmailPrompt_CheckBox1.AutoSize = True
        Me.PostEmailPrompt_CheckBox1.Location = New System.Drawing.Point(17, 285)
        Me.PostEmailPrompt_CheckBox1.Name = "PostEmailPrompt_CheckBox1"
        Me.PostEmailPrompt_CheckBox1.Size = New System.Drawing.Size(170, 17)
        Me.PostEmailPrompt_CheckBox1.TabIndex = 148
        Me.PostEmailPrompt_CheckBox1.Text = "Post Prompt for Email Address."
        Me.PostEmailPrompt_CheckBox1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AccessibleDescription = ""
        Me.Panel1.AccessibleName = ""
        Me.Panel1.Controls.Add(Me.PostEmailPrompt_CheckBox1)
        Me.Panel1.Controls.Add(Me.Checkbox_CheckForIntConnectYesNo)
        Me.Panel1.Controls.Add(Me.SSLcheckBox)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Label7_port)
        Me.Panel1.Controls.Add(Me.PortBox)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.textBox_Password)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.textBox_Username)
        Me.Panel1.Controls.Add(Me.label4_outgoing)
        Me.Panel1.Controls.Add(Me.textBox_MailServer)
        Me.Panel1.Location = New System.Drawing.Point(10, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(414, 313)
        Me.Panel1.TabIndex = 149
        Me.Panel1.Tag = "Email Configuration"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ConfigButton2)
        Me.Panel2.Controls.Add(Me.ConfigButton1)
        Me.Panel2.Controls.Add(Me.UseMasterListCheckbox)
        Me.Panel2.Controls.Add(Me.AdLabel2)
        Me.Panel2.Controls.Add(Me.IncludeAdCheckBox)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.EmailMasterListFilename)
        Me.Panel2.Location = New System.Drawing.Point(430, 9)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(420, 189)
        Me.Panel2.TabIndex = 150
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 363)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.AdLabel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Form2closeNoSavebutton)
        Me.Controls.Add(Me.CustomerInfoLabel)
        Me.Controls.Add(Me.Button_SaveAsDefault2)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email Configuration Editor"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents textBox_MailServer As System.Windows.Forms.TextBox
    Friend WithEvents label4_outgoing As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents textBox_Username As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents textBox_Password As System.Windows.Forms.TextBox
    Friend WithEvents Label7_port As System.Windows.Forms.Label
    Friend WithEvents PortBox As System.Windows.Forms.TextBox
    Friend WithEvents CustomerInfoLabel As System.Windows.Forms.Label
    Friend WithEvents Button_SaveAsDefault2 As System.Windows.Forms.Button
    Friend WithEvents Form2closeNoSavebutton As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents EmailMasterListFilename As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AdLabel As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents IncludeAdCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AdLabel2 As System.Windows.Forms.Label
    Friend WithEvents UseMasterListCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents ConfigButton1 As System.Windows.Forms.Button
    Friend WithEvents ConfigButton2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents SSLcheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Checkbox_CheckForIntConnectYesNo As System.Windows.Forms.CheckBox
    Friend WithEvents PostEmailPrompt_CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
