Public Class EmailSetupForm
    'Inherits System.Windows.Forms.Form

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Form2closeNoSavebutton.Click
        Me.Hide()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Button_SaveAsDefault2.Click, AddressOf EPEForm1.SaveAsXML

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()
        Try
            EmailMasterListFilename.Text = OpenFileDialog1.FileName
        Catch ex As Exception
            ' just don't show anything
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OpenFileDialog2.ShowDialog()
        Try
            AdLabel2.Text = OpenFileDialog2.FileName
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.Source)
        End Try
    End Sub

    ' ''' <summary>
    ' ''' FBlogo_Click call FBAuthenticate()
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub FBlogo_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    EPEForm1.FBauth_click(sender, e)
    'End Sub

    Public Sub ConfigButton0_Click(sender As System.Object, e As System.EventArgs) Handles ConfigButton0.Click
        EPEForm1.ImportDefaults(EPEForm1.DefaultFile0)
        EPEForm1.CurrentDefaultFileUsed = EPEForm1.DefaultFile0
        ConfigButton0.BackColor = Color.Green
        ConfigButton1.BackColor = Color.Gray
        ConfigButton2.BackColor = Color.Gray
        ConfigButton3.BackColor = Color.Gray
        ConfigButton4.BackColor = Color.Gray
        EPEForm1.Config0ButtonFrontPage.BackColor = Color.Green
        EPEForm1.Config1ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config2ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config3ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config4ButtonFrontPage.BackColor = Color.Gray
    End Sub

    Public Sub ConfigButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigButton1.Click
        EPEForm1.ImportDefaults(EPEForm1.DefaultFile1)
        EPEForm1.CurrentDefaultFileUsed = EPEForm1.DefaultFile1
        ConfigButton0.BackColor = Color.Gray
        ConfigButton1.BackColor = Color.Green
        ConfigButton2.BackColor = Color.Gray
        ConfigButton3.BackColor = Color.Gray
        ConfigButton4.BackColor = Color.Gray
        EPEForm1.Config0ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config1ButtonFrontPage.BackColor = Color.Green
        EPEForm1.Config2ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config3ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config4ButtonFrontPage.BackColor = Color.Gray

    End Sub

    Public Sub ConfigButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigButton2.Click
        EPEForm1.ImportDefaults(EPEForm1.DefaultFile2)
        EPEForm1.CurrentDefaultFileUsed = EPEForm1.DefaultFile2
        ConfigButton0.BackColor = Color.Gray
        ConfigButton1.BackColor = Color.Gray
        ConfigButton2.BackColor = Color.Green
        ConfigButton3.BackColor = Color.Gray
        ConfigButton4.BackColor = Color.Gray
        EPEForm1.Config0ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config1ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config2ButtonFrontPage.BackColor = Color.Green
        EPEForm1.Config3ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config4ButtonFrontPage.BackColor = Color.Gray
    End Sub

    Public Sub ConfigButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigButton3.Click
        EPEForm1.ImportDefaults(EPEForm1.DefaultFile3)
        EPEForm1.CurrentDefaultFileUsed = EPEForm1.DefaultFile3
        ConfigButton0.BackColor = Color.Gray
        ConfigButton1.BackColor = Color.Gray
        ConfigButton2.BackColor = Color.Gray
        ConfigButton3.BackColor = Color.Green
        ConfigButton4.BackColor = Color.Gray
        EPEForm1.Config0ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config1ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config2ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config3ButtonFrontPage.BackColor = Color.Green
        EPEForm1.Config4ButtonFrontPage.BackColor = Color.Gray

    End Sub


    Public Sub ConfigButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigButton4.Click
        EPEForm1.ImportDefaults(EPEForm1.DefaultFile4)
        EPEForm1.CurrentDefaultFileUsed = EPEForm1.DefaultFile4
        ConfigButton0.BackColor = Color.Gray
        ConfigButton1.BackColor = Color.Gray
        ConfigButton2.BackColor = Color.Gray
        ConfigButton3.BackColor = Color.Gray
        ConfigButton4.BackColor = Color.Green
        EPEForm1.Config0ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config1ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config2ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config3ButtonFrontPage.BackColor = Color.Gray
        EPEForm1.Config4ButtonFrontPage.BackColor = Color.Green

    End Sub





    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim tmp1 As String = ComboBox1.SelectedItem.ToString
        Dim tmp2() As String = Split(tmp1, "--")
        textBox_MailServer.Text = tmp2(1).Replace(" ", "")
    End Sub

    Private Sub Checkbox_CheckForIntConnectYesNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkbox_CheckForIntConnectYesNo.CheckedChanged
        If Checkbox_CheckForIntConnectYesNo.Checked Then
            EPEForm1.CheckForIntConnectYesNo = True
        Else
            EPEForm1.CheckForIntConnectYesNo = False
        End If
    End Sub

    Private Sub PostEmailPrompt_CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PromptForEmailAndSend_CheckBox.CheckedChanged
        If PromptForEmailAndSend_CheckBox.Checked Then
            EPEForm1.PostEmailPromptYesNo = True
        Else
            EPEForm1.PostEmailPromptYesNo = False
        End If
    End Sub

    Private Sub CompNameTextbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompNameTextbox.TextChanged
        EPEForm1.CustomerInfoLabel.Text = "Licensed to " & CompNameTextbox.Text
    End Sub

    Private Sub MyFormClosed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.FormClosing
        If PromptForEmailAndSend_CheckBox.Checked Or PromptForEmailDontSend_CheckBox.Checked Then
            EPEForm1.PostEmailPromptYesNo = True
        Else
            EPEForm1.PostEmailPromptYesNo = False
        End If
        EPEForm1.MyAdFileLabel = AdLabel2.Text
    End Sub

    Private Sub EmailMasterListFilename_TextChanged(sender As System.Object, e As System.EventArgs) Handles EmailMasterListFilename.TextChanged
        If UseMasterListCheckbox.Checked Then
            EPEForm1.GetEmailsFromMasterDirectory() ' update the list of names. Note...this may take some time if the list is long.
            'I noticed in testing that the first run upon startup will be fast. Subsequent runs took as long a 30 seconds.
            'The reason it is put here is to make sure that the latest names are used and that this function is only called once.
        End If
    End Sub




End Class