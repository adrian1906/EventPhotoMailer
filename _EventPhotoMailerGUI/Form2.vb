Public Class Form2
    Inherits System.Windows.Forms.Form
    Public myCaller As Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Button_SaveAsDefault2.Click, AddressOf Form1.Button_SaveAsDefault_Click
    End Sub
End Class