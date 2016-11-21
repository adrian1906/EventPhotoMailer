<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacebookGUI
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
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.LoginCountDownLabel = New System.Windows.Forms.ToolStripLabel()
        Me.LoginTimerLabel = New System.Windows.Forms.ToolStripLabel()
        Me.FBAuthTitleLabel = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(12, 83)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(768, 432)
        Me.WebBrowser1.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.LoginCountDownLabel, Me.LoginTimerLabel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(792, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripLabel1.Text = "Login Timer:"
        '
        'LoginCountDownLabel
        '
        Me.LoginCountDownLabel.Name = "LoginCountDownLabel"
        Me.LoginCountDownLabel.Size = New System.Drawing.Size(0, 22)
        '
        'LoginTimerLabel
        '
        Me.LoginTimerLabel.Name = "LoginTimerLabel"
        Me.LoginTimerLabel.Size = New System.Drawing.Size(19, 22)
        Me.LoginTimerLabel.Text = "10"
        '
        'FBAuthTitleLabel
        '
        Me.FBAuthTitleLabel.AutoSize = True
        Me.FBAuthTitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FBAuthTitleLabel.Location = New System.Drawing.Point(12, 49)
        Me.FBAuthTitleLabel.Name = "FBAuthTitleLabel"
        Me.FBAuthTitleLabel.Size = New System.Drawing.Size(639, 31)
        Me.FBAuthTitleLabel.TabIndex = 3
        Me.FBAuthTitleLabel.Text = "Event Photo Emailer - Facebook Authorization Page"
        Me.FBAuthTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FacebookGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.FBAuthTitleLabel)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Name = "FacebookGUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Event Photo Emailer - Facebook Login"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LoginCountDownLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents FBAuthTitleLabel As System.Windows.Forms.Label
    Friend WithEvents LoginTimerLabel As System.Windows.Forms.ToolStripLabel
End Class
