Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data.SqlClient

Namespace TANABE_MVC.Models
    Public Class ProductClass
        Public Function GetDataProduct()
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim rd As SqlDataReader

            Dim sSQL As String = String.Empty
            Dim model = New List(Of ProductModel)()

            Try
                sSQL = "select * from v_m_product_aso"
                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sSQL
                rd = cmd.ExecuteReader()
                While rd.Read()
                    Dim data = New ProductModel()

                    data.prd_aso_id = rd("prd_aso_id")
                    data.prd_aso_desc = rd("prd_aso_desc")

                    data.prd_aso_type = rd("prd_aso_type")
                    data.prd_aso_category = rd("prd_aso_category")
                    data.prd_aso_join_desc = rd("prd_aso_join_desc")
                    data.prd_aso_hna_bpjs = rd("prd_aso_hna_bpjs")
                    data.prd_aso_price = rd("prd_aso_price")

                    data.prd_aso_gp = rd("prd_aso_gp")
                    data.prd_aso_ose = rd("prd_aso_ose")
                    data.prd_aso_group = rd("prd_aso_group")
                    data.prd_aso_group_fin = rd("prd_aso_group_fin")
                    data.prd_aso_tab = rd("prd_aso_tab")

                    data.prd_aso_dossage = rd("prd_aso_dossage")
                    data.prd_aso_dostime = rd("prd_aso_dostime")
                    data.prd_aso_tc = rd("prd_aso_tc")
                    data.prd_aso_pm = rd("prd_aso_pm")
                    data.nama_pm = rd("nama_pm")

                    model.Add(data)
                End While

            Catch ex As Exception
            Finally
                conn.Close()
            End Try

            Return model.ToList
        End Function

        Public Function GetDataPM()
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim rd As SqlDataReader

            Dim sSQL As String = String.Empty
            Dim model = New List(Of ProductpmModel)()

            Try
                sSQL = "select row_number() over(order by [nomor induk] asc) as num, [nomor induk] as nik, nama from all_karyawan where kode_departemen = 'PMD'"
                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sSQL
                rd = cmd.ExecuteReader()
                While rd.Read()
                    Dim data = New ProductpmModel()
                    data.num = rd("num")
                    data.nik = rd("nik")
                    data.name = rd("nama")
                    model.Add(data)
                End While

            Catch ex As Exception
            Finally
                conn.Close()
            End Try

            Return model.ToList
        End Function
        ' Public Sub InsertProduct(ByVal product As ProductModel)
        Public Sub InsertProduct(ByVal coll As FormCollection)

            Dim prd_aso_id As String = coll("prd_aso_id")
            Dim prd_aso_desc As String = coll("prd_aso_desc")
            Dim prd_aso_type As String = coll("prd_aso_type")
            Dim prd_aso_category As String = coll("prd_aso_category")
            Dim prd_aso_hna_bpjs As String = coll("prd_aso_hna_bpjs")
            Dim prd_aso_price As String = coll("prd_aso_price")
            Dim prd_aso_gp As String = coll("prd_aso_gp")
            Dim prd_aso_ose As String = coll("prd_aso_ose")
            Dim prd_aso_group As String = coll("prd_aso_group")
            Dim prd_aso_group_fin As String = coll("prd_aso_group_fin")
            Dim prd_aso_tab As String = coll("prd_aso_tab")
            Dim prd_aso_dossage As String = coll("prd_aso_dossage")
            Dim prd_aso_dostime As String = coll("prd_aso_dostime")
            Dim prd_aso_tc As String = coll("prd_aso_tc")

            Dim nama_pm As String = coll("nama_pm")
            Dim params As String() = nama_pm.Split(New Char() {"-"})
            Dim nik As String = params(0)
            Dim name As String = params(1)

            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim sSQL As String = String.Empty

            Try
                sSQL = "SP_INSERT_MASTER_PRODUCT_ASO"
                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                cmd.Connection = conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = sSQL
                cmd.Parameters.AddWithValue("@prd_aso_id", prd_aso_id)
                cmd.Parameters.AddWithValue("@prd_aso_desc", IIf(prd_aso_desc IsNot Nothing, prd_aso_desc, ""))
                cmd.Parameters.AddWithValue("@prd_aso_type", IIf(prd_aso_type IsNot Nothing, prd_aso_type, ""))
                cmd.Parameters.AddWithValue("@prd_aso_category", IIf(prd_aso_category IsNot Nothing, prd_aso_category, ""))
                cmd.Parameters.AddWithValue("@prd_aso_hna_bpjs", IIf(prd_aso_hna_bpjs IsNot Nothing, prd_aso_hna_bpjs, ""))
                cmd.Parameters.AddWithValue("@prd_aso_price", IIf(prd_aso_price IsNot Nothing, prd_aso_price, ""))
                cmd.Parameters.AddWithValue("@prd_aso_gp", IIf(prd_aso_gp IsNot Nothing, prd_aso_gp, ""))
                cmd.Parameters.AddWithValue("@prd_aso_ose", IIf(prd_aso_ose IsNot Nothing, prd_aso_ose, ""))
                cmd.Parameters.AddWithValue("@prd_aso_group", IIf(prd_aso_group IsNot Nothing, prd_aso_group, ""))
                cmd.Parameters.AddWithValue("@prd_aso_group_fin", IIf(prd_aso_group_fin IsNot Nothing, prd_aso_group_fin, ""))
                cmd.Parameters.AddWithValue("@prd_aso_tab", IIf(prd_aso_tab IsNot Nothing, prd_aso_tab, ""))
                cmd.Parameters.AddWithValue("@prd_aso_dossage", IIf(prd_aso_dossage IsNot Nothing, prd_aso_dossage, ""))
                cmd.Parameters.AddWithValue("@prd_aso_dostime", IIf(prd_aso_dostime IsNot Nothing, prd_aso_dostime, ""))
                cmd.Parameters.AddWithValue("@prd_aso_tc", IIf(prd_aso_tc IsNot Nothing, prd_aso_tc, ""))
                cmd.Parameters.AddWithValue("@prd_aso_pm", nik)

                cmd.ExecuteNonQuery()

            Catch ex As Exception
            Finally
                conn.Close()
            End Try

        End Sub

        Public Sub DeleteProduct(ByVal coll As FormCollection)

            Dim prd_aso_id As String = coll("prd_aso_id")

            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim sSQL As String = String.Empty

            Try
                sSQL = "delete from m_product_aso where prd_aso_id=@prd_aso_id"
                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sSQL
                cmd.Parameters.AddWithValue("@prd_aso_id", prd_aso_id)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
            Finally
                conn.Close()
            End Try

        End Sub

        Public Sub UpdateProduct(ByVal coll As FormCollection)

            Dim prd_aso_id As String = coll("prd_aso_id")
            Dim prd_aso_desc As String = coll("prd_aso_desc")
            Dim prd_aso_type As String = coll("prd_aso_type")
            Dim prd_aso_category As String = coll("prd_aso_category")
            Dim prd_aso_hna_bpjs As String = coll("prd_aso_hna_bpjs")
            Dim prd_aso_price As String = coll("prd_aso_price")
            Dim prd_aso_gp As String = coll("prd_aso_gp")
            Dim prd_aso_ose As String = coll("prd_aso_ose")
            Dim prd_aso_group As String = coll("prd_aso_group")
            Dim prd_aso_group_fin As String = coll("prd_aso_group_fin")
            Dim prd_aso_tab As String = coll("prd_aso_tab")
            Dim prd_aso_dossage As String = coll("prd_aso_dossage")
            Dim prd_aso_dostime As String = coll("prd_aso_dostime")
            Dim prd_aso_tc As String = coll("prd_aso_tc")

            Dim nama_pm As String = coll("nama_pm")
            Dim params As String() = nama_pm.Split(New Char() {"-"})
            Dim nik As String = params(0)
            Dim name As String = params(1)

            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim sSQL As String = String.Empty

            Try
                sSQL = "[SP_UPDATE_MASTER_PRODUCT_ASO]"
                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                cmd.Connection = conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = sSQL
                cmd.Parameters.AddWithValue("@prd_aso_id", prd_aso_id)
                cmd.Parameters.AddWithValue("@prd_aso_desc", IIf(prd_aso_desc IsNot Nothing, prd_aso_desc, ""))
                cmd.Parameters.AddWithValue("@prd_aso_type", IIf(prd_aso_type IsNot Nothing, prd_aso_type, ""))
                cmd.Parameters.AddWithValue("@prd_aso_category", IIf(prd_aso_category IsNot Nothing, prd_aso_category, ""))
                cmd.Parameters.AddWithValue("@prd_aso_hna_bpjs", IIf(prd_aso_hna_bpjs IsNot Nothing, prd_aso_hna_bpjs, ""))
                cmd.Parameters.AddWithValue("@prd_aso_price", IIf(prd_aso_price IsNot Nothing, prd_aso_price, ""))
                cmd.Parameters.AddWithValue("@prd_aso_gp", IIf(prd_aso_gp IsNot Nothing, prd_aso_gp, ""))
                cmd.Parameters.AddWithValue("@prd_aso_ose", IIf(prd_aso_ose IsNot Nothing, prd_aso_ose, ""))
                cmd.Parameters.AddWithValue("@prd_aso_group", IIf(prd_aso_group IsNot Nothing, prd_aso_group, ""))
                cmd.Parameters.AddWithValue("@prd_aso_group_fin", IIf(prd_aso_group_fin IsNot Nothing, prd_aso_group_fin, ""))
                cmd.Parameters.AddWithValue("@prd_aso_tab", IIf(prd_aso_tab IsNot Nothing, prd_aso_tab, ""))
                cmd.Parameters.AddWithValue("@prd_aso_dossage", IIf(prd_aso_dossage IsNot Nothing, prd_aso_dossage, ""))
                cmd.Parameters.AddWithValue("@prd_aso_dostime", IIf(prd_aso_dostime IsNot Nothing, prd_aso_dostime, ""))
                cmd.Parameters.AddWithValue("@prd_aso_tc", IIf(prd_aso_tc IsNot Nothing, prd_aso_tc, ""))
                cmd.Parameters.AddWithValue("@prd_aso_pm", nik)

                cmd.ExecuteNonQuery()

            Catch ex As Exception
            Finally
                conn.Close()
            End Try

        End Sub
    End Class
End Namespace



