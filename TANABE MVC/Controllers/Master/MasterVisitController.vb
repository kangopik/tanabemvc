Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models

Public Class MasterVisitController
    Inherits Controller

    Public Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Master/MasterVisit/MasterVisit.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewMasterVisit() As ActionResult
        Try
            ViewData("RequestFlag") = "undefined"
            Dim repo = New Im_visit()
            Dim model = repo.GetAllMasterVisit()
            Return PartialView("~/Views/Master/MasterVisit/ViewMasterVisit.vbhtml", model)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <HttpGet> _
    Public Function Delete() As ActionResult
        Dim visit_code As String = Request.QueryString("visit_code")
        If visit_code <> "" Then
            Dim repo = New Im_visit()
            repo.Delete(visit_code)
        End If
        Return RedirectToAction("", "MasterVisit")
    End Function

    <HttpPost> _
    Public Function MasterVisitAdd(collection As FormCollection) As ActionResult
        Dim mdl = New m_visitModel()
        Dim repo = New Im_visit()

        Try
            mdl.visit_code = Trim(collection("visit_code")).Replace("""", "")
            mdl.visit_team = Trim(collection("visit_team")).Replace("""", "")
            mdl.visit_product = Trim(collection("visit_product")).Replace("""", "")
            mdl.visit_category = Trim(collection("visit_category")).Replace("""", "")
            If collection("visit_status") = "" Then
                mdl.visit_status = 0
            Else
                mdl.visit_status = collection("visit_status")
            End If
            repo.Insert(mdl)
            ViewData("RequestFlag") = "Add Master Visit Success"
            Dim model = repo.GetAllMasterVisit()
            Return PartialView("~/Views/Master/MasterVisit/ViewMasterVisit.vbhtml", model)
        Catch ex As Exception
            ViewData("RequestFlag") = "Add Master Visit Failed, Please Check Your Input Field"
            Dim model = repo.GetAllMasterVisit()
            Return PartialView("~/Views/Master/MasterVisit/ViewMasterVisit.vbhtml", model)
        End Try
    End Function

    <HttpPost> _
    Public Function MasterVisitUpdate(collection As FormCollection) As ActionResult
        Dim mdl = New m_visitModel()
        Dim repo = New Im_visit()

        Try
            mdl.visit_code = Trim(collection("visit_code")).Replace("""", "")
            mdl.visit_team = Trim(collection("visit_team")).Replace("""", "")
            mdl.visit_product = Trim(collection("visit_product")).Replace("""", "")
            mdl.visit_category = Trim(collection("visit_category")).Replace("""", "")
            If collection("visit_status") = "" Then
                mdl.visit_status = 0
            Else
                mdl.visit_status = collection("visit_status")
            End If
            repo.Update(mdl)
            ViewData("RequestFlag") = "Update Master Visit Success"
            Dim model = repo.GetAllMasterVisit()
            Return PartialView("~/Views/Master/MasterVisit/ViewMasterVisit.vbhtml", model)
        Catch ex As Exception
            ViewData("RequestFlag") = "Update Master Visit Failed, Please Check Your Input Field"
            Dim model = repo.GetAllMasterVisit()
            Return PartialView("~/Views/Master/MasterVisit/ViewMasterVisit.vbhtml", model)
        End Try

    End Function

    Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
        Dim model
        Try
            Dim repo = New Im_visit()
            model = repo.GetAllMasterVisit()
        Catch ex As Exception
            Throw ex
        End Try

        Select Case OutputFormat.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(MasterVisitGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(MasterVisitGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(MasterVisitGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(MasterVisitGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(MasterVisitGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("ViewMasterVisit")
        End Select
    End Function

End Class

#Region "EXPORT"
Public NotInheritable Class MasterVisitGridViewHelper
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
        settings.Name = "MASTER_VISIT"
        settings.CallbackRouteValues = New With {Key .Controller = "MasterVisit", Key .Action = "visit"}
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "master_visit_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


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
        settings.SettingsText.Title = "MASTER VISIT"


        settings.KeyFieldName = "visit_code"
        settings.Columns.Add("visit_code")
        settings.Columns.Add("visit_team")
        settings.Columns.Add("visit_product")
        settings.Columns.Add("visit_category")
        settings.Columns.Add("visit_status")

        settings.Columns(0).Caption = "Visit Code"
        settings.Columns(1).Caption = "Team Name"
        settings.Columns(2).Caption = "Group Product"
        settings.Columns(3).Caption = "Category"
        settings.Columns(4).Caption = "Status"

        Return settings
    End Function
End Class
#End Region