Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class Iaudit_visit

        Public con As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Function GetAuditVisitMontlyByParam(ByVal month As String, ByVal year As String, ByVal nik As String) As List(Of audit_visitModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@month_audit", Trim(month))
                param.Add("@year_audit", Trim(year))
                param.Add("@audit_by", Trim(nik))
                connection()
                con.Open()
                Dim str = SqlMapper.Query(Of audit_visitModel)(con, "SELECT * FROM _audit_visit WHERE month_audit = @month_audit AND year_audit = @year_audit AND audit_by = @audit_by", param, commandType:=CommandType.Text)
                Return str.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function AuditRetrieve(ByVal month As String, ByVal year As String, ByVal nik As String) As List(Of audit_visitModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@month_audit", Trim(month))
                param.Add("@year_audit", Trim(year))
                param.Add("@audit_by", Trim(nik))
                connection()
                con.Open()
                Dim str = SqlMapper.Query(Of audit_visitModel)(con, "SP_AUDIT_VISIT", param, commandType:=CommandType.StoredProcedure)
                Return str.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function AuditReset(ByVal nik As String) As List(Of audit_visitModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@nik", Trim(nik))
                connection()
                con.Open()
                Dim str = SqlMapper.Query(Of audit_visitModel)(con, "DELETE FROM _audit_visit WHERE audit_by = @nik", param, commandType:=CommandType.Text)
                Return str.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetAuditVisitMontly(ByVal nik As String) As List(Of audit_visitModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@nik", Trim(nik))
                connection()
                con.Open()
                Dim str = SqlMapper.Query(Of audit_visitModel)(con, "SELECT * FROM _audit_visit WHERE audit_by = @nik", param, commandType:=CommandType.Text)
                Return str.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

    End Class
End Namespace
