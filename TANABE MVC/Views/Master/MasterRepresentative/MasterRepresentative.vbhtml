@ModelType System.Collections.IEnumerable

<script type="text/javascript">
    var v_rep_id = "";

    function SelectionChanged(s, e) {
        s.GetSelectedFieldValues("rep_id", GetSelectedFieldValuesCallback);
    }

    function GetSelectedFieldValuesCallback(values) {
        v_rep_id = values;
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

    function cb_rep_ValueChanged(s, e) {
        var id = s.GetValue();
        $.ajax({
            url: "/MasterRepresentative/GetDetailRep/",
            type: "POST",
            data: '{rep_id: "' + id + '" }',
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (data) {
                $('#DataView1_DXEditor2_I').val(data.Nama.trim());
                $('#DataView1_DXEditor5_I').val(data.rep_region.trim());
                $('#DataView1_DXEditor13_I').val(data.rep_rm.trim());
                $('#DataView1_DXEditor10_I').val(data.nama_rm.trim());
            }
        });
    }

    function cb_sbo_ValueChanged(s, e) {
        var id = s.GetValue();
        $.ajax({
            url: "/MasterRepresentative/GetDetailSBO/",
            type: "POST",
            data: '{sbo_code: "' + id + '" }',
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (data) {
                $('#DataView1_DXEditor4_I').val(data.bo_code.trim());
                $('#DataView1_DXEditor12_I').val(data.bo_am.trim());
                $('#DataView1_DXEditor9_I').val(data.bo_am_name.trim());
            }
        });
    }

    function do_retrieve(s, e) {
        var reg = cbregion.GetValue();
        var param = 'retrieve:' + reg;
        DataView1.PerformCallback({ act: param });
    }

    function OnContextMenuItemClick(sender, args) {
        if (args.item.name == "Mapping Region") {
                popupMappingRegion.Show();
        }
    }

    function OnContextMenu(s, e) {
        if (e.objectType == "row") {
            var menuItemSelected = e.menu.GetItemByName("Mapping Region");
            var isRowSelected = s.IsRowSelectedOnPage(e.index);
            menuItemSelected.SetEnabled(isRowSelected);
        }
    }

    function ProccessMapping() {
        var reg = cbRegionMapping.GetValue();
        if ((v_rep_id != "") && (reg != "")) {
            var param = 'Mapping:' + reg + ';' + v_rep_id;
            v_rep_id = ""
            DataView1.UnselectRows();
            cbRegionMapping.SetValue(null);
            DataView1.PerformCallback({ act: param });
        } else {            
            alert("Please select the record And Region")
        }
        popupMappingRegion.Hide();
        v_rep_id = ""
        DataView1.UnselectRows();
        cbRegionMapping.SetValue(null);
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

    table td:nth-child(13) {
        display: none;
    }

    table td:nth-child(14) {
        display: none;
    }

    #grid_rep_DXPEForm_DXEFL_11 {
        display: none;
    }

    #grid_rep_DXPEForm_DXEFL_12 {
        display: none;
    }
</style>

<div class="panel-content">
    <table class="table">
        <tr><td class="title-form" style="text-align: center; font-weight: bold;" colspan="9">:: MASTER REPRESENTATIVE ::</td></tr>
        <tr>
            <td class="cell-month cell-backround">
                @Html.DevExpress().ComboBox(Sub(settings)
                                                settings.Name = "cbregion"
                                                settings.Properties.DataSource = TANABE_MVC.MasterRepresentativeController.CbRegion
                                                settings.Properties.Caption = "Region"
                                                settings.Properties.DropDownWidth = 300
                                                settings.Properties.EnableClientSideAPI = True
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
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnselectall"
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Select All"
                                              settings.ToolTip = "Select All"
                                              settings.UseSubmitBehavior = True
                                              settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                              settings.ClientSideEvents.Click = "function() { DataView1.SelectRows(); btnunselect.SetEnabled(true); }"
                                          End Sub).GetHtml()
            </td>
            <td class="cell-reset cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnselectpage"
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Select Page"
                                              settings.ToolTip = "Select Page"
                                              settings.UseSubmitBehavior = True
                                              settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                              settings.ClientSideEvents.Click = "function() { DataView1.SelectAllRowsOnPage(); btnunselect.SetEnabled(true); }"
                                          End Sub).GetHtml()
            </td>
            <td class="cell-reset cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnunselect"
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Unselect All"
                                              settings.ToolTip = "Unselect All"
                                              settings.UseSubmitBehavior = True
                                              settings.Images.Image.Url = "~/Content/Images/delete.png"
                                              settings.ClientSideEvents.Click = "function() { DataView1.UnselectRows(); btnunselect.SetEnabled(false); }"
                                          End Sub).GetHtml()
            </td>
            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("ExportTo", "MasterRepresentative"))
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
                @Using (Html.BeginForm("ExportTo", "MasterRepresentative"))
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
            @Html.Action("ViewMasterRepresentative", "MasterRepresentative")
        </tr>
    </table>
</div>

@Html.DevExpress.PopupControl(Sub(settings)
                                  settings.Name = "popupMappingRegion"
                                  settings.CloseAction = CloseAction.OuterMouseClick
                                  settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                  settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                  settings.AllowDragging = True
                                  settings.ShowFooter = True
                                  settings.Width = 400
                                  settings.Height = 100
                                  settings.HeaderText = "Mapping Product Sales"
                                  
                                  settings.SetContent(Sub()
                                                          ViewContext.Writer.Write("<table style='width:100%'>")
                                                          ViewContext.Writer.Write("<tr id='row_lookup_doctor'>")
                                                          ViewContext.Writer.Write("<td  style='width:150px;text-align:right;background-color:lightgray;'>Change Region To : </td>")
                                                          ViewContext.Writer.Write("<td>")
                                                          Html.DevExpress().ComboBox(Sub(s)
                                                                                         s.Name = "cbRegionMapping"
                                                                                         s.Properties.DataSource = TANABE_MVC.MasterRepresentativeController.ComboRegion
                                                                                         s.Properties.EnableClientSideAPI = True
                                                                                         s.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                                                         s.Properties.CallbackPageSize = 12
                                                                                         s.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
                                                                                         s.Properties.TextFormatString = "{0}"
                                                                                         s.Properties.ValueField = "reg_id"
                                                                                         s.Properties.TextField = "reg_id"
                                                                                         s.Properties.ValueType = GetType(String)
                                                                                         s.Properties.Columns.Add("reg_id", "Regional", 50)
                                                                                         s.Properties.Columns.Add("reg_functionary_name", "Functionary", 120)
                                                                                     End Sub).BindList(TANABE_MVC.MasterRepresentativeController.ComboRegion).GetHtml()
                                                          ViewContext.Writer.Write("</td>")
                                                          ViewContext.Writer.Write("</tr>")
                                                          ViewContext.Writer.Write("</table>")
                                                      End Sub)
                                  settings.SetFooterTemplateContent(Sub()
                                                                        ViewContext.Writer.Write("<div style='overflow: hidden'><div style='padding: 3px; float: right;'>")
                                                                        Html.DevExpress().Button(Sub(b)
                                                                                                     b.Name = "UpdateButton"
                                                                                                     b.Text = "Submit"
                                                                                                     b.UseSubmitBehavior = True
                                                                                                     b.ClientSideEvents.Click = "ProccessMapping"
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