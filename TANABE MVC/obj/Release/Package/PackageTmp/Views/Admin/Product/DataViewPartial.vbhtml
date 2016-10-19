@ModelType System.Collections.IEnumerable

@code
    Html.EnableClientValidation()
    Html.EnableUnobtrusiveJavaScript()
    
    Dim vp As New TANABE_MVC.TANABE_MVC.Models.ProductClass
    Dim model_pm = Nothing
    model_pm = vp.GetDataPM
    
       
End Code
@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "DataView1"
                                settings.CallbackRouteValues = New With {.Controller = "product", .Action = "DataViewPartial"}
                                'settings.CustomActionRouteValues = New With {.Controller = "Editing", .Action = "ChangeEditModePartial"}
                              
                                settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "product", .Action = "updateproduct"}
                                settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "product", .Action = "deleteproduct"}
                                settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "product", .Action = "newproduct"}
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
                                settings.CommandColumn.Width = Unit.Pixel(250)
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
                                settings.KeyFieldName = "prd_aso_id"
                              
                               
                                     
                                settings.Columns.Add("prd_aso_id", "CODE", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)
                                                                                                                                            
                                                                                                                                          Html.DevExpress().TextBox(Sub(aso)
                                                                                                                                                                        aso.Name = "prd_aso_id"
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
                                                         column.Name = "prd_aso_type"
                                                         column.FieldName = "prd_aso_type"
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         
                                                         With DirectCast(column.PropertiesEdit, ComboBoxProperties)
                                                             .Items.Add("")
                                                             .Items.Add("MIX")
                                                             .Items.Add("BI")
                                                         End With
                                                         
                                                         column.SetEditItemTemplateContent(Sub(c)
                                                                                               Html.DevExpress().ComboBox(Sub(typ)
                                                                                                                              typ.Name = "prd_aso_type"
                                                                                                                              Dim param As String = String.Empty
                                                                                                                              Try
                                                                                                                                  param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                              Catch ex As Exception
                                                                                                                                  param = "err"
                                                                                                                              End Try
                                                                                                                                                                        
                                                                                                                              If param <> "err" Then
                                                                                                                                 
                                                                                                                                  If param = "MIX" Then
                                                                                                                                      typ.SelectedIndex = 0
                                                                                                                                  Else
                                                                                                                                      typ.SelectedIndex = 1
                                                                                                                                  End If
                                                                                                                              End If
                                                                                                                                                                 
                                                                                                                           
                                                                                                                              typ.Width = Unit.Percentage(100)
                                                                                                                              typ.Properties.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
                                                                                                                              typ.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                                                              typ.Properties.Items.Add("MIX")
                                                                                                                              typ.Properties.Items.Add("BI")
                                                                                                                          End Sub).GetHtml()


                                                                                           End Sub)
                                                         
                                                     End Sub)
                                     
                                
                                settings.Columns.Add(Sub(column)
                                                         column.Name = "prd_aso_category"
                                                         column.FieldName = "prd_aso_category"
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         
                                                         With DirectCast(column.PropertiesEdit, ComboBoxProperties)
                                                             .Items.Add("")
                                                             .Items.Add("BPJS")
                                                             .Items.Add("REGULAR")
                                                         End With
                                                         
                                                         column.SetEditItemTemplateContent(Sub(c)
                                                                                               Html.DevExpress().ComboBox(Sub(typ)
                                                                                                                              typ.Name = "prd_aso_category"
                                                                                                                              Dim param As String = String.Empty
                                                                                                                              Try
                                                                                                                                  param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                              Catch ex As Exception
                                                                                                                                  param = "err"
                                                                                                                              End Try
                                                                                                                                                                        
                                                                                                                              If param <> "err" Then
                                                                                                                                 
                                                                                                                                  If param = "BPJS" Then
                                                                                                                                      typ.SelectedIndex = 0
                                                                                                                                  Else
                                                                                                                                      typ.SelectedIndex = 1
                                                                                                                                  End If
                                                                                                                              End If
                                                                                                                              
                                                                                                                                                          
                                                                                                                              typ.Width = Unit.Percentage(100)
                                                                                                                              typ.Properties.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
                                                                                                                              typ.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                                                              typ.Properties.Items.Add("BPJS")
                                                                                                                              typ.Properties.Items.Add("REGULAR")
                                                                                                                          End Sub).GetHtml()


                                                                                           End Sub)
                                                         
                                                     End Sub)
                                     
                                     
                               
                                     
                              
                                     
                                settings.Columns.Add("prd_aso_hna_bpjs", MVCxGridViewColumnType.SpinEdit).SetEditItemTemplateContent(Sub(column)

                                                                                                                                         Html.DevExpress().SpinEdit(Sub(hna)
                                                                                                                                                                        hna.Name = "prd_aso_hna_bpjs"
                                                                                                                                                                        Dim param As String = String.Empty
                                                                                                                                                                        Try
                                                                                                                                                                            param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                        Catch ex As Exception
                                                                                                                                                                            param = "err"
                                                                                                                                                                        End Try
                                                                                                                                                                        
                                                                                                                                                                        If param <> "err" Then
                                                                                                                                                                            hna.Number = DataBinder.Eval(column.DataItem, column.Column.FieldName)
                                                                                                                                                                        End If
                                                                                                                                                                                                                                                                                                                                               
                                                                                                                                                                        hna.Width = Unit.Percentage(100)
                                                                                                                                                                        hna.Properties.SpinButtons.ShowLargeIncrementButtons = False
                                                                                                                                                                        hna.Properties.SpinButtons.ShowIncrementButtons = False
                                                                                                                                                                        hna.Properties.LargeIncrement = 10
                                                                                                                                                                        hna.Properties.Increment = 1
                                                                                                                                                                        hna.Properties.NumberType = SpinEditNumberType.Float
                                                                                                                                                                    End Sub).GetHtml()


                                                                                                                                     End Sub)



                                settings.Columns.Add("prd_aso_price", MVCxGridViewColumnType.SpinEdit).SetEditItemTemplateContent(Sub(column)
                                                                                                                                   

                                                                                                                                      Html.DevExpress().SpinEdit(Sub(price)
                                                                                                                                                                     price.Name = "prd_aso_price"
                                                                                                                                                                     price.Width = Unit.Percentage(100)
                                                                                                                                                                     Dim param As String = String.Empty
                                                                                                                                                                     Try
                                                                                                                                                                         param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                                                                                                                                                     Catch ex As Exception
                                                                                                                                                                         param = "err"
                                                                                                                                                                     End Try
                                                                                                                                                                        
                                                                                                                                                                     If param <> "err" Then
                                                                                                                                                                         price.Number = DataBinder.Eval(column.DataItem, column.Column.FieldName)
                                                                                                                                                                     End If
                                                                                                                                                                     
                                                                                                                                                                    
                                                                                                                                                                     price.Properties.SpinButtons.ShowIncrementButtons = True
                                                                                                                                                                     price.Properties.LargeIncrement = 10
                                                                                                                                                                     price.Properties.Increment = 1
                                                                                                                                                                     price.Properties.NumberType = SpinEditNumberType.Float
                                                                                                                                                                 End Sub).GetHtml()


                                                                                                                                  End Sub)
                                     
                                
                                     
                                settings.Columns.Add(Sub(column)
                                                         column.Name = "prd_aso_gp"
                                                         column.FieldName = "prd_aso_gp"
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         
                                                         With DirectCast(column.PropertiesEdit, ComboBoxProperties)
                                                             .Items.Add("")
                                                             .Items.Add("BIO-R")
                                                             .Items.Add("BIO-S")
                                                             .Items.Add("HER")
                                                             .Items.Add("LIV")
                                                             .Items.Add("MAIN")
                                                             .Items.Add("NCV")
                                                             .Items.Add("TAN")
                                                             .Items.Add("TAON")
                                                         End With
                                                         
                                                         column.SetEditItemTemplateContent(Sub(c)
                                                                                               Html.DevExpress().ComboBox(Sub(gp)
                                                                                                                              gp.Name = "prd_aso_gp"
                                                                                                                              Dim param As String = String.Empty
                                                                                                                              Try
                                                                                                                                  param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                              Catch ex As Exception
                                                                                                                                  param = "err"
                                                                                                                              End Try
                                                                                                                                                                        
                                                                                                                              If param <> "err" Then
                                                                                                                                  Dim val As String = param
                                                                                                                                  If val = "BIO-R" Then
                                                                                                                                      gp.SelectedIndex = 0
                                                                                                                                  ElseIf val = "BIO-S" Then
                                                                                                                                      gp.SelectedIndex = 1
                                                                                                                                  ElseIf val = "HER" Then
                                                                                                                                      gp.SelectedIndex = 2
                                                                                                                                  ElseIf val = "LIV" Then
                                                                                                                                      gp.SelectedIndex = 3
                                                                                                                                  ElseIf val = "MAIN" Then
                                                                                                                                      gp.SelectedIndex = 4
                                                                                                                                  ElseIf val = "NCV" Then
                                                                                                                                      gp.SelectedIndex = 5
                                                                                                                                  ElseIf val = "TAN" Then
                                                                                                                                      gp.SelectedIndex = 6
                                                                                                                                  Else
                                                                                                                                      gp.SelectedIndex = 7
                                                                                                                                  End If
                                                                                                                              End If
                                                                                                                              
                                                                                                                             
                                                                                                                              gp.Width = Unit.Percentage(100)
                                                                                                                              gp.Properties.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
                                                                                                                              gp.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                                                              gp.Properties.Items.Add("BIO-R")
                                                                                                                              gp.Properties.Items.Add("BIO-S")
                                                                                                                              gp.Properties.Items.Add("HER")
                                                                                                                              gp.Properties.Items.Add("LIV")
                                                                                                                              gp.Properties.Items.Add("MAIN")
                                                                                                                              gp.Properties.Items.Add("NCV")
                                                                                                                              gp.Properties.Items.Add("TAN")
                                                                                                                              gp.Properties.Items.Add("TAON")
                                                                                                                          End Sub).GetHtml()


                                                                                           End Sub)
                                                         
                                                     End Sub)
                                     
                                settings.Columns.Add(Sub(column)
                                                         column.Name = "prd_aso_ose"
                                                         column.FieldName = "prd_aso_ose"
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         
                                                         With DirectCast(column.PropertiesEdit, ComboBoxProperties)
                                                             .Items.Add("")
                                                             .Items.Add("OTC")
                                                             .Items.Add("RED-DOT")
                                                         End With
                                                         
                                                         column.SetEditItemTemplateContent(Sub(c)
                                                                                               Html.DevExpress().ComboBox(Sub(gp)
                                                                                                                              gp.Name = "prd_aso_ose"
                                                                                                                              Dim param As String = String.Empty
                                                                                                                              Try
                                                                                                                                  param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                              Catch ex As Exception
                                                                                                                                  param = "err"
                                                                                                                              End Try
                                                                                                                                                                        
                                                                                                                              If param <> "err" Then
                                                                                                                                  Dim val As String = param
                                                                                                                                  If val = "OTC" Then
                                                                                                                                      gp.SelectedIndex = 0
                                                                                                                                  Else
                                                                                                                                      gp.SelectedIndex = 1
                                                                                                                                  End If
                                                                                                                              End If
                                                                                                                              
                                                                                                                              
                                                                                                                              gp.Width = Unit.Percentage(100)
                                                                                                                              gp.Properties.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
                                                                                                                              gp.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                                                              gp.Properties.Items.Add("OTC")
                                                                                                                              gp.Properties.Items.Add("RED-DOT")
                                                                                                                          End Sub).GetHtml()


                                                                                           End Sub)
                                                         
                                                     End Sub)
                                     
                                settings.Columns.Add(Sub(column)
                                                         column.Name = "prd_aso_group"
                                                         column.FieldName = "prd_aso_group"
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         
                                                         With DirectCast(column.PropertiesEdit, ComboBoxProperties)
                                                             .Items.Add("")
                                                             .Items.Add("BIO")
                                                             .Items.Add("HER-CD")
                                                             .Items.Add("HER-INJ")
                                                             .Items.Add("HER-ORAL")
                                                             .Items.Add("LIV")
                                                             .Items.Add("MAIN")
                                                             .Items.Add("NCV")
                                                             .Items.Add("TAN")
                                                             .Items.Add("TAON")
                                                         End With
                                                         
                                                         column.SetEditItemTemplateContent(Sub(c)
                                                                                               Html.DevExpress().ComboBox(Sub(gp)
                                                                                                                              gp.Name = "prd_aso_group"
                                                                                                                              Dim param As String = String.Empty
                                                                                                                              Try
                                                                                                                                  param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                              Catch ex As Exception
                                                                                                                                  param = "err"
                                                                                                                              End Try
                                                                                                                                                                        
                                                                                                                              If param <> "err" Then
                                                                                                                                  Dim val As String = param
                                                                                                                                  If val = "BIO" Then
                                                                                                                                      gp.SelectedIndex = 0
                                                                                                                                  ElseIf val = "HER-CD" Then
                                                                                                                                      gp.SelectedIndex = 1
                                                                                                                                  ElseIf val = "HER-INJ" Then
                                                                                                                                      gp.SelectedIndex = 2
                                                                                                                                  ElseIf val = "HER-ORAL" Then
                                                                                                                                      gp.SelectedIndex = 3
                                                                                                                                  ElseIf val = "LIV" Then
                                                                                                                                      gp.SelectedIndex = 4
                                                                                                                                  ElseIf val = "MAIN" Then
                                                                                                                                      gp.SelectedIndex = 5
                                                                                                                                  ElseIf val = "NCV" Then
                                                                                                                                      gp.SelectedIndex = 6
                                                                                                                                  ElseIf val = "TAN" Then
                                                                                                                                      gp.SelectedIndex = 7
                                                                                                                                  Else
                                                                                                                                      gp.SelectedIndex = 8
                                                                                                                                  End If
                                                                                                                              End If
                                                                                                                              
                                                                                                                              
                                                                                                                              gp.Width = Unit.Percentage(100)
                                                                                                                              gp.Properties.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
                                                                                                                              gp.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                                                              gp.Properties.Items.Add("BIO")
                                                                                                                              gp.Properties.Items.Add("HER-CD")
                                                                                                                              gp.Properties.Items.Add("HER-INJ")
                                                                                                                              gp.Properties.Items.Add("HER-ORAL")
                                                                                                                              gp.Properties.Items.Add("LIV")
                                                                                                                              gp.Properties.Items.Add("MAIN")
                                                                                                                              gp.Properties.Items.Add("NCV")
                                                                                                                              gp.Properties.Items.Add("TAN")
                                                                                                                              gp.Properties.Items.Add("TAON")
                                                                                                                          End Sub).GetHtml()


                                                                                           End Sub)
                                                         
                                                     End Sub)
                            
                                settings.Columns.Add(Sub(column)
                                                         column.Name = "prd_aso_group_fin"
                                                         column.FieldName = "prd_aso_group_fin"
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         
                                                         With DirectCast(column.PropertiesEdit, ComboBoxProperties)
                                                             .Items.Add("")
                                                             .Items.Add("AC 17 - GROUP")
                                                             .Items.Add("ASKES / BPJS")
                                                             .Items.Add("HER - GROUP")
                                                             .Items.Add("LIVALO")
                                                             .Items.Add("MAIN - GROUP")
                                                             .Items.Add("OTHER")
                                                             .Items.Add("REC")
                                                             .Items.Add("SIMPONI")
                                                             .Items.Add("TAL - GROUP")
                                                             .Items.Add("TAON")
                                                         End With
                                                         
                                                         column.SetEditItemTemplateContent(Sub(c)
                                                                                               Html.DevExpress().ComboBox(Sub(gp)
                                                                                                                              gp.Name = "prd_aso_group_fin"
                                                                                                                              Dim param As String = String.Empty
                                                                                                                              Try
                                                                                                                                  param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                              Catch ex As Exception
                                                                                                                                  param = "err"
                                                                                                                              End Try
                                                                                                                                                                        
                                                                                                                              If param <> "err" Then
                                                                                                                                  Dim val As String = param
                                                                                                                                  If val = "AC 17 - GROUP" Then
                                                                                                                                      gp.SelectedIndex = 0
                                                                                                                                  ElseIf val = "ASKES / BPJS" Then
                                                                                                                                      gp.SelectedIndex = 1
                                                                                                                                  ElseIf val = "HER - GROUP" Then
                                                                                                                                      gp.SelectedIndex = 2
                                                                                                                                  ElseIf val = "LIVALO" Then
                                                                                                                                      gp.SelectedIndex = 3
                                                                                                                                  ElseIf val = "MAIN - GROUP" Then
                                                                                                                                      gp.SelectedIndex = 4
                                                                                                                                  ElseIf val = "OTHER" Then
                                                                                                                                      gp.SelectedIndex = 5
                                                                                                                                  ElseIf val = "REC" Then
                                                                                                                                      gp.SelectedIndex = 6
                                                                                                                                  ElseIf val = "SIMPONI" Then
                                                                                                                                      gp.SelectedIndex = 7
                                                                                                                                  ElseIf val = "TAL - GROUP" Then
                                                                                                                                      gp.SelectedIndex = 8
                                                                                                                                  Else
                                                                                                                                      gp.SelectedIndex = 9
                                                                                                                                  End If
                                                                                                                              End If
                                                                                                                              
                                                                                                                                   
                                                                                                                              gp.Width = Unit.Percentage(100)
                                                                                                                              gp.Properties.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
                                                                                                                              gp.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                                                              gp.Properties.Items.Add("AC 17 - GROUP")
                                                                                                                              gp.Properties.Items.Add("ASKES / BPJS")
                                                                                                                              gp.Properties.Items.Add("HER - GROUP")
                                                                                                                              gp.Properties.Items.Add("LIVALO")
                                                                                                                              gp.Properties.Items.Add("MAIN - GROUP")
                                                                                                                              gp.Properties.Items.Add("OTHER")
                                                                                                                              gp.Properties.Items.Add("REC")
                                                                                                                              gp.Properties.Items.Add("SIMPONI")
                                                                                                                              gp.Properties.Items.Add("TAL - GROUP")
                                                                                                                              gp.Properties.Items.Add("TAON")
                                                                                                                          End Sub).GetHtml()


                                                                                           End Sub)
                                                         
                                                     End Sub)
                                     
                              


                                settings.Columns.Add("prd_aso_tab", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(c)
                                                                                                                                   Html.DevExpress().TextBox(Sub(aso)
                                                                                                                                                                 aso.Name = "prd_aso_tab"
                                                                                                                                                                 Dim param As String = String.Empty
                                                                                                                                                                 Try
                                                                                                                                                                     param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                                                                 Catch ex As Exception
                                                                                                                                                                     param = "err"
                                                                                                                                                                 End Try
                                                                                                                                                                        
                                                                                                                                                                 If param <> "err" Then
                                                                                                                                                                     aso.Text = param
                                                                                                                                                                 Else
                                                                                                                                                                     aso.Text = ""
                                                                                                                                                                 End If
                                                                                                                                                                
                                                                                                                                                                 aso.Width = Unit.Percentage(100)
                                                                                                                                                             End Sub).GetHtml()




                                                                                                                               End Sub)

                                settings.Columns.Add("prd_aso_dossage", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(c)


                                                                                                                                       Html.DevExpress().TextBox(Sub(aso)
                                                                                                                                                                     aso.Name = "prd_aso_dossage"
                                                                                                                                                                     Dim param As String = String.Empty
                                                                                                                                                                     Try
                                                                                                                                                                         param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                                                                     Catch ex As Exception
                                                                                                                                                                         param = "err"
                                                                                                                                                                     End Try
                                                                                                                                                                        
                                                                                                                                                                     If param <> "err" Then
                                                                                                                                                                         aso.Text = param
                                                                                                                                                                     Else
                                                                                                                                                                         aso.Text = ""
                                                                                                                                                                     End If
                                                                                                                                                                    
                                                                                                                                                                     aso.Width = Unit.Percentage(100)
                                                                                                                                                                 End Sub).GetHtml()




                                                                                                                                   End Sub)
                                     
                                
                                settings.Columns.Add("prd_aso_dostime", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(c)


                                                                                                                                       Html.DevExpress().TextBox(Sub(aso)
                                                                                                                                                                     aso.Name = "prd_aso_dostime"
                                                                                                                                                                     Dim param As String = String.Empty
                                                                                                                                                                     Try
                                                                                                                                                                         param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                                                                     Catch ex As Exception
                                                                                                                                                                         param = "err"
                                                                                                                                                                     End Try
                                                                                                                                                                        
                                                                                                                                                                     If param <> "err" Then
                                                                                                                                                                         aso.Text = param
                                                                                                                                                                     Else
                                                                                                                                                                         aso.Text = ""
                                                                                                                                                                     End If
                                                                                                                                                                     aso.Width = Unit.Percentage(100)
                                                                                                                                                                 End Sub).GetHtml()




                                                                                                                                   End Sub)
                                     
                                
                                     
                                settings.Columns.Add(Sub(column)
                                                         column.Name = "prd_aso_tc"
                                                         column.FieldName = "prd_aso_tc"
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         
                                                         With DirectCast(column.PropertiesEdit, ComboBoxProperties)
                                                             .Items.Add("")
                                                             .Items.Add("BIO")
                                                             .Items.Add("CV")
                                                             .Items.Add("NCV")
                                                         End With
                                                         
                                                         column.SetEditItemTemplateContent(Sub(c)
                                                                                               Html.DevExpress().ComboBox(Sub(gp)
                                                                                                                              gp.Name = "prd_aso_tc"
                                                                                                                              Dim param As String = String.Empty
                                                                                                                              Try
                                                                                                                                  param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                              Catch ex As Exception
                                                                                                                                  param = "err"
                                                                                                                              End Try
                                                                                                                                                                        
                                                                                                                              If param <> "err" Then
                                                                                                                                  Dim val As String = param
                                                                                                                                  If val = "BIO" Then
                                                                                                                                      gp.SelectedIndex = 0
                                                                                                                                  ElseIf val = "CV" Then
                                                                                                                                      gp.SelectedIndex = 1
                                                                                                                                  Else
                                                                                                                                      gp.SelectedIndex = 2
                                                                                                                                  End If
                                                                                                                              End If
                                                                                                                              
                                                                                                                             
                                                                                                                              gp.Width = Unit.Percentage(100)
                                                                                                                              gp.Properties.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
                                                                                                                              gp.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                                                              gp.Properties.Items.Add("BIO")
                                                                                                                              gp.Properties.Items.Add("CV")
                                                                                                                              gp.Properties.Items.Add("NCV")
                                                                                                                          End Sub).GetHtml()


                                                                                           End Sub)
                                                         
                                                     End Sub)
                                     
                                
                                     
                                settings.Columns.Add(Sub(column)
                                                         column.Name = "nama_pm"
                                                         column.FieldName = "nama_pm"
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         column.Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                                         With DirectCast(column.PropertiesEdit, ComboBoxProperties)
                                                             .Items.Add("")
                                                             .DropDownWidth = 250
                                                             .DropDownStyle = DropDownStyle.DropDownList
                                                             .CallbackPageSize = 30
                                                             .IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
                                                             .TextFormatString = "{1}"
                                                             .ValueField = "num"
                                                             .Columns.Add("nik", "NIK", Unit.Percentage(20))
                                                             .Columns.Add("name", "NAME", Unit.Percentage(80))
                                                             .DataSource = model_pm
                                                         End With
                                                         
                                                         column.SetEditItemTemplateContent(Sub(c)
                                                                                               Html.DevExpress().ComboBox(Sub(pm)
                                                                                                                              pm.Name = "nama_pm"
                                                                                                                              Dim param As String = String.Empty
                                                                                                                              Try
                                                                                                                                  param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                                                                                              Catch ex As Exception
                                                                                                                                  param = "err"
                                                                                                                              End Try
                                                                                                                                                                        
                                                                                                                              If param <> "err" Then
                                                                                                                                  Dim val As String = param
                                                                                                                                  For i As Integer = 0 To model_pm.count - 1
                                                                                                                                      Dim o As Object = model_pm(i)
                                                                                                                                      If o.name = val Then
                                                                                                                                          pm.SelectedIndex = o.num - 1
                                                                                                                                          Exit For
                                                                                                                                      End If
                                                                                                                                  Next
                                                                                                                              End If
                                                                                                                              
                                                                                                                                                                
                                                                                                                              pm.Width = Unit.Percentage(100)
                                                                                                                              pm.Properties.DropDownWidth = 250
                                                                                                                              pm.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                                                              pm.Properties.CallbackPageSize = 30
                                                                                                                              pm.Properties.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
                                                                                                                              pm.Properties.TextFormatString = "{0}-{1}"
                                                                                                                              pm.Properties.ValueField = "num"
                                                                                                                              pm.Properties.Columns.Add("nik", "NIK", Unit.Percentage(20))
                                                                                                                              pm.Properties.Columns.Add("name", "NAME", Unit.Percentage(80))
                                                                                                                          End Sub).BindList(model_pm).GetHtml()


                                                                                           End Sub)
                                                         
                                                     End Sub)
                                
                               
                            
                                settings.Columns(0).Caption = "CODE"
                                settings.Columns(1).Caption = "DESCRIPTION"
                                settings.Columns(2).Caption = "TYPE"
                                settings.Columns(3).Caption = "CATEGORY"
                                settings.Columns(4).Caption = "HNA"
                                settings.Columns(5).Caption = "PRICE"
                                settings.Columns(6).Caption = "GP"
                                settings.Columns(7).Caption = "OSE"
                                settings.Columns(8).Caption = "GROUP"
                                settings.Columns(9).Caption = "GROUP FINANCIAL"
                                settings.Columns(10).Caption = "TABLET"
                                settings.Columns(11).Caption = "DOSSAGE"
                                settings.Columns(12).Caption = "DOSTIME"
                                settings.Columns(13).Caption = "THEURA CLASS"
                                settings.Columns(14).Caption = "PM"
                                
                                For i As Integer = 0 To 14
                                    settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                    settings.Columns(i).CellStyle.VerticalAlign = VerticalAlign.Middle
                                    settings.Columns(i).CellStyle.Font.Size = 7
                                    If i = 1 Then
                                        settings.Columns(i).Width = 1200
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Left
                                        settings.Columns(i).CellStyle.Paddings.PaddingLeft = 5
                                    ElseIf i = 2 Then
                                        settings.Columns(i).Width = 50
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                    ElseIf i = 14 Then
                                        settings.Columns(i).Width = 800
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Left
                                        settings.Columns(i).CellStyle.Paddings.PaddingLeft = 5
                                    Else
                                        settings.Columns(i).Width = 150
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                    End If
                                Next
                                
                                'settings.CommandButtonInitialize = Sub(s, e)
                                '                                       If e.ButtonType = ColumnCommandButtonType.Edit Then
                                '                                           MsgBox("editttt")
                                '                                       End If
                                                                       

                                'End Sub
                            End Sub).Bind(Model).GetHtml()
