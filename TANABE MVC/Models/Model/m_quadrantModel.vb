Namespace Models
    Public Class m_quadrantModel

        Private _quadrant As String
        Public Property quadrant() As String
            Get
                Return _quadrant
            End Get
            Set(ByVal value As String)
                _quadrant = value
            End Set
        End Property

        Private _description As String
        Public Property description() As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                _description = value
            End Set
        End Property

    End Class
End Namespace
