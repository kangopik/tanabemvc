Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Namespace TANABE_MVC.Models
    Public Class SalesPlanClass
#Region "From View"

        'Public Function GetDataSalesPlan(tdb As SalesPlanEntities, ByVal rep_id As String) As Object
        '    Try


        '        Dim currentDate As DateTime = DateTime.Now
        '        Dim day, month, year As Integer
        '        day = 0
        '        month = currentDate.Month
        '        year = currentDate.Year

        '        Return (From m In tdb.v_visit_plan Select m).Where(Function(w) w.rep_id = rep_id And w.visit_date_plan.Value.Month = month And w.visit_date_plan.Value.Year = year And w.visit_plan_verification_status = 1 And w.visit_date_realization_saved Is Nothing).OrderBy(Function(p) p.visit_date_plan).ToList()

        '    Catch generatedExceptionName As Exception

        '        Throw New NotImplementedException()
        '    End Try

        'End Function

        'Public Function GetDataVisitRealizationRetrieve(tdb As VisitRealizationEntities, ByVal rep_id As String, ByVal month As String, ByVal year As String) As Object
        '    Using context As New VisitRealizationEntities()
        '        Return (From m In tdb.v_visit_plan Select m).Where(Function(w) w.rep_id = rep_id And w.visit_date_plan.Value.Month = month And w.visit_date_plan.Value.Year = year And w.visit_plan_verification_status = 1 And w.visit_date_realization_saved Is Nothing).OrderBy(Function(p) p.visit_date_plan).ToList()

        '    End Using
        'End Function

#End Region

    End Class
End Namespace


