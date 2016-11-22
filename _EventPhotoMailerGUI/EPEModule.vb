Imports System.IO
Imports System.Collections
Imports Facebook_Graph_Toolkit
Imports System.Web
Imports System.Text
Imports System.Net
Imports JSON
Imports System.Xml
Imports System.Management

Module Module1
    Dim SmtpErrorCodeGlobal As Integer
    Structure DEFAULTDATA
        Dim CompanyName As String
        Dim CompanyEmail As String
        Dim DefaultFilename As String
        Dim SubjectLine As String
        Dim ImageFolder As String
        Dim MessageFile As String
        Dim MailServer As String
        Dim UserName As String
        Dim PWDEncrypt As String
        Dim Port As String
        Dim TimeInterval As String
        Dim EmailMasterListName As String
        Dim UseMasterListBool As String
        Dim UseAdLabelBool As String
        Dim ConfimEmailBool As String
        Dim CombineEmailsBool As String
        Dim UseSSLBool As String
        Dim CheckInternetConnectionBool As String
        Dim PromptForEmailDontSend As String
        Dim EmailAddressViaDarkroom As String
        Dim PromptForEmailAndSend As String
        Dim Adfile As String
        Dim RepeatEmailsInEmailPrompt As String
        Dim RepeatEmailsInEmailPromptLock As String
        Dim NotifyUL As String ' Notify Box Location
        Dim NotifyUR As String
        Dim NotifyLL As String
        Dim NotifyLR As String
        Dim AttachFilesYesNo As String
        Dim LowerLeftRadioButton As String
        Dim LowerRightRadioButton As String
        Dim UpperLeftRadioButton As String
        Dim UpperRightRadioButton As String
    End Structure

    Public Function RetrieveSignalStrength() As Double
        Dim query As ManagementObjectSearcher
        Dim Qc As ManagementObjectCollection
        Dim Oq As ObjectQuery
        Dim Ms As ManagementScope
        Dim Co As ConnectionOptions
        Dim Mo As ManagementObject
        Dim signalStrength As Double
        Try
            Co = New ConnectionOptions
            Ms = New ManagementScope("root\wmi")
            Oq = New ObjectQuery("SELECT * FROM MSNdis_80211_ReceivedSignalStrength Where active=true")
            query = New ManagementObjectSearcher(Ms, Oq)
            Qc = query.Get
            signalStrength = 0
            For Each Mo In query.Get
                signalStrength = Convert.ToDouble(Mo("Ndis80211ReceivedSignalStrength"))
            Next
        Catch exp As Exception
            ' Indicate no signal
            signalStrength = -1
        End Try
        Return Convert.ToDouble(signalStrength)
    End Function

