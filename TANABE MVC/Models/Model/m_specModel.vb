Namespace Models
    Public Class m_specModel

        Private _spec_code As String
        Public Property spec_code() As String
            Get
                Return _spec_code
            End Get
            Set(ByVal value As String)
                _spec_code = value
            End Set
        End Property

        Private _spec_description As String
        Public Property spec_description() As String
            Get
                Return _spec_description
            End Get
            Set(ByVal value As String)
                _spec_description = value
            End Set
        End Property

    End Class
End Namespace
