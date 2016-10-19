Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class Im_bo

        Public con As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Function GetAllMasterBO() As List(Of m_boModel)
            Try
                connection()
                con.Open()
                Dim tb = con.Query(Of m_boModel)("SELECT * FROM v_bo_full ORDER BY bo_code ASC")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetBo() As List(Of m_boModel)
            Try
                connection()
                con.Open()
                Dim tb = SqlMapper.Query(Of m_boModel)(con, "SELECT * FROM [m_bo]")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function Insert(obj As m_boModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@bo_code", obj.bo_code)
                param.Add("@bo_description", obj.bo_description)
                param.Add("@bo_address", obj.bo_address)
                param.Add("@bo_am", obj.bo_am)
                param.Add("@reg_id", obj.reg_id)
                param.Add("@bo_status", obj.bo_status)
                connection()
                con.Open()
                con.Execute("SP_INSERT_MASTER_BO", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Update(obj As m_boModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("bo_code", obj.bo_code)
                param.Add("@bo_description", obj.bo_description)
                param.Add("@bo_address", obj.bo_address)
                param.Add("@bo_am", obj.bo_am)
                param.Add("@reg_id", obj.reg_id)
                param.Add("@bo_sequence_code", obj.bo_sequence_code)
                param.Add("@bo_status", obj.bo_status)
                connection()
                con.Open()
                con.Execute("SP_UPDATE_MASTER_BO", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Delete(ByVal bo_code As String) As Boolean
            Try
                Dim sqlQuery As String = "DELETE FROM m_bo WHERE bo_code = @bo_code"
                connection()
                con.Open()
                con.Execute(sqlQuery, New With {bo_code})
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
