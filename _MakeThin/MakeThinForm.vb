Imports System.IO
Imports System.ComponentModel ' For BackgroundWorkder Class
Imports System.Xml

Public Class MakeThinForm
    'The purpose of this program is to provide a quick means to make a photo thinner
    'There are 2 modes:
    '1.) GUI: Load the image and apply the edit:  This involves navigating to the image and choosing an output folder. This 
    ' hot folder works best when it is the same one that Darkroom uses to import the images.
    '2.) Watch Folder: This involves the program monitoring the watch folder and then processing. This is best when inside 
    'the EPE folder. There are three folders: ThreePercent FivePercent TenPercent.  Each one has a Raster Printer Assigned. B3==> 3%, B5==>5% B6==>10% (B10 would not work for some reason)
    'The modified folder is saved in: C:\EventPhotoEmailer\MakeThin\00_MTHotFolder. This folder can be setup for automatic import
    'Set this folder to be the input folder ('Could also make it the c:\Program Files\ExpressDigital\Darkroom Pro\Photos\FTP folder' which is already being pulled)
    'NOTE: Returned size has maximum dimension of 2100 pixels. This is done on purpose assuming the maximum print/email will be on the order of 5x7.

    Public WithEvents WF3 As New FileSystemWatcher
    Public WithEvents WF5 As New FileSystemWatcher
    Public WithEvents WF10 As New FileSystemWatcher

    Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'HotFolder.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\MT\MTHotFolder\"
        'QIMConfig.xml....
        '<?xml version="1.0" encoding="utf-8"?>
        '<QIMConfig>
        '<HotFolder>C:\EventPhotoEmailer\MakeThin\MTHotFolder</HotFolder>
        '</QIMConfig>
        MakeFolders()
        If File.Exists("c:\EventPhotoEmailer\MakeThin\QIMConfig.xml") Then
            HotFolder.Text = readXML("c:\EventPhotoEmailer\MakeThin\QIMConfig.xml", "HotFolder")
        Else
            HotFolder.Text = "C:\EventPhotoEmailer\MakeThin\00_MTHotFolder"
        End If

        WF3.Path = "c:\EventPhotoEmailer\MakeThin\ThreePercent"
        WF5.Path = "c:\EventPhotoEmailer\MakeThin\FivePercent"
        WF10.Path = "c:\EventPhotoEmailer\MakeThin\TenPercent"
        WF3.Filter = "*.jpg"
        WF5.Filter = "*.jpg"
        WF10.Filter = "*.jpg"
    End Sub

    Sub MakeFolders()
        If Not Directory.Exists("c:\EventPhotoEmailer\MakeThin\ThreePercent") Then
            Directory.CreateDirectory("c:\EventPhotoEmailer\MakeThin\ThreePercent")
        End If
        If Not Directory.Exists("c:\EventPhotoEmailer\MakeThin\FivePercent") Then
            Directory.CreateDirectory("c:\EventPhotoEmailer\MakeThin\FivePercent")
        End If
        If Not Directory.Exists("c:\EventPhotoEmailer\MakeThin\TenPercent") Then
            Directory.CreateDirectory("c:\EventPhotoEmailer\MakeThin\TenPercent")
        End If
        If Not Directory.Exists("C:\EventPhotoEmailer\MakeThin\00_MTHotFolder") Then
            Directory.CreateDirectory("C:\EventPhotoEmailer\MakeThin\00_MTHotFolder")
        End If
    End Sub

    Sub TakeOffWeight(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WF3.Created, WF5.Created, WF10.Created
        'This subroutine monitors the 3 folders for images and apply the scaling based on the folder
        Dim WF As New FileSystemWatcher
        Dim scale As Double = 1
        WF = sender
        Dim str4 As New IO.DirectoryInfo(WF.Path)
        Dim NoEmailFilename As IO.FileInfo() = str4.GetFiles("*.jpg")
        If WF.Equals(WF3) Then
            scale = 0.97
        ElseIf WF.Equals(WF5) Then
            scale = 0.95
        ElseIf WF.Equals(WF10) Then
            scale = 0.9
        Else
            scale = 1
        End If
        For Each temp5 In NoEmailFilename
            WaitForFileAvailibility(temp5.FullName, 10)
            CreateThumbsFUNCTION_scale(temp5.FullName, scale)
            System.IO.File.Delete(temp5.FullName)
        Next
    End Sub

    Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
        InputImageTextbox.Text = OpenFileDialog1.FileName
    End Sub

    Public Sub CreateThumbsFUNCTION(ByVal IMAGE As String)
        'following code resizes picture to fit
        'IMAGE needs the full path
        'If thumbnail already exists, it will skip
        Dim temp() As String
        temp = Split(IMAGE, "\")
        Dim ImageName As String = temp(temp.Length - 1).ToString
        Dim newimage As System.Drawing.Image
        Dim EW As New ExifWorks(IMAGE)
        'Dim MyOUTPUTPATH As String = OutputFolder.Text & "\"
        Dim MyOUTPUTPATH As String = HotFolder.Text & "\" & ImageName
        Dim CreateFlagg As Integer = 1
        Dim Hout, Wout As Integer
        Dim Scale As Double = 1
        newimage = Rotate_Image_From_EXIF(IMAGE)
        Dim bm As New Bitmap(newimage)
        'MsgBox("bm.width = " & bm.Width)
        If ThreePercent.Checked Then
            Scale = 0.97
        End If
        If FivePercent.Checked Then
            Scale = 0.95
        End If
        If TenPercent.Checked Then
            Scale = 0.9
        End If

        Wout = Scale * bm.Width
        Hout = bm.Height
        Dim thumb As New Bitmap(Wout, Hout) ' New object for smaller image
        Dim g As Graphics = Graphics.FromImage(thumb)
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.DrawImage(bm, New Rectangle(0, 0, Wout, Hout), New Rectangle(0, 0, bm.Width, _
        bm.Height), GraphicsUnit.Pixel)
        g.Dispose()
        Try
            thumb.Save(MyOUTPUTPATH, System.Drawing.Imaging.ImageFormat.Jpeg) 'can use any image format 
            'MsgBox("AFTER " & NewOutputPath & OUTPUTPATH(1))
            bm.Dispose()
            thumb.Dispose()
            newimage.Dispose()
            EW.Dispose()
        Catch ex As Exception
            ' I'm getting a GDI+ error after a fewDo nothing. Some files may present a problem.. check on this error
        End Try
    End Sub

    Public Sub CreateThumbsFUNCTION_scale(ByVal IMAGE As String, ByVal Scale As Double)
        'Same as CreateThumbsFunction but allows the scaling value as a parameter.
        'following code resizes picture to fit
        'IMAGE needs the full path
        'If thumbnail already exists, it will skip
        ' Dim temp() As String
        'temp = Split(IMAGE, "\")
        'Dim ImageName As String = temp(temp.Length - 1).ToString
        Dim ImageName As String = Path.GetFileName(IMAGE)
        Dim newimage As System.Drawing.Image
        Dim MyOUTPUTPATH As String = HotFolder.Text & "\" & ImageName
        Dim CreateFlagg As Integer = 1
        Dim Hout, Wout As Integer
        newimage = Rotate_Image_From_EXIF(IMAGE)
        Dim bm As New Bitmap(newimage)
        newimage.Dispose()
        Wout = Scale * bm.Width
        Hout = bm.Height
        Dim thumb As New Bitmap(Wout, Hout) ' New object for smaller image
        Dim g As Graphics = Graphics.FromImage(thumb)
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.DrawImage(bm, New Rectangle(0, 0, Wout, Hout), New Rectangle(0, 0, bm.Width, _
        bm.Height), GraphicsUnit.Pixel)
        g.Dispose()
        bm.Dispose()
        Try
            thumb.Save(MyOUTPUTPATH, System.Drawing.Imaging.ImageFormat.Jpeg) 'can use any image format 
            'MsgBox("AFTER " & NewOutputPath & OUTPUTPATH(1))
            thumb.Dispose()
        Catch ex As Exception
            ' I'm getting a GDI+ error after a fewDo nothing. Some files may present a problem.. check on this error
        End Try
    End Sub


    Public Function Rotate_Image_From_EXIF(ByVal InputFile As String) As System.Drawing.Image
        Dim EW As New ExifWorks(InputFile)
        Dim RotatedImage As System.Drawing.Image
        Dim keep As String = EW.Orientation.ToString
        'MsgBox(keep)
        If keep = "TopLeft" Then ' Vertical Correct
            RotatedImage = rotFlipImageFromFile(InputFile, RotateFlipType.RotateNoneFlipNone)
        ElseIf keep = "TopRight" Then
            'Flip across vertical line (Flip X) (Checked out!)
            RotatedImage = rotFlipImageFromFile(InputFile, RotateFlipType.RotateNoneFlipX)
        ElseIf keep = "BottomRight" Then
            'Rotate 180 degrees
            RotatedImage = rotFlipImageFromFile(InputFile, RotateFlipType.Rotate180FlipNone)
        ElseIf keep = "BottomLeft" Then
            'Flip along horizontal line
            RotatedImage = rotFlipImageFromFile(InputFile, RotateFlipType.RotateNoneFlipY)
        ElseIf keep = "LeftTop" Then
            ' Rotate clockwise 90 and flip across vertical line (flipxy)
            RotatedImage = rotFlipImageFromFile(InputFile, RotateFlipType.Rotate90FlipX)
        ElseIf keep = "RightTop" Then
            ' Rotate clockwise 90
            RotatedImage = rotFlipImageFromFile(InputFile, RotateFlipType.Rotate90FlipNone)
        ElseIf keep = "RightBottom" Then
            'rotate counter-clockwise 90 and flip across vertical
            RotatedImage = rotFlipImageFromFile(InputFile, RotateFlipType.Rotate270FlipX)
        ElseIf keep = "LftBottom" Then
            'rotate counter - clockwise 90 (Checked Out!)
            RotatedImage = rotFlipImageFromFile(InputFile, RotateFlipType.Rotate270FlipNone)
        Else
            'MsgBox("EXIF Orientation is not recognized") DO NOTHING
            RotatedImage = rotFlipImageFromFile(InputFile, RotateFlipType.RotateNoneFlipNone)
        End If
        'For counter = 0 To temp.Length - 1
        '    MsgBox(temp(counter))
        'Next
        'Debug.WriteLine(EW.ToString())
        EW.Dispose()
        Return RotatedImage
    End Function

    Public Function rotFlipImageFromFile(ByRef imgPath As String, ByRef rotFlipType As RotateFlipType) As System.Drawing.Image
        Dim img As System.Drawing.Image = System.Drawing.Bitmap.FromFile(imgPath)
        Try
            'img = System.Drawing.Bitmap.FromFile(imgPath)
            img.RotateFlip(rotFlipType)
            'PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            'PictureBox1.Image = img
            ' We delete the file if it exists so it doesn't fail.
            'If System.IO.File.Exists(savePath) Then System.IO.File.Delete(savePath)
            'img.Save(savePath, imgFormat)
            'img.Save(savePath)
            Return img
            img.Dispose()
        Catch ex As Exception
            Return img ' Return image unroated if problem rotating
            img.Dispose()
        End Try
    End Function


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FolderBrowserDialog1.ShowDialog()
        HotFolder.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Start.Click
        CreateThumbsFUNCTION(InputImageTextbox.Text)
    End Sub





    Private Sub OpenOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenOutput.Click
        Process.Start("explorer.exe", HotFolder.Text)
    End Sub

    Private Sub UseWatchFolderCheckbox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseWatchFolderCheckbox.CheckedChanged
        If UseWatchFolderCheckbox.Checked Then
            WF3.EnableRaisingEvents = True
            WF5.EnableRaisingEvents = True
            WF10.EnableRaisingEvents = True
            Panel1.Enabled = False
            Me.WindowState = FormWindowState.Minimized
        Else
            WF3.EnableRaisingEvents = False
            WF5.EnableRaisingEvents = False
            WF10.EnableRaisingEvents = False
            Panel1.Enabled = True
        End If

    End Sub
    ' *********************** Utilities
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
                    Threading.Thread.Sleep(1000)
                End If
            Catch ex As Exception
                Throw
            End Try
        Loop
    End Sub

    Public Sub ImportDefaults(ByVal DefaultFileToUse As String)
        If File.Exists(DefaultFileToUse) Then
            Dim mydata As String = readXML(DefaultFileToUse, "HotFolder")
        End If
    End Sub



    Function readXML(ByVal filename As String, ByVal fieldname As String) As String
        'Dim xmldoc As New XmlDataDocument() '  Claimed that this one was obsolete.
        Dim xmldoc As New XmlDocument()
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

    Public Sub SaveAsXML(ByVal DefaultFileToUse As String)
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True
        settings.OmitXmlDeclaration = False
        settings.NewLineOnAttributes = True
        ' Create XmlWriter.
        'TODO Getting an error message that file is in use
        Using writer As XmlWriter = XmlWriter.Create(DefaultFileToUse, settings)
            ' Begin writing.
            writer.WriteStartDocument()
            writer.WriteStartElement("QIMConfig")
            writer.WriteStartElement("HotFolder")
            writer.WriteString(HotFolder.Text)
            'writer.WriteEndElement()
            writer.WriteEndElement()
            writer.WriteEndDocument()
            writer.Close()
        End Using
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        SaveAsXML("c:\EventPhotoEmailer\MakeThin\QIMConfig.xml")
    End Sub




    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            InstructionsBox1.Visible = True
        Else
            InstructionsBox1.Visible = False
        End If
    End Sub

End Class

