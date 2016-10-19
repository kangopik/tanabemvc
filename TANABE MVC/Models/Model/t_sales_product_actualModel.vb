Namespace Models
    Public Class t_sales_product_actualModel

        Private _spa_id As Int64
        Public Property spa_id() As Int64
            Get
                Return _spa_id
            End Get
            Set(ByVal value As Int64)
                _spa_id = value
            End Set
        End Property

        Private _sp_id As Int64
        Public Property sp_id() As Int64
            Get
                Return _sp_id
            End Get
            Set(ByVal value As Int64)
                _sp_id = value
            End Set
        End Property

        Private _spa_date As DateTime
        Public Property spa_date() As DateTime
            Get
                Return _spa_date
            End Get
            Set(ByVal value As DateTime)
                _spa_date = value
            End Set
        End Property

        Private _spa_quantity As Int64
        Public Property spa_quantity() As Int64
            Get
                Return _spa_quantity
            End Get
            Set(ByVal value As Int64)
                _spa_quantity = value
            End Set
        End Property

        Private _spa_date_saved As DateTime
        Public Property spa_date_saved() As DateTime
            Get
                Return _spa_date_saved
            End Get
            Set(ByVal value As DateTime)
                _spa_date_saved = value
            End Set
        End Property

        Private _spa_note As String
        Public Property spa_note() As String
            Get
                Return _spa_note
            End Get
            Set(ByVal value As String)
                _spa_note = value
            End Set
        End Property

    End Class
End Namespace
