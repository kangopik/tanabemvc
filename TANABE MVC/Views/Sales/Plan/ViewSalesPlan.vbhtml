@Html.DevExpress().GridView(Sub(grid)
                                grid.Name = "gridSalesPlan"
                                grid.CallbackRouteValues = New With {.Controller = "SalesPlan", .Action = "ViewSalesPlan"}
                                grid.CustomActionRouteValues = New With {.Controller = "SalesPlan", .Action = "ViewSalesPlanCustomCallback"}
                                grid.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "SalesPlan", .Action = "DeletePlan", .sales_id = ViewData("sales_id")}
                                grid.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "SalesPlan", .Action = "UpdatePlan"}
                                grid.ClientSideEvents.EndCallback = "gridSalesPlan_EndCallBack"
                                grid.ClientSideEvents.SelectionChanged = "SelectionChanged"
                                grid.SettingsBehavior.ConfirmDelete = True
                                grid.ControlStyle.Paddings.Padding = System.Web.UI.WebControls.Unit.Pixel(1)
                                grid.ControlStyle.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                grid.ControlStyle.BorderBottom.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                grid.Width = Unit.Percentage(100)
                                grid.Styles.Cell.Font.Size = 8
                                grid.Styles.Header.Font.Size = 8
                                grid.Styles.GroupRow.Font.Size = 8
                                grid.Styles.Footer.Font.Size = 8
                                grid.Styles.Header.HorizontalAlign = HorizontalAlign.Center

                                grid.CommandColumn.ShowSelectCheckbox = True
                                grid.CommandColumn.ShowNewButton = False
                                grid.CommandColumn.ShowDeleteButton = False
                                grid.CommandColumn.VisibleIndex = 0
                                grid.CommandColumn.Width = 30

                                grid.SettingsContextMenu.Enabled = True
                                grid.SettingsContextMenu.RowMenuItemVisibility.DeleteRow = False
                                grid.SettingsContextMenu.RowMenuItemVisibility.EditRow = True
                                grid.SettingsContextMenu.RowMenuItemVisibility.NewRow = False
                                grid.SettingsDetail.ShowDetailRow = False
                                grid.SettingsDetail.ExportMode = GridViewDetailExportMode.All
                                grid.SettingsDetail.AllowOnlyOneMasterRowExpanded = True
                                grid.SettingsPager.PageSize = 20
                                grid.Settings.ShowGroupPanel = True
                                grid.Settings.ShowFilterRow = True
                                grid.Settings.ShowGroupedColumns = True
                                grid.Settings.VerticalScrollableHeight = 350
                                grid.SettingsEditing.Mode = GridViewEditingMode.PopupEditForm
                                grid.SettingsSearchPanel.Visible = False
                                grid.SettingsBehavior.AllowSelectByRowClick = True
                                grid.SettingsBehavior.ConfirmDelete = True
                                grid.SettingsBehavior.AllowFixedGroups = True
                                grid.SettingsBehavior.AutoExpandAllGroups = True
                                grid.Styles.EmptyDataRow.CssClass = "HideEmptyDataRow"
                                grid.Styles.Header.Font.Size = 7
                                grid.Styles.Header.Font.Bold = True
                                grid.Styles.Header.Paddings.PaddingLeft = 2
                                grid.Styles.Header.Paddings.PaddingRight = 2
                                grid.Styles.Header.Paddings.PaddingBottom = 1
                                grid.Styles.Header.Paddings.PaddingTop = 1
                                grid.Styles.Cell.Font.Size = 8
                                grid.Styles.Cell.Paddings.PaddingLeft = 2
                                grid.Styles.Cell.Paddings.PaddingRight = 2
                                grid.Styles.Cell.Paddings.PaddingBottom = 1
                                grid.Styles.Cell.Paddings.PaddingTop = 1
                                grid.Styles.InlineEditCell.Font.Size = 8
                                grid.Styles.GroupRow.Font.Size = 7
                                grid.Styles.GroupPanel.Font.Size = 7
                                grid.Styles.GroupPanel.Paddings.Padding = 1
                                grid.SettingsPopup.EditForm.Width = 400
                                grid.SettingsPopup.EditForm.MinHeight = 400
                                grid.SettingsPopup.EditForm.HorizontalAlign = PopupHorizontalAlign.Center
                                grid.SettingsPopup.EditForm.VerticalAlign = PopupVerticalAlign.TopSides
                                grid.SettingsPopup.EditForm.AllowResize = True
                                grid.SettingsPopup.EditForm.Modal = True
                                grid.SettingsPopup.CustomizationWindow.Width = Unit.Percentage(100)
                                grid.SettingsPopup.CustomizationWindow.HorizontalAlign = PopupHorizontalAlign.Center
                                grid.SettingsPopup.CustomizationWindow.VerticalAlign = PopupVerticalAlign.TopSides

                                grid.KeyFieldName = "dr_code"

                                Dim secondCC = New MVCxGridViewCommandColumn()
                                secondCC.ShowEditButton = True
                                secondCC.ButtonRenderMode = GridCommandButtonRenderMode.Link
                                secondCC.VisibleIndex = 0
                                secondCC.Caption = "Action"
                                secondCC.ShowDeleteButton = False
                                secondCC.ShowClearFilterButton = True
                                secondCC.ShowInCustomizationForm = True
                                secondCC.Width = 60
                                secondCC.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                secondCC.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                grid.Columns.Add(secondCC)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "rep_id"
                                                     column.VisibleIndex = 1
                                                     column.Caption = "REP ID"
                                                     column.Width = 50
                                                     column.Visible = False
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.EditFormSettings.Visible = DefaultBoolean.False
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sales_id"
                                                     column.VisibleIndex = 1
                                                     column.Caption = "SALES ID"
                                                     column.Width = 50
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.EditFormSettings.Visible = DefaultBoolean.False
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sales_date_plan"
                                                     column.Caption = "DATE PLAN"
                                                     column.ShowInCustomizationForm = True
                                                     column.VisibleIndex = 2
                                                     column.Width = 75
                                                     column.Visible = False
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sales_year_plan"
                                                     column.Caption = "YEAR PLAN"
                                                     column.ShowInCustomizationForm = True
                                                     column.VisibleIndex = 2
                                                     column.Width = 75
                                                     column.Visible = False
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.Name = "col_dr_code"
                                                     column.FieldName = "dr_code"
                                                     column.Caption = "DR. CODE"
                                                     column.VisibleIndex = 3
                                                     column.Width = 45
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.ColumnType = MVCxGridViewColumnType.CheckBox
                                                     column.FieldName = "sales_plan"
                                                     column.VisibleIndex = 3
                                                     column.Caption = "User Plan"
                                                     column.Width = 40
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.ColumnType = MVCxGridViewColumnType.CheckBox
                                                     column.FieldName = "sales_plan_verification_status"
                                                     column.VisibleIndex = 3
                                                     column.Width = 40
                                                     column.Caption = "Ver. Plan"
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "dr_name"
                                                     column.Caption = "DR. NAME"
                                                     column.VisibleIndex = 4
                                                     column.Width = 130
                                                     column.GroupIndex = 0
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Left
                                                     column.Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "dr_spec"
                                                     column.Caption = "DR. SPEC."
                                                     column.VisibleIndex = 5
                                                     column.Width = 50
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Left
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "dr_quadrant"
                                                     column.Caption = "QUAD"
                                                     column.VisibleIndex = 7
                                                     column.Width = 40
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "dr_monitoring"
                                                     column.Caption = "MONITORING"
                                                     column.VisibleIndex = 8
                                                     column.Width = 200
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Left
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sales_date_plan_updated"
                                                     column.Caption = "DATE_UPDATED"
                                                     column.Visible = False
                                                     column.VisibleIndex = 14
                                                     column.Width = 50
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "prd_name"
                                                     column.Caption = "PRODUCT. NAME"
                                                     column.VisibleIndex = 11
                                                     column.Width = 250
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Left
                                                     column.Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "prd_price"
                                                     column.Caption = "PRICE"
                                                     column.VisibleIndex = 12
                                                     column.Width = 50
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Right
                                                     column.PropertiesEdit.DisplayFormatString = "N3"
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "prd_category"
                                                     column.Caption = "CATEGORY"
                                                     column.VisibleIndex = 13
                                                     column.Width = 50
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sp_target_qty"
                                                     column.Caption = "TARGET QTY"
                                                     column.VisibleIndex = 14
                                                     column.Width = 50
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sp_target_value"
                                                     column.Caption = "TARGET VALUE"
                                                     column.VisibleIndex = 15
                                                     column.Width = 50
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
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
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                 End Sub)

                                grid.Columns.Add(Sub(column)
                                                     column.FieldName = "sp_sales_value"
                                                     column.Caption = "SALES VALUE"
                                                     column.VisibleIndex = 17
                                                     column.Width = 50
                                                     column.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.HeaderStyle.Wrap = DefaultBoolean.True
                                                     column.CellStyle.VerticalAlign = VerticalAlign.Middle
                                                     column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                     column.PropertiesEdit.DisplayFormatString = "N0"
                                                 End Sub)

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
                                                                    e.Column.ReadOnly = True
                                                                End If
                                                            End Sub
                                     
                                grid.BeforeGetCallbackResult = Sub(s, e)
                                                                   Dim g As MVCxGridView = DirectCast(s, MVCxGridView)
                                                                   g.ExpandAll()
                                                               End Sub

                                grid.SetEditFormTemplateContent(Sub(c)
                                                                    ViewContext.Writer.Write("<div style='padding: 4px 4px 3px 4px;width:800px'>")
                                                                    Html.DevExpress().PageControl(Sub(p)
                                                                                                      p.Name = "tabEdit"
                                                                                                      p.Width = Unit.Percentage(100)
                                                                                                      p.ShowTabs = False
                                                                                                      p.ActiveTabIndex = 0
                                                                                                      p.TabPages.Add(Sub(tb)
                                                                                                                         tb.Visible = True
                                                                                                                         tb.SetContent(Sub()
                                                                                                                                           Html.RenderAction("ViewEditForm", New With {.sales_id = DataBinder.Eval(c.DataItem, "sales_id"), .dr_code = DataBinder.Eval(c.DataItem, "dr_code"), .sales_date_plan = DataBinder.Eval(c.DataItem, "sales_date_plan"), .sales_year_plan = DataBinder.Eval(c.DataItem, "sales_year_plan")})
                                                                                                                                       End Sub)
                                                                                                                     End Sub)
                                                                                                  End Sub).GetHtml()
                                                                    ViewContext.Writer.Write("</div>")
                                                                    ViewContext.Writer.Write("<div id='div3'  style='float:left;margin-left:650px;margin-top:2px;'>")
                                                                    Html.DevExpress().Button(Sub(btns)
                                                                                                 btns.Text = "Submit"
                                                                                                 btns.Name = "btnsubmit"
                                                                                                 btns.ClientEnabled = False
                                                                                                 btns.ClientSideEvents.Click = "function (s, e) { gridSalesPlan.UpdateEdit(s, e); }"
                                                                                             End Sub).GetHtml()
                                                                    ViewContext.Writer.Write("</div>")
                                                                    ViewContext.Writer.Write("<div id='div4'  style='float:left;margin-left:2px;margin-top:2px;'>")
                                                                    Html.DevExpress().Button(Sub(btnf)
                                                                                                 btnf.Text = "Finish"
                                                                                                 btnf.Name = "btnfinish"
                                                                                                 btnf.ClientSideEvents.Click = "function (s, e) { gridSalesPlan.CancelEdit(s,e); }"
                                                                                             End Sub).GetHtml()
                                                                    ViewContext.Writer.Write("</div>")
                                                                End Sub)
                                     

                                grid.FillContextMenuItems = Sub(s, e)
                                                                If (e.MenuType = GridViewContextMenuType.Rows) Then
                                                                    Dim item = e.Items.Add("Mapping to Products", "Mapping")
                                                                    item.BeginGroup = True
                                                                    e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item)
                                                                    e.Items.FindByCommand(GridViewContextMenuCommand.EditRow).Text = "Planning"
                                                                End If
                                                            End Sub
                                grid.ClientSideEvents.ContextMenuItemClick = "function(s,e) { OnContextMenuItemClick(s, e); }"
                                grid.ClientSideEvents.ContextMenu = "OnContextMenu"

                                grid.CommandButtonInitialize = Sub(s, e)
                                                                   If e.VisibleIndex = -1 Then
                                                                       Return
                                                                   End If
                                                                   Dim fieldValue_sp As Object = (TryCast(s, MVCxGridView)).GetRowValues(e.VisibleIndex, "sales_plan")
                                                                   Dim fieldValue_spvs As Object = (TryCast(s, MVCxGridView)).GetRowValues(e.VisibleIndex, "sales_plan_verification_status")
                                                                   Select Case e.ButtonType
                                                                       Case ColumnCommandButtonType.Edit
                                                                           If fieldValue_sp = 0 Or IsDBNull(fieldValue_sp = True) Then
                                                                               e.Text = "Planning"
                                                                           Else
                                                                               e.Text = "Edit"
                                                                           End If
                                                                           If fieldValue_spvs = 0 Or IsDBNull(fieldValue_spvs = True) Then
                                                                               e.Visible = True
                                                                           Else
                                                                               e.Visible = False
                                                                           End If
                                                                       Case ColumnCommandButtonType.Delete
                                                                           If fieldValue_spvs = 0 Or IsDBNull(fieldValue_spvs = True) Then
                                                                               e.Visible = True
                                                                           Else
                                                                               e.Visible = False
                                                                           End If
                                                                       Case ColumnCommandButtonType.SelectCheckbox
                                                                           If fieldValue_sp = 0 Or IsDBNull(fieldValue_sp = True) Then
                                                                               e.Enabled = True
                                                                           Else
                                                                               e.Enabled = False
                                                                           End If
                                                                   End Select
                                                               End Sub

                                grid.CustomJSProperties = Sub(s, e)
                                                              If ViewData("RequestFlag") IsNot Nothing Then
                                                                  e.Properties("cpInsertResult") = ViewData("RequestFlag").ToString()
                                                              End If
                                                              If ViewData("GenerateFlag") IsNot Nothing Then
                                                                  e.Properties("cpInsertResult") = ViewData("GenerateFlag").ToString()
                                                              End If
                                                              If ViewData("CopyFlag") IsNot Nothing Then
                                                                  e.Properties("cpClosePopup") = ViewData("CopyFlag").ToString()
                                                              End If
                                                              If ViewData("MappingFlag") IsNot Nothing Then
                                                                  e.Properties("cpCloseMapping") = ViewData("MappingFlag").ToString()
                                                              End If
                                                          End Sub

                            End Sub).Bind(Model).GetHtml()
