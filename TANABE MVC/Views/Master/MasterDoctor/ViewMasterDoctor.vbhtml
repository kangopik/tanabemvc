@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "DataView1"
                                settings.CallbackRouteValues = New With {.Controller = "MasterDoctor", .Action = "ViewMasterDoctor"}
                                settings.ClientSideEvents.EndCallback = "DataView1_EndCallBack"
                                settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                                settings.SettingsPager.PageSize = 8
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
                                settings.CommandColumn.ShowSelectCheckbox = True
                                settings.CommandColumn.VisibleIndex = 0
                                settings.SettingsContextMenu.Enabled = True
                                settings.SettingsContextMenu.RowMenuItemVisibility.EditRow = True
                                settings.SettingsContextMenu.RowMenuItemVisibility.DeleteRow = False
                                settings.SettingsContextMenu.RowMenuItemVisibility.NewRow = True
                                settings.SettingsContextMenu.RowMenuItemVisibility.Refresh = True
								
                                settings.CommandColumn.ShowNewButtonInHeader = True
                                settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "MasterDoctor", .Action = "MasterDoctorAdd"}
                                settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "MasterDoctor", .Action = "MasterDoctorUpdate"}
                                settings.SettingsEditing.Mode = GridViewEditingMode.PopupEditForm
                                settings.SettingsBehavior.ConfirmDelete = True
                                settings.SettingsBehavior.AllowSelectByRowClick = True
                                settings.SettingsPopup.EditForm.Width = 800
                                settings.SettingsPopup.EditForm.HorizontalAlign = PopupHorizontalAlign.WindowCenter
                                settings.SettingsPopup.EditForm.VerticalAlign = PopupVerticalAlign.WindowCenter
                                settings.SettingsPopup.EditForm.ShowHeader = True
                                settings.SettingsPopup.EditForm.Modal = True
                                settings.CommandColumn.Visible = True
                                settings.CommandColumn.ShowEditButton = True
                                settings.SettingsCommandButton.EditButton.Image.Url = "~/Content/Images/Edit.png"
                                settings.SettingsCommandButton.EditButton.Text = " "
                                settings.SettingsCommandButton.NewButton.Image.Url = "~/Content/Images/Plus.png"
                                settings.SettingsCommandButton.NewButton.Text = " "
                                settings.SettingsCommandButton.CancelButton.Text = "Cancel"
                                settings.SettingsCommandButton.UpdateButton.Text = "Save"
								
                                settings.KeyFieldName = "dr_code"
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_code"
                                                         column.Caption = "DOCTOR CODE"
                                                         column.CellStyle.ForeColor = System.Drawing.Color.Blue
                                                         column.CellStyle.Font.Size = 10
                                                         column.VisibleIndex = 1
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.FixedStyle = GridViewColumnFixedStyle.None
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.ReadOnly = True
                                                         column.EditFormSettings.VisibleIndex = 1
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.ValidationSettings.RequiredField.IsRequired = True
                                                                                             c.Width = 90
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_name"
                                                         column.Caption = "NAME"
                                                         column.VisibleIndex = 1
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.FixedStyle = GridViewColumnFixedStyle.None
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.EditFormSettings.VisibleIndex = 3
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.ValidationSettings.RequiredField.IsRequired = True
                                                                                             c.Width = 300
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "dr_sbo"
                                                         column.Caption = "SBO AREA"
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.VisibleIndex = 2
                                                         column.EditFormSettings.VisibleIndex = 2
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterDoctorController.ComboSBO
                                                                                              c.Width = 100
                                                                                              c.DropDownWidth = 250
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.ValueField = "sbo_code"
                                                                                              c.TextField = "sbo_code"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("sbo_code", "SBO CODE", 50)
                                                                                              c.Columns.Add("bo_code", "BO Code", 50)
                                                                                              c.Columns.Add("rep_name", "REP IN CHARGE", 120)
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                              c.ClientSideEvents.ValueChanged = "function(s, e) { cb_sbo_ValueChanged(s); }"
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_rep"
                                                         column.Caption = "REP IN CHARGE"
                                                         column.VisibleIndex = 3
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.EditFormSettings.Visible = DefaultBoolean.False
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "rep_name"
                                                         column.Caption = "REP NAME"
                                                         column.VisibleIndex = 3
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.EditFormSettings.Visible = DefaultBoolean.False
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_am"
                                                         column.Caption = "AM IN CHARGE"
                                                         column.VisibleIndex = 3
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.EditFormSettings.Visible = DefaultBoolean.False
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_region"
                                                         column.Caption = "REG."
                                                         column.VisibleIndex = 4
                                                         column.EditFormSettings.Visible = DefaultBoolean.False
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "dr_spec"
                                                         column.Caption = "SPEC."
                                                         column.VisibleIndex = 6
                                                         column.EditFormSettings.VisibleIndex = 5
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterDoctorController.ComboSpec
                                                                                              c.Width = 90
                                                                                              c.DropDownWidth = 200
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.ValueField = "spec_code"
                                                                                              c.TextField = "spec_code"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("spec_code", "Spec", 50)
                                                                                              c.Columns.Add("spec_description", "Description", 120)
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_sub_spec"
                                                         column.Caption = "SUB SPEC."
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.VisibleIndex = 7
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.EditFormSettings.VisibleIndex = 6
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.Width = 150
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "dr_quadrant"
                                                         column.Caption = "QUAD"
                                                         column.VisibleIndex = 8
                                                         column.EditFormSettings.VisibleIndex = 4
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterDoctorController.ComboQuad
                                                                                              c.Width = 100
                                                                                              c.DropDownWidth = 200
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.ValueField = "quadrant"
                                                                                              c.TextField = "quadrant"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("quadrant", "Quadrant", 50)
                                                                                              c.Columns.Add("description", "Description", 120)
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_monitoring"
                                                         column.Caption = "MONITORING"
                                                         column.VisibleIndex = 9
                                                         column.ColumnType = MVCxGridViewColumnType.Memo
                                                         column.EditFormSettings.VisibleIndex = 7
                                                         column.EditorProperties.Memo(Sub(c)
                                                                                          c.ValidationSettings.RequiredField.IsRequired = True
                                                                                      End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_address"
                                                         column.Caption = "ADDRESS"
                                                         column.ColumnType = MVCxGridViewColumnType.Memo
                                                         column.VisibleIndex = 10
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.EditFormSettings.VisibleIndex = 8
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "dr_area_mis"
                                                         column.Caption = "AREA MIS"
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.VisibleIndex = 11
                                                         column.EditFormSettings.VisibleIndex = 9
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.Width = 150
                                                                                              c.DropDownWidth = 80
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.Items.Add("WEST", "WEST")
                                                                                              c.Items.Add("EAST", "EAST")
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_sum"
                                                         column.Caption = "SUM"
                                                         column.VisibleIndex = 12
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.EditFormSettings.Visible = DefaultBoolean.False
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "dr_category"
                                                         column.Caption = "CTG."
                                                         column.VisibleIndex = 13
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.EditFormSettings.VisibleIndex = 10
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.DataSource = TANABE_MVC.MasterDoctorController.ComboCategory
                                                                                              c.Width = 150
                                                                                              c.DropDownWidth = 200
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.ValueField = "category_id"
                                                                                              c.TextField = "category_id"
                                                                                              c.ValueType = GetType(String)
                                                                                              c.Columns.Add("category_id", "Ctg.", 50)
                                                                                              c.Columns.Add("category_description", "Description", 120)
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_sub_category"
                                                         column.Caption = "SUB CTG."
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.VisibleIndex = 14
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.EditFormSettings.VisibleIndex = 11
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.Width = 150
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "dr_chanel"
                                                         column.Caption = "CHANNEL"
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.VisibleIndex = 15
                                                         column.EditFormSettings.VisibleIndex = 12
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.Width = 100
                                                                                              c.DropDownWidth = 100
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.Items.Add("PHARMACY", "PHARMACY")
                                                                                              c.Items.Add("HOSPITAL", "HOSPITAL")
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_day_visit"
                                                         column.Caption = "DAY VISIT"
                                                         column.VisibleIndex = 16
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.EditFormSettings.VisibleIndex = 13
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.Width = 150
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_visiting_hour"
                                                         column.Caption = "VISIT HOUR"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.VisibleIndex = 17
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.EditFormSettings.VisibleIndex = 14
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.Width = 150
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_number_patient"
                                                         column.Caption = "PATIENT NUMBER"
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.VisibleIndex = 18
                                                         column.EditFormSettings.VisibleIndex = 15
                                                         column.EditorProperties().SpinEdit(Sub(p)
                                                                                                p.NumberType = SpinEditNumberType.Integer
                                                                                                p.Width = 60
                                                                                                p.MinValue = 1
                                                                                                p.MaxValue = 100000
                                                                                                p.SpinButtons.ShowIncrementButtons = False
                                                                                                p.SpinButtons.ShowLargeIncrementButtons = False
                                                                                            End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "dr_kol_not"
                                                         column.Caption = "KOL/NOT"
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.VisibleIndex = 19
                                                         column.EditFormSettings.VisibleIndex = 16
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.Width = 60
                                                                                              c.DropDownWidth = 100
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.Items.Add("KOL", "KOL")
                                                                                              c.Items.Add("NOT", "NOT")
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "dr_gender"
                                                         column.Caption = "GENDER"
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.VisibleIndex = 20
                                                         column.EditFormSettings.VisibleIndex = 17
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.Width = 60
                                                                                              c.DropDownWidth = 100
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.Items.Add("L", "L")
                                                                                              c.Items.Add("P", "P")
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_phone"
                                                         column.Caption = "PHONE"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.VisibleIndex = 21
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.EditFormSettings.VisibleIndex = 18
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.Width = 100
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_email"
                                                         column.Caption = "EMAIL"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.VisibleIndex = 22
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.EditFormSettings.VisibleIndex = 19
                                                         column.EditorProperties.TextBox(Sub(c)
                                                                                             c.Width = 150
                                                                                         End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "dr_birthday"
                                                         column.Caption = "BIRTHDAY"
                                                         column.VisibleIndex = 23
                                                         column.ColumnType = MVCxGridViewColumnType.DateEdit
                                                         column.EditFormSettings.VisibleIndex = 20
                                                         column.EditorProperties.DateEdit(Sub(c)
                                                                                              c.Width = 150
                                                                                              c.DisplayFormatString = "dd/MM/yyyy"
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.FieldName = "dr_dk_lk"
                                                         column.Caption = "DK/LK"
                                                         column.CellStyle.Wrap = DefaultBoolean.True
                                                         column.VisibleIndex = 24
                                                         column.EditFormSettings.VisibleIndex = 21
                                                         column.EditorProperties.ComboBox(Sub(c)
                                                                                              c.Width = 60
                                                                                              c.DropDownWidth = 100
                                                                                              c.DropDownStyle = DropDownStyle.DropDownList
                                                                                              c.CallbackPageSize = 12
                                                                                              c.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                              c.TextFormatString = "{0}"
                                                                                              c.Items.Add("DK", "DK")
                                                                                              c.Items.Add("LK", "LK")
                                                                                              c.ValidationSettings.RequiredField.IsRequired = True
                                                                                          End Sub)
                                                     End Sub)
                                settings.Columns.Add(Sub(columnCheck)
                                                         columnCheck.Caption = "STATUS"
                                                         columnCheck.FieldName = "dr_status"
                                                         columnCheck.ColumnType = MVCxGridViewColumnType.CheckBox
                                                         columnCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean
                                                         columnCheck.VisibleIndex = 25
                                                         columnCheck.CellStyle.Wrap = DefaultBoolean.True
                                                         columnCheck.CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                         columnCheck.EditFormSettings.VisibleIndex = 22
                                                         Dim CheckBoxProperties = TryCast(columnCheck.PropertiesEdit, CheckBoxProperties)
                                                         CheckBoxProperties.ValueType = GetType(Integer)
                                                         CheckBoxProperties.ValueChecked = 1
                                                         CheckBoxProperties.ValueUnchecked = 0
                                                         CheckBoxProperties.ValidationSettings.RequiredField.IsRequired = True
                                                     End Sub)
                                     
                                settings.CommandColumn.ShowSelectCheckbox = True
                                     
                                settings.FillContextMenuItems = Sub(s, e)
                                                                    If (e.MenuType = GridViewContextMenuType.Rows) Then
                                                                        Dim item1 = e.Items.Add("Change SBO", "Mapping SBO")
                                                                        item1.BeginGroup = True
                                                                        Dim item2 = e.Items.Add("Change Status", "Mapping Status")
                                                                        item2.BeginGroup = True
                                                                        Dim item3 = e.Items.Add("Change Quadrant", "Mapping Quadrant")
                                                                        item3.BeginGroup = True
                                                                    End If
                                                                End Sub
                                settings.ClientSideEvents.ContextMenuItemClick = "function(s,e) { OnContextMenuItemClick(s, e); }"
                                settings.ClientSideEvents.ContextMenu = "OnContextMenu"
                                
                                settings.CustomJSProperties = Sub(s, e)
                                                                  If ViewData("RequestFlag") IsNot Nothing Then
                                                                      e.Properties("cpMessage") = ViewData("RequestFlag").ToString()
                                                                  End If
                                                              End Sub
                                
                                     
                                settings.ClientSideEvents.SelectionChanged = "SelectionChanged"
                            End Sub).Bind(Model).GetHtml()