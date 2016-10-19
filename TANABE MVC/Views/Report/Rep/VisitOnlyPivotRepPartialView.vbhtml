@Html.DevExpress().PivotGrid(TANABE_MVC.PivotGridLayout.VisitOnlyPivotGridSettings).Bind(Model).GetHtml()

@*@Html.DevExpress().PivotGrid(
    Sub(settings)
            settings.Name = "VisitOnlyPivotRep"
            settings.CallbackRouteValues = New With {Key .Controller = "rptVisitOnlyPivotRep", Key .Action = "VisitOnlyPivotRepPartialView"}
            'settings.PivotCustomizationExtensionSettings.Name = "CustomVisitOnlyPivotRep"
            'settings.PivotCustomizationExtensionSettings.AllowedLayouts = Customization.CustomizationFormAllowedLayouts.All
            'settings.PivotCustomizationExtensionSettings.Layout = Customization.CustomizationFormLayout.BottomPanelOnly2by2
            'settings.PivotCustomizationExtensionSettings.AllowSort = True
            'settings.PivotCustomizationExtensionSettings.AllowFilter = True
            'settings.PivotCustomizationExtensionSettings.Height = Unit.Pixel(480)
            'settings.PivotCustomizationExtensionSettings.Width = Unit.Pixel(350)
            
            settings.Fields.Add(Sub(field)
                                        field.Area = PivotArea.RowArea
                                        field.FieldName = "rep_name"
                                        field.Caption = "TI NAME"
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
                                End Sub)
            settings.Fields.Add(Sub(field)
                                        field.Area = PivotArea.RowArea
                                        field.FieldName = "region"
                                        field.Caption = "REGION"
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
                                        field.Visible = False
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
    End Sub).Bind(Model).GetHtml()*@

@*@Html.DevExpress().RoundPanel(
        Sub(settings)
                settings.Name = "roundPanel"
                settings.CornerRadius = 0
                settings.HeaderText = "Complex Pivot Table"
                settings.Width = Unit.Percentage(100)
                settings.SetContent(
                    Sub()
                            ViewContext.Writer.Write("<div><div style="" float:left; padding-right:10px;"">")
                            'Html.DevExpress().PivotGrid(TANABE_MVC.PivotGridLayout.CompactLayoutPivotGridSettings).Render()
                            settings.SetContent(Sub() Html.RenderPartial("CompactLayoutPartial"))
                            ViewContext.Writer.Write("</div><div>")
                            Html.DevExpress().PivotCustomizationExtension(TANABE_MVC.PivotGridLayout.CompactLayoutPivotGridSettings).Render()
                            ViewContext.Writer.Write("</div></div>")

                    End Sub)

        End Sub).GetHtml()*@