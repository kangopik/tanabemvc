Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models

Public Class MasterBoController
    Inherits Controller

    Public Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Master/MasterBO/MasterBO.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewMasterBO() As ActionResult
        Try
            Dim repo = New Im_bo()
            Dim model = repo.GetAllMasterBO()
            Return PartialView("~/Views/Master/MasterBO/ViewMasterBO.vbhtml", model)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboAm()
        Dim repo = New Im_rep()
        Dim mdl = repo.GetAm()
        Return mdl
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboRegion()
        Dim repo = New Im_regional()
        Dim mdl = repo.GetRegion()
        Return mdl
    End Function

    <HttpPost> _
    Public Function GetInfoDetailAM(ByVal rep_id As String) As JsonResult
        Dim repo = New Im_rep()
        Dim listData = repo.GetInfoDetailAM(rep_id)
        Dim data = New With {
                .rep_region = listData.FirstOrDefault.rep_region
            }
        Return Json(data, JsonRequestBehavior.AllowGet)
    End Function

    <HttpGet> _
    Public Function Delete() As ActionResult
        Dim bo_code As String = Request.QueryString("bo_code")
        If bo_code <> "" Then
            Dim repo = New Im_bo()
            repo.Delete(bo_code)
        End If
        Return RedirectToAction("", "MasterBo")
    End Function

    <HttpPost> _
    Public Function MasterBoAdd(collection As FormCollection) As ActionResult
        Dim mdl = New m_boModel()
        Dim repo = New Im_bo()
        Try
            mdl.bo_code = Trim(collection("bo_code")).Replace("""", "")
            mdl.bo_description = Trim(collection("bo_description")).Replace("""", "")
            mdl.bo_address = Trim(collection("bo_address")).Replace("""", "")
            mdl.bo_am = Trim(collection("Nama")).Replace("""", "")
            mdl.reg_id = Trim(collection("reg_id")).Replace("""", "")
            If collection("bo_status").Replace("""", "") = "" Then
                mdl.bo_status = 0
            Else
                mdl.bo_status = collection("bo_status").Replace("""", "")
            End If
            repo.Insert(mdl)
            TempData("msg") = "Add Master BO Success"
            Dim model = repo.GetAllMasterBO()
            Return PartialView("~/Views/Master/MasterBO/ViewMasterBO.vbhtml", model)
        Catch ex As Exception
            TempData("msg") = "Add Master BO Failed, Please Check Your Input Field"
            Dim model = repo.GetAllMasterBO()
            Return PartialView("~/Views/Master/MasterBO/ViewMasterBO.vbhtml", model)
        End Try
    End Function

    <HttpPost> _
    Public Function MasterBoUpdate(collection As FormCollection) As ActionResult
        Dim mdl = New m_boModel()
        Dim repo = New Im_bo()
        Try
            Dim a As String = Trim(collection("Nama")).Replace("""", "")
            Dim b As String = Trim(collection("bo_am")).Replace("""", "")
            mdl.bo_code = Trim(collection("bo_code")).Replace("""", "")
            mdl.bo_description = Trim(collection("bo_description")).Replace("""", "")
            mdl.bo_address = Trim(collection("bo_address")).Replace("""", "")
            If a = b Then
                mdl.bo_am = Trim(collection("Nama")).Replace("""", "")
            Else
                mdl.bo_am = Trim(collection("bo_am")).Replace("""", "")
            End If
            If collection("bo_sequence_code").Replace("""", "") = "" Then
                mdl.bo_sequence_code = 0
            Else
                mdl.bo_sequence_code = Convert.ToInt32(collection("bo_sequence_code"))
            End If
            mdl.reg_id = Trim(collection("reg_id")).Replace("""", "")
            If collection("bo_status") = "" Then
                mdl.bo_status = 0
            Else
                mdl.bo_status = collection("bo_status").Replace("""", "")
            End If
            repo.Update(mdl)
            TempData("msg") = "Update Master BO Success"
            Dim model = repo.GetAllMasterBO()
            Return PartialView("~/Views/Master/MasterBO/ViewMasterBO.vbhtml", model)
        Catch ex As Exception
            TempData("msg") = "Update Master BO Failed, Please Check Your Input Field"
            Dim model = repo.GetAllMasterBO()
            Return PartialView("~/Views/Master/MasterBO/ViewMasterBO.vbhtml", model)
        End Try

    End Function

    Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
        Dim model
        Try
            Dim repo = New Im_bo()
            model = repo.GetAllMasterBO()
        Catch ex As Exception
            Throw ex
        End Try

        Select Case OutputFormat.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(MasterBoGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(MasterBoGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(MasterBoGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(MasterBoGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(MasterBoGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("ViewMasterBO")
        End Select
    End Function

End Class

#Region "EXPORT"
Public NotInheritable Class MasterBoGridViewHelper
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
        settings.Name = "MASTER_BO"
        settings.CallbackRouteValues = New With {Key .Controller = "MasterBo", Key .Action = "bo"}
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "master_bo_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


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
        settings.SettingsText.Title = "MASTER BO"


        settings.KeyFieldName = "bo_code"
        settings.Columns.Add("bo_code")
        settings.Columns.Add("bo_description")
        settings.Columns.Add("bo_address")
        settings.Columns.Add("bo_sequence_code")
        settings.Columns.Add("Nama")
        settings.Columns.Add("reg_id")
        settings.Columns.Add("bo_status")

        settings.Columns(0).Caption = "BO Code"
        settings.Columns(1).Caption = "BO Description"
        settings.Columns(2).Caption = "BO Address"
        settings.Columns(3).Caption = "Sequence Code"
        settings.Columns(4).Caption = "BO AM"
        settings.Columns(5).Caption = "Region"
        settings.Columns(6).Caption = "Status"

        Return settings
    End Function
End Class

#End Region