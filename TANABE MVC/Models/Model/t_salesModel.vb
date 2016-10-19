Namespace Models
    Public Class t_salesModel

        Private _sales_id As String
        Public Property sales_id() As String
            Get
                Return _sales_id
            End Get
            Set(ByVal value As String)
                _sales_id = value
            End Set
        End Property

        Private _rep_id As String
        Public Property rep_id() As String
            Get
                Return _rep_id
            End Get
            Set(ByVal value As String)
                _rep_id = value
            End Set
        End Property

        Private _sales_date_plan As Integer
        Public Property sales_date_plan() As Integer
            Get
                Return _sales_date_plan
            End Get
            Set(ByVal value As Integer)
                _sales_date_plan = value
            End Set
        End Property

        Private _sales_year_plan As Integer
        Public Property sales_year_plan() As Integer
            Get
                Return _sales_year_plan
            End Get
            Set(ByVal value As Integer)
                _sales_year_plan = value
            End Set
        End Property

        Private _sales_plan As Integer
        Public Property sales_plan() As Integer
            Get
                Return _sales_plan
            End Get
            Set(ByVal value As Integer)
                _sales_plan = value
            End Set
        End Property

        Private _sales_code As String
        Public Property sales_code() As String
            Get
                Return _sales_code
            End Get
            Set(ByVal value As String)
                _sales_code = value
            End Set
        End Property

        Private _sales_realization As Integer
        Public Property sales_realization() As Integer
            Get
                Return _sales_realization
            End Get
            Set(ByVal value As Integer)
                _sales_realization = value
            End Set
        End Property

        Private _sales_info As String
        Public Property sales_info() As String
            Get
                Return _sales_info
            End Get
            Set(ByVal value As String)
                _sales_info = value
            End Set
        End Property

        Private _dr_code As Integer
        Public Property dr_code() As Integer
            Get
                Return _dr_code
            End Get
            Set(ByVal value As Integer)
                _dr_code = value
            End Set
        End Property

        Private _sales_plan_verification_status As Integer
        Public Property sales_plan_verification_status() As Integer
            Get
                Return _sales_plan_verification_status
            End Get
            Set(ByVal value As Integer)
                _sales_plan_verification_status = value
            End Set
        End Property

        Private _sales_plan_verification_by As String
        Public Property sales_plan_verification_by() As String
            Get
                Return _sales_plan_verification_by
            End Get
            Set(ByVal value As String)
                _sales_plan_verification_by = value
            End Set
        End Property

        Private _sales_plan_verification_date As DateTime
        Public Property sales_plan_verification_date() As DateTime
            Get
                Return _sales_plan_verification_date
            End Get
            Set(ByVal value As DateTime)
                _sales_plan_verification_date = value
            End Set
        End Property

        Private _sales_real_verification_status As Integer
        Public Property sales_real_verification_status() As Integer
            Get
                Return _sales_real_verification_status
            End Get
            Set(ByVal value As Integer)
                _sales_real_verification_status = value
            End Set
        End Property

        Private _sales_real_verification_by As String
        Public Property sales_real_verification_by() As String
            Get
                Return _sales_real_verification_by
            End Get
            Set(ByVal value As String)
                _sales_real_verification_by = value
            End Set
        End Property

        Private _sales_real_verification_date As DateTime
        Public Property sales_real_verification_date() As DateTime
            Get
                Return _sales_real_verification_date
            End Get
            Set(ByVal value As DateTime)
                _sales_real_verification_date = value
            End Set
        End Property

        Private _sales_date_plan_saved As DateTime
        Public Property sales_date_plan_saved() As DateTime
            Get
                Return _sales_date_plan_saved
            End Get
            Set(ByVal value As DateTime)
                _sales_date_plan_saved = value
            End Set
        End Property

        Private _sales_date_plan_updated As DateTime
        Public Property sales_date_plan_updated() As DateTime
            Get
                Return _sales_date_plan_updated
            End Get
            Set(ByVal value As DateTime)
                _sales_date_plan_updated = value
            End Set
        End Property

        Private _sales_date_realization_saved As DateTime
        Public Property sales_date_realization_saved() As DateTime
            Get
                Return _sales_date_realization_saved
            End Get
            Set(ByVal value As DateTime)
                _sales_date_realization_saved = value
            End Set
        End Property

    End Class
End Namespace
