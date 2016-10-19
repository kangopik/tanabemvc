@Html.DevExpress().PopupControl(
    Sub(settings)
            settings.Name = "popupControlCancellation"
            settings.CallbackRouteValues = New With {.Controller = "visitrealization", .Action = "LoadCancellation"}
            settings.CloseAction = CloseAction.CloseButton
            settings.ShowCloseButton = True
            settings.ShowHeader = True
            settings.HeaderText = "Cancellation Form"
            settings.Modal = True
            settings.AllowDragging = True
            settings.EnableHotTrack = True
            settings.Height = Unit.Pixel(100)
            settings.Width = Unit.Pixel(250)
            settings.LoadContentViaCallback = LoadContentViaCallback.OnFirstShow
            settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
            settings.PopupVerticalAlign = PopupVerticalAlign.Above
            settings.ClientSideEvents.Closing = "function(s, e) { popupCancellation_Close(); }"
            settings.ClientSideEvents.EndCallback = "function(s, e) { popupCancellation_EndCallback(s, e); }"

            settings.CustomJSProperties = Sub(s, e)
                                                  If ViewData("CancellationFlag") IsNot Nothing Then
                                                      e.Properties("cpCancellationFlag") = ViewData("CancellationFlag").ToString()
                                                  End If
                                                  If ViewData("TCFlag") IsNot Nothing Then
                                                      e.Properties("cpTC") = ViewData("TCFlag").ToString()
                                                  End If
                                                  If ViewData("DTFlag") IsNot Nothing Then
                                                      e.Properties("cpDT") = ViewData("DTFlag").ToString()
                                                  End If
                                          End Sub
            settings.SetContent(Sub()
                                        Html.DevExpress().ComboBox(
                                        Sub(cbSettings)
                                                cbSettings.Properties.ClientSideEvents.SelectedIndexChanged = "function(s, e) { rbCondition_ValueChanged(s, e); }"
                                                cbSettings.Name = "rbCondition"
                                                cbSettings.Properties.Caption = "Condition"
                                                cbSettings.Properties.Items.Add("Sick Leave").Value = "full"
                                                cbSettings.Properties.Items.Add("Full Leave").Value = "full"
                                                cbSettings.Properties.Items.Add("Half Leave").Value = "half"
                                                cbSettings.Properties.Items.Add("Full Day Meeting").Value = "full"
                                                cbSettings.Properties.Items.Add("Half Day Meeting").Value = "half"
                                                cbSettings.Properties.Items.Add("Full Day UC").Value = "full"
                                                cbSettings.Properties.Items.Add("Half Day UC").Value = "half"
                                                cbSettings.Properties.Items.Add("Half Day AV").Value = "half"
                                                cbSettings.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                cbSettings.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                'cbSettings.SelectedIndex = DateTime.Now.Month - 1
                                                cbSettings.Width = 215
                                                cbSettings.ControlStyle.Font.Size = 10
                                        End Sub).GetHtml()
                                        'ViewContext.Writer.Write("</br>")
                                        Html.DevExpress().DateEdit(
                                            Sub(de)
                                                    de.Properties.Caption = "Date Visit"
                                                    de.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                    de.Name = "dateCancellation"
                                                    de.ControlStyle.Font.Size = 10
                                                    de.Properties.EditFormatString = "dd/MM/yyyy"
                                                    de.Properties.ClientSideEvents.ValueChanged = "function(s, e) { dateCancellation_ValueChanged(s, e); }"
                                                    'de.Date = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                                                    de.CalendarDayCellPrepared =
                                                        Sub(o, e)
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
                                                    de.Width = Unit.Pixel(215)
                                                                                           
                                                                                                                                                                                     
                                            End Sub).GetHtml()
                                        
                                        Html.RenderPartial("~/Views/Visit/Realization/CancellationVisitListPartial.vbhtml")
                                        
                                        ViewContext.Writer.Write("</br><div style='padding: 2px 0px 2px 0; margin-left:70px; float: left'>")
                                        
                                        Html.DevExpress().Button(Sub(btn)
                                                                         btn.Name = "btnSubmitCancellation"
                                                                         btn.Text = "Submit"
                                                                         'btn.UseSubmitBehavior = True
                                                                         btn.ClientSideEvents.Click = "submit_cancellation"
                                                                 End Sub).GetHtml()
                                        ViewContext.Writer.Write(" &nbsp; ")
                                                           
                                        Html.DevExpress().Button(Sub(btn)
                                                                         btn.Name = "btnCancelCancellation"
                                                                         btn.Text = "Cancel"
                                                                         'btn.UseSubmitBehavior = True
                                                                         btn.ClientSideEvents.Click = "cancel_cancellation"
                                                                 End Sub).GetHtml()
                                       
                                                            
                                        ViewContext.Writer.Write("</div>")

                                                            
                                End Sub)
    End Sub).GetHtml()

