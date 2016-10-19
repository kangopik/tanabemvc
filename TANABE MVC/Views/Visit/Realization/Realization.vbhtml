@ModelType System.Collections.IEnumerable
<script type="text/javascript">
    var temp_visit_id;
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



    function gv_CustomButtonClick(s, e) {
        
        if (e.buttonID == "btnRealization") {
            temp_visit_id = s.GetRowKey(e.visibleIndex);
            popupControlRealization.Show();
        }
    }

    function popupControlRealization_Shown(s, e) {
        GridLookup.SetValue(null);
        txtinfo.SetText(null);
        txtsp.SetValue(null);
        spvalue.SetValue(null);
        //grid_visit_plan.PerformCallback(null + ';' + null);
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
        white-space: nowrap;
    }
</style>

<div class="panel-content">
    <table class="table">
        <tr><td class="title-form">VISIT REALIZATION </td></tr>
        <tr>

            <td class="cell-newlan cell-backround">

                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btnadditional"
                                              settings.ControlStyle.Font.Size = 7
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Additional Visit"
                                              settings.ControlStyle.CssClass = "distance-left"
                                              settings.Images.Image.Url = "~/Content/Images/plus.png"
                                              settings.ToolTip = "Additional Visit"
                                              settings.ClientSideEvents.Click = "function(s, e){ popupControlAdditionalVisit.Show(); }"
                                          End Sub).GetHtml()

            </td>

            <td class="cell-newlan cell-backround">

                @Html.DevExpress().Button(Sub(settings)
                                              settings.Name = "btncancellation"
                                              settings.ControlStyle.Font.Size = 7
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Cancellation"
                                              settings.ControlStyle.CssClass = "distance-left"
                                              settings.Images.Image.Url = "~/Content/Images/cancel.png"
                                              settings.ToolTip = "Cancellation"
                                              settings.ClientSideEvents.Click = "function(s, e){ popupControlCancellation.Show();}"
                                          End Sub).GetHtml()

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
                                                    settings.Width = 120
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
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.ClientSideEvents.Click = "do_reset"
                                              End Sub).GetHtml()

            </td>
            <td class="cell-blank"></td>
            
            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("ExportTo", "visitrealization", method:=FormMethod.Post))
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnexportpdf"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Export to PDF"
                                                  settings.Images.Image.Url = "~/Content/Images/pdf.png"
                                                  settings.ToolTip = "Export to PDF"
                                                  settings.Attributes("type_file") = "PDF"
                                                  settings.ClientSideEvents.Click = "do_export"
                                                 
                                                  settings.ControlStyle.Font.Size = 7
                                              End Sub).GetHtml()

                End Using


            </td>
            <td class="cell-reset cell-backround">
               
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnexportexcel"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Export to Excel"
                                                  settings.Images.Image.Url = "~/Content/Images/excel.png"
                                                  settings.ToolTip = "Export to Excel"
                                                  settings.ControlStyle.CssClass = "distance-right"
                                                  settings.Attributes("type_file") = "XLS"
                                                  settings.ClientSideEvents.Click = "do_export"
                                                  settings.ControlStyle.Font.Size = 7
                                              End Sub).GetHtml()

            
            </td>

        </tr>
        <tr class="cell-divider"></tr>
        <tr>
            @Html.Action("DataViewPartial", "visitrealization")


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



</script>

@Html.Partial("~/Views/Visit/Realization/PopupRealization.vbhtml")
@Html.Partial("~/Views/Visit/Realization/PopupAdditionalVisit.vbhtml")
@Html.Partial("~/Views/Visit/Realization/PopupCancellation.vbhtml")



