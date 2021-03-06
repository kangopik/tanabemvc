﻿
@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "detailGrid_" + ViewData("dr_code")
                                settings.SettingsDetail.MasterGridName = "grid"
                                settings.CallbackRouteValues = New With {Key .Controller = "VisitActual", Key .Action = "MasterDetailPartial", Key .visit_id = ViewData("visit_id")}
                                settings.Width = Unit.Percentage(50)
                                settings.Styles.Cell.Font.Size = 8
                                settings.Styles.Header.Font.Size = 8
                                settings.Styles.GroupRow.Font.Size = 8
                                settings.Styles.Footer.Font.Size = 8
                                settings.Styles.Header.HorizontalAlign = HorizontalAlign.Center
                                     
                                settings.KeyFieldName = "dr_code"
                                settings.Columns.Add("vd_id")
                                settings.Columns.Add("visit_id")
                                settings.Columns.Add("visit_code")
                                settings.Columns.Add("visit_team")
                                settings.Columns.Add("visit_product")
                                settings.Columns.Add("visit_category")
                                settings.Columns.Add("vd_value")
                                settings.Columns(0).Caption = "VD ID"
                                settings.Columns(1).Caption = "VISIT ID"
                                settings.Columns(2).Caption = "CODE"
                                settings.Columns(3).Caption = "TEAM"
                                settings.Columns(4).Caption = "PRODUCT"
                                settings.Columns(5).Caption = "CATEGORY"
                                settings.Columns(6).Caption = "VD VALUE"
                                     
                                For i As Integer = 0 To 6
                                    settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                    settings.Columns(i).CellStyle.VerticalAlign = VerticalAlign.Middle
                                Next
                            End Sub).Bind(Model).GetHtml()
