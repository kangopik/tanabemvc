@If Model = TANABE_MVC.HeaderViewRenderMode.Title Then
    @<div class="templateTitle">
        @Html.ActionLink("PT. Tanabe Indonesia", "Index", "Home") 
    </div>
Else
    If Model = TANABE_MVC.HeaderViewRenderMode.Full Then
        @<div class="headerTop">
            <div class="templateTitle">
                <img src="~/Content/Images/logo.png"/>              
            </div>
            <div class="loginControl">
                @Html.Partial("LogOnPartialView")
            </div>
        </div>
    End If

    @<div class="headerMenu"> 
        @If Model = TANABE_MVC.HeaderViewRenderMode.Menu Then
                @* DXCOMMENT: Configure the header menu *@
    @Html.DevExpress().Menu(Sub(settings)
        settings.Name = "HeaderMenuExpanded"
        settings.ItemAutoWidth = False
        settings.Orientation = Orientation.Vertical
        settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
        settings.Styles.Style.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(0)
    End Sub).BindToXML(HttpContext.Current.Server.MapPath("~/App_Data/TopMenu.xml"), "/items/*").GetHtml()
 
        Else 
                @* DXCOMMENT: Configure the header menu *@
    @Html.DevExpress().Menu(Sub(settings)
        settings.Name = "HeaderMenu"
        settings.ItemAutoWidth = False
        settings.Width = System.Web.UI.WebControls.Unit.Percentage(100)
        settings.Styles.Style.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(0)
        settings.Styles.Style.BorderTop.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
    End Sub).BindToXML(HttpContext.Current.Server.MapPath("~/App_Data/TopMenu.xml"), "/items/*").GetHtml()
 
        End If
    </div>
End If