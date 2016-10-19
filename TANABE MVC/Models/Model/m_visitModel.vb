Namespace Models
    Public Class m_visitModel

        Private _visit_code As String
        Public Property visit_code() As String
            Get
                Return _visit_code
            End Get
            Set(ByVal value As String)
                _visit_code = value
            End Set
        End Property

        Private _visit_team As String
        Public Property visit_team() As String
            Get
                Return _visit_team
            End Get
            Set(ByVal value As String)
                _visit_team = value
            End Set
        End Property

        Private _visit_product As String
        Public Property visit_product() As String
            Get
                Return _visit_product
            End Get
            Set(ByVal value As String)
                _visit_product = value
            End Set
        End Property

        Private _visit_category As String
        Public Property visit_category() As String
            Get
                Return _visit_category
            End Get
            Set(ByVal value As String)
                _visit_category = value
            End Set
        End Property

        Private _visit_status As Integer
        Public Property visit_status() As Integer
            Get
                Return _visit_status
            End Get
            Set(ByVal value As Integer)
                _visit_status = value
            End Set
        End Property

    End Class
End Namespace

