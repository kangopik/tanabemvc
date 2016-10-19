Imports System.Data.SqlClient
Imports DevExpress.Web
Imports DevExpress.Web.Mvc

Public Class ConfigClass
    Public Shared sConnstring As String
    Shared Function Config(ByVal entity As String) As String
        Dim metadata As String = ""
        Dim conn As String = ConfigurationManager.ConnectionStrings("conn").ConnectionString
        Dim conn_produksi As String = ConfigurationManager.ConnectionStrings("conn_produksi").ConnectionString

        If entity = "LoginEntities" Then
            metadata = "metadata=res://*/Models.Login.LoginModel.csdl|res://*/Models.Login.LoginModel.ssdl|res://*/Models.Login.LoginModel.msl;"
            Return metadata & conn_produksi
        End If
        Dim res As String = ""
        Select Case entity
            Case "VisitPlanEntities" : metadata = "metadata=res://*/Models.Visit.Plan.VisitPlanModel.csdl|res://*/Models.Visit.Plan.VisitPlanModel.ssdl|res://*/Models.Visit.Plan.VisitPlanModel.msl;"
            Case "VisitPlanAddnewEntities" : metadata = "metadata=res://*/Models.Visit.Plan.VisitPlanAddNewModel.csdl|res://*/Models.Visit.Plan.VisitPlanAddNewModel.ssdl|res://*/Models.Visit.Plan.VisitPlanAddNewModel.msl;"
            Case "VisitPlanGetNewVisitNumberEntities" : metadata = "metadata=res://*/Models.Visit.Plan.VisitPlanGetNewVisitNumberModel.csdl|res://*/Models.Visit.Plan.VisitPlanGetNewVisitNumberModel.ssdl|res://*/Models.Visit.Plan.VisitPlanGetNewVisitNumberModel.msl;"
            Case "VisitPivotEntities" : metadata = "metadata=res://*/Models.Dashboard.VisitPivotModel.csdl|res://*/Models.Dashboard.VisitPivotModel.ssdl|res://*/Models.Dashboard.VisitPivotModel.msl;"
                'Case "LoginEntities" : metadata = "metadata=res://*/Models.Login.LoginModel.csdl|res://*/Models.Login.LoginModel.ssdl|res://*/Models.Login.LoginModel.msl;"
            Case "RepEntities" : metadata = "metadata=res://*/Models.Login.RepModel.csdl|res://*/Models.Login.RepModel.ssdl|res://*/Models.Login.RepModel.msl;"
            Case "VisitPlanAddNewTransactionEntities" : metadata = "metadata=res://*/Models.Visit.Plan.VisitPlanAddNewTransactionModel.csdl|res://*/Models.Visit.Plan.VisitPlanAddNewTransactionModel.ssdl|res://*/Models.Visit.Plan.VisitPlanAddNewTransactionModel.msl;"
            Case "VisitRealizationEntities" : metadata = "metadata=res://*/Models.Visit.Realization.VisitRealizationModel.csdl|res://*/Models.Visit.Realization.VisitRealizationModel.ssdl|res://*/Models.Visit.Realization.VisitRealizationModel.msl;"
            Case "VisitActualEntities" : metadata = "metadata=res://*/Models.Visit.Actual.VisitActualModel.csdl|res://*/Models.Visit.Actual.VisitActualModel.ssdl|res://*/Models.Visit.Actual.VisitActualModel.msl;"

            Case "VisitHistoryEntities" : metadata = "metadata=res://*/Models.Visit.History.VisitHistoryModel.csdl|res://*/Models.Visit.History.VisitHistoryModel.ssdl|res://*/Models.Visit.History.VisitHistoryModel.msl;"

        End Select
        res = metadata & conn
        Return res
    End Function

    Shared Function dbConfig() As SqlConnection
        Dim ConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("conn").ConnectionString
        Dim conn As New SqlConnection(ConnectionString)
        Return conn
    End Function

    Shared Function Get_Constring()
        'sConnstring = "data source=localhost;initial catalog=mva_new;integrated security=True;user id=sa;Password=Password!"
        sConnstring = "data source=192.168.0.11;initial catalog=mva_new;user id=sa;password=Kerukans;MultipleActiveResultSets=True;"
        Return sConnstring
    End Function

    Shared Function RealizationButtonVisibleCriteria(ByVal grid As MVCxGridView, ByVal visibleIndex As Integer) As Boolean
        Dim currentDate As DateTime = DateTime.Now
        Dim curr_month As Int32 = currentDate.Month
        Dim curr_year As Int32 = currentDate.Year
        Dim row As Object = grid.GetRow(visibleIndex)
        Dim vdp As Int32 = CDate(grid.GetRowValues(visibleIndex, "visit_date_plan")).ToString("dd")
        Dim vMonth As Int32 = CDate(grid.GetRowValues(visibleIndex, "visit_date_plan")).ToString("MM")
        Dim vYear As Int32 = CDate(grid.GetRowValues(visibleIndex, "visit_date_plan")).ToString("yyyy")


        If vYear = curr_year Then
            If vMonth < curr_month Then
                Return True
            End If

            If vMonth = curr_month Then
                If vdp <= currentDate.Day Then
                    Return True
                Else
                    Return False
                End If

                'Return (vdp <= currentDate.Day)
            End If
        End If


        If vYear < curr_year Then
            Return True
        End If

    End Function
End Class


