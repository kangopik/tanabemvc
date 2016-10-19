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
Imports DevExpress.Web.ASPxPivotGrid


Namespace Controllers.Report
    Public Class VisitProductPivotRepController
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
                Return View("~/Views/Report/Rep/VisitProductPivotRep.vbhtml")
            End If
        End Function

        <ValidateInput(False)> _
        Public Function VisitProductPivotRepPartialView(ByVal act As String) As ActionResult
            Dim repo = New r_VisitProductPivotRep()
            Dim model

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
                        Return RedirectToAction("ExportTo", "VisitProductPivotRep", New With {.export_type = params(1)})
                        'model = repo.GetVisitProductPivotRep(Session("date_start"), Session("date_end"), Session("rep_id"))
                        'Return PivotGridExtension.ExportToPdf(PivotGridLayout.VisitProductPivotGridSettings, model)
                End Select
            End If



            Try
                Dim rep_id As String = TryCast(Session("rep_id"), [String])
                Dim rep_position As String = TryCast(Session("rep_position"), [String])
                ViewData("rep_id") = rep_id
                ViewData("rep_position") = rep_position
                model = repo.GetVisitProductPivotRep(Session("date_start"), Session("date_end"), Session("rep_id"))

            Catch generatedExceptionName As Exception
                Throw
            End Try
            Return PartialView("~/Views/Report/Rep/VisitProductPivotRepPartialView.vbhtml", model)
        End Function

        Public Function ExportTo(ByVal export_type As String) As ActionResult
            Dim repo = New r_VisitProductPivotRep()
            Dim model
            Try
                model = repo.GetVisitProductPivotRep(Session("date_start"), Session("date_end"), Session("rep_id"))
            Catch generatedExceptionName As Exception
                Throw
            End Try

            Select Case export_type.ToUpper()
                Case "CSV"
                    Return PivotGridExtension.ExportToCsv(PivotGridLayout.VisitProductPivotRepGridSettings, model)
                Case "PDF"
                    Return PivotGridExtension.ExportToPdf(PivotGridLayout.VisitProductPivotRepGridSettings, model)
                Case "RTF"
                    Return PivotGridExtension.ExportToRtf(PivotGridLayout.VisitProductPivotRepGridSettings, model)
                Case "XLS"
                    Return PivotGridExtension.ExportToXls(PivotGridLayout.VisitProductPivotRepGridSettings, model)
                Case "XLSX"
                    Return PivotGridExtension.ExportToXls(PivotGridLayout.VisitProductPivotRepGridSettings, model)
                Case "ROWDATA"
                    Return GridViewExtension.ExportToXlsx(VisitProductPivotGridDataOutput.ExportRowDataSettings, model)
                Case Else
                    Return RedirectToAction("VisitProductPivotRepPartialView")
            End Select
        End Function

    End Class

    '    New PivotGridSettings() With { _
    '	Key .Name = "ExportPivotGrid", _
    '	Key .BeforePerformDataSelect = Function(sender, e) 
    '    Dim PivotGrid As MVCxPivotGrid = TryCast(sender, MVCxPivotGrid)
    '    Dim layout As String = DirectCast(Session("Layout"), String)
    '	Debug.WriteLine("Is layout empty? " & String.IsNullOrEmpty(layout))
    '	If Not String.IsNullOrEmpty(layout) Then
    '		PivotGrid.LoadLayoutFromString(layout, DevExpress.Web.ASPxPivotGrid.PivotGridWebOptionsLayout.DefaultLayout)
    '	End If

    'End Function _
    '}

    Public Class VisitProductPivotGridDataOutput

        Shared m_exportPivotGridSettings As PivotGridSettings
        Shared m_dataAwarePivotGridSettings As GridViewSettings
        'Public Shared ReadOnly Property ExportPivotGridSettings() As PivotGridSettings
        '    Get
        '        If m_exportPivotGridSettings Is Nothing Then
        '            m_exportPivotGridSettings = CreatePivotGridSettings()
        '        End If
        '        Return m_exportPivotGridSettings
        '    End Get
        'End Property

        Public Shared ReadOnly Property ExportRowDataSettings() As GridViewSettings
            Get
                If m_dataAwarePivotGridSettings Is Nothing Then
                    m_dataAwarePivotGridSettings = CreateDataAwarePivotGridSettings()
                End If
                Return m_dataAwarePivotGridSettings
            End Get
        End Property

        'Private Shared Function CreatePivotGridSettings() As PivotGridSettings
        '    Dim settings As New PivotGridSettings()
        '    settings.Name = "pivotGrid"
        '    settings.CallbackRouteValues = New With { _
        '        Key .Controller = "VisitProductPivotRep", _
        '        Key .Action = "VisitProductPivotRepPartialView" _
        '    }
        '    settings.Width = Unit.Percentage(100)
        '    settings.OptionsView.HorizontalScrollBarMode = ScrollBarMode.Auto

        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.RowArea
        '                            field.FieldName = "region"
        '                            field.Caption = "REGION"
        '                            field.AreaIndex = 0
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.RowArea
        '                            field.FieldName = "am"
        '                            field.Caption = "AM"
        '                            field.AreaIndex = 1
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.RowArea
        '                            field.FieldName = "rep_name"
        '                            field.Caption = "TI NAME"
        '                            field.AreaIndex = 2
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "position"
        '                            field.Caption = "POSITION"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "division"
        '                            field.Caption = "DIVISION"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "bo"
        '                            field.Caption = "BO"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "sbo"
        '                            field.Caption = "SBO"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "rep_am"
        '                            field.Caption = "REP AM"
        '                            field.Visible = False
        '                        End Sub)

        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "rep_rm"
        '                            field.Caption = "REP RM"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "rm"
        '                            field.Caption = "RM"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "month"
        '                            field.Caption = "MONTH"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.RowArea
        '                            field.FieldName = "date_visit"
        '                            field.Caption = "DATE"
        '                            field.Visible = False
        '                            field.AreaIndex = 2
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "dr_code"
        '                            field.Caption = "DR CODE"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.DataArea
        '                            field.FieldName = "plan"
        '                            field.Caption = "PLAN"
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "info"
        '                            field.Caption = "INFO"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "sp"
        '                            field.Caption = "SP"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "sp_value"
        '                            field.Caption = "SP VALUE"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.DataArea
        '                            field.FieldName = "realization"
        '                            field.Caption = "REAL"
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "dr_name"
        '                            field.Caption = "DR NAME"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "spec"
        '                            field.Caption = "SPEC"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "sub_spec"
        '                            field.Caption = "SUB SPEC"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "quadrant"
        '                            field.Caption = "QUADRANT"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "monitoring"
        '                            field.Caption = "MONITORING"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "dklk"
        '                            field.Caption = "DKLK"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "area_mis"
        '                            field.Caption = "AREA MIS"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "category"
        '                            field.Caption = "CTGY"
        '                            field.Visible = False
        '                        End Sub)
        '    settings.Fields.Add(Sub(field)
        '                            field.Area = PivotArea.FilterArea
        '                            field.FieldName = "channel"
        '                            field.Caption = "CHANNEL"
        '                            field.Visible = False
        '                        End Sub)

        '    settings.CustomCellDisplayText = Sub(sender, e)
        '                                         Dim pivotGrid As MVCxPivotGrid = DirectCast(sender, MVCxPivotGrid)
        '                                         Dim planField As DevExpress.Web.ASPxPivotGrid.PivotGridField = pivotGrid.Fields("plan")
        '                                         Dim plan As Object = e.GetCellValue(planField)
        '                                         Dim realField As DevExpress.Web.ASPxPivotGrid.PivotGridField = pivotGrid.Fields("realization")
        '                                         Dim real As Object = e.GetCellValue(realField)
        '                                         Dim grandTotalPlan As Decimal = CDec(e.GetRowGrandTotal(planField))
        '                                         Dim grandTotalReal As Decimal = CDec(e.GetRowGrandTotal(realField))

        '                                         If Object.ReferenceEquals(e.DataField, pivotGrid.Fields("Percent")) Then
        '                                             If plan Is Nothing Or plan = 0 Then
        '                                                 Return
        '                                             End If
        '                                             If real Is Nothing Or real = 0 Then
        '                                                 Return
        '                                             End If
        '                                             If grandTotalPlan = 0 Then
        '                                                 Return
        '                                             End If
        '                                             If grandTotalReal = 0 Then
        '                                                 Return
        '                                             End If

        '                                             Dim perc As Decimal = CDec(real) / CDec(plan)
        '                                             e.DisplayText = String.Format("{0:p}", perc)
        '                                         End If
        '                                         If Object.ReferenceEquals(e.DataField, pivotGrid.Fields("Remaining")) Then
        '                                             Dim remaining As Integer = CInt(real) - CInt(plan)
        '                                             e.DisplayText = remaining
        '                                         End If

        '                                         '---------------
        '                                         'If e.Value IsNot Nothing AndAlso TypeOf e.Value Is Decimal Then
        '                                         '    e.DisplayText = String.Format("{0:n2}", e.Value)
        '                                         'End If

        '                                     End Sub

        '    settings.PreRender = Sub(sender, e)
        '                             Dim PivotGrid As MVCxPivotGrid = TryCast(sender, MVCxPivotGrid)
        '                             If System.Web.HttpContext.Current.Session("Layout") IsNot Nothing Then
        '                                 PivotGrid.LoadLayoutFromString(DirectCast(System.Web.HttpContext.Current.Session("Layout"), String), PivotGridWebOptionsLayout.DefaultLayout)
        '                             End If
        '                             PivotGrid.CollapseAll()

        '                         End Sub
        '    settings.GridLayout = Sub(sender, e)
        '                              Dim PivotGrid As MVCxPivotGrid = TryCast(sender, MVCxPivotGrid)
        '                              System.Web.HttpContext.Current.Session("Layout") = PivotGrid.SaveLayoutToString(PivotGridWebOptionsLayout.DefaultLayout)

        '                          End Sub
        '    Return settings

        'End Function

        Private Shared Function CreateDataAwarePivotGridSettings() As GridViewSettings
            Dim settings As New GridViewSettings()
            Dim _user_name As String = GlobalClass.temp_user_name
            settings.Name = "VISIT_PRODUCT_PIVOT_REP"
            settings.CallbackRouteValues = New With {Key .Controller = "visit", Key .Action = "plan"}
            settings.SettingsExport.FileName = "VPPR" & _user_name & "_" & Now.ToString("ddMMyyyy HH:mm:ss")
            settings.SettingsExport.Styles.Cell.Font.Size = 9
            settings.SettingsExport.Styles.Header.Font.Size = 9
            settings.SettingsExport.MaxColumnWidth = 100
            settings.Columns.Add("bo") : settings.Columns(0).Caption = "BO"
            settings.Columns.Add("rep_name") : settings.Columns(1).Caption = "TI NAME"
            settings.Columns.Add("position") : settings.Columns(2).Caption = "POSITION"
            settings.Columns.Add("division") : settings.Columns(3).Caption = "DIVISION"
            settings.Columns.Add("bo") : settings.Columns(4).Caption = "BO"
            settings.Columns.Add("sbo") : settings.Columns(5).Caption = "SBO"
            settings.Columns.Add("rep_am") : settings.Columns(6).Caption = "REP AM"
            settings.Columns.Add("am") : settings.Columns(7).Caption = "AM"
            settings.Columns.Add("region") : settings.Columns(8).Caption = "REGION"
            settings.Columns.Add("rep_rm") : settings.Columns(9).Caption = "REP RM"
            settings.Columns.Add("rm") : settings.Columns(10).Caption = "RM"
            settings.Columns.Add("month") : settings.Columns(11).Caption = "MONTH"
            settings.Columns.Add("date_visit") : settings.Columns(12).Caption = "DATE"
            settings.Columns.Add("dr_code") : settings.Columns(13).Caption = "DR CODE"
            settings.Columns.Add("plan") : settings.Columns(14).Caption = "PLAN"
            settings.Columns.Add("info") : settings.Columns(15).Caption = "INFO"
            settings.Columns.Add("sp") : settings.Columns(16).Caption = "SP"
            settings.Columns.Add("sp_value") : settings.Columns(17).Caption = "SP VALUE"
            settings.Columns.Add("realization") : settings.Columns(18).Caption = "REALIZATION"
            settings.Columns.Add("dr_name") : settings.Columns(19).Caption = "DR NAME"
            settings.Columns.Add("spec") : settings.Columns(20).Caption = "SPEC"
            settings.Columns.Add("sub_spec") : settings.Columns(21).Caption = "SUB SPEC"
            settings.Columns.Add("quadrant") : settings.Columns(22).Caption = "QUADRANT"
            settings.Columns.Add("monitoring") : settings.Columns(23).Caption = "MONITORING"
            settings.Columns.Add("dklk") : settings.Columns(24).Caption = "DKLK"
            settings.Columns.Add("area_mis") : settings.Columns(25).Caption = "AREA MIS"
            settings.Columns.Add("category") : settings.Columns(26).Caption = "CATEGORY"
            settings.Columns.Add("channel") : settings.Columns(27).Caption = "CHANNEL"
            settings.Columns.Add("TAN") : settings.Columns(27).Caption = "TAN"
            settings.Columns.Add("HER_CD") : settings.Columns(27).Caption = "HER_CD"
            settings.Columns.Add("HER_INJ") : settings.Columns(27).Caption = "HER_INJ"
            settings.Columns.Add("LIV") : settings.Columns(27).Caption = "LIV"
            settings.Columns.Add("MAIN") : settings.Columns(27).Caption = "MAIN"
            settings.Columns.Add("TAON") : settings.Columns(27).Caption = "TAON"
            settings.Columns.Add("ADO") : settings.Columns(27).Caption = "ADO"
            settings.Columns.Add("ASP_K") : settings.Columns(27).Caption = "ASP_K"
            settings.Columns.Add("INO") : settings.Columns(27).Caption = "INO"
            settings.Columns.Add("OTHERS") : settings.Columns(27).Caption = "OTHERS"
            settings.Columns.Add("REMICADE") : settings.Columns(27).Caption = "REMICADE"
            settings.Columns.Add("SIMPONI") : settings.Columns(27).Caption = "SIMPONI"
            settings.Columns.Add("TAN_BPJS") : settings.Columns(27).Caption = "TAN_BPJS"
            settings.Columns.Add("HERCD_BPJS") : settings.Columns(27).Caption = "HERCD_BPJS"
            settings.Columns.Add("HERINJ_BPJS") : settings.Columns(27).Caption = "HERINJ_BPJS"

            For i = 0 To 42 Step 1
                settings.Columns(i).ExportWidth = 75
            Next
            Return settings
        End Function

    End Class
