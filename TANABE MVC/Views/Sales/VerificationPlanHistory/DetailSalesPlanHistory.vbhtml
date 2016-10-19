@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "detailGrid_" + ViewData("sales_id")
                                settings.SettingsDetail.MasterGridName = "grid"
                                settings.Width = Unit.Percentage(100)
                                settings.CallbackRouteValues = New With {Key .Controller = "SalesPlanHistoryVerification", Key .Action = "DetailSalesPlanHistory", Key .sales_id = ViewData("sales_id")}
                                settings.Styles.EmptyDataRow.CssClass = "HideEmptyDataRow"
                                settings.Styles.Header.Font.Size = 8
                                settings.Styles.Header.Font.Bold = True
                                settings.Styles.Cell.Font.Size = 7
                                settings.Styles.InlineEditCell.Font.Size = 8
                                settings.KeyFieldName = "sp_id"
                                     settings.Columns.Add("sp_id")
                                settings.Columns.Add("prd_name")
                                settings.Columns.Add("prd_category")
                                settings.Columns.Add("prd_price")
                                settings.Columns.Add("sp_target_qty")
                                settings.Columns.Add("sp_target_value")
                                settings.Columns.Add("sp_sales_qty")
                                settings.Columns.Add("sp_sales_value")
                                settings.Columns.Add("sp_note")
                                settings.Columns(0).Caption = "sp_id"
                                settings.Columns(1).Caption = "PRODUCT"
                                settings.Columns(2).Caption = "CATEGORY"
                                settings.Columns(3).Caption = "PRICE"
                                settings.Columns(4).Caption = "TARGET QTY."
                                settings.Columns(5).Caption = "TARGET VALUE"
                                settings.Columns(6).Caption = "SALES QTY"
                                settings.Columns(7).Caption = "SALES VALUE"
                                settings.Columns(8).Caption = "NOTE"
                                settings.Columns(0).Visible = False
                                settings.Columns(1).Visible = True
                                settings.Columns(2).Visible = True
                                settings.Columns(3).Visible = True
                                settings.Columns(4).Visible = True
                                settings.Columns(5).Visible = True
                                settings.Columns(6).Visible = True
                                settings.Columns(7).Visible = True
                                settings.Columns(8).Visible = True
                                settings.Columns(0).VisibleIndex = 1
                                settings.Columns(1).VisibleIndex = 2
                                settings.Columns(2).VisibleIndex = 3
                                settings.Columns(3).VisibleIndex = 4
                                settings.Columns(4).VisibleIndex = 5
                                settings.Columns(5).VisibleIndex = 6
                                settings.Columns(6).VisibleIndex = 7
                                settings.Columns(7).VisibleIndex = 8
                                settings.Columns(8).VisibleIndex = 8
                                settings.Columns(0).Width = Unit.Pixel(200)
                                settings.Columns(1).Width = Unit.Pixel(200)
                                settings.Columns(2).Width = Unit.Pixel(75)
                                settings.Columns(3).Width = Unit.Pixel(75)
                                settings.Columns(4).Width = Unit.Pixel(40)
                                settings.Columns(5).Width = Unit.Pixel(40)
                                settings.Columns(6).Width = Unit.Pixel(40)
                                settings.Columns(7).Width = Unit.Pixel(40)
                                settings.Columns(8).Width = Unit.Pixel(150)
                            End Sub).Bind(Model).GetHtml()
