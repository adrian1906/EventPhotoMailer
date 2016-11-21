<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailSetupForm
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
        Me.Button_SaveAsDefault2 = New System.Windows.Forms.Button()
        Me.Form2closeNoSavebutton = New System.Windows.Forms.Button()
        Me.EmailMasterListFilename = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.IncludeAdCheckBox = New System.Windows.Forms.CheckBox()
        Me.AdLabel2 = New System.Windows.Forms.Label()
        Me.UseMasterListCheckbox = New System.Windows.Forms.CheckBox()
        Me.ConfigButton1 = New System.Windows.Forms.Button()
        Me.ConfigButton2 = New System.Windows.Forms.Button()
        Me.CompNameLabel = New System.Windows.Forms.Label()
        Me.CompEmaillabel = New System.Windows.Forms.Label()
        Me.textBox_MailServer = New System.Windows.Forms.TextBox()
        Me.label4_outgoing = New System.Windows.Forms.Label()
        Me.textBox_Username = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textBox_Password = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PortBox = New System.Windows.Forms.TextBox()
        Me.Label7_port = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.SSLcheckBox = New System.Windows.Forms.CheckBox()
        Me.Checkbox_CheckForIntConnectYesNo = New System.Windows.Forms.CheckBox()
        Me.PostEmailPrompt_CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PromptButDelaySendingCheckbox = New System.Windows.Forms.CheckBox()
        Me.CheckBox_ConfirmationEmail = New System.Windows.Forms.CheckBox()
        Me.EmailCombineCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CurrentConfigLabel = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CompEmailTextbox = New System.Windows.Forms.TextBox()
        Me.CompNameTextbox = New System.Windows.Forms.TextBox()
        Me.PromptForEmailOnly_RadioButton = New System.Windows.Forms.RadioButton()
        Me.DontPromptForEmail_RadioButton = New System.Windows.Forms.RadioButton()
        Me.DontPromptForEmailAndSend_RadioButton = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_SaveAsDefault2
        '
        Me.Button_SaveAsDefault2.Location = New System.Drawing.Point(297, 328)
        Me.Button_SaveAsDefault2.Name = "Button_SaveAsDefault2"
        Me.Button_SaveAsDefault2.Size = New System.Drawing.Size(99, 23)
        Me.Button_SaveAsDefault2.TabIndex = 4
        Me.Button_SaveAsDefault2.Text = "Save and Close"
        Me.Button_SaveAsDefault2.UseVisualStyleBackColor = True
        '
        'Form2closeNoSavebutton
        '
        Me.Form2closeNoSavebutton.Location = New System.Drawing.Point(433, 328)
        Me.Form2closeNoSavebutton.Name = "Form2closeNoSavebutton"
        Me.Form2closeNoSavebutton.Size = New System.Drawing.Size(121, 23)
        Me.Form2closeNoSavebutton.TabIndex = 5
        Me.Form2closeNoSavebutton.Text = "Close without saving"
        Me.Form2closeNoSavebutton.UseVisualStyleBackColor = True
        '
        'EmailMasterListFilename
        '
        Me.EmailMasterListFilename.Location = New System.Drawing.Point(430, 300)
        Me.EmailMasterListFilename.Name = "EmailMasterListFilename"
        Me.EmailMasterListFilename.ReadOnly = True
        Me.EmailMasterListFilename.Size = New System.Drawing.Size(322, 20)
        Me.EmailMasterListFilename.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(758, 298)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Browse"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "EmailMasterListDialog"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(758, 252)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 1
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
        Me.IncludeAdCheckBox.Location = New System.Drawing.Point(430, 232)
        Me.IncludeAdCheckBox.Name = "IncludeAdCheckBox"
        Me.IncludeAdCheckBox.Size = New System.Drawing.Size(156, 17)
        Me.IncludeAdCheckBox.TabIndex = 138
        Me.IncludeAdCheckBox.Text = "Include Advertisement File?"
        Me.IncludeAdCheckBox.UseVisualStyleBackColor = True
        '
        'AdLabel2
        '
        Me.AdLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AdLabel2.Location = New System.Drawing.Point(430, 252)
        Me.AdLabel2.Name = "AdLabel2"
        Me.AdLabel2.Size = New System.Drawing.Size(322, 20)
        Me.AdLabel2.TabIndex = 0
        '
        'UseMasterListCheckbox
        '
        Me.UseMasterListCheckbox.AutoSize = True
        Me.UseMasterListCheckbox.Location = New System.Drawing.Point(430, 278)
        Me.UseMasterListCheckbox.Name = "UseMasterListCheckbox"
        Me.UseMasterListCheckbox.Size = New System.Drawing.Size(149, 17)
        Me.UseMasterListCheckbox.TabIndex = 140
        Me.UseMasterListCheckbox.Text = "Update Email Master List?"
        Me.UseMasterListCheckbox.UseVisualStyleBackColor = True
        '
        'ConfigButton1
        '
        Me.ConfigButton1.Location = New System.Drawing.Point(103, 15)
        Me.ConfigButton1.Name = "ConfigButton1"
        Me.ConfigButton1.Size = New System.Drawing.Size(109, 23)
        Me.ConfigButton1.TabIndex = 142
        Me.ConfigButton1.Text = "Configuration 1"
        Me.ConfigButton1.UseVisualStyleBackColor = True
        '
        'ConfigButton2
        '
        Me.ConfigButton2.Location = New System.Drawing.Point(227, 15)
        Me.ConfigButton2.Name = "ConfigButton2"
        Me.ConfigButton2.Size = New System.Drawing.Size(109, 23)
        Me.ConfigButton2.TabIndex = 143
        Me.ConfigButton2.Text = "Configuration 2"
        Me.ConfigButton2.UseVisualStyleBackColor = True
        '
        'CompNameLabel
        '
        Me.CompNameLabel.AutoSize = True
        Me.CompNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompNameLabel.Location = New System.Drawing.Point(10, 20)
        Me.CompNameLabel.Name = "CompNameLabel"
        Me.CompNameLabel.Size = New System.Drawing.Size(118, 16)
        Me.CompNameLabel.TabIndex = 153
        Me.CompNameLabel.Text = "Company Name"
        '
        'CompEmaillabel
        '
        Me.CompEmaillabel.AutoSize = True
        Me.CompEmaillabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompEmaillabel.Location = New System.Drawing.Point(10, 67)
        Me.CompEmaillabel.Name = "CompEmaillabel"
        Me.CompEmaillabel.Size = New System.Drawing.Size(116, 16)
        Me.CompEmaillabel.TabIndex = 152
        Me.CompEmaillabel.Text = "Company Email"
        '
        'textBox_MailServer
        '
        Me.textBox_MailServer.Location = New System.Drawing.Point(15, 75)
        Me.textBox_MailServer.Name = "textBox_MailServer"
        Me.textBox_MailServer.Size = New System.Drawing.Size(322, 20)
        Me.textBox_MailServer.TabIndex = 1
        '
        'label4_outgoing
        '
        Me.label4_outgoing.AutoSize = True
        Me.label4_outgoing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4_outgoing.Location = New System.Drawing.Point(15, 21)
        Me.label4_outgoing.Name = "label4_outgoing"
        Me.label4_outgoing.Size = New System.Drawing.Size(163, 16)
        Me.label4_outgoing.TabIndex = 114
        Me.label4_outgoing.Text = "Outgoing Email Server"
        '
        'textBox_Username
        '
        Me.textBox_Username.Location = New System.Drawing.Point(15, 121)
        Me.textBox_Username.Name = "textBox_Username"
        Me.textBox_Username.Size = New System.Drawing.Size(322, 20)
        Me.textBox_Username.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Username"
        '
        'textBox_Password
        '
        Me.textBox_Password.Location = New System.Drawing.Point(18, 172)
        Me.textBox_Password.Name = "textBox_Password"
        Me.textBox_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textBox_Password.Size = New System.Drawing.Size(322, 20)
        Me.textBox_Password.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Password"
        '
        'PortBox
        '
        Me.PortBox.Location = New System.Drawing.Point(354, 75)
        Me.PortBox.Name = "PortBox"
        Me.PortBox.Size = New System.Drawing.Size(48, 20)
        Me.PortBox.TabIndex = 2
        Me.PortBox.Text = "25"
        '
        'Label7_port
        '
        Me.Label7_port.AutoSize = True
        Me.Label7_port.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7_port.Location = New System.Drawing.Point(351, 56)
        Me.Label7_port.Name = "Label7_port"
        Me.Label7_port.Size = New System.Drawing.Size(36, 16)
        Me.Label7_port.TabIndex = 120
        Me.Label7_port.Text = "Port"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"List of ISP providers"})
        Me.ComboBox1.Location = New System.Drawing.Point(15, 40)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(322, 21)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Text = "List of ISPs"
        '
        'SSLcheckBox
        '
        Me.SSLcheckBox.AutoSize = True
        Me.SSLcheckBox.Location = New System.Drawing.Point(15, 238)
        Me.SSLcheckBox.Name = "SSLcheckBox"
        Me.SSLcheckBox.Size = New System.Drawing.Size(68, 17)
        Me.SSLcheckBox.TabIndex = 7
        Me.SSLcheckBox.Text = "Use SSL"
        Me.SSLcheckBox.UseVisualStyleBackColor = True
        '
        'Checkbox_CheckForIntConnectYesNo
        '
        Me.Checkbox_CheckForIntConnectYesNo.AutoSize = True
        Me.Checkbox_CheckForIntConnectYesNo.Enabled = False
        Me.Checkbox_CheckForIntConnectYesNo.Location = New System.Drawing.Point(15, 261)
        Me.Checkbox_CheckForIntConnectYesNo.Name = "Checkbox_CheckForIntConnectYesNo"
        Me.Checkbox_CheckForIntConnectYesNo.Size = New System.Drawing.Size(242, 17)
        Me.Checkbox_CheckForIntConnectYesNo.TabIndex = 8
        Me.Checkbox_CheckForIntConnectYesNo.Text = "Check for internet connection before sending."
        Me.Checkbox_CheckForIntConnectYesNo.UseVisualStyleBackColor = True
        Me.Checkbox_CheckForIntConnectYesNo.Visible = False
        '
        'PostEmailPrompt_CheckBox1
        '
        Me.PostEmailPrompt_CheckBox1.AutoSize = True
        Me.PostEmailPrompt_CheckBox1.Location = New System.Drawing.Point(15, 284)
        Me.PostEmailPrompt_CheckBox1.Name = "PostEmailPrompt_CheckBox1"
        Me.PostEmailPrompt_CheckBox1.Size = New System.Drawing.Size(170, 17)
        Me.PostEmailPrompt_CheckBox1.TabIndex = 9
        Me.PostEmailPrompt_CheckBox1.Text = "Post Prompt for Email Address."
        Me.PostEmailPrompt_CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PromptButDelaySendingCheckbox)
        Me.GroupBox1.Controls.Add(Me.CheckBox_ConfirmationEmail)
        Me.GroupBox1.Controls.Add(Me.EmailCombineCheckBox)
        Me.GroupBox1.Controls.Add(Me.PostEmailPrompt_CheckBox1)
        Me.GroupBox1.Controls.Add(Me.Checkbox_CheckForIntConnectYesNo)
        Me.GroupBox1.Controls.Add(Me.SSLcheckBox)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Label7_port)
        Me.GroupBox1.Controls.Add(Me.PortBox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.textBox_Password)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.textBox_MailServer)
        Me.GroupBox1.Controls.Add(Me.textBox_Username)
        Me.GroupBox1.Controls.Add(Me.label4_outgoing)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 307)
        Me.GroupBox1.TabIndex = 156
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Email Configuration"
        '
        'PromptButDelaySendingCheckbox
        '
        Me.PromptButDelaySendingCheckbox.AutoSize = True
        Me.PromptButDelaySendingCheckbox.Location = New System.Drawing.Point(199, 284)
        Me.PromptButDelaySendingCheckbox.Name = "PromptButDelaySendingCheckbox"
        Me.PromptButDelaySendingCheckbox.Size = New System.Drawing.Size(189, 17)
        Me.PromptButDelaySendingCheckbox.TabIndex = 121
        Me.PromptButDelaySendingCheckbox.Text = "Prompt For Email But Do Not Send"
        Me.PromptButDelaySendingCheckbox.UseVisualStyleBackColor = True
        '
        'CheckBox_ConfirmationEmail
        '
        Me.CheckBox_ConfirmationEmail.AutoSize = True
        Me.CheckBox_ConfirmationEmail.Location = New System.Drawing.Point(19, 204)
        Me.CheckBox_ConfirmationEmail.Name = "CheckBox_ConfirmationEmail"
        Me.CheckBox_ConfirmationEmail.Size = New System.Drawing.Size(166, 17)
        Me.CheckBox_ConfirmationEmail.TabIndex = 5
        Me.CheckBox_ConfirmationEmail.Text = "Receive Confirmation Emails?"
        Me.CheckBox_ConfirmationEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox_ConfirmationEmail.UseVisualStyleBackColor = True
        '
        'EmailCombineCheckBox
        '
        Me.EmailCombineCheckBox.AutoSize = True
        Me.EmailCombineCheckBox.Location = New System.Drawing.Point(199, 204)
        Me.EmailCombineCheckBox.Name = "EmailCombineCheckBox"
        Me.EmailCombineCheckBox.Size = New System.Drawing.Size(149, 17)
        Me.EmailCombineCheckBox.TabIndex = 6
        Me.EmailCombineCheckBox.Text = "Disable image combining?"
        Me.EmailCombineCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.EmailCombineCheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CurrentConfigLabel)
        Me.GroupBox2.Controls.Add(Me.ConfigButton2)
        Me.GroupBox2.Controls.Add(Me.ConfigButton1)
        Me.GroupBox2.Location = New System.Drawing.Point(430, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(420, 64)
        Me.GroupBox2.TabIndex = 157
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configuration Selection"
        '
        'CurrentConfigLabel
        '
        Me.CurrentConfigLabel.AutoSize = True
        Me.CurrentConfigLabel.Location = New System.Drawing.Point(155, 48)
        Me.CurrentConfigLabel.Name = "CurrentConfigLabel"
        Me.CurrentConfigLabel.Size = New System.Drawing.Size(122, 13)
        Me.CurrentConfigLabel.TabIndex = 144
        Me.CurrentConfigLabel.Text = "Configuration ? is in use."
        Me.CurrentConfigLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CompEmailTextbox)
        Me.GroupBox3.Controls.Add(Me.CompNameTextbox)
        Me.GroupBox3.Controls.Add(Me.CompNameLabel)
        Me.GroupBox3.Controls.Add(Me.CompEmaillabel)
        Me.GroupBox3.Location = New System.Drawing.Point(430, 27)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(419, 118)
        Me.GroupBox3.TabIndex = 158
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Company Information"
        '
        'CompEmailTextbox
        '
        Me.CompEmailTextbox.Location = New System.Drawing.Point(14, 92)
        Me.CompEmailTextbox.Name = "CompEmailTextbox"
        Me.CompEmailTextbox.Size = New System.Drawing.Size(394, 20)
        Me.CompEmailTextbox.TabIndex = 1
        '
        'CompNameTextbox
        '
        Me.CompNameTextbox.Location = New System.Drawing.Point(14, 44)
        Me.CompNameTextbox.Name = "CompNameTextbox"
        Me.CompNameTextbox.Size = New System.Drawing.Size(394, 20)
        Me.CompNameTextbox.TabIndex = 0
        '
        'PromptForEmailOnly_RadioButton
        '
        Me.PromptForEmailOnly_RadioButton.AutoSize = True
        Me.PromptForEmailOnly_RadioButton.Location = New System.Drawing.Point(22, 343)
        Me.PromptForEmailOnly_RadioButton.Name = "PromptForEmailOnly_RadioButton"
        Me.PromptForEmailOnly_RadioButton.Size = New System.Drawing.Size(128, 17)
        Me.PromptForEmailOnly_RadioButton.TabIndex = 159
        Me.PromptForEmailOnly_RadioButton.TabStop = True
        Me.PromptForEmailOnly_RadioButton.Text = "Prompt For Email Only"
        Me.PromptForEmailOnly_RadioButton.UseVisualStyleBackColor = True
        '
        'DontPromptForEmail_RadioButton
        '
        Me.DontPromptForEmail_RadioButton.AutoSize = True
        Me.DontPromptForEmail_RadioButton.Location = New System.Drawing.Point(22, 320)
        Me.DontPromptForEmail_RadioButton.Name = "DontPromptForEmail_RadioButton"
        Me.DontPromptForEmail_RadioButton.Size = New System.Drawing.Size(130, 17)
        Me.DontPromptForEmail_RadioButton.TabIndex = 159
        Me.DontPromptForEmail_RadioButton.TabStop = True
        Me.DontPromptForEmail_RadioButton.Text = "Dont Prompt For Email"
        Me.DontPromptForEmail_RadioButton.UseVisualStyleBackColor = True
        '
        'DontPromptForEmailAndSend_RadioButton
        '
        Me.DontPromptForEmailAndSend_RadioButton.AutoSize = True
        Me.DontPromptForEmailAndSend_RadioButton.Location = New System.Drawing.Point(22, 366)
        Me.DontPromptForEmailAndSend_RadioButton.Name = "DontPromptForEmailAndSend_RadioButton"
        Me.DontPromptForEmailAndSend_RadioButton.Size = New System.Drawing.Size(153, 17)
        Me.DontPromptForEmailAndSend_RadioButton.TabIndex = 159
        Me.DontPromptForEmailAndSend_RadioButton.TabStop = True
        Me.DontPromptForEmailAndSend_RadioButton.Text = "Prompt For Email and Send"
        Me.DontPromptForEmailAndSend_RadioButton.UseVisualStyleBackColor = True
        '
        'EmailSetupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 401)
        Me.Controls.Add(Me.DontPromptForEmailAndSend_RadioButton)
        Me.Controls.Add(Me.DontPromptForEmail_RadioButton)
        Me.Controls.Add(Me.PromptForEmailOnly_RadioButton)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.UseMasterListCheckbox)
        Me.Controls.Add(Me.Form2closeNoSavebutton)
        Me.Controls.Add(Me.Button_SaveAsDefault2)
        Me.Controls.Add(Me.AdLabel2)
        Me.Controls.Add(Me.EmailMasterListFilename)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.IncludeAdCheckBox)
        Me.Name = "EmailSetupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email Configuration Editor"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_SaveAsDefault2 As System.Windows.Forms.Button
    Friend WithEvents Form2closeNoSavebutton As System.Windows.Forms.Button
    Friend WithEvents EmailMasterListFilename As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents IncludeAdCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AdLabel2 As System.Windows.Forms.Label
    Friend WithEvents UseMasterListCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents ConfigButton1 As System.Windows.Forms.Button
    Friend WithEvents ConfigButton2 As System.Windows.Forms.Button
    Friend WithEvents CompNameLabel As System.Windows.Forms.Label
    Friend WithEvents CompEmaillabel As System.Windows.Forms.Label
    Friend WithEvents textBox_MailServer As System.Windows.Forms.TextBox
    Friend WithEvents label4_outgoing As System.Windows.Forms.Label
    Friend WithEvents textBox_Username As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents textBox_Password As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PortBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7_port As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents SSLcheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Checkbox_CheckForIntConnectYesNo As System.Windows.Forms.CheckBox
    Friend WithEvents PostEmailPrompt_CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CurrentConfigLabel As System.Windows.Forms.Label
    Friend WithEvents CompNameTextbox As System.Windows.Forms.TextBox
    Friend WithEvents CompEmailTextbox As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox_ConfirmationEmail As System.Windows.Forms.CheckBox
    Friend WithEvents EmailCombineCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PromptButDelaySendingCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents PromptForEmailOnly_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents DontPromptForEmail_RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents DontPromptForEmailAndSend_RadioButton As System.Windows.Forms.RadioButton
End Class
