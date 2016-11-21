Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Collections
Imports System.Diagnostics.Process
Imports System.Environment
Imports Facebook_Graph_Toolkit.GraphApi
Imports Facebook_Graph_Toolkit
'Imports JSON
Imports System.Net
Imports System.Web
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Json
Imports System.Web.Security
Imports System.Web.UI.WebControls
Imports System.Web.UI.Control
Imports System.Text
'''<summary>
''' This is the source code for Event Photo Emailer. The main goal of this program is to email photos. 
''' <history>
'''11-20 - Added the check for filenames that start with $ This is an indicator that Darkroom did 
'''not have an email address attached to the file. If not moved, an error will be generated. I wrote
''' code to move this to a folder called not named. This folder is in the EventFolder.
'''
''' 12-20 Wrote code that sends multiple images to a single email address. This works by taking inventory
'''of all the different email addresses and their corresponding image files. For the email address containing
'''more than a single image, an array is created and a filenameSTRING is created that has the form
'''image1.jpg;image20.jpg;image450;jpg' This is done before the email engine is called
'''When writing this code, the task of saving the truncated email file to the event folder was relegated
'''to the parsing stage from the sendemail stage. The filenames that are sent to the email program.
'''
''' 12-24 Wrote code that will allow the automatic sending of emails by monitoring a specified folder
'''
''' 12-26 A VB based emailing library was purchased in order to eliminate the use of the DOS based emailing program
'''and the limitations console batch programming. This program requires an unlocking key to unlock the see32.dll file
'''It also has a see64.dll to use when compiling on a 64bit machine. The 32 bit compilation should work ok on both 
'''64 bit and 32 bit machines
'''
''' 1/10/10 Added the ability to save the delay information. The delay is beneficial in the print to email mode in that it 
'''waits before collecting images to email. If a person is getting multiple images, it may send the first as soon as it comes
'''then when finished, send the others
'''1/10/10 Re-wrote code so that, when emails are created via ED, the working files will be deleted. However, they will only 
'''be deleted after a successfull send. This is so that if an error occurs in a batch email, it would be easy to pick
'''up where one leaves off
'''
''' 2-24 Added code to automatically run DarkroomShortcut_WinZ.exe program that produces a shortcut that
'''opens the photodata box and inserts email text.
'''2-24 added code that stops DarkroomShortcut_WinZ.exe when the program is exited via 'X' or via system tray
'''2-24 Added code to check for a connection before moving forward. This way, no files are deleted or folders
'''produced unnessesarily. CheckEmailConnection()
'''2-24 Added code that minimizes the window to the system tray and offers 3 options (hide,show,exit)
'''Added a start/stop indicator.
'''2-24 Created a structure variable for the Error variable.
'''
''' 2-26 Updated the version to 3.0
'''
''' 3-3 Changed the way that I handle the company's name. I wrote an encryption program that will 
'''encrypt text. This way, I can encrypt the company's name and email address and supply a license code
'''In compiling the code, CompanyName is set to "Evaluation" and "Return Email is "EVAL@SomeCompany.com"
'''Also, the message box is locked. 
'''The password was also encrypted.
'''3-3 Changed to version 3-1-0-0
'''
''' 4-20 RIP Dr. Heights.... Today, created an installer.
'''
''' 5-17 Fixed case for which the port address is different than 25. In checkconnection(), I had failed to 
'''set the port number before checking the connection. On my home system, the default 25 worked so the issue
'''was not flagged. Verizon FIOS recently blocked 25 and switched to 587 and the code stopped working. This is 
'''what drew me to this omission.
'''5-17 For cases for which the given email address is unroutable (Code = -49), a message is displayed saying
'''that the file is not routable and it is skipped. This will keep appearing until it is manually fixed.
'''5-17 It was noticed that a time delay is needed after the program makes an initial check for connectivity. Originally
'''I had 1 second, but I changed it to 5 seconds. This 5 second delay will be experienced each time the send button is
'''pressed or a new run (when in auto mode).
'''
''' 8-1 It was noticed that the UI became unresponsive when the watchfolder was active. This was fixed by placing
'''GOButton (renamed to LetsGo() ) in its own thread RunGO()
'''
''' 8-23 Added an internet connection status label
'''8-23 Added a standby notice
'''8-23 Added code that allows autoemail and confirmation selections to be saved.
'''
''' 9-2  Addressed issue with auto email mode for which files enter the folder quickly. Since this process is placed on a 
'''thread, there exist the possibilty of mulitple threads being launched for each file
'''
''' Oct 29, created the option to disable the email combining feature.
'''
''' Nov 1, added module to check for valid email address (IsValidEmail)
'''
''' March 8, 2011 - Added code to first access POP3. (I recieved a call from someone who said that their provider requires both pop3 
'''authentication and smtp authenication. The current command is simply Code = seePop3Connect(0, textBox_MailServer.Text, textBox_Username.Text, textBox_Password.Text) 
'''if Code=>0, then it is ok.
'''
''' March 8, 2011 - Added code to send email to Facebook. If the box is checked, the email address is replaced by the Facebook email.
'''Note: I still need to work on not purging filenames without email addresses (WORK ON LATER)
'''
''' April 16, 2011 - Fixed problem with streamline.net not sending out emails. I was told that I had to 1st check incoming email and then outgoing. It did not work.
'''After updating the emailing class see4VB it worked as long as the return to email is a derivative of the IP company. For version 51, I removed the incoming field.
'''
''' April 24, 2011 - Last week I created a Facebook App and modified the code to incorporate the app. Currently, it just uploads to the same folder. However, in the future, it will create folders and then add to them. The Faceebook Graph Toolkit is used.
'''I added a master email list that will keep adding emails across events
'''I got rid of the different event folders. Now, event folders are limited to the day they are created
'''I added a separate form to handle the configuration information
'''Added email only, facebook only, facebook and  email
'''Modified the packages to include 3 EPE printers  A0 A1 A2
'''Modified .reg files to install the 3 EPE printers
'''</history>
'''</summary>



Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim MyForm2 As New Form2()
    'DEFINE GLOBAL VARIABLES
    'Dim BuildType As Boolean = True ' True allows the Reply To address to Change
    Dim BuildType As Boolean = False ' True allows the Reply To address to Change
    'Dim BuildType As String = "Keep Reply To Company Name"

    ' Get Company Info from License File
    Dim SiteToPing As String = "www.google.com" ' used to detect internet connection availability
    Dim CompanyEmail As String
    Dim UserCompanyName As String
    Dim CancelFlagg As String = "Run" ' Needed to be able to cancel the emailing program
    Dim Code As Integer ' used as the returned variable for the seeVB library (email library)
    Dim NullString As String  ' used with seeVB
    Dim StatusFile As String
    Dim EventFolder As String
    Dim WithEvents WatchFolder As New System.IO.FileSystemWatcher()
    Dim GOThread As System.Threading.Thread
    Dim CheckEmailConnectionThread As System.Threading.Thread
    Dim SeeSMTPonThread As System.Threading.Thread
    Dim runstatusdots As System.Threading.Thread
    Dim chkemailconn As Boolean
    Dim AutoEmailFlagg As Boolean ' Use to signal other control to go invisible and to use only one event folder
    Dim SENDEMAILFLAGG As Boolean = True
    Dim WinZProgram As New Process() ' Used to run Shortcup program. Check if it exists first.
    Dim NewImagesAreReady As Boolean = False ' Used in autosend mode to detect that new images have been added while
    ' sendemail is processing previous photos
    Dim SmtpErrorCodeGlobal As Integer 'used when checking SMTP connection only.
    'Private Strt As System.Threading.Thread ' Used when monitoring a folder
    Public Const SEE_KEY_CODE As Integer = 1906781263&
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
        Dim MYAPIinfo As Facebook_Graph_Toolkit.GraphApi.Api
        Dim MYALBUMID As String
        Dim MYAID As String
    End Structure
    Dim FacebookCustomerInfo As HoodFacebookInfo = Nothing
    Dim WinZShortcut As String = "DarkroomShortcut_WinZ"
    Dim CurrentDirectory As String = System.Environment.CurrentDirectory
    'Dim MyApplicationDataFolder As String = Environment.GetFolderPath(SpecialFolder.ApplicationData)
    ' Dim MyApplicationDataFolder As String = Environment.GetFolderPath(SpecialFolder.CommonApplicationData) & "\EPE"
    'Dim DefaultImageDirectory As String = MyApplicationDataFolder & "\EPE_Hotfolder"
    Dim DefaultImageDirectory As String = CurrentDirectory & "\EPE_Hotfolder"
    'Dim DefaultFile As String = MyApplicationDataFolder & "\bin\DefaultS.txt"
    Dim DefaultFile As String = CurrentDirectory & "\bin\Defaults.txt"
    'Private Delegate Sub UpdateStatusWindowThread(ByVal MyString As String)
    'Private _updateStutusWindow As New UpdateStatusWindowThread(AddressOf LetsGO)
    Dim CHECKCONNECTIONYESNO As Boolean = True
    Dim SENDEMAILFINISHEDFLAGG As Boolean = True
    Dim CustomerAPI As GraphApi.Api = Nothing
    Dim FACEBOOKERRORONCE As Boolean = True
    Dim FACEBOOKERROR As Boolean = False
    Dim checktimerOK As Boolean = True ' used to keep the timer from checking internet connection while webpage is loading for Facebook mode
    Dim RunningInAutoMode As Boolean = False
    Dim InitialConnectionCheck As Boolean = True
    Dim POSTONFACEBOOKYESNO As Boolean = False ' used to keep from actually uploading
    ' **************************************  MAIN SUBROUTINES *****************
    ''' <summary>
    ''' Form1_Load() does the following:
    ''' sets CheckForIllegalCrossTread = False
    ''' Runs the splash screen
    ''' Initializes Email engine
    ''' Check for an initial internet connection
    ''' Reads setup data from saved file
    ''' Sets up toolstrip comments
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        SplashScreen1.Show()
        pause(2000)
        SplashScreen1.Hide()
        Me.Text = " Event Photo Emailer - Version: " & My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Revision
        ' The watchfolder is used monitor a folder for new entries. It is necessary to create it here in FormLoad
        ' to avoid threading errors. Initially, I had disabled that error. I have since re-enabled it now that I 
        ' correctly placed the code.
        'AddHandler WatchFolder.Created, AddressOf RunGo
        AddHandler GoButton.Click, AddressOf RunGo
        '******************************************* "Initialization Code For Emailer Library *********"
        ' attach SEE (seeAttach must be 1st SEE function called)
        ' This program checks to see if code and .dll file matches
        ' It either needs the keycode.vb attached or defined within this document
        Code = seeAttach(2, SEE_KEY_CODE)
        If Code < 0 Then
            MsgBox("Error: Problem is accessing emailer library.. Cannot attach..Check Keycode")
            End
        End If
        '******************************************* Initialization Code For Emailer Library *********"

        checkinternetconnection() ' Changes status label only. No process depends on the result.


        ProgDir2.Text = CurrentDirectory
        ' ******************************************* Enter Customer Information
        Dim COMPDATA As CompanyInfoSTRUCTURE
        COMPDATA = GetLicenseCode(CurrentDirectory)
        If COMPDATA.EvaluationMode = True Then
            MsgBox("You are operating in Evaluation Mode." & vbCrLf & _
                   " Your Company Name and Company Email address will reflect this")
        End If
        CompanyEmail = COMPDATA.CompanyEmail
        UserCompanyName = COMPDATA.CompanyName & COMPDATA.CompanyEmail
        CustomerInfoLabel.Text = "Licensed to: " & UserCompanyName
        ' ******************************************* Set Default Field Settings

        WinZProgram.StartInfo.FileName = CurrentDirectory & "\bin\" & WinZShortcut & ".exe"
        WinZProgram.StartInfo.Arguments = " "
        If File.Exists(WinZProgram.StartInfo.FileName) Then
            If IsProcessRunning(WinZShortcut) = False Then
                WinZProgram.Start()
            End If
        End If
        'MsgBox("The CurrentDirectory is: " & CurrentDirectory)
        'Dim DefaultFile As String = CurrentDirectory & "\bin\defaults.txt"


        'Dim DefaultFile As String = ProgDir2.Text & "\bin\defaults.txt"
        'defaults.txt order:
        '1 Subject Line 2 Image Folder 3 Message file 4 Mail Server Username 5 Port box 6 Time Interval 7 Facebook Login
        '8 Confirmation state 9 combine email 10 mail encryption
        If File.Exists(DefaultFile) Then
            Dim fs As New FileStream(DefaultFile, FileMode.Open, FileAccess.Read)
            'declaring a FileStream to open the file named file.doc with access mode of reading
            Dim d As New StreamReader(fs)
            'creating a new StreamReader and passing the filestream object fs as argument
            d.BaseStream.Seek(0, SeekOrigin.Begin)
            'Seek method is used to move the cursor to different positions in a file, in this code, to 
            'the beginning
            'ProgDir2.Text = d.ReadLine()
            textBox_SubjectLine.Text = d.ReadLine()
            If COMPDATA.EvaluationMode = True Then
                textBox_SubjectLine.ReadOnly = True
                textBox_SubjectLine.Text = "Evaluation Mode"
                FacebookCaptionTextBox1.ReadOnly = True
                FacebookCaptionTextBox1.Text = "Evaluation: Event Photo Emailer www.hoodandson.com/EPE"
            Else
                textBox_SubjectLine.ReadOnly = False
            End If
            Textbox_imagefolder.Text = d.ReadLine()
            If Textbox_imagefolder.Text = "*" Then
                Textbox_imagefolder.Text = DefaultImageDirectory
            End If
            textBox_messagefile.Text = d.ReadLine()
            If textBox_messagefile.Text = "*" Then
                textBox_messagefile.Text = CurrentDirectory & "\Message.txt"
            End If
            MyForm2.Show()
            MyForm2.textBox_MailServer.Text = d.ReadLine()
            MyForm2.textBox_Username.Text = d.ReadLine()
            Try
                Dim testtry = MyDecryption(d.ReadLine())
                MyForm2.textBox_Password.Text = testtry
            Catch ex As Exception
                MyForm2.textBox_Password.Text = d.ReadLine()
            End Try
            'textBox_Password.Text = MyDecryption(d.ReadLine())
            MyForm2.PortBox.Text = d.ReadLine()
            TimeIntervalTextBox.Text = d.ReadLine()
            Try
                MyForm2.FacebookLoginEmailTextbox.Text = MyDecryption(d.ReadLine())
                If MyForm2.FacebookLoginEmailTextbox.Text = "InvalidPasscode$$$Corrupt" Then
                    MyForm2.FacebookLoginEmailTextbox.Text = "Enter Facebook Address"
                End If
            Catch ex As Exception
                MyForm2.FacebookLoginEmailTextbox.Text = "Enter Facebook Address"
            End Try
            Try
                MyForm2.FaceboolLoginPasswordTextbox.Text = MyDecryption(d.ReadLine())
                MyForm2.FaceboolLoginPasswordTextbox.PasswordChar = CType("*", Char)
                If MyForm2.FaceboolLoginPasswordTextbox.Text = "InvalidPasscode$$$Corrupt" Then
                    'MyForm2.FaceboolLoginPasswordTextbox.PasswordChar = Nothing
                    MyForm2.FaceboolLoginPasswordTextbox.Text = "Enter Facebook Password"
                End If
            Catch ex As Exception
                MyForm2.FacebookLoginEmailTextbox.Text = "Enter Facebook Password"
                'MyForm2.FaceboolLoginPasswordTextbox.PasswordChar = Nothing
            End Try
            If d.ReadLine = "1" Then
                CheckBox_ConfirmationEmail.CheckState = CheckState.Checked
            Else
                CheckBox_ConfirmationEmail.CheckState = CheckState.Unchecked
            End If
            If d.ReadLine = "1" Then
                EmailCombineCheckBox.CheckState = CheckState.Checked
            Else
                EmailCombineCheckBox.CheckState = CheckState.Unchecked
            End If
            If d.ReadLine = "1" Then
                MyForm2.EmailEncryptionCheckBox.CheckState = CheckState.Checked
            Else
                MyForm2.EmailEncryptionCheckBox.CheckState = CheckState.Unchecked
            End If
            MyForm2.EmailMasterListFilename.Text = d.ReadLine
            d.Close()
        End If
        ToolTip1.SetToolTip(TimeIntervalLabel, "This value sets how long EPE will wait until " & vbCrLf & _
                            "after an image appears in the monitored folder " & vbCrLf & _
                            "before beginning the email process. This value depends on the " & vbCrLf & _
                            "size of the file being emailed. The delay value is in seconds.")
        ToolTip1.SetToolTip(AutoModeLabel, "This feature will allow you to let EPE " & vbCrLf & _
                            "run in the background and email photos as they " & vbCrLf & _
                            "become available.")
        ToolTip1.SetToolTip(EmailCombineCheckBox, "By default, images to the same email address " & vbCrLf & _
                            "are combined into one email. Check this box to send the images individually. ")
        ToolTip1.SetToolTip(CheckBox_ConfirmationEmail, "Check this box if you would like an email also" & vbCrLf & _
                            " sent to your company's email address")
        ToolTip1.SetToolTip(HideButton, "Click this button to hide the Event Photo Emailer windows. " & vbCrLf & _
                            "It will continue to run in the background. An icon is created in your system tray " & vbCrLf & _
                            "that will allow you to right-click and toggle the window's visibility")
        ContextMenuStrip_ForNotificationIcon.Visible = False
        '        pause(5000)
        '        StatusBox.Text = "Initializing ... " & vbCrLf
        '        pause(5000)
        StatusBox.Text = "Ready. " & vbCrLf
        MyForm2.Hide()
    End Sub

    ''' <summary>
    ''' SaveAsDefault saves text fields
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SaveAsDefault(ByVal sender As Object, ByVal e As EventArgs) Handles Button_SaveAsDefault.Click
        Dim fs As New FileStream(DefaultFile, FileMode.Create, FileAccess.Write) 'Set to create so old file will be totally rewritten
        Dim s As New StreamWriter(fs)
        'creating a new StreamWriter and passing the filestream object fs as argument
        s.BaseStream.Seek(0, SeekOrigin.End)
        'the seek method is used to move the cursor to next position to avoid text being
        'overwritten
        's.WriteLine(ProgDir2.Text)
        s.WriteLine(textBox_SubjectLine.Text)
        s.WriteLine(Textbox_imagefolder.Text)
        s.WriteLine(textBox_messagefile.Text)
        s.WriteLine(MyForm2.textBox_MailServer.Text)
        s.WriteLine(MyForm2.textBox_Username.Text)
        s.WriteLine(MyEncryption(MyForm2.textBox_Password.Text))
        s.WriteLine(MyForm2.PortBox.Text)
        s.WriteLine(TimeIntervalTextBox.Text)
        s.WriteLine(MyEncryption(MyForm2.FacebookLoginEmailTextbox.Text))
        s.WriteLine(MyEncryption(MyForm2.FaceboolLoginPasswordTextbox.Text))
        If CheckBox_ConfirmationEmail.CheckState = CheckState.Checked Then
            s.WriteLine("1")
        Else
            s.WriteLine("0")
        End If
        If EmailCombineCheckBox.CheckState = CheckState.Checked Then
            s.WriteLine("1")
        Else
            s.WriteLine("0")
        End If
        If MyForm2.EmailEncryptionCheckBox.CheckState = CheckState.Checked Then
            s.WriteLine("1")
        Else
            s.WriteLine("0")
        End If
        s.WriteLine(MyForm2.EmailMasterListFilename.Text)
        s.Close()
        'closing the file
    End Sub

#Region "MainProgram"

    ''' <summary>
    '''RunGo() is called by the watch folder as well as when the send email button is pressed.
    '''RunGo() calls LetsGo() on a thread.
    '''RunGo() checks to see if thread is busy first. If so, <c>NewImagesAreReady = TRUE</c>. This is based on the possibility
    '''that the RunGo() event was raised as images were being added while emailing.
    '''The <c>BW_LetsGo.RunWorkerCompleted</c> subroutine will check the flag to decide if to rerun the emailer.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RunGo()
        FACEBOOKERRORONCE = True 'used so that if there is a Facebook error, the message box only appears once.
        If BW_LetsGo.IsBusy = False Then
            If SENDEMAILFINISHEDFLAGG = True Then
                BW_LetsGo.RunWorkerAsync()
                NewImagesAreReady = False
            End If
            'Else
            'NewImagesAreReady = True ' Possible that new images could have triggered RunGo. This is tested for after completion
        End If
    End Sub

    Public Sub EmailNewImages(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BW_LetsGo.RunWorkerCompleted
        If NewImagesAreReady = True Then
            RunGo()
            NewImagesAreReady = False
        End If
    End Sub

    Public Sub disbletextboxes(ByVal Decision As Boolean)
        'CheckForIllegalCrossThreadCalls = False
        Textbox_imagefolder.Enabled = Decision
        MyForm2.textBox_MailServer.Enabled = Decision
        textBox_messagefile.Enabled = Decision
        MyForm2.textBox_Password.Enabled = Decision
        textBox_SubjectLine.Enabled = Decision
        MyForm2.textBox_Username.Enabled = Decision
        'CheckForIllegalCrossThreadCalls = True
    End Sub

    Public Sub RunFromWatchfolder(ByVal sender As Object, ByVal e As EventArgs) Handles WatchFolder.Created
        'CheckForIllegalCrossThreadCalls = False
        'GoButton.PerformClick()
        RunGo()
        'CheckForIllegalCrossThreadCalls = True
        'GoButton.Visible = False
    End Sub

    ''' <summary>
    ''' SendEmail_AND_HandleControlsOnThread()
    ''' This is the main part of the program. When the send button is pressed, there are two loops to take
    ''' 1.) If a directory is being used, the ReadFromDirectory() is used. 
    ''' 2.) If the files are parsed, then SendParsedEmails().
    ''' The global event folder is set in this subroutine.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SendEmail_AND_HandleControlsOnThread(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BW_LetsGo.ProgressChanged
        SENDEMAILFINISHEDFLAGG = False
        disbletextboxes(False)
        StatusBox.Clear() ' It is important that the clear status box appear after setting crossthreading to False
        ' Otherwise an unhandled fault will occur.
        checkinternetconnection()
        pause(1000)
        CancelFlagg = "Run"
        If CancelFlagg <> "Cancel" Then
            StoppedButton.Visible = False
            SENDINGBUTTON.Visible = True
            StatusBox.Clear()
            Dim chkSMTP As MAILERRORHOOD
            chkSMTP.SMTPOK = False ' initialize variable
            chkSMTP = CheckEmailConnection()
            If chkSMTP.SMTPOK = False Then
                StatusBox.Clear()
                StatusBox.Text = chkSMTP.SMTPerrorMessage
                'Error message is displayed in the status box
                'The send email button will need to be pressed again.
                'do not run loop since no SMTP connection exist.
            Else ' Proceed forward
                ' ***** PRODUCE THE EVENT FOLDER
                StatusBox.Text = "SMTP server found... Processing ... " & vbCrLf
                pause(3000) ' introduce a 3 second pause to ensure that the SMTP check is complete
                Dim MyDate As Date = Now
                'Dim MyDateString As String = MyDate.Month & "_" & MyDate.Day & "_" & MyDate.Year & "_" & MyDate.Hour & "_" & MyDate.Minute & "_" & MyDate.Second
                Dim MyDateString As String = MyDate.Month & MyDate.Day & MyDate.Year & MyDate.Hour & MyDate.Minute & MyDate.Second
                ''''If AutoEmailFlagg = True Then
                ''''    EventFolder = Textbox_imagefolder.Text & "\Event_" & MyDate.Month & MyDate.Day & MyDate.Year
                ''''Else
                ''''    EventFolder = Textbox_imagefolder.Text & "\" & "Event_" & MyDateString
                ''''End If
                EventFolder = Textbox_imagefolder.Text & "\Event_" & MyDate.Year & "_" & MyDate.Month & "_" & MyDate.Day
                StatusFile = EventFolder & "\status.txt" ' Global Vector

                ' Before creating the EventFolder and starting to email, first check if ther are any images to email
                Dim str As New IO.DirectoryInfo(Textbox_imagefolder.Text)
                Dim listing As IO.FileInfo() = str.GetFiles("*.jpg")
                If listing.Length > 0 Then
                    If Directory.Exists(EventFolder) Then
                        'do nothing
                    Else
                        Directory.CreateDirectory(EventFolder)
                    End If
                    ' *************************************************
                    If CheckBox2_emailfilename.CheckState = CheckState.Checked Then ' Case for supplied list
                        SendEmailFromDirectory(Nothing, Nothing)
                    Else ' Case for which filenames are parsed to get email addresses and filenames
                        SendParsedEmails(Nothing, Nothing) ' called to do the cleanup work
                    End If
                Else
                    Display(StatusBox, "There are no images to email")
                End If
            End If
        End If
        disbletextboxes(True) ' Boxes are disabled during mailing to avoid inadvertant errors due to changing the boxes.
        SENDEMAILFINISHEDFLAGG = True
        'Me.Enabled = True
        'If new images were loaded as the program was sending email.. this will make sure there is at least another run.
        'Control.CheckForIllegalCrossThreadCalls = True

    End Sub

    Public Sub LetsGO(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BW_LetsGo.DoWork
        ' Since ReportProgress can handle UI objects, I moved the code to be handled by it.
        ' the value 1 is just a dummy value
        BW_LetsGo.ReportProgress(1)
    End Sub

    ''' <summary>
    ''' Check if SMTP connection is available
    ''' Fixed error due to port not being set within this subroutine
    ''' Dim SMTPOK As Boolean ' True if ok, and False if error
    ''' Control.CheckForIllegalCrossThreadCalls = False
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckEmailConnection() As MAILERRORHOOD
        Dim MailError As MAILERRORHOOD
        'Dim SmtpErrorCode As Integer
        MailError.SMTPOK = True
        MailError.SMTPerrorMessage = "No Error"
        If Len(MyForm2.PortBox.Text) <> 0 Then
            Code = seeIntegerParam(0, SEE_SMTP_PORT, Convert.ToInt32(MyForm2.PortBox.Text)) 'set port (note: Comcast uses 587
            Display(StatusBox, "Checking for SMTP (This may take a few seconds...)")
            'Code = seeIntegerParam(0, SEE_SMTP_PORT, 587) 'set port (note: Comcast uses 587
        End If
        ' set up log file
        'Code = seeStringParam(0, SEE_LOG_FILE, EventFolder & "\DEBUG_MAILER.LOG")
        'Code = seeStringParam(0, SEE_LOG_FILE, ProgDir2.Text + "\Logfile.log") ' Use for debugging
        Code = seeIntegerParam(0, SEE_ENABLE_ESMTP, 1)
        If MyForm2.EmailEncryptionCheckBox.CheckState = CheckState.Checked Then
            seeIntegerParam(0, SEE_AUTHENTICATE_PROTOCOL, AUTHENTICATE_CRAM)
        End If
        Code = seeStringParam(0, SEE_SET_USER, MyForm2.textBox_Username.Text + Chr(0))
        Code = seeStringParam(0, SEE_SET_SECRET, MyForm2.textBox_Password.Text + Chr(0))
        'Code = seeDebug(0, SEE_GET_SERVER_IP, NullString, 40)
        'Code = seeIntegerParam(0, SEE_MAX_RESPONSE_WAIT, 1)
        'chkemailconn = False
        'stmpthread()
        'While chkemailconn = False
        '    Display(StatusBox,"still working")
        ''End While
        ' ''' It looks like I cannot put seeSmtpConnect on a tread. When I tried, it was ignored.
        ' ''' I'm going to keep the support code (stmpthread(), runstmponthread, SubSMTPconnectHOOD())
        ' ''' just in case I figure it out later.
        ' ''' I still need a way to keep the box from freezing up while attmpting to verify the
        ' ''' SMTP connection
        ' ''' Maybe I could put streaming dots on a thread.
        'SmtpErrorCodeGlobal = 999
        ' The statusindicatorhoodonthread method almost worked. (Info from:
        ' http://www.vbforums.com/showthread.php?t=551803&highlight=thread+return
        ' However, I need seeSMTPconnect to return a value and I have not figured out how to do that yet.
        'StatusIndicatorHoodonthread(0, textBox_MailServer.Text, "<Test>", NullString) ' Trying to use a thread did not work
        'StatusIndicatorHood()
        'CheckSMTPtimerdots.Start() ' No success with time either
        'CheckSMTPtimerdots.Stop()
        'Display(StatusBox,"Checking The Connection ...... ")
        'SmtpErrorCode = seeCommand(0, "NOOP" + Chr(0))  'Try this commmand. Used to check connection.
        'AccessPOP3() ' Used just in case server requires one to check mail first before sending.
        SmtpErrorCodeGlobal = seeSmtpConnect(0, MyForm2.textBox_MailServer.Text, "<Test>", NullString)
        If SmtpErrorCodeGlobal < 0 Then
            Dim INTCHECK As String = checkinternetconnection()
            If INTCHECK = "2" Then
                MailError.SMTPerrorMessage = "Your internet connection is not active."
            ElseIf INTCHECK = "3" Then
                MailError.SMTPerrorMessage = "A Network Connection has not been detected."
            Else
                MailError.SMTPerrorMessage = "Error obtaining a SMTP connection. Check:" _
            & vbCrLf & "1.) That your server address is correct." _
            & vbCrLf & "2.) That your username and password are correct." _
            & vbCrLf & "3.) That your security software allows outgoing mail on port: " & MyForm2.PortBox.Text & "."
            End If
            CheckConnectionTimer.Enabled = False ' turn off the check to avoid a loop of checkconnection(). I don't know why this occurs yet.
            'TODO Check if in AutoMode before issuing the MsgBox
            If RunningInAutoMode = False Then
                MsgBox(MailError.SMTPerrorMessage)
                CancelFlagg = "Cancel"
                Display(StatusBox, "Error: Emailing has been stopped.")
                SENDINGBUTTON.Visible = False
                StoppedButton.Visible = True
            End If
            MailError.SMTPOK = False
            chkemailconn = False
        Else
            MailError.SMTPOK = True
            chkemailconn = True
        End If
        'Control.CheckForIllegalCrossThreadCalls = True
        Return MailError
    End Function

    ''' <summary>
    ''' SendEmailFromDirectory()
    ''' Sends emails based on information in the directory file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SendEmailFromDirectory(ByVal sender As Object, ByVal e As EventArgs) Handles BW_EmailerDirectory.DoWork
        Dim StatusFile As String = EventFolder & "\status.txt"
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
        StatusBox.Clear()
        StatusBox.Text = "Sending emails ... "
        Display(StatusBox, "")
        'End If
        'StatusBox.Clear()
        'Clear Contents (statusbox.clear() does not work as expected)
        'It writes the new data starting at the beginning but does not erase the contents already 
        'in the statusbox. The next set of lines writes blank likes over a lot of lines.

        If Not File.Exists(EmailFilenameList.Text) Then
            Display(StatusBox, "Error: Directory File not provided")
            Display(StatusBox, "Please provide the name of your directory file")
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
                        Display(StatusBox, email.ToCharArray & ErrorString)
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
            Display(StatusBox, "Finished..........")
            StoppedButton.Visible = True
            SENDINGBUTTON.Visible = False
            ProgressBar1.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' SendParsedEmails()
    ''' Sends emails with email address(es) encoded into the filename.
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
        Dim testspace_email() As String
        Dim jj As Integer
        Dim oldfilename As String
        Dim newfilename As String
        Dim filenameshort(0) As String
        Dim temp() As String
        Dim emailstring(0) As String ' An array used to parse the email for multiple emails using the split command
        Dim filenamestring(0) As String ' An array used to parse the filename for multiple files
        Dim emailshortstring(0) As String
        Dim filenameshortstring(0) As String
        Dim kk, kkk As Integer
        Dim str As New IO.DirectoryInfo(Textbox_imagefolder.Text)
        'Dim NoEmailFilename As IO.FileInfo() = str.GetFiles("$*.jpg") 'Image with no email will just start with $

        'If MonitorFolderCheckBox.CheckState = CheckState.Checked Then
        'pause(CType(DelayTextBox1.Text, Integer) * 1000)
        'System.Threading.Thread.Sleep(CType(DelayTextBox1.Text, Integer) * 1000) 'I believe the trigger occurs when file appears but not when finished.
        ' A delay is needed for the file to be created and ready to send. This value is dependent on the computer
        ' and the filesize of the image to be created. The default is 2 seconds. Later, I may include a form
        ' field that will allow this value to be entered.
        'End If

        'Delete all files starting with $
        'Code was added to allow uploading to Facebook. When this occurs, only the Facebook email address is used. For this reason,
        'it is not necessary to check for filenames missing email addresses. So the following code will make the check only if the Facebook
        'checkbox is not selected.
        'todo have code bypass parsing the email when no email exist (for cases when simply uploading to facebook)
        If FacebookOnlyCheckBox.CheckState = CheckState.Unchecked Then
            CheckForNonEmailedJPGFiles()
        End If

        'For Each fullstring In NoEmailFilename
        '    Dim InputString As String = "***[" & fullstring.Name & "$" & "] did not have an email address attached...Not Sent***"
        '    Display(StatusBox,InputString)
        '    My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
        '    Dim NoEmailString As String = EventFolder & "\" & "NoAttachedEmailAddress"
        '    If Not File.Exists(NoEmailString) Then
        '        Directory.CreateDirectory(NoEmailString)
        '    End If
        '    If File.Exists(NoEmailString & "\" & fullstring.Name) Then
        '        File.Delete(NoEmailString & "\" & fullstring.Name)
        '    End If
        '    File.Move(Textbox_imagefolder.Text & "\" & fullstring.Name, NoEmailString & "\" & fullstring.Name)
        'Next

        'Now get remaining files. Note, I need to make allowance for other files sneaking into the directory
        'Note, chances are slim that a file that sneaked in has a $ in its name. Therefore, that file will fail with temp < 2
        'and the subroutine will be halted.
        Dim listing As IO.FileInfo() = str.GetFiles("*.jpg") ' Currently, only .jpg files are emailed
        Dim NumOfFiles As Double = listing.Length
        ' Sort Listing First
        counter = 0
        Dim fullstringcounter As Integer = 0

        For Each fullstring In listing ' This loops parses the files and produces arrays for email() and filename()
            fullstringcounter += 1
            temp = Split(fullstring.Name, "$") 'temp(0):email temp(1):filename
            'MsgBox("Filename = " & fullstring.Name & "   FullstringCounter = " & fullstringcounter & "  temp(0): " & temp(0) & "  temp(1): " & temp(1))
            If temp.Length < 2 Then
                MsgBox("Error: Possible problems:" _
                                           & vbCrLf & "1.) You are trying to read from an email/filename" _
                                           & vbCrLf & "directory, and the checkbox was not checked" _
                                           & vbCrLf & "2.) The selected image folder contains images" _
                                           & vbCrLf & "not intended to be emailed. Please clear" _
                                           & vbCrLf & Textbox_imagefolder.Text _
                                           & vbCrLf & "of these images and start the send process again.")
                Display(StatusBox, "Process has been cancelled")
                Exit Sub
            Else

                'First copy image to the event folder truncating the email address(s)
                oldfilename = Textbox_imagefolder.Text & "\" & fullstring.Name
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

                ParseEmail = Split(temp(0), "!") ' Checks for more than one recipient
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
                        End If
                        emailarray(counter + jj) = ParseEmail(jj).ToString
                        filenameshort(counter + jj) = temp(1)
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
                    End If
                    'MsgBox("Filename = " & fullstring.Name & "   FullstringCounter = " & fullstringcounter & "  temp(0): " & temp(0) & "  temp(1): " & temp(1))
                    'MsgBox("Counter: " & counter & "  Emailarray: " & emailarray(counter) & " temp: " & temp(0) & "  " & temp(1))
                    emailarray(counter) = temp(0)
                    filenameshort(counter) = temp(1)
                    'filenamearray(counter) = EventFolder & "\" & temp(1) ' filenamearray gives the absolute path
                    'MsgBox("emailarray: " & emailarray(counter) & "  filenamearray: " & filenamearray(counter) & " filenameshort: " & filenameshort(counter))
                    counter += 1
                    'Debug.WriteLine("Counter: " & counter & "  Emailarray: " & emailarray(counter))
                    'MsgBox("Non Multiple Email: emailarray.Length = " & emailarray.Length)
                End If
            End If
        Next
        Array.Sort(emailarray, filenameshort)
        For counter = 0 To filenameshort.Length - 1
            filenamearray(counter) = EventFolder & "\" & filenameshort(counter)
        Next
        Combine(emailarray, filenamearray, emailstring, filenamestring)
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



                SENDEMAIL(emailstring(counter), filenamestring(counter), EventFolder, filenameshortstring(counter), CancelFlagg, SENDEMAILFLAGG)
                If SENDEMAILFLAGG = True Then ' Email was sent successfully
                    ' Find the corresponding file in the image folder and then delete it.
                    For Each fullstring In listing ' This loops parses the files and produces arrays for email() and filename()
                        Dim checkfilestring() As String
                        Dim checkemailstring() As String
                        Dim parseOriginalEmail() As String
                        temp = Split(fullstring.Name, "$") 'temp(0):email temp(1):filename
                        checkfilestring = Split(filenameshortstring(counter), ";")
                        checkemailstring = Split(emailstring(counter), ";")
                        parseOriginalEmail = Split(temp(0), "!")

                        For kk = 0 To checkfilestring.Length - 1
                            For kkk = 0 To checkemailstring.Length - 1
                                'MsgBox("checkfilestring: " & checkfilestring(kk) _
                                '       & vbCrLf & " temp(1): " & temp(1) _
                                '       & vbCrLf & " checkemailstring: " & checkemailstring(kkk) _
                                '    & vbCrLf & " temp(0): " & parseOriginalEmail(0))

                                If (checkfilestring(kk) = temp(1)) And (checkemailstring(kkk) = parseOriginalEmail(0)) Then
                                    'MsgBox("We have a match!")
                                    'MsgBox(EventFolder & "\" & fullstring.Name)
                                    File.Delete(Textbox_imagefolder.Text & "\" & fullstring.Name)
                                End If
                            Next
                        Next
                    Next
                End If
            End If
            If NumOfEmailees <> 0 Then
                ProgressBar1.Visible = True
                ProgressBar1.Value = 100 * CType(Math.Round(counter / NumOfEmailees), Integer)
            End If
        Next


        If CancelFlagg <> "Cancel" And RunningInAutoMode = True Then
            'StatusBox.Text = StatusBox.Text & "Finished....."
            Display(StatusBox, "Finished..........")
            StoppedButton.Visible = True
            SENDINGBUTTON.Visible = False
            ProgressBar1.Visible = False
        End If

        If RunningInAutoMode = True Then
            Display(StatusBox, "Waiting for more images....." & vbCrLf)
            StoppedButton.Text = "Standby"
            StoppedButton.Visible = True
            StoppedButton.BackColor = Color.Green
        End If
        'System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        'CancelFlagg = "Cancel"

    End Sub
#End Region

    ''' <summary>
    ''' HOODFileWatcherJPG()
    ''' This subroutine was added to add intuition to the code. Before this, watchfolder was being used and I experienced unexplained behaviour. For one,
    ''' I kept getting threading errors.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>So far, it olnly looks for .jpg files.</remarks>
    Public Sub HOODFileWatcherJPG(ByVal sender As Object, ByVal e As EventArgs) Handles HoodWatchFolderOnTimer.Tick
        ' this file sets a timer that will monitor a given folder for jpg files at the given interval
        Dim str As New IO.DirectoryInfo(Textbox_imagefolder.Text)
        Dim listing As IO.FileInfo() = str.GetFiles("*.jpg")
        If listing.Length > 0 Then
            RunGo()
        End If
    End Sub

    Public Function PostPhotoOntoFacebook(ByVal IMAGESTRING As String, ByVal FACEBOOKALBUM As String, ByVal FACEBOOKCAPTION As String) As Boolean
        'Will need to 1st parse IMAGESTRING
        Dim FacebookUploadSuccessfull As Boolean = False
        Dim imagenames() As String
        Dim counter As Integer = 0
        Dim imageUse As String
        Dim MyWebBrowser As New WebBrowser
        imagenames = Split(IMAGESTRING, ";")
        FACEBOOKERROR = False
        For counter = 0 To imagenames.Length - 1
            imageUse = imagenames(counter)
            WaitForFileAvailibility(imageUse, 10000) 'wait 10 seconds to ensure that file is ready
            Dim B As System.Drawing.Bitmap = New System.Drawing.Bitmap(imageUse)


            If IsNothing(CustomerAPI) Then
                Try
                    Display(StatusBox, "Processing Facebook ...")
                    FacebookCustomerInfo = GetAPI(MyForm2.FacebookLoginEmailTextbox.Text, MyForm2.FaceboolLoginPasswordTextbox.Text, checktimerOK, MyWebBrowser)
                Catch ex As Exception
                    If FACEBOOKERRORONCE = True Then
                        MsgBox("There was a problem uploading to Facebook. Please check your internet connection and/or Facebook settings.")
                        FACEBOOKERRORONCE = False
                        FACEBOOKERROR = True
                    End If
                End Try
            End If


            Try
                CustomerAPI = FacebookCustomerInfo.MYAPIinfo
                'Dim UserID As Integer = CType(CustomerAPI.UserID, Integer)
                'Dim MyAlbums = CustomerAPI.GetAlbums() ' gets list of albums of current user.

                Dim ErrorMessage As String = PublishPhotoHOOD(B, FACEBOOKCAPTION, FacebookCustomerInfo)
                'CustomerAPI.PublishPhoto(B, FACEBOOKCAPTION)
                While B IsNot Nothing
                    B.Dispose()
                    B = Nothing
                End While
                FacebookUploadSuccessfull = True
            Catch ex As Exception
                If FACEBOOKERRORONCE = True Then
                    MsgBox("There was a problem uploading to Facebook. Please check your internet connection and/or Facebook settings.")
                    FACEBOOKERRORONCE = False
                    FACEBOOKERROR = True
                Else
                    'do nothing
                End If
            End Try
        Next
        Return FacebookUploadSuccessfull
    End Function


    Public Sub Combine(ByRef emailarray() As String, ByRef filenamearray() As String, ByRef emailstring() As String, ByRef filenamestring() As String)
        ' This subroutine is used to combine the images of like emails into a usable string that the 
        ' emailing program can use.
        ' On Oct 29, 2010, the option was added to ignore the combine.
        If EmailCombineCheckBox.CheckState = CheckState.Checked Then
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

    Public Sub SENDEMAIL(ByVal email As String, ByVal filenamestring As String, ByVal EventFolder As String, ByVal filenameshort As String, ByRef GOFLAGG As String, ByRef SENDEMAILFLAGG As Boolean)
        Dim StatusFile As String = EventFolder & "\status.txt"
        Dim DirectoryFile As String = EventFolder & "\directory.csv"
        Dim ErrorFile As String = EventFolder & "\errors.txt"
        Dim emailuse As String
        SENDEMAILFLAGG = False
        Dim MessageFlagg As Boolean = False
        If CancelFlagg <> "Cancel" Then

            If FacebookOnlyCheckBox.CheckState = CheckState.Checked Or EmailAndFacebook.CheckState = CheckState.Checked Then

                Dim PostOK As Boolean = PostPhotoOntoFacebook(filenamestring, FacebookAlbumName.Text, FacebookCaptionTextBox1.Text)
                If PostOK = True Then
                    If EmailAndFacebook.CheckState = CheckState.Unchecked Then
                        ' Use same code as for a successfull email send
                        SENDEMAILFLAGG = True
                        Dim InputString As String
                        InputString = "[" & filenameshort & "]" & " was successfully sent to FACEBOOK"
                        Display(StatusBox, InputString)
                        My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
                    End If
                Else

                    Dim InputString As String
                    InputString = "There was a problem sending [" & filenameshort & "] to FACEBOOK. This is either a connection issue or authorization issue"
                    Display(StatusBox, InputString)
                    My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
                End If
            End If

            If EmailAndFacebook.CheckState = CheckState.Checked Or EmailOnlyCheckbox.CheckState = CheckState.Checked Then
                'check that SMTP server name has been specified
                ' ************************* MAKE CHECKS ON INPUT DATA *************************
                If Len(MyForm2.textBox_MailServer.Text) = 0 Then
                    Display(StatusBox, "Missing SMTP server name.")
                    Exit Sub
                End If

                'check Email From

                If Len(CompanyEmail) = 0 Then
                    Display(StatusBox, "Missing 'Email From'")
                    Exit Sub
                End If

                ' add brackets if needed

                If InStr(CompanyEmail, "<") = 0 Then
                    CompanyEmail = "<" + CompanyEmail
                End If
                If InStr(CompanyEmail, ">") = 0 Then
                    CompanyEmail = CompanyEmail + ">"
                End If

                'check Email To
                If FacebookOnlyCheckBox.CheckState = CheckState.Checked Then
                    emailuse = "<" & MyForm2.FacebookLoginEmailTextbox.Text & ">"
                Else
                    emailuse = email
                End If

                'Will not produce a result when the folder is being monitored. I noticed that I would get
                'Some phantom files that I could not put a finger on. This is just a temparary fix. I'm thinking
                'That the change in the event folder is what is triggering the phantom file even though
                'the Filter is set to only look at *.jpg
                If Len(emailuse) = 0 Then
                    'Display(StatusBox,"Missing 'Email To' in " & filenamestring)
                    Exit Sub 'skip
                End If

                ' add brackets if needed

                If InStr(emailuse, "<") = 0 Then
                    emailuse = "<" + emailuse
                End If
                If InStr(emailuse, ">") = 0 Then
                    emailuse = emailuse + ">"
                End If

                'check Save Path

                If Len(textBox_SubjectLine.Text) = 0 Then
                    Display(StatusBox, "Missing Subject Line.")
                    Exit Sub
                End If

                'connect to server
                'The following code uses a username and password
                Code = seeIntegerParam(0, SEE_ENABLE_ESMTP, 1)
                If MyForm2.EmailEncryptionCheckBox.CheckState = CheckState.Checked Then
                    seeIntegerParam(0, SEE_AUTHENTICATE_PROTOCOL, AUTHENTICATE_CRAM)
                End If
                ' set up log file
                'Code = seeStringParam(0, SEE_LOG_FILE, EventFolder & "\DEBUG_MAILER.LOG")



                'If waitSMTPCheckBox.CheckState = CheckState.Checked Then
                ' Code = seeIntegerParam(0, SEE_CONNECT_WAIT, 20000) ' maximum time allowed to complete a connection to the email server.
                ' Code = seeIntegerParam(0, SEE_MAX_RESPONSE_WAIT, 10000) 'time after which a "timeout" error occurs if the server has not responded.
                'End If
                'Code = seeIntegerParam(0, SEE_SLEEP_TIME, 500) ' the time SEE sleeps when waiting on a Winsock.
                Code = seeIntegerParam(0, SEE_ENABLE_IMAGE, 1) ' Special processing when dealing with images to allow email program to view photos
                If Len(MyForm2.PortBox.Text) <> 0 Then
                    Code = seeIntegerParam(0, SEE_SMTP_PORT, Convert.ToInt32(MyForm2.PortBox.Text)) 'set port (note: Comcast uses 587
                    'Code = seeIntegerParam(0, SEE_SMTP_PORT, 587) 'set port (note: Comcast uses 587
                End If

                If Code < 0 Then
                    ShowErrorSendingFile(Code, "", "", StatusFile, ErrorFile)
                End If
                Code = seeStringParam(0, SEE_SET_SECRET, MyForm2.textBox_Password.Text + Chr(0))
                If Code < 0 Then
                    ShowErrorSendingFile(Code, "", "", StatusFile, ErrorFile)
                End If
                Code = seeStringParam(0, SEE_SET_USER, MyForm2.textBox_Username.Text + Chr(0))
                If Code < 0 Then
                    ShowErrorSendingFile(Code, "", "", StatusFile, ErrorFile)
                End If
                'Display(StatusBox,"Connecting to SMTP server: " + textBox_MailServer.Text)


                Code = seeDebug(0, SEE_GET_SERVER_IP, NullString, 40)
                If Code < 0 Then
                    ShowErrorSendingFile(Code, "", "", StatusFile, ErrorFile)
                End If
                ' Note: the @ symbol is used to tell the emailer program to used the contents of the message file
                'MsgBox("Email: " & email & " Filename: " & filenamestring)
                Dim SmtpErrorCode As Integer
                Dim tempfile As String = ""
                Dim APPENDEDMESSAGE As String = ""
                SmtpErrorCode = seeSmtpConnect(0, MyForm2.textBox_MailServer.Text, UserCompanyName, NullString)
                Dim SendEmailCode As Integer
                pause(2000) ' May be required for output from seeSmtpConnect. If too fast, the next line
                'may be analyzed and SmtpErrorCode may have an arbitrary value.
                If SmtpErrorCode < 0 Then
                    Dim SMTPerrorMessage As String
                    Dim INTCHECK As String = checkinternetconnection()
                    If INTCHECK = "2" Then
                        SMTPerrorMessage = "Your internet connection is not active."
                    ElseIf INTCHECK = "3" Then
                        SMTPerrorMessage = "No Network Connection Found"
                    Else
                        SMTPerrorMessage = "Error obtaining a SMTP connection. Check:" _
                    & vbCrLf & "1.) That your server address is correct." _
                    & vbCrLf & "2.) That your username and password are correct." _
                    & vbCrLf & "3.) That your security software allows outgoing mail on port: " & MyForm2.PortBox.Text & "."
                    End If
                    CheckConnectionTimer.Enabled = False ' turn off the check to avoid a loop of checkconnection(). I don't know why this occurs yet.
                    If RunningInAutoMode = True Then
                        MsgBox(SMTPerrorMessage)
                        CancelFlagg = "Cancel"
                        Display(StatusBox, "Error: Emailing has been stopped.")
                    End If
                    SENDINGBUTTON.Visible = False
                    StoppedButton.Visible = True
                    Exit Sub
                Else
                    ' Check if message file exists
                    If Not File.Exists(textBox_messagefile.Text) Then
                        MsgBox("Please use a valid Message text file and Re-try.")
                        CancelFlagg = "Cancel"
                        MessageFlagg = True 'used to bypass email error message but still keep the flow
                    Else

                        If BuildType = True Then
                            SendEmailCode = seeSendEmail(0, emailuse, NullString, NullString, textBox_SubjectLine.Text, APPENDEDMESSAGE, filenamestring)
                            'SendEmailCode = seeSendEmail(0, email, NullString, NullString, textBox_SubjectLine.Text, "@" & tempfile, filenamestring)
                            'File.Delete(tempfile)
                        Else
                            SendEmailCode = seeSendEmail(0, emailuse, NullString, NullString, textBox_SubjectLine.Text, "@" & textBox_messagefile.Text, filenamestring)
                        End If

                        ' Send Confirmation Email
                        If CheckBox_ConfirmationEmail.CheckState = CheckState.Checked Then
                            SendEmailCode = seeSendEmail(0, CompanyEmail, NullString, NullString, "Confirmation: " & textBox_SubjectLine.Text, "@" & textBox_messagefile.Text, filenamestring)
                        End If
                    End If 'MsgBox("seeSendEmail Code: " & Code & "  Email: " & email)

                    If SendEmailCode < 0 Or MessageFlagg = True Then 'Code corresponding to seeSendEmail()
                        'If SendEmailCode = -49 Then
                        'Dim InputString As String = "[" & filenameshort & "]" & " has an invalid address. Please fix."
                        'Display(StatusBox,InputString)
                        'My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
                        'Skip (and keep skipping every time until I figure out how to delete it)
                        'Else
                        SENDEMAILFLAGG = False
                        'error attempting to send email
                        'Call Display(StatusBox,"***Error sending [" & filenameshort & "]: Code: " + Str(Code) & " ***" & Chr(10) & Chr(13))
                        If MessageFlagg = False Then
                            ShowErrorSendingFile(SendEmailCode, "", "", StatusFile, ErrorFile)
                            Display(StatusBox, "Also, check if your security software allows outgoing mail on port: " & MyForm2.PortBox.Text)
                            Display(StatusBox, "") ' ads a CR+LF
                            CancelFlagg = "Cancel"
                        Else
                            Dim ee As EventArgs = Nothing
                            StartStopAutoMode(StopAutoButton, ee) ' simulate stop
                            'do nothing and allow the process to bypass
                        End If
                        'End If
                    Else
                        SENDEMAILFLAGG = True
                        Dim InputString As String
                        If FacebookOnlyCheckBox.CheckState = CheckState.Checked Then
                            InputString = "[" & filenameshort & "]" & " was successfully sent to FACEBOOK"
                        Else
                            InputString = "[" & filenameshort & "]" & " was successfully sent to " & emailuse
                        End If

                        Display(StatusBox, InputString)
                        My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
                        My.Computer.FileSystem.WriteAllText(DirectoryFile, filenameshort & "," & emailuse & Chr(13), True)
                        If Not IsNothing(MyForm2.EmailMasterListFilename.Text) Then
                            Try
                                My.Computer.FileSystem.WriteAllText(MyForm2.EmailMasterListFilename.Text, textBox_SubjectLine.Text & "," & filenameshort & "," & emailuse & Chr(13), True)
                            Catch ex As Exception
                                ' do nothing
                            End Try
                        End If
                        'Code = seeClose(0)
                        'Code = seeRelease()
                    End If
                    Code = seeClose(0)
                    If SmtpErrorCode > 0 Then
                        Code = seeRelease()
                    End If
                End If
            End If
        End If
        'Code = seeRelease()
    End Sub

    ' **************************************  SUPPORT SUBROUTINES *****************
    Public Sub WatchFolderWithSetFrequency(ByVal durationhood As Integer)
        ' This subroutine is not used yet. The idea is that I would like to put the filesystemwatcher method
        ' into a subroutine that allows me to enable/disable at a set frequency.
        ' integer is in seconds. Will use clock
        Dim MyDate As Date = Now
        Dim timehood = MyDate.Second
    End Sub

    Public Sub StartStopAutoMode(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartAutoButton.Click, StopAutoButton.Click
        'This subfunction watches a folder and looks for some activity. For this application, it looks for the
        'create activity. When this occurs it runs the LetsGo() subroutine. Note: there is a problem when
        'trying to access the statusbox and other like controls via this method. It appears that those controls
        'are only accessible when the button is actually clicked. Othersie you get an illegal Cross-Thread error.
        'This was bypassed by using System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False/True switch.
        'Dim WatchFolder As New System.IO.FileSystemWatcher()
        'Needs to first check that the folder exists'

        If Not Directory.Exists(Textbox_imagefolder.Text) Then
            MsgBox(Textbox_imagefolder.Text & " Does not exist. You many need to change the path in your " & Textbox_imagefolder.Text & "\bin\default.txt file")
        Else
            If sender.Equals(StartAutoButton) Then
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
                StatusBox.Clear()
                Display(StatusBox, "Currently monitoring " & vbCrLf & Textbox_imagefolder.Text & vbCrLf)
                'Display(StatusBox,"Your image directory is being monitored.")
                Display(StatusBox, "Emails will be automatically sent")
                Display(StatusBox, "Waiting....")
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
                StatusBox.Clear()
                Display(StatusBox, "Automatic mail delivery has been disabled. " & _
                        "Use the green 'SEND EMAILS' button below to start the process manually.")

                'MsgBox("EPE Emailer is not monitoring your image directory. Emails will need to be manually sent")
                GoButton.Visible = True
            End If
        End If
    End Sub



    'Public Sub MonitorFolderCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonitorFolderCheckBox.CheckedChanged, StartAutoButton.Click, StopAutoButton.Click
    '    'This subfunction watches a folder and looks for some activity. For this application, it looks for the
    '    'create activity. When this occurs it runs the LetsGo() subroutine. Note: there is a problem when
    '    'trying to access the statusbox and other like controls via this method. It appears that those controls
    '    'are only accessible when the button is actually clicked. Othersie you get an illegal Cross-Thread error.
    '    'This was bypassed by using System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False/True switch.
    '    'Dim WatchFolder As New System.IO.FileSystemWatcher()
    '    'Needs to first check that the folder exists'
    '    If Directory.Exists(Textbox_imagefolder.Text) Then
    '        ''''''Try
    '        ''''''    WatchFolder.Path = Textbox_imagefolder.Text
    '        ''''''Catch ex As Exception
    '        ''''''    'FolderBrowserDialog_image_location.ShowDialog()
    '        ''''''    'WatchFolder.Path = FolderBrowserDialog_image_location.SelectedPath
    '        ''''''    'do nothing
    '        ''''''End Try

    '        '''''''WatchFolder.NotifyFilter = NotifyFilters.CreationTime
    '        ''''''WatchFolder.Filter = "*.jpg" 'May use if other files are created in the same folder.
    '        ''''''' Add event handlers
    '        Dim timeinterval = CType(TimeIntervalTextBox.Text, Integer) * 1000
    '        If timeinterval < 1000 Then
    '            timeinterval = 1000
    '            TimeIntervalTextBox.Text = "1"
    '        End If
    '        HoodWatchFolderOnTimer.Interval = timeinterval
    '        If sender.Equals(StartAutoButton) Then
    '            MonitorFolderCheckBox.CheckState = CheckState.Checked
    '            adrianhood()
    '            HoodWatchFolderOnTimer.Start()
    '            If MonitorFolderCheckBox.CheckState = CheckState.Checked Then
    '                CancelFlagg = "run"
    '                'GoFlagg = True
    '                'MsgBox("GoFlagg = " & GoFlagg.ToString)
    '                ' The wait command will give it time to finish.
    '                AutoEmailFlagg = True
    '                'StatusBox.Text = "Your image directory is being monitored." & Chr(13) & Chr(10) & "Emails will be automatically sent" & Chr(10) & Chr(13) & "Waiting ..." & vbCrLf
    '                StatusBox.Clear()
    '                Display(StatusBox, "Currently monitoring " & vbCrLf & Textbox_imagefolder.Text & vbCrLf)
    '                'Display(StatusBox,"Your image directory is being monitored.")
    '                Display(StatusBox, "Emails will be automatically sent")
    '                Display(StatusBox, "Waiting....")
    '                'MsgBox("EPE Emailer will now monitor your image directory. Emails will be automatically sent")
    '                'WatchFolder.EnableRaisingEvents = True
    '                GoButton.Visible = False
    '                DelayLabel1.Enabled = True
    '                DelayTextBox1.Enabled = True
    '                StoppedButton.Enabled = True
    '                StoppedButton.Text = "Standby"
    '                StoppedButton.BackColor = Color.Green
    '                Label9_EmailListDescription.Enabled = False
    '                EmailFilenameList.Enabled = False
    '                Button3_browse_email_filename.Enabled = False
    '                ignoreJPG.Enabled = False
    '                CheckBox2_emailfilename.Enabled = False
    '            Else
    '                StoppedButton.Enabled = True
    '                StoppedButton.Text = "Stopped"
    '                StoppedButton.BackColor = Color.Red
    '                DelayLabel1.Enabled = False
    '                DelayTextBox1.Enabled = False
    '                AutoEmailFlagg = True
    '                Label9_EmailListDescription.Enabled = True
    '                EmailFilenameList.Enabled = True
    '                Button3_browse_email_filename.Enabled = True
    '                ignoreJPG.Enabled = True
    '                CheckBox2_emailfilename.Enabled = True
    '                'WatchFolder.EnableRaisingEvents = False
    '                HoodWatchFolderOnTimer.Stop()
    '                'StatusBox.Text = "Your image directory is NOT being monitored. Emails will NOT be automatically sent" & Chr(10) & Chr(13)
    '                StatusBox.Clear()
    '                Display(StatusBox, "Automatic mail delivery has been disabled. " & _
    '                        "Use the green 'SEND EMAILS' button below to start the process manually.")

    '                'MsgBox("EPE Emailer is not monitoring your image directory. Emails will need to be manually sent")
    '                GoButton.Visible = True
    '            End If
    '        End If
    '    Else
    '        MsgBox(Textbox_imagefolder.Text & " Does not exist. You many need to change the path in your ..\bin\default.txt file")
    '    End If
    'End Sub

    Public Sub Display(ByVal STATUSBOX As System.Windows.Forms.TextBox, ByVal X As String)
        'Chr(10) is linefeed and Chr(13) is Carriage Return.
        STATUSBOX.AppendText(X & vbCrLf)
    End Sub

    Public Sub CheckFileExistence_And_Spaces(ByVal PATH As String, ByVal FILENAMETOCHECK As String, ByRef CheckFileFlagg As String)
        Dim testspace_filename() As String
        Dim FN = PATH & FILENAMETOCHECK
        'MsgBox("Checking " & FN & "  file.exist = " & File.Exists(FN))
        If Not File.Exists(FN) Then 'check for existance
            CheckFileFlagg = "False"
            Display(StatusBox, FILENAMETOCHECK & " Does not exist, please check the spelling or make sure that the box" & _
                    " is checked to supress the .jpg extension")
            Display(StatusBox, "This file will not be sent")
            testspace_filename = Split(FILENAMETOCHECK, " ")
            If testspace_filename.Length > 1 Then
                Display(StatusBox, FILENAMETOCHECK & " cannot contain spaces." _
                & " Please check your message filename, CSV filename, image filenames and email addresses." _
                & FILENAMETOCHECK & " was not sent")
            End If
        Else
            CheckFileFlagg = "True"
        End If
    End Sub

    Public Sub ShowErrorSendingFile(ByVal ErrCode As Integer, ByVal Filename As String, ByVal emailaddress As String, ByVal STATFILE As String, ByVal ERRFILE As String)
        ' This is used to display the error in the Statusbox, in the status.txt file and also compiled into an errors.txt file
        Dim Length As Integer
        Dim Buffer As String
        Dim ErrorString As String
        Buffer = Space(80) ' Changed to 60 by Adrian. Gets error strings from error.txt longest is 50
        Length = seeErrorText(0, ErrCode, Buffer, Buffer.Length)
        'Call Display(Microsoft.VisualBasic.Left(Buffer, Buffer.Length))
        If Filename = "" Then ' case for Connection error 
            ErrorString = "Emailing has been aborted. Please check your mailserver parameters" & vbCrLf & _
                            "Code: " & ErrCode & " " & Buffer
            MsgBox(ErrorString)
        Else
            ErrorString = "Error sending [" & Filename & "] to " & emailaddress & vbCrLf & _
                            "Code: " & ErrCode & " " & Buffer
        End If
        Display(StatusBox, ErrorString)
        'Call Display(Microsoft.VisualBasic.Left(Buffer, Buffer.Length))
        My.Computer.FileSystem.WriteAllText(STATFILE, ErrorString & Chr(13), True)
        My.Computer.FileSystem.WriteAllText(ERRFILE, ErrorString & Chr(13), True)
    End Sub

    Public Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2_emailfilename.CheckedChanged
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then EmailFilenameList.Enabled = True Else EmailFilenameList.Enabled = False
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then ignoreJPG.Enabled = True Else ignoreJPG.Enabled = False
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then Button3_browse_email_filename.Enabled = True Else Button3_browse_email_filename.Enabled = False
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then Label9_EmailListDescription.Enabled = True Else Label9_EmailListDescription.Enabled = False
    End Sub



    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1_browse_image_location.Click
        FolderBrowserDialog_image_location.ShowDialog()
        Textbox_imagefolder.Text = FolderBrowserDialog_image_location.SelectedPath
    End Sub

    Public Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2_browse_message_file.Click
        OpenFileDialog1_message_location.ShowDialog()
        textBox_messagefile.Text = OpenFileDialog1_message_location.FileName
    End Sub

    Public Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3_browse_email_filename.Click
        OpenFileDialog2_emaillist.ShowDialog()
        EmailFilenameList.Text = OpenFileDialog2_emaillist.FileName
    End Sub


    Public Sub CancelButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton1.Click
        CancelFlagg = "Cancel"
    End Sub

#Region "Form Exiting and hiding Stuff"
    Public Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If IsProcessRunning(WinZShortcut) = True Then
            Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName(WinZShortcut)
            For Each p As Process In pProcess
                p.Kill()
            Next
        End If
        NotifyIcon1.Visible = False
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

    Public Sub HideButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideButton.Click
        HideEPEForm()
    End Sub
#End Region


#Region "Encryption"
    Public Function MyEncryption(ByVal PassCode As String) As String
        Dim sym As New Encryption.Symmetric(Encryption.Symmetric.Provider.Rijndael)
        Dim key As New Encryption.Data("OBAMA")
        Dim encryptedData As Encryption.Data
        encryptedData = sym.Encrypt(New Encryption.Data(PassCode), key)
        Dim base64EncryptedString As String = encryptedData.ToBase64
        Return encryptedData.ToBase64
    End Function

    Public Function MyDecryption(ByVal PassCode As String) As String
        Dim sym As New Encryption.Symmetric(Encryption.Symmetric.Provider.Rijndael)
        Dim key As New Encryption.Data("OBAMA")
        Dim encryptedData As New Encryption.Data
        Dim decryptedData As Encryption.Data
        Try
            encryptedData.Base64 = PassCode
            decryptedData = sym.Decrypt(encryptedData, key)
        Catch ex As Exception
            PassCode = MyEncryption("InvalidPasscode$$$Corrupt")
            encryptedData.Base64 = PassCode
            decryptedData = sym.Decrypt(encryptedData, key)
        End Try
        Return decryptedData.ToString
    End Function
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
                Display(StatusBox, InputString)
                My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
                Dim NoEmailString As String = EventFolder & "\" & "NoAttachedEmailAddress"
                If Not File.Exists(NoEmailString) Then
                    Directory.CreateDirectory(NoEmailString)
                End If
                If File.Exists(NoEmailString & "\" & temp5.Name) Then
                    File.Delete(NoEmailString & "\" & temp5.Name)
                End If
                File.Move(Textbox_imagefolder.Text & "\" & temp5.Name, NoEmailString & "\" & temp5.Name)
            End If
        Next
    End Sub



    Public Sub OpenImageFolderSub(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenImageFolderButton.Click
        'Process.Start("explorer.exe", Textbox_imagefolder.Text)
    End Sub


    Public Function checkinternetconnection() As String
        Dim NETFOUND As String
        If CHECKCONNECTIONYESNO = True Or InitialConnectionCheck = True Then
            Try
                If My.Computer.Network.IsAvailable Then
                    If My.Computer.Network.Ping(SiteToPing) Then ' this is preferred since it checks internet connectin
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
                ConnectionStatusResultLabel.Text = "Network status is not available"
                NETFOUND = "2"
            End Try
        Else
            ConnectionStatusResultLabel.Text = "Not Checking Internet Connections"
            NETFOUND = "1"
        End If
        Return NETFOUND
        InitialConnectionCheck = False
    End Function


    Public Function AppendText(ByVal Origfile As String, ByVal message As String) As String
        Dim newname As String = ProgDir2.Text & "\bin\e1t11906.dat"
        File.Copy(Origfile, newname, True)
        Dim w As StreamWriter
        w = File.AppendText(newname)
        w.Write(message)
        w.Close()
        Return newname
    End Function

#Region "Internet Connection Checks"
    Public Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckConnectionTimer.Tick
        If checktimerOK = True Then
            checkinternetconnection()
        End If
    End Sub
#End Region

    Public Sub FacebookCheckBoxChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FacebookOnlyCheckBox.CheckedChanged, EmailOnlyCheckbox.CheckedChanged, EmailAndFacebook.CheckedChanged
        If sender.Equals(FacebookOnlyCheckBox) Then
            If FacebookOnlyCheckBox.CheckState = CheckState.Checked Then
                EmailOnlyCheckbox.CheckState = CheckState.Unchecked
                EmailAndFacebook.CheckState = CheckState.Unchecked
                'FacebookAlbumName.Enabled = True
                'FacebookCaptionTextBox1.Enabled = True
            End If
        End If

        If sender.Equals(EmailOnlyCheckbox) Then
            If EmailOnlyCheckbox.CheckState = CheckState.Checked Then
                FacebookOnlyCheckBox.CheckState = CheckState.Unchecked
                EmailAndFacebook.CheckState = CheckState.Unchecked
                'FacebookAlbumName.Enabled = False
                'FacebookCaptionTextBox1.Enabled = False
            End If
        End If

        If sender.Equals(EmailAndFacebook) Then
            If EmailAndFacebook.CheckState = CheckState.Checked Then
                EmailOnlyCheckbox.CheckState = CheckState.Unchecked
                FacebookOnlyCheckBox.CheckState = CheckState.Unchecked
                FacebookAlbumName.Enabled = True
                FacebookCaptionTextBox1.Enabled = True
            End If
        End If

        ' At least one has to be checked (set email only as default)
        If FacebookOnlyCheckBox.CheckState = CheckState.Unchecked And EmailOnlyCheckbox.CheckState = CheckState.Unchecked And EmailAndFacebook.CheckState = CheckState.Unchecked Then
            EmailOnlyCheckbox.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub ConfigureEmailButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigureEmailButton.Click
        MyForm2.Show()
        Me.CenterToScreen()
    End Sub

    Private Sub AboutUs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUsButton.Click
        MsgBox("Adrian Hood Engineering Solutions" & vbCrLf & _
               "301-437-1186" & vbCrLf & _
               "adrian@hoodandson.com")
    End Sub

    Public Function GetAPI(ByVal email As String, ByVal password As String, ByRef CHECKTIMEROK As Boolean, ByVal MyWebBrowser As WebBrowser) As HoodFacebookInfo
        'GraphApi.Api()
        ' Adrian ID:        https://graph.gacebook.com/601201034
        ' Hood and Sons ID: https://graph.facebook.com/152049444821811
        ' App Name:	        Event Photo Emailer
        ' App URL:	        www.hoodandson.com/EPE/
        ' App ID:	        197403413634224
        ' App Secret:	    47219a746539dd80c785138e4f3bfcfd

        ' Get Access Token
        ' No need to get UserID..its returned with MyAPI
        ' I do need to get Managed Account ID.

        'WebBrowser2.Navigate("http://www.facebook.com/search/?o=2048&q=" & email)

        'Dim AdrianID = "601201034"
        'Dim HoodAndSonManagedAccountID = "152049444821811"
        Dim ReturnData As HoodFacebookInfo
        Dim AppID As String = "197403413634224" ' Event Photo Emailer App ID
        'Dim AppSecret As String = "47219a746539dd80c785138e4f3bfcfd"
        'Dim WindowLocationString As String = "https://www.facebook.com/connect/login_success.html"
        'Dim URL As String = "https://www.facebook.com/dialog/oauth?client_id=" & _
        'AppID(+"&redirect_uri=" + WindowLocationString +
        '"&response_type=token")
        Dim MyAppString2 = "https://www.facebook.com/dialog/oauth?client_id=" & AppID & _
                            "&redirect_uri=https://www.facebook.com/connect/login_success.html" & _
                            "&scope=publish_stream,offline_access,user_photos&response_type=token" 'offline_access eliminates need to keep loggin in
        ' Try and enter information in webbrowser by hand
        ' System.Diagnostics.Process.Start("iexplore" & MyAppString2)
        'MyWebBrowser.Show()
        MyWebBrowser.Navigate(MyAppString2)
        'Process.Start(MyAppString2)
        CHECKTIMEROK = False
        WebWait(MyWebBrowser, 15)
        ' Part 2: Automatically input username and password
        Dim theElementCollection As HtmlElementCollection = MyWebBrowser.Document.GetElementsByTagName("input")
        For Each curElement As HtmlElement In theElementCollection
            Dim controlName As String = curElement.GetAttribute("name").ToString

            If controlName = "email" Then
                curElement.SetAttribute("Value", email)
            ElseIf controlName = "pass" Then
                curElement.SetAttribute("Value", password)
            End If
        Next

        ' Part 3: Automatically click the Login button
        Dim theWElementCollection As HtmlElementCollection = MyWebBrowser.Document.GetElementsByTagName("input")
        For Each curElement As HtmlElement In theWElementCollection
            If curElement.GetAttribute("value").Equals("Login") Then
                curElement.InvokeMember("click")
                ' javascript has a click method for we need to invoke on the current submit button element.
            End If
        Next
        WebWait(MyWebBrowser, 15)
        Dim theWElementCollection2 As HtmlElementCollection = MyWebBrowser.Document.GetElementsByTagName("input")
        For Each curElement As HtmlElement In theWElementCollection2
            If curElement.GetAttribute("value").Equals("Allow") Then
                curElement.InvokeMember("click")
                ' javascript has a click method for we need to invoke on the current submit button element.
            End If
        Next
        WebWait(MyWebBrowser, 15)
        Dim AccessURI As String = MyWebBrowser.Url.ToString
        'Process.Start(AccessURI)
        Dim MyURI() As String
        MyURI = Split(AccessURI, "=")
        Dim MyAccessToken As String = MyURI(1)
        MyURI = Split(MyAccessToken, "&")
        MyAccessToken = MyURI(0)
        WebWait(MyWebBrowser, 15)
        Dim myAPI As New Api(MyAccessToken)
        CHECKTIMEROK = True
        ' **************  Get list of albums ********
        Dim MyAlbums = myAPI.GetAlbums ' This works for the March 25th build of the FGT and not the April 11 build
        'Dim Posts As IList(Album) = MyAlbums
        'Api call

        Dim aid As New ArrayList
        Dim tmp As String()
        Dim Myaid As String = Nothing
        Dim FBAlbumName = FacebookAlbumName.Text
        If FBAlbumName = "" Then
            FBAlbumName = "Event Upload Folder"
        End If
        Dim albumfoundflagg As Boolean = False
        Dim MyAlbumID As String = Nothing
        For Each P In MyAlbums
            If albumfoundflagg = False Then
                tmp = Split(P.link, "=")
                tmp = Split(tmp(1), "&")
                aid.Add(P.name & "," & tmp(0))
                If P.name = FBAlbumName Then
                    'MsgBox("Eureka")
                    Myaid = tmp(0)
                    MyAlbumID = P.id
                    albumfoundflagg = True
                End If
            End If
            'Dim A As Album = New Album(P.id, myAPI.AccessToken)
        Next
        If Myaid = Nothing Then ' Album does not exist .... need to make it
            Dim albumok As Boolean
            albumok = MakeAlbum3(FBAlbumName, MyWebBrowser)

            If albumok = True Then 'check albums again and get id of match
                ' note: There is a time delay for the album to be created and then available.
                ' the delay will be at least 5*albumcreationdelay. The search will occur at least 5 times.
                Dim albumcreationdelay As Integer = 3000
                Dim counter5 As Integer = 0
                albumfoundflagg = False
                Do While counter5 < 5 And albumfoundflagg = False
                    pause(albumcreationdelay)
                    counter5 = counter5 + 1
                    MyAlbums = myAPI.GetAlbums
                    For Each P In MyAlbums
                        If albumfoundflagg = False Then
                            tmp = Split(P.link, "=")
                            tmp = Split(tmp(1), "&")
                            aid.Add(P.name & "," & tmp(0))
                            If P.name = FBAlbumName Then
                                'MsgBox("Eureka")
                                Myaid = tmp(0)
                                MyAlbumID = P.id
                                albumfoundflagg = True
                                Display(StatusBox, FBAlbumName & " has been created")
                            End If
                        End If
                    Next
                Loop
            Else
                MsgBox("Error creating new album") ' chould not occur
            End If
        End If
        ' Get list of Friends
        'Dim GRAPHAPI As String = "https://graph.facebook.com/" & "601201034/"
        'Dim GRAPHAPI As String = "https://graph.facebook.com/" & myAPI.UserID
        'Dim MyFriend As String = GRAPHAPI & "friends?access_token=" & MyAccessToken
        'Dim MyAlbums As String = GRAPHAPI & "picture"
        'Dim testpost As String = GRAPHAPI & "feed"
        'MyWebBrowser.Navigate(MyFriend)

        'Dim B As System.Drawing.Bitmap = New System.Drawing.Bitmap(MyPhoto)
        'Create Album
        'Dim CreateAlbumString As String = "http://graph.facebook.com/PROFILE_ID/albums"
        'myAPI.PublishPhoto(B, "My 1st Facebook App Just Might Be Working!")
        'MsgBox(myAPI.ToString)
        ReturnData.MYALBUMID = MyAlbumID
        ReturnData.MYAPIinfo = myAPI
        ReturnData.MYAID = Myaid
        Return ReturnData
    End Function

    Public Function MakeAlbum3(ByVal AlbumName As String, ByVal MyWebBrowser As WebBrowser) As Boolean
        ' a first pass is needed to make the album
        Dim AlbumPageString As String = "http://www.facebook.com/albums/create.php"
        MyWebBrowser.Navigate(AlbumPageString)
        WebWait(MyWebBrowser, 15)
        Dim theElementCollection As HtmlElementCollection = MyWebBrowser.Document.GetElementsByTagName("input")
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
        Do While Not MWB.ReadyState = WebBrowserReadyState.Complete And counter <= MaxWait
            'MsgBox("Still Busy")
            pause(1000)
            counter = +1
        Loop
        If counter = MaxWait Then
            Display(StatusBox, "Taking too long to setup Facebook")
        End If
    End Sub

    Public Function PublishPhotoHOOD(ByVal photo As Bitmap, ByVal message As String, ByVal CustomerInfo As HoodFacebookInfo) As String
        Dim MS As New MemoryStream()
        photo.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim Imagebytes As Byte() = MS.ToArray()
        MS.Dispose()

        'Set up basic variables for constructing the multipart/form-data data
        Dim newline As String = vbCr & vbLf
        Dim boundary As String = DateTime.Now.Ticks.ToString("x")
        Dim data As String = ""

        'Construct data
        data += "--" & boundary & newline
        data += "Content-Disposition: form-data; name=""message""" & newline & newline
        data += message & newline

        data += "--" & boundary & newline
        data += "Content-Disposition: form-data; filename=""test.jpg""" & newline
        data += "Content-Type: image/jpeg" & newline & newline

        Dim ending As String = newline & "--" & boundary & "--" & newline

        'Convert data to byte[] array
        Dim finaldatastream As New MemoryStream()
        Dim databytes As Byte() = Encoding.UTF8.GetBytes(data)
        Dim endingbytes As Byte() = Encoding.UTF8.GetBytes(ending)
        finaldatastream.Write(databytes, 0, databytes.Length)
        finaldatastream.Write(Imagebytes, 0, Imagebytes.Length)
        finaldatastream.Write(endingbytes, 0, endingbytes.Length)
        Dim finaldatabytes As Byte() = finaldatastream.ToArray()
        finaldatastream.Dispose()

        'Make the request
        Dim request As WebRequest = HttpWebRequest.Create("https://graph.facebook.com/" & CustomerInfo.MYALBUMID & "/photos?access_token=" & CustomerInfo.MYAPIinfo.AccessToken)
        request.ContentType = "multipart/form-data; boundary=" & boundary
        request.ContentLength = finaldatabytes.Length
        request.Method = "POST"
        Using RStream As Stream = request.GetRequestStream()
            RStream.Write(finaldatabytes, 0, finaldatabytes.Length)
        End Using
        Dim WR As WebResponse = request.GetResponse()
        Dim _Response As String = ""
        Using sr As New StreamReader(WR.GetResponseStream())
            _Response = sr.ReadToEnd()
            sr.Close()
        End Using
        Dim JO As New JsonObject(_Response)
        Return DirectCast(JO("id"), String)
    End Function



End Class
