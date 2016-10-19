@ModelType System.Collections.IEnumerable

<script type="text/javascript">
    function OnExport(s, e) {
        var actionParams = $("form").attr("action").split("?OutputFormat=");
        actionParams[1] = s.GetMainElement().getAttribute("OutputFormatAttribute");
        $("form").attr("action", actionParams.join("?OutputFormat="));
    }

    function DataView1_EndCallBack(s, e) {
        if (s.cpMessage != "undefined") {
            alert(s.cpMessage);
            s.cpMessage = "undefined";
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
        <tr><td class="title-form" style="text-align: center; font-weight: bold;" colspan="3">:: MASTER SBO ::</td></tr>
        <tr>
            <td class="cell-blank"></td>
            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("ExportTo", "MasterSbo"))
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
                @Using (Html.BeginForm("ExportTo", "MasterSbo"))
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
            @Html.Action("ViewMasterSBO", "MasterSbo")
        </tr>
    </table>
</div>

