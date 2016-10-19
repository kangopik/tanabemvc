Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Collections
Imports DevExpressMvcApplication1.Models
Imports DevExpress.Web.Mvc
Imports Helpers
Imports DevExpress.XtraPivotGrid

Namespace DevExpressMvcApplication1.Controllers
    Public Class HomeController
        Inherits Controller
        Public Function Index() As ActionResult
            ViewBag.PivotSettings = CreatePivotSettings()
            Return View(GetSalesPersonData())
        End Function

        Public Function PivotGridPartial() As ActionResult
            ViewBag.PivotSettings = CreatePivotSettings()
            Return PartialView("PivotGridPartial", GetSalesPersonData())
        End Function
        Public Function PivotGridCustomCallback(CallbackInfo As String, LayoutName As String) As ActionResult
            Dim settings As PivotGridSettings = CreatePivotSettings()
            If String.IsNullOrEmpty(LayoutName) Then
                LayoutName = "PivotLayout"
            End If
            If CallbackInfo = "ClearFilter" Then
                settings.BeforeGetCallbackResult = Function(sender, e)
                                                                   Dim field = DirectCast(sender, MVCxPivotGrid).Fields("ProductName")
                                                                   Dim values As Object() = field.GetUniqueValues()
                                                                   field.FilterValues.ValuesIncluded = values

                                                               End Function
            ElseIf CallbackInfo = "SaveLayout" Then
                settings.AfterPerformCallback = Function(sender, e)
                                                                Layout.SaveLayout(DirectCast(sender, MVCxPivotGrid).SaveLayoutToString(), LayoutName)

                                                            End Function
            ElseIf CallbackInfo = "LoadLayout" AndAlso Not String.IsNullOrEmpty(Layout.LoadLayout(LayoutName)) Then
                settings.BeforeGetCallbackResult = Function(sender, e)
                                                                   DirectCast(sender, MVCxPivotGrid).LoadLayoutFromString(Layout.LoadLayout(LayoutName), DevExpress.Web.ASPxPivotGrid.PivotGridWebOptionsLayout.DefaultLayout)

                                                               End Function
            End If
            ViewBag.PivotSettings = settings
            Return PartialView("PivotGridPartial", GetSalesPersonData())


        End Function

        Public Function ChartPartial() As ActionResult
            Dim chartModel = PivotGridExtension.GetDataObject(CreatePivotSettings(), GetSalesPersonData())
            Return PartialView("ChartPartial", chartModel)
        End Function
        Public Function PivotChartInegration() As ActionResult
            Return Me.View("PivotChartInegration", GetSalesPersonData())
        End Function

        Private Shared Function CreatePivotSettings() As PivotGridSettings
            Dim settings As New PivotGridSettings()
            settings.Name = "pivotGrid"
            settings.CallbackRouteValues = New With { _
                Key .Controller = "Home", _
                Key .Action = "PivotGridPartial" _
            }
            settings.CustomActionRouteValues = New With { _
                Key .Controller = "Home", _
                Key .Action = "PivotGridCustomCallback" _
            }
            settings.OptionsView.ShowHorizontalScrollBar = True
            settings.OptionsChartDataSource.ProvideDataByColumns = False
            settings.Width = New System.Web.UI.WebControls.Unit(90, System.Web.UI.WebControls.UnitType.Percentage)

            settings.ClientSideEvents.BeginCallback = "OnBeforePivotGridCallback"
            settings.ClientSideEvents.EndCallback = "UpdateChart"


            settings.Groups.Add("Order Date")
            settings.Fields.Add("Country", PivotArea.FilterArea).ID = "fieldCountry"
            settings.Fields.Add("City", PivotArea.FilterArea).ID = "fieldCity"
            settings.Fields.Add(Function(field)
                                             field.Area = PivotArea.ColumnArea
                                             field.FieldName = "OrderDate"
                                             field.GroupInterval = PivotGroupInterval.DateYear
                                             field.Caption = "Year"
                                             field.GroupIndex = 0
                                             field.ID = "fieldYear"

                                         End Function)
            settings.Fields.Add(Function(field)
                                             field.Area = PivotArea.ColumnArea
                                             field.FieldName = "OrderDate"
                                             field.GroupInterval = PivotGroupInterval.DateMonth
                                             field.Caption = "Month"
                                             field.GroupIndex = 0
                                             field.InnerGroupIndex = 1
                                             field.ID = "fieldMonth"

                                         End Function)

            settings.Fields.Add(Function(field)
                                             field.Area = PivotArea.DataArea
                                             field.FieldName = "Quantity"
                                             field.Visible = False
                                             field.ID = "fieldQuantity"

                                         End Function)
            settings.Fields.Add(Function(field)
                                             field.Area = PivotArea.DataArea
                                             field.FieldName = "UnitPrice"
                                             field.Visible = False
                                             field.ID = "fieldUnitPrice"

                                         End Function)
            settings.Fields.Add(Function(field)
                                             field.Area = PivotArea.DataArea
                                             field.FieldName = "Amount"
                                             field.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
                                             field.UnboundExpression = "[UnitPrice]*[Quantity]"
                                             field.Visible = True
                                             field.ID = "fieldAmount"

                                         End Function)
            settings.Fields.Add("ProductName", PivotArea.RowArea).ID = "fieldProductName"
            settings.PreRender = Function(sender, e)
                                              DirectCast(sender, MVCxPivotGrid).CollapseAll()
                                              Dim field = DirectCast(sender, MVCxPivotGrid).Fields("ProductName")
                                              Dim values As Object() = field.GetUniqueValues()

                                              field.FilterValues.ValuesIncluded = values.Where(Function(name) name.ToString().StartsWith("N")).ToArray()

                                          End Function


            Return settings
        End Function

        Public Shared Function GetSalesPersonData() As IEnumerable
            Dim dc As New NorthwindDataContext()
            Return From _Invoice In dc.Invoices_Invoice
        End Function
    End Class

End Namespace
