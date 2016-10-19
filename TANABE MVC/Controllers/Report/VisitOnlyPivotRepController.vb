Imports System.Web.Mvc
Imports System.Drawing
Imports System.Threading
Imports System.Globalization
Imports System
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports TANABE_MVC.Repositories
Imports TANABE_MVC.Models
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports DevExpress.Utils
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Customization
Imports System.Collections.Generic
Imports DevExpress.Export
Imports DevExpress.XtraPrinting
Imports TANABE_MVC.PivotGridExportOptions


Namespace Controllers.Report
    Public Class VisitOnlyPivotRepController
        Inherits Controller

        Function Index() As ActionResult
            Dim username As String = UCase(TryCast(Session("username"), [String]))
            Dim rep_id As String = TryCast(Session("rep_id"), [String])
            GlobalClass.temp_user_name = TryCast(Session("username"), [String])

            If Not (Request.HttpMethod = "POST") Then           'page load
                Session("date_start") = "All"
                Session("date_end") = "All"
            End If

            If username = "" Then
                Return RedirectToAction("index", "login")
            Else
                ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
                Return View("~/Views/Report/Rep/VisitOnlyPivotRep.vbhtml")
            End If
        End Function

        <ValidateInput(False)> _
        Public Function VisitOnlyPivotRepPartialView(ByVal act As String) As ActionResult
            If act <> "" Then
                Dim params As String() = act.Split(New Char() {";"})
                Dim proc As String = params(0)
                Select Case proc
                    Case "reset"
                        Session("date_start") = "All"
                        Session("date_end") = "All"
                    Case "retrieve"
                        Dim dtStart As String = params(1)
                        Dim dtEnd As String = params(2)
                        Session("date_start") = CDate(dtStart).ToString("yyyy-MM-dd")
                        Session("date_end") = CDate(dtEnd).ToString("yyyy-MM-dd")
                    Case "export"
                        Return RedirectToAction("ExportTo", "VisitOnlyPivotRep", New With {.export_type = params(1)})
                End Select
            End If

            Dim repo = New r_visitonlypivotrep()
            Dim model

            Try
                Dim rep_id As String = TryCast(Session("rep_id"), [String])
                Dim rep_position As String = TryCast(Session("rep_position"), [String])
                ViewData("rep_id") = rep_id
                ViewData("rep_position") = rep_position
                model = repo.GetVisitOnlyPivotRep(Session("date_start"), Session("date_end"), Session("rep_id"))

            Catch generatedExceptionName As Exception
                Throw
            End Try

            'If GlobalClass.temp_message_visit_plan <> "" Then
            '    TempData("msg") = GlobalClass.temp_message_visit_plan
            '    GlobalClass.temp_message_visit_plan = ""
            'End If
            'Dim repo = New r_visitonlypivotrep()
            'Dim model = repo.GetVisitOnlyPivotRep()
            Return PartialView("~/Views/Report/Rep/VisitOnlyPivotRepPartialView.vbhtml", model)
        End Function

        Public Function ExportTo(ByVal export_type As String) As ActionResult
            Dim repo = New r_visitonlypivotrep()
            Dim model
            Try
                model = repo.GetVisitOnlyPivotRep(Session("date_start"), Session("date_end"), Session("rep_id"))
            Catch generatedExceptionName As Exception
                Throw
            End Try

            Select Case export_type.ToUpper()
                Case "CSV"
                    Return PivotGridExtension.ExportToCsv(PivotGridDataOutputHelper.ExportPivotGridSettings, model)
                Case "PDF"
                    Return PivotGridExtension.ExportToPdf(PivotGridDataOutputHelper.ExportPivotGridSettings, model)
                Case "RTF"
                    Return PivotGridExtension.ExportToRtf(PivotGridDataOutputHelper.ExportPivotGridSettings, model)
                Case "XLS"
                    Return PivotGridExtension.ExportToXls(PivotGridDataOutputHelper.ExportPivotGridSettings, model)
                Case "XLSX"
                    Return PivotGridExtension.ExportToXls(PivotGridDataOutputHelper.ExportPivotGridSettings, model)
                Case "ROWDATA"
                    Return GridViewExtension.ExportToXlsx(PivotGridDataOutputHelper.ExportRowDataSettings, model)
                Case Else
                    Return RedirectToAction("VisitOnlyPivotRepPartialView")
            End Select
        End Function

    End Class

    Public Class PivotGridDataOutputHelper

        Shared m_exportPivotGridSettings As PivotGridSettings
        Shared m_dataAwarePivotGridSettings As GridViewSettings
        Public Shared ReadOnly Property ExportPivotGridSettings() As PivotGridSettings
            Get
                If m_exportPivotGridSettings Is Nothing Then
                    m_exportPivotGridSettings = CreatePivotGridSettings()
                End If
                Return m_exportPivotGridSettings
            End Get
        End Property

        Public Shared ReadOnly Property ExportRowDataSettings() As GridViewSettings
            Get
                If m_dataAwarePivotGridSettings Is Nothing Then
                    m_dataAwarePivotGridSettings = CreateDataAwarePivotGridSettings()
                End If
                Return m_dataAwarePivotGridSettings
            End Get
        End Property

        Private Shared Function CreatePivotGridSettings() As PivotGridSettings
            Dim settings As New PivotGridSettings()
            settings.Name = "pivotGrid"
            settings.CallbackRouteValues = New With { _
                Key .Controller = "DataOutput", _
                Key .Action = "ExportPartial" _
            }
            settings.Width = Unit.Percentage(100)
            settings.OptionsView.HorizontalScrollBarMode = ScrollBarMode.Auto

            settings.Fields.Add(Sub(field)
                                    field.Area = PivotArea.RowArea
                                    field.FieldName = "rep_name"
                                    field.Caption = "TI NAME"
                                    field.AreaIndex = 1
                                End Sub)
            settings.Fields.Add(Sub(field)
                                    field.Area = PivotArea.RowArea
                                    field.FieldName = "am"
                                    field.Caption = "AM"
                                    field.AreaIndex = 0
                                End Sub)
            settings.Fields.Add(Sub(field)
                                    field.Area = PivotArea.RowArea
                                    field.FieldName = "date_visit"
                                    field.Caption = "DATE"
                                    field.Visible = True
                                    field.AreaIndex = 2
                                End Sub)
            settings.Fields.Add(Sub(field)
                                    field.Area = PivotArea.DataArea
                                    field.FieldName = "plan"
                                    field.Caption = "PLAN"
                                End Sub)
            settings.Fields.Add(Sub(field)
                                    field.Area = PivotArea.DataArea
                                    field.FieldName = "realization"
                                    field.Caption = "REAL"
                                End Sub)
            settings.Fields.Add(Sub(field)
                                    field.ID = "Percent"
                                    field.Area = PivotArea.DataArea
                                    field.FieldName = ""
                                    field.Caption = "ACHV"
                                    field.AreaIndex = 2
                                    field.CellFormat.FormatString = "p"
                                End Sub)
            settings.Fields.Add(Sub(field)
                                    field.ID = "Remaining"
                                    field.Area = PivotArea.DataArea
                                    field.FieldName = ""
                                    field.Caption = "REM"
                                    field.AreaIndex = 3
                                End Sub)

            settings.CustomCellDisplayText = Sub(sender, e)
                                                 Dim pivotGrid As MVCxPivotGrid = DirectCast(sender, MVCxPivotGrid)
                                                 Dim planField As ASPxPivotGrid.PivotGridField = pivotGrid.Fields("plan")
                                                 Dim plan As Object = e.GetCellValue(planField)
                                                 Dim realField As ASPxPivotGrid.PivotGridField = pivotGrid.Fields("realization")
                                                 Dim real As Object = e.GetCellValue(realField)
                                                 Dim grandTotalPlan As Decimal = CDec(e.GetRowGrandTotal(planField))
                                                 Dim grandTotalReal As Decimal = CDec(e.GetRowGrandTotal(realField))

                                                 If Object.ReferenceEquals(e.DataField, pivotGrid.Fields("Percent")) Then
                                                     If plan Is Nothing Or plan = 0 Then
                                                         Return
                                                     End If
                                                     If real Is Nothing Or real = 0 Then
                                                         Return
                                                     End If
                                                     If grandTotalPlan = 0 Then
                                                         Return
                                                     End If
                                                     If grandTotalReal = 0 Then
                                                         Return
                                                     End If

                                                     Dim perc As Decimal = CDec(real) / CDec(plan)
                                                     e.DisplayText = String.Format("{0:p}", perc)
                                                 End If
                                                 If Object.ReferenceEquals(e.DataField, pivotGrid.Fields("Remaining")) Then
                                                     Dim remaining As Integer = CInt(real) - CInt(plan)
                                                     e.DisplayText = remaining
                                                 End If
                                             End Sub
            Return settings

        End Function

        Private Shared Function CreateDataAwarePivotGridSettings() As GridViewSettings
            Dim settings As New GridViewSettings()
            Dim _user_name As String = GlobalClass.temp_user_name
            settings.Name = "VISIT_ONLY_PIVOT_REP"
            settings.CallbackRouteValues = New With {Key .Controller = "visit", Key .Action = "plan"}
            settings.SettingsExport.FileName = "VOPR" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")
            settings.SettingsExport.Styles.Cell.Font.Size = 9
            settings.SettingsExport.Styles.Header.Font.Size = 9
            settings.SettingsExport.MaxColumnWidth = 100
            settings.Columns.Add("bo") : settings.Columns(0).Caption = "BO" : settings.Columns(0).ExportWidth = 75
            settings.Columns.Add("rep_name") : settings.Columns(1).Caption = "TI NAME" : settings.Columns(1).ExportWidth = 75
            settings.Columns.Add("position") : settings.Columns(2).Caption = "POSITION" : settings.Columns(2).ExportWidth = 75
            settings.Columns.Add("division") : settings.Columns(3).Caption = "DIVISION" : settings.Columns(3).ExportWidth = 75
            settings.Columns.Add("bo") : settings.Columns(4).Caption = "BO" : settings.Columns(4).ExportWidth = 75
            settings.Columns.Add("sbo") : settings.Columns(5).Caption = "SBO" : settings.Columns(5).ExportWidth = 75
            settings.Columns.Add("rep_am") : settings.Columns(6).Caption = "REP AM" : settings.Columns(6).ExportWidth = 75
            settings.Columns.Add("am") : settings.Columns(7).Caption = "AM" : settings.Columns(7).ExportWidth = 75
            settings.Columns.Add("region") : settings.Columns(8).Caption = "REGION" : settings.Columns(8).ExportWidth = 75
            settings.Columns.Add("rep_rm") : settings.Columns(9).Caption = "REP RM" : settings.Columns(9).ExportWidth = 75
            settings.Columns.Add("rm") : settings.Columns(10).Caption = "RM" : settings.Columns(10).ExportWidth = 75
            settings.Columns.Add("month") : settings.Columns(11).Caption = "MONTH" : settings.Columns(11).ExportWidth = 75
            settings.Columns.Add("date_visit") : settings.Columns(12).Caption = "DATE" : settings.Columns(12).ExportWidth = 75
            settings.Columns.Add("dr_code") : settings.Columns(13).Caption = "DR CODE" : settings.Columns(13).ExportWidth = 75
            settings.Columns.Add("plan") : settings.Columns(14).Caption = "PLAN" : settings.Columns(14).ExportWidth = 75
            settings.Columns.Add("info") : settings.Columns(15).Caption = "INFO" : settings.Columns(15).ExportWidth = 75
            settings.Columns.Add("sp") : settings.Columns(16).Caption = "SP" : settings.Columns(16).ExportWidth = 75
            settings.Columns.Add("sp_value") : settings.Columns(17).Caption = "SP VALUE" : settings.Columns(17).ExportWidth = 75
            settings.Columns.Add("realization") : settings.Columns(18).Caption = "REALIZATION" : settings.Columns(18).ExportWidth = 75
            settings.Columns.Add("doc_name") : settings.Columns(19).Caption = "DOC NAME" : settings.Columns(19).ExportWidth = 75
            settings.Columns.Add("spec") : settings.Columns(20).Caption = "SPEC" : settings.Columns(20).ExportWidth = 75
            settings.Columns.Add("sub_spec") : settings.Columns(21).Caption = "SUB SPEC" : settings.Columns(21).ExportWidth = 75
            settings.Columns.Add("quadrant") : settings.Columns(22).Caption = "QUADRANT" : settings.Columns(22).ExportWidth = 75
            settings.Columns.Add("monitoring") : settings.Columns(23).Caption = "MONITORING" : settings.Columns(23).ExportWidth = 75
            settings.Columns.Add("dklk") : settings.Columns(24).Caption = "DKLK" : settings.Columns(24).ExportWidth = 75
            settings.Columns.Add("area_mis") : settings.Columns(25).Caption = "AREA MIS" : settings.Columns(25).ExportWidth = 75
            settings.Columns.Add("category") : settings.Columns(26).Caption = "CATEGORY" : settings.Columns(26).ExportWidth = 75
            settings.Columns.Add("channel") : settings.Columns(27).Caption = "CHANNEL" : settings.Columns(27).ExportWidth = 75
            Return settings
        End Function

    End Class
End Namespace




