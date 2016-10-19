Imports System.Web.Mvc
Imports TANABE_MVC.TANABE_MVC.Models

Imports System.Drawing.Printing
Imports DevExpress.Web.Mvc
Imports DevExpress.Web

Public Class VisitActualController
    Inherits Controller

    Dim db As New VisitActualEntities()
    Dim vp As New VisitActualClass

    ' GET: /VisitRealization
    Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else

            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            ViewData("rep_position") = TryCast(Session("rep_position"), [String])
            Return View("~/Views/Visit/Actual/Actual.vbhtml")
        End If

    End Function

    <ValidateInput(False)> _
    Public Function DataViewPartial(ByVal act As String) As ActionResult

        Dim arr_date As New VisitActualClass
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        arr_date.getFullVisitDate(rep_id)

        Dim day As Integer = 0
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
                    day = params(1)

                    Select Case Trim(params(2))
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

                    GlobalClass.temp_month = month
                    GlobalClass.temp_year = params(3)

                Case "retrieve_selected"
                    GlobalClass.temp_retrieve = 1
                    day = params(1)
                    GlobalClass.temp_month = params(2)
                    GlobalClass.temp_year = params(3)

                Case "export"
                    Return RedirectToAction("exportto", "visitactual", New With {.export_type = params(1)})

                Case "save_edit"
                    Dim model_exec As New VisitActualClass
                    Dim visit_id As String = GlobalClass.visit_actual_visit_id
                    Dim dr_code As String = GlobalClass.visit_actual_dr_code

                    Dim visit_plan As String
                    Dim visit_realization As String = params(1)
                    If visit_realization = True Then
                        visit_plan = 0
                        visit_realization = 1
                    Else
                        visit_plan = 1
                        visit_realization = 0
                    End If


                    Dim visit_info As String = params(2)
                    Dim visit_sp As String = params(3)
                    Dim visit_sp_value As String = params(4)

                    model_exec.ExecUpdate(visit_id, dr_code, visit_plan, visit_realization, visit_info, visit_sp, visit_sp_value)

                Case "request_verification"
                    Dim model_exec As New VisitActualClass
                    Dim date_selected As String = params(2) & "-" & params(3) & "-" & params(4)
                    model_exec.ExecReq(rep_id, params(1), date_selected)

                    TempData("msg") = GlobalClass.visit_actual_msg
                    GlobalClass.visit_actual_msg = ""
            End Select
        End If


        Dim model
        Try


            Using db = New VisitActualEntities()
                If GlobalClass.temp_retrieve = 1 Then
                    model = vp.GetDataVisitActualRetrieve(db, rep_id, day, GlobalClass.temp_month, GlobalClass.temp_year)
                Else
                    model = vp.GetDataVisitActual(db, rep_id)
                End If
            End Using
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Visit/Actual/VisitActualDataViewPartial.vbhtml", model)
    End Function
    Public Function LoadRequest() As ActionResult
        Return PartialView("~/Views/Visit/Actual/PopupReqVerification.vbhtml")
    End Function
    Public Function LoadEdit(ByVal act As String) As ActionResult
        If act <> "" Then
            Dim params As String() = act.Split(New Char() {"-"})
            GlobalClass.visit_actual_dr_code = params(0)
            GlobalClass.visit_actual_visit_id = params(1)

            GlobalClass.visit_actual_visited = params(2)
            GlobalClass.visit_actual_info = params(3)
            GlobalClass.visit_actual_sp = params(4)
            GlobalClass.visit_actual_sp_value = params(5)

        End If
        Dim model
        Try
            Dim vpproduct As New ProductListClass
            model = vpproduct.GetDataProductList()
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Visit/Actual/PopupEdit.vbhtml", model)
    End Function
   
    Public Function MasterDetailPartial(ByVal visit_id As String, ByVal dr_code As String) As ActionResult
        ViewData("visit_id") = visit_id
        ViewData("dr_code") = dr_code
        Dim model
        Try
            Dim vp As New VisitActualClass
            model = vp.GetDataDetail(visit_id)
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Visit/Actual/MasterDetailDetailPartial.vbhtml", model)

    End Function
    Public Function MasterDetailPartialEdit(ByVal visit_id As String, ByVal dr_code As String) As ActionResult
        'ViewData("visit_id") = visit_id
        'ViewData("dr_code") = dr_code
        'Dim model
        'Try
        '    Dim vp As New VisitActualClass
        '    model = vp.GetDataDetail(visit_id)
        'Catch generatedExceptionName As Exception
        '    Throw
        'End Try

        Return PartialView("~/Views/Visit/Actual/TabProduct.vbhtml")

    End Function
    <ValidateInput(False)> _
    Public Function LoadProduct() As ActionResult

        Dim model
        Try
            Dim vpproduct As New ProductListClass
            model = vpproduct.GetDataProductList()
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Visit/Actual/TabRealization.vbhtml", model)

    End Function
  
    Public Function ExportTo(ByVal export_type As String) As ActionResult
       

        Dim model
        Try
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            Using tdb = New VisitActualEntities()

                If GlobalClass.temp_retrieve = 1 Then
                    Dim day As Integer = 0
                    Dim year As Integer = GlobalClass.temp_year
                    Dim month As Integer = GlobalClass.temp_month

                    model = vp.GetDataVisitActualRetrieve(tdb, rep_id, day, month, year)

                Else
                    model = vp.GetDataVisitActual(tdb, rep_id)

                End If

            End Using
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Select Case export_type.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(VisitActualGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(VisitActualGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(VisitActualGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(VisitActualGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(VisitActualGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("DataViewPartial")
        End Select
    End Function
End Class
Public NotInheritable Class VisitActualGridViewHelper
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
        settings.Name = "VISIT_ACTUAL"
        settings.CallbackRouteValues = New With {Key .Controller = "visitactual", Key .Action = "Index"}
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = PaperKind.A4
        settings.SettingsExport.FileName = "visit_actual_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


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
        settings.SettingsText.Title = "VISIT ACTUAL"


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