@Html.DevExpress().PopupControl(Sub(settings)
                                    settings.Name = "popupControlReq"
                                    settings.CallbackRouteValues = New With {.Controller = "visitplan", .Action = "loadreqverivication"}
                                    settings.CloseAction = CloseAction.OuterMouseClick
                                    settings.PopupVerticalAlign = PopupVerticalAlign.Below
                                    settings.PopupHorizontalAlign = PopupHorizontalAlign.LeftSides
                                    'settings.ClientSideEvents.EndCallback = "popupControlReq_EndCallback"
                                    'settings.ClientSideEvents.EndCallback = "function(s, e) { popupControlReq_EndCallback(s, e); }"
                                    'settings.CustomJSProperties = Sub(s, e)
                                    '                                  If ViewData("RequestFlag") IsNot Nothing Then
                                    '                                      e.Properties("cpRequestFeedback") = ViewData("RequestFlag").ToString()
                                    '                                  End If

                                    '                              End Sub
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


                                                            Html.DevExpress().RadioButton(Sub(rd)
                                                                                              rd.Name = "rdAccordanceDown"
                                                                                              rd.Properties.Caption = "Submission Plans"
                                                                                              rd.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                              rd.Checked = True
                                                                                              rd.Enabled = False
                                                                                              rd.Text = "Accordance Shown"
                                                                                              rd.GroupName = "sub_mission"
                                                                                          End Sub).GetHtml()

                                                            Html.DevExpress().RadioButton(Sub(rd)
                                                                                              rd.Name = "rdAccordance"
                                                                                              rd.Text = "Monthly"
                                                                                              rd.Enabled = False
                                                                                              rd.GroupName = "sub_mission"
                                                                                          End Sub).GetHtml()


                                                            Html.DevExpress().ComboBox(Sub(monthReq)
                                                                                           monthReq.Name = "cbomonthReq"
                                                                                           monthReq.Properties.Caption = "Month"
                                                                                           monthReq.Properties.Items.Add("January").Value = 1
                                                                                           monthReq.Properties.Items.Add("February").Value = 2
                                                                                           monthReq.Properties.Items.Add("March").Value = 3
                                                                                           monthReq.Properties.Items.Add("April").Value = 4
                                                                                           monthReq.Properties.Items.Add("May").Value = 5
                                                                                           monthReq.Properties.Items.Add("June").Value = 6
                                                                                           monthReq.Properties.Items.Add("July").Value = 7
                                                                                           monthReq.Properties.Items.Add("August").Value = 8
                                                                                           monthReq.Properties.Items.Add("September").Value = 9
                                                                                           monthReq.Properties.Items.Add("October").Value = 10
                                                                                           monthReq.Properties.Items.Add("November").Value = 11
                                                                                           monthReq.Properties.Items.Add("December").Value = 12
                                                                                           monthReq.Properties.CaptionSettings.Position = EditorCaptionPosition.Left
                                                                                           monthReq.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                           monthReq.SelectedIndex = DateTime.Now.Month - 1
                                                                                           monthReq.Width = 240
                                                                                           monthReq.Height = 27
                                                                                           monthReq.Properties.ClientSideEvents.ValueChanged = "monthly_select"
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