#Region "File Management"
    ''' <summary>
    ''' getJPGfiles - Returns an arraylist of image filenames
    ''' </summary>
    ''' <param name="MAINFOLDER"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getJPGfiles(ByVal MAINFOLDER As String) As ArrayList
        Dim str4 As New System.IO.DirectoryInfo(MAINFOLDER)
        Dim NoEmailFilename As System.IO.FileInfo() = str4.GetFiles("*.jpg") 'Image with no email will just start with $
        Dim ImageList As New ArrayList
        For Each cc In NoEmailFilename
            ImageList.Add(cc.ToString)
        Next
        Return ImageList
    End Function

    ''' <summary>
    ''' ArrayAddItemsHOOD - is used to add items to an array. Works like arraylist.add
    ''' but for variable declared as arrays and not arraylists.
    ''' </summary>
    ''' <param name="AR"></param>
    ''' <param name="ItemToAdd"></param>
    ''' <remarks></remarks>

    Public Sub ArrayAddItemHOOD(ByRef AR As String(), ByVal ItemToAdd As String)
        'Used to easily redimension an array and add to it.
        'MsgBox("AR's length is: " & AR.Length)
        If AR(0) <> Nothing Then
            'If AR.Length > 1 Then
            ReDim Preserve AR(AR.Length)
        End If
        AR(AR.Length - 1) = ItemToAdd
    End Sub

    ''' <summary>
    ''' Reads text from a file and returns a string
    ''' </summary>
    ''' <param name="FullPath"></param>
    ''' <param name="ErrInfo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFileContents(ByVal FullPath As String, Optional ByRef ErrInfo As String = "") As String
        Dim strContents As String
        Dim objReader As StreamReader
        Try
            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Return strContents
        Catch Ex As Exception
            ErrInfo = Ex.Message
            MsgBox("Error Reading Body Text File")
            Return "Error"
        End Try
    End Function



    ''' <summary>
    ''' SaveTextToFile - Saves a string to file
    ''' </summary>
    ''' <param name="strData"> String</param>
    ''' <param name="FullPath"> Full path of file</param>
    ''' <param name="ErrInfo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
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


    ''' <summary>
    ''' AppendText is used to add text to a file
    ''' </summary>
    ''' <param name="Origfile"></param>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AppendText(ByVal Origfile As String, ByVal message As String, ByVal newname As String) As String
        'Dim newname As String = ProgDir2.Text & "\bin\e1t11906.dat"
        File.Copy(Origfile, newname, True)
        Dim w As StreamWriter
        w = File.AppendText(newname)
        w.Write(message)
        w.Close()
        Return newname
    End Function

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

    ''' <summary>
    ''' IsValidEmail - check to see if the email format is correct.
    ''' original by Brad Murray
    ''' optimized by Rob Hofker, email: rob@eurocamp.nl, 
    ''' 23 august 2000
    '''  </summary>
    ''' <param name="sEMail"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function IsValidEmail(ByVal sEMail As String) As Boolean
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


    ''' <summary>
    ''' IsProcessRunning checks to see if the given process is running.
    ''' The name of the process will have to match exactly.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsProcessRunning_old(ByVal name As String) As Boolean
        Dim MyProcesses As New ArrayList
        MyProcesses = ListProcesses()
        Dim nn As Integer = 0
        Dim ProcessList As New ArrayList
        Dim tmp As Integer = ProcessList.BinarySearch(name)
        If tmp < 0 Then ' name will need to match
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' IsProcessRunning checks to see if the given process is running.
    ''' The name of the process will have to match exactly.
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsProcessRunning(ByVal name As String) As Boolean
        Dim MyProcesses As New ArrayList
        MyProcesses = ListProcesses()
        Dim nn As Integer = 0
        Dim ProcessList As New ArrayList
        Dim counter As Integer
        Dim Flag As Boolean = False
        For counter = 0 To MyProcesses.Count - 1
            If MyProcesses(counter).ToString = name Then
                Flag = True
                Exit For
            End If
            Next
        Return Flag
    End Function


    Public Function ListProcesses() As ArrayList
        Dim MyProcesses As New ArrayList
        For Each Proc As Process In Process.GetProcesses()
            'Console.WriteLine(String.Format("Name {0} ID {1} " & Proc.ProcessName & "  " & Proc.Id))
            MyProcesses.Add(Proc.ProcessName)
        Next
        Return MyProcesses
    End Function



#End Region


#Region "Status Update Stuff"
    ''' <summary>
    ''' RunningDots - Used to show that a process is still running.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RunningDots()
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

    ''' <summary>
    ''' Produces a pause (in ms). Kept in ms to allow for fraction of a second.
    ''' </summary>
    ''' <param name="delay"></param>
    ''' <remarks></remarks>
    Public Sub pause(ByVal delay As Integer)
        Dim s As Integer = Environment.TickCount
        Dim e As Integer = 0
        Do : My.Application.DoEvents()
            System.Threading.Thread.Sleep(delay)
            e = Environment.TickCount
        Loop Until (e - s) >= delay
    End Sub

