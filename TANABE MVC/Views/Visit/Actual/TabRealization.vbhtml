

@code
        
    Html.DevExpress().TextBox(Sub(txtdr)
                                      txtdr.Name = "txtDrCode"
                                      txtdr.Width = Unit.Pixel(250)
                                      txtdr.Properties.Caption = "Doctor Code"
                                      txtdr.Enabled = False
                                      txtdr.Text = TANABE_MVC.GlobalClass.visit_actual_dr_code
                                      txtdr.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                              End Sub).GetHtml()
    
    'Public Shared visit_actual_visited As String
    
    'Public Shared visit_actual_info As String
    'Public Shared visit_actual_sp As String
    'Public Shared visit_actual_sp_value As String
    

    Html.DevExpress().RadioButton(Sub(rdas)
                                          rdas.Name = "rdVisitedDoctorVisit"
                                          rdas.Properties.Caption = "Actual Visit"
                                          rdas.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                          If TANABE_MVC.GlobalClass.visit_actual_visited = 1 Then
                                              rdas.Checked = True
                                          Else
                                              rdas.Checked = False
                                          End If
                                        
                                          rdas.Enabled = True
                                          rdas.Text = "Visited"
                                          rdas.GroupName = "doctor_visit"
                                          rdas.Properties.ClientSideEvents.CheckedChanged = "submission_check_doctor_visit"
                                  End Sub).GetHtml()

    Html.DevExpress().RadioButton(Sub(rdacc)
                                          rdacc.Name = "rdNotDoctorVisit"
                                          rdacc.Text = "Not Visited"
                                          rdacc.GroupName = "doctor_visit"
                                          rdacc.Enabled = True
                                          
                                          If TANABE_MVC.GlobalClass.visit_actual_visited = 1 Then
                                              rdacc.Checked = False
                                          Else
                                              rdacc.Checked = True
                                          End If
                                          
                                          rdacc.Properties.ClientSideEvents.CheckedChanged = "submission_check_doctor_visit"
                                  End Sub).GetHtml()

    Html.DevExpress().Memo(Sub(txtinfo)
                                   txtinfo.Name = "txtinfoDoctorVisit"
                                   txtinfo.ControlStyle.CssClass = "editor"
                                   txtinfo.Height = System.Web.UI.WebControls.Unit.Pixel(60)
                                   txtinfo.Properties.Caption = "Info"
                                   txtinfo.Width = Unit.Pixel(250)
                                   txtinfo.Text = TANABE_MVC.GlobalClass.visit_actual_info
                                   txtinfo.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                           End Sub).GetHtml()

    Html.DevExpress().TextBox(Sub(txtsp)
                                      txtsp.Name = "txtspDoctorVisit"
                                      txtsp.Width = Unit.Pixel(100)
                                      txtsp.Properties.Caption = "SP"
                                      txtsp.Text = TANABE_MVC.GlobalClass.visit_actual_sp
                                      txtsp.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                              End Sub).GetHtml()

    Html.DevExpress().SpinEdit(Sub(spvalue)
                                       spvalue.Name = "spvalueDoctorVisit"
                                       spvalue.Width = Unit.Pixel(100)
                                       spvalue.Properties.Caption = "SP Value"
                                       spvalue.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                                       spvalue.Properties.SpinButtons.ShowLargeIncrementButtons = False
                                       spvalue.Properties.SpinButtons.ShowIncrementButtons = True
                                       spvalue.Properties.LargeIncrement = 10
                                       spvalue.Properties.Increment = 1
                                       spvalue.Number = TANABE_MVC.GlobalClass.visit_actual_sp_value
                                       spvalue.Properties.MinValue = 0
                               End Sub).GetHtml()
      

End Code  
