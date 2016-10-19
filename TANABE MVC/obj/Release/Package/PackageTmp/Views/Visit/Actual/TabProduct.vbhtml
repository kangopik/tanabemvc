@code
    Dim model = Nothing
    Try
        Dim vp As New TANABE_MVC.TANABE_MVC.Models.VisitActualClass
        model = vp.GetDataDetail(ViewData("visit_id"))
    Catch generatedExceptionName As Exception
        Throw
    End Try
End Code
@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "EditGrid"
                                settings.SettingsDetail.MasterGridName = "grid"
                                settings.CallbackRouteValues = New With {Key .Controller = "VisitActual", Key .Action = "MasterDetailPartialEdit", Key .visit_id = ViewData("visit_id")}
                                settings.Width = Unit.Percentage(50)
                                settings.Styles.Cell.Font.Size = 8
                                settings.Styles.Header.Font.Size = 8
                                settings.Styles.GroupRow.Font.Size = 8
                                settings.Styles.Footer.Font.Size = 8
                                settings.Styles.Header.HorizontalAlign = HorizontalAlign.Center
                                     
                                settings.CommandColumn.Visible = True
                                settings.CommandColumn.ShowNewButton = True
                                settings.CommandColumn.ShowDeleteButton = True
                               
                                settings.CommandColumn.ButtonType = GridViewCommandButtonType.Image
                                
                                settings.SettingsCommandButton.NewButton.Image.Url = "~/Content/Images/plus.png"
                                settings.SettingsCommandButton.DeleteButton.Image.Url = "~/Content/Images/delete.png"
                                     
                                'settings.SettingsCommandButton.DeleteButton.Image.Url = "~/Content/img/DeleteList_16x16.png"
                                'settings.SettingsCommandButton.EditButton.Image.Url = "~/Content/img/EditName_16x16.png"
                                
                                     
                                     
                                settings.KeyFieldName = "vd_id"
                                settings.Columns.Add("vd_id")
                                settings.Columns.Add("visit_id")
                                settings.Columns.Add("visit_code")
                               
                                settings.Columns.Add("visit_product")
                                settings.Columns.Add("visit_team")
                                settings.Columns.Add("visit_category")
                                settings.Columns.Add("vd_value")
                                     
                                settings.Columns(0).Visible = False
                                settings.Columns(1).Visible = False
                                settings.Columns(2).Visible = False
                                settings.Columns(3).Caption = "TEAM"
                                settings.Columns(4).Caption = "PRODUCT"
                                settings.Columns(5).Caption = "CATEGORY"
                                settings.Columns(6).Visible = False

                                For i As Integer = 0 To 6
                                    settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                    settings.Columns(i).CellStyle.VerticalAlign = VerticalAlign.Middle
                                Next
                            End Sub).Bind(model).GetHtml()
