Namespace Models
    Public Class m_regionalModel

        Private _reg_id As String
        Public Property reg_id() As String
            Get
                Return _reg_id
            End Get
            Set(ByVal value As String)
                _reg_id = value
            End Set
        End Property

        Private _reg_description As String
        Public Property reg_description() As String
            Get
                Return _reg_description
            End Get
            Set(ByVal value As String)
                _reg_description = value
            End Set
        End Property

        Private _reg_functionary As String
        Public Property reg_functionary() As String
            Get
                Return _reg_functionary
            End Get
            Set(ByVal value As String)
                _reg_functionary = value
            End Set
        End Property

        Private _reg_functionary_name As String
        Public Property reg_functionary_name() As String
            Get
                Return _reg_functionary_name
            End Get
            Set(ByVal value As String)
                _reg_functionary_name = value
            End Set
        End Property

        Private _Nama As String
        Public Property Nama() As String
            Get
                Return _Nama
            End Get
            Set(ByVal value As String)
                _Nama = value
            End Set
        End Property

        Private _reg_sequence_code As Integer
        Public Property reg_sequence_code() As Integer
            Get
                Return _reg_sequence_code
            End Get
            Set(ByVal value As Integer)
                _reg_sequence_code = value
            End Set
        End Property

        Private _reg_status As Integer
        Public Property reg_status() As Integer
            Get
                Return _reg_status
            End Get
            Set(ByVal value As Integer)
                _reg_status = value
            End Set
        End Property

    End Class
End Namespace

