@Code
    Layout = "~/Views/Shared/_rootLayout.vbhtml"
End Code

@code
    Dim user_name As String = TryCast(Session("username"), [String])
    
    If user_name <> "" Then
        Html.DevExpress().Panel(Sub(settings)
                                        settings.Name = "LeftPane"
                                        settings.Width = 170
                                        settings.FixedPosition = PanelFixedPosition.WindowLeft
                                        settings.Collapsible = True
                                        'settings.SettingsAdaptivity.CollapseAtWindowInnerWidth = 1023
                                        settings.ControlStyle.CssClass = "leftPane"
                                        settings.Styles.Panel.CssClass = "panel"
                                        settings.SettingsAdaptivity.CollapseAtWindowInnerWidth = 20000
                                  
                                        settings.SetContent(Sub() Html.RenderPartial("ContentLeftPartialView"))
                                End Sub).GetHtml()
    End If
    
End Code
   

    <div class="contentPane">
        @RenderBody()
    </div>