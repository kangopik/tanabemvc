Imports DevExpress.Web.Mvc
Imports System.Web.Mvc
Imports TANABE_MVC.TANABE_MVC.Models
Imports DevExpress.Web
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports System.Collections.Generic
Public Class VisitHistoryController
    Inherits Controller
    ' GET: /Visit
    Dim db As New VisitHistoryEntities()
    Dim vp As New VisitHistoryClass

    Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])

        If username = "" Then
            Return RedirectToAction("", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Visit/History/History.vbhtml")
        End If

    End Function

    <ValidateInput(False)> _
    Public Function DataViewPartial(ByVal act As String) As ActionResult
        Dim month As Integer
        If act <> "" Then
            Dim params As String() = act.Split(New Char() {"-"})

            Select Case params(0)
                Case "reset"
                    GlobalClass.temp_retrieve = 0
                    GlobalClass.temp_year = 0
                    GlobalClass.temp_month = 0

                Case "retrieve"
                    GlobalClass.temp_retrieve = 1
                    Select Case Trim(params(1))
                        Case "January" : Month = 1
                        Case "February" : Month = 2
                        Case "March" : Month = 3
                        Case "April" : Month = 4
                        Case "May" : Month = 5
                        Case "June" : Month = 6
                        Case "July" : Month = 7
                        Case "August" : Month = 8
                        Case "September" : Month = 9
                        Case "October" : Month = 10
                        Case "November" : Month = 11
                        Case "December" : Month = 12
                    End Select

                    GlobalClass.temp_month = month
                    GlobalClass.temp_year = params(2)

                Case "export"
                    Return RedirectToAction("exportto", "visithistory", New With {.export_type = params(1)})



            End Select
        End If

        Dim model
        Try
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            Using tdb = New VisitHistoryEntities()
                If GlobalClass.temp_retrieve = 1 Then
                    model = vp.GetDataVisitHistoryRetrieve(tdb, rep_id, GlobalClass.temp_month, GlobalClass.temp_year)
                Else
                    model = vp.GetDataVisitHistory(tdb, rep_id)

                End If

            End Using
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Visit/History/VisitHistoryDataViewPartial.vbhtml", model)
    End Function

    Public Function MasterDetailPartial(ByVal visit_id As String, ByVal dr_code As String) As ActionResult
        ViewData("visit_id") = visit_id
        ViewData("dr_code") = dr_code
        Dim model
        Try
            Dim vp As New VisitHistoryClass
            model = vp.GetDataDetail(visit_id)
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Visit/History/MasterDetailDetailPartial.vbhtml", model)

    End Function
    Public Function ExportTo(ByVal export_type As String) As ActionResult
        

        Dim model
        Try
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            Using tdb = New VisitHistoryEntities()

                If GlobalClass.temp_retrieve = 1 Then
                    Dim year As Integer = GlobalClass.temp_year
                    Dim month As Integer = GlobalClass.temp_month

                    model = vp.GetDataVisitHistoryRetrieve(tdb, rep_id, month, year)

                Else
                    model = vp.GetDataVisitHistory(tdb, rep_id)

                End If

            End Using
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Select Case export_type.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(VisitHistoryGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(VisitHistoryGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(VisitHistoryGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(VisitHistoryGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(VisitHistoryGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("DataViewPartial")
        End Select
    End Function


End Class

Public NotInheritable Class VisitHistoryGridViewHelper
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
        settings.Name = "VISIT_HISTORY"
        settings.CallbackRouteValues = New With {Key .Controller = "visithistory", Key .Action = "index"}
        'settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "visit_history_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


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
        settings.SettingsText.Title = "VISIT HISTORY"


        settings.KeyFieldName = "rep_id"
        'settings.Settings.ShowFilterRow = True
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

