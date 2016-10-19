Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models

Public Class AuditVisitMonthlyController
    Inherits Controller

    Public Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])

        If Not (Request.HttpMethod = "POST") Then           'page load
            Dim model = Nothing
            Dim repo = New Iaudit_visit()
            model = repo.AuditReset(Session("rep_id"))
        End If

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Master/AuditVisitMonthly/AuditVisitMonthly.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewAuditVisitMonthly(ByVal act As String) As ActionResult
        Dim model = Nothing
        Try
            Dim month As Integer
            Dim repo = New Iaudit_visit()
            If act <> "" Then
                Dim params As String() = act.Split(New Char() {";"})
                Select Case params(0)
                    Case "retrieve"
                        Select Case Trim(params(1))
                            Case "January" : month = 1
                            Case "February" : month = 2
                            Case "March" : month = 3
                            Case "April" : month = 4
                            Case "May" : month = 5
                            Case "June" : month = 6
                            Case "July" : month = 7
                            Case "August" : month = 8
                            Case "September" : month = 9
                            Case "October" : month = 10
                            Case "November" : month = 11
                            Case "December" : month = 12
                        End Select
                        Session("month_audit") = month
                        Session("year_audit") = params(2)
                        model = repo.AuditRetrieve(Session("month_audit"), Session("year_audit"), Session("rep_id"))
                    Case "reset"
                        model = repo.AuditReset(Session("rep_id"))
                End Select
            End If

            model = repo.GetAuditVisitMontlyByParam(Session("month_audit"), Session("year_audit"), Session("rep_id"))

            'If GlobalClass.temp_retrieve = 1 Then
            '    model = repo.GetAuditVisitMontlyByParam(GlobalClass.temp_month, GlobalClass.temp_year, Session("rep_id"))
            'Else
            '    model = repo.AuditReset(Session("rep_id"))
            'End If

        Catch ex As Exception
            Throw
        End Try
        Return PartialView("~/Views/Master/AuditVisitMonthly/ViewAuditVisitMonthly.vbhtml", model)
    End Function

    Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
        Dim model
        Try
            Dim repo = New Iaudit_visit()
            model = repo.GetAuditVisitMontly(Session("rep_id"))
        Catch ex As Exception
            Throw ex
        End Try

        Select Case OutputFormat.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(AuditVisitMonthlyGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(AuditVisitMonthlyGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(AuditVisitMonthlyGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(AuditVisitMonthlyGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(AuditVisitMonthlyGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("ViewAuditVisitMonthly")
        End Select
    End Function

End Class

#Region "EXPORT"
Public NotInheritable Class AuditVisitMonthlyGridViewHelper
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
        settings.Name = "AUDIT_VISIT_MONTHLY"
        settings.CallbackRouteValues = New With {Key .Controller = "AuditVisitMonthly", Key .Action = "audit"}
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "audit_visit_monthly_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")

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
        settings.SettingsText.Title = "AUDIT VISIT MONTHLY"


        settings.KeyFieldName = "ID"
        settings.Columns.Add("nik")
        settings.Columns.Add("nama_rep")
        settings.Columns.Add("rep_position")
        settings.Columns.Add("rep_sbo")
        settings.Columns.Add("rep_am")
        settings.Columns.Add("jml_total_visit")
        settings.Columns.Add("finished_visit")
        settings.Columns.Add("jml_day_less_then")
        settings.Columns.Add("jml_plan_blm_verifikasi")
        settings.Columns.Add("jml_plan_sdh_verifikasi")
        settings.Columns.Add("jml_visit_blm_realisasi")
        settings.Columns.Add("jml_realisasi_blm_verifikasi")
        settings.Columns.Add("jml_dr_used_session")
        settings.Columns.Add("jml_dr_planned_on_visit")
        settings.Columns.Add("jml_dr_on_master")

        settings.Columns(0).Caption = "NIK"
        settings.Columns(1).Caption = "TI NAME"
        settings.Columns(2).Caption = "POS"
        settings.Columns(3).Caption = "SBO"
        settings.Columns(4).Caption = "AM"
        settings.Columns(5).Caption = "TV"
        settings.Columns(6).Caption = "FV"
        settings.Columns(7).Caption = "D < R"
        settings.Columns(8).Caption = "VPNP"
        settings.Columns(9).Caption = "VPV"
        settings.Columns(10).Caption = "VNR"
        settings.Columns(11).Caption = "VRNV"
        settings.Columns(12).Caption = "DRUS"
        settings.Columns(13).Caption = "DROV"
        settings.Columns(14).Caption = "DROM"

        Return settings
    End Function
End Class

#End Region