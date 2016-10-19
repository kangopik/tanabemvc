Namespace Models
    Public Class m_categoryModel

        Private _category_id As String
        Public Property category_id() As String
            Get
                Return _category_id
            End Get
            Set(ByVal value As String)
                _category_id = value
            End Set
        End Property

        Private _category_description As String
        Public Property category_description() As String
            Get
                Return _category_description
            End Get
            Set(ByVal value As String)
                _category_description = value
            End Set
        End Property

    End Class
End Namespace
