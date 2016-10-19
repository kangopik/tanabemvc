@Html.DevExpress().GridLookup(Sub(settings)
                                  settings.Name = "GridLookup"
                                  settings.KeyFieldName = "visit_code"
                                  settings.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "VisitRealization", Key .Action = "GridLookupProductPartial"}
                                  settings.Properties.SelectionMode = GridLookupSelectionMode.Multiple
                                  settings.GridViewProperties.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords
                                  settings.GridViewProperties.Settings.VerticalScrollBarMode = ScrollBarMode.Auto
                                  settings.Properties.TextFormatString = "{0}"
                                  settings.Columns.Add("visit_code")
                                  settings.Columns.Add("visit_product")
                                  settings.Columns.Add("visit_team")
                                  settings.Columns.Add("visit_category")
                                  settings.Columns(0).Visible = False
                                  settings.Columns(1).Caption = "PRODUCT"
                                  settings.Columns(2).Caption = "TEAM"
                                  settings.Columns(3).Caption = "VISIT CATRGORY"
                              End Sub).BindList(Model).GetHtml()
    