@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "DataView1"
                                settings.CallbackRouteValues = New With {.Controller = "AuditVisitMonthly", .Action = "ViewAuditVisitMonthly"}
                                settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                                settings.SettingsPager.PageSize = 10
                                settings.Settings.ShowGroupPanel = True
                                settings.Settings.ShowFilterRow = True
                                settings.Settings.ShowFilterRowMenu = True
                                settings.SettingsBehavior.ConfirmDelete = True
                                settings.ControlStyle.Paddings.Padding = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.ControlStyle.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.ControlStyle.BorderBottom.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.Width = Unit.Percentage(100)
                                settings.Styles.Cell.Font.Size = 8
                                settings.Styles.Header.Font.Size = 8
                                settings.Styles.GroupRow.Font.Size = 8
                                settings.Styles.Footer.Font.Size = 8
                                settings.Styles.Header.HorizontalAlign = HorizontalAlign.Center
                                settings.CommandColumn.Visible = True
                                settings.CommandColumn.ShowSelectCheckbox = True
                                settings.CommandColumn.VisibleIndex = 0
                                settings.SettingsBehavior.AllowSelectByRowClick = True
                                     
                                settings.SettingsEditing.Mode = GridViewEditingMode.Inline
                                settings.SettingsBehavior.ConfirmDelete = True
                                settings.CommandColumn.Visible = False
                                settings.CommandColumn.ShowEditButton = False
                                     
                                settings.KeyFieldName = "ID"
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "nik"
                                                         column.Caption = "NIK"
                                                         column.ReadOnly = True
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "nama_rep"
                                                         column.Caption = "TI NAME"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "rep_position"
                                                         column.Caption = "POS"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "rep_sbo"
                                                         column.Caption = "SBO"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "rep_am"
                                                         column.Caption = "AM"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "jml_total_visit"
                                                         column.Caption = "TV"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "finished_visit"
                                                         column.Caption = "FV"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "jml_day_less_then"
                                                         column.Caption = "D < R"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "jml_plan_blm_verifikasi"
                                                         column.Caption = "VPNV"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "jml_plan_sdh_verifikasi"
                                                         column.Caption = "VPV"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "jml_visit_blm_realisasi"
                                                         column.Caption = "VNR"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "jml_realisasi_blm_verifikasi"
                                                         column.Caption = "VRNV"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "jml_dr_used_session"
                                                         column.Caption = "DRUS"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "jml_dr_planned_on_visit"
                                                         column.Caption = "DROV"
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "jml_dr_on_master"
                                                         column.Caption = "DROM"
                                                     End Sub)
                                settings.ClientSideEvents.Init = "function(s, e) { s.PerformCallback(); }"
                            End Sub).Bind(Model).GetHtml()
