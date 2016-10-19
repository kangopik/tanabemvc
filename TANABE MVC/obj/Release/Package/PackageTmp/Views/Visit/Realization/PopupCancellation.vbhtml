@Html.DevExpress().PopupControl(Sub(settings)
                                    settings.Name = "popupControlCancellation"
                                    settings.CallbackRouteValues = New With {.Controller = "visitrealization", .Action = "LoadCancellation"}
                                    settings.CloseAction = CloseAction.CloseButton
                                    settings.ShowCloseButton = True
                                    settings.Modal = True
                                    settings.AllowDragging = True
                                    settings.EnableHotTrack = True
                                    settings.Height = Unit.Pixel(100)
                                    settings.Width = Unit.Pixel(250)
                                    settings.LoadContentViaCallback = LoadContentViaCallback.OnFirstShow

                                    settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                    settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter

                                    settings.SetHeaderTemplateContent(Sub()
                                                                          ViewContext.Writer.Write("<div style='font-size:small;'>Cancellation</div>")
                                                                      End Sub)
                                    settings.SetContent(Sub()

                                                            Html.DevExpress().ComboBox(Sub(cbocondition)
                                                                                           cbocondition.Name = "cbocondition"
                                                                                           cbocondition.Properties.Caption = "Condition"
                                                                                           cbocondition.Properties.Items.Add("Sick Leave")
                                                                                           cbocondition.Properties.Items(0).Value = "full"
                                                                                           cbocondition.Properties.Items.Add("Full Leave")
                                                                                           cbocondition.Properties.Items(1).Value = "full"
                                                                                           cbocondition.Properties.Items.Add("Half Leave")
                                                                                           cbocondition.Properties.Items(2).Value = "half"
                                                                                           cbocondition.Properties.Items.Add("Full Day Meeting")
                                                                                           cbocondition.Properties.Items(3).Value = "full"
                                                                                           
                                                                                           cbocondition.Properties.Items.Add("Half Day Meeting")
                                                                                           cbocondition.Properties.Items(4).Value = "half"
                                                                                           cbocondition.Properties.Items.Add("Full Day UC")
                                                                                           cbocondition.Properties.Items(5).Value = "full"
                                                                                           cbocondition.Properties.Items.Add("Half Day UC")
                                                                                           cbocondition.Properties.Items(6).Value = "half"
                                                                                           cbocondition.Properties.Items.Add("Half Day AV")
                                                                                           cbocondition.Properties.Items(7).Value = "half"
                                                                                           
                                                                                           cbocondition.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                           cbocondition.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                          
                                                                                           cbocondition.Width = Unit.Pixel(250)
                                                                                           cbocondition.Height = 27
                                                                                       End Sub).GetHtml()
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
                                                                                           de.Width = Unit.Pixel(250)
                                                                                           
                                                                                                                                                                                     
                                                                                       End Sub).GetHtml()

                                                            Html.DevExpress().GridLookup(Sub(productlist)
                                                                                             productlist.Name = "GridLookupCancellation"
                                                                                             productlist.Properties.Caption = "Planed Visit"
                                                                                             productlist.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                             productlist.KeyFieldName = "visit_code"
                                                                                             productlist.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "VisitRealization", Key .Action = "LoadRealization"}
                                                                                             productlist.Properties.SelectionMode = GridLookupSelectionMode.Multiple
                                                                                             productlist.Properties.TextFormatString = "{0}"
                                                                                             productlist.GridViewProperties.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords
                                                                                             productlist.GridViewProperties.Settings.VerticalScrollBarMode = ScrollBarMode.Auto
                                                                                             productlist.Width = Unit.Pixel(250)
                                                                                             productlist.Properties.MultiTextSeparator = ", "

                                                                                             productlist.Columns.Add("visit_code")
                                                                                             productlist.Columns.Add("visit_product")
                                                                                             productlist.Columns.Add("visit_team")
                                                                                             productlist.Columns.Add("visit_category")

                                                                                             productlist.Columns(0).Visible = False
                                                                                             productlist.Columns(1).Caption = "VISIT ID"
                                                                                             productlist.Columns(2).Caption = "DATE"
                                                                                             productlist.Columns(3).Caption = "DR CODE"

                                                                                             productlist.Columns(1).Width = Unit.Pixel(100)
                                                                                             productlist.Columns(2).Width = Unit.Pixel(100)
                                                                                             productlist.Columns(3).Width = Unit.Pixel(100)

                                                                                             productlist.GridViewStyles.Cell.Font.Size = 7.5
                                                                                             productlist.GridViewStyles.Header.Font.Size = 7.5
                                                                                             productlist.CommandColumn.ShowSelectCheckbox = True
                                                                                             productlist.CommandColumn.Visible = True
                                                                                             productlist.CommandColumn.SelectAllCheckboxMode = GridViewSelectAllCheckBoxMode.AllPages

                                                                                         End Sub).BindList(Model).GetHtml()

                                                            ViewContext.Writer.Write("</br><div style='padding: 2px 0px 2px 0; float: right'>")

                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnCancel"
                                                                                         btn.Text = "Cancel"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "cancel_cancellation"
                                                                                     End Sub).GetHtml()

                                                            ViewContext.Writer.Write(" &nbsp; &nbsp;")

                                                            
                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnSubmit"
                                                                                         btn.Text = "Submit"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "submit_cancellation"
                                                                                     End Sub).GetHtml()
                                                            
                                                            ViewContext.Writer.Write("</div>")

                                                        End Sub)

                                End Sub).GetHtml()

<script type="text/javascript">

    function submit_cancellation() {
        popupControlCancellation.Hide();
       
        var v_visit_code = GridLookup.GetValue();
       

        $.ajax({
            type: "POST",
            url: '@Url.Action("cancellation", "visitrealization")',
            data: {  visit_code: v_visit_code}
        }).done(function () {
                window.location.reload();
        });

    }


    function cancel_cancellation() {
        popupControlCancellation.Hide();
        }

  
</script>





