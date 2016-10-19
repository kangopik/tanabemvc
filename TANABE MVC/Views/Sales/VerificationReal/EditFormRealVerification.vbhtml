@Html.DevExpress().GridView(Sub(setting)
                                setting.Name = "gridEditProductSalesActual"
                                setting.KeyFieldName = "spa_id"
                                setting.Width = Unit.Percentage(100)
                                setting.CallbackRouteValues = New With {.Controller = "SalesRealVerification", .Action = "DetailEditForm"}
                                setting.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "SalesRealVerification", .Action = "AddProduct", .spa_date = ViewData("spa_date"), .spa_quantity = ViewData("spa_quantity"), .spa_note = ViewData("spa_note")}
                                setting.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "SalesRealVerification", .Action = "DeleteProduct", .spa_id = ViewData("spa_id")}
                                setting.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "SalesRealVerification", .Action = "UpdateProduct", .spa_id = ViewData("spa_id"), .spa_date = ViewData("spa_date"), .spa_quantity = ViewData("spa_quantity"), .spa_note = ViewData("spa_note")}
                                setting.CommandColumn.ShowNewButtonInHeader = True
                                setting.CommandColumn.ButtonRenderMode = GridCommandButtonRenderMode.Image
                                setting.CommandColumn.VisibleIndex = 5
                                setting.CommandColumn.ShowDeleteButton = True
                                setting.CommandColumn.ShowEditButton = True
                                setting.CommandColumn.Width = Unit.Pixel(50)
                                setting.CommandColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
                                setting.CommandColumn.HeaderStyle.VerticalAlign = VerticalAlign.Middle
                                setting.CommandColumn.SetHeaderCaptionTemplateContent(Sub(tmp)
                                                                                          ViewContext.Writer.Write("<div style='text-align: center'>")
                                                                                          Html.DevExpress().Button(Sub(button)
                                                                                                                       button.Name = "btnNew"
                                                                                                                       button.ToolTip = "Add New"
                                                                                                                       button.Text = ""
                                                                                                                       button.RenderMode = ButtonRenderMode.Link
                                                                                                                       button.Images.Image.Url = "~/Content/Images/Plus.png"
                                                                                                                       button.ClientSideEvents.Click = "function (s, e) { gridEditProductSalesActual.AddNewRow(); }"
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
                                setting.SettingsEditing.Mode = GridViewEditingMode.Inline
                                setting.SettingsEditing.NewItemRowPosition = GridViewNewItemRowPosition.Bottom
                                setting.SettingsBehavior.AllowSelectByRowClick = True
                                setting.SettingsBehavior.ConfirmDelete = True
                                setting.SettingsBehavior.AllowSelectSingleRowOnly = True
                                setting.SettingsPager.PageSize = 10
                                setting.Settings.ShowFooter = True
                                setting.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "spa_quantity")
                                     setting.Columns.Add(Sub(column)
                                                             column.Caption = "spa_id"
                                                             column.FieldName = "spa_id"
                                                             column.VisibleIndex = 1
                                                             column.Visible = False
                                                             column.Width = 200
                                                         End Sub)
                                     setting.Columns.Add(Sub(column)
                                                             column.ColumnType = MVCxGridViewColumnType.DateEdit
                                                             column.Caption = "DATE"
                                                             column.FieldName = "spa_date"
                                                             column.VisibleIndex = 2
                                                             column.Width = 120
                                                             column.EditorProperties.DateEdit(Sub(d)
                                                                                                  d.Width = Unit.Percentage(100)
                                                                                                  d.DisplayFormatString = "dd/MM/yyyy"
                                                                                                  d.ValidationSettings.RequiredField.IsRequired = True
                                                                                              End Sub)
                                                         End Sub)
                                     setting.Columns.Add(Sub(column)
                                                             column.ColumnType = MVCxGridViewColumnType.SpinEdit
                                                             column.Caption = "QUANTITY"
                                                             column.FieldName = "spa_quantity"
                                                             column.VisibleIndex = 3
                                                             column.Width = 50
                                                             column.EditorProperties.SpinEdit(Sub(s)
                                                                                                  s.Width = Unit.Percentage(100)
                                                                                                  s.MinValue = 0
                                                                                                  s.ValidationSettings.RequiredField.IsRequired = True
                                                                                              End Sub)
                                                         End Sub)
                                     setting.Columns.Add(Sub(column)
                                                             column.Caption = "NOTES"
                                                             column.FieldName = "spa_note"
                                                             column.VisibleIndex = 4
                                                             column.Width = 150
                                                         End Sub)
                            End Sub).Bind(Model).GetHtml()
