    @* DXCOMMENT: Configure GridView *@
    @Html.DevExpress().GridView(Sub(settings)
        settings.Name = "GridView"
        settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartialView"}
        settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
        settings.SettingsPager.PageSize = 50
        settings.ControlStyle.Paddings.Padding = System.Web.UI.WebControls.Unit.Pixel(0)
        settings.ControlStyle.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(0)
        settings.ControlStyle.BorderBottom.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
        
        ' DXCOMMENT: Specify the grid's key field name and define grid columns in accordance with data model fields
        settings.KeyFieldName = "CustomerID"
        settings.Columns.Add("ContactName")
        settings.Columns.Add("CompanyName")
        settings.Columns.Add("ContactTitle")
        settings.Columns.Add("City")
        settings.Columns.Add("Phone")
    End Sub).Bind(Model).GetHtml()
