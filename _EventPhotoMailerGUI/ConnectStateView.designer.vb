<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnectStateView
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConnectStateView))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.gbxConnectStatusCtrl = New System.Windows.Forms.GroupBox
        Me.lblConnectStatus = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.gbxConnectStatusCtrl.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ball7.ico")
        Me.ImageList1.Images.SetKeyName(1, "Ball8.ico")
        Me.ImageList1.Images.SetKeyName(2, "Ball9.ico")
        Me.ImageList1.Images.SetKeyName(3, "Ball15.ico")
        '
        'gbxConnectStatusCtrl
        '
        Me.gbxConnectStatusCtrl.Controls.Add(Me.lblConnectStatus)
        Me.gbxConnectStatusCtrl.Location = New System.Drawing.Point(4, 4)
        Me.gbxConnectStatusCtrl.Name = "gbxConnectStatusCtrl"
        Me.gbxConnectStatusCtrl.Size = New System.Drawing.Size(262, 47)
        Me.gbxConnectStatusCtrl.TabIndex = 0
        Me.gbxConnectStatusCtrl.TabStop = False
        Me.gbxConnectStatusCtrl.Text = "Connection Status"
        '
        'lblConnectStatus
        '
        Me.lblConnectStatus.AutoSize = True
        Me.lblConnectStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblConnectStatus.ImageIndex = 1
        Me.lblConnectStatus.ImageList = Me.ImageList1
        Me.lblConnectStatus.Location = New System.Drawing.Point(7, 20)
        Me.lblConnectStatus.Name = "lblConnectStatus"
        Me.lblConnectStatus.Size = New System.Drawing.Size(121, 14)
        Me.lblConnectStatus.TabIndex = 0
        Me.lblConnectStatus.Text = "          Connection Type:"
        Me.lblConnectStatus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ConnectStateView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbxConnectStatusCtrl)
        Me.Name = "ConnectStateView"
        Me.Size = New System.Drawing.Size(273, 57)
        Me.gbxConnectStatusCtrl.ResumeLayout(False)
        Me.gbxConnectStatusCtrl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents gbxConnectStatusCtrl As System.Windows.Forms.GroupBox
    Friend WithEvents lblConnectStatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