#Region "Facebook Stuff"
    ''' <summary>
    ''' MakeAlbum - used to create an album in Facebook. Needs Facebook_Graph_Toolkit
    ''' </summary>
    ''' <param name="message"></param>
    ''' <param name="MyAPI"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MakeAlbum(ByVal message As String, ByVal MyAPI As Facebook_Graph_Toolkit.GraphApi.Api) As String
        message = "MyAlbum"

        'Dim MS As New MemoryStream()
        'photo.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)
        'Dim Imagebytes As Byte() = MS.ToArray()
        'MS.Dispose()

        'Set up basic variables for constructing the multipart/form-data data
        Dim newline As String = vbCr & vbLf
        Dim boundary As String = DateTime.Now.Ticks.ToString("x")
        Dim data As String = ""

        'Construct data
        data += "--" & boundary & newline
        data += "Content-Disposition: form-data; name=""message""" & newline & newline
        data += message & newline

        ''data += "--" & boundary & newline
        ''data += "Content-Disposition: form-data; filename=""test.jpg""" & newline
        ''data += "Content-Type: image/jpeg" & newline & newline

        Dim ending As String = newline & "--" & boundary & "--" & newline

        'Convert data to byte[] array
        Dim finaldatastream As New MemoryStream()
        Dim databytes As Byte() = Encoding.UTF8.GetBytes(data)
        Dim endingbytes As Byte() = Encoding.UTF8.GetBytes(ending)
        finaldatastream.Write(databytes, 0, databytes.Length)
        'finaldatastream.Write(Imagebytes, 0, Imagebytes.Length)
        finaldatastream.Write(endingbytes, 0, endingbytes.Length)
        Dim finaldatabytes As Byte() = finaldatastream.ToArray()
        finaldatastream.Dispose()

        'Make the request
        Dim request As WebRequest = HttpWebRequest.Create("https://graph.facebook.com/me/photos?access_token=" & MyAPI.AccessToken)
        'request.ContentType = "Disposition: form-data; name=""message""" & newline
        request.ContentType = "message/http" & newline
        'request.ContentType = "multipart/form-data; boundary=" & boundary
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




    'Dim MyWebBrowser As New WebBrowser
    Public Function MakeAlbum2(ByVal AlbumName As String, ByVal MYAPI As Facebook_Graph_Toolkit.GraphApi.Api) As String
        'Dim MS As New MemoryStream()
        'photo.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)
        'Dim Imagebytes As Byte() = MS.ToArray()
        'MS.Dispose()

        'Set up basic variables for constructing the multipart/form-data data
        Dim newline As String = vbCr & vbLf
        Dim boundary As String = DateTime.Now.Ticks.ToString("x")
        Dim data As String = ""


        'Construct data
        'data += "--" & boundary & newline
        'data += "Content-Disposition: form-data; name=""message""" & newline & newline
        'data += AlbumName & newline

        ''data += "--" & boundary & newline
        ''data += "Content-Disposition: form-data; filename=""test.jpg""" & newline
        ''data += "Content-Type: image/jpeg" & newline & newline

        Dim ending As String = newline & "--" & boundary & "--" & newline

        'Convert data to byte[] array
        ''Dim finaldatastream As New MemoryStream()
        ''Dim databytes As Byte() = Encoding.UTF8.GetBytes(data)
        ''Dim endingbytes As Byte() = Encoding.UTF8.GetBytes(ending)
        ''finaldatastream.Write(databytes, 0, databytes.Length)
        ''finaldatastream.Write(Imagebytes, 0, Imagebytes.Length)
        ''finaldatastream.Write(endingbytes, 0, endingbytes.Length)
        ''Dim finaldatabytes As Byte() = finaldatastream.ToArray()
        ''finaldatastream.Dispose()

        ' I assume the way this works is:
        ' 1.) It converts the image to bytes =>Imagebytes
        ' 2.) Gets a unique identifyer code using the date
        ' 3.) create a data stream (data)
        ' 3.) create a header for message (lines,description,info/lines)
        ' 4.) create a header for image (lines,description,description,lines)
        ' 5.) combine bytes
        'Set up basic variables for constructing the multipart/form-data data

        ''///Added By Adrian Hood upload to existing album

        'Construct data for message only (just to create album)
        If IsNothing(AlbumName) Then
            AlbumName = "Event Photo Email Upload"
        End If
        Dim dataAlbum As String = ""
        'string AlbumName = "EPE Testing Album";
        dataAlbum += "--" & boundary & newline
        dataAlbum += "Content-Disposition: form-data; name=""message""" & newline & newline
        dataAlbum += AlbumName & newline & newline
        'string ending = newline + "--" + boundary + "--" + newline;
        'Convert data to byte[] array
        Dim finaldatastreamAlbum As New MemoryStream()
        Dim databytes2 As Byte() = Encoding.UTF8.GetBytes(data)
        Dim endingbytes2 As Byte() = Encoding.UTF8.GetBytes(ending)
        finaldatastreamAlbum.Write(databytes2, 0, databytes2.Length)
        finaldatastreamAlbum.Write(endingbytes2, 0, endingbytes2.Length)
        Dim finaldatabytesAlbum As Byte() = finaldatastreamAlbum.ToArray()
        finaldatastreamAlbum.Dispose()
        Dim GLOBAL_UserID = "12345"
        Dim RA As String = "https://graph.facebook.com/" & GLOBAL_UserID & "/album?access_token=" & MYAPI.AccessToken
        'Dim RA As String = "https://graph.facebook.com/" & MYAPI.UserID & "/album?access_token=" & MYAPI.AccessToken

        ' Create a request for the URL
        Dim request As WebRequest = WebRequest.Create(RA)
        ' Set settings
        request.ContentLength = finaldatabytesAlbum.Length
        request.Method = "POST"
        ' Get the response.

        '''''Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        '''''' Open the stream using a StreamReader for easy access.
        '''''Dim dataStream As Stream = response.GetResponseStream()
        '''''Dim reader As New StreamReader(dataStream)
        '''''' Read the content.
        '''''Dim responseFromServer As String = reader.ReadToEnd()
        '''''reader.Close()
        '''''dataStream.Close()
        '''''response.Close()
        Dim datastream As New MemoryStream
        datastream.Write(finaldatabytesAlbum, 0, finaldatabytesAlbum.Length)
        Dim WRAlbum As WebResponse = request.GetResponse()
        Dim _ResponseAlbum As String = ""
        Dim sr As New StreamReader(WRAlbum.GetResponseStream())
        Dim responseFromServer2 As String = sr.ReadToEnd()
        sr.Close()



        '''''''///Added By Adrian Hood upload to existing album

        '''''Make the request
        '''''Dim request As WebRequest = HttpWebRequest.Create("https://graph.facebook.com/" & AlbumID & "/photos?access_token=" & AccessToken)
        '''''Dim request As WebRequest = HttpWebRequest.Create("https://graph.facebook.com/me/photos?access_token=" & AccessToken)
        ''''request.ContentType = "multipart/form-data; boundary=" & boundary
        ''''request.ContentLength = finaldatabytes.Length
        ''''request.Method = "POST"
        ''''Using RStream As Stream = request.GetRequestStream()
        ''''    RStream.Write(finaldatabytes, 0, finaldatabytes.Length)
        ''''End Using
        ''''Dim WR As WebResponse = request.GetResponse()
        ''''Dim _Response As String = ""
        ''''Using sr As New StreamReader(WR.GetResponseStream())
        ''''    _Response = sr.ReadToEnd()
        ''''    sr.Close()
        ''''End Using
        '''''Dim JO As New JsonObject(_Response)
        '''''Return DirectCast(JO("id"), String)
        Return dataAlbum
    End Function




    'Public Function PublishPhoto(ByVal photo As Bitmap, ByVal message As String, ByVal AlbumName As String, ByVal AccessToken As String) As String
    '    Dim MS As New MemoryStream()
    '    photo.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg)
    '    Dim Imagebytes As Byte() = MS.ToArray()
    '    MS.Dispose()

    '    'Set up basic variables for constructing the multipart/form-data data
    '    Dim newline As String = vbCr & vbLf
    '    Dim boundary As String = DateTime.Now.Ticks.ToString("x")
    '    Dim data As String = ""


    '    'Construct data
    '    data += "--" & boundary & newline
    '    data += "Content-Disposition: form-data; name=""message""" & newline & newline
    '    data += message & newline

    '    data += "--" & boundary & newline
    '    data += "Content-Disposition: form-data; filename=""test.jpg""" & newline
    '    data += "Content-Type: image/jpeg" & newline & newline
    '    Dim ending As String = newline & "--" & boundary & "--" & newline

    '    'Convert data to byte[] array
    '    Dim finaldatastream As New MemoryStream()
    '    Dim databytes As Byte() = Encoding.UTF8.GetBytes(data)
    '    Dim endingbytes As Byte() = Encoding.UTF8.GetBytes(ending)
    '    finaldatastream.Write(databytes, 0, databytes.Length)
    '    finaldatastream.Write(Imagebytes, 0, Imagebytes.Length)
    '    finaldatastream.Write(endingbytes, 0, endingbytes.Length)
    '    Dim finaldatabytes As Byte() = finaldatastream.ToArray()
    '    finaldatastream.Dispose()

    '    ' I assume the way this works is:
    '    ' 1.) It converts the image to bytes =>Imagebytes
    '    ' 2.) Gets a unique identifyer code using the date
    '    ' 3.) create a data stream (data)
    '    ' 3.) create a header for message (lines,description,info/lines)
    '    ' 4.) create a header for image (lines,description,description,lines)
    '    ' 5.) combine bytes
    '    'Set up basic variables for constructing the multipart/form-data data

    '    '''///Added By Adrian Hood upload to existing album

    '    'Construct data for message only (just to create album)
    '    If IsNothing(AlbumName) Then
    '        AlbumName = "Event Photo Email Upload"
    '    End If
    '    Dim dataAlbum As String = ""
    '    'string AlbumName = "EPE Testing Album";
    '    dataAlbum += "--" & boundary & newline
    '    dataAlbum += "Content-Disposition: form-data; name=""message""" & newline & newline
    '    dataAlbum += AlbumName & newline & newline
    '    'string ending = newline + "--" + boundary + "--" + newline;
    '    'Convert data to byte[] array
    '    Dim finaldatastreamAlbum As New MemoryStream()
    '    Dim databytes2 As Byte() = Encoding.UTF8.GetBytes(data)
    '    Dim endingbytes2 As Byte() = Encoding.UTF8.GetBytes(ending)
    '    finaldatastreamAlbum.Write(databytes2, 0, databytes2.Length)
    '    finaldatastreamAlbum.Write(endingbytes2, 0, endingbytes2.Length)
    '    Dim finaldatabytesAlbum As Byte() = finaldatastreamAlbum.ToArray()
    '    finaldatastreamAlbum.Dispose()
    '    Dim requestAlbum As WebRequest = HttpWebRequest.Create("https://graph.facebook.com/me/album?access_token=" & AccessToken)
    '    requestAlbum.ContentLength = finaldatabytesAlbum.Length
    '    requestAlbum.Method = "POST"
    '    Using RStream As Stream = requestAlbum.GetRequestStream()
    '        RStream.Write(finaldatabytesAlbum, 0, finaldatabytesAlbum.Length)
    '    End Using
    '    Dim WRAlbum As WebResponse = requestAlbum.GetResponse()
    '    Dim _ResponseAlbum As String = ""
    '    Using sr As New StreamReader(WRAlbum.GetResponseStream())
    '        _ResponseAlbum = sr.ReadToEnd()
    '        sr.Close()
    '    End Using


    '    '''''''///Added By Adrian Hood upload to existing album

    '    '''''Make the request
    '    '''''Dim request As WebRequest = HttpWebRequest.Create("https://graph.facebook.com/" & AlbumID & "/photos?access_token=" & AccessToken)
    '    '''''Dim request As WebRequest = HttpWebRequest.Create("https://graph.facebook.com/me/photos?access_token=" & AccessToken)
    '    ''''request.ContentType = "multipart/form-data; boundary=" & boundary
    '    ''''request.ContentLength = finaldatabytes.Length
    '    ''''request.Method = "POST"
    '    ''''Using RStream As Stream = request.GetRequestStream()
    '    ''''    RStream.Write(finaldatabytes, 0, finaldatabytes.Length)
    '    ''''End Using
    '    ''''Dim WR As WebResponse = request.GetResponse()
    '    ''''Dim _Response As String = ""
    '    ''''Using sr As New StreamReader(WR.GetResponseStream())
    '    ''''    _Response = sr.ReadToEnd()
    '    ''''    sr.Close()
    '    ''''End Using
    '    '''''Dim JO As New JsonObject(_Response)
    '    '''''Return DirectCast(JO("id"), String)
    '    Return dataAlbum
    'End Function





#End Region

    Public Sub WaitForFileAvailibility(ByVal filePath As String, ByVal timeOut As Integer)
        'This subroutines tries to access a file. If an error event occurs while trying to read write,
        'it is assumed not available and tries again until timeOut is reached.
        'An example of its use is when using Watchfolder. An event may occur when a file appears but if its a large file
        'It may still be 'loading' and not finished. This subroutine waits until it is finished.
        'timeOut is in seconds
        'remember start time for time out
        Dim startTime As DateTime = DateTime.Now
        Dim looping As Boolean = True
        Do While looping
            Try
                Using fStream As New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                    If fStream IsNot Nothing Then
                        looping = False
                    End If
                End Using
            Catch exI0 As IOException
                If DateTime.Now.Subtract(startTime).TotalSeconds > timeOut Then
                    'time out
                    looping = False
                Else
                    'wait
                    System.Threading.Thread.Sleep(1000)
                End If
            Catch ex As Exception
                Throw
            End Try
        Loop
    End Sub

    ''' <summary>
    ''' This subroutine checks to see if residual images are in the image forlder. This is to guard against
    ''' images being emailed inadvertantly.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckForResidualImages(ByVal folder As String)
        Try
            Dim str As New IO.DirectoryInfo(folder)
            Dim listing As IO.FileInfo() = str.GetFiles("*.jpg")
            If listing.Length > 0 Then
                MsgBox("Warning: There are currently images inside your image folder [" & folder & "]. If these are not associated with your current event, you should move them to another location.")
            End If
        Catch ex As Exception
        End Try

        ' do nothing (Chances are the folder 
    End Sub

    ''' <summary>
    ''' IsConnectionAvailable pings the given website. Usually google.com
    ''' </summary>
    ''' <param name="website"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsConnectionAvailable2(ByVal website As String) As Boolean
        'Call url
        Dim url As New System.Uri(website)
        'Request for request
        Dim req As System.Net.WebRequest
        req = System.Net.WebRequest.Create(url)
        Dim resp As System.Net.WebResponse
        Try
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            Return True
        Catch ex As Exception
            req = Nothing
            Return False
        End Try
    End Function

    Public Function IsConnectionAvailable(ByVal website As String) As Boolean
        Try
            'Dim client As VariantType
            'Dim stream As VariantType
            Using client = New WebClient()
                Using stream = client.OpenRead(website)
                End Using
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    ''' <summary>
    ''' RetrieveSignalStrength attempts to get the signal strenth
    ''' So far, it doesn't work
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RetrieveSignalStrenth() As Double
        Dim theSignalStrength As Double = 0
        Dim theConnectionOptions As New ConnectionOptions()
        Dim theManagementScope As New ManagementScope("root\wmi")
        Dim theObjectQuery As New ObjectQuery("SELECT * FROM MSNdis_80211_ReceivedSignalStrength WHERE active=true")
        Dim theQuery As New ManagementObjectSearcher(theManagementScope, theObjectQuery)
        Try
            'ManagementObjectCollection theResults = theQuery.Get();
            For Each currentObject As ManagementObject In theQuery.Get()
                theSignalStrength = theSignalStrength + Convert.ToDouble(currentObject("Ndis80211ReceivedSignalStrength"))
            Next
        Catch e As Exception
            'handle
        End Try
        Return Convert.ToDouble(theSignalStrength)
    End Function

    ''' <summary>
    ''' method for retrieving the signal strength of all WI-FI adapters
    ''' </summary>
    ''' <returns></returns>
    Public Function GetWIFISignalStrength() As String
        Try
            Dim query As New ObjectQuery("SELECT * FROM MSNdis_80211_ReceivedSignalStrength Where active = true")
            Dim scope As New ManagementScope("root\wmi")
            Dim searcher As New ManagementObjectSearcher(scope, query)
            Dim result As String = ""
            For Each obj As ManagementObject In searcher.Get()
                If CBool(obj("Active")) = True Then
                    result += DirectCast(obj("Ndis80211ReceivedSignalStrength").ToString(), String) + Environment.NewLine
                End If
            Next
            If result = "" Then
                result = "No active WI-FI adapters found!"
            End If

            Return result.Trim()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return String.Empty
        End Try
    End Function

    Public Function GetWirelessSignalStrength() As List(Of WirelessInfoHood)

        Dim searcher As ManagementObjectSearcher = Nothing
        searcher = New ManagementObjectSearcher("root\WMI", "select InstanceName,Ndis80211ReceivedSignalStrength from MSNdis_80211_ReceivedSignalStrength")
        Dim adapterObjects As ManagementObjectCollection = searcher.[Get]()
        Dim result As New List(Of WirelessInfoHood)()
        For Each mo As ManagementObject In adapterObjects
            Dim w As New WirelessInfoHood()
            w.InstanceName = mo("InstanceName").ToString()
            Dim intStrength As Integer = Convert.ToInt32(mo("Ndis80211ReceivedSignalStrength"))
            If intStrength > -57 Then
                w.Bars = 5
            ElseIf intStrength > -68 Then
                w.Bars = 4
            ElseIf intStrength > -72 Then
                w.Bars = 3
            ElseIf intStrength > -80 Then
                w.Bars = 2
            ElseIf intStrength > -90 Then
                w.Bars = 1
            Else
                w.Bars = 0
            End If
            result.Add(w)
        Next
        Return result
    End Function




    Public Sub WatchFolderWithSetFrequency(ByVal durationhood As Integer)
        ' This subroutine is not used yet. The idea is that I would like to put the filesystemwatcher method
        ' into a subroutine that allows me to enable/disable at a set frequency.
        ' integer is in seconds. Will use clock
        Dim MyDate As Date = Now
        Dim timehood = MyDate.Second
    End Sub

    ''' <summary>
    ''' Display() is used to write to the statusbox along with 2 carriage returns. Allows the statusbox to be more 
    ''' easily read
    ''' </summary>
    ''' <param name="STATUSBOX"></param>
    ''' <param name="X"></param>
    ''' <remarks></remarks>
    Public Sub Display(ByVal STATUSBOX As System.Windows.Forms.TextBox, ByVal X As String)
        'Chr(10) is linefeed and Chr(13) is Carriage Return.
        STATUSBOX.AppendText(X & vbCrLf & vbCrLf)
    End Sub

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



    Public Sub AutosizeImage(ByVal ImagePath As String, ByVal picBox As PictureBox, ByVal picTextbox As Label, Optional ByVal pSizeMode As PictureBoxSizeMode = PictureBoxSizeMode.CenterImage)
        Try
            picBox.Image = Nothing
            picBox.SizeMode = pSizeMode
            If System.IO.File.Exists(ImagePath) Then
                Dim imgOrg As Bitmap
                Dim imgShow As Bitmap
                Dim g As Graphics
                Dim divideBy, divideByH, divideByW As Double
                imgOrg = DirectCast(Bitmap.FromFile(ImagePath), Bitmap)

                divideByW = imgOrg.Width / picBox.Width
                divideByH = imgOrg.Height / picBox.Height
                If divideByW > 1 Or divideByH > 1 Then
                    If divideByW > divideByH Then
                        divideBy = divideByW
                    Else
                        divideBy = divideByH
                    End If

                    imgShow = New Bitmap(CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy))
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, CInt(CDbl(imgOrg.Width) / divideBy), CInt(CDbl(imgOrg.Height) / divideBy)), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                Else
                    imgShow = New Bitmap(imgOrg.Width, imgOrg.Height)
                    imgShow.SetResolution(imgOrg.HorizontalResolution, imgOrg.VerticalResolution)
                    g = Graphics.FromImage(imgShow)
                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.DrawImage(imgOrg, New Rectangle(0, 0, imgOrg.Width, imgOrg.Height), 0, 0, imgOrg.Width, imgOrg.Height, GraphicsUnit.Pixel)
                    g.Dispose()
                End If
                imgOrg.Dispose()

                picBox.Image = imgShow
                picTextbox.Text = Path.GetFileName(ImagePath)
            Else
                picBox.Image = Nothing
            End If


        Catch ex As Exception
            MsgBox(ex.ToString & vbCrLf & ex.Source)
        End Try

    End Sub

    'Private Sub ShowSchemaButton_Click(ByVal MyDataSet As DataSet, ByVal Filename As String)
    '    Dim swXML As New System.IO.StringWriter()
    '    MyDataSet.WriteXmlSchema(swXML)
    '    TextBox1.Text = swXML.ToString
    'End Sub


    'Private Sub ReadXMLbutton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReadXMLbutton.Click

    '    Dim filePath As String = "C:\Users\AdrianSr\Desktop\TestBatchCRD\Authors.xml"
    '    AuthorsDataSet.ReadXml(filePath)
    '    DataGridView1.DataSource = AuthorsDataSet
    '    DataGridView1.DataMember = "authors"
    'End Sub

    Public Function GetXMLData(ByVal DefaultFilename As String) As DEFAULTDATA

        ' The goal is to eventually read in defualt contents stored as XML data.
        'Dim MyInfo As String = GetFileContents(filename)
        'Using MyXMLinfo As XmlReader = XmlReader.Create(New StringReader(MyInfo))

        Dim MyData As DEFAULTDATA = Nothing
        Try
            MyData.CompanyName = readXML(DefaultFilename, "CompanyName")
            MyData.CompanyEmail = readXML(DefaultFilename, "CompanyEmail")
            MyData.SubjectLine = readXML(DefaultFilename, "SubjectLine")
            MyData.ImageFolder = readXML(DefaultFilename, "ImageFolder")
            MyData.MessageFile = readXML(DefaultFilename, "MessageFile")
            MyData.MailServer = readXML(DefaultFilename, "MailServer")
            MyData.UserName = readXML(DefaultFilename, "UserName")
            MyData.PWDEncrypt = readXML(DefaultFilename, "PWDEncrypt")
            MyData.Port = readXML(DefaultFilename, "Port")
            MyData.TimeInterval = readXML(DefaultFilename, "TimeInterval")
            MyData.EmailMasterListName = readXML(DefaultFilename, "EmailMasterListName")
            MyData.UseMasterListBool = readXML(DefaultFilename, "UseMasterListBool")
            MyData.UseAdLabelBool = readXML(DefaultFilename, "UseAdLabelBool")
            MyData.ConfimEmailBool = readXML(DefaultFilename, "ConfimEmailBool")
            MyData.CombineEmailsBool = readXML(DefaultFilename, "CombineEmailsBool")
            MyData.UseSSLBool = readXML(DefaultFilename, "UseSSLBool")
            MyData.CheckInternetConnectionBool = readXML(DefaultFilename, "CheckInternetConnectionBool")
            MyData.Adfile = readXML(DefaultFilename, "Adfile")
            MyData.AttachFilesYesNo = readXML(DefaultFilename, "AttachFilesYesNo")
            MyData.EmailAddressViaDarkroom = readXML(DefaultFilename, "EmailAddressViaDarkroom")
            MyData.PromptForEmailAndSend = readXML(DefaultFilename, "PromptForEmailAndSend")
            MyData.PromptForEmailDontSend = readXML(DefaultFilename, "PromptForEmailDontSend")
            MyData.RepeatEmailsInEmailPrompt = readXML(DefaultFilename, "RepeatEmailsInEmailPrompt")
            MyData.RepeatEmailsInEmailPromptLock = readXML(DefaultFilename, "RepeatEmailsInEmailPromptLock")
            MyData.NotifyUL = readXML(DefaultFilename, "NotifyUL")
            MyData.NotifyUR = readXML(DefaultFilename, "NotifyUR")
            MyData.NotifyLL = readXML(DefaultFilename, "NotifyLL")
            MyData.NotifyLR = readXML(DefaultFilename, "NotifyLR")
        Catch ex As Exception

        End Try


        Return MyData
    End Function




    Public Function readXML(ByVal filename As String, ByVal fieldname As String) As String
        Dim xmldoc As New XmlDataDocument()
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim str As String = Nothing
        Dim fs As New FileStream(filename, FileMode.Open, FileAccess.Read)
        xmldoc.Load(fs)
        xmlnode = xmldoc.GetElementsByTagName(fieldname)
        Try
            For i = 0 To xmlnode.Count - 1
                str = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                'MsgBox(str)
            Next
        Catch ex As Exception
            str = ""
        End Try
        fs.Close()
        Return str
    End Function

    Public Function GetFileNameFromPath(ByVal FileNameFullPath As String) As String
        Dim tmp() As String
        tmp = Split(FileNameFullPath, "\")
        Return tmp(tmp.Count - 1)
    End Function

    Function MakeDictionary_from_CSV(ByVal MM As List(Of String)) As Dictionary(Of String, String)
        Dim table As Dictionary(Of String, String) = New Dictionary(Of String, String)
        Dim tmp() As String
        For Each cc As String In MM
            If Trim(cc) <> "" Then
                tmp = Split(cc, ",")
                table.Add(tmp(0), tmp(1) & "_" & tmp(2)) ' Key, Value (Folder)
            End If
        Next
        Return table
    End Function

    Public Function csvToDatatable_2(ByVal filename As String, ByVal separator As Char) As System.Data.DataTable
        Dim dt As New System.Data.DataTable
        Dim firstLine As Boolean = True
        If IO.File.Exists(filename) Then
            Using sr As New StreamReader(filename)
                While Not sr.EndOfStream
                    If firstLine Then
                        firstLine = False
                        Dim cols = sr.ReadLine.Split(separator)
                        For Each col In cols
                            dt.Columns.Add(New DataColumn(col, GetType(String)))
                            'dt.Columns.Add(col)
                        Next
                    Else
                        Dim data() As String = sr.ReadLine.Split(separator)
                        'dt.Rows.Add(data.ToArray)
                    End If
                End While
            End Using
        End If
        Return dt
    End Function


End Module
