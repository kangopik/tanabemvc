Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class Im_visit

        Public con As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Function GetAllMasterVisit() As List(Of m_visitModel)
            Try
                connection()
                con.Open()
                Dim tb = con.Query(Of m_visitModel)("SELECT * FROM m_visit ORDER BY visit_code ASC")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetVisit() As List(Of m_visitModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_visitModel)(con, "SELECT * FROM [m_visit]")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function Insert(obj As m_visitModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@visit_code", obj.visit_code)
                param.Add("@visit_team", obj.visit_team)
                param.Add("@visit_product", obj.visit_product)
                param.Add("@visit_category", obj.visit_category)
                param.Add("@visit_status", obj.visit_status)
                connection()
                con.Open()
                con.Execute("SP_INSERT_MASTER_VISIT", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Update(obj As m_visitModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@visit_code", obj.visit_code)
                param.Add("@visit_team", obj.visit_team)
                param.Add("@visit_product", obj.visit_product)
                param.Add("@visit_category", obj.visit_category)
                param.Add("@visit_status", obj.visit_status)
                connection()
                con.Open()
                con.Execute("SP_UPDATE_MASTER_VISIT", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Delete(ByVal visit_code As String) As Boolean
            Try
                Dim sqlQuery As String = "DELETE FROM m_visit WHERE visit_code = @visit_code"
                connection()
                con.Open()
                con.Execute(sqlQuery, New With {visit_code})
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

    End Class
End Namespace
