﻿@Html.DevExpress().GridView(Sub(settings)
                                settings.Name = "DataView1"
                                settings.CallbackRouteValues = New With {.Controller = "visithistory", .Action = "DataViewPartial"}
                                settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
                                settings.SettingsSearchPanel.Visible = True
                                settings.SettingsPager.PageSize = 50
                                settings.ControlStyle.Paddings.Padding = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.ControlStyle.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.ControlStyle.BorderBottom.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                settings.Width = Unit.Percentage(100)
                                settings.EnableRowsCache = True
                                settings.Settings.ShowFilterRow = True
                                    
                                settings.Styles.Cell.Paddings.PaddingLeft = Unit.Pixel(1)
                                settings.Styles.Cell.Paddings.PaddingRight = Unit.Pixel(1)
                                settings.Styles.Cell.Font.Size = 7
                                settings.Styles.Header.Font.Size = 7
                                settings.Styles.GroupRow.Font.Size = 7
                                settings.Styles.Footer.Font.Size = 7
                                settings.Styles.Header.HorizontalAlign = HorizontalAlign.Center

                                settings.Settings.ShowFilterRowMenu = True
                                settings.SettingsDetail.ShowDetailRow = True
                                settings.KeyFieldName = "visit_id"
                                     
                                settings.SettingsPager.PageSize = 15
                                settings.SettingsPager.FirstPageButton.Visible = True
                                settings.SettingsPager.LastPageButton.Visible = True
                                settings.SettingsPager.PageSizeItemSettings.Visible = True
                                settings.SettingsPager.PageSizeItemSettings.Items = New String() {"5", "10", "15", "20", "50"}


                                settings.AutoFilterCellEditorCreate = Sub(sender, e)
                                                                          If e.Column.FieldName = "visit_date_plan" Then
                                                                              Dim dp = New DateEditProperties()
                                                                              e.EditorProperties = dp
                                                                          End If

                                                                      End Sub

                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "visit_date_plan"
                                                         column.ColumnType = MVCxGridViewColumnType.DateEdit
                                                         column.Settings.AutoFilterCondition = AutoFilterCondition.Equals
                                                         column.Width = Unit.Pixel(50)

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
                                     
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "visit_real_verification_status"
                                                         column.ColumnType = MVCxGridViewColumnType.CheckBox
                                                         column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean

                                                         Dim checkBoxProperties = TryCast(column.PropertiesEdit, CheckBoxProperties)

                                                         checkBoxProperties.ValueType = GetType(Integer)
                                                         checkBoxProperties.ValueChecked = 1
                                                         checkBoxProperties.ValueUnchecked = 0

                                                     End Sub)
                                     
                                settings.Columns.Add("visit_sp").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                settings.Columns.Add("visit_sp_value").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                                     
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
                                settings.Columns.Add("visit_info").Settings.AutoFilterCondition = AutoFilterCondition.Contains

                               
                                settings.Columns(0).Visible = False
                                settings.Columns(1).Caption = "DR CODE"
                                settings.Columns(2).Caption = "PLAN"
                                settings.Columns(3).Caption = "REAL"
                                settings.Columns(4).Caption = "SP"
                                settings.Columns(5).Caption = "SP VALUE"
                                settings.Columns(6).Caption = "VER STATUS"
                                settings.Columns(7).Caption = "DR NAME"
                                settings.Columns(8).Caption = "DR SPEC"
                                settings.Columns(9).Caption = "SUB SPEC"
                                settings.Columns(10).Caption = "QRD"
                                settings.Columns(11).Caption = "MTG"
                                settings.Columns(12).Caption = "DK/LK"
                                settings.Columns(13).Caption = "AREA MIS"
                                settings.Columns(14).Caption = "CTG"
                                settings.Columns(15).Caption = "CNL"
                                settings.Columns(16).Caption = "INFO"
     
                                settings.Columns(7).Width = 120
                                settings.Columns(11).Width = 150
                                settings.Columns(16).Width = 80
                                     
                                settings.Columns.Add(Sub(c)
                                                         c.FieldName = "visit_date_plan"
                                                         c.Caption = "DATE PLAN"
                                                         c.GroupIndex = 0
                                                     End Sub)
                                     
                                For i As Integer = 0 To 15
                                    If i = 7 Or i = 11 Then
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Left
                                        settings.Columns(i).CellStyle.VerticalAlign = VerticalAlign.Middle
                                        settings.Columns(i).CellStyle.Paddings.PaddingLeft = 10
                                    Else
                                        settings.Columns(i).CellStyle.HorizontalAlign = HorizontalAlign.Center
                                        settings.Columns(i).CellStyle.VerticalAlign = VerticalAlign.Middle
                                    End If
                                    
                                Next
                                
                                             
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
                                     
                                settings.Columns(18).Visible = False
                                settings.Columns(19).Visible = False
                                settings.Columns(20).Visible = False

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
                                     
                                settings.SetDetailRowTemplateContent(Sub(c)
                                                                         Html.RenderAction("MasterDetailPartial", New With {Key .visit_id = DataBinder.Eval(c.DataItem, "visit_id"), Key .dr_code = DataBinder.Eval(c.DataItem, "dr_code")})
                                                                      
                                                                     End Sub)

                            End Sub).Bind(Model).GetHtml()