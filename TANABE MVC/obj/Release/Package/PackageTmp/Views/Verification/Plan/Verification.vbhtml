@ModelType System.Collections.IEnumerable
<script type="text/javascript">
    var v_visit_id;
    function OnClick(s, e) {
        var val =s.GetMainElement().getAttribute("OutputFormatAttribute")
        $.ajax({
            type: "POST",
            url: '@Url.Action("ExportTo", "vervisitplan")',
            data: { export_type: val }
        }).done(function () {

        });

    }
    function SelectAllRows() {        
        DataView1.SelectRows();
    }

    function SelectPage() {
        
        DataView1.SelectRows();
    }

    function UnselectRows() {
        DataView1.UnselectRows();
    }
   
    function VerifyPartial(s, e) {
        VerifyPopupControl.Show();
        v_visit_id = s.GetMainElement().getAttribute("v_visit_id")
    }

    function ProccessVerifyPartial() {
        VerifyPopupControl.Hide();
       
       
            if (v_visit_id != "") {
                $.ajax({
                    type: "POST",
                    url: '@Url.Action("verifypartial", "vervisitplan")',
                    data: { visit_id: v_visit_id }
                }).done(function () {
                    
                    window.location.reload();
                });
            }
       
    }

    function CancelVerifyPartial() {
        VerifyPopupControl.Hide();
       
            $.ajax({
                type: "POST",
                url: '@Url.Action("cancelverifypartial", "vervisitplan")'               
            }).done(function () {
                window.location.reload();
            });
       
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
        <tr><td class="title-form">VERIFICATION VISIT PLAN </td></tr>
        <tr>


@Using (Html.BeginForm("retrieve", "vervisitplan", method:=FormMethod.Post))
            @:<td class="cell-newlan cell-backround distance-left">

                @Html.Action("GridLookupPartial", "vervisitplan")


            @:</td>

           

                @:<td class="cell-month cell-backround">
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
                                                         settings.Width = 100
                                                         settings.Height = 27
                                                     End Sub).GetHtml()



                    @: </td>
                @:<td class="cell-year cell-backround">
                    @Html.DevExpress().SpinEdit(Sub(settings)
                                                         settings.Name = "cboyear"
                                                         settings.Properties.Caption = "Year"
                                                         settings.Properties.MinValue = "2015"
                                                         settings.Properties.MaxValue = "2100"
                                                         settings.Number = DateTime.Now.Year
                                                         settings.Width = 80
                                                         settings.Height = 27
                                                     End Sub).GetHtml()
                    @:</td>




                @:<td class="cell-retrieve cell-backround">


                    @Html.DevExpress().Button(Sub(settings)
                                                       settings.Name = "btnretrieve"
                                                       settings.ControlStyle.CssClass = "button"
                                                       settings.Text = "Retrieve"
                                                       settings.UseSubmitBehavior = True
                                                       settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                                       settings.ToolTip = "Retrieve"
                                                   End Sub).GetHtml()

                    @:</td>
