Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports DevExpress.Utils
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Customization
Imports System.Collections.Generic
Imports DevExpress.Export
Imports DevExpress.XtraPrinting
Imports TANABE_MVC.PivotGridExportOptions
Imports DevExpress.Web.ASPxPivotGrid
Imports System.Web
Imports System.Collections


Namespace Controllers.Report
    Public Class SalesPivotRepController
        Inherits Controller
        Dim model
        Dim repo As New r_SalesPivotRep()
        Function Index() As ActionResult
            Dim username As String = UCase(TryCast(Session("username"), [String]))
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            GlobalClass.temp_user_name = TryCast(Session("username"), [String])

            'if page load
            If Not (Request.HttpMethod = "POST") Then
                Session("Layout") = Nothing
                Session("sess_month_start") = "All"
                Session("sess_month_end") = "All"
                Session("sess_year_period") = "All"
            End If

            If username = "" Then
                Return RedirectToAction("index", "login")
            Else
                Return View("~/Views/Report/Rep/SalesPivotRep.vbhtml")
            End If
        End Function

        <ValidateInput(False)> _
        Public Function SalesPivotRepPartialView(ByVal act As String) As ActionResult
            Try
                Dim rep_id As String = TryCast(Session("rep_id"), [String])
                model = repo.GetSalesPivotRep(rep_id, Session("sess_month_start"), Session("sess_month_end"), Session("sess_year_period"))
            Catch generatedExceptionName As Exception
                Throw
            End Try
            Return PartialView("~/Views/Report/Rep/SalesPivotRepPartialView.vbhtml", model)
        End Function

        <ValidateInput(False)> _
        Public Function SalesPivotRepCustomCallBack(ByVal prm As String) As ActionResult
            Dim params As String() = prm.Split(New Char() {";"})
            Dim act As String = params(0)
            If act = "retrieve" Then
                Dim dtStart As String = params(1)
                Dim dtEnd As String = params(2)
                Dim dtYear As String = params(3)
                If dtStart <> "null" Then
                    If dtEnd <> "null" Then
                        Session("sess_month_start") = dtStart
                        Session("sess_month_end") = dtEnd
                        Session("sess_year_period") = dtYear
                    End If
                End If
            ElseIf act = "export" Then
                Return RedirectToAction("ExportTo", "SalesPivotRep", New With {.export_type = params(1)})
            Else
                Dim currentDate As DateTime = DateTime.Now
                Session("sess_month_start") = "All"
                Session("sess_month_end") = "All"
                Session("sess_year_period") = "All"
            End If
            Return PartialView("~/Views/Report/Rep/SalesPivotRepPartialView.vbhtml", GetSalesPivotRepData())
        End Function

        Public Function GetSalesPivotRepData() As IEnumerable
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            Dim mStart As String = TryCast(Session("sess_month_start"), [String])
            Dim mEnd As String = TryCast(Session("sess_month_end"), [String])
            Dim Year As String = TryCast(Session("sess_year_period"), [String])
            Dim repo = New r_SalesPivotRep()
            Dim model = repo.GetSalesPivotRep(rep_id, mStart, mEnd, Year)
            Return model
        End Function

        Public Function ExportTo(ByVal export_type As String) As ActionResult
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            Try
                model = repo.GetSalesPivotRep(rep_id, Session("sess_month_start"), Session("sess_month_end"), Session("sess_year_period"))
            Catch generatedExceptionName As Exception
                Throw
            End Try

            Select Case export_type.ToUpper()
                Case "CSV"
                    Return PivotGridExtension.ExportToCsv(PivotGridLayout.SalesPivotRepGridSettings, model)
                Case "PDF"
                    Return PivotGridExtension.ExportToPdf(PivotGridLayout.SalesPivotRepGridSettings, model)
                Case "RTF"
                    Return PivotGridExtension.ExportToRtf(PivotGridLayout.SalesPivotRepGridSettings, model)
                Case "XLS"
                    Return PivotGridExtension.ExportToXls(PivotGridLayout.SalesPivotRepGridSettings, model)
                Case "XLSX"
                    Return PivotGridExtension.ExportToXls(PivotGridLayout.SalesPivotRepGridSettings, model)
                Case "ROWDATA"
                    Return GridViewExtension.ExportToXlsx(SalesPivotGridDataOutput.ExportRowDataSettings, model)
                Case Else
                    Return RedirectToAction("SalesPivotRepPartialView")
            End Select
        End Function

    End Class

    Public Class SalesPivotGridDataOutput

        Shared m_exportPivotGridSettings As PivotGridSettings
        Shared m_dataAwarePivotGridSettings As GridViewSettings

        Public Shared ReadOnly Property ExportRowDataSettings() As GridViewSettings
            Get
                If m_dataAwarePivotGridSettings Is Nothing Then
                    m_dataAwarePivotGridSettings = CreateDataAwarePivotGridSettings()
                End If
                Return m_dataAwarePivotGridSettings
            End Get
        End Property

        Private Shared Function CreateDataAwarePivotGridSettings() As GridViewSettings
            Dim settings As New GridViewSettings()
            Dim _user_name As String = GlobalClass.temp_user_name
            settings.Name = "SALES_PIVOT_REP"
            settings.CallbackRouteValues = New With {Key .Controller = "SalesPivotRep", Key .Action = "SalesPivotRepPartialView"}
            settings.SettingsExport.FileName = "VPPR" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")
            settings.SettingsExport.Styles.Cell.Font.Size = 9
            settings.SettingsExport.Styles.Header.Font.Size = 9
            settings.SettingsExport.MaxColumnWidth = 100
            settings.Columns.Add("bo") : settings.Columns(0).Caption = "BO"
            settings.Columns.Add("rep_name") : settings.Columns(1).Caption = "TI NAME"
            settings.Columns.Add("position") : settings.Columns(2).Caption = "POSITION"
            settings.Columns.Add("division") : settings.Columns(3).Caption = "DIVISION"
            settings.Columns.Add("bo") : settings.Columns(4).Caption = "BO"
            settings.Columns.Add("sbo") : settings.Columns(5).Caption = "SBO"
            settings.Columns.Add("rep_am") : settings.Columns(6).Caption = "REP AM"
            settings.Columns.Add("am") : settings.Columns(7).Caption = "AM"
            settings.Columns.Add("region") : settings.Columns(8).Caption = "REGION"
            settings.Columns.Add("rep_rm") : settings.Columns(9).Caption = "REP RM"
            settings.Columns.Add("rm") : settings.Columns(10).Caption = "RM"
            settings.Columns.Add("month") : settings.Columns(11).Caption = "MONTH"
            settings.Columns.Add("date_visit") : settings.Columns(12).Caption = "DATE"
            settings.Columns.Add("dr_code") : settings.Columns(13).Caption = "DR CODE"
            settings.Columns.Add("plan") : settings.Columns(14).Caption = "PLAN"
            settings.Columns.Add("info") : settings.Columns(15).Caption = "INFO"
            settings.Columns.Add("sp") : settings.Columns(16).Caption = "SP"
            settings.Columns.Add("sp_value") : settings.Columns(17).Caption = "SP VALUE"
            settings.Columns.Add("realization") : settings.Columns(18).Caption = "REALIZATION"
            settings.Columns.Add("dr_name") : settings.Columns(19).Caption = "DR NAME"
            settings.Columns.Add("spec") : settings.Columns(20).Caption = "SPEC"
            settings.Columns.Add("sub_spec") : settings.Columns(21).Caption = "SUB SPEC"
            settings.Columns.Add("quadrant") : settings.Columns(22).Caption = "QUADRANT"
            settings.Columns.Add("monitoring") : settings.Columns(23).Caption = "MONITORING"
            settings.Columns.Add("dklk") : settings.Columns(24).Caption = "DKLK"
            settings.Columns.Add("area_mis") : settings.Columns(25).Caption = "AREA MIS"
            settings.Columns.Add("category") : settings.Columns(26).Caption = "CATEGORY"
            settings.Columns.Add("channel") : settings.Columns(27).Caption = "CHANNEL"

            For i = 0 To 42 Step 1
                settings.Columns(i).ExportWidth = 75
            Next
            Return settings
        End Function

    End Class
End Namespace


