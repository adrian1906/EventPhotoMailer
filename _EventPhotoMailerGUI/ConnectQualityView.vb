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
''' 
''' This control shows status as a function of whether or not the internet connection remains active
''' for a period of two seconds (you can adjust that by setting the timer value to something
''' other than 1500 msec).  The idea is to show good connections, intermittent connections, and
''' off line connections based upon polling for the differnces between the current and previous
''' status reports.
''' </summary>
''' <remarks></remarks>
''' 


Public Class ConnectQualityView


#Region "Declarations"

    Dim ConnectionQualityString As String = "Off"

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


    Private Sub ConnectQualityView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Timer1.Enabled = True
        Me.DoubleBuffered = True

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        lblConnectStatus.Refresh()

        Dim blnState As Boolean
        blnState = CheckInetConnection()

    End Sub


    Function CheckInetConnection() As Boolean

        Dim lngFlags As Long

        If InternetGetConnectedState(lngFlags, 0) Then
            ' True
            If lngFlags And InetConnState.lan Then
                Select Case ConnectionQualityString
                    Case "Good"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Off"
                        lblConnectStatus.ForeColor = Color.DarkOrange
                        lblConnectStatus.Text = "Connection Quality:  Intermittent"
                        ConnectionQualityString = "Intermittent"
                End Select
                Me.Refresh()
            ElseIf lngFlags And InetConnState.modem Then
                Select Case ConnectionQualityString
                    Case "Good"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Off"
                        lblConnectStatus.ForeColor = Color.DarkOrange
                        lblConnectStatus.Text = "Connection Quality:  Intermittent"
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.configured Then
                Select Case ConnectionQualityString
                    Case "Good"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Off"
                        lblConnectStatus.ForeColor = Color.DarkOrange
                        lblConnectStatus.Text = "Connection Quality:  Intermittent"
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.proxy Then
                Select Case ConnectionQualityString
                    Case "Good"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Off"
                        lblConnectStatus.ForeColor = Color.DarkOrange
                        lblConnectStatus.Text = "Connection Quality:  Intermittent"
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.ras Then
                Select Case ConnectionQualityString
                    Case "Good"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Off"
                        lblConnectStatus.ForeColor = Color.DarkOrange
                        lblConnectStatus.Text = "Connection Quality:  Intermittent"
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.offline Then
                Select Case ConnectionQualityString
                    Case "Good"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        lblConnectStatus.ForeColor = Color.Green
                        lblConnectStatus.Text = "Connection Quality:  Good"
                        ConnectionQualityString = "Good"
                    Case "Off"
                        lblConnectStatus.ForeColor = Color.DarkOrange
                        lblConnectStatus.Text = "Connection Quality:  Intermittent"
                        ConnectionQualityString = "Intermittent"
                End Select
            End If
        Else
            ' False
            Select Case ConnectionQualityString
                Case "Good"
                    lblConnectStatus.ForeColor = Color.DarkOrange
                    lblConnectStatus.Text = "Connection Quality:  Intermittent"
                    ConnectionQualityString = "Intermittent"
                Case "Intermittent"
                    lblConnectStatus.ForeColor = Color.Red
                    lblConnectStatus.Text = "Connection Quality:  Off"
                    ConnectionQualityString = "Off"
                Case "Off"
                    lblConnectStatus.ForeColor = Color.Red
                    lblConnectStatus.Text = "Connection Quality:  Off"
                    ConnectionQualityString = "Off"
            End Select
        End If

    End Function


#End Region


End Class
