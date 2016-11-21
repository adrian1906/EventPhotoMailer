Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Collections
'Notes: 11-20 - Added the check for filenames that start with $ This is an indicator that Darkroom did 
'not have an email address attached to the file. If not moved, an error will be generated. I wrote
' code to move this to a folder called not named. This folder is in the EventFolder.
Public Class Form1
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Dim UserCompanyName As String = "My Easy Photo Inc. <myeasyphoto@comcast.com>"
    Dim CancelFlagg As String = "Run"
    Private Strt As System.Threading.Thread
    Dim GoFlagg As Boolean = True
    Dim AutoEmailFlagg As Boolean
    Dim emailstring(0) As String
    Dim filenamestring(0) As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CustomerInfo.Text = "Customized for " & UserCompanyName
        VersionLabel.Text = "Version:" & My.Application.Info.Version.ToString
        Dim DefaultFile As String = ProgDir2.Text & "\bin\defaults.txt"
        If File.Exists(DefaultFile) Then
            Dim fs As New FileStream(DefaultFile, FileMode.Open, FileAccess.Read)
            'declaring a FileStream to open the file named file.doc with access mode of reading
            Dim d As New StreamReader(fs)
            'creating a new StreamReader and passing the filestream object fs as argument
            d.BaseStream.Seek(0, SeekOrigin.Begin)
            'Seek method is used to move the cursor to different positions in a file, in this code, to 
            'the beginning

            'While d.Peek() > -1
            'peek method of StreamReader object tells how much more data is left in the file
            ProgDir2.Text = d.ReadLine()
            textBox_SubjectLine.Text = d.ReadLine()
            Textbox_imagefolder.Text = d.ReadLine()
            textBox_messagefile.Text = d.ReadLine()
            textBox_MailServer.Text = d.ReadLine()
            textBox_Username.Text = d.ReadLine()
            textBox_Password.Text = d.ReadLine()
            PortBox.Text = d.ReadLine()
            'displaying text from doc file in the RichTextBox
            'End While
            d.Close()
        End If
    End Sub
    Private Sub TextBox1_TextChanged_3(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Textbox_imagefolder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textbox_imagefolder.TextChanged

    End Sub

    Private Sub GoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoButton.Click
        SENDEMAIL2()
        MsgBox("Stop Code")
        GoFlagg = True
        Dim EventFolder As String
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
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False ' needed to allow the use of controls. Normally they cannot be accessed without setting crosstread to false.
            'MsgBox("A new file has appeared. Oh Yeah. Counter = " & ii)
            'Directory.CreateDirectory(EventFolder) (MOVED)
            CancelFlagg = "Run" ' Allows the process to run. Set to "Cancel" when Cancel button is pressed.
            If Not File.Exists(EventFolder & "\status.txt") Then
                'MsgBox("Exist = " & File.Exists(EventFolder & "\status.txt") & " Event folder: " & EventFolder)
                StatusBox.Text = "Sending emails ... "
            End If
            If MonitorFolderCheckBox.CheckState = CheckState.Checked Then
                System.Threading.Thread.Sleep(2000) 'I believe the trigger occurs when file appears but no when finished.
            End If
            If CheckBox2_emailfilename.CheckState Then ' Case for supplied list
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
                Directory.CreateDirectory(EventFolder)
                While d4.Peek() > -1
                    'MsgBox(temp2)
                    ProgressBar1.Value = 100 * loopcounter / linecounter
                    loopcounter += 1
                    EmailFileLine = d4.ReadLine()
                    temp = Split(EmailFileLine, ",")
                    If ignoreJPG.Checked Then
                        filename = temp(0) & ".jpg"
                    Else
                        filename = temp(0)
                    End If
                    email = temp(1)
                    ' Check for spaces. If found, produce message box and bypass the file
                    testspace_filename = Split(filename.ToString, " ")
                    testspace_email = Split(email.ToString, " ")
                    testspace_CSVfile = Split(EmailFilenameList.Text, " ")
                    Dim fullstring2 As String = Textbox_imagefolder.Text & "\" & filename.ToString
                    ' Check if file exists
                    If File.Exists(fullstring2) Then
                        If testspace_filename.Length > 1 Or testspace_email.Length > 1 Or testspace_CSVfile.Length > 1 Then
                            MsgBox("Filenames and emails cannot contain spaces." _
                                    & " Please check your message filename, CSV filename, image filenames and email addresses." _
                                    & filename.ToString & " was not sent")
                        Else
                            SENDEMAIL(email, filename, EventFolder, fullstring2)
                        End If
                    Else
                        MsgBox("Filename: " & fullstring2 & " does not exist. Please check the spelling.")
                    End If
                End While
                d4.Close()
            Else ' Case for which filenames are parsed to get email addresses and filenames
                Dim str As New IO.DirectoryInfo(Textbox_imagefolder.Text)
                Dim NoEmailFilename As IO.FileInfo() = str.GetFiles("$*.jpg") 'Image with no email will just start with $

                For Each fullstring In NoEmailFilename
                    Dim NoEmailString As String = EventFolder & "\" & "NoAttachedEmailAddress"
                    If Not File.Exists(NoEmailString) Then
                        Directory.CreateDirectory(NoEmailString)
                    End If
                    File.Move(Textbox_imagefolder.Text & "\" & fullstring.Name, NoEmailString & "\" & fullstring.Name)
                    'File.Delete(Textbox_imagefolder.Text & "\" & fullstring.Name)
                Next
                Dim listing As IO.FileInfo() = str.GetFiles("*.jpg")
                Dim NumOfFiles As Double = listing.Length
                Dim filecounter As Integer = 1
                Dim ParseEmail() As String
                Dim fullstring1 As String
                Dim emailarray(0) As String
                Dim filenamearray(0) As String
                Dim jj As Integer
                Dim oldfilename As String
                Dim newfilename As String
                Directory.CreateDirectory(EventFolder)
                ' Sort Listing First
                Dim counter As Integer = 0
                Dim fullstringcounter As Integer = 0
                For Each fullstring In listing
                    fullstringcounter += 1
                    'email_filename = (fullstring.Name)
                    temp = Split(fullstring.Name, "$") 'temp(0):email temp(1):filename
                    'MsgBox("Filename = " & fullstring.Name & "   FullstringCounter = " & fullstringcounter & "  temp(0): " & temp(0) & "  temp(1): " & temp(1))
                    If temp.Length < 2 Then
                        MsgBox("Error: The filename is not delimited proplerly or the email/filename directory checkbox was not checked")
                    Else
                        'First copy images to the event folder:
                        If CheckBox2_emailfilename.CheckState <> 1 Then
                            oldfilename = Textbox_imagefolder.Text & "\" & fullstring.Name
                            newfilename = EventFolder & "\" & temp(1)
                            If File.Exists(newfilename) Then
                                File.Delete(newfilename)
                            End If
                            File.Copy(oldfilename, newfilename)
                            If CheckBox_DeleteWorkingFiles.CheckState Then
                                File.Delete(oldfilename)
                            End If
                        End If

                        'Now, split up the emails (just in case there are more than one)
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
                                End If
                                emailarray(counter + jj) = ParseEmail(jj).ToString
                                filenamearray(counter + jj) = EventFolder & "\" & temp(1).ToString
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
                            End If
                            'MsgBox("Filename = " & fullstring.Name & "   FullstringCounter = " & fullstringcounter & "  temp(0): " & temp(0) & "  temp(1): " & temp(1))
                            'MsgBox("Counter: " & counter & "  Emailarray: " & emailarray(counter) & " temp: " & temp(0) & "  " & temp(1))
                            emailarray(counter) = temp(0)
                            filenamearray(counter) = EventFolder & "\" & temp(1)
                            counter += 1
                            'Debug.WriteLine("Counter: " & counter & "  Emailarray: " & emailarray(counter))

                            'MsgBox("emailarray: " & emailarray(counter) & "  filenamearray: " & filenamearray(counter))
                            'MsgBox("Non Multiple Email: emailarray.Length = " & emailarray.Length)

                        End If
                    End If
                Next
                'MsgBox("Finished: emailarray.Length = " & emailarray.Length)
                'For counter = 0 To UBound(emailarray)
                'MsgBox("Before Calling Array.Sort()" & Chr(13) & "counter = " & counter & Chr(13) & "emailarray= " & emailarray(counter) & Chr(13) & "filenamearray= " & filenamearray(counter))
                'Next
                Array.Sort(emailarray, filenamearray) ' Sorts both email and filename.. Key is on email, filename just follows suit.
                'For counter = 0 To UBound(emailarray)
                'MsgBox("After Calling Array.sort()" & Chr(13) & "mailarray(" & counter & ")=" & emailarray(counter) & Chr(13) & "filenamearray(" & counter & ")=" & filenamearray(counter))
                'Next
                Combine(emailarray, filenamearray, emailstring, filenamestring)
                'MsgBox("emailstring.length = " & emailstring.Length)
                'For counter = 0 To emailstring.Length - 1
                'MsgBox("New Email: " & NewEmail2)
                'MsgBox("Combined Results: Counter: " & counter & "  " & emailstring(counter) & "  Filename: " & filenamestring(counter))
                'Next
                'MsgBox("Stop Now")
                Dim NumOfEmailees = emailstring.Length - 1
                For counter = 0 To NumOfEmailees
                    ProgressBar1.Value = 100 * counter / NumOfEmailees
                    ' Check for spaces in filenames and emails
                    testspace_filename = Split(filenamestring(counter), " ")
                    testspace_email = Split(emailstring(counter).ToString, " ")
                    If testspace_filename.Length > 1 Or testspace_email.Length > 1 Then
                        MsgBox("Filenames or emails cannot contain any spaces. " & " " & filenamestring(counter) & _
                               " was not sent")
                    Else
                        'fullstring1 = Textbox_imagefolder.Text & "\" & emailstring(counter)
                        fullstring1 = "NotUsed"
                        SENDEMAIL(emailstring(counter), filenamestring(counter), EventFolder, fullstring1)
                    End If
                Next
            End If
            StatusBox.Text = StatusBox.Text & "Finished....."
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
            GoFlagg = False
        End If
    End Sub



    Private Sub Combine(ByRef emailarray() As String, ByRef filenamearray() As String, ByRef emailstring() As String, ByRef filenamestring() As String)
        Dim tmpemail As String
        Dim tmpfilename As String
        Dim Flagg As Integer
        Dim j As Integer = 0
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
                    tmpfilename = tmpfilename & "," & filenamearray(counter + j)
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

    Private Sub SENDEMAIL2()
        Dim Code As Integer
        Dim Server, From, IsNull As String
        Dim ToList, CClist, BCClist As String
        Dim Subject, Message, Attachments As String
        IsNull = Chr(0)
        Server = "hoodands.ipower.com"
        From = "Adrian Hood <adrian@hoodandson.com>"
        ToList = "<adrian@hoodandson.com>"
        CClist = Chr(0)
        BCClist = Chr(0)
        Subject = "Visual Basic Test"
        Message = "Emailed from SEE4VB!"
        Attachments = "C:\EPE\ImagesToEmail\Event_12_28_2009_12_8_27\file2a.jpg"
        Code = seeAttach(1, SEE_KEY_CODE) ' keycode is 0 '
        If Code < 0 Then
            'MsgBox("Error with SEE KEY CODE")
            ' error calling seeAttach !
            '. . .
        End If
        ' connect to SMTP mail server
        Code = seeSmtpConnect(0, Server, From, From) ' chan, server, From & Reply-To addr
        If Code < 0 Then
            'MsgBox("Error with SEE KEY CODE")
            ' error calling seeSmtpConnect !
            '. . .
        End If
        Code = seeSendEmail(0, ToList, CClist, BCClist, Subject, Message, Attachments)
        If Code < 0 Then
            'MsgBox("Error with SEE KEY CODE")
            ' error calling seeSendEmail !
            '. . .
        End If
        Code = seeClose(0)
        Code = seeRelease()
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

    Private Sub textBox_messagefile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textBox_messagefile.TextChanged

    End Sub

    Private Sub textBox_MailServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textBox_MailServer.TextChanged

    End Sub

    Private Sub textBox_Username_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textBox_Username.TextChanged

    End Sub

    Private Sub textBox_Password_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textBox_Password.TextChanged

    End Sub

    Private Sub textBox_Event_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Title_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Title.Click

    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FolderBrowserDialog_image_location.HelpRequest

    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1_message_location.FileOk

    End Sub

    Private Sub label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles label3_subject.Click

    End Sub

    Private Sub TextBox1_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailFilenameList.TextChanged
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8_PD.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4_browse_PD.Click
        FolderBrowserDialog2_ProgramDirectory.ShowDialog()
        ProgDir2.Text = FolderBrowserDialog2_ProgramDirectory.SelectedPath
    End Sub

    Private Sub label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles label6_username.Click

    End Sub

    Private Sub TextBox1_TextChanged_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Credit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Credit.Click

    End Sub


    Private Sub Label7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7_port.Click

    End Sub


    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SaveAsDefaul.Click
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

    Private Sub FolderBrowserDialog2_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FolderBrowserDialog2_ProgramDirectory.HelpRequest

    End Sub

    Private Sub label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles label1_FileLocation.Click

    End Sub

    Private Sub label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles label2_message.Click

    End Sub

    Private Sub label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles label4_outgoing.Click

    End Sub

    Private Sub Label1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusLabel.Click

    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub VersionLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VersionLabel.Click

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

End Class
