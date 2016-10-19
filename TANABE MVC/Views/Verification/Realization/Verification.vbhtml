@ModelType System.Collections.IEnumerable
<script type="text/javascript">
    var v_visit_id;
    var v_verify;
    var v_arr_visit_id;
    var v_rep_position;

    function SelectAllRows() {
        v_verify = 1;
        DataView1.SelectRows();
        btnunselectall.SetEnabled(true);
        btnverify.SetEnabled(true);
        btnselectallrow.SetEnabled(true);
        btnselectpage.SetEnabled(true);
    }

    function SelectPage() {
        v_verify = 2;
        DataView1.SelectAllRowsOnPage();
        btnunselectall.SetEnabled(true);
        btnverify.SetEnabled(true);
        btnselectallrow.SetEnabled(true);
        btnselectpage.SetEnabled(true);

    }

    function UnselectRows() {
        v_verify = 0;
        DataView1.UnselectRows();
        btnunselectall.SetEnabled(false);
        btnverify.SetEnabled(false);
        btnselectallrow.SetEnabled(true);
        btnselectpage.SetEnabled(true);
    }

    function VerifyAllData(s, e) {
        //VerifyPopupControl.Show();
        var visit_id = v_arr_visit_id;
        var param = 'verify;' + null + ';' + null + ';' + null + ';' + visit_id;
        if (confirm("Are you sure want to verify selected realizations ?") == true) {
            DataView1.PerformCallback({ prm: param });
        }
    }
    function OnSelectionChanged(s, e) {
        var i = s.GetSelectedRowCount();
        if (i == 0) {
            btnverify.SetEnabled(false);
            btnunselectall.SetEnabled(false);
        } else {
            btnverify.SetEnabled(true);
            btnunselectall.SetEnabled(true);
        }

        s.GetSelectedFieldValues("visit_id", GetSelectedFieldValuesCallback);

    }

    function GetSelectedFieldValuesCallback(values) {
        v_arr_visit_id = values;
    }

    function do_export(s, e) {
        var param = "export;" + s.GetMainElement().getAttribute("type_file");
        DataView1.PerformCallback({ prm: param });
    }

    function do_retrieve(s, e) {
        if (v_rep_position == null) return;
        var month = cbomonth.GetValue();
        if (month == null || month == '') {
            alert('Please choose month periode');
            return false;
        }
        var year = cboyear.GetValue();
        var rep = GridLookup.GetValue();
        if (rep == null || rep == '') {
            alert('Please choose your subordinat representative');
            return false;
        }
        var param = 'retrieve;' + rep + ';' + +month + ';' + year;
        DataView1.PerformCallback({ prm: param });
    }

    function do_reset(s, e) {
        GridLookup.SetValue(null);
        Date.prototype.monthNames = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        var d = new Date();
        cbomonth.SetValue(null);
        cboyear.SetValue(d.getFullYear());
        btnunselectall.SetEnabled(false);
        btnverify.SetEnabled(false);
        btnselectallrow.SetEnabled(false);
        btnselectpage.SetEnabled(false);
        DataView1.PerformCallback({ prm: 'reset' });
    }


    Date.prototype.getMonthName = function () { return this.monthNames[this.getMonth()]; };

    function OnGetSelectionButtonClick(s, e) {
        var grid = s.GetGridView();
        grid.GetRowValues(grid.GetFocusedRowIndex(), 'rep_position', OnGetRowValues);
    }

    function OnGetRowValues(values) {
        v_rep_position = "";
        if (values[0].trim() == null) return;
        v_rep_position = values[0].trim() + values[1].trim() + values[2].trim();
    }

    function verify_Grid(s, e) {
        var visit_id = s.GetMainElement().getAttribute("v_visit_id");
        var param = 'verify_by_one;' + null + ';' + null + ';' + null + ';' + visit_id;
        if (confirm("Are you sure want to verify this realization visit with code " + visit_id + " ?") == true) {
            DataView1.PerformCallback({ prm: param });
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
        <tr><td class="title-form" colspan="12">VERIFICATION VISIT REALIZATION </td></tr>
        <tr>



            <td class="cell-newlan cell-backround distance-left">

                @Html.Action("GridLookupPartial", "VerVisitReal")


            </td>



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
                                                    settings.Width = 100
                                                    settings.Height = 27
                                                    settings.ControlStyle.Font.Size = 7
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
                                                    settings.ControlStyle.Font.Size = 7
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
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.Height = 27
                                              End Sub).GetHtml()

            </td>




            <td class="cell-reset cell-backround">

                @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnreset"
                                                  settings.ClientSideEvents.Click = "do_reset"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Reset"
                                                  settings.Images.Image.Url = "~/Content/Images/reset.png"
                                                  settings.ToolTip = "Reset"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.Height = 27
                                              End Sub).GetHtml()


            </td>
            <td class="cell-blank"></td>

                <td class="cell-reset cell-backround">

                @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnverify"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Verify"
                                                  settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                                  settings.ToolTip = "Verify selected row(s)"
                                                  settings.ClientSideEvents.Click = "VerifyAllData"
                                                  settings.Height = 27
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.ClientEnabled = False
                                              End Sub).GetHtml()




            </td>
            <td class="cell-reset cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnselectallrow"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Select Rows"
                                                  settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                                  settings.ToolTip = "Select all rows"
                                                  settings.Height = 27
                                                  settings.ClientSideEvents.Click = "SelectAllRows"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.ClientEnabled = False
                                              End Sub).GetHtml()



            </td>
            <td class="cell-reset cell-backround">

                @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnselectpage"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Select Page"
                                                  settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                                  settings.ToolTip = "Select page"
                                                  settings.Height = 27
                                                  settings.ClientSideEvents.Click = "SelectPage"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.ClientEnabled = False
                                              End Sub).GetHtml()




            </td>
            <td class="cell-reset cell-backround">

                @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnunselectall"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Unselect"
                                                  settings.Images.Image.Url = "~/Content/Images/unselect.png"
                                                  settings.ToolTip = "Unselect all"
                                                  settings.Height = 27
                                                  settings.ClientSideEvents.Click = "UnselectRows"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.ClientEnabled = False
                                              End Sub).GetHtml()




            </td>

            <td class="cell-reset cell-backround">

                @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnexportpdf"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "PDF"
                                                  settings.Images.Image.Url = "~/Content/Images/pdf.png"
                                                  settings.ToolTip = "Export to PDF"
                                                  settings.Attributes("type_file") = "PDF"
                                                  settings.ClientSideEvents.Click = "do_export"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.Height = 27
                                              End Sub).GetHtml()




            </td>
            <td class="cell-reset cell-backround">

                @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnexportexcel"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Excel"
                                                  settings.Images.Image.Url = "~/Content/Images/excel.png"
                                                  settings.ToolTip = "Export to Excel"
                                                  settings.ControlStyle.CssClass = "distance-right"
                                                  settings.Attributes("type_file") = "XLS"
                                                  settings.ClientSideEvents.Click = "do_export"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.Height = 27
                                              End Sub).GetHtml()


            </td>

        </tr>
        <tr class="cell-divider"></tr>
        <tr>
            @Html.Action("DataViewPartial", "VerVisitReal")


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
        if (s.cpVerifyFeedback != 'undefined') {
            if (s.cpVerifyFeedback == 'success_verify') {
                alert('Visit realization have been verified');
                s.cpVerifyFeedback = "undefined";
            } else if (s.cpVerifyFeedback == 'error_verify') {
                alert('Visit realization verification failed');
                s.cpVerifyFeedback = "undefined";
            } else if (s.cpVerifyFeedback == 'no_record') {
                alert('There is no record for filled criteria');
                btnunselectall.SetEnabled(false);
                btnverify.SetEnabled(false);
                btnselectallrow.SetEnabled(false);
                btnselectpage.SetEnabled(false);
                s.cpVerifyFeedback = "undefined";
            } else if (s.cpVerifyFeedback == 'record_exists') {
                btnunselectall.SetEnabled(false);
                btnverify.SetEnabled(false);
                btnselectallrow.SetEnabled(true);
                btnselectpage.SetEnabled(true);
                s.cpVerifyFeedback = "undefined";
            }

        }
    }

    function CloseGridLookup() {
        GridLookup.ConfirmCurrentSelection();
        GridLookup.HideDropDown();
        GridLookup.Focus();
    }


</script>



