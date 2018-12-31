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
        Me.components = New System.ComponentModel.Container()
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
        Me.PromptForEmailAndSend_CheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.NotifyBoxLocationGroupBox = New System.Windows.Forms.GroupBox()
        Me.LowerLeftRadioButton = New System.Windows.Forms.RadioButton()
        Me.LowerRightRadioButton = New System.Windows.Forms.RadioButton()
        Me.UpperLeftRadioButton = New System.Windows.Forms.RadioButton()
        Me.UpperRightRadioButton = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.AttachFilesYesNoCheckbox = New System.Windows.Forms.CheckBox()
        Me.DontPromptForEmail_AddviaDarkroom_Checkbox = New System.Windows.Forms.CheckBox()
        Me.PromptForEmailDontSend_CheckBox = New System.Windows.Forms.CheckBox()
        Me.CheckBox_ConfirmationEmail = New System.Windows.Forms.CheckBox()
        Me.EmailCombineCheckBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ConfigButton0 = New System.Windows.Forms.Button()
        Me.ConfigButton4 = New System.Windows.Forms.Button()
        Me.ConfigButton3 = New System.Windows.Forms.Button()
        Me.CurrentConfigLabel = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CompEmailTextbox = New System.Windows.Forms.TextBox()
        Me.CompNameTextbox = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SettingsGroupBox = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.NotifyBoxLocationGroupBox.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SettingsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button_SaveAsDefault2
        '
        Me.Button_SaveAsDefault2.Location = New System.Drawing.Point(538, 457)
        Me.Button_SaveAsDefault2.Name = "Button_SaveAsDefault2"
        Me.Button_SaveAsDefault2.Size = New System.Drawing.Size(99, 23)
        Me.Button_SaveAsDefault2.TabIndex = 4
        Me.Button_SaveAsDefault2.Text = "Save and Close"
        Me.Button_SaveAsDefault2.UseVisualStyleBackColor = True
        '
        'Form2closeNoSavebutton
        '
        Me.Form2closeNoSavebutton.Location = New System.Drawing.Point(697, 457)
        Me.Form2closeNoSavebutton.Name = "Form2closeNoSavebutton"
        Me.Form2closeNoSavebutton.Size = New System.Drawing.Size(121, 23)
        Me.Form2closeNoSavebutton.TabIndex = 5
        Me.Form2closeNoSavebutton.Text = "Close without saving"
        Me.Form2closeNoSavebutton.UseVisualStyleBackColor = True
        '
        'EmailMasterListFilename
        '
        Me.EmailMasterListFilename.Location = New System.Drawing.Point(449, 365)
        Me.EmailMasterListFilename.Name = "EmailMasterListFilename"
        Me.EmailMasterListFilename.ReadOnly = True
        Me.EmailMasterListFilename.Size = New System.Drawing.Size(322, 20)
        Me.EmailMasterListFilename.TabIndex = 2
        Me.EmailMasterListFilename.Text = "C:\EventPhotoEmailer\EmailMasterList.txt"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(777, 363)
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
        Me.Button3.Location = New System.Drawing.Point(777, 317)
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
        Me.IncludeAdCheckBox.Location = New System.Drawing.Point(449, 297)
        Me.IncludeAdCheckBox.Name = "IncludeAdCheckBox"
        Me.IncludeAdCheckBox.Size = New System.Drawing.Size(156, 17)
        Me.IncludeAdCheckBox.TabIndex = 138
        Me.IncludeAdCheckBox.Text = "Include Advertisement File?"
        Me.IncludeAdCheckBox.UseVisualStyleBackColor = True
        '
        'AdLabel2
        '
        Me.AdLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AdLabel2.Location = New System.Drawing.Point(449, 317)
        Me.AdLabel2.Name = "AdLabel2"
        Me.AdLabel2.Size = New System.Drawing.Size(322, 20)
        Me.AdLabel2.TabIndex = 0
        '
        'UseMasterListCheckbox
        '
        Me.UseMasterListCheckbox.AutoSize = True
        Me.UseMasterListCheckbox.Checked = True
        Me.UseMasterListCheckbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.UseMasterListCheckbox.Location = New System.Drawing.Point(449, 343)
        Me.UseMasterListCheckbox.Name = "UseMasterListCheckbox"
        Me.UseMasterListCheckbox.Size = New System.Drawing.Size(149, 17)
        Me.UseMasterListCheckbox.TabIndex = 140
        Me.UseMasterListCheckbox.Text = "Update Email Master List?"
        Me.UseMasterListCheckbox.UseVisualStyleBackColor = True
        '
        'ConfigButton1
        '
        Me.ConfigButton1.Location = New System.Drawing.Point(166, 15)
        Me.ConfigButton1.Name = "ConfigButton1"
        Me.ConfigButton1.Size = New System.Drawing.Size(109, 23)
        Me.ConfigButton1.TabIndex = 142
        Me.ConfigButton1.Text = "Configuration 1"
        Me.ConfigButton1.UseVisualStyleBackColor = True
        '
        'ConfigButton2
        '
        Me.ConfigButton2.Location = New System.Drawing.Point(290, 15)
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
        Me.Checkbox_CheckForIntConnectYesNo.Location = New System.Drawing.Point(98, 238)
        Me.Checkbox_CheckForIntConnectYesNo.Name = "Checkbox_CheckForIntConnectYesNo"
        Me.Checkbox_CheckForIntConnectYesNo.Size = New System.Drawing.Size(242, 17)
        Me.Checkbox_CheckForIntConnectYesNo.TabIndex = 8
        Me.Checkbox_CheckForIntConnectYesNo.Text = "Check for internet connection before sending."
        Me.ToolTip1.SetToolTip(Me.Checkbox_CheckForIntConnectYesNo, "A check for a valid internet connection is done prior to sending emails. This can" & _
        " cause a delay in being prompted to enter email addresses. Check this box if the" & _
        "re is a reliable internet connection.")
        Me.Checkbox_CheckForIntConnectYesNo.UseVisualStyleBackColor = True
        '
        'PromptForEmailAndSend_CheckBox
        '
        Me.PromptForEmailAndSend_CheckBox.AutoSize = True
        Me.PromptForEmailAndSend_CheckBox.Location = New System.Drawing.Point(8, 22)
        Me.PromptForEmailAndSend_CheckBox.Name = "PromptForEmailAndSend_CheckBox"
        Me.PromptForEmailAndSend_CheckBox.Size = New System.Drawing.Size(192, 17)
        Me.PromptForEmailAndSend_CheckBox.TabIndex = 9
        Me.PromptForEmailAndSend_CheckBox.Text = "Prompt for Email Address and Send"
        Me.PromptForEmailAndSend_CheckBox.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NotifyBoxLocationGroupBox)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.CheckBox_ConfirmationEmail)
        Me.GroupBox1.Controls.Add(Me.EmailCombineCheckBox)
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
        Me.GroupBox1.Location = New System.Drawing.Point(25, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 479)
        Me.GroupBox1.TabIndex = 156
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Email Configuration"
        '
        'NotifyBoxLocationGroupBox
        '
        Me.NotifyBoxLocationGroupBox.Controls.Add(Me.LowerLeftRadioButton)
        Me.NotifyBoxLocationGroupBox.Controls.Add(Me.LowerRightRadioButton)
        Me.NotifyBoxLocationGroupBox.Controls.Add(Me.UpperLeftRadioButton)
        Me.NotifyBoxLocationGroupBox.Controls.Add(Me.UpperRightRadioButton)
        Me.NotifyBoxLocationGroupBox.Location = New System.Drawing.Point(4, 385)
        Me.NotifyBoxLocationGroupBox.Name = "NotifyBoxLocationGroupBox"
        Me.NotifyBoxLocationGroupBox.Size = New System.Drawing.Size(398, 53)
        Me.NotifyBoxLocationGroupBox.TabIndex = 160
        Me.NotifyBoxLocationGroupBox.TabStop = False
        Me.NotifyBoxLocationGroupBox.Text = "Email Notification Box Location"
        '
        'LowerLeftRadioButton
        '
        Me.LowerLeftRadioButton.AutoSize = True
        Me.LowerLeftRadioButton.Location = New System.Drawing.Point(181, 23)
        Me.LowerLeftRadioButton.Name = "LowerLeftRadioButton"
        Me.LowerLeftRadioButton.Size = New System.Drawing.Size(75, 17)
        Me.LowerLeftRadioButton.TabIndex = 159
        Me.LowerLeftRadioButton.Text = "Lower Left"
        Me.LowerLeftRadioButton.UseVisualStyleBackColor = True
        '
        'LowerRightRadioButton
        '
        Me.LowerRightRadioButton.AutoSize = True
        Me.LowerRightRadioButton.Location = New System.Drawing.Point(274, 23)
        Me.LowerRightRadioButton.Name = "LowerRightRadioButton"
        Me.LowerRightRadioButton.Size = New System.Drawing.Size(82, 17)
        Me.LowerRightRadioButton.TabIndex = 159
        Me.LowerRightRadioButton.Text = "Lower Right"
        Me.LowerRightRadioButton.UseVisualStyleBackColor = True
        '
        'UpperLeftRadioButton
        '
        Me.UpperLeftRadioButton.AutoSize = True
        Me.UpperLeftRadioButton.Location = New System.Drawing.Point(100, 23)
        Me.UpperLeftRadioButton.Name = "UpperLeftRadioButton"
        Me.UpperLeftRadioButton.Size = New System.Drawing.Size(75, 17)
        Me.UpperLeftRadioButton.TabIndex = 159
        Me.UpperLeftRadioButton.Text = "Upper Left"
        Me.UpperLeftRadioButton.UseVisualStyleBackColor = True
        '
        'UpperRightRadioButton
        '
        Me.UpperRightRadioButton.AutoSize = True
        Me.UpperRightRadioButton.Checked = True
        Me.UpperRightRadioButton.Location = New System.Drawing.Point(4, 23)
        Me.UpperRightRadioButton.Name = "UpperRightRadioButton"
        Me.UpperRightRadioButton.Size = New System.Drawing.Size(82, 17)
        Me.UpperRightRadioButton.TabIndex = 159
        Me.UpperRightRadioButton.TabStop = True
        Me.UpperRightRadioButton.Text = "Upper Right"
        Me.UpperRightRadioButton.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.AttachFilesYesNoCheckbox)
        Me.GroupBox4.Controls.Add(Me.DontPromptForEmail_AddviaDarkroom_Checkbox)
        Me.GroupBox4.Controls.Add(Me.PromptForEmailDontSend_CheckBox)
        Me.GroupBox4.Controls.Add(Me.PromptForEmailAndSend_CheckBox)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 265)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(330, 114)
        Me.GroupBox4.TabIndex = 123
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Email Delay Options"
        '
        'AttachFilesYesNoCheckbox
        '
        Me.AttachFilesYesNoCheckbox.AutoSize = True
        Me.AttachFilesYesNoCheckbox.Location = New System.Drawing.Point(8, 90)
        Me.AttachFilesYesNoCheckbox.Name = "AttachFilesYesNoCheckbox"
        Me.AttachFilesYesNoCheckbox.Size = New System.Drawing.Size(170, 17)
        Me.AttachFilesYesNoCheckbox.TabIndex = 123
        Me.AttachFilesYesNoCheckbox.Text = "Send Images as Attachments?"
        Me.AttachFilesYesNoCheckbox.UseVisualStyleBackColor = True
        '
        'DontPromptForEmail_AddviaDarkroom_Checkbox
        '
        Me.DontPromptForEmail_AddviaDarkroom_Checkbox.AutoSize = True
        Me.DontPromptForEmail_AddviaDarkroom_Checkbox.Location = New System.Drawing.Point(8, 67)
        Me.DontPromptForEmail_AddviaDarkroom_Checkbox.Name = "DontPromptForEmail_AddviaDarkroom_Checkbox"
        Me.DontPromptForEmail_AddviaDarkroom_Checkbox.Size = New System.Drawing.Size(303, 17)
        Me.DontPromptForEmail_AddviaDarkroom_Checkbox.TabIndex = 122
        Me.DontPromptForEmail_AddviaDarkroom_Checkbox.Text = "Do Not Prompt For Email - Add Email Via Darkroom Instead"
        Me.DontPromptForEmail_AddviaDarkroom_Checkbox.UseVisualStyleBackColor = True
        '
        'PromptForEmailDontSend_CheckBox
        '
        Me.PromptForEmailDontSend_CheckBox.AutoSize = True
        Me.PromptForEmailDontSend_CheckBox.Location = New System.Drawing.Point(8, 45)
        Me.PromptForEmailDontSend_CheckBox.Name = "PromptForEmailDontSend_CheckBox"
        Me.PromptForEmailDontSend_CheckBox.Size = New System.Drawing.Size(208, 17)
        Me.PromptForEmailDontSend_CheckBox.TabIndex = 121
        Me.PromptForEmailDontSend_CheckBox.Text = "Prompt For Email Address - Don't Send"
        Me.PromptForEmailDontSend_CheckBox.UseVisualStyleBackColor = True
        '
        'CheckBox_ConfirmationEmail
        '
        Me.CheckBox_ConfirmationEmail.AutoSize = True
        Me.CheckBox_ConfirmationEmail.Location = New System.Drawing.Point(15, 204)
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
        Me.GroupBox2.Controls.Add(Me.ConfigButton0)
        Me.GroupBox2.Controls.Add(Me.ConfigButton4)
        Me.GroupBox2.Controls.Add(Me.ConfigButton3)
        Me.GroupBox2.Controls.Add(Me.CurrentConfigLabel)
        Me.GroupBox2.Controls.Add(Me.ConfigButton2)
        Me.GroupBox2.Controls.Add(Me.ConfigButton1)
        Me.GroupBox2.Location = New System.Drawing.Point(448, 170)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(420, 117)
        Me.GroupBox2.TabIndex = 157
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configuration Selection"
        '
        'ConfigButton0
        '
        Me.ConfigButton0.Location = New System.Drawing.Point(9, 49)
        Me.ConfigButton0.Name = "ConfigButton0"
        Me.ConfigButton0.Size = New System.Drawing.Size(148, 23)
        Me.ConfigButton0.TabIndex = 147
        Me.ConfigButton0.Text = "Default Configuration"
        Me.ConfigButton0.UseVisualStyleBackColor = True
        '
        'ConfigButton4
        '
        Me.ConfigButton4.Location = New System.Drawing.Point(290, 81)
        Me.ConfigButton4.Name = "ConfigButton4"
        Me.ConfigButton4.Size = New System.Drawing.Size(109, 23)
        Me.ConfigButton4.TabIndex = 146
        Me.ConfigButton4.Text = "Configuration 4"
        Me.ConfigButton4.UseVisualStyleBackColor = True
        '
        'ConfigButton3
        '
        Me.ConfigButton3.Location = New System.Drawing.Point(166, 81)
        Me.ConfigButton3.Name = "ConfigButton3"
        Me.ConfigButton3.Size = New System.Drawing.Size(109, 23)
        Me.ConfigButton3.TabIndex = 145
        Me.ConfigButton3.Text = "Configuration 3"
        Me.ConfigButton3.UseVisualStyleBackColor = True
        '
        'CurrentConfigLabel
        '
        Me.CurrentConfigLabel.AutoSize = True
        Me.CurrentConfigLabel.Location = New System.Drawing.Point(221, 54)
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
        Me.GroupBox3.Location = New System.Drawing.Point(449, 32)
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
        'SettingsGroupBox
        '
        Me.SettingsGroupBox.Controls.Add(Me.GroupBox3)
        Me.SettingsGroupBox.Controls.Add(Me.GroupBox2)
        Me.SettingsGroupBox.Controls.Add(Me.GroupBox1)
        Me.SettingsGroupBox.Controls.Add(Me.UseMasterListCheckbox)
        Me.SettingsGroupBox.Controls.Add(Me.Form2closeNoSavebutton)
        Me.SettingsGroupBox.Controls.Add(Me.Button_SaveAsDefault2)
        Me.SettingsGroupBox.Controls.Add(Me.AdLabel2)
        Me.SettingsGroupBox.Controls.Add(Me.EmailMasterListFilename)
        Me.SettingsGroupBox.Controls.Add(Me.Button2)
        Me.SettingsGroupBox.Controls.Add(Me.Button3)
        Me.SettingsGroupBox.Controls.Add(Me.IncludeAdCheckBox)
        Me.SettingsGroupBox.Location = New System.Drawing.Point(2, 1)
        Me.SettingsGroupBox.Name = "SettingsGroupBox"
        Me.SettingsGroupBox.Size = New System.Drawing.Size(876, 516)
        Me.SettingsGroupBox.TabIndex = 159
        Me.SettingsGroupBox.TabStop = False
        Me.SettingsGroupBox.Text = "Settings"
        '
        'EmailSetupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 589)
        Me.Controls.Add(Me.SettingsGroupBox)
        Me.Name = "EmailSetupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email Configuration Editor"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.NotifyBoxLocationGroupBox.ResumeLayout(False)
        Me.NotifyBoxLocationGroupBox.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.SettingsGroupBox.ResumeLayout(False)
        Me.SettingsGroupBox.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents PromptForEmailAndSend_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CurrentConfigLabel As System.Windows.Forms.Label
    Friend WithEvents CompNameTextbox As System.Windows.Forms.TextBox
    Friend WithEvents CompEmailTextbox As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox_ConfirmationEmail As System.Windows.Forms.CheckBox
    Friend WithEvents EmailCombineCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PromptForEmailDontSend_CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DontPromptForEmail_AddviaDarkroom_Checkbox As System.Windows.Forms.CheckBox
    Friend WithEvents NotifyBoxLocationGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents LowerRightRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents UpperLeftRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents UpperRightRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents LowerLeftRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AttachFilesYesNoCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents ConfigButton4 As System.Windows.Forms.Button
    Friend WithEvents ConfigButton3 As System.Windows.Forms.Button
    Friend WithEvents ConfigButton0 As System.Windows.Forms.Button
    Friend WithEvents SettingsGroupBox As System.Windows.Forms.GroupBox
End Class
