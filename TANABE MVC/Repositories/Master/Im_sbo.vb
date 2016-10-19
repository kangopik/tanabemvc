Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class Im_sbo

        Public con As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Function GetAllMasterSBO() As List(Of m_sboModel)
            Try
                connection()
                con.Open()
                Dim tb = con.Query(Of m_sboModel)("SELECT * FROM m_sbo ORDER BY sbo_code ASC")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function Insert(obj As m_sboModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sbo_code", obj.sbo_code)
                param.Add("@sbo_description", obj.sbo_description)
                param.Add("@sbo_address", obj.sbo_address)
                param.Add("@bo_code", obj.bo_code)
                param.Add("@sbo_status", obj.sbo_status)
                connection()
                con.Open()
                con.Execute("SP_INSERT_MASTER_SBO", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Update(obj As m_sboModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@sbo_code", obj.sbo_code)
                param.Add("@sbo_description", obj.sbo_description)
                param.Add("@sbo_address", obj.sbo_address)
                param.Add("@bo_code", obj.bo_code)
                param.Add("@sbo_sequence_code", obj.sbo_sequence_code)
                param.Add("@sbo_status", obj.sbo_status)
                connection()
                con.Open()
                con.Execute("SP_UPDATE_MASTER_SBO", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Delete(ByVal sbo_code As String) As Boolean
            Try
                Dim sqlQuery As String = "DELETE FFROM m_sbo WHERE sbo_code = @sbo_code"
                connection()
                con.Open()
                con.Execute(sqlQuery, New With {sbo_code})
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
