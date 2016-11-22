Imports System.IO
Imports System.Diagnostics.Process
Public Class InitializeEPE_Form
    Dim CurrentDirectory As String = System.Environment.CurrentDirectory 'Gives c:\EventPhotoEmailer
    Dim ID As String = "C:\EventPhotoEmailer\EPE_Hotfolder\"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            'Dim RegFilePath As String = CurrentDirectory & "\bin\setupEPE_RasterPrinter_DRPro.reg"
            Dim RegFilePath As String = CurrentDirectory & "\bin\EPE_and_MakeThin_DarkRoomPro_RasterPrinters.reg"
            'Process.Start("cmd", "/k" & RegFilePath) ' Code to keep window open
            Dim DarkroomPath As String = "C:\Program Files\ExpressDigital\Darkroom Pro"
            If Not Directory.Exists(DarkroomPath) Then
                DarkRoomStatusLabel.Text = "This setup requires Darkroom Pro"
            Else
                Process.Start(RegFilePath)
                If Directory.Exists("x:\Packages") Then
                    File.Copy(CurrentDirectory & "\bin\EventPhotoEmailer.pgrp", "x:\Packages\EventPhotoEmailer.pgrp", True)
                Else
                    DarkRoomStatusLabel.Text = "Error"
                    MsgBox("Error copying sample package into x:\Packages. In order to intall properly, Darkroom Pro should be running")
                End If
                'Copy Borders to Darkroom Directory
                If Directory.Exists("x:\templates") Then
                    CopyDirectory(CurrentDirectory & "\bin\ExampleProofBorders", "x:\templates\ExampleProofBorders")
                Else
                    DarkRoomStatusLabel.Text = "Error"
                    MsgBox("Error copying sample template into x:\templates. In order to intall properly, Darkroom Pro should be running")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error:" & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Process.Start(CurrentDirectory & "\bin\SetupDarkroomAssembly.bat")
    End Sub

    Private Sub CreateImagesAndCSVFile(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateImagesButton.Click
        Try

            Dim ImageDirectory As String = CurrentDirectory & "\Email_Filename_Test_Folder\"
            Dim TargetDirectory As String = ID
            Dim File1 As String = "Penguins.jpg"
            Dim File2 As String = "Chrysanthemum.jpg"
            Dim File3 As String = "Tulips.jpg"
            Dim EM As String = TextBox1.Text
            'Dim TestCSVfile As String = CurrentDirectory & "\Email_Filename_Test_Directory.csv"
            Dim TestCSVfile As String = "c:\EventPhotoEmailer\Email_Filename_Test_Directory.txt" 'Needs to be put in a folder with write access.
            File.Copy(ImageDirectory & File1, TargetDirectory & EM & "$" & File1, True)
            File.Copy(ImageDirectory & File2, TargetDirectory & EM & "$" & File2, True)
            File.Copy(ImageDirectory & File3, TargetDirectory & EM & "$" & File3, True)
            ' Create .csv file
            Dim fs As New FileStream(TestCSVfile, FileMode.Create, FileAccess.Write) 'Set to create so old file will be totally rewritten
            Dim s As New StreamWriter(fs)
            'creating a new StreamWriter and passing the filestream object fs as argument
            s.BaseStream.Seek(0, SeekOrigin.End)
            'the seek method is used to move the cursor to next position to avoid text being
            'overwritten
            s.WriteLine("Chrysanthemum.jpg," & EM)
            s.WriteLine("Chrysanthemum.jpg;Penguins.jpg;Tulips.jpg," & EM)
            s.Close()
            DoneLabel.Visible = True
            DoneLabel.Text = "Done"
        Catch ex As Exception
            DoneLabel.Visible = True
            DoneLabel.Text = "Error"

        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label6.Text = CurrentDirectory
        Me.Text = "EPE Initialization"
    End Sub

    Public Function CopyDirectory(ByVal Src As String, ByVal Dest As String) As Boolean
        'add Directory Seperator Character (\) for the string concatenation shown later
        If Dest.Substring(Dest.Length - 1, 1) <> Path.DirectorySeparatorChar Then
            Dest += Path.DirectorySeparatorChar
        End If
        If Not Directory.Exists(Dest) Then Directory.CreateDirectory(Dest)
        Dim Files As String()
        Files = Directory.GetFileSystemEntries(Src)
        Dim element As String
        For Each element In Files
            If Directory.Exists(element) Then
                'if the current FileSystemEntry is a directory,
                'call this function recursively
                CopyDirectory(element, Dest & Path.GetFileName(element))
            Else
                'the current FileSystemEntry is a file so just copy it
                File.Copy(element, Dest & Path.GetFileName(element), True) ' True means overright
            End If
        Next
        Return True
    End Function

    Private Sub Uninstall(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UninstallButton.Click
        Try
            'Dim RegFilePath As String = CurrentDirectory & "\bin\RemoveEPE_RasterPrinter_DRPro.reg"
            Dim RegFilePath As String = CurrentDirectory & "Remove_EPE_and_MakeThin_DarkRoomPro_RasterPrinters.reg"
            'Process.Start("cmd", "/k" & RegFilePath) ' Code to keep window open
            Process.Start(RegFilePath)
            If File.Exists("x:\Packages\EventPhotoEmailer.pgrp") Then
                File.Delete("x:\Packages\EventPhotoEmailer.pgrp")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try

    End Sub



End Class
