@code
    Html.EnableClientValidation()
    Html.EnableUnobtrusiveJavaScript()

    Dim msg As String
    msg = TempData("msg")

End Code
@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "DataView1"
                                settings.CallbackRouteValues = New With {.Controller = "MasterRepresentative", .Action = "ViewMasterRepresentative"}
                                settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                                settings.SettingsPager.PageSize = 10
                                settings.Settings.ShowGroupPanel = True
                                settings.Settings.ShowFilterRowMenu = True
                                settings.Settings.ShowFilterRow = True
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
                                settings.CommandColumn.SelectAllCheckboxMode = GridViewSelectAllCheckBoxMode.Page
                                settings.CommandColumn.ShowSelectCheckbox = True
                                settings.CommandColumn.VisibleIndex = 0
                                settings.SettingsContextMenu.Enabled = True
                                settings.SettingsContextMenu.RowMenuItemVisibility.NewRow = False
                                settings.SettingsContextMenu.RowMenuItemVisibility.EditRow = True
                                settings.SettingsContextMenu.RowMenuItemVisibility.DeleteRow = False
                                settings.SettingsContextMenu.RowMenuItemVisibility.Refresh = True
                                
                                settings.CommandColumn.ShowNewButtonInHeader = True
                                settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "MasterRepresentative", .Action = "MasterRepresentativeAdd"}
                                settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "MasterRepresentative", .Action = "MasterRepresentativeUpdate"}
                                settings.SettingsEditing.Mode = GridViewEditingMode.Inline
                                settings.SettingsBehavior.ConfirmDelete = True
                                settings.CommandColumn.ShowEditButton = True
                                settings.SettingsCommandButton.EditButton.Image.Url = "~/Content/Images/Edit.png"
                                settings.SettingsCommandButton.EditButton.Text = " "
                                settings.SettingsCommandButton.NewButton.Image.Url = "~/Content/Images/Plus.png"
                                settings.SettingsCommandButton.NewButton.Text = " "
                                settings.SettingsCommandButton.CancelButton.Image.Url = "~/Content/Images/delete.png"
                                settings.SettingsCommandButton.CancelButton.Text = " "
                                settings.SettingsCommandButton.UpdateButton.Image.Url = "~/Content/Images/check.png"
                                settings.SettingsCommandButton.UpdateButton.Text = " "
                                settings.KeyFieldName = "rep_id"

                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.Name = "cb_rep_id"
                                                         column.FieldName = "rep_id"
                                                         column.Caption = "NIK"
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterRepresentativeController.ComboNIK
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.ValueField = "Nomor_Induk"
                                                                                              c.TextField = "Nomor_Induk"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("Nomor_Induk", "NIK", 30)
                                                                                              c.Columns.Add("Nama", "Name", 120)
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                              c.ClientSideEvents.ValueChanged = "function(s, e) { cb_rep_ValueChanged(s); }"
                                                                                          End Sub)
                                                     End Sub)
                                     
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "rep_name"
                                                         column.Caption = "NAME"
                                                         column.Name = "rep_name"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.Width = 150
                                                         column.ReadOnly = True
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "rep_sbo"
                                                         column.Caption = "SUB BRANCH OFFICE"
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterRepresentativeController.ComboSBO
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.ValueField = "sbo_code"
                                                                                              c.TextField = "sbo_code"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("sbo_code", "SBO CODE", 50)
                                                                                              c.Columns.Add("sbo_description", "SBO Description", 120)
                                                                                              c.Columns.Add("bo_code", "BO Code", 50)
                                                                                              c.Columns.Add("bo_description", "BO Description", 120)
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                              c.ClientSideEvents.ValueChanged = "function(s, e) { cb_sbo_ValueChanged(s); }"
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "rep_bo"
                                                         column.Caption = "BRANCH OFFICE"
                                                         column.ReadOnly = True
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "rep_region"
                                                         column.Name = "rep_region"
                                                         column.Caption = "REGION"
                                                         column.ReadOnly = True
                                                         column.Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterRepresentativeController.ComboRegion
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.ValueField = "reg_id"
                                                                                              c.TextField = "reg_id"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("reg_id", "Regional", 50)
                                                                                              c.Columns.Add("reg_functionary_name", "Functionary", 120)
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "rep_position"
                                                         column.Caption = "POSITION"
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.Items.Add("MR", "MR")
                                                                                              c.Items.Add("AM", "AM")
                                                                                              c.Items.Add("RM", "RM")
                                                                                              c.Items.Add("PPM", "PPM")
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "rep_email"
                                                         column.Caption = "EMAIL"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "rep_division"
                                                         column.Caption = "DIVISION"
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterRepresentativeController.ComboDivision
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.ValueField = "div_id"
                                                                                              c.TextField = "div_id"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("div_id", "Division", 50)
                                                                                              c.Columns.Add("div_description", "Description", 120)
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "nama_am"
                                                         column.Caption = "AREA MANAGER"
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterRepresentativeController.ComboAM
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{1}"
                                                                                              c.ValueField = "bo_am"
                                                                                              c.TextField = "bo_am"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("bo_am", "NIK", 50)
                                                                                              c.Columns.Add("Nama", "Name", 120)
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.FieldName = "nama_rm"
                                                         column.Caption = "REGIONAL MANAGER"
                                                     End Sub)
                                settings.Columns.Add(Sub(columnCheck)
                                                         columnCheck.FieldName = "rep_status"
                                                         columnCheck.Caption = "STATUS"
                                                         columnCheck.ColumnType = MVCxGridViewColumnType.CheckBox
                                                         columnCheck.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                         columnCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean
                                                         Dim checkBoxProperties = TryCast(columnCheck.PropertiesEdit, CheckBoxProperties)
                                                         checkBoxProperties.ValueType = GetType(Integer)
                                                         checkBoxProperties.ValueChecked = 1
                                                         checkBoxProperties.ValueUnchecked = 0
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "rep_am"
                                                         column.Caption = ""
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "rep_rm"
                                                         column.Caption = ""
                                                     End Sub)
                                     

                                settings.CommandColumn.ShowSelectCheckbox = True
                                settings.ClientSideEvents.Init = "function(s, e) { s.PerformCallback(); }"
                                settings.ClientSideEvents.BeginCallback = "function(s, e) { OnStartCallback(s, e); }"
                                settings.ClientSideEvents.EndCallback = "function(s, e) { OnEndCallback(s, e); }"

                                settings.ClientSideEvents.SelectionChanged = "SelectionChanged"
                                settings.FillContextMenuItems = Sub(s, e)
                                                                    If (e.MenuType = GridViewContextMenuType.Rows) Then
                                                                        Dim item = e.Items.Add("Change Regions", "Mapping Region")
                                                                        item.BeginGroup = True
                                                                        e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item)
                                                                    End If
                                                                End Sub
                                settings.ClientSideEvents.ContextMenuItemClick = "function(s,e) { OnContextMenuItemClick(s, e); }"
                                settings.ClientSideEvents.ContextMenu = "OnContextMenu"
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


