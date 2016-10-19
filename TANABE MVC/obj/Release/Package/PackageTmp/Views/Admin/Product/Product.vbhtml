@ModelType System.Collections.IEnumerable
<script type="text/javascript">
    function OnClick(s, e) {
        var param = "export-"+s.GetMainElement().getAttribute("type_file");
        DataView1.PerformCallback({ act: param });      
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
        <tr><td class="title-form">MASTER PRODUCT ASO</td></tr>
        <tr><td class="cell-newlan cell-backround"></td>           
            <td class="cell-month cell-backround"></td>
            <td class="cell-year cell-backround"></td>
            <td class="cell-retrieve cell-backround"></td>
            <td class="cell-reset cell-backround"> </td>           
            <td class="cell-blank"></td>
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
                                                  settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "OnClick"
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
                                                  settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "OnClick"

                                              End Sub).GetHtml()
            </td>
        </tr>
        <tr class="cell-divider"></tr>
        <tr>
            @Html.Action("DataViewPartial", "product")


        </tr>
    </table>
</div>





