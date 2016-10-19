@Html.DevExpress().PopupControl(Sub(settings)
                                    settings.Name = "popupRequest"
                                    settings.CallbackRouteValues = New With {.Controller = "SalesActual", .Action = "ReqVerivication"}
                                    settings.CloseAction = CloseAction.OuterMouseClick
                                    settings.LoadContentViaCallback = LoadContentViaCallback.OnFirstShow
                                    settings.PopupElementID = "btnReqVer"
                                    settings.PopupVerticalAlign = PopupVerticalAlign.Below
                                    settings.PopupHorizontalAlign = PopupHorizontalAlign.LeftSides
                                    settings.AllowDragging = True
                                    settings.Width = Unit.Pixel(370)
                                    settings.Height = Unit.Pixel(160)
                                    settings.HeaderText = "Verification Condition"

                                    settings.SetContent(Sub()
                                                            ViewContext.Writer.Write("<table style='width:100%;'>")
                                                            ViewContext.Writer.Write("<tr>")
                                                            ViewContext.Writer.Write("<td style='text-align:right;width:110px;'>Submission Plans :</td>")
                                                            ViewContext.Writer.Write("<td>")
                                                            Html.DevExpress().RadioButton(Sub(rd)
                                                                                              rd.Name = "rdAccordance"
                                                                                              rd.Enabled = False
                                                                                              rd.Text = "Accordance Shown"
                                                                                              rd.GroupName = "sub_mission"
                                                                                          End Sub).GetHtml()
                                                            Html.DevExpress().RadioButton(Sub(rd)
                                                                                              rd.Name = "rdAccordanceDown"
                                                                                              rd.Text = "Monthly"
                                                                                              rd.Enabled = False
                                                                                              rd.Checked = True
                                                                                              rd.GroupName = "sub_mission"
                                                                                          End Sub).GetHtml()
                                                            ViewContext.Writer.Write("</td>")
                                                            ViewContext.Writer.Write("</tr>")
                                                            ViewContext.Writer.Write("<tr id='tr_period' visible='false'>")
                                                            ViewContext.Writer.Write("<td style='text-align:right;width:110px;'>Month Periode :</td>")
                                                            ViewContext.Writer.Write("<td style='padding-left:15px;'>")
                                                            Html.DevExpress().ComboBox(Sub(monthReq)
                                                                                           monthReq.Name = "cb_date_periode"
                                                                                           monthReq.Width = Unit.Percentage(100)
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
                                                                                           monthReq.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                           monthReq.SelectedIndex = DateTime.Now.Month - 1
                                                                                           monthReq.Width = 200
                                                                                           monthReq.Height = 27
                                                                                           monthReq.Properties.ClientSideEvents.ValueChanged = "periode_ValueChanged"
                                                                                       End Sub).GetHtml()
                                                            ViewContext.Writer.Write("</td>")
                                                            ViewContext.Writer.Write("</tr>")
                                                            ViewContext.Writer.Write("</table>")
                                                            ViewContext.Writer.Write("</br><div style='margin: 6px 6px 6px 210px'>")
                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnSubmitReq"
                                                                                         btn.Text = "Send Request"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "reqverification"
                                                                                     End Sub).GetHtml()
                                                            ViewContext.Writer.Write("</div>")
                                                        End Sub)
                                End Sub).GetHtml()

