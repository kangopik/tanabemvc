@ModelType System.Collections.IEnumerable

<script type="text/javascript">
    var SelectedKeys = new Array();
    var v_sales_id;

    function SelectionChanged(s, e) {
        var key = s.GetRowKey(e.visibleIndex);
        if (e.isSelected)
            SelectedKeys.push(key);
        else
            SelectedKeys = RemoveElementFromArray(SelectedKeys, key);

        v_sales_id = "";
        for (var index = 0; index < SelectedKeys.length; index++) {
            v_sales_id += SelectedKeys[index] + ",";
        }
        if (v_sales_id.length > 0) {
            v_sales_id = v_sales_id.substring(0, v_sales_id.length - 1);
        }
    }

    function RemoveElementFromArray(array, element) {
        var index = array.indexOf(element);
        if (index < 0) return array;
        array[index] = null;
        var result = [];
        for (var i = 0; i < array.length; i++) {
            if (array[i] === null)
                continue;
            result.push(array[i]);
        }
        return result;
    }

    function OnExport(s, e) {
        var actionParams = $("form").attr("action").split("?OutputFormat=");
        actionParams[1] = s.GetMainElement().getAttribute("OutputFormatAttribute");
        $("form").attr("action", actionParams.join("?OutputFormat="));
    }

    function OnContextMenuItemClick(sender, args) {
        if (args.item.name == "Mapping") {
            //popupMapping.Show();
        }
    }

    function OnContextMenu(s, e) {
        if (e.objectType == "row") {
            var menuItemSelected = e.menu.GetItemByName("Mapping");
            var isRowSelected = s.IsRowSelectedOnPage(e.index);
            menuItemSelected.SetEnabled(isRowSelected);
        }
    }

    function popupMapping_Shown(s, e) {
        cbProductLookup.SetValue(null);
        txTarget.SetValue(null);
        txNote.SetValue(null);
        return false;
    }

    function gridSalesActual_EndCallBack(s, e) {
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
            } else if (s.cpInsertResult == "finish_realization") {
                gridSalesActual.PerformCallback("reset" + ';' + null + ';' + null);
                s.cpInsertResult = "undefined";
            } else if (s.cpInsertResult == "null_record") {
                btnReqVer.SetEnabled(false);
            } else if (s.cpInsertResult == "record_exists") {
                btnReqVer.SetEnabled(true);
            }
        }
        if (s.cpCloseMapping != "undefined") {
            if (s.cpCloseMapping == "null_product") {
                alert("Please choose product for first");
                s.cpCloseMapping = "undefined"
            } else if (s.cpCloseMapping == "null_target") {
                alert("Please fill your target");
                s.cpCloseMapping = "undefined"
            } else if (s.cpCloseMapping == "success_mapping") {
                alert("Mapping has been successfull");
                s.cpCloseMapping = "undefined"
                popupMapping.Hide();
                gridSalesActual.UnselectAllRowsOnPage();
                gridSalesActual.Refresh();
                v_sales_id = "";
                SelectedKeys.length = 0;
            } else if (s.cpCloseMapping == "mapping_error") {
                alert("There is error on mapping data");
                s.cpCloseMapping = "undefined"
                popupMapping.Hide();
                gridSalesActual.UnselectAllRowsOnPage();
                gridSalesActual.Refresh();
                v_sales_id = "";
                SelectedKeys.length = 0;
            }
        }
    }

    function popupMapping_Shown(s, e) {
        cbProductMapping.SetValue(null);
        txTarget.SetValue(null);
        txNote.SetValue(null);
        return false;
    }

    function ProccessMappingProduct() {
        var prd = cbProductMapping.GetValue();
        var trg = txTarget.GetValue();
        var not = txNote.GetValue();
        var param = 'mapping;' + null + ';' + null + ';' + prd + ';' + trg + ';' + not + ';' + v_sales_id;
        gridSalesActual.PerformCallback({ prm: param });
    }

    function do_retrieve(s, e) {
        var month = cbomonth.GetValue();
        var year = cboyear.GetValue();
        if (month != null) {
            if (year != null) {
                var param = 'retrieve;' + month + ';' + year;
                gridSalesActual.PerformCallback({ prm: param });
            } else {
                alert('Please choose year periode');
            }
        } else {
            alert('Please choose month periode');
        }
    }

    function do_reset(s, e) {
        cbomonth.SetValue(null);
        cboyear.SetValue(null);
        var param = 'retrieve;' + null + ';' + null;
        gridSalesActual.PerformCallback({ prm: param });
        return false;
    }

    function reqverification() {
        var vmonth_req = cb_date_periode.GetValue();
        var param = "request;" + vmonth_req + ';' + '';
        gridSalesActual.PerformCallback({ prm: param });
    }

    function subPlan_ValueChanged(s, e) {
        var pc = s.GetValue();
        var currentTime = new Date()
        var month = currentTime.getMonth() + 1;
        var year = currentTime.getFullYear();
        PopupRequest.PerformCallback(pc);
    }

    function periode_ValueChanged(s, e) {
        var currentTime = new Date()
        var month = cb_date_periode.GetValue();
        var year = currentTime.getFullYear();
        gridSalesActual.PerformCallback("retrieve" + ';' + month + ';' + year);
        return false;
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
            <td class="title-form" style="text-align: center; font-weight: bold;" colspan="8">:: ACTUAL SALES ::</td>
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
                                                settings.SelectedIndex = DateTime.Now.Month - 1
                                                settings.Width = 120
                                                settings.Height = 27
                                                settings.Properties.NullText = "Month"
                                            End Sub).GetHtml()
            </td>
            <td class="cell-year cell-backround">
                @Html.DevExpress().SpinEdit(Sub(settings)
                                                settings.Name = "cboyear"
                                                settings.Properties.Caption = "Year"
                                                settings.Properties.MinValue = "2015"
                                                settings.Properties.MaxValue = "2100"
                                                settings.Number = DateTime.Now.Year
                                                settings.Width = 80
                                                settings.Height = 27
                                                settings.Properties.NullText = "Year"
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
                @Using (Html.BeginForm("ExportTo", "SalesActual"))
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
                @Using (Html.BeginForm("ExportTo", "SalesActual"))
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
        <tr class="cell-divider"></tr>
        <tr>
            @Html.Action("ViewSalesActual", "SalesActual")
        </tr>
    </table>
</div>

@Html.Partial("~/Views/Sales/Actual/PopupRequest.vbhtml")
@Html.Partial("~/Views/Sales/Actual/PopupMapping.vbhtml")