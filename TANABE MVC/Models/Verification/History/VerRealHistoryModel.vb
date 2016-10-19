
Imports System.Data.SqlClient

Public Class VerRealHistoryModel

    Public m_visit_id As String
    Public m_rep_id As String
    Public m_visit_date_plan As String
    Public m_visit_plan As String
    Public m_visit_realization As String

    Public m_dr_code As String
    Public m_dr_name As String
    Public m_dr_spec As String
    Public m_dr_sub_spec As String
    Public m_dr_quadrant As String

    Public m_dr_monitoring As String
    Public m_dr_dk_lk As String
    Public m_dr_area_mis As String
    Public m_dr_category As String
    Public m_dr_chanel As String

    Public m_visit_date_realization_saved As String
    Public m_visit_date_plan_saved As String
    Public m_visit_date_plan_updated As String
    Public m_visit_info As String
    Public m_visit_sp As String

    Public m_visit_sp_value As String
    Public m_visit_plan_verification_status As String
    Public m_visit_plan_verification_by As String
    Public m_visit_plan_verification_date As String
    Public m_visit_real_verification_status As String

    Public m_visit_real_verification_by As String
    Public m_visit_real_verification_date As String
    Public m_dr_address As String

    Public Property visit_id() As String
        Get
            Return m_visit_id
        End Get
        Set(value As String)
            m_visit_id = value
        End Set
    End Property

    Public Property rep_id() As String
        Get
            Return m_rep_id
        End Get
        Set(value As String)
            m_rep_id = value
        End Set
    End Property
    Public Property visit_date_plan() As String
        Get
            Return m_visit_date_plan
        End Get
        Set(value As String)
            m_visit_date_plan = value
        End Set
    End Property
    Public Property visit_plan() As String
        Get
            Return m_visit_plan
        End Get
        Set(value As String)
            m_visit_plan = value
        End Set
    End Property
    Public Property visit_realization() As String
        Get
            Return m_visit_realization
        End Get
        Set(value As String)
            m_visit_realization = value
        End Set
    End Property


    Public Property dr_code() As String
        Get
            Return m_dr_code
        End Get
        Set(value As String)
            m_dr_code = value
        End Set
    End Property

    Public Property dr_name() As String
        Get
            Return m_dr_name
        End Get
        Set(value As String)
            m_dr_name = value
        End Set
    End Property
    Public Property dr_spec() As String
        Get
            Return m_dr_spec
        End Get
        Set(value As String)
            m_dr_spec = value
        End Set
    End Property
    Public Property dr_sub_spec() As String
        Get
            Return m_dr_sub_spec
        End Get
        Set(value As String)
            m_dr_sub_spec = value
        End Set
    End Property
    Public Property dr_quadrant() As String
        Get
            Return m_dr_quadrant
        End Get
        Set(value As String)
            m_dr_quadrant = value
        End Set
    End Property

    Public Property dr_monitoring() As String
        Get
            Return m_dr_monitoring
        End Get
        Set(value As String)
            m_dr_monitoring = value
        End Set
    End Property

    Public Property dr_dk_lk() As String
        Get
            Return m_dr_dk_lk
        End Get
        Set(value As String)
            m_dr_dk_lk = value
        End Set
    End Property
    Public Property dr_area_mis() As String
        Get
            Return m_dr_area_mis
        End Get
        Set(value As String)
            m_dr_area_mis = value
        End Set
    End Property
    Public Property dr_category() As String
        Get
            Return m_dr_category
        End Get
        Set(value As String)
            m_dr_category = value
        End Set
    End Property
    Public Property dr_chanel() As String
        Get
            Return m_dr_chanel
        End Get
        Set(value As String)
            m_dr_chanel = value
        End Set
    End Property


    Public Property visit_date_realization_saved() As String
        Get
            Return m_visit_date_realization_saved
        End Get
        Set(value As String)
            m_visit_date_realization_saved = value
        End Set
    End Property

    Public Property visit_date_plan_saved() As String
        Get
            Return m_visit_date_plan_saved
        End Get
        Set(value As String)
            m_visit_date_plan_saved = value
        End Set
    End Property
    Public Property visit_date_plan_updated() As String
        Get
            Return m_visit_date_plan_updated
        End Get
        Set(value As String)
            m_visit_date_plan_updated = value
        End Set
    End Property
    Public Property visit_info() As String
        Get
            Return m_visit_info
        End Get
        Set(value As String)
            m_visit_info = value
        End Set
    End Property
    Public Property visit_sp() As String
        Get
            Return m_visit_sp
        End Get
        Set(value As String)
            m_visit_sp = value
        End Set
    End Property


    Public Property visit_sp_value() As String
        Get
            Return m_visit_sp_value
        End Get
        Set(value As String)
            m_visit_sp_value = value
        End Set
    End Property

    Public Property visit_plan_verification_status() As String
        Get
            Return m_visit_plan_verification_status
        End Get
        Set(value As String)
            m_visit_plan_verification_status = value
        End Set
    End Property
    Public Property visit_plan_verification_by() As String
        Get
            Return m_visit_plan_verification_by
        End Get
        Set(value As String)
            m_visit_plan_verification_by = value
        End Set
    End Property
    Public Property visit_plan_verification_date() As String
        Get
            Return m_visit_plan_verification_date
        End Get
        Set(value As String)
            m_visit_plan_verification_date = value
        End Set
    End Property
    Public Property visit_real_verification_status() As String
        Get
            Return m_visit_real_verification_status
        End Get
        Set(value As String)
            m_visit_real_verification_status = value
        End Set
    End Property

    Public Property visit_real_verification_by() As String
        Get
            Return m_visit_real_verification_by
        End Get
        Set(value As String)
            m_visit_real_verification_by = value
        End Set
    End Property

    Public Property visit_real_verification_date() As String
        Get
            Return m_visit_real_verification_date
        End Get
        Set(value As String)
            m_visit_real_verification_date = value
        End Set
    End Property

    Public Property dr_address() As String
        Get
            Return m_dr_address
        End Get
        Set(value As String)
            m_dr_address = value
        End Set
    End Property


End Class




