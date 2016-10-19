@Html.DevExpress().PopupControl(Sub(settings)
                                    settings.Name = "popupControlReq"
                                    settings.CallbackRouteValues = New With {.Controller = "visitplan", .Action = "loadreqverivication"}
                                    settings.CloseAction = CloseAction.OuterMouseClick
                                    settings.PopupVerticalAlign = PopupVerticalAlign.Below
                                    settings.PopupHorizontalAlign = PopupHorizontalAlign.LeftSides

                                    settings.AllowDragging = True
                                    settings.EnableHotTrack = True
                                    settings.Height = Unit.Pixel(100)
                                    settings.Width = Unit.Pixel(250)
                                    settings.LoadContentViaCallback = LoadContentViaCallback.OnFirstShow
                                    settings.PopupElementID = "btnrequest"

                                    settings.SetHeaderTemplateContent(Sub()
                                                                          ViewContext.Writer.Write("<div style='font-size:small;'>Verification Condition</div>")
                                                                      End Sub)
                                    settings.SetContent(Sub()
                                                            
                                                           
                                                            Html.DevExpress().RadioButton(Sub(rdas)
                                                                                              rdas.Name = "rdAccordanceDown"
                                                                                              rdas.Properties.Caption = "Submission Plans"
                                                                                              rdas.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                              rdas.Checked = True
                                                                                              rdas.Text = "Accordance Shown"
                                                                                              rdas.GroupName = "sub_mission"
                                                                                          End Sub).GetHtml()
                                                            
                                                            Html.DevExpress().RadioButton(Sub(rdacc)
                                                                                              rdacc.Name = "rdAccordance"
                                                                                              rdacc.Text = "Accordance"
                                                                                              rdacc.GroupName = "sub_mission"
                                                                                          End Sub).GetHtml()

                                                            
                                                            Html.DevExpress().ComboBox(Sub(monthReq)
                                                                                           monthReq.Name = "cbomonthReq"
                                                                                           monthReq.Properties.Caption = "Month"
                                                                                           monthReq.Properties.Items.Add("January")
                                                                                           monthReq.Properties.Items.Add("February")
                                                                                           monthReq.Properties.Items.Add("March")
                                                                                           monthReq.Properties.Items.Add("April")
                                                                                           monthReq.Properties.Items.Add("May")
                                                                                           monthReq.Properties.Items.Add("June")
                                                                                           monthReq.Properties.Items.Add("July")
                                                                                           monthReq.Properties.Items.Add("August")
                                                                                           monthReq.Properties.Items.Add("September")
                                                                                           monthReq.Properties.Items.Add("October")
                                                                                           monthReq.Properties.Items.Add("November")
                                                                                           monthReq.Properties.Items.Add("December")
                                                                                           monthReq.Properties.CaptionSettings.Position = EditorCaptionPosition.Left
                                                                                           monthReq.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                           monthReq.SelectedIndex = DateTime.Now.Month - 1
                                                                                           settings.Width = 240
                                                                                           settings.Height = 27
                                                                                       End Sub).GetHtml()

                                                            ViewContext.Writer.Write("</br><div style='padding: 2px 0px 2px 0; float: right'>")
                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnSubmitReq"
                                                                                         btn.Text = "Submit"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "reqverification"
                                                                                     End Sub).GetHtml()
                                                            ViewContext.Writer.Write("</div>")

                                                        End Sub)

                                End Sub).GetHtml()

<script type="text/javascript">

    function reqverification() {
        popupControlReq.Hide();

        var vmonth_req = cbomonthReq.GetValue();
      
      

        $.ajax({
            type: "POST",
            url: '@Url.Action("reqverification", "visitplan")',
            data: { month_req: vmonth_req }
        }).done(function () {
                window.location.reload();

        });

    }

</script>