End Using



            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("reset", "vervisitplan", method:=FormMethod.Post))
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnreset"
                                                  settings.UseSubmitBehavior = True
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Reset"
                                                  settings.Images.Image.Url = "~/Content/Images/reset.png"
                                                  settings.ToolTip = "Reset"
                                              End Sub).GetHtml()

                End Using
            </td>
            <td class="cell-blank"></td>






            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("ExportTo", "vervisitplan", method:=FormMethod.Post))
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnverify"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Verify"
                                                  settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                                  settings.ToolTip = "Verify selected row(s)"
                                                  'settings.Attributes("OutputFormatAttribute") = "PDF"
                                                  settings.UseSubmitBehavior = True
                                                  'settings.ClientSideEvents.Click = "OnClick"
                                              End Sub).GetHtml()

                End Using


            </td>
            <td class="cell-reset cell-backround">               
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnselectallrow"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Row"
                                                  settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                                  settings.ToolTip = "Select all rows"
                                                  settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "SelectAllRows"
                                              End Sub).GetHtml()

              

            </td>
            <td class="cell-reset cell-backround">
               
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnselectpage"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Page"
                                                  settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                                  settings.ToolTip = "Select page"
                                                  settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "SelectPage"
                                              End Sub).GetHtml()

               


            </td>
            <td class="cell-reset cell-backround">
               
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnunselectall"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Unselect"
                                                  settings.Images.Image.Url = "~/Content/Images/unselect.png"
                                                  settings.ToolTip = "Unselect all"
                                                  settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "UnselectRows"
                                              End Sub).GetHtml()

               


            </td>









            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("ExportTo", "vervisitplan", method:=FormMethod.Post))
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnexportpdf"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "PDF"
                                                  settings.Images.Image.Url = "~/Content/Images/pdf.png"
                                                  settings.ToolTip = "Export to PDF"
                                                  settings.Attributes("OutputFormatAttribute") = "PDF"
                                                  settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "OnClick"
                                              End Sub).GetHtml()

                End Using


            </td>
            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("ExportTo", "vervisitplan", method:=FormMethod.Post))
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnexportexcel"
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Excel"
                                                  settings.Images.Image.Url = "~/Content/Images/excel.png"
                                                  settings.ToolTip = "Export to Excel"
                                                  settings.ControlStyle.CssClass = "distance-right"

                                                  settings.Attributes("OutputFormatAttribute") = "XLS"
                                                  settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "OnClick"


                                              End Sub).GetHtml()

                End Using
            </td>

        </tr>
        <tr class="cell-divider"></tr>
        <tr>
            @Html.Action("DataViewPartial", "vervisitplan")


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
    
    function CloseGridLookup() {
        GridLookup.ConfirmCurrentSelection();
        GridLookup.HideDropDown();
        GridLookup.Focus();
    }


</script>

@Html.DevExpress().PopupControl(Sub(settings)
                                    settings.Name = "VerifyPopupControl"
                                    settings.AllowResize = True
                                    settings.ShowHeader = True
                                    settings.ShowOnPageLoad = False
                                    settings.AllowDragging = True
                                    settings.CloseAction = CloseAction.CloseButton
                                    settings.CloseOnEscape = False
                                    settings.Modal = True
                                    settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                    settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                    settings.SetHeaderTemplateContent(Sub()
                                                                          ViewContext.Writer.Write("<div style='font-size:small;'>Confirmation</div>")
                                                                      End Sub)

                                    settings.SetContent(Sub()
                                                            Dim msg As String = TANABE_MVC.GlobalClass.temp_ver_visit_plan_visit_id
                                                            
                                                            ViewContext.Writer.Write("Do you really want to verify  " & msg & " ?")
                                                            
                                                          
                                                            ViewContext.Writer.Write("</br></br>")
                                                            ViewContext.Writer.Write("<div style='overflow: hidden'><div style='padding: 3px; float: right;'>")
                                                            Html.DevExpress().Button(Sub(btnno)
                                                                                         btnno.Name = "btnno"
                                                                                         btnno.Text = "No"
                                                                                         btnno.UseSubmitBehavior = True
                                                                                         btnno.ClientSideEvents.Click = "CancelVerifyPartial"
                                                                                     End Sub).GetHtml()
                                                            ViewContext.Writer.Write(" &nbsp; &nbsp;")
                                                           
                                                            Html.DevExpress().Button(Sub(btnyes)
                                                                                         btnyes.Name = "btnyes"
                                                                                         btnyes.Text = "Yes"
                                                                                         btnyes.UseSubmitBehavior = True
                                                                                         btnyes.ClientSideEvents.Click = "ProccessVerifyPartial"
                                                                                     End Sub).GetHtml()
                                                            ViewContext.Writer.Write("</div></div>")
                                                            
                                                        End Sub)
                                End Sub).GetHtml()












