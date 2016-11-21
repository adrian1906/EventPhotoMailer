''' <summary>
''' ConnectStateView Control
''' 
''' The purpose of this control is provide a windows application with
''' the means to continuously test for the presence of a live internet
''' connection; this merely uses the wininet.dll library's InterGetConnectedState
''' function to poll for the presence of an active connection.  There is nothing
''' new or interesting about the manner in which this dll function is imported into
''' or used by this control.
''' 
''' The control was originally intended to support something of a smart
''' client application where transfer of data to a web service could only occur
''' during time periods in which an active connection existed; this control was used
''' to give the user an indication of the status of the connection.
''' 
''' A timer control is used to continuously poll the status of the connection; this
''' timer is set to trip every 1000 msec as it is not critically important that the status be
''' updated more than once a second.
''' </summary>
''' <remarks></remarks>


Public Class ConnectStateView

#Region "Declarations"

    Private ConnectionStateString As String

    Private Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef _
    lpSFlags As Int32, ByVal dwReserved As Int32) As Boolean

    Public Enum InetConnState
        modem = &H1
        lan = &H2
        proxy = &H4
        ras = &H10
        offline = &H20
        configured = &H40
    End Enum

#End Region


#Region "Control Methods"

    Private Sub ConnectStateView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Timer1.Enabled = True

    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim blnState As Boolean
        blnState = CheckInetConnection()
        lblConnectStatus.Text = "          Connection Type:  " & ConnectionStateString

    End Sub


    Private Function CheckInetConnection() As Boolean

        Dim lngFlags As Long

        If InternetGetConnectedState(lngFlags, 0) Then
            ' True
            If lngFlags And InetConnState.lan Then
                ConnectionStateString = "LAN."
                lblConnectStatus.Image = ImageList1.Images(1)
            ElseIf lngFlags And InetConnState.modem Then
                ConnectionStateString = "Modem."
                lblConnectStatus.Image = ImageList1.Images(1)
            ElseIf lngFlags And InetConnState.configured Then
                ConnectionStateString = "Configured."
                lblConnectStatus.Image = ImageList1.Images(1)
            ElseIf lngFlags And InetConnState.proxy Then
                ConnectionStateString = "Proxy"
                lblConnectStatus.Image = ImageList1.Images(1)
            ElseIf lngFlags And InetConnState.ras Then
                ConnectionStateString = "RAS."
                lblConnectStatus.Image = ImageList1.Images(1)
            ElseIf lngFlags And InetConnState.offline Then
                ConnectionStateString = "Offline."
                Me.lblConnectStatus.Image = ImageList1.Images(2)
            End If
        Else
            ' False
            ConnectionStateString = "Not Connected."
            lblConnectStatus.Image = ImageList1.Images(3)
        End If

    End Function


#End Region


End Class
