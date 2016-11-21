﻿Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Collections
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
'and the limitations console batch programming.
Public Class Form1
    Dim CompanyEmail As String = "<info@hoodandson.com>" ' Email program needs <>
    Dim UserCompanyName As String = "Hood & Son Photography" & " " & CompanyEmail
    Dim CancelFlagg As String = "Run" ' Needed to be able to cancel the emailing program
    Private Strt As System.Threading.Thread
    Dim GoFlagg As Boolean = True
    Dim AutoEmailFlagg As Boolean
    Dim emailstring(0) As String
    Dim filenamestring(0) As String
    Dim emailshortstring(0) As String
    Dim filenameshortstring(0) As String
    'SetTextCallback is a trick to allow a control's subroutine to be called without
    'accessing it from another control. This is used to run the Go_Button routine using
    'a subroutine that monitors a specified folder
    Delegate Sub SetTextCallback(ByVal [text] As String)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Initialization Code For Emailer Library *********
        Dim Code As Integer
        'Dim Version As Integer
        'Dim S1 As String
        'Dim S2 As String
        'Dim S3 As String
        ' attach SEE (seeAttach must be 1st SEE function called)
        ' This program checks to see if code and .dll file matches
        Code = seeAttach(1, SEE_KEY_CODE)
        If Code < 0 Then
            Display("ERROR " + Str(Code) + ": Cannot attach. Check SEE_KEY_CODE.")
            End
        End If
        ' *************************************************
        ' set up log file
        Code = seeStringParam(0, SEE_LOG_FILE, "c:\epe\MAILER.LOG")
        ' display version
        '        Version = seeStatistics(0, SEE_GET_VERSION)
        '        S1 = "SMTP/SMTP Email Engine Version "
        '        S2 = Hex$(Version)
        '        S3 = Mid$(S2, 1, 1) + "." + Mid$(S2, 2, 1) + "." + Mid$(S2, 3, 1)
        '        Display(S1 + S3)
        'Display("Ready to send email.")
        ' *************************************************

        CustomerInfo.Text = "Customized for " & UserCompanyName
        VersionLabel.Text = "Version:" & My.Application.Info.Version.ToString ' changed using Project/Properties/AssemblyInfo
        Dim DefaultFile As String = ProgDir2.Text & "\bin\defaults.txt" ' Location of default field settings
        If File.Exists(DefaultFile) Then
            Dim fs As New FileStream(DefaultFile, FileMode.Open, FileAccess.Read)
            'declaring a FileStream to open the file named file.doc with access mode of reading
            Dim d As New StreamReader(fs)
            'creating a new StreamReader and passing the filestream object fs as argument
            d.BaseStream.Seek(0, SeekOrigin.Begin)
            'Seek method is used to move the cursor to different positions in a file, in this code, to 
            'the beginning
            ProgDir2.Text = d.ReadLine()
            textBox_SubjectLine.Text = d.ReadLine()
            Textbox_imagefolder.Text = d.ReadLine()
            textBox_messagefile.Text = d.ReadLine()
            textBox_MailServer.Text = d.ReadLine()
            textBox_Username.Text = d.ReadLine()
            textBox_Password.Text = d.ReadLine()
            PortBox.Text = d.ReadLine()
            d.Close()
        End If
    End Sub

    Private Sub Button_SaveAsDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SaveAsDefault.Click
        Dim DefaultFile As String = ProgDir2.Text & "\bin\defaults.txt"
        Dim fs As New FileStream(DefaultFile, FileMode.Create, FileAccess.Write) 'Set to create so old file will be totally rewritten
        Dim s As New StreamWriter(fs)
        'creating a new StreamWriter and passing the filestream object fs as argument
        s.BaseStream.Seek(0, SeekOrigin.End)
        'the seek method is used to move the cursor to next position to avoid text being
        'overwritten
        s.WriteLine(ProgDir2.Text)
        s.WriteLine(textBox_SubjectLine.Text)
        s.WriteLine(Textbox_imagefolder.Text)
        s.WriteLine(textBox_messagefile.Text)
        s.WriteLine(textBox_MailServer.Text)
        s.WriteLine(textBox_Username.Text)
        s.WriteLine(textBox_Password.Text)
        s.WriteLine(PortBox.Text)
        s.Close()
        'closing the file
    End Sub

    Private Sub GoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoButton.Click
        Dim EventFolder As String
        GoFlagg = True ' Used to Cancel emailing. If the Cancel button is hit after the go button (or automatic email)
        ' Then GoFlagg will be set to False and later code will cease to run.
        If GoFlagg = True Then 'Global variable use to ensure this call to GoButton is only done once.
            Dim MyDate As Date = Now
            Dim MyDateString As String = MyDate.Month & "_" & MyDate.Day & "_" & MyDate.Year & "_" & MyDate.Hour & "_" & MyDate.Minute & "_" & MyDate.Second
            If AutoEmailFlagg = True Then
                EventFolder = Textbox_imagefolder.Text & "\Event_" & MyDate.Month & "_" & MyDate.Day & "_" & MyDate.Year
            Else
                EventFolder = Textbox_imagefolder.Text & "\" & "Event_" & MyDateString
            End If
            Dim temp() As String
            Dim temp2 As String
            Dim email As String
            Dim filename As String
            Dim testspace_filename() As String
            Dim testspace_email() As String
            Dim testspace_CSVfile() As String
            Dim fullstring As IO.FileInfo
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False ' needed to allow the use of controls. 
            'Normally they cannot be accessed without setting crosstread to false. This is set back to true at the end.
            'MsgBox("A new file has appeared. Counter = " & ii)
            CancelFlagg = "Run" ' Allows the process to run. Set to "Cancel" when Cancel button is pressed.
            If Not File.Exists(EventFolder & "\status.txt") Then
                'MsgBox("Exist = " & File.Exists(EventFolder & "\status.txt") & " Event folder: " & EventFolder)
                Display("Sending emails ... ")
            End If
            If MonitorFolderCheckBox.CheckState = CheckState.Checked Then
                System.Threading.Thread.Sleep(2000) 'I believe the trigger occurs when file appears but not when finished.
                ' A delay is needed for the file to be created and ready to send. This value is dependent on the computer
                ' and the filesize of the image to be created. The default is 2 seconds. Later, I may include a form
                ' field that will allow this value to be entered.
            End If
            ' ***********  USER SUPPLIED FILE/EMAIL DIRECTORY ******************
            ' ******************************************************************
            ' ******************************************************************
            If CheckBox2_emailfilename.CheckState Then ' Case for supplied list
                If Not File.Exists(EmailFilenameList.Text) Then
                    Display("Error: Directory File not provided")
                    Display("Please provide the name of your directory file")
                    GoFlagg = False
                Else
                    Dim fs3 As New FileStream(EmailFilenameList.Text, FileMode.Open, FileAccess.Read)
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
                    Dim fs4 As New FileStream(EmailFilenameList.Text, FileMode.Open, FileAccess.Read)
                    Dim d4 As New StreamReader(fs4)
                    d4.BaseStream.Seek(0, SeekOrigin.Begin) ' start over
                    Dim loopcounter As Integer = 1
                    Directory.CreateDirectory(EventFolder) ' This file is used to save the status.txt file and others.
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
                    While d4.Peek() > -1
                        EmailFileLine = d4.ReadLine()
                        temp = Split(EmailFileLine, ",")
                        If ignoreJPG.Checked Then
                            filename = temp(0) & ".jpg" ' Case for Cedric of Washington who wants to avoid typing .jpg
                        Else
                            filename = temp(0)
                        End If
                        email = temp(1)
                        ' Check for spaces. If found, produce message box and bypass the file
                        testspace_filename = Split(filename.ToString, " ")
                        testspace_email = Split(email.ToString, " ")
                        testspace_CSVfile = Split(EmailFilenameList.Text, " ")
                        Dim fullstring2 As String = Textbox_imagefolder.Text & "\" & filename.ToString
                        ' Check if file exists. Could be descrepency between filename in directory and actual filename
                        If File.Exists(fullstring2) Then
                            If testspace_filename.Length > 1 Or testspace_email.Length > 1 Or testspace_CSVfile.Length > 1 Then
                                MsgBox("Filenames and emails cannot contain spaces." _
                                        & " Please check your message filename, CSV filename, image filenames and email addresses." _
                                        & filename.ToString & " was not sent")
                            Else
                                'SENDEMAIL(email, filename, EventFolder, fullstring2)
                                SENDEMAIL2(email, Textbox_imagefolder.Text & "\" & filename, EventFolder, filename)
                            End If
                        Else
                            MsgBox("Filename: " & fullstring2 & " does not exist. Please check the spelling.")
                        End If
                        If MonitorFolderCheckBox.CheckState <> CheckState.Checked Then
                            ProgressBar1.Value = 100 * loopcounter / linecounter
                        End If
                        loopcounter += 1
                    End While
                    d4.Close()
                End If
                ' ***********  PARSED FILENAMES DIRECTORY **************************
                ' ******************************************************************
                ' ******************************************************************
            Else ' Case for which filenames are parsed to get email addresses and filenames
                Dim str As New IO.DirectoryInfo(Textbox_imagefolder.Text)
                Dim NoEmailFilename As IO.FileInfo() = str.GetFiles("$*.jpg") 'Image with no email will just start with $
                For Each fullstring In NoEmailFilename
                    Dim NoEmailString As String = EventFolder & "\" & "NoAttachedEmailAddress"
                    If Not File.Exists(NoEmailString) Then
                        Directory.CreateDirectory(NoEmailString)
                    End If
                    File.Move(Textbox_imagefolder.Text & "\" & fullstring.Name, NoEmailString & "\" & fullstring.Name)
                Next
                Dim listing As IO.FileInfo() = str.GetFiles("*.jpg") ' Currently, only .jpg files are emailed
                Dim NumOfFiles As Double = listing.Length
                Dim filecounter As Integer = 1
                Dim ParseEmail() As String
                Dim emailarray(0) As String ' Used to sort and gather files
                Dim filenamearray(0) As String ' Used to sort and gather files
                Dim jj As Integer
                Dim oldfilename As String
                Dim newfilename As String
                Dim filenameshort(0) As String
                Directory.CreateDirectory(EventFolder)
                ' Sort Listing First
                Dim counter As Integer = 0
                Dim fullstringcounter As Integer = 0
                For Each fullstring In listing
                    fullstringcounter += 1
                    temp = Split(fullstring.Name, "$") 'temp(0):email temp(1):filename
                    'MsgBox("Filename = " & fullstring.Name & "   FullstringCounter = " & fullstringcounter & "  temp(0): " & temp(0) & "  temp(1): " & temp(1))
                    If temp.Length < 2 Then
                        MsgBox("Error: The filename is not delimited proplerly or the email/filename directory checkbox was not checked")
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
                        If CheckBox_DeleteWorkingFiles.CheckState Then
                            File.Delete(oldfilename)
                        End If

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
                                filenamearray(counter + jj) = EventFolder & "\" & filenameshort(counter + jj)
                                'MsgBox("emailarray: " & emailarray(counter + jj) & "  filenamearray: " & filenamearray(counter + jj))
                                'Debug.WriteLine("Counter: " & counter + jj & "  Emailarray: " & emailarray(counter + jj))
                                'MsgBox("Counter: " & counter & " jj: " & jj & "  Emailarray: " & emailarray(counter + jj))
                                'MsgBox("jj= " & jj & " counter = " & counter & " emailarray.Length = " & emailarray.Length)
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
                            filenamearray(counter) = EventFolder & "\" & filenameshort(counter) ' filenamearray gives the absolute path
                            counter += 1
                            'Debug.WriteLine("Counter: " & counter & "  Emailarray: " & emailarray(counter))

                            'MsgBox("emailarray: " & emailarray(counter) & "  filenamearray: " & filenamearray(counter))
                            'MsgBox("Non Multiple Email: emailarray.Length = " & emailarray.Length)

                        End If
                    End If
                Next
                Array.Sort(emailarray, filenamearray) ' Sorts both email and filename.. Key is on email, filename just follows suit.
                Array.Sort(emailarray, filenameshort) ' Sorts both email and short filename
                Combine(emailarray, filenamearray, emailstring, filenamestring)
                'MsgBox("emailstring has length " & emailstring.Length)
                Combine(emailarray, filenameshort, emailshortstring, filenameshortstring)
                Dim NumOfEmailees = emailstring.Length - 1
                'MsgBox("NumOfEmailees = " & NumOfEmailees)
                '                For counter = 0 To NumOfEmailees
                '                    MsgBox("Email: " & emailstring(counter) & " filenamestring: " & filenamestring(counter))
                '                Next
                'MsgBox("Stop")
                For counter = 0 To NumOfEmailees

                    ' Check for spaces in filenames and emails
                    testspace_filename = Split(filenamestring(counter), " ")
                    testspace_email = Split(emailstring(counter), " ")
                    If testspace_filename.Length > 1 Or testspace_email.Length > 1 Then
                        MsgBox("Filenames or emails cannot contain any spaces. " & " " & filenamestring(counter) & _
                               " was not sent")
                    Else
                        'SENDEMAIL(emailstring(counter), filenamestring(counter), EventFolder, fullstring1)
                        'MsgBox("Email: " & emailstring(counter) & " filenamestring: " & filenamestring(counter) & " filenameshort: " & filenameshortstring(counter))
                        SENDEMAIL2(emailstring(counter), filenamestring(counter), EventFolder, filenameshortstring(counter))
                    End If
                    If MonitorFolderCheckBox.CheckState <> CheckState.Checked Then
                        ProgressBar1.Value = 100 * counter / NumOfEmailees
                    End If
                Next
            End If
            If GoFlagg = True Then
                StatusBox.Text = StatusBox.Text & "Finished....."
            End If
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
            GoFlagg = False
        End If
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

    Private Sub SENDEMAIL(ByVal email As String, ByVal filename As String, ByVal EventFolder As String, _
                          ByVal FString As String)
        Dim SubLine As String = textBox_SubjectLine.Text
        Dim ImFold As String = " " & Textbox_imagefolder.Text
        Dim MessFile As String = " " & textBox_messagefile.Text
        Dim UseName As String = " " & textBox_Username.Text
        Dim Pass As String = " " & textBox_Password.Text
        Dim Mserv As String = " " & textBox_MailServer.Text & ":" & PortBox.Text
        Dim DosQuote As String = Chr(92) + Chr(34)
        Dim Runfile As String
        Dim Arguments As String
        Dim ProcessProperties As New ProcessStartInfo
        Dim myProcess As Process
        Dim i As Integer
        Dim filecounter As Integer = 1
        ' *****************************************************
        'If CancelFlagg <> "Cancel" Then
        '*******************
        '*******************
        ' Ok, this is where we are..
        ' The emails and filenames have been parsed and what is sent to 'SendEmail' is
        ' adrian@hoodandson.com: file1.jpg,file2.jpg,file3.jpg   info@hoodandson.com: file1.jpg
        ' What needs to occur is that 1.) the filenames are stripped of email addresses and sent to the
        ' Event folder. This needs to be done at the initial parsing stage so that in this 'SendEmail'
        ' stage, all that needs to happen is the issuance of the command to send to 'emailaddress' the 'filenamestring'
        If CancelFlagg <> "Cancel" Then
            Runfile = ProgDir2.Text & "\bin\EPEsend.exe " ' Need space
            i = 0
            While CancelFlagg <> "Cancel"
                If CheckBox2_emailfilename.CheckState Then ' If using pre-made list, then all info is saved in target folder.
                    Arguments = email & " " & DosQuote & UserCompanyName & DosQuote & "  " & DosQuote & SubLine _
                    & DosQuote & " " & Mserv & " " & filename & " " & UseName & " " & Pass & " " & MessFile & " " & EventFolder & " " & ImFold
                Else
                    'Arguments = email & " " & DosQuote & UserCompanyName & DosQuote & "  " & DosQuote & SubLine _
                    ' & DosQuote & " " & Mserv & " " & filename & " " & UseName & " " & Pass & " " & MessFile & " " & EventFolder & " " & EventFolder
                    Arguments = email & " " & DosQuote & UserCompanyName & DosQuote & "  " & DosQuote & SubLine _
                    & DosQuote & " " & Mserv & " " & DosQuote & filename & DosQuote & " " & UseName & " " & Pass & " " & MessFile & " " & EventFolder & " " & EventFolder

                End If
                MsgBox(Arguments)
                If Dir(Runfile) <> "" Then
                    ProcessProperties.FileName = Runfile
                    ProcessProperties.Arguments = Arguments
                    ProcessProperties.WindowStyle = ProcessWindowStyle.Maximized
                    myProcess = Process.Start(ProcessProperties)
                    myProcess.WaitForExit()
                    System.Threading.Thread.Sleep(250) ' Used to be able to check the cancel button
                Else
                    MsgBox("Unable to locate a file needed to run. Please make sure your program directory is correct")
                End If
                If CancelFlagg <> "Cancel" Then 'Its possible that cancel is pressed while console has the process
                    'Doing a check again will have the program terminate properly.
                    StatusBox.Text = File.ReadAllText(EventFolder & "\status.txt")
                    i += 1
                Else
                    MsgBox("The operation has been cancelled")
                    StatusBox.Text = StatusBox.Text & "Aborted....."
                End If
            End While
        End If
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
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then CheckBox_DeleteWorkingFiles.Visible = False Else CheckBox_DeleteWorkingFiles.Visible = True
        If CheckBox2_emailfilename.CheckState = CheckState.Checked Then MonitorFolderCheckBox.Visible = False Else MonitorFolderCheckBox.Visible = True
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


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4_browse_PD.Click
        FolderBrowserDialog2_ProgramDirectory.ShowDialog()
        ProgDir2.Text = FolderBrowserDialog2_ProgramDirectory.SelectedPath
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SaveAsDefault.Click
        Dim DefaultFile As String = ProgDir2.Text & "\bin\defaults.txt"
        Dim fs As New FileStream(DefaultFile, FileMode.Create, FileAccess.Write)
        Dim s As New StreamWriter(fs)
        'creating a new StreamWriter and passing the filestream object fs as argument
        s.BaseStream.Seek(0, SeekOrigin.End)
        'the seek method is used to move the cursor to next position to avoid text to be
        'overwritten
        s.WriteLine(ProgDir2.Text)
        s.WriteLine(textBox_SubjectLine.Text)
        s.WriteLine(Textbox_imagefolder.Text)
        s.WriteLine(textBox_messagefile.Text)
        s.WriteLine(textBox_MailServer.Text)
        s.WriteLine(textBox_Username.Text)
        s.WriteLine(textBox_Password.Text)
        s.WriteLine(PortBox.Text)
        s.Close()
        'closing the file
    End Sub

    Private Sub CancelButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton1.Click
        CancelFlagg = "Cancel"
    End Sub

    Private Sub MonitorFolderCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonitorFolderCheckBox.CheckedChanged
        'This subfunction watches a folder and looks for some activity. For this application, it looks for the
        'create activity. When this occurs it runs the GoButton_Click subroutine. Note: there is a problem when
        'trying to access the statusbox and other like controls via this method. It appears that those controls
        'are only accessible when the button is actually clicked. Othersie you get an illegal Cross-Thread error.
        'This was bypassed by using System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False/True switch.
        Dim WatchFolder As New System.IO.FileSystemWatcher()
        WatchFolder.Path = Textbox_imagefolder.Text
        'WatchFolder.NotifyFilter = NotifyFilters.CreationTime
        'WatchFolder.Filter = "*.jpg" 'May use if other files are created in the same folder.
        ' Add event handlers
        AddHandler WatchFolder.Created, AddressOf GoButton_Click

        If MonitorFolderCheckBox.CheckState Then
            'GoFlagg = True
            'MsgBox("GoFlagg = " & GoFlagg.ToString)
            ' The wait command will give it time to finish.
            AutoEmailFlagg = True
            CheckBox_DeleteWorkingFiles.CheckState = 1 ' Set to delete file to make sure the file is not 'seen' again.
            StatusBox.Text = "Your image directory is being monitored. Emails will be automatically sent"
            'MsgBox("EPE Emailer will now monitor your image directory. Emails will be automatically sent")
            WatchFolder.EnableRaisingEvents = True
        Else
            AutoEmailFlagg = True
            WatchFolder.EnableRaisingEvents = False
            StatusBox.Text = "Your image directory is NOT being monitored. Emails will NOT be automatically sent"
            'MsgBox("EPE Emailer is not monitoring your image directory. Emails will need to be manually sent")

        End If
    End Sub

    Private Sub Display(ByVal X As String)
        'Chr(10) is linefeed and Chr(13) is Carriage Return.
        StatusBox.AppendText(X + Chr(13) + Chr(10))
    End Sub

    Private Sub ShowError(ByVal ErrCode As Long)
        Dim Length As Integer
        Dim Buffer As String
        Buffer = Space(512)
        Length = seeErrorText(0, ErrCode, Buffer, Buffer.Length)
        Call Display(Microsoft.VisualBasic.Left(Buffer, Buffer.Length))
    End Sub

    Private Sub SENDEMAIL2(ByVal email As String, ByVal filenamestring As String, ByVal EventFolder As String, ByVal filenameshort As String)
        If CancelFlagg <> "Cancel" Then
            Dim NullString As String = Chr(0)
            Dim Code As Integer
            'check that SMTP server name has been specified

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

            If Len(email) = 0 Then
                Display("Missing 'Email To'")
                Exit Sub
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
            Code = seeStringParam(0, SEE_SET_SECRET, textBox_Password.Text + Chr(0))
            Code = seeStringParam(0, SEE_SET_USER, textBox_Username.Text + Chr(0))
            'Display("Connecting to SMTP server: " + textBox_MailServer.Text)
            Code = seeSmtpConnect(0, textBox_MailServer.Text, UserCompanyName, NullString)
            If Code < 0 Then
                'error attempting to connect
                Call ShowError(Code)
                Display("Emailing has been aborted. Please check your mailserver parameters")
                Exit Sub
            End If

            Dim Temp As String = Chr(0)
            Code = seeDebug(0, SEE_GET_SERVER_IP, Temp, 40)
            ' Note: the @ symbol is used to tell the emailer program to used the contents of the message file
            Code = seeSendEmail(0, email, NullString, NullString, textBox_SubjectLine.Text, "@" & textBox_messagefile.Text, filenamestring)
            If Code < 0 Then
                'error attempting to send email
                Call Display("Error " + Str(Code) + " sending mail.")
                Call ShowError(Code)
                Display(filenameshort & " was not sent to " & email)
                Code = seeClose(0)
                Code = seeRelease()
                'Exit Sub 'Choose not to abort emailing but to instead just not send the file in question
            Else
                Display("[" & filenameshort & "]" & " was successfully sent to " & email)
                Dim StatusFile As String = EventFolder & "\status.txt"
                Dim DirectoryFile As String = EventFolder & "\directory.csv"
                Dim fs As New FileStream(StatusFile, FileMode.Append, FileAccess.Write)
                Dim fs2 As New FileStream(DirectoryFile, FileMode.Append, FileAccess.Write)
                If File.Exists(StatusFile) Then
                    Dim s As New StreamWriter(fs)
                    s.WriteLine("[" & filenameshort & "]" & " was successfully sent to " & email)
                    s.Close()
                    If MonitorFolderCheckBox.CheckState <> CheckState.Checked Then ' No need to create a directory if one already exists
                        Dim s2 As New StreamWriter(fs2)
                        s2.WriteLine(filenameshort & "," & email) ' Create comma separated file
                        s2.Close()
                    End If
                End If

                'Dim s As New StreamWriter(fs)
                'creating a new StreamWriter and passing the filestream object fs as argument
                's.BaseStream.Seek(0, SeekOrigin.End)
                'the seek method is used to move the cursor to next position to avoid text to be
                'overwritten
                ' s.WriteLine(filenameshort & " was successfully sent to " & email)
                's.Close()
            End If
            'Display("Email has been sent, closing connection.")
            Code = seeClose(0)
        End If
    End Sub

End Class
