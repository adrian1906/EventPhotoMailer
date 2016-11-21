Public Class EmailSetupForm
    'Inherits System.Windows.Forms.Form
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Form2closeNoSavebutton.Click
        Me.Hide()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Button_SaveAsDefault2.Click, AddressOf Form1.SaveAsXML
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
            MsgBox(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' FBlogo_Click call FBAuthenticate()
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub FBlogo_click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form1.FBauth_click(sender, e)
    End Sub

    Private Sub ConfigButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigButton1.Click
        Form1.ImportDefaults(Form1.DefaultFile1)
        Form1.CurrentDefaultFileUsed = Form1.DefaultFile1
    End Sub

    Private Sub ConfigButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigButton2.Click
        Form1.ImportDefaults(Form1.DefaultFile2)
        Form1.CurrentDefaultFileUsed = Form1.DefaultFile2
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim tmp1 As String = ComboBox1.SelectedItem.ToString
        Dim tmp2() As String = Split(tmp1, "--")
        textBox_MailServer.Text = tmp2(1).Replace(" ", "")
    End Sub

    Private Sub Checkbox_CheckForIntConnectYesNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkbox_CheckForIntConnectYesNo.CheckedChanged
        If Checkbox_CheckForIntConnectYesNo.Checked Then
            Form1.CheckForIntConnectYesNo = True
        Else
            Form1.CheckForIntConnectYesNo = False
        End If
    End Sub

    Private Sub PostEmailPrompt_CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostEmailPrompt_CheckBox1.CheckedChanged
        If PostEmailPrompt_CheckBox1.Checked Then
            Form1.PostEmailPromptYesNo = True
        Else
            Form1.PostEmailPromptYesNo = False
        End If
    End Sub

    Private Sub CompNameTextbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompNameTextbox.TextChanged
        Form1.CustomerInfoLabel.Text = "Licensed to " & CompNameTextbox.Text
    End Sub

End Class