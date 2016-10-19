@code
    Html.EnableClientValidation()
    Html.EnableUnobtrusiveJavaScript()
End Code
@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "DataView1"
                                settings.CallbackRouteValues = New With {.Controller = "visitplan", .Action = "DataView1Partial"}
                                'settings.CustomActionRouteValues = New With {.Controller = "Editing", .Action = "ChangeEditModePartial"}
                                settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "visitplan", .Action = "EditingDelete", .visit_id = ViewData("visit_id")}
                                settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "visitplan", .Action = "EditingUpdate", .visit_id = ViewData("visit_id")}
                                     
                           
                                     
                                     
                                settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                                settings.SettingsPager.PageSize = 50
                                settings.ControlStyle.Paddings.Padding = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.ControlStyle.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.ControlStyle.BorderBottom.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.Width = Unit.Percentage(100)
                                settings.EnableRowsCache = True
                                settings.Settings.ShowFilterRow = True
                                settings.Settings.ShowFilterRowMenu = True
                                settings.Styles.Cell.Paddings.PaddingLeft = Unit.Pixel(1)
                                settings.Styles.Cell.Paddings.PaddingRight = Unit.Pixel(1)
                                settings.Styles.Cell.Font.Size = 7
                                settings.Styles.Header.Font.Size = 7
                                settings.Styles.GroupRow.Font.Size = 7
                                settings.Styles.Footer.Font.Size = 7
                                settings.Styles.Header.HorizontalAlign = HorizontalAlign.Center
                               
                                settings.CommandColumn.Visible = True
                                settings.CommandColumn.Width = 40
                                settings.CommandColumn.ShowEditButton = True
                                settings.CommandColumn.ShowDeleteButton = True
                                settings.CommandColumn.ShowCancelButton = True
                                settings.CommandColumn.ShowUpdateButton = True
                                settings.CommandColumn.ButtonType = GridViewCommandButtonType.Image
                                settings.SettingsCommandButton.EditButton.Image.Url = "~/Content/Images/Edit.png"
                                settings.SettingsCommandButton.DeleteButton.Image.Url = "~/Content/Images/delete.png"
                                
                                settings.SettingsCommandButton.CancelButton.Image.Url = "~/Content/Images/cancel2.png"
                                settings.SettingsCommandButton.UpdateButton.Image.Url = "~/Content/Images/update.png"
                                     
                                     
                                settings.SettingsBehavior.ConfirmDelete = True
                                settings.SettingsEditing.Mode = GridViewEditingMode.Inline
                                settings.KeyFieldName = "visit_id"

                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "visit_id"
                                                         column.ColumnType = MVCxGridViewColumnType.TextBox
                                                         column.Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                                         column.Width = Unit.Percentage(100)
                                                       
                                                        
                                                     End Sub)
                                     
                                'settings.Columns.Add("visit_id").Settings.AutoFilterCondition = AutoFilterCondition.Contains

                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "visit_date_plan"
                                                         column.ColumnType = MVCxGridViewColumnType.DateEdit
                                                         column.Settings.AutoFilterCondition = AutoFilterCondition.Equals
                                                         column.Width = Unit.Percentage(100)
                                                        
                                                        
                                                     End Sub)


                                settings.Columns.Add("dr_code").Settings.AutoFilterCondition = AutoFilterCondition.Contains

                                settings.Columns.Add(Sub(columnCheck)
                                                         columnCheck.FieldName = "visit_plan_verification_status"
                                                         columnCheck.ColumnType = MVCxGridViewColumnType.CheckBox
                                                         columnCheck.UnboundType = DevExpress.Data.UnboundColumnType.Boolean

                                                         Dim checkBoxProperties = TryCast(columnCheck.PropertiesEdit, CheckBoxProperties)

                                                         checkBoxProperties.ValueType = GetType(Integer)
                                                         checkBoxProperties.ValueChecked = 1
                                                         checkBoxProperties.ValueUnchecked = 0

                                                     End Sub)

                                settings.Columns.Add("dr_name").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                settings.Columns.Add("dr_spec").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                settings.Columns.Add("dr_sub_spec").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                settings.Columns.Add("dr_quadrant").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                settings.Columns.Add("dr_monitoring").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                settings.Columns.Add("dr_dk_lk").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                settings.Columns.Add("dr_area_mis").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                settings.Columns.Add("dr_category").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                settings.Columns.Add("dr_chanel").Settings.AutoFilterCondition = AutoFilterCondition.Contains

                                settings.Columns(0).Caption = "PLAN ID"
                                settings.Columns(1).Caption = "DATE PLAN"
                                settings.Columns(2).Caption = "DR CODE"
                                settings.Columns(3).Caption = "VPLAN"
                                settings.Columns(4).Caption = "DR NAME"
                                settings.Columns(5).Caption = "DR SPEC"
                                settings.Columns(6).Caption = "SUB SPEC"
                                settings.Columns(7).Caption = "QRD"
                                settings.Columns(8).Caption = "MONITORING"
                                settings.Columns(9).Caption = "DK/LK"
                                settings.Columns(10).Caption = "AREA MIS"
                                settings.Columns(11).Caption = "CATEGORY"
                                settings.Columns(12).Caption = "CHANNEL"
                                
                                For i As Integer = 0 To 12
                                    settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                    settings.Columns(i).CellStyle.VerticalAlign = VerticalAlign.Middle
                                    settings.Columns(i).CellStyle.Font.Size = 7
                                    If i = 4 Then
                                        settings.Columns(i).Width = 100
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Left
                                        settings.Columns(i).CellStyle.Paddings.PaddingLeft = 5
                                    ElseIf i = 8 Then
                                        settings.Columns(i).Width = 150
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Left
                                        settings.Columns(i).CellStyle.Paddings.PaddingLeft = 5
                                    Else
                                        settings.Columns(i).Width = 40
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                    End If
                                    
                                    
                                   
                                         
                                Next
                                     

                                settings.Columns.Add(Sub(c)
                                                         c.FieldName = "visit_date_plan"
                                                         c.Caption = "DATE PLAN"
                                                         c.GroupIndex = 0
                                                     End Sub)
                               
                                     
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "q1"
                                                         column.UnboundType = DevExpress.Data.UnboundColumnType.Integer
                                                     End Sub)
                                     
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "q2"
                                                         column.UnboundType = DevExpress.Data.UnboundColumnType.Integer
                                                     End Sub)
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "q3"
                                                         column.UnboundType = DevExpress.Data.UnboundColumnType.Integer
                                                     End Sub)
                                     
                                settings.Columns(14).Visible = False
                                settings.Columns(15).Visible = False
                                settings.Columns(16).Visible = False
                                     
                                settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Count, "dr_code")
                                settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q1")
                                settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q2")
                                settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q3")
                                     
                                settings.Settings.ShowFooter = True

                                settings.ClientSideEvents.Init = "function(s, e) { s.PerformCallback(); }"
                                settings.ClientSideEvents.BeginCallback = "function(s, e) { OnStartCallback(s, e); }"
                                settings.ClientSideEvents.EndCallback = "function(s, e) { OnEndCallback(s, e); }"

                                settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, String.Empty)
                                
                                     
                                settings.CustomUnboundColumnData = Sub(sender, e)
                                                                       If e.Column.FieldName = "q1" Then
                                                                           
                                                                           Dim qrd As String = DirectCast(e.GetListSourceFieldValue("dr_quadrant"), [String])
                                                                           If Trim(qrd) = "Q1" Then
                                                                               e.Value = 1
                                                                               
                                                                           Else
                                                                               e.Value = 0
                                                                           End If
                                                                       End If
                                                                       
                                                                       If e.Column.FieldName = "q2" Then
                                                                           
                                                                           Dim qrd As String = DirectCast(e.GetListSourceFieldValue("dr_quadrant"), [String])
                                                                           If Trim(qrd) = "Q2" Then
                                                                               e.Value = 1
                                                                           Else
                                                                               e.Value = 0
                                                                           End If
                                                                       End If
                                                                       
                                                                       If e.Column.FieldName = "q3" Then
                                                                           
                                                                           Dim qrd As String = DirectCast(e.GetListSourceFieldValue("dr_quadrant"), [String])
                                                                           If Trim(qrd) = "Q3" Then
                                                                               e.Value = 1
                                                                           Else
                                                                               e.Value = 0
                                                                           End If
                                                                       End If
                                       
                                                                   End Sub

                                
                                     
                                settings.PreRender = Sub(s, e)
                                                         Dim grid As MVCxGridView = DirectCast(s, MVCxGridView)
                                                         grid.ExpandAll()
                                                     End Sub

                                settings.BeforeGetCallbackResult = Sub(s, e)
                                                                       Dim grid As MVCxGridView = DirectCast(s, MVCxGridView)
                                                                       grid.ExpandAll()
                                                                   End Sub
                                     
                                settings.SetFooterRowTemplateContent(Sub(c)
                                                                         Try
                                                                         
                                                                             Dim q1 As String = c.Grid.GetTotalSummaryValue(c.Grid.TotalSummary("q1")).ToString
                                                                             Dim q2 As String = c.Grid.GetTotalSummaryValue(c.Grid.TotalSummary("q2")).ToString
                                                                             Dim q3 As String = c.Grid.GetTotalSummaryValue(c.Grid.TotalSummary("q3")).ToString
                                                                             Dim tot As String = c.Grid.GetTotalSummaryValue(c.Grid.TotalSummary("dr_code")).ToString
                                                                         
                                                                             Dim footer As String = "Total Doctor(s) : " & tot & "                                     Total Q1=" & q1 & "               Total Q2=" & q2 & "               Total Q3=" & q3
                                                                             ViewContext.Writer.Write(footer)
                                                                         Catch ex As Exception
                                                                             Exit Sub
                                                                         End Try
                                                                        
                                                                     End Sub)
                                     
                               
                            End Sub).Bind(Model).GetHtml()