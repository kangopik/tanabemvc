@Imports System.Data

@code
    Dim msg As String
    msg = TempData("msg")
End Code

@Html.DevExpress().GridView(
    Sub(settings)
            settings.Name = "DataView1"
            settings.CallbackRouteValues = New With {.Controller = "visitrealization", .Action = "DataViewPartial"}
            settings.CustomActionRouteValues = New With {.Controller = "visitrealization", .Action = "DataViewPartialCustomCallback"}
            settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
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
                                
            settings.SettingsPager.PageSize = 15
            settings.SettingsPager.FirstPageButton.Visible = True
            settings.SettingsPager.LastPageButton.Visible = True
            settings.SettingsPager.PageSizeItemSettings.Visible = True
            settings.SettingsPager.PageSizeItemSettings.Items = New String() {"5", "10", "15", "20", "50"}
                              

            settings.KeyFieldName = "visit_id"
            settings.CommandColumn.Visible = True
            settings.CommandColumn.ButtonRenderMode = GridCommandButtonRenderMode.Button
            settings.CommandColumn.ShowEditButton = False
            settings.CommandColumn.ShowDeleteButton = False
            settings.CommandColumn.ShowCancelButton = False
            settings.CommandColumn.ShowUpdateButton = False
            settings.CommandColumn.Width = 100
            settings.CommandColumn.CustomButtons.Add(New GridViewCommandColumnCustomButton() With {.ID = "btnRealization", .Text = "Realization"})
            'settings.ClientSideEvents.CustomButtonClick = String.Format("function(s, e) {{ CustomButtonClick(s, e, '{0}'); }}", Url.Action("About", "Home"))
            settings.ClientSideEvents.CustomButtonClick = "gv_CustomButtonClick"
            

            
            settings.CustomButtonInitialize = Sub(sender, e)
                                                      Dim grid As MVCxGridView = DirectCast(sender, MVCxGridView)
                                                      If e.VisibleIndex = -1 Then
                                                          Return
                                                      End If
                                                      Dim fieldValue_dr As Object = grid.GetRowValues(e.VisibleIndex, "dr_code")
                                                     
                                                      If e.ButtonID = "btnRealization" Then 'AndAlso e.VisibleIndex Mod 2 <> 0 Then
                                                          'If (TANABE_MVC.ConfigClass.RealizationButtonVisibleCriteria(grid, e.VisibleIndex)) Then
                                                              
                                                          'End If
                                                          Dim isvisible As Boolean = TANABE_MVC.ConfigClass.RealizationButtonVisibleCriteria(grid, e.VisibleIndex)
                                                          If isvisible = True Then
                                                              e.Visible = DefaultBoolean.True
                                                          Else
                                                              e.Visible = DefaultBoolean.False
                                                          End If
                                                          
                                                          
                                                          If CInt(fieldValue_dr) < 100005 Then
                                                              e.Visible = DefaultBoolean.False
                                                          End If
                                                      End If
                                                                                
                                              End Sub
            
            settings.Columns.Add(Sub(column)
                                         column.Caption = ""
                                         column.Width = 0
                                         column.Visible = False
                                 End Sub)
                                          
            settings.Columns.Add("visit_id").Settings.AutoFilterCondition = AutoFilterCondition.Contains
                              

            settings.AutoFilterCellEditorCreate = Sub(sender, e)
                                                          If e.Column.FieldName = "visit_date_plan" Then
                                                              Dim dp = New DateEditProperties()
                                                              e.EditorProperties = dp
                                                          End If

                                                  End Sub
            

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
            settings.Columns(8).Caption = "QRD"
            settings.Columns(9).Caption = "MONITORING"
            settings.Columns(10).Caption = "DK/LK"
            settings.Columns(11).Caption = "AREA MIS"
            settings.Columns(12).Caption = "CATEGORY"
            settings.Columns(13).Caption = "CHANNEL"
                                
            For j As Integer = 0 To 12
                settings.Columns(j).CellStyle.HorizontalAlign = HorizontalAlign.Center
                settings.Columns(j).CellStyle.VerticalAlign = VerticalAlign.Middle
                settings.Columns(j).CellStyle.Font.Size = 7
                If j = 5 Then
                    settings.Columns(j).Width = 100
                    settings.Columns(j).CellStyle.HorizontalAlign = HorizontalAlign.Left
                    settings.Columns(j).CellStyle.Paddings.PaddingLeft = 5
                ElseIf j = 9 Then
                    settings.Columns(j).Width = 150
                    settings.Columns(j).CellStyle.HorizontalAlign = HorizontalAlign.Left
                    settings.Columns(j).CellStyle.Paddings.PaddingLeft = 5
                Else
                    settings.Columns(j).Width = 40
                    settings.Columns(j).CellStyle.HorizontalAlign = HorizontalAlign.Center
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
                                     
            settings.Columns(15).Visible = False
            settings.Columns(16).Visible = False
            settings.Columns(17).Visible = False
                                     
            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Count, "dr_code")
            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q1")
            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q2")
            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q3")
                                     

            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Count, "dr_code")
            settings.Settings.ShowFooter = True

            'settings.ClientSideEvents.Init = "function(s, e) { s.PerformCallback(); }"
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

@code

    If msg <> "" Then
        TempData("msg") = ""
        Html.DevExpress().PopupControl(Sub(settings)
                                               settings.Name = "PopupControl"
                                               settings.ShowHeader = True
                                               settings.ShowOnPageLoad = True
                                               settings.AllowDragging = True
                                               settings.CloseAction = CloseAction.OuterMouseClick
                                               settings.CloseOnEscape = True
                                               settings.Modal = True
                                               settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                               settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                               settings.SetHeaderTemplateContent(Sub()
                                                                                         ViewContext.Writer.Write("<div style='font-size:small;'>Information</div>")
                                                                                 End Sub)

                                               settings.SetContent(Sub()
                                                                           ViewContext.Writer.Write(msg)
                                                                   End Sub)


                                       End Sub).GetHtml()


    End If
End Code