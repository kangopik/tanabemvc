Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data.SqlClient

Namespace TANABE_MVC.Models
    Public Class VisitActualClass
        Public Function GetDataVisitActual(tdb As VisitActualEntities, ByVal rep_id As String) As Object
            Try
                Using context As New VisitActualEntities()

                    Dim currentDate As DateTime = DateTime.Now
                    Dim day, month, year As Integer

                    day = 0
                    month = currentDate.Month
                    year = currentDate.Year

                    Return context.SP_SELECT_SUBMITTED_VISIT(rep_id, day, month, year).ToList()
                End Using

            Catch generatedExceptionName As Exception

                Throw New NotImplementedException()
            End Try

        End Function
        Public Function GetDataVisitActualRetrieve(tdb As VisitActualEntities, ByVal rep_id As String, ByVal day As String, ByVal month As String, ByVal year As String) As Object
            Using context As New VisitActualEntities()
                Return context.SP_SELECT_SUBMITTED_VISIT(rep_id, day, month, year).ToList()
            End Using

        End Function

        Public Function GetDataDetail(ByVal visit_id As String)
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim rd As SqlDataReader

            Dim sSQL As String = String.Empty
            Dim model = New List(Of DetailActualModel)()

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
                    Dim data = New DetailActualModel()
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

        Public Sub getFullVisitDate(ByVal rep_id As String)

            Dim currentDate As DateTime = DateTime.Now
            Dim dtall As DataTable = Query("SELECT DATEPART(DAY, visit_date_plan) as daylist,count(DATEPART(DAY, visit_date_plan)) as cnt " & _
                                         "FROM t_visit WHERE rep_id = '" & rep_id & "' AND DATEPART(MONTH, visit_date_plan) =  DATEPART(MONTH, GETDATE()) " & _
                                         "AND DATEPART(YEAR, visit_date_plan) =  DATEPART(YEAR, GETDATE()) AND [visit_date_realization_saved] IS NOT NULL GROUP BY visit_date_plan;")
            Dim i As Integer = 0
            Dim arr_date(31) As String

            For Each row As DataRow In dtall.Rows
                GlobalClass.temp_arr_visit_plan_full_date(i) = row("daylist").ToString()
                GlobalClass.temp_arr_visit_plan_full_cnt(i) = row("cnt").ToString()
                i = i + 1
            Next
        End Sub
        Function Query(ByVal sql As String) As DataTable
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim sSQL As String = String.Empty
            sSQL = sql
            conn = New SqlConnection(ConfigClass.Get_Constring)
            conn.Open()
            cmd.Connection = conn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = sSQL
            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            dt.Load(sdr)
            sdr.Close()
            conn.Close()
            Return dt
        End Function

        Public Sub ExecUpdate(ByVal visit_id As String, ByVal dr_code As String, ByVal visit_plan As String, ByVal visit_realization As String, ByVal visit_info As String, ByVal visit_sp As String, ByVal visit_sp_value As String)
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim sSQL As String = String.Empty
            Try
                sSQL = "[SP_UPDATE_REALIZATION_VISIT_ACTUAL]"
                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                cmd.Connection = conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = sSQL
                cmd.Parameters.AddWithValue("@visit_id", visit_id)
                cmd.Parameters.AddWithValue("@dr_code", dr_code)
                cmd.Parameters.AddWithValue("@visit_plan", visit_plan)
                cmd.Parameters.AddWithValue("@visit_realization", visit_realization)
                cmd.Parameters.AddWithValue("@visit_info", visit_info)
                cmd.Parameters.AddWithValue("@visit_sp", visit_sp)
                cmd.Parameters.AddWithValue("@visit_sp_value", visit_sp_value)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            Finally
                conn.Close()
            End Try

        End Sub
        Public Sub ExecReq(ByVal rep_id As String, ByVal acc As String, ByVal date_selected As String)

            If (isHaveRemainingToSendMail("RVR", rep_id)) Then
                SetReport(rep_id)
                GlobalClass.visit_actual_msg = "Request has been sent." 'success_send

            Else
                GlobalClass.visit_actual_msg = "verification realization request is limited to 3 times per day." 'send_limitation
            End If
        End Sub

        Function isHaveRemainingToSendMail(ByVal email_type As String, ByVal rep_id As String) As Boolean
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim sSQL As String = String.Empty

            Try
                Dim currentDate As DateTime = DateTime.Now
                Dim curr_month As Int32 = currentDate.Month
                Dim curr_year As Int32 = currentDate.Year

                sSQL = "[SP_SELECT_TRANSACT_EMAIL]"
                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                cmd.Connection = conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = sSQL
                cmd.Parameters.AddWithValue("@rep_id", rep_id)
                cmd.Parameters.AddWithValue("@month", curr_month)
                cmd.Parameters.AddWithValue("@year", curr_year)
                cmd.Parameters.AddWithValue("@transaction_id", email_type)
                cmd.Parameters.AddWithValue("@date_sent", CDate(currentDate).ToString("yyyy-MM-dd"))
                Dim rd As SqlDataReader = cmd.ExecuteReader()
                rd.Read()
                If rd("is_pass") = 1 Then
                    rd.Close()
                    Return True         '//true = masih bisa kirim email
                Else
                    rd.Close()
                    Return False        '//false = tidak bisa kirim email
                End If
            Catch ex As Exception
                Return False
            Finally
                conn.Close()
            End Try
        End Function
        Sub SetReport(ByVal rep_id As String)
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Dim da As New SqlDataAdapter
            Dim dt As New DataTable
            Dim sSQL As String = String.Empty

            Try

                'MyConnection.Open()
                'exTransaction = MyConnection.BeginTransaction()

                'Dim tempPageMSG As New System.Text.StringBuilder
                'tempPageMSG.Append("PT. TANABE INDONESIA" & vbCrLf)
                'tempPageMSG.Append("VISIT PLANNED REALIZED" & vbCrLf)
                'tempPageMSG.Append("Nama      : " & Session("rep_name") & vbCrLf)
                'tempPageMSG.Append("Regional : " & Session("rep_reg") & vbCrLf)
                'tempPageMSG.Append("BO          : " & Session("rep_bo") & vbCrLf)
                'If Me.rb_sub_real.SelectedIndex = 1 Then
                '    tempPageMSG.Append("DATE     : " & dateVerReal.Text & vbCrLf)
                'Else
                '    tempPageMSG.Append("DATE     :____________________________" & vbCrLf)
                'End If

                'gridExport.ReportHeader = tempPageMSG.ToString

                'Dim PdfFile As New System.IO.MemoryStream

                'gridExport.WritePdf(PdfFile)

                'PdfFile.Seek(0, SeekOrigin.Begin)

                'Dim reader As New StreamReader(Server.MapPath("~/ContentEmailPage/email_page_new_real.htm"))
                'Dim readFile As String = reader.ReadToEnd()
                'Dim email_body As String = ""
                'email_body = readFile
                'email_body = email_body.Replace("$$RECEIVER$$", Session("rep_am_name"))
                'email_body = email_body.Replace("$$rep_name$$", Session("rep_name"))
                'email_body = email_body.Replace("$$rep_region$$", Session("rep_reg"))
                'email_body = email_body.Replace("$$bo$$", Session("rep_bo"))
                'email_body = email_body.Replace("$$sbo$$", Session("rep_sbo"))
                'email_body = email_body.Replace("$$rep_id$$", Session("rep_id"))
                'If Me.rb_sub_real.SelectedIndex = 1 Then
                '    email_body = email_body.Replace("$$date_plan$$", dateVerReal.Text)
                'Else
                '    email_body = email_body.Replace("$$date_plan$$", "")
                'End If

                'email_body = email_body.Replace("$$Date$$", Date.Now())


                'Dim mailMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
                'Dim smtpClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()
                'mailMessage.From = New System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings("fromEmailAddress"))
                'mailMessage.To.Add(New System.Net.Mail.MailAddress(Session("rep_am_email")))

                'If Me.rb_sub_real.SelectedIndex = 1 Then
                '    mailMessage.Attachments.Add(New Attachment(PdfFile, Session("rep_name") & " - Schedule_Visit_Realization - " & dateVerReal.Text, "application/pdf"))
                '    mailMessage.Subject = "Request Verification for " & Session("rep_name") & " - " & "Schedule Visit Realization - " & dateVerReal.Text
                'Else
                '    mailMessage.Attachments.Add(New Attachment(PdfFile, Session("rep_name") & " - Schedule_Visit_Realization", "application/pdf"))
                '    mailMessage.Subject = "Request Verification for " & Session("rep_name") & " - " & "Schedule Visit Realization"
                'End If
                'mailMessage.Priority = Net.Mail.MailPriority.High
                'mailMessage.Body = email_body.ToString()
                'mailMessage.IsBodyHtml = True
                'smtpClient.Send(mailMessage)

                Dim currentDate As DateTime = DateTime.Now
                Dim curr_month As Int32 = currentDate.Month
                Dim curr_year As Int32 = currentDate.Year

                sSQL = "[SP_INSERT_TRANSACT_EMAIL]"
                conn = New SqlConnection(ConfigClass.Get_Constring)
                conn.Open()
                cmd.Connection = conn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = sSQL


                cmd.Parameters.AddWithValue("@rep_id", rep_id)
                cmd.Parameters.AddWithValue("@month", curr_month)
                cmd.Parameters.AddWithValue("@year", curr_year)
                cmd.Parameters.AddWithValue("@transaction_id", "RVR")
                cmd.Parameters.AddWithValue("@date_sent", CDate(currentDate).ToString("yyyy-MM-dd"))

                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally
                conn.Close()
            End Try
        End Sub
    End Class
End Namespace


