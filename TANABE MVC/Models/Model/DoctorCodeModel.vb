Namespace Models
    Public Class DoctorCodeModel

        Private _NEW_DR_CODE As String
        Public Property NEW_DR_CODE() As String
            Get
                Return _NEW_DR_CODE
            End Get
            Set(ByVal value As String)
                _NEW_DR_CODE = value
            End Set
        End Property
    End Class

End Namespace
