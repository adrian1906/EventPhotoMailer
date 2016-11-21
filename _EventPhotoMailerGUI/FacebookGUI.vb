Public Class FacebookGUI
    Inherits System.Windows.Forms.Form

    Private Sub FacebookGUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        FBAuthTitleLabel.Left = 0
        FBAuthTitleLabel.Width = Me.Width
        FBAuthTitleLabel.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    Public Sub Closeing() Handles Me.FormClosing
        EPEForm1.IsForm2Open = False
    End Sub

   
End Class