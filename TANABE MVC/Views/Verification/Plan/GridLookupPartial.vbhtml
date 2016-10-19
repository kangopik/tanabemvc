@Html.DevExpress().GridLookup(Sub(glp)
                                  glp.Name = "GridLookup"
                                  glp.Width = 150
                                  glp.Height = 27
                                  glp.KeyFieldName = "rep_id"
                                  glp.Properties.Caption = "Rep"
                                  glp.Properties.CaptionSettings.Position = EditorCaptionPosition.Left
                                  glp.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "vervisitplan", Key .Action = "GridLookupPartial"}
                                  glp.Properties.SelectionMode = GridLookupSelectionMode.Single
                                  glp.Properties.TextFormatString = "{0}-{1}"
                                  'glp.GridViewProperties.Settings.ShowStatusBar = GridViewStatusBarMode.Visible
                                  'glp.GridViewProperties.Settings.ShowFooter = True
                                  glp.ControlStyle.Font.Size = 7
                                  glp.GridViewStyles.Cell.Font.Size = 7
                                  glp.GridViewStyles.Header.Font.Size = 7
                                  glp.Properties.EnableFocusedStyle = True
                                  glp.GridViewProperties.SettingsBehavior.AllowFocusedRow = True
                                  glp.GridViewProperties.SettingsBehavior.AllowSelectByRowClick = True
                                  glp.GridViewProperties.SettingsBehavior.EnableRowHotTrack = True
                                  glp.Properties.ClientSideEvents.ValueChanged = "OnGetSelectionButtonClick"

                                  'glp.GridViewProperties.SettingsPager.Visible = True
                                  glp.GridViewProperties.Settings.ShowGroupPanel = False
                                  glp.GridViewProperties.Settings.ShowFilterRow = True

                                  glp.Columns.Add("rep_id").Caption = "NIK"
                                  glp.Columns.Add("rep_name").Caption = "NAME"
                                  glp.Columns.Add("rep_bo").Caption = "BO"
                                  glp.Columns.Add("rep_sbo").Caption = "SBO"
                                  glp.Columns(0).Width = Unit.Pixel(25)
                                  glp.Columns(1).Width = Unit.Pixel(100)
                                  glp.Columns(2).Width = Unit.Pixel(25)
                                  glp.Columns(3).Width = Unit.Pixel(25)

                                  glp.GridViewProperties.SetStatusBarTemplateContent(
                                      Sub(c)
                                          ViewContext.Writer.Write("<div style='overflow: hidden'><div style='padding: 3px; float: right;'>                        ")
                                          Html.DevExpress().Button(Sub(btncl)
                                                                       btncl.Name = "btnClose"
                                                                       btncl.Text = "Close"
                                                                       btncl.UseSubmitBehavior = False
                                                                       btncl.ControlStyle.Font.Size = 7
                                                                       btncl.ClientSideEvents.Click = "CloseGridLookup"
                                                                   End Sub).Render()
                                          ViewContext.Writer.Write("</div></div>")


                                      End Sub)
                              End Sub).BindList(Model).GetHtml()
