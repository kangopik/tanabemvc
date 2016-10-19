Imports System.Data.SqlClient

Public Class DoctorPlanedClass
    Public Function GetDataDoctorPlaned(ByVal rep_id As String, ByVal visit_date_plan As String)
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim rd As SqlDataReader

        Dim sSQL As String = String.Empty
        Dim model = New List(Of DoctorPlanedModel)()

        Try
            sSQL = "select * from [v_visit_plan] where rep_id = @rep_id and convert(date,visit_date_plan) = @visit_date_plan and [visit_plan_verification_status] = 1 and [visit_date_realization_saved] is null order by visit_date_plan asc"
            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sSQL
            cmd.Parameters.AddWithValue("@rep_id", rep_id)
            cmd.Parameters.AddWithValue("@visit_date_plan", visit_date_plan)
            rd = cmd.ExecuteReader()
            While rd.Read()
                Dim data = New DoctorPlanedModel()

                data.visit_id = rd("visit_id")
                data.visit_date_plan = rd("visit_date_plan")
                data.dr_code = rd("dr_code")
                data.dr_name = rd("dr_name")
                data.dr_quadrant = rd("dr_quadrant")
                data.dr_monitoring = rd("dr_monitoring")

                model.Add(data)
            End While

        Catch ex As Exception
        Finally
            conn.Close()
        End Try

        Return model.ToList
    End Function
End Class
