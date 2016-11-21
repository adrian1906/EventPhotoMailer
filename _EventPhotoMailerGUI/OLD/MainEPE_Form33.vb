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

Public Class Form1

    'DEFINE GLOBAL VARIABLES
    Dim CompanyEmail As String = "<info@hoodandson.com>" ' Email program needs <>
    Dim UserCompanyName As String = "Hood & Son Photography" & " " & CompanyEmail
    'Dim CompanyEmail As String = "<cjoyce@vidlife.com>" ' Email program needs <>
    'Dim UserCompanyName As String = "Chris Joyce Photography" & " " & CompanyEmail
    'Dim CompanyEmail As String = "<casilas@att.net>" ' Cascade Photography
    'Dim UserCompanyName As String = "Cascade Photography" & " " & CompanyEmail
    'Dim CompanyEmail As String = "<bryan@photofellas.com>" ' Photofellas
    'Dim UserCompanyName As String = "Photofellas" & " " & CompanyEmail
    Dim CancelFlagg As String = "Run" ' Needed to be able to cancel the emailing program
    Private Strt As System.Threading.Thread ' Used when monitoring a folder
    Dim AutoEmailFlagg As Boolean ' Use to signal other control to go invisible and to use only one event folder
    Dim Code As Integer ' used as the returned variable for the seeVB library (email library)
    Dim NullString As String  ' used with seeVB
    Dim StatusFile As String
    Dim EventFolder As String
    Dim WatchFolder As New System.IO.FileSystemWatcher()
    Public Const SEE_KEY_CODE As Integer = 1906781263&
    'The use of the Delegate SetTextCallback is a trick to allow a control's subroutine to be called without
    'accessing it from another control. This is used to run the Go_Button routine using
    'a subroutine that monitors a specified folder
    'Delegate Sub SetTextCallback(ByVal [text] As String)
    Dim SENDEMAILFLAGG As Boolean = True
    Dim WinZProgram As New Process()



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Name = " Event Photo Emailer V " & My.Application.Info.Version.ToString
        ' The watchfolder is used monitor a folder for new entries. It is necessary to create it here in FormLoad
        ' to avoid threading errors. Initially, I had disabled that error. I have since re-enabled it not that I 
        ' correctly placed the code.
        AddHandler WatchFolder.Created, AddressOf GoButton_Click
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
        ' *** Enter Customer Information
        CustomerInfo.Text = "Licensed to: " & UserCompanyName
        VersionLabel.Text = "Version:" & My.Application.Info.Version.ToString ' changed using Project/Properties/AssemblyInfo
        ' 1/6/2010  I decided to have the program determine the directory  that the EPE program exists.
        ' I disabled the browse button for this text box. ( I may change this to a label)
        ' ********  Set Default Field Settings


        Dim CurrentDirectory As String = System.Environment.CurrentDirectory
        WinZProgram.StartInfo.FileName = CurrentDirectory & "\bin\DarkroomShortcut_WinZ.exe"
        WinZProgram.StartInfo.Arguments = " "
        If File.Exists(WinZProgram.StartInfo.FileName) Then
            WinZProgram.Start()
        End If
        'MsgBox("The CurrentDirectory is: " & CurrentDirectory)
        'Dim DefaultFile As String = CurrentDirectory & "\bin\defaults.txt"

        ProgDir2.Text = CurrentDirectory
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
            Textbox_imagefolder.Text = d.ReadLine()
            textBox_messagefile.Text = d.ReadLine()
            textBox_MailServer.Text = d.ReadLine()
            textBox_Username.Text = d.ReadLine()
            textBox_Password.Text = d.ReadLine()
            PortBox.Text = d.ReadLine()
            DelayTextBox1.Text = d.ReadLine()
            d.Close()
        End If
        ToolTip1.SetToolTip(DelayLabel1, "This value sets how long EPE will wait until" & vbCrLf & _
                            "after an image appears in the monitored folder" & vbCrLf & _
                            "before beginning the email process. This value depends on the" & vbCrLf & _
                            "size of the file being emailed. The delay value is in seconds.")
        ToolTip1.SetToolTip(MonitorFolderCheckBox, "This feature will all you to let EPE" & vbCrLf & _
                            "run in the background and email photos as they" & vbCrLf & _
                            "become available.")
        ContextMenuStrip_ForNotificationIcon.Visible = False
    End Sub

    Private Sub GoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoButton.Click
        ' This is the main part of the program. When the send button is pressed, there are two loops to take
        ' 1.) If a directory is being used, the ReadFromDirectory() is used. 
        ' 2.) If the files are parsed, then SendParsedEmails().
        ' The global event folder is set in this subroutine.
        'StatusBox.Clear()
        ' This code will send the program to the system tray.
        'If SystemTray_CheckBox1.CheckState = CheckState.Checked Then
        'NotifyIcon1.Visible = False
        'Me.Visible = False
        'End If

        Control.CheckForIllegalCrossThreadCalls = False
        CancelFlagg = "Run"
        If CancelFlagg <> "Cancel" Then
            StoppedButton.Visible = False
            SENDINGBUTTON.Visible = True
            StatusBox.Clear()
            StatusBox.Text = "Processing ... " & vbCrLf
            pause(1000)
            Dim chkSMTP As Boolean = CheckEmailConnection() ' Returns SMTPOK = True if OK
            If chkSMTP = False Then
                'Error message is displayed in the status box
                'The send email button will need to be pressed again.
                'do not run loop since no SMTP connection exist.
            Else ' Proceed forward
                ' ***** PRODUCE THE EVENT FOLDER
                Dim MyDate As Date = Now
                Dim MyDateString As String = MyDate.Month & "_" & MyDate.Day & "_" & MyDate.Year & "_" & MyDate.Hour & "_" & MyDate.Minute & "_" & MyDate.Second
                If AutoEmailFlagg = True Then
                    EventFolder = Textbox_imagefolder.Text & "\Event_" & MyDate.Month & "_" & MyDate.Day & "_" & MyDate.Year
                Else
                    EventFolder = Textbox_imagefolder.Text & "\" & "Event_" & MyDateString
                End If
                Directory.CreateDirectory(EventFolder)
                ' *************************************************

                If CheckBox2_emailfilename.CheckState Then ' Case for supplied list
                    SendEmailFromDirectory()
                Else ' Case for which filenames are parsed to get email addresses and filenames
                    SendParsedEmails()
                End If
            End If
            Control.CheckForIllegalCrossThreadCalls = True
        End If
    End Sub

    Public Sub SendEmailFromDirectory()
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
                    ProgressBar1.Value = 100 * loopcounter / linecounter
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
        Dim NoEmailFilename As IO.FileInfo() = str.GetFiles("$*.jpg") 'Image with no email will just start with $

        If MonitorFolderCheckBox.CheckState = CheckState.Checked Then
            System.Threading.Thread.Sleep(DelayTextBox1.Text * 1000) 'I believe the trigger occurs when file appears but not when finished.
            ' A delay is needed for the file to be created and ready to send. This value is dependent on the computer
            ' and the filesize of the image to be created. The default is 2 seconds. Later, I may include a form
            ' field that will allow this value to be entered.
        End If

        'Delete all files starting with $
        For Each fullstring In NoEmailFilename
            Dim InputString As String = "***[" & fullstring.Name & "$" & "] did not have an email address attached...Not Sent***"
            Display(InputString)
            My.Computer.FileSystem.WriteAllText(StatusFile, InputString & Chr(13), True)
            Dim NoEmailString As String = EventFolder & "\" & "NoAttachedEmailAddress"
            If Not File.Exists(NoEmailString) Then
                Directory.CreateDirectory(NoEmailString)
            End If
            If File.Exists(NoEmailString & "\" & fullstring.Name) Then
                File.Delete(NoEmailString & "\" & fullstring.Name)
            End If
            File.Move(Textbox_imagefolder.Text & "\" & fullstring.Name, NoEmailString & "\" & fullstring.Name)
        Next

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
                                           & vbCrLf & "not intended to be emailed. Please clear the image folder" _
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
                ProgressBar1.Value = 100 * counter / NumOfEmailees
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
            If Len(textBox_MailServer.Text) = 0 Then
                Display("Missing SMTP server name.")
                Exit Sub
            End If

            ' ************************* MAKE CHECKS ON INPUT DATA *************************
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

            ' set up log file
            'Code = seeStringParam(0, SEE_LOG_FILE, EventFolder & "\DEBUG_MAILER.LOG")

            'connect to server
            'The following code uses a username and password
            If Len(PortBox.Text) <> 0 Then
                Code = seeIntegerParam(0, SEE_SMTP_PORT, PortBox.Text) 'set port (note: Comcast uses 587
            End If

            'If waitSMTPCheckBox.CheckState = CheckState.Checked Then
            ' Code = seeIntegerParam(0, SEE_CONNECT_WAIT, 20000) ' maximum time allowed to complete a connection to the email server.
            'Code = seeIntegerParam(0, SEE_MAX_RESPONSE_WAIT, 20000) 'time after which a "timeout" error occurs if the server has not responded.
            'End If


            'Code = seeIntegerParam(0, SEE_SLEEP_TIME, 500) ' the time SEE sleeps when waiting on a Winsock.
            'Code = seeIntegerParam(0, SEE_ENABLE_IMAGE, 1) ' Special processing when dealing with images to allow email program to view photos
            Code = seeIntegerParam(0, SEE_ENABLE_ESMTP, 1)
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
            If SmtpErrorCode < 0 Then
                Dim SMTPerrorMessage As String
                SMTPerrorMessage = "Error obtaining a SMTP connection. Check:" _
                & vbCrLf & "1.) That your server address is correct." _
                & vbCrLf & "2.) That your username and password are correct." _
                & vbCrLf & "3.) That you have an active internet connection." _
                & vbCrLf & "4.) That your security software allows outgoing mail on port: " & PortBox.Text & "."
                CancelFlagg = "Cancel"
                Display("SMTP Error: Emailing has been stopped.")
                MsgBox(SMTPerrorMessage)
                SENDINGBUTTON.Visible = False
                StoppedButton.Visible = True
                Exit Sub
            Else
                SendEmailCode = seeSendEmail(0, email, NullString, NullString, textBox_SubjectLine.Text, "@" & textBox_messagefile.Text, filenamestring)
            End If 'MsgBox("seeSendEmail Code: " & Code & "  Email: " & email)

            If SendEmailCode < 0 Then 'Code corresponding to seeSendEmail()
                SENDEMAILFLAGG = False
                'error attempting to send email
                'Call Display("***Error sending [" & filenameshort & "]: Code: " + Str(Code) & " ***" & Chr(10) & Chr(13))
                ShowErrorSendingFile(Code, "", "", StatusFile, ErrorFile)
                Display("Also, check if your security software allows outgoing mail on port: " & PortBox.Text)
                Display("") ' ads a CR+LF
                CancelFlagg = "Cancel"
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




    Private Sub MonitorFolderCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonitorFolderCheckBox.CheckedChanged
        'This subfunction watches a folder and looks for some activity. For this application, it looks for the
        'create activity. When this occurs it runs the GoButton_Click subroutine. Note: there is a problem when
        'trying to access the statusbox and other like controls via this method. It appears that those controls
        'are only accessible when the button is actually clicked. Othersie you get an illegal Cross-Thread error.
        'This was bypassed by using System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False/True switch.
        'Dim WatchFolder As New System.IO.FileSystemWatcher()
        WatchFolder.Path = Textbox_imagefolder.Text
        'WatchFolder.NotifyFilter = NotifyFilters.CreationTime
        WatchFolder.Filter = "*.jpg" 'May use if other files are created in the same folder.
        ' Add event handlers
        'AddHandler WatchFolder.Created, AddressOf GoButton_Click

        If MonitorFolderCheckBox.CheckState Then
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
        Else
            DelayLabel1.Visible = False
            DelayTextBox1.Visible = False
            AutoEmailFlagg = True
            WatchFolder.EnableRaisingEvents = False
            'StatusBox.Text = "Your image directory is NOT being monitored. Emails will NOT be automatically sent" & Chr(10) & Chr(13)
            StatusBox.Clear()
            Display("Your image directory is NOT being monitored")
            Display("Emails will NOT be automatically sent")
            'MsgBox("EPE Emailer is not monitoring your image directory. Emails will need to be manually sent")
            GoButton.Visible = True
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

    Private Sub ShowErrorSendingFile(ByVal ErrCode As Long, ByVal Filename As String, ByVal emailaddress As String, ByVal STATFILE As String, ByVal ERRFILE As String)
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
        s.WriteLine(textBox_Password.Text)
        s.WriteLine(PortBox.Text)
        s.WriteLine(DelayTextBox1.Text)
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


    Private Sub ProgDir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgDir2.Click

    End Sub

    Private Sub pause(ByVal delay As Integer)
        Dim s As Integer = Environment.TickCount
        Dim e As Integer = 0
        Do : My.Application.DoEvents()
            Threading.Thread.Sleep(1)
            e = Environment.TickCount
        Loop Until (e - s) >= delay
    End Sub

    Public Function CheckEmailConnection() As Boolean
        'Check if SMTP connection is available
        Dim SMTPOK As Boolean ' True if ok, and False if error
        Dim SmtpErrorCode As Integer
        Code = seeIntegerParam(0, SEE_ENABLE_ESMTP, 1)
        Code = seeStringParam(0, SEE_SET_SECRET, textBox_Password.Text + Chr(0))
        Code = seeStringParam(0, SEE_SET_USER, textBox_Username.Text + Chr(0))
        Code = seeDebug(0, SEE_GET_SERVER_IP, NullString, 40)
        SmtpErrorCode = seeSmtpConnect(0, textBox_MailServer.Text, "<Test>", NullString)
        If SmtpErrorCode < 0 Then
            Dim SMTPerrorMessage As String
            SMTPerrorMessage = "Error obtaining a SMTP connection. Check:" _
            & vbCrLf & "1.) That your server address is correct." _
            & vbCrLf & "2.) That your username and password are correct." _
            & vbCrLf & "3.) That you have an active internet connection." _
            & vbCrLf & "4.) That your security software allows outgoing mail on port: " & PortBox.Text & "."
            CancelFlagg = "Cancel"
            Display("SMTP Error: Emailing has been stopped.")
            MsgBox(SMTPerrorMessage)
            SENDINGBUTTON.Visible = False
            StoppedButton.Visible = True
            SMTPOK = False
        Else
            SMTPOK = True
        End If
        Return SMTPOK
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
        If File.Exists(WinZProgram.StartInfo.FileName) Then
            WinZProgram.Kill()
        End If
        Me.Close()
    End Sub

End Class
