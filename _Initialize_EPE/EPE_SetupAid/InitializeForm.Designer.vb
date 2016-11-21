<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InitializeEPE_Form
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CreateImagesButton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.UninstallButton = New System.Windows.Forms.Button()
        Me.DoneLabel = New System.Windows.Forms.Label()
        Me.DarkRoomStatusLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(93, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(321, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Event Photo Emailer- Initial Setup"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(171, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(198, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Darkroom Pro Setup"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(496, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Generate Test Images and Email/Filename Directory"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(66, 169)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(196, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Install Event Photo Emailer Printers"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(188, 250)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(165, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Setup Darkroom Assembly"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(138, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(256, 24)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Darkroom Assembly Setup"
        Me.Label4.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(109, 102)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(211, 20)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Text = "Enter Email Address"
        '
        'CreateImagesButton
        '
        Me.CreateImagesButton.Location = New System.Drawing.Point(326, 99)
        Me.CreateImagesButton.Name = "CreateImagesButton"
        Me.CreateImagesButton.Size = New System.Drawing.Size(91, 23)
        Me.CreateImagesButton.TabIndex = 7
        Me.CreateImagesButton.Text = "Create Images"
        Me.CreateImagesButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Working Directory:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(106, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Working Directory:"
        '
        'UninstallButton
        '
        Me.UninstallButton.Location = New System.Drawing.Point(268, 169)
        Me.UninstallButton.Name = "UninstallButton"
        Me.UninstallButton.Size = New System.Drawing.Size(196, 23)
        Me.UninstallButton.TabIndex = 10
        Me.UninstallButton.Text = "Un-Install Event Photo Emailer Printers"
        Me.UninstallButton.UseVisualStyleBackColor = True
        '
        'DoneLabel
        '
        Me.DoneLabel.AutoSize = True
        Me.DoneLabel.Location = New System.Drawing.Point(438, 105)
        Me.DoneLabel.Name = "DoneLabel"
        Me.DoneLabel.Size = New System.Drawing.Size(33, 13)
        Me.DoneLabel.TabIndex = 11
        Me.DoneLabel.Text = "Done"
        Me.DoneLabel.Visible = False
        '
        'DarkRoomStatusLabel
        '
        Me.DarkRoomStatusLabel.AutoSize = True
        Me.DarkRoomStatusLabel.Location = New System.Drawing.Point(149, 195)
        Me.DarkRoomStatusLabel.Name = "DarkRoomStatusLabel"
        Me.DarkRoomStatusLabel.Size = New System.Drawing.Size(33, 13)
        Me.DarkRoomStatusLabel.TabIndex = 12
        Me.DarkRoomStatusLabel.Text = "Done"
        Me.DarkRoomStatusLabel.Visible = False
        '
        'InitializeEPE_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 305)
        Me.Controls.Add(Me.DarkRoomStatusLabel)
        Me.Controls.Add(Me.DoneLabel)
        Me.Controls.Add(Me.UninstallButton)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CreateImagesButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "InitializeEPE_Form"
        Me.Text = "Initialize Event Photo Emailer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CreateImagesButton As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UninstallButton As System.Windows.Forms.Button
    Friend WithEvents DoneLabel As System.Windows.Forms.Label
    Friend WithEvents DarkRoomStatusLabel As System.Windows.Forms.Label

End Class
