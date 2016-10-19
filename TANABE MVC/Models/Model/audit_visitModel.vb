Namespace Models
    Public Class audit_visitModel

        Private _ID As Decimal
        Public Property ID() As Decimal
            Get
                Return _ID
            End Get
            Set(ByVal value As Decimal)
                _ID = value
            End Set
        End Property

        Private _nik As String
        Public Property nik() As String
            Get
                Return _nik
            End Get
            Set(ByVal value As String)
                _nik = value
            End Set
        End Property

        Private _nama_rep As String
        Public Property nama_rep() As String
            Get
                Return _nama_rep
            End Get
            Set(ByVal value As String)
                _nama_rep = value
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

        Private _rep_sbo As String
        Public Property rep_sbo() As String
            Get
                Return _rep_sbo
            End Get
            Set(ByVal value As String)
                _rep_sbo = value
            End Set
        End Property

        Private _rep_am As String
        Public Property rep_am() As String
            Get
                Return _rep_am
            End Get
            Set(ByVal value As String)
                _rep_am = value
            End Set
        End Property

        Private _jml_total_visit As Integer
        Public Property jml_total_visit() As Integer
            Get
                Return _jml_total_visit
            End Get
            Set(ByVal value As Integer)
                _jml_total_visit = value
            End Set
        End Property

        Private _finished_visit As Integer
        Public Property finished_visit() As Integer
            Get
                Return _finished_visit
            End Get
            Set(ByVal value As Integer)
                _finished_visit = value
            End Set
        End Property

        Private _jml_day_less_then As Integer
        Public Property jml_day_less_then() As Integer
            Get
                Return _jml_day_less_then
            End Get
            Set(ByVal value As Integer)
                _jml_day_less_then = value
            End Set
        End Property

        Private _jml_plan_blm_verifikasi As Integer
        Public Property jml_plan_blm_verifikasi() As Integer
            Get
                Return _jml_plan_blm_verifikasi
            End Get
            Set(ByVal value As Integer)
                _jml_plan_blm_verifikasi = value
            End Set
        End Property

        Private _jml_plan_sdh_verifikasi As Integer
        Public Property jml_plan_sdh_verifikasi() As Integer
            Get
                Return _jml_plan_sdh_verifikasi
            End Get
            Set(ByVal value As Integer)
                _jml_plan_sdh_verifikasi = value
            End Set
        End Property

        Private _jml_visit_blm_realisasi As Integer
        Public Property jml_visit_blm_realisasi() As Integer
            Get
                Return _jml_visit_blm_realisasi
            End Get
            Set(ByVal value As Integer)
                _jml_visit_blm_realisasi = value
            End Set
        End Property

        Private _jml_realisasi_blm_verifikasi As Integer
        Public Property jml_realisasi_blm_verifikasi() As Integer
            Get
                Return _jml_realisasi_blm_verifikasi
            End Get
            Set(ByVal value As Integer)
                _jml_realisasi_blm_verifikasi = value
            End Set
        End Property

        Private _jml_dr_used_session As Integer
        Public Property jml_dr_used_session() As Integer
            Get
                Return _jml_dr_used_session
            End Get
            Set(ByVal value As Integer)
                _jml_dr_used_session = value
            End Set
        End Property

        Private _jml_dr_planned_on_visit As Integer
        Public Property jml_dr_planned_on_visit() As Integer
            Get
                Return _jml_dr_planned_on_visit
            End Get
            Set(ByVal value As Integer)
                _jml_dr_planned_on_visit = value
            End Set
        End Property

        Private _jml_dr_on_master As Integer
        Public Property jml_dr_on_master() As Integer
            Get
                Return _jml_dr_on_master
            End Get
            Set(ByVal value As Integer)
                _jml_dr_on_master = value
            End Set
        End Property

        Private _month_audit As Integer
        Public Property month_audit() As Integer
            Get
                Return _month_audit
            End Get
            Set(ByVal value As Integer)
                _month_audit = value
            End Set
        End Property

        Private _year_audit As Integer
        Public Property year_audit() As Integer
            Get
                Return _year_audit
            End Get
            Set(ByVal value As Integer)
                _year_audit = value
            End Set
        End Property

        Private _audit_by As String
        Public Property audit_by() As String
            Get
                Return _audit_by
            End Get
            Set(ByVal value As String)
                _audit_by = value
            End Set
        End Property

    End Class
End Namespace
