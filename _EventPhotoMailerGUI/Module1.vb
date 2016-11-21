Imports System.IO
Imports System.Collections
Imports Facebook_Graph_Toolkit
Module Module1
    Dim SmtpErrorCodeGlobal As Integer
#Region "File Management"

    Public Sub ReplaceTextInFileHood(ByVal OrigFileNameWithPath As String, ByVal NewFileName As String, ByVal target As String, ByVal replacetext As String)
        File.WriteAllText(NewFileName, File.ReadAllText(OrigFileNameWithPath).Replace(target, replacetext))
    End Sub

    Public Function getJPGfiles(ByVal MAINFOLDER As String) As ArrayList
        Dim str4 As New IO.DirectoryInfo(MAINFOLDER)
        Dim NoEmailFilename As IO.FileInfo() = str4.GetFiles("*.jpg") 'Image with no email will just start with $
        Dim ImageList As ArrayList = Nothing
        For Each cc In NoEmailFilename
            ImageList.Add(cc.ToString)
        Next
        Return ImageList
    End Function

    Public Function GetCurrentJPGlist(ByVal MAINFOLDER As String) As String()
        Dim str As New IO.DirectoryInfo(MAINFOLDER)
        Dim listing As IO.FileInfo() = str.GetFiles("*.jpg")
        Dim counter As Integer = 0
        Dim CurrentJPGlist() As String = Nothing
        For Each cc In listing
            ArrayAddItemHOOD(CurrentJPGlist, cc.Name)
        Next
        Return CurrentJPGlist
    End Function

    Public Sub ArrayAddItemHOOD(ByRef AR As String(), ByVal ItemToAdd As String)
        'Used to easily redimension an array and add to it.
        'MsgBox("AR's length is: " & AR.Length)
        If AR(0) <> Nothing Then
            'If AR.Length > 1 Then
            ReDim Preserve AR(AR.Length)
        End If
        AR(AR.Length - 1) = ItemToAdd
    End Sub
    Public Function GetFileContents(ByVal FullPath As String, ByVal CompanyName As String, Optional ByRef ErrInfo As String = "") As String
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

    Public Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String, Optional ByVal ErrInfo As String = "") As Boolean
        'Dim Contents As String
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
            Return False
        End Try
        Return bAns
    End Function

    Public Sub ReplaceTextInFileHood(ByVal OrigFileNameWithPath As String, ByVal NewFileName As String, ByVal target As String, ByVal replacetext As String)
        'Dim tmp() As String = Split(TextBox1.Text, ".")
        'Dim newfilename As String = tmp(0) & "revised.txt"
        File.WriteAllText(NewFileName, File.ReadAllText(OrigFileNameWithPath).Replace(target, replacetext))
    End Sub

#End Region

