Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class r_login
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("PRODcon").ToString()
        Dim myConnection As New SqlConnection(ConnectionString)

        Dim ConnectionStringMva As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
        Dim myConnectionMva As New SqlConnection(ConnectionStringMva)
        Public Function CheckGlobalUser(ByVal uName As String, ByVal uPwd As String) As List(Of tUserModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@uName", uName)
                param.Add("@uPwd", uPwd)
                myConnection.Open()
                Dim tb = SqlMapper.Query(Of tUserModel)(myConnection, "SELECT [Nomor Induk] as nomor_induk FROM tUser WHERE uName= @uName And userPwd=@uPwd", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Public Function GetFullName(ByVal nik As String) As List(Of AllKaryawanModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@nik", nik)
                myConnection.Open()
                Dim tb = SqlMapper.Query(Of AllKaryawanModel)(myConnection, "SELECT [Nama],[Kode_Departemen] FROM all_karyawan WHERE [Nomor Induk]=@nik;", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Public Function isSupervisor(ByVal nik As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@nik", nik)
                myConnection.Open()
                Dim tb = SqlMapper.Query(myConnection, "SELECT * FROM [lvl_mgrUpAll] WHERE [Nomor Induk] = @nik", param, commandType:=CommandType.Text)
                Return tb.Count > 0
            Catch ex As Exception
                Return False
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Public Function isManagerUp(ByVal nik As String) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@nik", nik)
                myConnection.Open()
                Dim tb = SqlMapper.Query(myConnection, "SELECT * FROM [lvl_mgrUpAll] WHERE [Nomor Induk] = @nik", param, commandType:=CommandType.Text)
                Return tb.Count > 0
            Catch ex As Exception
                Return False
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Public Function CheckMvaUserInfo(ByVal nik As String) As List(Of v_rep_fullModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@nik", nik)
                myConnectionMva.Open()
                Dim tb = SqlMapper.Query(Of v_rep_fullModel)(myConnectionMva, "SELECT * FROM v_rep_full WHERE rep_id= @nik;", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                myConnectionMva.Close()
            End Try
        End Function
    End Class
End Namespace
