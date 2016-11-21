Public Class EmailPrompt

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContinueButton.Click
        Form1.ContinueOrCancel = "Continue"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton2.Click
        Form1.ContinueOrCancel = "Cancel"
    End Sub
End Class