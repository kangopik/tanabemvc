

@Html.DevExpress().PopupControl(
    Sub(settings)
            settings.Name = "popupControlAdditionalVisit"
            settings.CallbackRouteValues = New With {.Controller = "visitrealization", .Action = "LoadAdditional"}
            settings.CloseAction = CloseAction.CloseButton
            settings.ShowCloseButton = True
            settings.Modal = True
            settings.CloseAnimationType = AnimationType.Slide
            settings.AllowDragging = True
            settings.EnableHotTrack = True
            settings.Height = Unit.Pixel(100)
            settings.Width = Unit.Pixel(300)
            settings.LoadContentViaCallback = LoadContentViaCallback.OnFirstShow
            settings.ShowFooter = False
            settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
            settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter

            settings.SetHeaderTemplateContent(
                Sub()
                        ViewContext.Writer.Write("<div style='font-size:small;'>Additional Visit</div>")
                End Sub)
            
            settings.CustomJSProperties = Sub(s, e)
                                                  If ViewData("AdditionalFlag") IsNot Nothing Then
                                                      e.Properties("cpAdditionalFlag") = ViewData("AdditionalFlag").ToString()
                                                  End If
                                          End Sub
            
            settings.ClientSideEvents.EndCallback = "function(s, e) { popupControlAdditionalVisit_EndCallback(s, e); }"
            
            settings.SetContent(
                Sub()
                        Html.RenderPartial("~/Views/Visit/Realization/AdditionalDoctorPartial.vbhtml")
                                                            
                        Html.DevExpress().DateEdit(
                            Sub(de)
                                    de.Properties.Caption = "Date"
                                    de.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                    de.Name = "DateEdit1"
                                    de.Properties.EditFormatString = "dd/MM/yyyy"
                                    de.Date = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                                                                                           
                                                                                           
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
                                    de.Width = Unit.Pixel(250)
                                                                                           
                                                                                                                                                                                     
                            End Sub).GetHtml()
                                                            
                        
                        Html.DevExpress().RadioButton(
                            Sub(rdas)
                                    rdas.Name = "rdVisitedAdditionalVisit"
                                    rdas.Properties.Caption = "Actual Visit"
                                    rdas.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                    rdas.Checked = True
                                    rdas.Enabled = False
                                    rdas.Text = "Visited"
                                    rdas.GroupName = "sub_mission"
                                    rdas.Properties.ClientSideEvents.CheckedChanged = "visit_check_additional"
                            End Sub).GetHtml()
                       
                        Html.DevExpress().RadioButton(
                            Sub(rdacc)
                                    rdacc.Name = "rdNotVisitedAdditionalVisit"
                                    rdacc.Text = "Not Visited"
                                    rdacc.GroupName = "sub_mission"
                                    rdacc.Enabled = False
                                    rdacc.Properties.ClientSideEvents.CheckedChanged = "visit_check_additional"
                            End Sub).GetHtml()
                        
                        Html.RenderPartial("~/Views/Visit/Realization/AdditionalProductPartial.vbhtml")
                                              
                        Html.DevExpress().Memo(
                            Sub(txtinfo)
                                    txtinfo.Name = "txtinfoAdditionalVisit"
                                    txtinfo.ControlStyle.CssClass = "editor"
                                    txtinfo.Height = System.Web.UI.WebControls.Unit.Pixel(60)
                                    txtinfo.Properties.Caption = "Info"
                                    txtinfo.Width = Unit.Pixel(250)
                                    txtinfo.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                            End Sub).GetHtml()

                        Html.DevExpress().TextBox(
                            Sub(txtsp)
                                    txtsp.Name = "txtspAdditionalVisit"
                                    txtsp.Width = Unit.Pixel(100)
                                    txtsp.Properties.Caption = "SP"
                                    txtsp.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                            End Sub).GetHtml()

                        Html.DevExpress().SpinEdit(
                            Sub(spvalue)
                                    spvalue.Name = "spvalueAdditionalVisit"
                                    spvalue.Width = Unit.Pixel(100)
                                    spvalue.Properties.Caption = "SP Value"
                                    spvalue.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                    spvalue.Properties.SpinButtons.ShowLargeIncrementButtons = False
                                    spvalue.Properties.SpinButtons.ShowIncrementButtons = True
                                    spvalue.Properties.LargeIncrement = 10
                                    spvalue.Properties.Increment = 1
                            End Sub).GetHtml()


                        ViewContext.Writer.Write("</br><div style='padding: 2px 0px 2px 0; float: right'>")
                        
                        Html.DevExpress().Button(
                            Sub(btn)
                                    btn.Name = "btnSubmitAdditionalVisit"
                                    btn.Text = "Submit"
                                    btn.ClientSideEvents.Click = "submit_additional"
                            End Sub).GetHtml()
                        ViewContext.Writer.Write(" &nbsp; &nbsp;")
                        Html.DevExpress().Button(
                            Sub(btn)
                                    btn.Name = "btnCancelAdditionalVisit"
                                    btn.Text = "Cancel"
                                    btn.ClientSideEvents.Click = "cancel_additional"
                            End Sub).GetHtml()

                        ViewContext.Writer.Write("</div>")

                End Sub)

    End Sub).GetHtml()

<script type="text/javascript">

    function submit_additional() {
        //popupControlAdditionalVisit.Hide();
        var v_dr_code = GridLookupDoctorList.GetValue();
        if (v_dr_code == null) {
            alert("please choose your dr code");
            GridLookupDoctorList.Focus();
            return false;
        }

        var dp = DateEdit1.GetDate();
        var day = dp.getDate();
        var month = dp.getMonth() + 1;
        var year = dp.getFullYear();
        var v_date = year + "-" + month + "-" + day;       

        var v_product_code = GridLookupProductAdditionalVisit.GetValue();
        if (v_product_code == null) {
            alert("please choose your visit code");
            GridLookupProductAdditionalVisit.Focus();
            return false;
        }

        var v_info = txtinfoAdditionalVisit.GetValue();
        var v_sp = txtspAdditionalVisit.GetValue();
        var v_sp_value = spvalueAdditionalVisit.GetValue();
        
        var param = 'additional;' + v_dr_code + ';' + v_date + ';' + v_product_code + ';' + v_info + ';' + v_sp + ';' + v_sp_value;
        popupControlAdditionalVisit.PerformCallback({ prm: param });

    }


    function cancel_additional() {
        popupControlAdditionalVisit.Hide();
        }

    function visit_check_additional() {
        var v_visited = rdVisitedAdditionalVisit.GetValue();

        if (v_visited == true) {
            GridLookupAdditionalVisit.SetEnabled(true);
            txtspAdditionalVisit.SetEnabled(true);
            spvalueAdditionalVisit.SetEnabled(true);
        } else {
            GridLookupAdditionalVisit.SetEnabled(false);           
            txtspAdditionalVisit.SetEnabled(false);
            txtspAdditionalVisit.SetValue(null);
            spvalueAdditionalVisit.SetEnabled(false);
            spvalueAdditionalVisit.SetValue(null);
        }

    }
    function popupControlAdditionalVisit_EndCallback(s, e) {
        if (s.cpAdditionalFlag != undefined) {
            if (s.cpAdditionalFlag == "success") {
                alert("Additional visit has been saved");
                popupControlAdditionalVisit.Hide();
                return true;
            } else {
                alert(s.cpAdditionalFlag);
                s.cpAdditionalFlag = 'undefined';
                return false;
            }
        }
        
    }
</script>





