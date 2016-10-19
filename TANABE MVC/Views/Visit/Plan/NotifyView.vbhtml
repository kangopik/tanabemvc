@Html.DevExpress().PopupControl(
    Sub(settings)
            settings.Name = "PopupControlNotify"
            'settings.CallbackRouteValues = New With {.Controller = "visitplan", .Action = "Notify"}
            settings.AllowResize = True
            settings.ShowHeader = True
            'settings.ShowOnPageLoad = True
            settings.AllowDragging = True
            settings.CloseAction = CloseAction.OuterMouseClick
            settings.CloseOnEscape = True
            settings.Modal = True
            'settings.Width = Unit.Pixel(600)
            'settings.Height = Unit.Pixel(100)
            settings.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
            settings.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
            settings.SetHeaderTemplateContent(Sub()
                                                      ViewContext.Writer.Write("<div style='font-size:small;'>Information</div>")
                                              End Sub)

            settings.SetContent(Sub()
                                        ViewContext.Writer.Write(ViewData("msg"))
                                End Sub)
            settings.CloseAnimationType = AnimationType.Slide
            settings.ShowCloseButton = True
            settings.ShowShadow = True

    End Sub).GetHtml()