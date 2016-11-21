Public Class WirelessInfoHood
    Private _InstanceName As String
    Private _Bars As Integer

    Public Property InstanceName() As String
        Get
            Return _InstanceName
        End Get
        Set(ByVal value As String)
            _InstanceName = value
        End Set
    End Property
    Public Property Bars() As Integer
        Get
            Return _Bars
        End Get
        Set(ByVal value As Integer)
            _Bars = value
        End Set
    End Property
End Class