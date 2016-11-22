<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EPEForm1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EPEForm1))
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
        Me.MainStatusBox = New System.Windows.Forms.TextBox()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.CustomerInfo = New System.Windows.Forms.Label()
        Me.CancelButton1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip_ForNotificationIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowEPE = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideEPE = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitEPE = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenImageFolderButton = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ConnectionStatusResultLabel = New System.Windows.Forms.Label()
        Me.CheckConnectionTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CheckSMTPtimerdots = New System.Windows.Forms.Timer(Me.components)
        Me.ignoreJPG = New System.Windows.Forms.CheckBox()
        Me.CheckBox2_emailfilename = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ConfigureEmailButton = New System.Windows.Forms.ToolStripButton()
        Me.AboutUsButton = New System.Windows.Forms.ToolStripButton()
        Me.BW_EmailerDirectory = New System.ComponentModel.BackgroundWorker()
        Me.BW_EmailerParcer = New System.ComponentModel.BackgroundWorker()
        Me.BW_LetsGo = New System.ComponentModel.BackgroundWorker()
        Me.CustomerInfoLabel = New System.Windows.Forms.Label()
        Me.FacebookLogoOnForm1 = New System.Windows.Forms.PictureBox()
        Me.HoodWatchFolderOnTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FacebookCaptionTextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.FacebookAuth_indicatorLabel = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.EmailSentCounterLabel = New System.Windows.Forms.Label()
        Me.EmailNotSentLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Facebooksentlabel = New System.Windows.Forms.Label()
        Me.FBSentLabel = New System.Windows.Forms.Label()
        Me.fbNotSentLabel = New System.Windows.Forms.Label()
        Me.FBNotSentLBL = New System.Windows.Forms.Label()
        Me.ChkConnectionButton = New System.Windows.Forms.Button()
        Me.AlbumComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TimeIntervalLabel = New System.Windows.Forms.Label()
        Me.MyXMLDataSet = New System.Data.DataSet()
        Me.EmailOnlyRadio = New System.Windows.Forms.RadioButton()
        Me.FacebookOnlyRadio = New System.Windows.Forms.RadioButton()
        Me.EmailAndFacebookRadio = New System.Windows.Forms.RadioButton()
        Me.FacebookGroupBox = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.MainGroupBox = New System.Windows.Forms.GroupBox()
        Me.AutomodeGroupBox = New System.Windows.Forms.GroupBox()
        Me.ManualSendRadio = New System.Windows.Forms.RadioButton()
        Me.AutoSendRadio = New System.Windows.Forms.RadioButton()
        Me.TimeIntervalTextBox = New System.Windows.Forms.TextBox()
        Me.ClearWindowButton = New System.Windows.Forms.Button()
        Me.MakeThinButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SendSavedEmailButton = New System.Windows.Forms.Button()
        Me.StoppedButton = New System.Windows.Forms.Button()
        Me.SENDINGBUTTON = New System.Windows.Forms.Button()
        Me.WiFiSigProgressLabel = New System.Windows.Forms.Label()
        Me.WiFiProgressBar_SignalStrength = New System.Windows.Forms.ProgressBar()
        Me.Testbutton = New System.Windows.Forms.Button()
        Me.Config1ButtonFrontPage = New System.Windows.Forms.Button()
        Me.Config2ButtonFrontPage = New System.Windows.Forms.Button()
        Me.Config4ButtonFrontPage = New System.Windows.Forms.Button()
        Me.Config3ButtonFrontPage = New System.Windows.Forms.Button()
        Me.ContextMenuStrip_ForNotificationIcon.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.FacebookLogoOnForm1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyXMLDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FacebookGroupBox.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MainGroupBox.SuspendLayout()
        Me.AutomodeGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GoButton
        '
        Me.GoButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GoButton.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GoButton.ForeColor = System.Drawing.Color.Black
        Me.GoButton.Location = New System.Drawing.Point(408, 544)
        Me.GoButton.Name = "GoButton"
        Me.GoButton.Size = New System.Drawing.Size(370, 38)
        Me.GoButton.TabIndex = 42
        Me.GoButton.Text = "SEND EMAILS"
        Me.GoButton.UseVisualStyleBackColor = False
        '
        'label3_subject
        '
        Me.label3_subject.AutoSize = True
        Me.label3_subject.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3_subject.Location = New System.Drawing.Point(1, 137)
        Me.label3_subject.Name = "label3_subject"
        Me.label3_subject.Size = New System.Drawing.Size(112, 13)
        Me.label3_subject.TabIndex = 33
        Me.label3_subject.Text = "Email Subject line:"
        '
        'textBox_SubjectLine
        '
        Me.textBox_SubjectLine.Location = New System.Drawing.Point(4, 156)
        Me.textBox_SubjectLine.Name = "textBox_SubjectLine"
        Me.textBox_SubjectLine.Size = New System.Drawing.Size(295, 20)
        Me.textBox_SubjectLine.TabIndex = 32
        '
        'label2_message
        '
        Me.label2_message.AutoSize = True
        Me.label2_message.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2_message.Location = New System.Drawing.Point(1, 91)
        Me.label2_message.Name = "label2_message"
        Me.label2_message.Size = New System.Drawing.Size(190, 13)
        Me.label2_message.TabIndex = 31
        Me.label2_message.Text = "Location of Message Document:"
        '
        'textBox_messagefile
        '
        Me.textBox_messagefile.Location = New System.Drawing.Point(4, 107)
        Me.textBox_messagefile.Name = "textBox_messagefile"
        Me.textBox_messagefile.ReadOnly = True
        Me.textBox_messagefile.Size = New System.Drawing.Size(295, 20)
        Me.textBox_messagefile.TabIndex = 30
        '
        'label1_FileLocation
        '
        Me.label1_FileLocation.AutoSize = True
        Me.label1_FileLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1_FileLocation.Location = New System.Drawing.Point(1, 43)
        Me.label1_FileLocation.Name = "label1_FileLocation"
        Me.label1_FileLocation.Size = New System.Drawing.Size(143, 13)
        Me.label1_FileLocation.TabIndex = 29
        Me.label1_FileLocation.Text = "Location of Image Files:"
        '
        'Textbox_imagefolder
        '
        Me.Textbox_imagefolder.Location = New System.Drawing.Point(4, 59)
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
        Me.Button1_browse_image_location.Location = New System.Drawing.Point(305, 57)
        Me.Button1_browse_image_location.Name = "Button1_browse_image_location"
        Me.Button1_browse_image_location.Size = New System.Drawing.Size(75, 23)
        Me.Button1_browse_image_location.TabIndex = 48
        Me.Button1_browse_image_location.Text = "Browse"
        Me.Button1_browse_image_location.UseVisualStyleBackColor = True
        '
        'Button2_browse_message_file
        '
        Me.Button2_browse_message_file.Location = New System.Drawing.Point(306, 107)
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
        Me.EmailFilenameList.Location = New System.Drawing.Point(5, 75)
        Me.EmailFilenameList.Name = "EmailFilenameList"
        Me.EmailFilenameList.Size = New System.Drawing.Size(267, 20)
        Me.EmailFilenameList.TabIndex = 50
        '
        'Button3_browse_email_filename
        '
        Me.Button3_browse_email_filename.Enabled = False
        Me.Button3_browse_email_filename.Location = New System.Drawing.Point(305, 70)
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
        Me.Label8_PD.Location = New System.Drawing.Point(1, 16)
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
        Me.Label9_EmailListDescription.Location = New System.Drawing.Point(2, 41)
        Me.Label9_EmailListDescription.Name = "Label9_EmailListDescription"
        Me.Label9_EmailListDescription.Size = New System.Drawing.Size(322, 26)
        Me.Label9_EmailListDescription.TabIndex = 55
        Me.Label9_EmailListDescription.Text = "The file list must have the following format (separated by a comma):" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1st Column:" & _
    " Filename , 2nd Column: Email Address (No Header)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'ProgDir2
        '
        Me.ProgDir2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProgDir2.Location = New System.Drawing.Point(96, 16)
        Me.ProgDir2.Name = "ProgDir2"
        Me.ProgDir2.Size = New System.Drawing.Size(277, 18)
        Me.ProgDir2.TabIndex = 57
        Me.ProgDir2.Text = "c:\EPE"
        '
        'Button_SaveAsDefault
        '
        Me.Button_SaveAsDefault.Location = New System.Drawing.Point(408, 588)
        Me.Button_SaveAsDefault.Name = "Button_SaveAsDefault"
        Me.Button_SaveAsDefault.Size = New System.Drawing.Size(92, 25)
        Me.Button_SaveAsDefault.TabIndex = 62
        Me.Button_SaveAsDefault.Text = "Save Settings"
        Me.Button_SaveAsDefault.UseVisualStyleBackColor = True
        '
        'MainStatusBox
        '
        Me.MainStatusBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainStatusBox.Location = New System.Drawing.Point(408, 164)
        Me.MainStatusBox.Multiline = True
        Me.MainStatusBox.Name = "MainStatusBox"
        Me.MainStatusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.MainStatusBox.Size = New System.Drawing.Size(372, 334)
        Me.MainStatusBox.TabIndex = 64
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabel.Location = New System.Drawing.Point(422, 26)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(78, 20)
        Me.StatusLabel.TabIndex = 65
        Me.StatusLabel.Text = "STATUS"
        Me.StatusLabel.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(408, 504)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(370, 20)
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
        Me.CancelButton1.Location = New System.Drawing.Point(687, 588)
        Me.CancelButton1.Name = "CancelButton1"
        Me.CancelButton1.Size = New System.Drawing.Size(92, 25)
        Me.CancelButton1.TabIndex = 72
        Me.CancelButton1.Text = "CANCEL"
        Me.CancelButton1.UseVisualStyleBackColor = True
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
        'OpenImageFolderButton
        '
        Me.OpenImageFolderButton.ImageKey = "(none)"
        Me.OpenImageFolderButton.Location = New System.Drawing.Point(163, 34)
        Me.OpenImageFolderButton.Name = "OpenImageFolderButton"
        Me.OpenImageFolderButton.Size = New System.Drawing.Size(108, 22)
        Me.OpenImageFolderButton.TabIndex = 83
        Me.OpenImageFolderButton.Text = "Open Image Folder"
        Me.OpenImageFolderButton.UseVisualStyleBackColor = True
        '
        'ConnectionStatusResultLabel
        '
        Me.ConnectionStatusResultLabel.AutoSize = True
        Me.ConnectionStatusResultLabel.Location = New System.Drawing.Point(528, 140)
        Me.ConnectionStatusResultLabel.Name = "ConnectionStatusResultLabel"
        Me.ConnectionStatusResultLabel.Size = New System.Drawing.Size(94, 13)
        Me.ConnectionStatusResultLabel.TabIndex = 85
        Me.ConnectionStatusResultLabel.Text = "Connection Status"
        '
        'CheckConnectionTimer
        '
        Me.CheckConnectionTimer.Enabled = True
        Me.CheckConnectionTimer.Interval = 300000
        '
        'CheckSMTPtimerdots
        '
        Me.CheckSMTPtimerdots.Interval = 10000
        '
        'ignoreJPG
        '
        Me.ignoreJPG.AutoSize = True
        Me.ignoreJPG.Enabled = False
        Me.ignoreJPG.Location = New System.Drawing.Point(175, 19)
        Me.ignoreJPG.Name = "ignoreJPG"
        Me.ignoreJPG.Size = New System.Drawing.Size(142, 17)
        Me.ignoreJPG.TabIndex = 114
        Me.ignoreJPG.Text = "Check if "".jpg"" is omitted"
        Me.ignoreJPG.UseVisualStyleBackColor = True
        '
        'CheckBox2_emailfilename
        '
        Me.CheckBox2_emailfilename.AutoSize = True
        Me.CheckBox2_emailfilename.Location = New System.Drawing.Point(5, 21)
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
        Me.ConfigureEmailButton.Size = New System.Drawing.Size(53, 22)
        Me.ConfigureEmailButton.Text = "Settings"
        '
        'AboutUsButton
        '
        Me.AboutUsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AboutUsButton.Image = CType(resources.GetObject("AboutUsButton.Image"), System.Drawing.Image)
        Me.AboutUsButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AboutUsButton.Name = "AboutUsButton"
        Me.AboutUsButton.Size = New System.Drawing.Size(60, 22)
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
        Me.CustomerInfoLabel.Location = New System.Drawing.Point(217, 36)
        Me.CustomerInfoLabel.Name = "CustomerInfoLabel"
        Me.CustomerInfoLabel.Size = New System.Drawing.Size(106, 13)
        Me.CustomerInfoLabel.TabIndex = 116
        Me.CustomerInfoLabel.Text = "Customer Information"
        '
        'FacebookLogoOnForm1
        '
        Me.FacebookLogoOnForm1.BackgroundImage = Global.EventPhotoEmailer.My.Resources.Resources.facebook_image
        Me.FacebookLogoOnForm1.Enabled = False
        Me.FacebookLogoOnForm1.Image = Global.EventPhotoEmailer.My.Resources.Resources.facebook_image
        Me.FacebookLogoOnForm1.InitialImage = Nothing
        Me.FacebookLogoOnForm1.Location = New System.Drawing.Point(50, 20)
        Me.FacebookLogoOnForm1.Name = "FacebookLogoOnForm1"
        Me.FacebookLogoOnForm1.Size = New System.Drawing.Size(121, 45)
        Me.FacebookLogoOnForm1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.FacebookLogoOnForm1.TabIndex = 117
        Me.FacebookLogoOnForm1.TabStop = False
        '
        'HoodWatchFolderOnTimer
        '
        Me.HoodWatchFolderOnTimer.Interval = 10000
        '
        'FacebookCaptionTextBox1
        '
        Me.FacebookCaptionTextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.FacebookCaptionTextBox1.Location = New System.Drawing.Point(147, 122)
        Me.FacebookCaptionTextBox1.Name = "FacebookCaptionTextBox1"
        Me.FacebookCaptionTextBox1.Size = New System.Drawing.Size(234, 20)
        Me.FacebookCaptionTextBox1.TabIndex = 123
        Me.FacebookCaptionTextBox1.Text = "Uploaded by EPEv5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "Facebook Caption:"
        '
        'FacebookAuth_indicatorLabel
        '
        Me.FacebookAuth_indicatorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FacebookAuth_indicatorLabel.Location = New System.Drawing.Point(192, 37)
        Me.FacebookAuth_indicatorLabel.Name = "FacebookAuth_indicatorLabel"
        Me.FacebookAuth_indicatorLabel.Size = New System.Drawing.Size(92, 13)
        Me.FacebookAuth_indicatorLabel.TabIndex = 129
        Me.FacebookAuth_indicatorLabel.Text = "Un-Authenticated"
        Me.FacebookAuth_indicatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(407, 528)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Emails Sent:"
        '
        'EmailSentCounterLabel
        '
        Me.EmailSentCounterLabel.AutoSize = True
        Me.EmailSentCounterLabel.Location = New System.Drawing.Point(467, 528)
        Me.EmailSentCounterLabel.Name = "EmailSentCounterLabel"
        Me.EmailSentCounterLabel.Size = New System.Drawing.Size(13, 13)
        Me.EmailSentCounterLabel.TabIndex = 133
        Me.EmailSentCounterLabel.Text = "0"
        '
        'EmailNotSentLabel
        '
        Me.EmailNotSentLabel.AutoSize = True
        Me.EmailNotSentLabel.ForeColor = System.Drawing.Color.Black
        Me.EmailNotSentLabel.Location = New System.Drawing.Point(656, 528)
        Me.EmailNotSentLabel.Name = "EmailNotSentLabel"
        Me.EmailNotSentLabel.Size = New System.Drawing.Size(13, 13)
        Me.EmailNotSentLabel.TabIndex = 135
        Me.EmailNotSentLabel.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(567, 528)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 134
        Me.Label6.Text = "Emails NOT Sent:"
        '
        'Facebooksentlabel
        '
        Me.Facebooksentlabel.AutoSize = True
        Me.Facebooksentlabel.Location = New System.Drawing.Point(557, 528)
        Me.Facebooksentlabel.Name = "Facebooksentlabel"
        Me.Facebooksentlabel.Size = New System.Drawing.Size(13, 13)
        Me.Facebooksentlabel.TabIndex = 137
        Me.Facebooksentlabel.Text = "0"
        Me.Facebooksentlabel.Visible = False
        '
        'FBSentLabel
        '
        Me.FBSentLabel.AutoSize = True
        Me.FBSentLabel.Location = New System.Drawing.Point(478, 528)
        Me.FBSentLabel.Name = "FBSentLabel"
        Me.FBSentLabel.Size = New System.Drawing.Size(83, 13)
        Me.FBSentLabel.TabIndex = 136
        Me.FBSentLabel.Text = "Facebook Sent:"
        Me.FBSentLabel.Visible = False
        '
        'fbNotSentLabel
        '
        Me.fbNotSentLabel.AutoSize = True
        Me.fbNotSentLabel.Location = New System.Drawing.Point(767, 528)
        Me.fbNotSentLabel.Name = "fbNotSentLabel"
        Me.fbNotSentLabel.Size = New System.Drawing.Size(13, 13)
        Me.fbNotSentLabel.TabIndex = 139
        Me.fbNotSentLabel.Text = "0"
        Me.fbNotSentLabel.Visible = False
        '
        'FBNotSentLBL
        '
        Me.FBNotSentLBL.AutoSize = True
        Me.FBNotSentLBL.Location = New System.Drawing.Point(667, 528)
        Me.FBNotSentLBL.Name = "FBNotSentLBL"
        Me.FBNotSentLBL.Size = New System.Drawing.Size(103, 13)
        Me.FBNotSentLBL.TabIndex = 138
        Me.FBNotSentLBL.Text = "Facebook Not Sent:"
        Me.FBNotSentLBL.Visible = False
        '
        'ChkConnectionButton
        '
        Me.ChkConnectionButton.Location = New System.Drawing.Point(410, 135)
        Me.ChkConnectionButton.Name = "ChkConnectionButton"
        Me.ChkConnectionButton.Size = New System.Drawing.Size(112, 23)
        Me.ChkConnectionButton.TabIndex = 140
        Me.ChkConnectionButton.Text = "Check Connection"
        Me.ChkConnectionButton.UseVisualStyleBackColor = True
        '
        'AlbumComboBox
        '
        Me.AlbumComboBox.FormattingEnabled = True
        Me.AlbumComboBox.Location = New System.Drawing.Point(147, 92)
        Me.AlbumComboBox.Name = "AlbumComboBox"
        Me.AlbumComboBox.Size = New System.Drawing.Size(233, 21)
        Me.AlbumComboBox.TabIndex = 141
        Me.AlbumComboBox.Text = "Event Photos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "Facebook Photo Album:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimeIntervalLabel
        '
        Me.TimeIntervalLabel.AutoSize = True
        Me.TimeIntervalLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeIntervalLabel.Location = New System.Drawing.Point(243, 27)
        Me.TimeIntervalLabel.Name = "TimeIntervalLabel"
        Me.TimeIntervalLabel.Size = New System.Drawing.Size(70, 13)
        Me.TimeIntervalLabel.TabIndex = 122
        Me.TimeIntervalLabel.Text = "Time interval:"
        '
        'MyXMLDataSet
        '
        Me.MyXMLDataSet.DataSetName = "NewDataSet"
        '
        'EmailOnlyRadio
        '
        Me.EmailOnlyRadio.AutoSize = True
        Me.EmailOnlyRadio.Checked = True
        Me.EmailOnlyRadio.Location = New System.Drawing.Point(16, 71)
        Me.EmailOnlyRadio.Name = "EmailOnlyRadio"
        Me.EmailOnlyRadio.Size = New System.Drawing.Size(80, 17)
        Me.EmailOnlyRadio.TabIndex = 144
        Me.EmailOnlyRadio.TabStop = True
        Me.EmailOnlyRadio.Text = "Email Only?"
        Me.EmailOnlyRadio.UseVisualStyleBackColor = True
        '
        'FacebookOnlyRadio
        '
        Me.FacebookOnlyRadio.AutoSize = True
        Me.FacebookOnlyRadio.Enabled = False
        Me.FacebookOnlyRadio.Location = New System.Drawing.Point(133, 68)
        Me.FacebookOnlyRadio.Name = "FacebookOnlyRadio"
        Me.FacebookOnlyRadio.Size = New System.Drawing.Size(103, 17)
        Me.FacebookOnlyRadio.TabIndex = 144
        Me.FacebookOnlyRadio.Text = "Facebook Only?"
        Me.FacebookOnlyRadio.UseVisualStyleBackColor = True
        '
        'EmailAndFacebookRadio
        '
        Me.EmailAndFacebookRadio.AutoSize = True
        Me.EmailAndFacebookRadio.Enabled = False
        Me.EmailAndFacebookRadio.Location = New System.Drawing.Point(253, 68)
        Me.EmailAndFacebookRadio.Name = "EmailAndFacebookRadio"
        Me.EmailAndFacebookRadio.Size = New System.Drawing.Size(128, 17)
        Me.EmailAndFacebookRadio.TabIndex = 144
        Me.EmailAndFacebookRadio.Text = "Email and Facebook?"
        Me.EmailAndFacebookRadio.UseVisualStyleBackColor = True
        '
        'FacebookGroupBox
        '
        Me.FacebookGroupBox.Controls.Add(Me.EmailAndFacebookRadio)
        Me.FacebookGroupBox.Controls.Add(Me.FacebookOnlyRadio)
        Me.FacebookGroupBox.Controls.Add(Me.EmailOnlyRadio)
        Me.FacebookGroupBox.Controls.Add(Me.AlbumComboBox)
        Me.FacebookGroupBox.Controls.Add(Me.Label1)
        Me.FacebookGroupBox.Controls.Add(Me.FacebookAuth_indicatorLabel)
        Me.FacebookGroupBox.Controls.Add(Me.Label3)
        Me.FacebookGroupBox.Controls.Add(Me.FacebookCaptionTextBox1)
        Me.FacebookGroupBox.Controls.Add(Me.FacebookLogoOnForm1)
        Me.FacebookGroupBox.Location = New System.Drawing.Point(8, 327)
        Me.FacebookGroupBox.Name = "FacebookGroupBox"
        Me.FacebookGroupBox.Size = New System.Drawing.Size(384, 148)
        Me.FacebookGroupBox.TabIndex = 145
        Me.FacebookGroupBox.TabStop = False
        Me.FacebookGroupBox.Text = "Facebook"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ignoreJPG)
        Me.GroupBox2.Controls.Add(Me.CheckBox2_emailfilename)
        Me.GroupBox2.Controls.Add(Me.Label9_EmailListDescription)
        Me.GroupBox2.Controls.Add(Me.Button3_browse_email_filename)
        Me.GroupBox2.Controls.Add(Me.EmailFilenameList)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 532)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(385, 100)
        Me.GroupBox2.TabIndex = 146
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Email from a directory file"
        '
        'MainGroupBox
        '
        Me.MainGroupBox.Controls.Add(Me.OpenImageFolderButton)
        Me.MainGroupBox.Controls.Add(Me.Button2_browse_message_file)
        Me.MainGroupBox.Controls.Add(Me.Label8_PD)
        Me.MainGroupBox.Controls.Add(Me.Button1_browse_image_location)
        Me.MainGroupBox.Controls.Add(Me.ProgDir2)
        Me.MainGroupBox.Controls.Add(Me.label3_subject)
        Me.MainGroupBox.Controls.Add(Me.textBox_SubjectLine)
        Me.MainGroupBox.Controls.Add(Me.label2_message)
        Me.MainGroupBox.Controls.Add(Me.textBox_messagefile)
        Me.MainGroupBox.Controls.Add(Me.label1_FileLocation)
        Me.MainGroupBox.Controls.Add(Me.Textbox_imagefolder)
        Me.MainGroupBox.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MainGroupBox.Location = New System.Drawing.Point(7, 57)
        Me.MainGroupBox.Name = "MainGroupBox"
        Me.MainGroupBox.Size = New System.Drawing.Size(384, 187)
        Me.MainGroupBox.TabIndex = 147
        Me.MainGroupBox.TabStop = False
        Me.MainGroupBox.Text = "Main"
        '
        'AutomodeGroupBox
        '
        Me.AutomodeGroupBox.Controls.Add(Me.ManualSendRadio)
        Me.AutomodeGroupBox.Controls.Add(Me.AutoSendRadio)
        Me.AutomodeGroupBox.Controls.Add(Me.TimeIntervalTextBox)
        Me.AutomodeGroupBox.Controls.Add(Me.TimeIntervalLabel)
        Me.AutomodeGroupBox.Location = New System.Drawing.Point(7, 263)
        Me.AutomodeGroupBox.Name = "AutomodeGroupBox"
        Me.AutomodeGroupBox.Size = New System.Drawing.Size(385, 51)
        Me.AutomodeGroupBox.TabIndex = 148
        Me.AutomodeGroupBox.TabStop = False
        Me.AutomodeGroupBox.Text = "Automatic Mode"
        '
        'ManualSendRadio
        '
        Me.ManualSendRadio.AutoSize = True
        Me.ManualSendRadio.Checked = True
        Me.ManualSendRadio.Location = New System.Drawing.Point(136, 24)
        Me.ManualSendRadio.Name = "ManualSendRadio"
        Me.ManualSendRadio.Size = New System.Drawing.Size(95, 17)
        Me.ManualSendRadio.TabIndex = 123
        Me.ManualSendRadio.TabStop = True
        Me.ManualSendRadio.Text = "Send Manually"
        Me.ManualSendRadio.UseVisualStyleBackColor = True
        '
        'AutoSendRadio
        '
        Me.AutoSendRadio.AutoSize = True
        Me.AutoSendRadio.Location = New System.Drawing.Point(5, 24)
        Me.AutoSendRadio.Name = "AutoSendRadio"
        Me.AutoSendRadio.Size = New System.Drawing.Size(115, 17)
        Me.AutoSendRadio.TabIndex = 123
        Me.AutoSendRadio.Text = "Send Automatically"
        Me.AutoSendRadio.UseVisualStyleBackColor = True
        '
        'TimeIntervalTextBox
        '
        Me.TimeIntervalTextBox.Location = New System.Drawing.Point(318, 24)
        Me.TimeIntervalTextBox.Name = "TimeIntervalTextBox"
        Me.TimeIntervalTextBox.Size = New System.Drawing.Size(41, 20)
        Me.TimeIntervalTextBox.TabIndex = 121
        Me.TimeIntervalTextBox.Text = "2"
        '
        'ClearWindowButton
        '
        Me.ClearWindowButton.Location = New System.Drawing.Point(544, 588)
        Me.ClearWindowButton.Name = "ClearWindowButton"
        Me.ClearWindowButton.Size = New System.Drawing.Size(92, 25)
        Me.ClearWindowButton.TabIndex = 62
        Me.ClearWindowButton.Text = "Clear Window"
        Me.ClearWindowButton.UseVisualStyleBackColor = True
        '
        'MakeThinButton
        '
        Me.MakeThinButton.Location = New System.Drawing.Point(4, 16)
        Me.MakeThinButton.Name = "MakeThinButton"
        Me.MakeThinButton.Size = New System.Drawing.Size(133, 20)
        Me.MakeThinButton.TabIndex = 0
        Me.MakeThinButton.Text = "Activate MakeThin"
        Me.MakeThinButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.MakeThinButton)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 485)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(384, 39)
        Me.GroupBox1.TabIndex = 149
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Image Modifications"
        '
        'SendSavedEmailButton
        '
        Me.SendSavedEmailButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SendSavedEmailButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.SendSavedEmailButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SendSavedEmailButton.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SendSavedEmailButton.ForeColor = System.Drawing.Color.Black
        Me.SendSavedEmailButton.Location = New System.Drawing.Point(410, 619)
        Me.SendSavedEmailButton.Name = "SendSavedEmailButton"
        Me.SendSavedEmailButton.Size = New System.Drawing.Size(370, 29)
        Me.SendSavedEmailButton.TabIndex = 150
        Me.SendSavedEmailButton.Text = "SEND Saved Emails"
        Me.SendSavedEmailButton.UseVisualStyleBackColor = False
        Me.SendSavedEmailButton.Visible = False
        '
        'StoppedButton
        '
        Me.StoppedButton.BackColor = System.Drawing.Color.Red
        Me.StoppedButton.Location = New System.Drawing.Point(626, 26)
        Me.StoppedButton.Name = "StoppedButton"
        Me.StoppedButton.Size = New System.Drawing.Size(95, 23)
        Me.StoppedButton.TabIndex = 80
        Me.StoppedButton.Text = "Stopped"
        Me.StoppedButton.UseVisualStyleBackColor = False
        Me.StoppedButton.Visible = False
        '
        'SENDINGBUTTON
        '
        Me.SENDINGBUTTON.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SENDINGBUTTON.Location = New System.Drawing.Point(528, 27)
        Me.SENDINGBUTTON.Name = "SENDINGBUTTON"
        Me.SENDINGBUTTON.Size = New System.Drawing.Size(92, 23)
        Me.SENDINGBUTTON.TabIndex = 79
        Me.SENDINGBUTTON.Text = "Sending"
        Me.SENDINGBUTTON.UseVisualStyleBackColor = False
        Me.SENDINGBUTTON.Visible = False
        '
        'WiFiSigProgressLabel
        '
        Me.WiFiSigProgressLabel.AutoSize = True
        Me.WiFiSigProgressLabel.Location = New System.Drawing.Point(490, 31)
        Me.WiFiSigProgressLabel.Name = "WiFiSigProgressLabel"
        Me.WiFiSigProgressLabel.Size = New System.Drawing.Size(71, 13)
        Me.WiFiSigProgressLabel.TabIndex = 131
        Me.WiFiSigProgressLabel.Text = "WiFi Strength"
        '
        'WiFiProgressBar_SignalStrength
        '
        Me.WiFiProgressBar_SignalStrength.Location = New System.Drawing.Point(647, 140)
        Me.WiFiProgressBar_SignalStrength.Name = "WiFiProgressBar_SignalStrength"
        Me.WiFiProgressBar_SignalStrength.Size = New System.Drawing.Size(100, 13)
        Me.WiFiProgressBar_SignalStrength.TabIndex = 130
        '
        'Testbutton
        '
        Me.Testbutton.Location = New System.Drawing.Point(366, 29)
        Me.Testbutton.Name = "Testbutton"
        Me.Testbutton.Size = New System.Drawing.Size(156, 23)
        Me.Testbutton.TabIndex = 151
        Me.Testbutton.Text = "TestButton"
        Me.Testbutton.UseVisualStyleBackColor = True
        Me.Testbutton.Visible = False
        '
        'Config1ButtonFrontPage
        '
        Me.Config1ButtonFrontPage.Location = New System.Drawing.Point(410, 54)
        Me.Config1ButtonFrontPage.Name = "Config1ButtonFrontPage"
        Me.Config1ButtonFrontPage.Size = New System.Drawing.Size(156, 23)
        Me.Config1ButtonFrontPage.TabIndex = 152
        Me.Config1ButtonFrontPage.Text = "Configuration 1"
        Me.Config1ButtonFrontPage.UseVisualStyleBackColor = True
        '
        'Config2ButtonFrontPage
        '
        Me.Config2ButtonFrontPage.Location = New System.Drawing.Point(619, 54)
        Me.Config2ButtonFrontPage.Name = "Config2ButtonFrontPage"
        Me.Config2ButtonFrontPage.Size = New System.Drawing.Size(156, 23)
        Me.Config2ButtonFrontPage.TabIndex = 153
        Me.Config2ButtonFrontPage.Text = "Configuration 2"
        Me.Config2ButtonFrontPage.UseVisualStyleBackColor = True
        '
        'Config4ButtonFrontPage
        '
        Me.Config4ButtonFrontPage.Location = New System.Drawing.Point(619, 95)
        Me.Config4ButtonFrontPage.Name = "Config4ButtonFrontPage"
        Me.Config4ButtonFrontPage.Size = New System.Drawing.Size(156, 23)
        Me.Config4ButtonFrontPage.TabIndex = 155
        Me.Config4ButtonFrontPage.Text = "Configuration 4"
        Me.Config4ButtonFrontPage.UseVisualStyleBackColor = True
        '
        'Config3ButtonFrontPage
        '
        Me.Config3ButtonFrontPage.Location = New System.Drawing.Point(410, 95)
        Me.Config3ButtonFrontPage.Name = "Config3ButtonFrontPage"
        Me.Config3ButtonFrontPage.Size = New System.Drawing.Size(156, 23)
        Me.Config3ButtonFrontPage.TabIndex = 154
        Me.Config3ButtonFrontPage.Text = "Configuration 3"
        Me.Config3ButtonFrontPage.UseVisualStyleBackColor = True
        '
        'EPEForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(792, 659)
        Me.Controls.Add(Me.Config4ButtonFrontPage)
        Me.Controls.Add(Me.Config3ButtonFrontPage)
        Me.Controls.Add(Me.Config2ButtonFrontPage)
        Me.Controls.Add(Me.Config1ButtonFrontPage)
        Me.Controls.Add(Me.Testbutton)
        Me.Controls.Add(Me.SendSavedEmailButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MainGroupBox)
        Me.Controls.Add(Me.AutomodeGroupBox)
        Me.Controls.Add(Me.ChkConnectionButton)
        Me.Controls.Add(Me.fbNotSentLabel)
        Me.Controls.Add(Me.FBNotSentLBL)
        Me.Controls.Add(Me.Facebooksentlabel)
        Me.Controls.Add(Me.FBSentLabel)
        Me.Controls.Add(Me.EmailNotSentLabel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.EmailSentCounterLabel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.WiFiSigProgressLabel)
        Me.Controls.Add(Me.WiFiProgressBar_SignalStrength)
        Me.Controls.Add(Me.CustomerInfoLabel)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ConnectionStatusResultLabel)
        Me.Controls.Add(Me.SENDINGBUTTON)
        Me.Controls.Add(Me.StoppedButton)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.MainStatusBox)
        Me.Controls.Add(Me.Button_SaveAsDefault)
        Me.Controls.Add(Me.CustomerInfo)
        Me.Controls.Add(Me.ClearWindowButton)
        Me.Controls.Add(Me.CancelButton1)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.GoButton)
        Me.Controls.Add(Me.Credit)
        Me.Controls.Add(Me.Title)
        Me.Controls.Add(Me.FacebookGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EPEForm1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Event Photos"
        Me.ContextMenuStrip_ForNotificationIcon.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.FacebookLogoOnForm1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyXMLDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FacebookGroupBox.ResumeLayout(False)
        Me.FacebookGroupBox.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MainGroupBox.ResumeLayout(False)
        Me.MainGroupBox.PerformLayout()
        Me.AutomodeGroupBox.ResumeLayout(False)
        Me.AutomodeGroupBox.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents GoButton As System.Windows.Forms.Button
    Private WithEvents label3_subject As System.Windows.Forms.Label
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
    Friend WithEvents MainStatusBox As System.Windows.Forms.TextBox
    Private WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents CustomerInfo As System.Windows.Forms.Label
    Friend WithEvents CancelButton1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip_ForNotificationIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowEPE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideEPE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitEPE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenImageFolderButton As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ConnectionStatusResultLabel As System.Windows.Forms.Label
    Friend WithEvents CheckConnectionTimer As System.Windows.Forms.Timer
    Friend WithEvents CheckSMTPtimerdots As System.Windows.Forms.Timer
    Friend WithEvents ignoreJPG As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2_emailfilename As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ConfigureEmailButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents BW_EmailerDirectory As System.ComponentModel.BackgroundWorker
    Friend WithEvents BW_EmailerParcer As System.ComponentModel.BackgroundWorker
    Friend WithEvents BW_LetsGo As System.ComponentModel.BackgroundWorker
    Friend WithEvents CustomerInfoLabel As System.Windows.Forms.Label
    Friend WithEvents AboutUsButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents FacebookLogoOnForm1 As System.Windows.Forms.PictureBox
    Friend WithEvents HoodWatchFolderOnTimer As System.Windows.Forms.Timer
    Friend WithEvents FacebookCaptionTextBox1 As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FacebookAuth_indicatorLabel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents EmailSentCounterLabel As System.Windows.Forms.Label
    Friend WithEvents EmailNotSentLabel As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Facebooksentlabel As System.Windows.Forms.Label
    Friend WithEvents FBSentLabel As System.Windows.Forms.Label
    Friend WithEvents fbNotSentLabel As System.Windows.Forms.Label
    Friend WithEvents FBNotSentLBL As System.Windows.Forms.Label
    Friend WithEvents ChkConnectionButton As System.Windows.Forms.Button
    Friend WithEvents AlbumComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents TimeIntervalLabel As System.Windows.Forms.Label
    Friend WithEvents MyXMLDataSet As System.Data.DataSet
    Friend WithEvents EmailOnlyRadio As System.Windows.Forms.RadioButton
    Friend WithEvents FacebookOnlyRadio As System.Windows.Forms.RadioButton
    Friend WithEvents EmailAndFacebookRadio As System.Windows.Forms.RadioButton
    Friend WithEvents FacebookGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents MainGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents AutomodeGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ManualSendRadio As System.Windows.Forms.RadioButton
    Friend WithEvents AutoSendRadio As System.Windows.Forms.RadioButton
    Friend WithEvents TimeIntervalTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ClearWindowButton As System.Windows.Forms.Button
    Friend WithEvents MakeThinButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents SendSavedEmailButton As System.Windows.Forms.Button
    Public WithEvents textBox_SubjectLine As System.Windows.Forms.TextBox
    Friend WithEvents StoppedButton As System.Windows.Forms.Button
    Friend WithEvents SENDINGBUTTON As System.Windows.Forms.Button
    Friend WithEvents WiFiSigProgressLabel As System.Windows.Forms.Label
    Friend WithEvents WiFiProgressBar_SignalStrength As System.Windows.Forms.ProgressBar
    Friend WithEvents Testbutton As System.Windows.Forms.Button
    Friend WithEvents Config1ButtonFrontPage As System.Windows.Forms.Button
    Friend WithEvents Config2ButtonFrontPage As System.Windows.Forms.Button
    Friend WithEvents Config4ButtonFrontPage As System.Windows.Forms.Button
    Friend WithEvents Config3ButtonFrontPage As System.Windows.Forms.Button

End Class
