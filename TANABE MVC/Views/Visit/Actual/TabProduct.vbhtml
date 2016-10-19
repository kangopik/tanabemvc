@code
    Dim v_visit_id As String = TANABE_MVC.GlobalClass.visit_actual_visit_id
    Dim model = Nothing
    Try
        Dim vp As New TANABE_MVC.TANABE_MVC.Models.VisitActualClass
        model = vp.GetDataDetail(v_visit_id)
    Catch generatedExceptionName As Exception
        Throw
    End Try
    
    
    Dim model_doctor = Nothing
    Try
        Dim vp As New TANABE_MVC.TANABE_MVC.Models.VisitActualClass
        model_doctor = vp.GetDataDetail(v_visit_id)
    Catch generatedExceptionName As Exception
        Throw
    End Try
    
End Code
@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "EditGrid"
                                settings.SettingsDetail.MasterGridName = "grid"
                                settings.CallbackRouteValues = New With {Key .Controller = "VisitActual", Key .Action = "MasterDetailPartialEdit", Key .visit_id = v_visit_id}
                                settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "VisitActual", .Action = "newproduct"}
                                settings.Width = Unit.Percentage(50)
                                settings.Styles.Cell.Font.Size = 8
                                settings.Styles.Header.Font.Size = 8
                                settings.Styles.GroupRow.Font.Size = 8
                                settings.Styles.Footer.Font.Size = 8
                                settings.Styles.Header.HorizontalAlign = HorizontalAlign.Center
                                     
                                settings.CommandColumn.ShowNewButtonInHeader = True
                                settings.CommandColumn.Visible = True
                               
                                settings.CommandColumn.ShowDeleteButton = True
                               
                                settings.CommandColumn.ButtonType = GridViewCommandButtonType.Image
                                settings.SettingsEditing.Mode = GridViewEditingMode.EditForm
                             
                                
                                settings.SettingsCommandButton.DeleteButton.Image.Url = "~/Content/Images/delete-icon2.png"
                                settings.SettingsCommandButton.CancelButton.Image.Url = "~/Content/Images/cancel-icon2.png"
                                settings.SettingsCommandButton.UpdateButton.Image.Url = "~/Content/Images/update-icon2.png"
                                settings.SettingsCommandButton.NewButton.Image.Url = "~/Content/Images/add-icon2.png"
                                     
                                settings.KeyFieldName = "vd_id"
                                settings.Columns.Add("vd_id")
                                settings.Columns.Add("visit_id")
                                settings.Columns.Add("visit_code")
                               
                                settings.Columns.Add("visit_product", "PRODUCT", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)
                                                                                                                                               
                                                                                                                                                Html.DevExpress().TextBox(Sub(aso)
                                                                                                                                                                              aso.Name = "visit_product"
                                                                                                                                                                              aso.Width = Unit.Percentage(100)
                                                                                                                                                                          End Sub).GetHtml()
                                                                                                                                            End Sub)
                            
                                     
                                settings.Columns.Add("visit_team", "TEAM", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)
                                                                                                                                          Html.DevExpress().TextBox(Sub(aso)
                                                                                                                                                                        aso.Name = "visit_team"
                                                                                                                                                                        aso.ClientVisible = False
                                                                                                                                                                        column.Visible = False
                                                                                                                                                                        aso.Width = Unit.Percentage(100)
                                                                                                                                                                    End Sub).GetHtml()
                                                                                                                                      End Sub)
                                     
                                settings.Columns.Add("visit_category", "CATEGORY", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(Sub(column)
                                                                                                                                                  Html.DevExpress().TextBox(Sub(aso)
                                                                                                                                                                                aso.Name = "visit_category"
                                                                                                                                                                                aso.ClientVisible = False
                                                                                                                                                                                column.Visible = False
                                                                                                                                                                                aso.Width = Unit.Percentage(100)
                                                                                                                                                                            End Sub).GetHtml()
                                                                                                                                              End Sub)
                                'settings.Columns.Add("visit_product")
                                'settings.Columns.Add("visit_team")
                                'settings.Columns.Add("visit_category")
                                     
                                settings.Columns.Add("vd_value")
                                     
                                settings.Columns(0).Visible = False
                                settings.Columns(1).Visible = False
                                settings.Columns(2).Visible = False
                                     
                                'settings.Columns(3).Caption = "TEAM"
                                ' settings.Columns(4).Caption = "PRODUCT"
                                'settings.Columns(5).Caption = "CATEGORY"
                                     
                                settings.Columns(6).Visible = False

                                For i As Integer = 0 To 6
                                    settings.Columns(i).Width = 400
                                    settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                    settings.Columns(i).CellStyle.VerticalAlign = VerticalAlign.Middle
                                Next
                            End Sub).Bind(model_doctor).GetHtml()
