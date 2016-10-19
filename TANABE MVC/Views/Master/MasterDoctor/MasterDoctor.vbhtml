@ModelType System.Collections.IEnumerable

<script type="text/javascript">
    var v_dr_code = "";

    function SelectionChanged(s, e) {
        s.GetSelectedFieldValues("dr_code", GetSelectedFieldValuesCallback);
    }

    function GetSelectedFieldValuesCallback(values) {
        v_dr_code = values;
    }

    function OnExport(s, e) {
        var actionParams = $("form").attr("action").split("?OutputFormat=");
        actionParams[1] = s.GetMainElement().getAttribute("OutputFormatAttribute");
        $("form").attr("action", actionParams.join("?OutputFormat="));
    }

    function OnEndCallBack(s, e) {
        if (s.cpMessage) {
            alert(s.cpMessage);
            delete s.cpMessage;
        }
    }

    function do_reset(s, e) {
        cbregion.SetValue(null);
        DataView1.PerformCallback("reset" + ';' + null);
    }

    function do_retrieve(s, e) {
        var reg = cbregion.GetValue();
        var param = 'retrieve:' + reg;
        DataView1.PerformCallback({ act: param });
    }

    function cb_sbo_ValueChanged(s, e) {
        var id = s.GetValue();
        $.ajax({
            url: "/MasterDoctor/GetDoctorCode/",
            type: "POST",
            data: '{sbo_code: "' + id + '" }',
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (data) {
                $('#DataView1_DXPEForm_DXEFL_DXEditor1_I').val(data.NEW_DR_CODE.trim());
            }
        });
    }

    function OnContextMenuItemClick(sender, args) {
        if (args.item.name == "Mapping SBO") {
            popupMappingSBO.Show();
        } else if (args.item.name == "Mapping Status") {
            popupMappingStatus.Show();
        } else if (args.item.name == "Mapping Quadrant") {
            popupMappingQuadrant.Show();
        }
    }

    function OnContextMenu(s, e) {
        if (e.objectType == "row") {
            var menuItemSelected1 = e.menu.GetItemByName("Mapping SBO");
            var menuItemSelected2 = e.menu.GetItemByName("Mapping Status");
            var menuItemSelected3 = e.menu.GetItemByName("Mapping Quadrant");
            var isRowSelected = s.IsRowSelectedOnPage(e.index);
            menuItemSelected1.SetEnabled(isRowSelected);
            menuItemSelected2.SetEnabled(isRowSelected);
            menuItemSelected3.SetEnabled(isRowSelected);
        }
    }

    function ProccessMappingSBO() {
        var sbo = cbMappingSBO.GetValue();
        if ((v_dr_code != "") && (sbo != "")) {
            var param = 'MappingSBO:' + sbo + ';' + v_dr_code;
            v_dr_code = ""
            DataView1.UnselectRows();
            cbMappingSBO.SetValue(null);
            DataView1.PerformCallback({ act: param });
        } else {
            alert("Please select the record And SBO")
        }
        popupMappingSBO.Hide();
        v_dr_code = ""
        DataView1.UnselectRows();
        cbMappingSBO.SetValue(null);
    }

    function ProccessMappingStatus() {
        var status = cbMappingStatus.GetValue();
        if ((v_dr_code != "") && (status != "")) {
            var param = 'MappingStatus:' + status + ';' + v_dr_code;
            v_dr_code = ""
            DataView1.UnselectRows();
            cbMappingStatus.SetValue(null);
            DataView1.PerformCallback({ act: param });            
        } else {
            alert("Please select the record And Status")
        }
        popupMappingStatus.Hide();
        v_dr_code = ""
        DataView1.UnselectRows();
        cbMappingStatus.SetValue(null);
    }

    function ProccessMappingQuadrant() {
        var quad = cbMappingQuadrant.GetValue();
        if ((v_dr_code != "") && (quad != "")) {
            var param = 'MappingQuadrant:' + quad + ';' + v_dr_code;
            v_dr_code = ""
            DataView1.UnselectRows();
            cbMappingQuadrant.SetValue(null);
            DataView1.PerformCallback({ act: param });            
        } else {
            alert("Please select the record And Region")
        }
        popupMappingQuadrant.Hide();
        v_dr_code = ""
        DataView1.UnselectRows();
        cbMappingQuadrant.SetValue(null);
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
        <tr><td class="title-form" style="text-align: center; font-weight: bold;" colspan="6">:: MASTER DOCTOR ::</td></tr>
        <tr>
                <td class="cell-month cell-backround">
                    @Html.DevExpress().ComboBox(Sub(settings)
                                                         settings.Name = "cbregion"
                                                         settings.Properties.DataSource = TANABE_MVC.MasterRepresentativeController.CbRegion
                                                         settings.Properties.Caption = "Region"
                                                         settings.Properties.DropDownWidth = 300
                                                         settings.Properties.CaptionSettings.Position = EditorCaptionPosition.Left
                                                         settings.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                         settings.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                         settings.Properties.CallbackPageSize = 15
                                                         settings.Properties.TextField = "rep_region"
                                                         settings.Properties.TextFormatString = "{0}"
                                                         settings.Properties.ValueField = "rep_region"
                                                         settings.Properties.ValueType = GetType(String)
                                                         settings.Properties.Columns.Add("rep_region", "Region", 30)
                                                         settings.Properties.Columns.Add("nama_rm", "Functionary", 120)
                                                     End Sub).BindList(TANABE_MVC.MasterRepresentativeController.CbRegion).GetHtml()
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
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Reset"
                                                  settings.ToolTip = "Reset"
                                                  settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "do_reset"
                                              End Sub).GetHtml()
            </td>
            <td class="cell-blank"></td>
            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("ExportTo", "MasterDoctor"))
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
                @Using (Html.BeginForm("ExportTo", "MasterDoctor"))
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
            @Html.Action("ViewMasterDoctor", "MasterDoctor")
        </tr>
    </table>
