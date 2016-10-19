@ModelType System.Collections.IEnumerable
@code
    Dim msg As String
    msg = TempData("msg")
End Code
<script type="text/javascript">
    function OnClick(s, e) {
        var val =s.GetMainElement().getAttribute("OutputFormatAttribute")
        $.ajax({
            type: "POST",
            url: '@Url.Action("ExportTo", "visitplan")',
            data: { export_type: val }
        }).done(function () {         

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

   
    @code
       
        If msg <> "" Then
            @Html.DevExpress().PopupControl(Sub(settings)
                                                settings.Name = "PopupControl"
                                                settings.AllowResize = True
                                                settings.ShowHeader = True
                                                settings.ShowOnPageLoad = True
                                                settings.AllowDragging = True
                                                settings.CloseAction = CloseAction.OuterMouseClick
                                                settings.CloseOnEscape = True
                                                settings.Modal = True
                                                settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
                                                settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
                                                settings.SetHeaderTemplateContent(Sub()
                                                                                      ViewContext.Writer.Write("<div style='font-size:small;'>Information</div>")
                                                                                  End Sub)
                                               
                                                settings.SetContent(Sub()
                                                                        ViewContext.Writer.Write(msg)
                                                                    End Sub)
                                                settings.CloseAnimationType = AnimationType.Slide
                                                settings.ShowCloseButton = True
                                                settings.ShowShadow = True
                                                
                                            End Sub).GetHtml()
          
      
        End If
   
    End Code
   

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
                                                  settings.ClientSideEvents.Click = "function(s, e){ popupControl.Show(); }"
                                              End Sub).GetHtml()
                
            </td>
           
@Using (Html.BeginForm("retrieve", "visitplan", method:=FormMethod.Post))

                @:<td class="cell-month cell-backround">
                    @Html.DevExpress().ComboBox(Sub(settings)
                                                    settings.Name = "cbomonth"
                                                    settings.ControlStyle.Font.Size = 7
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



                @:</td>
                @:<td class="cell-year cell-backround">
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



                @:</td>

               @:<td class="cell-retrieve cell-backround">

                   
                        @Html.DevExpress().Button(Sub(settings)
                                                      settings.ControlStyle.Font.Size = 7
                                                      settings.Name = "btnretrieve"
                                                      settings.ControlStyle.CssClass = "button"
                                                      settings.Text = "Retrieve"
                                                      settings.UseSubmitBehavior = True
                                                      settings.Images.Image.Url = "~/Content/Images/retrieve.png"
                                                      settings.ToolTip = "Retrieve"
                                                  End Sub).GetHtml()
                   
               @: </td>
End Using

           

            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("reset", "visitplan", method:=FormMethod.Post))
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnreset"
                                                  settings.ControlStyle.Font.Size = 7
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
                @Using (Html.BeginForm("reqverification", "visitplan", method:=FormMethod.Post))
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnrequest"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Request Verification"
                                                  settings.Images.Image.Url = "~/Content/Images/request.png"
                                                  settings.ToolTip = "Request Verification"
                                                  'settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "function(s, e){ popupControlReq.Show(); }"
                                              End Sub).GetHtml()

                End Using
            </td>
            <td class="cell-reset cell-backround">
                @Using (Html.BeginForm("ExportTo", "visitplan", method:=FormMethod.Post))
                    @Html.DevExpress().Button(Sub(settings)
                                                  settings.Name = "btnexportpdf"
                                                  settings.ControlStyle.Font.Size = 7
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Export to PDF"
                                                  settings.Images.Image.Url = "~/Content/Images/pdf.png"
                                                  settings.ToolTip = "Export to PDF"
                                                  settings.Attributes("OutputFormatAttribute") = "PDF"
                                                  settings.UseSubmitBehavior = True
                                                  settings.ClientSideEvents.Click = "OnClick"
                                              End Sub).GetHtml()

                End Using


            </td>
            <td class="cell-reset cell-backround">
              @Using (Html.BeginForm("ExportTo", "visitplan", method:=FormMethod.Post))
                    @Html.DevExpress().Button(Sub(settings)
                                                       settings.Name = "btnexportexcel"
                                                       settings.ControlStyle.Font.Size = 7
                                                       settings.ControlStyle.CssClass = "button"
                                                       settings.Text = "Export to Excel"
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
            @Html.Action("DataView1Partial", "visitplan")


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

@Html.Partial("~/Views/Visit/Plan/_PopupNewPlanView.vbhtml")
@Html.Partial("~/Views/Visit/Plan/PopUpReqVerification.vbhtml")
@Html.Partial("~/Views/Visit/Plan/InfoDetail.vbhtml")
