﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Partial Public Class VisitPivotEntities
    Inherits DbContext

    Public Sub New()
        ' MyBase.New("name=VisitPivotEntities")
        MyBase.New(ConfigClass.Config("VisitPivotEntities"))
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub


    Public Overridable Function SP_SELECT_VISIT_PIVOT_REP_DASHBOARD(rep_id As String) As ObjectResult(Of SP_SELECT_VISIT_PIVOT_REP_DASHBOARD_Result)
        Dim rep_idParameter As ObjectParameter = If(rep_id IsNot Nothing, New ObjectParameter("rep_id", rep_id), New ObjectParameter("rep_id", GetType(String)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction(Of SP_SELECT_VISIT_PIVOT_REP_DASHBOARD_Result)("SP_SELECT_VISIT_PIVOT_REP_DASHBOARD", rep_idParameter)
    End Function

End Class
