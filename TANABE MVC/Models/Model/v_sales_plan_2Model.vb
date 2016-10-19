Namespace Models
    Public Class v_sales_plan_2Model

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

        Private _sp_id As Int64
        Public Property sp_id() As Int64
            Get
                Return _sp_id
            End Get
            Set(ByVal value As Int64)
                _sp_id = value
            End Set
        End Property

        Private _sales_id As String
        Public Property sales_id() As String
            Get
                Return _sales_id
            End Get
            Set(ByVal value As String)
                _sales_id = value
            End Set
        End Property

        Private _prd_code As String
        Public Property prd_code() As String
            Get
                Return _prd_code
            End Get
            Set(ByVal value As String)
                _prd_code = value
            End Set
        End Property

        Private _sp_target_qty As Integer
        Public Property sp_target_qty() As Integer
            Get
                Return _sp_target_qty
            End Get
            Set(ByVal value As Integer)
                _sp_target_qty = value
            End Set
        End Property

        Private _sp_target_value As Double
        Public Property sp_target_value() As Double
            Get
                Return _sp_target_value
            End Get
            Set(ByVal value As Double)
                _sp_target_value = value
            End Set
        End Property

        Private _sp_sales_qty As Double
        Public Property sp_sales_qty() As Double
            Get
                Return _sp_sales_qty
            End Get
            Set(ByVal value As Double)
                _sp_sales_qty = value
            End Set
        End Property

        Private _sp_sales_value As Double
        Public Property sp_sales_value() As Double
            Get
                Return _sp_sales_value
            End Get
            Set(ByVal value As Double)
                _sp_sales_value = value
            End Set
        End Property

        Private _sp_note As String
        Public Property sp_note() As String
            Get
                Return _sp_note
            End Get
            Set(ByVal value As String)
                _sp_note = value
            End Set
        End Property

        Private _sp_plan As Integer
        Public Property sp_plan() As Integer
            Get
                Return _sp_plan
            End Get
            Set(ByVal value As Integer)
                _sp_plan = value
            End Set
        End Property

        Private _sp_real As Integer
        Public Property sp_real() As Integer
            Get
                Return _sp_real
            End Get
            Set(ByVal value As Integer)
                _sp_real = value
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

        Private _prd_price As Double
        Public Property prd_price() As Double
            Get
                Return _prd_price
            End Get
            Set(ByVal value As Double)
                _prd_price = value
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

        Private _dr_sub_category As String
        Public Property dr_sub_category() As String
            Get
                Return _dr_sub_category
            End Get
            Set(ByVal value As String)
                _dr_sub_category = value
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

        Private _dr_dk_lk As String
        Public Property dr_dk_lk() As String
            Get
                Return _dr_dk_lk
            End Get
            Set(ByVal value As String)
                _dr_dk_lk = value
            End Set
        End Property

        Private _rep_name As String
        Public Property rep_name() As String
            Get
                Return _rep_name
            End Get
            Set(ByVal value As String)
                _rep_name = value
            End Set
        End Property

        Private _nama_rm As String
        Public Property nama_rm() As String
            Get
                Return _nama_rm
            End Get
            Set(ByVal value As String)
                _nama_rm = value
            End Set
        End Property

        Private _nama_am As String
        Public Property nama_am() As String
            Get
                Return _nama_am
            End Get
            Set(ByVal value As String)
                _nama_am = value
            End Set
        End Property

        Private _rep_region As String
        Public Property rep_region() As String
            Get
                Return _rep_region
            End Get
            Set(ByVal value As String)
                _rep_region = value
            End Set
        End Property

        Private _rep_bo As String
        Public Property rep_bo() As String
            Get
                Return _rep_bo
            End Get
            Set(ByVal value As String)
                _rep_bo = value
            End Set
        End Property

        Private _rep_sbo As String
        Public Property rep_sbo() As String
            Get
                Return _rep_sbo
            End Get
            Set(ByVal value As String)
                _rep_sbo = value
            End Set
        End Property

        Private _rep_position As String
        Public Property rep_position() As String
            Get
                Return _rep_position
            End Get
            Set(ByVal value As String)
                _rep_position = value
            End Set
        End Property

        Private _rep_division As String
        Public Property rep_division() As String
            Get
                Return _rep_division
            End Get
            Set(ByVal value As String)
                _rep_division = value
            End Set
        End Property

        Private _prd_category As String
        Public Property prd_category() As String
            Get
                Return _prd_category
            End Get
            Set(ByVal value As String)
                _prd_category = value
            End Set
        End Property

        Private _target_class_user As String
        Public Property target_class_user() As String
            Get
                Return _target_class_user
            End Get
            Set(ByVal value As String)
                _target_class_user = value
            End Set
        End Property

        Private _real_class_user As String
        Public Property real_class_user() As String
            Get
                Return _real_class_user
            End Get
            Set(ByVal value As String)
                _real_class_user = value
            End Set
        End Property

    End Class
End Namespace
