@code
    Dim user_name As String = TryCast(Session("nama_lengkap"), [String])
    If user_name <> "" Then
        Html.DevExpress().Label(Sub(settings)
                                        settings.Name = "Label"
                                        settings.Text = UCase(user_name)
                                       
                                End Sub).GetHtml()

        ViewContext.Writer.Write("    |    ")
        @Html.ActionLink("Logout", "index", "login")


    End If
End Code
