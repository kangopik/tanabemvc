@ModelType System.Collections.IEnumerable
<script type="text/javascript">

    function do_export(s, e) {
        var param = "export;" + s.GetMainElement().getAttribute("type_file");
        VisitOnlyPivotRep.PerformCallback({ act: param });
    }

    function do_retrieve(s, e) {
        //var jsDate = dateEdit.GetDate();
        var jsDateStart = dateStart.GetDate();
        var yearStart = jsDateStart.getFullYear(); // where getFullYear returns the year (four digits)
        var monthStart = jsDateStart.getMonth() + 1; // where getMonth returns the month (from 0-11)
        var dayStart = jsDateStart.getDate();   // where getDate returns the day of the month (from 1-31)

        var jsDateEnd = dateEnd.GetDate();
        var yearEnd = jsDateEnd.getFullYear(); // where getFullYear returns the year (four digits)
        var monthEnd = jsDateEnd.getMonth() + 1; // where getMonth returns the month (from 0-11)
        var dayEnd = jsDateEnd.getDate();   // where getDate returns the day of the month (from 1-31)

        var DateStart = yearStart + '-' + monthStart + '-' + dayStart;
        var DateEnd = yearEnd + '-' + monthEnd + '-' + dayEnd;
        var param = 'retrieve;' + DateStart + ';' + DateEnd;
        VisitOnlyPivotRep.PerformCallback({ act: param });
        return false;
    }

    function do_reset(s, e) {
        dateStart.SetValue(null);
        dateEnd.SetValue(null);
        var param = 'reset;' + null + ';' + null;
        VisitOnlyPivotRep.PerformCallback({ act: param });
        return false;
    } 
    
    Date.prototype.getMonthName = function() {return this.monthNames[this.getMonth()];};

    function monthly_select(s, e) {
        var month = cbomonthReq.GetValue();
        var d = new Date();
        var year = d.getFullYear();      
        var param = 'retrieve-' + month + '-' + year;
        DataView1.PerformCallback({ act: param });
    }

    function reqverification() {
        popupControlReq.Hide();
        var vmonth_req = cbomonthReq.GetValue();      
        var param = "request-" + vmonth_req;
        DataView1.PerformCallback({ act: param });
    }

   
</script>

<style type="text/css">
    .table {
        width:100%;
        padding-right: 5px;
        /*border:1px solid red;*/
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
        <tr><td class="title-form">VISIT ONLY PIVOT</td></tr>
        <tr>

            <td class="cell-month cell-backround">
                @Html.DevExpress().DateEdit(
                    Sub(settings)
                            settings.Name = "dateStart"
                            settings.Properties.NullText = "Date Start"
                    End Sub).GetHtml()
            </td>

            <td class="cell-year cell-backround">
                @Html.DevExpress().DateEdit(
                    Sub(settings)
                            settings.Name = "dateEnd"
                            settings.Properties.NullText = "Date End"
                    End Sub).GetHtml()
            </td>

            <td class="cell-retrieve cell-backround">
                @Html.DevExpress().Button(Sub(settings)
                                              'settings.ControlStyle.Font.Size = 7
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
                                                  'settings.ControlStyle.Font.Size = 7
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Reset"
                                                  settings.Images.Image.Url = "~/Content/Images/reset.png"
                                                  settings.ToolTip = "Reset"
                                                  settings.ClientSideEvents.Click = "do_reset"
                                              End Sub).GetHtml()

             
            </td>
            <td class="cell-blank"></td>
            <td class="cell-blank"></td>
            <td class="cell-reset cell-backround">
              
            </td>
            <td class="cell-reset cell-backround"></td>
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
                                              settings.Name = "btnexportrowdata"
                                              settings.ControlStyle.Font.Size = 7
                                              settings.ControlStyle.CssClass = "button"
                                              settings.Text = "Export Row Data"
                                              settings.Images.Image.Url = "~/Content/Images/excel.png"
                                              settings.ToolTip = "Export Row Data"
                                              settings.Attributes("type_file") = "ROWDATA"
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
                                                  settings.Attributes("type_file") = "XLSX"
                                                  settings.ClientSideEvents.Click = "do_export"
                                              End Sub).GetHtml()

             
            </td>

        </tr>
        <tr class="cell-divider"></tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="padding-top:0px;vertical-align:top;">
                @Html.Action("VisitOnlyPivotRepPartialView", Model)
                @*@Html.Action("VisitOnlyPivotRepPartialView", "rptVisitOnlyPivotRep")*@
            </td>
            <td style="width:250px">
                @Html.DevExpress().PivotCustomizationExtension(TANABE_MVC.PivotGridLayout.VisitOnlyPivotGridSettings).GetHtml()
            </td>
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

    function msg_error(){
        PopupControl.PerformCallback();
        PopupControl.Show();
    }

</script>



