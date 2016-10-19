Namespace Models
    Public Class m_sboModel

        Private _sbo_code As String
        Public Property sbo_code() As String
            Get
                Return _sbo_code
            End Get
            Set(ByVal value As String)
                _sbo_code = value
            End Set
        End Property

        Private _bo_code As String
        Public Property bo_code() As String
            Get
                Return _bo_code
            End Get
            Set(ByVal value As String)
                _bo_code = value
            End Set
        End Property

        Private _sbo_description As String
        Public Property sbo_description() As String
            Get
                Return _sbo_description
            End Get
            Set(ByVal value As String)
                _sbo_description = value
            End Set
        End Property

        Private _sbo_address As String
        Public Property sbo_address() As String
            Get
                Return _sbo_address
            End Get
            Set(ByVal value As String)
                _sbo_address = value
            End Set
        End Property

        Private _sbo_sequence_code As Integer
        Public Property sbo_sequence_code() As Integer
            Get
                Return _sbo_sequence_code
            End Get
            Set(ByVal value As Integer)
                _sbo_sequence_code = value
            End Set
        End Property

        Private _sbo_status As Integer
        Public Property sbo_status() As Integer
            Get
                Return _sbo_status
            End Get
            Set(ByVal value As Integer)
                _sbo_status = value
            End Set
        End Property

    End Class
End Namespace

