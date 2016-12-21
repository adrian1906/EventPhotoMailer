Public Class CustomNotifyForm
    ' Idea came from https://www.youtube.com/watch?v=9GnpCtQpEYI
    Dim i As Integer = 0
    Dim MyWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim MyHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Dim Y As Integer = 0
    Dim X As Integer = 0
    Private Sub CustomNotifyForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim X, Y As Integer
        X = MyWidth
        Y = MyHeight
        Me.Location = New Point(X, Y)
        ' 200 is based on the dimension of the form.
    End Sub

    Public Sub ShowNotifyBox(ByVal ImageAddress As String, ByVal NotifyString As String, XX As Integer, YY As Integer)
        Try
            Me.Show()
            Me.Activate()
            Me.Visible = False
            AutosizeImage(ImageAddress, Notify_PictureBox, PhotoLabel_Label)
            NotifyRichTextBox1.Text = NotifyString
            PhotoLabel_Label.Text = ImageAddress
            'Me.Location = New Point(MyWidth - Me.Size.Width, MyHeight - Me.Size.Height)
            Me.Location = New Point(XX, YY)
            Me.Visible = True
            pause(1000)
            While Me.Opacity > 0
                Me.Opacity -= 0.02
                pause(25)
            End While
            Me.Close()
        Catch ex As Exception
            Debug.Print("Problem with showing notify box")
            Me.Close()
        End Try
    End Sub

    Public Function SetNotifyBoxLocation(ByVal ESF As EmailSetupForm) As List(Of Integer)
        Dim MyList As New List(Of Integer)
        'Dim MyWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        'Dim MyHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        'Dim X, Y As Integer
        If ESF.LowerLeftRadioButton.Checked Then
            X = 0
            Y = MyHeight - Me.Height
        ElseIf ESF.LowerRightRadioButton.Checked Then
            X = MyWidth - Me.Size.Width
            Y = MyHeight - Me.Height
        ElseIf ESF.UpperRightRadioButton.Checked Then
            X = MyWidth - Me.Size.Width
            Y = 0
        Else ' EmailSetupForm.UpperLeftRadioButton.Checked Then
            X = 0
            Y = 0
        End If
        MyList.Add(X)
        MyList.Add(Y)
        Return MyList
    End Function
End Class