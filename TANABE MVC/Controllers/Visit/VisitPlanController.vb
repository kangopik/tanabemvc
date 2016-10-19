Imports DevExpress.Web.Mvc
Imports System.Web.Mvc
Imports TANABE_MVC.TANABE_MVC.Models
Imports DevExpress.Web
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports DevExpress.Web.Mvc.MVCxGridView
Imports TANABE_MVC.Repositories
Imports System.IO
Imports System.Net.Mail

Public Class VisitPlanController
    Inherits Controller
    ' GET: /Visit
    'Dim db As New VisitPlanEntities()
    Dim repo As New r_plan
    Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])

        'page load
        If Not (Request.HttpMethod = "POST") Then
            Dim currentDate As DateTime = DateTime.Now
            Session("sess_day") = 0
            Session("sess_month") = currentDate.Month
            Session("sess_year") = currentDate.Year
        End If

        If username = "" Then
            Return RedirectToAction("", "login")
        Else

            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            GlobalClass.temp_rep_position = TryCast(Session("rep_position"), [String])
            repo.getFullVisitDate(rep_id)
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            If GlobalClass.temp_message_visit_plan_recent = False Then
                TempData("msg") = GlobalClass.temp_message_visit_plan
                GlobalClass.temp_message_visit_plan_recent = True
            Else
                TempData("msg") = GlobalClass.temp_message_visit_plan
                GlobalClass.temp_message_visit_plan = ""
                GlobalClass.temp_message_visit_plan_recent = False
            End If

            Return View("~/Views/Visit/Plan/Plan.vbhtml")
        End If

    End Function

    <HttpPost(), ValidateInput(False)> _
    Function DeletePlan(ByVal coll As FormCollection) As ActionResult
        Dim visit_id As String = coll("visit_id")
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Dim model
        If visit_id <> "" Then
            repo.DeleteVisitPlan(visit_id)
            repo.getFullVisitDate(rep_id)
        End If

        Try
            model = repo.GetVisitPlan(rep_id, Session("sess_day"), Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Visit/Plan/DataViewPartial.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function UpdatePlan(ByVal coll As FormCollection) As ActionResult
        Dim visit_id As String = coll("visit_id")
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Dim dr_code As String = coll("dr_code")
        If visit_id <> "" And dr_code <> "" Then
            repo.UpdatePlan(coll)
            repo.getFullVisitDate(rep_id)
        End If

        Dim model
        Try
            model = repo.GetVisitPlan(rep_id, Session("sess_day"), Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Visit/Plan/DataViewPartial.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DataViewPartial() As ActionResult
        Dim model
        Try
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            Dim rep_position As String = TryCast(Session("rep_position"), [String])
            repo.getFullVisitDate(rep_id)
            ViewData("rep_id") = rep_id
            ViewData("rep_position") = rep_position
            model = repo.GetVisitPlan(rep_id, Session("sess_day"), Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        If GlobalClass.temp_message_visit_plan <> "" Then
            TempData("msg") = GlobalClass.temp_message_visit_plan
            GlobalClass.temp_message_visit_plan = ""
        End If
        Return PartialView("~/Views/Visit/Plan/DataViewPartial.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DataViewPartialCustomCallback(ByVal prm As String) As ActionResult
        Dim rep_position As String = TryCast(Session("rep_position"), [String])
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Dim params As String() = prm.Split(New Char() {";"})
        Dim act As String = params(0)
        Dim day As String = 0
        If params.Count > 3 Then
            day = params(3)
        End If

        If act = "retrieve" Then
            Dim month As String = params(1)
            Dim year As String = params(2)
            If month <> "null" Then
                If year <> "null" Then
                    Session("sess_day") = 0
                    Session("sess_month") = month
                    Session("sess_year") = year
                End If
            End If
        ElseIf act = "filter" Then
            Dim month As String = params(1)
            Dim year As String = params(2)
            If month <> "null" Then
                If year <> "null" Then
                    Session("sess_day") = day
                    Session("sess_month") = month
                    Session("sess_year") = year
                End If
            End If
        ElseIf act = "export" Then
            Return RedirectToAction("exportto", "visitplan", New With {.export_type = params(1)})
        ElseIf act = "addvisit" Then
            GlobalClass.temp_doctor_planned_day_visit_plan = ""
            GlobalClass.temp_doctor_planned_week_visit_plan = ""
            GlobalClass.temp_message_visit_plan = ""
            GlobalClass.temp_retrieve = 0
            Dim v_visit_date_plan As String = CDate(params(2)).ToString("yyyy-MM-dd")
            Dim dr_code As String = params(1)
            'If dr_code = "324008" Then
            '    ViewData("SaveFlag") = "error_insert"
            'End If
            Dim words As String() = dr_code.Split(New Char() {","})


            For i As Integer = 0 To words.Length - 1
                repo.ExecVisitPlan(rep_id, v_visit_date_plan, words(i), rep_position)
            Next
        ElseIf act = "request" Then
            Dim month As Integer = params(1)
            Dim currentDate As DateTime = DateTime.Now
            Dim curr_month As Int32 = currentDate.Month
            Dim curr_year As Int32 = currentDate.Year
            Dim curr_monthRequest As Int32 = month
            If curr_monthRequest = 0 Then
                curr_monthRequest = curr_month
            End If

            If Not (repo.isAnyDoctorUnverificatedRealInPrevMonth(curr_monthRequest - 1, rep_id)) Then
                If Session("rep_position") <> "PPM" Then
                    If (repo.isAnyDoctorUnplaned(curr_monthRequest, rep_id)) Then
                        ViewData("RequestFlag") = "error_send"
                    Else
                        If Not (repo.isAnyDayLessThenMinimumDoctor(Session("rep_position"), rep_id)) Then
                            If (repo.isHaveRemainingToSendMail("RVP", rep_id)) Then
                                SetReport(rep_id, curr_monthRequest, params(2))
                                ViewData("RequestFlag") = "success_send"
                            Else
                                ViewData("RequestFlag") = "send_limitation"
                            End If
                        Else
                            ViewData("RequestFlag") = "less_doctor"
                        End If
                    End If
                Else
                    If Not (repo.isAnyDayLessThenMinimumDoctor(Session("rep_position"), rep_id)) Then
                        If (repo.isHaveRemainingToSendMail("RVP", rep_id)) Then
                            SetReport(rep_id, curr_monthRequest, params(2))
                            ViewData("RequestFlag") = "success_send"
                        Else
                            ViewData("RequestFlag") = "send_limitation"
                        End If
                    Else
                        ViewData("RequestFlag") = "less_doctor"
                    End If
                End If
            Else
                ViewData("RequestFlag") = "prev_month_unverificated_real"
            End If

        Else
            Dim currentDate As DateTime = DateTime.Now
            Session("sess_day") = 0
            Session("sess_month") = currentDate.Month
            Session("sess_year") = currentDate.Year
        End If
        Dim model
        Try
            repo.getFullVisitDate(rep_id)
            ViewData("rep_id") = rep_id
            ViewData("rep_position") = rep_position
            Dim year As Integer = GlobalClass.temp_year
            model = repo.GetVisitPlan(rep_id, Session("sess_day"), Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        If GlobalClass.temp_message_visit_plan <> "" Then
            TempData("msg") = GlobalClass.temp_message_visit_plan
            GlobalClass.temp_message_visit_plan = ""
        End If
        Return PartialView("~/Views/Visit/Plan/DataViewPartial.vbhtml", model)
    End Function

    Sub SetReport(ByVal rep_id As String, ByVal monthReq As String, ByVal sumCollection As String)
        Dim conn As New SqlConnection
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter
        Dim dt As New DataTable
        Dim sSQL As String = String.Empty

        Select Case monthReq
            Case 1 : monthReq = "January"
            Case 2 : monthReq = "February"
            Case 3 : monthReq = "March"
            Case 4 : monthReq = "April"
            Case 5 : monthReq = "May"
            Case 6 : monthReq = "June"
            Case 7 : monthReq = "July"
            Case 8 : monthReq = "August"
            Case 9 : monthReq = "September"
            Case 10 : monthReq = "October"
            Case 11 : monthReq = "November"
            Case 12 : monthReq = "December"
        End Select
        Dim prmSum As String() = sumCollection.Split(New Char() {"-"})

        Try
            Dim tempPageMSG As New System.Text.StringBuilder
            tempPageMSG.Append("PT. TANABE INDONESIA" & vbCrLf)
            tempPageMSG.Append("SHCEDULE VISIT PLAN" & vbCrLf)
            tempPageMSG.Append("Nama      : " & Session("rep_name") & vbCrLf)
            tempPageMSG.Append("Regional : " & Session("rep_reg") & vbCrLf)
            tempPageMSG.Append("BO          : " & Session("rep_bo") & vbCrLf)
            tempPageMSG.Append("Month     : " & monthReq & vbCrLf)

            Dim sumQ1 As String = prmSum(0)
            Dim sumQ2 As String = prmSum(1)
            Dim sumQ3 As String = prmSum(2)
            Dim sumDoctor As String = prmSum(3)

            Dim tempPageFooterMSG As New System.Text.StringBuilder
            tempPageFooterMSG.Append("Total Doctor                      : " & repo.GetDoctorRepInfo(rep_id) & vbCrLf)
            tempPageFooterMSG.Append("Total Planned Doctor       : " & sumDoctor & vbCrLf)
            tempPageFooterMSG.Append("Total Planned Doctor Q1 : " & sumQ1 & vbCrLf)
            tempPageFooterMSG.Append("Total Planned Doctor Q2 : " & sumQ2 & vbCrLf)
            tempPageFooterMSG.Append("Total Planned Doctor Q3 : " & sumQ3 & vbCrLf)

            Dim settings As GridViewSettings = VisitPlanGridViewHelper.ExportGridViewSettings
            settings.SettingsExport.ReportHeader = tempPageMSG.ToString
            settings.SettingsExport.ReportFooter = tempPageFooterMSG.ToString

            Dim PdfFile As New System.IO.MemoryStream
            Dim model
            Try
                model = repo.GetVisitPlan(rep_id, Session("sess_day"), Session("sess_month"), Session("sess_year"))
            Catch generatedExceptionName As Exception
                Throw
            End Try

            GridViewExtension.WritePdf(settings, model, PdfFile)
            PdfFile.Seek(0, SeekOrigin.Begin)
            Dim reader As New StreamReader(Server.MapPath("~/ContentEmailPage/email_page_new_plan.htm"))
            Dim readFile As String = reader.ReadToEnd()
            Dim email_body As String = ""
            email_body = readFile
            email_body = email_body.Replace("$$RECEIVER$$", Session("rep_am_name"))
            email_body = email_body.Replace("$$rep_name$$", Session("rep_name"))
            email_body = email_body.Replace("$$rep_region$$", Session("rep_reg"))
            email_body = email_body.Replace("$$bo$$", Session("rep_bo"))
            email_body = email_body.Replace("$$sbo$$", Session("rep_sbo"))
            email_body = email_body.Replace("$$rep_id$$", Session("rep_id"))
            email_body = email_body.Replace("$$month_plan$$", monthReq)


            email_body = email_body.Replace("$$Date$$", Date.Now())


            Dim mailMessage As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
            Dim smtpClient As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient()
            mailMessage.From = New System.Net.Mail.MailAddress(System.Configuration.ConfigurationManager.AppSettings("fromEmailAddress"))
            mailMessage.To.Add(New System.Net.Mail.MailAddress(Session("rep_am_email")))
            'mailMessage.To.Add(New System.Net.Mail.MailAddress("agus.hamdani@tanabe.co.id"))
            mailMessage.Attachments.Add(New Attachment(PdfFile, Session("rep_name") & " - Schedule_Visit_Plan - " & monthReq, "application/pdf"))
            mailMessage.Subject = "Request Verification for " & Session("rep_name") & " - " & "Schedule Visit Plan - " & monthReq

            mailMessage.Priority = Net.Mail.MailPriority.High
            mailMessage.Body = email_body.ToString()
            mailMessage.IsBodyHtml = True
            smtpClient.Send(mailMessage)

            repo.SaveReport(rep_id)

            ' exTransaction.Commit()
        Catch ex As Exception
            'exTransaction.Rollback()
        End Try


    End Sub

    <ValidateInput(False)> _
    Public Function InfoDetail(ByVal act As String) As ActionResult
        ViewData("dr_code") = act
        Dim model
        Try
            model = repo.GetDataDetail(act)
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Visit/Plan/InfoDetail.vbhtml", model)
    End Function

    Public Function LoadOnDemandPartial() As ActionResult
        Dim model
        Try
            Dim rep_position As String = TryCast(Session("rep_position"), [String])
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            repo.getFullVisitDate(rep_id)
            model = repo.GetDoctorList(rep_id, rep_position)
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Visit/Plan/PopupNewPlanView.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function GridLookupPartial() As ActionResult
        Dim model
        Try
            Dim rep_position As String = TryCast(Session("rep_position"), [String])
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            model = repo.GetDoctorList(rep_id, rep_position)
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Visit/Plan/GridLookupPartial.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function Notify() As ActionResult
        ViewData("msg") = GlobalClass.temp_message_visit_plan
        Return PartialView("~/Views/Visit/Plan/NotifyView.vbhtml")
    End Function

    Public Function LoadReqVerivication() As ActionResult
        Return PartialView("~/Views/Visit/Plan/PopUpReqVerification.vbhtml")
    End Function

    Public Function ExportTo(ByVal export_type As String) As ActionResult
        Dim model
        Try
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            model = repo.GetVisitPlan(rep_id, Session("sess_day"), Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Select Case export_type.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(VisitPlanGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(VisitPlanGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(VisitPlanGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(VisitPlanGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(VisitPlanGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("DataViewPartial")
        End Select
    End Function


End Class
Public NotInheritable Class VisitPlanGridViewHelper
    Private Shared exportGridViewSettings_Renamed As GridViewSettings

    Private Sub New()
    End Sub
    Public Shared ReadOnly Property ExportGridViewSettings() As GridViewSettings
        Get
            If exportGridViewSettings_Renamed Is Nothing Then
                exportGridViewSettings_Renamed = CreateExportGridViewSettings()
            End If
            Return exportGridViewSettings_Renamed
        End Get
    End Property

    Private Shared Function CreateExportGridViewSettings() As GridViewSettings
        Dim settings As New GridViewSettings()
        Dim _user_name As String = GlobalClass.temp_user_name
        settings.Name = "VISIT_PLAN"
        settings.CallbackRouteValues = New With {Key .Controller = "visit", Key .Action = "plan"}
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "visit_plan_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


        settings.SettingsExport.Styles.Title.Font.Size = 11
        settings.SettingsExport.Styles.Cell.Font.Size = 9
        settings.SettingsExport.Styles.Header.Font.Size = 9

        settings.SettingsExport.Styles.GroupRow.Font.Size = 9
        settings.SettingsExport.Styles.GroupFooter.Font.Size = 9

        settings.SettingsExport.Styles.Footer.Font.Size = 9
        settings.SettingsExport.PageHeader.Font.Size = 9

        settings.SettingsExport.TopMargin = 10
        settings.SettingsExport.LeftMargin = 10
        settings.SettingsExport.RightMargin = 10
        settings.SettingsExport.BottomMargin = 10
        settings.Settings.ShowFooter = True
        settings.SettingsExport.PageFooter.Right = "[Page # of Pages #]"

        settings.Settings.ShowTitlePanel = True
        settings.SettingsText.Title = "VISIT PLAN"

        settings.KeyFieldName = "rep_id"
        settings.Columns.Add("visit_id")
        settings.Columns.Add("visit_date_plan")
        settings.Columns.Add("dr_code")
        settings.Columns.Add("visit_plan")
        settings.Columns.Add("dr_name")
        settings.Columns.Add("dr_spec")
        settings.Columns.Add("dr_sub_spec")
        settings.Columns.Add("dr_quadrant")
        settings.Columns.Add("dr_monitoring")
        settings.Columns.Add("dr_dk_lk")
        settings.Columns.Add("dr_area_mis")
        settings.Columns.Add("dr_category")
        settings.Columns.Add("dr_chanel")
        settings.Columns(0).Caption = "PLAN ID"
        settings.Columns(1).Caption = "DATE PLAN"
        settings.Columns(2).Caption = "DR CODE"
        settings.Columns(3).Caption = "VPLAN"
        settings.Columns(4).Caption = "DR NAME"
        settings.Columns(5).Caption = "DR SPEC"
        settings.Columns(6).Caption = "SUB SPEC"
        settings.Columns(7).Caption = "QRD"
        settings.Columns(8).Caption = "MTG"
        settings.Columns(9).Caption = "DK/LK"
        settings.Columns(10).Caption = "AREA MIS"
        settings.Columns(11).Caption = "CATEGORY"
        settings.Columns(12).Caption = "CHANNEL"

        Return settings
    End Function
End Class


