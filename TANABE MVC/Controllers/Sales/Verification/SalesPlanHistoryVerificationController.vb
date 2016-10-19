Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models

Public Class SalesPlanHistoryVerificationController
    Inherits Controller

    Dim repo As New ISalesPlanVerificationHistory()

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
            Return View("~/Views/Sales/VerificationPlanHistory/SalesPlanHistoryVerification.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewSalesPlanHistory() As ActionResult
        Dim model
        Try
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.ds_sales(rep_id, Session("sess_month"), Session("sess_year"))
        Catch ex As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationPlanHistory/ViewSalesPlanHistoryVerification.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function DeleteVerification(ByVal coll As FormCollection) As ActionResult
        Dim sales_id As String = TryCast(Session("sales_id"), [String])
        Dim model
        repo.DeleteSalesPlan(sales_id)
        Try
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.ds_sales(rep_id, Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationPlanHistory/ViewSalesPlanHistoryVerification.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function ViewSalesPlanHistoryCustomCallback(ByVal prm As String) As ActionResult
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
                        model = repo.ds_sales(rep_id, Session("sess_month"), Session("sess_year"))
                        If model.Count = 0 Then
                            ViewData("VerifyFlag") = "null_record"
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
            model = repo.ds_sales(rep_id, Session("sess_month"), Session("sess_year"))
        ElseIf act = "verify_by_one" Then
            Dim sales_id As String = params(4)
            model = repo.UnverificationSalesPlan(sales_id, Session("sess_month"))
            If (model) Then
                ViewData("VerifyFlag") = "success_verify"
            Else
                ViewData("VerifyFlag") = "error_verify"
            End If
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.ds_sales(rep_id, Session("sess_month"), Session("sess_year"))
        ElseIf act = "verify" Then
            Dim sales_id As String() = params(4).Split(New Char() {","})
            For Each item As String In sales_id
                model = repo.UnverificationSalesPlan(item, Session("sess_month"))
            Next

            If (model) Then
                ViewData("VerifyFlag") = "success_verify"
            Else
                ViewData("VerifyFlag") = "error_verify"
            End If
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.ds_sales(rep_id, Session("sess_month"), Session("sess_year"))
        End If
        Return PartialView("~/Views/Sales/VerificationPlanHistory/ViewSalesPlanHistoryVerification.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DetailSalesPlanHistory(ByVal sales_id As String) As ActionResult
        ViewData("sales_id") = sales_id
        Dim model
        Try
            model = repo.dsEditProductSales(sales_id)
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Sales/VerificationPlanHistory/DetailSalesPlanHistory.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function ViewEditForm(ByVal sales_id As String) As ActionResult
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Session("sales_id") = sales_id

        Dim model
        Try
            model = repo.dsEditProductSales(Session("sales_id"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationPlanHistory/EditFormPlanHistory.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DetailEditForm() As ActionResult
        Dim model
        Try
            model = repo.dsEditProductSales(Session("sales_id"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationPlanHistory/EditFormPlanHistory.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function AddProduct(ByVal coll As FormCollection) As ActionResult
        Dim tx_target_qty As Integer = coll("tx_target_qty")
        Dim prd_code As String = coll("prd_code")
        Dim tx_note As String = coll("tx_note")
        Dim model
        repo.InsertSalesProduct(Session("sales_id"), prd_code, tx_target_qty, tx_note)
        Try
            model = repo.dsEditProductSales(Session("sales_id"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationPlanHistory/EditFormPlanHistory.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function DeleteProduct(ByVal coll As FormCollection) As ActionResult
        Dim sp_id As String = coll("sp_id")
        Dim model
        repo.DeleteSalesProduct(sp_id, Session("sales_id"))
        Try
            model = repo.dsEditProductSales(Session("sales_id"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationPlanHistory/EditFormPlanHistory.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Shared Function dsRep()
        Dim rep = New ISalesPlanVerificationHistory()
        Dim mdl = rep.dsRep()
        Return mdl
    End Function

    Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
        Dim model = Nothing
        Try
            Dim repo = New ISalesPlanVerificationHistory()
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.ds_sales(rep_id, Session("sess_month"), Session("sess_year"))
        Catch ex As Exception
            Throw ex
        End Try

        Select Case OutputFormat.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("ViewSalesPlan")
        End Select
    End Function

#Region "Export"
    Private exportGridViewSettings_Renamed As GridViewSettings

    Public ReadOnly Property ExportGridViewSettings() As GridViewSettings
        Get
            If exportGridViewSettings_Renamed Is Nothing Then
                exportGridViewSettings_Renamed = CreateExportGridViewSettings()
            End If
            Return exportGridViewSettings_Renamed
        End Get
    End Property

    Private Function CreateExportGridViewSettings() As GridViewSettings
        Dim settings As New GridViewSettings()
        Dim _user_name As String = GlobalClass.temp_user_name

        Dim tempPageMSG As New System.Text.StringBuilder
        tempPageMSG.Append("SALES PLAN VERIFICATION HISTORY" & vbCrLf)
        tempPageMSG.Append("Nama      : " & Session("rep_name") & vbCrLf)
        tempPageMSG.Append("Regional : " & Session("rep_reg") & vbCrLf)
        tempPageMSG.Append("BO          : " & Session("rep_bo") & vbCrLf)
        tempPageMSG.Append("Month     :____________________________" & vbCrLf)

        settings.Name = "gridSalesPlanHistoryVerification"
        settings.CallbackRouteValues = New With {Key .Controller = "SalesPlanHistoryVerification", Key .Action = "ViewSalesPlanHistoryVerification"}
        settings.SettingsBehavior.AllowFixedGroups = True
        settings.SettingsBehavior.AutoExpandAllGroups = True
        settings.SettingsDetail.ShowDetailRow = False
        settings.SettingsDetail.AllowOnlyOneMasterRowExpanded = True
        settings.Settings.ShowGroupedColumns = True
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = tempPageMSG.ToString()
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "sales_plan_history_verification" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")

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

        settings.KeyFieldName = "sales_id"
        settings.Columns.Add("sales_id")
        settings.Columns.Add("dr_code")
        settings.Columns.Add("sales_plan")
        settings.Columns.Add("sales_plan_verification_status")
        settings.Columns.Add("dr_name")
        settings.Columns.Add("dr_spec")
        settings.Columns.Add("dr_sub_spec")
        settings.Columns.Add("dr_quadrant")
        settings.Columns.Add("dr_monitoring")
        settings.Columns.Add("dr_dk_lk")
        settings.Columns.Add("dr_area_mis")
        settings.Columns.Add("dr_category")
        settings.Columns.Add("dr_chanel")
        settings.Columns.Add(Sub(c)
                                 c.FieldName = "sales_date_plan"
                                 c.Caption = "DATE PLAN"
                                 c.GroupIndex = 0
                                 c.Visible = False
                             End Sub)

        settings.Columns(0).Caption = "SALES ID"
        settings.Columns(1).Caption = "DR. CODE"
        settings.Columns(2).Caption = "Sales Plan"
        settings.Columns(3).Caption = "Ver. Plan"
        settings.Columns(4).Caption = "DR. NAME"
        settings.Columns(5).Caption = "DR. SPEC."
        settings.Columns(6).Caption = "SUB SPEC."
        settings.Columns(7).Caption = "QUADRANT"
        settings.Columns(8).Caption = "MONITORING"
        settings.Columns(9).Caption = "DK/LK"
        settings.Columns(10).Caption = "AREA MIS"
        settings.Columns(11).Caption = "CATEGORY"
        settings.Columns(12).Caption = "CHANNEL"

        Return settings
    End Function

#End Region

End Class