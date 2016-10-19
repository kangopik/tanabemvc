Imports System.Web.Mvc
Imports TANABE_MVC.TANABE_MVC.Models
Imports DevExpress.Web.Mvc

Public Class TargetController
    Inherits Controller

    ' GET: /Target
    Function Index() As ActionResult
        Dim username As String = UCase(TryCast(Session("username"), [String]))
        If username = "" Then
            Return RedirectToAction("", "login")
        Else
            Return View("~/Views/Admin/Target/Target.vbhtml")
        End If
    End Function

    Function DataViewPartial(ByVal act As String) As ActionResult
        If act <> "" Then
            Dim params As String() = act.Split(New Char() {"-"})
            Return RedirectToAction("exportto", "target", New With {.export_type = params(1)})
        End If

        Dim model
        Try
            Dim vp As New TargetClass
            model = vp.GetDataTarget()
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return PartialView("~/Views/Admin/Target/DataViewPartial.vbhtml", model)
    End Function
    <HttpPost(), ValidateInput(False)> _
    Function NewProduct(ByVal collection As FormCollection) As ActionResult

        If collection("prd_aso_id") <> "" Then
            Try
                Dim vp As New ProductClass
                vp.InsertProduct(collection)
            Catch generatedExceptionName As Exception
                Throw
            End Try
        End If

        Dim model
        Try
            Dim vp As New ProductClass
            model = vp.GetDataProduct()
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Admin/Target/DataViewPartial.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function DeleteTarget(ByVal collection As FormCollection) As ActionResult

        If collection("prd_aso_id") <> "" Then
            Try
                Dim vp As New ProductClass
                vp.DeleteProduct(collection)
            Catch generatedExceptionName As Exception
                Throw
            End Try
        End If

        Dim model
        Try
            Dim vp As New ProductClass
            model = vp.GetDataProduct()
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Admin/Target/DataViewPartial.vbhtml", model)
    End Function

    <HttpPost(), ValidateInput(False)> _
    Function UpdateProduct(ByVal collection As FormCollection) As ActionResult

        If collection("prd_aso_id") <> "" Then
            Try
                Dim vp As New ProductClass
                vp.UpdateProduct(collection)
            Catch generatedExceptionName As Exception
                Throw
            End Try
        End If

        Dim model
        Try
            Dim vp As New ProductClass
            model = vp.GetDataProduct()
        Catch generatedExceptionName As Exception
            Throw
        End Try
        Return PartialView("~/Views/Admin/Target/DataViewPartial.vbhtml", model)
    End Function
    Public Function ExportTo(ByVal export_type As String) As ActionResult
        Dim model = Nothing
        Try
            Dim vp As New ProductClass
            model = vp.GetDataProduct()
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Select Case export_type.ToUpper()
            Case "CSV"
                Return GridViewExtension.ExportToCsv(TargetGridViewHelper.ExportGridViewSettings, model)
            Case "PDF"
                Return GridViewExtension.ExportToPdf(TargetGridViewHelper.ExportGridViewSettings, model)
            Case "RTF"
                Return GridViewExtension.ExportToRtf(TargetGridViewHelper.ExportGridViewSettings, model)
            Case "XLS"
                Return GridViewExtension.ExportToXls(TargetGridViewHelper.ExportGridViewSettings, model)
            Case "XLSX"
                Return GridViewExtension.ExportToXlsx(TargetGridViewHelper.ExportGridViewSettings, model)
            Case Else
                Return RedirectToAction("DataViewPartial")
        End Select
    End Function
End Class
Public NotInheritable Class TargetGridViewHelper
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
        settings.Name = "VISIT_PLAN"
        settings.CallbackRouteValues = New With {Key .Controller = "product", Key .Action = ""}
        settings.SettingsExport.Landscape = True
        settings.SettingsExport.ReportHeader = "PT. TANABE INDONESIA"
        settings.SettingsExport.PaperKind = Drawing.Printing.PaperKind.A4
        settings.SettingsExport.FileName = "MASTER PRODUCT ASO"


        settings.SettingsExport.Styles.Title.Font.Size = 7.2
        settings.SettingsExport.Styles.Cell.Font.Size = 7.2
        settings.SettingsExport.Styles.Header.Font.Size = 7.2

        settings.SettingsExport.Styles.GroupRow.Font.Size = 7.2
        settings.SettingsExport.Styles.GroupFooter.Font.Size = 7.2

        settings.SettingsExport.Styles.Footer.Font.Size = 7.2
        settings.SettingsExport.PageHeader.Font.Size = 7.2

        settings.SettingsExport.TopMargin = 10
        settings.SettingsExport.LeftMargin = 10
        settings.SettingsExport.RightMargin = 10
        settings.SettingsExport.BottomMargin = 10
        settings.Settings.ShowFooter = True
        settings.SettingsExport.PageFooter.Right = "[Page # of Pages #]"

        settings.Settings.ShowTitlePanel = True
        settings.SettingsText.Title = "MASTER PRODUCT ASO"

        settings.KeyFieldName = "prd_aso_id"

        settings.Columns.Add("prd_aso_id")
        settings.Columns.Add("prd_aso_desc")
        settings.Columns.Add("prd_aso_type")
        settings.Columns.Add("prd_aso_category")
        'settings.Columns.Add("prd_aso_join_desc")
        settings.Columns.Add("prd_aso_hna_bpjs")
        settings.Columns.Add("prd_aso_price")

        settings.Columns.Add("prd_aso_gp")
        settings.Columns.Add("prd_aso_ose")
        settings.Columns.Add("prd_aso_group")
        settings.Columns.Add("prd_aso_group_fin")
        settings.Columns.Add("prd_aso_tab")

        settings.Columns.Add("prd_aso_dossage")
        settings.Columns.Add("prd_aso_dostime")
        settings.Columns.Add("prd_aso_tc")
        'settings.Columns.Add("prd_aso_pm")
        settings.Columns.Add("nama_pm")


        settings.Columns(0).Caption = "CODE"
        settings.Columns(1).Caption = "DESCRIPTION"
        settings.Columns(2).Caption = "TYPE"
        settings.Columns(3).Caption = "CATEGORY"
        settings.Columns(4).Caption = "HNA"
        settings.Columns(5).Caption = "PRICE"
        settings.Columns(5).CellStyle.HorizontalAlign = HorizontalAlign.Right
        settings.Columns(6).Caption = "GP"
        settings.Columns(7).Caption = "OSE"
        settings.Columns(8).Caption = "GROUP"
        settings.Columns(9).Caption = "GROUP FINANCIAL"
        settings.Columns(10).Caption = "TABLET"
        settings.Columns(11).Caption = "DOSSAGE"
        settings.Columns(12).Caption = "DOSTIME"
        settings.Columns(13).Caption = "THEURA CLASS"
        settings.Columns(14).Caption = "PM"

        Return settings
    End Function


End Class