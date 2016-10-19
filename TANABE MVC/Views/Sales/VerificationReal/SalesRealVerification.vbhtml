@ModelType System.Collections.IEnumerable

<script type="text/javascript">
    var var_sales_id;
    function OnExport(s, e) {
        var actionParams = $("form").attr("action").split("?OutputFormat=");
        actionParams[1] = s.GetMainElement().getAttribute("OutputFormatAttribute");
        $("form").attr("action", actionParams.join("?OutputFormat="));
    }

    function SelectionChanged(s, e) {
        var i = gridSalesRealVerification.GetSelectedRowCount();
        if (i == 0) {
            btnVerify.SetEnabled(false);
            btnUnselect.SetEnabled(false);
        } else {
            btnVerify.SetEnabled(true);
            btnUnselect.SetEnabled(true);
            gridSalesRealVerification.GetSelectedFieldValues("sales_id", GetSelectedFieldValuesCallback);
        }
    }

    function gridSalesRealVerification_EndCallBack(s, e) {
        if (s.cpInsertResult == "success_verify") {
            alert("Verification has been successfuly proceed");
            s.cpInsertResult = "undefined";
        } else if (s.cpInsertResult == "error_verify") {
            alert("There is an error on verification process with specified id " + s.cpErrorCode);
            s.cpInsertResult = "undefined";
        } else if (s.cpInsertResult == "null_record") {
            alert("There is no record for filled criteria");
            btnSelect.SetEnabled(false);
            btnSelectAll.SetEnabled(false);
            s.cpInsertResult = "undefined";
        }
    }

    function do_retrieve(s, e) {
        var cb_rep_selection = cb_rep.GetText();
        var rep_id = cb_rep_selection.substring(0, 5);
        var month = cb_month.GetValue();
        var year = cb_year.GetValue();
        if (rep_id != '') {
            if (month != null) {
                if (year != null) {
                    var param = "retrieve" + ';' + rep_id + ';' + month + ';' + year;
                    gridSalesRealVerification.PerformCallback({ prm: param });
                    btnSelect.SetEnabled(true);
                    btnSelectAll.SetEnabled(true);
                } else {
                    alert('Please choose year periode');
                }
            } else {
                alert('Please choose month periode');
            }
        } else {
            alert('Please choose your subordinat representative');
        }
    }

    function do_reset(s, e) {
        cb_month.SetValue(null);
        cb_year.SetValue(null);
        cb_rep.SetText(null);
        var param = "reset" + ';' + null + ';' + null + ';' + null;
        gridSalesRealVerification.PerformCallback({ prm: param });
        btnSelect.SetEnabled(false);
        btnSelectAll.SetEnabled(false);
    }

    function do_verify(s, e) {
        var param = "verify" + ';' + null + ';' + null + ';' + null;
        gridSalesRealVerification.PerformCallback({ prm: param });
    }

    function do_selectAll(s, e) {
        gridSalesRealVerification.SelectRows();
        btnVerify.SetEnabled(true);
        btnUnselect.SetEnabled(true);
    }

    function do_selectPage(s, e) {
        gridSalesRealVerification.SelectAllRowsOnPage();
        btnVerify.SetEnabled(true);
        btnUnselect.SetEnabled(true);
    }

    function do_unselect(s, e) {
        gridSalesRealVerification.UnselectRows();
        btnVerify.SetEnabled(false);
        btnUnselect.SetEnabled(false);
    }

    function GetSelectedFieldValuesCallback(values) {
        var_sales_id = values;
    }

    function verify_Grid(s, e) {
        var sales_id = s.GetMainElement().getAttribute("v_sales_id");
        var param = 'verify_by_one;' + null + ';' + null + ';' + null + ';' + sales_id;
        if (confirm("Are you sure want to verify this plan with code " + sales_id + " ?") == true) {
            gridSalesRealVerification.PerformCallback({ prm: param });
        }
    }

    function VerifyAllData(s, e) {
        var param = 'verify;' + null + ';' + null + ';' + null + ';' + var_sales_id;
        if (confirm("Are you sure want to verify selected plan ?") == true) {
            gridSalesRealVerification.PerformCallback({ prm: param });
        }
    }