#Region "Email Stuff"
    Public Function CheckEmailValidityInDirectory(ByVal emailaddress As String) As String
        'This function chack the validity of an email address. It first checks for the @ sign. Then
        Dim temp() As String
        temp = Split(emailaddress, "@") 'filenamestring = temp(0) email = temp(1)
        If temp.Length = 1 Then
            Return "Reject"
        End If

        Dim temp2() As String = Split(temp(0), " ")
        If temp2.Length > 1 Then
            Return "Reject"
        End If

        Dim temp3() As String = Split(temp(1), " ")
        If temp3.Length > 1 Then
            Return "Reject"
        End If
        Return "OK"
    End Function

    Function IsValidEmail(ByVal sEMail As String) As Boolean
        ' original by Brad Murray
        ' optimized by Rob Hofker, email: rob@eurocamp.nl, 
        '23 august 2000

        Dim sInvalidChars As String
        Dim bTemp As Boolean
        Dim i As Integer
        Dim sTemp As String

        ' Disallowed characters
        sInvalidChars = "!#$%^&*()=+{}[]|\;:'/?>,< "

        ' Check that there is at least one '@'
        bTemp = InStr(sEMail, "@") <= 0
        If bTemp Then GoTo exit_function

        ' Check that there is at least one '.'
        bTemp = InStr(sEMail, ".") <= 0
        If bTemp Then GoTo exit_function

        ' and that the length is at least six (a@a.ca)
        bTemp = Len(sEMail) < 6
        If bTemp Then GoTo exit_function

        ' Check that there is only one '@'
        i = InStr(sEMail, "@")
        sTemp = Mid(sEMail, i + 1)
        bTemp = InStr(sTemp, "@") > 0

        If bTemp Then GoTo exit_function
        'extra checks
        ' AFTER '@' space is not allowed
        bTemp = InStr(sTemp, " ") > 0
        If bTemp Then GoTo exit_function

        ' Check that there is one dot AFTER '@'
        bTemp = InStr(sTemp, ".") = 0
        If bTemp Then GoTo exit_function

        ' Check if there's a quote (")
        bTemp = InStr(sEMail, Chr(34)) > 0
        If bTemp Then GoTo exit_function


        ' Check if there's any other disallowed chars
        ' optimize a little if sEmail longer than sInvalidChars
        ' check the other way around
        If Len(sEMail) > Len(sInvalidChars) Then
            For i = 1 To Len(sInvalidChars)
                If InStr(sEMail, Mid(sInvalidChars, i, 1)) > 0 _
                      Then bTemp = True
                If bTemp Then Exit For
            Next
        Else
            For i = 1 To Len(sEMail)
                If InStr(sInvalidChars, Mid(sEMail, i, 1)) > 0 _
                       Then bTemp = True
                If bTemp Then Exit For
            Next
        End If
        If bTemp Then GoTo exit_function

        ' extra check
        ' no two consecutive dots
        bTemp = InStr(sEMail, "..") > 0
        If bTemp Then GoTo exit_function

exit_function:
        ' if any of the above are true, invalid e-mail
        IsValidEmail = Not bTemp
    End Function

    Public Sub AccessPOP3()
        'Code = seeIntegerParam(0, SEE_SET_RAWFILE_PREFIX, Asc("_"))
        'Code = seeIntegerParam(0, SEE_ENABLE_APOP, 1) ' note: may not recognize apop.
        'Code = seePop3Connect(0, IncomingServerTextBox.Text, textBox_Username.Text, textBox_Password.Text) ' Used to access pop3 (if pop3 before smtp is needed)
        '' get server IP address
        'Dim Temp As String = Space(50)
        'Code = seeDebug(0, SEE_GET_SERVER_IP, Temp, 50)
        ''Display("Connected to IP " + Microsoft.VisualBasic.Left(Temp, Code))

        '' get # messages waiting

        'Dim NbrMsg As Integer = seeGetEmailCount(0)
        'If NbrMsg < 0 Then
        '    Code = seeClose(0)
        '    Exit Sub
        'End If
        'Dim FileName = "Email" & LTrim(Str(1)) + ".txt"
        'Display("--- Downloading Message " + Str(1) + " as " + FileName)
        'FileName = FileName & Chr(0)

        'Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Code = seeGetEmailFile(0, 1, FileName, Textbox_imagefolder.Text, Textbox_imagefolder.Text)
        'SmtpErrorCodeGlobal = seeSmtpConnect(0, textBox_MailServer.Text, "<Test>", NullString)
        'seeClose(0)
    End Sub

#End Region


#Region "Threading Stuff"


    Public Function IsProcessRunning(ByVal name As String) As Boolean
        'here we're going to get a list of all running processes on
        'the computer
        'Dim processname As String
        Dim nn As Integer = 0
        Dim ProcessList As New ArrayList
        For Each clsProcess As Process In Process.GetProcesses()
            ' processname = clsProcess.MainModule.ModuleName.ToString
            ProcessList.Add(clsProcess.ProcessName)
        Next
        ProcessList.Sort()
        If ProcessList.BinarySearch(name) < 0 Then
            Return False
        Else
            Return True
        End If
        'For nn = 0 To ProcessList.
        '    For Each clsProcess As Process In Process.GetProcesses()
        '    'processnames(nn) = clsProcess.ProcessName.
        '    'nn = nn + 1
        '    'System.Console.Write(clsProcess.ProcessName)
        '    If clsProcess.ProcessName.StartsWith(name) Then
        '        'process found so it's running so return true
        '        Return True
        '    End If
        'Next
        ''MsgBox(processnames)
        ''process not found, return false
        'Return False
    End Function

    Public Sub ListProcesses()
        Dim ProcessList As System.Diagnostics.Process()
        ProcessList = System.Diagnostics.Process.GetProcesses()
        Dim Proc As System.Diagnostics.Process
        For Each Proc In ProcessList
            Console.WriteLine("Name {0} ID {1} " & Proc.ProcessName & "  " & Proc.Id)
        Next
    End Sub



#End Region


#Region "Status Update Stuff"
    Public Sub StatusIndicatorHood()
        ' Purpose is to create running dots on a thread
        ' currently not working.
        Dim maxduration As Double = 10 ' seconds
        Dim mydate2 As Date = Now
        Dim time1 As Integer = mydate2.Second
        Dim timecheck As Double = 0
        Dim time2 As Integer = time1
        Dim OutputText As String = Nothing
        ' The next line will wait until chkSMTP comes back true or Timeout is reached. This allows the execution to occur ASAP.
        While SmtpErrorCodeGlobal = 999 And timecheck < maxduration ' Timeout set to 10 seconds.
            mydate2 = Now
            timecheck = Math.Abs(mydate2.Second - modhood(time1 + maxduration, 60 + maxduration)) ' tacked on maxduration to eliminate premature termination if seconds in the 56-59 range.
            'StatusBox.Clear()
            'Display("Searching for SMTP server: " & timecheck & "/" & maxduration)
            pause(1000)
            OutputText = "Searching for SMTP server: " & timecheck & "/" & maxduration
            'StatusBox.Text = OutputText
        End While
    End Sub
#End Region
#Region "Math"
    Public Function modhood(ByVal value As Double, ByVal max As Double) As Double
        Dim n As Integer
        Dim d As Double = Math.Floor(value / max)
        n = CType(d, Integer) ' convert value to integer
        Return value - n * max
    End Function
#End Region

    Public Sub pause(ByVal delay As Integer)
        Dim s As Integer = Environment.TickCount
        Dim e As Integer = 0
        Do : My.Application.DoEvents()
            Threading.Thread.Sleep(1)
            e = Environment.TickCount
        Loop Until (e - s) >= delay
    End Sub

#Region "Facebook Stuff"

    Dim MyWebBrowser As New WebBrowser
    Public Function Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) As GraphApi.Api
        ' Adrian ID:        https://graph.gacebook.com/601201034
        ' Hood and Sons ID: https://graph.facebook.com/152049444821811
        ' App Name:	        Event Photo Emailer
        ' App URL:	        www.hoodandson.com/EPE/
        ' App ID:	        197403413634224
        ' App Secret:	    47219a746539dd80c785138e4f3bfcfd

        ' Get Access Token

        Dim AppID As String = "197403413634224" ' Event Photo Emailer App ID
        Dim AppSecret As String = "47219a746539dd80c785138e4f3bfcfd"
        Dim WindowLocationString As String = "https://www.facebook.com/connect/login_success.html"
        Dim URL As String = "https://www.facebook.com/dialog/oauth?client_id=" & _
                     AppID + "&redirect_uri=" + WindowLocationString +
                     "&response_type=token"
        Dim MyAppString2 = "https://www.facebook.com/dialog/oauth?client_id=" & AppID & _
                            "&redirect_uri=https://www.facebook.com/connect/login_success.html" & _
                            "&scope=publish_stream,offline_access&response_type=token" 'offline_access eliminates need to keep loggin in
        MyWebBrowser.Navigate(MyAppString2)
        WebWait()
        ' Part 2: Automatically input username and password
        Dim theElementCollection As HtmlElementCollection = MyWebBrowser.Document.GetElementsByTagName("input")
        For Each curElement As HtmlElement In theElementCollection
            Dim controlName As String = curElement.GetAttribute("name").ToString

            If controlName = "email" Then
                curElement.SetAttribute("Value", "adrian1906@yahoo.com")
            ElseIf controlName = "pass" Then
                curElement.SetAttribute("Value", "adrian6")
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
        WebWait()
        Dim theWElementCollection2 As HtmlElementCollection = MyWebBrowser.Document.GetElementsByTagName("input")
        For Each curElement As HtmlElement In theWElementCollection2
            If curElement.GetAttribute("value").Equals("Allow") Then
                curElement.InvokeMember("click")
                ' javascript has a click method for we need to invoke on the current submit button element.
            End If
        Next
        WebWait()
        Dim AccessURI As String = MyWebBrowser.Url.ToString
        Dim MyURI() As String
        MyURI = Split(AccessURI, "=")
        Dim MyAccessToken As String = MyURI(1)
        MyURI = Split(MyAccessToken, "&")
        MyAccessToken = MyURI(0)
        WebWait()

        ' Get list of Friends
        Dim GRAPHAPI As String = "https://graph.facebook.com/" & "601201034/"
        'Dim MyFriend As String = GRAPHAPI & "friends?access_token=" & MyAccessToken
        'Dim MyAlbums As String = GRAPHAPI & "picture"
        'Dim testpost As String = GRAPHAPI & "feed"
        'MyWebBrowser.Navigate(MyFriend)
        Dim myAPI As New Api(MyAccessToken)
        'Dim B As System.Drawing.Bitmap = New System.Drawing.Bitmap(MyPhoto)
        'Create Album
        'Dim CreateAlbumString As String = "http://graph.facebook.com/PROFILE_ID/albums"
        'myAPI.PublishPhoto(B, "My 1st Facebook App Just Might Be Working!")
        'MsgBox(myAPI.ToString)
        Return myAPI
    End Function

    Public Sub WebWait()
        Do While Not MyWebBrowser.ReadyState = WebBrowserReadyState.Complete
            'MsgBox("Still Busy")
            pause(1000)
        Loop
    End Sub

#End Region


End Module
