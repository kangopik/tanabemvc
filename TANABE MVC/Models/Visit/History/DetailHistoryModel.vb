Public Class DetailHistoryModel
    Public m_vd_id As String
    Public m_visit_id As String
    Public m_visit_code As String
    Public m_visit_team As String
    Public m_visit_product As String
    Public m_visit_category As String
    Public m_vd_value As String
    Public Property vd_id() As String
        Get
            Return m_vd_id
        End Get
        Set(value As String)
            m_vd_id = value
        End Set
    End Property
    Public Property visit_id() As String
        Get
            Return m_visit_id
        End Get
        Set(value As String)
            m_visit_id = value
        End Set
    End Property
    Public Property visit_code() As String
        Get
            Return m_visit_code
        End Get
        Set(value As String)
            m_visit_code = value
        End Set
    End Property
    Public Property visit_team() As String
        Get
            Return m_visit_team
        End Get
        Set(value As String)
            m_visit_team = value
        End Set
    End Property
    Public Property visit_product() As String
        Get
            Return m_visit_product
        End Get
        Set(value As String)
            m_visit_product = value
        End Set
    End Property
    Public Property visit_category() As String
        Get
            Return m_visit_category
        End Get
        Set(value As String)
            m_visit_category = value
        End Set
    End Property
    Public Property vd_value() As String
        Get
            Return m_vd_value
        End Get
        Set(value As String)
            m_vd_value = value
        End Set
    End Property
End Class


