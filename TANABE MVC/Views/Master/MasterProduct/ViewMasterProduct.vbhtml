@code
    Html.EnableClientValidation()
    Html.EnableUnobtrusiveJavaScript()

    Dim msg As String
    msg = TempData("msg")

End Code
@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "DataView1"
                                settings.CallbackRouteValues = New With {.Controller = "MasterProduct", .Action = "ViewMasterProduct"}
                                settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                                settings.SettingsPager.PageSize = 10
                                settings.SettingsSearchPanel.Visible = True
                                settings.Settings.ShowGroupPanel = True
                                settings.SettingsEditing.Mode = GridViewEditingMode.Inline
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
								
                                settings.CommandColumn.ShowNewButtonInHeader = True
                                settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "MasterProduct", .Action = "MasterProductAdd"}
                                settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "MasterProduct", .Action = "MasterProductUpdate"}
                                settings.SettingsEditing.Mode = GridViewEditingMode.Inline
                                settings.SettingsBehavior.ConfirmDelete = True
                                settings.CommandColumn.Visible = True
                                settings.CommandColumn.ShowEditButton = True
                                settings.SettingsCommandButton.EditButton.Image.Url = "~/Content/Images/Edit.png"
                                settings.SettingsCommandButton.EditButton.Text = " "
                                settings.SettingsCommandButton.NewButton.Image.Url = "~/Content/Images/Plus.png"
                                settings.SettingsCommandButton.NewButton.Text = " "
                                settings.SettingsCommandButton.CancelButton.Image.Url = "~/Content/Images/delete.png"
                                settings.SettingsCommandButton.CancelButton.Text = " "
                                settings.SettingsCommandButton.UpdateButton.Image.Url = "~/Content/Images/check.png"
                                settings.SettingsCommandButton.UpdateButton.Text = " "
								
                                settings.KeyFieldName = "prd_code"
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "prd_code"
                                                         column.Caption = "Product Code"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.ValidationSettings.RequiredField.IsRequired = True
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "prd_name"
                                                         column.Caption = "Product Name"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.ValidationSettings.RequiredField.IsRequired = True
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "prd_focus"
                                                         column.Caption = "Focus"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.ValidationSettings.RequiredField.IsRequired = True
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "prd_type"
                                                         column.Caption = "Type"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.ValidationSettings.RequiredField.IsRequired = True
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "prd_price"
                                                         column.Caption = "Price"
                                                         column.EditorProperties().SpinEdit(Sub(p)
                                                                                                p.NumberType = SpinEditNumberType.Integer
                                                                                                p.MinValue = 0
                                                                                                p.MaxValue = 100000000
                                                                                                p.SpinButtons.ShowIncrementButtons = True
                                                                                                p.SpinButtons.ShowLargeIncrementButtons = False
                                                                                                p.ValidationSettings.RequiredField.IsRequired = True
                                                                                            End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "prd_group"
                                                         column.Caption = "Group Visit"
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterProductController.ComboVisit
                                                                                              c.DropDownWidth = 300
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.ValueField = "visit_code"
                                                                                              c.TextField = "visit_code"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("visit_code", "Visit Code", 50)
                                                                                              c.Columns.Add("visit_product", "Visit Product", 120)
                                                                                              c.Columns.Add("visit_team", "Visit Team", 120)
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(columnCheck)
                                                         columnCheck.FieldName = "prd_status"
                                                         columnCheck.Caption = "Status"
                                                         columnCheck.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                         columnCheck.ColumnType = MVCxGridViewColumnType.CheckBox
                                                         columnCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean
                                                         Dim checkBoxProperties = TryCast(columnCheck.PropertiesEdit, CheckBoxProperties)
                                                         checkBoxProperties.ValueType = GetType(Integer)
                                                         checkBoxProperties.ValueChecked = 1
                                                         checkBoxProperties.ValueUnchecked = 0
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "prd_price_valid_year"
                                                         column.Caption = "Valid Year"
                                                         column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                         column.EditorProperties().SpinEdit(Sub(p)
                                                                                                p.NumberType = SpinEditNumberType.Integer
                                                                                                p.MinValue = 1
                                                                                                p.MaxValue = 10000
                                                                                                p.SpinButtons.ShowIncrementButtons = False
                                                                                                p.SpinButtons.ShowLargeIncrementButtons = False
                                                                                            End Sub)
                                                     End Sub)
                                     
                            End Sub).Bind(Model).GetHtml()

@code

    If msg <> "" Then
        TempData("msg") = ""
        Html.DevExpress().PopupControl(
            Sub(settings)
                    settings.Name = "PopupControl"
                    settings.ShowHeader = True
                    settings.ShowOnPageLoad = True
                    settings.AllowDragging = True
                    settings.CloseAction = CloseAction.OuterMouseClick
                    settings.CloseOnEscape = True
                    settings.Modal = True
                    settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                    settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                    settings.SetHeaderTemplateContent(
                        Sub()
                                ViewContext.Writer.Write("<div style='font-size:small;'>Information</div>")
                        End Sub)

                    settings.SetContent(
                        Sub()
                                ViewContext.Writer.Write(msg)
                        End Sub)


            End Sub).GetHtml()


    End If
End Code



