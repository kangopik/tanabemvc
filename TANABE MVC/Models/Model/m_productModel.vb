Namespace Models
    Public Class m_productModel

        Private _prd_code As String
        Public Property prd_code() As String
            Get
                Return _prd_code
            End Get
            Set(ByVal value As String)
                _prd_code = value
            End Set
        End Property

        Private _prd_name As String
        Public Property prd_name() As String
            Get
                Return _prd_name
            End Get
            Set(ByVal value As String)
                _prd_name = value
            End Set
        End Property

        Private _prd_focus As String
        Public Property prd_focus() As String
            Get
                Return _prd_focus
            End Get
            Set(ByVal value As String)
                _prd_focus = value
            End Set
        End Property

        Private _prd_type As String
        Public Property prd_type() As String
            Get
                Return _prd_type
            End Get
            Set(ByVal value As String)
                _prd_type = value
            End Set
        End Property

        Private _prd_price As Double
        Public Property prd_price() As Double
            Get
                Return _prd_price
            End Get
            Set(ByVal value As Double)
                _prd_price = value
            End Set
        End Property

        Private _prd_group As String
        Public Property prd_group() As String
            Get
                Return _prd_group
            End Get
            Set(ByVal value As String)
                _prd_group = value
            End Set
        End Property

        Private _prd_status As Integer
        Public Property prd_status() As Integer
            Get
                Return _prd_status
            End Get
            Set(ByVal value As Integer)
                _prd_status = value
            End Set
        End Property

        Private _prd_price_valid_year As Integer
        Public Property prd_price_valid_year() As Integer
            Get
                Return _prd_price_valid_year
            End Get
            Set(ByVal value As Integer)
                _prd_price_valid_year = value
            End Set
        End Property

    End Class
End Namespace

