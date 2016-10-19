Imports System.Data.SqlClient
Imports DevExpress.XtraPivotGrid
Imports DevExpress.Web.Mvc
Imports DevExpress.Utils
Imports DevExpress.XtraPivotGrid.Customization
Imports DevExpress.Web.ASPxPivotGrid

Public Class PivotGridLayout
    Shared compactVisitOnlyPivotRepGridSettings As PivotGridSettings
    Shared compactVisitProductPivotRepGridSettings As PivotGridSettings
    Shared compactSalesPivotRepGridSettings As PivotGridSettings

#Region "Pivot Visit Only Rep"
    Public Shared ReadOnly Property VisitOnlyPivotGridSettings() As PivotGridSettings
        Get
            If compactVisitOnlyPivotRepGridSettings Is Nothing Then
                compactVisitOnlyPivotRepGridSettings = CreateLayoutVisitOnlyPivotRepGridSettings()
            End If
            Return compactVisitOnlyPivotRepGridSettings
        End Get
    End Property

    Private Shared Function CreateLayoutVisitOnlyPivotRepGridSettings() As PivotGridSettings
        Dim settings As New PivotGridSettings()
        settings.Name = "VisitOnlyPivotRep"
        settings.Width = Unit.Percentage(100)
        settings.CallbackRouteValues = New With { _
            Key .Controller = "VisitOnlyPivotRep", _
            Key .Action = "VisitOnlyPivotRepPartialView" _
        }
        'settings.OptionsPager.NumericButtonCount = 7
        'settings.OptionsPager.RowsPerPage = 15
        settings.OptionsView.HorizontalScrollBarMode = Global.DevExpress.Web.ScrollBarMode.Auto
        settings.OptionsView.RowTotalsLocation = PivotRowTotalsLocation.Far
        settings.OptionsView.ShowGrandTotalsForSingleValues = True
        settings.OptionsView.ShowRowGrandTotals = True
        settings.OptionsView.ShowRowTotals = False
        settings.OptionsView.ShowTotalsForSingleValues = False
        'settings.OptionsView.ShowColumnHeaders = False
        'settings.OptionsView.ShowDataHeaders = False
        settings.OptionsView.ShowFilterHeaders = True
        'settings.OptionsView.ShowRowHeaders = False
        settings.ClientSideEvents.Init = "function(s, e) { s.PerformCallback(); }"

        settings.Styles.FieldValueStyle.Wrap = DefaultBoolean.False
        settings.Styles.HeaderStyle.Font.Size = 7
        settings.Styles.CellStyle.Font.Size = 7
        settings.Styles.ColumnAreaStyle.Font.Size = 7
        settings.Styles.RowAreaStyle.Font.Size = 7
        settings.Styles.FieldValueGrandTotalStyle.Font.Size = 7
        settings.Styles.GrandTotalCellStyle.Font.Size = 7

        settings.PivotCustomizationExtensionSettings.Name = "pivotCustomization"
        settings.PivotCustomizationExtensionSettings.AllowedLayouts = CustomizationFormAllowedLayouts.BottomPanelOnly1by4 Or CustomizationFormAllowedLayouts.BottomPanelOnly2by2 Or CustomizationFormAllowedLayouts.StackedDefault Or CustomizationFormAllowedLayouts.StackedSideBySide
        settings.PivotCustomizationExtensionSettings.Layout = CustomizationFormLayout.BottomPanelOnly2by2
        settings.PivotCustomizationExtensionSettings.AllowSort = True
        settings.PivotCustomizationExtensionSettings.AllowFilter = True
        settings.PivotCustomizationExtensionSettings.Height = Unit.Pixel(480)
        settings.PivotCustomizationExtensionSettings.Width = Unit.Pixel(250)



        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.RowArea
                                field.FieldName = "rep_name"
                                field.Caption = "TI NAME"
                                field.AreaIndex = 1
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "position"
                                field.Caption = "POSITION"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "division"
                                field.Caption = "DIVISION"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "bo"
                                field.Caption = "BO"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "sbo"
                                field.Caption = "SBO"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "rep_am"
                                field.Caption = "REP AM"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.RowArea
                                field.FieldName = "am"
                                field.Caption = "AM"
                                field.AreaIndex = 0
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.RowArea
                                field.FieldName = "region"
                                field.Caption = "REGION"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "rep_rm"
                                field.Caption = "REP RM"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "rm"
                                field.Caption = "RM"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "month"
                                field.Caption = "MONTH"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.RowArea
                                field.FieldName = "date_visit"
                                field.Caption = "DATE"
                                field.Visible = True
                                field.AreaIndex = 2
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dr_code"
                                field.Caption = "DR CODE"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.DataArea
                                field.FieldName = "plan"
                                field.Caption = "PLAN"
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "info"
                                field.Caption = "INFO"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "sp"
                                field.Caption = "SP"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "sp_value"
                                field.Caption = "SP VALUE"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.DataArea
                                field.FieldName = "realization"
                                field.Caption = "REAL"
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "doc_name"
                                field.Caption = "DR NAME"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "spec"
                                field.Caption = "SPEC"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "sub_spec"
                                field.Caption = "SUB SPEC"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "quadrant"
                                field.Caption = "QUADRANT"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "monitoring"
                                field.Caption = "MONITORING"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dklk"
                                field.Caption = "DKLK"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "area_mis"
                                field.Caption = "AREA MIS"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "category"
                                field.Caption = "CTGY"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "channel"
                                field.Caption = "CHANNEL"
                                field.Visible = False
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
                                             Dim planField As DevExpress.Web.ASPxPivotGrid.PivotGridField = pivotGrid.Fields("plan")
                                             Dim plan As Object = e.GetCellValue(planField)
                                             Dim realField As DevExpress.Web.ASPxPivotGrid.PivotGridField = pivotGrid.Fields("realization")
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

                                             '---------------
                                             'If e.Value IsNot Nothing AndAlso TypeOf e.Value Is Decimal Then
                                             '    e.DisplayText = String.Format("{0:n2}", e.Value)
                                             'End If

                                         End Sub

        'settings.PreRender = Sub(sender, e)
        '                         Dim pivotGrid As MVCxPivotGrid = DirectCast(sender, MVCxPivotGrid)
        '                         pivotGrid.CollapseAll()
        '                         pivotGrid.ExpandValue(False, New Object() {"UK"})
        '                         pivotGrid.ExpandValue(False, New Object() {"UK", "Condiments"})
        '                         pivotGrid.ExpandValue(False, New Object() {"UK", "Condiments", "Chef Anton's Cajun Seasoning"})
        '                         pivotGrid.ExpandValue(False, New Object() {"UK", "Condiments", "Chef Anton's Cajun Seasoning", "Robert King"})
        '                         pivotGrid.ExpandValue(False, New Object() {"UK", "Condiments", "Chef Anton's Cajun Seasoning", "Robert King", 1996})
        '                         pivotGrid.ExpandValue(False, New Object() {"UK", "Condiments", "Chef Anton's Cajun Seasoning", "Robert King", 1997})
        '                         pivotGrid.ExpandValue(False, New Object() {"UK", "Condiments", "Genen Shouyu"})
        '                         pivotGrid.ExpandValue(False, New Object() {"UK", "Condiments", "Genen Shouyu", "Michael Suyama"})

        '                     End Sub

        Return settings
    End Function
