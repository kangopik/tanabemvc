    @Html.DevExpress().GridLookup(
        Sub(doctorlist)
                doctorlist.Name = "GridLookupDoctorList"
                doctorlist.Properties.Caption = "Doctor Visit"
                doctorlist.Properties.CaptionSettings.Position = EditorCaptionPosition.Top
                doctorlist.KeyFieldName = "dr_code"
                doctorlist.GridViewProperties.CallbackRouteValues = New With {Key .Controller = "VisitRealization", Key .Action = "LoadDoctorList"}
                doctorlist.Properties.SelectionMode = GridLookupSelectionMode.Single
                doctorlist.Properties.TextFormatString = "{0}"
                doctorlist.GridViewProperties.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords
                doctorlist.GridViewProperties.Settings.VerticalScrollBarMode = ScrollBarMode.Auto
                doctorlist.Width = Unit.Pixel(250)
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


                doctorlist.GridViewStyles.Cell.Font.Size = 7
                doctorlist.GridViewStyles.Header.Font.Size = 7
                'doctorlist.CommandColumn.ShowSelectCheckbox = True
                doctorlist.CommandColumn.Visible = True
                'doctorlist.CommandColumn.SelectAllCheckboxMode = GridViewSelectAllCheckBoxMode.AllPages

        End Sub).BindList(Model).GetHtml()