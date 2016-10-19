@Html.DevExpress().PopupControl(Sub(settings)
                                    settings.Name = "popupControl"
                                    settings.CallbackRouteValues = New With {.Controller = "visitplan", .Action = "LoadOnDemandPartial"}
                                    settings.CloseAction = CloseAction.OuterMouseClick
                                    settings.PopupVerticalAlign = PopupVerticalAlign.Below
                                    settings.PopupHorizontalAlign = PopupHorizontalAlign.LeftSides
                      
                                    settings.AllowDragging = True
                                    settings.EnableHotTrack = True
                                    settings.Height = Unit.Pixel(100)
                                    settings.Width = Unit.Pixel(250)
                                    settings.LoadContentViaCallback = LoadContentViaCallback.OnFirstShow
                                    settings.PopupElementID = "btnnewplan"
                                         
                                    settings.SetHeaderTemplateContent(Sub()
                                                                          ViewContext.Writer.Write("<div style='font-size:small;'>Add plan by doctors</div>")
                                                                      End Sub)
                                    settings.SetContent(Sub()
                                                            
                                                            Html.DevExpress().DateEdit(Sub(de)
                                                                                           de.Properties.Caption = "Date"
                                                                                           de.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                           de.Name = "DateEdit1"
                                                                                           de.Properties.EditFormatString = "dd/MM/yyyy"
                                                                                           de.Date = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                                                                                                                                                                                      
                                                                                           de.CalendarDayCellPrepared = Sub(o, e)
                                                                                                                            If e.Date = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) Then
                                                                                                                                e.Cell.ToolTip = "Today"
                                                                                                                            End If
                                                                                                                            
                                                                                                                            Dim i As Integer = 0
                                                                                                                            For i = 0 To TANABE_MVC.GlobalClass.temp_arr_visit_plan_full_date.Length - 1
                                                                                                                                
                                                                                                                                Dim day As Integer = TANABE_MVC.GlobalClass.temp_arr_visit_plan_full_date(i)
                                                                                                                                Dim cnt As Integer = TANABE_MVC.GlobalClass.temp_arr_visit_plan_full_cnt(i)
                                                                                                                                Dim month As Integer = DateTime.Now.Month
                                                                                                                                Dim year As Integer = DateTime.Now.Year
                                                                                                                                Dim rep_position As String = TANABE_MVC.GlobalClass.temp_rep_position
                                                                                                                              
                                                                                                                                If day = 0 Then Exit Sub
                                                                                                                                If e.Date = New DateTime(year, month, day) Then
                                                                                                                                    Select Case Trim(rep_position)
                                                                                                                                        Case "MR"
                                                                                                                                            If cnt = 11 Then
                                                                                                                                                e.Cell.ToolTip = "Completed (" & cnt & ")"
                                                                                                                                                e.Cell.ForeColor = System.Drawing.Color.Black
                                                                                                                                                e.Cell.BackColor = System.Drawing.Color.Aqua
                                                                                                                                            Else
                                                                                                                                                e.Cell.ToolTip = "Incomplete (" & cnt & ")"
                                                                                                                                                e.Cell.ForeColor = System.Drawing.Color.Black
                                                                                                                                                e.Cell.BackColor = System.Drawing.Color.Yellow
                                                                                                                                            End If
                                                                                                                                        Case "AM"
                                                                                                                                            If cnt = 5 Then
                                                                                                                                                e.Cell.ToolTip = "Completed (" & cnt & ")"
                                                                                                                                                e.Cell.ForeColor = System.Drawing.Color.Black
                                                                                                                                                e.Cell.BackColor = System.Drawing.Color.Aqua
                                                                                                                                            Else
                                                                                                                                                e.Cell.ToolTip = "Incomplete (" & cnt & ")"
                                                                                                                                                e.Cell.ForeColor = System.Drawing.Color.Black
                                                                                                                                                e.Cell.BackColor = System.Drawing.Color.Yellow
                                                                                                                                            End If
                                                                                                                                        Case "PPM"
                                                                                                                                            If cnt = 4 Then
                                                                                                                                                e.Cell.ToolTip = "Completed (" & cnt & ")"
                                                                                                                                                e.Cell.ForeColor = System.Drawing.Color.Black
                                                                                                                                                e.Cell.BackColor = System.Drawing.Color.Aqua
                                                                                                                                            Else
                                                                                                                                                e.Cell.ToolTip = "Incomplete (" & cnt & ")"
                                                                                                                                                e.Cell.ForeColor = System.Drawing.Color.Black
                                                                                                                                                e.Cell.BackColor = System.Drawing.Color.Yellow
                                                                                                                                            End If
                                                                                                                                        Case "PS"
                                                                                                                                            If cnt = 6 Then
                                                                                                                                                e.Cell.ToolTip = "Completed (" & cnt & ")"
                                                                                                                                                e.Cell.ForeColor = System.Drawing.Color.Black
                                                                                                                                                e.Cell.BackColor = System.Drawing.Color.Aqua
                                                                                                                                            Else
                                                                                                                                                e.Cell.ToolTip = "Incomplete (" & cnt & ")"
                                                                                                                                                e.Cell.ForeColor = System.Drawing.Color.Black
                                                                                                                                                e.Cell.BackColor = System.Drawing.Color.Yellow
                                                                                                                                            End If
                                                                                                                                    End Select
                                                                                                                                    
                                                                                                                                    
                                                                                                                                End If
                                                                                                                               
                                                                                                                            Next
                                                                                                                        End Sub
                                                                                           de.Width = 240
                                                                                           
                                                                                                                                                                                     
                                                                                       End Sub).GetHtml()
                                                            
                                                          
                                                     
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
                                                                                                              
                                                                                                              glp.GridViewStyles.Header.Font.Size = 7
                                                                                                              glp.Columns.Add("dr_code").Caption = "DR CODE"
                                                                                                              glp.Columns.Add("dr_name").Caption = "DR NAME"
                                                                                                              glp.Columns.Add("dr_spec").Caption = "DR SPEC"
                                                                                                              glp.Columns.Add("dr_sub_spec").Caption = "SUB SPEC"
                                                                                                              glp.Columns.Add("dr_quadrant").Caption = "QUADRANT"
                                                                                                              glp.Columns.Add("dr_monitoring").Caption = "MONITORING"
                                                                                                              glp.Columns(0).Width = Unit.Pixel(60)
                                                                                                              glp.Columns(1).Width = Unit.Pixel(150)
                                                                                                              glp.Columns(2).Width = Unit.Pixel(50)
                                                                                                              glp.Columns(3).Width = Unit.Pixel(100)
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

                                                           
                                                            ViewContext.Writer.Write("</br><div style='padding: 2px 0px 2px 0; float: right'>")
                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnSubmit"
                                                                                         btn.Text = "Submit"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         
                                                                                         btn.ClientSideEvents.Click = "setdateplan"
                                                                                     End Sub).GetHtml()
                                                            ViewContext.Writer.Write("</div>")
                                                            
                                                        End Sub)
                                         
                                End Sub).GetHtml()

<script type="text/javascript">   
    function CloseGridLookup() {
        GridLookup.ConfirmCurrentSelection();
        GridLookup.HideDropDown();
        GridLookup.Focus();
    }

    function setdateplan() {
        popupControl.Hide();

        var dp = DateEdit1.GetDate();
        var day = dp.getDate();
        var month = dp.getMonth()+1;
        var year = dp.getFullYear();
        var vdate = year + "-" + month + "-" + day
        var vdr_code = GridLookup.GetValue();
        
        $.ajax({
            type: "POST",
            url: '@Url.Action("addvisit", "visitplan")',           
            data: { date_plan: vdate, dr_code: vdr_code }
        }).done(function () {          
                window.location.reload();
           
        });
         
    }

    function OnMoreInfoClick(element,params) {
        if (params!=''){
            PopupInfoDetailControl.ShowAtElement(element);
            PopupInfoDetailControl.PerformCallback({ act: params });
        }
       
    }
</script>