End Namespace



'Imports DevExpress.Web.Mvc
'Imports DevExpress.Web.ASPxPivotGrid
'Imports DevExpress.XtraPivotGrid
'Public Class PivotGridHelper
'    Shared _settings As PivotGridSettings
'    Public Shared ReadOnly Property Settings() As PivotGridSettings
'        Get
'            If _settings Is Nothing Then
'                _settings = GetSettings()
'            End If
'            Return _settings
'        End Get
'    End Property
'    Private Shared Function GetSettings() As PivotGridSettings
'        Dim settings As New PivotGridSettings()
'        settings.Name = "PivotGrid"
'        settings.CallbackRouteValues = New With { _
'            Key .Controller = "Home", _
'            Key .Action = "PivotGridPartial" _
'        }
'        settings.OptionsView.ShowHorizontalScrollBar = True
'        settings.Width = New System.Web.UI.WebControls.Unit(90, System.Web.UI.WebControls.UnitType.Percentage)


'        settings.Fields.Add(Function(field)
'                                      field.FieldName = "ExtendedPrice"
'                                      field.Area = PivotArea.DataArea
'                                      field.ID = "field" & Convert.ToString(field.FieldName)

'                                  End Function)
'        settings.Fields.Add(Function(field)
'                                      field.FieldName = "Quantity"
'                                      field.Area = PivotArea.DataArea
'                                      field.ID = "field" & Convert.ToString(field.FieldName)

