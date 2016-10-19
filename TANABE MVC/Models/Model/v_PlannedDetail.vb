Namespace Models
    Public Class v_PlannedDetail

        Private _visit_date_planned As DateTime
        Public Property visit_date_plan() As DateTime
            Get
                Return _visit_date_planned
            End Get
            Set(ByVal value As DateTime)
                _visit_date_planned = value
            End Set
        End Property

        Private _week As String
        Public Property week() As String
            Get
                Return _week
            End Get
            Set(ByVal value As String)
                _week = value
            End Set
        End Property

       
    End Class
End Namespace

