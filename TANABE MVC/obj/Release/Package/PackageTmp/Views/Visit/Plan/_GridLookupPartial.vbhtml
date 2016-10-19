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
                                                          glp.CommandColumn.ShowSelectCheckbox = True
                                                          glp.Properties.TextFormatString = "{0}"
                                                          glp.Properties.MultiTextSeparator = ", "
                                                                                                            
                                                          glp.CommandColumn.Visible = True
                                                          glp.GridViewProperties.SettingsPager.Visible = True
                                                          glp.GridViewProperties.Settings.ShowGroupPanel = False
                                                          glp.GridViewProperties.Settings.ShowFilterRow = True
                                                          glp.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                                            
                                                                                                            
                                                          
                                                          glp.GridViewProperties.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords
                                                          glp.GridViewProperties.Settings.VerticalScrollBarMode = ScrollBarMode.Auto
                                                                                                              
                                                                                                                 
                                                          glp.Columns.Add("dr_code").Caption = "DR CODE"
                                                          glp.Columns.Add("dr_name").Caption = "DR NAME"
                                                          glp.Columns.Add("dr_spec").Caption = "DR SPEC"
                                                          glp.Columns.Add("dr_sub_spec").Caption = "SUB SPEC"
                                                          glp.Columns.Add("dr_quadrant").Caption = "QUADRANT"
                                                          glp.Columns.Add("dr_monitoring").Caption = "MONITORING"
                                                          glp.Columns(0).Width = Unit.Pixel(60)
                                                          glp.Columns(1).Width = Unit.Pixel(150)
                                                          glp.Columns(2).Width = Unit.Pixel(50)
                                                          glp.Columns(3).Width = Unit.Pixel(80)
                                                          glp.Columns(4).Width = Unit.Pixel(50)
                                                          glp.Columns(5).Width = Unit.Pixel(150)
                                                                                                              
                                                                                                             
                                                                                                              
                                                          
                                                          
                                                          glp.Columns.Add(Sub(column)
                                                                                  column.Caption = "STATUS"
                                                                                  column.FieldName = "is_used"
                                                                                  column.ColumnType = MVCxGridViewColumnType.ButtonEdit
                                                                                 
                                                                                  column.SetDataItemTemplateContent(Sub(c)
                                                                                                                            Dim id = DataBinder.Eval(c.DataItem, "is_used")
                                                                                                                            Dim v_dr_code = DataBinder.Eval(c.DataItem, "dr_code")
                                                                                                                            ViewContext.Writer.Write("<a href='javascript:void(0);'onmouseover='OnMoreInfoClick(this," & v_dr_code & ")'>" & id & "</a> ")
                                                                                                                    End Sub)
                                                                          End Sub)
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          
                                                          glp.Columns.Add("dr_used_remaining").Caption = "REM"
                                                          
                                                          glp.Columns(6).Width = Unit.Pixel(70)
                                                          
                                                          For i As Integer = 0 To 7
                                                              glp.Columns(i).CellStyle.Font.Size = 7
                                                                                                                 
                                                              glp.Columns(i).CellStyle.VerticalAlign = VerticalAlign.Middle
                                                              If i = 1 Or i = 5 Then
                                                                  glp.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Left
                                                              Else
                                                                  glp.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                                              End If
                                                                                                                  
                                                          Next
                                                                                                              
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
