@Html.DevExpress().GridView(Sub(setting)
                                setting.Name = "gridEditProductSales"
                                setting.KeyFieldName = "sp_id"
                                setting.Width = Unit.Percentage(100)
                                setting.CallbackRouteValues = New With {.Controller = "SalesPlan", .Action = "DetailEditForm"}
                                setting.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "SalesPlan", .Action = "AddProduct", .prd_code = ViewData("cbProductLookup.GetValue()"), .tx_target_qty = ViewData("tx_target_qty"), .tx_note = ViewData("tx_note")}
                                setting.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "SalesPlan", .Action = "DeleteProduct", .sp_id = ViewData("sp_id")}
                                setting.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "SalesPlan", .Action = "UpdateProduct", .sp_id = ViewData("sp_id"), .tx_target_qty = ViewData("tx_target_qty"), .tx_note = ViewData("tx_note")}
                                setting.CommandColumn.ShowNewButtonInHeader = True
                                setting.CommandColumn.ButtonRenderMode = GridCommandButtonRenderMode.Image
                                setting.CommandColumn.ShowDeleteButton = True
                                setting.CommandColumn.ShowEditButton = True
                                setting.CommandColumn.Width = Unit.Pixel(60)
                                setting.CommandColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                setting.CommandColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                setting.CommandColumn.VisibleIndex = 10
                                setting.CommandColumn.SetHeaderCaptionTemplateContent(Sub(tmp)
                                                                                          ViewContext.Writer.Write("<div style='text-align: center'>")
                                                                                          Html.DevExpress().Button(Sub(button)
                                                                                                                       button.Name = "btnNew"
                                                                                                                       button.ToolTip = "Add New"
                                                                                                                       button.Text = ""
                                                                                                                       button.RenderMode = ButtonRenderMode.Link
                                                                                                                       button.Images.Image.Url = "~/Content/Images/Plus.png"
                                                                                                                       button.ClientSideEvents.Click = "function (s, e) { gridEditProductSales.AddNewRow(); }"
                                                                                                                   End Sub).GetHtml()
                                                                                          ViewContext.Writer.Write("</div>")
                                                                                      End Sub)
                                setting.SettingsCommandButton.NewButton.Image.Url = "~/Content/Images/Plus.png"
                                setting.SettingsCommandButton.EditButton.Image.Url = "~/Content/Images/Edit.png"
                                setting.SettingsCommandButton.DeleteButton.Image.Url = "~/Content/Images/delete-icon2.png"
                                setting.SettingsCommandButton.CancelButton.Image.Url = "~/Content/Images/cancel-icon2.png"
                                setting.SettingsCommandButton.UpdateButton.Image.Url = "~/Content/Images/update-icon2.png"
                                setting.Styles.Header.Font.Size = 7
                                setting.Styles.Header.Font.Bold = False
                                setting.Styles.Cell.Font.Size = 7
                                setting.Styles.InlineEditCell.Font.Size = 8
                                setting.Styles.EmptyDataRow.CssClass = "HideEmptyDataRow"
                                setting.SettingsEditing.Mode = GridViewEditingMode.EditFormAndDisplayRow
                                setting.SettingsEditing.NewItemRowPosition = GridViewNewItemRowPosition.Bottom
                                setting.SettingsBehavior.AllowSelectByRowClick = True
                                setting.SettingsBehavior.ConfirmDelete = True
                                setting.SettingsBehavior.AllowSelectSingleRowOnly = True
                                setting.Columns.Add(Sub(column)
                                                        column.Caption = "sp_id"
                                                        column.FieldName = "sp_id"
                                                        column.VisibleIndex = 1
                                                        column.Visible = False
                                                        column.Width = 200
                                                    End Sub)
                                setting.Columns.Add(Sub(column)
                                                        column.Caption = "PRODUCT"
                                                        column.FieldName = "prd_name"
                                                        column.VisibleIndex = 2
                                                        column.Width = 200
                                                    End Sub)
                                setting.Columns.Add(Sub(column)
                                                        column.Caption = "CATEGORY"
                                                        column.FieldName = "prd_category"
                                                        column.VisibleIndex = 3
                                                        column.Width = 75
                                                    End Sub)
                                setting.Columns.Add(Sub(column)
                                                        column.Caption = "PRICE"
                                                        column.FieldName = "prd_price"
                                                        column.VisibleIndex = 4
                                                        column.Width = 75
                                                    End Sub)
                                setting.Columns.Add(Sub(column)
                                                        column.Caption = "TARGET QTY."
                                                        column.FieldName = "sp_target_qty"
                                                        column.VisibleIndex = 5
                                                        column.Width = 40
                                                    End Sub)
                                setting.Columns.Add(Sub(column)
                                                        column.Caption = "TARGET VALUE"
                                                        column.FieldName = "sp_target_value"
                                                        column.VisibleIndex = 6
                                                        column.Width = 40
                                                    End Sub)
                                setting.Columns.Add(Sub(column)
                                                        column.Caption = "SALES QTY"
                                                        column.FieldName = "sp_sales_qty"
                                                        column.VisibleIndex = 7
                                                        column.Width = 40
                                                    End Sub)
                                setting.Columns.Add(Sub(column)
                                                        column.Caption = "SALES VALUE"
                                                        column.FieldName = "sp_sales_value"
                                                        column.VisibleIndex = 8
                                                        column.Width = 40
                                                    End Sub)
                                setting.Columns.Add(Sub(column)
                                                        column.Caption = "NOTE"
                                                        column.FieldName = "sp_note"
                                                        column.VisibleIndex = 9
                                                        column.Width = 150
                                                    End Sub)
                                setting.SetEditFormTemplateContent(Sub(e)
                                                                       ViewContext.Writer.Write("<table style='width:100%'>")
                                                                       ViewContext.Writer.Write("<tr id='row_lookup_doctor'>")
                                                                       ViewContext.Writer.Write("<td  style='width:150px;text-align:right;background-color:lightgray;'>PRODUCT :</td>")
                                                                       ViewContext.Writer.Write("<td>")
                                                                       Html.DevExpress().ComboBox(Sub(cmb)
                                                                                                      cmb.Name = "cbProductLookup"
                                                                                                      cmb.Width = Unit.Percentage(100)
                                                                                                      If Not e.Grid.IsNewRowEditing Then
                                                                                                          cmb.Properties.NullText = DataBinder.Eval(e.DataItem, "prd_name")
                                                                                                      End If
                                                                                                      cmb.Enabled = e.Grid.IsNewRowEditing
                                                                                                      cmb.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                                      cmb.Properties.ValueField = "prd_code"
                                                                                                      cmb.Properties.ValueType = GetType(String)
                                                                                                      cmb.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                                      cmb.Properties.TextFormatString = "{1}"
                                                                                                      cmb.Properties.TextField = "prd_name"
                                                                                                      cmb.Properties.Columns.Add("prd_code", "CODE", 50)
                                                                                                      cmb.Properties.Columns.Add("prd_name", "NAME", 200)
                                                                                                      cmb.Properties.Columns.Add("prd_focus", "FOCUS", 60)
                                                                                                      cmb.Properties.Columns.Add("prd_type", "TYPE", 60)
                                                                                                      cmb.Properties.Columns.Add("prd_price", "PRICE", 100)
                                                                                                  End Sub).BindList(TANABE_MVC.SalesPlanController.cbProductLookup).GetHtml()
                                                                       ViewContext.Writer.Write("</td>")
                                                                       ViewContext.Writer.Write("</tr>")
                                                                       ViewContext.Writer.Write("<tr id='row_date_visit'>")
                                                                       ViewContext.Writer.Write("<td  style='width:150px;text-align:right;background-color:lightgray;'>TARGET QUANTITY :</td>")
                                                                       ViewContext.Writer.Write("<td>")
                                                                       Html.DevExpress().SpinEdit(Sub(spin)
                                                                                                      spin.Name = "tx_target_qty"
                                                                                                      spin.Number = 0
                                                                                                      spin.Properties.MinValue = 1
                                                                                                      spin.Properties.MaxValue = 500
                                                                                                  End Sub).Bind(DataBinder.Eval(e.DataItem, "sp_target_qty")).GetHtml()
                                                                       ViewContext.Writer.Write("</td>")
                                                                       ViewContext.Writer.Write("</tr>")
                                                                       ViewContext.Writer.Write("<tr>")
                                                                       ViewContext.Writer.Write("<td style='width:150px;text-align:right;background-color:lightgray;'>NOTE :</td>")
                                                                       ViewContext.Writer.Write("<td>")
                                                                       Html.DevExpress().Memo(Sub(m)
                                                                                                  m.Name = "tx_note"
                                                                                                  m.Height = Unit.Pixel(71)
                                                                                                  m.Width = Unit.Percentage(100)
                                                                                              End Sub).Bind(DataBinder.Eval(e.DataItem,"sp_note")).GetHtml()
                                                                       ViewContext.Writer.Write("</td>")
                                                                       ViewContext.Writer.Write("</tr>")
                                                                       ViewContext.Writer.Write("</table>")
                                                                       ViewContext.Writer.Write("<div style='margin-left:310px'>")
                                                                       Html.DevExpress().Button(Sub(btns)
                                                                                                    btns.Text = ""
                                                                                                    btns.RenderMode = ButtonRenderMode.Link
                                                                                                    btns.Images.Image.Url = "~/Content/Images/update-icon2.png"
                                                                                                    btns.Name = "btnUpdates"
                                                                                                    btns.ClientSideEvents.Click = "function (s, e) { gridEditProductSales.UpdateEdit(s, e); }"
                                                                                                End Sub).GetHtml()
                                                                       ViewContext.Writer.Write("&nbsp;|&nbsp;")
                                                                       Html.DevExpress().Button(Sub(btnf)
                                                                                                    btnf.Text = ""
                                                                                                    btnf.RenderMode = ButtonRenderMode.Link
                                                                                                    btnf.Images.Image.Url = "~/Content/Images/cancel-icon2.png"
                                                                                                    btnf.Name = "btnCancels"
                                                                                                    btnf.ClientSideEvents.Click = "function (s, e) { gridEditProductSales.CancelEdit(s, e); }"
                                                                                                End Sub).GetHtml()
                                                                       ViewContext.Writer.Write("</div>")
                                                                   End Sub)
                                     
                            End Sub).Bind(Model).GetHtml()