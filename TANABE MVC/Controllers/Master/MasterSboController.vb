Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models

Public Class MasterSboController
    Inherits Controller

    Public Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Master/MasterSBO/MasterSBO.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewMasterSBO() As ActionResult
        Try
            ViewData("RequestFlag") = "undefined"
            Dim repo = New Im_sbo()
            Dim model = repo.GetAllMasterSBO()
            Return PartialView("~/Views/Master/MasterSBO/ViewMasterSBO.vbhtml", model)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboBo()
        Dim repo = New Im_bo()
        Dim mdl = repo.GetBo()
        Return mdl
    End Function

    <HttpGet> _
    Public Function Delete() As ActionResult
        Dim sbo_code As String = Request.QueryString("sbo_code")
        If sbo_code <> "" Then
            Dim repo = New Im_sbo()
            repo.Delete(sbo_code)
        End If
        Return RedirectToAction("", "MasterSbo")
    End Function

    <HttpPost> _
    Public Function MasterSboAdd(collection As FormCollection) As ActionResult
        Dim mdl = New m_sboModel()
        Dim repo = New Im_sbo()
        Try
            mdl.sbo_code = Trim(collection("sbo_code")).Replace("""", "")
            mdl.sbo_description = Trim(collection("sbo_description")).Replace("""", "")
            mdl.sbo_address = Trim(collection("sbo_address")).Replace("""", "")
            mdl.bo_code = Trim(collection("bo_code")).Replace("""", "")
            If collection("sbo_status") = "" Then
                mdl.sbo_status = 0
            Else
                mdl.sbo_status = collection("sbo_status")
            End If
            repo.Insert(mdl)
            ViewData("RequestFlag") = "Add Master SBO Success"
            Dim model = repo.GetAllMasterSBO()
            Return PartialView("~/Views/Master/MasterSBO/ViewMasterSBO.vbhtml", model)
        Catch ex As Exception
            ViewData("RequestFlag") = "Add Master SBO Failed, Please Check Your Input Field"
            Dim model = repo.GetAllMasterSBO()
            Return PartialView("~/Views/Master/MasterSBO/ViewMasterSBO.vbhtml", model)
        End Try
    End Function

    <HttpPost> _
    Public Function MasterSboUpdate(collection As FormCollection) As ActionResult
        Dim mdl = New m_sboModel()
        Dim repo = New Im_sbo()
        Try
            mdl.sbo_code = Trim(collection("sbo_code")).Replace("""", "")
            mdl.sbo_description = Trim(collection("sbo_description")).Replace("""", "")
            mdl.sbo_address = Trim(collection("sbo_address")).Replace("""", "")
            mdl.bo_code = Trim(collection("bo_code")).Replace("""", "")
            If collection("sbo_status") = "" Then
                mdl.sbo_status = 0
            Else
                mdl.sbo_status = collection("sbo_status")
            End If
            If collection("sbo_sequence_code") = "" Then
                mdl.sbo_sequence_code = 0
            Else
                mdl.sbo_sequence_code = Convert.ToInt32(collection("sbo_sequence_code"))
            End If
            repo.Update(mdl)
            ViewData("RequestFlag") = "Update Master SBO Success"
            Dim model = repo.GetAllMasterSBO()
            Return PartialView("~/Views/Master/MasterSBO/ViewMasterSBO.vbhtml", model)
        Catch ex As Exception
            ViewData("RequestFlag") = "Update Master SBO Failed, Please Check Your Input Field"
            Dim model = repo.GetAllMasterSBO()
            Return PartialView("~/Views/Master/MasterSBO/ViewMasterSBO.vbhtml", model)
        End Try

    End Function

    Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
        Dim model
        Try
            Dim repo = New Im_sbo()
            model = repo.GetAllMasterSBO()
        Catch ex As Exception
            Throw ex
        End Try

        Select Case OutputFormat.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(MasterSboGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(MasterSboGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(MasterSboGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(MasterSboGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(MasterSboGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("ViewMasterSBO")
        End Select
    End Function

End Class

#Region "EXPORT"
Public NotInheritable Class MasterSboGridViewHelper

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
        settings.Name = "MASTER_SBO"
        settings.CallbackRouteValues = New With {Key .Controller = "MasterSbo", Key .Action = "sbo"}
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "master_sbo_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


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
        settings.SettingsText.Title = "MASTER SBO"


        settings.KeyFieldName = "sbo_code"
        settings.Columns.Add("sbo_code")
        settings.Columns.Add("sbo_description")
        settings.Columns.Add("sbo_address")
        settings.Columns.Add("sbo_sequence_code")
        settings.Columns.Add("bo_code")
        settings.Columns.Add("sbo_status")

        settings.Columns(0).Caption = "SBO Code"
        settings.Columns(1).Caption = "SBO Description"
        settings.Columns(2).Caption = "SBO Address"
        settings.Columns(3).Caption = "Sequence Code"
        settings.Columns(4).Caption = "BO Code"
        settings.Columns(5).Caption = "Status"

        Return settings
    End Function

End Class

#End Region