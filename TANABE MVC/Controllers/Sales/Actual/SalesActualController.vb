﻿Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models
Imports System.IO
Imports System.Net.Mail

Public Class SalesActualController
    Inherits Controller

    Dim repo As New ISalesActual()

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
            Return View("~/Views/Sales/Actual/SalesActual.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewSalesActual() As ActionResult
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Try
            ViewData("RequestFlag") = ""
            Dim model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
            If (model.Count() = 0) Then
                ViewData("RequestFlag") = "null_record"
            Else
                ViewData("RequestFlag") = "record_exists"
            End If
            Return PartialView("~/Views/Sales/Actual/ViewSalesActual.vbhtml", model)
        Catch ex As Exception
            Throw
        End Try
    End Function

    <ValidateInput(False)> _
    Public Function ViewSalesActualCustomCallback(ByVal prm As String) As ActionResult
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
        ElseIf act = "request" Then
            Dim mon As Integer = params(1)
            Dim currentDate As DateTime = DateTime.Now
            Dim curr_month As Int32 = currentDate.Month
            Dim curr_year As Int32 = currentDate.Year
            Dim curr_monthRequest As Int32 = mon
            If curr_monthRequest = 0 Then
                curr_monthRequest = curr_month
            End If

            If (repo.isHaveRemainingToSendMail(rep_id, curr_month, curr_year)) Then
                SetReport(rep_id, curr_monthRequest)
                ViewData("CopyFlag") = "success_send"
            Else
                ViewData("CopyFlag") = "send_limitation"
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
        Return PartialView("~/Views/Sales/Actual/ViewSalesActual.vbhtml", model)
    End Function

    Public Function ReqVerivication() As ActionResult
        Return PartialView("~/Views/Sales/Actual/PopupRequest.vbhtml")
    End Function

    Sub SetReport(ByVal rep_id As String, ByVal monthReq As String)
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

        Try
            Dim tempPageMSG As New System.Text.StringBuilder
            tempPageMSG.Append("PT. TANABE INDONESIA" & vbCrLf)
            tempPageMSG.Append("SALES ACTUAL" & vbCrLf)
            tempPageMSG.Append("Nama      : " & Session("rep_name") & vbCrLf)
            tempPageMSG.Append("Regional : " & Session("rep_reg") & vbCrLf)
            tempPageMSG.Append("BO          : " & Session("rep_bo") & vbCrLf)

            Dim settings As GridViewSettings = ExportGridViewSettings
            settings.SettingsExport.ReportHeader = tempPageMSG.ToString

            Dim PdfFile As New System.IO.MemoryStream
            Dim model
            Try
                model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
            Catch generatedExceptionName As Exception
                Throw
            End Try

            GridViewExtension.WritePdf(settings, model, PdfFile)
            PdfFile.Seek(0, SeekOrigin.Begin)
            Dim reader As New StreamReader(Server.MapPath("~/ContentEmailPage/email_page_new_sales_real.htm"))
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
            mailMessage.Attachments.Add(New Attachment(PdfFile, Session("rep_name") & " - Sales_Realization - " & monthReq, "application/pdf"))
            mailMessage.Subject = "Request Verification for " & Session("rep_name") & " - " & "Sales Realization - " & monthReq

            mailMessage.Priority = Net.Mail.MailPriority.High
            mailMessage.Body = email_body.ToString()
            mailMessage.IsBodyHtml = True
            smtpClient.Send(mailMessage)

            repo.SaveReport(rep_id)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    <HttpPost(), ValidateInput(False)> _
    Function DeleteHistory(ByVal coll As FormCollection) As ActionResult
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
        Return PartialView("~/Views/Sales/Actual/ViewSalesActual.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function UpdateActual() As ActionResult
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        Dim model
        repo.UpdateFake()
        Try
            model = repo.dsProductSales(rep_id, Session("sess_month"), Session("sess_year"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/Actual/ViewSalesActual.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DetailSalesActual(ByVal sp_id As String) As ActionResult
        ViewData("sp_id") = sp_id
        Dim model
        Try
            model = repo.dsEditProductSalesActual(sp_id)
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Sales/Actual/DetailSalesActual.vbhtml", model)
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
        Return PartialView("~/Views/Sales/Actual/EditFormActual.vbhtml", model)
    End Function

    <ValidateInput(False)> _
    Public Function DetailEditForm() As ActionResult
        Dim model
        Try
            model = repo.dsEditProductSalesActual(Session("sp_id"))
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Sales/Actual/EditFormActual.vbhtml", model)
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
        Return PartialView("~/Views/Sales/Actual/EditFormActual.vbhtml", model)
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
        Return PartialView("~/Views/Sales/Actual/EditFormActual.vbhtml", model)
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
        Return PartialView("~/Views/Sales/Actual/EditFormActual.vbhtml", model)
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
            Dim repo = New ISalesActual()
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
                Return RedirectToAction("ViewSalesActual")
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
        tempPageMSG.Append("SALES ACTUAL" & vbCrLf)
        tempPageMSG.Append("Nama      : " & Session("rep_name") & vbCrLf)
        tempPageMSG.Append("Regional : " & Session("rep_reg") & vbCrLf)
        tempPageMSG.Append("BO          : " & Session("rep_bo") & vbCrLf)
        tempPageMSG.Append("Month     :____________________________" & vbCrLf)

        settings.Name = "gridSalesActual"
        settings.CallbackRouteValues = New With {Key .Controller = "SalesActual", Key .Action = "ViewSalesActual"}
        settings.SettingsBehavior.AllowFixedGroups = True
        settings.SettingsBehavior.AutoExpandAllGroups = True
        settings.SettingsDetail.ShowDetailRow = False
        settings.SettingsDetail.AllowOnlyOneMasterRowExpanded = True
        settings.Settings.ShowGroupedColumns = True
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = tempPageMSG.ToString()
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "sales_actual_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")

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