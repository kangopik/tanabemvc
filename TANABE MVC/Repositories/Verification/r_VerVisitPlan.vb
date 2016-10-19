Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class r_VerVisitPlan

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
        Dim myConnection As New SqlConnection(ConnectionString)
        Dim exTransaction As SqlTransaction
        Public Function GetVisitPlanReady(ByVal rep_id As String, ByVal month As String, ByVal year As String) As List(Of VerVisitPlanModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@month", month)
                param.Add("@year", year)
                myConnection.Open()
                Dim tb = SqlMapper.Query(Of VerVisitPlanModel)(myConnection, "SP_SELECT_VISIT_PLAN_READY", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Public Function GetDataRep(ByVal dept As String, ByVal repPos As String, ByVal rep_id As String) As List(Of m_repModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@department", dept)
                param.Add("@rep_position", repPos)
                param.Add("@rep_id", rep_id)
                myConnection.Open()
                Dim tb = SqlMapper.Query(Of m_repModel)(myConnection, "SP_SELECT_REP_FOR_VERIFICATION", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Function processVerify(ByVal visit_id As String, ByVal nik As String) As Boolean
            Dim date_now As Date = CDate(DateTime.Now())
            Dim pVisitId As String
            Try
                Dim v_visit_id As String() = visit_id.Split(New Char() {","})
                myConnection.Open()
                exTransaction = myConnection.BeginTransaction()
                For i As Integer = 0 To v_visit_id.Length - 1
                    pVisitId = v_visit_id(i).ToString()
                    Dim cmd As New SqlCommand("[SP_VERIFICATION_VISIT_PLAN]", myConnection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@visit_id", pVisitId)
                    cmd.Parameters.AddWithValue("@visit_plan_verification_by", nik)
                    cmd.Parameters.AddWithValue("@visit_plan_verification_date", date_now)
                    cmd.Transaction = exTransaction
                    cmd.ExecuteNonQuery()
                Next
                exTransaction.Commit()
                Return True

            Catch ex As Exception
                exTransaction.Rollback()
                Return False
            Finally
                myConnection.Close()
            End Try
        End Function

        Function processVerifyOnebyOne(ByVal visit_id As String, ByVal nik As String) As Boolean
            Dim date_now As Date = CDate(DateTime.Now())
            Try
                myConnection.Open()
                Dim cmd As New SqlCommand("[SP_VERIFICATION_VISIT_PLAN]", myConnection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@visit_id", visit_id)
                cmd.Parameters.AddWithValue("@visit_plan_verification_by", nik)
                cmd.Parameters.AddWithValue("@visit_plan_verification_date", date_now)
                cmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                Return False
            Finally
                myConnection.Close()
            End Try
        End Function
    End Class
End Namespace

