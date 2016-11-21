Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Collections
Imports System.Diagnostics.Process
'Notes: 11-20 - Added the check for filenames that start with $ This is an indicator that Darkroom did 
'not have an email address attached to the file. If not moved, an error will be generated. I wrote
' code to move this to a folder called not named. This folder is in the EventFolder.
'12-20 Wrote code that sends multiple images to a single email address. This works by taking inventory
'of all the different email addresses and their corresponding image files. For the email address containing
'more than a single image, an array is created and a filenameSTRING is created that has the form
'image1.jpg;image20.jpg;image450;jpg' This is done before the email engine is called
'When writing this code, the task of saving the truncated email file to the event folder was relegated
'to the parsing stage from the sendemail stage. The filenames that are sent to the email program.
'12-24 Wrote code that will allow the automatic sending of emails by monitoring a specified folder
'12-26 A VB based emailing library was purchased in order to eliminate the use of the DOS based emailing program
'and the limitations console batch programming. This program requires an unlocking key to unlock the see32.dll file
'It also has a see64.dll to use when compiling on a 64bit machine. The 32 bit compilation should work ok on both 
'64 bit and 32 bit machines
'1/10/10 Added the ability to save the delay information. The delay is beneficial in the print to email mode in that it 
'waits before collecting images to email. If a person is getting multiple images, it may send the first as soon as it comes
'then when finished, send the others
'1/10/10 Re-wrote code so that, when emails are created via ED, the working files will be deleted. However, they will only 
'be deleted after a successfull send. This is so that if an error occurs in a batch email, it would be easy to pick
'up where one leaves off
'2-24 Added code to automatically run DarkroomShortcut_WinZ.exe program that produces a shortcut that
'opens the photodata box and inserts email text.
'2-24 added code that stops DarkroomShortcut_WinZ.exe when the program is exited via 'X' or via system tray
'2-24 Added code to check for a connection before moving forward. This way, no files are deleted or folders
'produced unnessesarily. CheckEmailConnection()
'2-24 Added code that minimizes the window to the system tray and offers 3 options (hide,show,exit)
'Added a start/stop indicator.
'2-24 Created a structure variable for the Error variable.
'2-26 Updated the version to 3.0
'3-3 Changed the way that I handle the company's name. I wrote an encryption program that will 
'encrypt text. This way, I can encrypt the company's name and email address and supply a license code
'In compiling the code, CompanyName is set to "Evaluation" and "Return Email is "EVAL@SomeCompany.com"
'Also, the message box is locked. 
'The password was also encrypted.
'3-3 Changed to version 3-1-0-0
'4-20 RIP Dr. Heights.... Today, created an installer.
'5-17 Fixed case for which the port address is different than 25. In checkconnection(), I had failed to 
'set the port number before checking the connection. On my home system, the default 25 worked so the issue
'was not flagged. Verizon FIOS recently blocked 25 and switched to 587 and the code stopped working. This is 
'what drew me to this omission.
'5-17 For cases for which the given email address is unroutable (Code = -49), a message is displayed saying
'that the file is not routable and it is skipped. This will keep appearing until it is manually fixed.
'5-17 It was noticed that a time delay is needed after the program makes an initial check for connectivity. Originally
'I had 1 second, but I changed it to 5 seconds. This 5 second delay will be experienced each time the send button is
'pressed or a new run (when in auto mode).
'8-1 It was noticed that the UI became unresponsive when the watchfolder was active. This was fixed by placing
'GOButton (renamed to LetsGo() ) in its own thread RunGO()
'8-23 Added an internet connection status label
'8-23 Added a standby notice
'8-23 Added code that allows autoemail and confirmation selections to be saved.
Public Class Form1

    'DEFINE GLOBAL VARIABLES
    'Adrian Hood: X7wXvohZ01kC5ZZe2/zoY5V+5JxnEckxV7fDOcJwi4DXFDDn9aiIpvEVInladsVOUsmtH4dSbpeGb52UKFz1oQ==
    'My Easy Photo: rY+XintXtlQWTL0uSo+x7cwtsCqdJnZzd2sU1yH4uIXkLz8uSo2ToW360krySKtFIVKvJ81/tT4DA0FheMvARw==
    'My Easy Photo 2: n+vuq9xPppT/mqHKvMAlPWZWFbolo4grFWzEIsMS9RSdinNpWG0ZPagm55N98fW4FMFgusEqaefMjVzZ9ifhGg==
    'Chris Joyce Photography: 2wudczRIA0K9pKkzzSnk5Kb8hSveD9cZLdoGyMiEJigGsUbzciFi4DFxyIvRaKjsvOzr6KpCFirxF0JuxpsW0g==
    'Cascade Photography: u28JNFm9HAbzQTA4TNY3X94SItBFuyvsEoHm23ACsBETMpZQQhFGKh2chiACEi0B
    'Photofellas: hgnWLt+2H0YvXMpLKVO4AA2JLgq65LChHEiHAFt2Ifv8Qf1zO4/6i9oQ05ITi1dC
    'TEP Entertainment tepentertainment@gmail.com W8K0zTula6Lh0fuRyikoMBq48MAFQ12EzU21Bin8d/e3K+tqCHXaGqRlalI2gJ0W3b+tDrfLPUcQrv12rVB5YA==
    'Generic Company: hfQ98n3wQpPm2At3Gfv83Dml+V7MQtCM8dzDbLPEGiHcrxTeAEUl+h85lmnjG2TE
    'Creative One Photography: (Carliss) EFYTrdgsiQHFzY4dlFi40hJ4VSQaje4AokydEQEv7y+dq7jzAyi7PqKJol0RfMR2TM99cQNUMfQU8lJiJf/qoA==
    'Dim CompanyEmail As String = "<info@hoodandson.com>" ' Email program needs <>
    'Dim UserCompanyName As String = "Hood & Son Photography" & " " & CompanyEmail
    'Dim CompanyEmail As String = "<cjoyce@vidlife.com>" ' Email program needs <>
    'Dim UserCompanyName As String = "Chris Joyce Photography" & " " & CompanyEmail
    'Dim CompanyEmail As String = "<casilas@att.net>" ' Cascade Photography
    'Dim UserCompanyName As String = "Cascade Photography" & " " & CompanyEmail
    'Dim CompanyEmail As String = "<bryan@photofellas.com>" ' Photofellas
    'Dim UserCompanyName As String = "Photofellas" & " " & CompanyEmail
    'Dim CompanyEmail As String = "<myeasyphoto@comcast.net>" ' Photofellas
    'Dim UserCompanyName As String = "My Easy Photo, Inc." & " " & CompanyEmail
    'Dim CompanyEmail As String = "EVAL@SomeCompany.com"
    'Dim UserCompanyName As String = "EVALUATION  "    
    'My Easy Photo: 
    ' Get Company Info from License File
    Dim SiteToPing As String = "www.google.com" ' used to detect internet connection availability
    Dim CompanyEmail As String
    Dim UserCompanyName As String
    Dim CancelFlagg As String = "Run" ' Needed to be able to cancel the emailing program
    Dim Code As Integer ' used as the returned variable for the seeVB library (email library)
    Dim NullString As String  ' used with seeVB
    Dim StatusFile As String
    Dim EventFolder As String
    Dim WatchFolder As New System.IO.FileSystemWatcher()
    Dim GOThread As System.Threading.Thread
    Dim AutoEmailFlagg As Boolean ' Use to signal other control to go invisible and to use only one event folder
    Dim SENDEMAILFLAGG As Boolean = True
    Dim WinZProgram As New Process() ' Used to run Shortcup program. Check if it exists first.

    Private Strt As System.Threading.Thread ' Used when monitoring a folder
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
    'Private Delegate Sub UpdateStatusWindowThread(ByVal MyString As String)
    'Private _updateStutusWindow As New UpdateStatusWindowThread(AddressOf LetsGO)
    ' **************************************  MAIN SUBROUTINES *****************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Name = " Event Photo Emailer V " & My.Application.Info.Version.ToString
        ' The watchfolder is used monitor a folder for new entries. It is necessary to create it here in FormLoad
        ' to avoid threading errors. Initially, I had disabled that error. I have since re-enabled it not that I 
        ' correctly placed the code.
        AddHandler WatchFolder.Created, AddressOf RunGo
        AddHandler GoButton.Click, AddressOf LetsGO
        ' Initialization Code For Emailer Library *********
        ' attach SEE (seeAttach must be 1st SEE function called)
        ' This program checks to see if code and .dll file matches
        ' It either needs the keycode.vb attached or defined within this document

        Code = seeAttach(1, SEE_KEY_CODE)
        'MsgBox("Code: seeAttach: " & Code)
        If Code < 0 Then
            MsgBox("Error: Problem is accessing emailer library.. Cannot attach..Check Keycode")
            'Display("ERROR " + Str(Code) + ": Cannot attach. Check SEE_KEY_CODE.")
            End
        End If
        checkinternetconnection()

        Dim CurrentDirectory As String = System.Environment.CurrentDirectory
        ' *** Enter Customer Information
        Dim COMPDATA As CompanyInfoSTRUCTURE
        COMPDATA = GetLicenseCode(CurrentDirectory)
        If COMPDATA.EvaluationMode = True Then
            MsgBox("You are operating in Evaluation Mode." & vbCrLf & _
                   " Your Company Name and Company Email address will reflect this")
        End If
        'MsgBox("Company Email: " & COMPDATA.CompanyEmail & " Company Name: " & COMPDATA.CompanyName)
        'Dim CurrentDirectory As String = System.Environment.CurrentDirectory
        ProgDir2.Text = CurrentDirectory
        ' *** Enter Customer Information
        'Dim COMPDATA As CompanyInfoSTRUCTURE = GetLicenseCode()
        'Dim CompanyEmail As String = "<myeasyphoto@comcast.net>" ' Photofellas
        'Dim UserCompanyName As String = "My Easy Photo, Inc." & " " & CompanyEmail
        CompanyEmail = COMPDATA.CompanyEmail
        UserCompanyName = COMPDATA.CompanyName & COMPDATA.CompanyEmail
        CustomerInfo.Text = "Licensed to: " & UserCompanyName
        VersionLabel.Text = "Version:" & My.Application.Info.Version.ToString ' changed using Project/Properties/AssemblyInfo
        ' 1/6/2010  I decided to have the program determine the directory  that the EPE program exists.
        ' I disabled the browse button for this text box. ( I may change this to a label)
        ' ********  Set Default Field Settings
        WinZProgram.StartInfo.FileName = CurrentDirectory & "\bin\DarkroomShortcut_WinZ.exe"
        WinZProgram.StartInfo.Arguments = " "
        If File.Exists(WinZProgram.StartInfo.FileName) Then
            WinZProgram.Start()
        End If
        'MsgBox("The CurrentDirectory is: " & CurrentDirectory)
        'Dim DefaultFile As String = CurrentDirectory & "\bin\defaults.txt"


        Dim DefaultFile As String = ProgDir2.Text & "\bin\defaults.txt"
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
            Else
                textBox_SubjectLine.ReadOnly = False
            End If
            Textbox_imagefolder.Text = d.ReadLine()
            If Textbox_imagefolder.Text = "*" Then
                Textbox_imagefolder.Text = CurrentDirectory & "\EPE_HotFolder"
            End If
            textBox_messagefile.Text = d.ReadLine()
            If textBox_messagefile.Text = "*" Then
                textBox_messagefile.Text = CurrentDirectory & "\Message.txt"
            End If
            textBox_MailServer.Text = d.ReadLine()
            textBox_Username.Text = d.ReadLine()
            Try
                Dim testtry = MyDecryption(d.ReadLine())
                textBox_Password.Text = testtry
            Catch ex As Exception
                textBox_Password.Text = d.ReadLine()
            End Try
            'textBox_Password.Text = MyDecryption(d.ReadLine())
            PortBox.Text = d.ReadLine()
            DelayTextBox1.Text = d.ReadLine()
            If d.ReadLine() = "1" Then
                MonitorFolderCheckBox.CheckState = CheckState.Checked
            Else
                MonitorFolderCheckBox.CheckState = CheckState.Unchecked
            End If
            If d.ReadLine = "1" Then
                CheckBox_ConfirmationEmail.CheckState = CheckState.Checked
            Else
                CheckBox_ConfirmationEmail.CheckState = CheckState.Unchecked
            End If
            d.Close()
        End If
        ToolTip1.SetToolTip(DelayLabel1, "This value sets how long EPE will wait until" & vbCrLf & _
                            "after an image appears in the monitored folder" & vbCrLf & _
                            "before beginning the email process. This value depends on the" & vbCrLf & _
                            "size of the file being emailed. The delay value is in seconds.")
        ToolTip1.SetToolTip(MonitorFolderCheckBox, "This feature will allow you to let EPE" & vbCrLf & _
                            "run in the background and email photos as they" & vbCrLf & _
                            "become available.")
        ContextMenuStrip_ForNotificationIcon.Visible = False
        '        pause(5000)
        '        StatusBox.Text = "Initializing ... " & vbCrLf
        '        pause(5000)
        StatusBox.Text = "Ready. " & vbCrLf
        If MonitorFolderCheckBox.CheckState = CheckState.Checked Then
            MonitorFolderCheckBox_CheckedChanged(sender, New System.EventArgs) ' simulates an event
        End If
    End Sub

    Private Sub initialize()
        ' The purpose for this subroutine is to provide a means to reset the main window when a subroutine is aborted and does
        ' return to a stable state

    End Sub
    Public Sub RunGo()
        ' Runs LetsGo() on a thread to avoid the UI Freeze
        'Note: When thread ends, it is terminated automatically eliminating the need to use
        'GOThread.abort(). Because of this, a new thread is needed everytime.
        GOThread = New Thread(AddressOf LetsGO)
        GOThread.Start()
    End Sub

    Public Sub disbletextboxes(ByVal Decision As Boolean)
        Textbox_imagefolder.Enabled = Decision
        textBox_MailServer.Enabled = Decision
        textBox_messagefile.Enabled = Decision
        textBox_Password.Enabled = Decision
        textBox_SubjectLine.Enabled = Decision
        textBox_Username.Enabled = Decision
    End Sub

    Private Sub AccessControlStatusbox()
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf AccessControlStatusbox))
        Else
            ' Code wasn't working in the threading sub


        End If
    End Sub


    Public Sub LetsGO()
        ' This is the main part of the program. When the send button is pressed, there are two loops to take
        ' 1.) If a directory is being used, the ReadFromDirectory() is used. 
        ' 2.) If the files are parsed, then SendParsedEmails().
        ' The global event folder is set in this subroutine.

        Control.CheckForIllegalCrossThreadCalls = False
        disbletextboxes(False)
        ' Me.Enabled = False
        StatusBox.Clear() ' It is important that the clear status box appear after setting crossthreading to False
        ' Otherwise an unhandled fault will occur.
        pause(1000)
        CancelFlagg = "Run"
        If CancelFlagg <> "Cancel" Then
            'If MonitorFolderCheckBox.CheckState = CheckState.Checked Then
            'StoppedButton.Visible = True
            'StoppedButton.Text = "Standby"
            'StoppedButton.BackColor = Color.Gray
            'Else
            StoppedButton.Visible = False
            'End If
            SENDINGBUTTON.Visible = True
            StatusBox.Clear()
            Dim chkSMTP As MAILERRORHOOD
            chkSMTP.SMTPOK = False ' initialize variable
            chkSMTP = CheckEmailConnection() ' Returns SMTPOK = True if OK
            StatusBox.Text = "SMTP server found... Processing ... " & vbCrLf
            Dim mydate2 As Date = Now
            Dim time1 As Integer = mydate2.Second
            Dim timecheck As Double = 0
            Dim time2 As Integer = time1
            Dim maxduration As Double = 10
            ' The next line will wait until chkSMTP comes back true. This allows the execution to occur ASAP.
            While chkSMTP.SMTPOK = False And timecheck < maxduration ' Timeout set to 10 seconds.
                mydate2 = Now
                timecheck = Math.Abs(mydate2.Second - modhood(time1 + maxduration, 60 + maxduration)) ' tacked on maxduration to eliminate premature termination if seconds in the 56-59 range.
            End While
            'pause(3000) ' introduce a 3 second pause to ensure that the SMTP check is complete
            If chkSMTP.SMTPOK = False Then
                StatusBox.Clear()
                StatusBox.Text = chkSMTP.SMTPerrorMessage
                'Error message is displayed in the status box
                'The send email button will need to be pressed again.
                'do not run loop since no SMTP connection exist.
            Else ' Proceed forward
                ' ***** PRODUCE THE EVENT FOLDER
                Dim MyDate As Date = Now
                'Dim MyDateString As String = MyDate.Month & "_" & MyDate.Day & "_" & MyDate.Year & "_" & MyDate.Hour & "_" & MyDate.Minute & "_" & MyDate.Second
                Dim MyDateString As String = MyDate.Month & MyDate.Day & MyDate.Year & MyDate.Hour & MyDate.Minute & MyDate.Second
                If AutoEmailFlagg = True Then
                    EventFolder = Textbox_imagefolder.Text & "\Event_" & MyDate.Month & MyDate.Day & MyDate.Year
                Else
                    EventFolder = Textbox_imagefolder.Text & "\" & "Event_" & MyDateString
                End If
                StatusFile = EventFolder & "\status.txt" ' Global Vector
                Directory.CreateDirectory(EventFolder)
                ' *************************************************

                If CheckBox2_emailfilename.CheckState = CheckState.Checked Then ' Case for supplied list
                    SendEmailFromDirectory()
                Else ' Case for which filenames are parsed to get email addresses and filenames
                    SendParsedEmails()
                End If
            End If
        End If
        disbletextboxes(True)
        'Me.Enabled = True
        Control.CheckForIllegalCrossThreadCalls = True
    End Sub

    Public Sub SendEmailFromDirectory()
        'Dim StatusFile As String = EventFolder & "\status.txt"
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
        Display("")
        'End If
        'StatusBox.Clear()
        'Clear Contents (statusbox.clear() does not work as expected)
        'It writes the new data starting at the beginning but does not erase the contents already 
        'in the statusbox. The next set of lines writes blank likes over a lot of lines.

        If Not File.Exists(EmailFilenameList.Text) Then
            Display("Error: Directory File not provided")
            Display("Please provide the name of your directory file")
            CancelFlagg = "Cancel"
            Exit Sub
        Else
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
                    For counter2 = 0 To temp.Length - 1
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
                'If testspace_email.Length < 2 Then
                'MsgBox(filename)
                SENDEMAIL(EmailRemoveSpaces, filename, EventFolder, filenameshortDirectory, CancelFlagg, SENDEMAILFLAGG)
                'Else
                'MsgBox("Email address: " & email & " has spaces. No email is sent")
                'End If
                ' PROGRESS BAR
                If linecounter <> 0 Then
                    ProgressBar1.Visible = True
                    ProgressBar1.Value = 100 * CType(loopcounter / linecounter, Integer)
                End If
                loopcounter += 1
            End While
            d4.Close()
        End If
        If CancelFlagg <> "Cancel" And MonitorFolderCheckBox.CheckState <> CheckState.Checked Then
            'StatusBox.Text = StatusBox.Text & "Finished....."
            Display("Finished..........")
            StoppedButton.Visible = True
            SENDINGBUTTON.Visible = False
            ProgressBar1.Visible = False
        End If
    End Sub

    Public Sub SendParsedEmails()
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
        CheckForNonEmailedJPGFiles()
        'For Each fullstring In NoEmailFilename
        '    Dim InputString As String = "***[" & fullstring.Name & "$" & "] did not have an email address attached...Not Sent***"
        '    Display(InputString)
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
                Display("Process has been cancelled")
                Exit Sub
            Else
                'First copy image to the event folder truncating the email address(s)
                oldfilename = Textbox_imagefolder.Text & "\" & fullstring.Name
                newfilename = EventFolder & "\" & temp(1)
                If File.Exists(newfilename) Then
                    File.Delete(newfilename) 'An attempt was made to append the file with a counter but
                    ' book keeping got a little cumbersome. I may return to this but now, it simply 
                    ' deletes the old file
                End If
                File.Copy(oldfilename, newfilename)
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
                If SENDEMAILFLAGG = True Then
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
                ProgressBar1.Value = 100 * Convert.ToInt32(counter / NumOfEmailees)
            End If
        Next


        If CancelFlagg <> "Cancel" And MonitorFolderCheckBox.CheckState <> CheckState.Checked Then
            'StatusBox.Text = StatusBox.Text & "Finished....."
            Display("Finished..........")
            StoppedButton.Visible = True
            SENDINGBUTTON.Visible = False
            ProgressBar1.Visible = False
        End If

        If MonitorFolderCheckBox.CheckState = CheckState.Checked Then
            Display("Waiting for more images....." & vbCrLf)
            StoppedButton.Text = "Standby"
            StoppedButton.Visible = True
            StoppedButton.BackColor = Color.Green
        End If
        'System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        'CancelFlagg = "Cancel"

    End Sub

    Private Sub Combine(ByRef emailarray() As String, ByRef filenamearray() As String, ByRef emailstring() As String, ByRef filenamestring() As String)
        ' This subroutine is used to combine the images of like emails into a usable string that the 
        ' emailing program can use.
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
    End Sub

    Private Sub SENDEMAIL(ByVal email As String, ByVal filenamestring As String, ByVal EventFolder As String, ByVal filenameshort As String, ByRef GOFLAGG As String, ByRef SENDEMAILFLAGG As Boolean)
        Dim StatusFile As String = EventFolder & "\status.txt"
        Dim DirectoryFile As String = EventFolder & "\directory.csv"
        Dim ErrorFile As String = EventFolder & "\errors.txt"
        SENDEMAILFLAGG = False
        If CancelFlagg <> "Cancel" Then
            'check that SMTP server name has been specified
            ' ************************* MAKE CHECKS ON INPUT DATA *************************
            If Len(textBox_MailServer.Text) = 0 Then
                Display("Missing SMTP server name.")
                Exit Sub
            End If

            'check Email From

            If Len(CompanyEmail) = 0 Then
                Display("Missing 'Email From'")
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
            'Will not produce a result when the folder is being monitored. I noticed that I would get
            'Some phantom files that I could not put a finger on. This is just a temparary fix. I'm thinking
            'That the change in the event folder is what is triggering the phantom file even though
            'the Filter is set to only look at *.jpg
            If Len(email) = 0 Then
                'Display("Missing 'Email To' in " & filenamestring)
                Exit Sub 'skip
            End If

            ' add brackets if needed

            If InStr(email, "<") = 0 Then
                email = "<" + email
            End If
            If InStr(email, ">") = 0 Then
                email = email + ">"
            End If

            'check Save Path

            If Len(textBox_SubjectLine.Text) = 0 Then
                Display("Missing Subject Line.")
                Exit Sub
            End If

            'connect to server
            'The following code uses a username and password
            Code = seeIntegerParam(0, SEE_ENABLE_ESMTP, 1)

            ' set up log file
            'Code = seeStringParam(0, SEE_LOG_FILE, EventFolder & "\DEBUG_MAILER.LOG")



            'If waitSMTPCheckBox.CheckState = CheckState.Checked Then
            ' Code = seeIntegerParam(0, SEE_CONNECT_WAIT, 20000) ' maximum time allowed to complete a connection to the email server.
            ' Code = seeIntegerParam(0, SEE_MAX_RESPONSE_WAIT, 10000) 'time after which a "timeout" error occurs if the server has not responded.
            'End If
            'Code = seeIntegerParam(0, SEE_SLEEP_TIME, 500) ' the time SEE sleeps when waiting on a Winsock.
            Code = seeIntegerParam(0, SEE_ENABLE_IMAGE, 1) ' Special processing when dealing with images to allow email program to view photos
            If Len(PortBox.Text) <> 0 Then
                Code = seeIntegerParam(0, SEE_SMTP_PORT, Convert.ToInt32(PortBox.Text)) 'set port (note: Comcast uses 587
                'Code = seeIntegerParam(0, SEE_SMTP_PORT, 587) 'set port (note: Comcast uses 587
            End If

            If Code < 0 Then
                ShowErrorSendingFile(Code, "", "", StatusFile, ErrorFile)
            End If
            Code = seeStringParam(0, SEE_SET_SECRET, textBox_Password.Text + Chr(0))
            If Code < 0 Then
                ShowErrorSendingFile(Code, "", "", StatusFile, ErrorFile)
            End If
            Code = seeStringParam(0, SEE_SET_USER, textBox_Username.Text + Chr(0))
            If Code < 0 Then
                ShowErrorSendingFile(Code, "", "", StatusFile, ErrorFile)
            End If
            'Display("Connecting to SMTP server: " + textBox_MailServer.Text)


            Code = seeDebug(0, SEE_GET_SERVER_IP, NullString, 40)
            If Code < 0 Then
                ShowErrorSendingFile(Code, "", "", StatusFile, ErrorFile)
            End If
            ' Note: the @ symbol is used to tell the emailer program to used the contents of the message file
            'MsgBox("Email: " & email & " Filename: " & filenamestring)


            Dim SmtpErrorCode As Integer = seeSmtpConnect(0, textBox_MailServer.Text, UserCompanyName, NullString)
            Dim SendEmailCode As Integer
            pause(2000) ' May be required for output from seeSmtpConnect. If too fast, the next line
            'may be analyzed and SmtpErrorCode may have an arbitrary value.
            If SmtpErrorCode < 0 Then
                Dim SMTPerrorMessage As String
                Dim INTCHECK As String = checkinternetconnection()
                If INTCHECK = "1" Then
                    SMTPerrorMessage = "Your internet connection is not active."
                ElseIf INTCHECK = "3" Then
                    SMTPerrorMessage = "You do not have a network connection"
                Else
                    SMTPerrorMessage = "Error obtaining a SMTP connection. Check:" _
                & vbCrLf & "1.) That your server address is correct." _
                & vbCrLf & "2.) That your username and password are correct." _
                & vbCrLf & "3.) That your security software allows outgoing mail on port: " & PortBox.Text & "."
                End If
                CancelFlagg = "Cancel"
                Display("Error: Emailing has been stopped.")
                MsgBox(SMTPerrorMessage)
                SENDINGBUTTON.Visible = False
                StoppedButton.Visible = True
                CheckConnectionTimer.Enabled = False ' turn off the check to avoid a loop of checkconnection(). I don't know why this occurs yet.
                Exit Sub
            Else
                SendEmailCode = seeSendEmail(0, email, NullString, NullString, textBox_SubjectLine.Text, "@" & textBox_messagefile.Text, filenamestring)
                ' Send Confirmation Email
                If CheckBox_ConfirmationEmail.CheckState = CheckState.Checked Then
                    SendEmailCode = seeSendEmail(0, CompanyEmail, NullString, NullString, "Confirmation: " & textBox_SubjectLine.Text, "@" & textBox_messagefile.Text, filenamestring)
                End If
            End If 'MsgBox("seeSendEmail Code: " & Code & "  Email: " & email)

            If SendEmailCode < 0 Then 'Code corresponding to seeSendEmail()
                If SendEmailCode = -49 Then
                    Dim InputString As String = "[" & filenameshort & "]" & " has an invalid address. Please fix."
                    Display(InputString)
                    'Skip (and keep skipping every time until I figure out how to delete it)
                Else
                    SENDEMAILFLAGG = False
                    'error attempting to send email
                    'Call Display("***Error sending [" & filenameshort & "]: Code: " + Str(Code) & " ***" & Chr(10) & Chr(13))
                    ShowErrorSendingFile(SendEmailCode, "", "", StatusFile, ErrorFile)
                    Display("Also, check if your security software allows outgoing mail on port: " & PortBox.Text)
                    Display("") ' ads a CR+LF
                    CancelFlagg = "Cancel"
                End If
            Else
                SENDEMAILFLAGG = True
                Dim InputString As String = "[" & filenameshort & "]" & " was successfully sent to " & email
                Display(InputString)
                My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
                My.Computer.FileSystem.WriteAllText(DirectoryFile, filenameshort & "," & email & Chr(13), True)
                'Code = seeClose(0)
                'Code = seeRelease()
            End If
            Code = seeClose(0)
            If SmtpErrorCode > 0 Then
                Code = seeRelease()
            End If
        End If
        'Code = seeRelease()
    End Sub

    ' **************************************  SUPPORT SUBROUTINES *****************
    Private Sub WatchFolderWithSetFrequency(ByVal durationhood As Integer)
        ' This subroutine is not used yet. The idea is that I would like to put the filesystemwatcher method
        ' into a subroutine that allows me to enable/disable at a set frequency.
        ' integer is in seconds. Will use clock
        Dim MyDate As Date = Now
        Dim timehood = MyDate.Second
    End Sub

    Public Sub MonitorFolderCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonitorFolderCheckBox.CheckedChanged
        'This subfunction watches a folder and looks for some activity. For this application, it looks for the
        'create activity. When this occurs it runs the LetsGo() subroutine. Note: there is a problem when
        'trying to access the statusbox and other like controls via this method. It appears that those controls
        'are only accessible when the button is actually clicked. Othersie you get an illegal Cross-Thread error.
        'This was bypassed by using System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False/True switch.
        'Dim WatchFolder As New System.IO.FileSystemWatcher()
        'Needs to first check that the folder exists'
        If Directory.Exists(Textbox_imagefolder.Text) Then
            Try
                WatchFolder.Path = Textbox_imagefolder.Text
            Catch ex As Exception
                'FolderBrowserDialog_image_location.ShowDialog()
                'WatchFolder.Path = FolderBrowserDialog_image_location.SelectedPath
                'do nothing
            End Try

            'WatchFolder.NotifyFilter = NotifyFilters.CreationTime
            WatchFolder.Filter = "*.jpg" 'May use if other files are created in the same folder.
            ' Add event handlers

            If MonitorFolderCheckBox.CheckState = CheckState.Checked Then
                CancelFlagg = "run"
                'GoFlagg = True
                'MsgBox("GoFlagg = " & GoFlagg.ToString)
                ' The wait command will give it time to finish.
                AutoEmailFlagg = True
                'StatusBox.Text = "Your image directory is being monitored." & Chr(13) & Chr(10) & "Emails will be automatically sent" & Chr(10) & Chr(13) & "Waiting ..." & vbCrLf
                StatusBox.Clear()
                Display("Currently monitoring " & vbCrLf & Textbox_imagefolder.Text & vbCrLf)
                'Display("Your image directory is being monitored.")
                Display("Emails will be automatically sent")
                Display("Waiting....")
                'MsgBox("EPE Emailer will now monitor your image directory. Emails will be automatically sent")
                WatchFolder.EnableRaisingEvents = True
                GoButton.Visible = False
                DelayLabel1.Visible = True
                DelayTextBox1.Visible = True
                StoppedButton.Visible = True
                StoppedButton.Text = "Standby"
                StoppedButton.BackColor = Color.Green
            Else
                StoppedButton.Visible = True
                StoppedButton.Text = "Stopped"
                StoppedButton.BackColor = Color.Red
                DelayLabel1.Visible = False
                DelayTextBox1.Visible = False
                AutoEmailFlagg = True
                WatchFolder.EnableRaisingEvents = False
                'StatusBox.Text = "Your image directory is NOT being monitored. Emails will NOT be automatically sent" & Chr(10) & Chr(13)
                StatusBox.Clear()
                Display("Automatic mail delivery has been disabled. " & _
                        "Use the green 'SEND EMAILS' button below to start the process manually.")

                'MsgBox("EPE Emailer is not monitoring your image directory. Emails will need to be manually sent")
                GoButton.Visible = True
            End If
        Else
            MsgBox(Textbox_imagefolder.Text & " Does not exist. You many need to change the path in your ..\bin\default.txt file")
        End If
    End Sub

    Private Sub Display(ByVal X As String)
        'Chr(10) is linefeed and Chr(13) is Carriage Return.
        StatusBox.AppendText(X & vbCrLf)
    End Sub

    Private Sub CheckFileExistence_And_Spaces(ByVal PATH As String, ByVal FILENAMETOCHECK As String, ByRef CheckFileFlagg As String)
        Dim testspace_filename() As String
        Dim FN = PATH & FILENAMETOCHECK
        'MsgBox("Checking " & FN & "  file.exist = " & File.Exists(FN))
        If Not File.Exists(FN) Then 'check for existance
            CheckFileFlagg = "False"
            Display(FILENAMETOCHECK & " Does not exist, please check the spelling or make sure that the box" & _
                    " is checked to supress the .jpg extension")
            Display("This file will not be sent")
            testspace_filename = Split(FILENAMETOCHECK, " ")
            If testspace_filename.Length > 1 Then
                Display(FILENAMETOCHECK & " cannot contain spaces." _
                & " Please check your message filename, CSV filename, image filenames and email addresses." _
                & FILENAMETOCHECK & " was not sent")
            End If
        Else
            CheckFileFlagg = "True"
        End If
    End Sub

    Private Sub ShowErrorSendingFile(ByVal ErrCode As Integer, ByVal Filename As String, ByVal emailaddress As String, ByVal STATFILE As String, ByVal ERRFILE As String)
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
        Display(ErrorString)
        'Call Display(Microsoft.VisualBasic.Left(Buffer, Buffer.Length))
        My.Computer.FileSystem.WriteAllText(STATFILE, ErrorString & Chr(13), True)
        My.Computer.FileSystem.WriteAllText(ERRFILE, ErrorString & Chr(13), True)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FolderBrowserDialog_image_location.ShowDialog()
        Textbox_imagefolder.Text = FolderBrowserDialog_image_location.SelectedPath
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OpenFileDialog1_message_location.ShowDialog()
        textBox_messagefile.Text = OpenFileDialog1_message_location.FileName
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2_emailfilename.CheckedChanged
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then EmailFilenameList.Visible = True Else EmailFilenameList.Visible = False
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then ignoreJPG.Visible = True Else ignoreJPG.Visible = False
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then Button3_browse_email_filename.Visible = True Else Button3_browse_email_filename.Visible = False
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then MonitorFolderCheckBox.Visible = False Else MonitorFolderCheckBox.Visible = True
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then Label9_EmailListDescription.Visible = True Else Label9_EmailListDescription.Visible = False
    End Sub

    Private Sub Button_SaveAsDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SaveAsDefault.Click
        Dim DefaultFile As String = ProgDir2.Text & "\bin\defaults.txt"
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
        s.WriteLine(textBox_MailServer.Text)
        s.WriteLine(textBox_Username.Text)
        s.WriteLine(MyEncryption(textBox_Password.Text))
        s.WriteLine(PortBox.Text)
        s.WriteLine(DelayTextBox1.Text)
        If MonitorFolderCheckBox.CheckState = CheckState.Checked Then
            s.WriteLine("1")
        Else
            s.WriteLine("0")
        End If
        If CheckBox_ConfirmationEmail.CheckState = CheckState.Checked Then
            s.WriteLine("1")
        Else
            s.WriteLine("0")
        End If
        s.Close()
        'closing the file
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1_browse_image_location.Click
        FolderBrowserDialog_image_location.ShowDialog()
        Textbox_imagefolder.Text = FolderBrowserDialog_image_location.SelectedPath
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2_browse_message_file.Click
        OpenFileDialog1_message_location.ShowDialog()
        textBox_messagefile.Text = OpenFileDialog1_message_location.FileName
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3_browse_email_filename.Click
        OpenFileDialog2_emaillist.ShowDialog()
        EmailFilenameList.Text = OpenFileDialog2_emaillist.FileName
    End Sub

    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FolderBrowserDialog2_ProgramDirectory.ShowDialog()
    '    ProgDir2.Text = FolderBrowserDialog2_ProgramDirectory.SelectedPath
    'End Sub

    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SaveAsDefault.Click
    '    Dim DefaultFile As String = ProgDir2.Text & "\bin\defaults.txt"
    '    Dim fs As New FileStream(DefaultFile, FileMode.Create, FileAccess.Write)
    '    Dim s As New StreamWriter(fs)
    '    'creating a new StreamWriter and passing the filestream object fs as argument
    '    s.BaseStream.Seek(0, SeekOrigin.End)
    '    'the seek method is used to move the cursor to next position to avoid text to be
    '    'overwritten
    '    's.WriteLine(ProgDir2.Text)
    '    s.WriteLine(textBox_SubjectLine.Text)
    '    s.WriteLine(Textbox_imagefolder.Text)
    '    s.WriteLine(textBox_messagefile.Text)
    '    s.WriteLine(textBox_MailServer.Text)
    '    s.WriteLine(textBox_Username.Text)
    '    s.WriteLine(textBox_Password.Text)
    '    s.WriteLine(PortBox.Text)
    '    s.Close()
    '    'closing the file
    'End Sub

    Private Sub CancelButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton1.Click
        CancelFlagg = "Cancel"
    End Sub

    Private Sub pause(ByVal delay As Integer)
        Dim s As Integer = Environment.TickCount
        Dim e As Integer = 0
        Do : My.Application.DoEvents()
            Threading.Thread.Sleep(1)
            e = Environment.TickCount
        Loop Until (e - s) >= delay
    End Sub

    Public Function CheckEmailConnection() As MAILERRORHOOD
        'Check if SMTP connection is available
        'Fixed error due to port not being set within this subroutine
        'Dim SMTPOK As Boolean ' True if ok, and False if error
        Dim MailError As MAILERRORHOOD
        Dim SmtpErrorCode As Integer
        MailError.SMTPOK = True
        MailError.SMTPerrorMessage = "No Error"
        If Len(PortBox.Text) <> 0 Then
            Code = seeIntegerParam(0, SEE_SMTP_PORT, Convert.ToInt32(PortBox.Text)) 'set port (note: Comcast uses 587
            'Display("Sending mail on port: " & PortBox.Text)
            Display("Checking The Connection ...")
            'Code = seeIntegerParam(0, SEE_SMTP_PORT, 587) 'set port (note: Comcast uses 587
        End If
        ' set up log file
        'Code = seeStringParam(0, SEE_LOG_FILE, EventFolder & "\DEBUG_MAILER.LOG")
        'Code = seeStringParam(0, SEE_LOG_FILE, ProgDir2.Text + "\Logfile.log") ' Use for debugging
        Code = seeIntegerParam(0, SEE_ENABLE_ESMTP, 1)
        Code = seeStringParam(0, SEE_SET_USER, textBox_Username.Text + Chr(0))
        Code = seeStringParam(0, SEE_SET_SECRET, textBox_Password.Text + Chr(0))
        Code = seeDebug(0, SEE_GET_SERVER_IP, NullString, 40)
        SmtpErrorCode = seeSmtpConnect(0, textBox_MailServer.Text, "<Test>", NullString)
        'SmtpErrorCode = seeCommand(0, "NOOP" + Chr(0))  'Try this commmand. Used to check connection.
        If SmtpErrorCode < 0 Then
            Dim INTCHECK As String = checkinternetconnection()
            If INTCHECK = "1" Then
                MailError.SMTPerrorMessage = "Your internet connection is not active."
            ElseIf INTCHECK = "3" Then
                MailError.SMTPerrorMessage = "You do not have a network connection"
            Else
                MailError.SMTPerrorMessage = "Error obtaining a SMTP connection. Check:" _
            & vbCrLf & "1.) That your server address is correct." _
            & vbCrLf & "2.) That your username and password are correct." _
            & vbCrLf & "3.) That your security software allows outgoing mail on port: " & PortBox.Text & "."
            End If
            CancelFlagg = "Cancel"
            Display("Error: Emailing has been stopped.")
            MsgBox(MailError.SMTPerrorMessage)
            SENDINGBUTTON.Visible = False
            StoppedButton.Visible = True
            MailError.SMTPOK = False
        Else
            MailError.SMTPOK = True
        End If
        Return MailError
    End Function

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If File.Exists(WinZProgram.StartInfo.FileName) Then
            WinZProgram.Kill()
        End If
    End Sub

    Private Sub ShowEPEForm() Handles ShowEPE.Click
        Me.Visible = True
    End Sub

    Private Sub HideEPEForm() Handles HideEPE.Click
        Me.Visible = False
    End Sub

    Private Sub ExitEPEForm() Handles ExitEPE.Click
        NotifyIcon1.Visible = False
        Me.Close()  ' Calls the form1_FormClosing() function
    End Sub

    Private Sub HideButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideButton.Click
        HideEPEForm()
    End Sub

    Private Function MyEncryption(ByVal PassCode As String) As String
        Dim sym As New Encryption.Symmetric(Encryption.Symmetric.Provider.Rijndael)
        Dim key As New Encryption.Data("OBAMA")
        Dim encryptedData As Encryption.Data
        encryptedData = sym.Encrypt(New Encryption.Data(PassCode), key)
        Dim base64EncryptedString As String = encryptedData.ToBase64
        Return encryptedData.ToBase64
    End Function

    Private Function MyDecryption(ByVal PassCode As String) As String
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

    Private Function GetLicenseCode(ByVal DIRECTORY As String) As CompanyInfoSTRUCTURE
        'This works by first checking to see if there is a \bin\lic.dat file. If there is,
        'it is checked to obtain the encrypted company name and email address. A try/catch
        'loop is used in MyDecryption() just in case the the information is corrupt. If it is corrupt,
        '"InvalidPasscode$$$Corrupt" is used as the PassCode in Base64. This subroutine,
        'then decrypts the code. If its the corrupt code, then it gives the option to Abort, Retry, or
        'ignore. If retry, EnterPassCode() is called and the passcode is re-entered.
        Dim PassCode As String
        Dim tester() As String
        Dim COMP As CompanyInfoSTRUCTURE
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
                    ExitEPEForm() ' Kills program
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

    Private Sub CheckForNonEmailedJPGFiles()
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
                Display(InputString)
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

    Private Function modhood(ByVal value As Double, ByVal max As Double) As Double
        Dim n As Integer
        Dim d As Double = Math.Floor(value / max)
        n = CType(d, Integer) ' convert value to integer
        Return value - n * max
    End Function

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Process.Start("explorer.exe", Textbox_imagefolder.Text)
    End Sub

    Private Function checkinternetconnection() As String
        Dim NETFOUND As String
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
        Return NETFOUND

    End Function


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckConnectionTimer.Tick
        checkinternetconnection()
    End Sub

End Class
