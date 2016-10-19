Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports System.Web.HttpContext
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models

Public Class MasterRepresentativeController
    Inherits Controller

    Public Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])
        Session("rep_region_am") = ""

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Master/MasterRepresentative/MasterRepresentative.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewMasterRepresentative(ByVal act As String) As ActionResult
        Try
            Dim repo = New Im_rep()
            Dim model = Nothing

            If act <> "" Then
                Dim params As String() = act.Split(New Char() {":"})
                Select Case params(0)
                    Case "retrieve"
                        Dim reg As String = Trim(params(1))
                        If reg <> "" Then
                            model = repo.GetAllMasterRepByReg(reg)
                        Else
                            model = repo.GetAllMasterRep()
                        End If
                    Case "Mapping"
                        Dim param As String = Trim(params(1))
                        If param <> "" Then
                            Dim rep_id As String() = param.Split(New Char() {";"})
                            Dim list As String() = rep_id(1).Split(New Char() {","})
                            For Each item As String In list
                                Try
                                    model = repo.Mapping(item, rep_id(0))
                                    TempData("msg") = "Mapping Region Success"
                                Catch ex As Exception
                                    Throw
                                    TempData("msg") = "Mapping Region Failed"
                                End Try
                            Next item
                        End If
                        model = repo.GetAllMasterRep()
                End Select
            Else
                model = repo.GetAllMasterRep()
            End If

            Return PartialView("~/Views/Master/MasterRepresentative/ViewMasterRepresentative.vbhtml", model)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <ValidateInput(False)> _
    Public Shared Function CbRegion()
        Dim repo = New Im_rep()
        Dim mdl = repo.GetRegion()
        Return mdl
    End Function

    <ValidateInput(False)> _
    Private Sub GetInfoDetailRep(ByVal rep_id As String)
        Dim repo = New Im_rep()
        Dim mdl = repo.GetKodeDept(rep_id)
        Session("rep_region_am") = mdl
    End Sub

    <ValidateInput(False)> _
    Public Shared Function ComboNIK()
        Dim repo = New Im_rep()
        Dim mdl = repo.GetEmployee()
        Return mdl
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboSBO()
        Dim repo = New Im_rep()
        Dim mdl = repo.GetSBO()
        Return mdl
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboRegion()
        Dim repo = New Im_rep()
        Dim mdl = repo.GetReg()
        Return mdl
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboDivision()
        Dim repo = New Im_rep()
        Dim mdl = repo.GetDivision()
        Return mdl
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboAM()
        Dim repo = New Im_rep()
        Dim mdl = repo.GetAMS()
        Return mdl
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboRM()
        Dim repo = New Im_rep()
        Dim mdl = repo.GetRMS()
        Return mdl
    End Function

    <HttpGet> _
    Public Function Delete() As ActionResult
        Dim rep_id As String = Request.QueryString("rep_id")
        If rep_id <> "" Then
            Dim repo = New Im_rep()
            repo.Delete(rep_id)
        End If
        Return RedirectToAction("", "MasterRepresentative")
    End Function

    <HttpPost> _
    Public Function GetDetailRep(ByVal rep_id As String) As JsonResult
        Dim repo = New Im_rep()
        Dim repos = New Im_rep()
        Dim datas = repo.GetEmployeeByNIK(rep_id)
        Dim kode As String = datas.FirstOrDefault().Kode_Departemen
        Dim listData = repos.GetRepDetail(kode)
        Dim data = New With {
                .Nama = Trim(datas.FirstOrDefault.Nama),
                .rep_region = Trim(listData.FirstOrDefault.rep_region),
                .rep_rm = Trim(listData.FirstOrDefault.rep_rm),
                .nama_rm = Trim(listData.FirstOrDefault.nama_rm)
            }
        Return Json(data, JsonRequestBehavior.AllowGet)
    End Function

    Public Function GetDetailSBO(ByVal sbo_code As String) As JsonResult
        Dim repo = New Im_rep()
        Dim listData = repo.GetSBODetail(sbo_code)
        Dim data = New With {
                .bo_code = Trim(listData.FirstOrDefault.bo_code),
                .bo_am = Trim(listData.FirstOrDefault.bo_am),
                .bo_am_name = Trim(listData.FirstOrDefault.bo_am_name)
            }
        Return Json(data, JsonRequestBehavior.AllowGet)
    End Function

    <HttpPost> _
    Public Function MasterRepresentativeAdd(collection As FormCollection) As ActionResult
        Dim mdl = New m_repModel()
        Dim repo = New Im_rep()
        Dim model = Nothing
        mdl.rep_id = Trim(collection("rep_id")).Replace("""", "")
        If mdl.rep_id = "" Then
            mdl.rep_name = ""
        Else
            Dim repos As Im_rep = New Im_rep()
            Dim listData = repos.GetEmployeeByNIK(mdl.rep_id)
            mdl.rep_name = listData.FirstOrDefault().Nama
        End If
        mdl.rep_name = Trim(collection("rep_name")).Replace("""", "")
        mdl.rep_sbo = Trim(collection("rep_sbo")).Replace("""", "")
        If mdl.rep_sbo = "" Then
            mdl.rep_bo = ""
        Else
            Dim repos As Im_rep = New Im_rep()
            Dim listData = repos.FindBO(mdl.rep_sbo)
            mdl.rep_bo = listData.FirstOrDefault().bo_code
        End If
        mdl.rep_region = Trim(collection("rep_region")).Replace("""", "")
        mdl.rep_position = Trim(collection("rep_position")).Replace("""", "")
        mdl.rep_email = Trim(collection("rep_email")).Replace("""", "")
        mdl.rep_division = Trim(collection("rep_division")).Replace("""", "")
        mdl.rep_am = Trim(collection("nama_am")).Replace("""", "")
        mdl.rep_rm = Trim(collection("nama_rm")).Replace("""", "")
        If collection("rep_status") = "" Then
            mdl.rep_status = 0
        Else
            mdl.rep_status = collection("rep_status")
        End If

        If (repo.CekRep1(mdl.rep_sbo).Count = 0) Then
            Try
                repo.Insert(mdl)
                TempData("msg") = "Add Master Representative Success"
            Catch ex As Exception
                TempData("msg") = "Add Master Representative Failed, Please Check Your Input Field"
            End Try
        Else
            TempData("msg") = "Insert can't be done, Rep with current SBO CODE is already exists"
        End If
            
        model = repo.GetAllMasterRep()
        Return PartialView("~/Views/Master/MasterRepresentative/ViewMasterRepresentative.vbhtml", model)
    End Function

    <HttpPost> _
    Public Function MasterRepresentativeUpdate(collection As FormCollection) As ActionResult
        Dim mdl = New m_repModel()
        Dim repo = New Im_rep()
        Dim model = Nothing
        mdl.rep_id = Trim(collection("rep_id")).Replace("""", "")
        mdl.rep_name = Trim(collection("rep_name")).Replace("""", "")
        mdl.rep_sbo = Trim(collection("rep_sbo")).Replace("""", "")
        If mdl.rep_sbo = "" Then
            mdl.rep_bo = ""
        Else
            Dim repos As Im_rep = New Im_rep()
            Dim listData = repos.FindBO(mdl.rep_sbo)
            mdl.rep_bo = listData.FirstOrDefault().bo_code
        End If
        mdl.rep_region = Trim(collection("rep_region")).Replace("""", "")
        mdl.rep_position = Trim(collection("rep_position")).Replace("""", "")
        mdl.rep_email = Trim(collection("rep_email")).Replace("""", "")
        mdl.rep_division = Trim(collection("rep_division")).Replace("""", "")
        If Trim(collection("rep_am")).Replace("""", "") = Trim(collection("nama_am")).Replace("""", "") Then
            mdl.rep_am = Trim(collection("nama_am")).Replace("""", "")
        Else
            mdl.rep_am = Trim(collection("rep_am")).Replace("""", "")
        End If
        If Trim(collection("rep_rm")).Replace("""", "") = Trim(collection("nama_rm")).Replace("""", "") Then
            mdl.rep_am = Trim(collection("nama_rm")).Replace("""", "")
        Else
            mdl.rep_am = Trim(collection("rep_rm")).Replace("""", "")
        End If
        If collection("rep_status") = "" Then
            mdl.rep_status = 0
        Else
            mdl.rep_status = collection("rep_status")
        End If
        If collection("rep_status") = "" Then
            mdl.rep_status = 0
        Else
            mdl.rep_status = collection("rep_status")
        End If

        If (repo.CekRep1(mdl.rep_sbo).Count = 0) Then
            If (repo.CekRep2(mdl.rep_sbo).Count = 0) Then
                If (repo.CekRep3(mdl.rep_sbo).Count = 0) Then
                    Try
                        repo.Update(mdl)
                        TempData("msg") = "Update Master Representative Success"
                    Catch ex As Exception
                        TempData("msg") = "Update Master Representative Failed, Please Check Your Input Field"
                    End Try
                Else
                    TempData("msg") = "Insert can't be done, Some doctor in new SBO code is already planned on the visit"
                End If
            Else
                TempData("msg") = "Insert can't be done, Some doctor in previous SBO code is still planned on the visit"
            End If
        Else
            TempData("msg") = "Insert can't be done, Rep with current SBO CODE is already exists"
        End If

        model = repo.GetAllMasterRep()
        Return PartialView("~/Views/Master/MasterRepresentative/ViewMasterRepresentative.vbhtml", model)
    End Function

    Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
        Dim model
        Try
            Dim repo = New Im_rep()
            model = repo.GetAllMasterRep()
        Catch ex As Exception
            Throw ex
        End Try

        Select Case OutputFormat.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(MasterRepGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(MasterRepGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(MasterRepGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(MasterRepGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(MasterRepGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("ViewMasterRepresentative")
        End Select
    End Function

End Class

#Region "EXPORT"
Public NotInheritable Class MasterRepGridViewHelper

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
        settings.Name = "MASTER_REPRESENTATIVE"
        settings.CallbackRouteValues = New With {Key .Controller = "MasterRepresentative", Key .Action = "mrep"}
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "master_representative_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


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
        settings.SettingsText.Title = "MASTER REPRESENTATIVE"


        settings.KeyFieldName = "rep_id"
        settings.Columns.Add("rep_id")
        settings.Columns.Add("rep_name")
        settings.Columns.Add("rep_bo")
        settings.Columns.Add("rep_sbo")
        settings.Columns.Add("rep_region")
        settings.Columns.Add("rep_position")
        settings.Columns.Add("rep_email")
        settings.Columns.Add("rep_division")
        settings.Columns.Add("nama_am")
        settings.Columns.Add("nama_rm")
        settings.Columns.Add("rep_status")

        settings.Columns(0).Caption = "NIK"
        settings.Columns(1).Caption = "Name"
        settings.Columns(2).Caption = "Sub Branch Office"
        settings.Columns(3).Caption = "Branch Office"
        settings.Columns(4).Caption = "Region"
        settings.Columns(5).Caption = "Position"
        settings.Columns(6).Caption = "Email"
        settings.Columns(7).Caption = "Division"
        settings.Columns(8).Caption = "Area Manager"
        settings.Columns(9).Caption = "Regional Manager"
        settings.Columns(10).Caption = "Status"

        Return settings
    End Function

End Class

#End Region