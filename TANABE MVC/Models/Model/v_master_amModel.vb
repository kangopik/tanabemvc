Namespace Models
    Public Class v_master_amModel

        Private _bo_am As String
        Public Property bo_am() As String
            Get
                Return _bo_am
            End Get
            Set(ByVal value As String)
                _bo_am = value
            End Set
        End Property

        Private _Nama As String
        Public Property Nama() As String
            Get
                Return _Nama
            End Get
            Set(ByVal value As String)
                _Nama = value
            End Set
        End Property

    End Class
End Namespace