</script>

<style type="text/css">
    .table {
        padding-right: 5px;
    }

    .cell-backround {
        background-color: #F0F0F0;
        color: black;
    }

    .cell-newplan {
        padding-top: 4px;
        padding-bottom: 4px;
    }

    .cell-month {
        width: 150px;
        padding-top: 4px;
        padding-bottom: 4px;
        padding-left: 5px;
    }

    .cell-year {
        width: 50px;
        padding-top: 4px;
        padding-bottom: 4px;
        padding-left: 20px;
    }

    .cell-retrieve {
        padding-top: 4px;
        padding-bottom: 4px;
        padding-left: 10px;
    }

    .cell-reset {
        padding-top: 4px;
        padding-bottom: 4px;
        padding-left: 5px;
    }

    .panel-content {
        margin-left: 8px;
        margin-top: 8px;
    }

    .distance-left {
        margin-left: 5px;
    }

    .distance-right {
        margin-right: 5px;
    }

    .cell-blank {
        width: 100%;
        background-color: #F0F0F0;
    }

    .cell-divider {
        height: 5px;
        width: 100%;
    }

    .title-form {
        padding-bottom: 4px;
    }
</style>

<div class="panel-content">
    <table class="table">
        <tr>
            <td class="title-form" style="text-align: center; font-weight: bold;" colspan="11">:: ACTUAL SALES ::</td>
        </tr>
        <tr>
            <td class="cell-month cell-backround">
                @Html.DevExpress().ComboBox(Sub(settings)
                                                settings.Name = "cb_rep"
                                                settings.Properties.Caption = "Rep :"
                                                settings.Properties.DropDownWidth = Unit.Percentage(100)
                                                settings.Properties.NullText = "Your Sub-ordinat Representative"
                                                settings.Properties.CaptionSettings.Position = EditorCaptionPosition.Left
                                                settings.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                settings.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                settings.Properties.CallbackPageSize = 15
                                                settings.Properties.TextFormatString = "{0}-{1}"
                                                settings.Properties.ValueField = "rep_id"
                                                settings.Properties.ValueType = GetType(String)
                                                settings.Properties.Columns.Add("rep_id", "NIK", 45)
                                                settings.Properties.Columns.Add("rep_name", "NAME", 200)
                                                settings.Properties.Columns.Add("rep_bo", "BO", 50)
                                                settings.Properties.Columns.Add("rep_sbo", "SBO", 50)
                                                settings.Properties.Columns.Add("rep_division", "DIVISION", 60)
                                            End Sub).BindList(TANABE_MVC.SalesRealVerificationController.dsRep).GetHtml()
            </td>
            <td class="cell-month cell-backround">
                @Html.DevExpress().ComboBox(Sub(settings)
                                                settings.Name = "cb_month"
                                                settings.Properties.Caption = "Month :"
                                                settings.Properties.NullText = "Month"
                                                settings.Properties.Items.Add("January").Value = 1
                                                settings.Properties.Items.Add("February").Value = 2
                                                settings.Properties.Items.Add("March").Value = 3
                                                settings.Properties.Items.Add("April").Value = 4
                                                settings.Properties.Items.Add("May").Value = 5
                                                settings.Properties.Items.Add("June").Value = 6
                                                settings.Properties.Items.Add("July").Value = 7
                                                settings.Properties.Items.Add("August").Value = 8
                                                settings.Properties.Items.Add("September").Value = 9
                                                settings.Properties.Items.Add("October").Value = 10
                                                settings.Properties.Items.Add("November").Value = 11
                                                settings.Properties.Items.Add("December").Value = 12
                                                settings.Properties.CaptionSettings.Position = EditorCaptionPosition.Left
                                                settings.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                settings.Width = 120
                                                settings.Height = 27
                                            End Sub).GetHtml()
            </td>
            <td class="cell-year cell-backround">
                @Html.DevExpress().SpinEdit(Sub(settings)
                                                settings.Name = "cb_year"
                                                settings.Properties.Caption = "Year"
                                                settings.Properties.MinValue = "2015"
                                                settings.Properties.MaxValue = "2100"
                                                settings.Properties.NullText = "Year"
                                                settings.Width = 80
                                                settings.Height = 27
                                            End Sub).GetHtml()
            </td>
            <td class="cell-retrieve cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnretrieve"
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Retrieve"
                                              settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                              settings.ToolTip = "Retrieve"
                                              settings.ClientSideEvents.Click = "do_retrieve"
                                          End Sub).GetHtml()

            </td>
            <td class="cell-reset cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnreset"
                                              settings.UseSubmitBehavior = True
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Reset"
                                              settings.Images.Image.Url = "~/Content/Images/reset.png"
                                              settings.ToolTip = "Reset"
                                              settings.ClientSideEvents.Click = "do_reset"
                                          End Sub).GetHtml()
            </td>
            <td class="cell-blank"></td>
            <td class="cell-blank"></td>
            <td class="cell-blank"></td>
            <td class="cell-blank"></td>
            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("ExportTo", "SalesRealVerification"))
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "PDF"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Export to PDF"
                                                  settings.Images.Image.Url = "~/Content/Images/pdf.png"
                                                  settings.ToolTip = "Export to PDF"
                                                  settings.Attributes("OutputFormatAttribute") = "PDF"
                                                  settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "OnExport"
                                              End Sub).GetHtml()

                End Using
            </td>
            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("ExportTo", "SalesRealVerification"))
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "XLS"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Export to Excell"
                                                  settings.Images.Image.Url = "~/Content/Images/excel.png"
                                                  settings.ToolTip = "Export to Excell"
                                                  settings.ControlStyle.CssClass = "distance-right"
                                                  settings.Attributes("OutputFormatAttribute") = "XLS"
                                                  settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "OnExport"
                                              End Sub).GetHtml()
                End Using
            </td>
        </tr>
        <tr>
            <td class="cell-blank" colspan="6"></td>
            <td class="cell-blank">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td class="cell-reset cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnVerify"
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Verify Selected Records"
                                              settings.ToolTip = "Verify Selected Records"
                                              settings.UseSubmitBehavior = True
                                              settings.Images.Image.Url = "~/Content/Images/edit-icon2.png"
                                              settings.ClientEnabled = False
                                              settings.ClientSideEvents.Click = "VerifyAllData"
                                          End Sub).GetHtml()
            </td>
            <td class="cell-reset cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnSelectAll"
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Select All Rows"
                                              settings.ToolTip = "Select All Rows"
                                              settings.UseSubmitBehavior = True
                                              settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                              settings.ClientEnabled = False
                                              settings.ClientSideEvents.Click = "do_selectAll"
                                          End Sub).GetHtml()
            </td>
            <td class="cell-reset cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnSelect"
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Select Page"
                                              settings.ToolTip = "Select Page"
                                              settings.UseSubmitBehavior = True
                                              settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                              settings.ClientEnabled = False
                                              settings.ClientSideEvents.Click = "do_selectPage"
                                          End Sub).GetHtml()
            </td>
            <td class="cell-reset cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnUnselect"
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Unselect All"
                                              settings.ToolTip = "Unselect All"
                                              settings.UseSubmitBehavior = True
                                              settings.Images.Image.Url = "~/Content/Images/delete.png"
                                              settings.ClientEnabled = False
                                              settings.ClientSideEvents.Click = "do_unselect"
                                          End Sub).GetHtml()
            </td>
        </tr>
        <tr class="cell-divider"></tr>
        <tr>
            @Html.Action("ViewSalesRealVerification", "SalesRealVerification")
        </tr>
    </table>
</div>