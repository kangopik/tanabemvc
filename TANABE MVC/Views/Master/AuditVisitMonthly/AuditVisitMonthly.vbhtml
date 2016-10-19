@ModelType System.Collections.IEnumerable

<script type="text/javascript">
    function OnExport(s, e) {
        var actionParams = $("form").attr("action").split("?OutputFormat=");
        actionParams[1] = s.GetMainElement().getAttribute("OutputFormatAttribute");
        $("form").attr("action", actionParams.join("?OutputFormat="));
    }

    function do_retrieve(s, e) {
        var month = cbomonth.GetValue();
        var year = cboyear.GetValue();
        var params = 'retrieve;' + month + ';' + year;
        DataView1.PerformCallback({ act: params });
    }

    Date.prototype.getMonthName = function () { return this.monthNames[this.getMonth()]; };

    function do_reset(s, e) {
        Date.prototype.monthNames = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        var d = new Date();
        cbomonth.SetValue(d.getMonthName());
        cboyear.SetValue(d.getFullYear());
        DataView1.PerformCallback({ act: 'reset' });
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
        <tr><td class="title-form">VISIT PLAN </td></tr>
        <tr>
               <td class="cell-month cell-backround">
                    @Html.DevExpress().ComboBox(Sub(settings)
                                                         settings.Name = "cbomonth"
                                                         settings.Properties.Caption = "Month"
                                                         settings.Properties.Items.Add("January")
                                                         settings.Properties.Items.Add("February")
                                                         settings.Properties.Items.Add("March")
                                                         settings.Properties.Items.Add("April")
                                                         settings.Properties.Items.Add("May")
                                                         settings.Properties.Items.Add("June")
                                                         settings.Properties.Items.Add("July")
                                                         settings.Properties.Items.Add("August")
                                                         settings.Properties.Items.Add("September")
                                                         settings.Properties.Items.Add("October")
                                                         settings.Properties.Items.Add("November")
                                                         settings.Properties.Items.Add("December")
                                                         settings.Properties.CaptionSettings.Position = EditorCaptionPosition.Left
                                                         settings.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                         settings.SelectedIndex = DateTime.Now.Month - 1
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
                                                         settings.Number = DateTime.Now.Year
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
                @Using (Html.BeginForm("ExportTo", "AuditVisitMonthly"))
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
                @Using (Html.BeginForm("ExportTo", "AuditVisitMonthly"))
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
            @Html.Action("ViewAuditVisitMonthly", "AuditVisitMonthly")
        </tr>
    </table>
</div>

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