@ModelType System.Collections.IEnumerable
<script type="text/javascript">
    function tab_selected(s, e) {
        var index = s.GetActiveTabIndex();
        if (index == 0) {
            btnCancel.SetVisible(true);
            btnSubmit.SetVisible(true);
        } else {
            btnCancel.SetVisible(false);
            btnSubmit.SetVisible(false);
        }
            
    }

   
    function do_retrieve(s, e) {        
        var day=cboday.GetValue();
        var month =cbomonth.GetValue();
        var year = cboyear.GetValue();
        var param = 'retrieve-' + day + '-' + month + '-' + year;
        DataView1.PerformCallback({act:param});
    }
    function OnEdit(s,e) {
        var dr_code = s.GetMainElement().getAttribute("dr_code");
        var visit_id = s.GetMainElement().getAttribute("visit_id");

        var visited = s.GetMainElement().getAttribute("visited");
        var info = s.GetMainElement().getAttribute("info");
        var sp = s.GetMainElement().getAttribute("sp");
        var sp_value = s.GetMainElement().getAttribute("sp_value");

        var param = dr_code + "-" + visit_id + "-" + visited + "-" + info + "-" + sp + "-" + sp_value;
        popupControlEdit.PerformCallback({ act: param });
        popupControlEdit.Show();              
    }

    function do_reset(s, e) {
        Date.prototype.monthNames = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
        var d = new Date();
        cbomonth.SetValue(d.getMonthName());
        cboyear.SetValue(d.getFullYear());
        DataView1.PerformCallback({ act: 'reset' });
    }

    Date.prototype.getMonthName = function () { return this.monthNames[this.getMonth()]; };

    function do_export(s, e) {
        var param = "export-" + s.GetMainElement().getAttribute("type_file");
        DataView1.PerformCallback({ act: param });
    }



    var textSeparator = ",";
    function OnListBoxSelectionChanged(listBox, args) {
        //if (args.index == 0)
        //    args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
        //UpdateSelectAllItemState();
        UpdateText();
    }
    function UpdateSelectAllItemState() {
        IsAllSelected() ? checkListBox.SelectIndices([0]) : checkListBox.UnselectIndices([0]);
    }
    function IsAllSelected() {
        var selectedDataItemCount = checkListBox.GetItemCount() - (checkListBox.GetItem(0).selected ? 0 : 1);
        return checkListBox.GetSelectedItems().length == selectedDataItemCount;
    }
    function UpdateText() {
        var selectedItems = checkListBox.GetSelectedItems();
       
        checkComboBox.SetText(GetSelectedItemsText(selectedItems));
    }
    function SynchronizeListBoxValues(dropDown, args) {
        checkListBox.UnselectAll();
        var texts = dropDown.GetText().split(textSeparator);
        var values = GetValuesByTexts(texts);
        checkListBox.SelectValues(values);
        UpdateSelectAllItemState();
        UpdateText(); // for remove non-existing texts
    }
    function GetSelectedItemsText(items) {
        var texts = [];
        for (var i = 0; i < items.length; i++)
            //if (items[i].index != 0)
             
                //texts.push(items[i].text);

                texts.push(items[i].text.split(";",1));
        return texts.join(textSeparator);
    }
    function GetValuesByTexts(texts) {
        var actualValues = [];
        var item;
        for (var i = 0; i < texts.length; i++) {
            item = checkListBox.FindItemByText(texts[i]);
            if (item != null)
                actualValues.push(item.value);
        }
        return actualValues;
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
        <tr><td class="title-form">VISIT ACTUAL </td></tr>
        <tr>

            <td class="cell-newlan cell-backround">

                @Html.DevExpress().ComboBox(Sub(settings)
                                                settings.Name = "cboday"
                                                settings.Properties.Caption = "Day"
                                                For i As Integer = 1 To 31
                                                    settings.Properties.Items.Add(i)
                                                Next
                                                settings.ControlStyle.Font.Size = 7
                                                settings.Properties.CaptionSettings.Position = EditorCaptionPosition.Left
                                                settings.Properties.DropDownStyle = DropDownStyle.DropDownList
                                                settings.SelectedIndex = DateTime.Now.Day - 1
                                                settings.Width = 50
                                                settings.Height = 27
                                            End Sub).GetHtml()
            </td>

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
                                                  settings.ControlStyle.CssClass = "button"
                                                  settings.Text = "Reset"
                                                  settings.Images.Image.Url = "~/Content/Images/reset.png"
                                                  settings.ToolTip = "Reset"
                                                  settings.ClientSideEvents.Click = "do_reset"
                                                  settings.ControlStyle.Font.Size = 7
                                              End Sub).GetHtml()

              
            </td>
            <td class="cell-blank"></td>
            <td class="cell-reset cell-backround">
                @code
                    Dim rep_position As String = ViewData("rep_position")
                    If rep_position <> "AM" Then
                                              
                        Html.DevExpress().Button(Sub(settings)
                                                         settings.Name = "btnrequest"
                                                         settings.ControlStyle.CssClass = "button"
                                                         settings.Text = "Request Verification"
                                                         settings.Images.Image.Url = "~/Content/Images/request.png"
                                                         settings.ToolTip = "Request Verification"
                                                         settings.ClientSideEvents.Click = "function(s, e){ popupControlReqVerification.Show(); }"
                                                         settings.ControlStyle.Font.Size = 7
                                                 End Sub).GetHtml()
                                              
                    End If
               End Code
               
            </td>

            <td class="cell-reset cell-backround">
             
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
            @Html.Action("DataViewPartial", "visitactual")


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

@Html.Partial("~/Views/Visit/Actual/PopupReqVerification.vbhtml")
@Html.Partial("~/Views/Visit/Actual/PopupEdit.vbhtml")


