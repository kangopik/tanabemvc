@Html.DevExpress().PopupControl(
    Sub(settings)
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
            settings.ClientSideEvents.Shown = "popupControlRealization_Shown"
            
            settings.SetHeaderTemplateContent(Sub()
                                                      ViewContext.Writer.Write("<div style='font-size:small;'>Realization</div>")
                                              End Sub)
            settings.SetContent(Sub()
                                        Html.DevExpress().RadioButton(
                                            Sub(rdas)
                                                    rdas.Name = "rdVisited"
                                                    rdas.Properties.Caption = "Actual Visit"
                                                    rdas.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                    rdas.Checked = True
                                                    rdas.Text = "Visited"
                                                    rdas.GroupName = "sub_mission"
                                                    rdas.Properties.ClientSideEvents.CheckedChanged = "visit_check"
                                            End Sub).GetHtml()
                                                          
                                        Html.DevExpress().RadioButton(
                                            Sub(rdacc)
                                                    rdacc.Name = "rdNotVisited"
                                                    rdacc.Text = "Not Visited"
                                                    rdacc.GroupName = "sub_mission"
                                                    rdacc.Properties.ClientSideEvents.CheckedChanged = "visit_check"
                                            End Sub).GetHtml()
                                                                                                                      
                                        Html.RenderPartial("~/Views/Visit/Realization/RealizationProductPartial.vbhtml")
                                                           
                                                            
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
                                                                         btn.Name = "btnSubmit"
                                                                         btn.Text = "Submit"
                                                                         btn.ClientSideEvents.Click = "submit_realization"
                                                                 End Sub).GetHtml()
                                        ViewContext.Writer.Write(" &nbsp; &nbsp;")
                                        Html.DevExpress().Button(Sub(btn)
                                                                         btn.Name = "btnCancel"
                                                                         btn.Text = "Cancel"
                                                                         btn.ClientSideEvents.Click = "cancel_realization"
                                                                 End Sub).GetHtml()
                                                            
                                        ViewContext.Writer.Write(" &nbsp; &nbsp;")
                                                            
                                        
                                                            
                                        ViewContext.Writer.Write("</div>")

                                End Sub)

    End Sub).GetHtml()

<script type="text/javascript">



    function submit_realization() {
       // alert(temp_visit_id);
        if (temp_visit_id != "") {
            popupControlRealization.Hide();
            var v_visited = rdVisited.GetValue();
            var v_notvisited = rdNotVisited.GetValue();
            var v_visit_code = GridLookup.GetValue();
            var v_info = txtinfo.GetValue();
            var v_sp = txtsp.GetValue();
            var v_sp_value = spvalue.GetValue();
            var param = 'realization;' + v_visited + ';' + v_visit_code + ';' + v_info + ';' + v_sp + ';' + v_sp_value + ';' + temp_visit_id;
            DataView1.PerformCallback({ prm: param });
            temp_visit_id = "";
        }
        

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
            txtsp.SetEnabled(false);
            txtsp.SetValue(null);
            spvalue.SetEnabled(false);
            spvalue.SetValue(null);
        }
        
    }
</script>




