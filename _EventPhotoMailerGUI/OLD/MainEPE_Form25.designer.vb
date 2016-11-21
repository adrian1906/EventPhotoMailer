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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GoButton = New System.Windows.Forms.Button
        Me.label5_PW = New System.Windows.Forms.Label
        Me.textBox_Password = New System.Windows.Forms.TextBox
        Me.label6_username = New System.Windows.Forms.Label
        Me.textBox_Username = New System.Windows.Forms.TextBox
        Me.label4_outgoing = New System.Windows.Forms.Label
        Me.textBox_MailServer = New System.Windows.Forms.TextBox
        Me.label3_subject = New System.Windows.Forms.Label
        Me.textBox_SubjectLine = New System.Windows.Forms.TextBox
        Me.label2_message = New System.Windows.Forms.Label
        Me.textBox_messagefile = New System.Windows.Forms.TextBox
        Me.label1_FileLocation = New System.Windows.Forms.Label
        Me.Textbox_imagefolder = New System.Windows.Forms.TextBox
        Me.Credit = New System.Windows.Forms.Label
        Me.Title = New System.Windows.Forms.Label
        Me.FolderBrowserDialog_image_location = New System.Windows.Forms.FolderBrowserDialog
        Me.OpenFileDialog1_message_location = New System.Windows.Forms.OpenFileDialog
        Me.CheckBox2_emailfilename = New System.Windows.Forms.CheckBox
        Me.Button1_browse_image_location = New System.Windows.Forms.Button
        Me.Button2_browse_message_file = New System.Windows.Forms.Button
        Me.EmailFilenameList = New System.Windows.Forms.TextBox
        Me.Button3_browse_email_filename = New System.Windows.Forms.Button
        Me.OpenFileDialog2_emaillist = New System.Windows.Forms.OpenFileDialog
        Me.Button4_browse_PD = New System.Windows.Forms.Button
        Me.Label8_PD = New System.Windows.Forms.Label
        Me.FolderBrowserDialog2_ProgramDirectory = New System.Windows.Forms.FolderBrowserDialog
        Me.Label9_EmailListDescription = New System.Windows.Forms.Label
        Me.PictureBox1_logo = New System.Windows.Forms.PictureBox
        Me.ProgDir2 = New System.Windows.Forms.TextBox
        Me.PortBox = New System.Windows.Forms.TextBox
        Me.Label7_port = New System.Windows.Forms.Label
        Me.Button_SaveAsDefault = New System.Windows.Forms.Button
        Me.StatusBox = New System.Windows.Forms.TextBox
        Me.StatusLabel = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.CustomerInfo = New System.Windows.Forms.Label
        Me.VersionLabel = New System.Windows.Forms.Label
        Me.CheckBox_DeleteWorkingFiles = New System.Windows.Forms.CheckBox
        Me.CancelButton1 = New System.Windows.Forms.Button
        Me.HiddenButton1 = New System.Windows.Forms.Button
        Me.MonitorFolderCheckBox = New System.Windows.Forms.CheckBox
        Me.ignoreJPG = New System.Windows.Forms.CheckBox
        CType(Me.PictureBox1_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GoButton
        '
        Me.GoButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GoButton.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GoButton.ForeColor = System.Drawing.Color.Black
        Me.GoButton.Location = New System.Drawing.Point(397, 393)
        Me.GoButton.Name = "GoButton"
        Me.GoButton.Size = New System.Drawing.Size(292, 49)
        Me.GoButton.TabIndex = 42
        Me.GoButton.Text = "SEND EMAILS"
        Me.GoButton.UseVisualStyleBackColor = False
        '
        'label5_PW
        '
        Me.label5_PW.AutoSize = True
        Me.label5_PW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5_PW.Location = New System.Drawing.Point(19, 321)
        Me.label5_PW.Name = "label5_PW"
        Me.label5_PW.Size = New System.Drawing.Size(65, 13)
        Me.label5_PW.TabIndex = 39
        Me.label5_PW.Text = "Password:"
        '
        'textBox_Password
        '
        Me.textBox_Password.Location = New System.Drawing.Point(22, 337)
        Me.textBox_Password.Name = "textBox_Password"
        Me.textBox_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textBox_Password.Size = New System.Drawing.Size(267, 20)
        Me.textBox_Password.TabIndex = 38
        Me.textBox_Password.UseSystemPasswordChar = True
        '
        'label6_username
        '
        Me.label6_username.AutoSize = True
        Me.label6_username.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6_username.Location = New System.Drawing.Point(19, 273)
        Me.label6_username.Name = "label6_username"
        Me.label6_username.Size = New System.Drawing.Size(67, 13)
        Me.label6_username.TabIndex = 37
        Me.label6_username.Text = "Username:"
        '
        'textBox_Username
        '
        Me.textBox_Username.Location = New System.Drawing.Point(22, 289)
        Me.textBox_Username.Name = "textBox_Username"
        Me.textBox_Username.Size = New System.Drawing.Size(267, 20)
        Me.textBox_Username.TabIndex = 36
        '
        'label4_outgoing
        '
        Me.label4_outgoing.AutoSize = True
        Me.label4_outgoing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4_outgoing.Location = New System.Drawing.Point(19, 225)
        Me.label4_outgoing.Name = "label4_outgoing"
        Me.label4_outgoing.Size = New System.Drawing.Size(137, 13)
        Me.label4_outgoing.TabIndex = 35
        Me.label4_outgoing.Text = "Outgoing Email Server:"
        '
        'textBox_MailServer
        '
        Me.textBox_MailServer.Location = New System.Drawing.Point(22, 241)
        Me.textBox_MailServer.Name = "textBox_MailServer"
        Me.textBox_MailServer.Size = New System.Drawing.Size(267, 20)
        Me.textBox_MailServer.TabIndex = 34
        '
        'label3_subject
        '
        Me.label3_subject.AutoSize = True
        Me.label3_subject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3_subject.Location = New System.Drawing.Point(19, 174)
        Me.label3_subject.Name = "label3_subject"
        Me.label3_subject.Size = New System.Drawing.Size(78, 13)
        Me.label3_subject.TabIndex = 33
        Me.label3_subject.Text = "Subject line:"
        '
        'textBox_SubjectLine
        '
        Me.textBox_SubjectLine.Location = New System.Drawing.Point(22, 192)
        Me.textBox_SubjectLine.Name = "textBox_SubjectLine"
        Me.textBox_SubjectLine.Size = New System.Drawing.Size(267, 20)
        Me.textBox_SubjectLine.TabIndex = 32
        '
        'label2_message
        '
        Me.label2_message.AutoSize = True
        Me.label2_message.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2_message.Location = New System.Drawing.Point(19, 128)
        Me.label2_message.Name = "label2_message"
        Me.label2_message.Size = New System.Drawing.Size(190, 13)
        Me.label2_message.TabIndex = 31
        Me.label2_message.Text = "Location of Message Document:"
        '
        'textBox_messagefile
        '
        Me.textBox_messagefile.Location = New System.Drawing.Point(22, 144)
        Me.textBox_messagefile.Name = "textBox_messagefile"
        Me.textBox_messagefile.Size = New System.Drawing.Size(267, 20)
        Me.textBox_messagefile.TabIndex = 30
        '
        'label1_FileLocation
        '
        Me.label1_FileLocation.AutoSize = True
        Me.label1_FileLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1_FileLocation.Location = New System.Drawing.Point(19, 80)
        Me.label1_FileLocation.Name = "label1_FileLocation"
        Me.label1_FileLocation.Size = New System.Drawing.Size(143, 13)
        Me.label1_FileLocation.TabIndex = 29
        Me.label1_FileLocation.Text = "Location of Image Files:"
        '
        'Textbox_imagefolder
        '
        Me.Textbox_imagefolder.Location = New System.Drawing.Point(22, 96)
        Me.Textbox_imagefolder.Name = "Textbox_imagefolder"
        Me.Textbox_imagefolder.Size = New System.Drawing.Size(267, 20)
        Me.Textbox_imagefolder.TabIndex = 28
        '
        'Credit
        '
        Me.Credit.AutoSize = True
        Me.Credit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Credit.Location = New System.Drawing.Point(220, 3)
        Me.Credit.Name = "Credit"
        Me.Credit.Size = New System.Drawing.Size(123, 13)
        Me.Credit.TabIndex = 25
        Me.Credit.Text = "Created by: Adrian Hood"
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.Location = New System.Drawing.Point(17, 2)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(207, 25)
        Me.Title.TabIndex = 24
        Me.Title.Text = "Event Photo Emailer"
        '
        'FolderBrowserDialog_image_location
        '
        Me.FolderBrowserDialog_image_location.SelectedPath = "c:\EPE"
        '
        'OpenFileDialog1_message_location
        '
        Me.OpenFileDialog1_message_location.InitialDirectory = "c:\EPE"
        '
        'CheckBox2_emailfilename
        '
        Me.CheckBox2_emailfilename.AutoSize = True
        Me.CheckBox2_emailfilename.Location = New System.Drawing.Point(22, 373)
        Me.CheckBox2_emailfilename.Name = "CheckBox2_emailfilename"
        Me.CheckBox2_emailfilename.Size = New System.Drawing.Size(165, 17)
        Me.CheckBox2_emailfilename.TabIndex = 47
        Me.CheckBox2_emailfilename.Text = "Use email/filename directory?"
        Me.CheckBox2_emailfilename.UseVisualStyleBackColor = True
        '
        'Button1_browse_image_location
        '
        Me.Button1_browse_image_location.Location = New System.Drawing.Point(295, 94)
        Me.Button1_browse_image_location.Name = "Button1_browse_image_location"
        Me.Button1_browse_image_location.Size = New System.Drawing.Size(75, 23)
        Me.Button1_browse_image_location.TabIndex = 48
        Me.Button1_browse_image_location.Text = "Browse"
        Me.Button1_browse_image_location.UseVisualStyleBackColor = True
        '
        'Button2_browse_message_file
        '
        Me.Button2_browse_message_file.Location = New System.Drawing.Point(296, 144)
        Me.Button2_browse_message_file.Name = "Button2_browse_message_file"
        Me.Button2_browse_message_file.Size = New System.Drawing.Size(75, 23)
        Me.Button2_browse_message_file.TabIndex = 49
        Me.Button2_browse_message_file.Text = "Browse"
        Me.Button2_browse_message_file.UseVisualStyleBackColor = True
        '
        'EmailFilenameList
        '
        Me.EmailFilenameList.BackColor = System.Drawing.SystemColors.Info
        Me.EmailFilenameList.Location = New System.Drawing.Point(22, 422)
        Me.EmailFilenameList.Name = "EmailFilenameList"
        Me.EmailFilenameList.Size = New System.Drawing.Size(267, 20)
        Me.EmailFilenameList.TabIndex = 50
        Me.EmailFilenameList.Visible = False
        '
        'Button3_browse_email_filename
        '
        Me.Button3_browse_email_filename.Location = New System.Drawing.Point(295, 422)
        Me.Button3_browse_email_filename.Name = "Button3_browse_email_filename"
        Me.Button3_browse_email_filename.Size = New System.Drawing.Size(75, 23)
        Me.Button3_browse_email_filename.TabIndex = 51
        Me.Button3_browse_email_filename.Text = "Browse"
        Me.Button3_browse_email_filename.UseVisualStyleBackColor = True
        Me.Button3_browse_email_filename.Visible = False
        '
        'OpenFileDialog2_emaillist
        '
        Me.OpenFileDialog2_emaillist.InitialDirectory = "c:\EPE"
        '
        'Button4_browse_PD
        '
        Me.Button4_browse_PD.Location = New System.Drawing.Point(508, 45)
        Me.Button4_browse_PD.Name = "Button4_browse_PD"
        Me.Button4_browse_PD.Size = New System.Drawing.Size(54, 23)
        Me.Button4_browse_PD.TabIndex = 54
        Me.Button4_browse_PD.Text = "Browse"
        Me.Button4_browse_PD.UseVisualStyleBackColor = True
        '
        'Label8_PD
        '
        Me.Label8_PD.AutoSize = True
        Me.Label8_PD.Location = New System.Drawing.Point(276, 49)
        Me.Label8_PD.Name = "Label8_PD"
        Me.Label8_PD.Size = New System.Drawing.Size(94, 13)
        Me.Label8_PD.TabIndex = 53
        Me.Label8_PD.Text = "Program Directory:"
        '
        'FolderBrowserDialog2_ProgramDirectory
        '
        Me.FolderBrowserDialog2_ProgramDirectory.Description = "Description Here"
        '
        'Label9_EmailListDescription
        '
        Me.Label9_EmailListDescription.AutoSize = True
        Me.Label9_EmailListDescription.Location = New System.Drawing.Point(41, 393)
        Me.Label9_EmailListDescription.Name = "Label9_EmailListDescription"
        Me.Label9_EmailListDescription.Size = New System.Drawing.Size(329, 26)
        Me.Label9_EmailListDescription.TabIndex = 55
        Me.Label9_EmailListDescription.Text = "If so, this list must have the following format (separated by a comma):" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1st Colu" & _
            "mn: Filename , 2nd Column: Email Address (No Header)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'PictureBox1_logo
        '
        Me.PictureBox1_logo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1_logo.Image = Global.WindowsApplication1.My.Resources.Resources.EPEicon
        Me.PictureBox1_logo.Location = New System.Drawing.Point(621, 20)
        Me.PictureBox1_logo.Name = "PictureBox1_logo"
        Me.PictureBox1_logo.Size = New System.Drawing.Size(68, 68)
        Me.PictureBox1_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1_logo.TabIndex = 56
        Me.PictureBox1_logo.TabStop = False
        '
        'ProgDir2
        '
        Me.ProgDir2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgDir2.Location = New System.Drawing.Point(370, 47)
        Me.ProgDir2.Name = "ProgDir2"
        Me.ProgDir2.Size = New System.Drawing.Size(132, 20)
        Me.ProgDir2.TabIndex = 57
        Me.ProgDir2.Text = "c:\EPE"
        '
        'PortBox
        '
        Me.PortBox.Location = New System.Drawing.Point(295, 241)
        Me.PortBox.Name = "PortBox"
        Me.PortBox.Size = New System.Drawing.Size(41, 20)
        Me.PortBox.TabIndex = 58
        Me.PortBox.Text = "25"
        '
        'Label7_port
        '
        Me.Label7_port.AutoSize = True
        Me.Label7_port.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7_port.Location = New System.Drawing.Point(293, 225)
        Me.Label7_port.Name = "Label7_port"
        Me.Label7_port.Size = New System.Drawing.Size(30, 13)
        Me.Label7_port.TabIndex = 59
        Me.Label7_port.Text = "Port"
        '
        'Button_SaveAsDefault
        '
        Me.Button_SaveAsDefault.Location = New System.Drawing.Point(22, 42)
        Me.Button_SaveAsDefault.Name = "Button_SaveAsDefault"
        Me.Button_SaveAsDefault.Size = New System.Drawing.Size(227, 25)
        Me.Button_SaveAsDefault.TabIndex = 62
        Me.Button_SaveAsDefault.Text = "Click here to save settings as the default."
        Me.Button_SaveAsDefault.UseVisualStyleBackColor = True
        '
        'StatusBox
        '
        Me.StatusBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBox.Location = New System.Drawing.Point(397, 96)
        Me.StatusBox.Multiline = True
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.StatusBox.Size = New System.Drawing.Size(292, 213)
        Me.StatusBox.TabIndex = 64
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabel.Location = New System.Drawing.Point(504, 75)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(78, 20)
        Me.StatusLabel.TabIndex = 65
        Me.StatusLabel.Text = "STATUS"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(397, 315)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(293, 17)
        Me.ProgressBar1.TabIndex = 66
        '
        'CustomerInfo
        '
        Me.CustomerInfo.AutoSize = True
        Me.CustomerInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerInfo.Location = New System.Drawing.Point(220, 16)
        Me.CustomerInfo.Name = "CustomerInfo"
        Me.CustomerInfo.Size = New System.Drawing.Size(249, 13)
        Me.CustomerInfo.TabIndex = 67
        Me.CustomerInfo.Text = "Created for: Company Name <info@company.com>"
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel.Location = New System.Drawing.Point(19, 23)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(60, 16)
        Me.VersionLabel.TabIndex = 68
        Me.VersionLabel.Text = "Version: "
        '
        'CheckBox_DeleteWorkingFiles
        '
        Me.CheckBox_DeleteWorkingFiles.AutoSize = True
        Me.CheckBox_DeleteWorkingFiles.Location = New System.Drawing.Point(397, 370)
        Me.CheckBox_DeleteWorkingFiles.Name = "CheckBox_DeleteWorkingFiles"
        Me.CheckBox_DeleteWorkingFiles.Size = New System.Drawing.Size(124, 17)
        Me.CheckBox_DeleteWorkingFiles.TabIndex = 69
        Me.CheckBox_DeleteWorkingFiles.Text = "Delete working files?"
        Me.CheckBox_DeleteWorkingFiles.UseVisualStyleBackColor = True
        '
        'CancelButton1
        '
        Me.CancelButton1.Location = New System.Drawing.Point(614, 338)
        Me.CancelButton1.Name = "CancelButton1"
        Me.CancelButton1.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton1.TabIndex = 72
        Me.CancelButton1.Text = "CANCEL"
        Me.CancelButton1.UseVisualStyleBackColor = True
        '
        'HiddenButton1
        '
        Me.HiddenButton1.Location = New System.Drawing.Point(507, 6)
        Me.HiddenButton1.Name = "HiddenButton1"
        Me.HiddenButton1.Size = New System.Drawing.Size(108, 23)
        Me.HiddenButton1.TabIndex = 73
        Me.HiddenButton1.Text = "HiddenButton"
        Me.HiddenButton1.UseVisualStyleBackColor = True
        Me.HiddenButton1.Visible = False
        '
        'MonitorFolderCheckBox
        '
        Me.MonitorFolderCheckBox.AutoSize = True
        Me.MonitorFolderCheckBox.Location = New System.Drawing.Point(397, 339)
        Me.MonitorFolderCheckBox.Name = "MonitorFolderCheckBox"
        Me.MonitorFolderCheckBox.Size = New System.Drawing.Size(155, 30)
        Me.MonitorFolderCheckBox.TabIndex = 74
        Me.MonitorFolderCheckBox.Text = "Monitor Image Folder and" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Send Emails Automatically?"
        Me.MonitorFolderCheckBox.UseVisualStyleBackColor = True
        '
        'ignoreJPG
        '
        Me.ignoreJPG.AutoSize = True
        Me.ignoreJPG.Location = New System.Drawing.Point(201, 373)
        Me.ignoreJPG.Name = "ignoreJPG"
        Me.ignoreJPG.Size = New System.Drawing.Size(164, 17)
        Me.ignoreJPG.TabIndex = 75
        Me.ignoreJPG.Text = "Do not use "".jpg"" in email list."
        Me.ignoreJPG.UseVisualStyleBackColor = True
        Me.ignoreJPG.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(702, 464)
        Me.Controls.Add(Me.ignoreJPG)
        Me.Controls.Add(Me.MonitorFolderCheckBox)
        Me.Controls.Add(Me.HiddenButton1)
        Me.Controls.Add(Me.CancelButton1)
        Me.Controls.Add(Me.CheckBox_DeleteWorkingFiles)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.CustomerInfo)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.Button_SaveAsDefault)
        Me.Controls.Add(Me.Label7_port)
        Me.Controls.Add(Me.PortBox)
        Me.Controls.Add(Me.ProgDir2)
        Me.Controls.Add(Me.PictureBox1_logo)
        Me.Controls.Add(Me.Label9_EmailListDescription)
        Me.Controls.Add(Me.Button4_browse_PD)
        Me.Controls.Add(Me.Label8_PD)
        Me.Controls.Add(Me.Button3_browse_email_filename)
        Me.Controls.Add(Me.EmailFilenameList)
        Me.Controls.Add(Me.Button2_browse_message_file)
        Me.Controls.Add(Me.Button1_browse_image_location)
        Me.Controls.Add(Me.CheckBox2_emailfilename)
        Me.Controls.Add(Me.GoButton)
        Me.Controls.Add(Me.label5_PW)
        Me.Controls.Add(Me.textBox_Password)
        Me.Controls.Add(Me.label6_username)
        Me.Controls.Add(Me.textBox_Username)
        Me.Controls.Add(Me.label4_outgoing)
        Me.Controls.Add(Me.textBox_MailServer)
        Me.Controls.Add(Me.label3_subject)
        Me.Controls.Add(Me.textBox_SubjectLine)
        Me.Controls.Add(Me.label2_message)
        Me.Controls.Add(Me.textBox_messagefile)
        Me.Controls.Add(Me.label1_FileLocation)
        Me.Controls.Add(Me.Textbox_imagefolder)
        Me.Controls.Add(Me.Credit)
        Me.Controls.Add(Me.Title)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Event Photo Emailer"
        CType(Me.PictureBox1_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents GoButton As System.Windows.Forms.Button
    Private WithEvents label5_PW As System.Windows.Forms.Label
    Private WithEvents textBox_Password As System.Windows.Forms.TextBox
    Private WithEvents label6_username As System.Windows.Forms.Label
    Private WithEvents textBox_Username As System.Windows.Forms.TextBox
    Private WithEvents label4_outgoing As System.Windows.Forms.Label
    Private WithEvents textBox_MailServer As System.Windows.Forms.TextBox
    Private WithEvents label3_subject As System.Windows.Forms.Label
    Private WithEvents textBox_SubjectLine As System.Windows.Forms.TextBox
    Private WithEvents label2_message As System.Windows.Forms.Label
    Private WithEvents textBox_messagefile As System.Windows.Forms.TextBox
    Private WithEvents label1_FileLocation As System.Windows.Forms.Label
    Private WithEvents Textbox_imagefolder As System.Windows.Forms.TextBox
    Private WithEvents Credit As System.Windows.Forms.Label
    Private WithEvents Title As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog_image_location As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1_message_location As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CheckBox2_emailfilename As System.Windows.Forms.CheckBox
    Friend WithEvents Button1_browse_image_location As System.Windows.Forms.Button
    Friend WithEvents Button2_browse_message_file As System.Windows.Forms.Button
    Friend WithEvents EmailFilenameList As System.Windows.Forms.TextBox
    Friend WithEvents Button3_browse_email_filename As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog2_emaillist As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Button4_browse_PD As System.Windows.Forms.Button
    Private WithEvents Label8_PD As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog2_ProgramDirectory As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label9_EmailListDescription As System.Windows.Forms.Label
    Friend WithEvents PictureBox1_logo As System.Windows.Forms.PictureBox
    Friend WithEvents ProgDir2 As System.Windows.Forms.TextBox
    Friend WithEvents PortBox As System.Windows.Forms.TextBox
    Private WithEvents Label7_port As System.Windows.Forms.Label
    Friend WithEvents Button_SaveAsDefault As System.Windows.Forms.Button
    Friend WithEvents StatusBox As System.Windows.Forms.TextBox
    Private WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents CustomerInfo As System.Windows.Forms.Label
    Private WithEvents VersionLabel As System.Windows.Forms.Label
    Friend WithEvents CheckBox_DeleteWorkingFiles As System.Windows.Forms.CheckBox
    Friend WithEvents CancelButton1 As System.Windows.Forms.Button
    Friend WithEvents HiddenButton1 As System.Windows.Forms.Button
    Friend WithEvents MonitorFolderCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ignoreJPG As System.Windows.Forms.CheckBox

End Class
