@Html.DevExpress().PopupControl(Sub(settings)
                                    settings.Name = "popupControlRealization"
                                    settings.CallbackRouteValues = New With {.Controller = "visitrealization", .Action = "LoadRealization"}
                                    settings.CloseAction = CloseAction.CloseButton
                                    settings.ShowCloseButton = True
                                    settings.Modal = True
                                    settings.AllowDragging = True
                                    settings.EnableHotTrack = True
                                    settings.Height = Unit.Pixel(100)
                                    settings.Width = Unit.Pixel(250)
                                    settings.LoadContentViaCallback = LoadContentViaCallback.OnFirstShow
                                                                            
                                    settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                    settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter

                                    settings.SetHeaderTemplateContent(Sub()
                                                                          ViewContext.Writer.Write("<div style='font-size:small;'>Realization</div>")
                                                                      End Sub)
                                    settings.SetContent(Sub()

                                                          
                                                            Html.DevExpress().RadioButton(Sub(rdas)
                                                                                              rdas.Name = "rdVisited"
                                                                                              rdas.Properties.Caption = "Actual Visit"
                                                                                              rdas.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                              rdas.Checked = True
                                                                                              rdas.Text = "Visited"
                                                                                              rdas.GroupName = "sub_mission"
                                                                                              rdas.Properties.ClientSideEvents.CheckedChanged = "visit_check"
                                                                                          End Sub).GetHtml()
                                                          
                                                            Html.DevExpress().RadioButton(Sub(rdacc)
                                                                                              rdacc.Name = "rdNotVisited"
                                                                                              rdacc.Text = "Not Visited"
                                                                                              rdacc.GroupName = "sub_mission"
                                                                                              rdacc.Properties.ClientSideEvents.CheckedChanged = "visit_check"
                                                                                          End Sub).GetHtml()
                                                                                                                      
                                                            Html.DevExpress().GridLookup(Sub(productlist)
                                                                                             productlist.Name = "GridLookup"
                                                                                             productlist.Properties.Caption = "Visit Code"
                                                                                             productlist.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                             productlist.KeyFieldName = "visit_code"
                                                                                             productlist.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "VisitRealization", Key .Action = "LoadRealization"}
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
                                                                                             
                                                                                         End Sub).BindList(Model).GetHtml()
                                                           
                                                            
                                                            Html.DevExpress().Memo(Sub(txtinfo)
                                                                                       txtinfo.Name = "txtinfo"
                                                                                       txtinfo.ControlStyle.CssClass = "editor"
                                                                                       txtinfo.Height = System.Web.UI.WebControls.Unit.Pixel(60)
                                                                                       txtinfo.Properties.Caption = "Info"
                                                                                       txtinfo.Width = Unit.Pixel(250)
                                                                                       txtinfo.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                   End Sub).GetHtml()
                                                           
                                                            Html.DevExpress().TextBox(Sub(txtsp)
                                                                                          txtsp.Name = "txtsp"
                                                                                          txtsp.Width = Unit.Pixel(100)
                                                                                          txtsp.Properties.Caption = "SP"
                                                                                          txtsp.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                      End Sub).GetHtml()
                                                           
                                                            Html.DevExpress().SpinEdit(Sub(spvalue)
                                                                                           spvalue.Name = "spvalue"
                                                                                           spvalue.Width = Unit.Pixel(100)
                                                                                           spvalue.Properties.Caption = "SP Value"
                                                                                           spvalue.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                           spvalue.Properties.SpinButtons.ShowLargeIncrementButtons = False
                                                                                           spvalue.Properties.SpinButtons.ShowIncrementButtons = True
                                                                                           spvalue.Properties.LargeIncrement = 10
                                                                                           spvalue.Properties.Increment = 1
                                                                                       End Sub).GetHtml()


                                                            ViewContext.Writer.Write("</br><div style='padding: 2px 0px 2px 0; float: right'>")
                                                            
                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnCancel"
                                                                                         btn.Text = "Cancel"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "cancel_realization"
                                                                                     End Sub).GetHtml()
                                                            
                                                            ViewContext.Writer.Write(" &nbsp; &nbsp;")
                                                            
                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnSubmit"
                                                                                         btn.Text = "Submit"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "submit_realization"
                                                                                     End Sub).GetHtml()
                                                            
                                                            ViewContext.Writer.Write("</div>")

                                                        End Sub)

                                End Sub).GetHtml()

<script type="text/javascript">

    function submit_realization() {
        popupControlRealization.Hide();
        var v_visited = rdVisited.GetValue();
        var v_notvisited = rdNotVisited.GetValue();
        var v_visit_code = GridLookup.GetValue();
        var v_info = txtinfo.GetValue();
        var v_sp = txtsp.GetValue();
        var v_sp_value = spvalue.GetValue();
      
        $.ajax({
            type: "POST",
            url: '@Url.Action("realization", "visitrealization")',
            data: { visited: v_visited, visit_code: v_visit_code, info: v_info, sp: v_sp, sp_value: v_sp_value }
        }).done(function () {
                window.location.reload();
        });

    }

    
    function cancel_realization() {
        popupControlRealization.Hide();
        }

    function visit_check() {
        var v_visited = rdVisited.GetValue();
       
        if (v_visited == true) {           
            GridLookup.SetEnabled(true);           
            txtsp.SetEnabled(true);
            spvalue.SetEnabled(true);
        } else {          
            GridLookup.SetEnabled(false);
            //GridLookup.SetValue(null);
            txtsp.SetEnabled(false);
            txtsp.SetValue(null);
            spvalue.SetEnabled(false);
            spvalue.SetValue(null);
        }
        
    }
</script>




