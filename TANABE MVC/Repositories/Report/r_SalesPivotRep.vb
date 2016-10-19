Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class r_SalesPivotRep

        Public con As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Function GetSalesPivotRep(ByVal rep_id As String, ByVal monthStart As String, ByVal monthEnd As String, ByVal year As String) As List(Of SalesPivotRepModel)
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@rep_id", rep_id)
                param.Add("@month_start", monthStart)
                param.Add("@month_end", monthEnd)
                param.Add("@year", year)
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of SalesPivotRepModel)(con, "[SP_SELECT_SALES_PIVOT_REP]", param, commandType:=CommandType.StoredProcedure)
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function


    End Class
End Namespace
