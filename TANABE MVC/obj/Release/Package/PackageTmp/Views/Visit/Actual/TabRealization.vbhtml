@code
    Dim vpproduct As New TANABE_MVC.ProductListClass
    Dim model_product = Nothing
    model_product = vpproduct.GetDataProductList()
    
    Html.DevExpress().TextBox(Sub(txtdr)
                                      txtdr.Name = "txtdr_code"
                                      txtdr.Width = Unit.Pixel(250)
                                      txtdr.Properties.Caption = "Doctor Code"
                                      txtdr.Enabled = False
                                      txtdr.Text = ViewData("dr_code")
                                      txtdr.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                              End Sub).GetHtml()
    

    Html.DevExpress().RadioButton(Sub(rdas)
                                          rdas.Name = "rdVisitedDoctorVisit"
                                          rdas.Properties.Caption = "Actual Visit"
                                          rdas.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                          rdas.Checked = True
                                          rdas.Enabled = True
                                          rdas.Text = "Visited"
                                          rdas.GroupName = "doctor_visit"
                                          rdas.Properties.ClientSideEvents.CheckedChanged = "submission_check_doctor_visit"
                                  End Sub).GetHtml()

    Html.DevExpress().RadioButton(Sub(rdacc)
                                          rdacc.Name = "rdNotDoctorVisit"
                                          rdacc.Text = "Not Visited"
                                          rdacc.GroupName = "doctor_visit"
                                          rdacc.Enabled = True
                                          rdacc.Properties.ClientSideEvents.CheckedChanged = "submission_check_doctor_visit"
                                  End Sub).GetHtml()


    Html.DevExpress().GridLookup(Sub(productlist)
                                         productlist.Name = "GridLookupDoctorVisit"
                                         productlist.Properties.Caption = "Doctor Visit"
                                         productlist.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                         productlist.KeyFieldName = "visit_code"
                                         productlist.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "VisitRealization", Key .Action = "LoadProduct"}
                                         productlist.Properties.SelectionMode = GridLookupSelectionMode.Multiple
                                         productlist.Properties.TextFormatString = "{0}"
                                         productlist.GridViewProperties.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords
                                         productlist.GridViewProperties.Settings.VerticalScrollBarMode = ScrollBarMode.Auto
                                         productlist.Width = Unit.Pixel(250)
                                         productlist.Properties.MultiTextSeparator = ", "

                                         productlist.Columns.Add("visit_code")
                                         productlist.Columns.Add("visit_product")
                                         productlist.Columns.Add("visit_team")
                                         productlist.Columns.Add("visit_category")

                                         productlist.Columns(0).Visible = False
                                         productlist.Columns(1).Caption = "PRODUCT"
                                         productlist.Columns(2).Caption = "TEAM"
                                         productlist.Columns(3).Caption = "VISIT CATRGORY"

                                         productlist.Columns(1).Width = Unit.Pixel(100)
                                         productlist.Columns(2).Width = Unit.Pixel(100)
                                         productlist.Columns(3).Width = Unit.Pixel(100)


                                         productlist.GridViewStyles.Cell.Font.Size = 7.5
                                         productlist.GridViewStyles.Header.Font.Size = 7.5
                                         productlist.CommandColumn.ShowSelectCheckbox = True
                                         productlist.CommandColumn.Visible = True
                                         productlist.CommandColumn.SelectAllCheckboxMode = GridViewSelectAllCheckBoxMode.AllPages

                                 End Sub).BindList(model_product).GetHtml()


    Html.DevExpress().Memo(Sub(txtinfo)
                                   txtinfo.Name = "txtinfoDoctorVisit"
                                   txtinfo.ControlStyle.CssClass = "editor"
                                   txtinfo.Height = System.Web.UI.WebControls.Unit.Pixel(60)
                                   txtinfo.Properties.Caption = "Info"
                                   txtinfo.Width = Unit.Pixel(250)
                                   txtinfo.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                           End Sub).GetHtml()

    Html.DevExpress().TextBox(Sub(txtsp)
                                      txtsp.Name = "txtspDoctorVisit"
                                      txtsp.Width = Unit.Pixel(100)
                                      txtsp.Properties.Caption = "SP"
                                      txtsp.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                              End Sub).GetHtml()

    Html.DevExpress().SpinEdit(Sub(spvalue)
                                       spvalue.Name = "spvalueDoctorVisit"
                                       spvalue.Width = Unit.Pixel(100)
                                       spvalue.Properties.Caption = "SP Value"
                                       spvalue.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                       spvalue.Properties.SpinButtons.ShowLargeIncrementButtons = False
                                       spvalue.Properties.SpinButtons.ShowIncrementButtons = True
                                       spvalue.Properties.LargeIncrement = 10
                                       spvalue.Properties.Increment = 1
                                       spvalue.Properties.MinValue = 0
                               End Sub).GetHtml()
      

End Code  
