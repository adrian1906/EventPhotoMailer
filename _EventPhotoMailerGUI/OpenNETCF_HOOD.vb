Imports OpenNETCF
Imports OpenNETCF.Net
Module OpenNETCF_HOOD
    'Private progressBar1 As System.Windows.Forms.ProgressBar
    'Private acs As OpenNETCF.Net.AdapterCollection
    'Private acs As OpenNETCF.Net.NetworkInformation.NetworkInterface
    'Private label1 As System.Windows.Forms.Label
    'Private Sub checknetworkconnectionprogressbar(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Function checknetworkconnectionprogressbar(ByVal progressBar1 As ProgressBar, ByVal label1 As Label, ByVal ConnectionStatusResultLabel As Label) As String
        'acs = OpenNETCF.Net.Networking.GetAdapters()
        'Dim acs = OpenNETCF.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces
        Dim acs = OpenNETCF.Net.NetworkInformation.
        Dim NETFOUND As String
        If acs.Count > 0 Then

            ' -90 db means a bad connection
            ' -50 -> good
            ' 0 -> no wireless connection
            progressBar1.Minimum = 0
            progressBar1.Maximum = 100
            progressBar1.Value = 0
            progressBar1.Value = acs.Item(0).SignalStrength.Decibels
            progressBar1.Value = acs.
            ' additional infos

            label1.Text = ""
            If acs.Item(0).IsWireless Then
                label1.Text += "Is wireless" & vbLf
            Else
                label1.Text += "Is wired" & vbLf
            End If

            label1.Text += "DHCP server: " + acs.Item(0).DhcpServer & vbLf
            label1.Text += "Gateway: " + acs.Item(0).Gateway & vbLf
            label1.Text += "Current IP: " + acs.Item(0).CurrentIpAddress & vbLf
            label1.Text += "Current acces point: " + acs.Item(0).AssociatedAccessPoint & vbLf

            'timer1.Enabled = True
            ConnectionStatusResultLabel.Text = "Connected to the internet"
            NETFOUND = "1"
        Else
            ConnectionStatusResultLabel.Text = "Not Connected to the internet"
            NETFOUND = "2"
        End If
        Return NETFOUND
    End Function

    'Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    progressBar1.Value = acs.Item(0).SignalStrength.Decibels
    'End Sub

End Module
