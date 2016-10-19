Namespace Models
    Public Class m_boModel

        Private _bo_code As String
        Public Property bo_code() As String
            Get
                Return _bo_code
            End Get
            Set(ByVal value As String)
                _bo_code = value
            End Set
        End Property

        Private _reg_id As String
        Public Property reg_id() As String
            Get
                Return _reg_id
            End Get
            Set(ByVal value As String)
                _reg_id = value
            End Set
        End Property

        Private _bo_description As String
        Public Property bo_description() As String
            Get
                Return _bo_description
            End Get
            Set(ByVal value As String)
                _bo_description = value
            End Set
        End Property

        Private _bo_address As String
        Public Property bo_address() As String
            Get
                Return _bo_address
            End Get
            Set(ByVal value As String)
                _bo_address = value
            End Set
        End Property

        Private _bo_sequence_code As Integer
        Public Property bo_sequence_code() As Integer
            Get
                Return _bo_sequence_code
            End Get
            Set(ByVal value As Integer)
                _bo_sequence_code = value
            End Set
        End Property

        Private _bo_am As String
        Public Property bo_am() As String
            Get
                Return _bo_am
            End Get
            Set(ByVal value As String)
                _bo_am = value
            End Set
        End Property

        Private _bo_status As Integer
        Public Property bo_status() As Integer
            Get
                Return _bo_status
            End Get
            Set(ByVal value As Integer)
                _bo_status = value
            End Set
        End Property

        Private _bo_area As String
        Public Property bo_area() As String
            Get
                Return _bo_area
            End Get
            Set(ByVal value As String)
                _bo_area = value
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

    End Class
End Namespace

