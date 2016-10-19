Imports System.Data.SqlClient
Imports System.Linq
Imports System.Dynamic

Public Class ProductListClass
    Public Function GetDataProductList()
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim rd As SqlDataReader

        Dim sSQL As String = String.Empty
        Dim model = New List(Of ProductListModel)()

        Try
            sSQL = "select rtrim(visit_code) as visit_code,rtrim(visit_team) as visit_team,rtrim(visit_product) as visit_product, rtrim(visit_category) as visit_category from m_visit where visit_status = 1 and visit_code <> 't0' order by visit_team,visit_product"
            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sSQL
            rd = cmd.ExecuteReader()
            While rd.Read()
                Dim product = New ProductListModel()
                product.visit_code = rd("visit_code")
                product.visit_team = rd("visit_team")
                product.visit_product = rd("visit_product")
                product.visit_category = rd("visit_category")
                model.Add(product)
            End While

        Catch ex As Exception
        Finally
            conn.Close()
        End Try

        Return model.ToList
    End Function

End Class

