@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "DataView1"
                                settings.CallbackRouteValues = New With {.Controller = "visitrealization", .Action = "DataViewPartial"}
                                settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                                settings.SettingsPager.PageSize = 50
                                settings.ControlStyle.Paddings.Padding = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.ControlStyle.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.ControlStyle.BorderBottom.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.Width = Unit.Percentage(100)
                                settings.EnableRowsCache = True
                                settings.Settings.ShowFilterRow = True
                                settings.Styles.Cell.Font.Size = 8
                                settings.Styles.Header.Font.Size = 8
                                settings.Styles.GroupRow.Font.Size = 8
                                settings.Styles.Footer.Font.Size = 8
                                settings.Styles.Header.HorizontalAlign = HorizontalAlign.Center
                                settings.Settings.ShowFilterRowMenu = True
                              

                                settings.KeyFieldName = "visit_id"
                                settings.Columns.Add(Sub(column)
                                                         column.Caption = "REALIZATION"
                                                         column.EditFormCaptionStyle.HorizontalAlign = HorizontalAlign.Center
                                                         column.SetDataItemTemplateContent(Sub(c)
                                                                                               Dim id = DataBinder.Eval(c.DataItem, "visit_id")
                                                                                               Html.DevExpress().Button(Sub(btnreal)
                                                                                                                            btnreal.Name = "btnreal_" + c.KeyValue.ToString()
                                                                                                                            btnreal.UseSubmitBehavior = True
                                                                                                                            btnreal.Text = "Realization"
                                                                                                                            btnreal.Attributes("v_visit_id") = c.KeyValue.ToString()
                                                                                                                            'btnreal.ClientSideEvents.Click = "RealPartial"
                                                                                                                            btnreal.ClientSideEvents.Click = "function(s, e){ popupControlRealization.Show(); }"
                                                                                                                            TANABE_MVC.GlobalClass.temp_realization_visit_id = c.KeyValue.ToString()
                                                                                                                            btnreal.ToolTip = "Realization " & c.KeyValue.ToString()
                                                                                                                        End Sub).Render()

                                                                                           End Sub)
                                                     End Sub)
                                          
                                     
                                     
                                     
                                settings.Columns.Add("visit_id").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                              

                                settings.AutoFilterCellEditorCreate = Sub(sender, e)
                                                                          If e.Column.FieldName = "visit_date_plan" Then
                                                                              Dim dp = New DateEditProperties()
                                                                              e.EditorProperties = dp
                                                                          End If

                                                                      End Sub

                                'settings.Columns.Add(Sub(column)
                                '                         column.FieldName = "visit_date_plan"
                                '                         column.ColumnType = MVCxGridViewColumnType.DateEdit
                                '                         column.Settings.AutoFilterCondition = AutoFilterCondition.Equals
                                '                         column.Width = Unit.Pixel(100)

                                '                     End Sub)

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
                                     
                                settings.Columns.Add(Sub(columnCheck)
                                                         columnCheck.FieldName = "visit_real_verification_status"
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

                                settings.Columns(1).Caption = "PLAN ID"
                                settings.Columns(2).Caption = "DR CODE"
                                settings.Columns(3).Caption = "VER PLAN"
                                settings.Columns(4).Caption = "VER REAL"
                                settings.Columns(5).Caption = "DR NAME"
                                settings.Columns(6).Caption = "DR SPEC"
                                settings.Columns(7).Caption = "SUB SPEC"
                                settings.Columns(8).Caption = "QUADRANT"
                                settings.Columns(9).Caption = "MONITORING"
                                settings.Columns(10).Caption = "DK/LK"
                                settings.Columns(11).Caption = "AREA MIS"
                                settings.Columns(12).Caption = "CATEGORY"
                                settings.Columns(13).Caption = "CHANNEL"

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
                                     
                                settings.Columns(15).Visible = False
                                settings.Columns(16).Visible = False
                                settings.Columns(17).Visible = False
                                     
                                settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Count, "dr_code")
                                settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q1")
                                settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q2")
                                settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q3")
                                     

                                settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Count, "dr_code")
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