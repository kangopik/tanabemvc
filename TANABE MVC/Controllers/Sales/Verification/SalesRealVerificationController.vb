Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models
Public Class SalesRealVerificationController
    Inherits Controller

    Dim repo As New ISalesRealVerification()

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
            Return View("~/Views/Sales/VerificationReal/SalesRealVerification.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewSalesRealVerification() As ActionResult
        Dim model
        Try
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
        Catch ex As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationReal/ViewSalesRealVerification.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function DeleteVerification(ByVal coll As FormCollection) As ActionResult
        Dim sales_id As String = TryCast(Session("sales_id"), [String])
        Dim model
        repo.DeleteSalesPlan(sales_id)
        Try
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationReal/ViewSalesRealVerification.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function UpdateVerification() As ActionResult
        Dim model
        repo.UpdateFake()
        Try
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationReal/ViewSalesRealVerification.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DetailSalesRealVerification(ByVal sp_id As String) As ActionResult
        ViewData("sp_id") = sp_id
        Dim model
        Try
            model = repo.dsEditProductSalesActual(sp_id)
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Sales/VerificationReal/DetailRealVerification.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function ViewEditForm(ByVal sp_id As String) As ActionResult
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Session("sp_id") = sp_id

        Dim model
        Try
            model = repo.dsEditProductSalesActual(Session("sp_id"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationReal/EditFormRealVerification.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DetailEditForm() As ActionResult
        Dim model
        Try
            model = repo.dsEditProductSalesActual(Session("sp_id"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationReal/EditFormRealVerification.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function AddProduct(ByVal coll As FormCollection) As ActionResult
        Dim bd As String = Trim(coll("spa_date")).Replace(",", "-")
        bd = bd.Replace("new Date(", "")
        bd = bd.Replace(")", "")
        Dim spa_date As Date = DateTime.Parse(bd)
        Dim spa_quantity As Integer = coll("spa_quantity")
        Dim spa_note As String = coll("spa_note")
        Dim model
        repo.InsertSalesProductActual(Session("sp_id"), spa_date, spa_quantity, spa_note)
        Try
            model = repo.dsEditProductSalesActual(Session("sp_id"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationReal/EditFormRealVerification.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function DeleteProduct(ByVal coll As FormCollection) As ActionResult
        Dim spa_id As String = coll("spa_id")
        Dim model
        repo.DeleteSalesProductActual(spa_id)
        Try
            model = repo.dsEditProductSalesActual(Session("sp_id"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationReal/EditFormRealVerification.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function UpdateProduct(ByVal coll As FormCollection) As ActionResult
        Dim bd As String = Trim(coll("spa_date")).Replace(",", "-")
        bd = bd.Replace("new Date(", "")
        bd = bd.Replace(")", "")
        Dim spa_date As Date = DateTime.Parse(bd)
        Dim spa_id As String = coll("spa_id")
        Dim spa_quantity As Integer = coll("spa_quantity")
        Dim spa_note As String = coll("spa_note")
        Dim model
        repo.UpdateSalesProductActual(spa_id, Session("sp_id"), spa_date, spa_quantity, spa_note)
        Try
            model = repo.dsEditProductSalesActual(Session("sp_id"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/VerificationReal/EditFormRealVerification.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function ViewSalesRealVerificationCustomCallback(ByVal prm As String) As ActionResult
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
                        model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
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
            model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
        ElseIf act = "verify_by_one" Then
            Dim sales_id As String = params(4)
            model = repo.VerificationSalesReal(sales_id, Session("rep_id"))
            If (model) Then
                ViewData("VerifyFlag") = "success_verify"
            Else
                ViewData("VerifyFlag") = "error_verify"
            End If
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
        ElseIf act = "verify" Then
            Dim sales_id As String() = params(4).Split(New Char() {","})
            For Each item As String In sales_id
                model = repo.VerificationSalesReal(item, Session("rep_id"))
            Next

            If (model) Then
                ViewData("VerifyFlag") = "success_verify"
            Else
                ViewData("VerifyFlag") = "error_verify"
            End If
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
        End If
        Return PartialView("~/Views/Sales/VerificationReal/ViewSalesRealVerification.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Shared Function dsRep()
        Dim rep = New ISalesRealVerification()
        Dim mdl = rep.dsRep()
        Return mdl
    End Function

    Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
        Dim model = Nothing
        Try
            Dim repo = New ISalesRealVerification()
            Dim rep_id As String = TryCast(Session("rep_id_selection"), [String])
            model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
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
        tempPageMSG.Append("PT. TANABE INDONESIA" & vbCrLf)
        tempPageMSG.Append("SALES REALIZATION" & vbCrLf)
        tempPageMSG.Append("Nama      : " & Session("rep_name") & vbCrLf)
        tempPageMSG.Append("Regional : " & Session("rep_reg") & vbCrLf)
        tempPageMSG.Append("BO          : " & Session("rep_bo") & vbCrLf)
        tempPageMSG.Append("Month     :____________________________" & vbCrLf)

        settings.Name = "gridSalesRealVerification"
        settings.CallbackRouteValues = New With {Key .Controller = "SalesRealVerification", Key .Action = "ViewRealVerification"}
        settings.SettingsBehavior.AllowFixedGroups = True
        settings.SettingsBehavior.AutoExpandAllGroups = True
        settings.SettingsDetail.ShowDetailRow = False
        settings.SettingsDetail.AllowOnlyOneMasterRowExpanded = True
        settings.Settings.ShowGroupedColumns = True
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = tempPageMSG.ToString()
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "sales_real_verification_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")

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

        settings.KeyFieldName = "sp_id"
        settings.Columns.Add("sales_id")
        settings.Columns.Add("sales_plan_verification_status")
        settings.Columns.Add("sales_realization")
        settings.Columns.Add("sales_real_verification_status")
        settings.Columns.Add("dr_name")
        settings.Columns.Add("dr_spec")
        settings.Columns.Add("dr_quadrant")
        settings.Columns.Add("dr_monitoring")
        settings.Columns.Add("prd_price")
        settings.Columns.Add("prd_category")
        settings.Columns.Add("sp_target_qty")
        settings.Columns.Add("sp_target_value")
        settings.Columns.Add("sp_sales_qty")
        settings.Columns.Add("sp_sales_value")
        settings.Columns.Add(Sub(c)
                                 c.FieldName = "prd_name"
                                 c.Caption = "PRODUCT. NAME"
                                 c.GroupIndex = 0
                                 c.Visible = False
                             End Sub)

        settings.Columns(0).Caption = "SALES ID"
        settings.Columns(1).Caption = "Ver. Plan"
        settings.Columns(2).Caption = "Sales Real"
        settings.Columns(3).Caption = "Ver. Real"
        settings.Columns(4).Caption = "DOCTOR NAME"
        settings.Columns(5).Caption = "SPEC"
        settings.Columns(6).Caption = "DR. QUADRANT"
        settings.Columns(7).Caption = "DR. MONITORING"
        settings.Columns(8).Caption = "PRICE"
        settings.Columns(9).Caption = "CATEGORY"
        settings.Columns(10).Caption = "TARGET QTY"
        settings.Columns(11).Caption = "TARGET VALUE"
        settings.Columns(12).Caption = "SALES QTY"
        settings.Columns(13).Caption = "SALES VALUE"

        Return settings
    End Function

#End Region

End Class