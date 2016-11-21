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
        Me.components = New System.ComponentModel.Container
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
        Me.Label8_PD = New System.Windows.Forms.Label
        Me.FolderBrowserDialog2_ProgramDirectory = New System.Windows.Forms.FolderBrowserDialog
        Me.Label9_EmailListDescription = New System.Windows.Forms.Label
        Me.ProgDir2 = New System.Windows.Forms.Label
        Me.PortBox = New System.Windows.Forms.TextBox
        Me.Label7_port = New System.Windows.Forms.Label
        Me.Button_SaveAsDefault = New System.Windows.Forms.Button
        Me.StatusBox = New System.Windows.Forms.TextBox
        Me.StatusLabel = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.CustomerInfo = New System.Windows.Forms.Label
        Me.VersionLabel = New System.Windows.Forms.Label
        Me.CancelButton1 = New System.Windows.Forms.Button
        Me.MonitorFolderCheckBox = New System.Windows.Forms.CheckBox
        Me.ignoreJPG = New System.Windows.Forms.CheckBox
        Me.DelayLabel1 = New System.Windows.Forms.Label
        Me.DelayTextBox1 = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SENDINGBUTTON = New System.Windows.Forms.Button
        Me.StoppedButton = New System.Windows.Forms.Button
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip_ForNotificationIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowEPE = New System.Windows.Forms.ToolStripMenuItem
        Me.HideEPE = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitEPE = New System.Windows.Forms.ToolStripMenuItem
        Me.HideButton = New System.Windows.Forms.Button
        Me.CheckBox_ConfirmationEmail = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.ConnectionStatusResultLabel = New System.Windows.Forms.Label
        Me.CheckConnectionTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ClientNameLabel = New System.Windows.Forms.Label
        Me.ClientNameTextBox = New System.Windows.Forms.TextBox
        Me.ClientEmailAddressLabel = New System.Windows.Forms.Label
        Me.ClientEmailAddressTextBox = New System.Windows.Forms.TextBox
        Me.EmailCombineCheckBox = New System.Windows.Forms.CheckBox
        Me.ContextMenuStrip_ForNotificationIcon.SuspendLayout()
        Me.SuspendLayout()
        '
        'GoButton
        '
        Me.GoButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GoButton.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GoButton.ForeColor = System.Drawing.Color.Black
        Me.GoButton.Location = New System.Drawing.Point(397, 463)
        Me.GoButton.Name = "GoButton"
        Me.GoButton.Size = New System.Drawing.Size(371, 30)
        Me.GoButton.TabIndex = 42
        Me.GoButton.Text = "SEND EMAILS"
        Me.GoButton.UseVisualStyleBackColor = False
        '
        'label5_PW
        '
        Me.label5_PW.AutoSize = True
        Me.label5_PW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5_PW.Location = New System.Drawing.Point(19, 364)
        Me.label5_PW.Name = "label5_PW"
        Me.label5_PW.Size = New System.Drawing.Size(65, 13)
        Me.label5_PW.TabIndex = 39
        Me.label5_PW.Text = "Password:"
        '
        'textBox_Password
        '
        Me.textBox_Password.Location = New System.Drawing.Point(22, 380)
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
        Me.label6_username.Location = New System.Drawing.Point(19, 316)
        Me.label6_username.Name = "label6_username"
        Me.label6_username.Size = New System.Drawing.Size(67, 13)
        Me.label6_username.TabIndex = 37
        Me.label6_username.Text = "Username:"
        '
        'textBox_Username
        '
        Me.textBox_Username.Location = New System.Drawing.Point(22, 332)
        Me.textBox_Username.Name = "textBox_Username"
        Me.textBox_Username.Size = New System.Drawing.Size(267, 20)
        Me.textBox_Username.TabIndex = 36
        '
        'label4_outgoing
        '
        Me.label4_outgoing.AutoSize = True
        Me.label4_outgoing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4_outgoing.Location = New System.Drawing.Point(19, 268)
        Me.label4_outgoing.Name = "label4_outgoing"
        Me.label4_outgoing.Size = New System.Drawing.Size(137, 13)
        Me.label4_outgoing.TabIndex = 35
        Me.label4_outgoing.Text = "Outgoing Email Server:"
        '
        'textBox_MailServer
        '
        Me.textBox_MailServer.Location = New System.Drawing.Point(22, 284)
        Me.textBox_MailServer.Name = "textBox_MailServer"
        Me.textBox_MailServer.Size = New System.Drawing.Size(267, 20)
        Me.textBox_MailServer.TabIndex = 34
        '
        'label3_subject
        '
        Me.label3_subject.AutoSize = True
        Me.label3_subject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3_subject.Location = New System.Drawing.Point(19, 217)
        Me.label3_subject.Name = "label3_subject"
        Me.label3_subject.Size = New System.Drawing.Size(78, 13)
        Me.label3_subject.TabIndex = 33
        Me.label3_subject.Text = "Subject line:"
        '
        'textBox_SubjectLine
        '
        Me.textBox_SubjectLine.Location = New System.Drawing.Point(22, 235)
        Me.textBox_SubjectLine.Name = "textBox_SubjectLine"
        Me.textBox_SubjectLine.Size = New System.Drawing.Size(267, 20)
        Me.textBox_SubjectLine.TabIndex = 32
        '
        'label2_message
        '
        Me.label2_message.AutoSize = True
        Me.label2_message.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2_message.Location = New System.Drawing.Point(19, 171)
        Me.label2_message.Name = "label2_message"
        Me.label2_message.Size = New System.Drawing.Size(190, 13)
        Me.label2_message.TabIndex = 31
        Me.label2_message.Text = "Location of Message Document:"
        '
        'textBox_messagefile
        '
        Me.textBox_messagefile.Location = New System.Drawing.Point(22, 187)
        Me.textBox_messagefile.Name = "textBox_messagefile"
        Me.textBox_messagefile.Size = New System.Drawing.Size(267, 20)
        Me.textBox_messagefile.TabIndex = 30
        '
        'label1_FileLocation
        '
        Me.label1_FileLocation.AutoSize = True
        Me.label1_FileLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1_FileLocation.Location = New System.Drawing.Point(19, 123)
        Me.label1_FileLocation.Name = "label1_FileLocation"
        Me.label1_FileLocation.Size = New System.Drawing.Size(143, 13)
        Me.label1_FileLocation.TabIndex = 29
        Me.label1_FileLocation.Text = "Location of Image Files:"
        '
        'Textbox_imagefolder
        '
        Me.Textbox_imagefolder.Location = New System.Drawing.Point(22, 139)
        Me.Textbox_imagefolder.Name = "Textbox_imagefolder"
        Me.Textbox_imagefolder.Size = New System.Drawing.Size(267, 20)
        Me.Textbox_imagefolder.TabIndex = 28
        '
        'Credit
        '
        Me.Credit.AutoSize = True
        Me.Credit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Credit.Location = New System.Drawing.Point(158, 2)
        Me.Credit.Name = "Credit"
        Me.Credit.Size = New System.Drawing.Size(228, 13)
        Me.Credit.TabIndex = 25
        Me.Credit.Text = "Created by: Adrian Hood Engineering Solutions"
        '
        'Title
        '
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.Location = New System.Drawing.Point(17, 2)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(135, 50)
        Me.Title.TabIndex = 24
        Me.Title.Text = "Event Photo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Emailer"
        Me.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.CheckBox2_emailfilename.Location = New System.Drawing.Point(22, 404)
        Me.CheckBox2_emailfilename.Name = "CheckBox2_emailfilename"
        Me.CheckBox2_emailfilename.Size = New System.Drawing.Size(165, 17)
        Me.CheckBox2_emailfilename.TabIndex = 47
        Me.CheckBox2_emailfilename.Text = "Use email/filename directory?"
        Me.CheckBox2_emailfilename.UseVisualStyleBackColor = True
        '
        'Button1_browse_image_location
        '
        Me.Button1_browse_image_location.Location = New System.Drawing.Point(295, 137)
        Me.Button1_browse_image_location.Name = "Button1_browse_image_location"
        Me.Button1_browse_image_location.Size = New System.Drawing.Size(75, 23)
        Me.Button1_browse_image_location.TabIndex = 48
        Me.Button1_browse_image_location.Text = "Browse"
        Me.Button1_browse_image_location.UseVisualStyleBackColor = True
        '
        'Button2_browse_message_file
        '
        Me.Button2_browse_message_file.Location = New System.Drawing.Point(296, 187)
        Me.Button2_browse_message_file.Name = "Button2_browse_message_file"
        Me.Button2_browse_message_file.Size = New System.Drawing.Size(75, 23)
        Me.Button2_browse_message_file.TabIndex = 49
        Me.Button2_browse_message_file.Text = "Browse"
        Me.Button2_browse_message_file.UseVisualStyleBackColor = True
        '
        'EmailFilenameList
        '
        Me.EmailFilenameList.BackColor = System.Drawing.SystemColors.Info
        Me.EmailFilenameList.Location = New System.Drawing.Point(24, 473)
        Me.EmailFilenameList.Name = "EmailFilenameList"
        Me.EmailFilenameList.Size = New System.Drawing.Size(267, 20)
        Me.EmailFilenameList.TabIndex = 50
        Me.EmailFilenameList.Visible = False
        '
        'Button3_browse_email_filename
        '
        Me.Button3_browse_email_filename.Location = New System.Drawing.Point(296, 468)
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
        'Label8_PD
        '
        Me.Label8_PD.AutoSize = True
        Me.Label8_PD.Location = New System.Drawing.Point(19, 96)
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
        Me.Label9_EmailListDescription.Location = New System.Drawing.Point(19, 435)
        Me.Label9_EmailListDescription.Name = "Label9_EmailListDescription"
        Me.Label9_EmailListDescription.Size = New System.Drawing.Size(322, 26)
        Me.Label9_EmailListDescription.TabIndex = 55
        Me.Label9_EmailListDescription.Text = "The file list must have the following format (separated by a comma):" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1st Column:" & _
            " Filename , 2nd Column: Email Address (No Header)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label9_EmailListDescription.Visible = False
        '
        'ProgDir2
        '
        Me.ProgDir2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgDir2.Location = New System.Drawing.Point(114, 96)
        Me.ProgDir2.Name = "ProgDir2"
        Me.ProgDir2.Size = New System.Drawing.Size(277, 18)
        Me.ProgDir2.TabIndex = 57
        Me.ProgDir2.Text = "c:\EPE"
        '
        'PortBox
        '
        Me.PortBox.Location = New System.Drawing.Point(295, 284)
        Me.PortBox.Name = "PortBox"
        Me.PortBox.Size = New System.Drawing.Size(41, 20)
        Me.PortBox.TabIndex = 58
        Me.PortBox.Text = "25"
        '
        'Label7_port
        '
        Me.Label7_port.AutoSize = True
        Me.Label7_port.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7_port.Location = New System.Drawing.Point(293, 268)
        Me.Label7_port.Name = "Label7_port"
        Me.Label7_port.Size = New System.Drawing.Size(30, 13)
        Me.Label7_port.TabIndex = 59
        Me.Label7_port.Text = "Port"
        '
        'Button_SaveAsDefault
        '
        Me.Button_SaveAsDefault.Location = New System.Drawing.Point(22, 66)
        Me.Button_SaveAsDefault.Name = "Button_SaveAsDefault"
        Me.Button_SaveAsDefault.Size = New System.Drawing.Size(227, 25)
        Me.Button_SaveAsDefault.TabIndex = 62
        Me.Button_SaveAsDefault.Text = "Click here to save settings as the default."
        Me.Button_SaveAsDefault.UseVisualStyleBackColor = True
        '
        'StatusBox
        '
        Me.StatusBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBox.Location = New System.Drawing.Point(397, 114)
        Me.StatusBox.Multiline = True
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.StatusBox.Size = New System.Drawing.Size(371, 215)
        Me.StatusBox.TabIndex = 64
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabel.Location = New System.Drawing.Point(504, 64)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(78, 20)
        Me.StatusLabel.TabIndex = 65
        Me.StatusLabel.Text = "STATUS"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(397, 332)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(371, 17)
        Me.ProgressBar1.TabIndex = 66
        '
        'CustomerInfo
        '
        Me.CustomerInfo.AutoSize = True
        Me.CustomerInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerInfo.Location = New System.Drawing.Point(400, 2)
        Me.CustomerInfo.Name = "CustomerInfo"
        Me.CustomerInfo.Size = New System.Drawing.Size(249, 13)
        Me.CustomerInfo.TabIndex = 67
        Me.CustomerInfo.Text = "Created for: Company Name <info@company.com>"
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VersionLabel.Location = New System.Drawing.Point(21, 47)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(54, 15)
        Me.VersionLabel.TabIndex = 68
        Me.VersionLabel.Text = "Version: "
        '
        'CancelButton1
        '
        Me.CancelButton1.Location = New System.Drawing.Point(694, 430)
        Me.CancelButton1.Name = "CancelButton1"
        Me.CancelButton1.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton1.TabIndex = 72
        Me.CancelButton1.Text = "CANCEL"
        Me.CancelButton1.UseVisualStyleBackColor = True
        '
        'MonitorFolderCheckBox
        '
        Me.MonitorFolderCheckBox.AutoSize = True
        Me.MonitorFolderCheckBox.Location = New System.Drawing.Point(397, 359)
        Me.MonitorFolderCheckBox.Name = "MonitorFolderCheckBox"
        Me.MonitorFolderCheckBox.Size = New System.Drawing.Size(155, 17)
        Me.MonitorFolderCheckBox.TabIndex = 74
        Me.MonitorFolderCheckBox.Text = "Send Emails Automatically?"
        Me.MonitorFolderCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MonitorFolderCheckBox.UseVisualStyleBackColor = True
        '
        'ignoreJPG
        '
        Me.ignoreJPG.AutoSize = True
        Me.ignoreJPG.Location = New System.Drawing.Point(201, 404)
        Me.ignoreJPG.Name = "ignoreJPG"
        Me.ignoreJPG.Size = New System.Drawing.Size(142, 17)
        Me.ignoreJPG.TabIndex = 75
        Me.ignoreJPG.Text = "Check if "".jpg"" is omitted"
        Me.ignoreJPG.UseVisualStyleBackColor = True
        Me.ignoreJPG.Visible = False
        '
        'DelayLabel1
        '
        Me.DelayLabel1.AutoSize = True
        Me.DelayLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DelayLabel1.Location = New System.Drawing.Point(673, 360)
        Me.DelayLabel1.Name = "DelayLabel1"
        Me.DelayLabel1.Size = New System.Drawing.Size(48, 13)
        Me.DelayLabel1.TabIndex = 77
        Me.DelayLabel1.Text = "Delay (s)"
        Me.DelayLabel1.Visible = False
        '
        'DelayTextBox1
        '
        Me.DelayTextBox1.Location = New System.Drawing.Point(728, 357)
        Me.DelayTextBox1.Name = "DelayTextBox1"
        Me.DelayTextBox1.Size = New System.Drawing.Size(41, 20)
        Me.DelayTextBox1.TabIndex = 76
        Me.DelayTextBox1.Text = "2"
        Me.DelayTextBox1.Visible = False
        '
        'SENDINGBUTTON
        '
        Me.SENDINGBUTTON.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SENDINGBUTTON.Location = New System.Drawing.Point(639, 64)
        Me.SENDINGBUTTON.Name = "SENDINGBUTTON"
        Me.SENDINGBUTTON.Size = New System.Drawing.Size(129, 23)
        Me.SENDINGBUTTON.TabIndex = 79
        Me.SENDINGBUTTON.Text = "Sending"
        Me.SENDINGBUTTON.UseVisualStyleBackColor = False
        Me.SENDINGBUTTON.Visible = False
        '
        'StoppedButton
        '
        Me.StoppedButton.BackColor = System.Drawing.Color.Red
        Me.StoppedButton.Location = New System.Drawing.Point(639, 64)
        Me.StoppedButton.Name = "StoppedButton"
        Me.StoppedButton.Size = New System.Drawing.Size(129, 23)
        Me.StoppedButton.TabIndex = 80
        Me.StoppedButton.Text = "Stopped"
        Me.StoppedButton.UseVisualStyleBackColor = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "Event Photo Emailer"
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip_ForNotificationIcon
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Event Photo Emailer"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip_ForNotificationIcon
        '
        Me.ContextMenuStrip_ForNotificationIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowEPE, Me.HideEPE, Me.ExitEPE})
        Me.ContextMenuStrip_ForNotificationIcon.Name = "ContextMenuStrip_ForNotificationIcon"
        Me.ContextMenuStrip_ForNotificationIcon.Size = New System.Drawing.Size(126, 70)
        '
        'ShowEPE
        '
        Me.ShowEPE.Name = "ShowEPE"
        Me.ShowEPE.Size = New System.Drawing.Size(125, 22)
        Me.ShowEPE.Text = "Show EPE"
        '
        'HideEPE
        '
        Me.HideEPE.Name = "HideEPE"
        Me.HideEPE.Size = New System.Drawing.Size(125, 22)
        Me.HideEPE.Text = "Hide EPE"
        '
        'ExitEPE
        '
        Me.ExitEPE.Name = "ExitEPE"
        Me.ExitEPE.Size = New System.Drawing.Size(125, 22)
        Me.ExitEPE.Text = "Exit EPE"
        '
        'HideButton
        '
        Me.HideButton.Location = New System.Drawing.Point(421, 424)
        Me.HideButton.Name = "HideButton"
        Me.HideButton.Size = New System.Drawing.Size(115, 35)
        Me.HideButton.TabIndex = 81
        Me.HideButton.Text = "Hide Window in " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "System Tray?"
        Me.HideButton.UseVisualStyleBackColor = True
        '
        'CheckBox_ConfirmationEmail
        '
        Me.CheckBox_ConfirmationEmail.AutoSize = True
        Me.CheckBox_ConfirmationEmail.Location = New System.Drawing.Point(397, 378)
        Me.CheckBox_ConfirmationEmail.Name = "CheckBox_ConfirmationEmail"
        Me.CheckBox_ConfirmationEmail.Size = New System.Drawing.Size(166, 17)
        Me.CheckBox_ConfirmationEmail.TabIndex = 82
        Me.CheckBox_ConfirmationEmail.Text = "Receive Confirmation Emails?"
        Me.CheckBox_ConfirmationEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox_ConfirmationEmail.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.ImageKey = "(none)"
        Me.Button1.Location = New System.Drawing.Point(181, 114)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 22)
        Me.Button1.TabIndex = 83
        Me.Button1.Text = "Open Image Folder"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(400, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Connection Status:"
        '
        'ConnectionStatusResultLabel
        '
        Me.ConnectionStatusResultLabel.AutoSize = True
        Me.ConnectionStatusResultLabel.Location = New System.Drawing.Point(521, 97)
        Me.ConnectionStatusResultLabel.Name = "ConnectionStatusResultLabel"
        Me.ConnectionStatusResultLabel.Size = New System.Drawing.Size(142, 13)
        Me.ConnectionStatusResultLabel.TabIndex = 85
        Me.ConnectionStatusResultLabel.Text = "Obtaining Connection Status"
        '
        'CheckConnectionTimer
        '
        Me.CheckConnectionTimer.Enabled = True
        Me.CheckConnectionTimer.Interval = 10000
        '
        'ClientNameLabel
        '
        Me.ClientNameLabel.AutoSize = True
        Me.ClientNameLabel.Location = New System.Drawing.Point(292, 20)
        Me.ClientNameLabel.Name = "ClientNameLabel"
        Me.ClientNameLabel.Size = New System.Drawing.Size(74, 13)
        Me.ClientNameLabel.TabIndex = 86
        Me.ClientNameLabel.Text = "Client's Name:"
        '
        'ClientNameTextBox
        '
        Me.ClientNameTextBox.Location = New System.Drawing.Point(403, 20)
        Me.ClientNameTextBox.Name = "ClientNameTextBox"
        Me.ClientNameTextBox.Size = New System.Drawing.Size(365, 20)
        Me.ClientNameTextBox.TabIndex = 87
        '
        'ClientEmailAddressLabel
        '
        Me.ClientEmailAddressLabel.AutoSize = True
        Me.ClientEmailAddressLabel.Location = New System.Drawing.Point(293, 42)
        Me.ClientEmailAddressLabel.Name = "ClientEmailAddressLabel"
        Me.ClientEmailAddressLabel.Size = New System.Drawing.Size(109, 13)
        Me.ClientEmailAddressLabel.TabIndex = 88
        Me.ClientEmailAddressLabel.Text = "Client's EmailAddress:"
        '
        'ClientEmailAddressTextBox
        '
        Me.ClientEmailAddressTextBox.Location = New System.Drawing.Point(403, 42)
        Me.ClientEmailAddressTextBox.Name = "ClientEmailAddressTextBox"
        Me.ClientEmailAddressTextBox.Size = New System.Drawing.Size(365, 20)
        Me.ClientEmailAddressTextBox.TabIndex = 89
        '
        'EmailCombineCheckBox
        '
        Me.EmailCombineCheckBox.AutoSize = True
        Me.EmailCombineCheckBox.Location = New System.Drawing.Point(397, 401)
        Me.EmailCombineCheckBox.Name = "EmailCombineCheckBox"
        Me.EmailCombineCheckBox.Size = New System.Drawing.Size(226, 17)
        Me.EmailCombineCheckBox.TabIndex = 90
        Me.EmailCombineCheckBox.Text = "Check to disable image combining feature."
        Me.EmailCombineCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.EmailCombineCheckBox.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(772, 547)
        Me.Controls.Add(Me.EmailCombineCheckBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ClientEmailAddressTextBox)
        Me.Controls.Add(Me.ConnectionStatusResultLabel)
        Me.Controls.Add(Me.ClientEmailAddressLabel)
        Me.Controls.Add(Me.ClientNameTextBox)
        Me.Controls.Add(Me.CheckBox_ConfirmationEmail)
        Me.Controls.Add(Me.ClientNameLabel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SENDINGBUTTON)
        Me.Controls.Add(Me.HideButton)
        Me.Controls.Add(Me.StoppedButton)
        Me.Controls.Add(Me.ignoreJPG)
        Me.Controls.Add(Me.DelayLabel1)
        Me.Controls.Add(Me.MonitorFolderCheckBox)
        Me.Controls.Add(Me.DelayTextBox1)
        Me.Controls.Add(Me.VersionLabel)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.CancelButton1)
        Me.Controls.Add(Me.Button_SaveAsDefault)
        Me.Controls.Add(Me.Label7_port)
        Me.Controls.Add(Me.PortBox)
        Me.Controls.Add(Me.CustomerInfo)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.Button2_browse_message_file)
        Me.Controls.Add(Me.Label9_EmailListDescription)
        Me.Controls.Add(Me.Button3_browse_email_filename)
        Me.Controls.Add(Me.EmailFilenameList)
        Me.Controls.Add(Me.Label8_PD)
        Me.Controls.Add(Me.Button1_browse_image_location)
        Me.Controls.Add(Me.CheckBox2_emailfilename)
        Me.Controls.Add(Me.ProgDir2)
        Me.Controls.Add(Me.label5_PW)
        Me.Controls.Add(Me.GoButton)
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
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.Credit)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Event Photo Emailer"
        Me.ContextMenuStrip_ForNotificationIcon.ResumeLayout(False)
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
    Private WithEvents Label8_PD As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog2_ProgramDirectory As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label9_EmailListDescription As System.Windows.Forms.Label
    Friend WithEvents ProgDir2 As System.Windows.Forms.Label
    Friend WithEvents PortBox As System.Windows.Forms.TextBox
    Private WithEvents Label7_port As System.Windows.Forms.Label
    Friend WithEvents Button_SaveAsDefault As System.Windows.Forms.Button
    Friend WithEvents StatusBox As System.Windows.Forms.TextBox
    Private WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents CustomerInfo As System.Windows.Forms.Label
    Private WithEvents VersionLabel As System.Windows.Forms.Label
    Friend WithEvents CancelButton1 As System.Windows.Forms.Button
    Friend WithEvents MonitorFolderCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ignoreJPG As System.Windows.Forms.CheckBox
    Private WithEvents DelayLabel1 As System.Windows.Forms.Label
    Friend WithEvents DelayTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SENDINGBUTTON As System.Windows.Forms.Button
    Friend WithEvents StoppedButton As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents HideButton As System.Windows.Forms.Button
    Friend WithEvents CheckBox_ConfirmationEmail As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip_ForNotificationIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowEPE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideEPE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitEPE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ConnectionStatusResultLabel As System.Windows.Forms.Label
    Friend WithEvents CheckConnectionTimer As System.Windows.Forms.Timer
    Friend WithEvents ClientNameLabel As System.Windows.Forms.Label
    Private WithEvents ClientNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ClientEmailAddressLabel As System.Windows.Forms.Label
    Private WithEvents ClientEmailAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EmailCombineCheckBox As System.Windows.Forms.CheckBox

End Class
