Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class r_visitonlypivotrep

        Public con As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Function GetVisitOnlyPivotRep(ByVal dtStart As String, ByVal dtEnd As String, ByVal rep_id As String) As List(Of VisitOnlyPivotRepModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@date_start", dtStart)
                param.Add("@date_end", dtEnd)
                param.Add("@rep_id", rep_id)
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of VisitOnlyPivotRepModel)(con, "MVC_SP_SELECT_VISIT_ONLY_PIVOT_REP", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

    End Class
End Namespace
