Imports System.Web.Mvc
Imports System.Web.HttpContext
Imports TANABE_MVC.TANABE_MVC.Models
Imports TANABE_MVC.Repositories

Public Class LoginController
    Inherits Controller
    Dim repo As New r_login
    Dim model
    Function Index() As ActionResult
        Session("username") = ""
        Session("password") = ""
        Return View()
    End Function
    <HttpPost> _
    Function Login(collection As FormCollection) As ActionResult
        Dim username As String = collection("username")
        Dim password As String = Encrypt(collection("password"))
        Dim success_login As Boolean
        Dim strNamaLengkap As String = ""
        Dim strKodeDepartemen As String = ""
        Dim strPwd As String = ""
        Dim strNIK As String = ""
        Dim Kode_Level As String = ""
        Dim rep_id As String = Session("rep_id")
        Dim rep_pos As String = "ADMIN"
        Dim rep_name As String = ""
        Dim rep_region As String = ""
        Dim rep_bo As String = ""
        Dim rep_sbo As String = ""
        Dim rep_am As String = ""
        Dim rep_rm As String = ""
        Dim rep_email As String = ""
        Dim rep_am_email As String = ""
        Dim rep_rm_email As String = ""

        Try
            'get nik
            model = repo.CheckGlobalUser(username, password)
            If model.Count <> 0 Then
                strNIK = model(0).nomor_induk
                success_login = True

                'get full name & Dept code
                model = repo.GetFullName(strNIK)
                If model.Count <> 0 Then
                    strNamaLengkap = model(0).Nama
                    strKodeDepartemen = model(0).Kode_Departemen
                End If

                'cek spv level
                Dim isSupervisor As Boolean = repo.isSupervisor(strNIK)

                'cek mgr level
                Dim isManagerUp As Boolean = repo.isManagerUp(strNIK)

                'get rep info
                model = repo.CheckMvaUserInfo(strNIK)
                If model.Count <> 0 Then
                    rep_pos = Trim(model(0).rep_position)
                    rep_region = Trim(model(0).rep_region)
                    rep_name = model(0).rep_name
                    rep_bo = Trim(model(0).rep_bo)
                    rep_sbo = Trim(model(0).rep_sbo)
                    rep_am = model(0).nama_am
                    rep_rm = model(0).nama_rm
                    rep_email = model(0).rep_email
                    rep_am_email = model(0).email_am
                    rep_rm_email = model(0).email_rm
                    success_login = True
                Else
                    success_login = False
                End If
            Else
                success_login = False
            End If
        Catch generatedExceptionName As Exception
            success_login = False
            Throw
        End Try

        If (success_login) Then
            'SET SESSION
            Session("KODEDEPARTEMEN") = strKodeDepartemen
            Session("rep_position") = rep_pos
            Session("rep_reg") = rep_region
            Session("rep_name") = rep_name
            Session("rep_bo") = rep_bo
            Session("rep_sbo") = rep_sbo
            Session("rep_am_name") = rep_am
            Session("rep_rm_name") = rep_rm
            Session("rep_email") = rep_email
            Session("rep_am_email") = rep_am_email
            Session("rep_rm_email") = rep_rm_email
            Session("username") = username
            Session("nama_lengkap") = strNamaLengkap
            Session("password") = password
            Session("rep_id") = strNIK
            Return RedirectToAction("index", "home")
        Else
            ViewBag.MsgError = "!Login Failed"
            Return View("~/Views/Login/Index.vbhtml")
        End If
    End Function
    Protected Function Encrypt(ByVal icText As String) As String
        Dim icLen As Integer
        Dim icNewText As String
        Dim icChar As String
        Dim i As Integer
        icChar = ""
        icNewText = ""
        icLen = Len(icText)
        For i = 1 To icLen
            icChar = Mid(icText, i, 1)
            Select Case Asc(icChar)
                Case 65 To 90
                    icChar = Chr(Asc(icChar) + 127)
                Case 97 To 122
                    icChar = Chr(Asc(icChar) + 121)
                Case 48 To 57
                    icChar = Chr(Asc(icChar) + 196)
                Case 32
                    icChar = Chr(32)
            End Select
            icNewText = icNewText + icChar
        Next
        Encrypt = icNewText
    End Function

    Protected Function Decrypt(ByVal icText As String) As String
        Dim icLen As Integer
        Dim icNewText As String
        Dim icChar As String
        Dim i As Integer
        icChar = ""
        icNewText = ""
        icLen = Len(icText)
        For i = 1 To icLen
            icChar = Mid(icText, i, 1)
            Select Case Asc(icChar)
                Case 192 To 217
                    icChar = Chr(Asc(icChar) - 127)
                Case 218 To 243
                    icChar = Chr(Asc(icChar) - 121)
                Case 244 To 253
                    icChar = Chr(Asc(icChar) - 196)
                Case 32
                    icChar = Chr(32)
            End Select
            icNewText = icNewText + icChar
        Next
        Decrypt = icNewText
    End Function
End Class