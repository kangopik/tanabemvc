@Html.DevExpress().GridLookup(
                Sub(productlist)
                        productlist.Name = "gridLookupPlannedVisit"
                        productlist.Properties.Caption = "Planed Visit"
                        productlist.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                        productlist.KeyFieldName = "visit_id"
                        productlist.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "VisitRealization", Key .Action = "LoadDoctorPlaned"}
                        productlist.Properties.SelectionMode = GridLookupSelectionMode.Multiple
                        productlist.Properties.TextFormatString = "{0}"
                        productlist.GridViewProperties.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords
                        productlist.GridViewProperties.Settings.VerticalScrollBarMode = ScrollBarMode.Auto
                        productlist.Width = Unit.Pixel(215)
                        productlist.Properties.MultiTextSeparator = ","

                        productlist.Columns.Add("visit_id")
                        productlist.Columns.Add("visit_date_plan")
                        productlist.Columns.Add("dr_code")
                        productlist.Columns.Add("dr_name")
                        productlist.Columns.Add("dr_quadrant")
                        productlist.Columns.Add("dr_monitoring")

                        productlist.GridViewClientSideEvents.SelectionChanged = "gridLookupPlannedVisit_SelectedChanges"


                        productlist.Columns(0).Caption = "VISIT ID"
                        productlist.Columns(1).Caption = "DATE"
                        productlist.Columns(2).Caption = "DR CODE"
                        productlist.Columns(3).Caption = "DR NAME"
                        productlist.Columns(4).Caption = "QRD"
                        productlist.Columns(5).Caption = "MONITORING"

                        productlist.Columns(0).Width = Unit.Pixel(80)
                        productlist.Columns(1).Width = Unit.Pixel(70)
                        productlist.Columns(2).Width = Unit.Pixel(80)
                        productlist.Columns(3).Width = Unit.Pixel(100)
                        productlist.Columns(4).Width = Unit.Pixel(40)
                        productlist.Columns(5).Width = Unit.Pixel(180)

                        productlist.GridViewStyles.Cell.Font.Size = 7
                        productlist.GridViewStyles.Header.Font.Size = 7
                        productlist.CommandColumn.ShowSelectCheckbox = True
                        productlist.CommandColumn.Visible = True
                        productlist.CommandColumn.SelectAllCheckboxMode = GridViewSelectAllCheckBoxMode.AllPages

                End Sub).BindList(Model).GetHtml()
