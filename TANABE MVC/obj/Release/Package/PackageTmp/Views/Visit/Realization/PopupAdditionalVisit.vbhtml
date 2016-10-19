@code
    Dim vpproduct As New TANABE_MVC.ProductListClass
    Dim model_product = Nothing
    model_product = vpproduct.GetDataProductList()
       
End Code
@Html.DevExpress().PopupControl(Sub(settings)
                                    settings.Name = "popupControlAdditionalVisit"
                                    settings.CallbackRouteValues = New With {.Controller = "visitrealization", .Action = "LoadDoctorList"}
                                    settings.CloseAction = CloseAction.CloseButton
                                    settings.ShowCloseButton = True
                                    settings.Modal = True
                                    settings.CloseAnimationType = AnimationType.Slide
                                    settings.AllowDragging = True
                                    settings.EnableHotTrack = True
                                    settings.Height = Unit.Pixel(100)
                                    settings.Width = Unit.Pixel(250)
                                    settings.LoadContentViaCallback = LoadContentViaCallback.OnFirstShow

                                    settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                    settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter

                                    settings.SetHeaderTemplateContent(Sub()
                                                                          ViewContext.Writer.Write("<div style='font-size:small;'>Additional Visit</div>")
                                                                      End Sub)
                                    settings.SetContent(Sub()


                                                            Html.DevExpress().GridLookup(Sub(doctorlist)
                                                                                             doctorlist.Name = "GridLookupDoctorList"
                                                                                             doctorlist.Properties.Caption = "Doctor Visit"
                                                                                             doctorlist.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                             doctorlist.KeyFieldName = "dr_code"
                                                                                             doctorlist.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "VisitRealization", Key .Action = "LoadDoctorList"}
                                                                                             doctorlist.Properties.SelectionMode = GridLookupSelectionMode.Multiple
                                                                                             doctorlist.Properties.TextFormatString = "{0}"
                                                                                             doctorlist.GridViewProperties.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords
                                                                                             doctorlist.GridViewProperties.Settings.VerticalScrollBarMode = ScrollBarMode.Auto
                                                                                             doctorlist.Width = Unit.Pixel(250)
                                                                                             doctorlist.Properties.MultiTextSeparator = ", "
                                                                                             
                                                                                             doctorlist.Columns.Add("dr_code")
                                                                                             doctorlist.Columns.Add("dr_name")
                                                                                             doctorlist.Columns.Add("dr_spec")
                                                                                             doctorlist.Columns.Add("dr_sub_spec")
                                                                                             doctorlist.Columns.Add("dr_quadrant")
                                                                                             doctorlist.Columns.Add("dr_monitoring")
                                                                                             doctorlist.Columns.Add("is_used")

                                                                                             doctorlist.Columns(0).Visible = False
                                                                                             doctorlist.Columns(1).Caption = "DR NAME"
                                                                                             doctorlist.Columns(2).Caption = "SPEC"
                                                                                             doctorlist.Columns(3).Caption = "SUB SPEC"
                                                                                             doctorlist.Columns(4).Caption = "QRD"
                                                                                             doctorlist.Columns(5).Caption = "MONITORING"
                                                                                             doctorlist.Columns(6).Caption = "STATUS"
                                                                                             
                                                                                             For i As Integer = 0 To 6
                                                                                                 If i = 4 Or i = 2 Then
                                                                                                     doctorlist.Columns(i).Width = Unit.Pixel(50)
                                                                                                 ElseIf i = 5 Then
                                                                                                     doctorlist.Columns(i).Width = Unit.Pixel(200)
                                                                                                 ElseIf i = 6 Then
                                                                                                     doctorlist.Columns(i).Width = Unit.Pixel(80)
                                                                                                 Else
                                                                                                     doctorlist.Columns(i).Width = Unit.Pixel(150)
                                                                                                 End If
                                                                                                
                                                                                             Next
                                                                                                                                                                                    

                                                                                             doctorlist.GridViewStyles.Cell.Font.Size = 7.5
                                                                                             doctorlist.GridViewStyles.Header.Font.Size = 7.5
                                                                                             doctorlist.CommandColumn.ShowSelectCheckbox = True
                                                                                             doctorlist.CommandColumn.Visible = True
                                                                                             doctorlist.CommandColumn.SelectAllCheckboxMode = GridViewSelectAllCheckBoxMode.AllPages

                                                                                         End Sub).BindList(Model).GetHtml()
                                                            
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
                                                            
                                                            
                                                            Html.DevExpress().RadioButton(Sub(rdas)
                                                                                              rdas.Name = "rdVisitedAdditionalVisit"
                                                                                              rdas.Properties.Caption = "Actual Visit"
                                                                                              rdas.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                              rdas.Checked = True
                                                                                              rdas.Enabled = False
                                                                                              rdas.Text = "Visited"
                                                                                              rdas.GroupName = "sub_mission"
                                                                                              rdas.Properties.ClientSideEvents.CheckedChanged = "visit_check_additional"
                                                                                          End Sub).GetHtml()

                                                            Html.DevExpress().RadioButton(Sub(rdacc)
                                                                                              rdacc.Name = "rdNotVisitedAdditionalVisit"
                                                                                              rdacc.Text = "Not Visited"
                                                                                              rdacc.GroupName = "sub_mission"
                                                                                              rdacc.Enabled = False
                                                                                              rdacc.Properties.ClientSideEvents.CheckedChanged = "visit_check_additional"
                                                                                          End Sub).GetHtml()
                                                                                                                      
                                                            
                                                            Html.DevExpress().GridLookup(Sub(productlist)
                                                                                             productlist.Name = "GridLookupProductAdditionalVisit"
                                                                                             productlist.Properties.Caption = "Doctor Visit"
                                                                                             productlist.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                             productlist.KeyFieldName = "visit_code"
                                                                                             productlist.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "VisitRealization", Key .Action = "LoadProduct"}
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
                                                                                             productlist.Columns(1).Caption = "PRODUCT"
                                                                                             productlist.Columns(2).Caption = "TEAM"
                                                                                             productlist.Columns(3).Caption = "VISIT CATRGORY"

                                                                                             productlist.Columns(1).Width = Unit.Pixel(100)
                                                                                             productlist.Columns(2).Width = Unit.Pixel(100)
                                                                                             productlist.Columns(3).Width = Unit.Pixel(100)
                                                                                         

                                                                                             productlist.GridViewStyles.Cell.Font.Size = 7.5
                                                                                             productlist.GridViewStyles.Header.Font.Size = 7.5
                                                                                             productlist.CommandColumn.ShowSelectCheckbox = True
                                                                                             productlist.CommandColumn.Visible = True
                                                                                             productlist.CommandColumn.SelectAllCheckboxMode = GridViewSelectAllCheckBoxMode.AllPages

                                                                                         End Sub).BindList(model_product).GetHtml()


                                                            Html.DevExpress().Memo(Sub(txtinfo)
                                                                                       txtinfo.Name = "txtinfoAdditionalVisit"
                                                                                       txtinfo.ControlStyle.CssClass = "editor"
                                                                                       txtinfo.Height = System.Web.UI.WebControls.Unit.Pixel(60)
                                                                                       txtinfo.Properties.Caption = "Info"
                                                                                       txtinfo.Width = Unit.Pixel(250)
                                                                                       txtinfo.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                   End Sub).GetHtml()

                                                            Html.DevExpress().TextBox(Sub(txtsp)
                                                                                          txtsp.Name = "txtspAdditionalVisit"
                                                                                          txtsp.Width = Unit.Pixel(100)
                                                                                          txtsp.Properties.Caption = "SP"
                                                                                          txtsp.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                                                                      End Sub).GetHtml()

                                                            Html.DevExpress().SpinEdit(Sub(spvalue)
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

                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnCancelAdditionalVisit"
                                                                                         btn.Text = "Cancel"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "cancel_additional"
                                                                                     End Sub).GetHtml()

                                                            ViewContext.Writer.Write(" &nbsp; &nbsp;")

                                                            Html.DevExpress().Button(Sub(btn)
                                                                                         btn.Name = "btnSubmitAdditionalVisit"
                                                                                         btn.Text = "Submit"
                                                                                         btn.UseSubmitBehavior = True
                                                                                         btn.ClientSideEvents.Click = "submit_additional"
                                                                                     End Sub).GetHtml()

                                                            ViewContext.Writer.Write("</div>")

                                                        End Sub)

                                End Sub).GetHtml()

<script type="text/javascript">

    function submit_additional() {
        popupControlAdditionalVisit.Hide();
       
        var v_dr_code = GridLookupDoctorList.GetValue();
      
        var dp = DateEdit1.GetDate();
        var day = dp.getDate();
        var month = dp.getMonth() + 1;
        var year = dp.getFullYear();
        var v_date = year + "-" + month + "-" + day;       

        var v_product_code = GridLookupProductAdditionalVisit.GetValue();
        var v_info = txtinfoAdditionalVisit.GetValue();
        var v_sp = txtspAdditionalVisit.GetValue();
        var v_sp_value = spvalueAdditionalVisit.GetValue();
        
        $.ajax({
            type: "POST",
            url: '@Url.Action("additional", "visitrealization")',
            data: { dr_code: v_dr_code, visit_date_plan: v_date, product_code: v_product_code, info: v_info, sp: v_sp, sp_value: v_sp_value }
        }).done(function () {
                window.location.reload();
        });

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
</script>





