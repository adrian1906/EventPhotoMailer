Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.Diagnostics.Debug
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Collections
Imports System.Diagnostics.Process
Imports System.Environment
Imports Facebook_Graph_Toolkit.GraphApi
Imports Facebook_Graph_Toolkit
Imports JSON
Imports System.Net
Imports System.Web
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Web.Security
Imports System.Web.UI.WebControls
Imports System.Web.UI.Control
Imports System.Text
Imports System.Net.Mail
Imports System.Management
Imports System.Drawing
Imports System.Xml
Imports System.Net.Sockets.TcpClient
Imports System.Data

'''<summary>
''' This is the source code for Event Photo Emailer. The main goal of this program is to email photos and post images onto Facebook. 
''' <history>
''' 11-20-2009 Added the check for filenames that start with $ This is an indicator that Darkroom did 
''' not have an email address attached to the file. If not moved, an error will be generated. I wrote
''' code to move this to a folder called "not named". This folder is in the EventFolder.
'''
''' 12-20 Wrote code that sends multiple images to a single email address. This works by taking inventory
''' of all the different email addresses and their corresponding image files. For the email address containing
''' more than a single image, an array is created and a filenameSTRING is created that has the form
''' image1.jpg;image20.jpg;image450.jpg' This is done before the email engine is called
''' When writing this code, the task of saving the truncated email file to the Event Eolder was relegated
''' to the "parsing stage" from the "sendemail stage".
'''
''' 12-24 Wrote code that will allow the automatic sending of emails by monitoring a specified folder
'''
''' 12-26 A VB based emailing library was purchased in order to eliminate the use of the DOS based emailing program
''' and the limitations console batch programming. This program requires an unlocking key to unlock the see32.dll file
''' It also has a see64.dll to use when compiling on a 64bit machine. The 32 bit compilation should work ok on both 
''' 64 bit and 32 bit machines (Note: the emailer has since been changed to the .Net.mail version)
''' 
''' 1/10/10 Added the ability to save the delay information. The delay is beneficial in the print to email mode in that it 
''' waits before collecting images to email. If a person is getting multiple images, it may send the first as soon as it comes
''' then when finished, send the others
''' 1/10/10 Re-wrote code so that, when emails are created via Darkroom Pro, the working files will be deleted. However, they will only 
''' be deleted after a successfull send. This is so that if an error occurs in a batch email, it would be easy to pick
''' up where one leaves off
'''
''' 2-24 Added code to automatically run DarkroomShortcut_WinZ.exe program that produces a shortcut that
''' opens the photodata box and inserts email text.
''' 2-24 added code that stops DarkroomShortcut_WinZ.exe when the program is exited via 'X' or via system tray
''' 2-24 Added code to check for an intermittent connection before proceeding with the email process. This way, 
''' no files are deleted or folders produced unnessesarily. CheckEmailConnection()
''' 2-24 Added code that minimizes the window to the system tray and offers 3 options (hide,show,exit)
''' 2-24Added a start/stop indicator.
''' 2-24 Created a structure variable for the Error variable.
'''
''' 2-26 Updated the version to 3.0
'''
''' 3-3 Changed the way that I handle the company's name. I wrote an encryption program that will 
''' encrypt text. This way, I can encrypt the company's name and email address and supply a license code
''' In compiling the code, CompanyName is set to "Evaluation" and "Return Email is "EVAL@SomeCompany.com"
''' Also, the message box is locked. 
''' The password was also encrypted.
''' 3-3 Changed to version 3-1-0-0
''' 
''' 4-20 RIP Dr. Heights.... Today, created an installer.
'''
''' 5-17 Fixed case for which the port address is different than 25. In checkconnection(), I had failed to 
''' set the port number before checking the connection. On my home system, the default 25 worked so the issue
''' was not flagged. Verizon FIOS recently blocked 25 and switched to 587 and the code stopped working. This is 
''' what drew me to this omission.
''' 5-17 For cases for which the given email address is unroutable (Code = -49), a message is displayed saying
''' that the file is not routable and it is skipped. This will keep appearing until it is manually fixed.
''' 5-17 It was noticed that a time delay is needed after the program makes an initial check for connectivity. Originally
''' I had 1 second, but I changed it to 5 seconds. This 5 second delay will be experienced each time the send button is
''' pressed or a new run (when in auto mode).
'''
''' 8-1 It was noticed that the UI became unresponsive when the watchfolder was active. This was fixed by placing
''' GOButton (renamed to LetsGo() ) in its own thread RunGO()
'''
''' 8-23 Added an internet connection status label
''' 8-23 Added a standby notice
''' 8-23 Added code that allows autoemail and confirmation selections to be saved.
'''
''' 9-2  Addressed issue with auto email mode for which files enter the folder quickly. Since this process is placed on a 
'''thread, there exist the possibilty of mulitple threads being launched for each file
'''
''' Oct 29, created the option to disable the email combining feature.
'''
''' Nov 1, added module to check for valid email address (IsValidEmail)
'''
''' March 8, 2011 - Added code to first access POP3. (I recieved a call from someone who said that their provider requires both pop3 
''' authentication and smtp authenication. The current command is simply Code = seePop3Connect(0, textBox_MailServer.Text, 
''' textBox_Username.Text, textBox_Password.Text) 
''' if Code=>0, then it is ok.
'''
''' March 8, 2011 - Added code to send email to Facebook. If the box is checked, the email address is replaced by the Facebook email.
'''
''' April 16, 2011 - Fixed problem with streamline.net not sending out emails. I was told that I had to 1st check incoming 
''' email and then outgoing. It did not work. 
''' After updating the emailing class see4VB it worked as long as the return to email is a derivative of the IP company. 
''' For version 51, I removed the incoming field.
'''
''' April 24, 2011 - Last week I created a Facebook App and modified the code to incorporate the app. 
''' Currently, it just uploads to the same folder. However, in the future, it will create folders and then add to them. 
''' The Faceebook Graph Toolkit is used.
''' I added a master email list that will keep adding emails across events
''' I got rid of the different event folders. Now, event folders are limited to the day they are created
''' I added a separate form to handle the configuration information
''' Added email only, facebook only, facebook and  email
''' Modified the packages to include 3 EPE printers  A0 A1 A2
''' Modified .reg files to install the 3 EPE printers
''' May 10, 2011
''' Changed the way Facebook is Authenticated. A webbrowser is loaded and the person logs in.
''' Fixed a bug. I created a dummy email address to use in TestEmail(). The email address is epedumm@hoodandson.com. This 
''' address is set to route all mail to the trash so no info is saved on my server. In cleaning up my site,
''' I had deleted ''' this email address. This caused a Mail Not Deliverable Error. I re-created the email address and hopefully 
''' I will not forget what its for.
''' A check for internet connection is now done when the send button is pressed. This feature can be disabled 
''' using a checkbox on the setup dialog box.
''' I added a feature that will check the image folder for residual images when the program loads.
''' This is to avoid associating a previous event with the current one.
''' 2/5/2012 - Congrats NY Giants...I mean NFC EAST
''' This weekend I updated to code to reflect version 2.6 of Facebook Toolkit
''' This version changed the way that publishphoto was handled and did away with UserID
''' I noticed an issue with the possiblity to create multiple albums with the same name. (Will Need Another Facebook plugin)
''' I will need to look into way this is possible. Check the AlbumID numbers against the known numbers as a start.
''' Also, on the setup, I set the .NET framework launch condition to 'ANY'. Hopefully this will aid when depoloying the code. 
''' So far zero errors and zero warning.
''' May 2012 - Removed requirement for licensing. (Data is entered on Form 2) 
'''          - Data is now stored in an XML file.
''' If using Facebook/Email option, the email will contain the link to the album (not the individual photo)
''' The message file must contian '****" in the body.
''' April 2, 2015  - Checks email with TestSMTP to eliminate using epedummy@hoodandson.com to do the checks.
''' 
''' PROBLEM  March 11 , 2016. There appears to be problems with infinite loops. I believe this is due to the way I reference a form
''' from another form. It looks like using Dim MyForm as new Form1 will keep calling Form1. This is found int EmailPromptForm.
''' I will try to solve this later. I need to go to bed.
''' March 16 - It looks like the method to properly reference other forms is not to create an instance of the form, but use My.Forms
''' instead. This is possible if the form is already in the project. This is based on the information found here:
''' https://msdn.microsoft.com/library/ms172723(v=vs.100).aspx
''' I figured it out.
''' In an attempt to clear the SavedEmails object I used SavedEmails = Nothing where I should have used SavedEmails.clear
''' Because of this, an exception was thrown. I failed to handle it properly...I ignored it...NEVER DO THIS.
''' Because of this 'bug', I lost many hours and I changed the code alot
''' March 19 - Cleaned up "Prompt for Email Address" feature in the Email Setup Prompt. There are only 3 option now. Two
''' Will prompt and one will not.  The "send later' checkbox on the Email Prompt Form emulates the setting in the Email Setup Form
''' It can be overridden only for the current instance. To make the override condition the defualt, it is best to change the 
''' setting in the Email Setup Form.
''' TODO.. I still need to clean up the checkboxes so that only one checked and the others are not. I may switch over to the radios.
''' I tested the send later featured and the images were successfully sent to the EmailLater folder. I then chose the EmailViaDarkroom setting,
''' dragged the images from the EmailLater folder into the hotfolder, and all of the images were sent properly.
'''</history>
'''</summary>
''' 
Public Class EPEForm1

    'If there is a failure to authenticate, then the Facebook feature should be disabled. The Facebook Check boxes should be
    'grayed out until authentication is complete. If internet connection is intermittent, a Try-Catch loop should be used
    'to keep the images around until a connection becomes avaialable.
    Inherits System.Windows.Forms.Form
    '**********************************   DEFINE GLOBAL STRUCTURES   ********************************** 
    Structure MAILERRORHOOD
        Dim SMTPerrorMessage As String
        Dim SMTPOK As Boolean
    End Structure
    Structure CompanyInfoSTRUCTURE
        Dim CompanyName As String
        Dim CompanyEmail As String
        Dim Flagg As Boolean
        Dim EvaluationMode As Boolean
    End Structure
    Structure HoodFacebookInfo
        Dim MYAPIinfo As Facebook_Graph_Toolkit.GraphApi.Api ' Contains the access token and expire
        Dim MYALBUMID As String
        Dim MYAID As String
        Dim MyALBUMNAME As String
        Dim MyLink As String
        Dim MyAlbumLink As String
        Dim ErrorGettingAccessToken As Boolean
        Dim FanPage As String
    End Structure
    '**********************************   DEFINE GLOBAL VARIABLES   **********************************   
    ' Global variables can be defined using Dim, Public, or Private. 
    'Public MyForm2 As New EmailSetupForm()
    'Public MyEmailSetupForm As New EmailSetupForm()


    'Public BuildType As String = "Keep Reply To Company Name"
    'Public SiteToPing As String = "74.125.93.147" 'Google used to detect internet connection availability
    Public SiteToPing As String = "google.com" 'Google used to detect internet connection availability
    Public MyMakeThinForm As New MakeThin.MakeThinForm
    Public CompanyEmail As String
    'Public UserCompanyName As String
    Public CancelFlagg As String = "Run"   ' Needed to be able to cancel the emailing program
    Public Code As Integer                 ' used as the returned variable for the seeVB library (email library)
    Public NullString As String            ' used with seeVB
    Public StatusFile As String
    Public EventFolder As String
    Public WithEvents WatchFolder As New System.IO.FileSystemWatcher()
    Public chkemailconn As Boolean
    Public AutoEmailFlagg As Boolean       ' Use to signal other control to go invisible and to use only one event folder
    Public SENDEMAILFLAGG As Boolean = True
    Public WinZProgram As New Process()    ' Used to run Shortcup program. Check if it exists first.
    Public WinZShortcut As String = "DarkroomShortcut_WinZ"
    ' NewImagesAreReady is used in autosend mode to detect that new images have been added while
    ' sendemail is processing previous photos
    Public NewImagesAreReady As Boolean = False
    Public SmtpErrorCodeGlobal As Integer
    Public FacebookCustomerInfo As HoodFacebookInfo
    Public CurrentDirectory As String = Environment.CurrentDirectory
    ' Note: CommonApplicationData ==> c:\ProgramData (Not accessible)
    ' Note: [AppDataFolder] is used as the defaultlocation is the deployment project for SpecialFolder.ApplicationData
    'Public CommonDirectory As String = Environment.GetFolderPath(SpecialFolder.ApplicationData) & "\EventPhotoEmailer"
    ' Note: Folder had to be changed to something easy. Darkroom does not recognize the %appdata% variable..bummer
    Public CommonDirectory As String = "c:\EventPhotoEmailer"
    'Public CommonDirectory As String = Environment.GetFolderPath(SpecialFolder.CommonProgramFiles) & "\EventPhotoEmailer"
    Public DefaultImageDirectory As String = CurrentDirectory & "\EPE_Hotfolder"
    Public DefaultFile0 As String = CommonDirectory & "\Defaults0.xml"
    Public DefaultFile1 As String = CommonDirectory & "\Defaults1.xml"
    Public DefaultFile2 As String = CommonDirectory & "\Defaults2.xml"
    Public DefaultFile3 As String = CommonDirectory & "\Defaults3.xml"
    Public DefaultFile4 As String = CommonDirectory & "\Defaults4.xml"
    Public CurrentDefaultFileUsed As String = DefaultFile0
    Public CHECKCONNECTIONYESNO As Boolean = True
    Public SENDEMAILFINISHEDFLAGG As Boolean = True
    Public SENDEMAILFromEmailReadyFolderFLAGG As Boolean = False
    Public FACEBOOKERRORONCE As Boolean = True
    Public FACEBOOKERROR As Boolean = False
    ' checktimerOK is used to keep the timer from checking internet connection while webpage is loading for Facebook mode
    Public checktimerOK As Boolean = True
    Public RunningInAutoMode As Boolean = False
    Public InitialConnectionCheck As Boolean = True
    Public POSTONFACEBOOKYESNO As Boolean = False ' used to keep from actually uploading
    'Public COMPDATA As CompanyInfoSTRUCTURE
    Public emailsentcounter As Integer = 0
    Public emailNOTsentcounter As Integer = 0
    Public facebooksentcounter As Integer = 0
    Public fbnotsentcounter As Integer = 0
    Public IsForm2Open As Boolean = False
    Public PhotoFacebookAlbumURL As String = Nothing
    Public ContinueOrCancel As String = Nothing
    Public ChkInt As String = Nothing
    Public PostEmailPromptYesNo As Boolean = Nothing
    Public CheckForIntConnectYesNo As Boolean = False
    Public Email1Save As String = Nothing ' used to save previous email entry
    Public Email2Save As String = Nothing ' used to save previous email entry
    Public Email3Save As String = Nothing ' used to save previous email entry
    Public Email4Save As String = Nothing ' used to save previous email entry
    Public Email5Save As String = Nothing ' used to save previous email entry
    Public Name1Save As String = Nothing ' used to save previous email entry
    Public Name2Save As String = Nothing ' used to save previous email entry
    Public Name3Save As String = Nothing ' used to save previous email entry
    Public Name4Save As String = Nothing ' used to save previous email entry
    Public Name5Save As String = Nothing ' used to save previous email entry
    Public tryagain As Integer = 1
    Public MaxTries As Integer = 5
    Public Shared SavedEmails As New AutoCompleteStringCollection()
    Public Shared SavedNames As New AutoCompleteStringCollection()
    Public InitialStart As Boolean = True
    Public EmailTable As DataTable
    'Public MyFacebookForm As New FacebookGUI()
    'Public EmailPrompt As New EmailPrompt()
    'Dim BuildType As Boolean = True ' True allows the Reply To address to Change
    Public BuildType As Boolean = False ' True allows the Reply To address to Change
    Public RepeatEmailsInEmailPrompt As Boolean = False ' Used for cases win which all photos are going to the same set of individuals
    Public RepeatEmailsInEmailPromptLock As Boolean = False ' Used for cases win which all photos are going to the same set of individuals
    Public PullFilesFromDirectoryFlag As Boolean = False
    Public MyAdFileLabel As String = Nothing
    ' **************************************  MAIN SUBROUTINES *****************
    ''' <summary>
    ''' Form1_Load() does the following:
    ''' sets CheckForIllegalCrossTread = False
    ''' Runs the splash screenf
    ''' Initializes Email engine
    ''' Check for an initial internet connection
    ''' Reads setup data from saved file
    ''' Sets up toolstrip comments
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks> </remarks>
    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        'TODO Get rid of all Checks for illegal cross thread calls
        SplashScreen1.Show()
        pause(2000)
        SplashScreen1.Close()
        Me.Text = " Event Photo Emailer - Version: " & My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Revision

        '''' AddHandler GoButton.Click, AddressOf RunGo 'changed on June 26, 2015
        '******************************************* Initialization Code For Emailer Library *********"
        ProgDir2.Text = CurrentDirectory
        ' ******************************************* Hide WiFi indicators
        WiFiProgressBar_SignalStrength.Visible = True
        WiFiSigProgressLabel.Visible = False

        ' ******************************************* Set Default Field Settings
        'Dim Myresult As New List(Of WirelessInfoHood)()
        'Myresult = GetWirelessSignalStrength()
        ''MyResult = RetrieveSignalStrength()
        WinZProgram.StartInfo.FileName = CurrentDirectory & "\bin\" & WinZShortcut & ".exe"
        'WinZProgram.StartInfo.FileName = CurrentDirectory & "\EventPhotoEmailer\bin\" & WinZShortcut
        WinZProgram.StartInfo.Arguments = " "
        Try

            If File.Exists(WinZProgram.StartInfo.FileName) Then
                If IsProcessRunning(WinZShortcut) = False Then
                    WinZProgram.Start()
                End If
            End If

        Catch ex As Exception
            MsgBox("The Win-Z Darkroom Shortcut was not initialized")
        End Try

        Fill_ISP_Listbox(CurrentDirectory & "\bin") ' import latest company SMTP server list ("\bin\SMTPServerList.csv")
        ImportDefaults(CurrentDefaultFileUsed) ' Set to DefaultFile0 earlier
        Config0ButtonFrontPage.BackColor = Color.Green
        ' ******************************************* TOOLTIPS
        ToolTip1.SetToolTip(AutomodeGroupBox, "This feature allows EPE to" & vbCrLf & _
                            "run in the background. The image folder is checked at " & vbCrLf & _
                            "the set time interval.")
        ToolTip1.SetToolTip(EmailSetupForm.EmailCombineCheckBox, "By default, images to the same email address " & vbCrLf & _
                            "are combined into one email. Check this box to send the images individually. ")
        ToolTip1.SetToolTip(EmailSetupForm.CheckBox_ConfirmationEmail, "Check this box if you would like an email also" & vbCrLf & _
                            " sent to your company's email address")
        ToolTip1.SetToolTip(FacebookGroupBox, "Allows images to be sent to Facebook. Click the Facebook button to Authenticate Facebook")


        ' *******************************************
        ContextMenuStrip_ForNotificationIcon.Visible = False
        MainStatusBox.Text = "Ready. " & vbCrLf
        CheckConnectionTimer.Enabled = False
        CheckForResidualImages(Textbox_imagefolder.Text) ' Checks to see if images are in the main folder first.
        GetEmailsFromMasterDirectory()

        'Check if emails are in the EmailLater Folder:
        Try
            Dim listing As ArrayList = getJPGfiles(Textbox_imagefolder.Text & "\EmailLater")
            If listing.Count > 0 Then
                SendSavedEmailButton.Visible = True
            Else
                SendSavedEmailButton.Visible = False
            End If
        Catch ex As Exception
            Debug.Print("Problem checking " & Textbox_imagefolder.Text & "\EmailLater")
        End Try

    End Sub

    ''' <summary>
    ''' ImportDefaults imports the defalut information from text files
    ''' </summary>
    ''' <param name="DefaultFileToUse"></param>
    ''' <remarks>
    ''' 'defaults.txt order:
    ''' '1 Subject Line 2 Image Folder 3 Message file 4 Mail Server Username 5 Port box 6 Time Interval 7 Facebook Login
    ''' '8 Confirmation state 9 combine email 10 mail encryption </remarks>
    ''' 

    Public Sub ImportDefaults(ByVal DefaultFileToUse As String)
        'TODO  - update to put data in textboxes.
        If DefaultFileToUse = DefaultFile0 Then
            EmailSetupForm.CurrentConfigLabel.Text = "Configuration 0 is being used."
        ElseIf DefaultFileToUse = DefaultFile1 Then
            EmailSetupForm.CurrentConfigLabel.Text = "Configuration 1 is being used."
        ElseIf DefaultFileToUse = DefaultFile2 Then
            EmailSetupForm.CurrentConfigLabel.Text = "Configuration 2 is being used."
        ElseIf DefaultFileToUse = DefaultFile3 Then
            EmailSetupForm.CurrentConfigLabel.Text = "Configuration 3 is being used."
        ElseIf DefaultFileToUse = DefaultFile4 Then
            EmailSetupForm.CurrentConfigLabel.Text = "Configuration 4 is being used."
        End If

        Dim mydata As DEFAULTDATA = Nothing ' Defined in EPEModule.vb
        If File.Exists(DefaultFileToUse) Then
            mydata = GetXMLData(DefaultFileToUse)
        End If
        ' Textboxes

        textBox_SubjectLine.Text = mydata.SubjectLine
        Textbox_imagefolder.Text = mydata.ImageFolder
        If Textbox_imagefolder.Text = "" Then
            Textbox_imagefolder.Text = CommonDirectory & "\EPE_Hotfolder"
        End If
        textBox_messagefile.Text = mydata.MessageFile
        If textBox_messagefile.Text = Nothing Then
            textBox_messagefile.Text = CommonDirectory & "\message.txt"
        End If
        TimeIntervalTextBox.Text = mydata.TimeInterval
        EmailSetupForm.CheckBox_ConfirmationEmail.CheckState = BooleanToCheckState(mydata.ConfimEmailBool)
        EmailSetupForm.EmailCombineCheckBox.CheckState = BooleanToCheckState(mydata.CombineEmailsBool)
        Try
            With EmailSetupForm
                .CompNameTextbox.Text = mydata.CompanyName
                .CompEmailTextbox.Text = mydata.CompanyEmail
                .textBox_MailServer.Text = mydata.MailServer
                .textBox_Username.Text = mydata.UserName
                .PortBox.Text = mydata.Port
                .AdLabel2.Text = mydata.Adfile
                .EmailMasterListFilename.Text = mydata.EmailMasterListName
                .IncludeAdCheckBox.CheckState = BooleanToCheckState(mydata.UseAdLabelBool)
                .UseMasterListCheckbox.CheckState = BooleanToCheckState(mydata.UseMasterListBool)
                .IncludeAdCheckBox.CheckState = BooleanToCheckState(mydata.UseAdLabelBool)
                .SSLcheckBox.CheckState = BooleanToCheckState(mydata.UseSSLBool)
                .Checkbox_CheckForIntConnectYesNo.CheckState = BooleanToCheckState(mydata.CheckInternetConnectionBool)
                .PromptForEmailAndSend_CheckBox.CheckState = BooleanToCheckState(mydata.PromptForEmailAndSend)
                .DontPromptForEmail_AddviaDarkroom_Checkbox.CheckState = BooleanToCheckState(mydata.EmailAddressViaDarkroom)
                .PromptForEmailDontSend_CheckBox.CheckState = BooleanToCheckState(mydata.PromptForEmailDontSend)
                .textBox_Password.Text = MyDecryption(mydata.PWDEncrypt) ' This textbox only shows dots
                .AttachFilesYesNoCheckbox.CheckState = BooleanToCheckState(mydata.AttachFilesYesNo)
                .LowerLeftRadioButton.Checked = Convert.ToBoolean(mydata.NotifyLL)
                .LowerRightRadioButton.Checked = Convert.ToBoolean(mydata.NotifyLR)
                .UpperLeftRadioButton.Checked = Convert.ToBoolean(mydata.NotifyUL)
                .UpperRightRadioButton.Checked = Convert.ToBoolean(mydata.NotifyUR)
            End With
            EmailPrompt.ApplyToAllCheckBox1.CheckState = BooleanToCheckState(mydata.RepeatEmailsInEmailPromptLock)
        Catch ex As Exception
            MsgBox("There was a problem loading your settings")
        End Try
        ''If COMPDATA.EvaluationMode = True Then
        ''    textBox_SubjectLine.ReadOnly = True
        ''    textBox_SubjectLine.Text = "Evaluation Mode"
        ''    FacebookCaptionTextBox1.ReadOnly = True
        ''    FacebookCaptionTextBox1.Text = "Evaluation: Event Photo Emailer www.hoodandson.com/EPE"
        ''Else

        ''End If
        textBox_SubjectLine.ReadOnly = False
        FacebookCaptionTextBox1.ReadOnly = False
        Dim sender As Object = Nothing
        Dim e As ErrorEventArgs = Nothing
    End Sub

    Public Function BooleanToCheckState(ByVal Mystring As String) As CheckState
        Dim MyCheckstate As CheckState
        If Mystring = "False" Then
            MyCheckstate = CheckState.Unchecked
        Else
            MyCheckstate = CheckState.Checked
        End If
        Return MyCheckstate
    End Function

    Public Function BooleanToCheck(ByVal Mystring As String) As CheckState
        Dim MyCheckstate As CheckState
        If Mystring = "False" Then
            MyCheckstate = CheckState.Unchecked
        Else
            MyCheckstate = CheckState.Checked
        End If
        Return MyCheckstate
    End Function

    Public Function CheckStateToBoolean(ByVal MyCheckState As CheckState) As String
        Dim MyString As String
        If MyCheckState = CheckState.Unchecked Then
            MyString = "False"
        Else
            MyString = "True"
        End If
        Return MyString
    End Function

    Public Sub SaveAsXMLPerformClick()
        Button_SaveAsDefault.PerformClick()
    End Sub

    Public Sub SaveAsXML(ByVal sender As Object, ByVal e As EventArgs) Handles Button_SaveAsDefault.Click
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        Dim MyInfoArraylist As New ArrayList
        MyInfoArraylist.Add("CompanyName" & "!" & EmailSetupForm.CompNameTextbox.Text)
        MyInfoArraylist.Add("CompanyEmail" & "!" & EmailSetupForm.CompEmailTextbox.Text)
        MyInfoArraylist.Add("SubjectLine" & "!" & textBox_SubjectLine.Text)
        MyInfoArraylist.Add("ImageFolder" & "!" & Textbox_imagefolder.Text)
        MyInfoArraylist.Add("MessageFile" & "!" & textBox_messagefile.Text)
        MyInfoArraylist.Add("MailServer" & "!" & EmailSetupForm.textBox_MailServer.Text)
        MyInfoArraylist.Add("UserName" & "!" & EmailSetupForm.textBox_Username.Text)
        MyInfoArraylist.Add("PWDEncrypt" & "!" & MyEncryption(EmailSetupForm.textBox_Password.Text))
        MyInfoArraylist.Add("Port" & "!" & EmailSetupForm.PortBox.Text)
        MyInfoArraylist.Add("TimeInterval" & "!" & TimeIntervalTextBox.Text)
        MyInfoArraylist.Add("EmailMasterListName" & "!" & EmailSetupForm.EmailMasterListFilename.Text)
        MyInfoArraylist.Add("UseMasterListBool" & "!" & CheckStateToBoolean(EmailSetupForm.UseMasterListCheckbox.CheckState))

        MyInfoArraylist.Add("ConfimEmailBool" & "!" & CheckStateToBoolean(EmailSetupForm.CheckBox_ConfirmationEmail.CheckState))
        MyInfoArraylist.Add("CombineEmailsBool" & "!" & CheckStateToBoolean(EmailSetupForm.EmailCombineCheckBox.CheckState))
        MyInfoArraylist.Add("UseSSLBool" & "!" & CheckStateToBoolean(EmailSetupForm.SSLcheckBox.CheckState))
        MyInfoArraylist.Add("CheckInternetConnectionBool" & "!" & CheckStateToBoolean(EmailSetupForm.Checkbox_CheckForIntConnectYesNo.CheckState))
        MyInfoArraylist.Add("Adfile" & "!" & EmailSetupForm.AdLabel2.Text)
        MyInfoArraylist.Add("UseAdLabelBool" & "!" & CheckStateToBoolean(EmailSetupForm.IncludeAdCheckBox.CheckState))

        MyInfoArraylist.Add("EmailAddressViaDarkroom" & "!" & CheckStateToBoolean(EmailSetupForm.DontPromptForEmail_AddviaDarkroom_Checkbox.CheckState))
        MyInfoArraylist.Add("PromptForEmailAndSend" & "!" & CheckStateToBoolean(EmailSetupForm.PromptForEmailAndSend_CheckBox.CheckState))
        MyInfoArraylist.Add("PromptForEmailDontSend" & "!" & CheckStateToBoolean(EmailSetupForm.PromptForEmailDontSend_CheckBox.CheckState))
        MyInfoArraylist.Add("RepeatEmailsInEmailPrompt" & "!" & CheckStateToBoolean(EmailPrompt.RepeatEmailsInEmailPrompt_Checkbox.CheckState))
        MyInfoArraylist.Add("RepeatEmailsInEmailPromptLock" & "!" & CheckStateToBoolean(EmailPrompt.ApplyToAllCheckBox1.CheckState))

        MyInfoArraylist.Add("NotifyUL" & "!" & EmailSetupForm.UpperLeftRadioButton.Checked.ToString)
        MyInfoArraylist.Add("NotifyUR" & "!" & EmailSetupForm.UpperRightRadioButton.Checked.ToString)
        MyInfoArraylist.Add("NotifyLL" & "!" & EmailSetupForm.LowerLeftRadioButton.Checked.ToString)
        MyInfoArraylist.Add("NotifyLR" & "!" & EmailSetupForm.LowerRightRadioButton.Checked.ToString)
        MyInfoArraylist.Add("AttachFilesYesNo" & "!" & CheckStateToBoolean(EmailSetupForm.AttachFilesYesNoCheckbox.CheckState))


        settings.Indent = True
        settings.OmitXmlDeclaration = False
        settings.NewLineOnAttributes = True
        ' Create XmlWriter.
        'TODO Getting an error message that file is in use
        Using writer As XmlWriter = XmlWriter.Create(CurrentDefaultFileUsed, settings)
            ' Begin writing.
            Dim counter As Integer
            Dim tmpp() As String
            writer.WriteStartDocument()
            writer.WriteStartElement("EPEConfig")
            For counter = 0 To MyInfoArraylist.Count - 1
                tmpp = Split(MyInfoArraylist(counter).ToString, "!")
                writer.WriteStartElement(tmpp(0))
                writer.WriteString(tmpp(1))
                writer.WriteEndElement()
                'writer.WriteElementString(tmpp(0), tmpp(1))
            Next
            writer.WriteEndElement()
            writer.WriteEndDocument()
            writer.Close()
        End Using
        EmailSetupForm.Hide()
    End Sub



#Region "MainProgram"

    ''' <summary>
    ''' RunGo() checks if LetsGo() is running in the background and if not, calls LetsGo()
    ''' Before attempting to send 
    ''' </summary>
    ''' <remarks> RunGo() is called by the watch folder as well as when the send email button is pressed.
    ''' It calls LetsGo() on a thread. If LetsGo() is busy, <c>NewImagesAreReady = TRUE</c>. This is based on the possibility
    ''' that the RunGo() event was raised as images were being added while emailing.
    ''' The <c>BW_LetsGo.RunWorkerCompleted</c> subroutine will check the flag to decide if to rerun the emailer. Note: the
    ''' <c>SENDEMAILFINISHEDFLAGG</c> is set during the SENDEMAIL subroutine</remarks>

    Public Sub RunGo()
        Dim temp() As String = Nothing
        Dim MyFilenames As New Collection

        ''If PostEmailPromptYesNo = True And Not FacebookOnlyRadio.Checked Then
        ''    MyFilenames = ConditionImageFolder()
        ''    For Each cc As String In MyFilenames
        ''        EmailPrompt(cc) ' Will return a string of emails separated by !.
        ''    Next
        ''End If
        If CheckForIntConnectYesNo = True Then
            ChkInt = checkinternetconnection()
        End If
        If ChkInt = "1" Or CheckForIntConnectYesNo = False Then 'send to Facebook before emailing
            If EmailAndFacebookRadio.Checked Or FacebookOnlyRadio.Checked Then
                Try
                    FBauth_click(Nothing, Nothing)
                Catch ex As Exception
                    MsgBox("There was a problem authorizing Facebook")
                End Try
            End If

            FACEBOOKERRORONCE = True 'used so that if there is a Facebook error, the message box only appears once.

            'If EmailAndFacebookRadio.Checked Then ' Don't send email if facebook only radio is checked.
            If BW_LetsGo.IsBusy = False Then
                If SENDEMAILFINISHEDFLAGG = True And InitialStart = False Then
                    BW_LetsGo.RunWorkerAsync() 'Handled by DoWork
                    NewImagesAreReady = False
                End If
                InitialStart = False ' Used to keep emails being sent out at startup.
            End If
            'End If
        Else ' case for no internet connection
            MsgBox("Unable to send. There is a problem connecting to the internet. If you would like to disable checks for internet connection, this can be done in the Setup Menu.")
            If AutoEmailFlagg Then
                HoodWatchFolderOnTimer.Stop()
                MainStatusBox.Clear()
                Display(MainStatusBox, "Automatic mail delivery has been disabled. " & _
                        "Use the green 'SEND EMAILS' button below to start the process manually.")
            End If
        End If
    End Sub

    ''' <summary>
    ''' EmailNewImages() is handled by <c>LetsGo.RunWorkerCompleted</c> to see if a rerun is needed
    ''' </summary>
    ''' <remarks>It is possible that new images may appear during processing. If so, a new trigger will result. If LetsGO()
    ''' is busy, this flag is set to let the program know to rerun RunGo(). This will occur until the folder is empty</remarks>
    Public Sub EmailNewImages(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BW_LetsGo.RunWorkerCompleted
        If NewImagesAreReady = True Then
            RunGo()
            NewImagesAreReady = False
        End If
    End Sub

    Public Sub EmailNewImagesFromReadyToSendFolder(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendSavedEmailButton.Click
        'If NewImagesAreReady = True Then
        SENDEMAILFromEmailReadyFolderFLAGG = True
        RunGo()
        NewImagesAreReady = False
        'End If
    End Sub
    ''' <summary>
    ''' Disabletextboxes() is used to avoid changes to these fields while processing
    ''' </summary>
    ''' <param name="Decision">A boolean to assign to textbox.enabled</param>
    ''' <remarks>While processing, values from these fields are referenced. If changed
    ''' while processing, an error can result. These are disabled to avoid these errors.</remarks>
    Public Sub enabletextboxes(ByVal Decision As Boolean)
        Textbox_imagefolder.Enabled = Decision
        EmailSetupForm.textBox_MailServer.Enabled = Decision
        textBox_messagefile.Enabled = Decision
        EmailSetupForm.textBox_Password.Enabled = Decision
        textBox_SubjectLine.Enabled = Decision
        EmailSetupForm.textBox_Username.Enabled = Decision
    End Sub

    ''' <summary>
    ''' SendEmail_AND_HandleControlsOnThread() is the main program.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>When RunGo() is called (via SEND button or WatchFolder trigger), LetsGo is ran.
    ''' Since form controls are called, the possibility of thread errors result. It is recommended
    ''' that all control calls be placed into the .ProgressChanged event. Instead of breaking the code
    ''' into parts that called controls and the parts that didn't, it was decided to have the entire
    ''' code handled by the .ProgressChanged event. The <c>LetGo()</c>
    ''' subroutine simply calls <c>BW_LetsGo.ReportProgress(1)</c> where 1 acts as a dummy value.   
    ''' When the send button is pressed, there are two loops to take
    ''' 1.) If a directory is being used, the <c>ReadFromDirectory()</c> is used. 
    ''' 2.) If the files are parsed, then <c>SendParsedEmails()</c>.
    ''' The global event folder is set in this subroutine with n name corresponding to the current date.
    ''' Currently, only .jpg files are handled</remarks>
    Public Sub SendEmail_AND_HandleControlsOnThread(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BW_LetsGo.ProgressChanged
        SENDEMAILFINISHEDFLAGG = False
        enabletextboxes(False)
        MainStatusBox.Clear() ' It is important that the clear status box appear after setting crossthreading to False
        ' Otherwise an unhandled fault will occur.
        ''''checkinternetconnection()
        If EmailSetupForm.Checkbox_CheckForIntConnectYesNo.Checked Then
            pause(1000)
        End If
        CancelFlagg = "Run"
        Dim chkSMTP As MAILERRORHOOD = Nothing
        chkSMTP.SMTPOK = True
        If CancelFlagg <> "Cancel" Then
            SENDINGBUTTON.Visible = True
            StoppedButton.Visible = False
            MainStatusBox.Clear()
            If (EmailSetupForm.PromptForEmailDontSend_CheckBox.Checked Or EmailSetupForm.Checkbox_CheckForIntConnectYesNo.Checked = False) And _
                SENDEMAILFromEmailReadyFolderFLAGG = False Then
                ' Dont check if email is available and proceed to email prompt
            Else ' check smtp server
                chkSMTP.SMTPOK = False ' initialize variable

                chkSMTP = MailHoodTest() ' sends test email
                'chkSMTP.SMTPOK = True
                'TODO redo MailHoodTest()
                If chkSMTP.SMTPOK Then
                    MainStatusBox.Text = "SMTP server found... Processing ... " & vbCrLf
                    pause(1000) ' introduce a 1 second pause to ensure that the SMTP check is complete
                End If
            End If  'Look for Email Prompt Only
            If chkSMTP.SMTPOK = False Then
                MainStatusBox.Clear()
                MainStatusBox.Text = chkSMTP.SMTPerrorMessage
                'Error message is displayed in the status box
                'The send email button will need to be pressed again.
                'do not run loop since no SMTP connection exist.
            Else ' Proceed forward
                ' ***** PRODUCE THE EVENT FOLDER (Needed for All cases, email only, facebook only, and both
                Dim MyDate As Date = Now
                'Dim MyDateString As String = MyDate.Month & "_" & MyDate.Day & "_" & MyDate.Year & "_" & MyDate.Hour & "_" & MyDate.Minute & "_" & MyDate.Second
                Dim MyDateString As String = MyDate.Month & MyDate.Day & MyDate.Year & MyDate.Hour & MyDate.Minute & MyDate.Second
                EventFolder = Textbox_imagefolder.Text & "\Event_" & MyDate.Year & "_" & MyDate.Month & "_" & MyDate.Day
                StatusFile = EventFolder & "\status.txt" ' Global Vector

                ' Before creating the EventFolder and starting to email, first check if ther are any images to email
                Dim listing As ArrayList
                If SENDEMAILFromEmailReadyFolderFLAGG = True Then
                    listing = getJPGfiles(Textbox_imagefolder.Text & "\EmailLater")
                    'SENDEMAILFromEmailReadyFolderFLAGG = False  ' Reset
                    'SendSavedEmailButton.Visible = False ' Do not reset here. Reset after SendEmails.
                Else
                    listing = getJPGfiles(Textbox_imagefolder.Text)
                End If
                If listing.Count > 0 Then
                    If Not Directory.Exists(EventFolder) Then
                        Directory.CreateDirectory(EventFolder)
                    End If
                    ' *************************************************
                    If CheckBox2_emailfilename.Checked Then ' Case for supplied list
                        SendEmailFromDirectory(Nothing, Nothing)
                    Else ' Case for which filenames are parsed to get email addresses and filenames
                        SendParsedEmails(Nothing, Nothing) ' called to do the cleanup work
                    End If
                Else
                    Display(MainStatusBox, "There are no images to send")
                End If
            End If
        End If
        enabletextboxes(True) ' Boxes are disabled during mailing to avoid inadvertant errors due to changing the boxes.
        SENDEMAILFINISHEDFLAGG = True ' global variable to indicate to RunGo() thats its ok to start again.
        StoppedButton.Visible = True
        SENDINGBUTTON.Visible = False
        Try
            Dim listing As ArrayList = getJPGfiles(Textbox_imagefolder.Text & "\EmailLater")
            If listing.Count > 0 Then
                SendSavedEmailButton.Visible = True
            Else
                SendSavedEmailButton.Visible = False
            End If
        Catch ex As Exception
            Debug.Print("Problem checking " & Textbox_imagefolder.Text & "\EmailLater")
        End Try
    End Sub

    ''' <summary>
    ''' LetsGo() calls <seealso>LetsGo.ProgressCompleted</seealso>
    ''' </summary>
    ''' <remarks>Code that should go here has been moved to .ProgressCompleted since it is better
    ''' in handling possible threading errors.</remarks>
    Public Sub LetsGO(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BW_LetsGo.DoWork
        ' Since ReportProgress can handle UI objects, I moved the code to be handled by it.
        ' the value 1 is just a dummy value
        BW_LetsGo.ReportProgress(1)
    End Sub


    ''' <summary>
    ''' SendEmailFromDirectory()
    ''' Sends emails based on information in the directory file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SendEmailFromDirectory(ByVal sender As Object, ByVal e As EventArgs) Handles BW_EmailerDirectory.DoWork
        StatusFile = EventFolder & "\status.txt"
        Dim temp() As String
        Dim temp3() As String
        Dim temp2 As String
        Dim email As String
        'Dim testspace_email() As String
        Dim counter2 As Integer
        'Dim testspace_CSVfile() As String
        Dim CheckFileFlagg As String = "True"
        'System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False ' needed to allow the use of controls. 
        'Normally they cannot be accessed without setting crosstread to false. This is set back to true at the end.
        'MsgBox("A new file has appeared. Counter = " & ii)
        'If Not File.Exists(EventFolder & "\status.txt") Then
        'MsgBox("Exist = " & File.Exists(EventFolder & "\status.txt") & " Event folder: " & EventFolder)
        MainStatusBox.Clear()
        MainStatusBox.Text = "Sending emails ... "
        Display(MainStatusBox, "")
        'End If
        'StatusBox.Clear()
        'Clear Contents (statusbox.clear() does not work as expected)
        'It writes the new data starting at the beginning but does not erase the contents already 
        'in the statusbox. The next set of lines writes blank likes over a lot of lines.

        If Not File.Exists(EmailFilenameList.Text) Then
            Display(MainStatusBox, "Error: Directory File not provided")
            Display(MainStatusBox, "Please provide the name of your directory file")
            CancelFlagg = "Cancel"
            Exit Sub
        Else
            Try

                ' Run 2 loops. First is to get a count of the number of emails to use in the status bar.
                ' The second actually sends out the emails.
                Dim fs3 As New FileStream(EmailFilenameList.Text, FileMode.Open, FileAccess.Read) ' Read supplied list
                Dim d3 As New StreamReader(fs3)
                Dim EmailFileLine As String
                d3.BaseStream.Seek(0, SeekOrigin.Begin)
                ' Count number of lines
                Dim linecounter = 0
                While d3.Peek() > -1
                    temp2 = d3.ReadLine()
                    linecounter += 1
                End While
                d3.Close()
                ' Start Sending Emails '
                Dim fs4 As New FileStream(EmailFilenameList.Text, FileMode.Open, FileAccess.Read)
                Dim d4 As New StreamReader(fs4)
                d4.BaseStream.Seek(0, SeekOrigin.Begin) ' start over
                Dim loopcounter As Integer = 1
                'Directory.CreateDirectory(EventFolder) ' This file is used to save the status.txt file and others.
                ' I decided to leave the images in the original positions because of the scenario for which the 
                ' customer may be using the original images and does not expect them to be moved. This is different 
                ' than the case for which the image files are created and parsed. The temparary images are not needed.
                ' Note: if a given email address has multiple files associated with it, it will currently get 
                ' multiple emails. It is expected that each filename cell contains only one filename (no parcing of
                ' the filenames like the case for which the files are created.
                ' The expected order is Column1: Filename  Column2: email address
                'File.Create(EventFolder & "\status.txt")
                'If MonitorFolderCheckBox.CheckState <> CheckState.Checked Then
                'File.Create(EventFolder & "\directory.csv")
                'End If
                'Note: The following code is set to handle the case for which multiple filenames are supplied
                'in the filename column (separated by ;).
                While d4.Peek() > -1
                    Dim filename As String = "" ' Due to the appending of the strings, Its important that after each loop, this variable is cleared
                    Dim filenameshortDirectory As String = ""
                    EmailFileLine = d4.ReadLine()
                    temp = Split(EmailFileLine, ",") 'filenamestring = temp(0) email = temp(1)
                    email = temp(1)
                    temp3 = Split(temp(0), ";") ' If multiple files... parse. This is necessary to append the images' path

                    ' create filename string
                    ' filenames are checked for spaces. If found, produce message box and bypass the file
                    If temp3.Length = 1 Then ' case for single file in filename field
                        If ignoreJPG.Checked Then
                            temp3(0) = temp3(0) & ".jpg" ' Case for Cedric of Washington who wants to avoid typing .jpg
                        End If
                        CheckFileExistence_And_Spaces(Textbox_imagefolder.Text & "\", temp3(0), CheckFileFlagg)
                        If CheckFileFlagg = "True" Then
                            filename = Textbox_imagefolder.Text & "\" & temp3(0)
                            filenameshortDirectory = temp3(0)
                        End If
                    Else ' Multiple Files
                        For counter2 = 0 To temp3.Length - 1
                            If ignoreJPG.Checked Then
                                temp3(counter2) = temp3(counter2) & ".jpg" ' Case for Cedric of Washington who wants to avoid typing .jpg
                            End If
                            CheckFileExistence_And_Spaces(Textbox_imagefolder.Text & "\", temp3(counter2), CheckFileFlagg)
                            If CheckFileFlagg = "True" Then
                                filenameshortDirectory = filenameshortDirectory & temp3(counter2)
                                filename = filename & Textbox_imagefolder.Text & "\" & temp3(counter2)
                                If counter2 < temp3.Length - 1 Then
                                    filename = filename & ";"
                                    filenameshortDirectory = filenameshortDirectory & ";"
                                End If
                            End If
                        Next
                    End If
                    'MsgBox("filename = " & filename & "  filenameshortDirectory = " & filenameshortDirectory)
                    'testspace_email = Split(email.ToString, " ")
                    'The purpose of the next line is to remove emails addresses that contain spaces. In test, it is found that
                    'The previous method used to test for spaces would still fail if there was space after the email address
                    'Because of this, I decided that I would just remove all spaces, even in the email address, and send on
                    'Chances are that would fix the space error, or they would get a bounced back email. What I want to 
                    'avoid is it crashing the program.
                    Dim EmailRemoveSpaces As String
                    EmailRemoveSpaces = Replace(email.ToString, " ", "")
                    ' Check email validity
                    Dim checkemail As Boolean = IsValidEmail(email.ToString)
                    If checkemail = False Then
                        Dim ErrorString As String = "is invalid. This file is ignored. You can edit the filename directly to fix the problem."
                        Display(MainStatusBox, email.ToCharArray & ErrorString)
                    Else
                        'If testspace_email.Length < 2 Then
                        'MsgBox(filename)
                        SENDEMAIL(EmailRemoveSpaces, filename, EventFolder, filenameshortDirectory, CancelFlagg, SENDEMAILFLAGG)
                        'Else
                        'MsgBox("Email address: " & email & " has spaces. No email is sent")
                        'End If
                        ' PROGRESS BAR
                        If linecounter <> 0 Then
                            ProgressBar1.Visible = True
                            ProgressBar1.Value = 100 * CType(Math.Round(loopcounter / linecounter), Integer)
                        End If
                        loopcounter += 1
                    End If
                End While
                d4.Close()
            Catch ex As Exception
                MsgBox("Error accessing file. Please make sure " & EmailFilenameList.Text & " is not open in another application like Excel")
            End Try
        End If
        If CancelFlagg <> "Cancel" And RunningInAutoMode = True Then
            'StatusBox.Text = StatusBox.Text & "Finished....."
            If ContinueOrCancel = "Cancel" Then
                Display(MainStatusBox, "Operation Cancelled....")
            Else
                Display(MainStatusBox, "Finished..........")
            End If
            StoppedButton.Visible = True
            SENDINGBUTTON.Visible = False
            ProgressBar1.Visible = False
        End If
    End Sub
    ''' <summary>
    ''' The expected format of the text file is:
    '''EventName,filename,emailaddress,Person's Name
    '''This file will get the information from the text files and populate two
    '''autocomplete variable: SavedEmails and SavedNames
    '''The user will have the option of which one to use.
    '''If they start typing in the name box, it will auto populate
    '''Then upon leaving, the email will appear.
    '''The opposite is true for typing in the email box.
    '''For both cases, the information is saved in the same format.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GetEmailsFromMasterDirectory()
        Dim objReader As StreamReader
        'Dim FullPath = "C:\EventPhotoEmailer\MasterEmailList.txt"
        Dim FullPath = EmailSetupForm.EmailMasterListFilename.Text
        Dim EmailFileLine As String
        Dim SkipLine1Flagg As Boolean = True
        Dim tmp() As String
        SavedEmails.Clear() ' Clear variable to avoid duplicates. This subroutine is updated after each email
        SavedNames.Clear()
        Try
            objReader = New StreamReader(FullPath)
            While objReader.EndOfStream = False
                EmailFileLine = objReader.ReadLine()
                If SkipLine1Flagg <> True Then ' Avoid top line
                    tmp = Split(EmailFileLine, ",")
                    If tmp.Length > 1 Then
                        If tmp.Length = 4 Then ' If names are saved with email address (will be in 4th column)
                            SavedEmails.Add(tmp(2) & "---" & tmp(3))
                            SavedNames.Add(tmp(3) & "---" & tmp(2))
                        ElseIf tmp.Length = 3 Then ' case for which no name is given
                            SavedEmails.Add(tmp(2) & "--- ") ' No Name Attached. Keep space afterward so that a "" will returned for tmp(3) later
                            'TODO  --- Still need to work out the logic---too tired now.
                            SavedNames.Add(" ---" & tmp(2)) 'No Name Attached. Keep space afterward so that a "" will returned for tmp(3) later
                        End If
                    End If
                End If
                    SkipLine1Flagg = False
                    Debug.Print("Reading in line: " & SavedEmails.Count & " at: " & System.DateTime.Now)
            End While
            objReader.Close()
        Catch ex As Exception
            MsgBox("Error in GetEmailsFromMasterDirectory()" & vbCrLf & ex.Message)
        End Try
        EmailTable = ConvertEmailFileToTable(EmailSetupForm.EmailMasterListFilename.Text) 'not used yet
    End Sub


    ''' <summary>
    ''' SendParsedEmails()
    ''' Sends emails with email address(es) encoded into the filename.
    ''' This is done on its own thread
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SendParsedEmails(ByVal sender As Object, ByVal e As EventArgs) Handles BW_EmailerParcer.DoWork
        Dim StatusFile As String = EventFolder & "\status.txt"
        Dim counter As Integer
        Dim filecounter As Integer = 1
        Dim ParseEmail() As String
        Dim emailarray(0) As String ' Used to sort and gather files
        Dim filenamearray(0) As String ' Used to sort and gather files
        Dim CustNameArray(0) As String ' Used to sort and gather files
        Dim testspace_email() As String
        Dim jj As Integer
        Dim oldfilename As String = Nothing
        Dim newfilename As String = Nothing
        Dim filenameshort(0) As String
        Dim temp() As String
        Dim temp2() As String
        Dim emailstring(0) As String ' An array used to parse the email for multiple emails using the split command
        Dim filenamestring(0) As String ' An array used to parse the filename for multiple files
        Dim emailshortstring(0) As String
        Dim CustNameString(0) As String
        Dim filenameshortstring(0) As String
        Dim kk, kkk As Integer
        Dim tempstring As String
        Dim copyok As Boolean = True
        Dim EmailString2 As String
        Dim NameString As String
        Dim ParseName() As String
        Dim FileReadyStatus As Boolean
        Dim WaitTime As Integer = 10000 ' Max wait time for a file to indicate that it is ready
        If SENDEMAILFromEmailReadyFolderFLAGG = False Then
            tempstring = Textbox_imagefolder.Text
        Else
            tempstring = Textbox_imagefolder.Text & "\EmailLater"
        End If
        'Dim str As New IO.DirectoryInfo(Textbox_imagefolder.Text)
        Dim str As New IO.DirectoryInfo(tempstring)
        Dim SendLaterFlagg As Boolean = False
        'Dim NoEmailFilename As IO.FileInfo() = str.GetFiles("$*.jpg") 'Image with no email will just start with $

        'If MonitorFolderCheckBox.CheckState = CheckState.Checked Then
        'pause(CType(DelayTextBox1.Text, Integer) * 1000)
        'System.Threading.Thread.Sleep(CType(DelayTextBox1.Text, Integer) * 1000) 'I believe the trigger occurs when file appears but not when finished.
        ' A delay is needed for the file to be created and ready to send. This value is dependent on the computer
        ' and the filesize of the image to be created. The default is 2 seconds. Later, I may include a form
        ' field that will allow this value to be entered.        'End If

        'Delete all files starting with $
        'Code was added to allow uploading to Facebook. When this occurs, only the Facebook email address is used. For this reason,
        'it is not necessary to check for filenames missing email addresses. So the following code will make the check only if the Facebook
        'checkbox is not selected.
        'todo have code bypass parsing the email when no email exist (for cases when simply uploading to facebook)
        If EmailSetupForm.PromptForEmailAndSend_CheckBox.Checked Or EmailSetupForm.PromptForEmailDontSend_CheckBox.Checked Then
            PostEmailPromptYesNo = True
        Else
            PostEmailPromptYesNo = False
        End If
        If EmailOnlyRadio.Checked And PostEmailPromptYesNo = False Then
            CheckForNonEmailedJPGFiles()
        End If

        'Now get remaining files. Note, I need to make allowance for other files sneaking into the directory
        'Note, chances are slim that a file that sneaked in has a $ in its name. Therefore, that file will fail with temp < 2
        'and the subroutine will be halted.
        Dim listing As IO.FileInfo() = str.GetFiles("*.jpg") ' Currently, only .jpg files are emailed
        Dim NumOfFiles As Double = listing.Length
        ' Sort Listing First
        counter = 0
        Dim fullstringcounter As Integer = 0
        For Each fullstring In listing ' This loops parses the files and produces arrays for email() and filename()
            FileReadyStatus = WaitForFileAvailibility(fullstring.FullName, WaitTime)
            If FileReadyStatus = False Then
                fullstringcounter += 1
                temp = Split(fullstring.Name, "$") 'temp(0):email temp(1):filename
                'MsgBox("Filename = " & fullstring.Name & "   FullstringCounter = " & fullstringcounter & "  temp(0): " & temp(0) & "  temp(1): " & temp(1))
                If temp.Length < 2 Then 'indicates that there was no $ in the string. Will need to add the $ to proceed
                    ReDim Preserve temp(1)
                    temp(1) = temp(0)
                    temp(0) = ""
                End If

                'First copy image to the event folder truncating the email address(s)
                oldfilename = tempstring & "\" & fullstring.Name
                newfilename = EventFolder & "\" & temp(1)

                If File.Exists(newfilename) Then
                    Dim tmp() As String = Split(newfilename, ".jpg")
                    newfilename = tmp(0) & "_1.jpg"
                    'File.Delete(newfilename) 'An attempt was made to append the file with a counter but
                    ' book keeping got a little cumbersome. I may return to this but now, it simply 
                    ' deletes the old file
                End If
                File.Copy(oldfilename, newfilename, True)

                'Now, split up the emails (just in case there are more than one)
                'Here, ! is used as a delimiter because in Express Digital, it was one of only a few 
                'That was honored by the Raster Image Printer. Commas and Colons were ignored and #,%,&,*,etc, all had
                'pre-determined functions.
                'The parsing and collecting code works as follows. Firts, it sorts the data by email and then filename
                'This makes like emails consecutive.
                'Then the code systematically goes through the entries in the sorted order, keeping track of the email address
                'field and noting when a new email address is reached. The filenames are collected for like email addresses
                'into an array and eventually merged into a form that is easily read by the emailing program. For example, the current format
                'is file1.jpg;file2.jpg,ect  The files are simply separated by a semicolon.
                'If (PostEmailPromptYesNo = True And Not FacebookOnlyRadio.Checked) And SENDEMAILFromEmailReadyFolderFLAGG = False Then
                'ToDo .. Need to fix this DrHood
                If EmailSetupForm.PromptForEmailDontSend_CheckBox.Checked Or EmailSetupForm.PromptForEmailAndSend_CheckBox.Checked And Not FacebookOnlyRadio.Checked And SENDEMAILFromEmailReadyFolderFLAGG = False Then
                    ''If PullFilesFromDirectoryFlag = False Then
                    ''    GetEmailsFromMasterDirectory() '  Pull the latest email list to update SentEmails object
                    ''    'Note: it takes forever for a long email list to populate on the second attemp
                    ''    'PullFilesFromDirectoryFlag = True
                    ''End If
                    temp(0) = EmailPromptFunction(newfilename) ' Will return a string of emails separated by !. It will also return matching Names separated by "**"
                    If temp(0) = "EmailLater" Then
                        File.Delete(oldfilename) ' Will only delete if there is no error
                        SendLaterFlagg = True
                    Else
                        If temp(0) = "" Then ' case for cancel or blank lines
                            Dim Msboxreply As Integer = MsgBox("A valid email address is required. Would you like to try again?", MsgBoxStyle.YesNoCancel)
                            If Msboxreply = 1 Then ' OK
                                ' ''If PullFilesFromDirectoryFlag = False Then
                                ''GetEmailsFromMasterDirectory() '  Pull the latest email list to update SentEmails object
                                ''PullFilesFromDirectoryFlag = True
                                ' ''End If

                                temp(0) = EmailPromptFunction(newfilename) 'returns EmailString2 ** NameString
                                ContinueOrCancel = Nothing ' reset
                                If temp(0) = "" Then
                                    MsgBox("Emailing has been aborted.") ' canceled again
                                    ContinueOrCancel = Nothing ' reset
                                End If
                            Else
                                MsgBox("Emailing has been aborted.") ' canceled again
                                ContinueOrCancel = Nothing ' reset
                                Exit Sub ' Exits the SendParsedEmails function (No value needs to be returned)
                            End If
                        End If
                    End If
                End If ' Email later


                If temp(0) <> "EmailLater" Then
                    'Separate Saved Names from Saved Email Addresses
                    temp2 = Split(temp(0), "**") ' File returend as emailaddress1!emailddress2**Name1!Name2
                    If temp2.Count > 1 Then ' Feature is used
                        EmailString2 = temp2(0)
                        NameString = temp2(1)
                    Else ' Saved Name feature is not used yet
                        EmailString2 = temp(0)
                        NameString = temp(1)
                    End If
                    ParseName = Split(NameString, "!") ' need to ensure that names match.
                    'ParseEmail = Split(temp(0), "!") ' Checks for more than one recipient
                    ParseEmail = Split(EmailString2, "!") ' Checks for more than one recipient

                    'MsgBox("Before Parse: emailarray.Length = " & emailarray.Length & " ParseEmail.length = " & ParseEmail.Length)
                    If ParseEmail.Length > 1 Then
                        For jj = 0 To ParseEmail.Length - 1
                            'MsgBox("ParseEmail =" & ParseEmail(jj).ToString)
                            'MsgBox("emailarray.length = " & emailarray.Length & "UBound(emailarray) = " & UBound(emailarray))
                            'MsgBox("Before Redim: emailarray.Length = " & emailarray.Length)
                            If counter + jj > 0 Then
                                ReDim Preserve emailarray(emailarray.Length)
                                ReDim Preserve filenamearray(filenamearray.Length)
                                ReDim Preserve filenameshort(filenameshort.Length)
                                ReDim Preserve CustNameArray(CustNameArray.Length)
                            End If
                            emailarray(counter + jj) = ParseEmail(jj).ToString
                            filenameshort(counter + jj) = temp(1)
                            CustNameArray(counter + jj) = ParseName(jj).ToString
                            'filenamearray(counter + jj) = EventFolder & "\" & temp(1)
                            'MsgBox("emailarray: " & emailarray(counter + jj) & "  filenamearray: " & filenamearray(counter + jj))
                            'Debug.WriteLine("Counter: " & counter + jj & "  Emailarray: " & emailarray(counter + jj))
                            'MsgBox("Counter: " & counter & " jj: " & jj & "  Emailarray: " & emailarray(counter + jj))
                            'MsgBox("jj= " & jj & " counter = " & counter & " emailarray.Length = " & emailarray.Length)
                            'MsgBox("emailarray: " & emailarray(counter + jj) & "  filenamearray: " & filenamearray(counter + jj) & " filenameshort: " & filenameshort(counter + jj))
                        Next
                        counter += jj
                    Else
                        If counter >= 1 Then
                            ReDim Preserve emailarray(emailarray.Length)
                            ReDim Preserve filenamearray(filenamearray.Length)
                            ReDim Preserve filenameshort(filenameshort.Length)
                            ReDim Preserve CustNameArray(CustNameArray.Length)
                        End If
                        'MsgBox("Filename = " & fullstring.Name & "   FullstringCounter = " & fullstringcounter & "  temp(0): " & temp(0) & "  temp(1): " & temp(1))
                        'MsgBox("Counter: " & counter & "  Emailarray: " & emailarray(counter) & " temp: " & temp(0) & "  " & temp(1))
                        emailarray(counter) = temp2(0)
                        filenameshort(counter) = temp(1)
                        'filenamearray(counter) = EventFolder & "\" & temp(1) ' filenamearray gives the absolute path
                        'MsgBox("emailarray: " & emailarray(counter) & "  filenamearray: " & filenamearray(counter) & " filenameshort: " & filenameshort(counter))
                        counter += 1
                        'Debug.WriteLine("Counter: " & counter & "  Emailarray: " & emailarray(counter))
                        'MsgBox("Non Multiple Email: emailarray.Length = " & emailarray.Length)
                    End If
                End If ' email later
            Else
                'File is not ready after 
                Display(MainStatusBox, "The file is not ready after waiting " & WaitTime / 1000 & " seconds \n" & _
                        "One reasons could be that the file is very large. \n If emails are sent automatically, it will retry shortly. If not, you will have to resend manually")

            End If
        Next

        'If SendLaterFlagg = False And EmailSetupForm.PromptForEmailDontSend_CheckBox.Checked = False Or EmailSetupForm.PromptForEmailAndSend_CheckBox.Checked = False Then
        If SendLaterFlagg = False Then
            Dim MyEmails As New List(Of EmailAndName)

            For counterr As Integer = 0 To emailarray.Length - 1
                Dim MyEmailClass As New EmailAndName
                MyEmailClass.Name = CustNameArray(counterr)
                MyEmailClass.Email = emailarray(counterr)
                MyEmailClass.FileNameShort = filenameshort(counterr)
                MyEmails.Add(MyEmailClass)
            Next
            MyEmails = MyEmails.OrderBy(Function(x) x.Email).ToList
            For counter = 0 To MyEmails.Count - 1
                emailarray(counter) = MyEmails(counter).Email
                filenameshort(counter) = MyEmails(counter).FileNameShort
                CustNameArray(counter) = MyEmails(counter).Name
            Next

            'Array.Sort(emailarray, filenameshort) 'Sort emailarray in order by email name
            'ToDo -- Problem. I need CustNameArray to match the order of emailarray
            'Array.Sort(CustNameArray, filenameshort) 'Sort CusNameArray in order by email name
            For counter = 0 To filenameshort.Length - 1
                filenamearray(counter) = EventFolder & "\" & filenameshort(counter)
            Next
            Combine(emailarray, filenamearray, emailstring, filenamestring)
            Combine(CustNameArray, filenamearray, CustNameString, filenamestring)
            Combine(emailarray, filenameshort, emailshortstring, filenameshortstring)
            '                For counter = 0 To filenameshort.Length - 1
            '                    MsgBox("email: " & emailarray(counter) & vbCrLf & _
            '                           "filenamearray: " & filenamearray(counter) & vbCrLf & _
            '                           "filenameshort: " & filenameshort(counter))
            '                Next
            '                MsgBox("STOP")
            Dim NumOfEmailees = emailstring.Length - 1
            For counter = 0 To NumOfEmailees
                ' Check for spaces in filenames and emails
                'testspace_filename = Split(filenamestring(counter), " ")
                testspace_email = Split(emailstring(counter), " ")
                'If testspace_filename.Length > 1 Or testspace_email.Length > 1 Then
                If testspace_email.Length > 1 Then ' I don't think a space in the filename is problemsome
                    'MsgBox("Filenames or emails cannot contain any spaces. " & " " & filenamestring(counter) & _
                    '       " was not sent" & " Counter = " & counter)
                    MsgBox("Emails cannot contain any spaces. " & " " & filenamestring(counter) & _
           " was not sent" & " Counter = " & counter)
                    StoppedButton.Visible = True
                    SENDINGBUTTON.Visible = False
                Else
                    'MsgBox("Email: " & emailstring(counter) & " filenamestring: " & filenamestring(counter) & " filenameshort: " & filenameshortstring(counter))
                    If emailstring(counter) <> "" Then ' Take's care of case for when a row is skipped in the email prompt which
                        ' leads to an empty email string.  If felt that taking care of it at this point required the least bit
                        ' of code rewrite.
                        SENDEMAIL(emailstring(counter), filenamestring(counter), EventFolder, filenameshortstring(counter), CancelFlagg, SENDEMAILFLAGG, CustNameString(counter))
                        If SENDEMAILFLAGG = True Then ' Email was sent successfully
                            ' Find the corresponding file in the image folder and then delete it.
                            For Each fullstring In listing ' This loops parses the files and produces arrays for email() and filename()
                                Dim checkfilestring() As String
                                Dim checkemailstring() As String
                                Dim parseOriginalEmail() As String
                                Dim tempB() As String = Split(fullstring.Name, "$") 'temp(0):email temp(1):filename
                                'Handle case for which fullstring.name does not contain a $ symbol..to to reformat 
                                'the string to the expected format.
                                If tempB.Length < 2 Then
                                    ReDim Preserve tempB(1)
                                    tempB(1) = tempB(0)
                                    'tempB(0) = emailstring(counter)
                                End If

                                checkfilestring = Split(filenameshortstring(counter), ";")
                                checkemailstring = Split(emailstring(counter), ";")
                                parseOriginalEmail = Split(tempB(0), "!")

                                For kk = 0 To checkfilestring.Length - 1
                                    For kkk = 0 To checkemailstring.Length - 1
                                        'MsgBox("checkfilestring: " & checkfilestring(kk) _
                                        '       & vbCrLf & " temp(1): " & temp(1) _
                                        '       & vbCrLf & " checkemailstring: " & checkemailstring(kkk) _
                                        '    & vbCrLf & " temp(0): " & parseOriginalEmail(0))

                                        If (checkfilestring(kk) = tempB(1)) And (checkemailstring(kkk) = parseOriginalEmail(0)) Or PostEmailPromptYesNo = True Then
                                            'MsgBox("We have a match!")
                                            'MsgBox(EventFolder & "\" & fullstring.Name)
                                            'File.Delete(Textbox_imagefolder.Text & "\" & fullstring.Name)
                                            'File.Delete(oldfilename)
                                            If counter = NumOfEmailees Then
                                                Try
                                                    'Note: Move does not work if a file already exists in the destination. It does not have the
                                                    'overwrite capability. Because of this, I am using a copy and delete combination.
                                                    'File.Move(tempstring & "\" & fullstring.Name, tempstring & "\Sent\" & fullstring.Name)
                                                    If Not File.Exists(tempstring & "\Sent\") Then
                                                        Directory.CreateDirectory(tempstring & "\Sent\")
                                                    End If
                                                    If File.Exists(tempstring & "\" & fullstring.Name) Then ' This is needed for the case when multiple individuals are emailed the same image. I need to fix the logic.
                                                        File.Copy(tempstring & "\" & fullstring.Name, tempstring & "\Sent\" & fullstring.Name, True)
                                                        pause(500)
                                                        File.Delete(tempstring & "\" & fullstring.Name)
                                                    End If
                                                Catch ex As Exception

                                                    MsgBox("Problem deleting file after successful email. The Method is: SendParsedEmails()" & vbCrLf &
                                                           "The file: " & tempstring & "\" & fullstring.Name & " may need to be deleted manually." & vbCrLf &
                                                           ex.Message)
                                                End Try
                                            End If
                                        End If
                                    Next
                                Next
                            Next
                        End If
                    End If
                End If
                If NumOfEmailees <> 0 Then
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = 100 * CType(Math.Round(counter / NumOfEmailees), Integer)
                End If
            Next

        End If
        If CancelFlagg <> "Cancel" And RunningInAutoMode = False Then
            'StatusBox.Text = StatusBox.Text & "Finished....."
            If ContinueOrCancel = "Cancel" Then
                Display(MainStatusBox, "Operation Cancelled....")
            Else
                Display(MainStatusBox, "Finished..........")
            End If
            StoppedButton.Visible = True
            SENDINGBUTTON.Visible = False
            ProgressBar1.Visible = False
        End If

        If RunningInAutoMode = True Then
            Display(MainStatusBox, "Waiting for more images....." & vbCrLf)
            StoppedButton.Text = "Standby"
            StoppedButton.Visible = True
            StoppedButton.BackColor = Color.Green
        End If
        'System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        'CancelFlagg = "Cancel"
        SendLaterFlagg = True ' reset
        RepeatEmailsInEmailPrompt = False ' reset
        EmailPrompt.RepeatEmailsInEmailPrompt_Checkbox.Checked = False ' reset
        SENDEMAILFromEmailReadyFolderFLAGG = False 'resetw
        ContinueOrCancel = "Continue" ' reset
    End Sub
#End Region

    ''' <summary>
    ''' HOODFileWatcherJPG()
    ''' This subroutine was added to add intuition to the code. Before this, watchfolder was being used and I 
    ''' experienced unexplained behaviour. For one, I kept getting threading errors. 
    ''' Now this event is triggered by a timer.
    ''' At a specified interval, the folder is checked for new JPEG images. If at least one image 
    ''' exists, RunGO() is called.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>So far, it olnly looks for .jpg files.</remarks>
    Public Sub HOODFileWatcherJPG(ByVal sender As Object, ByVal e As EventArgs) Handles HoodWatchFolderOnTimer.Tick, GoButton.Click
        Dim listing As ArrayList = getJPGfiles(Textbox_imagefolder.Text)
        If listing.Count > 0 Then
            RunGo()
        Else
            Display(MainStatusBox, "There are no images to send" & vbCrLf)
        End If
    End Sub

    ''' <summary>
    ''' PostPhotoOnFacebookFGT() uses methods from the Facebook Graph Toolkit. It checks to see if the album name
    ''' has been changed. If so, then GetAPIandAlbumID() is called again to create the album and get the new AID
    ''' which is saved in the global variable FacebookCustomerInfo. After the image is posted, the actual URL is saved
    ''' in a variable called PhotoFacebookAlbumURL. This can be used later in the email message to give the customer a 
    ''' direct link to the photo. Note: The person will need a valide Facebook account to see the link.
    ''' </summary>
    ''' <param name="IMAGESTRING">The image(s) to be posted</param>
    ''' <param name="FACEBOOKCAPTION"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PostPhotoOnFacebookFGT(ByVal IMAGESTRING As String, ByVal FACEBOOKCAPTION As String) As Boolean
        Dim FacebookUploadSuccessfull As Boolean = False
        Dim imagenames() As String
        Dim counter As Integer = 0
        Dim imageUse As String
        Dim MyWebBrowser As New WebBrowser
        Dim FileReadyStatus As Boolean
        imagenames = Split(IMAGESTRING, ";")
        FACEBOOKERROR = False
        Display(MainStatusBox, "Processing Facebook ...")
        'TODO Look into. It appears that counter only goes to 0 but yet all photos are sent to facebook.
        For counter = 0 To imagenames.Length - 1
            imageUse = imagenames(counter)
            Try
                FBauth_click(Nothing, Nothing)
            Catch ex As Exception
                If FACEBOOKERRORONCE = True Then
                    MsgBox("Error: " & ex.Message & "  There was a problem uploading to Facebook. Please check your internet connection and/or Facebook settings.")
                    FACEBOOKERRORONCE = False
                    FACEBOOKERROR = True
                End If
            End Try
            Try
                FileReadyStatus = WaitForFileAvailibility(imageUse, 10000) 'wait up to 10 seconds to ensure that file is ready
                'TODO use technique from slideshow program to load image.
                Dim B As System.Drawing.Bitmap = New System.Drawing.Bitmap(imageUse)
                ' This next line will automatically run the first time. Then checks to see if the album name has changed are
                ' done on subsequent calls
                If FacebookCustomerInfo.MyALBUMNAME <> AlbumComboBox.Text Then
                    FacebookCustomerInfo.MYALBUMID = CheckCurrentAlbumList(checktimerOK, FacebookGUI.WebBrowser1) ' in case album changes
                End If
                'check to make sure album does not aleady exist
                Dim tmp() As String = Split(imageUse, "\")
                Display(MainStatusBox, "Uploading image " & tmp(tmp.Length - 1) & " to Facebook.")
                Dim MyAPI2 As GraphApi.Api = FacebookCustomerInfo.MYAPIinfo
                Dim PhotoID As String = FacebookCustomerInfo.MYAPIinfo.PublishPhoto(FacebookCustomerInfo.MYALBUMID, B, FacebookCaptionTextBox1.Text)
                Dim PhotoURL = FacebookCustomerInfo.MYAPIinfo.GetPictureURL(PhotoID)
                Dim MyAlbumURL = FacebookCustomerInfo.MyAlbumLink
                While B IsNot Nothing
                    B.Dispose()
                    B = Nothing
                End While
                FacebookUploadSuccessfull = True
            Catch ex As Exception 'TODO: An exeption occurred but the images were still sent. Need to look into.
                FacebookUploadSuccessfull = False
                MsgBox("Error: " & ex.Message & "  There was a problem uploading to Facebook. Please check your internet connection and/or Facebook settings.")
            End Try
        Next
        Return FacebookUploadSuccessfull
    End Function

    ''' <summary>
    ''' Combine() is used to combine the images of like emails into a usable string that the 
    ''' emailing program can use. On Oct 29, 2010, the EmailCombineCheckBox was added to allow this 
    ''' feature to be ignored. This is useful if the files are large in size and may produce an undeliverable email.
    ''' It uses a delimiter defined by EmailDelimiter.
    ''' </summary>
    ''' <param name="emailarray">An array of emails strings</param>
    ''' <param name="filenamearray">An array of filenames that match the order of the emailarray</param>
    ''' <param name="emailstring">Outputs (passed as ByRef). This is the </param>
    ''' <param name="filenamestring"></param>
    ''' <remarks></remarks>
    Public Sub Combine(ByRef emailarray() As String, ByRef filenamearray() As String, ByRef emailstring() As String, ByRef filenamestring() As String)
        'TODO A better description on how this routine works is needed.
        If EmailSetupForm.EmailCombineCheckBox.Checked Then
            emailstring = emailarray
            filenamestring = filenamearray
            'Do Nothing and since all variables are ByRef, there is no need for a return variable
        Else

            Dim tmpemail As String
            Dim tmpfilename As String
            Dim Flagg As Integer
            Dim j As Integer = 0
            Dim EmailDelimiter As String = ";"
            'Array.Sort(emailarray, filenamearray) ' Sorts both email and filename.. Key is on email, filename just follows suit.
            Dim NN As Integer = 0
            Dim counter As Integer = 0 ' Counter starts at 1 because array.sort forced emailarray and filenamearray to start at index 1
            While counter < emailarray.Length
                tmpemail = emailarray(counter)
                tmpfilename = filenamearray(counter)
                'MsgBox("counter = " & counter & "   tmpemail = " & tmpemail & "  tmpfilename = " & tmpfilename)
                If counter + 1 < emailarray.Length Then
                    If emailarray(counter + 1) = emailarray(counter) Then
                        Flagg = 1
                        j = 0
                    End If
                    While Flagg = 1
                        j += 1
                        tmpfilename = tmpfilename & EmailDelimiter & filenamearray(counter + j)
                        If (counter + j + 1) < emailarray.Length Then
                            If emailarray(counter + j + 1) <> emailarray(counter + j) Then
                                Flagg = 0
                            End If
                        Else
                            Flagg = 0
                        End If
                    End While
                End If
                If counter > 0 Then
                    ReDim Preserve filenamestring(filenamestring.Length)
                    ReDim Preserve emailstring(emailstring.Length)
                End If
                'MsgBox("Inside Combine()" & Chr(13) & "counter= " & counter & Chr(13) & "j= " & j & Chr(13) & "NN= " & NN & Chr(13) & "filenamestring = " & filenamestring(NN) & Chr(13) & "emailstring=  " & emailstring(NN))
                'MsgBox("NN= " & NN & Chr(13) & "tmpemail = " & tmpemail & Chr(13) & "tmpfilename = " & tmpfilename)
                filenamestring(NN) = tmpfilename
                emailstring(NN) = tmpemail
                'MsgBox("j= " & j & " NN= " & NN & Chr(13) & "emailstring = " & emailstring(NN) & Chr(13) & "filenamestring = " & filenamestring(NN))
                'MsgBox("email: " & tmpemail & "  " & "  Filename: " & tmpfilename & "  Counter: " & counter)
                NN += 1
                If j > 0 Then
                    counter += j + 1
                Else
                    counter += 1
                End If
                'MsgBox("After loop, counter = " & counter)
                j = 0

            End While
            'Dim i As Integer
            'For i = 0 To emailarray.Length - 1
            ' MsgBox(emailarray(i) & "  " & filenamearray(i))
            'Next i
        End If
    End Sub

    ''' <summary>
    ''' SENDEMAIL() is the main program to send emails and / or post to Facebook. A tally of successes and failures is displayed.
    ''' If uploading to Facebook is requested, that is done first. At this stage, no check made 
    ''' to see if the filenames contain email addresses.
    ''' In the next step, if emailing is requested, a check is made to see if the filenames are valid.
    '''  Note, it is possible
    ''' that an image can be uploaded to Facebook but not emailed if no email address was attached.
    ''' No images are moved to the Event folder in this subroutine. This occurs after returning to
    ''' the calling function.
    '''  It is called both by Parseemail() and Sendemailfromdirectory()
    ''' Emails are sent using calls to MailHood() ... which uses the System.Net.Mail method
    ''' </summary>
    ''' <param name="email">A single email address</param>
    ''' <param name="filenamestring">A list of attachments separated by commas. Uses full path names</param>
    ''' <param name="EventFolder"></param>
    ''' <param name="filenameshort">List of pathless filenames. Used for status updates</param>
    ''' <param name="GOFLAGG">Global variable. Indicator that mail processing is busy</param>
    ''' <param name="SENDEMAILFLAGG"></param>
    ''' <remarks></remarks>
    Public Sub SENDEMAIL(ByVal email As String, ByVal filenamestring As String, ByVal EventFolder As String, ByVal filenameshort As String, ByRef GOFLAGG As String, ByRef SENDEMAILFLAGG As Boolean, Optional ByVal EmailName As String = "")
        Dim StatusFile As String = EventFolder & "\status.txt"
        Dim DirectoryFile As String = EventFolder & "\directory.txt" ' Changed from directory.csv on 8/23/11
        Dim ErrorFile As String = EventFolder & "\errors.txt"
        Dim emailuse As String
        SENDEMAILFLAGG = False
        Dim MessageFlagg As Boolean = False
        Dim FileStringToUse As String
        Dim InputString As String
        Dim SendEmailCode As MAILERRORHOOD
        SendEmailCode.SMTPOK = False
        If CancelFlagg <> "Cancel" Then
            If FacebookOnlyRadio.Checked Or EmailAndFacebookRadio.Checked Then
                'Dim PostOK As Boolean = PostPhotoOntoFacebook(filenamestring, FacebookAlbumName.Text, FacebookCaptionTextBox1.Text)
                Dim PostOK As Boolean = PostPhotoOnFacebookFGT(filenamestring, FacebookCaptionTextBox1.Text)
                If PostOK = True Then
                    If EmailOnlyRadio.Checked = False Then
                        ' Use same code as for a successfull email send
                        SENDEMAILFLAGG = True
                        InputString = "[" & System.DateTime.Now & "]  " & "[" & filenameshort & "]" & " was successfully sent to FACEBOOK"
                        Display(MainStatusBox, InputString)
                        My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
                        facebooksentcounter += 1
                        Facebooksentlabel.Text = facebooksentcounter.ToString
                    End If
                Else

                    InputString = "There was a problem sending [" & filenameshort & "] to FACEBOOK. This is either a connection issue or authorization issue"
                    Display(MainStatusBox, InputString)
                    My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
                    fbnotsentcounter += 1
                    fbNotSentLabel.ForeColor = Color.Red
                    fbNotSentLabel.Text = fbnotsentcounter.ToString
                End If
            End If

            If EmailAndFacebookRadio.Checked Or EmailOnlyRadio.Checked Then
                ' check for possible files that are missing an email address. These were allowed through because they 
                'needed to be uploaded to Facebook.

                'check that SMTP server name has been specified
                ' ************************* MAKE CHECKS ON INPUT DATA *************************
                If Len(EmailSetupForm.PortBox.Text) = 0 Then
                    EmailSetupForm.PortBox.Text = "25"
                End If

                If Len(EmailSetupForm.textBox_MailServer.Text) = 0 Then
                    Display(MainStatusBox, "Missing SMTP server name.")
                    Exit Sub
                End If

                'check Email From

                If Len(EmailSetupForm.CompEmailTextbox.Text) = 0 Then
                    Display(MainStatusBox, "Missing 'Email From'")
                    Exit Sub
                End If

                If Not File.Exists(textBox_messagefile.Text) Then
                    MsgBox("Please use a valid Message text file and Re-try.")
                    Exit Sub
                End If

                'check Email To
                emailuse = email
                If Len(emailuse) = 0 Then
                    'Display(StatusBox,"Missing 'Email To' in " & filenamestring)
                    Exit Sub 'skip
                End If

                If Len(textBox_SubjectLine.Text) = 0 Then
                    Display(MainStatusBox, "Missing Subject Line.")
                    Exit Sub
                End If

                ' Include Advertisement File
                If EmailSetupForm.IncludeAdCheckBox.Checked And Not EmailSetupForm.AdLabel2.Text = "" Then
                    'FileStringToUse = filenamestring & ";" & EmailSetupForm.AdLabel2.Text
                    FileStringToUse = EmailSetupForm.AdLabel2.Text & ";" & filenamestring ' Put Ad First
                Else
                    FileStringToUse = filenamestring
                End If
                ' Check if message file exists

                If BuildType = True Then
                    Try
                        SendEmailCode = MailHood(EmailSetupForm.CompEmailTextbox.Text, FileStringToUse)
                    Catch ex As Exception
                        SendEmailCode = MailHood(emailuse, filenamestring)
                    End Try
                Else
                    Try
                        SendEmailCode = MailHood(emailuse, FileStringToUse)
                    Catch ex As Exception
                        SendEmailCode = MailHood(emailuse, filenamestring)
                    End Try
                End If
                ' Send Confirmation Email
                If EmailSetupForm.CheckBox_ConfirmationEmail.Checked Then
                    Try
                        SendEmailCode = MailHood(EmailSetupForm.CompEmailTextbox.Text, FileStringToUse)
                    Catch ex As Exception
                        SendEmailCode = MailHood(EmailSetupForm.CompEmailTextbox.Text, filenamestring)
                    End Try
                End If

                If SendEmailCode.SMTPOK = False Then 'Code corresponding to MailHood
                    ' turn off the connectioncheck to avoid a loop of checkconnection(). I don't know why this occurs yet.
                    CheckConnectionTimer.Enabled = False
                    CancelFlagg = "Cancel"
                    If RunningInAutoMode = True Then
                        Dim ee As EventArgs = Nothing
                        StartStopAutoMode(ManualSendRadio, ee) ' simulate stop
                        Display(MainStatusBox, "Error: Emailing has been stopped.")
                    End If
                    ManualSendRadio.Checked = True ' Disables the send auto feature
                    SENDINGBUTTON.Visible = False
                    StoppedButton.Visible = True
                    SENDEMAILFLAGG = False
                    HoodWatchFolderOnTimer.Stop()
                    ShowErrorSendingFileHOOD(SendEmailCode.SMTPerrorMessage, "", "", StatusFile, ErrorFile)
                    Display(MainStatusBox, "1) Verify that the username/password is correct" & vbCrLf)
                    Display(MainStatusBox, "2) Verify that the SMTP server address is correct & you are using the correct port (usually 25 or 587)" & vbCrLf)
                    Display(MainStatusBox, "3) Check if your security software allows outgoing mail on port: " & EmailSetupForm.PortBox.Text)
                    Display(MainStatusBox, "") ' ads a CR+LF
                    emailNOTsentcounter += 1
                    EmailNotSentLabel.ForeColor = Color.Red
                    EmailNotSentLabel.Text = emailNOTsentcounter.ToString
                    MsgBox(SendEmailCode.SMTPerrorMessage)
                    InputString = "******  [" & System.DateTime.Now & "]  " & "[" & filenameshort & "]" & " FAILED when sending to " & emailuse & "******" & vbCrLf
                Else
                    SENDEMAILFLAGG = True
                    InputString = "[" & System.DateTime.Now & "]  " & "[" & filenameshort & "]" & " was successfully sent to " & emailuse & vbCrLf
                    'NotifyEmailSuccess(InputString)
                    'CustomNotifyForm.ShowNotifyBox(filenamestring, InputString)
                    SetNofifyboxlocationandshow(filenamestring, InputString)
                    emailsentcounter += 1
                    EmailSentCounterLabel.Text = emailsentcounter.ToString
                End If
                Display(MainStatusBox, InputString)
                My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
                My.Computer.FileSystem.WriteAllText(DirectoryFile, filenameshort & "," & emailuse & Chr(13), True)
                'If Not IsNothing(EmailSetupForm.EmailMasterListFilename.Text) Then
                If EmailSetupForm.UseMasterListCheckbox.Checked Then
                    Try
                        My.Computer.FileSystem.WriteAllText(EmailSetupForm.EmailMasterListFilename.Text, textBox_SubjectLine.Text & "," & filenameshort & "," & emailuse & "," & EmailName & vbCrLf, True)
                    Catch ex As Exception
                        MsgBox("Problem in SENDEMAIL()" & vbCrLf & ex.Message)
                    End Try
                End If ' Master list
            End If 'FB checkbox and Email only checkbox
        End If ' If Cancelflagg
    End Sub

    Public Sub SetNofifyboxlocationandshow(filenamestring As String, InputString As String)
        Dim MyList As New List(Of Integer)
        Try
            MyList = CustomNotifyForm.SetNotifyBoxLocation(EmailSetupForm)
            CustomNotifyForm.ShowNotifyBox(filenamestring, InputString, MyList(0), MyList(1))
        Catch ex As Exception
            Debug.Print("Problem with Testbuttonclick")
        End Try
    End Sub


    ' **************************************  SUPPORT SUBROUTINES *****************


    ''' <summary>
    ''' StartStopAutoMode() activates a timer (HoodWatchFolderOnTimer) used watch a folder for new files. 
    ''' When this occurs it runs the LetsGo() subroutine. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartStopAutoMode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSendRadio.Click, ManualSendRadio.Click
        'Needs to first check that the folder exists
        If Not Directory.Exists(Textbox_imagefolder.Text) Then
            MsgBox(Textbox_imagefolder.Text & " Does not exist. You many need to change the path in your " & Textbox_imagefolder.Text & "\bin\default.txt file")
        Else
            If sender.Equals(AutoSendRadio) Then
                Dim timeinterval = CType(TimeIntervalTextBox.Text, Integer) * 1000
                If timeinterval < 1000 Then
                    timeinterval = 1000
                    TimeIntervalTextBox.Text = "1"
                End If
                HoodWatchFolderOnTimer.Interval = timeinterval
                HoodWatchFolderOnTimer.Start()
                CancelFlagg = "run"
                'GoFlagg = True
                'MsgBox("GoFlagg = " & GoFlagg.ToString)
                ' The wait command will give it time to finish.
                AutoEmailFlagg = True
                'StatusBox.Text = "Your image directory is being monitored." & Chr(13) & Chr(10) & "Emails will be automatically sent" & Chr(10) & Chr(13) & "Waiting ..." & vbCrLf
                MainStatusBox.Clear()
                Display(MainStatusBox, "Currently monitoring " & vbCrLf & Textbox_imagefolder.Text & vbCrLf)
                'Display(StatusBox,"Your image directory is being monitored.")
                Display(MainStatusBox, "Emails will be automatically sent")
                Display(MainStatusBox, "Waiting....")
                'MsgBox("EPE Emailer will now monitor your image directory. Emails will be automatically sent")
                'WatchFolder.EnableRaisingEvents = True
                GoButton.Visible = False
                StoppedButton.Enabled = True
                StoppedButton.Text = "Standby"
                StoppedButton.BackColor = Color.Green
                Label9_EmailListDescription.Enabled = False
                EmailFilenameList.Enabled = False
                Button3_browse_email_filename.Enabled = False
                ignoreJPG.Enabled = False
                CheckBox2_emailfilename.Enabled = False
            Else 'stop button was hit
                RunningInAutoMode = True
                StoppedButton.Enabled = True
                StoppedButton.Text = "Stopped"
                StoppedButton.BackColor = Color.Red
                AutoEmailFlagg = True
                Label9_EmailListDescription.Enabled = True
                EmailFilenameList.Enabled = True
                Button3_browse_email_filename.Enabled = True
                ignoreJPG.Enabled = True
                CheckBox2_emailfilename.Enabled = True
                'WatchFolder.EnableRaisingEvents = False
                HoodWatchFolderOnTimer.Stop()
                MainStatusBox.Clear()
                Display(MainStatusBox, "Automatic mail delivery has been disabled. " & _
                        "Use the green 'SEND EMAILS' button below to start the process manually.")

                'MsgBox("EPE Emailer is not monitoring your image directory. Emails will need to be manually sent")
                GoButton.Visible = True
            End If
        End If
    End Sub

    ''' <summary>
    ''' CheckFileExistence_And_Spaces() checks if a file exists. It also checks if it has any spaces. If it does
    ''' contain spaces then the file is ignored. A message is sent to the status window as well as the status
    ''' file indicating that this file was not sent. The output variable, CheckFileFlagg, is set and used by the 
    ''' calling subroutine to decide if to email the file or not. If not, this file will remain in the hotfolder
    ''' </summary>
    ''' <param name="PATH"></param>
    ''' <param name="FILENAMETOCHECK"></param>
    ''' <param name="CheckFileFlagg">True if the filename is valid.</param>
    ''' <remarks></remarks>
    Public Sub CheckFileExistence_And_Spaces(ByVal PATH As String, ByVal FILENAMETOCHECK As String, ByRef CheckFileFlagg As String)
        Dim testspace_filename() As String
        Dim FN = PATH & FILENAMETOCHECK
        'MsgBox("Checking " & FN & "  file.exist = " & File.Exists(FN))
        If Not File.Exists(FN) Then 'check for existance
            CheckFileFlagg = "False"
            Display(MainStatusBox, FILENAMETOCHECK & " Does not exist, please check the spelling or make sure that the box" & _
                    " is checked to supress the .jpg extension")
            Display(MainStatusBox, "This file will not be sent")
            testspace_filename = Split(FILENAMETOCHECK, " ")
            If testspace_filename.Length > 1 Then
                Display(MainStatusBox, FILENAMETOCHECK & " cannot contain spaces." _
                & " Please check your message filename, directory filename, image filenames and email addresses." _
                & FILENAMETOCHECK & " was not sent")
            End If
        Else
            CheckFileFlagg = "True"
        End If
    End Sub
    ''' <summary>
    ''' ShowErrorSendingFilesHood displays error in status bar as well as statfile and errfile
    ''' </summary>
    ''' <param name="ErrorString"></param>
    ''' <param name="Filename"></param>
    ''' <param name="emailaddress"></param>
    ''' <param name="STATFILE"></param>
    ''' <param name="ERRFILE"></param>
    ''' <remarks></remarks>
    Public Sub ShowErrorSendingFileHOOD(ByVal ErrorString As String, ByVal Filename As String, ByVal emailaddress As String, ByVal STATFILE As String, ByVal ERRFILE As String)
        Display(MainStatusBox, ErrorString)
        'Call Display(Microsoft.VisualBasic.Left(Buffer, Buffer.Length))
        My.Computer.FileSystem.WriteAllText(STATFILE, ErrorString & Chr(13), True)
        My.Computer.FileSystem.WriteAllText(ERRFILE, ErrorString & Chr(13), True)
    End Sub

    Public Sub CheckBox2_CheckedChanged_OLD(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2_emailfilename.CheckedChanged
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then EmailFilenameList.Enabled = True Else EmailFilenameList.Enabled = False
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then ignoreJPG.Enabled = True Else ignoreJPG.Enabled = False
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then Button3_browse_email_filename.Enabled = True Else Button3_browse_email_filename.Enabled = False
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then Label9_EmailListDescription.Enabled = True Else Label9_EmailListDescription.Enabled = False
    End Sub



    ''' <summary>
    ''' Emailfilename_CheckedChanged() handles the logic for the checkbox that determines if a filename
    ''' directory is used.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Emailfilename_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2_emailfilename.CheckedChanged
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then
            EmailFilenameList.Enabled = True
            ignoreJPG.Enabled = True
            Button3_browse_email_filename.Enabled = True
            Label9_EmailListDescription.Enabled = True
        Else
            EmailFilenameList.Enabled = False
            ignoreJPG.Enabled = False
            Button3_browse_email_filename.Enabled = False
            Label9_EmailListDescription.Enabled = False
        End If
    End Sub

    Public Sub ImageLocationButton(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1_browse_image_location.Click
        FolderBrowserDialog_image_location.ShowDialog()
        Textbox_imagefolder.Text = FolderBrowserDialog_image_location.SelectedPath
    End Sub

    Public Sub MessageFileButton(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2_browse_message_file.Click
        OpenFileDialog1_message_location.ShowDialog()
        textBox_messagefile.Text = OpenFileDialog1_message_location.FileName
    End Sub

    Public Sub EmailFilenameDirectoryButton(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3_browse_email_filename.Click
        OpenFileDialog2_emaillist.ShowDialog()
        EmailFilenameList.Text = OpenFileDialog2_emaillist.FileName
    End Sub


    Public Sub CancelButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton1.Click
        CancelFlagg = "Cancel"
    End Sub

#Region "Form Exiting and Hiding Stuff"
    Public Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If IsProcessRunning(WinZShortcut) = True Then
            Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName(WinZShortcut)
            For Each p As Process In pProcess
                p.Kill()
            Next
        End If
        Try
            NotifyIcon1.Visible = False
            NotifyIcon1.Icon = Nothing
            NotifyIcon1.Dispose()
            NotifyIcon1 = Nothing
            ' Close all forms
            'Dim AllMyForms As FormCollection = My.Application.OpenForms
            Dim SkipFirstForm = False
            For Each f As Form In My.Application.OpenForms
                If SkipFirstForm = True Then
                    f.Close()
                End If
                SkipFirstForm = True
            Next
        Catch ex As Exception
            Debug.Print("An Error occured trying to close the application")
        End Try

    End Sub

    Public Sub ShowEPEForm() Handles ShowEPE.Click
        Me.Visible = True
    End Sub

    Public Sub HideEPEForm() Handles HideEPE.Click
        Me.Visible = False
    End Sub

    Public Sub ExitEPEForm(ByVal sender As Object, ByVal e As EventArgs) Handles ExitEPE.Click
        Me.Close()  ' Calls the form1_FormClosing() function
    End Sub


#End Region


#Region "Encryption"

    Public Function GetLicenseCode(ByVal DIRECTORY As String) As CompanyInfoSTRUCTURE
        'This works by first checking to see if there is a \bin\lic.dat file. If there is,
        'it is checked to obtain the encrypted company name and email address. A try/catch
        'loop is used in MyDecryption() just in case the the information is corrupt. If it is corrupt,
        '"InvalidPasscode$$$Corrupt" is used as the PassCode in Base64. This subroutine,
        'then decrypts the code. If its the corrupt code, then it gives the option to Abort, Retry, or
        'ignore. If retry, EnterPassCode() is called and the passcode is re-entered.
        Dim PassCode As String
        Dim tester() As String
        Dim COMP As CompanyInfoSTRUCTURE = Nothing
        Dim DefaultFile As String
        DefaultFile = DIRECTORY & "\bin\lic.dat"
        If Not File.Exists(DefaultFile) Then
            COMP = EnterPassCode(DefaultFile)
        Else
            Dim fs As New FileStream(DefaultFile, FileMode.Open, FileAccess.Read)
            Dim d As New StreamReader(fs)
            d.BaseStream.Seek(0, SeekOrigin.Begin)
            PassCode = d.ReadLine()
            d.Close()
            tester = Split(MyDecryption(PassCode), "$$$") 'Passcode should have valid format. Taken care of in MyDecryption()
            If tester(0) = "InvalidPasscode" Then
                Dim returnvalue = MsgBox("Invalid Passcode." & vbCrLf & _
                                    "Please verify the Passcode in " & DefaultFile & " is correct." & vbCrLf & _
                                    "Choose RETRY to re-enter the Passcode or" & vbCrLf & _
                                    "Choose IGNORE to continue in Evaluation Mode." & vbCrLf & _
                                    "Choose ABORT to close the program", MsgBoxStyle.AbortRetryIgnore)
                If returnvalue = MsgBoxResult.Abort Then
                    Me.Close()
                    'ExitEPEForm() ' Kills program
                ElseIf returnvalue = MsgBoxResult.Ignore Then
                    COMP.CompanyName = "EVALUATION VERSION "
                    COMP.CompanyEmail = "<EVAL@SomeCompany.com>"
                    COMP.EvaluationMode = True
                ElseIf returnvalue = MsgBoxResult.Retry Then
                    COMP = EnterPassCode(DefaultFile)
                End If
            Else
                COMP.CompanyName = tester(0)
                COMP.CompanyEmail = tester(1)
                COMP.EvaluationMode = False
            End If
        End If
        Return COMP
    End Function

    Public Function EnterPassCode(ByVal DefaultFile As String) As CompanyInfoSTRUCTURE
        'Called if lic.dat does not exist or if faulty'
        Dim tester() As String
        Dim COMP2 As CompanyInfoSTRUCTURE
        Dim PassCode As String = InputBox("Please Enter Your Passcode")
        If PassCode = "" Then
            PassCode = "trail"
        End If
        Dim fs As New FileStream(DefaultFile, FileMode.Create, FileAccess.Write) 'Set to create so old file will be totally rewritten
        Dim s As New StreamWriter(fs)
        'creating a new StreamWriter and passing the filestream object fs as argument
        s.BaseStream.Seek(0, SeekOrigin.End)
        'the seek method is used to move the cursor to next position to avoid text being
        'overwritten
        's.WriteLine(ProgDir2.Text)
        s.WriteLine(PassCode)
        s.Close()
        tester = Split(MyDecryption(PassCode), "$$$")
        If tester(0) = "InvalidPasscode" Then
            Dim returnvalue = MsgBox("Invalid Passcode." & vbCrLf & _
                                     "Please verify the value in " & DefaultFile & " is correct." & vbCrLf & _
                                     "Continuing in Evaluation Mode?")
            COMP2.CompanyName = "EVALUATION VERSION "
            COMP2.CompanyEmail = "<EVAL@SomeCompany.com>"
            COMP2.EvaluationMode = True
        Else
            COMP2.CompanyName = tester(0)
            COMP2.CompanyEmail = tester(1)
            COMP2.EvaluationMode = False
        End If
        Return COMP2
    End Function
#End Region


    ''' <summary>
    ''' CheckForNonEmailedJPGFiles() checks to see if files exist that start with $. If so, it is an indication that no email was attached.
    ''' For the case of facebook only, this subroutine is not called since it would not have an email address attached.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckForNonEmailedJPGFiles()
        Dim str4 As New IO.DirectoryInfo(Textbox_imagefolder.Text)
        Dim NoEmailFilename As IO.FileInfo() = str4.GetFiles("*.jpg") 'Image with no email will just start with $
        Dim temp4() As String
        Dim ChkValEmail() As String ' Used to check if email address is valid (to the point of containing a DOT)
        Dim InputString As String
        For Each temp5 In NoEmailFilename
            temp4 = Split(temp5.Name, "$") 'temp(0):email temp(1):filename
            ChkValEmail = Split(temp4(0), ".")
            If temp4.Length = 1 Or temp4(0) = "" Or ChkValEmail.Length = 1 Then
                If temp4.Length = 1 Or temp4(0) = "" Then
                    InputString = "***[" & temp5.Name & "] did not have a valid email address ...Not Sent***"
                Else 'ChkValEmail.Length = 1 
                    InputString = "***[" & temp4(0) & "] is not a valid email address for image: " & temp4(1) & "...Not Sent***"
                End If
                Display(MainStatusBox, InputString)
                My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
                Dim NoEmailString As String = EventFolder & "\" & "NoAttachedEmailAddress"
                If Not File.Exists(NoEmailString) Then
                    Directory.CreateDirectory(NoEmailString)
                End If
                If File.Exists(NoEmailString & "\" & temp5.Name) Then
                    File.Delete(NoEmailString & "\" & temp5.Name)
                End If
                File.Move(Textbox_imagefolder.Text & "\" & temp5.Name, NoEmailString & "\" & temp5.Name)
                emailNOTsentcounter += 1
                EmailNotSentLabel.ForeColor = Color.Red
                EmailNotSentLabel.Text = emailNOTsentcounter.ToString
            End If
        Next
    End Sub



    Public Sub OpenImageFolderSub(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenImageFolderButton.Click
        Try
            Process.Start("explorer.exe", Textbox_imagefolder.Text)
        Catch ex As Exception
            MsgBox("Error attempting to open the image folder. Please ensure that image folder is correct")
        End Try

    End Sub


#Region "Internet Connection Checks"
    ''' <summary>
    ''' checkinternetconnection()
    ''' Checks if there is a connection to the internet. 
    ''' </summary>
    ''' <returns>NETFOUND - 
    ''' 1: Connected to the internet
    ''' 2: Not Connected to the internet
    ''' 3: No Network Found
    ''' 4: Something caused and exception
    ''' 5: Not checking internet connection
    ''' Has a global flag called CHECKCONNECTIONYESNO which is used during debugging
    ''' </returns>
    ''' <remarks>Checks for an internet connection. This is called before sending and
    ''' also periodically using a timer (CheckConnectionTimer.Tick) to give feedback as to the current internet status. 
    ''' Ideally, this should be placed on a thead that updates a signal strength indicator.
    ''' this code is staying local and not moved to the module because of dependence on status boxes
    ''' and global variables.</remarks>
    Public Function checkinternetconnection() As String
        Dim NETFOUND As String
        If EmailSetupForm.Checkbox_CheckForIntConnectYesNo.CheckState = CheckState.Checked Or InitialConnectionCheck = True Then
            Try
                If My.Computer.Network.IsAvailable Then
                    Dim PingTimeout As Integer = 10000 ' 5 seconds
                    Display(MainStatusBox, "Checking for an internet connection . . .")
                    Dim pingtmp As Boolean = My.Computer.Network.Ping(SiteToPing, PingTimeout)
                    'Dim pingtmp As Boolean = IsConnectionAvailable(SiteToPing)
                    If pingtmp = True Then ' this is preferred since it checks internet connection
                        'If My.Computer.Network.IsAvailable Then ' This method checks network connection, not quite internet
                        ConnectionStatusResultLabel.Text = "Connected to the internet"
                        NETFOUND = "1"
                    Else
                        ConnectionStatusResultLabel.Text = "Not Connected to the internet"
                        NETFOUND = "2"
                    End If
                Else
                    ConnectionStatusResultLabel.Text = "No Network Found"
                    NETFOUND = "3"
                End If
            Catch ex As Exception
                ConnectionStatusResultLabel.Text = ex.Message
                NETFOUND = "4"
            End Try
        Else
            ConnectionStatusResultLabel.Text = "Not Checking Internet Connections"
            NETFOUND = "5"
        End If
        Display(MainStatusBox, ConnectionStatusResultLabel.Text)
        Return NETFOUND
        InitialConnectionCheck = False
    End Function


    ''' <summary>
    ''' Timer1_Tick() is used to check the internet connection on a given interval. 
    ''' *** This is currenlty not being used.***
    ''' Instead, it is checked at the time the send button is pressed, or, if in auto mode, when a new event rises.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckConnectionTimer.Tick
        If checktimerOK = True Then
            checkinternetconnection()
        End If
    End Sub
#End Region

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailOnlyRadio.CheckedChanged
        GoButton.Text = "Send Email"
        AlbumComboBox.Enabled = False
        FacebookCaptionTextBox1.Enabled = False
    End Sub

    Private Sub EmailAndFacebookRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailAndFacebookRadio.CheckedChanged
        AlbumComboBox.Enabled = True
        FacebookCaptionTextBox1.Enabled = True
        GoButton.Text = "Send to Email and Facebook"
    End Sub

    Private Sub FacebookOnlyRadio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacebookOnlyRadio.CheckedChanged
        AlbumComboBox.Enabled = True
        FacebookCaptionTextBox1.Enabled = True
        GoButton.Text = "Send to Facebook Only"
    End Sub

    Private Sub ConfigureEmailButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureEmailButton.Click
        EmailSetupForm.Show()
        EmailSetupForm.BringToFront()
        Me.CenterToScreen()
    End Sub

    Private Sub AboutUs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUsButton.Click
        MsgBox("Adrian Hood Engineering Solutions" & vbCrLf & _
               "301-437-1186" & vbCrLf & _
               "adrian@hoodandson.com")
    End Sub

    ''' <summary>
    ''' CheckCurrentAlbumList is used to check the current list, and create a new album if needed.
    ''' one is created.
    ''' </summary>
    ''' <param name="CHECKTIMEROK">Used to disable the timer control used to check the internet connection.</param>
    ''' <param name="MyWebBrowser">Current Webbrowser Object</param>
    ''' <returns>HoodFacebookInfo - A structured variable which holds the desired info: AccessToken, ID, AID, and AlbumID</returns>
    ''' <remarks>This code is called to get the Album ID. It the album name changes, it is called again.
    ''' When the Facebook logo is pressed, another code is called (fb_authenticate()) that only authenticates. This brings up the
    ''' webbrowser window and ask for login information. MyAPI (a global variable) is assigned a value at that time. When GetAPIandAlbumID is called,
    ''' a check is done to see if MyAPI has a value. If so, the authenicate process is bypassed eliminating the need to keep logging in.
    ''' The code that calls this function creates a CustomerAPI variable. After it is created, this subroutine is no longer called.
    ''' This code requires my EPE Facebook appliation ID: "197403413634224". A check is made to ensure a network connection
    ''' is available.
    ''' </remarks>
    ''' 
    Public Function CheckCurrentAlbumList(ByRef CHECKTIMEROK As Boolean, ByVal MyWebBrowser As WebBrowser) As String
        ' **************  Get list of albums ********
        Dim MyAlbums As IList(Of Facebook_Graph_Toolkit.GraphApi.Album) = GraphApi.User.GetAlbums("Me", FacebookCustomerInfo.MYAPIinfo.AccessToken, Nothing, Nothing)
        Dim FBAlbumName = AlbumComboBox.Text
        If FBAlbumName = "" Then
            FBAlbumName = "Event Upload Folder"
        End If
        Dim albumfoundflagg As Boolean = False
        Dim MyAlbumID As String = Nothing
        For Each P In MyAlbums
            If albumfoundflagg = False Then
                If P.Name = FBAlbumName Then
                    MyAlbumID = P.ID
                    albumfoundflagg = True
                    FacebookCustomerInfo.MyAlbumLink = P.NavigateUrl
                End If
            End If
        Next
        If MyAlbumID = Nothing Then ' Album does not exist .... need to make it
            'Make Album
            Dim albumok As Boolean
            albumok = MakeAlbum3(FBAlbumName, FacebookGUI.WebBrowser1)
            If albumok = True Then 'check albums again and get id of match
                ' note: There is a time delay for the album to be created and then available.
                ' the delay will be at least 5*albumcreationdelay. The search will occur at least 5 times.
                Dim tmp As HoodFacebookInfo = Nothing
                MyAlbumID = tmp.MYAID
                tmp = CheckForNewAlbums(FBAlbumName)
            Else
                MsgBox("There was a problem creating the Facebook album")
            End If
        End If
        'ReturnData = Nothing
        'ReturnData.MYALBUMID = MyAlbumID
        'ReturnData.MYAPIinfo = FacebookCustomerInfo.MYAPIinfo
        ''ReturnData.MYAID = Myaid
        'ReturnData.MyALBUMNAME = FBAlbumName
        'ReturnData.MyLink = MyLink
        ''ReturnData.MyLink = String.Format("http://www.facebook.com/media/set/?set=a.{0}.{1}", MyAlbumID, Myaid)
        Return MyAlbumID
    End Function

    Function CheckForNewAlbums(ByVal FBAlbumName As String) As HoodFacebookInfo
        Dim albumcreationdelay As Integer = 3000
        Dim counter5 As Integer = 0
        Dim albumfoundflagg As Boolean = False
        Dim tmp As New HoodFacebookInfo
        Do While counter5 < 5 And albumfoundflagg = False
            pause(albumcreationdelay)
            counter5 = counter5 + 1
            Dim MyAlbums = GraphApi.User.GetAlbums("Me", FacebookCustomerInfo.MYAPIinfo.AccessToken, Nothing, Nothing)
            For Each P In MyAlbums
                If albumfoundflagg = False Then
                    If P.Name = FBAlbumName Then
                        tmp.MYALBUMID = P.ID
                        tmp.MyLink = P.NavigateUrl
                        albumfoundflagg = True
                        Display(MainStatusBox, FBAlbumName & " has been created")
                        FacebookCustomerInfo.MyAlbumLink = P.NavigateUrl
                    End If
                End If
            Next
        Loop
        If albumfoundflagg = False Then
            MsgBox("Error creating new album") ' chould not occur
        End If
        Return tmp
    End Function

    ''' <summary>
    ''' GetAlbumsAndPopulateDropdown gets the list of albums. It is called by fbauthenticate()
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub GetAlbumsAndPopulateDropdown(ByVal sender As Object, ByVal e As EventArgs) Handles FacebookLogoOnForm1.Click
        FBauth_click(sender, e)
        Dim aid As New ArrayList
        If Not FacebookCustomerInfo.MYAPIinfo.AccessToken = "AccessTokenError" Then
            Dim MyAlbums As IList(Of Facebook_Graph_Toolkit.GraphApi.Album) = GraphApi.User.GetAlbums("Me", FacebookCustomerInfo.MYAPIinfo.AccessToken, Nothing, Nothing)
            For Each P In MyAlbums
                AlbumComboBox.Items.Add(P.Name)
            Next
        End If
    End Sub


    ''' <summary>
    ''' MakeAlbum3 uses the facebook create.php site to make an album
    ''' </summary>
    ''' <param name="AlbumName"></param>
    ''' <param name="MyWebBrowser"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MakeAlbum3(ByVal AlbumName As String, ByVal MyWebBrowser As WebBrowser) As Boolean
        ' a first pass is needed to make the album
        Dim AlbumPageString As String = "http://www.facebook.com/albums/create.php"
        MyWebBrowser.Navigate(AlbumPageString)
        WebWait(MyWebBrowser, 15)
        Dim doc As HtmlDocument = MyWebBrowser.Document
        Dim theElementCollection As HtmlElementCollection = doc.GetElementsByTagName("input")
        Dim foundflagg As Boolean = False
        Dim itemarray As ArrayList = Nothing
        For Each curElement As HtmlElement In theElementCollection
            'If foundflagg = False Then
            Dim controlName As String = curElement.GetAttribute("name").ToString
            'itemarray.Add(controlName.ToString)
            If controlName = "name" Then
                curElement.SetAttribute("Value", AlbumName)
                foundflagg = True
                'MsgBox("Found")
            End If
            'End If
        Next
        Dim MyListArray As New ArrayList
        ' Part 3: Automatically click the Login button
        Dim theWElementCollection As HtmlElementCollection = MyWebBrowser.Document.GetElementsByTagName("input")
        Dim albumclickflagg As Boolean = False
        For Each curElement As HtmlElement In theWElementCollection
            If albumclickflagg = False Then
                Dim controlName As String = curElement.GetAttribute("value").ToString
                MyListArray.Add(controlName.ToString)
                If controlName = "Create Album" Then
                    curElement.InvokeMember("click")
                    'MsgBox("Album Click Found")
                    albumclickflagg = True
                End If
            End If
            ''Dim tmp As String = curElement.ToString
            ''If curElement.GetAttribute("value").Equals("Create Album") Then
            ''    curElement.InvokeMember("click")
            ''    ' javascript has a click method for we need to invoke on the current submit button element.
            ''End If
        Next


        'WebWait(MyWebBrowser, 15)
        'Dim counter2 As Integer = 0
        'Dim AccessURI As String = MyWebBrowser.Url.ToString
        'Do While AccessURI = AlbumPageString
        '    WebWait(MyWebBrowser, 1)
        '    counter2 = counter2 + 1
        '    Display(StatusBox, "Creating Album ...." & counter2)
        'Loop
        'AccessURI = MyWebBrowser.Url.ToString
        'Dim MyURI() As String
        'MyURI = Split(AccessURI, "aid=")
        'Dim MyAccessToken As String = MyURI(1)
        'MyURI = Split(MyAccessToken, "&")
        'Dim MyAlbumID = MyURI(0)
        'Return MyAlbumID
        Return albumclickflagg
    End Function

    Public Sub WebWait(ByVal MWB As WebBrowser, ByVal MaxWait As Integer)
        Dim counter As Integer = 0
        Try
            Do While Not MWB.ReadyState = WebBrowserReadyState.Complete And counter <= MaxWait
                'MsgBox("Still Busy")
                pause(1000)
                counter = +1
            Loop
            If counter = MaxWait Then
                If IsNothing(FacebookCustomerInfo.MYAPIinfo) Then
                    ' do nothing
                Else
                    Display(MainStatusBox, "Taking too long to setup Facebook")
                End If
            End If
        Catch ex As Exception
            pause(1000)
            counter = +1
            'If counter = MaxWait Then
            '    Display(StatusBox, "Taking too long to setup Facebook")
            'End If
            'Exit Sub
        End Try
    End Sub

    ''' <summary>
    ''' FBaut_click is activated when either of the Facebook logos are clicked. 
    ''' This brings up a webbrowser to log in to facebook and allow permissions 
    ''' to EPE's Facebook App. The global variable FacebookCustomerInfo is also set.
    ''' In addition, the dropdown menu is populated with existing albumms.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub FBauth_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If IsNothing(FacebookCustomerInfo.MYAPIinfo) Or FacebookCustomerInfo.MYAPIinfo.AccessToken = "AccessTokenError" Then
        If IsNothing(FacebookCustomerInfo.MYAPIinfo) Then
            FacebookGUI.Show()
            FacebookCustomerInfo = FBAuthenticate()
            If FacebookCustomerInfo.MYAPIinfo.AccessToken = "AccessTokenError" Then
                FacebookAuth_indicatorLabel.Text = "Error"
            Else
                FacebookAuth_indicatorLabel.Text = "Authenticated"
                GetAlbumsAndPopulateDropdown(sender, e)
            End If
        End If
    End Sub
    ''' <summary>
    ''' FBAuthenticate() brings up a web browser and allows the user
    ''' to login to Facebook. Also, during this time, the album drop down
    ''' list will populate.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FBAuthenticate() As HoodFacebookInfo
        ' GraphApi.Api()
        ' Adrian ID:            https://graph.facebook.com/601201034
        ' Hood and Sons ID:     https://graph.facebook.com/152049444821811
        ' fanpage ID (page_ID)  152049444821811
        ' Hood and Sons Fanpage:http://www.facebook.com/pages/Hood-and-Sons-Photography/152049444821811
        ' App Name:	        Event Photo Emailer
        ' App URL:	        www.hoodandson.com/EPE/
        ' App ID:	        197403413634224
        ' App Secret:	    47219a746539dd80c785138e4f3bfcfd

        ' Get Access Token
        ' No need to get UserID..its returned with MyAPI
        ' I do need to get Managed Account ID.
        ' CreateTestFacebookAccount()
        Dim OUTPUT As HoodFacebookInfo = Nothing
        Dim AppID As String = "197403413634224" ' Event Photo Emailer App ID
        Dim WindowLocationString As String = "https://www.facebook.com/connect/login_success.html"
        Dim ExtendedPermissions As String = "publish_stream,offline_access,user_photos" 'offline_access eliminates need to keep loggin in
        'Dim ExtendedPermissions As String = "publish_stream,user_photos" 'offline_access description looks like I want to be sneaky with the person's account
        Dim AuthString As String = "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}&response_type=token"
        Dim AuthorizeUrl As String = String.Format(AuthString, AppID, WindowLocationString, ExtendedPermissions)
        FacebookGUI.Show()
        IsForm2Open = True
        'FacebookGUI.WebBrowser1.Visible = True
        FacebookGUI.WebBrowser1.Navigate(AuthorizeUrl)
        WebWait(FacebookGUI.WebBrowser1, 15)
        'MyFacebookForm.Show() ' Using the browser on another form does not show during debugging
        'MyFacebookForm.WebBrowser1.Navigate(AuthorizeUrl)
        Dim BrowserReadyFlagg As Boolean = False
        Dim AccessURI As String = Nothing
        Dim BrowserCounter As Integer = 0
        Dim MaxLoginTime As Integer = 120
        FacebookGUI.LoginTimerLabel.Text = MaxLoginTime.ToString
        Dim remaining As Integer
        Dim MyAccessToken As String = Nothing
        Dim expire As String = Nothing
        Do While BrowserReadyFlagg = False And BrowserCounter < MaxLoginTime And IsForm2Open
            Try
                AccessURI = FacebookGUI.WebBrowser1.Url.ToString
                If AccessURI.ToString.StartsWith("https://www.facebook.com/connect/login_success") Then
                    BrowserReadyFlagg = True
                    Dim tmptmp As String = ExtractAccessToken(AccessURI.ToString)
                    tmptmp = "https://graph.facebook.com/152049444821811?fields=access_token&access_token=" & tmptmp
                    FacebookGUI.WebBrowser1.Navigate(tmptmp)
                    AccessURI = FacebookGUI.WebBrowser1.Url.ToString
                    FacebookGUI.WebBrowser1.Visible = False
                Else
                    pause(1000)
                    BrowserCounter += 1
                    remaining = MaxLoginTime - BrowserCounter
                    FacebookGUI.LoginTimerLabel.Text = remaining.ToString
                End If
            Catch ex As Exception
                BrowserCounter = -1
            End Try
        Loop

        If IsForm2Open = False Then
            ' do nothing and just return to form
            MyAccessToken = "AccessTokenError"
        Else
            FacebookGUI.Close()
            If BrowserCounter = MaxLoginTime Then
                MsgBox("The time period to login expired. Facebook authorization was not successful. Please make sure that your login information is correct")
                MyAccessToken = "AccessTokenError"
            ElseIf BrowserCounter = -1 Then
                MsgBox("An error occured while authorizing Facebook")
                MyAccessToken = "AccessTokenError"
            Else
                checktimerOK = False
                Dim MyURI() As String

                MyURI = Split(AccessURI, "=")
                expire = MyURI(2)
                MyAccessToken = MyURI(1)
                MyURI = Split(MyAccessToken, "&")
                MyAccessToken = MyURI(0)
                'Dim myAPI As New Api(MyAccessToken) 'global
                checktimerOK = True
                Dim sender As Object = Nothing
                Dim e As EventArgs = Nothing
            End If
        End If
        OUTPUT.MYAPIinfo = New GraphApi.Api(MyAccessToken)
        Return OUTPUT
    End Function

    Public Function ExtractAccessToken(ByVal Mystring As String) As String
        Dim MyURI() As String
        Dim expire As String
        Dim MyAccessToken As String
        MyURI = Split(Mystring, "=")
        expire = MyURI(2)
        MyAccessToken = MyURI(1)
        MyURI = Split(MyAccessToken, "&")
        MyAccessToken = MyURI(0)
        Return MyAccessToken
    End Function

    '' ''Function CreateTestFacebookAccount() As String
    '' ''    Dim AppID As String = "197403413634224"
    '' ''    Dim AppSecret As String = "47219a746539dd80c785138e4f3bfcfd"
    '' ''    'URL for testing
    '' ''    ' Get App_Access_Token
    '' ''    Dim AppAccessURL As String = String.Format("https://graph.facebook.com/oauth/access_token?client_id=1{0}&client_secret={1}&grant_type=client_credentials", AppID, AppSecret)
    '' ''    FacebookGUI.Show()
    '' ''    FacebookGUI.WebBrowser1.Navigate(AppAccessURL)
    '' ''    WebWait(FacebookGUI.WebBrowser1, 15)
    '' ''    'Dim theElementCollection As HtmlElementCollection = FacebookGUI.WebBrowser1.Document.GetElementsByTagName("input")
    '' ''    Dim HTMLCode As HtmlDocument = FacebookGUI.WebBrowser1.Document
    '' ''    Dim temp() As String = Split(HTMLCode.ToString, "=")
    '' ''    '' ''        Returns()
    '' ''    '' ''        {
    '' ''    '' ''   "id": "100002536207342",
    '' ''    '' ''   "access_token": "197403413634224|2.AQBWwyJ_QuOPAyNe.3600.1307149200.0-100002536207342|Ne1U0yzrGtFQaFd115h0_h1muaE",
    '' ''    '' ''   "login_url": "https://www.facebook.com/platform/test_account_login.php?user_id=100002536207342&n=PC5lI7OvePeihCj",
    '' ''    '' ''   "email": "xunnyyg_wisemanberg\u0040tfbnw.net",
    '' ''    '' ''   "password": "148067903"
    '' ''    '' ''}
    '' ''    Dim app_access_token As String = temp(1)
    '' ''    'Dim access_token As String = "197403413634224|ahbI-LAJCVPJxk9hQKk0tQBxokg"
    '' ''    AppAccessURL = _
    '' ''        String.Format("https://graph.facebook.com/{0}/accounts/test-users?installed=True&permissions=read_stream&method=post&access_token={1}", AppID, app_access_token)
    '' ''    FacebookGUI.WebBrowser1.Navigate(AppAccessURL)
    '' ''    WebWait(FacebookGUI.WebBrowser1, 15)
    '' ''    'HTMLCode = FacebookGUI.WebBrowser1.Document.All("login_url").InnerHtml
    '' ''    Return "Done"
    '' ''End Function

    ''' <summary>
    ''' Fill_ISP_listbox reads data from the "\bin\SMTPServerList.csv" file.
    ''' This file is a database of known ISP companies and thier IP addresses
    ''' </summary>
    ''' <param name="Commonpath"></param>
    ''' <remarks></remarks>
    Public Sub Fill_ISP_Listbox(ByVal Commonpath As String)
        Dim tmp1() As String
        Dim tmp2 As String
        Dim SS As StreamReader = New StreamReader(Commonpath & "\SMTPServerList.csv")
        Try
            While Not SS.EndOfStream
                tmp2 = SS.ReadLine
                tmp1 = Split(tmp2, ",")
                'tmp2 = "<" & tmp1(0) & "> " & tmp1(1)
                tmp2 = tmp1(0) & " -- " & tmp1(1)
                EmailSetupForm.ComboBox1.Items.Add(tmp2)
            End While
        Catch ex As Exception
            Debug.Print("Problem loading the SMTP server list")
        End Try
        SS.Close()
    End Sub


    Private Sub ChkConnectionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkConnectionButton.Click
        checkinternetconnection() ' This will only change the status label
    End Sub

    Public Function MailHood(ByVal emailuse As String, ByVal filenames As String) As MAILERRORHOOD
        Dim MailError As MAILERRORHOOD
        Dim InfoBoxesComplete As Boolean = True
        MailError.SMTPOK = False ' Assume that it does not go through. Was causing a false message that the file was being emailed
        MailError.SMTPerrorMessage = "An error occured during transmission"
        Dim SmtpServer As New SmtpClient()
        AddHandler SmtpServer.SendCompleted, AddressOf SendCompletedCallback
        Try

            If EmailSetupForm.textBox_Username.Text = "" Or EmailSetupForm.textBox_Password.Text = "" Then
                MsgBox("Email parameter field contain blank entries. Please enter the correct information.")
                MailError.SMTPerrorMessage = "Error - Parameters not set"
                MailError.SMTPOK = False
            Else
                With SmtpServer
                    .Credentials = New Net.NetworkCredential(EmailSetupForm.textBox_Username.Text, EmailSetupForm.textBox_Password.Text)
                    .Port = CType(EmailSetupForm.PortBox.Text, Integer)
                    .Host = EmailSetupForm.textBox_MailServer.Text
                    If EmailSetupForm.SSLcheckBox.Checked Then
                        .EnableSsl = True
                    Else
                        .EnableSsl = False
                    End If
                End With

                Dim addr() As String = Nothing

                addr = Split(emailuse, ";")
                Dim mail = New MailMessage()
                Try
                    With mail
                        .From = New MailAddress(EmailSetupForm.CompEmailTextbox.Text, EmailSetupForm.CompNameTextbox.Text, System.Text.Encoding.UTF8)
                        .Subject = textBox_SubjectLine.Text
                        .Body = GetFileContents(textBox_messagefile.Text) ' have to write code to get contents of file
                        If EmailAndFacebookRadio.Checked Then
                            Dim tmp() As String = Split(mail.Body, "****")
                            If tmp.Length > 1 Then
                                .Body = tmp(0) & vbCrLf & _
                                    "Your image has also been uploaded to Facebook: " & vbCrLf & _
                                    FacebookCustomerInfo.MyAlbumLink & vbCrLf _
                                    & tmp(1)
                            End If
                        End If
                        .DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
                        .ReplyTo = New MailAddress(EmailSetupForm.CompEmailTextbox.Text)

                        Dim i As Integer
                        For i = 0 To addr.Length - 1
                            .To.Add(addr(i))
                        Next

                        Dim filestoemail() As String = Split(filenames, ";") ' This delimiter is sent in sendemail()

                        If EmailSetupForm.AttachFilesYesNoCheckbox.CheckState = CheckState.Checked Then
                            For i = 0 To filestoemail.Length - 1
                                .Attachments.Add(New Attachment(filestoemail(i)))
                            Next
                            mail.Body = Replace(mail.Body, "<p>", vbCrLf)
                            mail.Body = Replace(mail.Body, "<P>", vbCrLf)
                        Else
                            mail = MailMessage(mail, filestoemail)
                        End If
                    End With
            While tryagain < MaxTries
                Try
                    'Dim userState As Object = "test message1"
                    'SmtpServer.SendAsync(mail, userState) ' SendAsync works like a charm however I would have to redo my code in order to provide feedback to the window (TODO later)
                    ' If an error occurs, an exception will be thrown and the default values for MailError will pass. Otherwise, success flags will be used.
                    SmtpServer.Send(mail)
                    tryagain = MaxTries + 1
                    MailError.SMTPOK = True
                    MailError.SMTPerrorMessage = "No Error"
                Catch ex As Exception
                    tryagain += 1
                    Display(MainStatusBox, "Error sending email: Retry: " & tryagain & " of " & MaxTries)
                    pause(1000) 'used to allow info to show and recognize cancel
                End Try
            End While

        Catch ex As Exception
            MsgBox("Problem Sending Email")
            ''If tryagain <= MaxTries Then
            ''    While tryagain <= MaxTries
            ''        SmtpServer.Send(mail)
            ''    End While
            ''    tryagain += 1
            ''    Display(MainStatusBox, "Retrying the SMTP connection. Try: " & tryagain & "of " & MaxTries)
            ''    pause(5000) 'used to allow info to show and recognize cancel
            ''    MailError = MailHoodTest()
            ''Else
            ''    tryagain = 0
            ''    MsgBox(ex.ToString())
            ''    MailError.SMTPOK = False
            ''    MailError.SMTPerrorMessage = ex.ToString()
            ''End If
        End Try
            End If
        Catch ex As Exception
            MsgBox("If This box is seen, then something is wrong with they Try/Catch in MailHood")
        End Try
        tryagain = 1 ' reset
        Return MailError
    End Function

    ''Public Function sendInlineImg(mail As MailMessage, MyFilename As String) As MailMessage
    ''    'Dim mail As New MailMessage()
    ''    mail.IsBodyHtml = True
    ''    mail.AlternateViews.Add(getEmbeddedImage(MyFilename, mail))
    ''    'mail.From = New MailAddress(MyAddress)
    ''    'mail.[To].Add(MyCustomers)
    ''    'mail.Subject = MySubject
    ''    Return mail
    ''    'MySmtpServer.Send(mail) '* Set up your SMTPClient before!
    ''End Function
    ''Public Function getEmbeddedImage(filePath As [String], mail As MailMessage) As AlternateView
    ''    'TODO
    ''    'It looks like each call to this method replaces the htmlbody
    ''    'so that the email sent only shows the last image
    ''    'I need to append the htmlbody with a new <img src...> line
    ''    Dim htmlBody As String
    ''    Dim inline As New LinkedResource(filePath)
    ''    inline.ContentId = Guid.NewGuid().ToString()
    ''    If mail.AlternateViews.Count > 0 Then ' 
    ''        htmlBody = mail.Body & vbCrLf & "<img src='cid:" + inline.ContentId + "'/>"
    ''    Else
    ''        htmlBody = "<img src='cid:" + inline.ContentId + "'/>"
    ''    End If
    ''    Dim alternateView__1 As AlternateView = AlternateView.CreateAlternateViewFromString(htmlBody, Nothing, "text/html")
    ''    alternateView__1.LinkedResources.Add(inline)
    ''    Return alternateView__1
    ''End Function

    Public Function MailMessage(msg As MailMessage, filestoemail As String()) As MailMessage
        msg.IsBodyHtml = True

        ' Generate the charts for the given metric

        'Dim htmlBody As String = "<html><body>" & vbCrLf & msg.Body

        Dim htmlBody As String = msg.Body
        ' Attach filenames
        For i = 0 To filestoemail.Length - 1
            If EmailPrompt.IncludeAdCheckBox1.Checked = True Then
                If i > 0 Then
                    htmlBody = htmlBody & " <P>" & "Attachment: " & GetFileNameFromPath(filestoemail(i))
                End If
            End If
            If EmailPrompt.IncludeAdCheckBox1.Checked = False Then
                htmlBody = htmlBody & " <P>" & "Attachment: " & GetFileNameFromPath(filestoemail(i))
            End If
        Next
        htmlBody = htmlBody & " <P>"

        Dim resources As New List(Of LinkedResource)()
        For i As Integer = 0 To filestoemail.Count - 1

            Dim inline As New LinkedResource(filestoemail(i), "image/jpeg")
            inline.ContentId = Guid.NewGuid().ToString
            inline.ContentId = "MyImage" & i
            Dim imageTag As String = String.Format("<img src=cid:MyImage{0} /><br>", i)
            'Dim imageTag As String = "<img src='cid:" + inline.ContentId + "'/><br>"
            htmlBody += vbCrLf & imageTag
            resources.Add(inline)
        Next

        'htmlBody += vbCrLf & "</body></html>"

        ' Alternate view for embedded images
        'Dim avText As AlternateView = AlternateView.CreateAlternateViewFromString(metric.Name, Nothing, "text/html")
        Dim avImages As AlternateView = AlternateView.CreateAlternateViewFromString(htmlBody, Nothing, "text/html")

        ' Add all the images as linked resources
        'resources.ForEach(Function(x) avImages.LinkedResources.Add(x))
        For Each xx As LinkedResource In resources
            avImages.LinkedResources.Add(xx)
        Next
        ' Add the views for image
        'msg.AlternateViews.Add(avText)
        msg.AlternateViews.Add(avImages)


        Return msg
    End Function


    Public Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        ' Get the unique identifier for this asynchronous operation.
        Dim token As String = CStr(e.UserState)

        If e.Cancelled Then
            Console.WriteLine("[{0}] Send canceled.", token)
        End If
        If e.Error IsNot Nothing Then
            Console.WriteLine("[{0}] {1}", token, e.Error.ToString())
            Display(MainStatusBox, token & vbCrLf & e.Error.ToString())
        Else
            Console.WriteLine("Message sent.")
        End If
    End Sub

    Public Function TestSMPT() As Boolean
        Dim client As System.Net.Sockets.TcpClient
        client = New System.Net.Sockets.TcpClient(EmailSetupForm.textBox_MailServer.Text, CInt(EmailSetupForm.PortBox.Text))
        Dim stream As Object = client.GetStream()
        Dim bytes() As Byte = System.Text.Encoding.ASCII.GetBytes("localhost helo")
        client.GetStream.Write(bytes, 0, bytes.Length)
        TestSMPT = client.Connected
    End Function

    Public Function MailHoodTest() As MAILERRORHOOD
        Dim MailError As MAILERRORHOOD
        MailError.SMTPOK = True
        MailError.SMTPerrorMessage = "No Error"
        Dim SmtpServer As New SmtpClient()
        If Len(EmailSetupForm.PortBox.Text) = 0 Then
            EmailSetupForm.PortBox.Text = "25"
        End If
        'Dim SMTPUserInfo As System.Net.NetworkCredential
        ''SMTPUserInfo = New System.Net.NetworkCredential(ConfigurationManager.AppSettings(EmailSetupForm.textBox_Username.Text), ConfigurationManager.AppSettings(EmailSetupForm.textBox_Password.Text))
        With SmtpServer
            '.Credentials = SMTPUserInfo
            .UseDefaultCredentials = False
            .Credentials = New Net.NetworkCredential(EmailSetupForm.textBox_Username.Text, EmailSetupForm.textBox_Password.Text)
            .Port = CType(EmailSetupForm.PortBox.Text, Integer)
            .Host = EmailSetupForm.textBox_MailServer.Text

            If EmailSetupForm.SSLcheckBox.Checked Then
                .EnableSsl = True
            Else
                .EnableSsl = False
            End If
        End With

        ''Dim mail = New MailMessage()
        ''With mail
        ''    .From = New MailAddress(EmailSetupForm.CompEmailTextbox.Text, EmailSetupForm.CompNameTextbox.Text, System.Text.Encoding.UTF8)
        ''    .Subject = textBox_SubjectLine.Text
        ''    .Body = GetFileContents(textBox_messagefile.Text) ' have to write code to get contents of file
        ''    .DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
        ''    .ReplyTo = New MailAddress(EmailSetupForm.CompEmailTextbox.Text)
        ''    .To.Add("epedummy@hoodandsons.com") ' This email address is setup on my server and routes 
        ''End With

        MailError.SMTPOK = False ' No error was tripped
        MailError.SMTPerrorMessage = "No Error"
        Dim DisplayedAlready As Boolean = False
        While tryagain <= MaxTries And MailError.SMTPOK = False
            Try
                'SmtpServer.Send(mail)
                MailError.SMTPOK = TestSMPT() ' Will throw an execption on error, otherwise will be true
                'MailError.SMTPOK = True ' If not error
            Catch ex As Exception
                If tryagain <= MaxTries Then
                    tryagain += 1
                    Display(MainStatusBox, "Checking SMTP Server: Try: " & tryagain & " of " & MaxTries & vbCrLf)
                    'If DisplayedAlready = False Then
                    '    Display(MainStatusBox, "Error Message: " & ex.ToString & vbCrLf)
                    '    DisplayedAlready = True
                    'End If
                    pause(100) 'used to allow info to show
                    MailError.SMTPerrorMessage = "Error with SMTP. Please check your parameters. No emails were sent." & vbCrLf & vbCrLf & "Error Message:" & vbCrLf & vbCrLf & ex.ToString
                    'MailHoodTest()
                    'SmtpServer.Send(mail) 'try again
                Else
                    MsgBox("Unable to send email. Please check your SMTP parameters")
                    'sgBox(ex.ToString())
                    MailError.SMTPerrorMessage = ex.ToString()
                End If
            End Try
        End While
        tryagain = 0
        ' ''If tryagain > 0 And MailError.SMTPOK = False Then
        ' ''    Display(MainStatusBox, "Unable to send email. Please check your SMTP parameters")
        ' ''End If
        Return MailError
    End Function


    '''<summary>
    ''' EmailPrompt allows emails to be entered when images arrive in the hotfolder. This eliminates
    ''' the need for Darkroom to attach the email address to the filename. A small thumbnail will
    ''' show to make sure the correct image is chosen.
    ''' </summary>
    ''' <param name="ImageAddress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Function EmailPromptFunction(ByVal ImageAddress As String) As String
        Dim emailstrings As String = Nothing
        Dim emailnamesstrings As String = Nothing
        EmailPrompt.Show()
        EmailPrompt.Activate() ' brings box to the front
        'EmailPrompt.UpdateAutoComplete()
        'EmailPrompt.Thumbnail_PictureBox.Image = System.Drawing.Image.FromFile(ImageAddress)
        AutosizeImage(ImageAddress, EmailPrompt.Thumbnail_PictureBox, EmailPrompt.PhotoLabel_Label)
        ContinueOrCancel = ""
        While ContinueOrCancel <> "Cancel" And ContinueOrCancel <> "Continue"
            pause(100)
            If RepeatEmailsInEmailPrompt = True And (ContinueOrCancel <> "Cancel" And ContinueOrCancel <> "Continue") Then
                EmailPrompt.RepeatEmail_Button1.PerformClick()
                EmailPrompt.ContinueButton.PerformClick() 'TODO May need to do EnterPreviousEmailAddress.PerformClick(()
                ContinueOrCancel = "Continue"
            End If
        End While
        If ContinueOrCancel = "Cancel" Then
            emailstrings = ""
        End If
        If ContinueOrCancel = "Continue" Then
            emailstrings = EmailPrompt.TextBox1.Text & "!" & _
            EmailPrompt.TextBox2.Text & "!" & _
            EmailPrompt.TextBox3.Text & "!" & _
            EmailPrompt.TextBox4.Text & "!" & _
            EmailPrompt.TextBox5.Text

            emailnamesstrings = EmailPrompt.EmailNameText1.Text & "!" & _
            EmailPrompt.EmailNameText2.Text & "!" & _
            EmailPrompt.EmailNameText3.Text & "!" & _
            EmailPrompt.EmailNameText4.Text & "!" & _
            EmailPrompt.EmailNameText5.Text

        End If
        ' EmailSave variables are Global which allows them to be recalled 
        Email1Save = EmailPrompt.TextBox1.Text
        Email2Save = EmailPrompt.TextBox2.Text
        Email3Save = EmailPrompt.TextBox3.Text
        Email4Save = EmailPrompt.TextBox4.Text
        Email5Save = EmailPrompt.TextBox5.Text
        Name1Save = EmailPrompt.EmailNameText1.Text
        Name2Save = EmailPrompt.EmailNameText2.Text
        Name3Save = EmailPrompt.EmailNameText3.Text
        Name4Save = EmailPrompt.EmailNameText4.Text
        Name5Save = EmailPrompt.EmailNameText5.Text
        EmailPrompt.Hide()
        EmailPrompt.TextBox1.Text = "" ' clears the box
        EmailPrompt.TextBox2.Text = "" ' clears the box
        EmailPrompt.TextBox3.Text = "" ' clears the box
        EmailPrompt.TextBox4.Text = "" ' clears the box
        EmailPrompt.TextBox5.Text = "" ' clears the box
        EmailPrompt.EmailNameText1.Text = ""
        EmailPrompt.EmailNameText2.Text = ""
        EmailPrompt.EmailNameText3.Text = ""
        EmailPrompt.EmailNameText4.Text = ""
        EmailPrompt.EmailNameText5.Text = ""
        emailstrings = Replace(emailstrings, "!!!!", "") ' case for only one entry
        emailstrings = Replace(emailstrings, "!!!", "") ' case for only 2 entries
        emailstrings = Replace(emailstrings, "!!", "") ' case for only 3 entries
        emailnamesstrings = Replace(emailnamesstrings, "!!!!", "") ' case for only one entry
        emailnamesstrings = Replace(emailnamesstrings, "!!!", "") ' case for only 2 entries
        emailnamesstrings = Replace(emailnamesstrings, "!!", "") ' case for only 3 entries
        If EmailPrompt.SaveForLaterCheckBox.Checked Then
            Dim newfilename = Textbox_imagefolder.Text & "\EmailLater\" & emailstrings & "$" & GetFileNameFromPath(ImageAddress)
            System.IO.File.Copy(ImageAddress, CheckIfFileExistandIfSoAppendNumber(newfilename))
            Dim MyInputString As String = "[" & System.DateTime.Now & "] [" & GetFileNameFromPath(ImageAddress) & "] was sent to the EmailLater folder"
            Display(MainStatusBox, MyInputString)
            'My.Computer.FileSystem.WriteAllText(StatusFile, MyInputString & Chr(13), True)
            'File is deleted after return
            Return "EmailLater"
        Else
            Return emailstrings & "**" & emailnamesstrings
        End If
        'ContinueOrCancel = "Continue" ' Reset just in case the cancel button was pressed.
        ContinueOrCancel = "" ' Reset just in case the cancel button was pressed.
    End Function

    Public Function CheckIfFileExistandIfSoAppendNumber(ByVal newfilename As String) As String
        If File.Exists(newfilename) Then
            Dim tmp() As String = Split(newfilename, ".jpg")
            newfilename = tmp(0) & "_1.jpg"
            'File.Delete(newfilename) 'An attempt was made to append the file with a counter but
            ' book keeping got a little cumbersome. I may return to this but now, it simply 
            ' deletes the old file
        End If
        Return newfilename
    End Function


    Public Function GetFileContentsCompany(ByVal FullPath As String, ByVal CompanyName As String, Optional ByRef ErrInfo As String = "") As String
        Dim strContents As String
        Dim objReader As StreamReader
        Dim NewMessage As String
        Try
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            NewMessage = strContents & vbCrLf & vbCrLf & "Photography by " & CompanyName
            'MsgBox(NewMessage)
            Return NewMessage
        Catch Ex As Exception
            ErrInfo = Ex.Message
            NewMessage = "There was a problem reading the file"
            MsgBox(NewMessage)
            Return "Failed"
        End Try

    End Function




    Public Sub NotifyEmailSuccess(ByVal MyMessage As String)
        Dim tmpNotify = NotifyIcon1.BalloonTipText
        NotifyIcon1.BalloonTipText = MyMessage
        NotifyIcon1.ShowBalloonTip(100)
        NotifyIcon1.BalloonTipText = tmpNotify
    End Sub

    Public Sub ClearWindowButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearWindowButton.Click
        MainStatusBox.Clear()
    End Sub

    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MakeThinButton.Click
        'Activate Make Thin
        MyMakeThinForm.Show()
        'MsgBox(" The Make Thin Option is currently unavailable")
        ' I need to figure out why I am unable to access the form from the project MakeThin
    End Sub


    Public Function ConditionImageFolder() As Collection
        Dim Str As New IO.DirectoryInfo(Textbox_imagefolder.Text)
        Dim emailstring(0) As String ' An array used to parse the email for multiple emails using the split command
        Dim filenamestring(0) As String ' An array used to parse the filename for multiple files
        Dim listing As IO.FileInfo() = Str.GetFiles("*.jpg") ' Currently, only .jpg files are emailed
        Dim NumOfFiles As Double = listing.Length
        ' Sort Listing First
        Dim counter As Integer = 0
        Dim fullstringcounter As Integer = 0
        Dim temp() As String
        Dim oldfilename, newfilename As String
        Dim filenamecollection As New Collection
        For Each fullstring In listing ' This loops parses the files and produces arrays for email() and filename()
            fullstringcounter += 1
            temp = Split(fullstring.Name, "$") 'temp(0):email temp(1):filename
            'MsgBox("Filename = " & fullstring.Name & "   FullstringCounter = " & fullstringcounter & "  temp(0): " & temp(0) & "  temp(1): " & temp(1))
            If temp.Length < 2 Then 'indicates that there was no $ in the string. Will need to add the $ to proceed
                ReDim Preserve temp(1)
                temp(1) = temp(0)
                temp(0) = ""
            End If
            'First copy image to the event folder truncating the email address(s)
            oldfilename = Textbox_imagefolder.Text & "\" & fullstring.Name
            newfilename = Textbox_imagefolder.Text & "\SIoutput\" & temp(1)

            If File.Exists(newfilename) Then
                Dim tmp() As String = Split(newfilename, ".jpg")
                newfilename = tmp(0) & "_1.jpg"
                'File.Delete(newfilename) 'An attempt was made to append the file with a counter but
                ' book keeping got a little cumbersome. I may return to this but now, it simply 
                ' deletes the old file
            End If
            File.Copy(oldfilename, newfilename, True)
            filenamecollection.Add(newfilename)
        Next
        Return filenamecollection
    End Function



    Private Sub MainStatusBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainStatusBox.TextChanged
        'SENDEMAILFromEmailReadyFolderFLAGG = False
        RunGo()
    End Sub

    Private Function ConvertEmailFileToTable(ByVal Filename As String) As System.Data.DataTable
        Dim MyEmailTable As System.Data.DataTable = csvToDatatable_2(Filename, System.Convert.ToChar(","))
        Return MyEmailTable
    End Function

    Private Sub Textbox_imagefolder_TextChanged(sender As System.Object, e As System.EventArgs) Handles Textbox_imagefolder.TextChanged
        DefaultImageDirectory = Textbox_imagefolder.Text
    End Sub


    Private Sub Config0ButtonFrontPage_Click(sender As System.Object, e As System.EventArgs) Handles Config0ButtonFrontPage.Click
        EmailSetupForm.ConfigButton0_Click(sender, e)
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Config1ButtonFrontPage.Click
        EmailSetupForm.ConfigButton1_Click(sender, e)
    End Sub

    Private Sub Config2ButtonFrontPage_Click(sender As System.Object, e As System.EventArgs) Handles Config2ButtonFrontPage.Click
        EmailSetupForm.ConfigButton2_Click(sender, e)
    End Sub

    Private Sub Config3ButtonFrontPage_Click(sender As System.Object, e As System.EventArgs) Handles Config3ButtonFrontPage.Click
        EmailSetupForm.ConfigButton3_Click(sender, e)
    End Sub

    Private Sub Config4ButtonFrontPage_Click(sender As System.Object, e As System.EventArgs) Handles Config4ButtonFrontPage.Click
        EmailSetupForm.ConfigButton4_Click(sender, e)
    End Sub


End Class