'                                  End Function)
'        settings.Fields.Add(Function(field)
'                                      field.FieldName = "Freight"
'                                      field.Area = PivotArea.DataArea
'                                      field.ID = "field" & Convert.ToString(field.FieldName)

'                                  End Function)
'        settings.Fields.Add(Function(field)
'                                      field.FieldName = "Country"
'                                      field.Area = PivotArea.ColumnArea
'                                      field.ID = "field" & Convert.ToString(field.FieldName)

'                                  End Function)
'        settings.Fields.Add(Function(field)
'                                      field.FieldName = "City"
'                                      field.Area = PivotArea.ColumnArea
'                                      field.ID = "field" & Convert.ToString(field.FieldName)

'                                  End Function)
'        settings.Fields.Add(Function(field)
'                                      field.Area = PivotArea.RowArea
'                                      field.FieldName = "OrderDate"
'                                      field.GroupInterval = PivotGroupInterval.DateYear
'                                      field.ID = "fieldYear"
'                                      field.UnboundFieldName = "DateYear"
'                                      field.Caption = "Year"

'                                  End Function)
'        settings.Fields.Add(Function(field)
'                                      field.Area = PivotArea.RowArea
'                                      field.FieldName = "OrderDate"
'                                      field.GroupInterval = PivotGroupInterval.DateMonth
'                                      field.ID = "fieldMonth"
'                                      field.UnboundFieldName = "DateMonth"
'                                      field.Caption = "Month"

