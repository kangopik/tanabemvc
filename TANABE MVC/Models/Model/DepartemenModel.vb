Namespace Models
    Public Class DepartemenModel

        Private _Nama_Departemen As String
        Public Property Nama_Departemen() As String
            Get
                Return _Nama_Departemen
            End Get
            Set(ByVal value As String)
                _Nama_Departemen = value
            End Set
        End Property

        Private _Kode_Departemen As String
        Public Property Kode_Departemen() As String
            Get
                Return _Kode_Departemen
            End Get
            Set(ByVal value As String)
                _Kode_Departemen = value
            End Set
        End Property

    End Class
End Namespace
