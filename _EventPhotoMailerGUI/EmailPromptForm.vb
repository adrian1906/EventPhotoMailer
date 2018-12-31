Imports System.IO
Public Class EmailPrompt
    Dim EmailSetupForm As New EmailSetupForm
    Sub EmailPromptOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearBoxes() ' Clears the name and email textboxes
        RepeatEmailsInEmailPrompt_Checkbox.Checked = EPEForm1.RepeatEmailsInEmailPrompt ' sets the checkbox to the value saved
        SaveForLaterCheckBox.Checked = EmailSetupForm.PromptForEmailDontSend_CheckBox.Checked
        UpdateAutoComplete() ' Updates saved email list for AutoFill
        IncludeAdCheckBox1.CheckState = EmailSetupForm.IncludeAdCheckBox.CheckState
        If SaveForLaterCheckBox.Checked Then
            ContinueButton.Text = "Send Later"
        Else
            ContinueButton.Text = "Send Email"
        End If
        AdFileLabel.Text = EmailSetupForm.AdLabel2.Text
        Fill_EmailToTextComboBox(EPEForm1.ProgDir2.Text & "\bin") ' import list of cell phone carriers
        ' This next few lines of code will automate the process of adding email addresses when you know that all the emails are going to the same addresses.
        'TextBox1.Focus()
    End Sub

    ''' <summary>
    ''' Fill EmailToText Combobox reads data from the "\bin\SMTPServerList.csv" file.
    ''' This file is a database of known ISP companies and thier IP addresses
    ''' </summary>
    ''' <param name="Commonpath"></param>
    ''' <remarks></remarks>
    Public Sub Fill_EmailToTextComboBox(ByVal Commonpath As String)
        Dim tmp1() As String
        Dim tmp2 As String
        Dim SS As StreamReader = New StreamReader(Commonpath & "\EmailToText.txt")
        Try
            While Not SS.EndOfStream
                tmp2 = SS.ReadLine
                tmp1 = Split(tmp2, ",")
                'tmp2 = "<" & tmp1(0) & "> " & tmp1(1)
                tmp2 = tmp1(0) & " -- " & tmp1(1)
                CellPhoneCarrierCombobox.Items.Add(tmp2)
            End While
        Catch ex As Exception
            Debug.Print("Problem loading the Email to Text server list")
        End Try
        SS.Close()
    End Sub

    Sub ClearBoxes()
        TextBox1.Text = "" ' clears the box
        TextBox2.Text = "" ' clears the box
        TextBox3.Text = "" ' clears the box
        TextBox4.Text = "" ' clears the box
        TextBox5.Text = "" ' clears the box
        EmailNameText1.Text = " "
        EmailNameText2.Text = " "
        EmailNameText3.Text = " "
        EmailNameText4.Text = " "
        EmailNameText5.Text = " "
    End Sub

    Public Sub UpdateAutoComplete()
        TextBox1.AutoCompleteCustomSource = EPEForm1.SavedEmails
        TextBox2.AutoCompleteCustomSource = EPEForm1.SavedEmails
        TextBox3.AutoCompleteCustomSource = EPEForm1.SavedEmails
        TextBox4.AutoCompleteCustomSource = EPEForm1.SavedEmails
        TextBox5.AutoCompleteCustomSource = EPEForm1.SavedEmails
        EmailNameText1.AutoCompleteCustomSource = EPEForm1.SavedNames
        EmailNameText2.AutoCompleteCustomSource = EPEForm1.SavedNames
        EmailNameText3.AutoCompleteCustomSource = EPEForm1.SavedNames
        EmailNameText4.AutoCompleteCustomSource = EPEForm1.SavedNames
        EmailNameText5.AutoCompleteCustomSource = EPEForm1.SavedNames
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton2.Click
        EPEForm1.ContinueOrCancel = "Cancel"
    End Sub

    Public Sub RepeatEmailButton(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepeatEmail_Button1.Click
        TextBox1.Text = EPEForm1.Email1Save
        TextBox2.Text = EPEForm1.Email2Save
        TextBox3.Text = EPEForm1.Email3Save
        TextBox4.Text = EPEForm1.Email4Save
        TextBox5.Text = EPEForm1.Email5Save
        EmailNameText1.Text = EPEForm1.Name1Save
        EmailNameText2.Text = EPEForm1.Name2Save
        EmailNameText3.Text = EPEForm1.Name3Save
        EmailNameText4.Text = EPEForm1.Name4Save
        EmailNameText5.Text = EPEForm1.Name5Save
    End Sub



    ''' <summary>
    ''' The purpose of this subroutine is to add names and email addresses to a text file that is used to 
    ''' store emails and names. This text file is used to autocomplete fields in the EmailPrompt form.
    ''' When finished, 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AddEmailsToDatabaseAndFinishEmailing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContinueButton.Click
        Dim SubjectLineString As String = EPEForm1.textBox_SubjectLine.Text

        Try
            ' For the first pass, EPEForm1.RepeatEmailsInEmailPrompt = False (onLoad) and the SavedEmail and SavedNames variables are set
            ' A check is made later to see if the EPEForm1.RepeatEmailsInEmailPrompt_checkbox is set and if so, the variable's
            ' value is changed.
            'If EPEForm1.RepeatEmailsInEmailPrompt = True And EPEForm1.SENDEMAILFINISHEDFLAGG = False Then
            '    RepeatEmail_Button1.PerformClick()
            'Else
            If TextBox1.Text <> "" Then
                EPEForm1.SavedEmails.Add(TextBox1.Text & "---" & EmailNameText1.Text)
                EPEForm1.SavedNames.Add(EmailNameText1.Text & "---" & TextBox1.Text) ' A space is added so when the tring is parsed on '!' it's not empty which could cause trouble
            End If
            If TextBox2.Text <> "" Then
                EPEForm1.SavedEmails.Add(TextBox2.Text & "---" & EmailNameText2.Text)
                EPEForm1.SavedNames.Add(EmailNameText2.Text & "---" & TextBox2.Text)
                If EmailNameText2.Text = "" Then
                    EmailNameText2.Text = " " ' introduce a space just in case no name is attached.
                End If
                If TextBox1.Text = "" Then
                    'MsgBox("Please do not skip rows when entering email addresses.")
                End If
            End If
            If TextBox3.Text <> "" Then
                EPEForm1.SavedEmails.Add(TextBox3.Text & "---" & EmailNameText3.Text)
                EPEForm1.SavedNames.Add(EmailNameText3.Text & "---" & TextBox3.Text)
                If EmailNameText3.Text = "" Then
                    EmailNameText3.Text = " " ' introduce a space just in case no name is attached.
                End If
                If TextBox2.Text = "" Then
                    ' TODO MsgBox("Please do not skip rows when entering email addresses.") (Will need to revisit this later)
                End If
            End If
            If TextBox4.Text <> "" Then
                EPEForm1.SavedEmails.Add(TextBox4.Text & "---" & EmailNameText4.Text)
                EPEForm1.SavedNames.Add(EmailNameText4.Text & "---" & TextBox4.Text)
                If EmailNameText4.Text = "" Then
                    EmailNameText4.Text = " " ' introduce a space
                End If
                If TextBox3.Text = "" Then
                    'MsgBox("Please do not skip rows when entering email addresses.")
                End If
            End If
            If TextBox5.Text <> "" Then
                EPEForm1.SavedEmails.Add(TextBox5.Text & "---" & EmailNameText5.Text)
                EPEForm1.SavedNames.Add(EmailNameText5.Text & "---" & TextBox5.Text)
                If EmailNameText5.Text = "" Then
                    EmailNameText5.Text = " " ' introduce a space
                End If
                If TextBox4.Text = "" Then
                    'MsgBox("Please do not skip rows when entering email addresses.")
                End If
            End If





            'UpdateAutoComplete() ' It looks like the TextBox##.AutoCompleteCustomSource changes automatically when SaavedEmails is updated
            EPEForm1.ContinueOrCancel = "Continue"
            'TextBox1.Focus()
            'If RepeatEmailsInEmailPrompt_Checkbox.Checked Then
            '    EPEForm1.RepeatEmailsInEmailPrompt = True
            'Else
            '    EPEForm1.RepeatEmailsInEmailPrompt = False
            'End If
            AdFileLabel.Text = EmailSetupForm.AdLabel2.Text ' Reset just in case this value is changed after on_load has executed
            IncludeAdCheckBox1.CheckState = EmailSetupForm.IncludeAdCheckBox.CheckState ' Reset
            'End If
        Catch ex As Exception
            Debug.Print("Problem getting names")

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncludeAdCheckBox1.CheckedChanged
        ' The way it is setup, the checkstate will originally take on the default. After that, it will maintain the last checkstate.
        'EPEForm1.MyEmailSetupForm.IncludeAdCheckBox.CheckState = CheckBox1.CheckState
    End Sub

    Private Sub SaveForLaterCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveForLaterCheckBox.CheckedChanged
        If SaveForLaterCheckBox.Checked Then
            ContinueButton.Text = "Send Later"
        Else
            ContinueButton.Text = "Send Email"
        End If
    End Sub

    Private Sub OpenImageFolderButton_Click(sender As System.Object, e As System.EventArgs) Handles OpenImageFolderButton.Click
        Try
            Process.Start("explorer.exe", EPEForm1.DefaultImageDirectory)
        Catch ex As Exception
            MsgBox("Error attempting to open the image folder. Please ensure that image folder is correct")
        End Try
    End Sub

    Private Sub ReSetOnShow(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
        AdFileLabel.Text = EmailSetupForm.AdLabel2.Text ' Reset just in case this value is changed after on_load has executed
        IncludeAdCheckBox1.CheckState = EmailSetupForm.IncludeAdCheckBox.CheckState ' Reset
        'If ApplyToAllCheckBox1.Checked Then
        '    RepeatEmailsInEmailPrompt_Checkbox.Checked = True
        'Else
        '    RepeatEmailsInEmailPrompt_Checkbox.Checked = False
        'End If
    End Sub

    Private Sub FormClose(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        EPEForm1.ContinueOrCancel = "Cancel"
        Me.Hide()
    End Sub

    'Private Sub CheckBox1_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles ApplyToAllCheckBox1.CheckedChanged
    '    If ApplyToAllCheckBox1.Checked Then
    '        RepeatEmailsInEmailPrompt_Checkbox.Checked = True
    '    Else
    '        RepeatEmailsInEmailPrompt_Checkbox.Checked = False
    '    End If
    'End Sub

    Private Sub SetEmailAndName(sender As System.Object, e As System.EventArgs) Handles TextBox1.Validating, TextBox2.Validating, TextBox3.Validating, TextBox4.Validating, TextBox5.Validating
        Dim tmp() As String
        Dim MySender As TextBox
        MySender = CType(sender, TextBox)
        'CType(sender, TextBox)
        Try
            tmp = Split(MySender.Text, "---")
            If tmp.Length > 1 Then
                MySender.Text = tmp(0)
                If MySender.Name = TextBox1.Name Then
                    EmailNameText1.Text = tmp(1)
                ElseIf MySender.Name = TextBox2.Name Then
                    EmailNameText2.Text = tmp(1)
                ElseIf MySender.Name = TextBox3.Name Then
                    EmailNameText3.Text = tmp(1)
                ElseIf MySender.Name = TextBox4.Name Then
                    EmailNameText4.Text = tmp(1)
                ElseIf MySender.Name = TextBox5.Name Then
                    EmailNameText5.Text = tmp(1)
                End If
                MySender.Text = tmp(0)
            End If
        Catch ex As Exception
            Debug.Print("Something Happened in SetEmailAndName()")
        End Try
    End Sub

    Private Sub SetNameAndEmail(sender As System.Object, e As System.EventArgs) Handles EmailNameText1.Validating, EmailNameText2.Validating, EmailNameText3.Validating, EmailNameText4.Validating, EmailNameText5.Validating
        Dim tmp() As String
        Dim MySender As TextBox
        MySender = CType(sender, TextBox)
        'CType(sender, TextBox)
        Try
            tmp = Split(MySender.Text, "---")
            If tmp.Length > 1 Then
                MySender.Text = tmp(0)
                If MySender.Name = EmailNameText1.Name Then
                    TextBox1.Text = tmp(1)
                ElseIf MySender.Name = EmailNameText2.Name Then
                    TextBox2.Text = tmp(1)
                ElseIf MySender.Name = EmailNameText3.Name Then
                    TextBox3.Text = tmp(1)
                ElseIf MySender.Name = EmailNameText4.Name Then
                    TextBox4.Text = tmp(1)
                ElseIf MySender.Name = EmailNameText5.Name Then
                    TextBox5.Text = tmp(1)
                End If
                MySender.Text = tmp(0)
            End If
        Catch ex As Exception
            Debug.Print("Something Happened in SetNameAndEmail()")
        End Try
    End Sub

    Private Sub Button_SaveAsDefault2_Click(sender As System.Object, e As System.EventArgs) Handles Button_SaveAsDefault2.Click
        EPEForm1.SaveAsXMLPerformClick()
    End Sub


    Private Sub CellPhoneCarrierCombobox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CellPhoneCarrierCombobox.SelectedIndexChanged
        Dim temp() As String
        Try
            temp = Split(CellPhoneCarrierCombobox.Text, "--")
            Dim MA As String = Trim(temp(1))
            If TextBox1.Text = "" Then
                TextBox1.Text = MA
            ElseIf TextBox2.Text = "" Then
                TextBox2.Text = MA
            ElseIf TextBox3.Text = "" Then
                TextBox3.Text = MA
            ElseIf TextBox4.Text = "" Then
                TextBox4.Text = MA
            ElseIf TextBox5.Text = "" Then
                TextBox5.Text = MA
            Else
                MsgBox("Error adding text to email address. You will need to enter in manually")
            End If
        Catch ex As Exception
            MsgBox("Error adding text to email address. You will need to enter in manually" & vbCrLf & ex.Message)
        End Try

    End Sub


    Private Sub RepeatEmailsInEmailPrompt_Checkbox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RepeatEmailsInEmailPrompt_Checkbox.CheckedChanged
        If RepeatEmailsInEmailPrompt_Checkbox.Checked Then
            EPEForm1.RepeatEmailsInEmailPrompt = True
        Else
            EPEForm1.RepeatEmailsInEmailPrompt = False
        End If
    End Sub
End Class