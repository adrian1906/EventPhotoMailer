<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailPrompt
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
        Me.Thumbnail_PictureBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Email_RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ContinueButton = New System.Windows.Forms.Button()
        Me.CancelButton2 = New System.Windows.Forms.Button()
        CType(Me.Thumbnail_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Thumbnail_PictureBox
        '
        Me.Thumbnail_PictureBox.Location = New System.Drawing.Point(23, 56)
        Me.Thumbnail_PictureBox.Name = "Thumbnail_PictureBox"
        Me.Thumbnail_PictureBox.Size = New System.Drawing.Size(123, 194)
        Me.Thumbnail_PictureBox.TabIndex = 0
        Me.Thumbnail_PictureBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(75, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(441, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Please enter the email addresses on separate lines."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Email_RichTextBox1
        '
        Me.Email_RichTextBox1.BulletIndent = 2
        Me.Email_RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Email_RichTextBox1.Location = New System.Drawing.Point(165, 56)
        Me.Email_RichTextBox1.Name = "Email_RichTextBox1"
        Me.Email_RichTextBox1.Size = New System.Drawing.Size(407, 194)
        Me.Email_RichTextBox1.TabIndex = 0
        Me.Email_RichTextBox1.Text = ""
        '
        'ContinueButton
        '
        Me.ContinueButton.Location = New System.Drawing.Point(267, 265)
        Me.ContinueButton.Name = "ContinueButton"
        Me.ContinueButton.Size = New System.Drawing.Size(75, 23)
        Me.ContinueButton.TabIndex = 2
        Me.ContinueButton.Text = "Continue"
        Me.ContinueButton.UseVisualStyleBackColor = True
        '
        'CancelButton2
        '
        Me.CancelButton2.Location = New System.Drawing.Point(412, 265)
        Me.CancelButton2.Name = "CancelButton2"
        Me.CancelButton2.Size = New System.Drawing.Size(75, 23)
        Me.CancelButton2.TabIndex = 3
        Me.CancelButton2.Text = "Cancel"
        Me.CancelButton2.UseVisualStyleBackColor = True
        '
        'EmailPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 312)
        Me.Controls.Add(Me.CancelButton2)
        Me.Controls.Add(Me.ContinueButton)
        Me.Controls.Add(Me.Email_RichTextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Thumbnail_PictureBox)
        Me.Name = "EmailPrompt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EmailPrompt"
        CType(Me.Thumbnail_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Thumbnail_PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Email_RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ContinueButton As System.Windows.Forms.Button
    Friend WithEvents CancelButton2 As System.Windows.Forms.Button
End Class
