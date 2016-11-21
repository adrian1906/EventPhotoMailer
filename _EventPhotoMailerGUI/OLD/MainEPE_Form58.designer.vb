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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GoButton = New System.Windows.Forms.Button()
        Me.label3_subject = New System.Windows.Forms.Label()
        Me.textBox_SubjectLine = New System.Windows.Forms.TextBox()
        Me.label2_message = New System.Windows.Forms.Label()
        Me.textBox_messagefile = New System.Windows.Forms.TextBox()
        Me.label1_FileLocation = New System.Windows.Forms.Label()
        Me.Textbox_imagefolder = New System.Windows.Forms.TextBox()
        Me.Credit = New System.Windows.Forms.Label()
        Me.Title = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog_image_location = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1_message_location = New System.Windows.Forms.OpenFileDialog()
        Me.Button1_browse_image_location = New System.Windows.Forms.Button()
        Me.Button2_browse_message_file = New System.Windows.Forms.Button()
        Me.EmailFilenameList = New System.Windows.Forms.TextBox()
        Me.Button3_browse_email_filename = New System.Windows.Forms.Button()
        Me.OpenFileDialog2_emaillist = New System.Windows.Forms.OpenFileDialog()
        Me.Label8_PD = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog2_ProgramDirectory = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label9_EmailListDescription = New System.Windows.Forms.Label()
        Me.ProgDir2 = New System.Windows.Forms.Label()
        Me.Button_SaveAsDefault = New System.Windows.Forms.Button()
        Me.StatusBox = New System.Windows.Forms.TextBox()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.CustomerInfo = New System.Windows.Forms.Label()
        Me.CancelButton1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SENDINGBUTTON = New System.Windows.Forms.Button()
        Me.StoppedButton = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip_ForNotificationIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowEPE = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideEPE = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitEPE = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideButton = New System.Windows.Forms.Button()
        Me.CheckBox_ConfirmationEmail = New System.Windows.Forms.CheckBox()
        Me.OpenImageFolderButton = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ConnectionStatusResultLabel = New System.Windows.Forms.Label()
        Me.CheckConnectionTimer = New System.Windows.Forms.Timer(Me.components)
        Me.EmailCombineCheckBox = New System.Windows.Forms.CheckBox()
        Me.CheckSMTPtimerdots = New System.Windows.Forms.Timer(Me.components)
        Me.FacebookOnlyCheckBox = New System.Windows.Forms.CheckBox()
        Me.ignoreJPG = New System.Windows.Forms.CheckBox()
        Me.CheckBox2_emailfilename = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ConfigureEmailButton = New System.Windows.Forms.ToolStripButton()
        Me.AboutUsButton = New System.Windows.Forms.ToolStripButton()
        Me.BW_EmailerDirectory = New System.ComponentModel.BackgroundWorker()
        Me.BW_EmailerParcer = New System.ComponentModel.BackgroundWorker()
        Me.BW_LetsGo = New System.ComponentModel.BackgroundWorker()
        Me.CustomerInfoLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.EmailAndFacebook = New System.Windows.Forms.CheckBox()
        Me.EmailOnlyCheckbox = New System.Windows.Forms.CheckBox()
        Me.FacebookAlbumName = New System.Windows.Forms.TextBox()
        Me.HoodWatchFolderOnTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TimeIntervalLabel = New System.Windows.Forms.Label()
        Me.TimeIntervalTextBox = New System.Windows.Forms.TextBox()
        Me.FacebookCaptionTextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.StartAutoButton = New System.Windows.Forms.Button()
        Me.StopAutoButton = New System.Windows.Forms.Button()
        Me.AutoModeLabel = New System.Windows.Forms.Label()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.ContextMenuStrip_ForNotificationIcon.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GoButton
        '
        Me.GoButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GoButton.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GoButton.ForeColor = System.Drawing.Color.Black
        Me.GoButton.Location = New System.Drawing.Point(409, 508)
        Me.GoButton.Name = "GoButton"
        Me.GoButton.Size = New System.Drawing.Size(370, 43)
        Me.GoButton.TabIndex = 42
        Me.GoButton.Text = "SEND EMAILS"
        Me.GoButton.UseVisualStyleBackColor = False
        '
        'label3_subject
        '
        Me.label3_subject.AutoSize = True
        Me.label3_subject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3_subject.Location = New System.Drawing.Point(7, 223)
        Me.label3_subject.Name = "label3_subject"
        Me.label3_subject.Size = New System.Drawing.Size(78, 13)
        Me.label3_subject.TabIndex = 33
        Me.label3_subject.Text = "Subject line:"
        '
        'textBox_SubjectLine
        '
        Me.textBox_SubjectLine.Location = New System.Drawing.Point(10, 242)
        Me.textBox_SubjectLine.Name = "textBox_SubjectLine"
        Me.textBox_SubjectLine.Size = New System.Drawing.Size(295, 20)
        Me.textBox_SubjectLine.TabIndex = 32
        '
        'label2_message
        '
        Me.label2_message.AutoSize = True
        Me.label2_message.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2_message.Location = New System.Drawing.Point(7, 177)
        Me.label2_message.Name = "label2_message"
        Me.label2_message.Size = New System.Drawing.Size(190, 13)
        Me.label2_message.TabIndex = 31
        Me.label2_message.Text = "Location of Message Document:"
        '
        'textBox_messagefile
        '
        Me.textBox_messagefile.Location = New System.Drawing.Point(10, 193)
        Me.textBox_messagefile.Name = "textBox_messagefile"
        Me.textBox_messagefile.ReadOnly = True
        Me.textBox_messagefile.Size = New System.Drawing.Size(295, 20)
        Me.textBox_messagefile.TabIndex = 30
        '
        'label1_FileLocation
        '
        Me.label1_FileLocation.AutoSize = True
        Me.label1_FileLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1_FileLocation.Location = New System.Drawing.Point(7, 129)
        Me.label1_FileLocation.Name = "label1_FileLocation"
        Me.label1_FileLocation.Size = New System.Drawing.Size(143, 13)
        Me.label1_FileLocation.TabIndex = 29
        Me.label1_FileLocation.Text = "Location of Image Files:"
        '
        'Textbox_imagefolder
        '
        Me.Textbox_imagefolder.Location = New System.Drawing.Point(10, 145)
        Me.Textbox_imagefolder.Name = "Textbox_imagefolder"
        Me.Textbox_imagefolder.Size = New System.Drawing.Size(295, 20)
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
        Me.Title.Location = New System.Drawing.Point(4, 27)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(207, 25)
        Me.Title.TabIndex = 24
        Me.Title.Text = "Event Photo Emailer"
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
        'Button1_browse_image_location
        '
        Me.Button1_browse_image_location.Location = New System.Drawing.Point(311, 143)
        Me.Button1_browse_image_location.Name = "Button1_browse_image_location"
        Me.Button1_browse_image_location.Size = New System.Drawing.Size(75, 23)
        Me.Button1_browse_image_location.TabIndex = 48
        Me.Button1_browse_image_location.Text = "Browse"
        Me.Button1_browse_image_location.UseVisualStyleBackColor = True
        '
        'Button2_browse_message_file
        '
        Me.Button2_browse_message_file.Location = New System.Drawing.Point(312, 193)
        Me.Button2_browse_message_file.Name = "Button2_browse_message_file"
        Me.Button2_browse_message_file.Size = New System.Drawing.Size(75, 23)
        Me.Button2_browse_message_file.TabIndex = 49
        Me.Button2_browse_message_file.Text = "Browse"
        Me.Button2_browse_message_file.UseVisualStyleBackColor = True
        '
        'EmailFilenameList
        '
        Me.EmailFilenameList.BackColor = System.Drawing.SystemColors.Info
        Me.EmailFilenameList.Enabled = False
        Me.EmailFilenameList.Location = New System.Drawing.Point(11, 533)
        Me.EmailFilenameList.Name = "EmailFilenameList"
        Me.EmailFilenameList.Size = New System.Drawing.Size(267, 20)
        Me.EmailFilenameList.TabIndex = 50
        '
        'Button3_browse_email_filename
        '
        Me.Button3_browse_email_filename.Enabled = False
        Me.Button3_browse_email_filename.Location = New System.Drawing.Point(311, 528)
        Me.Button3_browse_email_filename.Name = "Button3_browse_email_filename"
        Me.Button3_browse_email_filename.Size = New System.Drawing.Size(75, 23)
        Me.Button3_browse_email_filename.TabIndex = 51
        Me.Button3_browse_email_filename.Text = "Browse"
        Me.Button3_browse_email_filename.UseVisualStyleBackColor = True
        '
        'OpenFileDialog2_emaillist
        '
        Me.OpenFileDialog2_emaillist.InitialDirectory = "c:\EPE"
        '
        'Label8_PD
        '
        Me.Label8_PD.AutoSize = True
        Me.Label8_PD.Location = New System.Drawing.Point(7, 102)
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
        Me.Label9_EmailListDescription.Enabled = False
        Me.Label9_EmailListDescription.Location = New System.Drawing.Point(6, 494)
        Me.Label9_EmailListDescription.Name = "Label9_EmailListDescription"
        Me.Label9_EmailListDescription.Size = New System.Drawing.Size(322, 26)
        Me.Label9_EmailListDescription.TabIndex = 55
        Me.Label9_EmailListDescription.Text = "The file list must have the following format (separated by a comma):" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1st Column:" & _
            " Filename , 2nd Column: Email Address (No Header)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'ProgDir2
        '
        Me.ProgDir2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgDir2.Location = New System.Drawing.Point(102, 102)
        Me.ProgDir2.Name = "ProgDir2"
        Me.ProgDir2.Size = New System.Drawing.Size(277, 18)
        Me.ProgDir2.TabIndex = 57
        Me.ProgDir2.Text = "c:\EPE"
        '
        'Button_SaveAsDefault
        '
        Me.Button_SaveAsDefault.Location = New System.Drawing.Point(10, 72)
        Me.Button_SaveAsDefault.Name = "Button_SaveAsDefault"
        Me.Button_SaveAsDefault.Size = New System.Drawing.Size(227, 25)
        Me.Button_SaveAsDefault.TabIndex = 62
        Me.Button_SaveAsDefault.Text = "Click here to save settings as the default."
        Me.Button_SaveAsDefault.UseVisualStyleBackColor = True
        '
        'StatusBox
        '
        Me.StatusBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBox.Location = New System.Drawing.Point(408, 91)
        Me.StatusBox.Multiline = True
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.StatusBox.Size = New System.Drawing.Size(371, 306)
        Me.StatusBox.TabIndex = 64
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabel.Location = New System.Drawing.Point(558, 34)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(78, 20)
        Me.StatusLabel.TabIndex = 65
        Me.StatusLabel.Text = "STATUS"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(408, 403)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(363, 20)
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
        'CancelButton1
        '
        Me.CancelButton1.Location = New System.Drawing.Point(704, 473)
        Me.CancelButton1.Name = "CancelButton1"
        Me.CancelButton1.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton1.TabIndex = 72
        Me.CancelButton1.Text = "CANCEL"
        Me.CancelButton1.UseVisualStyleBackColor = True
        '
        'SENDINGBUTTON
        '
        Me.SENDINGBUTTON.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SENDINGBUTTON.Location = New System.Drawing.Point(642, 31)
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
        Me.StoppedButton.Location = New System.Drawing.Point(642, 31)
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
        Me.ContextMenuStrip_ForNotificationIcon.Size = New System.Drawing.Size(122, 70)
        '
        'ShowEPE
        '
        Me.ShowEPE.Name = "ShowEPE"
        Me.ShowEPE.Size = New System.Drawing.Size(121, 22)
        Me.ShowEPE.Text = "Show EPE"
        '
        'HideEPE
        '
        Me.HideEPE.Name = "HideEPE"
        Me.HideEPE.Size = New System.Drawing.Size(121, 22)
        Me.HideEPE.Text = "Hide EPE"
        '
        'ExitEPE
        '
        Me.ExitEPE.Name = "ExitEPE"
        Me.ExitEPE.Size = New System.Drawing.Size(121, 22)
        Me.ExitEPE.Text = "Exit EPE"
        '
        'HideButton
        '
        Me.HideButton.Location = New System.Drawing.Point(408, 467)
        Me.HideButton.Name = "HideButton"
        Me.HideButton.Size = New System.Drawing.Size(115, 35)
        Me.HideButton.TabIndex = 81
        Me.HideButton.Text = "Hide Window in " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "System Tray?"
        Me.HideButton.UseVisualStyleBackColor = True
        '
        'CheckBox_ConfirmationEmail
        '
        Me.CheckBox_ConfirmationEmail.AutoSize = True
        Me.CheckBox_ConfirmationEmail.Location = New System.Drawing.Point(8, 312)
        Me.CheckBox_ConfirmationEmail.Name = "CheckBox_ConfirmationEmail"
        Me.CheckBox_ConfirmationEmail.Size = New System.Drawing.Size(166, 17)
        Me.CheckBox_ConfirmationEmail.TabIndex = 82
        Me.CheckBox_ConfirmationEmail.Text = "Receive Confirmation Emails?"
        Me.CheckBox_ConfirmationEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox_ConfirmationEmail.UseVisualStyleBackColor = True
        '
        'OpenImageFolderButton
        '
        Me.OpenImageFolderButton.ImageKey = "(none)"
        Me.OpenImageFolderButton.Location = New System.Drawing.Point(169, 120)
        Me.OpenImageFolderButton.Name = "OpenImageFolderButton"
        Me.OpenImageFolderButton.Size = New System.Drawing.Size(108, 22)
        Me.OpenImageFolderButton.TabIndex = 83
        Me.OpenImageFolderButton.Text = "Open Image Folder"
        Me.OpenImageFolderButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(411, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Connection Status:"
        '
        'ConnectionStatusResultLabel
        '
        Me.ConnectionStatusResultLabel.AutoSize = True
        Me.ConnectionStatusResultLabel.Location = New System.Drawing.Point(532, 72)
        Me.ConnectionStatusResultLabel.Name = "ConnectionStatusResultLabel"
        Me.ConnectionStatusResultLabel.Size = New System.Drawing.Size(142, 13)
        Me.ConnectionStatusResultLabel.TabIndex = 85
        Me.ConnectionStatusResultLabel.Text = "Obtaining Connection Status"
        '
        'CheckConnectionTimer
        '
        Me.CheckConnectionTimer.Enabled = True
        Me.CheckConnectionTimer.Interval = 60000
        '
        'EmailCombineCheckBox
        '
        Me.EmailCombineCheckBox.AutoSize = True
        Me.EmailCombineCheckBox.Location = New System.Drawing.Point(8, 333)
        Me.EmailCombineCheckBox.Name = "EmailCombineCheckBox"
        Me.EmailCombineCheckBox.Size = New System.Drawing.Size(226, 17)
        Me.EmailCombineCheckBox.TabIndex = 90
        Me.EmailCombineCheckBox.Text = "Check to disable image combining feature."
        Me.EmailCombineCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.EmailCombineCheckBox.UseVisualStyleBackColor = True
        '
        'CheckSMTPtimerdots
        '
        Me.CheckSMTPtimerdots.Interval = 10000
        '
        'FacebookOnlyCheckBox
        '
        Me.FacebookOnlyCheckBox.AutoSize = True
        Me.FacebookOnlyCheckBox.Location = New System.Drawing.Point(239, 367)
        Me.FacebookOnlyCheckBox.Name = "FacebookOnlyCheckBox"
        Me.FacebookOnlyCheckBox.Size = New System.Drawing.Size(104, 17)
        Me.FacebookOnlyCheckBox.TabIndex = 91
        Me.FacebookOnlyCheckBox.Text = "Facebook Only?"
        Me.FacebookOnlyCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.FacebookOnlyCheckBox.UseVisualStyleBackColor = True
        '
        'ignoreJPG
        '
        Me.ignoreJPG.AutoSize = True
        Me.ignoreJPG.Enabled = False
        Me.ignoreJPG.Location = New System.Drawing.Point(188, 468)
        Me.ignoreJPG.Name = "ignoreJPG"
        Me.ignoreJPG.Size = New System.Drawing.Size(142, 17)
        Me.ignoreJPG.TabIndex = 114
        Me.ignoreJPG.Text = "Check if "".jpg"" is omitted"
        Me.ignoreJPG.UseVisualStyleBackColor = True
        '
        'CheckBox2_emailfilename
        '
        Me.CheckBox2_emailfilename.AutoSize = True
        Me.CheckBox2_emailfilename.Location = New System.Drawing.Point(9, 468)
        Me.CheckBox2_emailfilename.Name = "CheckBox2_emailfilename"
        Me.CheckBox2_emailfilename.Size = New System.Drawing.Size(165, 17)
        Me.CheckBox2_emailfilename.TabIndex = 113
        Me.CheckBox2_emailfilename.Text = "Use email/filename directory?"
        Me.CheckBox2_emailfilename.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigureEmailButton, Me.AboutUsButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(792, 25)
        Me.ToolStrip1.TabIndex = 115
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ConfigureEmailButton
        '
        Me.ConfigureEmailButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ConfigureEmailButton.Image = CType(resources.GetObject("ConfigureEmailButton.Image"), System.Drawing.Image)
        Me.ConfigureEmailButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ConfigureEmailButton.Name = "ConfigureEmailButton"
        Me.ConfigureEmailButton.Size = New System.Drawing.Size(50, 22)
        Me.ConfigureEmailButton.Text = "Settings"
        '
        'AboutUsButton
        '
        Me.AboutUsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AboutUsButton.Image = CType(resources.GetObject("AboutUsButton.Image"), System.Drawing.Image)
        Me.AboutUsButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AboutUsButton.Name = "AboutUsButton"
        Me.AboutUsButton.Size = New System.Drawing.Size(55, 22)
        Me.AboutUsButton.Text = "About Us"
        '
        'BW_EmailerDirectory
        '
        Me.BW_EmailerDirectory.WorkerReportsProgress = True
        Me.BW_EmailerDirectory.WorkerSupportsCancellation = True
        '
        'BW_EmailerParcer
        '
        Me.BW_EmailerParcer.WorkerReportsProgress = True
        Me.BW_EmailerParcer.WorkerSupportsCancellation = True
        '
        'BW_LetsGo
        '
        Me.BW_LetsGo.WorkerReportsProgress = True
        Me.BW_LetsGo.WorkerSupportsCancellation = True
        '
        'CustomerInfoLabel
        '
        Me.CustomerInfoLabel.AutoSize = True
        Me.CustomerInfoLabel.Location = New System.Drawing.Point(6, 52)
        Me.CustomerInfoLabel.Name = "CustomerInfoLabel"
        Me.CustomerInfoLabel.Size = New System.Drawing.Size(106, 13)
        Me.CustomerInfoLabel.TabIndex = 116
        Me.CustomerInfoLabel.Text = "Customer Information"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.facebook_image
        Me.PictureBox1.Image = Global.WindowsApplication1.My.Resources.Resources.facebook_image
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(9, 359)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(118, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 117
        Me.PictureBox1.TabStop = False
        '
        'EmailAndFacebook
        '
        Me.EmailAndFacebook.AutoSize = True
        Me.EmailAndFacebook.Location = New System.Drawing.Point(176, 390)
        Me.EmailAndFacebook.Name = "EmailAndFacebook"
        Me.EmailAndFacebook.Size = New System.Drawing.Size(129, 17)
        Me.EmailAndFacebook.TabIndex = 118
        Me.EmailAndFacebook.Text = "Email and Facebook?"
        Me.EmailAndFacebook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.EmailAndFacebook.UseVisualStyleBackColor = True
        '
        'EmailOnlyCheckbox
        '
        Me.EmailOnlyCheckbox.AutoSize = True
        Me.EmailOnlyCheckbox.Checked = True
        Me.EmailOnlyCheckbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.EmailOnlyCheckbox.Location = New System.Drawing.Point(152, 367)
        Me.EmailOnlyCheckbox.Name = "EmailOnlyCheckbox"
        Me.EmailOnlyCheckbox.Size = New System.Drawing.Size(81, 17)
        Me.EmailOnlyCheckbox.TabIndex = 119
        Me.EmailOnlyCheckbox.Text = "Email Only?"
        Me.EmailOnlyCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.EmailOnlyCheckbox.UseVisualStyleBackColor = True
        '
        'FacebookAlbumName
        '
        Me.FacebookAlbumName.BackColor = System.Drawing.SystemColors.Window
        Me.FacebookAlbumName.Location = New System.Drawing.Point(133, 413)
        Me.FacebookAlbumName.Name = "FacebookAlbumName"
        Me.FacebookAlbumName.Size = New System.Drawing.Size(253, 20)
        Me.FacebookAlbumName.TabIndex = 120
        Me.FacebookAlbumName.Text = "Event Photos"
        '
        'HoodWatchFolderOnTimer
        '
        Me.HoodWatchFolderOnTimer.Interval = 10000
        '
        'TimeIntervalLabel
        '
        Me.TimeIntervalLabel.AutoSize = True
        Me.TimeIntervalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeIntervalLabel.Location = New System.Drawing.Point(170, 290)
        Me.TimeIntervalLabel.Name = "TimeIntervalLabel"
        Me.TimeIntervalLabel.Size = New System.Drawing.Size(81, 13)
        Me.TimeIntervalLabel.TabIndex = 122
        Me.TimeIntervalLabel.Text = "Time interval (s)"
        '
        'TimeIntervalTextBox
        '
        Me.TimeIntervalTextBox.Location = New System.Drawing.Point(257, 287)
        Me.TimeIntervalTextBox.Name = "TimeIntervalTextBox"
        Me.TimeIntervalTextBox.Size = New System.Drawing.Size(41, 20)
        Me.TimeIntervalTextBox.TabIndex = 121
        Me.TimeIntervalTextBox.Text = "2"
        '
        'FacebookCaptionTextBox1
        '
        Me.FacebookCaptionTextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.FacebookCaptionTextBox1.Location = New System.Drawing.Point(133, 436)
        Me.FacebookCaptionTextBox1.Name = "FacebookCaptionTextBox1"
        Me.FacebookCaptionTextBox1.Size = New System.Drawing.Size(253, 20)
        Me.FacebookCaptionTextBox1.TabIndex = 123
        Me.FacebookCaptionTextBox1.Text = "Uploaded by EPEv4"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 413)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Album Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 439)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "Facebook Caption:"
        '
        'StartAutoButton
        '
        Me.StartAutoButton.Location = New System.Drawing.Point(8, 287)
        Me.StartAutoButton.Name = "StartAutoButton"
        Me.StartAutoButton.Size = New System.Drawing.Size(75, 23)
        Me.StartAutoButton.TabIndex = 126
        Me.StartAutoButton.Text = "Start Auto"
        Me.StartAutoButton.UseVisualStyleBackColor = True
        '
        'StopAutoButton
        '
        Me.StopAutoButton.Location = New System.Drawing.Point(89, 287)
        Me.StopAutoButton.Name = "StopAutoButton"
        Me.StopAutoButton.Size = New System.Drawing.Size(75, 23)
        Me.StopAutoButton.TabIndex = 127
        Me.StopAutoButton.Text = "Stop Auto"
        Me.StopAutoButton.UseVisualStyleBackColor = True
        '
        'AutoModeLabel
        '
        Me.AutoModeLabel.AutoSize = True
        Me.AutoModeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoModeLabel.Location = New System.Drawing.Point(129, 271)
        Me.AutoModeLabel.Name = "AutoModeLabel"
        Me.AutoModeLabel.Size = New System.Drawing.Size(68, 13)
        Me.AutoModeLabel.TabIndex = 128
        Me.AutoModeLabel.Text = "Auto Mode"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 25)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(792, 548)
        Me.WebBrowser1.TabIndex = 129
        Me.WebBrowser1.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.AutoModeLabel)
        Me.Controls.Add(Me.StopAutoButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.StartAutoButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FacebookCaptionTextBox1)
        Me.Controls.Add(Me.TimeIntervalLabel)
        Me.Controls.Add(Me.TimeIntervalTextBox)
        Me.Controls.Add(Me.FacebookAlbumName)
        Me.Controls.Add(Me.CustomerInfoLabel)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.EmailOnlyCheckbox)
        Me.Controls.Add(Me.EmailAndFacebook)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ignoreJPG)
        Me.Controls.Add(Me.EmailCombineCheckBox)
        Me.Controls.Add(Me.CheckBox2_emailfilename)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ConnectionStatusResultLabel)
        Me.Controls.Add(Me.OpenImageFolderButton)
        Me.Controls.Add(Me.SENDINGBUTTON)
        Me.Controls.Add(Me.CheckBox_ConfirmationEmail)
        Me.Controls.Add(Me.FacebookOnlyCheckBox)
        Me.Controls.Add(Me.StoppedButton)
        Me.Controls.Add(Me.HideButton)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.Button_SaveAsDefault)
        Me.Controls.Add(Me.CancelButton1)
        Me.Controls.Add(Me.CustomerInfo)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.Button2_browse_message_file)
        Me.Controls.Add(Me.Label8_PD)
        Me.Controls.Add(Me.Button1_browse_image_location)
        Me.Controls.Add(Me.Label9_EmailListDescription)
        Me.Controls.Add(Me.Button3_browse_email_filename)
        Me.Controls.Add(Me.EmailFilenameList)
        Me.Controls.Add(Me.ProgDir2)
        Me.Controls.Add(Me.label3_subject)
        Me.Controls.Add(Me.GoButton)
        Me.Controls.Add(Me.textBox_SubjectLine)
        Me.Controls.Add(Me.label2_message)
        Me.Controls.Add(Me.textBox_messagefile)
        Me.Controls.Add(Me.label1_FileLocation)
        Me.Controls.Add(Me.Textbox_imagefolder)
        Me.Controls.Add(Me.Credit)
        Me.Controls.Add(Me.Title)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Event Photo Emailer"
        Me.ContextMenuStrip_ForNotificationIcon.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents GoButton As System.Windows.Forms.Button
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
    Friend WithEvents Button1_browse_image_location As System.Windows.Forms.Button
    Friend WithEvents Button2_browse_message_file As System.Windows.Forms.Button
    Friend WithEvents EmailFilenameList As System.Windows.Forms.TextBox
    Friend WithEvents Button3_browse_email_filename As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog2_emaillist As System.Windows.Forms.OpenFileDialog
    Private WithEvents Label8_PD As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog2_ProgramDirectory As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label9_EmailListDescription As System.Windows.Forms.Label
    Friend WithEvents ProgDir2 As System.Windows.Forms.Label
    Friend WithEvents Button_SaveAsDefault As System.Windows.Forms.Button
    Friend WithEvents StatusBox As System.Windows.Forms.TextBox
    Private WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents CustomerInfo As System.Windows.Forms.Label
    Friend WithEvents CancelButton1 As System.Windows.Forms.Button
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
    Friend WithEvents OpenImageFolderButton As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ConnectionStatusResultLabel As System.Windows.Forms.Label
    Friend WithEvents CheckConnectionTimer As System.Windows.Forms.Timer
    Friend WithEvents EmailCombineCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CheckSMTPtimerdots As System.Windows.Forms.Timer
    Friend WithEvents FacebookOnlyCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ignoreJPG As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2_emailfilename As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ConfigureEmailButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents BW_EmailerDirectory As System.ComponentModel.BackgroundWorker
    Friend WithEvents BW_EmailerParcer As System.ComponentModel.BackgroundWorker
    Friend WithEvents BW_LetsGo As System.ComponentModel.BackgroundWorker
    Friend WithEvents CustomerInfoLabel As System.Windows.Forms.Label
    Friend WithEvents AboutUsButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents EmailAndFacebook As System.Windows.Forms.CheckBox
    Friend WithEvents EmailOnlyCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents FacebookAlbumName As System.Windows.Forms.TextBox
    Friend WithEvents HoodWatchFolderOnTimer As System.Windows.Forms.Timer
    Private WithEvents TimeIntervalLabel As System.Windows.Forms.Label
    Friend WithEvents TimeIntervalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FacebookCaptionTextBox1 As System.Windows.Forms.TextBox
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents StartAutoButton As System.Windows.Forms.Button
    Friend WithEvents StopAutoButton As System.Windows.Forms.Button
    Private WithEvents AutoModeLabel As System.Windows.Forms.Label
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser

End Class