<script type="text/javascript">
    function gridLookupPlannedVisit_SelectedChanges(s, e) {
            var i = s.GetSelectedRowCount();
            if (i == 6) { 
                alert('You have selected max record to process cancellation');
                s.UnselectRows(e.visibleIndex); 
                }
    }

    function cancel_cancellation() {
        dateCancellation.SetValue(null);
        rbCondition.SetText(null);
        gridLookupPlannedVisit.SetValue(null);
        popupControlCancellation.Hide();
    }

    
    function submit_cancellation() {
        alert('masuk');
        var conText = rbCondition.GetText();
        var conValue = rbCondition.GetValue();
        if (conValue == null) {
            alert("Please choose your cancellation condition !");
            rbCondition.Focus();
            return false;
        }
        var dateValue = dateCancellation.GetText();
        if (dateValue == null || dateValue == '') {
            alert("Please choose your cancellation date !");
            dateCancellation.Focus();
            return false;
        }
        if (conValue == "half") {
            var planText = gridLookupPlannedVisit.GetText();
            if (planText == null || planText == '') {
                alert("Please choose your visit !");
                gridLookupPlannedVisit.Focus();
                return false;
            }
            params = 'submit;' + conText + ';' + conValue + ';' + dateValue + ';' + planText
        } else {
            params = 'submit;' + conText + ';' + conValue + ';' + dateValue 
        }
        popupControlCancellation.Hide();
        popupControlCancellation.PerformCallback({ prm: params });
        
    }

    function popupCancellation_Close() {
        rbCondition.SetText(null);
        gridLookupPlannedVisit.SetValue(null);
        dateCancellation.SetValue(null);
        //grid_visit_plan.PerformCallback(null + ';' + null);
    }

    function dateCancellation_ValueChanged(s, e) {
        var action = rbCondition.GetValue();
        var textCondition = rbCondition.GetText();
        var date = s.GetText();
        var params = date + ';' + textCondition + ';' + action
        if (action == null) {
            alert("Please choose cancellation condition for first")
            dateCancellation.SetValue(null);
            rbCondition.Focus();
            return false;
        }
        if (action == "half"){
            popupControlCancellation.PerformCallback({ prm: params });
        }
    }

    function rbCondition_ValueChanged(s, e) {
        var condition = s.GetValue();
        var textCondition = s.GetText();
        var params = condition + ';' + textCondition;
        popupControlCancellation.PerformCallback({ prm: params });

    }

    function popupCancellation_EndCallback(s, e) {
        if (s.cpCancellationFlag != "undefined") {
            rbCondition.SetValue(null);
            if (s.cpCancellationFlag == "success_submit") {
                popupControlCancellation.Hide();
                alert("Cancellation has been successfully submitted");
                //grid_visit_plan.PerformCallback("reset" + ';' + null + ';' + null);
                DataView1.Refresh();
                s.cpCancellationFlag = "undefined";
            } else if (s.cpCancellationFlag == "error_submit") {
                popupControlCancellation.Hide();
                alert("There is an error on submitting cancellation process");
                s.cpCancellationFlag = "undefined";
            }  else if (s.cpCancellationFlag == "null_plan") {
                rbCondition.SetText(s.cpTC);
               // dateCancellation.SetText(s.cpDT);
                alert("There is no visit planned on selected dates");
                s.cpCancellationFlag = "undefined";
                dateCancellation.SetValue(null);
            } else if (s.cpCancellationFlag == "full") {
                rbCondition.SetText(s.cpTC);
                gridLookupPlannedVisit.SetVisible(false);
                s.cpCancellationFlag = "undefined";
            } else if (s.cpCancellationFlag == "half") {
                gridLookupPlannedVisit.SetVisible(true);
                rbCondition.SetText(s.cpTC);
                s.cpCancellationFlag = "undefined";
            } else if (s.cpCancellationFlag == "available_plan") {
                rbCondition.SetText(s.cpTC);
                dateCancellation.SetText(s.cpDT);
                s.cpCancellationFlag = "undefined";
            }
        }

    }
</script>