'                                  End Function)
'        settings.Fields.Add(Function(field)
'                                      field.Area = PivotArea.RowArea
'                                      field.FieldName = "OrderDate"
'                                      field.GroupInterval = PivotGroupInterval.[Date]
'                                      field.ID = "fieldDate"
'                                      field.UnboundFieldName = "Date"
'                                      field.Caption = "Date"

'                                  End Function)

'        settings.PreRender = Function(sender, e)
'                                       Dim PivotGrid As MVCxPivotGrid = TryCast(sender, MVCxPivotGrid)
'                                       If System.Web.HttpContext.Current.Session("Layout") IsNot Nothing Then
'                                           PivotGrid.LoadLayoutFromString(DirectCast(System.Web.HttpContext.Current.Session("Layout"), String), PivotGridWebOptionsLayout.DefaultLayout)
'                                       End If
'                                       PivotGrid.CollapseAll()

'                                   End Function
'        settings.GridLayout = Function(sender, e)
'                                        Dim PivotGrid As MVCxPivotGrid = TryCast(sender, MVCxPivotGrid)
'                                        System.Web.HttpContext.Current.Session("Layout") = PivotGrid.SaveLayoutToString(PivotGridWebOptionsLayout.DefaultLayout)

'                                    End Function
'        Return settings
'    End Function
'End Class

