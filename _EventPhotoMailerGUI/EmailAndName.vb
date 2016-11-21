Public Class EmailAndName
    Private _name As String
    Private _email As String
    Private _filenameshort As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
        End Set
    End Property

    Public Property FileNameShort() As String
        Get
            Return _filenameshort
        End Get
        Set(value As String)
            _filenameshort = value
        End Set
    End Property
End Class
