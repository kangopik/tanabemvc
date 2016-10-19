Imports DevExpress.Web.Mvc

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Public Function Index() As ActionResult
        'ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!"
        ' DXCOMMENT: Pass a data model for GridView
        'Return View(NorthwindDataProvider.GetCustomers())

        Dim username As String = UCase(TryCast(Session("username"), [String]))
        If username = "" Then

            Return RedirectToAction("index", "login")
        Else
            ViewBag.UserName = UCase(TryCast(Session("username"), [String]))
            Return View("~/Views/Home/ChartView.vbhtml")
        End If

        'Return View("ChartView")
    End Function

    <ValidateInput(False)> _
    Public Function PivotGridPartial() As ActionResult
        Dim model = New Object() {}
        Return PartialView("_PivotGridPartial", model)
    End Function

    <ValidateInput(False)> _
    Public Function PivotGrid1Partial() As ActionResult
        Dim model = New Object() {}
        Return PartialView("_PivotGrid1Partial", model)
    End Function
End Class

Public Enum HeaderViewRenderMode
    Full
    Menu
    Title
End Enum