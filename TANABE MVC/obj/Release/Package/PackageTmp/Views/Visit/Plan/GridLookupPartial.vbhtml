@Code
    Dim gridLookup = Html.DevExpress().GridLookup(Sub(glp)
                                                          glp.Name = "GridLookup"
                                                          glp.Width = 240
                                                          glp.KeyFieldName = "dr_code"
                                                          glp.Properties.Caption = "Doctor list "
                                                          glp.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                          glp.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "visitplan", Key .Action = "GridLookupPartial"}
                                                          glp.Properties.SelectionMode = GridLookupSelectionMode.Multiple
                                                          glp.Properties.TextFormatString = "{0}"
                                                          glp.GridViewProperties.Settings.ShowStatusBar = GridViewStatusBarMode.Visible
                                                          glp.GridViewProperties.Settings.ShowFooter = True
                                                          glp.GridViewProperties.Settings.VerticalScrollBarMode = ScrollBarMode.Auto

                                                          glp.CommandColumn.ShowSelectCheckbox = True
                                                          glp.Properties.TextFormatString = "{0}"
                                                          glp.Properties.MultiTextSeparator = ", "

                                                          glp.CommandColumn.Visible = True
                                                          glp.GridViewProperties.SettingsPager.Visible = True
                                                          glp.GridViewProperties.Settings.ShowGroupPanel = False
                                                          glp.GridViewProperties.Settings.ShowFilterRow = True
                                                          glp.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                          glp.Properties.IncrementalFilteringDelay = 500

                                                          glp.Columns.Add("dr_code").Caption = "DR CODE"
                                                          glp.Columns.Add("dr_name").Caption = "DR NAME"
                                                          glp.Columns.Add("dr_spec").Caption = "DR SPEC"
                                                          glp.Columns.Add("dr_sub_spec").Caption = "SUB SPEC"
                                                          glp.Columns.Add("dr_quadrant").Caption = "QUADRANT"
                                                          glp.Columns.Add("dr_monitoring").Caption = "MONITORING"
                                                          glp.Columns.Add("is_used").Caption = "STATUS"
                                                          glp.Columns.Add("dr_used_remaining").Caption = "REM"

                                                          glp.GridViewProperties.SetStatusBarTemplateContent(Sub(c)
                                                                                                                     ViewContext.Writer.Write("<div style='overflow: hidden'><div style='padding: 3px; float: right;'>")
                                                                                                                     Html.DevExpress().Button(Sub(btncl)
                                                                                                                                                      btncl.Name = "btnClose"
                                                                                                                                                      btncl.Text = "Close"
                                                                                                                                                      btncl.UseSubmitBehavior = False
                                                                                                                                                      btncl.ClientSideEvents.Click = "CloseGridLookup"
                                                                                                                                              End Sub).Render()
                                                                                                                     ViewContext.Writer.Write("</div></div>")

                                                                                                             End Sub)



                                                  End Sub)
    If ViewData("EditError") IsNot Nothing Then
        gridLookup.SetEditErrorText(CStr(ViewData("EditError")))
    End If

    gridLookup.BindList(Model).GetHtml()

End Code

