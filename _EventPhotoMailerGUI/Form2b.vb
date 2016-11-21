Public Class Form2
    Inherits System.Windows.Forms.Form
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Button_SaveAsDefault2.Click, AddressOf Form1.SaveAsDefault
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()
        Try
            EmailMasterListFilename.Text = OpenFileDialog1.FileName
        Catch ex As Exception
            ' just don't show anything
        End Try
    End Sub
End Class