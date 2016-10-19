
Namespace Models
    Public Class tUserModel

        Private _uName As String
        Public Property uName() As String
            Get
                Return _uName
            End Get
            Set(ByVal value As String)
                _uName = value
            End Set
        End Property

        Private _uPwd As String
        Public Property uPwd() As String
            Get
                Return _uPwd
            End Get
            Set(ByVal value As String)
                _uPwd = value
            End Set
        End Property

        Private _kode_bagian As String
        Public Property kode_bagian() As String
            Get
                Return _kode_bagian
            End Get
            Set(value As String)
                _kode_bagian = value
            End Set
        End Property

        Private _nomor_induk As String
        Public Property nomor_induk() As String
            Get
                Return _nomor_induk
            End Get
            Set(value As String)
                _nomor_induk = value
            End Set
        End Property

        Private _Kode_Level As Integer
        Public Property Kode_Level() As Integer
            Get
                Return _Kode_Level
            End Get
            Set(ByVal value As Integer)
                _Kode_Level = value
            End Set
        End Property

        Private _nama_seksi As String
        Public Property Nama_Seksi() As String
            Get
                Return _nama_seksi
            End Get
            Set(ByVal value As String)
                _nama_seksi = value
            End Set
        End Property

        Private _departemen As String
        Public Property Departemen() As String
            Get
                Return _departemen
            End Get
            Set(ByVal value As String)
                _departemen = value
            End Set
        End Property

        Private _level_no As String
        Public Property level_no() As String
            Get
                Return _level_no
            End Get
            Set(ByVal value As String)
                _level_no = value
            End Set
        End Property

        Private _status_aktif As Integer
        Public Property status_aktif() As Integer
            Get
                Return _status_aktif
            End Get
            Set(ByVal value As Integer)
                _status_aktif = value
            End Set
        End Property

        Private _last_login As DateTime
        Public Property last_login() As DateTime
            Get
                Return _last_login
            End Get
            Set(ByVal value As DateTime)
                _last_login = value
            End Set
        End Property

        Private _headquarter As String
        Public Property Headquarter() As String
            Get
                Return _headquarter
            End Get
            Set(ByVal value As String)
                _headquarter = value
            End Set
        End Property

        Private _pesan As String
        Public Property Pesan() As String
            Get
                Return _pesan
            End Get
            Set(ByVal value As String)
                _pesan = value
            End Set
        End Property

        Private _desktop_app As Integer
        Public Property desktop_app() As Integer
            Get
                Return _desktop_app
            End Get
            Set(ByVal value As Integer)
                _desktop_app = value
            End Set
        End Property

        Private _web_app As Integer
        Public Property web_app() As Integer
            Get
                Return _web_app
            End Get
            Set(ByVal value As Integer)
                _web_app = value
            End Set
        End Property

        Private _kode_office As String
        Public Property kode_office() As String
            Get
                Return _kode_office
            End Get
            Set(ByVal value As String)
                _kode_office = value
            End Set
        End Property

        Private _userPwd As String
        Public Property userPwd() As String
            Get
                Return _userPwd
            End Get
            Set(ByVal value As String)
                _userPwd = value
            End Set
        End Property

        Private _min_panjang_pwd As String
        Public Property Min_Panjang_Pwd() As String
            Get
                Return _min_panjang_pwd
            End Get
            Set(ByVal value As String)
                _min_panjang_pwd = value
            End Set
        End Property

        Private _terakhir_ganti_pwd As DateTime
        Public Property Terakhir_Ganti_Pwd() As DateTime
            Get
                Return _terakhir_ganti_pwd
            End Get
            Set(ByVal value As DateTime)
                _terakhir_ganti_pwd = value
            End Set
        End Property

        Private _lama_ganti_pwd As String
        Public Property Lama_Ganti_Pwd() As String
            Get
                Return _lama_ganti_pwd
            End Get
            Set(ByVal value As String)
                _lama_ganti_pwd = value
            End Set
        End Property

        Private _email_address As String
        Public Property Email_Address() As String
            Get
                Return _email_address
            End Get
            Set(ByVal value As String)
                _email_address = value
            End Set
        End Property

        Private _last_login_decision As DateTime
        Public Property last_login_decision() As DateTime
            Get
                Return _last_login_decision
            End Get
            Set(ByVal value As DateTime)
                _last_login_decision = value
            End Set
        End Property

        Private _user_right As Integer
        Public Property user_right() As Integer
            Get
                Return _user_right
            End Get
            Set(ByVal value As Integer)
                _user_right = value
            End Set
        End Property

        Private _sec_user_id As Integer
        Public Property sec_user_id() As Integer
            Get
                Return _sec_user_id
            End Get
            Set(ByVal value As Integer)
                _sec_user_id = value
            End Set
        End Property

        Private _sec_role_id As Integer
        Public Property sec_role_id() As Integer
            Get
                Return _sec_role_id
            End Get
            Set(ByVal value As Integer)
                _sec_role_id = value
            End Set
        End Property

        Private _status_id As Integer
        Public Property status_id() As Integer
            Get
                Return _status_id
            End Get
            Set(ByVal value As Integer)
                _status_id = value
            End Set
        End Property

        Private _count_wrong_password As Integer
        Public Property count_wrong_password() As Integer
            Get
                Return _count_wrong_password
            End Get
            Set(ByVal value As Integer)
                _count_wrong_password = value
            End Set
        End Property

        Private _section_id As Integer
        Public Property section_id() As Integer
            Get
                Return _section_id
            End Get
            Set(ByVal value As Integer)
                _section_id = value
            End Set
        End Property

    
    End Class
End Namespace
