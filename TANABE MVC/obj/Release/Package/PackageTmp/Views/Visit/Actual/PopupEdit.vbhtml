@Html.DevExpress().PopupControl(Sub(settings)
                                    settings.Name = "popupControlEdit"
                                    settings.CallbackRouteValues = New With {.Controller = "visitactual", .Action = "LoadEdit"}
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
                                                                          ViewContext.Writer.Write("<div style='font-size:small;'>Edit Form</div>")
                                                                      End Sub)
                                    settings.SetContent(Sub()

                                                           
                                                            Html.DevExpress().PageControl(Sub(tb)
                                                                                              tb.Name = "TabControl"
                                                                                              tb.TabPosition = TabPosition.Top
                                                                                              tb.TabPages.Add(Sub(tab)
                                                                                                                  tab.Name = "TabRealization"
                                                                                                                  tab.Text = "Realization Detail"
                                                                                                                  tab.SetContent(Html.Partial("~/Views/Visit/Actual/TabRealization.vbhtml").ToHtmlString())
                                                                                                                                       
                                                                                                              End Sub)
                                                                                              tb.TabPages.Add(Sub(tab)
                                                                                                                  tab.Name = "TabProduct"
                                                                                                                  tb.TabPosition = TabPosition.Top
                                                                                                                  tab.Text = "Visit Products"
                                                                                                                  tab.SetContent(Html.Partial("~/Views/Visit/Actual/TabProduct.vbhtml").ToHtmlString())
                                                                                                                                       
                                                                                                              End Sub)
                                                                                              
                                                                                              
                                                                                              
                                                                                          End Sub).GetHtml()



                                                            ViewContext.Writer.Write("</br><div style='padding: 2px 0px 2px 0; float: right'>")

                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnCancel"
                                                                                         btn.Text = "Cancel"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "cancel_edit"
                                                                                     End Sub).GetHtml()

                                                            ViewContext.Writer.Write(" &nbsp; &nbsp;")


                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnSubmit"
                                                                                         btn.Text = "Save"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "submit_edit"
                                                                                     End Sub).GetHtml()

                                                            ViewContext.Writer.Write("</div>")

                                                        End Sub)

                                End Sub).GetHtml()

<script type="text/javascript">

    function submit_edit() {
        popupControlEdit.Hide();

    }


    function cancel_edit() {
        popupControlEdit.Hide();
    }

    function submission_check_doctor_visit() {
        var v_accordance = rdVisitedDoctorVisit.GetValue();

        if (v_accordance == false) {
            GridLookupDoctorVisit.SetEnabled(false);
            txtspDoctorVisit.SetEnabled(false);
            spvalueDoctorVisit.SetEnabled(false);
            TabControl.GetTabByName('TabProduct').SetEnabled(false);
            txtinfoDoctorVisit.Focus();
        } else {
            GridLookupDoctorVisit.SetEnabled(true);
            txtspDoctorVisit.SetEnabled(true);
            spvalueDoctorVisit.SetEnabled(true);
            TabControl.GetTabByName('TabProduct').SetEnabled(true);
        }
    }
    
    function submission_check() {
        var v_submission = rdAccordanceDown.GetValue();

        if (v_submission == true) {
            DateEdit1.SetVisible(false);
            DataView1.PerformCallback({ act: 'reset' });
        } else {
            DateEdit1.SetVisible(true);

        }
    }

    function daily_select(s, e) {

        var dp = DateEdit1.GetDate();
        var day = dp.getDate();
        var month = dp.getMonth() + 1;
        var year = dp.getFullYear();
        var param = 'retrieve_selected-' + day + '-' + month + '-' + year;
        DataView1.PerformCallback({ act: param });
    }

</script>








