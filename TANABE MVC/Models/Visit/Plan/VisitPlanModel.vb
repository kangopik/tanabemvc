Namespace Models
    Public Class VisitPlanModel

        Private _visit_id As String
        Public Property visit_id() As String
            Get
                Return _visit_id
            End Get
            Set(ByVal value As String)
                _visit_id = value
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

        Private _visit_date_plan As DateTime
        Public Property visit_date_plan() As DateTime
            Get
                Return _visit_date_plan
            End Get
            Set(ByVal value As DateTime)
                _visit_date_plan = value
            End Set
        End Property

        Private _visit_plan As Integer
        Public Property visit_plan() As Integer
            Get
                Return _visit_plan
            End Get
            Set(ByVal value As Integer)
                _visit_plan = value
            End Set
        End Property

        Private _visit_realization As Integer
        Public Property visit_realization() As Integer
            Get
                Return _visit_realization
            End Get
            Set(ByVal value As Integer)
                _visit_realization = value
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

        Private _dr_name As String
        Public Property dr_name() As String
            Get
                Return _dr_name
            End Get
            Set(ByVal value As String)
                _dr_name = value
            End Set
        End Property

        Private _dr_spec As String
        Public Property dr_spec() As String
            Get
                Return _dr_spec
            End Get
            Set(ByVal value As String)
                _dr_spec = value
            End Set
        End Property

        Private _dr_sub_spec As String
        Public Property dr_sub_spec() As String
            Get
                Return _dr_sub_spec
            End Get
            Set(ByVal value As String)
                _dr_sub_spec = value
            End Set
        End Property

        Private _dr_quadrant As String
        Public Property dr_quadrant() As String
            Get
                Return _dr_quadrant
            End Get
            Set(ByVal value As String)
                _dr_quadrant = value
            End Set
        End Property

        Private _dr_monitoring As String
        Public Property dr_monitoring() As String
            Get
                Return _dr_monitoring
            End Get
            Set(ByVal value As String)
                _dr_monitoring = value
            End Set
        End Property

        Private _dr_dk_lk As String
        Public Property dr_dk_lk() As String
            Get
                Return _dr_dk_lk
            End Get
            Set(ByVal value As String)
                _dr_dk_lk = value
            End Set
        End Property

        Private _dr_area_mis As String
        Public Property dr_area_mis() As String
            Get
                Return _dr_area_mis
            End Get
            Set(ByVal value As String)
                _dr_area_mis = value
            End Set
        End Property

        Private _dr_category As String
        Public Property dr_category() As String
            Get
                Return _dr_category
            End Get
            Set(ByVal value As String)
                _dr_category = value
            End Set
        End Property

        Private _dr_chanel As String
        Public Property dr_chanel() As String
            Get
                Return _dr_chanel
            End Get
            Set(ByVal value As String)
                _dr_chanel = value
            End Set
        End Property

        Private _visit_date_realization_saved As DateTime
        Public Property visit_date_realization_saved() As DateTime
            Get
                Return _visit_date_realization_saved
            End Get
            Set(ByVal value As DateTime)
                _visit_date_realization_saved = value
            End Set
        End Property

        Private _visit_date_plan_saved As DateTime
        Public Property visit_date_plan_saved() As DateTime
            Get
                Return _visit_date_plan_saved
            End Get
            Set(ByVal value As DateTime)
                _visit_date_plan_saved = value
            End Set
        End Property

        Private _visit_date_plan_updated As DateTime
        Public Property visit_date_plan_updated() As DateTime
            Get
                Return _visit_date_plan_updated
            End Get
            Set(ByVal value As DateTime)
                _visit_date_plan_updated = value
            End Set
        End Property

        Private _visit_info As String
        Public Property visit_info() As String
            Get
                Return _visit_info
            End Get
            Set(ByVal value As String)
                _visit_info = value
            End Set
        End Property

        Private _visit_sp As String
        Public Property visit_sp() As String
            Get
                Return _visit_sp
            End Get
            Set(ByVal value As String)
                _visit_sp = value
            End Set
        End Property

        Private _visit_sp_value As Double
        Public Property visit_sp_value() As Double
            Get
                Return _visit_sp_value
            End Get
            Set(ByVal value As Double)
                _visit_sp_value = value
            End Set
        End Property

        Private _visit_plan_verification_status As Integer
        Public Property visit_plan_verification_status() As Integer
            Get
                Return _visit_plan_verification_status
            End Get
            Set(ByVal value As Integer)
                _visit_plan_verification_status = value
            End Set
        End Property

        Private _visit_plan_verification_by As String
        Public Property visit_plan_verification_by() As String
            Get
                Return _visit_plan_verification_by
            End Get
            Set(ByVal value As String)
                _visit_plan_verification_by = value
            End Set
        End Property

        Private _visit_plan_verification_date As DateTime
        Public Property visit_plan_verification_date() As DateTime
            Get
                Return _visit_plan_verification_date
            End Get
            Set(ByVal value As DateTime)
                _visit_plan_verification_date = value
            End Set
        End Property

        Private _visit_real_verification_status As Integer
        Public Property visit_real_verification_status() As Integer
            Get
                Return _visit_real_verification_status
            End Get
            Set(ByVal value As Integer)
                _visit_real_verification_status = value
            End Set
        End Property

        Private _visit_real_verification_by As String
        Public Property visit_real_verification_by() As String
            Get
                Return _visit_real_verification_by
            End Get
            Set(ByVal value As String)
                _visit_real_verification_by = value
            End Set
        End Property

        Private _visit_real_verification_date As DateTime
        Public Property visit_real_verification_date() As DateTime
            Get
                Return _visit_real_verification_date
            End Get
            Set(ByVal value As DateTime)
                _visit_real_verification_date = value
            End Set
        End Property

        Private _dr_address As String
        Public Property dr_address() As String
            Get
                Return _dr_address
            End Get
            Set(ByVal value As String)
                _dr_address = value
            End Set
        End Property


    End Class
End Namespace

