@Html.DevExpress().GridLookup(Sub(productlist)
                                  productlist.Name = "GridLookup"
                                  productlist.Properties.Caption = "Visit Code"
                                  productlist.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                  productlist.KeyFieldName = "visit_code"
                                  productlist.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "VisitRealization", Key .Action = "LoadRealProduct"}
                                  productlist.Properties.SelectionMode = GridLookupSelectionMode.Multiple
                                  productlist.Properties.TextFormatString = "{0}"
                                  productlist.GridViewProperties.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords
                                  productlist.GridViewProperties.Settings.VerticalScrollBarMode = ScrollBarMode.Auto
                                  productlist.Width = Unit.Pixel(250)
                                  productlist.Properties.MultiTextSeparator = ", "

                                  productlist.Columns.Add("visit_code")
                                  productlist.Columns.Add("visit_product")
                                  productlist.Columns.Add("visit_team")
                                  productlist.Columns.Add("visit_category")

                                  productlist.Columns(0).Visible = False
                                  productlist.Columns(1).Caption = "PRODUCT"
                                  productlist.Columns(2).Caption = "TEAM"
                                  productlist.Columns(3).Caption = "VISIT CATRGORY"

                                  productlist.Columns(1).Width = Unit.Pixel(100)
                                  productlist.Columns(2).Width = Unit.Pixel(100)
                                  productlist.Columns(3).Width = Unit.Pixel(100)

                                  productlist.GridViewStyles.Cell.Font.Size = 7
                                  productlist.GridViewStyles.Header.Font.Size = 7
                                  productlist.CommandColumn.ShowSelectCheckbox = True
                                  productlist.CommandColumn.Visible = True
                                  productlist.CommandColumn.SelectAllCheckboxMode = GridViewSelectAllCheckBoxMode.AllPages

                              End Sub).BindList(Model).GetHtml()