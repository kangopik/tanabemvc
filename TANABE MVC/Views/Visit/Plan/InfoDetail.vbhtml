   
    @Html.DevExpress().PopupControl(Sub(settings)
                                        settings.Name = "PopupInfoDetailControl"
                                        settings.AllowResize = True
                                        settings.ShowHeader = True
                                        settings.ShowOnPageLoad = False
                                        settings.CallbackRouteValues = New With {Key .Controller = "visitplan", Key .Action = "InfoDetail"}
                                        settings.AllowDragging = False
                                        settings.CloseAction = CloseAction.MouseOut
                                        settings.CloseOnEscape = False
                                          
                                        settings.SetHeaderTemplateContent(Sub()
                                                                              ViewContext.Writer.Write("<div style='font-size:small;'>Doctors Planned Detail</div>")
                                                                          End Sub)
                                         
                                        settings.SetContent(Sub()
                                                               
                                                                ViewContext.Writer.Write("<div style='margin: -15px -15px -15px -15px;'>")
                                                                Html.DevExpress().GridView(Sub(gridDetail)
                                                                                               gridDetail.Name = "detailGrid"
                                                                                               gridDetail.SettingsDetail.MasterGridName = "grid"
                                                                                               gridDetail.CallbackRouteValues = New With {Key .Controller = "visitplan", Key .Action = "InfoDetail", Key .dr_code = ViewData("dr_code")}
                                                                                               gridDetail.Width = Unit.Percentage(100)
                                                                                               gridDetail.Styles.Cell.Font.Size = 7
                                                                                               gridDetail.Styles.Header.Font.Size = 7
                                                                                               gridDetail.Styles.GroupRow.Font.Size = 7
                                                                                               gridDetail.Styles.Footer.Font.Size = 7
                                                                                               gridDetail.Styles.Header.HorizontalAlign = HorizontalAlign.Center
                                                                                                                                                                                             
                                     
                                                                                               gridDetail.KeyFieldName = "visit_date_plan"
                                                                                               gridDetail.Columns.Add("visit_date_plan")
                                                                                               gridDetail.Columns.Add("week")
                                                                                              
                                                                                               gridDetail.Columns(0).Caption = "VISIT DATE PLAN"
                                                                                               gridDetail.Columns(1).Caption = "WEEK"
                                                                                            
                                     
                                                                                               For i As Integer = 0 To 1
                                                                                                   gridDetail.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                                                                   gridDetail.Columns(i).CellStyle.VerticalAlign = VerticalAlign.Middle
                                                                                                   gridDetail.Columns(i).CellStyle.Font.Size = 7
                                                                                               Next
                                                                                           End Sub).Bind(Model).GetHtml()

                                                                ViewContext.Writer.Write("</div>")
                                                                
                                                            End Sub)
                                    End Sub).GetHtml()

 
   
