@Html.DevExpress().PopupControl(Sub(settings)
                                    settings.Name = "popupCopySales"
                                    settings.CallbackRouteValues = New With {.Controller = "SalesPlan", .Action = "CopySales"}
                                    settings.CloseAction = CloseAction.OuterMouseClick
                                    settings.PopupElementID = "btnCopySales"
                                    settings.PopupVerticalAlign = PopupVerticalAlign.Below
                                    settings.PopupHorizontalAlign = PopupHorizontalAlign.LeftSides
                                    settings.AllowDragging = True
                                    settings.Width = Unit.Pixel(300)
                                    settings.Height = Unit.Pixel(160)
                                    settings.HeaderText = "Copy Sales Plan Template"
                                    settings.LoadContentViaCallback = LoadContentViaCallback.OnFirstShow
                                    settings.ClientSideEvents.Shown = "popupCopySales_Shown"     
                                    
                                    settings.SetContent(Sub()
                                                            ViewContext.Writer.Write("<table style='width:100%;'>")
                                                            ViewContext.Writer.Write("<tr>")
                                                            ViewContext.Writer.Write("<td style='text-align:right;width:100px;'>From Month : </td>")
                                                            ViewContext.Writer.Write("<td>")
                                                            Html.DevExpress().ComboBox(Sub(monthReq)
                                                                                           monthReq.Name = "cb_from_month"
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
                                                                                           monthReq.Width = 150
                                                                                           monthReq.Height = 27
                                                                                           monthReq.Properties.NullText = "Month"
                                                                                       End Sub).GetHtml()
                                                            ViewContext.Writer.Write("</td>")
                                                            ViewContext.Writer.Write("</tr>")
                                                            ViewContext.Writer.Write("<tr>")
                                                            ViewContext.Writer.Write("<td style='text-align:right;width:100px;'>Year : </td>")
                                                            ViewContext.Writer.Write("<td>")
                                                            Html.DevExpress().SpinEdit(Sub(yearReq)
                                                                                           yearReq.Name = "cb_from_year"
                                                                                           yearReq.Properties.MinValue = 2015
                                                                                           yearReq.Properties.MaxValue = 2100
                                                                                           yearReq.Properties.NullText = "Year"
                                                                                       End Sub).GetHtml()
                                                            ViewContext.Writer.Write("</td>")
                                                            ViewContext.Writer.Write("</tr>")
                                                            ViewContext.Writer.Write("</table>")
                                                            ViewContext.Writer.Write("</br><div style='padding: 2px 0px 2px 0; float: right'>")
                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnCopy"
                                                                                         btn.Text = "Generate Copy"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "copySales"
                                                                                     End Sub).GetHtml()
                                                            ViewContext.Writer.Write("</div>")
                                                        End Sub)
                                End Sub).GetHtml()
