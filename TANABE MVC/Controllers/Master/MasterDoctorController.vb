Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models

Public Class MasterDoctorController
    Inherits Controller

    Public Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        Dim rep_id As String = TryCast(Session("rep_id"), [String])
        GlobalClass.temp_user_name = TryCast(Session("username"), [String])

        If username = "" Then
            Return RedirectToAction("index", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Master/MasterDoctor/MasterDoctor.vbhtml")
        End If
    End Function

    <ValidateInput(False)> _
    Public Function ViewMasterDoctor(ByVal act As String) As ActionResult
        Try
            Dim repo = New Im_doctor()
            Dim model = Nothing
            If act <> "" Then
                Dim params As String() = act.Split(New Char() {":"})
                Select Case params(0)
                    Case "retrieve"
                        Dim reg As String = Trim(params(1))
                        If reg <> "" Then
                            model = repo.GetAllMasterDoctorByReg(reg)
                        Else
                            model = repo.GetAllMasterDoctor()
                        End If
                    Case "MappingSBO"
                        Dim param As String = Trim(params(1))
                        If param <> "" Then
                            Dim dr_code As String() = param.Split(New Char() {";"})
                            Dim list As String() = dr_code(1).Split(New Char() {","})
                            For Each item As String In list
                                If (repo.CekDokterAlreadyPlaned(dr_code(0)) = 0) Then
                                    If (repo.CekDokterStillPlaned(item) = 0) Then
                                        Try
                                            model = repo.MappingSBO(item, dr_code(0))
                                            TempData("msg") = "Mapping SBO Success"
                                        Catch ex As Exception
                                            Throw
                                            TempData("msg") = "Mapping SBO Failed"
                                        End Try
                                    Else
                                        TempData("msg") = "Doctor Still Planned"
                                    End If
                                Else
                                    TempData("msg") = "Doctor Already Planned"
                                End If
                            Next item
                        End If
                        model = repo.GetAllMasterDoctor()
                    Case "MappingStatus"
                        Dim param As String = Trim(params(1))
                        If param <> "" Then
                            Dim dr_code As String() = param.Split(New Char() {";"})
                            Dim list As String() = dr_code(1).Split(New Char() {","})
                            For Each item As String In list
                                If (repo.CekDokterStillPlaned(item) = 0) Then
                                    Try
                                        model = repo.MappingStatus(item, dr_code(0))
                                        TempData("msg") = "Mapping Status Success"
                                    Catch ex As Exception
                                        Throw
                                        TempData("msg") = "Mapping Status Failed"
                                    End Try
                                Else
                                    TempData("msg") = "Doctor Still Planned"
                                End If
                            Next item
                        End If
                        model = repo.GetAllMasterDoctor()
                    Case "MappingQuadrant"
                        Dim param As String = Trim(params(1))
                        If param <> "" Then
                            Dim dr_code As String() = param.Split(New Char() {";"})
                            Dim list As String() = dr_code(1).Split(New Char() {","})
                            For Each item As String In list
                                If (repo.CekDokterStillPlaned(item) = 0) Then
                                    Try
                                        model = repo.MappingQuadrant(item, dr_code(0))
                                        TempData("msg") = "Mapping Quadrant Success"
                                    Catch ex As Exception
                                        Throw
                                        TempData("msg") = "Mapping Quadrant Failed"
                                    End Try
                                Else
                                    TempData("msg") = "Doctor Still Planned"
                                End If
                            Next item
                        End If
                        model = repo.GetAllMasterDoctor()
                End Select
            Else
                model = repo.GetAllMasterDoctor()
            End If

            Return PartialView("~/Views/Master/MasterDoctor/ViewMasterDoctor.vbhtml", model)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboSBO()
        Dim repo = New Im_doctor()
        Dim mdl = repo.GetSboFull()
        Return mdl
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboSpec()
        Dim repo = New Im_doctor()
        Dim mdl = repo.GetSpec()
        Return mdl
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboQuad()
        Dim repo = New Im_doctor()
        Dim mdl = repo.GetQuad()
        Return mdl
    End Function

    <ValidateInput(False)> _
    Public Shared Function ComboCategory()
        Dim repo = New Im_doctor()
        Dim mdl = repo.GetCategory()
        Return mdl
    End Function


    <HttpGet> _
    Public Function Delete() As ActionResult
        Dim dr_code As Integer = Request.QueryString("dr_code")
        If dr_code <> 0 Then
            Dim repo = New Im_doctor
            repo.Delete(dr_code)
        End If
        Return RedirectToAction("", "MasterDoctor")
    End Function

    Public Function GetDoctorCode(ByVal sbo_code As String) As JsonResult
        Dim repo = New Im_doctor()
        Dim listData = repo.GetDoctorCode(sbo_code)
        Dim data = New With {
                .NEW_DR_CODE = Trim(listData.FirstOrDefault.NEW_DR_CODE)
            }
        Return Json(data, JsonRequestBehavior.AllowGet)
    End Function

    <HttpPost> _
    Public Function MasterDoctorAdd(collection As FormCollection) As ActionResult
        Dim mdl = New m_doctorModel()
        Dim repo = New Im_doctor()
        Try
            mdl.dr_code = Trim(collection("dr_code")).Replace("""", "")
            mdl.dr_name = Trim(collection("dr_name")).Replace("""", "")
            mdl.dr_sbo = Trim(collection("dr_sbo")).Replace("""", "")
            mdl.dr_spec = Trim(collection("dr_spec")).Replace("""", "")
            mdl.dr_quadrant = Trim(collection("dr_quadrant")).Replace("""", "")
            mdl.dr_monitoring = Trim(collection("dr_monitoring")).Replace("""", "")
            mdl.dr_address = Trim(collection("dr_address")).Replace("""", "")
            mdl.dr_area_mis = Trim(collection("dr_area_mis")).Replace("""", "")
            mdl.dr_category = Trim(collection("dr_category")).Replace("""", "")
            mdl.dr_sub_category = Trim(collection("dr_sub_category")).Replace("""", "")
            mdl.dr_chanel = Trim(collection("dr_chanel")).Replace("""", "")
            mdl.dr_day_visit = Trim(collection("dr_day_visit")).Replace("""", "")
            mdl.dr_visiting_hour = Trim(collection("dr_number_patient")).Replace("""", "")
            If collection("dr_number_patient") = "" Then
                mdl.dr_number_patient = 0
            Else
                mdl.dr_number_patient = collection("dr_number_patient")
            End If
            mdl.dr_kol_not = Trim(collection("dr_kol_not")).Replace("""", "")
            mdl.dr_gender = Trim(collection("dr_gender")).Replace("""", "")
            mdl.dr_phone = Trim(collection("dr_phone")).Replace("""", "")
            mdl.dr_email = Trim(collection("dr_email")).Replace("""", "")
            Dim bd As String = Trim(collection("dr_birthday")).Replace(",", "-")
            bd = bd.Replace("new Date(", "")
            bd = bd.Replace(")", "")
            mdl.dr_birthday = DateTime.Parse(bd)
            mdl.dr_dk_lk = Trim(collection("dr_dk_lk")).Replace(",", "-")
            If collection("dr_status") = "" Then
                mdl.dr_status = 0
            Else
                mdl.dr_status = collection("dr_status").Replace("""", "")
            End If
            repo.Insert(mdl)
            TempData("msg") = "Add Master Doctor Success"
            Dim model = repo.GetAllMasterDoctor()
            Return PartialView("~/Views/Master/MasterDoctor/ViewMasterDoctor.vbhtml", model)
        Catch ex As Exception
            TempData("msg") = "Add Master Doctor Failed, Please Check Your Input Field"
            Dim model = repo.GetAllMasterDoctor()
            Return PartialView("~/Views/Master/MasterDoctor/ViewMasterDoctor.vbhtml", model)
        End Try
    End Function

    <HttpPost> _
    Public Function MasterDoctorUpdate(collection As FormCollection) As ActionResult
        Dim mdl = New m_doctorModel()
        Dim repo = New Im_doctor()
        mdl.dr_code = Trim(collection("dr_code")).Replace("""", "")
        mdl.dr_name = Trim(collection("dr_name")).Replace("""", "")
        mdl.dr_sbo = Trim(collection("dr_sbo")).Replace("""", "")
        mdl.dr_spec = Trim(collection("dr_spec")).Replace("""", "")
        mdl.dr_quadrant = Trim(collection("dr_quadrant")).Replace("""", "")
        mdl.dr_monitoring = Trim(collection("dr_monitoring")).Replace("""", "")
        mdl.dr_address = Trim(collection("dr_address")).Replace("""", "")
        mdl.dr_area_mis = Trim(collection("dr_area_mis")).Replace("""", "")
        mdl.dr_category = Trim(collection("dr_category")).Replace("""", "")
        mdl.dr_sub_category = Trim(collection("dr_sub_category")).Replace("""", "")
        mdl.dr_chanel = Trim(collection("dr_chanel")).Replace("""", "")
        mdl.dr_day_visit = Trim(collection("dr_day_visit")).Replace("""", "")
        mdl.dr_visiting_hour = Trim(collection("dr_number_patient")).Replace("""", "")
        If collection("dr_number_patient") = "" Then
            mdl.dr_number_patient = 0
        Else
            mdl.dr_number_patient = collection("dr_number_patient")
        End If
        mdl.dr_kol_not = Trim(collection("dr_kol_not")).Replace("""", "")
        mdl.dr_gender = Trim(collection("dr_gender")).Replace("""", "")
        mdl.dr_phone = Trim(collection("dr_phone")).Replace("""", "")
        mdl.dr_email = Trim(collection("dr_email")).Replace("""", "")
        Dim bd As String = Trim(collection("dr_birthday")).Replace(",", "-")
        bd = bd.Replace("new Date(", "")
        bd = bd.Replace(")", "")
        mdl.dr_birthday = DateTime.Parse(bd)
        mdl.dr_dk_lk = Trim(collection("dr_dk_lk")).Replace("""", "")
        If collection("dr_status") = "" Then
            mdl.dr_status = 0
        Else
            mdl.dr_status = collection("dr_status")
        End If
        Dim model = Nothing
        If (repo.CekDokter(mdl.dr_code).Count = 0) Then
            Try
                repo.Update(mdl)
                TempData("msg") = "Update Master Doctor Success"
            Catch ex As Exception
                TempData("msg") = "Update Master Doctor Failed, Please Check Your Input Field"
            End Try
        Else
            TempData("msg") = "Update can't be done unless doctor status on visit is unplanned"
        End If
        
        model = repo.GetAllMasterDoctor()
        Return PartialView("~/Views/Master/MasterDoctor/ViewMasterDoctor.vbhtml", model)
    End Function

    Public Function ExportTo(ByVal OutputFormat As String) As ActionResult
        Dim model
        Try
            Dim repo = New Im_doctor
            model = repo.GetAllMasterDoctor()
        Catch ex As Exception
            Throw ex
        End Try

        Select Case OutputFormat.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(MasterDoctorGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(MasterDoctorGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(MasterDoctorGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(MasterDoctorGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(MasterDoctorGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("ViewMasterDoctor")
        End Select
    End Function

End Class

#Region "EXPORT"
Public NotInheritable Class MasterDoctorGridViewHelper
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
        settings.Name = "MASTER_DOCTOR"
        settings.CallbackRouteValues = New With {Key .Controller = "MasterDoctor", Key .Action = "doctor"}
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = Printing.PaperKind.A4
        settings.SettingsExport.FileName = "master_doctor_" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")


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
        settings.SettingsText.Title = "MASTER DOCTOR"


        settings.KeyFieldName = "dr_code"
        settings.Columns.Add("dr_code")
        settings.Columns.Add("dr_sbo")
        settings.Columns.Add("dr_name")
        settings.Columns.Add("dr_quadrant")
        settings.Columns.Add("dr_spec")
        settings.Columns.Add("dr_sub_spec")
        settings.Columns.Add("dr_monitoring")
        settings.Columns.Add("dr_address")
        settings.Columns.Add("dr_area_mis")
        settings.Columns.Add("dr_category")
        settings.Columns.Add("dr_sub_category")
        settings.Columns.Add("dr_day_visit")
        settings.Columns.Add("dr_visiting_hour")
        settings.Columns.Add("dr_number_patient")
        settings.Columns.Add("dr_kol_not")
        settings.Columns.Add("dr_gender")
        settings.Columns.Add("dr_phone")
        settings.Columns.Add("dr_dk_lk")
        settings.Columns.Add("dr_birthday")
        settings.Columns.Add("dr_email")
        settings.Columns.Add("dr_status")

        settings.Columns(0).Caption = "Doctor Code"
        settings.Columns(1).Caption = "SBO Code"
        settings.Columns(2).Caption = "Name"
        settings.Columns(3).Caption = "Quadrant"
        settings.Columns(4).Caption = "Spec"
        settings.Columns(5).Caption = "Sub Spec"
        settings.Columns(6).Caption = "Monitoring"
        settings.Columns(7).Caption = "Address"
        settings.Columns(8).Caption = "Area MIS"
        settings.Columns(9).Caption = "Category"
        settings.Columns(10).Caption = "Sub Category"
        settings.Columns(11).Caption = "Day Visit"
        settings.Columns(12).Caption = "Visit Hour"
        settings.Columns(12).Caption = "Patient Number"
        settings.Columns(12).Caption = "KOL/NOT"
        settings.Columns(12).Caption = "Gender"
        settings.Columns(12).Caption = "Phone"
        settings.Columns(12).Caption = "DK/LK"
        settings.Columns(12).Caption = "Birthday"
        settings.Columns(12).Caption = "Email"
        settings.Columns(12).Caption = "Status"

        Return settings
    End Function

End Class

#End Region