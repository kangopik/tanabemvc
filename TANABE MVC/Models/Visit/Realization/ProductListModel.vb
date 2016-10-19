Public Class ProductListModel
    Public m_visit_code As String
    Public m_visit_team As String
    Public m_visit_product As String
    Public m_visit_category As String

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


End Class

