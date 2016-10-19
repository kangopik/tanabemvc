Namespace Models
    Public Class TransactEmailModel

        Private _is_pass As Integer
        Public Property is_pass() As Integer
            Get
                Return _is_pass
            End Get
            Set(ByVal value As Integer)
                _is_pass = value
            End Set
        End Property

    End Class
End Namespace
