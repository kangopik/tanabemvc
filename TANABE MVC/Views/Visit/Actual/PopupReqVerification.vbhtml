@Html.DevExpress().PopupControl(Sub(settings)
                                    settings.Name = "popupControlReqVerification"
                                    settings.CallbackRouteValues = New With {.Controller = "visitactual", .Action = "LoadRequest"}
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
                                                                          ViewContext.Writer.Write("<div style='font-size:small;'>Verification Condition</div>")
                                                                      End Sub)
                                    settings.SetContent(Sub()

                                                            Html.DevExpress().RadioButton(Sub(racc)
                                                                                              racc.Name = "rdAccordanceDown"
                                                                                              racc.Properties.Caption = "Submission Plans"
                                                                                              racc.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                              racc.Text = "Accordance Shown"
                                                                                              racc.Properties.ClientSideEvents.CheckedChanged = "submission_check"
                                                                                              racc.GroupName = "sub_mission"
                                                                                          End Sub).GetHtml()
                                                            
                                                            Html.DevExpress().RadioButton(Sub(rddaily)
                                                                                              rddaily.Name = "rdDaily"
                                                                                              rddaily.Text = "Daily"
                                                                                              rddaily.Checked = True
                                                                                              rddaily.Properties.ClientSideEvents.CheckedChanged = "submission_check"
                                                                                              rddaily.GroupName = "sub_mission"
                                                                                          End Sub).GetHtml()

                                                            
                                                            Html.DevExpress().DateEdit(Sub(de)
                                                                                           de.Properties.Caption = "Date"
                                                                                           de.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                           de.Name = "DateEdit1"
                                                                                           de.Properties.EditFormatString = "dd/MM/yyyy"
                                                                                           de.Date = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                                                                                           de.Width = Unit.Pixel(250)
                                                                                           de.Properties.ClientSideEvents.ValueChanged = "daily_select"
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
                                                                                                                              
                                                                                                                              
                                                                                                                                If day = 0 Then Exit Sub
                                                                                                                                If e.Date = New DateTime(year, month, day) Then
                                                                                                                                    
                                                                                                                                    e.Cell.ToolTip = "Items : (" & cnt & ")"
                                                                                                                                    e.Cell.ForeColor = System.Drawing.Color.Black
                                                                                                                                    e.Cell.BackColor = System.Drawing.Color.Aqua
                                                                                                                                    
                                                                                                                                End If
                                                                                                                               
                                                                                                                            Next
                                                                                                                        End Sub
                                                                                           
                                                                                       End Sub).GetHtml()


                                                            ViewContext.Writer.Write("</br><div style='padding: 2px 0px 2px 0; float: right'>")

                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnCancel"
                                                                                         btn.Text = "Cancel"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "cancel_ReqVerification"
                                                                                     End Sub).GetHtml()

                                                            ViewContext.Writer.Write(" &nbsp; &nbsp;")


                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnSubmit"
                                                                                         btn.Text = "Submit"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "submit_ReqVerification"
                                                                                     End Sub).GetHtml()

                                                            ViewContext.Writer.Write("</div>")

                                                        End Sub)

                                End Sub).GetHtml()

<script type="text/javascript">

    function submit_ReqVerification() {
        popupControlReqVerification.Hide();
        var acc = rdAccordanceDown.GetValue();
        var dp = DateEdit1.GetDate();
        var day = dp.getDate();
        var month = dp.getMonth() + 1;
        var year = dp.getFullYear();
        var param = 'request_verification-'+acc +'-' + day + '-' + month + '-' + year;
        DataView1.PerformCallback({ act: param });

    }


    function cancel_ReqVerification() {
        popupControlReqVerification.Hide();
        }

    function submission_check() {
        var v_submission = rdAccordanceDown.GetValue();
      
        if (v_submission == true) {
            DateEdit1.SetVisible(false);          
            DataView1.PerformCallback({ act: 'reset' });          
        } else {
            DateEdit1.SetVisible(true);
           
        }
    }

    function daily_select(s, e) {
       
        var dp = DateEdit1.GetDate();
        var day = dp.getDate();
        var month = dp.getMonth() + 1;
        var year = dp.getFullYear();        
        var param = 'retrieve_selected-' + day + '-' + month + '-' + year;
        DataView1.PerformCallback({ act: param });
    }
   
  

</script>






