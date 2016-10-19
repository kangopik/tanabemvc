@code
    Html.EnableClientValidation()
    Html.EnableUnobtrusiveJavaScript()

    Dim vp As New TANABE_MVC.Repositories.r_plan
    Dim model_pm = Nothing
    model_pm = vp.GetDataDoctor(ViewData("rep_id"), ViewData("rep_position"))

    Dim msg As String
    msg = TempData("msg")


End Code
@Html.DevExpress().GridView(
    Sub(settings)
            settings.Name = "DataView1"
            settings.CallbackRouteValues = New With {.Controller = "VisitPlan", .Action = "DataViewPartial"}
            settings.CustomActionRouteValues = New With {.Controller = "VisitPlan", .Action = "DataViewPartialCustomCallback"}
            settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "visitplan", .Action = "DeletePlan", .visit_id = ViewData("visit_id")}
            settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "visitplan", .Action = "UpdatePlan", .visit_id = ViewData("visit_id")}
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
            
            'settings.CommandColumn.ButtonType = GridViewCommandButtonType.Image
            settings.SettingsCommandButton.EditButton.RenderMode = GridCommandButtonRenderMode.Image
            settings.SettingsCommandButton.EditButton.Image.Url = "~/Content/Images/edit-icon2.png"
            settings.SettingsCommandButton.DeleteButton.RenderMode = GridCommandButtonRenderMode.Image
            settings.SettingsCommandButton.DeleteButton.Image.Url = "~/Content/Images/delete-icon2.png"
            settings.SettingsCommandButton.CancelButton.RenderMode = GridCommandButtonRenderMode.Image
            settings.SettingsCommandButton.CancelButton.Image.Url = "~/Content/Images/cancel-icon2.png"
            settings.SettingsCommandButton.UpdateButton.RenderMode = GridCommandButtonRenderMode.Image
            settings.SettingsCommandButton.UpdateButton.Image.Url = "~/Content/Images/update-icon2.png"

            settings.SettingsPager.FirstPageButton.Visible = True
            settings.SettingsPager.LastPageButton.Visible = True
            settings.SettingsPager.PageSizeItemSettings.Visible = True
            settings.SettingsPager.PageSizeItemSettings.Items = New String() {"5", "10", "15", "20", "50"}

            settings.SettingsBehavior.ConfirmDelete = True
            settings.SettingsEditing.Mode = GridViewEditingMode.Inline
            settings.KeyFieldName = "visit_id"
            settings.Columns.Add("visit_id", "PLAN ID", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(
                Sub(column)
                        Html.DevExpress().TextBox(
                            Sub(aso)
                                    aso.Name = "visit_id"
                                    Dim param As String = String.Empty

                                    Try
                                        param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                    Catch ex As Exception
                                        param = "err"
                                    End Try

                                    If param <> "err" Then
                                        aso.Text = param
                                        If column.Grid.IsEditing = True Then
                                            aso.Enabled = False
                                        Else
                                            aso.Enabled = True
                                        End If
                                    Else
                                        aso.Text = ""
                                    End If

                                    aso.Width = Unit.Percentage(100)
                            End Sub).GetHtml()
                End Sub)

            settings.Columns.Add("visit_date_plan", "DATE PLAN", MVCxGridViewColumnType.DateEdit).SetEditItemTemplateContent(
                Sub(column)
                        Html.DevExpress().DateEdit(
                            Sub(aso)
                                    aso.Name = "visit_date_plan"
                                    Dim param As String = String.Empty
                                    Try
                                        param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                    Catch ex As Exception
                                        param = "err"
                                    End Try

                                    If param <> "err" Then
                                        aso.Date = param
                                    Else
                                        aso.Date = Now.Date
                                    End If

                                    aso.Width = Unit.Percentage(100)
                            End Sub).GetHtml()
                End Sub)

            settings.Columns.Add(
                Sub(column)
                        column.Name = "dr_code"
                        column.Caption = "DR CODE"
                        column.FieldName = "dr_code"
                        column.ColumnType = MVCxGridViewColumnType.TextBox
                        column.Settings.AutoFilterCondition = AutoFilterCondition.Contains
                        column.SetEditItemTemplateContent(
                            Sub(c)
                                    Html.DevExpress().ComboBox(
                                    Sub(pm)
                                            pm.Name = "dr_code"
                                            Dim param As String = String.Empty
                                            Try
                                                TANABE_MVC.GlobalClass.temp_dr_code_ald_visit_plan = ""
                                                param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                            Catch ex As Exception
                                                param = "err"
                                            End Try

                                            If param <> "err" Then
                                                If c.Grid.IsEditing = True Then
                                                    pm.Properties.NullText = param
                                                    pm.Properties.ValueField = param
                                                    TANABE_MVC.GlobalClass.temp_dr_code_ald_visit_plan = param
                                                End If

                                            End If

                                            pm.Width = Unit.Percentage(100)
                                            pm.Properties.DropDownWidth = 600
                                            pm.Properties.DropDownStyle = DropDownStyle.DropDownList
                                            pm.Properties.CallbackPageSize = 30
                                            pm.Properties.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
                                            pm.Properties.TextFormatString = "{0}"
                                            pm.Properties.ValueField = "dr_code"
                                            pm.Properties.Columns.Add("dr_code", "CODE", Unit.Percentage(10))
                                            pm.Properties.Columns.Add("dr_name", "NAME", Unit.Percentage(25))
                                            pm.Properties.Columns.Add("dr_spec", "SPEC", Unit.Percentage(8))
                                            pm.Properties.Columns.Add("dr_sub_spec", "SUB SPEC", Unit.Percentage(15))
                                            pm.Properties.Columns.Add("dr_quadrant", "QRD", Unit.Percentage(5))
                                            pm.Properties.Columns.Add("dr_monitoring", "MONITORING", Unit.Percentage(25))
                                            pm.Properties.Columns.Add("is_used", "STATUS", Unit.Percentage(12))
                                            pm.Properties.Columns.Add("dr_used_month_session", "PP", Unit.Percentage(5))

                                    End Sub).BindList(model_pm).GetHtml()
                            End Sub)
                End Sub)

            settings.Columns.Add(
                Sub(column)
                        column.Name = "visit_plan_verification_status"
                        column.Caption = "VPLAN"
                        column.FieldName = "visit_plan_verification_status"
                        column.ColumnType = MVCxGridViewColumnType.CheckBox

                        With DirectCast(column.PropertiesEdit, CheckBoxProperties)
                            .ValueType = GetType(Integer)
                            .ValueChecked = 1
                            .ValueUnchecked = 0
                        End With

                        column.SetEditItemTemplateContent(
                            Sub(c)
                                    Html.DevExpress().CheckBox(
                                        Sub(typ)
                                                typ.Name = "visit_plan_verification_status"
                                                Dim param As String = String.Empty
                                                Try
                                                    param = DataBinder.Eval(c.DataItem, c.Column.FieldName).ToString()
                                                Catch ex As Exception
                                                    param = "err"
                                                End Try

                                                If param <> "err" Then

                                                    If c.Grid.IsEditing = True Then
                                                        typ.Enabled = False
                                                    Else
                                                        typ.Enabled = True
                                                    End If

                                                    If param = 1 Then
                                                        typ.Checked = True
                                                    Else
                                                        typ.Checked = False
                                                    End If
                                                End If

                                                typ.Width = Unit.Percentage(100)
                                                typ.Properties.ValueType = GetType(Integer)
                                                typ.Properties.ValueChecked = 1
                                                typ.Properties.ValueUnchecked = 0

                                        End Sub).GetHtml()


                            End Sub)

                End Sub)


            settings.Columns.Add("dr_name", "DR NAME", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(
                Sub(column)

                        Html.DevExpress().TextBox(
                            Sub(aso)
                                    aso.Name = "dr_name"
                                    Dim param As String = String.Empty
                                    Try
                                        param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                    Catch ex As Exception
                                        param = "err"
                                    End Try

                                    If param <> "err" Then
                                        aso.Text = param
                                        If column.Grid.IsEditing = True Then
                                            aso.Enabled = False
                                        Else
                                            aso.Enabled = True
                                        End If
                                    Else
                                        aso.Text = ""
                                    End If

                                    aso.Width = Unit.Percentage(100)
                            End Sub).GetHtml()
                End Sub)



            settings.Columns.Add("dr_spec", "DR SPEC", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(
                Sub(column)
                        Html.DevExpress().TextBox(
                            Sub(aso)
                                    aso.Name = "dr_spec"
                                    Dim param As String = String.Empty
                                    Try
                                        param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                    Catch ex As Exception
                                        param = "err"
                                    End Try

                                    If param <> "err" Then
                                        aso.Text = param
                                        If column.Grid.IsEditing = True Then
                                            aso.Enabled = False
                                        Else
                                            aso.Enabled = True
                                        End If
                                    Else
                                        aso.Text = ""
                                    End If

                                    aso.Width = Unit.Percentage(100)
                            End Sub).GetHtml()
                End Sub)


            settings.Columns.Add("dr_sub_spec", "SUB SPEC", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(
                Sub(column)
                        Html.DevExpress().TextBox(
                            Sub(aso)
                                    aso.Name = "dr_sub_spec"
                                    Dim param As String = String.Empty
                                    Try
                                        param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                    Catch ex As Exception
                                        param = "err"
                                    End Try

                                    If param <> "err" Then
                                        aso.Text = param
                                        If column.Grid.IsEditing = True Then
                                            aso.Enabled = False
                                        Else
                                            aso.Enabled = True
                                        End If
                                    Else
                                        aso.Text = ""
                                    End If

                                    aso.Width = Unit.Percentage(100)
                            End Sub).GetHtml()
                End Sub)

            settings.Columns.Add("dr_quadrant", "QRD", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(
                Sub(column)
                        Html.DevExpress().TextBox(
                            Sub(aso)
                                    aso.Name = "dr_quadrant"
                                    Dim param As String = String.Empty
                                    Try
                                        param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                    Catch ex As Exception
                                        param = "err"
                                    End Try

                                    If param <> "err" Then
                                        aso.Text = param
                                        If column.Grid.IsEditing = True Then
                                            aso.Enabled = False
                                        Else
                                            aso.Enabled = True
                                        End If
                                    Else
                                        aso.Text = ""
                                    End If

                                    aso.Width = Unit.Percentage(100)
                            End Sub).GetHtml()
                End Sub)


            settings.Columns.Add("dr_monitoring", "MONITORING", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(
                Sub(column)
                        Html.DevExpress().TextBox(
                            Sub(aso)
                                    aso.Name = "dr_monitoring"
                                    Dim param As String = String.Empty
                                    Try
                                        param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                    Catch ex As Exception
                                        param = "err"
                                    End Try

                                    If param <> "err" Then
                                        aso.Text = param
                                        If column.Grid.IsEditing = True Then
                                            aso.Enabled = False
                                        Else
                                            aso.Enabled = True
                                        End If
                                    Else
                                        aso.Text = ""
                                    End If

                                    aso.Width = Unit.Percentage(100)
                            End Sub).GetHtml()


                End Sub)

            settings.Columns.Add("dr_dk_lk", "DK/LK", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(
                Sub(column)

                        Html.DevExpress().TextBox(
                            Sub(aso)
                                    aso.Name = "dr_dk_lk"
                                    Dim param As String = String.Empty
                                    Try
                                        param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                    Catch ex As Exception
                                        param = "err"
                                    End Try

                                    If param <> "err" Then
                                        aso.Text = param
                                        If column.Grid.IsEditing = True Then
                                            aso.Enabled = False
                                        Else
                                            aso.Enabled = True
                                        End If
                                    Else
                                        aso.Text = ""
                                    End If

                                    aso.Width = Unit.Percentage(100)
                            End Sub).GetHtml()


                End Sub)

            settings.Columns.Add("dr_area_mis", "AREA MIS", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(
                Sub(column)

                        Html.DevExpress().TextBox(
                            Sub(aso)
                                    aso.Name = "dr_area_mis"
                                    Dim param As String = String.Empty
                                    Try
                                        param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                    Catch ex As Exception
                                        param = "err"
                                    End Try

                                    If param <> "err" Then
                                        aso.Text = param
                                        If column.Grid.IsEditing = True Then
                                            aso.Enabled = False
                                        Else
                                            aso.Enabled = True
                                        End If
                                    Else
                                        aso.Text = ""
                                    End If

                                    aso.Width = Unit.Percentage(100)
                            End Sub).GetHtml()


                End Sub)

            settings.Columns.Add("dr_category", "CATEGORY", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(
                Sub(column)

                        Html.DevExpress().TextBox(
                            Sub(aso)
                                    aso.Name = "dr_category"
                                    Dim param As String = String.Empty
                                    Try
                                        param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                    Catch ex As Exception
                                        param = "err"
                                    End Try

                                    If param <> "err" Then
                                        aso.Text = param
                                        If column.Grid.IsEditing = True Then
                                            aso.Enabled = False
                                        Else
                                            aso.Enabled = True
                                        End If
                                    Else
                                        aso.Text = ""
                                    End If

                                    aso.Width = Unit.Percentage(100)
                            End Sub).GetHtml()


                End Sub)

            settings.Columns.Add("dr_chanel", "CHANNEL", MVCxGridViewColumnType.TextBox).SetEditItemTemplateContent(
                Sub(column)

                        Html.DevExpress().TextBox(
                            Sub(aso)
                                    aso.Name = "dr_chanel"
                                    Dim param As String = String.Empty
                                    Try
                                        param = DataBinder.Eval(column.DataItem, column.Column.FieldName).ToString()
                                    Catch ex As Exception
                                        param = "err"
                                    End Try

                                    If param <> "err" Then
                                        aso.Text = param
                                        If column.Grid.IsEditing = True Then
                                            aso.Enabled = False
                                        Else
                                            aso.Enabled = True
                                        End If
                                    Else
                                        aso.Text = ""
                                    End If

                                    aso.Width = Unit.Percentage(100)
                            End Sub).GetHtml()


                End Sub)



            For j As Integer = 0 To 12
                settings.Columns(j).CellStyle.HorizontalAlign = HorizontalAlign.Center
                settings.Columns(j).CellStyle.VerticalAlign = VerticalAlign.Middle
                settings.Columns(j).CellStyle.Font.Size = 7
                If j = 4 Then
                    settings.Columns(j).Width = 100
                    settings.Columns(j).CellStyle.HorizontalAlign = HorizontalAlign.Left
                    settings.Columns(j).CellStyle.Paddings.PaddingLeft = 5
                ElseIf j = 8 Then
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

            settings.Columns(14).Visible = False
            settings.Columns(15).Visible = False
            settings.Columns(16).Visible = False

            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Count, "dr_code")
            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q1")
            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q2")
            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "q3")

            settings.Settings.ShowFooter = True

            'settings.ClientSideEvents.Init = "function(s, e) { s.PerformCallback(); }"
            settings.ClientSideEvents.BeginCallback = "function(s, e) { OnStartCallback(s, e); }"
            settings.ClientSideEvents.EndCallback = "function(s, e) { OnEndCallback(s, e); }"
            
            
            settings.CustomJSProperties = Sub(s, e)
                                                  If ViewData("RequestFlag") IsNot Nothing Then
                                                      e.Properties("cpRequestFeedback") = ViewData("RequestFlag").ToString()
                                                  End If
                                                  'Dim grid As MVCxGridView = DirectCast(s, MVCxGridView)
                                                  Dim sumOfQ1 As String = IIf(s.GetTotalSummaryValue(s.TotalSummary("q1")) Is Nothing, 0, s.GetTotalSummaryValue(s.TotalSummary("q1")))
                                                  Dim sumOfQ2 As String = IIf(s.GetTotalSummaryValue(s.TotalSummary("q2")) Is Nothing, 0, s.GetTotalSummaryValue(s.TotalSummary("q2")))
                                                  Dim sumOfQ3 As String = IIf(s.GetTotalSummaryValue(s.TotalSummary("q3")) Is Nothing, 0, s.GetTotalSummaryValue(s.TotalSummary("q3")))
                                                  Dim sumOfDoc As String = IIf(s.GetTotalSummaryValue(s.TotalSummary("dr_code")) Is Nothing, 0, s.GetTotalSummaryValue(s.TotalSummary("dr_code")))
                                                  e.Properties("cpRequestSendFeedback") = sumOfQ1 + "-" + sumOfQ2 + "-" + sumOfQ3 + "-" + sumOfDoc
                                                                                        
                                          End Sub
            
            'settings.DataBound = Sub(sender, e)
            '                             Dim grid As MVCxGridView = DirectCast(s, MVCxGridView)
            '                             If ViewData("RequestFlag") IsNot Nothing Then
            '                                 e.Properties("cpRequestFeedback") = ViewData("RequestFlag").ToString()
            '                             End If

            '                     End Sub

            settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, String.Empty)


            settings.CustomUnboundColumnData =
                Sub(sender, e)
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

            settings.SetFooterRowTemplateContent(
                Sub(c)
                        Try
                            
                            Dim q1 As String = c.Grid.GetTotalSummaryValue(c.Grid.TotalSummary("q1")).ToString
                            Dim q2 As String = c.Grid.GetTotalSummaryValue(c.Grid.TotalSummary("q2")).ToString
                            Dim q3 As String = c.Grid.GetTotalSummaryValue(c.Grid.TotalSummary("q3")).ToString
                            Dim tot As String = c.Grid.GetTotalSummaryValue(c.Grid.TotalSummary("dr_code")).ToString
                            ViewData("sum") = q1 + "-" + q2 + "-" + q3 + "-" + tot
 
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
        Html.DevExpress().PopupControl(
            Sub(settings)
                    settings.Name = "PopupControl"
                    settings.ShowHeader = True
                    settings.ShowOnPageLoad = True
                    settings.AllowDragging = False
                    settings.CloseAction = CloseAction.OuterMouseClick
                    settings.CloseOnEscape = True
                    settings.Modal = True
                    settings.Width = Unit.Pixel(300)
                    settings.Height = Unit.Pixel(100)
                    settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                    settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                    settings.HeaderText = "Information"
                    
                    'settings.SetHeaderTemplateContent(
                    '    Sub()
                    '            ViewContext.Writer.Write("<div style='font-size:small;'>Information</div>")
                    '    End Sub)

                    settings.SetContent(Sub()
                                                ViewContext.Writer.Write(msg)
                                        End Sub)
                    settings.ShowCloseButton = True
                    settings.ShowShadow = True

            End Sub).GetHtml()


    End If
End Code