@Html.DevExpress().GridLookup(Sub(glp)
                                  glp.Name = "GridLookup"
                                  glp.Width = 180
                                  glp.KeyFieldName = "rep_id"
                                  glp.Properties.Caption = "Rep"
                                  glp.Properties.CaptionSettings.Position = EditorCaptionPosition.Left
                                  glp.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "vervisitplan", Key .Action = "GridLookupPartial"}
                                  glp.Properties.SelectionMode = GridLookupSelectionMode.Single
                                  glp.Properties.TextFormatString = "{0}-{1}"
                                  glp.GridViewProperties.Settings.ShowStatusBar = GridViewStatusBarMode.Visible
                                  glp.GridViewProperties.Settings.ShowFooter = True

                                  'glp.CommandColumn.ShowSelectCheckbox = True
                                 

                                  'glp.CommandColumn.Visible = True
                                  glp.GridViewProperties.SettingsPager.Visible = True
                                  glp.GridViewProperties.Settings.ShowGroupPanel = False
                                  glp.GridViewProperties.Settings.ShowFilterRow = True
                                  
                                  glp.Columns.Add("rep_id").Caption = "NIK"
                                  glp.Columns.Add("rep_name").Caption = "NAME"
                                  glp.Columns.Add("rep_bo").Caption = "BO"
                                  glp.Columns.Add("rep_sbo").Caption = "SBO"
                                  glp.Columns.Add("rep_division").Caption = "DIVISION"


                                  glp.GridViewProperties.SetStatusBarTemplateContent(Sub(c)
                                                                                         ViewContext.Writer.Write("<div style='overflow: hidden'><div style='padding: 3px; float: right;'>                        ")
                                                                                         Html.DevExpress().Button(Sub(btncl)
                                                                                                                      btncl.Name = "btnClose"
                                                                                                                      btncl.Text = "Close"
                                                                                                                      btncl.UseSubmitBehavior = False
                                                                                                                      btncl.ClientSideEvents.Click = "CloseGridLookup"
                                                                                                                  End Sub).Render()
                                                                                         ViewContext.Writer.Write("</div></div>")

                                                                                         
                                                                                     End Sub)
                              End Sub).BindList(Model).GetHtml()
