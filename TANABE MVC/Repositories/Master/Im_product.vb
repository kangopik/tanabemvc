Imports System.Data.SqlClient
Imports Dapper
Imports TANABE_MVC.Models

Namespace Repositories
    Public Class Im_product

        Public con As SqlConnection
        Public Sub connection()
            Dim constr As String = ConfigurationManager.ConnectionStrings("MVAcon").ToString()
            con = New SqlConnection(constr)
        End Sub

        Public Function GetAllMasterProduct() As List(Of m_productModel)
            Try
                connection()
                con.Open()
                Dim tb = con.Query(Of m_productModel)("SELECT * FROM m_product ORDER BY prd_code ASC")
                Return tb.ToList()
            Catch ex As Exception
                Throw ex
            Finally
                con.Close()
            End Try
        End Function

        Public Function Insert(obj As m_productModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@prd_code", obj.prd_code)
                param.Add("@prd_name", obj.prd_name)
                param.Add("@prd_focus", obj.prd_focus)
                param.Add("@prd_type", obj.prd_type)
                param.Add("@prd_price", obj.prd_price)
                param.Add("@prd_group", obj.prd_group)
                param.Add("@prd_status", obj.prd_status)
                param.Add("@prd_price_valid_year", obj.prd_price_valid_year)
                connection()
                con.Open()
                con.Execute("SP_INSERT_MASTER_PRODUCT", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Update(obj As m_productModel) As Boolean
            Try
                Dim param As DynamicParameters = New DynamicParameters()
                param.Add("@prd_code", obj.prd_code)
                param.Add("@prd_name", obj.prd_name)
                param.Add("@prd_focus", obj.prd_focus)
                param.Add("@prd_type", obj.prd_type)
                param.Add("@prd_price", obj.prd_price)
                param.Add("@prd_group", obj.prd_group)
                param.Add("@prd_status", obj.prd_status)
                param.Add("@prd_price_valid_year", obj.prd_price_valid_year)
                connection()
                con.Open()
                con.Execute("SP_UPDATE_MASTER_PRODUCT", param, commandType:=CommandType.StoredProcedure)
                Return True
            Catch ex As Exception
                Throw ex
                Return False
            Finally
                con.Close()
            End Try
        End Function

        Public Function Delete(ByVal prd_code As String) As Boolean
            Try
                Dim sqlQuery As String = "DELETE FROM m_product WHERE prd_code = @prd_code"
                connection()
                con.Open()
                con.Execute(sqlQuery, New With {prd_code})
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