</div>

@Html.DevExpress.PopupControl(Sub(settings)
                                  settings.Name = "popupMappingSBO"
                                  settings.CloseAction = CloseAction.OuterMouseClick
                                  settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                  settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                  settings.AllowDragging = True
                                  settings.ShowFooter = True
                                  settings.Width = 400
                                  settings.Height = 100
                                  settings.HeaderText = "Mapping Sub Branch Office"

                                  settings.SetContent(Sub()
                                                          ViewContext.Writer.Write("<table style='width:100%'>")
                                                          ViewContext.Writer.Write("<tr id='row_lookup_doctor'>")
                                                          ViewContext.Writer.Write("<td  style='width:150px;text-align:right;background-color:lightgray;'>Change SBO To : </td>")
                                                          ViewContext.Writer.Write("<td>")
                                                          Html.DevExpress().ComboBox(Sub(s)
                                                                                         s.Name = "cbMappingSBO"
                                                                                         s.Properties.DataSource = TANABE_MVC.MasterDoctorController.ComboSBO
                                                                                         s.Properties.EnableClientSideAPI = True
                                                                                         s.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                         s.Properties.CallbackPageSize = 12
                                                                                         s.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                         s.Properties.TextFormatString = "{0}"
                                                                                         s.Properties.ValueField = "sbo_code"
                                                                                         s.Properties.TextField = "sbo_code"
                                                                                         s.Properties.Columns.Add("sbo_code", "SBO CODE", 50)
                                                                                         s.Properties.Columns.Add("bo_code", "BO Code", 50)
                                                                                         s.Properties.Columns.Add("rep_name", "REP IN CHARGE", 120)
                                                                                     End Sub).BindList(TANABE_MVC.MasterDoctorController.ComboSBO).GetHtml()
                                                          ViewContext.Writer.Write("</td>")
                                                          ViewContext.Writer.Write("</tr>")
                                                          ViewContext.Writer.Write("</table>")
                                                      End Sub)
                                  settings.SetFooterTemplateContent(Sub()
                                                                        ViewContext.Writer.Write("<div style='overflow: hidden'><div style='padding: 3px; float: right;'>")
                                                                        Html.DevExpress().Button(Sub(b)
                                                                                                     b.Name = "UpdateButtonSBO"
                                                                                                     b.Text = "Submit"
                                                                                                     b.UseSubmitBehavior = True
                                                                                                     b.ClientSideEvents.Click = "ProccessMappingSBO"
                                                                                                 End Sub).GetHtml()
                                                                        ViewContext.Writer.Write("</div></div>")
                                                                    End Sub)
                              End Sub).GetHtml()

