Imports System.Data.SqlClient
Imports System.Linq
Imports System.Dynamic

Public Class VisitRealization
    Dim exTransaction As SqlTransaction
    Public Function GetDataVisitRealizationRetrieve(ByVal rep_id As String, ByVal month As Integer, ByVal year As Integer)
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim rd As SqlDataReader

        Dim sSQL As String = String.Empty
        Dim model = New List(Of VisitRealModel)()

        Try
            sSQL = "SELECT * FROM [v_visit_plan] WHERE rep_id = @rep_id AND (DATEPART(month,visit_date_plan) = @visit_date_plan AND DATEPART(year,visit_date_plan) = @visit_year_plan) AND visit_plan_verification_status = 1 AND visit_date_realization_saved is null  ORDER BY visit_date_plan ASC"
            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sSQL
            cmd.Parameters.AddWithValue("@rep_id", rep_id)
            cmd.Parameters.AddWithValue("@visit_date_plan", month)
            cmd.Parameters.AddWithValue("@visit_year_plan", year)
            rd = cmd.ExecuteReader()
            While rd.Read()
                Dim realization = New VisitRealModel()
                realization.rep_id = rd("rep_id")
                realization.visit_id = rd("visit_id")
                realization.dr_code = rd("dr_code")
                realization.dr_name = rd("dr_name")

                realization.visit_date_plan = rd("visit_date_plan")
                realization.visit_plan_verification_status = rd("visit_plan_verification_status")
                realization.visit_real_verification_status = rd("visit_real_verification_status")
                realization.dr_spec = rd("dr_spec")
                realization.dr_sub_spec = rd("dr_sub_spec")
                realization.dr_quadrant = rd("dr_quadrant")

                realization.dr_monitoring = rd("dr_monitoring")
                realization.dr_dk_lk = rd("dr_dk_lk")
                realization.dr_area_mis = rd("dr_area_mis")
                realization.dr_category = rd("dr_category")
                realization.dr_chanel = rd("dr_chanel")

                model.Add(realization)
            End While

        Catch ex As Exception
        Finally
            conn.Close()
        End Try

        Return model.ToList
    End Function

    Public Function GetDataVisitRealization(ByVal rep_id As String)
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim rd As SqlDataReader

        Dim sSQL As String = String.Empty

        Dim today = Date.Today

        Dim year As Integer = today.Year
        Dim month As Integer = today.Month
        Dim model = New List(Of VisitRealModel)()

        Try
            sSQL = "SELECT * FROM [v_visit_plan] WHERE rep_id = @rep_id AND (DATEPART(month,visit_date_plan) = @visit_date_plan AND DATEPART(year,visit_date_plan) = @visit_year_plan) AND visit_plan_verification_status = 1 AND visit_date_realization_saved is null  ORDER BY visit_date_plan ASC"
            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sSQL
            cmd.Parameters.AddWithValue("@rep_id", rep_id)
            cmd.Parameters.AddWithValue("@visit_date_plan", month)
            cmd.Parameters.AddWithValue("@visit_year_plan", year)
            rd = cmd.ExecuteReader()
            While rd.Read()
                Dim realization = New VisitRealModel()
                realization.rep_id = rd("rep_id")
                realization.visit_id = rd("visit_id")
                realization.dr_code = rd("dr_code")
                realization.dr_name = rd("dr_name")

                realization.visit_date_plan = rd("visit_date_plan")
                realization.visit_plan_verification_status = rd("visit_plan_verification_status")
                realization.visit_real_verification_status = rd("visit_real_verification_status")
                realization.dr_spec = rd("dr_spec")
                realization.dr_sub_spec = rd("dr_sub_spec")
                realization.dr_quadrant = rd("dr_quadrant")

                realization.dr_monitoring = rd("dr_monitoring")
                realization.dr_dk_lk = rd("dr_dk_lk")
                realization.dr_area_mis = rd("dr_area_mis")
                realization.dr_category = rd("dr_category")
                realization.dr_chanel = rd("dr_chanel")

                model.Add(realization)
            End While


        Catch ex As Exception
        Finally
            conn.Close()
        End Try

        Return model.ToList
    End Function

    
    
    
    Public Sub ExecHalfCancellation(ByVal rep_id As String, ByVal visit_id As String, ByVal rep_position As String, ByVal visit_info As String)
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand

        Dim currentDate As DateTime = DateTime.Now
        Dim sSQL As String = String.Empty
        Try
            sSQL = "[SP_UPDATE_VISIT_PLAN_CANCELLATION]"
            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = sSQL
            cmd.Parameters.AddWithValue("@rep_id", rep_id)
            cmd.Parameters.AddWithValue("@rep_position", rep_position)
            cmd.Parameters.AddWithValue("@visit_id", visit_id)
            cmd.Parameters.AddWithValue("@visit_info", visit_info)
            cmd.Parameters.AddWithValue("@visit_date_realization_saved", currentDate)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            GlobalClass.realization_msg = "There is an error on submitting cancellation process."
        Finally
            GlobalClass.realization_msg = "Cancellation has been successfully submitted."
            conn.Close()
        End Try

    End Sub
    Public Sub ExecFullCancellation(ByVal rep_id As String, ByVal rep_position As String, ByVal visit_info As String, ByVal visit_date_plan As String)
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand

        Dim currentDate As DateTime = DateTime.Now
        Dim sSQL As String = String.Empty
        Try
            sSQL = "[SP_UPDATE_VISIT_PLAN_BY_DATE]"
            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = sSQL
            cmd.Parameters.AddWithValue("@rep_id", rep_id)
            cmd.Parameters.AddWithValue("@rep_position", rep_position)
            cmd.Parameters.AddWithValue("@visit_info", visit_info)
            cmd.Parameters.AddWithValue("@visit_date_realization_saved", currentDate)
            cmd.Parameters.AddWithValue("@visit_date_plan", CDate(visit_date_plan).ToString("yyyy-MM-dd"))

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            GlobalClass.realization_msg = "There is an error on submitting cancellation process."
        Finally
            GlobalClass.realization_msg = "Cancellation has been successfully submitted."
            conn.Close()
        End Try
    End Sub
End Class
