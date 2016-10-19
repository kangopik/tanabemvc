Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models

Public Class SalesHistoryController
    Inherits Controller

    Dim repo As New ISalesHistory()

    Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])

        If Not (Request.HttpMethod = "POST") Then
            Dim currentDate As DateTime = DateTime.Now
            Session("sess_day") = 0
            Session("sess_month") = currentDate.Month
            Session("sess_year") = currentDate.Year
        End If

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Sales/History/SalesHistory.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewSalesHistory() As ActionResult
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Try
            ViewData("RequestFlag") = ""
            Dim model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
            If (model.Count() = 0) Then
                ViewData("RequestFlag") = "null_record"
            Else
                ViewData("RequestFlag") = "record_exists"
            End If
            Return PartialView("~/Views/Sales/History/ViewSalesHistory.vbhtml", model)
        Catch ex As Exception
            Throw
        End Try
    End Function

    <ValidateInput(False)> _
    Public Function ViewSalesHistoryCustomCallback(ByVal prm As String) As ActionResult
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Dim params As String() = prm.Split(New Char() {";"})
        Dim act As String = params(0)
        Dim month As String = params(1)
        Dim year As String = params(2)
        Dim model = Nothing
        ViewData("RequestFlag") = Nothing

        If act = "retrieve" Then
            If month <> "null" Then
                If year <> "null" Then
                    Session("sess_month") = month
                    Session("sess_year") = year
                    Try
                        model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
                        If (model.Count() = 0) Then
                            ViewData("RequestFlag") = "null_record"
                        Else
                            ViewData("RequestFlag") = "record_exists"
                        End If
                    Catch generatedExceptionName As Exception
                        Throw
                    End Try
                End If
            End If
        ElseIf act = "mapping" Then
            Dim prod As String = params(3)
            Dim target As String = params(4)
            Dim note As String = params(5)
            Dim sales_id As String() = params(6).Split(New Char() {","})
            If prod = "" Then
                ViewData("MappingFlag") = "null_product"
            Else
                If target = "" Then
                    ViewData("MappingFlag") = "null_target"
                Else
                    For Each item As String In sales_id
                        Try
                            model = repo.InsertSalesProduct(item, prod, target, note)
                            ViewData("MappingFlag") = "success_mapping"
                        Catch ex As Exception
                            Throw
                            ViewData("MappingFlag") = "mapping_error"
                        End Try
                    Next
                End If
            End If
        Else
            Dim currentDate As DateTime = DateTime.Now
            Session("sess_month") = currentDate.Month
            Session("sess_year") = currentDate.Year
            model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
            If (model.Count() = 0) Then
                ViewData("RequestFlag") = "null_record"
            Else
                ViewData("RequestFlag") = "record_exists"
            End If
        End If

        model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
        Return PartialView("~/Views/Sales/History/ViewSalesHistory.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function DeleteActual(ByVal coll As FormCollection) As ActionResult
        Dim sales_id As String = coll("sales_id")
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Dim model
        If sales_id <> "" Then
            repo.DeleteSalesPlan(sales_id)
        End If
        Try
            model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/History/ViewSalesHistory.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function UpdateHistory() As ActionResult
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Dim model
        repo.UpdateFake()
        Try
            model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/History/ViewSalesHistory.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DetailSalesHistory(ByVal sp_id As String) As ActionResult
        ViewData("sp_id") = sp_id
        Dim model
        Try
            model = repo.dsEditProductSalesActual(sp_id)
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Sales/History/DetailSalesHistory.vbhtml", model)
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
        Return PartialView("~/Views/Sales/History/EditFormHistory.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DetailEditForm() As ActionResult
        Dim model
        Try
            model = repo.dsEditProductSalesActual(Session("sp_id"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/History/EditFormHistory.vbhtml", model)
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
        Return PartialView("~/Views/Sales/History/EditFormHistory.vbhtml", model)
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
        Return PartialView("~/Views/Sales/History/EditFormHistory.vbhtml", model)
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
        Return PartialView("~/Views/Sales/History/EditFormHistory.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Shared Function cbProductLookup()
        Dim repo = New ISalesRealization()
        Dim mdl = repo.dsProductLookup()
        Return mdl
    End Function

    Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
        Dim model
        Try
            Dim repo = New ISalesHistory()
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
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
                Return RedirectToAction("ViewSalesHistory")
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
        tempPageMSG.Append("SALES HISTORY" & vbCrLf)
        tempPageMSG.Append("Nama      : " & Session("rep_name") & vbCrLf)
        tempPageMSG.Append("Regional : " & Session("rep_reg") & vbCrLf)
        tempPageMSG.Append("BO          : " & Session("rep_bo") & vbCrLf)
        tempPageMSG.Append("Month     :____________________________" & vbCrLf)

        settings.Name = "gridSalesHistory"
        settings.CallbackRouteValues = New With {Key .Controller = "SalesHistory", Key .Action = "ViewSalesHistory"}
        settings.SettingsBehavior.AllowFixedGroups = True
        settings.SettingsBehavior.AutoExpandAllGroups = True
        settings.SettingsDetail.ShowDetailRow = False
        settings.SettingsDetail.AllowOnlyOneMasterRowExpanded = True
        settings.Settings.ShowGroupedColumns = True
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = tempPageMSG.ToString()
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "sales_history_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")

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
        settings.Columns.Add("dr_code")
        settings.Columns.Add("sales_plan_verification_status")
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

        settings.Columns(0).Caption = "DR. CODE"
        settings.Columns(1).Caption = "Ver. Plan"
        settings.Columns(2).Caption = "Ver. Real"
        settings.Columns(3).Caption = "DOCTOR NAME"
        settings.Columns(4).Caption = "SPEC"
        settings.Columns(5).Caption = "DR. QUADRANT"
        settings.Columns(6).Caption = "DR. MONITORING"
        settings.Columns(7).Caption = "PRICE"
        settings.Columns(8).Caption = "CATEGORY"
        settings.Columns(9).Caption = "TARGET QTY"
        settings.Columns(10).Caption = "TARGET VALUE"
        settings.Columns(11).Caption = "SALES QTY"
        settings.Columns(12).Caption = "SALES VALUE"

        Return settings
    End Function

#End Region

End Class