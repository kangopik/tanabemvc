@code
    Html.EnableClientValidation()
    Html.EnableUnobtrusiveJavaScript()

    Dim msg As String
    msg = TempData("msg")

End Code
@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "DataView1"
                                settings.CallbackRouteValues = New With {.Controller = "MasterRegional", .Action = "ViewMasterRegional"}
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
                                settings.Styles.Header.Font.Bold = True     
                                settings.Styles.GroupRow.Font.Size = 8
                                settings.Styles.Footer.Font.Size = 8
                                settings.Styles.Header.HorizontalAlign = HorizontalAlign.Center
								
                                settings.CommandColumn.ShowNewButtonInHeader = True
                                settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "MasterRegional", .Action = "MasterRegionalAdd"}
                                settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "MasterRegional", .Action = "MasterRegionalUpdate"}
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
								
                                settings.KeyFieldName = "reg_id"
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "reg_id"
                                                         column.Caption = "REGIONAL Code"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.ValidationSettings.RequiredField.IsRequired = True
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "reg_description"
                                                         column.Caption = "Regional Description"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "Nama"
                                                         column.Caption = "FUNCTIONARY"
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterRegionalController.ComboFunctionary
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{1}"
                                                                                              c.ValueField = "rep_id"
                                                                                              c.TextField = "Nama"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("rep_id", "NIK", 50)
                                                                                              c.Columns.Add("rep_full_name", "Name", 180)
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "reg_sequence_code"
                                                         column.Caption = "Sequence Code"
                                                         column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                         column.EditorProperties().SpinEdit(Sub(p)
                                                                                                p.NumberType = SpinEditNumberType.Integer
                                                                                                p.MinValue = 1
                                                                                                p.MaxValue = 10
                                                                                                p.SpinButtons.ShowIncrementButtons = False
                                                                                                p.SpinButtons.ShowLargeIncrementButtons = False
                                                                                            End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(columnCheck)
                                                         columnCheck.FieldName = "reg_status"
                                                         columnCheck.Caption = "STATUS"
                                                         columnCheck.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                         columnCheck.ColumnType = MVCxGridViewColumnType.CheckBox
                                                         columnCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean
                                                         Dim checkBoxProperties = TryCast(columnCheck.PropertiesEdit, CheckBoxProperties)
                                                         checkBoxProperties.ValueType = GetType(Integer)
                                                         checkBoxProperties.ValueChecked = 1
                                                         checkBoxProperties.ValueUnchecked = 0
                                                     End Sub)
                                
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "reg_functionary"
                                                         column.Caption = ""
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

<style>
    table td:nth-child(7) {
        display: none;
    }
    #DataView1_DXPEForm_DXEFL_5 {
        display: none;
    }
</style>