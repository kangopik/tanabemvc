@ModelType System.Collections.IEnumerable

@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "DataView1"
                                     
                                settings.CallbackRouteValues = New With {.Controller = "target", .Action = "DataViewPartial"}
                                'settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "target", .Action = "updatetarget"}
                                settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "target", .Action = "deletetarget"}
                                'settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "target", .Action = "newtarget"}
                                     
                                settings.Settings.ShowGroupPanel = True

                                settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                                settings.SettingsPager.PageSize = 50
                                settings.ControlStyle.Paddings.Padding = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.ControlStyle.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.ControlStyle.BorderBottom.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.Width = Unit.Percentage(100)
                                settings.EnableRowsCache = True
                                settings.Settings.ShowFilterRow = True
                                settings.Settings.ShowFilterRowMenu = True
                                settings.Styles.Cell.Paddings.PaddingLeft = Unit.Pixel(1)
                                settings.Styles.Cell.Paddings.PaddingRight = Unit.Pixel(1)
                                settings.Styles.Cell.Font.Size = 7
                                settings.Styles.Header.Font.Size = 7
                                settings.Styles.GroupRow.Font.Size = 7
                                settings.Styles.Footer.Font.Size = 7
                                settings.Styles.Header.HorizontalAlign = HorizontalAlign.Center

                                settings.CommandColumn.Visible = True
                                settings.CommandColumn.Width = Unit.Pixel(450)
                                settings.CommandColumn.ShowNewButtonInHeader = True
                                settings.CommandColumn.ShowEditButton = True
                                settings.CommandColumn.ShowDeleteButton = True
                                settings.CommandColumn.ShowCancelButton = True
                                settings.CommandColumn.ShowUpdateButton = True
                                settings.CommandColumn.ButtonType = GridViewCommandButtonType.Image
                                settings.SettingsCommandButton.EditButton.Image.Url = "~/Content/Images/edit-icon2.png"
                                settings.SettingsCommandButton.DeleteButton.Image.Url = "~/Content/Images/delete-icon2.png"

                                settings.SettingsCommandButton.CancelButton.Image.Url = "~/Content/Images/cancel-icon2.png"
                                settings.SettingsCommandButton.UpdateButton.Image.Url = "~/Content/Images/update-icon2.png"

                                settings.SettingsCommandButton.NewButton.Image.Url = "~/Content/Images/add-icon2.png"
                                     
                                settings.SettingsPager.PageSize = 10
                                settings.SettingsPager.FirstPageButton.Visible = True
                                settings.SettingsPager.LastPageButton.Visible = True
                                settings.SettingsPager.PageSizeItemSettings.Visible = True
                                settings.SettingsPager.PageSizeItemSettings.Items = New String() {"5", "10", "20"}
                                     
                                settings.SettingsBehavior.ConfirmDelete = True
                                settings.SettingsEditing.Mode = GridViewEditingMode.Inline
                                settings.KeyFieldName = "target_id"



                                settings.Columns.Add("target_year", "YEAR", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                                           Html.DevExpress().TextBox(Sub(aso)
                                                                                                                                                                         aso.Name = "target_year"
                                                                                                                                                                         Dim param As String = String.Empty
                                                                                                                                                                         Try
                                                                                                                                                                             param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                         Catch ex As Exception
                                                                                                                                                                             param = "err"
                                                                                                                                                                         End Try

                                                                                                                                                                         If param <> "err" Then
                                                                                                                                                                             aso.Text = param
                                                                                                                                                                             aso.ReadOnly = column.Grid.IsEditing
                                                                                                                                                                         Else
                                                                                                                                                                             aso.Text = ""
                                                                                                                                                                         End If

                                                                                                                                                                         aso.Width = Unit.Percentage(100)
                                                                                                                                                                     End Sub).GetHtml()




                                                                                                                                       End Sub)

                                settings.Columns.Add("target_month", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                                    Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                                  typ.Name = "target_month"
                                                                                                                                                                  Dim param As String = String.Empty
                                                                                                                                                                  Try
                                                                                                                                                                      param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                  Catch ex As Exception
                                                                                                                                                                      param = "err"
                                                                                                                                                                  End Try

                                                                                                                                                                  If param <> "err" Then
                                                                                                                                                                      typ.Text = param
                                                                                                                                                                  Else
                                                                                                                                                                      typ.Text = ""
                                                                                                                                                                  End If

                                                                                                                                                                  typ.Width = Unit.Percentage(100)
                                                                                                                                                              End Sub).GetHtml()


                                                                                                                                End Sub)
                                settings.Columns.Add("target_sbo", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                                  Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                                typ.Name = "target_sbo"
                                                                                                                                                                Dim param As String = String.Empty
                                                                                                                                                                Try
                                                                                                                                                                    param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                Catch ex As Exception
                                                                                                                                                                    param = "err"
                                                                                                                                                                End Try

                                                                                                                                                                If param <> "err" Then
                                                                                                                                                                    typ.Text = param
                                                                                                                                                                Else
                                                                                                                                                                    typ.Text = ""
                                                                                                                                                                End If

                                                                                                                                                                typ.Width = Unit.Percentage(100)
                                                                                                                                                            End Sub).GetHtml()


                                                                                                                              End Sub)
                                     
                                settings.Columns.Add("target_product_code", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                                           Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                                         typ.Name = "target_product_code"
                                                                                                                                                                         Dim param As String = String.Empty
                                                                                                                                                                         Try
                                                                                                                                                                             param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                         Catch ex As Exception
                                                                                                                                                                             param = "err"
                                                                                                                                                                         End Try

                                                                                                                                                                         If param <> "err" Then
                                                                                                                                                                             typ.Text = param
                                                                                                                                                                         Else
                                                                                                                                                                             typ.Text = ""
                                                                                                                                                                         End If

                                                                                                                                                                         typ.Width = Unit.Percentage(100)
                                                                                                                                                                     End Sub).GetHtml()


                                                                                                                                       End Sub)
                                     
                                settings.Columns.Add("prd_aso_desc", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                                    Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                                  typ.Name = "prd_aso_desc"
                                                                                                                                                                  Dim param As String = String.Empty
                                                                                                                                                                  Try
                                                                                                                                                                      param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                  Catch ex As Exception
                                                                                                                                                                      param = "err"
                                                                                                                                                                  End Try

                                                                                                                                                                  If param <> "err" Then
                                                                                                                                                                      typ.Text = param
                                                                                                                                                                  Else
                                                                                                                                                                      typ.Text = ""
                                                                                                                                                                  End If

                                                                                                                                                                  typ.Width = Unit.Percentage(100)
                                                                                                                                                              End Sub).GetHtml()


                                                                                                                                End Sub)
                                     
                                settings.Columns.Add(Sub(column)
                                                         column.Name = "target_description"
                                                         column.FieldName = "target_description"
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox

                                                         With DirectCast(column.PropertiesEdit, ComboBoxProperties)
                                                             .Items.Add("")
                                                             .Items.Add("TARGET")
                                                             .Items.Add("TARGET REVISI")
                                                             .Items.Add("TARGET SECTOR")
                                                             .Items.Add("TARGET SECTOR REVISI")
                                                         End With

                                                         column.SetEditItemTemplateContent(Sub(c)
                                                                                               Html.DevExpress().ComboBox(Sub(typ)
                                                                                                                              typ.Name = "target_description"
                                                                                                                              Dim param As String = String.Empty
                                                                                                                              Try
                                                                                                                                  param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                              Catch ex As Exception
                                                                                                                                  param = "err"
                                                                                                                              End Try

                                                                                                                              If param <> "err" Then

                                                                                                                                  If param = "TARGET" Then
                                                                                                                                      typ.SelectedIndex = 0
                                                                                                                                  ElseIf param = "TARGET REVISI" Then
                                                                                                                                      typ.SelectedIndex = 1
                                                                                                                                  ElseIf param = "TARGET SECTOR" Then
                                                                                                                                      typ.SelectedIndex = 2
                                                                                                                                  Else
                                                                                                                                      typ.SelectedIndex = 3
                                                                                                                                  End If
                                                                                                                              End If


                                                                                                                              typ.Width = Unit.Percentage(100)
                                                                                                                              typ.Properties.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
                                                                                                                              typ.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                                                              typ.Properties.Items.Add("TARGET")
                                                                                                                              typ.Properties.Items.Add("TARGET REVISI")
                                                                                                                              typ.Properties.Items.Add("TARGET SECTOR")
                                                                                                                              typ.Properties.Items.Add("TARGET SECTOR REVISI")
                                                                                                                          End Sub).GetHtml()


                                                                                           End Sub)

                                                     End Sub)
                                     
                                
                                settings.Columns.Add("prd_aso_category", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                                        Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                                      typ.Name = "prd_aso_category"
                                                                                                                                                                      Dim param As String = String.Empty
                                                                                                                                                                      Try
                                                                                                                                                                          param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                      Catch ex As Exception
                                                                                                                                                                          param = "err"
                                                                                                                                                                      End Try

                                                                                                                                                                      If param <> "err" Then
                                                                                                                                                                          typ.Text = param
                                                                                                                                                                      Else
                                                                                                                                                                          typ.Text = ""
                                                                                                                                                                      End If

                                                                                                                                                                      typ.Width = Unit.Percentage(100)
                                                                                                                                                                  End Sub).GetHtml()


                                                                                                                                    End Sub)
                                settings.Columns.Add("prd_aso_price", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                                     Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                                   typ.Name = "prd_aso_price"
                                                                                                                                                                   Dim param As String = String.Empty
                                                                                                                                                                   Try
                                                                                                                                                                       param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                   Catch ex As Exception
                                                                                                                                                                       param = "err"
                                                                                                                                                                   End Try

                                                                                                                                                                   If param <> "err" Then
                                                                                                                                                                       typ.Text = param
                                                                                                                                                                   Else
                                                                                                                                                                       typ.Text = ""
                                                                                                                                                                   End If

                                                                                                                                                                   typ.Width = Unit.Percentage(100)
                                                                                                                                                               End Sub).GetHtml()


                                                                                                                                 End Sub)
                                settings.Columns.Add("target_plan_qty", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                                       Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                                     typ.Name = "target_plan_qty"
                                                                                                                                                                     Dim param As String = String.Empty
                                                                                                                                                                     Try
                                                                                                                                                                         param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                     Catch ex As Exception
                                                                                                                                                                         param = "err"
                                                                                                                                                                     End Try

                                                                                                                                                                     If param <> "err" Then
                                                                                                                                                                         typ.Text = param
                                                                                                                                                                     Else
                                                                                                                                                                         typ.Text = ""
                                                                                                                                                                     End If

                                                                                                                                                                     typ.Width = Unit.Percentage(100)
                                                                                                                                                                 End Sub).GetHtml()


                                                                                                                                   End Sub)
                                settings.Columns.Add("target_plan_value", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                                         Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                                       typ.Name = "target_plan_value"
                                                                                                                                                                       Dim param As String = String.Empty
                                                                                                                                                                       Try
                                                                                                                                                                           param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                       Catch ex As Exception
                                                                                                                                                                           param = "err"
                                                                                                                                                                       End Try

                                                                                                                                                                       If param <> "err" Then
                                                                                                                                                                           typ.Text = param
                                                                                                                                                                       Else
                                                                                                                                                                           typ.Text = ""
                                                                                                                                                                       End If

                                                                                                                                                                       typ.Width = Unit.Percentage(100)
                                                                                                                                                                   End Sub).GetHtml()


                                                                                                                                     End Sub)
                                     
                                settings.Columns.Add("rep_name", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                                Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                              typ.Name = "rep_name"
                                                                                                                                                              Dim param As String = String.Empty
                                                                                                                                                              Try
                                                                                                                                                                  param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                              Catch ex As Exception
                                                                                                                                                                  param = "err"
                                                                                                                                                              End Try

                                                                                                                                                              If param <> "err" Then
                                                                                                                                                                  typ.Text = param
                                                                                                                                                              Else
                                                                                                                                                                  typ.Text = ""
                                                                                                                                                              End If

                                                                                                                                                              typ.Width = Unit.Percentage(100)
                                                                                                                                                          End Sub).GetHtml()


                                                                                                                            End Sub)
                                settings.Columns.Add("rep_bo", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                              Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                            typ.Name = "rep_bo"
                                                                                                                                                            Dim param As String = String.Empty
                                                                                                                                                            Try
                                                                                                                                                                param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                            Catch ex As Exception
                                                                                                                                                                param = "err"
                                                                                                                                                            End Try

                                                                                                                                                            If param <> "err" Then
                                                                                                                                                                typ.Text = param
                                                                                                                                                            Else
                                                                                                                                                                typ.Text = ""
                                                                                                                                                            End If

                                                                                                                                                            typ.Width = Unit.Percentage(100)
                                                                                                                                                        End Sub).GetHtml()


                                                                                                                          End Sub)
                                     
                                settings.Columns.Add("nama_am", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                               Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                             typ.Name = "nama_am"
                                                                                                                                                             Dim param As String = String.Empty
                                                                                                                                                             Try
                                                                                                                                                                 param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                             Catch ex As Exception
                                                                                                                                                                 param = "err"
                                                                                                                                                             End Try

                                                                                                                                                             If param <> "err" Then
                                                                                                                                                                 typ.Text = param
                                                                                                                                                             Else
                                                                                                                                                                 typ.Text = ""
                                                                                                                                                             End If

                                                                                                                                                             typ.Width = Unit.Percentage(100)
                                                                                                                                                         End Sub).GetHtml()


                                                                                                                           End Sub)
                                     
                                settings.Columns.Add("nama_rm", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                               Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                             typ.Name = "nama_rm"
                                                                                                                                                             Dim param As String = String.Empty
                                                                                                                                                             Try
                                                                                                                                                                 param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                             Catch ex As Exception
                                                                                                                                                                 param = "err"
                                                                                                                                                             End Try

                                                                                                                                                             If param <> "err" Then
                                                                                                                                                                 typ.Text = param
                                                                                                                                                             Else
                                                                                                                                                                 typ.Text = ""
                                                                                                                                                             End If

                                                                                                                                                             typ.Width = Unit.Percentage(100)
                                                                                                                                                         End Sub).GetHtml()


                                                                                                                           End Sub)
                                settings.Columns.Add("rep_region", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)

                                                                                                                                  Html.DevExpress().TextBox(Sub(typ)
                                                                                                                                                                typ.Name = "rep_region"
                                                                                                                                                                Dim param As String = String.Empty
                                                                                                                                                                Try
                                                                                                                                                                    param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                Catch ex As Exception
                                                                                                                                                                    param = "err"
                                                                                                                                                                End Try

                                                                                                                                                                If param <> "err" Then
                                                                                                                                                                    typ.Text = param
                                                                                                                                                                Else
                                                                                                                                                                    typ.Text = ""
                                                                                                                                                                End If

                                                                                                                                                                typ.Width = Unit.Percentage(100)
                                                                                                                                                            End Sub).GetHtml()
                                                                                                                              End Sub)

                                settings.Columns(0).Caption = "YEAR"
                                settings.Columns(1).Caption = "MONTH"
                                settings.Columns(2).Caption = "SBO"
                                settings.Columns(3).Caption = "CODE"
                                settings.Columns(4).Caption = "DESCRIPTION"
                                settings.Columns(5).Caption = "DATA TYPE"
                                settings.Columns(6).Caption = "CATEGORY"
                                settings.Columns(7).Caption = "PRICE"
                                settings.Columns(8).Caption = "PLAN QTY"
                                settings.Columns(9).Caption = "PLAN VALUE"
                                settings.Columns(10).Caption = "MR"
                                settings.Columns(11).Caption = "BO"
                                settings.Columns(12).Caption = "AM"
                                settings.Columns(13).Caption = "RM"
                                settings.Columns(14).Caption = "REG"

                                For i As Integer = 0 To 14
                                    settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                    settings.Columns(i).CellStyle.VerticalAlign = VerticalAlign.Middle
                                    settings.Columns(i).CellStyle.Font.Size = 7
                                    If i = 4 Then
                                        settings.Columns(i).Width = 1500
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Left
                                        settings.Columns(i).CellStyle.Paddings.PaddingLeft = 5
                                    ElseIf i = 10 Then
                                        settings.Columns(i).Width = 900
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                    ElseIf i = 12 Or i = 13 Then
                                        settings.Columns(i).Width = 1000
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Left
                                        settings.Columns(i).CellStyle.Paddings.PaddingLeft = 5
                                    Else
                                        settings.Columns(i).Width = 150
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                    End If
                                Next

                               
                            End Sub).Bind(Model).GetHtml()

