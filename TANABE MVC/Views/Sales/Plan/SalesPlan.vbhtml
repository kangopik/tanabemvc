@ModelType System.Collections.IEnumerable

<script type="text/javascript">
    var v_dr_code = "";
    var v_date = "";
    var v_year = "";

    function SelectionChanged(s, e) {
        gridSalesPlan.GetSelectedFieldValues("dr_code", GetSelectedFieldValuesDr);
        gridSalesPlan.GetSelectedFieldValues("sales_date_plan", GetSelectedFieldValuesDate);
        gridSalesPlan.GetSelectedFieldValues("sales_year_plan", GetSelectedFieldValuesYear);
    }

    function GetSelectedFieldValuesDr(values) {
        v_dr_code = values;
    }

    function GetSelectedFieldValuesDate(values) {
        v_date = values;
    }

    function GetSelectedFieldValuesYear(values) {
        v_year = values;
    }

    function OnExport(s, e) {
        var actionParams = $("form").attr("action").split("?OutputFormat=");
        actionParams[1] = s.GetMainElement().getAttribute("OutputFormatAttribute");
        $("form").attr("action", actionParams.join("?OutputFormat="));
    }

    function generateSales(s, e) {
        var currentTime = new Date();
        var month = currentTime.getMonth() + 1;
        var year = currentTime.getFullYear();
        var param = 'generate;' + month + ';' + year;
        if (confirm('Are you sure want to generate sales plan automatically in current month ?') == true) {
            gridSalesPlan.PerformCallback({ prm: param });
        }
    }

    function copySales(s, e) {
        var currentTime = new Date();
        var month = cb_from_month.GetValue();
        if (month == null) { month = ""}
        var year = cb_from_year.GetValue();
        if (year == null) { year = ""}
        var param = 'copy;' + month + ';' + year;
        if (confirm('Are you sure want to copy sales plan automatically from selected month ?') == true) {
            gridSalesPlan.PerformCallback({ prm: param });
        }
    }

    function do_retrieve(s, e) {
        var month = cbomonth.GetValue();
        var year = cboyear.GetValue();
        var param = 'retrieve;' + month + ';' + year;
        gridSalesPlan.PerformCallback({ prm: param });
    }

    function do_reset(s, e) {
        cbomonth.SetValue(null);
        cboyear.SetValue(null);
        var param = 'reset;' + null + ';' + null;
        gridSalesPlan.PerformCallback({ prm: param });
    }

    function gridSalesPlan_EndCallBack(s, e) {
        if (s.cpInsertResult != "undefined") {
            if (s.cpInsertResult == "success_on_generate") {
                alert("Sales scheme has been successfully generated");
                s.cpInsertResult = "undefined";
            } else if (s.cpInsertResult == "error_on_generate") {
                alert("There is error on generating sales scheme plan");
                s.cpInsertResult = "undefined";
            } else if (s.cpInsertResult == "sales_planned_already") {
                alert("System can't generate scheme because sales plan has been already created in current month");
                s.cpInsertResult = "undefined";
            } else if (s.cpInsertResult == "null_record") {
                btnReqVer.SetEnabled(false);
                s.cpInsertResult = "undefined";
            } else if (s.cpInsertResult == "record_exists") {
                btnReqVer.SetEnabled(true);
                s.cpInsertResult = "undefined";
            }
        }
        if (s.cpClosePopup != "undefined") {
            if (s.cpClosePopup == "null_month") {
                alert("Please fill the month plan from");
                cb_from_month.focus();
                s.cpClosePopup = "undefined"
            } else if (s.cpClosePopup == "null_year") {
                alert("Please fill year from");
                cb_from_year.focus();
                s.cpClosePopup = "undefined"
            } else if (s.cpClosePopup == "success_copy") {
                alert("Copy has been successfull");
                popupCopySales.Hide();
                gridSalesPlan.Refresh();
                btnReqVer.SetEnabled(true);
                popupCopySales.SetPopupElementID(btnReqVer.name);
                s.cpClosePopup = "undefined"
            } else if (s.cpClosePopup == "copy_error") {
                alert("There is error on copyng data");
                popupCopySales.Hide();
                s.cpClosePopup = "undefined"
            } else if (s.cpClosePopup == "sales_planned_already") {
                alert("System can't generate scheme because sales plan has been already created in current month");
                s.cpInsertResult = "undefined";
            } else if (s.cpClosePopup == "null_planned") {
                alert("System can't generate scheme because there is no plan already in selected month");
                s.cpInsertResult = "undefined";
            }
        }
        if (s.cpCloseMapping != "undefined") {
            if (s.cpCloseMapping == "null_product") {
                alert("Please choose product for first");
                s.cpCloseMapping = "undefined";
            } else if (s.cpCloseMapping == "null_target") {
                alert("Please fill your target");
                s.cpCloseMapping = "undefined";
            } else if (s.cpCloseMapping == "success_mapping") {
                alert("Mapping has been successfull");
                popupMapping.Hide();
                gridSalesPlan.UnselectAllRowsOnPage();
                gridSalesPlan.Refresh();
                cbProductMapping.SetValue(null);
                s.cpCloseMapping = "undefined";
            } else if (s.cpCloseMapping == "mapping_error") {
                alert("There is error on mapping data");
                popupMapping.Hide();
                gridSalesPlan.UnselectAllRowsOnPage();
                gridSalesPlan.Refresh();
                cbProductMapping.SetValue(null);
                s.cpCloseMapping = "undefined";
            }
        }
        if (s.cpCekGrid != "") {
            if (s.cpClosePopup == "null_record") {
                btnReqVer.SetEnabled(false);
                s.cpCekGrid = ""
            } else if (s.cpClosePopup == "record_exists") {
                btnReqVer.SetEnabled(true);
                s.cpCekGrid = ""
            }
        }
    }

    function OnContextMenuItemClick(sender, args) {
        if (args.item.name == "Mapping") {
            popupMapping.Show();
        }
    }

    function OnContextMenu(s, e) {
        if (e.objectType == "row") {
            var menuItemSelected = e.menu.GetItemByName("Mapping");
            var isRowSelected = s.IsRowSelectedOnPage(e.index);
            menuItemSelected.SetEnabled(isRowSelected);
        }
    }

    function popupCopySales_Shown(s, e) {
        cb_from_month.SetValue(null);
        cb_from_year.SetValue(null);
    }

    function popupMapping_Shown(s, e) {
        cbProductMapping.SetValue(null);
        txTarget.SetValue(null);
        txNote.SetValue(null);
    }

    function ProccessMappingProduct() {
        var prd = cbProductMapping.GetValue();
        var trg = txTarget.GetValue();
        var not = txNote.GetValue();
        if (v_dr_code != "") {
            var param = 'mapping;' + v_date + ';' + v_year + ';' + prd + ';' + trg + ';' + not + ';' + v_dr_code;
            gridSalesPlan.PerformCallback({ prm: param });
            v_dr_code = ""
        }
    }

    function periode_ValueChanged(s, e) {
        var currentTime = new Date()
        var month = cb_date_periode.GetValue();
        var year = currentTime.getFullYear();
        var param = 'retrieve;' + month + ';' + year;
        gridSalesPlan.PerformCallback({ prm: param });
    }

    function reqverification() {
        var vmonth_req = cb_date_periode.GetValue();
        var param = "request;" + vmonth_req + ';' + '';
        gridSalesPlan.PerformCallback({ prm: param });
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
            <td class="title-form" style="text-align:center; font-weight:bold;" colspan="8">:: SALES PLAN ::</td>
        </tr>
        <tr>
            <td class="cell-month cell-backround">
                @Html.DevExpress().ComboBox(Sub(settings)
                                                settings.Name = "cbomonth"
                                                settings.Properties.Caption = "Month"
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
                                                settings.Properties.NullText = "Month"
                                                settings.Width = 120
                                                settings.Height = 27
                                            End Sub).GetHtml()
            </td>
            <td class="cell-year cell-backround">
                @Html.DevExpress().SpinEdit(Sub(settings)
                                                settings.Name = "cboyear"
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
            <td class="cell-reset cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnReqVer"
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Request Verification"
                                              settings.Images.Image.Url = "~/Content/Images/request.png"
                                              settings.ToolTip = "Request Verification"
                                          End Sub).GetHtml()
            </td>
            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("ExportTo", "SalesPlan"))
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
                @Using (Html.BeginForm("ExportTo", "SalesPlan"))
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
            <td class="cell-newlan cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btngeneratesales"
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Generate Sales Plan Template"
                                              settings.ControlStyle.CssClass = "distance-left"
                                              settings.Images.Image.Url = "~/Content/Images/scheme.png"
                                              settings.ToolTip = "Generate Sales Plan Template"
                                              settings.ClientSideEvents.Click = "generateSales"
                                          End Sub).GetHtml()
            </td>
            <td class="cell-newlan cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnCopySales"
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Copy Sales Plan Template"
                                              settings.ControlStyle.CssClass = "distance-left"
                                              settings.Images.Image.Url = "~/Content/Images/copy.png"
                                              settings.ToolTip = "Copy Sales Plan Template"
                                              settings.ClientSideEvents.Click = "function(s, e){ popupCopySales.Show(); }"
                                          End Sub).GetHtml()

            </td>
            <td class="cell-blank" colspan="6"></td>
        </tr>
        <tr class="cell-divider"></tr>
        <tr>
            @Html.Action("ViewSalesPlan", "SalesPlan")
        </tr>
    </table>
</div>

@Html.Partial("~/Views/Sales/Plan/PopupRequest.vbhtml")
@Html.Partial("~/Views/Sales/Plan/PopupMapping.vbhtml")
@Html.Partial("~/Views/Sales/Plan/PopupCopySales.vbhtml")


