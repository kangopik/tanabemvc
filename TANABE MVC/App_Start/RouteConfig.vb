Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Class RouteConfig
    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        routes.IgnoreRoute("{resource}.ashx/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        '------------------------------- VISIT -----------------
        routes.MapRoute( _
           name:="VisitPlan_0", _
           url:="Visit/Plan", _
           defaults:=New With {.controller = "VisitPlan", .action = "Index", .id = UrlParameter.Optional} _
        )
        routes.MapRoute( _
           name:="VisitRealization_0", _
           url:="Visit/Realization", _
           defaults:=New With {.controller = "VisitRealization", .action = "Index", .id = UrlParameter.Optional} _
        )
        routes.MapRoute( _
          name:="VisitActual_0", _
          url:="Visit/Actual", _
          defaults:=New With {.controller = "VisitActual", .action = "Index", .id = UrlParameter.Optional} _
       )
        routes.MapRoute( _
          name:="VisitHistory_0", _
          url:="Visit/History", _
          defaults:=New With {.controller = "VisitHistory", .action = "Index", .id = UrlParameter.Optional} _
       )
        '------------------------------- VISIT -----------------

        '------------------------------- VERIFICATION -----------------
        routes.MapRoute( _
          name:="Ver_0", _
          url:="Verification/Visit/Plan", _
          defaults:=New With {.controller = "VerVisitPlan", .action = "Index", .id = UrlParameter.Optional} _
       )
        routes.MapRoute( _
          name:="Ver_2", _
          url:="Verification/Visit/PlanVerificationHistory", _
          defaults:=New With {.controller = "VerPlanHistory", .action = "Index", .id = UrlParameter.Optional} _
       )
        routes.MapRoute( _
          name:="Ver_3", _
          url:="Verification/Visit/Realization", _
          defaults:=New With {.controller = "VerVisitReal", .action = "Index", .id = UrlParameter.Optional} _
       )
        routes.MapRoute( _
          name:="Ver_4", _
          url:="Verification/Visit/RealVerificationHistory", _
          defaults:=New With {.controller = "VerRealHistory", .action = "Index", .id = UrlParameter.Optional} _
       )
        '------------------------------- VERIFICATION -----------------

        routes.MapRoute( _
            name:="VisitOnlyPivotRep", _
            url:="Report/Rep/VisitOnly", _
            defaults:=New With {.controller = "VisitOnlyPivotRep", .action = "index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="VisitProductPivotRep", _
            url:="Report/Rep/VisitProduct", _
            defaults:=New With {.controller = "VisitProductPivotRep", .action = "index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="SalesPivotRep", _
            url:="Report/Rep/SalesUser", _
            defaults:=New With {.controller = "SalesPivotRep", .action = "index", .id = UrlParameter.Optional} _
        )

        '------------------------------- MASTER -----------------
        routes.MapRoute( _
            name:="Mst_0", _
            url:="Master/AuditVisit", _
            defaults:=New With {.controller = "AuditVisitMonthlyController", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="Mst_1", _
            url:="Master/BO", _
            defaults:=New With {.controller = "MasterBo", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="Mst_2", _
            url:="Master/Doctor", _
            defaults:=New With {.controller = "MasterDoctor", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="Mst_3", _
            url:="Master/Product", _
            defaults:=New With {.controller = "MasterProduct", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="Mst_4", _
            url:="Master/Regional", _
            defaults:=New With {.controller = "MasterRegional", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="Mst_5", _
            url:="Master/Representative", _
            defaults:=New With {.controller = "MasterRepresentative", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="Mst_6", _
            url:="Master/SBO", _
            defaults:=New With {.controller = "MasterSbo", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="Mst_7", _
            url:="Master/Visit", _
            defaults:=New With {.controller = "MasterVisit", .action = "Index", .id = UrlParameter.Optional} _
        )
        '------------------------------- MASTER -----------------
        

        '------------------------------- SALES -----------------
        routes.MapRoute( _
            name:="Sls_0", _
            url:="Sales/Actual", _
            defaults:=New With {.controller = "SalesActual", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="Sls_1", _
            url:="Sales/History", _
            defaults:=New With {.controller = "SalesHistory", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="Sls_2", _
            url:="Sales/Plan", _
            defaults:=New With {.controller = "SalesPlan", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="Sls_3", _
            url:="Sales/Realization", _
            defaults:=New With {.controller = "SalesRealization", .action = "Index", .id = UrlParameter.Optional} _
        )
        '------------------------------- SALES -----------------

        '------------------------------- VERIFICATION SALES -----------------
        routes.MapRoute( _
            name:="SlsVer_0", _
            url:="Verification/Sales/PlanHistory", _
            defaults:=New With {.controller = "SalesPlanHistoryVerification", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="SlsVer_1", _
            url:="Verification/Sales/Plan", _
            defaults:=New With {.controller = "SalesPlanVerification", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="SlsVer_2", _
            url:="Verification/Sales/RealHistory", _
            defaults:=New With {.controller = "SalesRealHistoryVerification", .action = "Index", .id = UrlParameter.Optional} _
        )

        routes.MapRoute( _
            name:="SlsVer_3", _
            url:="Verification/Sales/Real", _
            defaults:=New With {.controller = "SalesRealVerification", .action = "Index", .id = UrlParameter.Optional} _
        )
        '------------------------------- VERIFICATION SALES -----------------

        routes.MapRoute( _
            name:="Default", _
            url:="{controller}/{action}/{id}", _
            defaults:=New With {.controller = "Login", .action = "Index", .id = UrlParameter.Optional} _
        )

        
    End Sub
End Class