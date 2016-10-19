@code 
    If ViewBag.MessageError <> "" Then
        Html.DevExpress().PopupControl(Sub(settings)
                                               settings.Name = "PopupControl"
                                               settings.AllowResize = True
                                               settings.ShowHeader = True
                                               settings.ShowOnPageLoad = False
                                               settings.AllowDragging = True
                                               settings.CloseAction = CloseAction.OuterMouseClick
                                               settings.CloseOnEscape = False
                                               settings.Modal = True
                                               settings.ShowOnPageLoad = True
                                               settings.SetContent(Sub()
                                                                           ViewContext.Writer.Write(ViewBag.MessageError)
                                                                   End Sub)
                                       End Sub).GetHtml()

    End If
End Code
