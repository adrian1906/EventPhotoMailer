<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.textBox_MailServer = New System.Windows.Forms.TextBox()
        Me.label4_outgoing = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textBox_Username = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textBox_Password = New System.Windows.Forms.TextBox()
        Me.Label7_port = New System.Windows.Forms.Label()
        Me.PortBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button_SaveAsDefault2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FacebookLoginEmailTextbox = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'textBox_MailServer
        '
        Me.textBox_MailServer.Location = New System.Drawing.Point(24, 97)
        Me.textBox_MailServer.Name = "textBox_MailServer"
        Me.textBox_MailServer.Size = New System.Drawing.Size(322, 20)
        Me.textBox_MailServer.TabIndex = 113
        '
        'label4_outgoing
        '
        Me.label4_outgoing.AutoSize = True
        Me.label4_outgoing.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4_outgoing.Location = New System.Drawing.Point(21, 78)
        Me.label4_outgoing.Name = "label4_outgoing"
        Me.label4_outgoing.Size = New System.Drawing.Size(163, 16)
        Me.label4_outgoing.TabIndex = 114
        Me.label4_outgoing.Text = "Outgoing Email Server"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Username"
        '
        'textBox_Username
        '
        Me.textBox_Username.Location = New System.Drawing.Point(24, 145)
        Me.textBox_Username.Name = "textBox_Username"
        Me.textBox_Username.Size = New System.Drawing.Size(322, 20)
        Me.textBox_Username.TabIndex = 115
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Password"
        '
        'textBox_Password
        '
        Me.textBox_Password.Location = New System.Drawing.Point(27, 193)
        Me.textBox_Password.Name = "textBox_Password"
        Me.textBox_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.textBox_Password.Size = New System.Drawing.Size(322, 20)
        Me.textBox_Password.TabIndex = 117
        '
        'Label7_port
        '
        Me.Label7_port.AutoSize = True
        Me.Label7_port.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7_port.Location = New System.Drawing.Point(360, 78)
        Me.Label7_port.Name = "Label7_port"
        Me.Label7_port.Size = New System.Drawing.Size(36, 16)
        Me.Label7_port.TabIndex = 120
        Me.Label7_port.Text = "Port"
        '
        'PortBox
        '
        Me.PortBox.Location = New System.Drawing.Point(363, 97)
        Me.PortBox.Name = "PortBox"
        Me.PortBox.Size = New System.Drawing.Size(48, 20)
        Me.PortBox.TabIndex = 119
        Me.PortBox.Text = "25"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(391, 37)
        Me.Label3.TabIndex = 121
        Me.Label3.Text = "Email Configuration Editor"
        '
        'Button_SaveAsDefault2
        '
        Me.Button_SaveAsDefault2.Location = New System.Drawing.Point(12, 325)
        Me.Button_SaveAsDefault2.Name = "Button_SaveAsDefault2"
        Me.Button_SaveAsDefault2.Size = New System.Drawing.Size(75, 23)
        Me.Button_SaveAsDefault2.TabIndex = 122
        Me.Button_SaveAsDefault2.Text = "Save"
        Me.Button_SaveAsDefault2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(363, 325)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 123
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(190, 238)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 16)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Settings (Optional)"
        '
        'FacebookLoginEmailTextbox
        '
        Me.FacebookLoginEmailTextbox.Location = New System.Drawing.Point(27, 287)
        Me.FacebookLoginEmailTextbox.Name = "FacebookLoginEmailTextbox"
        Me.FacebookLoginEmailTextbox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.FacebookLoginEmailTextbox.Size = New System.Drawing.Size(322, 20)
        Me.FacebookLoginEmailTextbox.TabIndex = 125
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.facebook_image
        Me.PictureBox1.Image = Global.WindowsApplication1.My.Resources.Resources.facebook_image
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(107, 229)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(77, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 127
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 268)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 16)
        Me.Label5.TabIndex = 128
        Me.Label5.Text = "Facebook Login Email:"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 360)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.FacebookLoginEmailTextbox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button_SaveAsDefault2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7_port)
        Me.Controls.Add(Me.PortBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.textBox_Password)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.textBox_Username)
        Me.Controls.Add(Me.label4_outgoing)
        Me.Controls.Add(Me.textBox_MailServer)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email Configuration Editor"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents textBox_MailServer As System.Windows.Forms.TextBox
    Friend WithEvents label4_outgoing As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents textBox_Username As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents textBox_Password As System.Windows.Forms.TextBox
    Friend WithEvents Label7_port As System.Windows.Forms.Label
    Friend WithEvents PortBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button_SaveAsDefault2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FacebookLoginEmailTextbox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
