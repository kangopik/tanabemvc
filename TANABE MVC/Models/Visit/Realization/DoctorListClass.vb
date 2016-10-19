
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data.Entity.Core.Objects

Namespace TANABE_MVC.Models
    Public Class DoctorListClass
        Public Function GetDataDoctorList(tdb As DoctorListEntities, ByVal rep_id As String, ByVal rep_position As String) As Object
            Using context As New DoctorListEntities()
                Return context.SP_SELECT_DOCTOR_LIST(rep_id, rep_position).ToList()
            End Using
        End Function
    End Class
End Namespace


