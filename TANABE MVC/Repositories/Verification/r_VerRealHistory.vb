Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class r_VerRealHistory

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
        Dim myConnection As New SqlConnection(ConnectionString)
        Dim exTransaction As SqlTransaction
        Public Function GetVisitRealVerified(ByVal rep_id As String, ByVal month As String, ByVal year As String) As List(Of VerRealHistoryModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@month", month)
                param.Add("@year", year)
                myConnection.Open()
                Dim tb = SqlMapper.Query(Of VerRealHistoryModel)(myConnection, "SELECT * FROM [v_visit_plan] WHERE rep_id = @rep_id AND (DATEPART(month,visit_date_plan) = @month AND DATEPART(year,visit_date_plan) = @year) " & _
                                                                             "AND visit_plan_verification_status = 1 AND visit_real_verification_status = 1  ORDER BY visit_date_plan,visit_id ASC", param, commandType:=CommandType.Text)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                myConnection.Close()
            End Try
        End Function

        Public Function GetMasterDetail(ByVal visit_id As String) As List(Of DetailActualModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@visit_id", visit_id)
                myConnection.Open()
                Dim tb = SqlMapper.Query(Of DetailActualModel)(myConnection, "select * from v_visit_product where visit_id = @visit_id", param, commandType:=CommandType.Text)
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

        Function processUnVerify(ByVal visit_id As String) As Boolean
            Dim date_now As Date = CDate(DateTime.Now())
            Dim pVisitId As String
            Try
                Dim v_visit_id As String() = visit_id.Split(New Char() {","})
                myConnection.Open()
                exTransaction = myConnection.BeginTransaction()
                For i As Integer = 0 To v_visit_id.Length - 1
                    pVisitId = v_visit_id(i).ToString()
                    Dim cmd As New SqlCommand("[SP_UNVERIFICATION_VISIT_REAL]", myConnection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@visit_id", pVisitId)
                    cmd.Parameters.AddWithValue("@month", 0)
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

        Function processUnVerifyOnebyOne(ByVal visit_id As String) As Boolean
            Dim date_now As Date = CDate(DateTime.Now())
            Try
                myConnection.Open()
                Dim cmd As New SqlCommand("[SP_UNVERIFICATION_VISIT_REAL]", myConnection)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@visit_id", visit_id)
                cmd.Parameters.AddWithValue("@month", 0)
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

