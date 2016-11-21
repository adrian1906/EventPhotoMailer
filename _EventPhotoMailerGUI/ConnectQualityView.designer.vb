<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnectQualityView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.gbxConnectStatusCtrl = New System.Windows.Forms.GroupBox
        Me.lblConnectStatus = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.gbxConnectStatusCtrl.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxConnectStatusCtrl
        '
        Me.gbxConnectStatusCtrl.Controls.Add(Me.lblConnectStatus)
        Me.gbxConnectStatusCtrl.Location = New System.Drawing.Point(3, 3)
        Me.gbxConnectStatusCtrl.Name = "gbxConnectStatusCtrl"
        Me.gbxConnectStatusCtrl.Size = New System.Drawing.Size(214, 47)
        Me.gbxConnectStatusCtrl.TabIndex = 1
        Me.gbxConnectStatusCtrl.TabStop = False
        Me.gbxConnectStatusCtrl.Text = "Connection Status"
        '
        'lblConnectStatus
        '
        Me.lblConnectStatus.AutoSize = True
        Me.lblConnectStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConnectStatus.ForeColor = System.Drawing.Color.Red
        Me.lblConnectStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblConnectStatus.ImageIndex = 3
        Me.lblConnectStatus.Location = New System.Drawing.Point(7, 20)
        Me.lblConnectStatus.Name = "lblConnectStatus"
        Me.lblConnectStatus.Size = New System.Drawing.Size(135, 14)
        Me.lblConnectStatus.TabIndex = 0
        Me.lblConnectStatus.Text = "Connection Quality:  Off"
        Me.lblConnectStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1500
        '
        'ConnectQualityView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbxConnectStatusCtrl)
        Me.Name = "ConnectQualityView"
        Me.Size = New System.Drawing.Size(225, 57)
        Me.gbxConnectStatusCtrl.ResumeLayout(False)
        Me.gbxConnectStatusCtrl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbxConnectStatusCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents lblConnectStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
