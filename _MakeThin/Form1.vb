Imports System.IO
Imports System.ComponentModel ' For BackgroundWorkder Class
Public Class Form1

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
        Dim MyOUTPUTPATH As String = OutputFolder.Text & ImageName
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
        'If bm.Height < MAXDIMENSION And bm.Width < MAXDIMENSION Then
        '    Hout = bm.Height
        '    Wout = bm.Width
        'Else
        '    If bm.Height > bm.Width Then
        '        Hout = MAXDIMENSION
        '        Wout = Hout * (bm.Width / bm.Height)
        '    Else
        '        Wout = MAXDIMENSION
        '        Hout = Wout * (bm.Height / bm.Width)
        '    End If
        'End If

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
        OutputFolder.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Start.Click
        CreateThumbsFUNCTION(InputImageTextbox.Text)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OutputFolder.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\SIoutput\"
    End Sub

    Private Sub OpenOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenOutput.Click
        Process.Start("explorer.exe", OutputFolder.Text)
    End Sub
End Class

