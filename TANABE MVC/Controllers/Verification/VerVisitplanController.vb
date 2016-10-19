
Imports System.Web.Mvc
Imports TANABE_MVC.TANABE_MVC.Models
Imports System.Drawing.Printing
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories

Public Class VerVisitplanController
    Inherits Controller
    Dim repo As New r_VerVisitPlan
    ' GET: /VerVisitplanController

    Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])
        Session("sess_rep_id") = ""

        If Not (Request.HttpMethod = "POST") Then
            Dim currentDate As DateTime = DateTime.Now
            Session("rep_id_selection") = ""
            Session("sess_month") = currentDate.Month
            Session("sess_year") = currentDate.Year
        End If

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Verification/Plan/Verification.vbhtml")
        End If

    End Function

    <ValidateInput(False)> _
    Public Function DataViewPartial() As ActionResult
        Dim model
        Try
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.GetVisitPlanReady(rep_id, Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Verification/Plan/VerVisitPlanDataViewPartial.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DataViewPartialCustomCallback(ByVal prm As String) As ActionResult
        ViewData("VerifyFlag") = "undefined"
        Dim model = Nothing
        Dim params As String() = prm.Split(New Char() {";"})
        Dim act As String = params(0)

        If act = "retrieve" Then
            Dim rep_id_selection As String = params(1)
            Dim month As String = params(2)
            Dim year As String = params(3)
            If rep_id_selection <> "null" Then
                If month <> "null" Then
                    If year <> "null" Then
                        Session("rep_id_selection") = rep_id_selection
                        Session("sess_month") = month
                        Session("sess_year") = year
                        Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
                        model = repo.GetVisitPlanReady(rep_id, Session("sess_month"), Session("sess_year"))
                        If model.Count = 0 Then
                            ViewData("VerifyFlag") = "no_record"
                        Else
                            ViewData("VerifyFlag") = "record_exists"
                        End If
                    End If
                End If
            End If
        ElseIf act = "reset" Then
            Dim currentDate As DateTime = DateTime.Now
            Session("rep_id_selection") = ""
            Session("sess_month") = currentDate.Month
            Session("sess_year") = currentDate.Year
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.GetVisitPlanReady(rep_id, Session("sess_month"), Session("sess_year"))
        ElseIf act = "verify" Then
            Dim visit_id As String = params(4)
            model = repo.processVerify(visit_id, Session("rep_id"))
            If (model) Then
                ViewData("VerifyFlag") = "success_verify"
            Else
                ViewData("VerifyFlag") = "error_verify"
            End If
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.GetVisitPlanReady(rep_id, Session("sess_month"), Session("sess_year"))
        ElseIf act = "export" Then
            Return RedirectToAction("exportto", "vervisitplan", New With {.export_type = params(1)})
        Else
            Dim visit_id As String = params(4)
            model = repo.processVerifyOnebyOne(visit_id, Session("rep_id"))
            If (model) Then
                ViewData("VerifyFlag") = "success_verify"
            Else
                ViewData("VerifyFlag") = "error_verify"
            End If
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.GetVisitPlanReady(rep_id, Session("sess_month"), Session("sess_year"))
        End If

       
        Return PartialView("~/Views/Verification/Plan/VerVisitPlanDataViewPartial.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function GridLookupPartial() As ActionResult
        Dim model = Nothing
        Try
            Dim rep_position As String = TryCast(Session("rep_position"), [String])
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            Dim departemen As String = TryCast(Session("KODEDEPARTEMEN"), [String])
            model = repo.GetDataRep(departemen, rep_position, rep_id)
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Verification/Plan/GridLookupPartial.vbhtml", model)
    End Function

    Public Function ExportTo(ByVal export_type As String) As ActionResult
        Dim model
        Try
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.GetVisitPlanReady(rep_id, Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Select Case export_type.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(VerVisitPlanervisitplanGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(VerVisitPlanervisitplanGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(VerVisitPlanervisitplanGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(VerVisitPlanervisitplanGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(VerVisitPlanervisitplanGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("DataViewPartial")
        End Select
    End Function
End Class

Public NotInheritable Class VerVisitPlanervisitplanGridViewHelper
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
        settings.Name = "VER_VISIT_PLAN"
        settings.CallbackRouteValues = New With {Key .Controller = "vervisitplan", Key .Action = "Index"}
        'settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = PaperKind.A4
        settings.SettingsExport.FileName = "ver_visit_plan_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


        settings.SettingsExport.Styles.Title.Font.Size = 11.5
        settings.SettingsExport.Styles.Cell.Font.Size = 7
        settings.SettingsExport.Styles.Header.Font.Size = 7

        settings.SettingsExport.Styles.GroupRow.Font.Size = 7
        settings.SettingsExport.Styles.GroupFooter.Font.Size = 7

        settings.SettingsExport.Styles.Footer.Font.Size = 7
        settings.SettingsExport.PageHeader.Font.Size = 7

        settings.SettingsExport.TopMargin = 10
        settings.SettingsExport.LeftMargin = 10
        settings.SettingsExport.RightMargin = 10
        settings.SettingsExport.BottomMargin = 10
        settings.Settings.ShowFooter = True
        settings.SettingsExport.PageFooter.Right = "[Page # of Pages #]"

        settings.Settings.ShowTitlePanel = True
        settings.SettingsText.Title = "VERIFICATION VISIT PLAN"


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