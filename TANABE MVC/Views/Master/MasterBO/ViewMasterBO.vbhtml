@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "DataView1"
                                settings.CallbackRouteValues = New With {.Controller = "MasterBo", .Action = "ViewMasterBO"}
                                settings.ClientSideEvents.EndCallback = "DataView1_EndCallBack"
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
                                settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "MasterBo", .Action = "MasterBoAdd"}
                                settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "MasterBo", .Action = "MasterBoUpdate"}
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
								
                                settings.KeyFieldName = "bo_code"
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "bo_code"
                                                         column.Caption = "BO CODE"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.ValidationSettings.RequiredField.IsRequired = True
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "bo_description"
                                                         column.Caption = "BO Description"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "bo_address"
                                                         column.Caption = "BO ADDRESS"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "bo_sequence_code"
                                                         column.Caption = "SEQUENCE CODE"
                                                         column.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                         column.EditorProperties().SpinEdit(Sub(p)
                                                                                                p.NumberType = SpinEditNumberType.Integer
                                                                                                p.MinValue = 1
                                                                                                p.MaxValue = 10
                                                                                                p.SpinButtons.ShowIncrementButtons = False
                                                                                                p.SpinButtons.ShowLargeIncrementButtons = False
                                                                                                p.ValidationSettings.RequiredField.IsRequired = True
                                                                                            End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "Nama"
                                                         column.Caption = "BO AM"
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterBoController.ComboAm
                                                                                              c.DropDownWidth = 300
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{1}"
                                                                                              c.ValueField = "rep_id"
                                                                                              c.TextField = "rep_id"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("rep_id", "NIK", 50)
                                                                                              c.Columns.Add("rep_full_name", "Name", 150)
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                              c.ClientSideEvents.ValueChanged = "function(s, e) { cb_am_ValueChanged(s); }"
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.FieldName = "reg_id"
                                                         column.Caption = "REGION"
                                                         column.ReadOnly = True
                                                         column.Name = "reg_id"
                                                     End Sub)
                                settings.Columns.Add(Sub(columnCheck)
                                                         columnCheck.FieldName = "bo_status"
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
                                                         column.FieldName = "bo_am"
                                                         column.Caption = ""
                                                     End Sub)
                                     
                                     settings.CustomJSProperties = Sub(s, e)
                                                                       If ViewData("RequestFlag") IsNot Nothing Then
                                                                           e.Properties("cpMessage") = ViewData("RequestFlag").ToString()
                                                                       End If
                                                                   End Sub
                                     
                            End Sub).Bind(Model).GetHtml()

<style>
    table td:nth-child(9) {
        display: none;
    }
    #DataView1_DXPEForm_DXEFL_7 {
        display: none;
    }
</style>