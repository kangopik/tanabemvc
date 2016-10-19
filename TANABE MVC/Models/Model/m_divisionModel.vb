Namespace Models
    Public Class m_divisionModel

        Private _div_id As String
        Public Property div_id() As String
            Get
                Return _div_id
            End Get
            Set(ByVal value As String)
                _div_id = value
            End Set
        End Property

        Private _div_description As String
        Public Property div_description() As String
            Get
                Return _div_description
            End Get
            Set(ByVal value As String)
                _div_description = value
            End Set
        End Property

    End Class
End Namespace
