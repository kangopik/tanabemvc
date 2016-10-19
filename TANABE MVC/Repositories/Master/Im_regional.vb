Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class Im_regional

        Public con As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Function GetAllMasterRegional() As List(Of m_regionalModel)
            Try
                connection()
                con.Open()
                Dim tb = con.Query(Of m_regionalModel)("SELECT * FROM v_regional_full ORDER BY reg_sequence_code ASC")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function GetRegion() As List(Of m_regionalModel)
            Try
                connection()
                con.Open()
                Dim tb = con.Query(Of m_regionalModel)("SELECT * FROM m_regional ORDER BY reg_id ASC")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function Insert(obj As m_regionalModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@reg_id", obj.reg_id)
                param.Add("@reg_description", obj.reg_description)
                param.Add("@reg_functionary", obj.reg_functionary)
                param.Add("@reg_status", obj.reg_status)
                connection()
                con.Open()
                con.Execute("SP_INSERT_MASTER_REGION", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Update(obj As m_regionalModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@reg_id", obj.reg_id)
                param.Add("@reg_description", obj.reg_description)
                param.Add("@reg_sequence_code", obj.reg_sequence_code)
                param.Add("@reg_functionary", obj.reg_functionary)
                param.Add("@reg_status", obj.reg_status)
                connection()
                con.Open()
                con.Execute("SP_UPDATE_MASTER_REGIONAL", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Delete(ByVal reg_id As String) As Boolean
            Try
                Dim sqlQuery As String = "DELETE FROM m_regional WHERE reg_id = @reg_id"
                connection()
                con.Open()
                con.Execute(sqlQuery, New With {reg_id})
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

