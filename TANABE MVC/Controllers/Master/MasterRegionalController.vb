Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models

Public Class MasterRegionalController
    Inherits Controller

    Public Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Master/MasterRegional/MasterRegional.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewMasterRegional() As ActionResult
        Try
            Dim repo = New Im_regional()
            Dim model = repo.GetAllMasterRegional()
            Return PartialView("~/Views/Master/MasterRegional/ViewMasterRegional.vbhtml", model)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboFunctionary()
        Dim repo = New Im_rep()
        Dim mdl = repo.GetFunctionary()
        Return mdl
    End Function

    <HttpGet> _
    Public Function Delete() As ActionResult
        Dim reg_id As String = Request.QueryString("reg_id")
        If reg_id <> "" Then
            Dim repo = New Im_regional()
            repo.Delete(reg_id)
        End If
        Return RedirectToAction("", "MasterRegional")
    End Function

    <HttpPost> _
    Public Function MasterRegionalAdd(collection As FormCollection) As ActionResult
        Dim mdl = New m_regionalModel()
        Dim repo = New Im_regional()
        Try
            mdl.reg_id = Trim(collection("reg_id")).Replace("""", "")
            mdl.reg_description = Trim(collection("reg_description")).Replace("""", "")
            mdl.reg_functionary = Trim(collection("Nama")).Replace("""", "")
            If collection("reg_status") = "" Then
                mdl.reg_status = 0
            Else
                mdl.reg_status = collection("reg_status")
            End If
            repo.Insert(mdl)
            TempData("msg") = "Add Master Region Success"
            Dim model = repo.GetAllMasterRegional()
            Return PartialView("~/Views/Master/MasterRegional/ViewMasterRegional.vbhtml", model)
        Catch ex As Exception
            TempData("msg") = "Add Master Region Failed, Please Check Your Input Field"
            Dim model = repo.GetAllMasterRegional()
            Return PartialView("~/Views/Master/MasterRegional/ViewMasterRegional.vbhtml", model)
        End Try

    End Function

    <HttpPost> _
    Public Function MasterRegionalUpdate(collection As FormCollection) As ActionResult
        Dim mdl = New m_regionalModel()
        Dim repo = New Im_regional()
        Try
            Dim a As String = Trim(collection("Nama")).Replace("""", "")
            Dim b As String = Trim(collection("reg_functionary")).Replace("""", "")
            mdl.reg_id = Trim(collection("reg_id")).Replace("""", "")
            mdl.reg_description = Trim(collection("reg_description")).Replace("""", "")
            If a = b Then
                mdl.reg_functionary = Trim(collection("Nama")).Replace("""", "")
            Else
                mdl.reg_functionary = Trim(collection("reg_functionary")).Replace("""", "")
            End If
            If collection("reg_sequence_code").Replace("""", "") = "" Then
                mdl.reg_sequence_code = 1
            Else
                mdl.reg_sequence_code = Convert.ToInt32(collection("reg_sequence_code"))
            End If
            If collection("reg_status").Replace("""", "") = "" Then
                mdl.reg_status = 0
            Else
                mdl.reg_status = collection("reg_status")
            End If
            repo.Update(mdl)
            TempData("msg") = "Update Master Region Success"
            Dim model = repo.GetAllMasterRegional()
            Return PartialView("~/Views/Master/MasterRegional/ViewMasterRegional.vbhtml", model)
        Catch ex As Exception
            TempData("msg") = "Update Master Region Failed, Please Check Your Input Field"
            Dim model = repo.GetAllMasterRegional()
            Return PartialView("~/Views/Master/MasterRegional/ViewMasterRegional.vbhtml", model)
        End Try

    End Function

    Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
        Dim model
        Dim repo = New Im_regional()
        Try
            model = repo.GetAllMasterRegional()
        Catch ex As Exception
            Throw ex
        End Try

        Select Case OutputFormat.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(MasterRegionalGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(MasterRegionalGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(MasterRegionalGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(MasterRegionalGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(MasterRegionalGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("ViewMasterRegional")
        End Select
    End Function

End Class

#Region "EXPORT"
Public NotInheritable Class MasterRegionalGridViewHelper

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
        settings.Name = "MASTER_REGION"
        settings.CallbackRouteValues = New With {Key .Controller = "MasterRegion", Key .Action = "region"}
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "master_region_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


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
        settings.SettingsText.Title = "MASTER REGION"


        settings.KeyFieldName = "reg_id"
        settings.Columns.Add("reg_id")
        settings.Columns.Add("reg_description")
        settings.Columns.Add("Nama")
        settings.Columns.Add("reg_sequence_code")
        settings.Columns.Add("reg_status")

        settings.Columns(0).Caption = "Regional Code"
        settings.Columns(1).Caption = "Regional Description"
        settings.Columns(2).Caption = "Functionary"
        settings.Columns(3).Caption = "Sequence Code"
        settings.Columns(4).Caption = "Status"


        Return settings
    End Function

End Class

#End Region