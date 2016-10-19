Imports System.Web.Mvc
Imports TANABE_MVC.TANABE_MVC.Models

Imports System.Drawing.Printing
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories

Public Class VisitRealizationController
    Inherits Controller

    ' GET: /VisitRealization
    Dim repo As New r_realization
    Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])
        Dim rep_id As String = TryCast(Session("rep_id"), [String])


        'page load
        If Not (Request.HttpMethod = "POST") Then
            Dim currentDate As DateTime = DateTime.Now
            Session("sess_month") = currentDate.Month
            Session("sess_year") = currentDate.Year
        End If

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else
            'Dim model As New VisitPlan
            GlobalClass.temp_rep_position = TryCast(Session("rep_position"), [String])
            repo.getFullVisitDate(rep_id)
            GlobalClass.realization_visit_date_plan = ""
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Visit/Realization/Realization.vbhtml")
        End If

    End Function

    <ValidateInput(False)> _
    Public Function DataViewPartial() As ActionResult
        Dim model
        Try
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            Dim vpreal As New VisitRealization
            model = repo.GetVisitReal(rep_id, Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Visit/Realization/VisitRealizationDataViewPartial.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DataViewPartialCustomCallback(ByVal prm As String) As ActionResult
        Dim rep_position As String = TryCast(Session("rep_position"), [String])
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Dim params As String() = prm.Split(New Char() {";"})
        Dim act As String = params(0)

        If act = "retrieve" Then
            Dim month As String = params(1)
            Dim year As String = params(2)
            If month <> "null" Then
                If year <> "null" Then
                    Session("sess_month") = month
                    Session("sess_year") = year
                End If
            End If
        ElseIf act = "export" Then
            Return RedirectToAction("exportto", "visitrealization", New With {.export_type = params(1)})
        ElseIf act = "realization" Then
            Dim visited As String = params(1)
            Dim visit_code As String = params(2)
            Dim info As String = params(3)
            Dim sp As String = params(4)
            Dim sp_value As String = IIf(params(5) = "null", "", params(5))
            Dim visit_id As String = IIf(params(6) = "null", 0, params(6))
            Dim visit_real As Integer
            If visited = True Then
                visit_real = 1
            Else
                visit_code = ""
                visit_real = 0
            End If
            repo.SaveRealizationVisit(visit_id, rep_id, rep_position, visit_real, visit_code, info, sp, sp_value)
        Else
            Dim currentDate As DateTime = DateTime.Now
            Session("sess_day") = 0
            Session("sess_month") = currentDate.Month
            Session("sess_year") = currentDate.Year
        End If

        Dim model
        Try
            model = repo.GetVisitReal(rep_id, Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Visit/Realization/VisitRealizationDataViewPartial.vbhtml", model)
    End Function

    Public Function LoadRealProduct() As ActionResult
        Dim model
        Try
            Dim vpproduct As New ProductListClass
            model = vpproduct.GetDataProductList()
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Visit/Realization/RealizationProductPartial.vbhtml", model)

    End Function

    <ValidateInput(False)> _
    Public Function LoadDoctorPlaned(ByVal act As String) As ActionResult
        Dim model = Nothing
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Try
            Dim vp As New DoctorPlanedClass
            model = vp.GetDataDoctorPlaned(rep_id, Session("sess_date_plan"))
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Visit/Realization/CancellationVisitListPartial.vbhtml", model)

    End Function

    Public Function LoadRealization() As ActionResult
        Dim model
        Try
            Dim vpproduct As New ProductListClass
            model = vpproduct.GetDataProductList()
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Visit/Realization/PopupRealization.vbhtml", model)

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
        Return PartialView("~/Views/Visit/Realization/AdditionalProductPartial.vbhtml", model)

    End Function

    <ValidateInput(False)> _
    Public Function LoadAdditional(ByVal prm As String) As ActionResult
        ViewData("AdditionalFlag") = Nothing
        Dim rep_position As String = TryCast(Session("rep_position"), [String])
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Dim model
        Dim vp As New DoctorListClass
        Try
            Using tdb = New DoctorListEntities()
                model = vp.GetDataDoctorList(tdb, rep_id, rep_position)
            End Using
        Catch generatedExceptionName As Exception
            Throw
        End Try

        If prm <> "" Then
            Dim params As String() = prm.Split(New Char() {";"})
            Dim act As String = params(0)
            If act = "additional" Then
                Dim dr_code As String = params(1)
                Dim visit_date_plan As String = params(2)
                Dim product_code As String = params(3)
                Dim info As String = params(4)
                Dim sp As String = IIf(params(5) = "null", "", params(5))
                Dim sp_value As String = IIf(params(6) = "null", 0, params(6))
                TempData("rep_id") = rep_id
                TempData("rep_position") = rep_position

                'jika sudah buat plan leave/absen pada tanggal tersebut, additional visit tidak bisa dilakukan
                If Not (repo.isValidDay(rep_id, CDate(visit_date_plan).ToString("yyyy-MM-dd"))) Then
                    ViewData("AdditionalFlag") = "You've made an absent plan on that day"
                    Return PartialView("~/Views/Visit/Realization/PopupAdditionalVisit.vbhtml", model)
                End If
                'jika belum ada plan sama sekali pada tanggal dimana akan dibuat additional visit, maka AV tidak bisa dilakukan
                If Not (repo.isAlreadyPlannedVisitInCurrDay(rep_id, CDate(visit_date_plan).ToString("yyyy-MM-dd"), rep_position)) Then
                    ViewData("AdditionalFlag") = "You haven't made some plans on that day"
                    Return PartialView("~/Views/Visit/Realization/PopupAdditionalVisit.vbhtml", model)
                End If
                'jika ada doctor yg sama pada tanggal tersebut, maka AV tidak bisa dilakukan
                If (repo.isAlreadyPlannedDoctorInCurrDay(rep_id, CDate(visit_date_plan).ToString("yyyy-MM-dd"), Trim(dr_code))) Then
                    ViewData("AdditionalFlag") = "There is already planned doctor with name " + Session("DoctorPlannedDay") + " on that day"
                    Return PartialView("~/Views/Visit/Realization/PopupAdditionalVisit.vbhtml", model)
                End If
                'jika max visit lebih besar atau sama dengan 3, maka AV tidak bisa dilakukan berlaku hanya 3 AV
                If repo.CheckMaxVisit(rep_id, CDate(visit_date_plan).ToString("yyyy-MM-dd")) >= 3 Then
                    ViewData("AdditionalFlag") = "Additional visit actual is only given 3 times per day"
                    Return PartialView("~/Views/Visit/Realization/PopupAdditionalVisit.vbhtml", model)
                End If

                If (repo.isMaxLimitedDoctorinCurrDay(rep_id, CDate(visit_date_plan).ToString("yyyy-MM-dd"), rep_position)) Then
                    ViewData("AdditionalFlag") = "You've exceeded the maximum limit doctor visits on that day"
                    Return PartialView("~/Views/Visit/Realization/PopupAdditionalVisit.vbhtml", model)
                End If
                ViewData("AdditionalFlag") = "success"
                repo.SaveAdditionalVisit(dr_code, visit_date_plan, rep_id, rep_position, product_code, info, sp, sp_value)
                Return PartialView("~/Views/Visit/Realization/PopupAdditionalVisit.vbhtml", model)
            End If
        Else
            Return PartialView("~/Views/Visit/Realization/PopupAdditionalVisit.vbhtml", model)
        End If

    End Function

    <ValidateInput(False)> _
    Public Function LoadDoctorList() As ActionResult
        Dim model
        Dim vp As New DoctorListClass
        Try
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            Dim rep_position As String = TryCast(Session("rep_position"), [String])

            Using tdb = New DoctorListEntities()
                model = vp.GetDataDoctorList(tdb, rep_id, rep_position)
            End Using

        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Visit/Realization/AdditionalDoctorPartial.vbhtml", model)

    End Function

    <ValidateInput(False)> _
    Public Function LoadCancellation(ByVal prm As String) As ActionResult
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Dim model
        If prm <> "" Then
            Dim params As String() = prm.Split(New Char() {";"})
            If params(0) = "full" Then
                ViewData("CancellationFlag") = "full"
                ViewData("TCFlag") = params(1)
            ElseIf params(0) = "half" Then
                ViewData("CancellationFlag") = "half"
                ViewData("TCFlag") = params(1)
            ElseIf params(0) = "submit" Then
                Dim condiDev As String = params(2)
                Dim currentDate As DateTime = DateTime.Now
                If (repo.SaveCancellationVisit(rep_id, condiDev, Session("rep_position"), params(4), params(1), params(3))) Then
                    ViewData("CancellationFlag") = "success_submit"
                Else
                    ViewData("CancellationFlag") = "error_submit"
                End If

            Else
                Dim date_plan As String = CDate(params(0)).ToString("yyyy-MM-dd")
                If params(1) = "" Then
                    ViewData("CancellationFlag") = "null_condition"
                    ViewData("TCFlag") = params(1)
                End If
                Dim condiDev As String = params(2)
                If (repo.isAnyPlanOnChoosenDay(rep_id, date_plan)) Then
                    ViewData("CancellationFlag") = "available_plan"
                    ViewData("TCFlag") = params(1)
                    ViewData("DTFlag") = params(0)
                    If condiDev <> "full" Then
                        Session("sess_date_plan") = date_plan
                        Dim vp As New DoctorPlanedClass
                        model = vp.GetDataDoctorPlaned(rep_id, date_plan)
                        Return PartialView("~/Views/Visit/Realization/PopupCancellation.vbhtml", model)
                    Else
                        'tr_planned_visit.Visible = False
                        ViewData("CancellationFlag") = "hide_planned"
                    End If

                Else
                    ViewData("CancellationFlag") = "null_plan"
                    ViewData("TCFlag") = params(1)
                    ViewData("DTFlag") = params(0)
                End If
            End If
        End If
        
        Return PartialView("~/Views/Visit/Realization/PopupCancellation.vbhtml")
    End Function


    Public Function ExportTo(ByVal export_type As String) As ActionResult


        Dim model
        Try
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            Dim vpreal As New VisitRealization
            If GlobalClass.temp_retrieve = 1 Then
                Dim year As Integer = GlobalClass.temp_year
                Dim month As Integer = GlobalClass.temp_month
                model = vpreal.GetDataVisitRealizationRetrieve(rep_id, month, year)
            Else
                model = vpreal.GetDataVisitRealization(rep_id)

            End If

        Catch generatedExceptionName As Exception
            Throw
        End Try

        Select Case export_type.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(VisitRealizationGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(VisitRealizationGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(VisitRealizationGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(VisitRealizationGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(VisitRealizationGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("DataViewPartial")
        End Select
    End Function

End Class
Public NotInheritable Class VisitRealizationGridViewHelper
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
        settings.Name = "VISIT_REALIZATION"
        settings.CallbackRouteValues = New With {Key .Controller = "visitrealization", Key .Action = "Index"}

        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = PaperKind.A4
        settings.SettingsExport.FileName = "visit_realization_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


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
        settings.SettingsText.Title = "VISIT REALIZATION"


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