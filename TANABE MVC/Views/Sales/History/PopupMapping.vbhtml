@Html.DevExpress().PopupControl(Sub(setting)
                                    setting.Name = "popupMapping"
                                    setting.CloseAction = CloseAction.OuterMouseClick
                                    setting.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                    setting.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                    setting.AllowDragging = True
                                    setting.ShowFooter = True
                                    setting.Width = Unit.Pixel(400)
                                    setting.Height = Unit.Pixel(200)
                                    setting.HeaderText = "Mapping Product Sales"
                                    setting.ClientSideEvents.Shown = "popupMapping_Shown"

                                    setting.SetContent(Sub()
                                                           ViewContext.Writer.Write("<table style='width:100%'>")
                                                           ViewContext.Writer.Write("<tr id='row_lookup_doctor'>")
                                                           ViewContext.Writer.Write("<td  style='width:150px;text-align:right;background-color:lightgray;'>PRODUCT :</td>")
                                                           ViewContext.Writer.Write("<td>")
                                                           Html.DevExpress().ComboBox(Sub(cmb)
                                                                                          cmb.Name = "cbProductMapping"
                                                                                          cmb.Width = Unit.Percentage(100)
                                                                                          cmb.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                          cmb.Properties.ValueField = "prd_code"
                                                                                          cmb.Properties.TextField = "prd_code"
                                                                                          cmb.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                          cmb.Properties.TextFormatString = "{1}"
                                                                                          cmb.EnableTheming = True
                                                                                          cmb.Properties.Columns.Add("prd_code", "CODE", 50)
                                                                                          cmb.Properties.Columns.Add("prd_name", "NAME", 200)
                                                                                          cmb.Properties.Columns.Add("prd_focus", "FOCUS", 60)
                                                                                          cmb.Properties.Columns.Add("prd_type", "TYPE", 60)
                                                                                          cmb.Properties.Columns.Add("prd_price", "PRICE", 100)
                                                                                      End Sub).BindList(TANABE_MVC.SalesHistoryController.cbProductLookup).GetHtml()
                                                           ViewContext.Writer.Write("</td>")
                                                           ViewContext.Writer.Write("</tr>")
                                                           ViewContext.Writer.Write("<tr id='row_date_visit'>")
                                                           ViewContext.Writer.Write("<td  style='width:150px;text-align:right;background-color:lightgray;'>TARGET QUANTITY :</td>")
                                                           ViewContext.Writer.Write("<td>")
                                                           Html.DevExpress().SpinEdit(Sub(spin)
                                                                                          spin.Name = "txTarget"
                                                                                          spin.Number = 0
                                                                                          spin.Properties.MinValue = 0
                                                                                      End Sub).GetHtml()
                                                           ViewContext.Writer.Write("</td>")
                                                           ViewContext.Writer.Write("</tr>")
                                                           ViewContext.Writer.Write("<tr>")
                                                           ViewContext.Writer.Write("<td style='width:150px;text-align:right;background-color:lightgray;'>NOTE :</td>")
                                                           ViewContext.Writer.Write("<td>")
                                                           Html.DevExpress().Memo(Sub(m)
                                                                                      m.Name = "txNote"
                                                                                      m.Height = Unit.Pixel(71)
                                                                                      m.Width = Unit.Percentage(100)
                                                                                  End Sub).GetHtml()
                                                           ViewContext.Writer.Write("</td>")
                                                           ViewContext.Writer.Write("</tr>")
                                                           ViewContext.Writer.Write("</table>")
                                                       End Sub)

                                    setting.SetFooterContentTemplateContent(Sub()
                                                                                ViewContext.Writer.Write("<div style='margin: 6px 6px 6px 330px;'>")
                                                                                Html.DevExpress().Button(Sub(btn)
                                                                                                             btn.Name = "UpdateButton"
                                                                                                             btn.Text = "Submit"
                                                                                                             btn.UseSubmitBehavior = True
                                                                                                             btn.ClientSideEvents.Click = "ProccessMappingProduct"
                                                                                                         End Sub).GetHtml()
                                                                                ViewContext.Writer.Write("</div>")
                                                                            End Sub)

                                End Sub).GetHtml()


