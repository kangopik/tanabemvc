Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models

Public Class MasterProductController
    Inherits Controller

    Public Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Master/MasterProduct/MasterProduct.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewMasterProduct() As ActionResult
        Try
            Dim repo = New Im_product()
            Dim model = repo.GetAllMasterProduct()
            Return PartialView("~/Views/Master/MasterProduct/ViewMasterProduct.vbhtml", model)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboVisit()
        Dim repo = New Im_visit()
        Dim mdl = repo.GetVisit()
        Return mdl
    End Function

    <HttpGet> _
    Public Function Delete() As ActionResult
        Dim prd_code As String = Request.QueryString("prd_code")
        If prd_code <> "" Then
            Dim repo = New Im_product()
            repo.Delete(prd_code)
        End If
        Return RedirectToAction("", "MasterProduct")
    End Function

    <HttpPost> _
    Public Function MasterProductAdd(collection As FormCollection) As ActionResult
        Dim mdl = New m_productModel()
        Dim repo = New Im_product()
        Try
            mdl.prd_code = Trim(collection("prd_code")).Replace("""", "")
            mdl.prd_name = Trim(collection("prd_name")).Replace("""", "")
            mdl.prd_focus = Trim(collection("prd_focus")).Replace("""", "")
            mdl.prd_type = Trim(collection("prd_type")).Replace("""", "")
            If collection("prd_price").Replace("""", "") = "" Then
                mdl.prd_price = 0
            Else
                mdl.prd_price = Convert.ToDouble(collection("prd_price"))
            End If
            mdl.prd_group = Trim(collection("prd_group")).Replace("""", "")
            If collection("prd_price_valid_year").Replace("""", "") = "" Then
                mdl.prd_price_valid_year = 0
            Else
                mdl.prd_price_valid_year = Convert.ToInt32(collection("prd_price_valid_year"))
            End If
            If collection("prd_status").Replace("""", "") = "" Then
                mdl.prd_status = 0
            Else
                mdl.prd_status = collection("prd_status").Replace("""", "")
            End If
            repo.Insert(mdl)
            TempData("msg") = "Add Master Product Success"
            Dim model = repo.GetAllMasterProduct()
            Return PartialView("~/Views/Master/MasterProduct/ViewMasterProduct.vbhtml", model)
        Catch ex As Exception
            TempData("msg") = "Add Master Product Failed, Please Check Your Input Field"
            Dim model = repo.GetAllMasterProduct()
            Return PartialView("~/Views/Master/MasterProduct/ViewMasterProduct.vbhtml", model)
        End Try
    End Function

    <HttpPost> _
    Public Function MasterProductUpdate(collection As FormCollection) As ActionResult
        Dim mdl = New m_productModel()
        Dim repo = New Im_product()
        Try
            mdl.prd_code = Trim(collection("prd_code")).Replace("""", "")
            mdl.prd_name = Trim(collection("prd_name")).Replace("""", "")
            mdl.prd_focus = Trim(collection("prd_focus")).Replace("""", "")
            mdl.prd_type = Trim(collection("prd_type")).Replace("""", "")
            If collection("prd_price") = "" Then
                mdl.prd_price = 0
            Else
                mdl.prd_price = Convert.ToDouble(collection("prd_price"))
            End If
            mdl.prd_group = Trim(collection("prd_group")).Replace("""", "")
            If collection("prd_price_valid_year").Replace("""", "") = "" Then
                mdl.prd_price_valid_year = 0
            Else
                mdl.prd_price_valid_year = Convert.ToInt32(collection("prd_price_valid_year"))
            End If
            If collection("prd_status") = "" Then
                mdl.prd_status = 0
            Else
                mdl.prd_status = collection("prd_status").Replace("""", "")
            End If
            repo.Update(mdl)
            TempData("msg") = "Update Master Product Success"
            Dim model = repo.GetAllMasterProduct()
            Return PartialView("~/Views/Master/MasterProduct/ViewMasterProduct.vbhtml", model)
        Catch ex As Exception
            TempData("msg") = "Update Master Product Failed, , Please Check Your Input Field"
            Dim model = repo.GetAllMasterProduct()
            Return PartialView("~/Views/Master/MasterProduct/ViewMasterProduct.vbhtml", model)
        End Try

    End Function

    Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
        Dim model
        Try
            Dim repo = New Im_product()
            model = repo.GetAllMasterProduct()
        Catch ex As Exception
            Throw ex
        End Try

        Select Case OutputFormat.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(MasterProductGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(MasterProductGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(MasterProductGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(MasterProductGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(MasterProductGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("ViewMasterProduct")
        End Select
    End Function

End Class

#Region "EXPORT"
Public NotInheritable Class MasterProductGridViewHelper

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
        settings.Name = "MASTER_PRODUCT"
        settings.CallbackRouteValues = New With {Key .Controller = "MasterProduct", Key .Action = "product"}
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "master_product_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


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
        settings.SettingsText.Title = "MASTER PRODUCT"


        settings.KeyFieldName = "prd_code"
        settings.Columns.Add("prd_code")
        settings.Columns.Add("prd_name")
        settings.Columns.Add("prd_focus")
        settings.Columns.Add("prd_type")
        settings.Columns.Add("prd_price")
        settings.Columns.Add("prd_group")
        settings.Columns.Add("prd_status")
        settings.Columns.Add("prd_price_valid_year")

        settings.Columns(0).Caption = "Product Code"
        settings.Columns(1).Caption = "Product Name"
        settings.Columns(2).Caption = "Focus"
        settings.Columns(3).Caption = "Type"
        settings.Columns(4).Caption = "Price"
        settings.Columns(5).Caption = "Group Visit"
        settings.Columns(6).Caption = "Status"
        settings.Columns(7).Caption = "Valid Year"

        Return settings
    End Function

End Class

#End Region