#End Region

#Region "Pivot Visit Product Rep"
    Public Shared ReadOnly Property VisitProductPivotRepGridSettings() As PivotGridSettings
        Get
            If compactVisitProductPivotRepGridSettings Is Nothing Then
                compactVisitProductPivotRepGridSettings = CreateLayoutVisitProductPivotRepGridSettings()
            End If
            Return compactVisitProductPivotRepGridSettings
        End Get
    End Property

    Private Shared Function CreateLayoutVisitProductPivotRepGridSettings() As PivotGridSettings
        Dim settings As New PivotGridSettings()
        settings.Name = "VisitProductPivotRep"
        settings.Width = Unit.Percentage(100)
        settings.CallbackRouteValues = New With { _
            Key .Controller = "VisitProductPivotRep", _
            Key .Action = "VisitProductPivotRepPartialView" _
        }
        'settings.OptionsPager.NumericButtonCount = 7
        'settings.OptionsPager.RowsPerPage = 15
        settings.OptionsView.HorizontalScrollBarMode = Global.DevExpress.Web.ScrollBarMode.Auto
        settings.OptionsView.RowTotalsLocation = PivotRowTotalsLocation.Far
        settings.OptionsView.ShowGrandTotalsForSingleValues = True
        settings.OptionsView.ShowRowGrandTotals = True
        settings.OptionsView.ShowRowTotals = False
        settings.OptionsView.ShowTotalsForSingleValues = False
        'settings.OptionsView.ShowColumnHeaders = False
        'settings.OptionsView.ShowDataHeaders = False
        settings.OptionsView.ShowFilterHeaders = True
        'settings.OptionsView.ShowRowHeaders = False

        settings.ClientSideEvents.Init = "function(s, e) { s.PerformCallback(); }"

        settings.Styles.FieldValueStyle.Wrap = DefaultBoolean.False
        settings.Styles.HeaderStyle.Font.Size = 7
        settings.Styles.CellStyle.Font.Size = 7
        settings.Styles.ColumnAreaStyle.Font.Size = 7
        settings.Styles.RowAreaStyle.Font.Size = 7
        settings.Styles.FieldValueGrandTotalStyle.Font.Size = 7
        settings.Styles.GrandTotalCellStyle.Font.Size = 7

        settings.PivotCustomizationExtensionSettings.Name = "pivotCustomization"
        settings.PivotCustomizationExtensionSettings.AllowedLayouts = CustomizationFormAllowedLayouts.BottomPanelOnly1by4 Or CustomizationFormAllowedLayouts.BottomPanelOnly2by2 Or CustomizationFormAllowedLayouts.StackedDefault Or CustomizationFormAllowedLayouts.StackedSideBySide
        settings.PivotCustomizationExtensionSettings.Layout = CustomizationFormLayout.BottomPanelOnly2by2
        settings.PivotCustomizationExtensionSettings.AllowSort = True
        settings.PivotCustomizationExtensionSettings.AllowFilter = True
        settings.PivotCustomizationExtensionSettings.Height = Unit.Pixel(480)
        settings.PivotCustomizationExtensionSettings.Width = Unit.Pixel(250)

        settings.Fields.Add(Sub(field)
                                field.ID = "reg"
                                field.Area = PivotArea.RowArea
                                field.FieldName = "region"
                                field.Caption = "REGION"
                                field.AreaIndex = 0
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "cam"
                                field.Area = PivotArea.RowArea
                                field.FieldName = "am"
                                field.Caption = "AM"
                                field.AreaIndex = 1
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "3"
                                field.Area = PivotArea.RowArea
                                field.FieldName = "rep_name"
                                field.Caption = "TI NAME"
                                field.AreaIndex = 2
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "4"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "position"
                                field.Caption = "POSITION"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "5"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "division"
                                field.Caption = "DIVISION"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "6"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "bo"
                                field.Caption = "BO"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "7"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "sbo"
                                field.Caption = "SBO"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "8"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "rep_am"
                                field.Caption = "REP AM"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "9"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "rep_rm"
                                field.Caption = "REP RM"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "10"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "rm"
                                field.Caption = "RM"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "11"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "month"
                                field.Caption = "MONTH"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "12"
                                field.Area = PivotArea.RowArea
                                field.FieldName = "date_visit"
                                field.Caption = "DATE"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "13"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dr_code"
                                field.Caption = "DR CODE"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "14"
                                field.Area = PivotArea.DataArea
                                field.FieldName = "plan"
                                field.Caption = "PLAN"
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "15"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "info"
                                field.Caption = "INFO"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "16"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "sp"
                                field.Caption = "SP"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "17"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "sp_value"
                                field.Caption = "SP VALUE"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "18"
                                field.Area = PivotArea.DataArea
                                field.FieldName = "realization"
                                field.Caption = "REAL"
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "19"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dr_name"
                                field.Caption = "DR NAME"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "20"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "spec"
                                field.Caption = "SPEC"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "21"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "sub_spec"
                                field.Caption = "SUB SPEC"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "22"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "quadrant"
                                field.Caption = "QUADRANT"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "23"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "monitoring"
                                field.Caption = "MONITORING"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "24"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dklk"
                                field.Caption = "DKLK"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "25"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "area_mis"
                                field.Caption = "AREA MIS"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "26"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "category"
                                field.Caption = "CTGY"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "27"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "channel"
                                field.Caption = "CHANNEL"
                                field.Visible = False
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

        settings.Fields.Add(Sub(field)
                                field.ID = "28"
                                field.FieldName = "TAN"
                                field.Caption = "TAN"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "29"
                                field.FieldName = "HER_CD"
                                field.Caption = "HER_CD"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "30"
                                field.FieldName = "HER_INJ"
                                field.Caption = "HER_INJ"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "31"
                                field.FieldName = "LIV"
                                field.Caption = "LIV"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "32"
                                field.FieldName = "MAIN"
                                field.Caption = "MAIN"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "33"
                                field.FieldName = "TAON"
                                field.Caption = "TAON"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "34"
                                field.FieldName = "ADO"
                                field.Caption = "ADO"
                                field.Visible = False
                            End Sub)


        settings.Fields.Add(Sub(field)
                                field.ID = "35"
                                field.FieldName = "ASP_K"
                                field.Caption = "ASP_K"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "36"
                                field.FieldName = "INO"
                                field.Caption = "INO"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "37"
                                field.FieldName = "OTHERS"
                                field.Caption = "OTHERS"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "38"
                                field.FieldName = "REMICADE"
                                field.Caption = "REMICADE"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "39"
                                field.FieldName = "SIMPONI"
                                field.Caption = "SIMPONI"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "40"
                                field.FieldName = "TAN_BPJS"
                                field.Caption = "TAN_BPJS"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "41"
                                field.FieldName = "HERCD_BPJS"
                                field.Caption = "HERCD_BPJS"
                                field.Visible = False
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "42"
                                field.FieldName = "HERINJ_BPJS"
                                field.Caption = "HERINJ_BPJS"
                                field.Visible = False
                            End Sub)

        settings.CustomCellDisplayText = Sub(sender, e)
                                             Dim pivotGrid As MVCxPivotGrid = DirectCast(sender, MVCxPivotGrid)
                                             Dim planField As DevExpress.Web.ASPxPivotGrid.PivotGridField = pivotGrid.Fields("plan")
                                             Dim plan As Object = e.GetCellValue(planField)
                                             Dim realField As DevExpress.Web.ASPxPivotGrid.PivotGridField = pivotGrid.Fields("realization")
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

                                             '---------------
                                             'If e.Value IsNot Nothing AndAlso TypeOf e.Value Is Decimal Then
                                             '    e.DisplayText = String.Format("{0:n2}", e.Value)
                                             'End If

                                         End Sub

        settings.PreRender = Sub(sender, e)
                                 Dim PivotGrid As MVCxPivotGrid = DirectCast(sender, MVCxPivotGrid)
                                 If System.Web.HttpContext.Current.Session("Layout") IsNot Nothing Then
                                     PivotGrid.LoadLayoutFromString(DirectCast(System.Web.HttpContext.Current.Session("Layout"), String), PivotGridWebOptionsLayout.DefaultLayout)
                                 End If
                                 PivotGrid.ExpandAll()

                             End Sub

        settings.GridLayout = Sub(sender, e)
                                  Dim PivotGrid As MVCxPivotGrid = DirectCast(sender, MVCxPivotGrid)
                                  System.Web.HttpContext.Current.Session("Layout") = PivotGrid.SaveLayoutToString(PivotGridWebOptionsLayout.DefaultLayout)

                              End Sub

        Return settings
    End Function
#End Region

#Region "Sales Pivot Rep"
    Public Shared ReadOnly Property SalesPivotRepGridSettings() As PivotGridSettings
        Get
            If compactSalesPivotRepGridSettings Is Nothing Then
                compactSalesPivotRepGridSettings = CreateLayoutSalesPivotRepGridSettings()
            End If
            Return compactSalesPivotRepGridSettings
        End Get
    End Property

    Private Shared Function CreateLayoutSalesPivotRepGridSettings() As PivotGridSettings
        Dim settings As New PivotGridSettings()
        settings.Name = "SalesPivotRep"
        settings.Width = Unit.Percentage(100)
        settings.CallbackRouteValues = New With { _
            Key .Controller = "SalesPivotRep", _
            Key .Action = "SalesPivotRepPartialView" _
        }
        settings.CustomActionRouteValues = New With { _
            Key .Controller = "SalesPivotRep", _
            Key .Action = "SalesPivotRepCustomCallBack" _
        }
        'settings.OptionsPager.NumericButtonCount = 7
        'settings.OptionsPager.RowsPerPage = 15
        settings.OptionsView.HorizontalScrollBarMode = Global.DevExpress.Web.ScrollBarMode.Auto
        settings.OptionsView.RowTotalsLocation = PivotRowTotalsLocation.Far
        settings.OptionsView.ShowGrandTotalsForSingleValues = True
        settings.OptionsView.ShowRowGrandTotals = True
        settings.OptionsView.ShowRowTotals = False
        settings.OptionsView.ShowTotalsForSingleValues = False
        'settings.OptionsView.ShowColumnHeaders = False
        'settings.OptionsView.ShowDataHeaders = False
        settings.OptionsView.ShowFilterHeaders = True
        'settings.OptionsView.ShowRowHeaders = False

        'settings.ClientSideEvents.Init = "function(s, e) { s.PerformCallback(); }"
        settings.BeforePerformDataSelect = Sub(sender, e)
                                               Dim PivotGrid As MVCxPivotGrid = DirectCast(sender, MVCxPivotGrid)
                                               Dim layout As String = DirectCast(System.Web.HttpContext.Current.Session("Layout"), String)
                                               'Debug.WriteLine("Is layout empty? " & String.IsNullOrEmpty(layout))
                                               If Not String.IsNullOrEmpty(layout) Then
                                                   PivotGrid.LoadLayoutFromString(layout, DevExpress.Web.ASPxPivotGrid.PivotGridWebOptionsLayout.DefaultLayout)
                                               End If
                                           End Sub
        settings.PreRender = Sub(sender, e)
                                 Dim PivotGrid As MVCxPivotGrid = DirectCast(sender, MVCxPivotGrid)
                                 If System.Web.HttpContext.Current.Session("Layout") IsNot Nothing Then
                                     PivotGrid.LoadLayoutFromString(DirectCast(System.Web.HttpContext.Current.Session("Layout"), String), PivotGridWebOptionsLayout.DefaultLayout)
                                 End If
                                 PivotGrid.ExpandAll()

                             End Sub


        settings.Styles.FieldValueStyle.Wrap = DefaultBoolean.False
        settings.Styles.HeaderStyle.Font.Size = 7
        settings.Styles.CellStyle.Font.Size = 7
        settings.Styles.ColumnAreaStyle.Font.Size = 7
        settings.Styles.RowAreaStyle.Font.Size = 7
        settings.Styles.FieldValueGrandTotalStyle.Font.Size = 7
        settings.Styles.GrandTotalCellStyle.Font.Size = 7

        settings.PivotCustomizationExtensionSettings.Name = "pivotCustomization"
        settings.PivotCustomizationExtensionSettings.AllowedLayouts = CustomizationFormAllowedLayouts.BottomPanelOnly1by4 Or CustomizationFormAllowedLayouts.BottomPanelOnly2by2 Or CustomizationFormAllowedLayouts.StackedDefault Or CustomizationFormAllowedLayouts.StackedSideBySide
        settings.PivotCustomizationExtensionSettings.Layout = CustomizationFormLayout.BottomPanelOnly2by2
        settings.PivotCustomizationExtensionSettings.AllowSort = True
        settings.PivotCustomizationExtensionSettings.AllowFilter = True
        settings.PivotCustomizationExtensionSettings.Height = Unit.Pixel(480)
        settings.PivotCustomizationExtensionSettings.Width = Unit.Pixel(250)

        settings.Fields.Add(Sub(field)
                                field.ID = "1"
                                field.Area = PivotArea.RowArea
                                field.FieldName = "rep_region"
                                field.Caption = "REGION"
                                field.AreaIndex = 0
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "2"
                                field.Area = PivotArea.RowArea
                                field.FieldName = "prd_name"
                                field.Caption = "PRODUCT"
                                field.AreaIndex = 1
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "3"
                                field.Area = PivotArea.DataArea
                                field.FieldName = "sp_target_qty"
                                field.Caption = "TARGET QTY"
                                field.AreaIndex = 0
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "4"
                                field.Area = PivotArea.DataArea
                                field.FieldName = "sp_target_value"
                                field.Caption = "TARGET VALUE"
                                field.AreaIndex = 1
                                field.CellFormat.FormatString = "n0"
                                field.CellFormat.FormatType = FormatType.Numeric
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "5"
                                field.Area = PivotArea.DataArea
                                field.FieldName = "sp_sales_qty"
                                field.Caption = "SALES QTY"
                                field.AreaIndex = 2
                                field.CellFormat.FormatString = "n0"
                                field.CellFormat.FormatType = FormatType.Numeric
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "6"
                                field.Area = PivotArea.DataArea
                                field.FieldName = "sp_sales_value"
                                field.Caption = "SALES VALUE"
                                field.AreaIndex = 3
                                field.CellFormat.FormatString = "n0"
                                field.CellFormat.FormatType = FormatType.Numeric
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "7"
                                field.Area = PivotArea.DataArea
                                field.FieldName = "sp_plan"
                                field.Caption = "USER PLAN"
                                field.AreaIndex = 4
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "8"
                                field.Area = PivotArea.DataArea
                                field.FieldName = "sp_real"
                                field.Caption = "USER REAL"
                                field.AreaIndex = 5
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "9"
                                field.Area = PivotArea.RowArea
                                field.FieldName = "dr_name"
                                field.Caption = "DR NAME"
                                field.AreaIndex = 2
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "Percent"
                                field.Area = PivotArea.DataArea
                                field.FieldName = ""
                                field.Caption = "PROD ACHV"
                                field.AreaIndex = 6
                                field.CellFormat.FormatString = "p"
                            End Sub)

        settings.Fields.Add(Sub(field)
                                field.ID = "10"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "prd_price"
                                field.Caption = "PRICE"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "11"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "sales_date_plan"
                                field.Caption = "MONTH"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "12"
                                field.Area = PivotArea.RowArea
                                field.FieldName = "sales_year_plan"
                                field.Caption = "YEAR"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "13"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dr_code"
                                field.Caption = "DR CODE"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "14"
                                field.Area = PivotArea.DataArea
                                field.FieldName = "prd_code"
                                field.Caption = "PROD CODE"
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "15"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "sales_plan"
                                field.Caption = "SALES PLAN"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "16"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "sales_realization"
                                field.Caption = "SALES REAL"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "17"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dr_spec"
                                field.Caption = "SPEC"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "18"
                                field.Area = PivotArea.DataArea
                                field.FieldName = "dr_sub_spec"
                                field.Caption = "SUB SPEC"
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "19"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dr_quadrant"
                                field.Caption = "QUADRANT"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "20"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dr_monitoring"
                                field.Caption = "MONITORING"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "21"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dr_dk_lk"
                                field.Caption = "DK/LK"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "22"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dr_area_mis"
                                field.Caption = "AREA MIS"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "23"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dr_category"
                                field.Caption = "CATEGORY"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "24"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "prd_category"
                                field.Caption = "PRO CTGY"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "25"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "dr_chanel"
                                field.Caption = "CHANNEL"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "26"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "rep_name"
                                field.Caption = "TI NAME"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "27"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "rep_position"
                                field.Caption = "POSITION"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "28"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "rep_division"
                                field.Caption = "DIVISION"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "29"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "rep_sbo"
                                field.Caption = "SBO"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "30"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "nama_am"
                                field.Caption = "AM"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "31"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "rep_bo"
                                field.Caption = "BO"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "32"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "nama_rm"
                                field.Caption = "RM"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "33"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "target_class_user"
                                field.Caption = "TARGET CLASS USER"
                                field.Visible = False
                            End Sub)
        settings.Fields.Add(Sub(field)
                                field.ID = "34"
                                field.Area = PivotArea.FilterArea
                                field.FieldName = "real_class_user"
                                field.Caption = "REAL CLASS USER"
                                field.Visible = False
                            End Sub)


        settings.CustomCellDisplayText = Sub(sender, e)
                                             Dim pivotGrid As MVCxPivotGrid = DirectCast(sender, MVCxPivotGrid)
                                             Dim planField As DevExpress.Web.ASPxPivotGrid.PivotGridField = pivotGrid.Fields("sp_plan")
                                             Dim plan As Object = e.GetCellValue(planField)
                                             Dim realField As DevExpress.Web.ASPxPivotGrid.PivotGridField = pivotGrid.Fields("sp_real")
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
                                         End Sub



        settings.GridLayout = Sub(sender, e)
                                  Dim PivotGrid As MVCxPivotGrid = DirectCast(sender, MVCxPivotGrid)
                                  System.Web.HttpContext.Current.Session("Layout") = PivotGrid.SaveLayoutToString(PivotGridWebOptionsLayout.DefaultLayout)

                              End Sub

            Return settings
    End Function
#End Region
End Class
