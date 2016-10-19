Public Class ProductpmModel
    Public m_num As String
    Public m_nik As String
    Public m_name As String
    Public Property num() As String
        Get
            Return m_num
        End Get
        Set(value As String)
            m_num = value
        End Set
    End Property
    Public Property nik() As String
        Get
            Return m_nik
        End Get
        Set(value As String)
            m_nik = value
        End Set
    End Property
    Public Property name() As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property
End Class
