<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomNotifyForm
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
        Me.PhotoLabel_Label = New System.Windows.Forms.Label()
        Me.Notify_PictureBox = New System.Windows.Forms.PictureBox()
        Me.NotifyRichTextBox1 = New System.Windows.Forms.RichTextBox()
        CType(Me.Notify_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PhotoLabel_Label
        '
        Me.PhotoLabel_Label.AutoSize = True
        Me.PhotoLabel_Label.Location = New System.Drawing.Point(2, 114)
        Me.PhotoLabel_Label.Name = "PhotoLabel_Label"
        Me.PhotoLabel_Label.Size = New System.Drawing.Size(49, 13)
        Me.PhotoLabel_Label.TabIndex = 17
        Me.PhotoLabel_Label.Text = "Photo ID"
        '
        'Notify_PictureBox
        '
        Me.Notify_PictureBox.Location = New System.Drawing.Point(5, 9)
        Me.Notify_PictureBox.Name = "Notify_PictureBox"
        Me.Notify_PictureBox.Size = New System.Drawing.Size(87, 97)
        Me.Notify_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Notify_PictureBox.TabIndex = 16
        Me.Notify_PictureBox.TabStop = False
        '
        'NotifyRichTextBox1
        '
        Me.NotifyRichTextBox1.Location = New System.Drawing.Point(98, 9)
        Me.NotifyRichTextBox1.Name = "NotifyRichTextBox1"
        Me.NotifyRichTextBox1.Size = New System.Drawing.Size(169, 97)
        Me.NotifyRichTextBox1.TabIndex = 18
        Me.NotifyRichTextBox1.Text = ""
        '
        'CustomNotifyForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(279, 136)
        Me.Controls.Add(Me.NotifyRichTextBox1)
        Me.Controls.Add(Me.PhotoLabel_Label)
        Me.Controls.Add(Me.Notify_PictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CustomNotifyForm"
        Me.Text = "CustomNotifyForm"
        CType(Me.Notify_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PhotoLabel_Label As System.Windows.Forms.Label
    Friend WithEvents Notify_PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NotifyRichTextBox1 As System.Windows.Forms.RichTextBox
End Class
