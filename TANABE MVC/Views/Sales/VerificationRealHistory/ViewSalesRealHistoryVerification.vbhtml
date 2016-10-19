@code
    Html.EnableClientValidation()
    Html.EnableUnobtrusiveJavaScript()

    Dim msg As String
    msg = TempData("msg")

End Code

@Html.DevExpress().GridView(Sub(grid)
                                grid.Name = "gridSalesRealHistoryVerification"
                                grid.CallbackRouteValues = New With {.Controller = "SalesRealHistoryVerification", .Action = "ViewSalesRealHistory"}
                                grid.CustomActionRouteValues = New With {.Controller = "SalesRealHistoryVerification", .Action = "ViewSalesRealHistoryCustomCallback"}
                                grid.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "SalesRealHistoryVerification", .Action = "DeleteVerification", .sales_id = ViewData("sales_id")}
                                grid.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "SalesRealHistoryVerification", .Action = "UpdateVerification"}
                                grid.ClientSideEvents.EndCallback = "gridSalesRealHistoryVerification_EndCallBack"
                                grid.ClientSideEvents.SelectionChanged = "SelectionChanged"
                                     
                                grid.KeyFieldName = "sp_id"
                                grid.Width = Unit.Percentage(100)
                                                                                            
                                grid.CommandColumn.VisibleIndex = 0
                                grid.CommandColumn.ShowSelectCheckbox = True
                                grid.CommandColumn.ShowClearFilterButton = True
                                grid.CommandColumn.ShowInCustomizationForm = True
                                grid.CommandColumn.Width = 30
                                                                                            
                                grid.SettingsContextMenu.Enabled = True
                                grid.SettingsContextMenu.RowMenuItemVisibility.EditRow = False
                                grid.SettingsContextMenu.RowMenuItemVisibility.NewRow = False
                                grid.SettingsDetail.ShowDetailRow = True
                                grid.SettingsDetail.ExportMode = GridViewDetailExportMode.All
                                grid.SettingsDetail.AllowOnlyOneMasterRowExpanded = True
                                grid.SettingsPager.PageSize = 20
                                grid.Settings.ShowGroupPanel = True
                                grid.Settings.ShowFooter = True
                                grid.SettingsEditing.Mode = GridViewEditingMode.PopupEditForm
                                grid.SettingsSearchPanel.Visible = True
                                grid.SettingsBehavior.AllowSelectByRowClick = False
                                grid.SettingsBehavior.ConfirmDelete = True
                                grid.SettingsBehavior.AllowFixedGroups = True
                                grid.SettingsBehavior.AutoExpandAllGroups = True
                                grid.Styles.EmptyDataRow.CssClass = "HideEmptyDataRow"
                                grid.Styles.Header.Font.Size = 8
                                grid.Styles.Header.Font.Bold = True
                                grid.Styles.Cell.Font.Size = 8
                                grid.Styles.InlineEditCell.Font.Size = 8
                                grid.SettingsPopup.EditForm.ShowHeader = False
                                grid.SettingsPopup.EditForm.Width = 400
                                grid.SettingsPopup.EditForm.MinHeight = 500
                                grid.SettingsPopup.EditForm.HorizontalAlign = PopupHorizontalAlign.Center
                                grid.SettingsPopup.EditForm.VerticalAlign = PopupVerticalAlign.TopSides
                                grid.SettingsPopup.EditForm.AllowResize = True
                                grid.SettingsPopup.EditForm.Modal = True
                                grid.SettingsPopup.CustomizationWindow.Width = Unit.Percentage(100)
                                grid.SettingsPopup.CustomizationWindow.HorizontalAlign = PopupHorizontalAlign.Center
                                grid.SettingsPopup.CustomizationWindow.VerticalAlign = PopupVerticalAlign.TopSides
                                                                                            
                                grid.Columns.Add(Sub(c)
                                                     c.Caption = "Action"
                                                     c.VisibleIndex = 1
                                                     c.Width = 50
                                                     c.EditFormSettings.VisibleIndex = 1
                                                     c.EditFormSettings.Visible = DefaultBoolean.False
                                                     c.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     c.SetDataItemTemplateContent(Sub(s)
                                                                                      Dim id = DataBinder.Eval(s.DataItem, "sales_id")
                                                                                      Html.DevExpress().Button(Sub(btnVerify)
                                                                                                                   btnVerify.Name = "btnVerify_" + s.KeyValue.ToString()
                                                                                                                   btnVerify.UseSubmitBehavior = True
                                                                                                                   btnVerify.Text = "UnVerify"
                                                                                                                   btnVerify.ControlStyle.Font.Size = 7
                                                                                                                   btnVerify.Attributes("v_sales_id") = id.ToString()
                                                                                                                   btnVerify.ClientSideEvents.Click = "verify_Grid"
                                                                                                                   TANABE_MVC.GlobalClass.temp_ver_visit_plan_visit_id = s.KeyValue.ToString()
                                                                                                                   btnVerify.ToolTip = "UnVerify " & s.KeyValue.ToString()
                                                                                                               End Sub).Render()
                                                                                  End Sub)
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sp_id"
                                                     column.Caption = "SP_ID"
                                                     column.Visible = False
                                                     column.VisibleIndex = 1
                                                     column.Width = 50
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.EditFormSettings.Visible = DefaultBoolean.False
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sales_id"
                                                     column.Caption = "SALES_ID"
                                                     column.Visible = True
                                                     column.VisibleIndex = 2
                                                     column.Width = 50
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.EditFormSettings.Visible = DefaultBoolean.False
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "dr_code"
                                                     column.Caption = "DR CODE"
                                                     column.VisibleIndex = 3
                                                     column.Width = 50
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.EditFormSettings.Visible = DefaultBoolean.False
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.ColumnType = MVCxGridViewColumnType.CheckBox
                                                     column.FieldName = "sales_plan_verification_status"
                                                     column.Caption = "Ver. Plan"
                                                     column.VisibleIndex = 4
                                                     column.Width = 60
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.ColumnType = MVCxGridViewColumnType.CheckBox
                                                     column.FieldName = "sales_realization"
                                                     column.Caption = "Sales Real"
                                                     column.VisibleIndex = 5
                                                     column.Width = 60
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.ColumnType = MVCxGridViewColumnType.CheckBox
                                                     column.FieldName = "sales_real_verification_status"
                                                     column.Caption = "Ver. Real"
                                                     column.VisibleIndex = 6
                                                     column.Width = 60
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "dr_name"
                                                     column.Caption = "DOCTOR NAME"
                                                     column.ShowInCustomizationForm = True
                                                     column.VisibleIndex = 7
                                                     column.Width = 250
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Left
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "dr_spec"
                                                     column.Caption = "SPEC"
                                                     column.ShowInCustomizationForm = True
                                                     column.VisibleIndex = 8
                                                     column.Width = 50
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.Name = "col_dr_code"
                                                     column.FieldName = "dr_quadrant"
                                                     column.Caption = "DR. QUADRANT"
                                                     column.VisibleIndex = 9
                                                     column.Width = 40
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                     column.Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "dr_monitoring"
                                                     column.Caption = "DR. MONITORING"
                                                     column.VisibleIndex = 10
                                                     column.Width = 250
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Left
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "prd_name"
                                                     column.Caption = "PRODUCT. NAME"
                                                     column.GroupIndex = 0
                                                     column.VisibleIndex = 11
                                                     column.Width = 250
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Left
                                                     column.Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "prd_price"
                                                     column.Caption = "PRICE"
                                                     column.VisibleIndex = 12
                                                     column.Width = 50
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Right
                                                     column.PropertiesEdit.DisplayFormatString = "N3"
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "prd_category"
                                                     column.Caption = "CATEGORY"
                                                     column.VisibleIndex = 13
                                                     column.Width = 50
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sp_target_qty"
                                                     column.Caption = "TARGET QTY"
                                                     column.VisibleIndex = 14
                                                     column.Width = 50
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sp_target_value"
                                                     column.Caption = "TARGET VALUE"
                                                     column.VisibleIndex = 15
                                                     column.Width = 50
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                                     column.PropertiesEdit.DisplayFormatString = "N0"
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sp_sales_qty"
                                                     column.Caption = "SALES QTY"
                                                     column.VisibleIndex = 16
                                                     column.Width = 50
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                 End Sub)
                                                                                            
                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sp_sales_value"
                                                     column.Caption = "SALES VALUE"
                                                     column.VisibleIndex = 17
                                                     column.Width = 50
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.PropertiesEdit.DisplayFormatString = "N0"
                                                 End Sub)
                                     
                                     grid.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "sp_target_qty")
                                     grid.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "sp_target_value")
                                     grid.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "sp_sales_qty")
                                     grid.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "sp_sales_value")
                                          
                                     
                                grid.BeforeGetCallbackResult = Sub(s, e)
                                                                   Dim g As MVCxGridView = DirectCast(s, MVCxGridView)
                                                                   g.ExpandAll()
                                                               End Sub
                                     
                                grid.CellEditorInitialize = Sub(s, e)
                                                                If (e.Column.Grid.IsNewRowEditing) Then
                                                                    If e.Column.FieldName = "sales_date_plan" Then
                                                                        e.Editor.Focus()
                                                                    End If
                                                                End If
                                                                If e.Column.FieldName = "sales_id" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "sales_plan_verification_status" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "sales_plan_verification_status" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "sales_id" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "dr_name" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "dr_spec" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "dr_sub_spec" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "dr_quadrant" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "dr_monitoring" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "dr_dk_lk" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "dr_area_mis" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "dr_category" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "dr_visit_category" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                                If e.Column.FieldName = "dr_chanel" Then
                                                                    e.Editor.ReadOnly = True
                                                                End If
                                                            End Sub
                                     
                                grid.SetDetailRowTemplateContent(Sub(c)
                                                                     ViewContext.Writer.Write("<div style='padding: 3px 3px 2px 3px'>")
                                                                     Html.DevExpress().PageControl(Sub(p)
                                                                                                       p.Name = "pageControl"
                                                                                                       p.ActiveTabIndex = 0
                                                                                                       p.Width = Unit.Pixel(800)
                                                                                                       p.TabPages.Add(Sub(tb)
                                                                                                                          tb.Visible = True
                                                                                                                          tb.Text = "ACTUAL SALES"
                                                                                                                          tb.SetContent(Sub()
                                                                                                                                            Html.RenderAction("DetailSalesRealHistory", New With {Key .sp_id = DataBinder.Eval(c.DataItem, "sp_id")})
                                                                                                                                        End Sub)
                                                                                                                      End Sub)
                                                                                                   End Sub).GetHtml()
                                                                     ViewContext.Writer.Write("</div>")
                                                                 End Sub)
                                     
                                grid.SetEditFormTemplateContent(Sub(c)
                                                                    ViewContext.Writer.Write("<div style='padding: 4px 4px 3px 4px;width:800px;'>")
                                                                    Html.DevExpress().PageControl(Sub(p)
                                                                                                      p.Name = "tabEdit"
                                                                                                      p.Width = Unit.Percentage(100)
                                                                                                      p.ShowTabs = False
                                                                                                      p.ActiveTabIndex = 0
                                                                                                      p.TabPages.Add(Sub(tb)
                                                                                                                         tb.Visible = True
                                                                                                                         Html.RenderAction("ViewEditForm", New With {.sales_id = DataBinder.Eval(c.DataItem, "sales_id")})
                                                                                                                     End Sub)
                                                                                                  End Sub).GetHtml()
                                                                    ViewContext.Writer.Write("</div>")
                                                                    ViewContext.Writer.Write("</div>")
                                                                    ViewContext.Writer.Write("<div id='div3'  style='float:left;margin-left:650px;margin-top:2px;'>")
                                                                    Html.DevExpress().Button(Sub(btns)
                                                                                                 btns.Text = "Submit"
                                                                                                 btns.Name = "btnsubmit"
                                                                                                 btns.ClientEnabled = False
                                                                                                 btns.ClientSideEvents.Click = "function (s, e) { gridSalesRealHistoryVerification.UpdateEdit(s, e); }"
                                                                                             End Sub).GetHtml()
                                                                    ViewContext.Writer.Write("</div>")
                                                                    ViewContext.Writer.Write("<div id='div4'  style='float:left;margin-left:2px;margin-top:2px;'>")
                                                                    Html.DevExpress().Button(Sub(btnf)
                                                                                                 btnf.Text = "Finish"
                                                                                                 btnf.Name = "btnfinish"
                                                                                                 btnf.ClientSideEvents.Click = "function (s, e) { gridSalesRealHistoryVerification.CancelEdit(s,e); }"
                                                                                             End Sub).GetHtml()
                                                                    ViewContext.Writer.Write("</div>")
                                                                End Sub)
                                     
                                grid.FillContextMenuItems = Sub(s, e)
                                                                If (e.MenuType = GridViewContextMenuType.Rows) Then
                                                                    Dim item = e.Items.Add("Mapping to Products", "Mapping")
                                                                    item.BeginGroup = True
                                                                    e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item)
                                                                End If
                                                            End Sub
                                     
                                grid.CustomJSProperties = Sub(s, e)
                                                              If ViewData("VerifyFlag") IsNot Nothing Then
                                                                  e.Properties("cpInsertResult") = ViewData("VerifyFlag").ToString()
                                                              End If
                                                          End Sub
                                                                                            
                            End Sub).Bind(Model).GetHtml()