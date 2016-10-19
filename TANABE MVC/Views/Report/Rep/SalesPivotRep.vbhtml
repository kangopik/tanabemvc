@ModelType System.Collections.IEnumerable
<script type="text/javascript">

    function do_export(s, e) {
        var param = "export;" + s.GetMainElement().getAttribute("type_file");
        SalesPivotRep.PerformCallback({ prm: param });
    }

    function do_retrieve(s, e) {
        var monthStart = cbMonthStart.GetValue();
        var monthEnd = cbMonthEnd.GetValue();
        var year = cbYear.GetValue();
        var param = 'retrieve;' + monthStart + ';' + monthEnd + ';' + year;
        SalesPivotRep.PerformCallback({ prm: param });
        return false;
    }

    function do_reset(s, e) {
        cbMonthStart.SetValue(null);
        cbMonthEnd.SetValue(null);
        cbYear.SetValue(null);
        var param = 'reset;' + null + ';' + null + ';' + null;
        SalesPivotRep.PerformCallback({ prm: param });
        return false;
    } 
    
    Date.prototype.getMonthName = function() {return this.monthNames[this.getMonth()];};

 
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
        <tr><td class="title-form">SALES PIVOT</td></tr>
        <tr>

            <td class="cell-month cell-backround">
               @Html.DevExpress().ComboBox(Sub(settings)
                                               settings.Name = "cbMonthStart"
                                               settings.ControlStyle.Font.Size = 7
                                               settings.Properties.Caption = "Month Start"
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
                                               settings.ToolTip = "Month Start"
                                           End Sub).GetHtml()
            </td>

            <td class="cell-year cell-backround">
                @Html.DevExpress().ComboBox(Sub(settings)
                                                settings.Name = "cbMonthEnd"
                                                settings.ControlStyle.Font.Size = 7
                                                settings.Properties.Caption = "Month End"
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
                                                settings.ToolTip = "Month End"
                                            End Sub).GetHtml()
            </td>
            <td class="cell-retrieve cell-backround">
                @Html.DevExpress().SpinEdit(Sub(settings)
                                                settings.Name = "cbYear"
                                                settings.ControlStyle.Font.Size = 7
                                                settings.Properties.Caption = "Year"
                                                settings.Properties.MinValue = "2014"
                                                settings.Properties.MaxValue = "2100"
                                                settings.Number = DateTime.Now.Year
                                                settings.Width = 80
                                                settings.Height = 27
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
                                                  settings.Attributes("type_file") = "XLS"
                                                  settings.ClientSideEvents.Click = "do_export"
                                              End Sub).GetHtml()

             
            </td>

        </tr>
        <tr class="cell-divider"></tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td style="padding-top:0px;vertical-align:top;">
                @Html.Action("SalesPivotRepPartialView", Model)
                @*@Html.Action("VisitOnlyPivotRepPartialView", "rptVisitOnlyPivotRep")*@
            </td>
            <td style="width:250px">
                @Html.DevExpress().PivotCustomizationExtension(TANABE_MVC.PivotGridLayout.SalesPivotRepGridSettings).GetHtml()
                @*@Html.Partial("~/Views/Report/Rep/SalesPivotCustomizationPartialView.vbhtml")*@
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



