@ModelType System.Collections.IEnumerable
<script type="text/javascript">
    function do_export(s, e) {
        var param = "export;" + s.GetMainElement().getAttribute("type_file");
        DataView1.PerformCallback({ prm: param });
    }

    function do_retrieve(s, e) {
        var month = cbomonth.GetValue();
        var year = cboyear.GetValue();
        var param = 'retrieve;' + month + ';' + year;
        DataView1.PerformCallback({ prm: param });
    }

    function do_reset(s, e) {
        Date.prototype.monthNames = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        var d = new Date();
        cbomonth.SetValue(d.getMonthName());
        cboyear.SetValue(d.getFullYear());
        DataView1.PerformCallback({ prm: 'reset' });
    }

    Date.prototype.getMonthName = function () { return this.monthNames[this.getMonth()]; };

    function monthly_select(s, e) {
        var month = cbomonthReq.GetValue();
        var d = new Date();
        var year = d.getFullYear();
        var param = 'retrieve;' + month + ';' + year;
        DataView1.PerformCallback({ prm: param });
    }

    function reqverification() {
        //popupControlReq.Hide();
        var vmonth_req = cbomonthReq.GetValue();
        var SumCollection = DataView1.cpRequestSendFeedback
        var param = "request;" + vmonth_req + ";" + SumCollection;
        DataView1.PerformCallback({ prm: param });
    }

    function selected_doctors(s, e) {

        var i = s.GetSelectedRowCount();

        lblSelected.SetText('You have selected ' + i + ' doctors');
        //var index = s.GetFocusedRowIndex();
        //var drcode = s.GetRowKey(index);
        //if ( i > 1) {
        //    if (drcode < 100005) {
        //        alert('Leave code can not be paired with a doctor code');
        //        s.UnselectRows(e.visibleIndex);
        //    }
        //}
        //if (i > 11) {
        //    alert('You are only allowed to choose 11 doctors.');
        //        s.UnselectRows(e.visibleIndex);

        //}

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

            <td class="cell-newlan cell-backround">

                @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnnewplan"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Add New Plan"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.ControlStyle.CssClass = "distance-left"
                                                  settings.Images.Image.Url = "~/Content/Images/plus.png"
                                                  settings.ToolTip = "Add New Plan"
                                                  settings.ClientSideEvents.Click = "function(s, e){ popupControl.PerformCallback();popupControl.Show(); }"
                                              End Sub).GetHtml()

            </td>

            <td class="cell-month cell-backround">
                @Html.DevExpress().ComboBox(Sub(settings)
                                                    settings.Name = "cbomonth"
                                                    settings.ControlStyle.Font.Size = 7
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
                                                End Sub).GetHtml()



            </td>
            <td class="cell-year cell-backround">
                @Html.DevExpress().SpinEdit(Sub(settings)
                                                    settings.Name = "cboyear"
                                                    settings.ControlStyle.Font.Size = 7
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
                                                      settings.ControlStyle.Font.Size = 7
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
                                                  settings.ControlStyle.Font.Size = 7
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
                                                  settings.Name = "btnrequest"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Request Verification"
                                                  settings.Images.Image.Url = "~/Content/Images/request.png"
                                                  settings.ToolTip = "Request Verification"
                                                  settings.ClientSideEvents.Click = "function(s, e){ popupControlReq.Show(); }"
                                              End Sub).GetHtml()


            </td>
            <td class="cell-reset cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnexportpdf"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Export to PDF"
                                                  settings.Images.Image.Url = "~/Content/Images/pdf.png"
                                                  settings.ToolTip = "Export to PDF"
                                                  settings.Attributes("type_file") = "PDF"
                                                  settings.ClientSideEvents.Click = "do_export"
                                              End Sub).GetHtml()


            </td>
            <td class="cell-reset cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnexportexcel"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Export to Excel"
                                                  settings.Images.Image.Url = "~/Content/Images/excel.png"
                                                  settings.ToolTip = "Export to Excel"
                                                  settings.ControlStyle.CssClass = "distance-right"
                                                  settings.Attributes("type_file") = "XLS"
                                                  settings.ClientSideEvents.Click = "do_export"
                                              End Sub).GetHtml()


            </td>

        </tr>
        <tr class="cell-divider"></tr>
        <tr>
            @Html.Action("DataViewPartial", "visitplan")


        </tr>
    </table>
</div>



<script type="text/javascript">

    var callbackInitDate;
    var command;

    function OnStartCallback(s, e) {
        callbackInitDate = new Date();
        command = e.command;
        //alert(s.cpRequestSendFeedback);
    }
    function OnEndCallback(s, e) {
        var currentDate = new Date();
        var time = currentDate - callbackInitDate;
        if (s.cpRequestFeedback != 'undefined') {
            if (s.cpRequestFeedback == 'success_send') {
                popupControlReq.Hide();
                alert("Request has been sent");
                s.cpRequestFeedback = 'undefined'
            } else if (s.cpRequestFeedback == 'error_send') {
                popupControlReq.Hide();
                alert("Cannot send request, because you still have some doctors who has not planned yet");
                s.cpRequestFeedback = 'undefined'
            } else if (s.cpRequestFeedback == 'send_limitation') {
                popupControlReq.Hide();
                alert("verification plan request is limited to 3 times per month");
                s.cpRequestFeedback = 'undefined'
            } else if (s.cpRequestFeedback == 'less_doctor') {
                popupControlReq.Hide();
                alert("Cannot send request, you still have one day less than minimum visits");
                s.cpRequestFeedback = 'undefined'
            } else if (s.cpRequestFeedback == 'prev_month_unverificated_real') {
                popupControlReq.Hide();
                alert("You still have some doctors are tied to the realization visit in the previous month that has not been verified by your Manager");
                s.cpRequestFeedback = 'undefined'
            }
        }
    }

    function msg_error() {
        PopupControl.PerformCallback();
        PopupControl.Show();
    }

</script>

@Html.Partial("~/Views/Visit/Plan/PopupNewPlanView.vbhtml")
@Html.Partial("~/Views/Visit/Plan/PopUpReqVerification.vbhtml")
@Html.Partial("~/Views/Visit/Plan/InfoDetail.vbhtml")