@Html.DevExpress.PopupControl(Sub(settings)
                                  settings.Name = "popupMappingStatus"
                                  settings.CloseAction = CloseAction.OuterMouseClick
                                  settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                  settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                  settings.AllowDragging = True
                                  settings.ShowFooter = True
                                  settings.Width = 400
                                  settings.Height = 100
                                  settings.HeaderText = "Mapping Doctor Status"

                                  settings.SetContent(Sub()
                                                          ViewContext.Writer.Write("<table style='width:100%'>")
                                                          ViewContext.Writer.Write("<tr id='row_lookup_doctor'>")
                                                          ViewContext.Writer.Write("<td  style='width:150px;text-align:right;background-color:lightgray;'>Change Status To : </td>")
                                                          ViewContext.Writer.Write("<td>")
                                                          Html.DevExpress().ComboBox(Sub(s)
                                                                                         s.Name = "cbMappingStatus"
                                                                                         s.Properties.EnableClientSideAPI = True
                                                                                         s.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                         s.Properties.CallbackPageSize = 12
                                                                                         s.Properties.TextFormatString = "{0}"
                                                                                         s.Properties.Items.Add("ACTIVE", "1")
                                                                                         s.Properties.Items.Add("NON ACTIVE", "0")
                                                                                     End Sub).GetHtml()
                                                          ViewContext.Writer.Write("</td>")
                                                          ViewContext.Writer.Write("</tr>")
                                                          ViewContext.Writer.Write("</table>")
                                                      End Sub)
                                  settings.SetFooterTemplateContent(Sub()
                                                                        ViewContext.Writer.Write("<div style='overflow: hidden'><div style='padding: 3px; float: right;'>")
                                                                        Html.DevExpress().Button(Sub(b)
                                                                                                     b.Name = "UpdateButtonStatus"
                                                                                                     b.Text = "Submit"
                                                                                                     b.UseSubmitBehavior = True
                                                                                                     b.ClientSideEvents.Click = "ProccessMappingStatus"
                                                                                                 End Sub).GetHtml()
                                                                        ViewContext.Writer.Write("</div></div>")
                                                                    End Sub)
                              End Sub).GetHtml()

@Html.DevExpress.PopupControl(Sub(settings)
                                       settings.Name = "popupMappingQuadrant"
                                  settings.CloseAction = CloseAction.OuterMouseClick
                                  settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                  settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                  settings.AllowDragging = True
                                  settings.ShowFooter = True
                                  settings.Width = 400
                                  settings.Height = 100
                                  settings.HeaderText = "Mapping Doctor Quadrant"

                                  settings.SetContent(Sub()
                                                          ViewContext.Writer.Write("<table style='width:100%'>")
                                                          ViewContext.Writer.Write("<tr id='row_lookup_doctor'>")
                                                          ViewContext.Writer.Write("<td  style='width:150px;text-align:right;background-color:lightgray;'>Change Quadrant To : </td>")
                                                          ViewContext.Writer.Write("<td>")
                                                          Html.DevExpress().ComboBox(Sub(s)
                                                                                         s.Name = "cbMappingQuadrant"
                                                                                         s.Properties.DataSource = TANABE_MVC.MasterDoctorController.ComboQuad
                                                                                         s.Properties.EnableClientSideAPI = True
                                                                                         s.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                         s.Properties.CallbackPageSize = 12
                                                                                         s.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                         s.Properties.TextFormatString = "{0}"
                                                                                         s.Properties.ValueField = "quadrant"
                                                                                         s.Properties.TextField = "quadrant"
                                                                                         s.Properties.ValueType = GetType(String)
                                                                                         s.Properties.Columns.Add("quadrant", "Quadrant", 50)
                                                                                         s.Properties.Columns.Add("description", "Description", 120)
                                                                                     End Sub).BindList(TANABE_MVC.MasterDoctorController.ComboQuad).GetHtml()
                                                          ViewContext.Writer.Write("</td>")
                                                          ViewContext.Writer.Write("</tr>")
                                                          ViewContext.Writer.Write("</table>")
                                                      End Sub)
                                  settings.SetFooterTemplateContent(Sub()
                                                                        ViewContext.Writer.Write("<div style='overflow: hidden'><div style='padding: 3px; float: right;'>")
                                                                        Html.DevExpress().Button(Sub(b)
                                                                                                     b.Name = "UpdateButtonQuad"
                                                                                                     b.Text = "Submit"
                                                                                                     b.UseSubmitBehavior = True
                                                                                                     b.ClientSideEvents.Click = "ProccessMappingQuadrant"
                                                                                                 End Sub).GetHtml()
                                                                        ViewContext.Writer.Write("</div></div>")
                                                                    End Sub)
                              End Sub).GetHtml()

<script type="text/javascript">

    var callbackInitDate;
    var command;

    function OnStartCallback(s, e) {
        callbackInitDate = new Date();
        command = e.command;
    }
    function OnEndCallback(s, e) {
        var currentDate = new Date();
        var time = currentDate - callbackInitDate;
    }

    function msg_error() {
        PopupControl.PerformCallback();
        PopupControl.Show();
    }

</script>

