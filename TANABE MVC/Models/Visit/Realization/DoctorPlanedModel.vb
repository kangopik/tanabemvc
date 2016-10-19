Public Class DoctorPlanedModel
    Public m_visit_id As String
    Public m_visit_date_plan As String
    Public m_dr_code As String
    Public m_dr_name As String
    Public m_dr_quadrant As String
    Public m_dr_monitoring As String
    Public Property visit_id() As String
        Get
            Return m_visit_id
        End Get
        Set(value As String)
            m_visit_id = value
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
End Class


