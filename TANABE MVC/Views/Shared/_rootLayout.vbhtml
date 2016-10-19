<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no, maximum-scale=1.0, minimum-scale=1.0" />
    <title>MEDIVISIT | Dashboard</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />

    
    @Html.DevExpress().GetStyleSheets(
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView}, 
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.PivotGrid}, 
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.HtmlEditor}, 
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors}, 
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, 
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Chart}, 
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Report},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Scheduler},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.TreeList},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.Spreadsheet},
    New StyleSheet With {.ExtensionSuite = ExtensionSuite.SpellChecker})
@Html.DevExpress().GetScripts(
    New Script With {.ExtensionSuite = ExtensionSuite.GridView}, 
    New Script With {.ExtensionSuite = ExtensionSuite.PivotGrid}, 
    New Script With {.ExtensionSuite = ExtensionSuite.HtmlEditor}, 
    New Script With {.ExtensionSuite = ExtensionSuite.Editors}, 
    New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, 
    New Script With {.ExtensionSuite = ExtensionSuite.Chart}, 
    New Script With {.ExtensionSuite = ExtensionSuite.Report},
    New Script With {.ExtensionSuite = ExtensionSuite.Scheduler},
    New Script With {.ExtensionSuite = ExtensionSuite.TreeList},
    New Script With {.ExtensionSuite = ExtensionSuite.Spreadsheet},
    New Script With {.ExtensionSuite = ExtensionSuite.SpellChecker})
</head>
<body>
    @Html.DevExpress().Panel(Sub(settings)
                                 settings.Name = "HeaderPane"
                                 settings.FixedPosition = PanelFixedPosition.WindowTop
                                 settings.Collapsible = True
                                 settings.SettingsAdaptivity.CollapseAtWindowInnerWidth = 500
                                 settings.ControlStyle.CssClass = "headerPane"
                                 settings.Styles.Panel.CssClass = "panel"
                                 settings.Styles.ExpandBar.CssClass = "bar"
                                 settings.SetContent(Sub() Html.RenderPartial("HeaderPartialView", TANABE_MVC.HeaderViewRenderMode.Full))
                                 settings.SetExpandedPanelTemplateContent(Sub(c) Html.RenderPartial("HeaderPartialView", TANABE_MVC.HeaderViewRenderMode.Menu))
                                 settings.SetExpandBarTemplateContent(Sub(c) Html.RenderPartial("HeaderPartialView", TANABE_MVC.HeaderViewRenderMode.Title))
                             End Sub).GetHtml()

    @Html.DevExpress().Panel(Sub(settings)
        settings.Name = "MainPane"
        settings.ControlStyle.CssClass = "mainContentPane"
        settings.SetContent(RenderBody().ToHtmlString())
    End Sub).GetHtml()


</body>
</html>