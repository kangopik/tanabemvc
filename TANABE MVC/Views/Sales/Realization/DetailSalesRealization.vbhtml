@Html.DevExpress().GridView(Sub(settings)
                                     settings.Name = "detailGrid_" + ViewData("sp_id")
                                settings.SettingsDetail.MasterGridName = "grid"
                                settings.Width = Unit.Percentage(100)
                                settings.CallbackRouteValues = New With {Key .Controller = "SalesRealization", Key .Action = "DetailSalesRealization", Key .sp_id = ViewData("sp_id")}
                                settings.Settings.ShowFooter = True
                                settings.Styles.EmptyDataRow.CssClass = "HideEmptyDataRow"
                                settings.Styles.Header.Font.Size = 8
                                settings.Styles.Header.Font.Bold = True
                                settings.Styles.Cell.Font.Size = 7
                                settings.Styles.InlineEditCell.Font.Size = 8
                                settings.KeyFieldName = "spa_id"
                                settings.Columns.Add("spa_id")
                                settings.Columns.Add("spa_date")
                                settings.Columns.Add("spa_quantity")
                                settings.Columns(0).Caption = "spa_id"
                                settings.Columns(1).Caption = "DATE"
                                settings.Columns(2).Caption = "QUANTITY"
                                settings.Columns(0).Visible = False
                                settings.Columns(1).Visible = True
                                settings.Columns(2).Visible = True
                                settings.Columns(0).VisibleIndex = 1
                                settings.Columns(1).VisibleIndex = 2
                                settings.Columns(2).VisibleIndex = 3
                                settings.Columns(0).Width = Unit.Pixel(200)
                                settings.Columns(1).Width = Unit.Pixel(150)
                                settings.Columns(2).Width = Unit.Pixel(75)
                                     settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "spa_quantity")
                                     
                            End Sub).Bind(Model).GetHtml()
