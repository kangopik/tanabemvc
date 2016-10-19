Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data.Entity.Core.Objects
Imports System.Data.SqlClient

Namespace TANABE_MVC.Models
    Public Class VisitHistoryClass

        Public Function GetDataVisitHistory(tdb As VisitHistoryEntities, ByVal rep_id As String) As Object
            Using context As New VisitHistoryEntities()

                Dim currentDate As DateTime = DateTime.Now
                Dim month, year As Integer
                month = currentDate.Month
                year = currentDate.Year

                Return context.SP_SELECT_FINISHED_VISIT(rep_id, month, year).ToList()
            End Using
        End Function
        Public Function GetDataVisitHistoryRetrieve(tdb As VisitHistoryEntities, ByVal rep_id As String, ByVal month As String, ByVal year As String) As Object
            Using context As New VisitHistoryEntities()
                Return context.SP_SELECT_FINISHED_VISIT(rep_id, month, year).ToList()
            End Using
        End Function

        Public Function GetDataDetail(ByVal visit_id As String)
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim rd As SqlDataReader

            Dim sSQL As String = String.Empty
            Dim model = New List(Of DetailHistoryModel)()

            Try
                sSQL = "select * from v_visit_product where visit_id = @visit_id"
                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                cmd.Connection = conn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sSQL
                cmd.Parameters.AddWithValue("@visit_id", visit_id)
                rd = cmd.ExecuteReader()
                While rd.Read()
                    Dim data = New DetailHistoryModel()
                    data.vd_id = rd("vd_id")
                    data.visit_id = rd("visit_id")
                    data.visit_code = rd("visit_code")
                    data.visit_team = rd("visit_team")
                    data.visit_product = rd("visit_product")
                    data.visit_category = rd("visit_category")
                    data.vd_value = rd("vd_value")
                    model.Add(data)
                End While

            Catch ex As Exception
            Finally
                conn.Close()
            End Try

            Return model.ToList
        End Function
    End Class
End Namespace


